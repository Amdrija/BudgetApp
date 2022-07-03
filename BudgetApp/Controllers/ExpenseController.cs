using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Threading.Tasks;
using BudgetApp.Apllication;
using BudgetApp.Apllication.Category.AddCategory;
using BudgetApp.Apllication.Category.AddDefaultCategories;
using BudgetApp.Apllication.Category.DeleteCategory;
using BudgetApp.Apllication.Category.EditCategory;
using BudgetApp.Apllication.Category.GetCategories;
using BudgetApp.Apllication.Category.GetCategory;
using BudgetApp.Apllication.Expense.AddExpense;
using BudgetApp.Apllication.Expense.DeleteExpense;
using BudgetApp.Apllication.Expense.EditExpense;
using BudgetApp.Apllication.Expense.GetExpense;
using BudgetApp.Apllication.Expense.GraphSearch;
using BudgetApp.Apllication.Expense.Search;
using BudgetApp.Domain.Category;
using BudgetApp.Domain.Expense;
using BudgetApp.Exceptions;
using BudgetApp.Requests;
using Microsoft.Extensions.Configuration;

namespace BudgetApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class ExpenseController : ControllerBase
    {
        private readonly ILogger<ExpenseController> _logger;

        public ExpenseController(ILogger<ExpenseController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public async Task<List<Expense>> AddExpenses(
            [FromServices] IUseCase<List<AddExpenseRequest>, AddExpenseResponse> useCase,
            [FromBody] List<ModifyExpenseAPIRequest> request)
        {
            if (!request.Any())
            {
                throw new CannotAddZeroExpensesException();
            }
            
            var response = await useCase.ExecuteAsync(
                request.Select(
                    e => new AddExpenseRequest()
                    {
                        Amount = e.Amount,
                        CategoryId = e.CategoryId,
                        Date = e.Date,
                        Description = e.Decription,
                        Name = e.Name,
                        UserId = this.HttpContext.User.Identity.Name
                    }).ToList());

            return response.Expenses;
        }

        [HttpPost("{id}")]
        public async Task<Expense> EditExpense(
            [FromServices] IUseCase<EditExpenseRequest, EditExpenseResponse> useCase,
            [FromRoute] Guid id,
            [FromBody] ModifyExpenseAPIRequest request)
        {
            var response = await useCase.ExecuteAsync(
                new EditExpenseRequest()
                {
                    Amount = request.Amount,
                    CategoryId = request.CategoryId,
                    Date = request.Date,
                    Description = request.Decription,
                    Id = id,
                    Name = request.Name,
                    UserId = this.HttpContext.User.Identity.Name
                });

            return response.Expense;
        }
        
        [HttpGet("{id}")]
        public async Task<Expense> GetExpense(
            [FromServices] IUseCase<GetExpenseRequest, GetExpenseResponse> useCase,
            [FromRoute] Guid id)
        {
            var response = await useCase.ExecuteAsync(
                new GetExpenseRequest()
                {
                    Id = id,
                    UserId = this.HttpContext.User.Identity.Name
                });

            return response.Expense;
        }
        
        [HttpDelete("{id}")]
        public async Task DeleteExpense(
            [FromServices] IUseCase<DeleteExpenseRequest, DeleteExpenseResponse> useCase,
            [FromRoute] Guid id)
        { 
            await useCase.ExecuteAsync(
                new DeleteExpenseRequest()
                {
                    Id = id,
                    UserId = this.HttpContext.User.Identity.Name
                });
        }

        [HttpGet("graph")]
        public Task<GraphSearchResponse> GetGraph(
            [FromServices] IUseCase<GraphSearchRequest, GraphSearchResponse> useCase,
            [FromQuery] GraphSearchAPIRequest request)
        {
            return useCase.ExecuteAsync(new GraphSearchRequest()
            {
                CategoryIds = request.CategoryIds,
                StartDate = request.StartDate == null ? null : TimeZoneInfo.ConvertTimeToUtc(request.StartDate.Value),
                EndDate = request.EndDate == null ? null : TimeZoneInfo.ConvertTimeToUtc(request.EndDate.Value),
                UserId = this.HttpContext.User.Identity.Name
            });
        }
        
        [HttpGet()]
        public async Task<List<Expense>> Get(
            [FromServices] IUseCase<SearchRequest, SearchResponse> useCase,
            [FromQuery] SearchAPIRequest request)
        {
            var response = await useCase.ExecuteAsync(new SearchRequest()
            {
                CategoryIds = request.CategoryIds,
                StartDate = request.StartDate == null ? null : TimeZoneInfo.ConvertTimeToUtc(request.StartDate.Value),
                EndDate = request.EndDate == null ? null : TimeZoneInfo.ConvertTimeToUtc(request.EndDate.Value),
                UserId = this.HttpContext.User.Identity.Name,
                MinimumAmount = request.MinimumAmount,
                MaximumAmount = request.MaximumAmount
            });

            return response.Expenses;
        }
    }
}

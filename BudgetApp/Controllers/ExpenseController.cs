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
    }
}

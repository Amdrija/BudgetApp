using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetApp.Apllication.Category.Interfaces;
using BudgetApp.Apllication.Expense.Interfaces;

namespace BudgetApp.Apllication.Expense.AddExpense
{
    public class AddExpenseUseCase : IUseCase<List<AddExpenseRequest>, AddExpenseResponse>
    {
        private readonly IExpenseRepository repository;

        public AddExpenseUseCase(IExpenseRepository repository)
        {
            this.repository = repository;
        }

        public async Task<AddExpenseResponse> ExecuteAsync(List<AddExpenseRequest> request)
        {
            return new AddExpenseResponse()
            {
                Expenses = await this.repository.AddExpensesAsync(
                    request.Select(
                               e => new Domain.Expense.Expense()
                               {
                                   Date = e.Date,
                                   Amount = e.Amount,
                                   CategoryId = e.CategoryId,
                                   Description = e.Description,
                                   Name = e.Name,
                                   UserId = e.UserId
                               })
                           .ToList())
            };
        }
    }
}
using System;
using System.Threading.Tasks;
using BudgetApp.Apllication.Expense.Interfaces;

namespace BudgetApp.Apllication.Expense.EditExpense
{
    public class EditExpenseUseCase : IUseCase<EditExpenseRequest, EditExpenseResponse>
    {
        private readonly IExpenseRepository repository;

        public EditExpenseUseCase(IExpenseRepository repository)
        {
            this.repository = repository;
        }

        public async Task<EditExpenseResponse> ExecuteAsync(EditExpenseRequest request)
        {
            var expense = await this.repository.GetOneAsync(request.Id, request.UserId);
            expense.Amount = request.Amount;
            expense.Date = request.Date;
            expense.Description = request.Description;
            expense.Name = request.Name;
            expense.CategoryId = request.CategoryId;
            
            return new EditExpenseResponse()
            {
                Expense = await this.repository.EditExpenseAsync(expense)
            };
        }
    }
}
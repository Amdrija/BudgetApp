using System;
using System.Threading.Tasks;
using BudgetApp.Apllication.Expense.Interfaces;

namespace BudgetApp.Apllication.Expense.DeleteExpense
{
    public class DeleteExpenseUseCase : IUseCase<DeleteExpenseRequest, DeleteExpenseResponse>
    {
        private readonly IExpenseRepository repository;

        public DeleteExpenseUseCase(IExpenseRepository repository)
        {
            this.repository = repository;
        }

        public async Task<DeleteExpenseResponse> ExecuteAsync(DeleteExpenseRequest request)
        {
            await this.repository.DeleteExpenseAsync(
                new Domain.Expense.Expense()
                {
                    Id = request.Id,
                    UserId = request.UserId
                });
            
            return new DeleteExpenseResponse();
        }
    }
}
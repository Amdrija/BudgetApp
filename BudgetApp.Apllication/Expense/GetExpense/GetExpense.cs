using System;
using System.Threading.Tasks;
using BudgetApp.Apllication.Expense.Interfaces;

namespace BudgetApp.Apllication.Expense.GetExpense
{
    public class GetExpenseUseCase : IUseCase<GetExpenseRequest, GetExpenseResponse>
    {
        private readonly IExpenseRepository repository;

        public GetExpenseUseCase(IExpenseRepository repository)
        {
            this.repository = repository;
        }

        public async Task<GetExpenseResponse> ExecuteAsync(GetExpenseRequest request)
        {
            return new GetExpenseResponse()
            {
                Expense = await this.repository.GetOneAsync(request.Id, request.UserId)
            };
        }
    }
}
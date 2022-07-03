using System;

namespace BudgetApp.Apllication.Expense.Exceptions
{
    public class ExpenseNotFoundException : NotFoundException
    {
        public ExpenseNotFoundException(Guid id, string userId) : base($"Expense with Id: {id}, UserId: {userId} not found.") { }
    }
}
using System;

namespace BudgetApp.Exceptions
{
    public class CannotAddZeroExpensesException : ApplicationException
    {
        public CannotAddZeroExpensesException() : base("You have to add at least 1 expense")
        {
            
        }
    }
}
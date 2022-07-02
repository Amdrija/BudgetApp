using System;

namespace BudgetApp.Apllication
{
    public class ApplicationException : Exception
    {
        public ApplicationException(string message) : base(message) { }

        public ApplicationException(string message, Exception inner) : base(message, inner) { }
    }
}
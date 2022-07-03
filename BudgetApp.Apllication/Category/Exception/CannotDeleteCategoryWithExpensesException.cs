namespace BudgetApp.Apllication.Category.Exception
{
    public class CannotDeleteCategoryWithExpensesException : ApplicationException
    {
        public CannotDeleteCategoryWithExpensesException() : base("Cannot delete a category that has expenses. Delete the expenses first.") { }
    }
}
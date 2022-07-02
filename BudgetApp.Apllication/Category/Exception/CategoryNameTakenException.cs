namespace BudgetApp.Apllication.Category.Exception
{
    public class CategoryNameTakenException : ApplicationException
    {
        public CategoryNameTakenException(string name) : base($"The name of category: {name} is taken.") { }
    }
}
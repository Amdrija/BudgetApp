namespace BudgetApp.Domain.Category.Exceptions
{
    public class CategoryColorFormatException : DomainException
    {
        public CategoryColorFormatException() : base("Category color should be in hexadecimal format, eg. #F123AB") { }
    }
}
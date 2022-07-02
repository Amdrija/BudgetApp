using BudgetApp.Apllication.Category.AddCategory;
using BudgetApp.Domain.Category;
using BudgetApp.Requests;
using FluentValidation;

namespace BudgetApp.Validators
{
    public class AddCategoryAPIReqeustValidator : AbstractValidator<AddCategoryAPIRequest>
    {
        public AddCategoryAPIReqeustValidator()
        {
            this.RuleFor(r => r.Color).NotEmpty().Must(Category.IsColorHex);
            this.RuleFor(r => r.Name).NotEmpty();
        }
    }
}
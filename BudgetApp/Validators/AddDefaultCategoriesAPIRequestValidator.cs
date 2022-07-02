using BudgetApp.Requests;
using FluentValidation;

namespace BudgetApp.Validators
{
    public class AddDefaultCategoriesAPIRequestValidator : AbstractValidator<AddDefaultCategoriesAPIRequest>
    {
        public AddDefaultCategoriesAPIRequestValidator()
        {
            this.RuleFor(r => r.Secret).NotEmpty();
            this.RuleFor(r => r.UserId).NotEmpty();
        }
    }
}
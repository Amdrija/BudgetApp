using BudgetApp.Requests;
using FluentValidation;

namespace BudgetApp.Validators
{
    public class ModifyExpenseAPIRequestValidator : AbstractValidator<ModifyExpenseAPIRequest>
    {
        public ModifyExpenseAPIRequestValidator()
        {
            this.RuleFor(r => r.Name).NotEmpty();
            this.RuleFor(r => r.CategoryId).NotEmpty();
            this.RuleFor(r => r.Amount).NotEmpty();
            this.RuleFor(r => r.Date).NotEmpty();
        }
    }
}
using System;

namespace BudgetApp.Apllication.Category.GetCategory
{
    public class GetCategoryRequest
    {
        public Guid Id { get; set; }

        public string UserId { get; set; }
    }
}
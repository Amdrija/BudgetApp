using System;

namespace BudgetApp.Apllication.Category.DeleteCategory
{
    public class DeleteCategoryRequest
    {
        public Guid Id { get; set; }

        public string UserId { get; set; }
    }
}
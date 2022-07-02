using System;

namespace BudgetApp.Apllication.Category.EditCategory
{
    public class EditCategoryRequest
    {
        public Guid Id { get; set; }
        
        public string Name { get; set; }

        public string Color { get; set; }

        public string UserId { get; set; }
    }
}
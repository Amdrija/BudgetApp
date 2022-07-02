using System;

namespace BudgetApp.Apllication.Category.Exception
{
    public class CategoryNotFoundException: NotFoundException
    {
        public CategoryNotFoundException(Guid id, string userId) : base($"Category with Id: {id}, UserId: {userId} not found.") { }
    }
}
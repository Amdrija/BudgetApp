using System.Collections.Generic;

namespace BudgetApp.Domain.Category
{
    public class DefaultCategories
    {
        public static List<Category> Get(string userId)
        {
            List<Domain.Category.Category> categories = new();
            
            categories.Add(new Domain.Category.Category()
            {
                UserId = userId,
                Color = "#55DDE0",
                Name = "Становање"
            });
            
            categories.Add(new Domain.Category.Category()
            {
                UserId = userId,
                Color = "#33658A",
                Name = "Превоз"
            });
            
            categories.Add(new Domain.Category.Category()
            {
                UserId = userId,
                Color = "#F26419",
                Name = "Храна"
            });
            
            categories.Add(new Domain.Category.Category()
            {
                UserId = userId,
                Color = "#F6AE2D",
                Name = "Комуналије"
            });
            
            categories.Add(new Domain.Category.Category()
            {
                UserId = userId,
                Color = "#401F3E",
                Name = "Одећа"
            });
            
            categories.Add(new Domain.Category.Category()
            {
                UserId = userId,
                Color = "#453F78",
                Name = "Здравље"
            });
            
            categories.Add(new Domain.Category.Category()
            {
                UserId = userId,
                Color = "#759AAB",
                Name = "Кућне потрепштине"
            });

            categories.Add(new Domain.Category.Category()
            {
                UserId = userId,
                Color = "#A53860",
                Name = "Лични трошкови"
            });
            
            categories.Add(new Domain.Category.Category()
            {
                UserId = userId,
                Color = "#61C9A8",
                Name = "Образовање"
            });
            
            categories.Add(new Domain.Category.Category()
            {
                UserId = userId,
                Color = "#7BF1A8",
                Name = "Забава"
            });
            
            categories.Add(new Domain.Category.Category()
            {
                UserId = userId,
                Color = "#FFD6E0",
                Name = "Поклони и донације"
            });
            
            categories.Add(new Domain.Category.Category()
            {
                UserId = userId,
                Color = "#FFEF9F",
                Name = "Дуговања"
            });
            
            categories.Add(new Domain.Category.Category()
            {
                UserId = userId,
                Color = "#90F1EF",
                Name = "Инвестиције"
            });
            
            categories.Add(new Domain.Category.Category()
            {
                UserId = userId,
                Color = "#C1FBA4",
                Name = "Плата"
            });
            
            categories.Add(new Domain.Category.Category()
            {
                UserId = userId,
                Color = "#2B2D42",
                Name = "Уштеђевина"
            });
            
            categories.Add(new Domain.Category.Category()
            {
                UserId = userId,
                Color = "#8D99AE",
                Name = "Остало"
            });
            
            return categories;
        }
    }
}
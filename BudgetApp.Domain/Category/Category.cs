using System;
using System.Text.RegularExpressions;
using BudgetApp.Domain.Category.Exceptions;

namespace BudgetApp.Domain.Category
{
    public class Category
    {
        public Guid Id { get; set; }

        public string Name { get; init; }

        private string color;
        
        public string Color
        {
            get => this.color;
            init
            {
                if (!IsColorHex(value))
                {
                    throw new CategoryColorFormatException();
                }

                this.color = value;
            }
        }

        public string UserId { get; init; }

        public Category()
        {
            this.Id = Guid.NewGuid();
            this.Name = "";
            this.color = "#FFFFFF";
            this.UserId = "";
        }

        public static bool IsColorHex(string color)
        {
            var hexRegex = new Regex("^#[0-9A-Fa-f]{6}$");

            return hexRegex.IsMatch(color);
        }
    }
}
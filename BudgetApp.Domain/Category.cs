namespace BudgetApp.Domain
{
    public class Category
    {
        public Guid Id { get; set; }

        public string Name { get; init; }

        public string Color { get; init; }

        public string UserId { get; init; }

        public Category()
        {
            this.Id = Guid.NewGuid();
            this.Name = "";
            this.Color = "#FFFFFF";
            this.UserId = "";
        }
    }
}
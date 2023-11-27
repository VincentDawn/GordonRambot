namespace GordonRambot.Shared.Clients.API_Client.DTOs
{
    public class RecipeData
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Cuisine { get; set; } = null!;
        public IList<string> Tags { get; set; } = null!;
        public string SpiceLevel { get; set; } = null!;
        public string PortionSize { get; set; } = null!;
        public int ServingCount { get; set; }

        // Nutritional Information per dish
        public int EstimatedCalories { get; set; }
        public int TotalFatGrams { get; set; }
        public int TotalCarbsGrams { get; set; }
        public int TotalProteinGrams { get; set; }
        public int TotalFiberGrams { get; set; }
        public int TotalSugarGrams { get; set; }
        public int TotalSaltGrams { get; set; }

        public IList<Ingredient> Ingredients { get; set; } = null!;
    }
}

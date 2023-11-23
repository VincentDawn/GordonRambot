using GordonRambot.Shared.Clients.API_Client.Enums;

namespace GordonRambot.Shared.Clients.API_Client.DTOs
{
    public class RecipeData
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public CuisineStyles Cuisine { get; set; }
        public IList<FoodTags> Tags { get; set; }
        public SpiceLevel SpiceLevel { get; set; }
        public PortionSize PortionSize { get; set; }
        public int ServingCount { get; set; }

        // Nutritional Information per dish
        public int EstimatedCalories { get; set; }
        public int TotalFatGrams { get; set; }
        public int TotalCarbsGrams { get; set; }
        public int TotalProteinGrams { get; set; }
        public int TotalFiberGrams { get; set; }
        public int TotalSugarGrams { get; set; }
        public int TotalSaltGrams { get; set; }
    }
}

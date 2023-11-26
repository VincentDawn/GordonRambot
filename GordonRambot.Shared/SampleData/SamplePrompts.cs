using GordonRambot.Shared.Clients.API_Client.DTOs;
using System.Text.Json;

namespace GordonRambot.Shared.Samples
{
    public static class SamplePrompts
    {
        public static class IngredientsSamples
        {
            public const string SampleIngredientsJson = "[{\"Name\":\"Apple\",\"WeightGrams\":150},{\"Name\":\"Egg\",\"WeightGrams\":50},{\"Name\":\"Milk Carton\",\"WeightGrams\":1000},{\"Name\":\"Butter\",\"WeightGrams\":200},{\"Name\":\"Cheddar Cheese\",\"WeightGrams\":250},{\"Name\":\"Yogurt\",\"WeightGrams\":500},{\"Name\":\"Carrot\",\"WeightGrams\":100},{\"Name\":\"Cucumber\",\"WeightGrams\":300},{\"Name\":\"Tomato\",\"WeightGrams\":100},{\"Name\":\"Lettuce\",\"WeightGrams\":200},{\"Name\":\"Orange Juice\",\"WeightGrams\":1000},{\"Name\":\"Grapes\",\"WeightGrams\":500},{\"Name\":\"Strawberries\",\"WeightGrams\":250},{\"Name\":\"Ham\",\"WeightGrams\":300},{\"Name\":\"Salmon Fillet\",\"WeightGrams\":400}]";

            public static readonly List<Ingredient> SampleIngredients = JsonSerializer.Deserialize<List<Ingredient>>(SampleIngredientsJson)!;
        }

        public static class DietaryRequirementsSamples
        {
            public static readonly DietaryRequirements DietaryRequirements = new DietaryRequirements()
            {
                Allergies = AllergiesSamples.SampleAllergies,
                CuisineStyles = CuisineStylesSamples.SampleCuisineStyles,
                NutritionalConstraints = NutritionalConstraintsSamples.SampleNutritionalConstraints,
                FoodTags = FoodTagsSamples.SampleFoodTags,
                SpiceLevel = SpiceLevelSamples.SampleSpiceLevel,
                NumberOfServings = NumberOfServingsSamples.SampleNumberOfServings
            };
        }

        public static class AllergiesSamples
        {
            public static readonly List<string> SampleAllergies = new List<string> { "Peanuts", "Shellfish", "Gluten" };
        }

        public static class CuisineStylesSamples
        {
            public static readonly List<string> SampleCuisineStyles = new List<string>
            {
                "Italian",
                "Mexican",
                "Chinese",
                "Indian",
                "Japanese",
                "French",
                "Thai",
                "Greek",
                "Spanish",
                "Korean",
                "American",
                "Mediterranean",
                "Middle Eastern",
                "Vietnamese",
                "Brazilian"
            };
        }

        public static class NutritionalConstraintsSamples
        {
            public static readonly NutritionalConstraints SampleNutritionalConstraints = new NutritionalConstraints
            {
                MinCalories = 300,
                MaxCalories = 800,
                MinFatGrams = 10,
                MaxFatGrams = 70,
                MinCarbsGrams = 30,
                MaxCarbsGrams = 200,
                MinFiberGrams = 3,
                MaxFiberGrams = 30,
                MinSaltGrams = 1,
                MaxSaltGrams = 6,
                MinProteinGrams = 5,
                MaxProteinGrams = 50,
                MinSugarGrams = 2,
                MaxSugarGrams = 40
            };
        }

        public static class FoodTagsSamples
        {
            public static readonly List<string> SampleFoodTags = new List<string>
                {
                    "Vegan",
                    "GlutenFree",
                    "HighProtein"
                };

        }

        public static class SpiceLevelSamples
        {
            public static readonly string SampleSpiceLevel = "Any";
        }

        public static class NumberOfServingsSamples
        {
            public const int SampleNumberOfServings = 2;
        }

        public static class RecipeDataSamples
        {
            public static readonly RecipeData SampleRecipeData = new RecipeData()
            {
                Name = "Mediterranean Quinoa Salad",
                Description = "A vibrant, nutrient-rich salad featuring quinoa, fresh vegetables, feta cheese, and a lemon-herb dressing.",
                Cuisine = "Mediterranean",
                Tags = new List<string> { "GlutenFree", "Vegetarian" },
                SpiceLevel = "Low",
                PortionSize = "Medium",
                ServingCount = 4,
                EstimatedCalories = 200,
                TotalFatGrams = 10,
                TotalCarbsGrams = 25,
                TotalProteinGrams = 8,
                TotalFiberGrams = 5,
                TotalSugarGrams = 3,
                TotalSaltGrams = 1
            };
        }
    }
}

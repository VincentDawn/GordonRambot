using GordonRambot.Shared.Clients.API_Client.DTOs;

namespace GordonRambot.Shared.Clients.APIClient.Requests
{
    public class RecipesDataFromRequirementsRequest
    {
        public IEnumerable<Ingredient> Ingredients { get; set; }
        public DietaryRequirements DietaryRequirements { get; set; }
    }
}

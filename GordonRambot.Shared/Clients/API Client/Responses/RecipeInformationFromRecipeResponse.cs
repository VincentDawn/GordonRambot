using GordonRambot.Shared.Clients.API_Client.DTOs;

namespace GordonRambot.Shared.Clients.APIClient.Responses
{
    public class RecipeInformationFromRecipeResponse
    {
        public RecipeData RecipeData { get; set; } = null!;
        public string RecipeInstructions { get; set; } = null!;
    }
}

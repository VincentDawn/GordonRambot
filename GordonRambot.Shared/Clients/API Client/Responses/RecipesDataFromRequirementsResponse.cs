using GordonRambot.Shared.Clients.API_Client.DTOs;

namespace GordonRambot.Shared.Clients.APIClient.Responses
{
    public class RecipesDataFromRequirementsResponse
    {
        public IEnumerable<RecipeData> RecipeDatas { get; set; }
    }
}

using GordonRambot.Shared.Clients.APIClient.Requests;
using GordonRambot.Shared.Clients.APIClient.Responses;

namespace GordonRambot.Shared.Clients.API_Client
{
    public interface IApiClient
    {
        Task<IngredientsFromImageRequest?> GetIngredientsFromImage(IngredientsFromImageRequest request);
        Task<RecipesDataFromRequirementsResponse?> GetRecipeDatas(RecipesDataFromRequirementsRequest request);
        Task<RecipeInformationFromRecipeResponse?> GetRecipeInformation(RecipeInformationFromRecipeRequest request);
    }
}

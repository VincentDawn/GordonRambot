using GordonRambot.Shared.Clients.API_Client.DTOs;
using GordonRambot.Shared.Clients.APIClient.Requests;
using GordonRambot.Shared.Clients.APIClient.Responses;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GordonRambot.Shared.Clients.APIClient
{
    public interface ApiClient
    {
        [Post("GetIngredientsFromImage")]
        Task<IngredientsFromImageRequest> GetIngredientsFromImage(IngredientsFromImageRequest request);

        [Post("GetRecipesData")]
        Task<RecipesDataFromRequirementsResponse> GetRecipeData(RecipesDataFromRequirementsRequest request);

        [Post("GetRecipeInformation")]
        Task<RecipeInformationFromRecipeResponse> GetRecipeInformation(RecipeInformationFromRecipeRequest request);
    }
}

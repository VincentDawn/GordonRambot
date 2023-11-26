using Azure.AI.OpenAI;
using GordonRambot.Services.Settings;
using GordonRambot.Shared.Clients.API_Client;
using GordonRambot.Shared.Clients.API_Client.DTOs;
using GordonRambot.Shared.Clients.APIClient.Requests;
using GordonRambot.Shared.Clients.APIClient.Responses;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace GordonRambot.Services.Services
{
    public class OpenAiService : IApiClient
    {
        private readonly OpenAIClient _openAIClient;

        public OpenAiService(IOptions<OpenAiServiceSettings> options)
        {
            var uri = new Uri(options.Value.Url);
            var key = options.Value.Key;
            var githubAlias = options.Value.GitHubAlias;
            var credentials = new Azure.AzureKeyCredential($"{key}/{githubAlias}");

            _openAIClient = new OpenAIClient(uri, credentials);
        }

        public Task<IngredientsFromImageRequest?> GetIngredientsFromImage(IngredientsFromImageRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<RecipesDataFromRequirementsResponse?> GetRecipeDatas(RecipesDataFromRequirementsRequest request)
        {
            try
            {
                var ingredientsList = JsonSerializer.Serialize(request.Ingredients);
                var dietaryRequirements = JsonSerializer.Serialize(request.DietaryRequirements);

                var chatCompletionsOptions = new ChatCompletionsOptions()
                {
                    MaxTokens = 2048,
                    Temperature = 0.7f,
                    NucleusSamplingFactor = 0.95f,
                    DeploymentName = "gpt-35-turbo",
                    Messages =
                {
                    new ChatMessage(ChatRole.System, "Context: " + OpenAiServiceHelpers.Context),
                    new ChatMessage(ChatRole.System, "Ingredients schema: " + OpenAiServiceHelpers.IngredientsJSONFormat),
                    new ChatMessage(ChatRole.System, "Dietary requirements schema: " + OpenAiServiceHelpers.DietaryRequirementsJSONFormat),
                    new ChatMessage(ChatRole.System, "Recipe data response schema" + OpenAiServiceHelpers.RecipeDatasJSONFormat),
                    new ChatMessage(ChatRole.System, $"Ingredients: {ingredientsList}." + $"Dietary requirements {dietaryRequirements}"),
                    new ChatMessage(ChatRole.User, OpenAiServiceHelpers.RecipesDatasPrompt)
                },
                    ChoiceCount = 1
                };

                var response = await _openAIClient.GetChatCompletionsAsync(chatCompletionsOptions);
                if (response is not null)
                {

                    var content = response.Value.Choices.First().Message.Content;

                    if (content is not null)
                    {
                        content = RemoveFormatting(content);

                        return new RecipesDataFromRequirementsResponse()
                        {
                            RecipeDatas = JsonSerializer.Deserialize<List<RecipeData>>(content)!
                        };
                    }
                }
            }
            catch (Exception)
            {

            }

            return null;
        }

        public async Task<RecipeInformationFromRecipeResponse?> GetRecipeInformation(RecipeInformationFromRecipeRequest request)
        {
            try
            {
                var recipeData = JsonSerializer.Serialize(request.RecipeData);
                var dietaryRequirements = JsonSerializer.Serialize(request.DietaryRequirements);

                var chatCompletionsOptions = new ChatCompletionsOptions()
                {
                    MaxTokens = 2048,
                    Temperature = 0.7f,
                    NucleusSamplingFactor = 0.95f,
                    DeploymentName = "gpt-35-turbo",
                    Messages =
                {
                    new ChatMessage(ChatRole.System, "Context: " + OpenAiServiceHelpers.Context),
                    new ChatMessage(ChatRole.System, "Recipe data schema" + OpenAiServiceHelpers.RecipeDataJSONFormat),
                    new ChatMessage(ChatRole.System, "Dietary requirements schema: " + OpenAiServiceHelpers.DietaryRequirementsJSONFormat),
                    new ChatMessage(ChatRole.System, "Recipe information schema: " + OpenAiServiceHelpers.RecipeInformationJSONFormat),
                    new ChatMessage(ChatRole.System, $"Recipe data: {recipeData}." + $"Dietary requirements {dietaryRequirements}"),
                    new ChatMessage(ChatRole.User, OpenAiServiceHelpers.RecipeInformationPrompt)
                },
                    ChoiceCount = 1
                };

                var response = await _openAIClient.GetChatCompletionsAsync(chatCompletionsOptions);
                if (response is not null)
                {
                    var content = response.Value.Choices.First().Message.Content;

                    if (content is not null)
                    {
                        content = RemoveFormatting(content);

                        return JsonSerializer.Deserialize<RecipeInformationFromRecipeResponse>(content);
                    }
                }
            }
            catch (Exception)
            {

            }

            return null;
        }

        private static string RemoveFormatting(string content)
        {
            content = content.Replace("\n", "").Replace("\r", "");
            return content;
        }
    }
}

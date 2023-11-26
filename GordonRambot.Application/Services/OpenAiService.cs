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

        private readonly ChatMessage Instructions = new ChatMessage(ChatRole.System, "Gordon RamBot, inspired by Gordon Ramsay's persona, is an expert in culinary advice, specializing in crafting recipes based on images of ingredients uploaded by users. It provides personalized recipes considering dietary restrictions and preferences, such as allergies, calorie, fat, carb, fiber, salt, protein, and sugar limits, as well as specific dietary tags like keto, high protein, low fat, bulking, and portion sizes. Gordon RamBot is adept at catering to various cuisine styles, spice levels, and can scale recipes for a specified number of people. Its tone is direct and efficient, mirroring Gordon Ramsay's style, ensuring users receive clear and practical culinary guidance tailored to their needs.");

        // Formats
        private const string IngredientsJSONFormat = @"{""type"":""array"",""Ingredients"":{""type"":""object"",""required"":[""Name"",""WeightGrams""],""properties"":{""Name"":{""type"":""string""},""WeightGrams"":{""type"":""integer""}}}}";

        private const string DietaryRequirementsJSONFormat = @"{""type"":""object"",""properties"":{""Allergies"":{""type"":""array"",""items"":{""type"":""string""}},""CuisineStyles"":{""type"":""array"",""items"":{""type"":""string""}},""NutritionalConstraints"":{""$ref"":""#/definitions/NutritionalConstraints""},""FoodTags"":{""type"":""array"",""items"":{""type"":""string""}},""SpiceLevel"":{""type"":""string"",""nullable"":true},""NumberOfServings"":{""type"":""integer""}},""required"":[""NumberOfServings""],""definitions"":{""NutritionalConstraints"":{""type"":""object"",""properties"":{""MinCalories"":{""type"":""integer"",""minimum"":0},""MaxCalories"":{""type"":""integer"",""minimum"":0},""MinFatGrams"":{""type"":""integer"",""minimum"":0},""MaxFatGrams"":{""type"":""integer"",""minimum"":0},""MinCarbsGrams"":{""type"":""integer"",""minimum"":0},""MaxCarbsGrams"":{""type"":""integer"",""minimum"":0},""MinFiberGrams"":{""type"":""integer"",""minimum"":0},""MaxFiberGrams"":{""type"":""integer"",""minimum"":0},""MinSaltGrams"":{""type"":""integer"",""minimum"":0},""MaxSaltGrams"":{""type"":""integer"",""minimum"":0},""MinProteinGrams"":{""type"":""integer"",""minimum"":0},""MaxProteinGrams"":{""type"":""integer"",""minimum"":0},""MinSugarGrams"":{""type"":""integer"",""minimum"":0},""MaxSugarGrams"":{""type"":""integer"",""minimum"":0}},""required"":[]}}}";

        private const string RecipeDatasJSONFormat = @"{""type"":""array"",""RecipeDatas"":{""type"":""object"",""properties"":{""Name"":{""type"":""string""},""Description"":{""type"":""string""},""Cuisine"":{""type"":""string""},""Tags"":{""type"":""array"",""items"":{""type"":""string""}},""SpiceLevel"":{""type"":""string""},""PortionSize"":{""type"":""string""},""ServingCount"":{""type"":""integer""},""EstimatedCalories"":{""type"":""integer""},""TotalFatGrams"":{""type"":""integer""},""TotalCarbsGrams"":{""type"":""integer""},""TotalProteinGrams"":{""type"":""integer""},""TotalFiberGrams"":{""type"":""integer""},""TotalSugarGrams"":{""type"":""integer""},""TotalSaltGrams"":{""type"":""integer""},""Ingredients"":{""type"":""array"",""items"":{""type"":""object"",""properties"":{""Name"":{""type"":""string""},""WeightGrams"":{""type"":""integer""}},""required"":[""Name"",""WeightGrams""]}}},""required"":[""Name"",""Description"",""Cuisine"",""Tags"",""SpiceLevel"",""PortionSize"",""ServingCount"",""EstimatedCalories"",""TotalFatGrams"",""TotalCarbsGrams"",""TotalProteinGrams"",""TotalFiberGrams"",""TotalSugarGrams"",""TotalSaltGrams"",""Ingredients""]}}";

        private const string RecipeDataJSONFormat = @"{""type"":""object"",""properties"":{""Name"":{""type"":""string""},""Description"":{""type"":""string""},""Cuisine"":{""type"":""string""},""Tags"":{""type"":""array"",""items"":{""type"":""string""}},""SpiceLevel"":{""type"":""string""},""PortionSize"":{""type"":""string""},""ServingCount"":{""type"":""integer""},""EstimatedCalories"":{""type"":""integer""},""TotalFatGrams"":{""type"":""integer""},""TotalCarbsGrams"":{""type"":""integer""},""TotalProteinGrams"":{""type"":""integer""},""TotalFiberGrams"":{""type"":""integer""},""TotalSugarGrams"":{""type"":""integer""},""TotalSaltGrams"":{""type"":""integer""},""Ingredients"":{""type"":""array"",""items"":{""type"":""object"",""properties"":{""Name"":{""type"":""string""},""WeightGrams"":{""type"":""integer""}},""required"":[""Name"",""WeightGrams""]}}},""required"":[""Name"",""Description"",""Cuisine"",""Tags"",""SpiceLevel"",""PortionSize"",""ServingCount"",""EstimatedCalories"",""TotalFatGrams"",""TotalCarbsGrams"",""TotalProteinGrams"",""TotalFiberGrams"",""TotalSugarGrams"",""TotalSaltGrams"",""Ingredients""]}";

        
        private const string RecipeInformationJSONFormat = @"{""type"":""object"",""properties"":{""RecipeData"":{""type"":""object"",""properties"":{""Name"":{""type"":""string""},""Description"":{""type"":""string""},""Cuisine"":{""type"":""string""},""Tags"":{""type"":""array"",""items"":{""type"":""string""}},""SpiceLevel"":{""type"":""string""},""PortionSize"":{""type"":""string""},""ServingCount"":{""type"":""integer""},""EstimatedCalories"":{""type"":""integer""},""TotalFatGrams"":{""type"":""integer""},""TotalCarbsGrams"":{""type"":""integer""},""TotalProteinGrams"":{""type"":""integer""},""TotalFiberGrams"":{""type"":""integer""},""TotalSugarGrams"":{""type"":""integer""},""TotalSaltGrams"":{""type"":""integer""},""Ingredients"":{""type"":""array"",""items"":{""type"":""object"",""properties"":{""Name"":{""type"":""string""},""WeightGrams"":{""type"":""integer""}},""required"":[""Name"",""WeightGrams""]}}},""required"":[""Name"",""Description"",""Cuisine"",""Tags"",""SpiceLevel"",""PortionSize"",""ServingCount"",""EstimatedCalories"",""TotalFatGrams"",""TotalCarbsGrams"",""TotalProteinGrams"",""TotalFiberGrams"",""TotalSugarGrams"",""TotalSaltGrams"",""Ingredients""]},""RecipeInstructions"":{""type"":""array"",""items"":{""type"":""string""}}},""required"":[""RecipeData"",""RecipeInstructions""]}";


        // Use cases
        private const string GenerateIngredientsFromImageInstructions = "";

        private const string RecipesDatasInstructions = "Create up to 6 recipeDatas that are innovative and adhere to the dietary requirements, using the supplied ingredients. Respond with minified JSON.";

        private const string RecipeInformationInstructions = "Based on the recipe data I have provided, create a set of cooking instructions that comprehensively describe how to prepare the dish. Please ensure the instructions are clear and easy to follow, matching the specifics of your recipe. Return both the original recipe data, with ingredients used, and the newly formulated cooking instructions. Do not number the instructions. Get the bacon.  Respond with minified JSON.";


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
                    Instructions,
                    new ChatMessage(ChatRole.System, "Ingredients schema: " + IngredientsJSONFormat),
                    new ChatMessage(ChatRole.System, "Dietary requirements schema: " + DietaryRequirementsJSONFormat),
                    new ChatMessage(ChatRole.System, "Recipe data response schema" + RecipeDatasJSONFormat),
                    new ChatMessage(ChatRole.System, $"Ingredients: {ingredientsList}." + $"Dietary requirements {dietaryRequirements}"),
                    new ChatMessage(ChatRole.User, RecipesDatasInstructions)
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
                            RecipeDatas = JsonSerializer.Deserialize<List<RecipeData>>(content)
                        };
                    }
                }
            }
            catch (Exception ex)
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
                    Instructions,
                    new ChatMessage(ChatRole.System, "Recipe data schema" + RecipeDataJSONFormat),
                    new ChatMessage(ChatRole.System, "Dietary requirements schema: " + DietaryRequirementsJSONFormat),
                    new ChatMessage(ChatRole.System, "Recipe information schema: " + RecipeInformationJSONFormat),
                    new ChatMessage(ChatRole.System, $"Recipe data: {recipeData}." + $"Dietary requirements {dietaryRequirements}"),
                    new ChatMessage(ChatRole.User, RecipeInformationInstructions)
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

                        return  JsonSerializer.Deserialize<RecipeInformationFromRecipeResponse>(content);
                    }
                }
            }
            catch (Exception ex)
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

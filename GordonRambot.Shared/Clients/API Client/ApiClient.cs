using GordonRambot.Shared.Clients.APIClient.Requests;
using GordonRambot.Shared.Clients.APIClient.Responses;
using System.Text;
using System.Text.Json;

namespace GordonRambot.Shared.Clients.APIClient
{
    public class ApiClient
    {
        public HttpClient HttpClient { get; set; }

        public ApiClient(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        // "GetIngredientsFromImage"
        public static async Task<IngredientsFromImageRequest> GetIngredientsFromImage(IngredientsFromImageRequest request)
        {
            using (var httpClient = new HttpClient())
            {
                // Serialize your data to JSON
                var jsonData = JsonSerializer.Serialize(request);

                // StringContent allows us to create a HTTP content based on a string, using a particular encoding and media type.
                using (var content = new StringContent(jsonData, Encoding.UTF8, "application/json"))
                {
                    // Post the data
                    var response = await httpClient.PostAsync("your-api-endpoint-url", content);

                    if (response.IsSuccessStatusCode)
                    {
                        // Handle success
                        var responseContent = await response.Content.ReadAsStringAsync();
                        // Deserialize the response content to the expected type
                        var deserializedResponse = JsonSerializer.Deserialize<IngredientsFromImageRequest>(responseContent);

                        // Check if deserialization was successful
                        if (deserializedResponse != null)
                        {
                            return deserializedResponse;
                        }
                        else
                        {
                            // Handle the case where deserialization returns null
                            throw new InvalidOperationException("Deserialization returned null.");
                        }
                    }
                    else
                    {
                        // Handle error, maybe throw an exception or return a default instance
                        throw new HttpRequestException($"Error fetching data: {response.ReasonPhrase}");
                    }
                }
            }
        }




        // "GetRecipesData"
        public static async Task<RecipesDataFromRequirementsResponse> GetRecipeData(RecipesDataFromRequirementsRequest request)
        {
            using (var httpClient = new HttpClient())
            {
                // Serialize your data to JSON
                var jsonData = JsonSerializer.Serialize(request);

                // StringContent allows us to create a HTTP content based on a string, using a particular encoding and media type.
                using (var content = new StringContent(jsonData, Encoding.UTF8, "application/json"))
                {
                    // Post the data
                    var response = await httpClient.PostAsync("your-api-endpoint-url", content);

                    if (response.IsSuccessStatusCode)
                    {
                        // Handle success
                        var responseContent = await response.Content.ReadAsStringAsync();
                        // Deserialize the response content to the expected type
                        var deserializedResponse = JsonSerializer.Deserialize<RecipesDataFromRequirementsResponse>(responseContent);

                        // Check if deserialization was successful
                        if (deserializedResponse != null)
                        {
                            return deserializedResponse;
                        }
                        else
                        {
                            // Handle the case where deserialization returns null
                            throw new InvalidOperationException("Deserialization returned null.");
                        }
                    }
                    else
                    {
                        // Handle error, maybe throw an exception or return a default instance
                        throw new HttpRequestException($"Error fetching data: {response.ReasonPhrase}");
                    }
                }
            }
        }


        // "GetRecipeInformation"
        public static async Task<RecipeInformationFromRecipeResponse> GetRecipeInformation(RecipeInformationFromRecipeRequest request)
        {
            using (var httpClient = new HttpClient())
            {
                // Serialize your request data to JSON
                var jsonData = JsonSerializer.Serialize(request);

                // StringContent allows us to create an HTTP content based on a string, using a particular encoding and media type.
                using (var content = new StringContent(jsonData, Encoding.UTF8, "application/json"))
                {
                    // Post the data to the API endpoint
                    var response = await httpClient.PostAsync("your-api-endpoint-url", content);

                    if (response.IsSuccessStatusCode)
                    {
                        // Handle success by reading the response content
                        var responseContent = await response.Content.ReadAsStringAsync();
                        // Deserialize the response content to the expected response type
                        var deserializedResponse = JsonSerializer.Deserialize<RecipeInformationFromRecipeResponse>(responseContent);

                        // Check if deserialization was successful and not null
                        if (deserializedResponse != null)
                        {
                            return deserializedResponse;
                        }
                        else
                        {
                            // Handle the case where deserialization returns null
                            throw new InvalidOperationException("Deserialization returned null.");
                        }
                    }
                    else
                    {
                        // Handle error, such as by throwing an exception or returning a default instance
                        throw new HttpRequestException($"Error fetching data: {response.ReasonPhrase}");
                    }
                }
            }
        }

    }
}

namespace GordonRambot.Shared.Clients.API_Client.DTOs
{
    public class DietaryRequirements
    {
        public List<string> Allergies { get; set; } = null!;

        public List<string> CuisineStyles { get; set; } = null!;

        public NutritionalConstraints NutritionalConstraints { get; set; } = null!;

        public List<string> FoodTags { get; set; } = null!;

        public string SpiceLevel { get; set; } = null!;

        public int NumberOfServings { get; set; }
    }
}

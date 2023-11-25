namespace GordonRambot.Shared.Clients.API_Client.DTOs
{
    public class DietaryRequirements
    {
        public IEnumerable<string>? Allergies { get; set; }

        public IEnumerable<string>? CuisineStyles { get; set; }

        public NutritionalConstraints? NutritionalConstraints { get; set; }

        public IEnumerable<string>? FoodTags { get; set; }

        public string? SpiceLevel { get; set; }

        public int NumberOfServings { get; set; }
    }
}

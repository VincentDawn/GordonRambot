namespace GordonRambot.Shared.Clients.API_Client.DTOs
{
    public class DietaryRequirements
    {
        public List<string> Allergies { get; set; }

        public List<string> CuisineStyles { get; set; }

        public NutritionalConstraints NutritionalConstraints { get; set; }

        public List<string> FoodTags { get; set; }

        public string SpiceLevel { get; set; }

        public int NumberOfServings { get; set; }
    }
}

using GordonRambot.Shared.Clients.API_Client.Enums;

namespace GordonRambot.Shared.Clients.API_Client.DTOs
{
    public class DietaryRequirements
    {
        public IEnumerable<string>? Allergies { get; set; }

        public IEnumerable<CuisineStyles>? CuisineStyles { get; set; }

        public NutritionalConstraints? NutritionalConstraints { get; set; }

        public IEnumerable<FoodTags>? FoodTags { get; set; }

        public SpiceLevel? SpiceLevel { get; set; }

        public int NumberOfServings { get; set; }
    }
}

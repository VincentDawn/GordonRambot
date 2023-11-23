using System.ComponentModel.DataAnnotations;

namespace GordonRambot.Shared.Clients.API_Client.Enums
{
    public enum FoodTags
    {
        [Display(Name = "Keto")]
        Keto,

        [Display(Name = "High Protein")]
        HighProtein,

        [Display(Name = "Low Fat")]
        LowFat,

        [Display(Name = "Bulking")]
        Bulking,

        [Display(Name = "Vegan")]
        Vegan,

        [Display(Name = "Gluten Free")]
        GlutenFree,

        [Display(Name = "Low Carb")]
        LowCarb,

        [Display(Name = "Dairy Free")]
        DairyFree,

        [Display(Name = "Vegetarian")]
        Vegetarian,

        [Display(Name = "Paleo")]
        Paleo
    }
}

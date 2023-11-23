using System.ComponentModel.DataAnnotations;

namespace GordonRambot.Shared.Clients.API_Client.Enums
{
    public enum CuisineStyles
    {
        [Display(Name = "Italian")]
        Italian,

        [Display(Name = "British")]
        British,

        [Display(Name = "French")]
        French,

        [Display(Name = "Chinese")]
        Chinese,

        [Display(Name = "Japanese")]
        Japanese,

        [Display(Name = "Indian")]
        Indian,

        [Display(Name = "Mexican")]
        Mexican,

        [Display(Name = "Thai")]
        Thai,

        [Display(Name = "Spanish")]
        Spanish,

        [Display(Name = "American")]
        American
    }
}

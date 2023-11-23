using System.ComponentModel.DataAnnotations;

namespace GordonRambot.Shared.Clients.API_Client.Enums
{
    public enum SpiceLevel
    {
        [Display(Name = "None")]
        None,

        [Display(Name = "Mild")]
        Mild,

        [Display(Name = "Medium")]
        Medium,

        [Display(Name = "Hot")]
        Hot,

        [Display(Name = "Extra Hot")]
        ExtraHot,

        [Display(Name = "Extreme")]
        Extreme
    }
}

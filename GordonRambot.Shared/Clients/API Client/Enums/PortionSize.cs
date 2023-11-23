namespace GordonRambot.Shared.Clients.API_Client.Enums
{
    using System.ComponentModel.DataAnnotations;

    public enum PortionSize
    {
        [Display(Name = "Small")]
        Small,

        [Display(Name = "Medium")]
        Medium,

        [Display(Name = "Large")]
        Large,

        [Display(Name = "Extra Large")]
        ExtraLarge
    }
}

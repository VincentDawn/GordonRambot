namespace GordonRambot.Services.Settings
{
    public class OpenAiServiceSettings
    {
        public const string SectionName = "AzureOpenAi";

        public string Url { get; set; } = null!;
        public string Key { get; set; } = null!;
        public string GitHubAlias { get; set; } = null!;
    }
}

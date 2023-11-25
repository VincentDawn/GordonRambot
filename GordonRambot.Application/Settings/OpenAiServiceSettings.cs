namespace GordonRambot.Services.Settings
{
    public class OpenAiServiceSettings
    {
        public const string SectionName = "AzureOpenAi";

        public string Url { get; set; }
        public string Key { get; set; }
        public string GitHubAlias { get; set; }
    }
}

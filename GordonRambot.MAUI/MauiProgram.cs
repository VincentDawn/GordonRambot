using GordonRambot.Services.Services;
using GordonRambot.Services.Settings;
using GordonRambot.Shared.Clients.API_Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace GordonRambot
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            // Appsettings
            builder.Configuration
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile("appsettings.development.json", true, true);

            // Other services
            builder.Services.AddOptions<OpenAiServiceSettings>().Bind(builder.Configuration.GetSection(OpenAiServiceSettings.SectionName));
            builder.Services.AddSingleton<IApiClient, OpenAiService>();

            builder.Services.AddMauiBlazorWebView();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}

using CommunityToolkit.Maui;
using jegyzetek.ViewModels;
using jegyzetek.Views;
using Microsoft.Extensions.Logging;

namespace jegyzetek
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("fa_solid.ttf", "FontAwesome");
                });

            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<MainViewModel>();

            builder.Services.AddSingleton<FormPage>();
            builder.Services.AddSingleton<FormViewModel>();

#if DEBUG
            builder.Logging.AddDebug();
#endif


            return builder.Build();
        }
    }
}
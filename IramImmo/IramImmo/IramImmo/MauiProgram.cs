using IramImmo.Utilities.DataAccess;
using IramImmo.View;
using IramImmo.ViewModel;
using Microsoft.Extensions.Logging;

namespace IramImmo
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
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton<DataAccess>();


            builder.Services.AddTransient<MainPageViewModel>();
            builder.Services.AddTransient<MainPage>();



#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}

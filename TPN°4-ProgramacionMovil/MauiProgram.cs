using Microsoft.Extensions.Logging;
using TPN_4_ProgramacionMovil.Services;

namespace TPN_4_ProgramacionMovil
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

            builder.Services.AddMauiBlazorWebView();

            var httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://fakestoreapi.com/")
            };
            builder.Services.AddSingleton(httpClient);
            builder.Services.AddScoped<ProductService>();
            builder.Services.AddScoped<UserService>();

#if DEBUG
    		builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}

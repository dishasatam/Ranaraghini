using Microsoft.Extensions.Logging;
using Ranaraghini.Data;
using Ranaraghini.Services;
using Plugin.Maui.Audio;

#if ANDROID
using Ranaraghini.Platforms.Android.Services;
#endif

namespace Ranaraghini
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
                    fonts.AddFont(
                        "OpenSans-Regular.ttf",
                        "OpenSansRegular");
                });

            // =========================
            // BLAZOR
            // =========================

            builder.Services.AddMauiBlazorWebView();

            // =========================
            // DATABASE
            // =========================

            string dbPath = Path.Combine(
                FileSystem.AppDataDirectory,
                "ranaraghini.db");

            builder.Services.AddSingleton<AppDatabase>(
                s => ActivatorUtilities.CreateInstance<AppDatabase>(
                    s,
                    dbPath));

            // =========================
            // SERVICES
            // =========================
            builder.Services.AddSingleton<FirebaseService>();
            builder.Services.AddSingleton<LocationService>();
            builder.Services.AddSingleton<SosService>();
            builder.Services.AddSingleton<ApiSmsService>();
            builder.Services.AddSingleton<PermissionService>();
            builder.Services.AddSingleton<SessionService>();
            builder.Services.AddSingleton(AudioManager.Current);
#if ANDROID
            builder.Services.AddSingleton<ICallService, AndroidCallService>();

            // ANDROID SMS SERVICE

            builder.Services.AddSingleton<AndroidSmsService>();

#endif

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
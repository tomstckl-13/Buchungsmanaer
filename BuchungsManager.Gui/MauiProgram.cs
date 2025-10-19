using BuchungsManager.Core.ViewModels;
using BuchungsManager.Lib.Interfaces;
using BuchungsManager.Lib.Repositories;
using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;

namespace BuchungsManager.Gui
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
                });

#if DEBUG
    		builder.Logging.AddDebug();

            //path
            var folder = FileSystem.AppDataDirectory;
            var filename = "buchungen.xml";
            var fullpath = System.IO.Path.Join(folder, filename);   

            //Viewmodels
            builder.Services.AddSingleton<MainViewModel>();

            //Pages
            builder.Services.AddSingleton<MainPage>();

            //Schnittstellen
            builder.Services.AddSingleton<IRepository>(new XMLRepository(fullpath));

            //Ausgeben
            System.Diagnostics.Debug.WriteLine($"Pfad: {fullpath}");
#endif

            return builder.Build();
        }
    }
}

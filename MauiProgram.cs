using Microsoft.Extensions.Logging;
using SMSApp.Application.Managers;
using SMSApp.Domain.DataContext;
namespace SMSApp
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

            builder.Services.AddScoped<DataContext>(provider =>
            {
                var dbPath = Constants.DatabasePath;
                var flags = Constants.Flags;
                return new DataContext(dbPath, flags);
            });

            builder.Services.AddTransient<StudentsManager, StudentsManagerImpl>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}

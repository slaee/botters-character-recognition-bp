using Microsoft.Extensions.DependencyInjection;
using CharacterRecognitionBP.Core.AppStartup;

namespace CharacterRecognitionBP
{
    internal static class Program
    {
        public static IServiceProvider? ServiceProvider { get; private set; }
        
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            ConfigureServices();

            Application.Run(ServiceProvider!.GetRequiredService<MainForm>());
        }
        
        private static void ConfigureServices()
        {
            var services = new ServiceCollection();

            services.AddTransient<MainForm>();
            services.AddInterfaces();

            ServiceProvider = services.BuildServiceProvider();
        }
    }
}
using CharacterRecognitionBP.Core.Interfaces;
using CharacterRecognitionBP.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CharacterRecognitionBP.Core.AppStartup
{
    public static class Services
    {
        public static IServiceCollection AddInterfaces(this IServiceCollection services)
        {
            services.AddSingleton<IWaiter, Waiter>();

            return services;
        }
    }
}

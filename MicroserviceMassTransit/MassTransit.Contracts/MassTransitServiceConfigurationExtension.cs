using Microsoft.Extensions.DependencyInjection;

namespace MassTransit.Contracts
{
    public static class MassTransitServiceConfigurationExtension
    {
        public static void Configure(this IServiceCollection services,
        Action<MassTransitConfiguration> configuration,
        string serviceName)
        {
            var transitConfiguration = new MassTransitConfiguration();
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            configuration(transitConfiguration);

            if (string.IsNullOrEmpty(serviceName))
            {
                throw new ArgumentException(nameof(serviceName));
            }

            transitConfiguration.ServiceName = serviceName;

            services.AddSingleton(transitConfiguration);
        }
    }
}

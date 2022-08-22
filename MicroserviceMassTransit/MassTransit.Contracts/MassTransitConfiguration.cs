using MassTransit.ExtensionsDependencyInjectionIntegration;

namespace MassTransit.Contracts
{
    public class MassTransitConfiguration
    {
        public bool IsDebug { get; set; }
        public Action<IServiceCollectionBusConfigurator> Configurator { get; set; }
        public Action<IBusControl, IServiceProvider> BusControl { get; set; }

        public string ServiceName { get; set; }
    }
}

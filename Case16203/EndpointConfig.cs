
using log4net.Config;
using NServiceBus.Log4Net;
using NServiceBus.Logging;
using StructureMap;
using StructureMap.Configuration.DSL;
using StructureMap.Graph;

namespace Case16203
{
    using NServiceBus;

    public class EndpointConfig : IConfigureThisEndpoint
    {
        public void Customize(BusConfiguration busConfiguration)
        {
            var container = new Container(x => x.AddRegistry<StructureMapRegistry>());

            busConfiguration.UseContainer<StructureMapBuilder>(x => x.ExistingContainer(container));

            busConfiguration.PurgeOnStartup(false);
            busConfiguration.UseSerialization<JsonSerializer>();
            busConfiguration.EnableInstallers();
            busConfiguration.UsePersistence<InMemoryPersistence>();
            busConfiguration.EndpointName("Case16203");

            BasicConfigurator.Configure();
            LogManager.Use<Log4NetFactory>();
        }
    }

    public class StructureMapRegistry : Registry
    {
        public StructureMapRegistry()
        {
            Scan(x =>
            {
                x.AssembliesFromApplicationBaseDirectory();
                x.WithDefaultConventions();
                x.Exclude(type => type == typeof(IBus));
            });
        }
    }
}

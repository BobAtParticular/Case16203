using System;
using Case16203.Messages;
using NServiceBus;

namespace Case16203Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var busConfiguration = new BusConfiguration();
            busConfiguration.UseSerialization<JsonSerializer>();
            busConfiguration.EnableInstallers();

            using (var bus = Bus.CreateSendOnly(busConfiguration))
            {
                bus.Send<Case16203Command>("Case16203", cmd => { });
                Console.WriteLine("\r\nMessage Sent; press any key to stop program\r\n");
                Console.ReadKey();
            }
        }
    }
}

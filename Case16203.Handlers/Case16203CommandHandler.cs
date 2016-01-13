using System.Diagnostics;
using Case16203.Messages;
using NServiceBus;

namespace Case16203.Handlers
{
    public class Case16203CommandHandler : IHandleMessages<Case16203Command>
    {
        public void Handle(Case16203Command message)
        {
            Debugger.Break();
        }
    }
}

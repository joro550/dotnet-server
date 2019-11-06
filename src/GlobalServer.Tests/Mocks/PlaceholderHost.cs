using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace GlobalServer.Tests.Mocks
{
    public class PlaceholderHost : IHost
    {
        public void Dispose()
        {
            
        }

        public Task StartAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return Task.CompletedTask;
        }

        public IServiceProvider Services { get; }
    }
}
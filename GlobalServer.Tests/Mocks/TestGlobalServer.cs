using GlobalServer.Api;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;

namespace GlobalServer.Tests.Mocks
{
    public class TestGlobalServer 
        : WebApplicationFactory<GlobalServerApi>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            
        }
    }
}
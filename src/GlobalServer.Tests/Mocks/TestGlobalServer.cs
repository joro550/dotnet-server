using GlobalServer.Api;
using Microsoft.AspNetCore.Mvc.Testing;

namespace GlobalServer.Tests.Mocks
{
    public class TestGlobalServer 
        : WebApplicationFactory<GlobalServerApi>
    {
    }
}
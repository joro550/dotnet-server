using System;
using System.Threading.Tasks;

namespace GlobalServer
{
    public interface ICommandRunner : IDisposable
    {
        Task Run();
    }
}
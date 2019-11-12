using System.Threading.Tasks;

namespace GlobalServer
{
    public class NullCommand : ICommandRunner
    {
        public Task Run() 
            => Task.CompletedTask;

        public void Dispose()
        {
        }
    }
}
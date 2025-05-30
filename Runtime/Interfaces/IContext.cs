using System.Threading;
using System.Threading.Tasks;

namespace Better.Contexts.Runtime.BetterContexts.Runtime.Interfaces
{
    public interface IContext
    {
        public BindStatus Status { get; }
        public Task BindAsync(CancellationToken cancellationToken);
        public Task PostBindAsync(CancellationToken cancellationToken);
        public Task UnbindAsync(CancellationToken cancellationToken);
    }
}
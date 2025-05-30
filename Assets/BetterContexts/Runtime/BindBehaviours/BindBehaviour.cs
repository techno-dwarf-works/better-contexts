using System;
using System.Threading;
using System.Threading.Tasks;

namespace Better.Contexts.Runtime
{
    [Serializable]
    public abstract class BindBehaviour
    {
        public virtual void OnAwake(PocoContext context, CancellationToken aliveToken)
        {
        }

        public virtual void OnStart(PocoContext context, CancellationToken aliveToken)
        {
        }

        public virtual void OnEnable(PocoContext context, CancellationToken aliveToken)
        {
        }

        public virtual void OnDisable(PocoContext context, CancellationToken aliveToken)
        {
        }

        public virtual Task OnBindAsync(PocoContext context, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public virtual Task OnPostBindAsync(PocoContext context, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public virtual Task OnUnbindAsync(PocoContext context, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
        public virtual void OnDestroy(PocoContext context, CancellationToken aliveToken)
        {
        }
    }
}
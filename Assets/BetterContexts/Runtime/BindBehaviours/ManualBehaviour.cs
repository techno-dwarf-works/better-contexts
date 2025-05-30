using System;
using System.Threading;
using System.Threading.Tasks;

namespace Better.Contexts.Runtime
{
    [Serializable]
    public class ManualBehaviour : BindBehaviour
    {
        public override async Task OnBindAsync(PocoContext context, CancellationToken cancellationToken)
        {
            await base.OnBindAsync(context, cancellationToken);

            await context.BindAsync(cancellationToken);
        }

        public override async Task OnPostBindAsync(PocoContext context, CancellationToken cancellationToken)
        {
            await base.OnPostBindAsync(context, cancellationToken);

            await context.PostBindAsync(cancellationToken);
        }

        public override async Task OnUnbindAsync(PocoContext context, CancellationToken cancellationToken)
        {
            await base.OnUnbindAsync(context, cancellationToken);

            await context.UnbindAsync(cancellationToken);
        }
    }
}
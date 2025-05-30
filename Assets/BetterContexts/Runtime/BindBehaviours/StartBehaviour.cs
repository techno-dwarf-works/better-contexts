using System;
using System.Threading;

namespace Better.Contexts.Runtime
{
    [Serializable]
    public class StartBehaviour : AutoBehaviour
    {
        public override async void OnStart(PocoContext context, CancellationToken aliveToken)
        {
            base.OnStart(context, aliveToken);
            
            await context.BindAsync(aliveToken);
            await context.PostBindAsync(aliveToken);
        }

        public override async void OnDestroy(PocoContext context, CancellationToken aliveToken)
        {
            base.OnDestroy(context, aliveToken);
            
            await context.UnbindAsync(aliveToken);
        }
    }
}
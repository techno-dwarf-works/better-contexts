using System;
using System.Threading;

namespace Better.Contexts.Runtime
{
    [Serializable]
    public class EnableBehaviour : AutoBehaviour
    {
        public override async void OnEnable(PocoContext context, CancellationToken aliveToken)
        {
            base.OnEnable(context, aliveToken);
            
            await context.BindAsync(aliveToken);
            await context.PostBindAsync(aliveToken);
        }

        public override async void OnDisable(PocoContext context, CancellationToken aliveToken)
        {
            base.OnDisable(context, aliveToken);
            
            await context.UnbindAsync(aliveToken);
        }
    }
}
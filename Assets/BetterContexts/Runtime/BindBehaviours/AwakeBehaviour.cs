using System;
using System.Threading;

namespace Better.Contexts.Runtime
{
    [Serializable]
    public class AwakeBehaviour : AutoBehaviour
    {
        public override async void OnAwake(PocoContext context, CancellationToken aliveToken)
        {
            base.OnAwake(context, aliveToken);

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
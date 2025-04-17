using System;
using System.Threading;
using System.Threading.Tasks;
using Better.Commons.Runtime.Utility;
using UnityEngine;

namespace Better.Contexts.Runtime
{
    [Serializable]
    public abstract class AutoBehaviour : BindBehaviour
    {
        public override sealed Task OnBindAsync(PocoContext context, CancellationToken cancellationToken)
        {
            var message = "Can not bind manually";
            DebugUtility.LogException<InvalidOperationException>(message);
            
            return Task.CompletedTask;
        }

        public override sealed Task OnPostBindAsync(PocoContext context, CancellationToken cancellationToken)
        {
            var message = "Can not post-bind manually";
            DebugUtility.LogException<InvalidOperationException>(message);
            
            return Task.CompletedTask;
        }

        public override sealed Task OnUnbindAsync(PocoContext context, CancellationToken cancellationToken)
        {
            var message = "Can not unbind manually";
            DebugUtility.LogException<InvalidOperationException>(message);
            
            return Task.CompletedTask;
        }
    }
}
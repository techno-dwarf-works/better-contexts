using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Better.Attributes.Runtime.Select;
using Better.Commons.Runtime.Extensions;
using Better.Contexts.Runtime.BetterContexts.Runtime.Interfaces;
using Better.Contexts.Runtime.Installers;
using UnityEngine;

namespace Better.Contexts.Runtime
{
    [Serializable]
    public class PocoContext : IContext
    {
        [Select]
        [SerializeReference] private Installer[] _installers;

        public BindStatus Status { get; private set; }

        public async Task BindAsync(CancellationToken cancellationToken)
        {
            if (!ValidateStatus(BindStatus.Unbound))
            {
                return;
            }

            await _installers.Select(installer => installer.InstallBindingsAsync(cancellationToken)).WhenAll();

            ChangeStatus(BindStatus.Binding);
        }

        public async Task PostBindAsync(CancellationToken cancellationToken)
        {
            if (!ValidateStatus(BindStatus.Binding))
            {
                return;
            }

            await _installers.Select(installer => installer.PostInstallBindingsAsync(cancellationToken)).WhenAll();

            ChangeStatus(BindStatus.Bound);
        }

        public async Task UnbindAsync(CancellationToken cancellationToken)
        {
            if (!ValidateStatus(BindStatus.Bound))
            {
                return;
            }

            await _installers.Select(installer => installer.UninstallBindingsAsync(cancellationToken)).WhenAll();

            ChangeStatus(BindStatus.Unbound);
        }
        
        private void ChangeStatus(BindStatus status)
        {
            Status = status;
        }

        private bool ValidateStatus(BindStatus targetStatus, bool logError = true)
        {
            var isValid = Status == targetStatus;
            if (!isValid && logError)
            {
                var message = $"Not valid, status must be {targetStatus}";
                Debug.LogError(message);
            }

            return isValid;
        }
    }
}
#if BETTER_LOCATORS && BETTER_SERVICES
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Better.Commons.Runtime.Extensions;
using Better.Locators.Runtime;
using Better.Services.Runtime.Interfaces;
using UnityEngine;

namespace Better.Contexts.Runtime.Installers
{
    [Serializable]
    public abstract class ServicesInstaller<TDerivedService> : Installer
        where TDerivedService : class, IService
    {
        protected abstract TDerivedService[] Services { get; }

        public override async Task InstallBindingsAsync(CancellationToken cancellationToken)
        {
            await Services.Select(x => x.InitializeAsync(cancellationToken)).WhenAll();

            if (cancellationToken.IsCancellationRequested)
            {
                Debug.LogError("Operation was cancelled");
                return;
            }

            for (int i = 0; i < Services.Length; i++)
            {
                ServiceLocator.Register(Services[i]);
            }

        }

        public override Task PostInstallBindingsAsync(CancellationToken cancellationToken)
        {
            return Services.Select(x => x.PostInitializeAsync(cancellationToken)).WhenAll();
        }

        public override Task UninstallBindingsAsync(CancellationToken cancellationToken)
        {
            for (int i = 0; i < Services.Length; i++)
            {
                ServiceLocator.Unregister(Services[i]);
            }
            
            return Task.CompletedTask;
        }
    }
}
#endif
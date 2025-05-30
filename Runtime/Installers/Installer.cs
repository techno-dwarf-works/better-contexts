using System;
using System.Threading;
using System.Threading.Tasks;

namespace Better.Contexts.Runtime.Installers
{
    [Serializable]
    public abstract class Installer
    {
        public abstract Task InstallBindingsAsync(CancellationToken cancellationToken);
        public abstract Task PostInstallBindingsAsync(CancellationToken cancellationToken);
        public abstract Task UninstallBindingsAsync(CancellationToken cancellationToken);
    }
}
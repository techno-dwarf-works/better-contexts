using System.Threading;
using System.Threading.Tasks;
using Better.Attributes.Runtime.Misc;
using Better.Attributes.Runtime.Select;
using Better.Attributes.Runtime.Validation;
using Better.Contexts.Runtime.BetterContexts.Runtime.Interfaces;
using UnityEngine;

namespace Better.Contexts.Runtime
{
    public class MonoContext : MonoBehaviour, IContext
    {
        [HideLabel]
        [SerializeField] private PocoContext _context;

        [Select] [NotNull]
        [SerializeReference] private BindBehaviour _bindBehaviour;

        public BindStatus Status => _context.Status;

        private CancellationTokenSource _tokenSource;

        private void Awake()
        {
            _tokenSource = new CancellationTokenSource();
            _bindBehaviour.OnAwake(_context, _tokenSource.Token);
        }

        private void Start()
        {
            _bindBehaviour.OnStart(_context, _tokenSource.Token);
        }

        private void OnEnable()
        {
            _bindBehaviour.OnEnable(_context, _tokenSource.Token);
        }

        private void OnDisable()
        {
            _bindBehaviour.OnDisable(_context, _tokenSource.Token);
        }

        #region IContext

        public Task BindAsync(CancellationToken cancellationToken)
        {
            var linkedTokenSource = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, _tokenSource.Token);
            
            return _bindBehaviour.OnBindAsync(_context, linkedTokenSource.Token);
        }

        public Task PostBindAsync(CancellationToken cancellationToken)
        {
            var linkedTokenSource = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, _tokenSource.Token);
            
            return _bindBehaviour.OnPostBindAsync(_context, linkedTokenSource.Token);
        }

        public Task UnbindAsync(CancellationToken cancellationToken)
        {
            var linkedTokenSource = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, _tokenSource.Token);
            
            return _bindBehaviour.OnUnbindAsync(_context, linkedTokenSource.Token);
        }

        #endregion

        private void OnDestroy()
        {
            _tokenSource?.Cancel();
            _bindBehaviour.OnDestroy(_context, CancellationToken.None);
        }
    }
}
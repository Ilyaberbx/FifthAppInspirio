using System;
using System.Threading;
using System.Threading.Tasks;
using Better.Saves.Runtime;
using Better.Saves.Runtime.Data;
using Better.Saves.Runtime.Interfaces;
using Better.Services.Runtime;

namespace Inspirio.Global.Services.Persistence
{
    [Serializable]
    public sealed class UserService : PocoService, IUserService
    {
        private ISaveSystem _savesSystem;

        protected override Task OnInitializeAsync(CancellationToken cancellationToken)
        {
            _savesSystem = new SavesSystem();
            return Task.CompletedTask;
        }

        protected override Task OnPostInitializeAsync(CancellationToken cancellationToken)
        {
            CurrentWebViewUrl = new SavesProperty<string>(_savesSystem, nameof(CurrentWebViewUrl), string.Empty);
            return Task.CompletedTask;
        }

        public SavesProperty<string> CurrentWebViewUrl { get; private set; }
    }
}
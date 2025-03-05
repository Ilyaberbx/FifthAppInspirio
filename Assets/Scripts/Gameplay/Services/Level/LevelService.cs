using System;
using System.Threading;
using System.Threading.Tasks;
using Better.Services.Runtime;

namespace Inspirio.Gameplay.Services.Level
{
    [Serializable]
    public sealed class LevelService : PocoService, ILevelService
    {
        public event Action OnSpin;
        protected override Task OnInitializeAsync(CancellationToken cancellationToken) => Task.CompletedTask;
        protected override Task OnPostInitializeAsync(CancellationToken cancellationToken) => Task.CompletedTask;
        public void FireSpin() => OnSpin?.Invoke();
    }
}
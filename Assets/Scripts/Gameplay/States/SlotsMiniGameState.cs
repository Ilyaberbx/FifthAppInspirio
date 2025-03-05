using System.Threading;
using System.Threading.Tasks;
using Better.Locators.Runtime;
using Inspirio.UI.Services.Huds;
using Inspirio.UI.Services.Popups;

namespace Inspirio.Gameplay.States
{
    public sealed class SlotsMiniGameState : BaseGameplayState
    {
        private IPopupsService _popupsService;
        private IHudsService _hudsService;

        public override async Task EnterAsync(CancellationToken token)
        {
            InitializeServices();
        }

        private void InitializeServices()
        {
            _popupsService = ServiceLocator.Get<PopupsService>();
            _hudsService = ServiceLocator.Get<HudsService>();
        }

        public override Task ExitAsync(CancellationToken token)
        {
            DisposeAllModules();
            _popupsService.Hide();
            _hudsService.HideAll();
            return Task.CompletedTask;
        }
    }
}
using System.Threading;
using System.Threading.Tasks;
using Better.Locators.Runtime;
using Inspirio.Gameplay.Modules;
using Inspirio.UI.Services.Screens;

namespace Inspirio.Gameplay.States
{
    public sealed class MainMenuState : BaseGameplayState
    {
        private ScreensService _screensService;

        public override async Task EnterAsync(CancellationToken token)
        {
            _screensService = ServiceLocator.Get<ScreensService>();
            await AddModuleAsync<MainMenuModule>();
        }

        public override Task ExitAsync(CancellationToken token)
        {
            _screensService.Hide();
            return Task.CompletedTask;
        }
    }
}
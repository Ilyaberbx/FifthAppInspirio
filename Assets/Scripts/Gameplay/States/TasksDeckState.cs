using System.Threading;
using System.Threading.Tasks;
using Better.Locators.Runtime;
using Inspirio.UI.Huds.Navigation;
using Inspirio.UI.Popups.TaskDeck;
using Inspirio.UI.Services.Huds;
using Inspirio.UI.Services.Popups;

namespace Inspirio.Gameplay.States
{
    public sealed class TasksDeckState : BaseGameplayState
    {
        private IPopupsService _popupService;
        private IHudsService _hudsService;

        public override async Task EnterAsync(CancellationToken token)
        {
            _popupService = ServiceLocator.Get<PopupsService>();
            _hudsService = ServiceLocator.Get<HudsService>();
            await _popupService.ShowAsync<TaskDeckPopupController, TaskDeckPopupModel>(new TaskDeckPopupModel());
            await _hudsService.ShowAsync<NavigationHudController, NavigationHudModel>(new NavigationHudModel(), ShowType.Additive);
        }

        public override Task ExitAsync(CancellationToken token)
        {
            _popupService.Hide();
            _hudsService.HideAll();
            return Task.CompletedTask;
        }
    }
}
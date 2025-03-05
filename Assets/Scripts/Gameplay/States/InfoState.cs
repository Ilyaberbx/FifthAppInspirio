using System.Threading;
using System.Threading.Tasks;
using Better.Locators.Runtime;
using Inspirio.UI.Popups.Info;
using Inspirio.UI.Services.Popups;

namespace Inspirio.Gameplay.States
{
    public sealed class InfoState : BaseGameplayState
    {
        private IPopupsService _popupsService;

        public override Task EnterAsync(CancellationToken token)
        {
            _popupsService = ServiceLocator.Get<PopupsService>();
            _popupsService.ShowAsync<InfoPopupController, InfoPopupModel>(new InfoPopupModel());
            return Task.CompletedTask;
        }

        public override Task ExitAsync(CancellationToken token)
        {
            _popupsService.Hide();
            return Task.CompletedTask;
        }
    }
}
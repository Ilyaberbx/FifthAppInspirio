using Better.Commons.Runtime.Extensions;
using Better.Locators.Runtime;
using Inspirio.Gameplay.Services.StatesManagement;
using Inspirio.Gameplay.States;
using Inspirio.UI.Core;

namespace Inspirio.UI.Popups.Info
{
    public sealed class InfoPopupController : BaseController<InfoPopupModel, InfoPopupView>
    {
        private IGameplayStatesService _gameplayStatesService;

        protected override void Show(InfoPopupModel model, InfoPopupView view)
        {
            base.Show(model, view);

            _gameplayStatesService = ServiceLocator.Get<GameplayStatesService>();
            View.CloseButton.onClick.AddListener(OnCloseClicked);
        }


        protected override void Hide()
        {
            base.Hide();
            View.CloseButton.onClick.RemoveListener(OnCloseClicked);
        }

        private void OnCloseClicked() => _gameplayStatesService.ChangeStateAsync<MainMenuState>().Forget();
    }
}
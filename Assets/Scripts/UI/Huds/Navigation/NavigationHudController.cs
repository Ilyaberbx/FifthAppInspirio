using Better.Locators.Runtime;
using Inspirio.Gameplay.Services.StatesManagement;
using Inspirio.Gameplay.States;
using Inspirio.UI.Core;

namespace Inspirio.UI.Huds.Navigation
{
    public sealed class NavigationHudController : BaseController<NavigationHudModel, NavigationHudView>
    {
        private IGameplayStatesService _gameplayStatesService;

        protected override void Show(NavigationHudModel model, NavigationHudView view)
        {
            base.Show(model, view);

            _gameplayStatesService = ServiceLocator.Get<GameplayStatesService>();
            View.BackButton.onClick.AddListener(OnBackClicked);
        }

        protected override void Hide()
        {
            base.Hide();
            View.BackButton.onClick.RemoveAllListeners();
        }

        private void OnBackClicked() => _gameplayStatesService.ChangeStateAsync<MainMenuState>();
    }
}
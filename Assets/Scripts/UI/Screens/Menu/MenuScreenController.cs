using Better.Locators.Runtime;
using Inspirio.Gameplay.Services.StatesManagement;
using Inspirio.Gameplay.States;
using Inspirio.UI.Core;

namespace Inspirio.UI.Screens.Menu
{
    public sealed class MenuScreenController : BaseController<MenuScreenModel, MenuScreenView>
    {
        private IGameplayStatesService _gameplayStatesService;

        protected override void Show(MenuScreenModel model, MenuScreenView view)
        {
            base.Show(model, view);

            _gameplayStatesService = ServiceLocator.Get<GameplayStatesService>();

            View.OnPlayClicked += OnPlayButtonClicked;
            View.OnTaskDeckClicked += OnTaskDeckClicked;
        }

        protected override void Hide()
        {
            base.Hide();

            View.OnPlayClicked -= OnPlayButtonClicked;
            View.OnTaskDeckClicked -= OnTaskDeckClicked;
        }

        private void OnPlayButtonClicked() => _gameplayStatesService.ChangeStateAsync<SlotsMiniGameState>();
        private void OnTaskDeckClicked() => _gameplayStatesService.ChangeStateAsync<TasksDeckState>();
    }
}
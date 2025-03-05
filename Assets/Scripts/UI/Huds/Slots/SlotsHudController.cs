using Better.Commons.Runtime.Extensions;
using Better.Locators.Runtime;
using Inspirio.Gameplay.Services.Input;
using Inspirio.Gameplay.Services.Level;
using Inspirio.Gameplay.Services.StatesManagement;
using Inspirio.Gameplay.States;
using Inspirio.UI.Core;
using Inspirio.UI.Services.Huds;
using Inspirio.UI.Services.Popups;
using Inspirio.UI.Services.Screens;

namespace Inspirio.UI.Huds.Slots
{
    public sealed class SlotsHudController : BaseController<SlotsHudModel, SlotsHudView>
    {
        private ILevelService _levelService;
        private IInputService _inputService;
        private IGameplayStatesService _gameplayStatesService;

        protected override void Show(SlotsHudModel model, SlotsHudView view)
        {
            base.Show(model, view);

            _levelService = ServiceLocator.Get<LevelService>();
            _inputService = ServiceLocator.Get<InputService>();
            _gameplayStatesService = ServiceLocator.Get<GameplayStatesService>();
            View.SpinButton.onClick.AddListener(OnSpinClicked);
            View.InfoButton.onClick.AddListener(OnInfoClicked);
        }

        protected override void Hide()
        {
            base.Hide();

            View.SpinButton.onClick.RemoveAllListeners();
            View.InfoButton.onClick.RemoveAllListeners();
        }

        private void OnSpinClicked()
        {
            if (_inputService.IsLocked)
            {
                return;
            }

            _levelService.FireSpin();
        }

        private void OnInfoClicked()
        {
            _gameplayStatesService.ChangeStateAsync<InfoState>().Forget();
        }
    }
}
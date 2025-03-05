using Better.Locators.Runtime;
using Inspirio.Gameplay.Services.Input;
using Inspirio.Gameplay.Services.Level;
using Inspirio.UI.Core;

namespace Inspirio.UI.Huds.Gameplay
{
    public sealed class SlotsHudController : BaseController<SlotsHudModel, SlotsHudView>
    {
        private ILevelService _levelService;
        private IInputService _inputService;

        protected override void Show(SlotsHudModel model, SlotsHudView view)
        {
            base.Show(model, view);

            _levelService = ServiceLocator.Get<LevelService>();
            _inputService = ServiceLocator.Get<InputService>();
            View.SpinButton.onClick.AddListener(OnSpinClicked);
        }

        protected override void Hide()
        {
            base.Hide();

            View.SpinButton.onClick.RemoveAllListeners();
        }

        private void OnSpinClicked()
        {
            if (_inputService.IsLocked)
            {
                return;
            }

            _levelService.FireSpin();
        }
    }
}
using Inspirio.UI.Core;

namespace Inspirio.UI.Huds.Navigation
{
    public sealed class NavigationHudController : BaseController<NavigationHudModel, NavigationHudView>
    {
        protected override void Show(NavigationHudModel model, NavigationHudView view)
        {
            base.Show(model, view);
            
            View.BackButton.onClick.AddListener(OnBackClicked);
        }

        protected override void Hide()
        {
            base.Hide();

            View.BackButton.onClick.RemoveAllListeners();
        }

        private void OnBackClicked()
        {
        }
    }
}
using Better.Locators.Runtime;
using Inspirio.Global.Services.StatesManagement;
using Inspirio.Global.States;
using Inspirio.UI.Core;
using Inspirio.Webview;

namespace Inspirio.UI.Huds.WebView
{
    public sealed class WebViewHudController : BaseController<WebViewHudModel, WebViewHudView>
    {
        private IWebViewService _webViewService;
        private IGameStatesService _gameStatesService;

        protected override void Show(WebViewHudModel model, WebViewHudView view)
        {
            base.Show(model, view);

            _webViewService = ServiceLocator.Get<WebViewService>();
            _gameStatesService = ServiceLocator.Get<GameStatesService>();
            View.OnBackClicked += OnBackClicked;
            View.OnReloadClicked += OnReloadClicked;
        }

        protected override void Hide()
        {
            base.Hide();

            View.OnBackClicked -= OnBackClicked;
            View.OnReloadClicked -= OnReloadClicked;
        }

        private void OnBackClicked()
        {
            if (_webViewService.CanGoBack())
            {
                _webViewService.GoBack();
                return;
            }

            _gameStatesService.ChangeStateAsync<GameplayState>();
        }

        private void OnReloadClicked() => _webViewService.Reload();
    }
}
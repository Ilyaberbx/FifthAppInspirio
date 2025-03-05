using System;
using System.Collections.Generic;
using Better.Commons.Runtime.Utility;
using Better.Locators.Runtime;
using Inspirio.Gameplay.Data.Persistent;
using Inspirio.Gameplay.Services.Currency;
using Inspirio.Gameplay.Services.Sprites;
using Inspirio.UI.Core;

namespace Inspirio.UI.Huds.Currency
{
    public sealed class CurrencyHudController : BaseController<CurrencyHudModel, CurrencyHudView>
    {
        private ICurrencyService _currencyService;
        private ISpritesService _spriteService;

        protected override void Show(CurrencyHudModel model, CurrencyHudView view)
        {
            base.Show(model, view);

            _currencyService = ServiceLocator.Get<CurrencyService>();
            _spriteService = ServiceLocator.Get<SpriteService>();

            Model.Currencies.Subscribe(OnCurrencyChanged);
            Model.Currencies.Value = _currencyService.Current;
        }

        protected override void Hide()
        {
            base.Hide();
            Model.Currencies.Unsubscribe(OnCurrencyChanged);
        }

        private async void OnCurrencyChanged(List<CurrencyData> currencies)
        {
            try
            {
                for (var i = 0; i < currencies.Count; i++)
                {
                    var currency = currencies[i];
                    var sprite = await _spriteService.GetCurrencySpriteAsync(currency.Type);
                    var view = View.CurrencyViews[i];
                    view.SetIcon(sprite);
                    view.SetCountText(currency.Amount.ToString());
                }
            }
            catch (Exception e)
            {
                DebugUtility.LogException(e);
            }
        }
    }
}
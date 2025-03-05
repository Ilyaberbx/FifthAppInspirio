using Inspirio.UI.Core;
using Inspirio.UI.ViewComponents;
using UnityEngine;

namespace Inspirio.UI.Huds.Currency
{
    public sealed class CurrencyHudView : BaseView
    {
        [SerializeField] private CurrencyView[] _currencyViews;

        public CurrencyView[] CurrencyViews => _currencyViews;
    }
}
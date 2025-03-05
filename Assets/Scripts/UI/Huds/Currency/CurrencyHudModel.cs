using System.Collections.Generic;
using Better.Commons.Runtime.DataStructures.Properties;
using Inspirio.Gameplay.Data.Persistent;
using Inspirio.UI.Core;

namespace Inspirio.UI.Huds.Currency
{
    public sealed class CurrencyHudModel : IModel
    {
        public ReactiveProperty<List<CurrencyData>> Currencies { get; } = new();
    }
}
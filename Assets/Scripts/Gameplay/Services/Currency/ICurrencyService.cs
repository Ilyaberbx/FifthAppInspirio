using System.Collections.Generic;
using Inspirio.Gameplay.Data.Persistent;

namespace Inspirio.Gameplay.Services.Currency
{
    public interface ICurrencyService
    {
        public List<CurrencyData> Current { get; }
        public void AddCurrency(CurrencyType type, int amount);
    }
}
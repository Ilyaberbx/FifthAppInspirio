using System;
using Inspirio.Gameplay.Services.Currency;

namespace Inspirio.Gameplay.Data.Persistent
{
    [Serializable]
    public sealed class CurrencyData
    {
        public CurrencyType Type;
        public int Amount;

        public CurrencyData(CurrencyType type, int amount)
        {
            Type = type;
            Amount = amount;
        }
    }
}
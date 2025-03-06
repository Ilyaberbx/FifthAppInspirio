using System;
using Inspirio.Gameplay.Services.Currency;

namespace Inspirio.Gameplay.Data.Common
{
    [Serializable]
    public sealed class RewardData
    {
        public CurrencyType Type { get; set; }
        public int Amount { get; set; }
    }
}
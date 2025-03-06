using System;
using Inspirio.Gameplay.Services.Currency;
using Inspirio.Gameplay.Services.Tasks;

namespace Inspirio.Gameplay.Data.Common
{
    [Serializable]
    public sealed class RewardData
    {
        public TaskPriority Priority;
        public CurrencyType Type;
        public int Amount;
    }
}
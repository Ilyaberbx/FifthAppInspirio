using System;
using Inspirio.Gameplay.Services.Tasks;

namespace Inspirio.Extensions
{
    public static class TaskPriorityExtensions
    {
        public static string ToFriendlyString(this TaskPriority priority)
        {
            switch (priority)
            {
                case TaskPriority.RoyalFlush:
                    return "ROYAL FLUSH - CRITICAL";
                case TaskPriority.FourOfAKind:
                    return "FOUR OF A KIND - HIGH";
                case TaskPriority.FullHouse:
                    return "FULL HOUSE - MEDIUM";
                case TaskPriority.Flush:
                    return "FLUSH - LOW";
                case TaskPriority.TwoPair:
                    return "TWO PAIR - LOWEST";
                default:
                    throw new ArgumentOutOfRangeException(nameof(priority), priority, null);
            }
        }
    }
}
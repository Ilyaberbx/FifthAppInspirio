using Inspirio.Gameplay.Data.Common;
using Inspirio.Gameplay.Services.Tasks;

namespace Inspirio.Gameplay.Services.Rewards
{
    public interface IRewardsService
    {
        public RewardData[] GetRewards(TaskPriority priority);
    }
}
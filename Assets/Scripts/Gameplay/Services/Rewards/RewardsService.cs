using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Better.Locators.Runtime;
using Better.Services.Runtime;
using Inspirio.Gameplay.Data.Common;
using Inspirio.Gameplay.Services.StaticDataManagement;
using Inspirio.Gameplay.Services.Tasks;

namespace Inspirio.Gameplay.Services.Rewards
{
    [Serializable]
    public sealed class RewardsService : PocoService, IRewardsService
    {
        private IGameplayStaticDataService _gameplayStaticDataService;
        protected override Task OnInitializeAsync(CancellationToken cancellationToken) => Task.CompletedTask;

        protected override Task OnPostInitializeAsync(CancellationToken cancellationToken)
        {
            _gameplayStaticDataService = ServiceLocator.Get<GameplayStaticDataService>();
            return Task.CompletedTask;
        }

        public RewardData[] GetRewards(TaskPriority priority)
        {
            var rewards = _gameplayStaticDataService.GetRewardsConfiguration();
            var rewardsByPriority = rewards.Data.Where(temp => temp.Priority == priority);
            return rewardsByPriority.ToArray();
        }
    }
}
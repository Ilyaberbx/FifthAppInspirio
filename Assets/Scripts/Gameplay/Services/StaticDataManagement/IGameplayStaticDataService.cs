using Inspirio.Gameplay.Data.Static;

namespace Inspirio.Gameplay.Services.StaticDataManagement
{
    public interface IGameplayStaticDataService
    {
        RewardsConfiguration GetRewardsConfiguration();
    }
}
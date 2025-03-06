using Inspirio.Gameplay.Data.Common;
using UnityEngine;

namespace Inspirio.Gameplay.Data.Static
{
    [CreateAssetMenu(menuName = "Configs/Gameplay/Rewards", fileName = "RewardsConfiguration", order = 0)]
    public sealed class RewardsConfiguration : ScriptableObject
    {
        [SerializeField] private RewardData[] _data;

        public RewardData[] Data => _data;
    }
}
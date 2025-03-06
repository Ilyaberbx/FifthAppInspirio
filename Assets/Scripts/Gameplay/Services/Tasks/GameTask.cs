using System;
using Inspirio.Gameplay.Data.Common;

namespace Inspirio.Gameplay.Services.Tasks
{
    [Serializable]
    public class GameTask
    {
        public GameTask(string name, TaskPriority priority, RewardData[] rewards)
        {
            Name = name;
            Priority = priority;
            Rewards = rewards;
        }

        public string Name;
        public TaskPriority Priority;
        public RewardData[] Rewards;
        public bool MarkedForCompletion;
    }
}
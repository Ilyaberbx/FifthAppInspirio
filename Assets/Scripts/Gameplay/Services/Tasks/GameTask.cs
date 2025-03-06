using System;

namespace Inspirio.Gameplay.Services.Tasks
{
    [Serializable]
    public class GameTask
    {
        public GameTask(string name, TaskPriority priority)
        {
            Name = name;
            Priority = priority;
        }

        public string Name;
        public TaskPriority Priority;
        public bool MarkedForCompletion;
    }
}
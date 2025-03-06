using System.Collections.Generic;

namespace Inspirio.Gameplay.Services.Tasks
{
    public interface ITasksService
    {
        public void AddTask(GameTask gameTask);
        public bool RemoveTask(GameTask gameTask);
        IEnumerable<GameTask> GetAllTasks();
        bool TryCompleteTask(GameTask gameTask);
        bool TryDismissTask(GameTask gameTask);
    }
}
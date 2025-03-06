using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Better.Locators.Runtime;
using Better.Services.Runtime;
using Inspirio.Gameplay.Services.Currency;
using Inspirio.Gameplay.Services.Rewards;
using Inspirio.Global.Services.Persistence;

namespace Inspirio.Gameplay.Services.Tasks
{
    [Serializable]
    public sealed class TasksService : PocoService, ITasksService
    {
        private ICurrencyService _currencyService;
        private IUserService _userService;
        private IRewardsService _rewardsService;

        protected override Task OnInitializeAsync(CancellationToken cancellationToken) => Task.CompletedTask;

        protected override Task OnPostInitializeAsync(CancellationToken cancellationToken)
        {
            _currencyService = ServiceLocator.Get<CurrencyService>();
            _userService = ServiceLocator.Get<UserService>();
            _rewardsService = ServiceLocator.Get<RewardsService>();

            return Task.CompletedTask;
        }

        public void AddTask(GameTask gameTask)
        {
            if (gameTask == null)
            {
                return;
            }

            _userService.GameTasks.Value.Add(gameTask);
            _userService.GameTasks.SetDirty();
        }

        public IEnumerable<GameTask> GetAllTasks() => _userService.GameTasks.Value;

        public bool RemoveTask(GameTask gameTask)
        {
            if (_userService.GameTasks.Value.Remove(gameTask))
            {
                _userService.GameTasks.SetDirty();
                return true;
            }

            return false;
        }

        public bool TryCompleteTask(GameTask gameTask)
        {
            if (!gameTask.MarkedForCompletion)
            {
                return false;
            }

            if (!RemoveTask(gameTask))
            {
                return false;
            }

            var rewards = _rewardsService.GetRewards(gameTask.Priority);

            foreach (var reward in rewards)
            {
                _currencyService.AddCurrency(reward.Type, reward.Amount);
            }

            return true;
        }

        public bool TryDismissTask(GameTask gameTask) => RemoveTask(gameTask);
    }
}
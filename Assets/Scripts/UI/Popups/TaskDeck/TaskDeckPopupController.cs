using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Better.Commons.Runtime.Extensions;
using Better.Commons.Runtime.Utility;
using Better.Locators.Runtime;
using Inspirio.Gameplay.Services.Rewards;
using Inspirio.Gameplay.Services.Sprites;
using Inspirio.Gameplay.Services.Tasks;
using Inspirio.UI.Core;
using Inspirio.UI.Popups.NewTask;
using Inspirio.UI.Services.Popups;
using Inspirio.UI.ViewComponents;

namespace Inspirio.UI.Popups.TaskDeck
{
    public sealed class TaskDeckPopupController : BaseController<TaskDeckPopupModel, TaskDeckPopupView>
    {
        private ITasksService _tasksService;
        private ISpritesService _spriteService;
        private IRewardsService _rewardsService;
        private IPopupsService _popupsService;

        protected override void Show(TaskDeckPopupModel model, TaskDeckPopupView view)
        {
            base.Show(model, view);

            _tasksService = ServiceLocator.Get<TasksService>();
            _spriteService = ServiceLocator.Get<SpriteService>();
            _rewardsService = ServiceLocator.Get<RewardsService>();
            _popupsService = ServiceLocator.Get<PopupsService>();

            Model.AllTasks.Subscribe(OnAllTasksChanged);
            Model.AllTasks.Value = _tasksService.GetAllTasks();

            for (var i = 0; i < View.DeskTaskViews.Length; i++)
            {
                var deskTaskView = View.DeskTaskViews[i];
                deskTaskView.SetIndex(i);
                deskTaskView.OnCompleteClicked += OnCompleteClicked;
                deskTaskView.OnDismissClicked += OnDismissClicked;
            }

            View.OnAddClicked += OnAddClicked;
        }

        protected override void Hide()
        {
            base.Hide();

            Model.AllTasks.Unsubscribe(OnAllTasksChanged);

            foreach (var deskTaskView in View.DeskTaskViews)
            {
                deskTaskView.OnCompleteClicked -= OnCompleteClicked;
                deskTaskView.OnDismissClicked -= OnDismissClicked;
            }

            View.OnAddClicked -= OnAddClicked;
        }

        private void OnAddClicked() => _popupsService
            .ShowAsync<NewTaskPopupController, NewTaskPopupModel>(new NewTaskPopupModel())
            .Forget();

        private async void OnAllTasksChanged(IEnumerable<GameTask> allTasks)
        {
            try
            {
                var tasksByPriority = allTasks.OrderBy(temp => temp.Priority).ToList();
                var taskCount = tasksByPriority.Count;

                for (var i = 0; i < View.DeskTaskViews.Length; i++)
                {
                    if (i >= taskCount)
                    {
                        View.DeskTaskViews[i].SetActive(false);
                        continue;
                    }

                    var task = tasksByPriority[i];
                    var deskTaskView = View.DeskTaskViews[i];

                    await SetTaskViewAsync(deskTaskView, task);
                }
            }
            catch (Exception e)
            {
                DebugUtility.LogException(e);
            }
        }

        private void OnDismissClicked(int index)
        {
            var taskToDismiss = Model.AllTasks.Value.ElementAt(index);

            if (_tasksService.TryDismissTask(taskToDismiss))
            {
                Model.AllTasks.Value = _tasksService.GetAllTasks();
            }
        }

        private void OnCompleteClicked(int index)
        {
            var taskToComplete = Model.AllTasks.Value.ElementAt(index);

            taskToComplete.MarkedForCompletion = true;

            if (_tasksService.TryCompleteTask(taskToComplete))
            {
                Model.AllTasks.Value = _tasksService.GetAllTasks();
            }
        }

        private async Task SetTaskViewAsync(DeskTaskView deskTaskView, GameTask task)
        {
            var prioritySprite = await _spriteService.GetPrioritySpriteAsync(task.Priority);
            deskTaskView.SetPrioritySprite(prioritySprite);
            deskTaskView.SetName(task.Name);

            for (var j = 0; j < deskTaskView.CurrencyViews.Length; j++)
            {
                var currencyView = deskTaskView.CurrencyViews[j];
                var rewards = _rewardsService.GetRewards(task.Priority);
                if (j >= rewards.Length)
                {
                    currencyView.SetActive(false);
                    continue;
                }

                var reward = rewards[j];
                var rewardIcon = await _spriteService.GetCurrencySpriteAsync(reward.Type);
                currencyView.SetCountText(reward.Amount.ToString());
                currencyView.SetIcon(rewardIcon);
                currencyView.SetActive(true);
            }

            deskTaskView.SetActive(true);
        }
    }
}
using System;
using Better.Commons.Runtime.Extensions;
using Better.Commons.Runtime.Utility;
using Better.Locators.Runtime;
using Inspirio.Extensions;
using Inspirio.Gameplay.Services.Rewards;
using Inspirio.Gameplay.Services.Sprites;
using Inspirio.Gameplay.Services.Tasks;
using Inspirio.UI.Core;
using Inspirio.UI.Popups.TaskDeck;
using Inspirio.UI.Services.Popups;

namespace Inspirio.UI.Popups.NewTask
{
    public sealed class NewTaskPopupController : BaseController<NewTaskPopupModel, NewTaskPopupView>
    {
        private IRewardsService _rewardsService;
        private ISpritesService _spriteService;
        private ITasksService _tasksService;
        private IPopupsService _popupsService;

        protected override void Show(NewTaskPopupModel model, NewTaskPopupView view)
        {
            base.Show(model, view);

            _rewardsService = ServiceLocator.Get<RewardsService>();
            _spriteService = ServiceLocator.Get<SpriteService>();
            _tasksService = ServiceLocator.Get<TasksService>();
            _popupsService = ServiceLocator.Get<PopupsService>();

            View.OnSaveClicked += OnSaveClicked;
            View.OnInputChanged += OnInputChanged;
            View.OnDropdownChanged += OnDropdownChanged;

            Model.Priority.Subscribe(OnPriorityChanged);

            var priorities = Enum.GetValues(typeof(TaskPriority));

            foreach (var priority in priorities)
            {
                var value = (TaskPriority)priority;
                var valueText = value.ToFriendlyString();
                View.SetOption(valueText);
            }

            foreach (var currencyView in View.CurrencyViews)
            {
                currencyView.SetActive(false);
            }

            OnPriorityChanged(TaskPriority.RoyalFlush);
        }

        protected override void Hide()
        {
            base.Hide();

            View.OnSaveClicked -= OnSaveClicked;
            View.OnInputChanged -= OnInputChanged;
            View.OnDropdownChanged -= OnDropdownChanged;

            Model.Priority.Unsubscribe(OnPriorityChanged);
        }

        private void OnSaveClicked()
        {
            if (string.IsNullOrEmpty(Model.Name))
            {
                return;
            }

            var task = new GameTask(Model.Name, Model.Priority.Value);
            _tasksService.AddTask(task);
            _popupsService.ShowAsync<TaskDeckPopupController, TaskDeckPopupModel>(new TaskDeckPopupModel())
                .Forget();
        }

        private void OnInputChanged(string value) => Model.Name = value;

        private void OnDropdownChanged(int index)
        {
            var priority = (TaskPriority)index;
            Model.Priority.Value = priority;
        }

        private async void OnPriorityChanged(TaskPriority priority)
        {
            try
            {
                var rewards = _rewardsService.GetRewards(priority);

                for (var i = 0; i < View.CurrencyViews.Length; i++)
                {
                    var currencyView = View.CurrencyViews[i];

                    if (rewards.Length <= i)
                    {
                        currencyView.SetActive(false);
                        continue;
                    }

                    var reward = rewards[i];
                    var currencyIcon = await _spriteService.GetCurrencySpriteAsync(reward.Type);
                    currencyView.SetIcon(currencyIcon);
                    currencyView.SetCountText(reward.Amount.ToString());
                    currencyView.SetActive(true);
                }
            }
            catch (Exception e)
            {
                DebugUtility.LogException(e);
            }
        }
    }
}
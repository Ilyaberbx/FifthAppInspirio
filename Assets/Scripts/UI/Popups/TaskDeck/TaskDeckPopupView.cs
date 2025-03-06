using System;
using Inspirio.UI.Core;
using Inspirio.UI.ViewComponents;
using UnityEngine;
using UnityEngine.UI;

namespace Inspirio.UI.Popups.TaskDeck
{
    public sealed class TaskDeckPopupView : BaseView
    {
        public event Action OnAddClicked;
        [SerializeField] private DeskTaskView[] _deskTaskViews;
        [SerializeField] private Button _addButton;
        public DeskTaskView[] DeskTaskViews => _deskTaskViews;
        private void OnEnable() => _addButton.onClick.AddListener(OnAddButtonClicked);
        private void OnDisable() => _addButton.onClick.RemoveAllListeners();
        private void OnAddButtonClicked() => OnAddClicked?.Invoke();
    }
}
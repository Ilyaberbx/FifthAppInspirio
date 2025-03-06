using System;
using Inspirio.UI.Core;
using UnityEngine;
using UnityEngine.UI;

namespace Inspirio.UI.Screens.Menu
{
    public sealed class MenuScreenView : BaseView
    {
        public event Action OnPlayClicked;
        public event Action OnTaskDeckClicked;

        [SerializeField] private Button _playButton;
        [SerializeField] private Button _taskDeckButton;

        private void OnEnable()
        {
            _playButton.onClick.AddListener(OnPlayButtonClicked);
            _taskDeckButton.onClick.AddListener(OnTaskDeckButtonClicked);
        }

        private void OnDisable()
        {
            _playButton.onClick.RemoveListener(OnPlayButtonClicked);
            _taskDeckButton.onClick.RemoveListener(OnTaskDeckButtonClicked);
        }

        private void OnTaskDeckButtonClicked() => OnTaskDeckClicked?.Invoke();
        private void OnPlayButtonClicked() => OnPlayClicked?.Invoke();
    }
}
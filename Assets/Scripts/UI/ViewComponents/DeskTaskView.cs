using System;
using Better.Commons.Runtime.Components.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Inspirio.UI.ViewComponents
{
    public sealed class DeskTaskView : UIMonoBehaviour
    {
        public event Action<int> OnCompleteClicked;
        public event Action<int> OnDismissClicked;

        [SerializeField] private Image _priorityImage;
        [SerializeField] private TextMeshProUGUI _nameText;
        [SerializeField] private CurrencyView[] _currencyViews;
        [SerializeField] private Button _completeButton;
        [SerializeField] private Button _dismissButton;

        private int _index;

        public CurrencyView[] CurrencyViews => _currencyViews;

        private void OnEnable()
        {
            _completeButton.onClick.AddListener(OnCompleteButtonClicked);
            _dismissButton.onClick.AddListener(OnDismissButtonClicked);
        }

        private void OnDisable()
        {
            _completeButton.onClick.RemoveAllListeners();
            _dismissButton.onClick.RemoveAllListeners();
        }

        public void SetPrioritySprite(Sprite sprite) => _priorityImage.sprite = sprite;
        public void SetName(string name) => _nameText.text = name;
        public void SetActive(bool isActive) => gameObject.SetActive(isActive);
        public void SetIndex(int index) => _index = index;
        private void OnDismissButtonClicked() => OnDismissClicked?.Invoke(_index);
        private void OnCompleteButtonClicked() => OnCompleteClicked?.Invoke(_index);
    }
}
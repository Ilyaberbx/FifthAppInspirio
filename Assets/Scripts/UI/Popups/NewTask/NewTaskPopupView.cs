using System;
using Inspirio.UI.Core;
using Inspirio.UI.ViewComponents;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Inspirio.UI.Popups.NewTask
{
    public sealed class NewTaskPopupView : BaseView
    {
        public event Action<string> OnInputChanged;
        public event Action<int> OnDropdownChanged;
        public event Action OnSaveClicked;

        [SerializeField] private TMP_Dropdown _dropdown;
        [SerializeField] private TMP_InputField _inputField;
        [SerializeField] private Button _saveButton;
        [SerializeField] private CurrencyView[] _currencyViews;

        public CurrencyView[] CurrencyViews => _currencyViews;


        private void OnEnable()
        {
            _dropdown.options.Clear();
            _inputField.onValueChanged.AddListener(OnInputFieldChanged);
            _saveButton.onClick.AddListener(OnSaveButtonClicked);
            _dropdown.onValueChanged.AddListener(OnDropdownValueChanged);
        }

        public void SetOption(string optionText)
        {
            var optionData = new TMP_Dropdown.OptionData(optionText);
            _dropdown.options.Add(optionData);
        }

        private void OnDisable()
        {
            _inputField.onValueChanged.RemoveListener(OnInputFieldChanged);
            _saveButton.onClick.RemoveListener(OnSaveButtonClicked);
        }

        private void OnSaveButtonClicked() => OnSaveClicked?.Invoke();
        private void OnDropdownValueChanged(int index) => OnDropdownChanged?.Invoke(index);
        private void OnInputFieldChanged(string value) => OnInputChanged?.Invoke(value);
    }
}
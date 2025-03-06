using Better.Commons.Runtime.Components.UI;
using TMPro;
using UnityEngine;

namespace Inspirio.UI.ViewComponents
{
    public sealed class RoadMapNodeView : UIMonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _nameText;
        [SerializeField] private TextMeshProUGUI _tasksText;
        [SerializeField] private TextMeshProUGUI _multiplierText;
        [SerializeField] private GameObject _currentContainer;
        [SerializeField] private GameObject _nextContainer;


        public void SetNameText(string name) => _nameText.text = name;
        public void SetTasksText(string tasksText) => _tasksText.text = tasksText;
        public void SetMultiplierText(string multiplierText) => _multiplierText.text = multiplierText;

        public void SetCurrent(bool isCurrent)
        {
            _currentContainer.SetActive(isCurrent);
            _nextContainer.SetActive(!isCurrent);
        }
    }
}
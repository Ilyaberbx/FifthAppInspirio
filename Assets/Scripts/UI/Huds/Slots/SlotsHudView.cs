using Inspirio.UI.Core;
using UnityEngine;
using UnityEngine.UI;

namespace Inspirio.UI.Huds.Slots
{
    public sealed class SlotsHudView : BaseView
    {
        [SerializeField] private Button _spinButton;
        [SerializeField] private Button _infoButton;
        

        public Button SpinButton => _spinButton;

        public Button InfoButton => _infoButton;
    }
}
using Inspirio.UI.Core;
using UnityEngine;
using UnityEngine.UI;

namespace Inspirio.UI.Huds.Gameplay
{
    public sealed class SlotsHudView : BaseView
    {
        [SerializeField] private Button _spinButton;

        public Button SpinButton => _spinButton;
    }
}
using Inspirio.UI.Core;
using UnityEngine;
using UnityEngine.UI;

namespace Inspirio.UI.Huds.Navigation
{
    public sealed class NavigationHudView : BaseView
    {
        [SerializeField] private Button _backButton;

        public Button BackButton => _backButton;
    }
}
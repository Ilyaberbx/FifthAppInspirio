using Inspirio.UI.Core;
using Inspirio.UI.ViewComponents;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Inspirio.UI.Popups.Info
{
    public sealed class InfoPopupView : BaseView
    {
        [SerializeField] private Button _closeButton;

        public Button CloseButton => _closeButton;
        
    }
}
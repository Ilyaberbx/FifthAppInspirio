using Better.Commons.Runtime.Components.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Inspirio.UI.ViewComponents
{
    public sealed class CurrencyView : UIMonoBehaviour
    {
        [SerializeField] private Image _iconImage;
        [SerializeField] private TextMeshProUGUI _countText;

        public void SetIcon(Sprite icon) => _iconImage.sprite = icon;
        public void SetCountText(string text) => _countText.text = text;
        public void SetActive(bool isActive) => gameObject.SetActive(isActive);
    }
}
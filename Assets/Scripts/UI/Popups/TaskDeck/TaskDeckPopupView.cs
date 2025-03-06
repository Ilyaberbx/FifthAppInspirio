using Inspirio.UI.Core;
using Inspirio.UI.ViewComponents;
using UnityEngine;

namespace Inspirio.UI.Popups.TaskDeck
{
    public sealed class TaskDeckPopupView : BaseView
    {
        [SerializeField] private DeskTaskView[] _deskTaskViews;

        public DeskTaskView[] DeskTaskViews => _deskTaskViews;
    }
}
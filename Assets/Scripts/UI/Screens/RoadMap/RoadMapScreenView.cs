using Inspirio.UI.Core;
using Inspirio.UI.ViewComponents;
using UnityEngine;

namespace Inspirio.UI.Screens.RoadMap
{
    public sealed class RoadMapScreenView : BaseView
    {
        [SerializeField] private RoadMapNodeView _nodeViews;

        public RoadMapNodeView NodeViews => _nodeViews;
    }
}
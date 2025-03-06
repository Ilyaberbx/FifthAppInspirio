using Better.Commons.Runtime.DataStructures.Properties;
using Inspirio.Gameplay.Services.Tasks;
using Inspirio.UI.Core;

namespace Inspirio.UI.Popups.NewTask
{
    public sealed class NewTaskPopupModel : IModel
    {
        public string Name { get; set; }
        public ReactiveProperty<TaskPriority> Priority { get; } = new();
    }
}
using System.Collections.Generic;
using Better.Commons.Runtime.DataStructures.Properties;
using Inspirio.Gameplay.Services.Tasks;
using Inspirio.UI.Core;

namespace Inspirio.UI.Popups.TaskDeck
{
    public sealed class TaskDeckPopupModel : IModel
    {
        public ReactiveProperty<IEnumerable<GameTask>> AllTasks { get; } = new();
    }
}
using System.Collections.Generic;
using Better.Saves.Runtime.Data;
using Inspirio.Gameplay.Data.Persistent;
using Inspirio.Gameplay.Services.Tasks;

namespace Inspirio.Global.Services.Persistence
{
    public interface IUserService
    {
        public SavesProperty<string> CurrentWebViewUrl { get; }
        public SavesProperty<List<CurrencyData>> Currencies { get; }
        public SavesProperty<List<GameTask>> GameTasks { get; }
    }
}
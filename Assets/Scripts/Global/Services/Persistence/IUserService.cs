using System.Collections.Generic;
using Better.Saves.Runtime.Data;
using Inspirio.Gameplay.Data.Persistent;

namespace Inspirio.Global.Services.Persistence
{
    public interface IUserService
    {
        public SavesProperty<string> CurrentWebViewUrl { get; }
        public SavesProperty<List<CurrencyData>> Currencies { get; }
    }
}
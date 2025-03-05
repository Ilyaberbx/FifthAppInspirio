using Better.Saves.Runtime.Data;

namespace Inspirio.Global.Services.Persistence
{
    public interface IUserService
    {
        public SavesProperty<string> CurrentWebViewUrl { get; }
    }
}
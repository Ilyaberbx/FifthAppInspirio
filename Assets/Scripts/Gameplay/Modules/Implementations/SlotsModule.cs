using System.Threading.Tasks;
using Better.Locators.Runtime;
using Inspirio.UI.Huds.Gameplay;
using Inspirio.UI.Services.Huds;

namespace Inspirio.Gameplay.Modules
{
    public sealed class SlotsModule : BaseGameplayModule
    {
        private IHudsService _hudsService;

        public override Task InitializeAsync()
        {
            _hudsService = ServiceLocator.Get<HudsService>();
            return _hudsService.ShowAsync<SlotsHudController, SlotsHudModel>(new SlotsHudModel(), ShowType.Additive);
        }

        public override void Dispose() => _hudsService = null;
    }
}
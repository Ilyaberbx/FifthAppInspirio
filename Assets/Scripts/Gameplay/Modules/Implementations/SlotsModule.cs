using System.Threading.Tasks;
using Better.Locators.Runtime;
using Inspirio.UI.Huds.Navigation;
using Inspirio.UI.Huds.Slots;
using Inspirio.UI.Services.Huds;

namespace Inspirio.Gameplay.Modules
{
    public sealed class SlotsModule : BaseGameplayModule
    {
        private IHudsService _hudsService;

        public override async Task InitializeAsync()
        {
            _hudsService = ServiceLocator.Get<HudsService>();
            await _hudsService.ShowAsync<SlotsHudController, SlotsHudModel>(new SlotsHudModel(), ShowType.Additive);
            await _hudsService.ShowAsync<NavigationHudController, NavigationHudModel>(new NavigationHudModel(), ShowType.Additive);
        }

        public override void Dispose() => _hudsService = null;
    }
}
using System;
using System.Threading;
using System.Threading.Tasks;
using Better.Locators.Runtime;
using Better.Services.Runtime;
using Inspirio.Gameplay.Services.Currency;
using Inspirio.Global.Services.AssetsManagement;
using UnityEngine;

namespace Inspirio.Gameplay.Services.Sprites
{
    [Serializable]
    public sealed class SpriteService : PocoService, ISpritesService
    {
        private IAssetsService _assetsService;
        private const string Sprites = "Sprites/";
        private const string Currency = "Currency/";

        protected override Task OnInitializeAsync(CancellationToken cancellationToken) => Task.CompletedTask;

        protected override Task OnPostInitializeAsync(CancellationToken cancellationToken)
        {
            _assetsService = ServiceLocator.Get<ResourcesAssetsService>();
            return Task.CompletedTask;
        }

        public async Task<Sprite> GetCurrencySpriteAsync(CurrencyType type)
        {
            var path = Sprites + Currency + type;
            var sprite = await _assetsService.Load<Sprite>(path);
            return sprite;
        }
    }
}
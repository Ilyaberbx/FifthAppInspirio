using System.Threading.Tasks;
using Inspirio.Gameplay.Services.Currency;
using Inspirio.Gameplay.Services.Tasks;
using UnityEngine;

namespace Inspirio.Gameplay.Services.Sprites
{
    public interface ISpritesService
    {
        public Task<Sprite> GetCurrencySpriteAsync(CurrencyType type);
        public Task<Sprite> GetPrioritySpriteAsync(TaskPriority priority);
    }
}
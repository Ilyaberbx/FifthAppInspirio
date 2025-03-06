using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Better.Locators.Runtime;
using Better.Saves.Runtime.Data;
using Better.Services.Runtime;
using Inspirio.Gameplay.Data.Persistent;
using Inspirio.Global.Services.Persistence;

namespace Inspirio.Gameplay.Services.Currency
{
    [Serializable]
    public sealed class CurrencyService : PocoService, ICurrencyService
    {
        private IUserService _userService;
        public List<CurrencyData> Current => _userService.Currencies.Value;
        private SavesProperty<List<CurrencyData>> Currencies => _userService.Currencies;
        protected override Task OnInitializeAsync(CancellationToken cancellationToken) => Task.CompletedTask;
        protected override Task OnPostInitializeAsync(CancellationToken cancellationToken)
        {
            _userService = ServiceLocator.Get<UserService>();
            return Task.CompletedTask;
        }
        public void AddCurrency(CurrencyType type, int amount)
        {
            if (amount <= 0)
            {
                return;
            }

            var currency = Currencies.Value.FirstOrDefault(temp => temp.Type == type);
            if (currency == null)
            {
                Currencies.Value.Add(new CurrencyData(type, amount));
                Currencies.SetDirty();
                return;
            }

            currency.Amount += amount;
            Currencies.SetDirty();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Better.Saves.Runtime;
using Better.Saves.Runtime.Data;
using Better.Saves.Runtime.Interfaces;
using Better.Services.Runtime;
using Inspirio.Gameplay.Data.Common;
using Inspirio.Gameplay.Data.Persistent;
using Inspirio.Gameplay.Services.Currency;
using Inspirio.Gameplay.Services.Tasks;

namespace Inspirio.Global.Services.Persistence
{
    [Serializable]
    public sealed class UserService : PocoService, IUserService
    {
        private ISaveSystem _savesSystem;

        protected override Task OnInitializeAsync(CancellationToken cancellationToken)
        {
            _savesSystem = new SavesSystem();
            return Task.CompletedTask;
        }

        protected override Task OnPostInitializeAsync(CancellationToken cancellationToken)
        {
            CurrentWebViewUrl = new SavesProperty<string>(_savesSystem, nameof(CurrentWebViewUrl), string.Empty);
            Currencies = new SavesProperty<List<CurrencyData>>(_savesSystem, nameof(Currencies),
                new List<CurrencyData>()
                {
                    new(CurrencyType.Coins, 50),
                    new(CurrencyType.Diamonds, 100),
                });

            GameTasks = new SavesProperty<List<GameTask>>(_savesSystem, nameof(GameTasks), new List<GameTask>()
            {
                new("Call Client", TaskPriority.RoyalFlush),
                new("Draft Email", TaskPriority.FourOfAKind),
                new("Daily Workout", TaskPriority.FullHouse),
                new("Daily Workout", TaskPriority.Flush),
                new("Team Meeting", TaskPriority.TwoPair),
            });
            return Task.CompletedTask;
        }

        public SavesProperty<string> CurrentWebViewUrl { get; private set; }
        public SavesProperty<List<CurrencyData>> Currencies { get; private set; }
        public SavesProperty<List<GameTask>> GameTasks { get; private set; }
    }
}
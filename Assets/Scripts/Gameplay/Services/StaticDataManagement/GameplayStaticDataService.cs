using System;
using System.Threading;
using System.Threading.Tasks;
using Better.Services.Runtime;
using Inspirio.Gameplay.Data.Static;
using UnityEngine;

namespace Inspirio.Gameplay.Services.StaticDataManagement
{
    [Serializable]
    public sealed class GameplayStaticDataService : PocoService, IGameplayStaticDataService
    {
        [SerializeField] private RewardsConfiguration _rewardsConfiguration;

        protected override Task OnInitializeAsync(CancellationToken cancellationToken) => Task.CompletedTask;
        protected override Task OnPostInitializeAsync(CancellationToken cancellationToken) => Task.CompletedTask;

        public RewardsConfiguration GetRewardsConfiguration() => _rewardsConfiguration;
    }
}
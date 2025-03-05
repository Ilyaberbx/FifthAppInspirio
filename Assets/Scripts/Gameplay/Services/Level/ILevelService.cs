using System;

namespace Inspirio.Gameplay.Services.Level
{
    public interface ILevelService
    {
        public event Action OnSpin;

        public void FireSpin();
    }
}
using Signals;
using UnityEngine;
using Zenject;

namespace Game
{
    public class GameState : ITickable
    {
        private readonly SignalBus _signalBus;
        private float _nextLevelTime = 0;
        private bool _isGameOver = false;

        [Inject]
        public GameState(SignalBus signalBus)
        {
            _signalBus = signalBus;
            _signalBus.Subscribe<PlayerHitSignal>(() => IsGameOver = true);
            _signalBus.Subscribe<RestartSignal>(() =>
            {
                _level = 0;
                _isGameOver = false;
            });
        }

        private int _level = 0;

        public int Level
        {
            get => _level;
            private set
            {
                _level = value;
                _signalBus.Fire(new NextLevelSignal() {CurrentLevel = _level});
            }
        }

        public bool IsGameOver
        {
            get => _isGameOver;
            private set
            {
                _isGameOver = value;
                _signalBus.Fire(new GameOverSignal());
            }
        }

        public void Tick()
        {
            if (Time.time > _nextLevelTime && !_isGameOver)
            {
                Level++;
                _nextLevelTime += 10;
            }
        }
    }
}
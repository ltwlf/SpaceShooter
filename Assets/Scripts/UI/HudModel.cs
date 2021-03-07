using Game;
using Signals;
using UniRx;
using Zenject;

namespace UI
{
    public class HudModel
    {
        private readonly SignalBus _signalBus;
        private ReactiveProperty<int> _score = new ReactiveProperty<int>(0);
        private ReactiveProperty<int> _level = new ReactiveProperty<int>(1);
        private ReactiveProperty<bool> _gameOver = new ReactiveProperty<bool>(false);

        public ReactiveProperty<int> Score => _score;
        public ReactiveProperty<int> Level => _level;
        public ReactiveProperty<bool> GameOver => _gameOver;

        [Inject]
        public HudModel(SignalBus signalBus)
        {
            _signalBus = signalBus;
            _signalBus.Subscribe<AsteroidDestroyedSignal>(() => _score.Value++);
            _signalBus.Subscribe<NextLevelSignal>(nextLevel =>
            {
                _level.Value = nextLevel.CurrentLevel;
            });
            _signalBus.Subscribe<GameOverSignal>(() => _gameOver.Value = true );
        }

        public void Restart()
        {
            _score.Value = 0;
            _level.Value = 1;
            _gameOver.Value = false;
            _signalBus.Fire<RestartSignal>();
        }
    }
}
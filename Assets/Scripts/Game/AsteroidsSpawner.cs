using System;
using System.Collections.Generic;
using Asteroids;
using Cysharp.Threading.Tasks;
using Misc;
using Signals;
using UniRx;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Game
{
    public class AsteroidsSpawner : IInitializable
    {
        private readonly Asteroid.Factory _factory;
        private readonly LevelBoundary _boundary;
        private readonly Settings _settings;
        private readonly SignalBus _signalBus;
        private readonly GameState _gameState;
        private int _waitBeforeNextWave = 5;

        [Inject]
        public AsteroidsSpawner(Asteroid.Factory factory, LevelBoundary boundary, Settings settings,
            GameState gameState, SignalBus signalBus)
        {
            _factory = factory;
            _boundary = boundary;
            _settings = settings;
            _gameState = gameState;
            _signalBus = signalBus;
            
            _signalBus.Subscribe<RestartSignal>(() => SpawnWave().Forget());
        }


        public void Initialize()
        {
            SpawnWave().Forget();
        }

        private async UniTaskVoid SpawnWave()
        {
            var level = _gameState.Level;

            await UniTask.Delay(_waitBeforeNextWave);

            var asteroidsToSpawn = 5 + level;

            for (var i = 0; i < asteroidsToSpawn; i++)
            {
                Spawn();
                await UniTask.Delay(Mathf.Clamp(Random.Range(0, 2000 - level * 100), 0, 2000));
            }

            if (!_gameState.IsGameOver)
            {
                SpawnWave().Forget();   
            }
        }

        private void Spawn()
        {
            var asteroid =
                _factory.Create(_settings.Prefabs[Random.Range(0, _settings.Prefabs.Count - 1)]);
            asteroid.Position += new Vector3(Random.Range(_boundary.Left, _boundary.Right), 0, 0);
        }

        [Serializable]
        public class Settings
        {
            public List<GameObject> Prefabs = new List<GameObject>();
        }
    }
}
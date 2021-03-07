using System;
using Services.InputAdapter;
using UniRx;
using UnityEngine;
using Zenject;

namespace Player
{
    public class PlayerFireHandler : IInitializable
    {
        private readonly IInputAdapter _input;
        private readonly PlayerLaserShot.Factory _factory;
        private readonly Player _player;
        private readonly Settings _settings;

        public PlayerFireHandler(IInputAdapter input, PlayerLaserShot.Factory factory, Player player, Settings settings)
        {
            _input = input;
            _factory = factory;
            _player = player;
            _settings = settings;
        }

        public void Initialize()
        {
            Observable.EveryUpdate()
                .Where(x => _input.Fire)
                .First()
                .Do(_ =>
                {
                    var laser = _factory.Create();
                    laser.transform.position = _player.transform.position;
                })
                .Delay(TimeSpan.FromMilliseconds(_settings.FireRate))
                .Repeat()
                .Subscribe();
        }

        [Serializable]
        public class Settings
        {
            public float FireRate = 250;
        }
    }
}
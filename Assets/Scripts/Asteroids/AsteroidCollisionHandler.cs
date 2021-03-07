using System;
using Player;
using Signals;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using Zenject;

namespace Asteroids
{
    public class AsteroidCollisionHandler : IDisposable, IInitializable
    {
        private readonly Collider _collider;
        private readonly Asteroid _asteroid;
        private readonly SignalBus _signalBus;
        private readonly AsteroidExplosion.Factory _explosionFactory;
        private readonly CompositeDisposable _disposable = new CompositeDisposable();

        [Inject]
        public AsteroidCollisionHandler(Collider collider, Asteroid asteroid, SignalBus signalBus, AsteroidExplosion.Factory explosionFactory)
        {
            _collider = collider;
            _asteroid = asteroid;
            _signalBus = signalBus;
            _explosionFactory = explosionFactory;
        }
        
        public void Initialize()
        {
            _collider.OnTriggerEnterAsObservable().Do(other =>
            {
                var player = other.gameObject.GetComponent<IPlayer>();
                if (player != null)
                {
                    player.Hit();
                    Explode();
                }

                var laser = other.gameObject.GetComponent<Player.PlayerLaserShot>();
                if (laser)
                {
                    _signalBus.Fire<AsteroidDestroyedSignal>();
                    laser.Kill();
                    Explode();
                }
                
            }).Subscribe().AddTo(_disposable);
        }

        private void Explode()
        {
            var explosion = _explosionFactory.Create();
            explosion.Position = _asteroid.Position;
            _asteroid.Kill(explosion.EffectDuration);
        }

        public void Dispose()
        {
            _disposable?.Dispose();
        }
        
    }
}
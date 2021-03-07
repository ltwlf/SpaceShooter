using Game;
using Signals;
using UnityEngine;
using Zenject;

namespace Player
{
    public class PlayerHitHandler
    {
        private readonly SignalBus _signalBus;
        private readonly Player _player;
        private readonly PlayerExplosion.Factory _explosionFactory;

        [Inject]
        public PlayerHitHandler(SignalBus signalBus, Player player, PlayerExplosion.Factory explosionFactory)
        {
            _signalBus = signalBus;
            _player = player;
            _explosionFactory = explosionFactory;
        }

        public void Hit()
        {
            _player.gameObject.SetActive(false);
            _explosionFactory.Create();
            _signalBus.Fire<PlayerHitSignal>();
        }
        
    }
}
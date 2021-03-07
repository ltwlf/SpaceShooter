using System;
using System.Runtime.Remoting.Messaging;
using Signals;
using UnityEngine;
using Zenject;

namespace Player
{
    public interface IPlayer
    {
        void Hit();
        
        Transform Transform { get; }
    }
    
    public class Player : MonoBehaviour, IPlayer
    {
        private PlayerState _state;
        private PlayerHitHandler _hitHandler;
        private SignalBus _signalBus;
        
        [Inject]
        public void Construct(PlayerState state, PlayerHitHandler hitHandler, SignalBus signalBus)
        {
            _state = state;
            _hitHandler = hitHandler;
            _signalBus = signalBus;
            _signalBus.Subscribe<RestartSignal>(() => Restart());
        }

        public Vector3 Position
        {
            get => _state.Position;
        }
        
        public void Hit()
        {
            _hitHandler.Hit();
        }

        public Transform Transform
        {
            get => transform;
        }

        public void Restart()
        {
            gameObject.SetActive(true);
            transform.localPosition = new Vector3();
        }
    }
}
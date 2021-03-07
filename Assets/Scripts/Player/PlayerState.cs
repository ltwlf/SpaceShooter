using UnityEngine;
using Zenject;

namespace Player
{
    public class PlayerState
    {
        private readonly Rigidbody _rigidbody;

        [Inject]
        public PlayerState(Rigidbody rigidbody)
        {
            _rigidbody = rigidbody;
        }
        
        public Vector3 Position
        {
            get => _rigidbody.position;
            set => _rigidbody.position = value;
        }

        public Vector3 Velocity
        {
            get => _rigidbody.velocity;
            set => _rigidbody.velocity = value;
        }

        public Quaternion Rotation
        {
            get => _rigidbody.rotation;
            set => _rigidbody.rotation = value;
        }
        
    }
}
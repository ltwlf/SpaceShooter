using UnityEngine;
using Zenject;

namespace Asteroids
{
    public class AsteroidMoveHandler: IInitializable
    {
        private readonly Rigidbody _rigidbody;

        [Inject]
        public AsteroidMoveHandler(Rigidbody rigidbody )
        {
            _rigidbody = rigidbody;
        }

        public void Initialize()
        {
            _rigidbody.velocity = Vector3.back * 5; 
        }
    }
}
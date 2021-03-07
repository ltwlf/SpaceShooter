using System;
using UniRx;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;
using Random = UnityEngine.Random;

namespace Asteroids
{
    public class AsteroidRotationHandler: IInitializable
    {
        private readonly Rigidbody _rigidbody;
        private readonly Settings _settings;

        [Inject]
        public AsteroidRotationHandler(Rigidbody rigidbody, Settings settings)
        {
            _rigidbody = rigidbody;
            _settings = settings;
        }
        
        public void Initialize()
        {
            _rigidbody.angularVelocity = Random.insideUnitSphere * _settings.Tumble;
        }
        

        [Serializable]
        public class Settings
        {
            public float Tumble = 5;
        }
    }
}
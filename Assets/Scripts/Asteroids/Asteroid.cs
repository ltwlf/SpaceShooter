using System;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using Zenject;

namespace Asteroids
{
    public class Asteroid : MonoBehaviour
    {
        private Rigidbody _asteroidRigidbody = null;

        [Inject]
        public void Construct(Rigidbody asteroidRigidbody)
        {
            _asteroidRigidbody = asteroidRigidbody;
            _asteroidRigidbody.OnDestroyAsObservable().Subscribe(_ => { Destroy(gameObject); });
        }

        public void Kill(float time = 0)
        {
            _asteroidRigidbody.gameObject.SetActive(false);
            Destroy(gameObject, time);
        }
        
        public Vector3 Position
        {
            get => _asteroidRigidbody.position;
            set => _asteroidRigidbody.position = value;
        }

        public class Factory : PlaceholderFactory<GameObject, Asteroid>
        {
        }
    }
}
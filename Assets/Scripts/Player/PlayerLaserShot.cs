using System;
using UnityEngine;
using Zenject;

namespace Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerLaserShot : MonoBehaviour
    {
        private Settings _settings;
        private Rigidbody _rigidbody;

        [Inject]
        public void Construct(Settings settings)
        {
            _settings = settings;
        }

        public void Kill()
        {
            Destroy(gameObject);
        }

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        void Start()
        {
            _rigidbody.velocity = Vector3.forward * _settings.Speed;
        }

        public class Factory : PlaceholderFactory<PlayerLaserShot>
        {
        }

        [Serializable]
        public class Settings
        {
            public float Speed = 40;
        }
    }
}
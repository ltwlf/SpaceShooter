using System;
using UnityEngine;
using Zenject;
using Zenject.SpaceFighter;

namespace Asteroids
{
    public class AsteroidExplosion : MonoBehaviour
    {
        public Vector3 Position
        {
            set => transform.position = value;
        }

        public float EffectDuration
        {
            get => GetComponent<ParticleSystem>().main.duration;
        }

        [Serializable]
        public class Settings
        {
            public GameObject ExplosionPrefab = null;
        }
        
        public class Factory : PlaceholderFactory<AsteroidExplosion>
        {
        }
        
    }
}
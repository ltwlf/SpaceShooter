using System;
using UnityEngine;
using UnityEngine.UIElements;
using Zenject;

namespace Player
{
    public class PlayerExplosion: MonoBehaviour
    {
        public Vector3 Position
        {
            set => transform.position  = value;
        }
        
        [Serializable]
        public class Settings
        {
            public GameObject ExplosionPrefab = null;
        }
        
        public class Factory : PlaceholderFactory<PlayerExplosion>
        {
            private readonly IPlayer _player;

            [Inject]
            public Factory(IPlayer player)
            {
                _player = player;
            }

            public override PlayerExplosion Create()
            {
                var explosion = base.Create();
                explosion.Position = _player.Transform.position;
                return explosion;
            }
        }
    }
}
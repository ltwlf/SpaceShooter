using System;
using Misc;
using Services.InputAdapter;
using UnityEngine;
using Zenject;

namespace Player
{
    public class PlayerMoveHandler : IFixedTickable
    {
        private readonly Settings _settings;
        private readonly PlayerState _playerState;
        private readonly LevelBoundary _boundary;
        private readonly IInputAdapter _input;

        public PlayerMoveHandler(Settings settings, PlayerState playerState, LevelBoundary boundary,
            IInputAdapter input)
        {
            _settings = settings;
            _playerState = playerState;
            _boundary = boundary;
            _input = input;
        }

        public void FixedTick()
        {
            Move();
            EnsureBoundaries();
        }

        private void Move()
        {
            var velocity = new Vector3(_input.Horizontal, 0.0f, _input.Vertical) * _settings.Speed;
            var rotation = Quaternion.Euler(0.0f, 0.0f, velocity.x * -_settings.Tilt);

            _playerState.Velocity = velocity;
            _playerState.Rotation = rotation;
        }

        private void EnsureBoundaries()
        {
            _playerState.Position = new Vector3
            (
                Mathf.Clamp(_playerState.Position.x, _boundary.Left, _boundary.Right),
                0.0f,
                Mathf.Clamp(_playerState.Position.z, _boundary.Bottom, _boundary.Top)
            );
        }

        [Serializable]
        public class Settings
        {
            public int Speed = 20;
            public int Tilt = 5;
        }
    }
}
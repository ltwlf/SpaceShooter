using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using Asteroids;
using Game;
using Player;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}
    
[CreateAssetMenu(fileName = "Settings", menuName = "Ltwlf/Settings", order = 0)]
public class GameSettingsInstaller : ScriptableObjectInstaller<GameSettingsInstaller>
{
    public PlayerSettings Player = null;
    public AsteroidSettings Asteroid = null;
    
    
    [Serializable]
    public class PlayerSettings
    {
        public PlayerMoveHandler.Settings Settings = null;
        public PlayerLaserShot.Settings Laser = null;
        public PlayerFireHandler.Settings FireRate = null;
        public PlayerExplosion.Settings Expolsion;
    }

    [Serializable]
    public class AsteroidSettings
    {
        public AsteroidsSpawner.Settings Asteroids = null;
        public AsteroidExplosion.Settings Explosion = null;
    }

    public override void InstallBindings()
    {
        Container.BindInstance(Player.Settings).IfNotBound();
        Container.BindInstance(Player.Laser).IfNotBound();
        Container.BindInstance(Player.FireRate).IfNotBound();
        Container.BindInstance(Player.Expolsion).IfNotBound();
        Container.BindInstance(Asteroid.Asteroids).IfNotBound();
        Container.BindInstance(Asteroid.Explosion).IfNotBound();
    }
}
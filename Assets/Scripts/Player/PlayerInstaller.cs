using System;
using Player;
using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField] private PlayerSettings _settings = null;


    [Inject]
    private PlayerExplosion.Settings playerExplosionSettings;
    
    public override void InstallBindings()
    {
        Container.BindInstance(_settings.Rigidbody).AsSingle();
        Container.BindInstance(_settings.MeshRenderer).AsSingle();
        
        Container.BindFactory<PlayerLaserShot, PlayerLaserShot.Factory>()
            .FromNewComponentOnNewPrefab(_settings.LaserPrefab).UnderTransformGroup("LaserShots");

        Container.BindFactory<PlayerExplosion, PlayerExplosion.Factory>()
            .FromNewComponentOnNewPrefab(playerExplosionSettings.ExplosionPrefab);

        Container.Bind<PlayerState>().AsSingle();
        Container.Bind<PlayerHitHandler>().AsSingle();
        Container.BindInterfacesAndSelfTo<PlayerMoveHandler>().AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<PlayerFireHandler>().AsSingle().NonLazy();
    }

    [Serializable]
    public class PlayerSettings
    {
        public Rigidbody Rigidbody;
        public MeshRenderer MeshRenderer;
        public GameObject LaserPrefab;
    }
}
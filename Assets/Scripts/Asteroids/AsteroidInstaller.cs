using UnityEngine;
using Zenject;

namespace Asteroids
{
    public class AsteroidsInstaller : Installer<AsteroidsInstaller>
    {
        [Inject] public GameObject Prefab;
        [Inject] public AsteroidExplosion.Settings ExplosionSettings;

        public override void InstallBindings()
        {
            Container.Bind<AsteroidRotationHandler.Settings>().FromInstance(new AsteroidRotationHandler.Settings()
            {
                Tumble = 5
            });
            Container.Bind(typeof(Rigidbody), typeof(Collider)).FromComponentInNewPrefab(Prefab).AsSingle();
            Container.BindInterfacesAndSelfTo<AsteroidCollisionHandler>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<AsteroidMoveHandler>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<AsteroidRotationHandler>().AsSingle().NonLazy();
            Container.Bind<Asteroid>().FromNewComponentOnRoot().AsSingle().NonLazy();

            Container.BindFactory<AsteroidExplosion, AsteroidExplosion.Factory>()
                .FromNewComponentOnNewPrefab(ExplosionSettings.ExplosionPrefab);
        }
    }
}
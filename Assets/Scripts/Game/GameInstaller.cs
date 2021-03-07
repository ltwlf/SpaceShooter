using System;
using System.ComponentModel;
using Asteroids;
using Game;
using Misc;
using Player;
using Services.InputAdapter;
using Signals;
using UI;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        SignalBusInstaller.Install(Container);

        Container.DeclareSignal<PlayerHitSignal>();
        Container.DeclareSignal<AsteroidDestroyedSignal>();
        Container.DeclareSignal<NextLevelSignal>();
        Container.DeclareSignal<GameOverSignal>();
        Container.DeclareSignal<RestartSignal>();
        
        Container.BindInterfacesAndSelfTo<GameState>().AsSingle();
        
        Container.Bind<IInputAdapter>().To<KeyboardInputAdapter>().AsSingle();
        Container.BindInterfacesAndSelfTo<LevelBoundary>().AsSingle();
        
        // Asteroids
        Container.BindFactory<GameObject, Asteroid, Asteroid.Factory>().FromSubContainerResolve()
            .ByNewGameObjectInstaller<AsteroidsInstaller>().WithGameObjectName("Asteroid")
            .UnderTransformGroup("Asteroids");
        Container.BindInterfacesAndSelfTo<AsteroidsSpawner>().AsSingle().NonLazy();
        
    }
}
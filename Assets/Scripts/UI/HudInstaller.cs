using UI;
using UnityEngine;
using Zenject;

public class HudInstaller : MonoInstaller<HudInstaller>
{
    public override void InstallBindings()
    {
        // Container.BindInterfacesAndSelfTo<HudView>().FromComponentInChildren().AsSingle();
        Container.BindInterfacesAndSelfTo<HudModel>().AsSingle();
        Container.BindInterfacesAndSelfTo<HudPresenter>().AsSingle().NonLazy();
    }
}
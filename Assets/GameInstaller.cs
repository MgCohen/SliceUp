using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        SignalBusInstaller.Install(Container);

        Container.BindInterfacesAndSelfTo<Controller>().AsSingle().NonLazy();

        Container.DeclareSignal<OnLockSignal>().OptionalSubscriber();
        Container.DeclareSignal<OnTapSignal>().OptionalSubscriber();
    }
}
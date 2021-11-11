using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{

    [SerializeField]
    public FloatingText m_floatingTextPrefab;
    public override void InstallBindings()
    {
        SignalBusInstaller.Install(Container);

        Container.BindInterfacesAndSelfTo<Controller>().AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<FloatingTextManager>().AsSingle().NonLazy();

        Container.DeclareSignal<OnLockSignal>().OptionalSubscriber();
        Container.DeclareSignal<OnTapSignal>().OptionalSubscriber();
        Container.DeclareSignal<OnObstacleDestroyedSignal>().OptionalSubscriber();

        Container.BindFactory<string, Transform, FloatingText, FloatingText.Factory>().FromComponentInNewPrefab(m_floatingTextPrefab).AsSingle();
    }
}
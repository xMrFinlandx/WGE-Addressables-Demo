using Zenject;

namespace AddressablesDemo
{
    public class PlayerSceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<AddressablesPlayerController>()
                .FromComponentInHierarchy()
                .AsSingle();

            Container.BindInterfacesAndSelfTo<PlayerLifecycleService>()
                .AsSingle()
                .NonLazy();
        }
    }
}

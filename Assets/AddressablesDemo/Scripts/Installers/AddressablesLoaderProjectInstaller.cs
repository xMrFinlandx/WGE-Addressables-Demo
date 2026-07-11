using Zenject;

namespace AddressablesDemo
{
    public class AddressablesLoaderProjectInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<AddressablesLoader>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<SceneLoader>().AsSingle().NonLazy();
        }
    }
}
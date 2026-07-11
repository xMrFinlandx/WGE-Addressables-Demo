using Zenject;

namespace AddressablesDemo
{
    public class GameStatsProjectInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<GraphDataService>().AsSingle();
        }
    }
}
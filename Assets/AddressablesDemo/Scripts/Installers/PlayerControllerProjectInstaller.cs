using UnityEngine;
using Zenject;

namespace AddressablesDemo
{
    public class PlayerControllerProjectInstaller : MonoInstaller
    {
        [SerializeField] private AddressablesPlayerController _playerPrefab;
        
        public override void InstallBindings()
        {
            Container.Bind<AddressablesPlayerController>().FromInstance(_playerPrefab);
            Container.BindInterfacesAndSelfTo<PlayerLifecycleService>().AsSingle().NonLazy();
        }
    }
}
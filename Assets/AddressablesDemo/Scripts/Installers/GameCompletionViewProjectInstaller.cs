using UnityEngine;
using Zenject;

namespace AddressablesDemo
{
    public class GameCompletionViewProjectInstaller : MonoInstaller
    {
        [SerializeField] private GameCompletionViewService _viewService;
        
        public override void InstallBindings()
        {
            Container.Bind<GameCompletionViewService>()
                .FromComponentInNewPrefab(_viewService)
                .AsSingle()
                .NonLazy();
        }
    }
}
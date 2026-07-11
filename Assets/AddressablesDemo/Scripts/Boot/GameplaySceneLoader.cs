using System.Threading;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;

namespace AddressablesDemo.Boot
{
    public class GameplaySceneLoader : MonoBehaviour
    {
        [SerializeField] private AssetReference _firstScene;

        private ISceneLoader _sceneLoader;

        [Inject]
        public void Construct(ISceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }

        public async void Start()
        {
            await _sceneLoader.LoadAsync(_firstScene, CancellationToken.None);
        }
    }
}
    
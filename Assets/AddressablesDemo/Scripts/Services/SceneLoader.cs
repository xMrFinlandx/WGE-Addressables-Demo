using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

namespace AddressablesDemo
{
    public class SceneLoader : ISceneLoader
    {
        private readonly IAddressablesLoader _loader;
        private SceneInstance? _currentScene;

        public SceneLoader(IAddressablesLoader loader)
        {
            _loader = loader;
        }

        public Task LoadAsync(string address, CancellationToken token)
            => LoadInternalAsync(address, token);

        public Task LoadAsync(AssetReference reference, CancellationToken token)
            => LoadInternalAsync((string)reference.RuntimeKey, token);

        private async Task LoadInternalAsync(string address, CancellationToken token)
        {
            Scene previousActive = SceneManager.GetActiveScene();
            SceneInstance? previousAddressables = _currentScene;

            SceneInstance? loaded = await _loader.LoadSceneAsync(address, token);

            if (loaded == null)
            {
                Debug.LogError($"Failed to load Addressables scene '{address}'");
                return;
            }

            _currentScene = loaded;
            SceneManager.SetActiveScene(loaded.Value.Scene);

            if (previousAddressables != null)
                await _loader.UnloadSceneAsync(previousAddressables.Value, token);
            else if (previousActive.IsValid() && previousActive.isLoaded)
                await SceneManager.UnloadSceneAsync(previousActive);
        }
    }
}

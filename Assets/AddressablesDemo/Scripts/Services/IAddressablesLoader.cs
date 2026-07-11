using System.Threading;
using System.Threading.Tasks;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

namespace AddressablesDemo
{
    public interface IAddressablesLoader
    {
        public Task<SceneInstance?> LoadSceneAsync(string address, CancellationToken token, LoadSceneMode mode = LoadSceneMode.Additive);

        public Task<bool> UnloadSceneAsync(SceneInstance scene, CancellationToken token);
    }
}
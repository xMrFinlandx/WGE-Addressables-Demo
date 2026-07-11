using System.Threading;
using System.Threading.Tasks;
using UnityEngine.AddressableAssets;

namespace AddressablesDemo
{
    public interface ISceneLoader
    {
        public Task LoadAsync(string address, CancellationToken token);
        public Task LoadAsync(AssetReference reference, CancellationToken token);
    }
}

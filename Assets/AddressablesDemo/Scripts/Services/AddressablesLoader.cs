using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

namespace AddressablesDemo
{
    public class AddressablesLoader : IAddressablesLoader
    {
        public async Task<SceneInstance?> LoadSceneAsync(string address, CancellationToken token, LoadSceneMode mode = LoadSceneMode.Additive)
        {
            try
            {
                token.ThrowIfCancellationRequested();

                AsyncOperationHandle<SceneInstance> handle = Addressables.LoadSceneAsync(address, mode);
                SceneInstance scene = await handle.Task;

                return scene;
            }
            catch (OperationCanceledException)
            {
                Debug.Log($"Cancelled scene '{address}'");
                return null;
            }
            catch (Exception e)
            {
                Debug.LogException(e);
                return null;
            }
        }

        public async Task<bool> UnloadSceneAsync(SceneInstance scene, CancellationToken token)
        {
            try
            {
                token.ThrowIfCancellationRequested();

                AsyncOperationHandle<SceneInstance> handle = Addressables.UnloadSceneAsync(scene);
                await handle.Task;

                Debug.Log("Scene Unloaded");
                return true;
            }
            catch (OperationCanceledException)
            {
                Debug.Log("Cancelled");
                return false;
            }
            catch (Exception e)
            {
                Debug.LogException(e);
                return false;
            }
        }
    }
}
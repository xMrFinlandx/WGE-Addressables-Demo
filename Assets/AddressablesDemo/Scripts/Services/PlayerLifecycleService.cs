using System;
using UnityEngine;
using WorldGraphEditor;

namespace AddressablesDemo
{
    public class PlayerLifecycleService : IDisposable
    {
        private readonly ITransitionManager _manager;
        private readonly AddressablesPlayerController _controller;

        public PlayerLifecycleService(ITransitionManager manager, AddressablesPlayerController controller)
        {
            _manager = manager;
            _controller = controller;

            _manager.TransitionStarted += OnTransitionStarted;
            _manager.SceneLoaded += OnSceneLoaded;
            
            _controller.EnableMovement();
        }

        private void OnTransitionStarted()
        {
            _controller.DisableMovement();

            if (_manager.InputTransitionComponent is IPuller puller)
                _controller.SetPullForce(puller.GetPullData());
        }

        private void OnSceneLoaded()
        {
            _controller.transform.position = _manager.NextSpawnPosition;
            
            if (_manager.OutputTransitionComponent is IPusher pusher)
                _controller.SetPushForce(pusher.GetPushData());

            _controller.EnableMovement();
        }
        
        public void Dispose()
        {
            _manager.TransitionStarted -= OnTransitionStarted;
            _manager.SceneLoaded -= OnSceneLoaded;
        }
    }
}

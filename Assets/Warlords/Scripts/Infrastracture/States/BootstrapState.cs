using UnityEngine;

namespace Warlords.Infrastracture.States
{
    public class BootstrapState : IState
    {
        private StateMachine _stateMachine;
        private SceneLoader _sceneLoader;

        public BootstrapState(SceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }
        
        public async void Enter()
        {
            _sceneLoader.LoadScene("MainMenu");
        }

        public void Exit()
        {
            
        }
    }
}
using Warlords.Utils;

namespace Warlords.Infrastructure.States
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
            _sceneLoader.LoadScene(Constants.SceneNames.MainMenu);
        }

        public void Exit()
        {
            
        }
    }
}
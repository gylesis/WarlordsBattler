using Cysharp.Threading.Tasks;
using Warlords.Utils;

namespace Warlords.Infrastructure.States
{
    public class BootstrapState : IState
    {
        private readonly SceneLoader _sceneLoader;
        private readonly ISaveLoadDataService _saveLoadDataService;

        public BootstrapState(SceneLoader sceneLoader, ISaveLoadDataService saveLoadDataService)
        {
            _saveLoadDataService = saveLoadDataService;
            _sceneLoader = sceneLoader;
        }

        public async UniTask Enter()
        {
            await _saveLoadDataService.Load();

            //await _sceneLoader.LoadScene(Constants.SceneNames.BattleLevel);
            await _sceneLoader.LoadScene(Constants.SceneNames.MainMenu);
        }

        public async UniTask Exit()
        {
            
        }
    }
}
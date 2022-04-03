using Cysharp.Threading.Tasks;
using Warlords.Utils;

namespace Warlords.Battle
{
    public class BattleGameStarter // here will be some configs
    {
        private readonly SceneLoader _sceneLoader;

        public BattleGameStarter(SceneLoader sceneLoader)   
        {
            _sceneLoader = sceneLoader;
        }

        public async UniTask StartRankedGame()
        {
            await LoadScene();
        }

        public async UniTask StartCasualGame()
        {
            await LoadScene();
        }

        private async UniTask LoadScene()
        {
            await _sceneLoader.LoadScene(Constants.SceneNames.BattleLevel);
        }
    }
    
}

using Cysharp.Threading.Tasks;

namespace Warlords.Battle
{
    public class BattleAreaStarter
    {
        private readonly BattleAreaCurtain _battleAreaCurtain;
        private readonly BattleGamePoller _battleGamePoller;

        public BattleAreaStarter(BattleAreaCurtain battleAreaCurtain, BattleGamePoller battleGamePoller)
        {
            _battleGamePoller = battleGamePoller;
            _battleAreaCurtain = battleAreaCurtain;
        }
        public async void StartGame(GameModeType gameModeType)
        {
            switch (gameModeType)
            {
                case GameModeType.Casual:
                    await StartCasualGame();
                    break;
                case GameModeType.Ranked:
                    await StartRankedGame();
                    break;
            }
        }

        private async UniTask StartCasualGame()
        {
            _battleAreaCurtain.Show();

            UniTask findCasualGame = _battleGamePoller.FindCasualGame((() =>
            {
                _battleAreaCurtain.UpdateTitle("You found casual game!");

            }));
            await findCasualGame;
            
            _battleAreaCurtain.Hide();
        }

        private async UniTask StartRankedGame()
        {
            _battleAreaCurtain.Show();

            UniTask findRankedGame = _battleGamePoller.FindRankedGame((() =>
            {
                _battleAreaCurtain.UpdateTitle("You found ranked game!");

            }));
            await findRankedGame;
            
            _battleAreaCurtain.Hide();
        }
    }
}
using Cysharp.Threading.Tasks;
using UniRx;

namespace Warlords.Battle
{
    public class BattleGameFinder
    {
        private readonly BattleAreaCurtain _battleAreaCurtain;
        private readonly BattleGamePoller _battleGamePoller;
        private readonly BattleGameStarter _battleGameStarter;
        private readonly AcceptButtonsPopUp _acceptButtonsPopUp;

        public BattleGameFinder(BattleAreaCurtain battleAreaCurtain, BattleGamePoller battleGamePoller,
            BattleGameStarter battleGameStarter, AcceptButtonsPopUp acceptButtonsPopUp)
        {
            _acceptButtonsPopUp = acceptButtonsPopUp;
            _battleGameStarter = battleGameStarter;
            _battleGamePoller = battleGamePoller;
            _battleAreaCurtain = battleAreaCurtain;
        }

        public async void StartGame(GameModeType gameModeType)
        {
            UniTask task;

            switch (gameModeType)
            {
                case GameModeType.Casual:
                    task = StartCasualGame();
                    break;
                case GameModeType.Ranked:
                    task = StartRankedGame();
                    break;
                default:
                    task = StartCasualGame();
                    break;
            }

            await task;
        }

        private async UniTask StartCasualGame()
        {
            _battleAreaCurtain.Show();

            UniTask findCasualGame = _battleGamePoller.FindCasualGame(FoundGame);

            async void FoundGame()
            {
                _battleAreaCurtain.UpdateTitle("You found casual game!");

                bool decisionMade = false;
                
                _acceptButtonsPopUp.gameObject.SetActive(true);
                _acceptButtonsPopUp.DecisionMake.Take(1).Subscribe((decision => decisionMade = decision));

                await UniTask.WaitUntil((() => decisionMade));
                
                await _battleGameStarter.StartCasualGame();

                _battleAreaCurtain.Hide();
            }

            await findCasualGame;
        }

        private async UniTask StartRankedGame()
        {
            _battleAreaCurtain.Show();

            UniTask findRankedGame = _battleGamePoller.FindRankedGame(FoundGame);

            async void FoundGame()
            {
                _battleAreaCurtain.UpdateTitle("You found ranked game!");

                bool decisionMade = false;
                
                _acceptButtonsPopUp.gameObject.SetActive(true);
                _acceptButtonsPopUp.DecisionMake.Take(1).Subscribe((decision => decisionMade = decision));

                await UniTask.WaitUntil((() => decisionMade));
                
                await _battleGameStarter.StartRankedGame();

                _battleAreaCurtain.Hide();
            }

            await findRankedGame;
        }
    }
}
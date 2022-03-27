using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;

namespace Warlords.Battle
{
    public class BattleGameFinder
    {
        private readonly BattleAreaCurtain _battleAreaCurtain;
        private readonly BattleGamePoller _battleGamePoller;
        private readonly BattleGameStarter _battleGameStarter;
        private readonly AcceptButtonsPopUp _acceptButtonsPopUp;
        private readonly RedirectionService _redirectionService;

        public BattleGameFinder(BattleAreaCurtain battleAreaCurtain, BattleGamePoller battleGamePoller,
            BattleGameStarter battleGameStarter, AcceptButtonsPopUp acceptButtonsPopUp, RedirectionService redirectionService)
        {
            _redirectionService = redirectionService;
            _acceptButtonsPopUp = acceptButtonsPopUp;
            _battleGameStarter = battleGameStarter;
            _battleGamePoller = battleGamePoller;
            _battleAreaCurtain = battleAreaCurtain;
        }

        public async void StartGame(GameModeType gameModeType)
        {
            UniTask task;
            _battleAreaCurtain.Show();

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
            UniTask findCasualGame = _battleGamePoller.FindCasualGame((() => FoundGame(GameModeType.Casual)));

            await findCasualGame;
        }

        async void FoundGame(GameModeType gameModeType)
        {
            _battleAreaCurtain.UpdateTitle($"You found {gameModeType} game!");
            _battleAreaCurtain.StopStopwatch();

            var decision = await WaitForDecision();

            if (decision == false)
            {
                _battleAreaCurtain.Hide();
                _redirectionService.ShowMainMenu();
                return;
            }

            if (gameModeType == GameModeType.Casual)
            {
                await _battleGameStarter.StartCasualGame();
            }
            else if (gameModeType == GameModeType.Ranked)
            {
                await _battleGameStarter.StartRankedGame();
            }

            _battleAreaCurtain.Hide();
        }

        private async UniTask<bool> WaitForDecision()
        {
            bool decisionMade = false;
            int temp = 0;
            
            _acceptButtonsPopUp.gameObject.SetActive(true);
            _acceptButtonsPopUp.DecisionMake.Take(1).Subscribe((decision =>
            {
                decisionMade = decision;
                temp = 1;
            }));

            await UniTask.WaitUntil((() => temp == 1));
            
            return decisionMade;
        }

        private async UniTask StartRankedGame()
        {
            UniTask findRankedGame = _battleGamePoller.FindRankedGame((() => FoundGame(GameModeType.Ranked)));

            await findRankedGame;
        }
    }


    public interface IGameSearchListener
    {
        
    }
    
}
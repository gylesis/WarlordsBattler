using UniRx;
using Warlords.Utils;

namespace Warlords.Battle
{
    public class GameModeButtonsHandler
    {
        private readonly BattleGameFinder _battleGameFinder;
        private readonly GameModeButtonsContainer _gameModeButtonsContainer;
     
        private GameModeButtonsHandler(BattleGameFinder battleGameFinder, GameModeButtonsContainer gameModeButtonsContainer)
        {
            _gameModeButtonsContainer = gameModeButtonsContainer;
            _battleGameFinder = battleGameFinder;
            
            foreach (GameModeButton gameModeButton in _gameModeButtonsContainer.GameModeButtons)
                gameModeButton.Clicked.TakeUntilDestroy(gameModeButton).Subscribe((OnClicked));
        }

        private void OnClicked(EventContext<GameModeButton, GameModeType> context)
        {
            GameModeType gameModeType = context.Value;

            _battleGameFinder.StartGame(gameModeType);

            _gameModeButtonsContainer.Hide();
        }
    }
}
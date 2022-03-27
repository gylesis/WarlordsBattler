using UniRx;
using UnityEngine;
using Warlords.Utils;
using Zenject;

namespace Warlords.Battle
{
    public class GameModeButtonsHandler : MonoBehaviour
    {
        private BattleGameFinder _battleGameFinder;
        private GameModeButtonsContainer _gameModeButtonsContainer;

        [Inject]
        private void Init(BattleGameFinder battleGameFinder, GameModeButtonsContainer gameModeButtonsContainer)
        {
            _gameModeButtonsContainer = gameModeButtonsContainer;
            _battleGameFinder = battleGameFinder;
            
            foreach (GameModeButton gameModeButton in _gameModeButtonsContainer.GameModeButtons)
                gameModeButton.Clicked.TakeUntilDestroy(this).Subscribe((OnClicked));
        }

        private void OnClicked(EventContext<GameModeButton, GameModeType> context)
        {
            GameModeType gameModeType = context.Value;

            _battleGameFinder.StartGame(gameModeType);

            _gameModeButtonsContainer.Hide();
        }
    }
}
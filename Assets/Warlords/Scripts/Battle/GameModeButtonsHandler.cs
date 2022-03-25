using UniRx;
using UnityEngine;
using Warlords.Utils;
using Zenject;

namespace Warlords.Battle
{
    public class GameModeButtonsHandler : MonoBehaviour
    {
        [SerializeField] private GameModeButton[] _gameModeButtons;

        private BattleAreaStarter _battleAreaStarter;

        [Inject]
        private void Init(BattleAreaStarter battleAreaStarter)
        {
            _battleAreaStarter = battleAreaStarter;
        }
        
        private void Awake()
        {
            foreach (GameModeButton gameModeButton in _gameModeButtons)
                gameModeButton.Clicked.TakeUntilDestroy(this).Subscribe((OnClicked));
        }

        private void OnClicked(EventContext<GameModeButton, GameModeType> context)
        {
            GameModeType gameModeType = context.Value;

            _battleAreaStarter.StartGame(gameModeType);
            
            foreach (GameModeButton gameModeButton in _gameModeButtons) 
                gameModeButton.gameObject.SetActive(false);
        }
    }
}
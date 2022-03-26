using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;
using Warlords.Utils;
using Zenject;

namespace Warlords.Battle
{
    public class GameModeButtonsHandler : MonoBehaviour
    {
        [SerializeField] private GameModeButton[] _gameModeButtons;
        [SerializeField] private Transform _gameModeButtonsParent;

        private BattleGameFinder _battleGameFinder;

        [Inject]
        private void Init(BattleGameFinder battleGameFinder)
        {
            _battleGameFinder = battleGameFinder;
        }

        private void Awake()
        {
            foreach (GameModeButton gameModeButton in _gameModeButtons)
                gameModeButton.Clicked.TakeUntilDestroy(this).Subscribe((OnClicked));
        }

        private void OnClicked(EventContext<GameModeButton, GameModeType> context)
        {
            GameModeType gameModeType = context.Value;

            _battleGameFinder.StartGame(gameModeType);

            _gameModeButtonsParent.gameObject.SetActive(false);
        }
    }
}
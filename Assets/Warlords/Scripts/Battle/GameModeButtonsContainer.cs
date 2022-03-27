using UnityEngine;

namespace Warlords.Battle
{
    public class GameModeButtonsContainer : MonoBehaviour
    {
        [SerializeField] private GameModeButton[] _gameModeButtons;
        [SerializeField] private Transform _root;

        public GameModeButton[] GameModeButtons => _gameModeButtons;

        public void Show()
        {
            _root.gameObject.SetActive(true);
        }

        public void Hide()
        {
            _root.gameObject.SetActive(false);
        }
        
    }
}
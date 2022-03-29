using UnityEngine;

namespace Warlords.Battle
{
    public class GameModeButtonsContainer : MonoBehaviour
    {
        [SerializeField] private Transform _root;
        [SerializeField] private GameModeButton[] _gameModeButtons;

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
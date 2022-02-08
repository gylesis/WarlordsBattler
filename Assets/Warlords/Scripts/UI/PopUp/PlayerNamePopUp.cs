using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Warlords.UI.PopUp
{
    public class PlayerNamePopUp : MonoBehaviour
    {
        [SerializeField] private PlayerNamePopUpButton _playerNamePopUpButton;

        public PlayerNamePopUpButton PlayerNamePopUpButton => _playerNamePopUpButton;
    }
}
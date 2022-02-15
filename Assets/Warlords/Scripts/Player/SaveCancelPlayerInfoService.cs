using UniRx;
using UnityEngine;
using Warlords.Player.Attributes;
using Warlords.Utils;
using Zenject;

namespace Warlords.Player
{
    public class SaveCancelPlayerInfoService : MonoBehaviour
    {
        [SerializeField] private DefaultReactiveButton _saveButton;
        [SerializeField] private DefaultReactiveButton _cancelButton;
        
        private PlayerInfoPreSaver _playerInfoPreSaver;

        [Inject]
        private void Init(PlayerInfoPreSaver playerInfoPreSaver)
        {
            _saveButton.gameObject.SetActive(false);
            _cancelButton.gameObject.SetActive(false);
            
            _playerInfoPreSaver = playerInfoPreSaver;
            
            _playerInfoPreSaver.PlayerInfoChanged
                .Subscribe(PlayerInfoChanged);

            _saveButton.Clicked
                .TakeUntilDestroy(this)
                .Subscribe(SaveButtonClicked);
            
            _cancelButton.Clicked
                .TakeUntilDestroy(this)
                .Subscribe(DiscardButtonClicked);
        }

        private void SaveButtonClicked(Unit unit)
        {
            _playerInfoPreSaver.Save();
            
            SetButtons(false);
        }
        
        private void DiscardButtonClicked(Unit unit)
        {
            _playerInfoPreSaver.Discard();
            
            SetButtons(false);
        }
        private void PlayerInfoChanged(PlayerInfo playerInfo)
        {
            SetButtons(true);
        }

        private void SetButtons(bool state)
        {
            _saveButton.gameObject.SetActive(state);
            _cancelButton.gameObject.SetActive(state);
        }
        
    }
    
    
}
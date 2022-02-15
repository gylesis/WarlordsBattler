using System;
using UniRx;
using UnityEngine;

namespace Warlords.Player.Attributes
{
    public class PlayerInfoPreSaver
    {
        public PlayerInfo PlayerInfo => _playerInfo;
        
        private PlayerInfo _playerInfo;
        private PlayerInfo _oldPlayerInfo;

        private readonly ISaveLoadDataService _saveLoadDataService;
        public readonly Subject<PlayerInfo> PlayerInfoChanged = new Subject<PlayerInfo>();
        public readonly Subject<PlayerInfo> PlayerInfoChangedDiscard = new Subject<PlayerInfo>();
        
        public PlayerInfoPreSaver(ISaveLoadDataService saveLoadDataService)
        {
            _saveLoadDataService = saveLoadDataService;
            _playerInfo = _saveLoadDataService.Data.PlayerInfo;
            _oldPlayerInfo = _playerInfo.Copy();
        }

        public void Overwrite(Action<PlayerInfo> overwrite)
        {
            overwrite?.Invoke(_playerInfo);

            PlayerInfoChanged.OnNext(_playerInfo);
        }

        public void Save()
        {
            _saveLoadDataService.Overwrite(playerInfo =>
            {
                PlayerInfo playerInfoCopy = _playerInfo.Copy();
                
                playerInfo.PlayerInfo = playerInfoCopy;
                _oldPlayerInfo = playerInfoCopy;
            });
            
            PlayerInfoChanged.OnNext(_playerInfo);
        }

        public void Discard()
        {
            Debug.Log("SOMETHING");
            
            _playerInfo = _oldPlayerInfo.Copy();
            
            PlayerInfoChangedDiscard.OnNext(_playerInfo);
        }
        
        
    }
}
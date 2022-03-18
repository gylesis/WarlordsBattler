using System;
using UniRx;
using Warlords.Infrastructure;
using Warlords.Utils;

namespace Warlords.Player.Attributes
{
    public class PlayerInfoPreSaver : IPlayerInfoChangedListener
    {
        public PlayerInfo PlayerInfo => _playerInfo;
        
        private PlayerInfo _playerInfo;
        private PlayerInfo _oldPlayerInfo;

        private readonly ISaveLoadDataService _saveLoadDataService;
        private readonly PlayerInfoChangedDispatcher _playerInfoChangedDispatcher;
        public Subject<PlayerInfo> PlayerInfoDiscarded { get; } = new Subject<PlayerInfo>();
        public Subject<PlayerInfo> PlayerInfoSaved { get; } = new Subject<PlayerInfo>();
        
        public PlayerInfoPreSaver(ISaveLoadDataService saveLoadDataService, PlayerInfoChangedDispatcher playerInfoChangedDispatcher, PlayerInfoChangeRegister register)
        {
            register.Register(this);

            _playerInfoChangedDispatcher = playerInfoChangedDispatcher;
            _saveLoadDataService = saveLoadDataService;
            _playerInfo = _saveLoadDataService.Data.PlayerInfo;
            _oldPlayerInfo = _playerInfo.Copy();
        }

        public void Overwrite(Action<PlayerInfo> overwrite, bool overwriteWithSave = false)
        {
            overwrite?.Invoke(_playerInfo);

            _playerInfoChangedDispatcher.ChangePlayerInfo(_playerInfo);
            
            if(overwriteWithSave)
                Save();
        }

        public void Save()
        {
            _saveLoadDataService.Overwrite(saveData =>
            {
                PlayerInfo playerInfoCopy = _playerInfo.Copy();

                saveData.PlayerInfo = playerInfoCopy;
                _oldPlayerInfo = playerInfoCopy;
            });
            
            PlayerInfoSaved.OnNext(_playerInfo);
        }

        public void Discard()
        {
            _playerInfo = _oldPlayerInfo.Copy();
            
            PlayerInfoDiscarded.OnNext(_playerInfo);
            _playerInfoChangedDispatcher.DiscardPlayerInfo(_playerInfo);
        }

        public void PlayerInfoChanged(PlayerInfo playerInfo)
        {
            _playerInfo = playerInfo.Copy();
        }

        void IPlayerInfoChangedListener.PlayerInfoDiscarded(PlayerInfo playerInfo)
        {
        }
    }
}
using UniRx;

namespace Warlords.Player
{
    public class PlayerInfoSetter 
    {
        public PlayerInfo PlayerInfo => _playerInfo;
        
        private readonly PlayerInfo _playerInfo;

        private readonly PlayerInfoChangedDispatcher _playerInfoChangedDispatcher;

        public PlayerInfoSetter(PlayerInfoChangedDispatcher playerInfoChangedDispatcher)
        {
            _playerInfoChangedDispatcher = playerInfoChangedDispatcher;
            _playerInfo = new PlayerInfo();
            
        }
        
        public void SetFaction(WarlordFaction faction)
        {
            _playerInfo._faction = faction;
            
            _playerInfoChangedDispatcher.ChangePlayerInfo(_playerInfo);
        }
    }
}
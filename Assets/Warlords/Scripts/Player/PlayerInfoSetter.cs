
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
            _playerInfo.Faction = faction;
            
            _playerInfoChangedDispatcher.ChangePlayerInfo(_playerInfo);
        }

        public void SetName(string name)
        {
            _playerInfo.Name = name;

            _playerInfoChangedDispatcher.ChangePlayerInfo(_playerInfo);
        }
        
    }
    
    
}
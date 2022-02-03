using UniRx;

namespace Warlords
{
    public class PlayerInfoSetter
    {
        private PlayerInfo _playerInfo;

        public readonly Subject<PlayerInfo> PlayerInfoChanged = new Subject<PlayerInfo>();

        public PlayerInfoSetter()
        {
            _playerInfo = new PlayerInfo();
        }
        
        public void SetFraction(WarlordFraction fraction)
        {
            _playerInfo.Fraction = fraction;
            
            PlayerInfoChanged.OnNext(_playerInfo);
        }
    }
}
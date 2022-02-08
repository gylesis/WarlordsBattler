using Warlords.Player;

namespace Warlords.UI.PopUp
{
    public class PlayerNameSetter
    {
        private readonly IPlayerNameFilter _nameFilter;
        private readonly PlayerInfoSetter _playerInfoSetter;

        public PlayerNameSetter(PlayerInfoSetter playerInfoSetter, IPlayerNameFilter nameFilter)
        {
            _playerInfoSetter = playerInfoSetter;
            _nameFilter = nameFilter;
        }

        public void Set(string name)
        {
            var filteredName = _nameFilter.Filter(name);
            _playerInfoSetter.SetName(filteredName);
        }
        
    }
}
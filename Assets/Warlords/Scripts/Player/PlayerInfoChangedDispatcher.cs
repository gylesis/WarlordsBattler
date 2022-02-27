using System.Collections.Generic;

namespace Warlords.Player
{
    public class PlayerInfoChangedDispatcher
    {
        private readonly List<IPlayerInfoChangedListener> _listeners = new List<IPlayerInfoChangedListener>();

        public void AddListener(IPlayerInfoChangedListener listener)
        {
            _listeners.Add(listener);
        }
        
        public void ChangePlayerInfo(PlayerInfo playerInfo)
        {
            foreach (IPlayerInfoChangedListener playerInfoChangedListener in _listeners)
                playerInfoChangedListener.PlayerInfoChanged(playerInfo);
        }
        
        public void DiscardPlayerInfo(PlayerInfo playerInfo)
        {
            foreach (IPlayerInfoChangedListener playerInfoChangedListener in _listeners)
                playerInfoChangedListener.PlayerInfoDiscarded(playerInfo);
        }
    }
}
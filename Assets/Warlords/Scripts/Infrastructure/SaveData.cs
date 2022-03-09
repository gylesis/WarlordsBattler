using System;
using Warlords.Player;

namespace Warlords.Infrastructure
{
    [Serializable]
    public class SaveData
    {
        public PlayerInfo PlayerInfo = new PlayerInfo();
        public FirstActionsData FirstActionsData = new FirstActionsData();
    }
    
}
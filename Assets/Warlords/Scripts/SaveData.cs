using System;
using Warlords.Player;

namespace Warlords
{
    [Serializable]
    public class SaveData
    {
        public PlayerInfo PlayerInfo = new PlayerInfo();
        public FirstActionsData FirstActionsData = new FirstActionsData();
    }
}
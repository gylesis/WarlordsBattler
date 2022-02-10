using System;
using Warlords.Player;
using Warlords.UI.PopUp;

namespace Warlords
{
    [Serializable]
    public class SaveData
    {
        public PlayerInfo PlayerInfo = new PlayerInfo();
        public FirstActionsData FirstActionsData = new FirstActionsData();
    }
}
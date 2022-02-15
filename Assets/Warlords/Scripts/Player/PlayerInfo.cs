using System;
using Warlords.Faction;
using Warlords.Player.Attributes;

namespace Warlords.Player
{
    [Serializable]
    public class PlayerInfo
    {
        public string Name;
        public WarlordFaction Faction = new WarlordFaction();
        public LevelInfo Level = new LevelInfo();
        public PlayerAttributes PlayerAttributes = new PlayerAttributes();
    }
}
using System;

namespace Warlords.Player
{
    [Serializable]
    public class PlayerInfo
    {
        public string Name;
        public WarlordFaction Faction = new WarlordFaction();
        public LevelInfo Level = new LevelInfo();
    }
}
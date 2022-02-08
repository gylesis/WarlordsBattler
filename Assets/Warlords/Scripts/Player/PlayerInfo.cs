using System;

namespace Warlords.Player
{
    [Serializable]
    public class PlayerInfo
    {
        public string Name;
        public WarlordFaction Faction;
        public LevelInfo Level;
    }
}
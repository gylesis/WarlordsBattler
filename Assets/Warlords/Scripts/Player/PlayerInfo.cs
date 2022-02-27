using System;
using Warlords.Faction;
using Warlords.Player.Attributes;
using Warlords.Player.Spells;
using Warlords.UI.Appearance;
using Warlords.UI.PopUp;

namespace Warlords.Player
{
    [Serializable]
    public class PlayerInfo
    {
        public string Name;
        public WarlordFaction Faction = new WarlordFaction();
        public LevelInfo Level = new LevelInfo();
        public PlayerAttributes PlayerAttributes = new PlayerAttributes();
        public PlayerAppearance Appearance = new PlayerAppearance();
        public PlayerSpellInfo SpellInfo = new PlayerSpellInfo();
    }

    [Serializable]
    public class PlayerAppearance
    {
        public AppearanceItemData Head;
        public AppearanceItemData Body;
        public AppearanceItemData Skin;
    }


    [Serializable]
    public class AppearanceItemData
    {
        public string Path;
        public AppearanceItemType Type;
    }
    
}
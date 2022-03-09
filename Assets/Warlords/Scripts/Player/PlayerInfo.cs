using System;
using Warlords.Factions;
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
        public Faction Faction = new Faction();
        public LevelInfo Level = new LevelInfo();
        public PlayerAttributesData AttributesData = new PlayerAttributesData();
        public PlayerAppearance Appearance = new PlayerAppearance();
        public PlayerSpellInfo SpellInfo = new PlayerSpellInfo();
    }

    [Serializable]
    public class PlayerAppearance
    {
        public AppearanceItemData Head = new AppearanceItemData();
        public AppearanceItemData Body = new AppearanceItemData();
        public AppearanceItemData Skin = new AppearanceItemData();
    }


    [Serializable]
    public class AppearanceItemData
    {
        public int Index = -1;
        public string Path;
        public AppearanceItemType Type;
    }
    
}
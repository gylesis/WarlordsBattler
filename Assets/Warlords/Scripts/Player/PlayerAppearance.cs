using System;

namespace Warlords.Player
{
    [Serializable]
    public class PlayerAppearance
    {
        public AppearanceItemData Head = new AppearanceItemData();
        public AppearanceItemData Body = new AppearanceItemData();
        public AppearanceItemData Skin = new AppearanceItemData();
    }
}
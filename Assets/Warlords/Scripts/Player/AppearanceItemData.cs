using System;
using Warlords.UI.Appearance;

namespace Warlords.Player
{
    [Serializable]
    public class AppearanceItemData
    {
        public int Index = -1;
        public string Path;
        public AppearanceItemType Type;
    }
}
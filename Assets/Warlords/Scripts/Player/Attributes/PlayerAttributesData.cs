using System;
using System.Collections.Generic;
using Warlords.Utils;

namespace Warlords.Player.Attributes
{
    [Serializable]
    public class PlayerAttributesData
    {
        public PlayerAttribute[] Attributes = new PlayerAttribute[8];
        public int LeftUpgrades;
    }
}
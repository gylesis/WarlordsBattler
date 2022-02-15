using System;
using System.Collections.Generic;
using Warlords.Utils;

namespace Warlords.Player.Attributes
{
    [Serializable]
    public class PlayerAttributes
    {
        public List<PlayerAttribute> Attributes = new List<PlayerAttribute>();
        public int LeftUpgrades;
    }
}
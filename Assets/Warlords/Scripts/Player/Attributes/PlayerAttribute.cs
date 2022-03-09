using System;
using Warlords.Utils;

namespace Warlords.Player.Attributes
{
    [Serializable]
    public class PlayerAttribute 
    {
        public string Name;
        public IntStat Stat = new IntStat();
    }
}
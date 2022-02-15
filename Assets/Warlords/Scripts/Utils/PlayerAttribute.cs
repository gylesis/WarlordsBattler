using System;

namespace Warlords.Utils
{
    [Serializable]
    public class PlayerAttribute
    {
        public string Name;
        public IntStat Stat = new IntStat();
    }
}
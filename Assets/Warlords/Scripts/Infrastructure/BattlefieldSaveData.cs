using System;
using System.Collections.Generic;

namespace Warlords.Infrastructure
{
    [Serializable]
    public class BattlefieldSaveData
    {
        public List<BattlefieldPropertySaveData> BattlefieldUpgrades = new List<BattlefieldPropertySaveData>();
    }
}
using System;
using System.Collections.Generic;

namespace Warlords.Infrastructure
{
    [Serializable]
    public class BattlefieldsSaveData
    {
        public List<BattlefieldSaveData> BattlefieldDatas = new List<BattlefieldSaveData>();
    }
}
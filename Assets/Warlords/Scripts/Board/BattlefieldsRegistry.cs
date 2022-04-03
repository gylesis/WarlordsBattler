using System.Collections.Generic;
using Warlords.Infrastructure;

namespace Warlords.Board
{
    public class BattlefieldsRegistry // don't remember why i created this class 
    {
        private readonly Dictionary<Battlefield, BattlefieldData> _battlefieldDatas =
            new Dictionary<Battlefield, BattlefieldData>();

        public BattlefieldsRegistry(BattlefieldsContainer battlefieldsContainer,
            ISaveLoadDataService saveLoadDataService)
        {
           // var battlefieldSaveDatas = saveLoadDataService.Data.BattlefieldsSaveData.BattlefieldDatas;

            for (var i = 0; i < battlefieldsContainer.MyBattlefields.Length; i++)
            {
                Battlefield battlefield = battlefieldsContainer.MyBattlefields[i];
     //           BattlefieldSaveData saveData = battlefieldSaveDatas?[i];

                _battlefieldDatas.Add(battlefield, battlefield.BattlefieldData);

                //foreach (BattlefieldPropertySaveData propertySaveData in saveData.BattlefieldUpgrades) { } //property init
            }

        }
    }
    
}
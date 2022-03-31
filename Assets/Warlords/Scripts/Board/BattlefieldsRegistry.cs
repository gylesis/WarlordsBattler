using System.Collections.Generic;
using Warlords.Infrastructure;

namespace Warlords.Board
{
    public class BattlefieldsRegistry
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

                var battlefieldData = new BattlefieldData();

                /*var cellData = new CellContext();

                cellData.Transform = battlefield.transform;

                battlefieldData.CellData = cellData;*/
                
                battlefieldData.Index = i;

                battlefield.Init(battlefieldData);
                
                _battlefieldDatas.Add(battlefield, battlefieldData);

                //foreach (BattlefieldPropertySaveData propertySaveData in saveData.BattlefieldUpgrades) { } //property init
            }

        }
    }
    
}
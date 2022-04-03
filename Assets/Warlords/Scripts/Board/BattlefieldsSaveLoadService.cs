using Warlords.Infrastructure;

namespace Warlords.Board
{
    public class BattlefieldsSaveLoadService
    {
        private readonly ISaveLoadDataService _saveLoadDataService;

        private byte _index = 1;
        
        public BattlefieldsSaveLoadService(ISaveLoadDataService saveLoadDataService)
        {
            _saveLoadDataService = saveLoadDataService;
        }

        public BattlefieldData GetData()
        {
           // BattlefieldSaveData battlefieldSaveData = _saveLoadDataService.Data.BattlefieldsSaveData.BattlefieldDatas[_index]; // load upgrades
            var battlefieldData = new BattlefieldData();

            battlefieldData.Index = _index;
            
            _index++;
            return battlefieldData;
        }
    }
}
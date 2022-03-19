using System.Linq;
using Warlords.Inventory;

namespace Warlords.Infrastructure.Installers
{
    public class InventorySlotsDataBinder
    {
        private readonly InventorySlotData[] _inventorySlotDatas;

        private int _index;

        public InventorySlotsDataBinder(ISaveLoadDataService saveLoadDataService)
        {
            _inventorySlotDatas = saveLoadDataService.Data.InventorySaveData.SlotsDatas.Select(x => new InventorySlotData(x)).ToArray();
        }

        public InventorySlotData GetSlotData() => _inventorySlotDatas[_index++];
    }
}
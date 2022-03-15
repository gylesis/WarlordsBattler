using UnityEngine;
using Warlords.Inventory;

namespace Warlords.Infrastructure.Installers
{
    public class InventorySlotsDataBinder
    {
        private readonly InventorySlotData[] _inventorySlotDatas;

        private int _index;

        public InventorySlotsDataBinder(ISaveLoadDataService saveLoadDataService)
        {
            _inventorySlotDatas = saveLoadDataService.Data.InventorySaveData.SlotsDatas.ToArray();
            Debug.Log(_inventorySlotDatas.Length);
        }

        public InventorySlotData GetSlotData() => _inventorySlotDatas[_index++];
    }
}
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using Warlords.Infrastructure;

namespace Warlords.Inventory
{
    public class Inventory : IAsyncLoad
    {
        private List<InventorySlotData> _inventorySlotDatas = new List<InventorySlotData>();
        private readonly Dictionary<InventorySlot, Item> _inventorySlots = new Dictionary<InventorySlot, Item>();
        
        private readonly InventorySlotViewsContainer _inventorySlotViewsContainer;
        private readonly InventoryViewService _inventoryViewService;
        private readonly ISaveLoadDataService _saveLoadDataService;

        public Inventory(InventorySlotViewsContainer inventorySlotViewsContainer, InventoryViewService inventoryViewService, ISaveLoadDataService saveLoadDataService, AsyncLoadingsRegister asyncLoadingsRegister)
        {
            asyncLoadingsRegister.Register(this);
            
            _saveLoadDataService = saveLoadDataService;
            _inventoryViewService = inventoryViewService;
            _inventorySlotViewsContainer = inventorySlotViewsContainer;
        }

        public async UniTask AsyncLoad()
        {
            _inventoryViewService.UpdateInventoryView(_saveLoadDataService.Data.InventorySaveData.SlotsDatas.ToArray());
            
            foreach (InventorySlot inventorySlot in _inventorySlotViewsContainer.InventorySlotViews)
            {
                Item item = inventorySlot.SlotData.Item;

                _inventorySlots.Add(inventorySlot, item);   
            }

            await UniTask.CompletedTask;
        }

        public void RemoveItem(Item item)
        {
            InventorySlot inventorySlot = _inventorySlots.First(x => x.Value == item).Key;

            var itemCount = inventorySlot.SlotData.Count.Value;
            
            if (itemCount - 1 <= 0)
            {
                _inventorySlots[inventorySlot] = null;
            }
 
            inventorySlot.SlotData.Count.Value--;
        }
    }

    public class InventoryState
    {
        public List<InventorySlotData> InventorySlotDatas = new List<InventorySlotData>();
    }
}
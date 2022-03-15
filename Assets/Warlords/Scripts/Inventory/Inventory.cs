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

        public Inventory(InventorySlotViewsContainer inventorySlotViewsContainer, AsyncLoadingsRegister asyncLoadingsRegister)
        {
            asyncLoadingsRegister.Register(this);
            
            _inventorySlotViewsContainer = inventorySlotViewsContainer; 
        }

        public async UniTask AsyncLoad()
        {
            
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
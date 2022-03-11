using Zenject;

namespace Warlords.Inventory
{
    public class InventoryViewService 
    {
        private InventoryViewService(InventorySlotViewsContainer inventorySlotViewsContainer)
        {
            int temp = 0;
            foreach (InventorySlot inventorySlotView in inventorySlotViewsContainer.InventorySlotViews)
            {
                var inventorySlotData = new InventorySlotData();
                inventorySlotData.Count.Value = 2;
                inventorySlotData.Name = $"Random {++temp}";
                
                inventorySlotView.Init(inventorySlotData);
            }
        }
        
    }
}
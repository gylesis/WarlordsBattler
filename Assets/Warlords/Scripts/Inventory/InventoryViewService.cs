
namespace Warlords.Inventory
{
    public class InventoryViewService 
    {
        private readonly InventorySlot[] _inventorySlotViews;

        private InventoryViewService(InventorySlotViewsContainer inventorySlotViewsContainer)
        {       
            _inventorySlotViews = inventorySlotViewsContainer.InventorySlotViews;
        }

        public void UpdateInventoryView(InventorySlotData[] slotDatas)
        {
            for (var i = 0; i < slotDatas.Length; i++)
            {
                InventorySlot inventorySlotView = _inventorySlotViews[i];
                
                InventorySlotData slotData = slotDatas[i];

                inventorySlotView.Init(slotData);
            }
        }
        
        
    }
}
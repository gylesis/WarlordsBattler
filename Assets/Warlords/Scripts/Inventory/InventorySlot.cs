using UnityEngine;
using Warlords.UI.Units;
using Zenject;

namespace Warlords.Inventory
{
    public class InventorySlot : MonoBehaviour
    {
        private InventoryDraggableUIElement _draggableUIElement;
        private InventorySlotData _inventorySlotData;
        private InventorySlotView _inventorySlotView;

        public InventorySlotData SlotData => _inventorySlotData;
        public InventoryDraggableUIElement DraggableUIElement => _draggableUIElement;

        [Inject]
        private void Init(InventorySlotData slotData, InventoryDraggableUIElement draggableUIElement, InventorySlotView inventorySlotView)
        {
            _inventorySlotView = inventorySlotView;
            _inventorySlotData = slotData;
            _draggableUIElement = draggableUIElement;
        }
        
        public void AddItem(Item item)
        {
            _inventorySlotData.Item = item;
            _inventorySlotData.Count.Value++;
        }
        
    }
}
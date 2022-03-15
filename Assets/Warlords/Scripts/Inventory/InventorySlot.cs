using UnityEngine;
using Warlords.UI.Units;
using Zenject;

namespace Warlords.Inventory
{
    public class InventorySlot : MonoBehaviour
    {
        private InventoryDraggableUIElement _draggableUIElement;
        private InventorySlotData _inventorySlotData;

        public InventorySlotData SlotData => _inventorySlotData;
        public InventoryDraggableUIElement DraggableUIElement => _draggableUIElement;

        [Inject]
        private void Init(InventorySlotData slotData, InventoryDraggableUIElement draggableUIElement)
        {
            _inventorySlotData = slotData;
            _draggableUIElement = draggableUIElement;
        }

    }
}
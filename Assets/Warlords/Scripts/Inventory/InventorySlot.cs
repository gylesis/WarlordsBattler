using UniRx;
using UnityEngine;
using Warlords.UI.Units;
using Warlords.Utils;
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

        public Subject<EventContext<InventorySlot, InventorySlotData>> SlotChanged { get; } =
            new Subject<EventContext<InventorySlot, InventorySlotData>>();
        
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
            _inventorySlotData.Count.Value.Value++;
            
            var eventContext = new EventContext<InventorySlot, InventorySlotData>();
            eventContext.Sender = this;
            eventContext.Value = _inventorySlotData;

            SlotChanged.OnNext(eventContext);

            _inventorySlotView.UpdateItem(item);
        }
        
    }
}
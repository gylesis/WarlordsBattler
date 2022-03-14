using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEngine;
using UnityEngine.EventSystems;
using Warlords.Crafting;
using Warlords.UI.Units;

namespace Warlords.Inventory
{
    public class InventorySlotsDragHandler
    {
        private readonly Dictionary<InventorySlot, Vector3> _elementsPositions =
            new Dictionary<InventorySlot, Vector3>();

        private Inventory _inventory;
        private Workbench _workbench;

        public InventorySlotsDragHandler(InventorySlotViewsContainer inventorySlotViewsContainer,
            Inventory inventory, Workbench workbench)
        {
            _workbench = workbench;
            _inventory = inventory;
            
            var uiElements = inventorySlotViewsContainer.InventorySlotViews.Select(x => x.DraggableUIElement);

            foreach (InventoryDraggableUIElement uiElement in uiElements)
            {
                uiElement.PointerDrag.TakeUntilDestroy(uiElement).Subscribe((HandleDrag));
                uiElement.PointerUp.TakeUntilDestroy(uiElement).Subscribe((HandleUp));
                uiElement.PointerDown.TakeUntilDestroy(uiElement).Subscribe((HandleDown));
            }
        }

        private void HandleDown(UIElementContextData<InventorySlot> context)
        {
            InventorySlot uiElement = context.Sender;
            Vector3 rectPosition = uiElement.DraggableUIElement.Rect.position;

            _elementsPositions.Add(uiElement, rectPosition);
        }

        private void HandleUp(UIElementContextData<InventorySlot> context)
        {
            InventorySlot inventorySlot = context.Sender;
            Vector3 position = _elementsPositions[inventorySlot];
            Item item = inventorySlot.SlotData.Item;

            SetPosition(inventorySlot, position);
            
            var hoveredObjects = context.PointerEventData.hovered;

            WorkbenchSlot workbenchSlot = null;

            var isHoveredWorkbenchSlot = hoveredObjects.Any(obj => obj.TryGetComponent(out workbenchSlot));

            if (isHoveredWorkbenchSlot)
            {
                if (workbenchSlot != null)
                {
                    if (workbenchSlot.TryGetComponent<WorkbenchSlot>(out var slot))
                    {
                        _workbench.TryPut(slot, item);
                    }
                }
            }

            _elementsPositions.Remove(inventorySlot);
        }

        private void HandleDrag(UIElementContextData<InventorySlot> context)
        {
            RectTransform rectTransform = context.Sender.DraggableUIElement.Rect;
            PointerEventData pointerEventData = context.PointerEventData;

            rectTransform.anchoredPosition += pointerEventData.delta * 2;
        }


        private void SetPosition(InventorySlot inventorySlot, Vector3 position)
        {
            inventorySlot.DraggableUIElement.Rect.position = position;
        }
    }
}
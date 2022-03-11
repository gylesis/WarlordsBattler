using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEngine;
using UnityEngine.EventSystems;
using Warlords.UI.Units;

namespace Warlords.Inventory
{
    public class InventorySlotsDragHandler 
    {
        private readonly Dictionary<InventorySlot, Vector3> _elementsPositions =
            new Dictionary<InventorySlot, Vector3>();

        public InventorySlotsDragHandler(InventorySlotViewsContainer inventorySlotViewsContainer)
        {
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

            inventorySlot.DraggableUIElement.Rect.position = position;

            var hoveredObjects = context.PointerEventData.hovered;

            var needsToBeDeleted = hoveredObjects.Any(obj => obj.name == "Delete");
            
            if (needsToBeDeleted)
            {
                inventorySlot.SlotData.Count.Value--;
            }

            _elementsPositions.Remove(inventorySlot);
        }

        private void HandleDrag(UIElementContextData<InventorySlot> context)
        {
            RectTransform rectTransform = context.Sender.DraggableUIElement.Rect;
            PointerEventData pointerEventData = context.PointerEventData;

            rectTransform.anchoredPosition += pointerEventData.delta * 2;
        }
    }

    public class Inventory
    {
        private Dictionary<InventorySlot, InventoryDraggableUIElement> _hoverableUIElements =
            new Dictionary<InventorySlot, InventoryDraggableUIElement>();

        public Inventory(InventorySlotViewsContainer inventorySlotViewsContainer)
        {
            foreach (InventorySlot inventorySlotView in inventorySlotViewsContainer.InventorySlotViews)
            {
                InventoryDraggableUIElement draggableUIElement = inventorySlotView.DraggableUIElement;
                
                _hoverableUIElements.Add(inventorySlotView,draggableUIElement);
            }
        }

        public void RemoveItem()
        {
            
        }
        
        
        


    }
    
}
﻿using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;
using UnityEngine.EventSystems;
using Warlords.Crafting;
using Warlords.Infrastructure;
using Warlords.UI.Units;

namespace Warlords.Inventory
{
    public class InventorySlotsDragHandler : IAsyncLoad
    {
        private readonly Dictionary<InventorySlot, Vector3> _elementsPositions =
            new Dictionary<InventorySlot, Vector3>();

        private readonly Workbench _workbench;
        private readonly InventorySlotViewsContainer _inventorySlotViewsContainer;

        public InventorySlotsDragHandler(InventorySlotViewsContainer inventorySlotViewsContainer,
            Workbench workbench, AsyncLoadingsRegister asyncLoadingsRegister)
        {
            asyncLoadingsRegister.Register(this);

            _inventorySlotViewsContainer = inventorySlotViewsContainer;
            _workbench = workbench;
        }

        public async UniTask AsyncLoad()
        {
            var uiElements = _inventorySlotViewsContainer.InventorySlotViews.Select(x => x.DraggableUIElement);

            foreach (InventoryDraggableUIElement uiElement in uiElements)
            {
                uiElement.PointerDrag.TakeUntilDestroy(uiElement).Subscribe((HandleDrag));
                uiElement.PointerUp.TakeUntilDestroy(uiElement).Subscribe((HandleUp));
                uiElement.PointerDown.TakeUntilDestroy(uiElement).Subscribe((HandleDown));
            }

            await UniTask.CompletedTask;
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
            _elementsPositions.Remove(inventorySlot);

            var hoveredObjects = context.PointerEventData.hovered;

            WorkbenchSlot workbenchSlot = null;

            var isHoveredWorkbenchSlot = hoveredObjects.Any(obj => obj.TryGetComponent(out workbenchSlot));

            if (isHoveredWorkbenchSlot == false) return;

            if (workbenchSlot.TryGetComponent<WorkbenchSlot>(out var slot))
            {
                if (item is Ingredient ingredient)
                {
                    _workbench.TryPut(slot, ingredient);
                }
            }
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
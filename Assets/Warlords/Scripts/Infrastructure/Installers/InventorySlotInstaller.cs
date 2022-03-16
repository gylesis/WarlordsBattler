using UnityEngine;
using Warlords.Inventory;
using Warlords.UI.Units;
using Zenject;

namespace Warlords.Infrastructure.Installers
{
    public class InventorySlotInstaller : MonoInstaller
    {
        [SerializeField] private InventoryDraggableUIElement _draggableUIElement;
        [SerializeField] private InventorySlotView _inventorySlotView;  
        
        [Inject] private InventorySlotsDataBinder _inventorySlotsDataBinder;

        public override void InstallBindings()
        {
            Container.Bind<InventorySlotView>().FromInstance(_inventorySlotView).AsSingle();
            Container.Bind<InventoryDraggableUIElement>().FromInstance(_draggableUIElement).AsSingle();
            Container.Bind<InventorySlotData>().FromInstance(_inventorySlotsDataBinder.GetSlotData()).AsSingle();
        }
    }
}
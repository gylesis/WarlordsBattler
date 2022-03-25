using UniRx;
using UnityEngine;
using Warlords.Inventory;
using Warlords.Utils;
using Zenject;

namespace Warlords.Crafting
{
    public class WorkbenchView : MonoBehaviour
    {
        [SerializeField] private DefaultReactiveButton _reactiveButton;
        [SerializeField] private WorkbenchSlot _craftedItemView;

        private Workbench _workbench;

        [Inject]
        private void Init(Workbench workbench, ItemsRecipesDictionary itemsRecipesDictionary)
        {
            _workbench = workbench;
            _reactiveButton.Clicked.TakeUntilDestroy(this).Subscribe((CraftClick));

            workbench.WorkbenchRecipeAvailable.TakeUntilDestroy(this).Subscribe(OnWorkbenchRecipeAvailable);
        }

        private void OnWorkbenchRecipeAvailable(Item item)
        {
            if (item == null)
            {
                _craftedItemView.SetItem(null);
                _reactiveButton.gameObject.SetActive(false);
                return;
            }

            _reactiveButton.gameObject.SetActive(true);
            _craftedItemView.SetItem(item);
        }

        private void CraftClick(Unit _)
        {
            _workbench.Craft();
        }
    }
}
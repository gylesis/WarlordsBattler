using UniRx;
using UnityEngine;
using Warlords.Utils;
using Zenject;

namespace Warlords.Crafting
{
    public class WorkbenchView : MonoBehaviour
    {
        [SerializeField] private DefaultReactiveButton _reactiveButton;
        
        private Workbench _workbench;

        [Inject]
        private void Init(Workbench workbench)
        {
            _workbench = workbench;
            _reactiveButton.Clicked.TakeUntilDestroy(this).Subscribe((CraftClick));
            
            workbench.OnWorkbenchFull.TakeUntilDestroy(this)
                .Subscribe((unit => _reactiveButton.gameObject.SetActive(true)));
        }

        private void CraftClick(Unit _)
        {
            _workbench.Craft();
        }
    }
}
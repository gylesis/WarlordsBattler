using UniRx;
using UnityEngine;
using Warlords.Utils;
using Zenject;

namespace Warlords.UI.PopUp
{
    public class AppearanceButtonsHandler : MonoBehaviour
    {
        [SerializeField] private AppearanceButton[] _appearanceButtons;

        private AppearanceController _appearanceController;

        [Inject]
        public void Init(AppearanceController appearanceController)
        {
            _appearanceController = appearanceController;
            
            foreach (AppearanceButton appearanceButton in _appearanceButtons)
            {
                appearanceButton.Clicked
                    .TakeUntilDestroy(this)
                    .Subscribe(onNext: Click);
            }
        }

        private void Click(ButtonContext<AppearanceItemType, bool> context)
        {
            _appearanceController.SwitchToNext(context.Sender, context.Value);
        }
    }


    /*public class AppearanceItemsContainer : ScriptableObject
    {
        public AppearanceItemData[] ItemsData;
    }*/
}
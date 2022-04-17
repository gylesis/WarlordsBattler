using TMPro;
using UniRx;
using UnityEngine;
using Warlords.UI.Menu;
using Warlords.Utils;
using Zenject;

namespace Warlords.UI.PopUp
{
    public class RedirectionPopUp : MonoBehaviour
    {
        [SerializeField] private DefaultReactiveButton _button;
        [SerializeField] private TMP_Text _description;
        
        private MenuSwitcher _menuSwitcher;

        public Subject<RedirectionPopUp> OnSucceedRedirect { get; } = new Subject<RedirectionPopUp>();
        
        [Inject]    
        private void Init(MenuSwitcher menuSwitcher)
        {
            _menuSwitcher = menuSwitcher;
        }
        
        public void SetDirectionToOpenMenu(RedirectionPopUpContext context)
        {
            _description.text = context.Description;
            
            _button.Clicked.Take(1).TakeUntilDestroy(this).Subscribe((_ =>
            {
                _menuSwitcher.OpenMenu(context.MenuTag);
                OnSucceedRedirect.OnNext(this);
            }));
        }
        
    }

    
    public struct RedirectionPopUpContext
    {
        public string Description;
        public MenuTag MenuTag;
    }
    
}
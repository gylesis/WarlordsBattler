using UnityEngine;
using Warlords.Utils;
using Zenject;

namespace Warlords.UI.Menu
{
    public class MenuButton : ReactiveButton<MenuButton,MenuTag>
    {
        [SerializeField] private MenuTag _menuTagToOpen;
        protected override MenuTag Value => _menuTagToOpen;
        protected override MenuButton Sender => this;

        [Inject]
        private void Init(MenuButtonsHandler menuButtonsHandler)  // To replace
        {
            menuButtonsHandler.Register(this);
        }
    }
}
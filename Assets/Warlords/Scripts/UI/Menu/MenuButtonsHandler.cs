using System;
using UniRx;
using UnityEngine;
using Warlords.Utils;

namespace Warlords.UI.Menu
{
    public class MenuButtonsHandler : IDisposable
    {
        private readonly MenuSwitcher _menuSwitcher;
        private readonly CompositeDisposable _disposable = new CompositeDisposable();
        
        public MenuButtonsHandler(MenuSwitcher menuSwitcher)
        {
            _menuSwitcher = menuSwitcher;
        }

        public void Register(MenuButton menuButton)
        {
            menuButton.Clicked.Subscribe(ProcessClick).AddTo(_disposable);
        }
        
        private void ProcessClick(ButtonContext<MenuButton, MenuTag> context)
        {
            MenuTag menuTag = context.Value;

            if (menuTag is URLMenuTag)
            {
                var urlMenuTag = menuTag as URLMenuTag;
                Application.OpenURL(urlMenuTag.URL);
                return;
            }
            
            _menuSwitcher.OpenMenu(menuTag);
        }

        public void Dispose()
        {
            _disposable.Dispose();
        }
    }
}
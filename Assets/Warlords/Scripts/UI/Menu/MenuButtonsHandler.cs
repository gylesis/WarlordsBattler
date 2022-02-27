using System;
using UniRx;
using UnityEngine;
using Warlords.Player;
using Warlords.Player.Attributes;
using Warlords.Utils;

namespace Warlords.UI.Menu
{
    public class MenuButtonsHandler : IDisposable
    {
        private readonly MenuSwitcher _menuSwitcher;
        private readonly CompositeDisposable _disposable = new CompositeDisposable();

        private MenuTag _currentTag;
        private PlayerInfoPreSaver _playerInfoPreSaver;

        public MenuButtonsHandler(MenuSwitcher menuSwitcher, PlayerInfoPreSaver playerInfoPreSaver)
        {
            _playerInfoPreSaver = playerInfoPreSaver;
            _menuSwitcher = menuSwitcher;
        }

        public void Register(MenuButton menuButton)
        {
            menuButton.Clicked.Subscribe(ProcessClick).AddTo(_disposable);
        }
        
        private void ProcessClick(ButtonContext<MenuButton, MenuTag> context)
        {
            _playerInfoPreSaver.Discard();
            MenuTag menuTag = context.Value;

            if(_currentTag == menuTag) return;

            if (menuTag is URLMenuTag urlMenuTag)
            {
                ApplicationURLOpener.Instance.OpenURL(urlMenuTag.URL);
                return;
            }

            _menuSwitcher.OpenMenu(menuTag);
            
            _currentTag = menuTag;
        }

        public void Dispose()
        {
            _disposable.Dispose();
        }
    }
}
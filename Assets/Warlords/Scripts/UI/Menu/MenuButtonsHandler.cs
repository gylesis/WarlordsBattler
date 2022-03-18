using System;
using Cysharp.Threading.Tasks;
using UniRx;
using Warlords.Player.Attributes;
using Warlords.Utils;

namespace Warlords.UI.Menu
{
    public class MenuButtonsHandler : IDisposable
    {
        private readonly MenuSwitcher _menuSwitcher;
        private readonly CompositeDisposable _disposable = new CompositeDisposable();
        private readonly MenuTagsContainer _menuTagsContainers;
        private readonly PlayerInfoPreSaver _playerInfoPreSaver;
        private readonly FirstActionsChecker _firstActionsChecker;

        private MenuTag _currentTag;

        public MenuButtonsHandler(MenuSwitcher menuSwitcher, PlayerInfoPreSaver playerInfoPreSaver,
            MenuTagsContainer menuTagsContainers, FirstActionsChecker firstActionsChecker)
        {
            _firstActionsChecker = firstActionsChecker;
            _menuTagsContainers = menuTagsContainers;
            _playerInfoPreSaver = playerInfoPreSaver;
            _menuSwitcher = menuSwitcher;
        }

        public void Register(MenuButton menuButton)
        {
            menuButton.Clicked.Subscribe(ProcessClick).AddTo(_disposable);
        }

        private void ProcessClick(EventContext<MenuButton, MenuTag> context)
        {
            MenuTag menuTag = context.Value;
            if (_currentTag == menuTag) return;

            _playerInfoPreSaver.Discard();

            if (menuTag is URLMenuTag urlMenuTag)
            {
                ApplicationURLOpener.Instance.OpenURL(urlMenuTag.URL);
                return;
            }

            _menuSwitcher.OpenMenu(menuTag);

            CheckSomeConditions();

            void CheckSomeConditions()
            {
                MenuTag warlordMenuTag = _menuTagsContainers.WarlordTag;

                if (menuTag == warlordMenuTag)
                {
                    _firstActionsChecker.CheckWarlordMenuFirstEnter();
                }
            }

            _currentTag = menuTag;
        }

        public void Dispose()
        {
            _disposable.Dispose();
        }
    }
}
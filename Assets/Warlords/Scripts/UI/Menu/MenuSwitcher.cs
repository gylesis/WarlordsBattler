using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Warlords.UI
{
    public class MenuSwitcher : MonoBehaviour
    {
        [SerializeField] private Menu[] _menus;

        private MenuContext[] _menuContexts;
        private MenuButton[] _buttons;

        [Inject]
        private void Init()
        {
            _buttons = GetComponentsInChildren<MenuButton>(true);
            
            foreach (MenuButton menuButton in _buttons)
            {
                menuButton.Init(this);
            }
            
            var menuContexts = new List<MenuContext>();

            for (var i = 0; i < _menus.Length; i++)
            {
                Menu menu = _menus[i];

                var menuContext = new MenuContext(menu, menu.Tag);
                
                menuContexts.Add(menuContext);
            }

            _menuContexts = menuContexts.ToArray();
        }
        
        public void OpenMenu(MenuTag menuTag)
        {
            MenuContext context = FindMenuContextByTag(menuTag);

            OpenMenu(context.Menu);
        }

        private void OpenMenu(Menu targetMenu)
        {
            targetMenu.gameObject.SetActive(true);
            
            for (var i = 0; i < _menus.Length; i++)
            {
                Menu menu = _menus[i];

                if (targetMenu != menu)
                {
                    menu.gameObject.SetActive(false);
                }
            }
        }
        
        private MenuContext FindMenuContextByTag(MenuTag tag)
        {
            MenuContext menuContext = new MenuContext();

            int counter = 0;
            
            for (var i = 0; i < _menus.Length; i++)
            {
                Menu menu = _menus[i];

                if (menu.Tag == tag)
                {
                    counter++;
                    MenuContext context = _menuContexts.First(m => m.Tag == menu.Tag);

                    menuContext = context;
                }
            }

            if (counter > 1)
            {
                Debug.LogWarning($"You have at least 2 menus under the same tag!");
            }

            return menuContext;
        }
        
    }
}
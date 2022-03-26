using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Warlords.UI.Menu
{
    public class MenuSwitcher : MonoBehaviour
    {
        [SerializeField] private Menu[] _menus;

        private MenuContext[] _menuContexts;
        private MenuTag _menuTag;

        [Inject]
        private void Init()
        {
            var menuContexts = new List<MenuContext>();

            for (var i = 0; i < _menus.Length; i++)
            {
                Menu menu = _menus[i];

                var menuContext = new MenuContext(menu, menu.Tag);
                
                menuContexts.Add(menuContext);
            }

            var sceneCount = SceneManager.sceneCount;

            _menuContexts = menuContexts.ToArray();
            
            if (sceneCount > 1)
            {
                OpenMenu(_menuContexts[0].Tag);
            }
        }

        public void OpenPrevMenu()
        {
            
        }
        
        public void OpenMenu(MenuTag menuTag)
        {
            _menuTag = menuTag;
            MenuContext context = FindMenuContextByTag(menuTag);

            OpenMenu(context.Menu, menuTag.IsAdditive);
        }

        private void OpenMenu(Menu targetMenu, bool isAdditive = false)
        {
            ActivateMenu();

            void ActivateMenu()
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
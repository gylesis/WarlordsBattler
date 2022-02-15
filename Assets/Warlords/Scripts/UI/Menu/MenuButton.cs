using UnityEngine;
using UnityEngine.UI;

namespace Warlords.UI.Menu
{
    [RequireComponent(typeof(Button))]
    public class MenuButton : MonoBehaviour
    {
        [SerializeField] private MenuTag _menuTagToOpen;
        
        private Button _button;
        private MenuSwitcher _menuSwitcher;

        private void Reset()
        {
            _button = GetComponent<Button>();
        }

        public void Init(MenuSwitcher menuSwitcher)
        {
            _menuSwitcher = menuSwitcher;
        }
        
        private void Awake()
        {
            if (_button == null) _button = GetComponent<Button>();
            
            _button.onClick.AddListener(ProcessClick);
        }

        private void ProcessClick()
        {
            _menuSwitcher.OpenMenu(_menuTagToOpen);
        }

        private void OnDestroy()
        {
            _button.onClick.RemoveListener(ProcessClick);
        }
    }
    
    [RequireComponent(typeof(Button))]
    public class AdditionalMenuButton : MonoBehaviour
    {
        [SerializeField] private MenuTag _menuTagToOpen;
        
        private Button _button;
        private MenuSwitcher _menuSwitcher;

        private void Reset()    
        {
            _button = GetComponent<Button>();
        }

        public void Init(MenuSwitcher menuSwitcher)
        {
            _menuSwitcher = menuSwitcher;
        }
        
        private void Awake()
        {
            if (_button == null) _button = GetComponent<Button>();
            
            _button.onClick.AddListener(ProcessClick);
        }

        private void ProcessClick()
        {
            _menuSwitcher.OpenMenu(_menuTagToOpen);
        }

        private void OnDestroy()
        {
            _button.onClick.RemoveListener(ProcessClick);
        }
    }
    
}
using Warlords.UI.Menu;

namespace Warlords.UI.PopUp
{
    public class MenuSwitchUpdater
    {
        private readonly IMenuSwitchEventListener[] _menuSwitchEventListeners;

        public MenuSwitchUpdater(IMenuSwitchEventListener[] menuSwitchEventListeners)
        {
            _menuSwitchEventListeners = menuSwitchEventListeners;
        }

        public void MenuSwitched(MenuSwitchEventContext menuSwitchEventContext)
        {
            foreach (IMenuSwitchEventListener listener in _menuSwitchEventListeners)
                listener.OnMenuSwitched(menuSwitchEventContext);
        }
    }
    
    public interface IMenuSwitchEventListener
    {
        void OnMenuSwitched(MenuSwitchEventContext context);
    }
    
    public struct MenuSwitchEventContext
    {
        public MenuTag Tag;
    }

}
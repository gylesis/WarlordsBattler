namespace Warlords.UI
{
    public struct MenuContext
    {
        public Menu Menu;
        public MenuTag Tag;

        public MenuContext(Menu menu, MenuTag menuTag)
        {
            Menu = menu;
            Tag = menuTag;
        }
    }
}
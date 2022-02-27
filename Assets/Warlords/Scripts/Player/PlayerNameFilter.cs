namespace Warlords.Player
{
    public class PlayerNameFilter : IPlayerNameFilter
    {
        public string Filter(string name)
        {
            return name;
        }
    }
}
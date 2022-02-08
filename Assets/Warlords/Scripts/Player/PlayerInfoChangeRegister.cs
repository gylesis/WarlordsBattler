namespace Warlords.Player
{
    public class PlayerInfoChangeRegister
    {
        private readonly PlayerInfoChangedDispatcher _dispatcher;

        public PlayerInfoChangeRegister(PlayerInfoChangedDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        public void Register(IPlayerInfoChangedListener listener)
        {
            _dispatcher.AddListener(listener);
        }
        
    }
}
namespace Warlords.Infrastracture
{
    public class AsyncLoadingsRegister
    {
        private readonly AsyncLoadingsDispatcher _dispatcher;

        public AsyncLoadingsRegister(AsyncLoadingsDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }
        
        public void Register(IAsyncLoad asyncLoad)
        {
            _dispatcher.AddListener(asyncLoad);
        }
    }
}
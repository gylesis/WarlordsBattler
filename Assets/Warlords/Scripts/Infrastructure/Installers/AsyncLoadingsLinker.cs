
namespace Warlords.Infrastructure.Installers
{
    public class AsyncLoadingsLinker 
    {
        public AsyncLoadingsLinker(AsyncLoadingsRegister asyncLoadingsRegister, IAsyncLoad[] asyncLoads)
        {
            foreach (IAsyncLoad asyncLoad in asyncLoads) 
                asyncLoadingsRegister.Register(asyncLoad);
        }
    }
}
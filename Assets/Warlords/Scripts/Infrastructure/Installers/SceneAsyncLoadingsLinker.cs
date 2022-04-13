
namespace Warlords.Infrastructure.Installers
{
    public class SceneAsyncLoadingsLinker 
    {
        public SceneAsyncLoadingsLinker(AsyncLoadingsRegister asyncLoadingsRegister, IAsyncLoad[] asyncLoads)
        {
            foreach (IAsyncLoad asyncLoad in asyncLoads) 
                asyncLoadingsRegister.Register(asyncLoad);
        }
    }
}
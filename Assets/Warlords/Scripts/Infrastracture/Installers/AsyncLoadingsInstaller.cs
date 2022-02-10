using Warlords.Utils;
using Zenject;

namespace Warlords.Infrastracture.Installers
{
    public class AsyncLoadingsInstaller : Installer
    {
        [Inject] private IAsyncLoad[] _asyncLoads;
        
        public override void InstallBindings()
        {
            var asyncLoadingsContext = new AsyncLoadingsContext();
            asyncLoadingsContext.AsyncLoads = _asyncLoads;

            Container.Bind<AsyncLoadingsContext>().FromInstance(asyncLoadingsContext).AsSingle().NonLazy();
        }
    }
}
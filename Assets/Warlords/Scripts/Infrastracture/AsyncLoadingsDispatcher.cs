using System.Collections.Generic;
using System.Threading.Tasks;

namespace Warlords.Infrastracture
{
    public class AsyncLoadingsDispatcher
    {
        private readonly List<IAsyncLoad> _asyncLoads = new List<IAsyncLoad>();

        public void AddListener(IAsyncLoad asyncLoad)
        {
            _asyncLoads.Add(asyncLoad);
        }
        
        public async Task LoadAsync()
        {
            foreach (IAsyncLoad asyncLoad in _asyncLoads)
            {
                await asyncLoad.AsyncLoad();
            }
            
            _asyncLoads.Clear();
        }
        
        public async void LoadAsync(IAsyncLoad[] asyncLoads)
        {
            foreach (IAsyncLoad asyncLoad in asyncLoads)
            {
                await asyncLoad.AsyncLoad();
            }
        }
    }
}
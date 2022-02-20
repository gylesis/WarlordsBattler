using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UniRx;

namespace Warlords.Infrastracture
{
    public class AsyncLoadingsDispatcher : IDisposable
    {
        private readonly List<IAsyncLoad> _asyncLoads = new List<IAsyncLoad>();

        private readonly CancellationTokenSource _cancellationToken = new CancellationTokenSource(); 
        
        public void AddListener(IAsyncLoad asyncLoad)
        {
            _asyncLoads.Add(asyncLoad);
        }
        
        public async Task LoadAsync()
        {
            foreach (IAsyncLoad asyncLoad in _asyncLoads)
            {
                var task = new Task((o => asyncLoad.AsyncLoad()), _cancellationToken);

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

        public void Dispose()
        {
            
        }
    }
}
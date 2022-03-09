using System;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;

namespace Warlords.Infrastructure
{
    public class AsyncLoadingsDispatcher : IDisposable
    {
        private readonly List<IAsyncLoad> _asyncLoads = new List<IAsyncLoad>();

        private readonly CancellationTokenSource _cancellationToken = new CancellationTokenSource();
   
        public void AddListener(IAsyncLoad asyncLoad)
        {
            _asyncLoads.Add(asyncLoad);
        }
        
        public async UniTask LoadAsync(IProgress<float> progress)
        {
            float progressValue = 1;
            
            foreach (IAsyncLoad asyncLoad in _asyncLoads)
            {
                await asyncLoad.AsyncLoad();
                progressValue++;
                progress.Report(progressValue / _asyncLoads.Count);
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
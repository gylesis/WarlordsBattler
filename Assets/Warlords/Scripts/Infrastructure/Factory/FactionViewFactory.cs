using Cysharp.Threading.Tasks;
using UnityEngine;
using Warlords.Factions;
using Warlords.Utils;

namespace Warlords.Infrastructure.Factory
{
    public class FactionViewFactory : IAsyncLoad
    {
        private FactionView _factionViewPrefab;
        private readonly Transform _spawnParent;

        public FactionViewFactory(AsyncLoadingsRegister asyncLoadingsRegister, FactionViewFactoryContext context)
        {
            asyncLoadingsRegister.Register(this);
            
            _spawnParent = context.SpawnParent;
        }
        
        public async UniTask AsyncLoad()
        {
            ResourceRequest resourceRequest = Resources.LoadAsync<FactionView>(AssetsPath.FactionView);
            
            await resourceRequest;

            _factionViewPrefab = resourceRequest.asset as FactionView;
        }

        public FactionView Create(FractionViewContext context)
        {
            FactionView factionView = Object.Instantiate(_factionViewPrefab, _spawnParent);
                
            factionView.Init(context);
                
            return factionView;
        }
    }


    public struct FactionViewFactoryContext
    {
        public Transform SpawnParent;
    }
    
}
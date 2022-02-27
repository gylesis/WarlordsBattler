using Cysharp.Threading.Tasks;
using UnityEngine;
using Warlords.Faction;
using Warlords.Utils;

namespace Warlords.Infrastracture.Factory
{
    public class FactionsViewFactory : IAsyncLoad
    {
        private FactionView _factionViewPrefab;

        public FactionsViewFactory(AsyncLoadingsRegister asyncLoadingsRegister)
        {
            asyncLoadingsRegister.Register(this);
        }
        
        public async UniTask AsyncLoad()
        {
            ResourceRequest resourceRequest = Resources.LoadAsync<FactionView>(AssetsPath.FactionView);
            
            await resourceRequest;

            _factionViewPrefab = resourceRequest.asset as FactionView;
        }

        public FactionView Create(FractionViewContext context)
        {
            FactionView factionView = Object.Instantiate(_factionViewPrefab, context.Parent);
                
            factionView.Init(context);
                
            return factionView;
        }
    }
}
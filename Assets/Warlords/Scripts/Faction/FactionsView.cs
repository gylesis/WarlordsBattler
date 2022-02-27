using System.Collections.Generic;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Warlords.Infrastracture;
using Warlords.Infrastracture.Factory;
using Zenject;

namespace Warlords.Faction
{
    public class FactionsView : MonoBehaviour, IAsyncLoad
    {
        private AvailableFactions _factions;
        private FactionsViewFactory _factionsFactory;
        private FactionButtonsHandler _factionButtonsHandler;

        [Inject]
        private void Init(AvailableFactions factions, FactionsViewFactory factionsFactory,
            AsyncLoadingsRegister asyncLoadingsRegister, FactionButtonsHandler factionButtonsHandler)
        {
            asyncLoadingsRegister.Register(this);

            _factionButtonsHandler = factionButtonsHandler;
            _factionsFactory = factionsFactory;
            _factions = factions;
        }

        public async UniTask AsyncLoad()
        {
            var fractions = _factions.WarlordFactions;

            List<FactionView> factionViews = new List<FactionView>();
            
            foreach (WarlordFaction warlordFraction in fractions)
            {
                var context = new FractionViewContext();

                context.WarlordFaction = new WarlordFaction();
                context.Parent = transform;

                context.WarlordFaction.Color = warlordFraction.Color;
                context.WarlordFaction.Name = warlordFraction.Name;

                FactionView factionView = _factionsFactory.Create(context);
                
                factionViews.Add(factionView);
            }
            
            _factionButtonsHandler.Register(factionViews);
            
            await UniTask.CompletedTask;
        }
    }
}
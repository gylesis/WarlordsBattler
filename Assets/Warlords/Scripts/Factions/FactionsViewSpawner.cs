using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Warlords.Infrastructure;
using Warlords.Infrastructure.Factory;

namespace Warlords.Factions
{
    public class FactionsViewSpawner : IAsyncLoad
    {
        private readonly AvailableFactions _factions;
        private readonly FactionViewFactory _factionFactory;
        private readonly FactionsButtonsHandler _factionsButtonsHandler;

        public FactionsViewSpawner(AvailableFactions factions, FactionViewFactory factionFactory,
            AsyncLoadingsRegister asyncLoadingsRegister, FactionsButtonsHandler factionsButtonsHandler)
        {
            asyncLoadingsRegister.Register(this);

            _factionsButtonsHandler = factionsButtonsHandler;
            _factionFactory = factionFactory;
            _factions = factions;
        }

        public async UniTask AsyncLoad()
        {
            var factions = _factions.GetAvailableFactions();

            List<FactionView> factionViews = new List<FactionView>();
            
            foreach (Faction warlordFraction in factions)
            {
                var context = new FractionViewContext();

                context.Faction = new Faction();

                context.Faction.Color = warlordFraction.Color;
                context.Faction.Name = warlordFraction.Name;

                FactionView factionView = _factionFactory.Create(context);
                
                factionViews.Add(factionView);
            }
            
            _factionsButtonsHandler.Register(factionViews);
            
            await UniTask.CompletedTask;
        }
    }
    
}
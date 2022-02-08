using UnityEngine;
using Warlords.Faction;

namespace Warlords.Infrastracture
{
    public class FactionsViewFactory
    {
        public FactionView Create(FractionViewContext context)
        {
            FactionView factionView = Object.Instantiate(context.Prefab,context.Parent);
                
            factionView.Init(context);
                
            return factionView;
        }
        
    }
}
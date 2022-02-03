using UnityEngine;

namespace Warlords
{
    public class FractionsViewFactory
    {
        public FractionView Create(FractionViewContext context)
        {
            FractionView fractionView = Object.Instantiate(context.Prefab,context.Parent);
                
            fractionView.Init(context);
                
            return fractionView;
        }
        
    }
}
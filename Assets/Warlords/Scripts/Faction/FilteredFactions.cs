using Warlords.Player;

namespace Warlords.Faction
{
    public class FilteredFactions
    {
        private readonly FactionsContainer _factionsContainer;

        public WarlordFaction[] WarlordFractions => _factionsContainer.WarlordFractions;
        
        public FilteredFactions(FactionsContainer factionsContainer)
        {
            _factionsContainer = factionsContainer;
        }
        
    }
}
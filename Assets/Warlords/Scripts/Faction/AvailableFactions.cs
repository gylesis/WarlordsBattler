namespace Warlords.Faction
{
    public class AvailableFactions
    {
        private readonly FactionsContainer _factionsContainer;

        public WarlordFaction[] WarlordFractions => _factionsContainer.WarlordFractions;
        
        public AvailableFactions(FactionsContainer factionsContainer)
        {
            _factionsContainer = factionsContainer;
        }
        
    }
}
namespace Warlords.Faction
{
    public class AvailableFactions
    {
        private readonly FactionsContainer _factionsContainer;

        public WarlordFaction[] WarlordFactions => _factionsContainer.WarlordFactions;
        
        public AvailableFactions(FactionsContainer factionsContainer)
        {
            _factionsContainer = factionsContainer;
        }
        
    }
}
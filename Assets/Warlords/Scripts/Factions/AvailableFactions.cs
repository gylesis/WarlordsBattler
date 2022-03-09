using System.Linq;

namespace Warlords.Factions
{
    public class AvailableFactions
    {
        private readonly FactionsContainer _factionsContainer;
        
        public Faction[] GetAvailableFactions()
        {
            return _factionsContainer.WarlordFactions.Select(x => x.Value).ToArray();
        }
        
        public AvailableFactions(FactionsContainer factionsContainer)
        {
            _factionsContainer = factionsContainer;
        }
        
    }
}
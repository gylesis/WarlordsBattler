namespace Warlords
{
    public class FilteredFractions
    {
        private readonly FractionsContainer _fractionsContainer;

        public WarlordFraction[] WarlordFractions => _fractionsContainer.WarlordFractions;
        
        public FilteredFractions(FractionsContainer fractionsContainer)
        {
            _fractionsContainer = fractionsContainer;
        }
        
    }
}
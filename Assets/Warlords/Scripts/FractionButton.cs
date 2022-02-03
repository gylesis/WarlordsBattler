namespace Warlords
{
    public class FractionButton : ReactiveButton<WarlordFraction>
    {
        private WarlordFraction _data;
        protected override WarlordFraction Value => _data;

        public void Init(WarlordFraction data)
        {
            _data = data;
        }
        
    }
}
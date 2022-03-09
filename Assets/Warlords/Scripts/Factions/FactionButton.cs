using Warlords.Utils;

namespace Warlords.Factions
{
    public class FactionButton : ReactiveButton<FactionView, Faction>
    {
        private Faction _data;
        private FactionView _factionView;
        protected override Faction Value => _data;
        protected override FactionView Sender => _factionView;

        public void Init(FactionView factionView, Faction data)
        {
            _factionView = factionView;
            _data = data;
        }
    }
}
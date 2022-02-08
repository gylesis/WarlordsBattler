using Warlords.Player;
using Warlords.Utils;

namespace Warlords.Faction
{
    public class FactionButton : ReactiveButton<FactionView, WarlordFaction>
    {
        private WarlordFaction _data;
        private FactionView _factionView;
        protected override WarlordFaction Value => _data;
        protected override FactionView Sender => _factionView;

        public void Init(FactionView factionView, WarlordFaction data)
        {
            _factionView = factionView;
            _data = data;
        }
    }
}
using Warlords.Utils;

namespace Warlords.Player.Spells
{
    public class SelectableSpellButton : ReactiveButton<SpellData>
    {
        private SpellData _spellData;
        protected override SpellData Value => _spellData;

        public void Init(SpellData spellData)
        {
            _spellData = spellData;
        }
        
    }
}
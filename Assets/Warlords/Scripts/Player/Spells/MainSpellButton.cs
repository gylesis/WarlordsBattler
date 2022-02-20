using Warlords.Utils;

namespace Warlords.Player.Spells
{
    public class MainSpellButton : ReactiveButton<SpellType>
    {
        private SpellType _spellType;
        protected override SpellType Value => _spellType;

        public void Init(SpellType spellType)
        {
            _spellType = spellType;
        }
        
    }
}
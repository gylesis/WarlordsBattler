using System;

namespace Warlords.Player.Spells
{
    [Serializable]
    public class PlayerSpellInfo
    {
        public SpellData[] SpellDatas =
        {
            new SpellData() {Index = -1, Type = SpellType.Spell1},
            new SpellData() {Index = -1, Type = SpellType.Spell2},
            new SpellData() {Index = -1, Type = SpellType.Spell3},
            new SpellData() {Index = -1, Type = SpellType.Ultimate},
            new SpellData() {Index = -1, Type = SpellType.Counter},
            new SpellData() {Index = -1, Type = SpellType.Reaction},
        };
    }
}
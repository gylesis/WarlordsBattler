using System;
using Warlords.Utils;

namespace Warlords.Board
{
    [Serializable]
    public class UnitStats
    {
        public UnitStats(Stats stats)
        {
            AttackPower = new IntStat(stats.AttackPower);
            AttackSpeed = new IntStat(stats.AttackSpeed);
            HitPoints = new IntStat(stats.HitPoints);
            SpellPower = new IntStat(stats.SpellPower);
            CastSpeed = new IntStat(stats.CastSpeed);
            MagicResistance = new IntStat(stats.MagicResistance);
            MovementSpeed = new IntStat(stats.MovementSpeed);
        }

        public IntStat AttackPower;
        public IntStat AttackSpeed;
        public IntStat HitPoints;
        public IntStat SpellPower;
        public IntStat CastSpeed;
        public IntStat MagicResistance;
        public IntStat MovementSpeed;
    }
}
using UnityEngine;
using Zenject;

namespace Warlords.Board
{
    public class UnitsFactory : IFactory<UnitContext, Unit>
    {
        private int temp = 0;
        private readonly Unit _prefab;
        private DiContainer _container;

        public UnitsFactory(Unit prefab, DiContainer container)
        {
            _container = container;
            _prefab = prefab;
        }
        
        public Unit Create(UnitContext context)
        {
            Unit unit = Object.Instantiate(_prefab, context.Position,Quaternion.identity);

            Vector3 scale = unit.transform.localScale;
            scale.y *= 2;
            unit.transform.localScale = scale;
            
            var unitData = new UnitData();

            unitData.Stats = new UnitStats(context.Stats);
            
            IMovingCommand movingCommand;
            Color color;

            if (temp % 2 == 0)
            {
                movingCommand = new CheatMoveCommand();
                color = Color.white;
            }
            else
            {
                movingCommand = new TeleportMoveCommand();
                color = Color.blue;
            }

            unitData.MovingCommand = movingCommand;
            unit.UnitView.SetColor(color);

            unit.Init(unitData);
            
            temp++;
            return unit;
        }
    }

    
    public struct UnitContext
    {
        public Vector3 Position;
        public Stats Stats;
    }

    public struct Stats
    {
        public int AttackPower;
        public int AttackSpeed;
        public int HitPoints;
        public int SpellPower;
        public int CastSpeed;
        public int MagicResistance;
        public int MovementSpeed;
    }
    
    
}
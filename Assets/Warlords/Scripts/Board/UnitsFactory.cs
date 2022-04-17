using UnityEngine;
using Zenject;

namespace Warlords.Board
{
    public class UnitsFactory : IFactory<UnitContext, Unit>
    {
        private int temp;
        private readonly Unit _prefab;
        private readonly MoveCommandsContainer _moveCommandsContainer;

        public UnitsFactory(Unit prefab, MoveCommandsContainer moveCommandsContainer)
        {
            _moveCommandsContainer = moveCommandsContainer;
            _prefab = prefab;
        }

        public Unit Create(UnitContext context)
        {
            Unit unit = Object.Instantiate(_prefab, context.UnitPivotTransform.position, Quaternion.identity);

            Vector3 scale = unit.transform.localScale;
            scale.y *= 2;
            unit.transform.localScale = scale;

            var unitData = new UnitData();

            unitData.Stats = new UnitStats(context.Stats);

            IMovingCommand movingCommand;
            Color color;

            if (temp % 2 == 0)
            {
                movingCommand = _moveCommandsContainer.Get<MoveByCellsCommand>();
                color = Color.white;
            }
            else
            {
                movingCommand = _moveCommandsContainer.Get<TeleportMoveCommand>();
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
        public Transform UnitPivotTransform;
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
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using Warlords.Infrastructure;

namespace Warlords.Board
{
    public class BoardDataService : IAsyncLoad
    {
        public List<Battlefield> Battlefields { get; } = new List<Battlefield>(36);
        public Dictionary<int, List<int>> BattlefieldsNeighbours { get; } = new Dictionary<int, List<int>>();

        private readonly BattlefieldCellDatas _battlefieldCellDatas;

        public BoardDataService(BattlefieldsContainer battlefieldsContainer,
            IBoardCellsDataLoader cellsDataLoader)
        {
            _battlefieldCellDatas = cellsDataLoader.Load();

            Battlefields.AddRange(battlefieldsContainer.MyBattlefields);
            Battlefields.AddRange(battlefieldsContainer.EnemyBattlefields);
        }

        public UniTask AsyncLoad()
        {
            foreach (CellData cellData in _battlefieldCellDatas.Datas)
                BattlefieldsNeighbours.Add(cellData.Index, cellData.Neighbours.ToList());

            return UniTask.CompletedTask;
        }

        public bool TryGetUnitBattlefield(Unit unit, out Battlefield battlefield)
        {
            battlefield = null;

            foreach (Battlefield batlefield in Battlefields)
            {
                var b = batlefield.BattlefieldUnitInfo.Unit == unit;

                if (b)
                {
                    battlefield = batlefield;
                    return true;
                }
            }

            return false;
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Warlords.Infrastructure;

namespace Warlords.Board
{
    public class BoardDataService : IAsyncLoad
    {
        private readonly BattlefieldCellDatas _battlefieldCellDatas;
        private readonly BattlefieldsContainer _battlefieldsContainer;
        public List<Battlefield> Battlefields { get; } = new List<Battlefield>(36);

        public Dictionary<int, List<int>> BattlefieldsNeighbours { get; } = new Dictionary<int, List<int>>();

        public BoardDataService(BattlefieldsContainer battlefieldsContainer,
            IBoardCellsDataLoader cellsDataLoader)
        {
            _battlefieldsContainer = battlefieldsContainer;
            _battlefieldCellDatas = cellsDataLoader.Load();

            Battlefields.AddRange(_battlefieldsContainer.MyBattlefields);
            Battlefields.AddRange(_battlefieldsContainer.EnemyBattlefields);
        }

        public async UniTask AsyncLoad()
        {
            foreach (CellData cellData in _battlefieldCellDatas.Datas)
                BattlefieldsNeighbours.Add(cellData.Index, cellData.Neighbours.ToList());
            
            await UniTask.CompletedTask;
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

    public class CellNode
    {
        public float GCost;
        public float HCost;

        public Vector3 Position;

        public float FCost => GCost + HCost;

        public bool Walkable;
        public int Index;
        public CellNode[] Neighbours;
    }
}
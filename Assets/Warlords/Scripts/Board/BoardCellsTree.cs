using System;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;
using Warlords.Infrastructure;

namespace Warlords.Board
{
    public class BoardCellsTree : IAsyncLoad, IDisposable, IBoardUpdateListener
    {
        private readonly CompositeDisposable _disposable = new CompositeDisposable();
        private readonly BoardDataService _boardDataService;
        private readonly List<CellNode> _cellNodes = new List<CellNode>();

        public BoardCellsTree(BoardDataService boardDataService)
        {
            _boardDataService = boardDataService;
        }

        public void OnBoardUpdate(BoardUpdateContext context)
        {
            Debug.Log("UpdateWalkable");
            UpdateWalkable();
        }

        public async UniTask AsyncLoad()
        {
            foreach (var keyValuePair in _boardDataService.BattlefieldsNeighbours)
            {
                var cellNode = new CellNode();

                cellNode.Index = keyValuePair.Key;

                var neighbours = keyValuePair.Value.Select(x =>
                {
                    var node = new CellNode();

                    node.Index = x;
                    node.Position = _boardDataService.Battlefields[node.Index - 1].BattlefieldUnitInfo.Pivot.position;

                    return node;
                }).ToArray();

                cellNode.Neighbours = neighbours;

                Battlefield battlefield = _boardDataService.Battlefields[cellNode.Index - 1];
                cellNode.Walkable = battlefield.BattlefieldUnitInfo.Unit == null;
                cellNode.Position = battlefield.BattlefieldUnitInfo.Pivot.position;

                _cellNodes.Add(cellNode);
            }

            await UniTask.CompletedTask;
        }

        public void UpdateWalkable()
        {
            foreach (CellNode cellNode in _cellNodes)
            {
                Battlefield battlefield = _boardDataService.Battlefields[cellNode.Index - 1];
                battlefield.BattlefieldView.ColorDefault();
                cellNode.Walkable = battlefield.BattlefieldUnitInfo.Unit == null;
            }
        }

        public async UniTask<Battlefield[]> FindPath(int battlefieldStartIndex, int battlefieldTargetIndex)
        {
            List<CellNode> visitedCells = new List<CellNode>();

            CellNode startNode = _cellNodes.First(x => x.Index == battlefieldStartIndex);
            CellNode targetNode = _cellNodes.First(x => x.Index == battlefieldTargetIndex);

            CellNode nextNode = startNode;

            List<CellNode> path = new List<CellNode>();
            
            while (visitedCells.Count < 60)
            {
                List<CellNode> neighbours = _boardDataService.BattlefieldsNeighbours[nextNode.Index].Select(Selector).ToList();

                neighbours = neighbours.Except(visitedCells).ToList();

                for (var index = neighbours.Count - 1; index >= 0; index--)
                {
                    CellNode neighbour = neighbours[index];
                    
                    if (neighbour.Walkable == false) neighbours.Remove(neighbour);
                }

                if (neighbours.Count == 0)
                {
                    visitedCells.Add(nextNode);
                    nextNode = visitedCells[visitedCells.Count - 2];
                    continue;
                }
                
                foreach (CellNode node in neighbours)
                {
                    if (node.Walkable == false) continue;
                    if (visitedCells.Contains(node)) continue;

                    node.GCost = GetDistance(startNode, node);
                    node.HCost = GetDistance(targetNode, node);
                }

                neighbours = neighbours.OrderBy(x => x.FCost).ToList();

                visitedCells.Add(nextNode);
                path.Add(nextNode);
                
                nextNode = neighbours[0];

                BattlefieldView battlefieldView = _boardDataService.Battlefields[nextNode.Index - 1].BattlefieldView;
                battlefieldView.ColorMaterial(Color.black);

                if (nextNode.HCost == 0)
                {
                    path.Add(nextNode);
                    break;
                }
                
                await UniTask.Delay(100);
            }
            
           
            foreach (CellNode node in path)
            {
                BattlefieldView battlefieldView = _boardDataService.Battlefields[node.Index - 1].BattlefieldView;
                battlefieldView.ColorMaterial(Color.green);
            }

            var battlefields = path.Select(x => _boardDataService.Battlefields[x.Index - 1]).ToArray();

            return battlefields;
        }

        private CellNode Selector(int index)
        {
            var cellNode = _cellNodes.First(x => x.Index == index);

            return cellNode;
        }

        float GetDistance(CellNode nodeA, CellNode nodeB)
        {
            var distance = Vector3.Distance(nodeA.Position, nodeB.Position);

            return distance;
        }

        public void Dispose()
        {
            _disposable.Dispose();
        }
    }
}
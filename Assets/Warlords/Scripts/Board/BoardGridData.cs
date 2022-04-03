using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Warlords.Board
{
    public class BoardGridData : MonoBehaviour
    {
        public List<BattlefieldData> Datas = new List<BattlefieldData>();

        public Battlefield[] Battlefields;

        [ContextMenu(nameof(Fill))]
        public void Fill()
        {
            foreach (Battlefield battlefield in Battlefields)
            {
                var battlefieldData = new BattlefieldData();
                battlefieldData.Battlefield = battlefield;
                battlefieldData.Index = Datas.Count + 1;
                
                Datas.Add(battlefieldData);
            }
        }

        public int GetIndex(Battlefield battlefield)
        {
            BattlefieldData battlefieldData = Datas.First((data => data.Battlefield == battlefield));

            return battlefieldData.Index;
        }
        
        [Serializable]
        public struct BattlefieldData
        {
            public Battlefield Battlefield;
            public int Index;
            public Battlefield[] Neighbours;
        }
    }
}
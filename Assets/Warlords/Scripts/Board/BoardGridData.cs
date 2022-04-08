using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;
using Zenject;

namespace Warlords.Board
{
    public class BoardGridData : MonoBehaviour
    {
        public List<BattlefieldEditorData> Datas = new List<BattlefieldEditorData>();
        
        public Battlefield[] Battlefields;

        [Inject]
        private void Init(IBoardCellsDataLoader cellsDataLoader)
        {
            BattlefieldCellDatas battlefieldCellDatas = cellsDataLoader.Load();
            
            for (var index = 0; index < Battlefields.Length; index++)
            {
                CellData cellData = battlefieldCellDatas.Datas[index];
                Battlefield battlefield = Battlefields[index];
                
                var battlefieldData = new BattlefieldEditorData();
                battlefieldData.Battlefield = battlefield;
                battlefieldData.Index = cellData.Index;
                
                Datas.Add(battlefieldData);
            }

            for (var index = 0; index < Datas.Count; index++)
            {
                CellData cellData = battlefieldCellDatas.Datas[index];
                BattlefieldEditorData battlefieldEditorData = Datas[index];

                List<BattlefieldEditorData> neighbours = new List<BattlefieldEditorData>();
                
                foreach (var neighbourIndex in cellData.Neighbours)
                {
                    var editorData = Datas.FirstOrDefault(x => x.Index == neighbourIndex);

                    var neighbour = new BattlefieldEditorData();

                    neighbour.Battlefield = editorData.Battlefield;
                    neighbour.Index = editorData.Index;
                    neighbour.Neighbours = null;
                    
                    neighbours.Add(neighbour);                    
                }

                battlefieldEditorData.Neighbours = neighbours.ToArray();
            }
        }
        
        
        [ContextMenu(nameof(ReadFile))]
        private void ReadFile()
        {
            string path = @"E:\UnityDev\Job\Warlords\save2.txt";

            var readAllText = File.ReadAllText(path);

            var fromJson = JsonUtility.FromJson<BattlefieldCellDatas>(readAllText);

            Debug.Log(JsonUtility.ToJson(fromJson,true));
        }
        
        [ContextMenu(nameof(Fill))]
        public void Fill()
        {
            foreach (Battlefield battlefield in Battlefields)
            {
                var battlefieldData = new BattlefieldEditorData();
                battlefieldData.Battlefield = battlefield;
                battlefieldData.Index = Datas.Count + 1;

                Datas.Add(battlefieldData);
            }
        }
        
        [ContextMenu(nameof(Write))]
        public void Write()
        {
            var foo = new BattlefieldCellDatas();

            foreach (BattlefieldEditorData battlefieldEditorData in Datas)
            {
                var tempo = new CellData();

                tempo.Index = battlefieldEditorData.Index;
                tempo.Neighbours = battlefieldEditorData.Neighbours.Select(x => x.Index).ToArray();
                
                foo.Datas.Add(tempo);
            }
            
            var test = JsonUtility.ToJson(foo, true);

            var bytes = Encoding.UTF8.GetBytes(test);

           // var binaryFormatter = new BinaryFormatter();
           // binaryFormatter.Serialize(,test);

            string path = @"E:\UnityDev\Job\Warlords\save3.txt";

           // File.WriteAllBytes(path, bytes);

            File.WriteAllText(path, test);
        }
        
        [ContextMenu(nameof(SetNeighbours))]
        public void SetNeighbours()
        {
            for (var index = 0; index < Datas.Count; index++)
            {
                BattlefieldEditorData data1 = Datas[index];
    
                int minIndex = Mathf.Clamp(index - 10, 0, 35);
                int maxIndex = Mathf.Clamp(index + 10, 0, 35);

                List<BattlefieldEditorData> neighbours = new List<BattlefieldEditorData>();

                for (int i = minIndex; i < maxIndex; i++)
                {
                    BattlefieldEditorData data2 = Datas[i];
                    Battlefield suggestedNeighbour = data2.Battlefield;
                    
                    if(data2.Index == data1.Index) continue;
                    
                    var distance = Vector3.Distance(data1.Battlefield.transform.position,
                        suggestedNeighbour.transform.position);

                    if (distance < 2.2f)
                    {
                        if (neighbours.Contains(data2) == false)
                        {
                            var battlefieldEditorData = new BattlefieldEditorData();

                            battlefieldEditorData.Battlefield = data2.Battlefield;
                            battlefieldEditorData.Index = data2.Index;
                            battlefieldEditorData.Neighbours = null;

                            neighbours.Add(battlefieldEditorData);
                        }
                    }
                }

                data1.Neighbours = neighbours.ToArray();
            }

            var foo = new BattlefieldCellDatas();

            foreach (BattlefieldEditorData battlefieldEditorData in Datas)
            {
                var tempo = new CellData();

                tempo.Index = battlefieldEditorData.Index;
                tempo.Neighbours = battlefieldEditorData.Neighbours.Select(x => x.Index).ToArray();
                
                foo.Datas.Add(tempo);
            }
            
            var test = JsonUtility.ToJson(foo, true);
    
            string path = @"E:\UnityDev\Job\Warlords\save2.txt";

            File.WriteAllText(path, test);
        }

       
        public int GetIndex(Battlefield battlefield)
        {
            BattlefieldEditorData battlefieldEditorData = Datas.First((data => data.Battlefield == battlefield));

            return battlefieldEditorData.Index;
        }

        [Serializable]
        public class BattlefieldEditorData
        {
            public Battlefield Battlefield;
            public int Index;
            public BattlefieldEditorData[] Neighbours;
        }

    }

    [Serializable]
    public class BattlefieldCellDatas
    {
        public List<CellData> Datas = new List<CellData>();
    }
    
    [Serializable]
    public class CellData
    {
        public int Index;
        public int[] Neighbours;
    }
}
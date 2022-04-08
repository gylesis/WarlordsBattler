using System.IO;
using UnityEngine;
using Warlords.Utils;

namespace Warlords.Board
{
    public interface IBoardCellsDataLoader
    {
        BattlefieldCellDatas Load();
    }

    public class TextFileBoardCellsDataLoader : IBoardCellsDataLoader
    {
        public BattlefieldCellDatas Load()
        {
            //string path = @"E:\UnityDev\Job\Warlords\BoardCellsData.txt";

            string path = AssetsPath.BoardCellsData;

            var textAsset = Resources.Load<TextAsset>(path);

           // var readAllText = File.ReadAllText(path);

            var data = JsonUtility.FromJson<BattlefieldCellDatas>(textAsset.ToString());

            Debug.Log(JsonUtility.ToJson(data,true));

            return data;
        }
    }
    
    
}
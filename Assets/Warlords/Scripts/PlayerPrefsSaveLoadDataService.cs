using System;
using System.Threading.Tasks;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Warlords
{
    public class PlayerPrefsSaveLoadDataService : ISaveLoadDataService 
    {
        private const string PrefsKey = "SaveData";

        private SaveData _data;

        public SaveData Data => _data;

        public async Task<SaveData> Load()
        {
            var prefs = PlayerPrefs.GetString(PrefsKey);

            SaveData saveData;
            
            if (prefs == String.Empty)
            {
                saveData = new SaveData();
                InitPlayer(saveData);
            }
            else
            {
                saveData = JsonUtility.FromJson<SaveData>(prefs);
            }

            Debug.Log($"SavedData:\n {JsonUtility.ToJson(saveData,true)}");

            _data = saveData;

            await Task.Delay(100);
            
            return saveData;
        }

        public void Overwrite(Action<SaveData> onOverwrite)
        {
            onOverwrite?.Invoke(_data);

            var json = JsonUtility.ToJson(_data);
            
            PlayerPrefs.SetString(PrefsKey,json);
            PlayerPrefs.Save();
        }

        private void InitPlayer(SaveData saveData)
        {
            saveData.PlayerInfo.Name = $"Player{Random.Range(3000, 9000)}";
            saveData.PlayerInfo.Faction.Color = Color.black;
            saveData.PlayerInfo.Faction.Name = "Random";
        }
        
    }
}
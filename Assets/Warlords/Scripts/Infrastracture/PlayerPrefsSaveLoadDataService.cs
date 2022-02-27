using System;
using System.Threading.Tasks;
using UnityEngine;
using Warlords.Player;

namespace Warlords.Infrastracture
{
    public class PlayerPrefsSaveLoadDataService : ISaveLoadDataService 
    {
        private const string PrefsKey = "SaveData";

        private SaveData _data;
        private readonly IPlayerInfoInitializer _playerInfoInitializer;

        public PlayerPrefsSaveLoadDataService(IPlayerInfoInitializer playerInfoInitializer)
        {
            _playerInfoInitializer = playerInfoInitializer;
        }
        
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

            await Task.Delay(0);
            
            return saveData;
        }

        public void Overwrite(Action<SaveData> onOverwrite)
        {
            onOverwrite?.Invoke(_data);

            //Debug.Log($"Overwriting SaveData:\n {_data}");
            
            var json = JsonUtility.ToJson(_data);
            
            PlayerPrefs.SetString(PrefsKey,json);
            PlayerPrefs.Save();
        }

        private void InitPlayer(SaveData saveData)
        {
            saveData.PlayerInfo = _playerInfoInitializer.Initialize();
        }
        
        
    }
}
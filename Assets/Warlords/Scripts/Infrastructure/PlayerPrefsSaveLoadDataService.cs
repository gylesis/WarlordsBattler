using System;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;
using Warlords.Player;
using Warlords.Utils;

namespace Warlords.Infrastructure
{
    public class PlayerPrefsSaveLoadDataService : ISaveLoadDataService
    {

        private SaveData _data;
        private readonly ISaveDataInitializer _saveDataInitializer;

        public PlayerPrefsSaveLoadDataService(ISaveDataInitializer saveDataInitializer)
        {
            _saveDataInitializer = saveDataInitializer;
        }

        public SaveData Data => _data;

        public async Task<SaveData> Load()
        {
            var prefs = PlayerPrefs.GetString(Constants.Saves.PrefsKey);

            SaveData saveData;

            if (prefs == String.Empty)
            {
                saveData = await _saveDataInitializer.Initialize();
            }
            else
            {
                saveData = JsonUtility.FromJson<SaveData>(prefs);
            }

            // Debug.Log($"SavedData:\n {JsonUtility.ToJson(saveData,true)}");

            _data = saveData;

            await Task.Delay(0);

            return saveData;
        }

        public void Overwrite(Action<SaveData> onOverwrite)
        {
            onOverwrite?.Invoke(_data);

            //Debug.Log($"Overwriting SaveData:\n {_data}");

            var json = JsonUtility.ToJson(_data);

            PlayerPrefs.SetString(Constants.Saves.PrefsKey, json);
            PlayerPrefs.Save();
        }
    }
}
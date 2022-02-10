using System.Threading.Tasks;
using Warlords.Utils;

namespace Warlords.Player
{
    public class PlayerInfoSetter : IAsyncLoad
    {
        private readonly PlayerInfoChangedDispatcher _playerInfoChangedDispatcher;
        private readonly ISaveLoadDataService _saveLoadDataService;
        private SaveData _saveData;

        public PlayerInfoSetter(PlayerInfoChangedDispatcher playerInfoChangedDispatcher,
            ISaveLoadDataService saveLoadDataService)
        {
            _saveLoadDataService = saveLoadDataService;
            _playerInfoChangedDispatcher = playerInfoChangedDispatcher;
        }

        public void SetFaction(WarlordFaction faction)
        {
            _saveData.PlayerInfo.Faction = faction;

            PlayerInfoChanged(_saveData.PlayerInfo);
        }

        public void SetName(string name)
        {
            _saveData.PlayerInfo.Name = name;

            PlayerInfoChanged(_saveData.PlayerInfo);
        }

        private void PlayerInfoChanged(PlayerInfo playerInfo)
        {
            _playerInfoChangedDispatcher.ChangePlayerInfo(_saveData.PlayerInfo);

            _saveLoadDataService.Overwrite(data => { data.PlayerInfo = playerInfo; });
        }

        public async Task AsyncLoad()
        {
            var saveDataAsyncLoad = _saveLoadDataService.Load();
            
            await saveDataAsyncLoad;

            _saveData = saveDataAsyncLoad.Result;
            
            _playerInfoChangedDispatcher.ChangePlayerInfo(_saveData.PlayerInfo);
        }
    }
}
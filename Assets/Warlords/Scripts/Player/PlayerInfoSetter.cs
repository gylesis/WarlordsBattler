using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Warlords.Faction;
using Warlords.Infrastracture;

namespace Warlords.Player
{
    public class PlayerInfoSetter : IAsyncLoad
    {
        private readonly PlayerInfoChangedDispatcher _playerInfoChangedDispatcher;
        private readonly ISaveLoadDataService _saveLoadDataService;
        private readonly SaveData _saveData;

        public PlayerInfoSetter(PlayerInfoChangedDispatcher playerInfoChangedDispatcher,
            ISaveLoadDataService saveLoadDataService, AsyncLoadingsRegister asyncLoadingsRegister)
        {
            asyncLoadingsRegister.Register(this);
            
            _saveLoadDataService = saveLoadDataService;
            _playerInfoChangedDispatcher = playerInfoChangedDispatcher;
            
            _saveData = saveLoadDataService.Data;
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

            _saveLoadDataService.Overwrite(data =>
            {
                data.PlayerInfo = playerInfo;
            });
        }

        public async UniTask AsyncLoad()
        {
            PlayerInfo saveDataPlayerInfo = _saveData.PlayerInfo;
            _playerInfoChangedDispatcher.ChangePlayerInfo(saveDataPlayerInfo);

            await UniTask.CompletedTask;
        }
    }
}
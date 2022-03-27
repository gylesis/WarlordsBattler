using System;
using Cysharp.Threading.Tasks;

namespace Warlords.Battle
{
    public class BattleGamePoller
    {
        public async UniTask FindCasualGame(Action foundGame)
        {
            await UniTask.Delay(TimeSpan.FromSeconds(5));
            
            foundGame.Invoke();
        }
        
        public async UniTask FindRankedGame(Action foundGame)
        {
            await UniTask.Delay(TimeSpan.FromSeconds(7));
            
            foundGame.Invoke();
        }
        
    }
}
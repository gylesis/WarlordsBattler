using System;
using Cysharp.Threading.Tasks;
using DG.Tweening;

namespace Warlords.Battle
{
    public class BattleGamePoller
    {

        public async UniTask FindCasualGame(Action foundGame)
        {
            await UniTask.Delay(5);
            foundGame.Invoke();
        }
        
        public async UniTask FindRankedGame(Action foundGame)
        {
            await UniTask.Delay(5);
            foundGame.Invoke();
        }
        
    }
}
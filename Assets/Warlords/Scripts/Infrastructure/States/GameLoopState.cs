using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Warlords.Infrastructure.States
{
    public class GameLoopState : IState
    {
        public GameLoopState() { }

        public async UniTask Exit()
        {
            
        }

        public async UniTask Enter()
        {
            Debug.Log("loop state");
        }
    }
}
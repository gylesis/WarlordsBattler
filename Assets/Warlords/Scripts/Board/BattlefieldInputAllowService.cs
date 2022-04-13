using System;
using Cysharp.Threading.Tasks;

namespace Warlords.Board
{
    public class BattlefieldInputAllowService
    {
        public bool Value { get; private set; }

        public async void AllowForSeconds(int seconds)
        {
            Value = true;

            TimeSpan waitTime = TimeSpan.FromSeconds(seconds);

            await UniTask.Delay(waitTime);
            Value = false;
        }

        public void Allow() => 
            Value = true;

        public void Disallow() => 
            Value = false;
    }
}
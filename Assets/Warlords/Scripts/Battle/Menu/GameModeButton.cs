using UnityEngine;
using Warlords.Utils;

namespace Warlords.Battle
{
    public class GameModeButton : ReactiveButton<GameModeButton,GameModeType>
    {
        [SerializeField] private GameModeType _gameModeType;
        
        protected override GameModeType Value => _gameModeType;
        protected override GameModeButton Sender => this;
    }
}
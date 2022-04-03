using System;
using UnityEngine;

namespace Warlords.Board
{
    public class MoveCommandsContainer
    {
        private IMovingCommand[] _movingCommands;

        private readonly IMovingCommand _smoothMoveCommand = new CheatMoveCommand();
        private readonly IMovingCommand _teleportMoveCommand = new TeleportMoveCommand();
        
        public MoveCommandsContainer(IMovingCommand[] movingCommands)
        {
            _movingCommands = movingCommands;

            /*foreach (IMovingCommand movingCommand in movingCommands)
            {
                Type baseType = movingCommand.GetType().BaseType;
                Debug.Log(baseType );
            }*/
        }
        
    }
}
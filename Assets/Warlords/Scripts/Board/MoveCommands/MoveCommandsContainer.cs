using System;
using System.Collections.Generic;
using System.Linq;

namespace Warlords.Board
{
    public class MoveCommandsContainer
    {
        private readonly Dictionary<Type, IMovingCommand> _commands;
        
        public MoveCommandsContainer(IMovingCommand[] movingCommands)
        {
            _commands = movingCommands.ToDictionary((command => command.GetType()));
        }

        public IMovingCommand Get<TMoveCommand>() where TMoveCommand : IMovingCommand => 
            _commands[typeof(TMoveCommand)];
    }
}
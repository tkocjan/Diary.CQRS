﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Diary.CQRS.Commands;
using Diary.CQRS.Utils;

namespace Diary.CQRS.Messaging
{
    public class CommandBus:ICommandBus
    {
        private readonly ICommandHandlerFactory _commandHandlerFactory;

        public CommandBus(ICommandHandlerFactory commandHandlerFactory)
        {
            _commandHandlerFactory = commandHandlerFactory;
        }

        public void Send<T>(T command) where T : Command
        {
            var handler = _commandHandlerFactory.GetHandler<T>();
            if (handler!=null)
            {
                handler.Execute(command);
            }
            else
            {
                throw new Exception();
            }
        }
    }
}

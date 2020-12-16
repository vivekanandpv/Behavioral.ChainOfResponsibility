using System;
using System.Collections.Generic;
using System.Text;

namespace Behavioral.ChainOfResponsibility
{
    //  scalable conditional processing logic
    //  if-else in an object-oriented way

    public class LogMessage
    {
        public string Message { get; set; }
    }



    public interface ILogMessageHandler<T>
    {
        ILogMessageHandler<T> SetNext(ILogMessageHandler<T> nextHandler);
        void Handle(T message);
    }

    public abstract class LogMessageHandler<T> : ILogMessageHandler<T> where T : class
    {
        private ILogMessageHandler<T> Next { get; set; }

        public ILogMessageHandler<T> SetNext(ILogMessageHandler<T> nextHandler)
        {
            Next = nextHandler;
            return Next;
        }

        public virtual void Handle(T message)
        {
            Next?.Handle(message);
        }
    }

    //  Concrete handlers
    public class ConsoleLogHandler : LogMessageHandler<LogMessage>
    {
        private readonly int _id;

        public ConsoleLogHandler(int id)
        {
            _id = id;
        }
        public override void Handle(LogMessage message)
        {
            Console.WriteLine($"Console Logger {_id}: {message.Message}");
            //  Separate validator class objects can be used
            //  If the operation is not supported, they can throw the exception
            base.Handle(message);
        }
    }

    public class DebugLogHandler : LogMessageHandler<LogMessage>
    {
        private readonly int _id;

        public DebugLogHandler(int id)
        {
            _id = id;
        }
        public override void Handle(LogMessage message)
        {
            Console.WriteLine($"Debug Logger {_id}: {message.Message}");
            base.Handle(message);
        }
    }
}

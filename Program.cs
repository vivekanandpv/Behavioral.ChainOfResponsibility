using System;

namespace Behavioral.ChainOfResponsibility
{
    class Program
    {
        static void Main(string[] args)
        {
            var logger = new ConsoleLogHandler(1);
            logger.SetNext(new DebugLogHandler(1))
                .SetNext(new ConsoleLogHandler(2))
                .SetNext(new DebugLogHandler(2));
            
            logger.Handle(new LogMessage {Message = "Here is the message to log"});
        }
    }
}

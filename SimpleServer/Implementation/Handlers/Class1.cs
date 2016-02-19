using SimpleServerCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class MessageProcessor
{
    private List<IMessageHandler> handlers = new List<IMessageHandler>();

    public MessageProcessor()
    {
        handlers.Add(new DefaultMessageHandler());
        handlers.Add(new LoginMessageHandler());
    }

    public void ProcessMessage(IMessage msg)
    {
        foreach (IMessageHandler handler in handlers)
        {
            if (handler.HandlerMessage(msg))
            {
                break;
            }
        }
    }
}

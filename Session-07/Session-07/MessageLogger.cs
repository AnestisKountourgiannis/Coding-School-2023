using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_07
{
    public class MessageLogger
    {
        public Message[]? Messages { get; set; }
        public MessageLogger(Message[] messages)
        {
            Messages = messages;
        }
        public void ReadAll()
        {
        }
        public void Clear()
        {
        }
        public void Write(Message)
        {
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_07
{
    public class MessageLogger
    {
        public MessageLogger()
        {
            Messages = new Message[1000];
        }
        public Message[] Messages { get; set; }
        private int _messageCounter = 0;
        public MessageLogger(Message[] messages) { }
        
        public void ReadAll()
        {
        }
        public void Clear()
        {
        }
        public void Write(Message message)
        {
                Messages[_messageCounter] = message;
            _messageCounter++
            }
        }
    }
}
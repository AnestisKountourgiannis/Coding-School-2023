using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_07
{
    public class Message
    {
        public Guid ID { get; set; }
        public DateTime TimeStamp { get; set; }
        public string? Text { get; set; }
        public Message() { }
        public Message(Guid id)
        {
            ID = id;
        }
        public Message(Guid id, DateTime timestamp)
        {
            ID = id;
            TimeStamp = timestamp;
        }
        public Message(Guid id, DateTime timeStamp, string? message)
        {
            ID = id;
            TimeStamp = timeStamp;
            Text = message;
        }
    }
}
// See https://aka.ms/new-console-template for more information
namespace Session_07
{
    public enum ActionEnum
    {
        Convert,
        Uppercase,
        Reverse
    }
    public class ActionRequest
    {

        //properties
        public Guid RequestID { get; set; }
        public string? Input { get; set; }
        public ActionEnum Action { get; set; }
        //constructors
        public ActionRequest() {}
    public ActionRequest(Guid requestid)
        {
        RequestID = requestid;
        }
public ActionRequest(Guid requestid,string input)
        {
            RequestID = requestid;
            Input = input;
        }

    public ActtionRequest(Guid requestid, string? input, ActionEnum action)
        {
        RequestID = requestid;
        Input = input;
        Action = action;
        }
    }
    public class Message
    {
      public Guid ID { get; set; }
      public DateTime TimeStamp { get; set; }
      public string? Message { get; set; }
        public Message() {}
        public Message (Guid id)
        {
            ID = id;
        }
        public Message (Guid id, DateTime timestamp)
        {
            ID = id;
            TimeStamp = timestamp;
        }
        public Message(Guid id, DateTime timeStamp, string? message)
        {
            ID = id;
            TimeStamp = timeStamp;
            Message = message;
        }
    }
    public class MessageLogger
    {
        public Message[]? Messages { get; set; }
        public MessageLogger(Message[] messages)
        {
            Messages = messages;
        }
        public void ReadAll() {
        }
        public void Clear() {
        }
        public void Write(Message) {
        }
    }
    public class ActionResponse
    {
        public Guid RequestID { get; set; }
        public Guid ResponseID { get; set; }
        public string? Output { get; set; }
        public ActionResponse() { }
        public ActionResponse(Guid requestid)
        {
            RequestID = requestid;
        }
        public ActionResponse(Guid requestid, Guid responseid)
        {
            RequestID = requestid;
            ResponseID = responseid;
        }
        public ActionResponse(Guid requestid, Guid responseid, string? output)
        {
            RequestID = requestid;
            ResponseID = responseid;
            Output = output;
        }
    } 
    public class ActionResolver
    {
        public MessageLogger Logger { get; set; }
        public ActionResolver()
        {
        }
        public ActionResponse Execute(ActionRequest requestid)
        {
            if (Requestid !=null)
            {
                return Requestid;
            }
            return null;
        }
    }
}
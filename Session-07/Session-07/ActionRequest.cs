using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_07
{
    public class ActionRequest
    {

        //properties
        public Guid RequestID { get; set; }
        public string? Input { get; set; }
        public ActionEnum Action { get; set; }
        //constructors
        public ActionRequest() { }
        public ActionRequest(Guid requestid)
        {
            RequestID = requestid;
        }
        public ActionRequest(Guid requestid, string input)
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
}
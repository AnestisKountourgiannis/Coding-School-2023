using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_07
{
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
}
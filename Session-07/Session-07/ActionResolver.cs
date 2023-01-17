using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_07
{
    public class ActionResolver
    {
        public MessageLogger Logger { get; set; }
        public ActionResolver()
        {
        }
        public ActionResponse Execute(ActionRequest requestid)
        {
            if (Requestid != null)
            {
                return Requestid;
            }
            return null;
        }
    }
}
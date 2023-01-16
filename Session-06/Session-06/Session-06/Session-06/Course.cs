using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_06
{
    public class Course
    {
        //properties
        public Guid ID { get; set; }
        public string? Code { get; set; }
        public string? Subject { get; set; }
        //constructors
        public Course() { }
        public Course(Guid id)
        {
            ID = id;
        }
        public Course(Guid id,string code)
        {
            ID = id;
            Code = code;
        }
        public Course(Guid id, string code, string subject)
        {
            ID = id;
            Code = code;
            Subject = subject;
        }
    }
}

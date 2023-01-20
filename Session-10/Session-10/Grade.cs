using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Cache;
using System.Text;
using System.Threading.Tasks;

namespace Session_06
{
    public class Grade
    {
        //properties
        public Guid ID { get; set; }
        public Guid StudentID { get; set; }
        public Guid CourseID { get; set; }
        public int Grades { get; set; }
        //constructors
        public Grade() { }
        public Grade(Guid id)
        {
            ID = id;
        }
        public Grade(Guid id, Guid studentid)
        {
            ID = id;
            StudentID = studentid;
        }
        public Grade(Guid id,Guid studentid,Guid courseid)
        {
                ID = id;
                StudentID= studentid;
                CourseID = courseid;
        }
        public Grade(Guid id, Guid studentid, Guid courseid, int grade)
        {
            ID = id;
            StudentID = studentid;
            CourseID = courseid;
            Grades= grade;
        }
    }
}
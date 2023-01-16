using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_06
{
    public class Schedule
    {
        //properties
        public Guid ID { get; set; }
        public Guid CourseID { get; set; }
        public Guid ProfessorID { get; set; }
        public DateTime Callendar { get; set; }
        //constructors
        public Schedule() {}
        public Schedule(Guid id)
        {
            ID= id; 
        }
        public Schedule(Guid id, Guid courseid)
        {
            ID= id;
            CourseID= courseid;

        }
        public Schedule(Guid id, Guid courseid, Guid professorid) 
        {
            ID = id;
            CourseID = courseid;
            ProfessorID = professorid;
        }
        public Schedule(Guid id, Guid courseid, Guid professorid, DateTime callendar) 
        {
            ID = id;
            CourseID = courseid;
            ProfessorID = professorid;
            Callendar = callendar;
        }
    }
}

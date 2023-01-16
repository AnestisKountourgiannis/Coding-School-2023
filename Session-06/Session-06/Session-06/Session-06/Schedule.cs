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
        public Schedule(Guid iD, Guid courseID, Guid professorID) 
        {
            CourseID = courseID;
            ProfessorID = professorID;
        }
        public Schedule(Guid iD, Guid courseID, Guid professorID, DateTime callendar) : this(iD, courseID, professorID)
        {
            CourseID = courseID;
            ProfessorID = professorID;
            Callendar = callendar;
        }
    }
}

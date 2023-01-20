using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_06
{
    public class University : Institute
    {
        //properties
        public Student[]? Students { get; set; }
        public Course[]? Courses { get; set; }
        public Grade[]? Grades { get; set; }
        public Schedule[]? ScheduledCourse { get; set; }

        //constructors
        public University()
        {
        }
        public University(Guid id) : base(id)
        {
        }
        public University(Guid id, string name) : base(id, name)
        {
        }

        //methods
        public void GetStudents()
        {
        }
        public void GetCours()
        {
        }
        public void GetGrades()
        {
        }
        public void SetSchedule(Guid courseId, Guid ProfessorID, DateTime datetime)
        {
        }
    }
}

  

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University
{
    public class University : Institute
    {
        public List<Student> Students;
        public List<Professor> Professors;
        public List<Course> Courses;
        public List<Grade> Grades;
        public List<Schedule> ScheduledCourses;
        public University()
        {
            Students = new List<Student>();
            Courses = new List<Course>();
            Grades = new List<Grade>();
            Professors = new List<Professor>();
            ScheduledCourses = new List<Schedule>();
        }
        public void GetStudents()
        {

        }
        public void GetCourses()
        {

        }
        public void GetGrades()
        {

        }
        public void SetSchedule(Guid coursID, Guid professorID, DateTime datetime)
        {

        }
    }
}
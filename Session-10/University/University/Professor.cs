using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University
{
    public class Professor : Person
    {
        public string Rank { get; set; }
        public List<Course> Courses;
        public Professor(string name, int age, string rank, List<Course> courseList) : base(name, age)
        {
            Rank = rank;
            Courses = courseList;
        }

        public void Teach(Course course, DateTime datetime)
        {
        }
        public void SetGrade(Guid studentID, Guid courseID, int grade)
        {

        }
        public void GetName()
        { 
            
        }
    }
}
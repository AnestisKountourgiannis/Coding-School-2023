using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University
{
    public class Student : Person
    {
        public int RegistrationNumber { get; set; }
        public List<Course> Courses;
        public Student(string name, int age, int registrationNumber, List<Course> courseList) : base(name, age)
        {
            RegistrationNumber = registrationNumber;
            Courses = courseList;
        }
    }
}
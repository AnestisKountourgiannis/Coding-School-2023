using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_06
{
    internal class Student : Person
    {
        public int RegistrationNumber { get; set; }
        public Course[] Courses;

        public void Attend(Course course, DateTime datetime) { }
        public void WriteExam(Course course, DateTime datetime) { }
    }
}
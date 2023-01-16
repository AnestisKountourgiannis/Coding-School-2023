using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Session_06
{
    public class Professor : Person
    { 
        public string Rank { get; set; }
        public Course[] Courses;
        
        public Professor()
        {
            Courses = new Course[20];
        }
        public Professor(Guid id, string name) : base(id, name)
        {

        }
        public Professor(Guid id,string name,string rank, Course[] course): base(id, name)
        {
            Rank = rank;
            Courses = course;
        }
        public void Teach(Course course,DateTime datetime) { }
        public void SetGrade() { }
    }
}

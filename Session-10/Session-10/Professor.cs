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
    internal class Professor : Person
    { 
        //properties
        public string Rank { get; set; }
        public Course[]? Courses { get; set; }
        //constructors
        public Professor() : base() { }
        public Professor(Guid id): base( id) { }
        public Professor(Guid id, string name) : base( id, name) { }
        public Professor(Guid id, string name, string rank) : base(id, name)
        {
            Rank = rank;
        }
        public Professor(Guid id,string name,string rank, Course[] course): base(id, name)
        {
            Rank = rank;
            Courses = course;
        }
        public void Teach(Course course,DateTime datetime) { }
        public void SetGrade(Guid studentID,Guid courseID,int grade) { }
        public static new string GetName()
        {
           return String.Format("Dr. (0)", name);
        }
    }
}

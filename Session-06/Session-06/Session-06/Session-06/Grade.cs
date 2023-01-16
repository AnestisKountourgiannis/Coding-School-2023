using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
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
        public int Grade { get; set; }
        //constructors
        public Grade() { }
        public Grade(Guid id)
        {
            ID = id;
        }
        public Grade(Guid ID, Guid StudentID)
        {
            ID =    
        }



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University
{
    public class Grade
    {
        public Guid ID { get; }
        public Guid StudentID { get; }
        public Guid CourseID { get; }
        public int Mark { get; set; }
        public Grade(Guid courseId, Guid studentId, int mark)
        {
            ID = Guid.NewGuid();
            CourseID = courseId;
            StudentID = studentId;
            Mark = mark;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libs {

    public class Employee {

        public Guid ID { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public double Salary { get; set; }
        
        public EmployeeType EmployeeType { get; set; }

        
        public Employee() {
            ID = Guid.NewGuid();
        }

    }

}

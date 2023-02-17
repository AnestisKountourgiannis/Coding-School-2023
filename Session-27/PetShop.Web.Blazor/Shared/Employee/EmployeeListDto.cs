using PetShop.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Web.Blazor.Shared.Employee {
    public class EmployeeListDto {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public EmployeeType EmployeeType { get; set; }
        public int SalaryPerMonth { get; set; }
    }
}

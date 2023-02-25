using FuelStation.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelStation.Web.Blazor.Shared.Employee {
    public class EmployeeListDto {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public DateTime HireDateStart { get; set; }
        public DateTime HireDateEnd { get; set; }
        public int SallaryPerMonth { get; set; }
        public EmployeeType EmployeeType { get; set; }
    }
}

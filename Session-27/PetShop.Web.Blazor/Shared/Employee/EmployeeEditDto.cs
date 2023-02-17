using PetShop.Model.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Web.Blazor.Shared.Employee {
    public class EmployeeEditDto {
        public int Id { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Name must have max length 50 letters.")]
        public string Name { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Surname must have max length 50 letters.")]
        public string Surname { get; set; }
		public EmployeeType EmployeeType { get; set; }
		public int SalaryPerMonth { get; set; }
    }
}

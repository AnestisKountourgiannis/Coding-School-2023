using FuelStation.Model.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelStation.Web.Blazor.Shared.Employee {
	public class EmployeeEditDto {
		public int Id { get; set; }
		[Required]
		[MaxLength(50, ErrorMessage = "Name must have max length 50 letters.")]
		public string Name { get; set; } = null!;
		[Required]
		[MaxLength(50, ErrorMessage = "Surname must have max length 50 letters.")]
		public string Surname { get; set; } = null!;
		[Required]
		public DateTime HireDateStart { get; set; }
		[Required]
		public DateTime HireDateEnd { get; set; }
		[Required]
		[Range(0,10000, ErrorMessage = "Salary must have range (0,10000)")]
		public int SallaryPerMonth { get; set; }
		[Required]
		public EmployeeType EmployeeType { get; set; }
	}
}

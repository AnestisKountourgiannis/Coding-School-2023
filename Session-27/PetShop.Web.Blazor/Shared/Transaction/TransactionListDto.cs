using PetShop.Model.Enums;
using PetShop.Web.Blazor.Shared.Customer;
using PetShop.Web.Blazor.Shared.Employee;
using PetShop.Web.Blazor.Shared.Pet;
using PetShop.Web.Blazor.Shared.PetFood;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Web.Blazor.Shared.Transaction {
    public class TransactionListDto {
		public int Id { get; set; }
		public DateTime Date { get; set; }
		public decimal PetPrice { get; set; }
		public int PetFoodQty { get; set; }
		public decimal PetFoodPrice { get; set; }
		public decimal TotalPrice { get; set; }
		public int CustomerId { get; set; }
		public int EmployeeId { get; set; }
		public int PetId { get; set; }
		public int PetFoodId { get; set; }
		public decimal PetFoodCost { get; set; }
		public decimal PetCost { get; set; }
		

		public List<CustomerListDto> Customers { get; set; } = new();
		public List<EmployeeListDto> Employees { get; set; } = new();
		public List<PetFoodListDto> PetFoods { get; set; } = new();
		public List<PetListDto> Pets { get; set; } = new();

		public string CustomerFullName { get; set; } = null!;
		public string EmployeeFullName { get; set; } = null!;
		public AnimalType PetFoodAnimalType { get; set; }
		public string PetBreed { get; set; } = null!;
		public AnimalType PetType { get; set; }
		public decimal EmployeeSalary { get; set; }
	}
}

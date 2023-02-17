using PetShop.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Web.Blazor.Shared.Transaction {
    public class TransactionDetailsDto {
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

        public string CustomerFullName { get; set; } = null!;
        public string EmployeeFullName { get; set; } = null!;
        public AnimalType PetFoodAnimalType { get; set; }
        public string PetBreed { get; set; } = null!;
    }
}

using PetShop.Model.Enums;
using PetShop.Web.Blazor.Shared.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Web.Blazor.Shared.Employee {
    public class EmployeeDetailsDto {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public EmployeeType EmployeeType { get; set; }
        public int SalaryPerMonth { get; set; }
        public List<TransactionDetailsDto> Transactions { get; set; } = new List<TransactionDetailsDto>();
    }
}

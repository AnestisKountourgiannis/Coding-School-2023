using PetShop.Web.Blazor.Shared.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Web.Blazor.Shared.Customer {
	public class CustomerDetailsDto {
		public int Id { get; set; }
		public string Name { get; set; }
		public string Surname { get; set; }
		public string Phone { get; set; }
		public string Tin { get; set; }
		public List<TransactionDetailsDto> Transactions { get; set; } = new List<TransactionDetailsDto>();

	}
}

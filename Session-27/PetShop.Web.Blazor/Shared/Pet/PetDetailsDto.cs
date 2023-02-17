using PetShop.Model.Enums;
using PetShop.Web.Blazor.Shared.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Web.Blazor.Shared.Pet {
	public class PetDetailsDto {
		public int Id { get; set; }
		public string Breed { get; set; }
		public AnimalType AnimalType { get; set; }
		public PetStatus PetStatus { get; set; }
		public decimal Price { get; set; }
		public decimal Cost { get; set; }
		public List<TransactionDetailsDto> Transactions { get; set; } = new List<TransactionDetailsDto>();
	}
}

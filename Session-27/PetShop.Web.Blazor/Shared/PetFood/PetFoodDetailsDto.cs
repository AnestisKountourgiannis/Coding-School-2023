using PetShop.Model.Enums;
using PetShop.Web.Blazor.Shared.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Web.Blazor.Shared.PetFood {
    public class PetFoodDetailsDto {
        public int Id { get; set; }
        public AnimalType AnimalType { get; set; }
        public decimal Price { get; set; }
        public decimal Cost { get; set; }
        public List<TransactionDetailsDto> Transactions { get; set; } = new List<TransactionDetailsDto>();
    }
}

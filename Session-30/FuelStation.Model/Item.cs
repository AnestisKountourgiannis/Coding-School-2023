using FuelStation.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelStation.Model {
    public class Item {

        public Item(string code, string description, ItemType itemType, decimal price, decimal cost) {
            Code = code;
            Description = description;
            ItemType = itemType;
            Price = price;
            Cost = cost;

            TransactionLines = new List<TransactionLine>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public ItemType ItemType { get; set; }
        public decimal Price { get; set; }
        public decimal Cost { get; set; }

        //RELATIONS
        public List<TransactionLine> TransactionLines { get; set; }
    }
}

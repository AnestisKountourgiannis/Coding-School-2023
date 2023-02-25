using FuelStation.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelStation.Web.Blazor.Shared.Item {
	public class ItemListDto {
		public int Id { get; set; }
		public string Code { get; set; } = null!;
		public string Description { get; set; } = null!;
		public ItemType ItemType { get; set; }
		public decimal Price { get; set; }
		public decimal Cost { get; set; }
	}
}

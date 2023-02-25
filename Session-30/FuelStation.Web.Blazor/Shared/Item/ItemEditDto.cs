using FuelStation.Model.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelStation.Web.Blazor.Shared.Item {
	public class ItemEditDto {
		public int Id { get; set; }
		[Required]
		[MaxLength(10, ErrorMessage = "Code must have max length 10 numbers.")]
		public string Code { get; set; } = null!;
		[Required]
		[MaxLength(100, ErrorMessage = "Despription must have max length 100 letters.")]
		public string Description { get; set; } = null!;
		[Required]
		public ItemType ItemType { get; set; }
		[Required]
		[RegularExpression(@"^(0|[1-9]\d{0,2})(.\d{1,2})?$", ErrorMessage = "Invalid Price Number. Must have precision (5,2).")]
		[Range(1, 999.99, ErrorMessage = "Invalid Price Number. Must have range (1,999.99).")]
		public decimal Price { get; set; }
		[Required]
		[RegularExpression(@"^(0|[1-9]\d{0,2})(.\d{1,2})?$", ErrorMessage = "Invalid Price Number. Must have precision (5,2).")]
		[Range(1, 999.99, ErrorMessage = "Invalid Price Number. Must have range (1,999.99).")]
		public decimal Cost { get; set; }
	}
}

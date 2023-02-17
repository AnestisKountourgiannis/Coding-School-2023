using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Web.Blazor.Shared.Customer
{
    public class CustomerEditDto
    {
        public int Id { get; set; }
		[Required]
		[MaxLength(50, ErrorMessage = "Name must have max length 50 letters.")]
		public string Name { get; set; } = null!;
		[Required]
		[MaxLength(50, ErrorMessage = "Surname must have max length 50 letters.")]
		public string Surname { get; set; } = null!;
		[Required]
		[MaxLength(12, ErrorMessage = "Phone must have max length 12 digits.")]
		public string Phone { get; set; }
		[Required]
		[MaxLength(10, ErrorMessage = "Tin must have max length 10 digits.")]
		public string Tin { get; set; } = null!;
    }
}

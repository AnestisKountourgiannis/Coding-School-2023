using PetShop.Model.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Web.Blazor.Shared.Pet
{
    public class PetEditDto
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Breed must have max length 50 letters.")]
		public string Breed { get; set; } = null!;
        public AnimalType AnimalType { get; set; }
        public PetStatus PetStatus { get; set; }
        [RegularExpression(@"^(0|[1-9][0-9]?)(.\d{1,2})?$", ErrorMessage = "Invalid Price Number. Must have precision (4,2).")]
        [Range(1, 99, ErrorMessage = "Invalid Price Number. Must have precision (4,2).")]
        public decimal Price { get; set; }
        [RegularExpression(@"^(0|[1-9][0-9]?)(.\d{1,2})?$", ErrorMessage = "Invalid Cost Number. Must have precision (4,2).")]
        [Range(1, 99, ErrorMessage = "Invalid Price Number. Must have precision (4,2).")]
        public decimal Cost { get; set; }
    }
}

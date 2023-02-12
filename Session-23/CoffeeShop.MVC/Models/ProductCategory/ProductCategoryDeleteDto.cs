using CoffeeShop.Model.Enums;

namespace CoffeeShop.MVC.Models.ProductCategory {
    public class ProductCategoryDeleteDto {
        public int Id { get; set; }
        public string Code { get; set; } = null!;
        public string Description { get; set; } = null!;
        public ProductType ProductType { get; set; }
    }
}

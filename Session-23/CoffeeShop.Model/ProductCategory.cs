﻿using CoffeeShop.Model.Enums;

namespace CoffeeShop.Model
{
    public class ProductCategory: BaseEntity { 
        public ProductCategory(string code, string description, ProductType productType)
        {
            Code = code;
            Description = description;
            ProductType = productType;

            Products = new List<Product>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public ProductType ProductType { get; set; }

        
        public List<Product> Products { get; set; }
    }
}

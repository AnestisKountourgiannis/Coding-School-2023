using CoffeeShop.EF.Context;
using CoffeeShop.EF.Repositories;
using CoffeeShop.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Orm.Repositories {
    public class ProductRepo : IEntityRepo<Product> {
        public void Create(Product entity) {
            using var context = new CoffeeShopDbContext();
            context.Products.Add(entity);
            context.SaveChanges();
        }

        public void Delete(int id) {
            using var context = new CoffeeShopDbContext();
            var foundTodo = context.Products.SingleOrDefault(prod => prod.Id == id);
            if (foundTodo is null)
                return;
            context.Products.Remove(foundTodo);
            context.SaveChanges();
        }

        public IList<Product> GetAll() {
            using var context = new CoffeeShopDbContext();
            return context.Products.ToList();
        }

        public Product? GetById(int id) {
            using var context = new CoffeeShopDbContext();
            return context.Products.Include(prod=>prod.ProductCategory).Where(prod => prod.Id == id).SingleOrDefault();
        }

        public void Update(int id, Product entity) {
            using var context = new CoffeeShopDbContext();
            var foundProduct = context.Products.SingleOrDefault(prod => prod.Id == id);
            if (foundProduct is null)
                return;
            foundProduct.Cost = entity.Cost;
            foundProduct.Code = entity.Code;
            foundProduct.Price = entity.Price;
            foundProduct.Description = entity.Description;
            foundProduct.ProductCategory = entity.ProductCategory;
            foundProduct.ProductCategoryId = entity.ProductCategoryId;
            context.SaveChanges();
        }
    }
}

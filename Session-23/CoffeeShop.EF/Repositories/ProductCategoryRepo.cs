using CoffeeShop.EF.Context;
using CoffeeShop.EF.Repositories;
using CoffeeShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Orm.Repositories {
    public class ProductCategoryRepo : IEntityRepo<ProductCategory> {
        public void Create(ProductCategory entity) {
            using var context = new CoffeeShopDbContext();
            context.ProductCategories.Add(entity);
            context.SaveChanges();
        }

        public void Delete(int id) {
            using var context = new CoffeeShopDbContext();
            var foundProdCat = context.ProductCategories.SingleOrDefault(prodCat => prodCat.Id == id);
            if (foundProdCat is null)
                return;
            context.ProductCategories.Remove(foundProdCat);
             context.SaveChanges();
        }

        public IList<ProductCategory> GetAll() {
            using var context = new CoffeeShopDbContext();
            return context.ProductCategories.ToList();
        }

        public ProductCategory? GetById(int id) {
            using var context = new CoffeeShopDbContext();
            return context.ProductCategories.Where(prodCat => prodCat.Id == id).SingleOrDefault();
        }

        public void Update(int id, ProductCategory entity) {
            using var context = new CoffeeShopDbContext();
            var foundProductCat = context.ProductCategories.SingleOrDefault(prodCat => prodCat.Id == id);
            if (foundProductCat is null)
                return;
            foundProductCat.Code = entity.Code;
            foundProductCat.Description = entity.Description;
            foundProductCat.ProductType = entity.ProductType;
            context.SaveChanges();
        }
    }
}

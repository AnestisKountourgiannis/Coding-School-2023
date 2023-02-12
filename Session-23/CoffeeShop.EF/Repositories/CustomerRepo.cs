using CoffeeShop.EF.Context;
using CoffeeShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.EF.Repositories {
    public class CustomerRepo : IEntityRepo<Customer> {
        public void Create(Customer entity) {
            using var context = new CoffeeShopDbContext();
            context.Customers.Add(entity);
             context.SaveChanges();
        }

        public void Delete(int id) {
            using var context = new CoffeeShopDbContext();
            var foundCustomer = context.Customers.SingleOrDefault(customer => customer.Id == id);
            if (foundCustomer is null)
                return;

            context.Customers.Remove(foundCustomer);
            context.SaveChanges();
        }

        public IList<Customer> GetAll() {
            using var context = new CoffeeShopDbContext();
            return context.Customers.ToList();
        }

        public Customer? GetById(int id) {
            using var context = new CoffeeShopDbContext();
            return context.Customers.Where(customer => customer.Id == id).SingleOrDefault();
        }

        public void Update(int id, Customer entity) {
            using var context = new CoffeeShopDbContext();
            var foundCustomer = context.Customers.SingleOrDefault(customer => customer.Id == id);
            if (foundCustomer is null)
                return;

            foundCustomer.Code = entity.Code;
            foundCustomer.Description = entity.Description;
            context.SaveChanges();
        }
    }
}

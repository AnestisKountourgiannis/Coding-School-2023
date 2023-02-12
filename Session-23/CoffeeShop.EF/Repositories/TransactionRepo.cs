using CoffeeShop.EF.Context;
using CoffeeShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.EF.Repositories {
    public class TransactionRepo : IEntityRepo<Transaction> {
        public void Create(Transaction entity) {
            using var context = new CoffeeShopDbContext();
            context.Transactions.Add(entity);
            context.SaveChanges();
        }

        public void Delete(int id) {
            using var context = new CoffeeShopDbContext();
            var foundTrans = context.Transactions.SingleOrDefault(trans => trans.Id == id);
            if (foundTrans is null)
                return;

            context.Transactions.Remove(foundTrans);
            context.SaveChanges();
        }

        public IList<Transaction> GetAll() {
            using var context = new CoffeeShopDbContext();
            return context.Transactions.ToList();
        }
        public Transaction? GetById(int id) {
            using var context = new CoffeeShopDbContext();
            return context.Transactions.Where(trans => trans.Id == id).SingleOrDefault(); ;
        }

        public void Update(int id, Transaction entity) {
            using var context = new CoffeeShopDbContext();
            var foundTrans = context.Transactions.SingleOrDefault(trans => trans.Id == id);
            if (foundTrans is null)
                return;
            foundTrans.Date = entity.Date;
            foundTrans.EmployeeId = entity.EmployeeId;
            foundTrans.CustomerId = entity.CustomerId;
            foundTrans.PaymentMethod = entity.PaymentMethod;
            foundTrans.TotalPrice = entity.TotalPrice;
            foundTrans.Date = entity.Date;
            context.SaveChanges();
        }
    }
}

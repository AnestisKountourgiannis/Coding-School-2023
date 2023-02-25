using FuelStation.EF.Context;
using FuelStation.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelStation.EF.Repositories {
    public class TransactionRepo : IEntityRepo<Transaction> {
        public void Add(Transaction entity) {

            using var context = new FuelStationDbContext();
            if (entity.Id != 0) {

                throw new ArgumentException("Given entity should not have Id set", nameof(entity));
            }
            context.Add(entity);
            context.SaveChanges();
        }

        public void Delete(int id) {

            using var context = new FuelStationDbContext();
            var dbTransaction = context.Transactions.Where(transaction => transaction.Id == id).SingleOrDefault();
            if (dbTransaction is null) {
                throw new KeyNotFoundException($"Given id '{id}' was not found in database");
            }
            context.Remove(dbTransaction);
            context.SaveChanges();
        }

        public IEnumerable<Transaction> GetAll() {

            using var context = new FuelStationDbContext();
            return context.Transactions.Include(transaction => transaction.Customer).Include(transaction => transaction.Employee)
                .Include(transaction => transaction.TransactionLines).ToList();
        }

        public Transaction? GetById(int id) {

            using var context = new FuelStationDbContext();
            return context.Transactions.Where(transaction => transaction.Id == id).Include(transaction => transaction.Customer)
                .Include(transaction => transaction.Employee).Include(transaction => transaction.TransactionLines).SingleOrDefault();
        }

        public void Update(int id, Transaction entity) {

            using var context = new FuelStationDbContext();
            var dbTransaction = context.Transactions.Where(transaction => transaction.Id == id).SingleOrDefault();
            if (dbTransaction is null) {
                throw new KeyNotFoundException($"Given id '{id}' was not found in database");
            }
            dbTransaction.Date = entity.Date;
            dbTransaction.PaymentMethod = entity.PaymentMethod;
            dbTransaction.TotalValue = entity.TotalValue;
            dbTransaction.CustomerId = entity.CustomerId;
            dbTransaction.EmployeeId = entity.EmployeeId;
            context.SaveChanges();
        }
    }
}

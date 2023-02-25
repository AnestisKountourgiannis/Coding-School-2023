using FuelStation.EF.Context;
using FuelStation.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelStation.EF.Repositories {
    public class TransactionLineRepo : IEntityRepo<TransactionLine> {
        public void Add(TransactionLine entity) {

            using var context = new FuelStationDbContext();
            if (entity.Id != 0) {

                throw new ArgumentException("Given entity should not have Id set", nameof(entity));
            }
            context.Add(entity);
            context.SaveChanges();
        }

        public void Delete(int id) {

            using var context = new FuelStationDbContext();
            var dbTransactionLine = context.TransactionLines.Where(transactionLine => transactionLine.Id == id).SingleOrDefault();
            if (dbTransactionLine is null) {
                throw new KeyNotFoundException($"Given id '{id}' was not found in database");
            }
            context.Remove(dbTransactionLine);
            context.SaveChanges();
        }

        public IEnumerable<TransactionLine> GetAll() {

            using var context = new FuelStationDbContext();
            return context.TransactionLines.Include(transactionLine => transactionLine.Transaction)
                .Include(transactionLine => transactionLine.Item).ToList();
        }

        public TransactionLine? GetById(int id) {

            using var context = new FuelStationDbContext();
            return context.TransactionLines.Where(transactionLine => transactionLine.Id == id).Include(transactionLine => transactionLine.Transaction)
                .Include(transactionLine => transactionLine.Item).SingleOrDefault();
        }

        public void Update(int id, TransactionLine entity) {

            using var context = new FuelStationDbContext();
            var dbTransactionLine = context.TransactionLines.Where(transactionLine => transactionLine.Id == id).SingleOrDefault();
            if (dbTransactionLine is null) {
                throw new KeyNotFoundException($"Given id '{id}' was not found in database");
            }
            dbTransactionLine.Quantity = entity.Quantity;
            dbTransactionLine.ItemPrice = entity.ItemPrice;
            dbTransactionLine.NetValue = entity.NetValue;
            dbTransactionLine.DiscountPercent = entity.DiscountPercent;
            dbTransactionLine.DiscountValue = entity.DiscountValue;
            dbTransactionLine.TotalValue = entity.TotalValue;
            dbTransactionLine.TransactionId = entity.TransactionId;
            dbTransactionLine.ItemId = entity.ItemId;
            context.SaveChanges();
        }
    }
}

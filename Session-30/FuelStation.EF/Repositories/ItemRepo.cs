using FuelStation.EF.Context;
using FuelStation.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelStation.EF.Repositories {
    public class ItemRepo : IEntityRepo<Item> {
        public void Add(Item entity) {

            using var context = new FuelStationDbContext();
            if (entity.Id != 0) {

                throw new ArgumentException("Given entity should not have Id set", nameof(entity));
            }
            context.Add(entity);
            context.SaveChanges();
        }

        public void Delete(int id) {

            using var context = new FuelStationDbContext();
            var dbItem = context.Items.SingleOrDefault(item => item.Id == id);
            if (dbItem is null) {
                throw new KeyNotFoundException($"Given id '{id}' was not found in database");
            }
            context.Remove(dbItem);
            context.SaveChanges();
        }

        public IEnumerable<Item> GetAll() {

            using var context = new FuelStationDbContext();
            return context.Items.Include(item => item.TransactionLines).ToList();
        }

        public Item? GetById(int id) {

            using var context = new FuelStationDbContext();
            return context.Items.Where(item => item.Id == id).Include(item => item.TransactionLines).SingleOrDefault();
        }

        public void Update(int id, Item entity) {

            using var context = new FuelStationDbContext();
            var dbItem = context.Items.Where(item => item.Id == id).SingleOrDefault();
            if (dbItem is null) {
                throw new KeyNotFoundException($"Given id '{id}' was not found in database");
            }
            dbItem.Code = entity.Code;
            dbItem.Description = entity.Description;
            dbItem.ItemType = entity.ItemType;
            dbItem.Price = entity.Price;
            dbItem.Cost = entity.Cost;
            dbItem.TransactionLines = entity.TransactionLines;
            context.SaveChanges();
        }
    }
}

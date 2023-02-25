using FuelStation.EF.Context;
using FuelStation.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelStation.EF.Repositories {
    public class EmployeeRepo : IEntityRepo<Employee> {
        public void Add(Employee entity) {

            using var context = new FuelStationDbContext();
            if (entity.Id != 0) {

                throw new ArgumentException("Given entity should not have Id set", nameof(entity));
            }
            context.Add(entity);
            context.SaveChanges();
        }

        public void Delete(int id) {

            using var context = new FuelStationDbContext();
            var dbEmployee = context.Employees.SingleOrDefault(employee => employee.Id == id);
            if (dbEmployee is null) {
                throw new KeyNotFoundException($"Given id '{id}' was not found in database");
            }
            context.Remove(dbEmployee);
            context.SaveChanges();
        }

        public IEnumerable<Employee> GetAll() {

            using var context = new FuelStationDbContext();
            return context.Employees.Include(employee => employee.Transactions).ToList();
        }

        public Employee? GetById(int id) {

            using var context = new FuelStationDbContext();
            return context.Employees.Where(employee => employee.Id == id).Include(employee => employee.Transactions).SingleOrDefault();
        }

        public void Update(int id, Employee entity) {

            using var context = new FuelStationDbContext();
            var dbEmployee = context.Employees.Where(employee => employee.Id == id).SingleOrDefault();
            if (dbEmployee is null) {
                throw new KeyNotFoundException($"Given id '{id}' was not found in database");
            }
            dbEmployee.Name = entity.Name;
            dbEmployee.Surname = entity.Surname;
            dbEmployee.HireDateStart = entity.HireDateStart;
            dbEmployee.HireDateEnd = entity.HireDateEnd;
            dbEmployee.SallaryPerMonth = entity.SallaryPerMonth;
            dbEmployee.EmployeeType = entity.EmployeeType;
            dbEmployee.Transactions = entity.Transactions;
            context.SaveChanges();
        }
    }
}

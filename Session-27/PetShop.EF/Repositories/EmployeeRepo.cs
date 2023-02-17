using Microsoft.EntityFrameworkCore;
using PetShop.EF.Context;
using PetShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.EF.Repositories {
    public class EmployeeRepo : IEntityRepo<Employee> {
        public void Add(Employee entity) {
            using var context = new PetShopDbContext();
            if (entity.Id != 0) 
                throw new ArgumentException("Given entity should not have Id set", nameof(entity));
            context.Add(entity);
            context.SaveChanges();
        }

        public void Delete(int id) {
            using var context = new PetShopDbContext();
            var dbEmployee = context.Employees.Where(employee => employee.Id == id).SingleOrDefault();
            if(dbEmployee is null)
                throw new KeyNotFoundException($"Given id '{id}' was not found in database");
            context.Remove(dbEmployee);
            context.SaveChanges();
        }

        public IList<Employee> GetAll() {
            using var context = new PetShopDbContext();
            return context.Employees.Include(employee => employee.Transactions).ToList();
        }

        public Employee GetById(int id) {
            using var context = new PetShopDbContext();
            return context.Employees.Include(employee => employee.Transactions).SingleOrDefault(employee => employee.Id == id);
        }

        public void Update(int id, Employee entity) {
            using var context = new PetShopDbContext();
            var dbEmployee = context.Employees
                .Include(employee => employee.Transactions)
                .Where(employee => employee.Id == id).SingleOrDefault();
            if(dbEmployee is null)
                throw new KeyNotFoundException($"Given id '{id}' was not found in database");
            dbEmployee.Name = entity.Name;
            dbEmployee.Surname = entity.Surname;
            dbEmployee.EmployeeType = entity.EmployeeType;
            dbEmployee.SalaryPerMonth = entity.SalaryPerMonth;
            context.SaveChanges();
        }
    }
}

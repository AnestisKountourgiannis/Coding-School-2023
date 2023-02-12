using CoffeeShop.EF.Context;
using CoffeeShop.EF.Repositories;
using CoffeeShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Orm.Repositories {
    public class EmployeeRepo : IEntityRepo<Employee> {
        public void Create(Employee entity) {
            using var context = new CoffeeShopDbContext();
            context.Employees.Add(entity);
            context.SaveChanges();
        }

        public void Delete(int id) {
            using var context = new CoffeeShopDbContext();
            var foundEmployee = context.Employees.SingleOrDefault(prodCat => prodCat.Id == id);
            if (foundEmployee is null)
                return;
            context.Employees.Remove(foundEmployee);
            context.SaveChanges();
        }

        public IList<Employee> GetAll() {
            using var context = new CoffeeShopDbContext();
            return context.Employees.ToList();
        }

        public Employee? GetById(int id) {
            using var context = new CoffeeShopDbContext();
            return context.Employees.Where(employee => employee.Id == id).SingleOrDefault();
        }

        public void Update(int id, Employee entity) {
            using var context = new CoffeeShopDbContext();
            var foundEmployee = context.Employees.SingleOrDefault(employee => employee.Id == id);
            if (foundEmployee is null)
                return;
            foundEmployee.Name = entity.Name;
            foundEmployee.Surname = entity.Surname;
            foundEmployee.SalaryPerMonth = entity.SalaryPerMonth;
            foundEmployee.EmployeeType = entity.EmployeeType;
            context.SaveChanges();
        }
    }
}

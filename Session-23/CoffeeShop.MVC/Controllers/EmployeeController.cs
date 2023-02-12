using CoffeeShop.EF.Repositories;
using CoffeeShop.Model;
using CoffeeShop.MVC.Models.Employee;
using CoffeeShop.MVC.Models.ProductCategory;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShop.MVC.Controllers {
    public class EmployeeController : Controller {
        private IEntityRepo<Employee> _employeeRepo;
        private IEntityRepo<Transaction> _transactionRepo;
        public EmployeeController(IEntityRepo<Employee> employeeRepo, IEntityRepo<Transaction> transactionRepo) {
            _employeeRepo = employeeRepo;
            _transactionRepo = transactionRepo;

        }
        // GET: EmployeeController
        public ActionResult Index() {
            var emp = _employeeRepo.GetAll();
            var employees = emp.ToList();
            return View(model:employees);
        }

        // GET: EmployeeController/Details/5
        public ActionResult Details(int? id) {
            var employee = _employeeRepo.GetById(id.Value);
            if (id == null) {
                return NotFound();
            }
            if (employee == null) {
                return NotFound();
            }
            var viewEmployee = new EmployeeDetailsDto {
                EmployeeType= employee.EmployeeType,
                Id= employee.Id,
                Name= employee.Name,
                Surname= employee.Surname,
                SalaryPerMonth= employee.SalaryPerMonth
            
            };
            var transList = _transactionRepo.GetAll().ToList();
            foreach(var tr in transList) {
                if(tr.EmployeeId == viewEmployee.Id) {
                    viewEmployee.Transactions.Add(tr);
                }
            }
            return View(model: viewEmployee);
        }

        // GET: EmployeeController/Create
        public ActionResult Create() {
            var newEmployee = new EmployeeCreateDto();
            var prodCats = _employeeRepo.GetAll();
            return View(model: newEmployee);
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmployeeCreateDto employee) {
            if (!ModelState.IsValid) {
                return View();
            }
            var dbEmployee = new Employee(employee.Name,employee.Surname,employee.SalaryPerMonth,employee.EmployeeType);
            try {
                _employeeRepo.Create(dbEmployee);
                return RedirectToAction(nameof(Index));
            }
            catch {
                return View();
            }
        }

        // GET: EmployeeController/Edit/5
        public ActionResult Edit(int id) {
            if (id == null) {
                return NotFound();
            }
            var dbEmployee = _employeeRepo.GetById(id);
            if (dbEmployee == null) {
                return NotFound();
            }
            var editEmployee = new EmployeeEditDto {
                Id = dbEmployee.Id
            };
       
            return View(model: editEmployee);
        }
    

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EmployeeEditDto employee) {
            if (!ModelState.IsValid) {
                return View();
            }
            var dbEmployee = _employeeRepo.GetById(id);
            if (dbEmployee == null) {
                return NotFound();
            }
            dbEmployee.Name = employee.Name;
            dbEmployee.Surname = employee.Surname;
            dbEmployee.SalaryPerMonth = employee.SalaryPerMonth;
            dbEmployee.EmployeeType = employee.EmployeeType;
            _employeeRepo.Update(id, dbEmployee);
            return RedirectToAction(nameof(Index));
        }

        // GET: EmployeeController/Delete/5
        public ActionResult Delete(int id) {
            var dbEmployee = _employeeRepo.GetById(id);
            if (dbEmployee == null) {
                return NotFound();
            }
            var deleteEmployee = new EmployeeDeleteDto {
                Id = dbEmployee.Id,
                Name= dbEmployee.Name,
                Surname= dbEmployee.Surname
            };
            return View(model: deleteEmployee);
        }

        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection) {
            _employeeRepo.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

using CoffeeShop.EF.Repositories;
using CoffeeShop.Model;
using CoffeeShop.MVC.Models.Customer;
using CoffeeShop.MVC.Models.Employee;
using CoffeeShop.Orm.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShop.MVC.Controllers {
    public class CustomerController : Controller {
        private IEntityRepo<Customer> _customerRepo;
        private IEntityRepo<Transaction> _transactionRepo;
        public CustomerController(IEntityRepo<Customer> customerRepo, IEntityRepo<Transaction> transactionRepo) {
            _customerRepo = customerRepo;
            _transactionRepo = transactionRepo;
        }
        #region Index
        // GET: CustomerController
        public ActionResult Index() {
            var cus = _customerRepo.GetAll();
            var customers = cus.ToList();
            return View(model: customers);
        }
        #endregion
        #region Details
        // GET: CustomerController/Details/5
        public ActionResult Details(int? id) {
            var customer = _customerRepo.GetById(id.Value);
            if (id == null) {
                return NotFound();
            }
            if (customer == null) {
                return NotFound();
            }
            var viewCustomer = new CustomerDetailsDto {
                Id= customer.Id,
                Code= customer.Code,
                Description= customer.Description,
            };
            var transList = _transactionRepo.GetAll().ToList();
            foreach (var tr in transList) {
                if (tr.CustomerId == viewCustomer.Id) {
                    viewCustomer.Transactions.Add(tr);
                }
            }
            return View(model: viewCustomer);
        }
        #endregion
        #region Create
        // GET: CustomerController/Create
        public ActionResult Create() {
            var newCustomer = new CustomerCreateDto();
            return View(model: newCustomer);
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CustomerCreateDto customer) {
            if (!ModelState.IsValid) {
                return View();
            }
            var dbCustomer = new Customer(customer.Code,customer.Description);
            try {
                _customerRepo.Create(dbCustomer);
                return RedirectToAction(nameof(Index));
            }
            catch {
                return View();

            } 
        }
        #endregion
        #region Edit
        // GET: CustomerController/Edit/5
        public ActionResult Edit(int id) {
            if (id == null) {
                return NotFound();
            }
            var dbCustomer = _customerRepo.GetById(id);
            if (dbCustomer == null) {
                return NotFound();
            }
            var editCustomer = new CustomerEditDto {
                Id = dbCustomer.Id
            };
            return View(model: editCustomer);
        } 



        // POST: CustomerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CustomerDeleteDto customer) {
            if (!ModelState.IsValid) {
                return View();
            }
            var dbCustomer = _customerRepo.GetById(id);
            if (dbCustomer == null) {
                return NotFound();
            }
            dbCustomer.Code = customer.Code;
            dbCustomer.Description = customer.Description;
            _customerRepo.Update(id, dbCustomer);
            return RedirectToAction(nameof(Index));
        }
        #endregion
        #region Delete
        // GET: CustomerController/Delete/5
        public ActionResult Delete(int id) {
            var dbCustomer = _customerRepo.GetById(id);
            if (dbCustomer == null) {
                return NotFound();
            }
            var deleteEmployee = new CustomerDeleteDto {
                Id = dbCustomer.Id,
                Code = dbCustomer.Code,
                Description = dbCustomer.Description
            };
            return View(model: deleteEmployee);
        }

        // POST: CustomerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection) {
            try {
                _customerRepo.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch {
                return View();
            }
        }
        #endregion
    }
}

using Microsoft.AspNetCore.Mvc;
using PetShop.EF.Repositories;
using PetShop.Model;
using PetShop.Model.Enums;
using PetShop.Web.Blazor.Shared.Employee;
using PetShop.Web.Blazor.Shared.PetFood;
using PetShop.Web.Blazor.Shared.Transaction;
using System.Security.Cryptography;

namespace PetShop.Web.Blazor.Server.Controllers {
    [Route("[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase {
        private readonly IEntityRepo<Employee> _employeeRepo;
		private readonly IEntityRepo<Transaction> _transactionRepo;

		public EmployeeController(IEntityRepo<Employee> employeeRepo, IEntityRepo<Transaction> transactionRepo) {
            _employeeRepo = employeeRepo;
			_transactionRepo = transactionRepo;
		}

		[HttpGet]
        public async Task<IEnumerable<EmployeeListDto>> Get() {
            var result = _employeeRepo.GetAll();
            return result.Select(employee => new EmployeeListDto {
                Id = employee.Id,
                Name = employee.Name,
                Surname = employee.Surname,
                EmployeeType = employee.EmployeeType,
                SalaryPerMonth = employee.SalaryPerMonth
            });
        }

        [HttpGet("{id}")]
        public async Task<EmployeeEditDto> GetById(int id) {
            var result = _employeeRepo.GetById(id);
            return new EmployeeEditDto {
                Id = id,
                Name = result.Name,
                Surname = result.Surname,
                EmployeeType = result.EmployeeType,
                SalaryPerMonth = result.SalaryPerMonth
            };
        }

		[HttpGet("details/{id}")]
		public async Task<EmployeeDetailsDto> GetByIdDetails(int id) {
			var result = _employeeRepo.GetById(id);
			var transactions = _transactionRepo.GetAll();

			return new EmployeeDetailsDto {
				Id = id,
				Name = result.Name,
				Surname = result.Surname,
				EmployeeType = result.EmployeeType,
				SalaryPerMonth = result.SalaryPerMonth,
				Transactions = transactions.Select(transaction => new TransactionDetailsDto {
					Id = transaction.Id,
					Date = transaction.Date,
					PetPrice = transaction.PetPrice,
					PetFoodQty = transaction.PetFoodQty,
					PetFoodPrice = transaction.PetFoodPrice,
					TotalPrice = transaction.TotalPrice,
					EmployeeId = transaction.EmployeeId,
					CustomerId = transaction.CustomerId,
					PetId = transaction.PetId,
					PetFoodId = transaction.PetFoodId,
                    CustomerFullName = $"{transaction.Customer.Name} {transaction.Customer.Surname}",
                    EmployeeFullName = $"{transaction.Employee.Name} {transaction.Employee.Surname}",
                    PetFoodAnimalType = transaction.PetFood.AnimalType,
                    PetBreed = transaction.Pet.Breed
                }).ToList().FindAll(transaction => transaction.EmployeeId == id)

			};
		}

		[HttpPost]
        public async Task Post(EmployeeEditDto employee) {
            var newEmployee = new Employee(employee.Name, employee.Surname, employee.EmployeeType, employee.SalaryPerMonth);
            _employeeRepo.Add(newEmployee);
        }

        [HttpPut]
        public async Task Put(EmployeeEditDto employee) {
            var itemToUpdate = _employeeRepo.GetById(employee.Id);
            itemToUpdate.Name = employee.Name;
            itemToUpdate.Surname = employee.Surname;
            itemToUpdate.EmployeeType = employee.EmployeeType;
            itemToUpdate.SalaryPerMonth = employee.SalaryPerMonth;
            _employeeRepo.Update(employee.Id, itemToUpdate);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id) {
            _employeeRepo.Delete(id);
        }
    }
}
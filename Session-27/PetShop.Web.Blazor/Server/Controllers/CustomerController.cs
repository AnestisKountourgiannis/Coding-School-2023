using Microsoft.AspNetCore.Mvc;
using PetShop.EF.Repositories;
using PetShop.Model;
using PetShop.Web.Blazor.Shared.Customer;
using PetShop.Web.Blazor.Shared.Employee;
using PetShop.Web.Blazor.Shared.Transaction;

namespace PetShop.Web.Blazor.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IEntityRepo<Customer> _customerRepo;
		private readonly IEntityRepo<Transaction> _transactionRepo;

		public CustomerController(IEntityRepo<Customer> customerRepo, IEntityRepo<Transaction> transactionRepo) {
            _customerRepo = customerRepo;
			_transactionRepo = transactionRepo;
		}

		[HttpGet]
        public async Task<IEnumerable<CustomerListDto>> Get()
        {
            var result = _customerRepo.GetAll();
            return result.Select(customer => new CustomerListDto
            {
                Id = customer.Id,
                Name= customer.Name,
                Surname = customer.Surname,
                Phone = customer.Phone,
                Tin = customer.Tin
            });
        }
        [HttpGet("{id}")]
        public async Task<CustomerEditDto> GetById(int id)
        {
            var result = _customerRepo.GetById(id);
            return new CustomerEditDto
            {
                Id = id,
                Name = result.Name,
                Surname = result.Surname,
                Phone = result.Phone,
                Tin = result.Tin
            };
        }

		[HttpGet("details/{id}")]
		public async Task<CustomerDetailsDto> GetByIdDetails(int id) {
			var result = _customerRepo.GetById(id);
			var transactions = _transactionRepo.GetAll();

			return new CustomerDetailsDto {
				Id = id,
				Name = result.Name,
				Surname = result.Surname,
				Phone = result.Phone,
				Tin = result.Tin,
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
                }).ToList().FindAll(transaction => transaction.CustomerId == id)

			};
		}

		[HttpPost]
        public async Task Post(CustomerEditDto customer)
        {
            var newCustomer = new Customer(customer.Name, customer.Surname, customer.Phone, customer.Tin);            
            _customerRepo.Add(newCustomer);
        }

        [HttpPut]
        public async Task Put(CustomerEditDto customer)
        {
            var itemToUpdate = _customerRepo.GetById(customer.Id);
            itemToUpdate.Name = customer.Name;
            itemToUpdate.Surname = customer.Surname;
            itemToUpdate.Phone = customer.Phone;
            itemToUpdate.Tin = customer.Tin;
            _customerRepo.Update(customer.Id, itemToUpdate);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            _customerRepo.Delete(id);
        }

    }
}

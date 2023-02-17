using Microsoft.AspNetCore.Mvc;
using PetShop.EF.Repositories;
using PetShop.Model;
using PetShop.Web.Blazor.Shared.Transaction;

namespace PetShop.Web.Blazor.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    { 
        private readonly IEntityRepo<Transaction> _transactionRepo;
        private readonly IEntityRepo<Customer> _customerRepo;
        private readonly IEntityRepo<Pet> _petRepo;
        private readonly IEntityRepo<PetFood> _petFoodRepo;
        public TransactionController(IEntityRepo<Transaction> transactionRepo, IEntityRepo<Customer> customerRepo, IEntityRepo<Pet> petRepo, IEntityRepo<PetFood> petFoodRepo)
        {
            _transactionRepo = transactionRepo;
            _customerRepo = customerRepo;
            _petRepo = petRepo;
            _petFoodRepo = petFoodRepo;
        }
        [HttpGet]
        public async Task<IEnumerable<TransactionListDto>> Get()
        {
            var result = _transactionRepo.GetAll();
            return result.Select(transaction => new TransactionListDto
            {
                Id = transaction.Id,
                Date = transaction.Date,
                PetPrice = transaction.PetPrice,
                PetFoodQty = transaction.PetFoodQty,
                PetFoodPrice = transaction.PetFoodPrice,
                TotalPrice = transaction.TotalPrice,
                CustomerId = transaction.Customer.Id,
                PetId = transaction.PetId,
                PetFoodId = transaction.PetFoodId,
                EmployeeId = transaction.EmployeeId,
                CustomerFullName = $"{transaction.Customer.Name} {transaction.Customer.Surname}",
                EmployeeFullName = $"{transaction.Employee.Name} {transaction.Employee.Surname}",
                PetFoodAnimalType = transaction.PetFood.AnimalType,
                PetBreed = transaction.Pet.Breed,

            });
        }
        [HttpGet("{id}")]
        public async Task<TransactionEditDto> GetById(int id)
        {
            var result = _transactionRepo.GetById(id);
            return new TransactionEditDto
            {
                Id = id,
                Date = result.Date,
                PetPrice = result.PetPrice,
                PetFoodQty = result.PetFoodQty,
                PetFoodPrice = result.PetFoodPrice,
                TotalPrice = result.TotalPrice,
                CustomerId = result.Customer.Id,
                EmployeeId = result.EmployeeId,
                PetFoodId= result.PetFoodId,
                PetId = result.PetId
            };
        }

        [HttpPost]
        public async Task Post(TransactionEditDto transaction)
        {
            var newTransaction = new Transaction(transaction.PetPrice, transaction.PetFoodQty, transaction.PetFoodPrice, transaction.TotalPrice);
            newTransaction.PetId= transaction.PetId;
            newTransaction.PetFoodId= transaction.PetFoodId;
            newTransaction.EmployeeId = transaction.EmployeeId;
            newTransaction.CustomerId = transaction.CustomerId;
            _transactionRepo.Add(newTransaction);
        }
        [HttpPut]
        public async Task Put(TransactionEditDto transaction)
        {
            var itemToUpdate = _transactionRepo.GetById(transaction.Id);
            itemToUpdate.PetPrice = transaction.PetPrice;
            itemToUpdate.PetFoodQty = transaction.PetFoodQty;
            itemToUpdate.PetFoodPrice = transaction.PetFoodPrice;
            itemToUpdate.TotalPrice = transaction.TotalPrice;
            itemToUpdate.CustomerId = transaction.CustomerId;
            itemToUpdate.EmployeeId = transaction.EmployeeId;
            itemToUpdate.PetId = transaction.PetId;
            itemToUpdate.PetFoodId = transaction.PetFoodId;
            _transactionRepo.Update(transaction.Id, itemToUpdate);
        }
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            _transactionRepo.Delete(id);
        }
    }
}

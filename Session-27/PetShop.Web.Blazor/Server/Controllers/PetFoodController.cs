using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetShop.EF.Repositories;
using PetShop.Model;
using PetShop.Web.Blazor.Shared.PetFood;
using PetShop.Web.Blazor.Shared.Transaction;
using System.Linq;

namespace PetShop.Web.Blazor.Server.Controllers {
    [Route("[controller]")]
    [ApiController]
    public class PetFoodController : ControllerBase {
        private readonly IEntityRepo<PetFood> _petFoodRepo;
        private readonly IEntityRepo<Transaction> _transactionRepo;

        public PetFoodController(IEntityRepo<PetFood> petFoodRepo, IEntityRepo<Transaction> transactionRepo)
        {
            _petFoodRepo = petFoodRepo;
            _transactionRepo = transactionRepo;
        }

        [HttpGet]
        public async Task<IEnumerable<PetFoodListDto>> Get()
        {
            var result = _petFoodRepo.GetAll();
            return result.Select(petFood => new PetFoodListDto
            {
                Id = petFood.Id,
                AnimalType = petFood.AnimalType,
                Price = petFood.Price,
                Cost = petFood.Cost
            });
        }

        [HttpGet("{id}")]
        public async Task<PetFoodEditDto> GetById(int id) {
            var result = _petFoodRepo.GetById(id);
            return new PetFoodEditDto {
                Id = id,
                AnimalType = result.AnimalType,
                Price = result.Price,
                Cost = result.Cost,
            };
        }

        [HttpGet("details/{id}")]
        public async Task<PetFoodDetailsDto> GetByIdDetails(int id) {
            var petFood = _petFoodRepo.GetById(id);
            var transactions = _transactionRepo.GetAll();
        
            return new PetFoodDetailsDto {
                Id = id,
                AnimalType = petFood.AnimalType,
                Price = petFood.Price,
                Cost = petFood.Cost,
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
                }).ToList().FindAll(transaction => transaction.PetFoodId == id)
                
            };
        }

        [HttpPost]
        public async Task Post(PetFoodEditDto petFood)
        {
            var newPetFood = new PetFood(petFood.AnimalType, petFood.Price, petFood.Cost);
            _petFoodRepo.Add(newPetFood);
        }

        [HttpPut]
        public async Task Put(PetFoodEditDto petFood)
        {
            var itemToUpdate = _petFoodRepo.GetById(petFood.Id);
            itemToUpdate.AnimalType = petFood.AnimalType;
            itemToUpdate.Price = petFood.Price;
            itemToUpdate.Cost = petFood.Cost;
            _petFoodRepo.Update(petFood.Id, itemToUpdate);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            _petFoodRepo.Delete(id);
        }
    }
}

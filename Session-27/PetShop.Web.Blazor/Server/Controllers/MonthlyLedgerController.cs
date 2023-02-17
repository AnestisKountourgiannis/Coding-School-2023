using Microsoft.AspNetCore.Mvc;
using PetShop.EF.Repositories;
using PetShop.Model;
using PetShop.Web.Blazor.Shared.Pet;
using PetShop.Web.Blazor.Shared.PetFood;
using PetShop.Web.Blazor.Shared.Transaction;

namespace PetShop.Web.Blazor.Server.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class MonthlyLedgerController : ControllerBase
    {
        private readonly IEntityRepo<Transaction> _transactionRepo;
        
        private readonly IEntityRepo<Pet> _petRepo;
        private readonly IEntityRepo<PetFood> _petFoodRepo;
		
		public MonthlyLedgerController(IEntityRepo<Transaction> transactionRepo, IEntityRepo<Pet> petRepo, IEntityRepo<PetFood> petFoodRepo)
        {
            _transactionRepo = transactionRepo;
            _petRepo = petRepo;
            _petFoodRepo = petFoodRepo;
        }
		[HttpGet]
		public async Task<IEnumerable<TransactionListDto>> Get()
        {
            var result = _transactionRepo.GetAll();
            var pett = _petRepo.GetAll();
            var pettFood = _petFoodRepo.GetAll();
            
            return result.Select(transaction => new TransactionListDto
            {
                Id = transaction.Id,
                Date = transaction.Date,
                PetPrice = transaction.PetPrice,
                PetFoodQty = transaction.PetFoodQty,
                PetFoodPrice = transaction.PetFoodPrice,
                TotalPrice = transaction.TotalPrice,
                PetId = transaction.PetId,
                PetFoodId = transaction.PetFoodId,
                PetFoodAnimalType = transaction.PetFood.AnimalType,
                PetBreed = transaction.Pet.Breed,
                PetFoodCost = transaction.PetFood.Cost,
                PetCost = transaction.Pet.Cost,
                EmployeeSalary = transaction.Employee.SalaryPerMonth,
				//Pets = pett.Select(pett => new PetListDto
    //            {
    //                Id = pett.Id,
    //                Breed = pett.Breed,
    //                AnimalType= pett.AnimalType,
    //                Cost= pett.Cost,
    //                Price= pett.Price

    //            }).ToList(),
                PetFoods = pettFood.Select(pettFood => new PetFoodListDto
                {
                    Id = pettFood.Id,
                    AnimalType=pettFood.AnimalType,
                    Cost= pettFood.Cost,
                    Price= pettFood.Price
                }).ToList()
			});
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using PetShop.EF.Repositories;
using PetShop.Model;
using PetShop.Model.Enums;
using PetShop.Web.Blazor.Shared.Pet;
using PetShop.Web.Blazor.Shared.PetReport;
using PetShop.Web.Blazor.Shared.Transaction;

namespace PetShop.Web.Blazor.Server.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class PetReportController : ControllerBase
    {
        private readonly IEntityRepo<Transaction> _transactionRepo;
        private readonly IEntityRepo<Pet> _petRepo;

        public PetReportController(IEntityRepo<Transaction> transactionRepo, IEntityRepo<Pet> petRepo)
        {
            _transactionRepo = transactionRepo;
            _petRepo = petRepo;
        }

        [HttpGet]
        public async Task<IEnumerable<TransactionListDto>> Get()
        {
            var result = _transactionRepo.GetAll();
            var pett = _petRepo.GetAll();
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
                PetType = transaction.Pet.AnimalType

            });
        }
    }
}
using FuelStation.EF.Repositories;
using FuelStation.Model;
using FuelStation.Web.Blazor.Shared.Item;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FuelStation.Web.Blazor.Server.Controllers {
	[Route("[controller]")]
	[ApiController]
	public class ItemController : ControllerBase {
		private readonly IEntityRepo<Item> _itemRepo;

		public ItemController(IEntityRepo<Item> itemRepo) {
			_itemRepo = itemRepo;
		}

		[HttpGet]
		public async Task<IEnumerable<ItemListDto>> Get() {
			var result = _itemRepo.GetAll();
			return result.Select(item => new ItemListDto {
				Id = item.Id,
				Code = item.Code,
				Description = item.Description,
				ItemType = item.ItemType,
				Price = item.Price,
				Cost = item.Cost
			});
		}

		[HttpGet("{id}")]
		public async Task<ItemEditDto> GetById(int id) {
			var result = _itemRepo.GetById(id);
			return new ItemEditDto {
				Id = id,
				Code = result.Code,
				Description = result.Description,
				ItemType = result.ItemType,
				Price = result.Price,
				Cost = result.Cost
			};
		}


		[HttpPost]
		public async Task Post(ItemEditDto item) {
			var newItem = new Item(item.Code, item.Description, item.ItemType, item.Price, item.Cost);
			_itemRepo.Add(newItem);
		}

		[HttpPut]
		public async Task Put(ItemEditDto item) {
			var itemToUpdate = _itemRepo.GetById(item.Id);
			itemToUpdate.Code = item.Code;
			itemToUpdate.Description = item.Description;
			itemToUpdate.ItemType = item.ItemType;
			itemToUpdate.Price = item.Price;
			itemToUpdate.Cost = item.Cost;
			_itemRepo.Update(item.Id, itemToUpdate);
		}

		[HttpDelete("{id}")]
		public async Task Delete(int id) {
			_itemRepo.Delete(id);
		}
	}
}

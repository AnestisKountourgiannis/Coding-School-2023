using FuelStation.EF.Repositories;
using FuelStation.Model;
using FuelStation.Web.Blazor.Shared.Employee;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FuelStation.Web.Blazor.Server.Controllers {
    [Route("[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase {

        private readonly IEntityRepo<Employee> _employeeRepo;

        public EmployeeController(IEntityRepo<Employee> employeeRepo) {
            _employeeRepo = employeeRepo;
        }

        [HttpGet]
        public async Task<IEnumerable<EmployeeListDto>> Get() {
            var result = _employeeRepo.GetAll();
            return result.Select(employee => new EmployeeListDto {
                Id = employee.Id,
                Name = employee.Name,
                Surname = employee.Surname,
                HireDateStart = employee.HireDateStart,
                HireDateEnd = employee.HireDateEnd,
                SallaryPerMonth = employee.SallaryPerMonth,
                EmployeeType = employee.EmployeeType
            });
        }

		[HttpGet("{id}")]
		public async Task<EmployeeEditDto> GetById(int id) {
			var result = _employeeRepo.GetById(id);
			return new EmployeeEditDto {
				Id = id,
				Name = result.Name,
				Surname = result.Surname,
				HireDateStart = result.HireDateStart,
				HireDateEnd = result.HireDateEnd,
				SallaryPerMonth = result.SallaryPerMonth,
				EmployeeType = result.EmployeeType
			};
		}


		[HttpPost]
		public async Task Post(EmployeeEditDto employee) {
			var newEmployee = new Employee(employee.Name, employee.Surname, employee.HireDateStart, employee.HireDateEnd, employee.SallaryPerMonth, employee.EmployeeType);
			_employeeRepo.Add(newEmployee);
		}

		[HttpPut]
		public async Task Put(EmployeeEditDto employee) {
			var itemToUpdate = _employeeRepo.GetById(employee.Id);
			itemToUpdate.Name = employee.Name;
			itemToUpdate.Surname = employee.Surname;
			itemToUpdate.HireDateStart = employee.HireDateStart;
			itemToUpdate.HireDateEnd = employee.HireDateEnd;
			itemToUpdate.SallaryPerMonth = employee.SallaryPerMonth;
			itemToUpdate.EmployeeType = employee.EmployeeType;
			_employeeRepo.Update(employee.Id, itemToUpdate);
		}

		[HttpDelete("{id}")]
		public async Task Delete(int id) {
			_employeeRepo.Delete(id);
		}
	}
}

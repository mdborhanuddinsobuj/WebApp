using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApp.Core;
using WebApp.Extensions;
using WebApp.Helpers.Base;
using WebApp.Service.Services.Configurations;
using WebApp.Sql.Entities.Configurations;

namespace WebApp.Controllers.Configurations
{
    [ApiController]
    [Route("api/[controller]")]
    public class CityController : GenericBaseController<City>
    {
        private readonly ICityService _cityService;

        public CityController(ICityService cityService) : base(cityService)
        {
            _cityService = cityService;
        }

        [HttpGet("dropdown")]
        public async Task<IActionResult> GetDropdownAsync(long? stateId = null, string searchText = null)
        {
            var res = await _cityService.GetDropdownAsync(stateId, searchText);

            return new ApiOkActionResult(res);
        }
    }
}

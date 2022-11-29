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
    public class CountryController : GenericBaseController<Country>
    {
        private readonly ICountryService _countryService;

        public CountryController(ICountryService countryService) : base(countryService)
        {
            _countryService = countryService;
        }

        [HttpGet("dropdown")]
        public async Task<IActionResult> GetDropdownAsync(string searchText = null)
        {
            var res = await _countryService.GetDropdownAsync(searchText);

            return new ApiOkActionResult(res);
        }
    }
}

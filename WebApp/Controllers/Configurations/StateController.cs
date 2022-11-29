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
    public class StateController : GenericBaseController<State>
    {
        private readonly IStateService _stateService;

        public StateController(IStateService stateService) : base(stateService)
        {
            _stateService = stateService;
        }

        [HttpGet("dropdown")]
        public async Task<IActionResult> GetDropdownAsync(long? countryId = null, string searchText = null)
        {
            var res = await _stateService.GetDropdownAsync(countryId, searchText);

            return new ApiOkActionResult(res);
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApp.Extensions;
using WebApp.Helpers.Base;
using WebApp.Service.Services.Configurations;
using WebApp.Sql.Entities.Configurations;

namespace WebApp.Controllers.Configurations
{
    [Route("api/[controller]")]
    [ApiController]
    public class DesignationController : GenericBaseController<Designation>
    {
        private readonly IDesignationService _designationService;

        public DesignationController(IDesignationService designationService) : base(designationService)
        {
            _designationService = designationService;
        }

        [HttpGet("dropdown")]
        public async Task<IActionResult> GetDropdownAsync(string searchText = null)
        {
            var res = await _designationService.GetDropdownAsync(searchText);

            return new ApiOkActionResult(res);
        }
    }
}

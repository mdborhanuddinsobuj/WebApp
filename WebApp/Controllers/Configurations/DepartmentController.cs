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
    public class DepartmentController : GenericBaseController<Department>
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService) : base(departmentService)
        {
            _departmentService = departmentService;
        }
        [HttpGet("dropdown")]
        public async Task<IActionResult> GetDropdownAsync(long? designationId = null, string searchText = null)
        {
            var res = await _departmentService.GetDropdownAsync(designationId, searchText);

            return new ApiOkActionResult(res);
        }
    }
}

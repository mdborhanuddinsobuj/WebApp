using System.Threading.Tasks;
using WebApp.Core;
using WebApp.Core.Collections;
using WebApp.Services;
using WebApp.Sql.Entities.Configurations;

namespace WebApp.Service.Services.Configurations
{
    public interface ICityService : IBaseService<City>
    {
        Task<Dropdown<CityModel>> GetDropdownAsync(long? stateId = null, string searchText = null, int size = CommonVariables.DropdownSize);
    }
}
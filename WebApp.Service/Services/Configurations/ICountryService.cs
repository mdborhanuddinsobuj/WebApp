using System.Threading.Tasks;
using WebApp.Core;
using WebApp.Core.Collections;
using WebApp.Services;
using WebApp.Sql.Entities.Configurations;

namespace WebApp.Service.Services.Configurations
{
    public interface ICountryService : IBaseService<Country>
    {
        Task<Dropdown<CountryModel>> GetDropdownAsync(string searchText = null, int size = CommonVariables.DropdownSize);
    }
}

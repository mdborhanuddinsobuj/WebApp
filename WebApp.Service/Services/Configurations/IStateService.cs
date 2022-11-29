using System.Threading.Tasks;
using WebApp.Core;
using WebApp.Core.Collections;
using WebApp.Services;
using WebApp.Sql.Entities.Configurations;

namespace WebApp.Service.Services.Configurations
{
    public interface IStateService : IBaseService<State>
    {
        Task<Dropdown<StateModel>> GetDropdownAsync(long? countryId = null,
            string searchText = null,
            int size = CommonVariables.DropdownSize);
    }
}



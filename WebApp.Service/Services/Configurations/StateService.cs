using AutoMapper;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Core;
using WebApp.Core.Collections;
using WebApp.Services;
using WebApp.Sql.Entities.Configurations;

namespace WebApp.Service.Services.Configurations
{
    public class StateService : BaseService<State>, IStateService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StateService(IUnitOfWork unitOfWork,
                IMapper mapper) : base(unitOfWork)
        {
            this._unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Dropdown<StateModel>> GetDropdownAsync(long? countryId = null,
            string searchText = null,
            int size = CommonVariables.DropdownSize)
        {
            var data = await _unitOfWork.Repository<State>().GetDropdownAsync(
                p => ((string.IsNullOrEmpty(searchText) || p.Name.Contains(searchText))
                        && countryId == null || p.CountryId == countryId),
                o => o.OrderBy(ob => ob.Id),
                se => new StateModel { Id = se.Id, Name = se.Name, CountryId = se.CountryId },
                size);

            return data;
        }
    }
}

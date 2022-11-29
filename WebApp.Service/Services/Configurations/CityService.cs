using AutoMapper;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Core;
using WebApp.Core.Collections;
using WebApp.Services;
using WebApp.Sql.Entities.Configurations;

namespace WebApp.Service.Services.Configurations
{
    public class CityService : BaseService<City>, ICityService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CityService(IUnitOfWork unitOfWork,
                IMapper mapper) : base(unitOfWork)
        {
            this._unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Dropdown<CityModel>> GetDropdownAsync(long? stateId = null,
            string searchText = null,
            int size = CommonVariables.DropdownSize)
        {
            var data = await _unitOfWork.Repository<City>().GetDropdownAsync(
                s => (string.IsNullOrEmpty(searchText) || s.Name.Contains(searchText)),
                o => o.OrderBy(ob => ob.Id),
                se => new CityModel { Id = se.Id, Name = se.Name, StateId = se.StateId },
                size);

            return data;
        }
    }
}

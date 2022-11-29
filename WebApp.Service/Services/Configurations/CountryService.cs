using AutoMapper;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Core;
using WebApp.Core.Collections;
using WebApp.Services;
using WebApp.Sql.Entities.Configurations;

namespace WebApp.Service.Services.Configurations
{
    public class CountryService : BaseService<Country>, ICountryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CountryService(IUnitOfWork unitOfWork,
                IMapper mapper) : base(unitOfWork)
        {
            this._unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Dropdown<CountryModel>> GetDropdownAsync(string searchText = null,
            int size = CommonVariables.DropdownSize)
        {
            var data = await _unitOfWork.Repository<Country>().GetDropdownAsync(
                p => (string.IsNullOrEmpty(searchText) || p.Name.Contains(searchText)),
                o => o.OrderBy(ob => ob.Id),
                se => new CountryModel { Id = se.Id, Name = se.Name, Code = se.Code, Currency = se.Currency, Flag = se.Flag },
                size);

            return data;
        }
    }
}

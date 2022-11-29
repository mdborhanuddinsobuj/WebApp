using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Core;
using WebApp.Core.Collections;
using WebApp.Service.Models.Configurations;
using WebApp.Services;
using WebApp.Sql.Entities.Configurations;

namespace WebApp.Service.Services.Configurations
{
    public class DepartmentService : BaseService<Department>, IDepartmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DepartmentService(IUnitOfWork unitOfWork,
              IMapper mapper) : base(unitOfWork)
        {
            this._unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Dropdown<DepartmentModel>> GetDropdownAsync(long? designationId = null,
         string searchText = null,
         int size = CommonVariables.DropdownSize)
        {
            var data = await _unitOfWork.Repository<Department>().GetDropdownAsync(
                p => ((string.IsNullOrEmpty(searchText) || p.Name.Contains(searchText))
                        && designationId == null || p.DesignationId == designationId),
                o => o.OrderBy(ob => ob.Id),
                se => new DepartmentModel { Id = se.Id, Name = se.Name, DesignationId = se.DesignationId },
                size);

            return data;
        }
    }
}

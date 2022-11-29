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
    public interface IDepartmentService : IBaseService<Department>
    {
        Task<Dropdown<DepartmentModel>> GetDropdownAsync(long? designationId = null,
          string searchText = null,
          int size = CommonVariables.DropdownSize);
    }
}

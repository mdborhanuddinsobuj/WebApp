using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Core;
using WebApp.Sql.Entities.Configurations;
using static WebApp.Sql.Entities.Identities.IdentityModel;

namespace WebApp.Sql.Entities.Enrols
{
    public class Employees : BaseEntity
    {
        public long? UserId { get; set; }   
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public Gender GenderId { get; set; }
        public string Address { get; set; }
        public int BasicSalary { get; set; }

        public bool Status { get; set; }
        public DateTime JoiningDate { get; set; }
        public DateTime ResignDate { get; set; } 
        public long? DepartmentId { get; set; }  
        public long? DesignationId { get; set; }

        public string AcountName { get; set; }
        public string AcountNumber { get; set; }
        public string SwiftCode { get; set; }
        public string Brance { get; set; }
        public string Avatar { get; set; }
        public Department Department { get; set; }
        public Designation Designation { get; set; }
        public User  User { get; set; }
    }
}

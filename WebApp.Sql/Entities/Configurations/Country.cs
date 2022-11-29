using System.Collections.Generic;
using WebApp.Sql.Entities.Enrols;

namespace WebApp.Sql.Entities.Configurations
{
    public class Country : BaseEntity
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Currency { get; set; }
        public string Flag { get; set; }

        public IList<State> States { get; set; }
        public IList<UserInformation> UserInformations { get; set; }
        public IList<UserInformation> UserInformationNationalities { get; set; }
    }
}

using System.Collections.Generic;
using WebApp.Sql.Entities.Enrols;

namespace WebApp.Sql.Entities.Configurations
{
    public class City : BaseEntity
    {
        public long StateId { get; set; }
        public string Name { get; set; }

        public State State { get; set; }
        public IList<UserInformation> UserInformations { get; set; }
    }
}

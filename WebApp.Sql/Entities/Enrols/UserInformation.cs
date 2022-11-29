using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using WebApp.Core;
using WebApp.Sql.Entities.Configurations;
using static WebApp.Sql.Entities.Identities.IdentityModel;

namespace WebApp.Sql.Entities.Enrols
{
    public class UserInformation : BaseEntity
    {
        public long? UserId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime? BirthDate { get; set; }
        public long? NationalityId { get; set; }
        public Religion ReligionId { get; set; }
        public string ReligionText { get; set; }
        public Gender GenderId { get; set; }
        public MaritalStatus MaritalStatusId { get; set; }

        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public string NationalIdentificationNumber { get; set; }
        public string DrivingLicenseNumber { get; set; }
        public string PassportNumber { get; set; }

        public string FatherFirstname { get; set; }
        public string FatherLasttname { get; set; }
        public string FatherContactNumber { get; set; }
        public string MotherFirstname { get; set; }
        public string FatherLastname { get; set; }
        public string MotherContactNumber { get; set; }

        public long? CountryId { get; set; }
        public long? StateId { get; set; }
        public long? CityId { get; set; }
        public string ZipCode { get; set; }
        public string Address1 { get; set; }
        public string Avatar { get; set; }

        public User User { get; set; }
        public Country Country { get; set; }
        public Country Nationality { get; set; }
        public State State { get; set; }
        public City City { get; set; }
        public IList<UserBasicInformation> UserBasicInformations { get; set; }
        public IList<UserHobbyInformation> UserHobbyInformations { get; set; }
        public IList<UserAddressInformation> UserAddressInformations { get; set; }
        public IList<UserEducationalInformation> UserEducationalInformations { get; set; }
        public IList<UserProfessionalInformation> UserProfessionalInformations { get; set; }
        public IList<UserCertification> UserCertifications { get; set; }
        public IList<UserSkill> UserSkills { get; set; }
    }

    //public enum Gender
    //{
    //    Male,
    //    Femaile,
    //    Other
    //}

    //public enum MaritalStatus
    //{
    //    Married,
    //    Unmarried,
    //    Widow
    //}

    public enum Religion
    {
        Islam,
        Christian,
        Hindu,
        Shikh,
        Ihudi,
        Other
    }
}

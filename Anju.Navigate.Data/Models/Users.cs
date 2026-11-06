using System;
using System.Collections.Generic;

namespace Anju.Navigate.Data
{
    public partial class Users : BaseResponseModel
    {
        public Users()
        {
            UserCredentials = new HashSet<UserCredentials>();
        }

        public int UserId { get; set; }
        public string Salutation { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public int? RoleId { get; set; }
        public string OrganizationName { get; set; }
        public string Department { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public int? CityId { get; set; }
        public int? StateId { get; set; }
        public int? CountryId { get; set; }
        public string CountryName { get; set; }
        public string StateName { get; set; }
        public string CityName { get; set; }
        public string  CredentialNames { get; set; }
        public string Zip { get; set; }
        public string TelephoneNumber { get; set; }
        public string MobileNumber { get; set; }
        public DateTime? Dob { get; set; }
        public string Fax { get; set; }
        public string PrimaryEmailId { get; set; }
        public string SecondaryEmailId { get; set; }
        public string Gender { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }
        public DateTime? PasswordExpiryDate { get; set; }
        public string UserType { get; set; }
        public string UserStatus { get; set; }
        public string Suffix { get; set; }
        public bool? IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public bool? IsAccountLocked { get; set; }
        public int? FailedAttempts { get; set; }
        public string EndUserType { get; set; }
        public string ANJU_AddedBy { get; set; }
        public DateTime? ANJU_AddDate { get; set; }
        public string ANJU_ChangedBy { get; set; }
        public DateTime? ANJU_ChangeDate { get; set; }

        public virtual UserRoles Role { get; set; }
        public virtual ICollection<UserCredentials> UserCredentials { get; set; }
    }
}

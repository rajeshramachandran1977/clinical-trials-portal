using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Anju.Navigate.DataAccess
{
    public partial class Users:EntityBase
    {
        //public Users()
        //{
        //    UserCredentials = new HashSet<UserCredentials>();
        //}
        [Key]
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
        public string Zip { get; set; }
        public string TelephoneNumber { get; set; }
        public string MobileNumber { get; set; }
        public DateTime? Dob { get; set; }
        public string Fax { get; set; }
        public string PrimaryEmailId { get; set; }
        public string SecondaryEmailId { get; set; }
        public string Gender { get; set; }
        public string UserName { get; set; }
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

        public virtual UserRoles Role { get; set; }
        //public virtual ICollection<UserCredentials> UserCredentials { get; set; }
    }

    public partial class Users_H:HistoryEntityBase
    {
        //public Users_H()
        //{
        //    UserCredentials = new HashSet<UserCredentials_H>();
        //}

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
        public string Zip { get; set; }
        public string TelephoneNumber { get; set; }
        public string MobileNumber { get; set; }
        public DateTime? Dob { get; set; }
        public string Fax { get; set; }
        public string PrimaryEmailId { get; set; }
        public string SecondaryEmailId { get; set; }
        public string Gender { get; set; }
        public string UserName { get; set; }
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
      

        public virtual UserRoles Role { get; set; }
        //public virtual ICollection<UserCredentials_H> UserCredentials { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;

namespace BookManagment.Models
{
    [Index(nameof(Email), IsUnique = true)]
    public class Member
    {
        [Key]
        public string Id { get; set; }
        public string FullName { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        public string? Phone { get; set; }
        [DataType(DataType.EmailAddress)]
      
        public string Email { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Pincode { get; set; }
        public string FullAddress { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string AccountStatus { get; set; }

        public Member(string fullName, string email, string password, string? phone, string country,string city,string pincode,string fulladdress,string status)
        {
            Id = Guid.NewGuid().ToString();
            FullName = fullName;
            Email = email;
            Password = password;
            Phone = phone;
            Country = country;
            City = city;
            Pincode = pincode;
            FullAddress = fulladdress;
            AccountStatus = status;
          
        }
    }
}

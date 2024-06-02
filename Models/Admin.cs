using System.ComponentModel.DataAnnotations;

namespace BookManagment.Models
{
    public class Admin
    {
        [Key]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        public string FullName { get; set; } = string.Empty;


        public Admin(string userName,string fullName,string password)
        {
            UserName = userName;
            FullName = fullName;
            Password = password;
               
        }
    }
}

using System.ComponentModel.DataAnnotations;

namespace BookManagment.Models
{
    public class Genre
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }

        public Genre(string name)
        {
            Id = Guid.NewGuid().ToString();
            Name = name;
        }
    }
}

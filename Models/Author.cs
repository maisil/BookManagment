using System.ComponentModel.DataAnnotations;

namespace BookManagment.Models
{
    public class Author
    {
        [Key]
        public string Id { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }

        public Author(string name)
        {
            Id = Guid.NewGuid().ToString();
            Name = name;
        }
        public Author()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}

using System.ComponentModel.DataAnnotations;

namespace BookManagment.Models
{
    public class Publisher
    {
        [Key]
        public string Id { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }

        public Publisher(string name)
        {
            Id = Guid.NewGuid().ToString();
            Name = name;
        }
    }
}

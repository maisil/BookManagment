﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BookManagment.Models
{
    [Index(nameof(Name), IsUnique = true)]
    public class Genre
    {
        [Key]
        public string Id { get; set; }
      
        public string Name { get; set; }

        public ICollection<BookGenre> Books { get; set; } = [];
        public Genre(string name)
        {
            Id = Guid.NewGuid().ToString();
            Name = name;
        }

        public Genre()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}

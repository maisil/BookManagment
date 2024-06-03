using System.ComponentModel.DataAnnotations;

namespace BookManagment.Models
{
    public class Book
    {
        [Key]
        public string Id { get; set; }
        public string Title { get; set; }
        public string GenreId { get; set; }
        public string Isbn { get; set; }
        [DataType(DataType.Date)]
        public DateTime PublishDate { get; set; }
        public string Language { get; set; }
        public string Edition { get; set; }
        public double BookCost { get; set; }
        public int NoOfPages { get; set; }
        public string? Description { get; set; }
        public int ActualStock { get; set; }
        public int CurrentStock { get; set; }
        public string ImgLink { get; set; }
        public string AuthorId { get; set; }
        public string PublisherId { get; set; } = string.Empty;
        public  Author Author { get; set; }
        public  Publisher Publisher { get; set; }
        public  Genre Genre { get; set; }
        public ICollection<BookGenre> Genres { get; set; } = [];
        public ICollection<BookIssue> Members { get; set; } = [];

        public Book(string title, string description, string authorId,string publisherId, string isbn, string genreId, DateTime publishDate,string language,string edition,string imgLink,int actualStock,int noOfPages)
        {
            Id = Guid.NewGuid().ToString();
            Title = title;
            Description = description;
            AuthorId = authorId;
            Isbn = isbn;
            GenreId = genreId;
            PublishDate = publishDate;
            Language = language;
            Edition = edition;
            ActualStock = actualStock;
            CurrentStock = actualStock;
            ImgLink = imgLink;
            NoOfPages = noOfPages;
            PublisherId = publisherId;


        }
    }
}

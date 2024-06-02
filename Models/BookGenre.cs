namespace BookManagment.Models
{
    public class BookGenre
    {
        public string BookId {  get; set; }
        public string GenreId {  get; set; }

        public Book Book { get; set; }
        public Genre Genre { get; set; }

        public BookGenre(string bookId,string genreId)
        {
            BookId = bookId;
            GenreId = genreId;
        }
    }
}

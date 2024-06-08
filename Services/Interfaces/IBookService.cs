using BookManagment.Models;

namespace BookManagment.Services.Interfaces
{
    public interface IBookService
    {
        public void Add(Book book);
        public void Update(Book book);
        public void Delete(string Id);
        public IEnumerable<Book> GetAll();
        public Book GetById(string id);

        public bool Exist(string id);
    }
}

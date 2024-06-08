using BookManagment.Data;
using BookManagment.Models;
using BookManagment.Services.Interfaces;
using Humanizer.Localisation;
using Microsoft.EntityFrameworkCore;

namespace BookManagment.Services
{
    public class BookService:IBookService
    {
        private readonly EBMDbContext _eBMDbContext;

        public BookService(EBMDbContext eBMDbContext)
        {
            _eBMDbContext = eBMDbContext;
        }
        public void Add(Book book)
        {
            if (book != null)
            {
                _eBMDbContext.Add(book);
                _eBMDbContext.SaveChanges();
            }
        }
        public void Update(Book book)
        {
            if (book != null)
            {
                _eBMDbContext.books.Entry(book).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _eBMDbContext.SaveChanges();
            }
        }
        public void Delete(string Id)
        {
            var book = _eBMDbContext.books.FirstOrDefault(b => b.Id == Id);
            if (book != null)
            {
                _eBMDbContext.books.Remove(book);
                _eBMDbContext.SaveChanges();
            }
        }
        public IEnumerable<Book> GetAll()
        {
            return _eBMDbContext.books.Include(b => b.Author).Include(b => b.Genre).Include(b => b.Publisher).ToList();
        }
        public Book GetById(string id)
        {
            return _eBMDbContext.books.Include(b => b.Author).Include(b => b.Genre).Include(b => b.Publisher).FirstOrDefault(b => b.Id == id);
        }

        public bool Exist(string id)
        {
            var book = GetById(id);
            return book!=null;
        }
    }
}

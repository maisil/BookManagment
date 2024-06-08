using BookManagment.Data;
using BookManagment.Models;
using BookManagment.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookManagment.Services
{
    public class AuthorService:IAuthorService
    {
        private readonly EBMDbContext _eBMDbContext;

        public AuthorService(EBMDbContext eBMDbContext)
        {
            _eBMDbContext = eBMDbContext;
        }
        public void Add(Author author)
        {
            if (author != null)
            {
                _eBMDbContext.Add(author);
                _eBMDbContext.SaveChanges();
            }
        }
        public void Update(Author author)
        {
            if (author != null)
            {
                _eBMDbContext.authors.Entry(author).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _eBMDbContext.SaveChanges();
            }
        }
        public void Delete(string Id)
        {
            var author = _eBMDbContext.books.FirstOrDefault(a => a.Id == Id);
            if (author != null)
            {
                _eBMDbContext.books.Remove(author);
                _eBMDbContext.SaveChanges();
            }
        }
        public IEnumerable<Author> GetAll()
        {
            return _eBMDbContext.authors.ToList();
        }
        public Author GetById(string id)
        {
            return _eBMDbContext.authors.FirstOrDefault(a =>a.Id == id);
        }

        public bool Exist(string id)
        {
            var author = GetById(id);
            return author != null;
        }
    }
}

using BookManagment.Data;
using BookManagment.Models;

namespace BookManagment.Services.Interfaces
{
    public interface IAuthorService
    {
       
        public void Add(Author author);
        public void Update(Author author);
        public void Delete(string Id);
        public IEnumerable<Author> GetAll();
        public Author GetById(string id);

        public bool Exist(string id);
    }
}

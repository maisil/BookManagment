using BookManagment.Models;

namespace BookManagment.Services.Interfaces
{
    public interface IGenreService
    {
        public void Add(Genre genre);
        public void Update(Genre genre);
        public void Delete(string Id);
        public IEnumerable<Genre> GetAll();
        public Genre GetById(string id);
    }
}

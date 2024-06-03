using BookManagment.Data;
using BookManagment.Models;
using BookManagment.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookManagment.Services
{
    public class GenreService:IGenreService
    {
        private readonly EBMDbContext _eBMDbContext;

        public GenreService(EBMDbContext eBMDbContext)
        {
            _eBMDbContext = eBMDbContext;
        }
        public void Add(Genre genre)
        {
            if(genre != null)
            {
                _eBMDbContext.Add(genre);
                _eBMDbContext.SaveChanges();
            }
        }
        public void Update(Genre genre)
        {
            if (genre != null)
            {
                _eBMDbContext.genres.Entry(genre).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _eBMDbContext.SaveChanges();
            }
        }
        public void Delete(string Id)
        {
            var genre = _eBMDbContext.genres.FirstOrDefault(g => g.Id == Id);
            if (genre != null)
            {
                _eBMDbContext.genres.Remove(genre);
                _eBMDbContext.SaveChanges();
            }
        }
        public IEnumerable<Genre> GetAll()
        {
            return _eBMDbContext.genres.Include(g=>g.Books).ToList();
        }
        public Genre GetById(string Id)
        {
            var genre = _eBMDbContext.genres.FirstOrDefault(g => g.Id == Id);
            return genre;

        }
    }
}

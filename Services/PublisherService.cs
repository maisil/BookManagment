using BookManagment.Data;
using BookManagment.Models;
using BookManagment.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookManagment.Services
{
    public class PublisherService:IPublisherService
    {
        private readonly EBMDbContext _eBMDbContext;

        public PublisherService(EBMDbContext eBMDbContext)
        {
            _eBMDbContext = eBMDbContext;
        }
        public void Add(Publisher publisher)
        {
            if (publisher != null)
            {
                _eBMDbContext.Add(publisher);
                _eBMDbContext.SaveChanges();
            }
        }
        public void Update(Publisher publisher)
        {
            if (publisher != null)
            {
                _eBMDbContext.publishers.Entry(publisher).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _eBMDbContext.SaveChanges();
            }
        }
        public void Delete(string Id)
        {
            var publisher = _eBMDbContext.publishers.FirstOrDefault(p => p.Id == Id);
            if (publisher != null)
            {
                _eBMDbContext.publishers.Remove(publisher);
                _eBMDbContext.SaveChanges();
            }
        }
        public IEnumerable<Publisher> GetAll()
        {
            return _eBMDbContext.publishers.ToList();
        }
        public Publisher GetById(string id)
        {
            return _eBMDbContext.publishers.FirstOrDefault(b => b.Id == id);
        }

        public bool Exist(string id)
        {
            var publisher = GetById(id);
            return publisher != null;
        }
    }
}

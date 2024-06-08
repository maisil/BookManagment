using BookManagment.Models;

namespace BookManagment.Services.Interfaces
{
    public interface IPublisherService
    {
       
        public void Add(Publisher publisher);
        public void Update(Publisher publisher);
        public void Delete(string Id);
        public IEnumerable<Publisher> GetAll();
        public Publisher GetById(string id);

        public bool Exist(string id);
    }
}

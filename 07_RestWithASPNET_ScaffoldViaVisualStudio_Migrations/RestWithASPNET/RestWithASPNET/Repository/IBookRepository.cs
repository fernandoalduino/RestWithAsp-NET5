using RestWithASPNET.Models;

namespace RestWithASPNET.Repository
{
    public interface IBookRepository
    {
        Book Create(Book book);

        Book Update(Book book); 

        List <Book> GetAll();

        Book FindById(long id);

        void Delete(long id);

        bool Exists(long id);

    }
}

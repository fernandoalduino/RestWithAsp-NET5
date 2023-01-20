using RestWithASPNET.Models;

namespace RestWithASPNET.Business
{
    public interface IBookBusiness
    {
        Book Create(Book book);

        Book Update(Book book); 

        List <Book> GetAll();

        Book FindById(long id);

        void Delete(long id);


    }
}

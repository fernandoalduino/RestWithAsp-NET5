using RestWithASPNET.Models;

namespace RestWithASPNET.Services
{
    public interface IPersonService
    {
        Person Create(Person person);

        Person Update(Person person); 

        List <Person> GetAll();

        Person FindById(long id);

        void Delete(long id);


    }
}

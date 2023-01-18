using RestWithASPNET.Models;

namespace RestWithASPNET.Repository
{
    public interface IPersonRepository
    {
        Person Create(Person person);

        Person Update(Person person); 

        List <Person> GetAll();

        Person FindById(long id);

        void Delete(long id);

        bool Exists(long id);

    }
}

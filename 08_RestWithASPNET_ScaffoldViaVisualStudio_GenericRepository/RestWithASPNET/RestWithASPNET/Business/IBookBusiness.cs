using RestWithASPNET.Models;

namespace RestWithASPNET.Business
{
    public interface IPersonBusiness
    {
        Person Create(Person person);

        Person Update(Person person); 

        List <Person> GetAll();

        Person FindById(long id);

        void Delete(long id);


    }
}

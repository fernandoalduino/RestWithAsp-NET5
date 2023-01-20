using RestWithASPNET.Models;
using RestWithASPNET.Models.Base;

namespace RestWithASPNET.Repository.Generic
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Create(T item);

        T Update(T item);

        List<T> GetAll();

        T FindById(long id);

        void Delete(long id);

        bool Exists(long id);
    }
}

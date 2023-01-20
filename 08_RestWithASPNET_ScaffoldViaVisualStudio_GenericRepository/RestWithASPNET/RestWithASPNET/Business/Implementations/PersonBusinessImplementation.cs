using RestWithASPNET.Business;
using RestWithASPNET.Models;
using RestWithASPNET.Models.Context;
using RestWithASPNET.Repository;
using RestWithASPNET.Repository.Generic;
using System;

namespace RestWithASPNET.Business.Implementations
{
    public class PersonBusinessImplementation : IPersonBusiness
    {
        private readonly IRepository<Person> _repository;

        public PersonBusinessImplementation(IRepository<Person> repository) {
            _repository= repository;
        }

        public List<Person> GetAll()
        {
            return _repository.GetAll();
        }

        public Person FindById(long id)
        {
            return _repository.FindById(id);
        }

        public Person Create(Person person)
        {
            return _repository.Create(person);
        }

        public Person Update(Person person)
        {
            return _repository.Update(person);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }
    }
}

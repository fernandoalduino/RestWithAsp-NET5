using RestWithASPNET.Business;
using RestWithASPNET.Models;
using RestWithASPNET.Models.Context;
using RestWithASPNET.Repository;
using RestWithASPNET.Repository.Generic;
using System;

namespace RestWithASPNET.Business.Implementations
{
    public class BookBusinessImplementation : IBookBusiness
    {
        private readonly IRepository<Book> _repository;

        public BookBusinessImplementation(IRepository<Book> repository) {
            _repository= repository;
        }

        public List<Book> GetAll()
        {
            return _repository.GetAll();
        }

        public Book FindById(long id)
        {
            return _repository.FindById(id);
        }

        public Book Create(Book book)
        {
            return _repository.Create(book);
        }

        public Book Update(Book book)
        {
            return _repository.Update(book);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }
    }
}

using RestWithASPNET.Models;
using RestWithASPNET.Models.Context;
using System;

namespace RestWithASPNET.Repository.Implementations
{
    public class BookRepositoryImplementation : IBookRepository
    {
        private MySQLContext _context;

        public BookRepositoryImplementation(MySQLContext context) {
            _context= context;
        }

        public Book Create(Book book)
        {
            book.LaunchDate = DateTime.Now;

            try{
                _context.Add(book);
                _context.SaveChanges();
            }catch(Exception ex) {
                throw ex;
            }
            return book;
        }

        public void Delete(long id)
        {
            var result = _context.Books.SingleOrDefault(p => p.Id.Equals(id));
            if (result != null)
            {
                try
                {
                    _context.Books.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public Book FindById(long id)
        {
            return _context.Books.SingleOrDefault(p => p.Id.Equals(id)) ;
        }

        public List<Book> GetAll()
        {
            return _context.Books.ToList();
        }

        public Book Update(Book book)
        {
            if (!Exists(book.Id))
                return null;

            var result = _context.Books.SingleOrDefault(p => p.Id.Equals(book.Id));

            if (result != null)
            {
                book.LaunchDate = result.LaunchDate;
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(book);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return book;
        }

        public bool Exists(long id)
        {
            return _context.Books.Any(p => p.Id.Equals(id));
        }
    }
}

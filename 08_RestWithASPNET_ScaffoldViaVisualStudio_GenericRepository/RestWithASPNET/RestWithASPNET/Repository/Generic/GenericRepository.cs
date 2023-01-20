using Microsoft.EntityFrameworkCore;
using RestWithASPNET.Models;
using RestWithASPNET.Models.Base;
using RestWithASPNET.Models.Context;
using System;

namespace RestWithASPNET.Repository.Generic
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        private MySQLContext _context;
        private DbSet<T> _dbSet;

        public GenericRepository(MySQLContext context)
        {
            _context = context;
            _dbSet   = context.Set<T>();
        }

        public T Create(T item)
        {
            try
            {
                _dbSet.Add(item);
                _context.SaveChanges();
                return item;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(long id)
        {
            var result = _dbSet.SingleOrDefault(p => p.Id.Equals(id));
            if (result != null)
            {
                try
                {
                    _dbSet.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public T Update(T item)
        {
            if (!Exists(item.Id))
                return null;

            var result = _dbSet.SingleOrDefault(p => p.Id.Equals(item.Id));

            if (result != null)
            {
                try
                {
                    _dbSet.Entry(result).CurrentValues.SetValues(item);
                    _context.SaveChanges();
                    return item;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                return null;
            }
        }

        public bool Exists(long id)
        {
            return _dbSet.Any(p => p.Id.Equals(id));
        }

        public T FindById(long id)
        {
            return _dbSet.SingleOrDefault(p => p.Id.Equals(id));
        }

        public List<T> GetAll()
        {
            return _dbSet.ToList();
        }
    }
}

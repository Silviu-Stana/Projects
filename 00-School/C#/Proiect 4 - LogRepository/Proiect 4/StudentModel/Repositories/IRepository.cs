using System;
using System.Collections.Generic;

namespace LoggingRepository
{
    public interface IRepository<T> where T : class
    {
        T GetById(int id);
        List<T> GetAll();
        void Create(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}

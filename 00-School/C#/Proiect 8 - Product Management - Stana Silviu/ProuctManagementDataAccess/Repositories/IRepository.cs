using System;
using System.Collections.Generic;

namespace ProductManagement.DataAccess
{
    public interface IRepository<T>
    {
        T GetById(int id);
        List<T> GetAll();
        T Create(T value);
        void Delete(int id);
        T Update(T value);
    }
}

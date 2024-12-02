using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateDataAccess.Repository
{
    public interface IRepository<T>
    {
        T GetById(int id);
        List<T> GetAll();
        T Create(T value); //creaza un nou obiect T in baza de date
        void Delete(int id);
        T Update(T value); //se face update (modificare) a obiectului T
    }
}

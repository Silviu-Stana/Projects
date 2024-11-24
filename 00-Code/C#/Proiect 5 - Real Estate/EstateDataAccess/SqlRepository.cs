using EstateDataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EstateDataAccess
{
    public class SQLRepository<T> : IRepository<T> where T : new()
    {
        public static string stringConectare = @"Data Source=SEAL\SEAL;Initial Catalog=RealEstate;Integrated Security=True";

        public SQLRepository()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(stringConectare))
                {
                    connection.Open();
                    Console.WriteLine("Conectare cu succes!");
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Eșec conectare! Mesaj eroare: {ex.Message}");
            }
        }

        public virtual T Create(T value)
        {
            throw new NotImplementedException();
        }

        public virtual void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public virtual List<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public virtual T GetById(int id)
        {
            throw new NotImplementedException();
        }

        public virtual T Update(T value)
        {
            throw new NotImplementedException();
        }
    }
}
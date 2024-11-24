using EstateDataAccess;
using EstateDataAccess.Repository;
using EstateModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace EstateDataAccess.Repository.SqlRepository
{
    public class EstateRepository : SQLRepository<Estate>
    {
        string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

        public Estate Create(Estate value)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Estate> GetAll()
        {
            throw new NotImplementedException();
        }

        public Estate GetById(int id)
        {
            string selectById = $"select * from Estate where EstateId={id}";
            Estate estate = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(selectById, connection))
                    {
                        using (var row = cmd.ExecuteReader())
                        {
                            if (row.Read())
                            {
                                estate = new Estate()
                                {
                                    Id = (int)row["EstateId"],
                                    Name = (string)row["Name"],
                                    Address = (string)row["Address"],
                                    Price = (double)row["Price"],
                                    CreateDate = (DateTime)row["CreateDate"],
                                };
                            }
                            else
                            {
                                Console.WriteLine("Id not found");
                                return null;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR: {ex.Message}");
                return null;
            }

            return estate;
        }

        public Estate Update(Estate value)
        {
            throw new NotImplementedException();
        }
    }
}
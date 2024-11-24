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
    public class OwnerRepository : SQLRepository<Owner>
    {
        string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

        //public override new List<Owner> GetAll()
        //{
        //    string selectById = $"select * from Owners";
        //    Owner owner = null;

        //    try
        //    {
        //        using (SqlConnection connection = new SqlConnection(stringConectare))
        //        {
        //            connection.Open();
        //            using (SqlCommand cmd = new SqlCommand(selectById, connection))
        //            {
        //                using (var row = cmd.ExecuteReader())
        //                {
        //                    if (row.Read())
        //                    {
        //                        owner = new Owner()
        //                        {
        //                            Id = (int)row["OwnerId"],
        //                            Name = (string)row["Name"],
        //                            Email = (string)row["Email"],
        //                            Phone = (string)row["Phone"],
        //                            Cnp = (string)row["Cnp"],
        //                        };
        //                    }
        //                    else
        //                    {
        //                        Console.WriteLine("Id not found");
        //                        return null;
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"An error occurred: {ex.Message}");
        //        return null;
        //    }

        //    return owner;
        //}




        public override Owner GetById(int id)
        {
            string selectById = $"select * from Owner where OwnerId={id}";
            Owner owner = null;

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
                                owner = new Owner()
                                {
                                    Id = (int)row["OwnerId"],
                                    Name = (string)row["Name"],
                                    Email = (string)row["Email"],
                                    Phone = (string)row["Phone"],
                                    Cnp = (string)row["Cnp"],
                                };
                            }
                            else
                            {
                                Console.WriteLine("Owner Id not found");
                                return null;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }

            return owner;
        }
    }
}
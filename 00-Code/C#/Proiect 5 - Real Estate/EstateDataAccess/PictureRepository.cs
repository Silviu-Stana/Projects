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
    public class PictureRepository : SQLRepository<Picture>
    {
        string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;


        public override Picture Create(Picture value)
        {
            throw new NotImplementedException();
        }

        public override void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override List<Picture> GetAll()
        {
            throw new NotImplementedException();
        }

        public override Picture GetById(int id)
        {
            string selectById = $"select * from Picture where PictureId={id}";
            Picture picture = null;

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
                                picture = new Picture()
                                {
                                    Id = (int)row["PictureId"],
                                    Name = (string)row["Name"],
                                    Size = (long)row["Size"],
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
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }

            return picture;
        }

        public override Picture Update(Picture value)
        {
            throw new NotImplementedException();
        }
    }
}

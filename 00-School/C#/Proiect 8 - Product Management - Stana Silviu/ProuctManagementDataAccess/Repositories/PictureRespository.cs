using ProductManagement.BusinessModel;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace ProductManagement.DataAccess.Repositories
{
    public class PictureRepository : IRepository<PictureModel>
    {
        public string ConnectionString = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;

        public PictureModel Create(PictureModel value)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                if (db.State == ConnectionState.Closed) db.Open();
                db.Query<PictureModel>($"DELETE FROM Picture WHERE Id={id}", commandType: CommandType.Text);
            }
        }

        public List<PictureModel> GetAll()
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                if (db.State == ConnectionState.Closed) db.Open();
                return db.Query<PictureModel>("SELECT * FROM Picture", commandType: CommandType.Text).ToList();
            }
        }

        public PictureModel GetById(int id)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                if (db.State == ConnectionState.Closed) db.Open();
                return db.QueryFirstOrDefault<PictureModel>($"SELECT * FROM Picture WHERE Id={id}");
            }
        }

        public PictureModel GetByName(string Username)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                if (db.State == ConnectionState.Closed) db.Open();
                return db.QueryFirstOrDefault<PictureModel>(
                    "SELECT * FROM Picture WHERE Username = @Username",
                    new { Username }
                );
            }
        }


        public PictureModel Update(PictureModel value)
        {
            throw new NotImplementedException();
        }
    }
}

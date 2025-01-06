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
    public class UserRepository : IRepository<UserModel>
    {
        public string ConnectionString = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;

        public UserModel Create(UserModel value)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                if (db.State == ConnectionState.Closed) db.Open();
                db.Query<UserModel>($"DELETE FROM [User] WHERE Id={id}", commandType: CommandType.Text);
            }
        }

        public List<UserModel> GetAll()
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                if (db.State == ConnectionState.Closed) db.Open();
                return db.Query<UserModel>("SELECT * FROM [User]", commandType: CommandType.Text).ToList();
            }
        }

        public UserModel GetById(int id)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                if (db.State == ConnectionState.Closed) db.Open();
                return (UserModel)db.QueryFirstOrDefault($"SELECT * FROM [User] WHERE Id={id}");
            }
        }

        public UserModel GetByName(string Username)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                if (db.State == ConnectionState.Closed) db.Open();
                return db.QueryFirstOrDefault<UserModel>(
                    "SELECT * FROM [User] WHERE Username = @Username",
                    new { Username }
                );
            }
        }

        public UserModel Login(string Username, string Password)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                if (db.State == ConnectionState.Closed) db.Open();
                return db.QueryFirstOrDefault<UserModel>(
                    "SELECT * FROM [User] WHERE Username = @Username AND Password = @Password",
                    new { Username, Password }
                );
            }
        }

        public UserModel Register(string Username, string Password)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                if (db.State == ConnectionState.Closed) db.Open();
                var id = db.ExecuteScalar<int>(
                    "INSERT INTO [User] (Username, Password) VALUES (@Username, @Password); SELECT SCOPE_IDENTITY();",
                    new { Username, Password }
                );

                // You could fetch the user model by the inserted ID if necessary
                return db.QueryFirstOrDefault<UserModel>("SELECT * FROM [User] WHERE Id = @Id", new { Id = id });
            }
        }


        public UserModel Update(UserModel value)
        {
            throw new NotImplementedException();
        }
    }
}

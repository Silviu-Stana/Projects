using ProductManagement.BusinessModel;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace ProductManagement.DataAccess.Repositories
{
    public class CategoryRepository : IRepository<CategoryModel>
    {
        public string ConnectionString = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;

        public CategoryModel Create(CategoryModel value)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                if (db.State == ConnectionState.Closed) db.Open();
                var query = @"
                    INSERT INTO Category(Id, CategoryName) 
                    VALUES(@Id,@CategoryName);
                    SELECT CAST(SCOPE_IDENTITY() as int)";

                //Get back newly created id
                var id = db.Query<int>(query, new { value.Id, value.CategoryName }).Single();
                value.Id = id;
                return value;
            }
        }

        public CategoryModel Update(CategoryModel value)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                if (db.State == ConnectionState.Closed) db.Open();
                db.Query<CategoryModel>($"DELETE FROM Category WHERE Id={id}", commandType: CommandType.Text);
            }
        }

        public List<CategoryModel> GetAll()
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                if (db.State == ConnectionState.Closed) db.Open();
                return db.Query<CategoryModel>("SELECT * FROM Category", commandType: CommandType.Text).ToList();
            }
        }

        public CategoryModel GetById(int id)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                if (db.State == ConnectionState.Closed) db.Open();
                return db.QueryFirstOrDefault<CategoryModel>($"SELECT * FROM Category WHERE Id={id}");
            }
        }


    }
}

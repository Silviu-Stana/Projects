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
    public class ProductCategoryRepository : IRepository<ProductCategory>
    {
        public string ConnectionString = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;

        public ProductCategory Create(ProductCategory value)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                if (db.State == ConnectionState.Closed) db.Open();
                var query = @"
                    INSERT INTO ProductCategory(ProductId, CategoryId) 
                    VALUES(@ProductId,@CategoryId);
                    SELECT CAST(SCOPE_IDENTITY() as int)";

                //Get back newly created id
                var id = db.Query<int>(query, new { value.ProductId, value.CategoryId }).Single();
                value.CategoryId = id;
                return value;
            }
        }

        public ProductCategory Update(ProductCategory value)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                if (db.State == ConnectionState.Closed) db.Open();
                db.Query<ProductCategory>($"DELETE FROM ProductCategory WHERE ProductId={id}", commandType: CommandType.Text);
            }
        }

        public List<ProductCategory> GetAll()
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                if (db.State == ConnectionState.Closed) db.Open();
                return db.Query<ProductCategory>("SELECT * FROM ProductCategory", commandType: CommandType.Text).ToList();
            }
        }

        public ProductCategory GetById(int id)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                if (db.State == ConnectionState.Closed) db.Open();
                return db.QueryFirstOrDefault<ProductCategory>($"SELECT * FROM ProductCategory WHERE ProductId={id}");
            }
        }

        public List<ProductCategory> GetAllById(int id)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                if (db.State == ConnectionState.Closed) db.Open();
                return db.Query<ProductCategory>($"SELECT * FROM ProductCategory WHERE ProductId={id}").ToList();
            }
        }
    }
}

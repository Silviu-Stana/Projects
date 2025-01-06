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
    public class ProductRepository : IRepository<ProductModel>
    {
        public string ConnectionString = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;

        public ProductModel Create(ProductModel value)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                if (db.State == ConnectionState.Closed) db.Open();
                var query = @"
                    INSERT INTO Product(Title,Description,Price,Category,UserId,Phone) 
                    VALUES(@Title,@Description,@Price,@Category,@UserId,@Phone);
                    SELECT CAST(SCOPE_IDENTITY() as int)";

                //Get back newly created id
                var id = db.Query<int>(query, new { value.Title, value.Description, value.Price }).Single();
                value.Id = id;
                return value;
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                if (db.State == ConnectionState.Closed) db.Open();
                db.Query<ProductModel>($"DELETE FROM Product WHERE Id={id}", commandType: CommandType.Text);
            }
        }

        public List<ProductModel> GetAll()
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                if (db.State == ConnectionState.Closed) db.Open();
                return db.Query<ProductModel>("SELECT * FROM Product", commandType: CommandType.Text).ToList();
            }
        }

        public ProductModel GetById(int id)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                if (db.State == ConnectionState.Closed) db.Open();
                return db.QueryFirstOrDefault<ProductModel>($"SELECT * FROM Product WHERE Id={id}");
            }
        }

        public List<ProductModel> GetByTitlePattern(string pattern, string ProductCategory)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                if (db.State == ConnectionState.Closed) db.Open();

                if (ProductCategory == "" || ProductCategory == null || ProductCategory == "None")
                    return db.Query<ProductModel>(
                        "SELECT * FROM Product WHERE LOWER(Title) LIKE LOWER(@Pattern)",
                        new { Pattern = $"%{pattern}%" }
                    ).ToList();
                else
                    return db.Query<ProductModel>(
                    "SELECT * FROM Product WHERE LOWER(Title) LIKE LOWER(@Pattern) AND Category=@ProductCategory",
                    new { Pattern = $"%{pattern}%", ProductCategory }
                ).ToList();
            }
        }

        public ProductModel Update(ProductModel value)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                if (db.State == ConnectionState.Closed) db.Open();
                var query = "UPDATE Product SET Title=@Title, Description=@Description, Price=@Price, Category=@Category, UserId=@UserId, Phone=@Phone WHERE Id=@Id";
                db.Execute(query, new { value.Title, value.Description, value.Price, value.Id });
                return value;
            }
        }
    }
}

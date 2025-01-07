using ProductManagement.BusinessModel;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.IO;

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
                    INSERT INTO Product(Title,Description,Price,FabricationDate,Brand,IsDisabled) 
                    VALUES(@Title,@Description,@Price,@FabricationDate,@Brand,@IsDisabled);
                    SELECT CAST(SCOPE_IDENTITY() as int)";

                //Get back newly created id
                var id = db.Query<int>(query, new { value.Title, value.Description, value.Price, value.FabricationDate, value.Brand, value.IsDisabled }).Single();
                value.Id = id;
                return value;
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                if (db.State == ConnectionState.Closed) db.Open();
                using (var transaction = db.BeginTransaction())
                {
                    try
                    {
                        var query = "DELETE FROM Product WHERE Id = @ProductId";
                        db.Execute(query, new { ProductId = id }, transaction);

                        DeletePicturesFolder(id);

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        private void DeletePicturesFolder(int productId)
        {
            string folderPath = Path.Combine("Pictures", productId.ToString());
            if (Directory.Exists(folderPath))
            {
                Directory.Delete(folderPath, true);
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

        public List<ProductModel> GetByTitlePattern(string pattern, string ProductCategory, string orderBy)
        {
            string howToOrderBy = "ASC";
            string ordering = "Id";
            //"Title, Price, FabricationDate, Brand, Rating"
            if (orderBy.Contains("Title")) ordering = "Title";
            else if (orderBy.Contains("Price")) ordering = "Price";
            else if (orderBy.Contains("Fabrication Date")) ordering = "FabricationDate";
            else if (orderBy.Contains("Brand")) ordering = "Brand";



            if (orderBy.Contains("Ascending")) howToOrderBy = "ASC";
            else if (orderBy.Contains("Descending")) howToOrderBy = "DESC";


            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                if (db.State == ConnectionState.Closed) db.Open();

                if (ProductCategory == "" || ProductCategory == null || ProductCategory == "None")
                    return db.Query<ProductModel>(
                        $"SELECT * FROM Product WHERE LOWER(Title) LIKE LOWER(@Pattern) ORDER BY {ordering} {howToOrderBy}",
                        new { Pattern = $"%{pattern}%" }
                    ).ToList();
                else
                    return db.Query<ProductModel>(
                        $"SELECT A.* FROM Product A INNER JOIN ProductCategory B ON A.Id=B.ProductId INNER JOIN Category C ON B.CategoryId=C.Id WHERE LOWER(A.Title) LIKE LOWER(@Pattern) AND C.CategoryName=@ProductCategory ORDER BY {ordering} {howToOrderBy}",
                        new { Pattern = $"%{pattern}%", ProductCategory, ordering, howToOrderBy }
                    ).ToList();
            }
        }

        public ProductModel Update(ProductModel value)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                if (db.State == ConnectionState.Closed) db.Open();
                var query = "UPDATE Product SET Title=@Title, Description=@Description, Price=@Price, FabricationDate=@FabricationDate, Brand=@Brand, IsDisabled=@IsDisabled WHERE Id=@Id";
                db.Execute(query, new { value.Title, value.Description, value.Price, value.FabricationDate, value.Brand, value.IsDisabled, value.Id });
                return value;
            }
        }
    }
}

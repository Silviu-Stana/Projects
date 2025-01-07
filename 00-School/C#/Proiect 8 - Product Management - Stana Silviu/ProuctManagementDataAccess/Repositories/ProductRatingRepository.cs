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
    public class ProductRatingRepository : IRepository<ProductEvaluation>
    {
        public string ConnectionString = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;

        public ProductEvaluation Create(ProductEvaluation value)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                if (db.State == ConnectionState.Closed) db.Open();
                var query = @"
                                    INSERT INTO ProductEvaluation(ProductId, UserId, Value) 
                                    VALUES(@ProductId, @UserId, @Value)";

                db.Execute(query, new { value.ProductId, value.UserId, value.Value });
                return value;
            }
        }

        public ProductEvaluation Update(ProductEvaluation value)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                if (db.State == ConnectionState.Closed) db.Open();
                var query = @"
                                UPDATE ProductEvaluation 
                                SET Value = @Value 
                                WHERE ProductId = @ProductId AND UserId = @UserId";

                db.Execute(query, new { value.ProductId, value.UserId, value.Value });
                return value;
            }
        }

        public void Delete(int ProductId, int UserId)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                if (db.State == ConnectionState.Closed) db.Open();
                db.Execute($"DELETE FROM ProductEvaluation WHERE ProductId={ProductId} AND UserId={UserId}", commandType: CommandType.Text);
            }
        }

        public List<ProductEvaluation> GetAll()
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                if (db.State == ConnectionState.Closed) db.Open();
                return db.Query<ProductEvaluation>("SELECT * FROM ProductEvaluation", commandType: CommandType.Text).ToList();
            }
        }

        public ProductEvaluation GetById(int ProductId, int UserId)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                if (db.State == ConnectionState.Closed) db.Open();
                var query = "SELECT * FROM ProductEvaluation WHERE ProductId = @ProductId AND UserId = @UserId";
                return db.QueryFirstOrDefault<ProductEvaluation>(query, new { ProductId, UserId });
            }
        }


        public double GetAverageRating(int productId)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                if (db.State == ConnectionState.Closed) db.Open();
                var query = "SELECT AVG(CAST(Value AS DECIMAL(5, 1))) FROM ProductEvaluation WHERE ProductId = @ProductId";
                return db.ExecuteScalar<double>(query, new { ProductId = productId });
            }
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ProductEvaluation GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}

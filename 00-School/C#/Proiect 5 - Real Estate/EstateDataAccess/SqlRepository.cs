using EstateDataAccess.Repository;
using EstateModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;

namespace EstateDataAccess
{
    public class SQLRepository<T> : IRepository<T> where T : new()
    {
        public static string stringConectare = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

        public SQLRepository()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(stringConectare))
                {
                    connection.Open();
                    Console.WriteLine("Conectare cu succes!");
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Eșec conectare! Mesaj eroare: {ex.Message}");
            }
        }

        public T Create(T value)
        {
            var properties = typeof(T).GetProperties();

            var nonIdProperties = properties.Where(p => !p.Name.Contains("Id")).Select(p => p.Name);

            string insertCommand = $@"INSERT INTO {typeof(T).Name} ({string.Join(", ", nonIdProperties)})
                                                          VALUES ({string.Join(", ", nonIdProperties.Select(name => "@" + name))})";

            Console.WriteLine(insertCommand);

            //Executa
            using (var connection = new SqlConnection(stringConectare))
            {
                connection.Open();
                using (var command = new SqlCommand(insertCommand, connection))
                {
                    foreach (var prop in nonIdProperties)
                    {
                        command.Parameters.AddWithValue("@" + prop, typeof(T).GetProperty(prop)?.GetValue(value) ?? DBNull.Value);
                    }

                    command.ExecuteNonQuery();
                }
            }

            return value;
        }

        public void Delete(int id)
        {
            string deleteCommand = $"DELETE FROM {typeof(T).Name} WHERE {typeof(T).Name}Id = @Id";
            using (var connection = new SqlConnection(stringConectare))
            {
                connection.Open();
                using (var command = new SqlCommand(deleteCommand, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<T> GetAll()
        {
            string selectAll = $"select {typeof(T).Name}Id as Id, * from {typeof(T).Name}";
            var list = new List<T>();

            try
            {
                using (var connection = new SqlConnection(stringConectare))
                {
                    connection.Open();
                    using (var command = new SqlCommand(selectAll, connection))
                    {

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                T e = new T();
                                foreach (var prop in typeof(T).GetProperties())
                                {
                                    try
                                    {
                                        if (!reader.IsDBNull(reader.GetOrdinal(prop.Name)))
                                        {
                                            prop.SetValue(e, reader[prop.Name]);
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine($"Error mapping property '{prop.Name}': {ex.Message}");
                                    }
                                }
                                list.Add(e);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            return list;
        }

        public T GetById(int id)
        {
            //In clasa Estate se numeste "Id" in timp ce numele coloanei este "EstateId"!! Asta era problema!
            //Deci in implementarea generica, selectul trebuie sa mapaze corect "Id" -> "EstateId"
            string selectById = $"select {typeof(T).Name}Id as Id, * from {typeof(T).Name} where {typeof(T).Name}Id = @Id";
            T e = default;

            try
            {
                using (var connection = new SqlConnection(stringConectare))
                {
                    connection.Open();
                    using (var command = new SqlCommand(selectById, connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                e = new T();
                                foreach (var prop in typeof(T).GetProperties())
                                {
                                    try
                                    {
                                        if (!reader.IsDBNull(reader.GetOrdinal(prop.Name)))
                                        {
                                            prop.SetValue(e, reader[prop.Name]);
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine($"Error mapping property '{prop.Name}': {ex.Message}");
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            return e;
        }


        public T Update(T value)
        {
            var properties = typeof(T).GetProperties();

            var idProperty = properties.FirstOrDefault(p => p.Name == $"{typeof(T).Name}Id" || p.Name == "Id");
            var nonIdProperties = properties.Where(p => p != idProperty).Select(p => p.Name).ToList();

            if (idProperty == null)
                throw new InvalidOperationException("The entity must have an Id property to perform an update.");

            //Foloseste numele coloanei corect, care difera de numele proprietatii
            var idColumnName = idProperty.Name == "Id" ? $"{typeof(T).Name}Id" : idProperty.Name;

            string updateCommand = $@"
        UPDATE {typeof(T).Name}
        SET {string.Join(", ", nonIdProperties.Select(name => $"{name} = @{name}"))}
        WHERE {idColumnName} = @{idProperty.Name}";

            Console.WriteLine(updateCommand);

            //Executa
            using (var connection = new SqlConnection(stringConectare))
            {
                connection.Open();
                using (var command = new SqlCommand(updateCommand, connection))
                {
                    foreach (var prop in nonIdProperties) command.Parameters.AddWithValue("@" + prop, typeof(T).GetProperty(prop)?.GetValue(value) ?? DBNull.Value);
                    command.Parameters.AddWithValue("@" + idProperty.Name, idProperty.GetValue(value) ?? DBNull.Value);

                    command.ExecuteNonQuery();
                }
            }

            return value;
        }

    }
}
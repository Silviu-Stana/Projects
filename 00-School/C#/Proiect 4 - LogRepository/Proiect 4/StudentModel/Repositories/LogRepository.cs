using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Entities;

namespace LoggingRepository
{
    public class LogRepository : IRepository<Log>
    {
        static string stringConectare = @"Data Source=SEAL\SEAL;Initial Catalog=New;Integrated Security=True";
        static SqlConnection con;


        //Constructor
        public LogRepository()
        {
            try
            {
                con = new SqlConnection(stringConectare);
                con.Open();
                con.Close();
                Console.WriteLine("Conectare cu succes!");
            }
            catch { Console.WriteLine("Esec conectare!"); }
        }


        Log IRepository<Log>.GetById(int id)
        {
            SqlDataReader rdr;
            Log log = new Log();

            try
            {
                SqlCommand cmd = new SqlCommand($"select * from Logs where id={id}", con);
                con.Open();
                rdr = cmd.ExecuteReader();

                //We did not find the id
                if (rdr.Read() == false)
                {
                    Console.WriteLine("Id not found");
                    return null;
                }
                else
                {
                    log.Id = (int)rdr["codLog"];
                    log.LogDate = rdr["logDate"].ToString();
                    log.LogMessage = (string)rdr["logMessage"];
                }
            }
            finally
            {
                con.Close();
            }
            rdr.Close();


            return log;
        }


        List<Log> IRepository<Log>.GetAll()
        {
            SqlDataReader rdr;
            List<Log> logList = new List<Log>();

            try
            {
                SqlCommand cmd = new SqlCommand("select * from Logs", con);
                con.Open();
                rdr = cmd.ExecuteReader();

                if (rdr.Read() == false)
                {
                    Console.WriteLine("No logs found.");
                    return null;
                }
                else
                {
                    //Without this ELSE, the first log will not be added.
                    logList.Add(new Log
                    {
                        Id = (int)rdr["codLog"],
                        LogDate = rdr["logDate"].ToString(),
                        LogMessage = (string)rdr["logMessage"]
                    });
                }

            }
            catch { Console.WriteLine("esec SqlDataReader"); return null; }

            while (rdr.Read())
            {
                logList.Add(new Log
                {
                    Id = (int)rdr["codLog"],
                    LogDate = rdr["logDate"].ToString(),
                    LogMessage = (string)rdr["logMessage"]
                });
            }
            rdr.Close();
            con.Close();

            return logList;
        }



        void IRepository<Log>.Create(Log entity)
        {
            string strInsert = $"insert into Logs(logDate,logMessage) values ('{entity.LogDate}', '{entity.LogMessage}')";

            try
            {
                SqlCommand cmd = new SqlCommand(strInsert, con);
                con.Open();
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: Inserting logs.\n" + strInsert + "\n");

                Console.WriteLine(ex.Message);
            }
            con.Close();
        }

        void IRepository<Log>.Update(Log entity)
        {
            string strUpdate = $"UPDATE Logs SET logDate='{entity.LogDate}', logMessage='{entity.LogMessage}' WHERE codLog={entity.Id}";

            try
            {
                SqlCommand cmd = new SqlCommand(strUpdate, con);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: Updating log with code `{entity.Id}`\n" + e.ToString());
            }
            con.Close();
        }

        public void Delete(int id)
        {
            string strDelete = $"DELETE FROM Logs WHERE codLog='{id}'";

            int n;
            try
            {

                SqlCommand cmd = new SqlCommand(strDelete, con);
                con.Open();
                n = cmd.ExecuteNonQuery();
                con.Close();
                if (n == 0) throw new Exception("Log code not found");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: Deleting log with code `{id}`\n" + e.ToString());
            };
        }
    }
}

//public bool Contains(T value)
//{
//    foreach (var item in _values) if (item.Equals(value)) return true;
//    return false;
//}
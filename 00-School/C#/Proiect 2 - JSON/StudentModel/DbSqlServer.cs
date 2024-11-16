using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentModel
{
    public class DbSqlServer
    {
        static string stringConectare = @"Data Source=SEAL\SEAL;Initial Catalog=New;Integrated Security=True";
        public static SqlConnection con;


        public DbSqlServer()
        {
            try
            {
                con = new SqlConnection(stringConectare);
                con.Open();
                con.Close();
                //Console.WriteLine("Conectare cu succes!");
            }
            catch { Console.WriteLine("Esec conectare!"); }
        }

        public void ListLogs()
        {
            SqlDataReader rdr;

            try
            {
                SqlCommand cmd = new SqlCommand("select * from Logs", con);
                con.Open();
                rdr = cmd.ExecuteReader();

            }
            catch { Console.WriteLine("esec SqlDataReader"); return; }

            Console.WriteLine("{0,-10}{1,-30}{2,-50}", "Cod Log", "Date of Log", "Message");
            while (rdr.Read())
            {
                Console.WriteLine("{0,-10}{1,-30}{2,-50}", rdr["codLog"], rdr["logDate"], rdr["logMessage"]);
            }
            rdr.Close();
            con.Close();
        }


        public void InsertLogs(string DateLog, string LogMessage)
        {
            string strInsert = $"insert into Logs(logDate,logMessage) values ('{DateLog}', '{LogMessage}')";

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

        public void StergeLog(string CodLog)
        {
            string strDelete = "DELETE FROM Logs WHERE codLog=" + CodLog;

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
                Console.WriteLine($"Error: Deleting log with code {CodLog}\n" + e.ToString());
            };
        }

    }
}
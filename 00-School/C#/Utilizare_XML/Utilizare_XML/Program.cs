using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Configuration;

namespace Utilizare_XML
{
    class Global
    {
        static string strConectare = ConfigurationManager.AppSettings["stringConectare"];
        public static SqlConnection con = null;
        public static DataSet ds;
        //public static SqlDataAdapter daMed;
        public static DataTable table;

        public Global()
        {
            con = new SqlConnection(strConectare);
            ds = new DataSet();

            //daMed = new SqlDataAdapter("select * from tMedicamente", con);

            //table = new DataTable("DocumenteXML");
            //table.Columns.Add("Id_document", typeof(int));
            //table.Columns.Add("Cale_document", typeof(string));
            table = new DataTable("Medicamente");
            table.Columns.Add("CodMedicament", typeof(int));
            table.Columns.Add("Nume", typeof(string));

            table.Rows.Add(1, "Ibuprofen");
            table.Rows.Add(2, "Xanax");
            table.Rows.Add(3, "Droguri");


            ds.Tables.Add(table);

            //daMed.Fill(ds, "Medicamente");
        }
    }

    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}

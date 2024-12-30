using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

//Parola Student_2023

namespace SGBP_Project___Silviu
{
    static class Global
    {
        public static String stringConectare = "Data Source=SEAL\\SEAL;Initial Catalog=dbFirma;Integrated Security=True";
        public static SqlConnection con = new SqlConnection(stringConectare);

        public static SqlDataAdapter angajatiDataAdapter;
        public static SqlDataAdapter clientiDataAdapter;
        public static SqlDataAdapter comenziDataAdapter;
        public static SqlDataAdapter detaliiComandaDataAdapter;

        public static DataSet dataSet = new DataSet();
    }

    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form());
        }
    }
}

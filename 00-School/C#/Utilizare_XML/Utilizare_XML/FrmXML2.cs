using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Utilizare_XML
{
    public partial class FrmXML2 : Form
    {
        static string strCon = "Data source= virtualdb; Initial Catalog = dbDocumenteXML; user id = student; password=student";
        SqlConnection con2 = null;

        DataSet ds2;
        SqlDataAdapter daXML = null;

        DataView dv;
        DataView dv2;


        public FrmXML2()
        {
            InitializeComponent();
        }

        private void FrmXML2_Load(object sender, EventArgs e)
        {
            con2 = new SqlConnection(strCon);
            ds2 = new DataSet();
            daXML = new SqlDataAdapter("select * from tDocumenteXML", con2);
            daXML.Fill(ds2, "DocumenteXML");

            dv = new DataView(ds2.Tables["DocumenteXML"]);
            dv2 = new DataView(ds2.Tables["DocumenteXML"]);

            dv.Sort = "Cale_Document";
            //cb_XML.DataSource = dv;

            //cb_XML.DisplayMember = "Cale_Document";//ce vedem
            //cb_XML.ValueMember = "Id_Document";//ce folosim
        }

        private void btnImportXML_Click(object sender, EventArgs e)
        {
            //string idDocument = cb_XML.SelectedValue.ToString();
            string filePath;
            DataSet dsw = new DataSet();
            //dv2.RowFilter = "Id_Document='" + idDocument + "'";

            DataRowView r = dv2[0];
            filePath = r["Cale_Document"].ToString();
            dsw.ReadXml(filePath);

            //dgv_Documente.DataSource = dsw.Tables[0];

            MessageBox.Show(dsw.Tables[0].TableName);
        }
    }
}

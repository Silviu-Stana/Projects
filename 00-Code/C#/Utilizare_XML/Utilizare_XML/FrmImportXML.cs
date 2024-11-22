using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Utilizare_XML
{
    public partial class FrmImportXML : Form
    {
        public FrmImportXML()
        {
            InitializeComponent();
        }

        private void btnImportXML_Click(object sender, EventArgs e)
        {
            DataSet dsXML = new DataSet();
            string filePath = @"C:\Users\silviu\Desktop\Medicamente.xml";
            dsXML.ReadXml(filePath);

            dgvMed.DataSource = dsXML;
            dgvMed.DataMember = "Medicamente";
        }

        private void dgvMed_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

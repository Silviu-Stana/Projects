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
    public partial class FrmExportXML : Form
    {
        public FrmExportXML()
        {
            InitializeComponent();
        }

        private void FrmExportXML_Load(object sender, EventArgs e)
        {
            dgvMed.DataSource = Global.ds;
            dgvMed.DataMember = "Medicamente";
        }

        private void btnExportXML_Click(object sender, EventArgs e)
        {
            Global.ds.Tables["Medicamente"].WriteXml(@"C:\Users\silviu\Desktop\Medicamente.xml");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

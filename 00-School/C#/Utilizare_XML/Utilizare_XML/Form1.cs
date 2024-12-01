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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            new Global();
        }

        private void exportXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmExportXML f = new FrmExportXML();
            f.ShowDialog();
        }

        private void importXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmImportXML f = new FrmImportXML();
            f.ShowDialog();
        }

        private void vizualizareDocumenteXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmXML2 f = new FrmXML2();
            f.ShowDialog();
        }
    }

}

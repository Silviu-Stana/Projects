using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SGBP_Project___Silviu
{
    public partial class Form : System.Windows.Forms.Form
    {
        public Form()
        {
            InitializeComponent();
        }

        private void listaDeClientiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CautaComanda form = new CautaComanda();
            form.Show();
        }

        private void EmployeesMenu_Click(object sender, EventArgs e)
        {
            ListaAngajatiForm form = new ListaAngajatiForm();
            form.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ListaAngajatiForm form = new ListaAngajatiForm();
            form.Show();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            CautaComanda form = new CautaComanda();
            form.Show();
        }

        private void Form_Load(object sender, EventArgs e)
        {

        }


    }
}

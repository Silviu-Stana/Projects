using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace SGBP_Project___Silviu
{
    public partial class CautaComanda : System.Windows.Forms.Form
    {
        string codClient, nrComanda;
        string numeClient;
        int selectedClientRowIndex = -1;
        int selectedComanda = -1;

        public CautaComanda()
        {
            InitializeComponent();
        }

        private void CautaComanda_Load(object sender, EventArgs e)
        {
            Client_GridView.ReadOnly = true;
            Comenzi_GridView.ReadOnly = true;
            Comanda_GridView.ReadOnly = true;

            Client_GridView.MultiSelect = false;
            Comenzi_GridView.MultiSelect = false;
            Comanda_GridView.MultiSelect = false;


            SetupDatePicker();

            Client_GridView.AllowUserToAddRows = false; //taie ultimul rand din GridView ca sa arate mai frumos
            Comenzi_GridView.AllowUserToAddRows = false;
            Comanda_GridView.AllowUserToAddRows = false;

            Global.clientiDataAdapter = new SqlDataAdapter("select numeClient, localitate, codClient from Pachete.tClienti order by codClient", Global.con);
            Global.clientiDataAdapter.Fill(Global.dataSet, "Clienti");
            DataView dataView = new DataView(Global.dataSet.Tables["Clienti"]);
            dataView.Sort = "codClient ASC";
            Client_GridView.DataSource = dataView;

            //AddListaFunctiiLaDropDown();
            Client_GridView.ClearSelection();
            Comenzi_GridView.ClearSelection();
            Comanda_GridView.ClearSelection();

            Enable_Label2.Text = numeClient;
            DeterminaNrClienti();
        }

        void SetupDatePicker()
        {
            dateTimePicker1.MaxDate = DateTime.Now;
            dateTimePicker1.MinDate = new DateTime(2000, 1, 1);
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd HH:mm";
        }

        void DeterminaNrClienti()
        {
            string sql = "select count(codClient) from tClienti";
            using (SqlCommand cmd = new SqlCommand(sql, Global.con))
            {
                Global.con.Open();
                int count = (int)cmd.ExecuteScalar(); //valoare din row1 column1
                Global.con.Close();
                NrClienti_Label.Text = count.ToString();
            }
        }


        private void Client_GridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // Prevent error when clicking on column names

            numeClient = Client_GridView.Rows[e.RowIndex].Cells[0].Value.ToString();
            codClient = Client_GridView.Rows[e.RowIndex].Cells[2].Value.ToString();
            selectedClientRowIndex = e.RowIndex;

            // Clear previous data to prevent duplicates
            if (Global.dataSet.Tables.Contains("Comenzi"))
            {
                Global.dataSet.Tables["Comenzi"].Clear();
            }

            Global.comenziDataAdapter = new SqlDataAdapter("select nrComanda, dataComanda, dataLivrare from Pachete.tComenzi where codClient=@codClient", Global.con);
            Global.comenziDataAdapter.SelectCommand.Parameters.AddWithValue("@codClient", codClient);
            Global.comenziDataAdapter.Fill(Global.dataSet, "Comenzi");

            // Clear Comanda_GridView to prevent showing old data
            if (Global.dataSet.Tables.Contains("DetaliiComanda"))
            {
                Global.dataSet.Tables["DetaliiComanda"].Clear();
            }
            Comanda_GridView.DataSource = null;

            DataView dataView = new DataView(Global.dataSet.Tables["Comenzi"]);
            dataView.Sort = "nrComanda ASC";
            Comenzi_GridView.DataSource = dataView;

            Comenzi_GridView.ClearSelection();
            Comanda_GridView.ClearSelection();

            ShowInformationAboutNumberOfOrders();
            AscundeInformatiiDespreComanda();
        }

        void ShowInformationAboutNumberOfOrders()
        {
            Enable_InfoBox.Enabled = true;
            Enable_Label1.Enabled = true;
            Enable_Label2.Enabled = true;
            Enable_NrOrders.Enabled = true;

            Enable_InfoBox.Visible = true;
            Enable_Label1.Visible = true;
            Enable_Label2.Visible = true;
            Enable_NrOrders.Visible = true;

            Enable_Label2.Text = numeClient;

            CalculeazaNrComenzi();
        }
        void CalculeazaNrComenzi()
        {
            string sql = "select count(nrComanda) from Pachete.tComenzi where codClient=@codClient";
            using (SqlCommand cmd = new SqlCommand(sql, Global.con))
            {
                Global.con.Open();
                cmd.Parameters.AddWithValue("@codClient", codClient);
                int count = (int)cmd.ExecuteScalar(); //valoare din row1 column1
                Global.con.Close();
                Enable_NrOrders.Text = count.ToString();
            }
            CentreazaText(Enable_Label2, -20);
        }


        int nrComandaSelectata;

        private void Comenzi_GridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; //prevent error when clicking on column names

            nrComandaSelectata = int.Parse(Comenzi_GridView.Rows[e.RowIndex].Cells[0].Value.ToString());

            DeliveryPanel.Visible = true;
            var selectedDeliveryDate = Comenzi_GridView.Rows[e.RowIndex].Cells[2].Value;
            if (selectedDeliveryDate != DBNull.Value) dateTimePicker1.Value = Convert.ToDateTime(selectedDeliveryDate);
            else dateTimePicker1.Value = DateTime.Today;

            nrComanda = Comenzi_GridView.Rows[e.RowIndex].Cells[0].Value.ToString();
            selectedComanda = e.RowIndex;

            // Clear previous data to prevent duplicates
            if (Global.dataSet.Tables.Contains("DetaliiComanda")) Global.dataSet.Tables["DetaliiComanda"].Clear();

            Global.detaliiComandaDataAdapter = new SqlDataAdapter(
            "select A.idRand, A.codProdus, B.denumire, A.cantitate, A.cantitate*B.pret as PretTotal " +
            "from Pachete.tDetaliiComanda as A " +
            "inner join Pachete.tProduse as B " +
            "on A.codProdus=B.codProdus " +
            "where nrComanda=@nrComanda", Global.con);

            Global.detaliiComandaDataAdapter.SelectCommand.Parameters.AddWithValue("@nrComanda", nrComanda);
            Global.detaliiComandaDataAdapter.Fill(Global.dataSet, "DetaliiComanda");

            DataView dataView = new DataView(Global.dataSet.Tables["DetaliiComanda"]);
            dataView.Sort = "idRand ASC";
            Comanda_GridView.DataSource = dataView;

            CalculeazaPretTotal();
            ArataInformatiiDespreComanda();
        }

        void CalculeazaPretTotal()
        {
            int total = 0;
            foreach (DataGridViewRow row in Comanda_GridView.Rows)
            {
                if (row.Cells[4].Value != null) total += Convert.ToInt32(row.Cells[4].Value);
            }
            PretTotal_Label.Text = total.ToString() + " RON";
            CentreazaText(PretTotal_Label, 20);
        }

        private void SetDeliveryDate_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE Pachete.tComenzi SET dataLivrare=@dataLivrare WHERE nrComanda=@nrComanda", Global.con))
                {
                    cmd.Parameters.AddWithValue("@dataLivrare", dateTimePicker1.Value);
                    cmd.Parameters.AddWithValue("@nrComanda", nrComandaSelectata);
                    Global.con.Open();
                    cmd.ExecuteNonQuery();
                    Global.con.Close();
                }

                // Update the cell in the grid view to reflect the changes
                Comenzi_GridView.Rows[selectedComanda].Cells[2].Value = dateTimePicker1.Value;
            }
            catch
            {
                MessageBox.Show("Eroare la modificarea datei de livrare");
            }
        }

        void ArataInformatiiDespreComanda()
        {
            groupBox2.Enabled = true;
            PretTotal_Label.Enabled = true;
            PretTotal_Label2.Enabled = true;

            groupBox2.Visible = true;
            PretTotal_Label.Visible = true;
            PretTotal_Label2.Visible = true;
        }

        void AscundeInformatiiDespreComanda()
        {
            groupBox2.Enabled = false;
            PretTotal_Label.Enabled = false;
            PretTotal_Label2.Enabled = false;

            groupBox2.Visible = false;
            PretTotal_Label.Visible = false;
            PretTotal_Label2.Visible = false;

            DeliveryPanel.Visible = false;
        }


        void CentreazaText(System.Windows.Forms.Label label, int scadePozitiaY)
        {
            label.Location = new Point(
                (label.Parent.Width - label.Width) / 2, // Centreaza orizonal (in parintele GroupBox)
                (label.Parent.Height - label.Height + scadePozitiaY) / 2 // Centreaza vertical
            );
        }

        private void Comanda_GridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Comenzi_GridView_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

        private void Comanda_GridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void NrClienti_Label_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Client_GridView_CellContentClick(object sender, DataGridViewCellEventArgs e) { }


    }
}

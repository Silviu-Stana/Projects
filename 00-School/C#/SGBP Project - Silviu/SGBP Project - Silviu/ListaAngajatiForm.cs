using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

///
/// Lista Angajati
///   -pot fii selectare functii, si schimbat numele
///   -pot fii salvate datele noi in baza de date
///   -si lista de angajati poate fii salvata ca fisier XML/CSV
///


namespace SGBP_Project___Silviu
{
    public partial class ListaAngajatiForm : System.Windows.Forms.Form
    {
        int selectedRow = -1;
        string numeAngajat;
        string functieAngajat;
        string codAngajat;

        public ListaAngajatiForm()
        {
            InitializeComponent();
        }

        private void ListaAngajati_GridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            numeAngajat = ListaAngajati_GridView.Rows[e.RowIndex].Cells[0].Value.ToString();
            functieAngajat = ListaAngajati_GridView.Rows[e.RowIndex].Cells[1].Value.ToString();
            codAngajat = ListaAngajati_GridView.Rows[e.RowIndex].Cells[2].Value.ToString();
            Nume_TextBox.Text = numeAngajat;
            Functie_DropDown.Text = functieAngajat;

            selectedRow = e.RowIndex;
        }

        private void ListaAngajati_GridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void ListaAngajatiForm_Load(object sender, EventArgs e)
        {
            ListaAngajati_GridView.ReadOnly = true;
            ListaAngajati_GridView.AllowUserToAddRows = false; //taie ultimul rand din GridView ca sa arate mai frumos

            Global.angajatiDataAdapter = new SqlDataAdapter(
                "select numeAngajat, B.functie, A.codAngajat from Pachete.tAngajati as A inner JOIN Pachete.tFunctii as B on A.codFunctie=B.codFunctie", Global.con);
            Global.angajatiDataAdapter.Fill(Global.dataSet, "Angajati");

            ListaAngajati_GridView.DataSource = Global.dataSet;
            ListaAngajati_GridView.DataMember = "Angajati";

            ListaAngajati_GridView.Columns[0].Width = ListaAngajati_GridView.Columns[0].Width;
            ListaAngajati_GridView.Columns[1].Width = ListaAngajati_GridView.Columns[0].Width * 2;

            AddListaFunctiiLaDropDown(Functie_DropDown);
            AddListaFunctiiLaDropDown(FunctieInsert_DropDown);

            ListaAngajati_GridView.ClearSelection(); // Clear selection after data binding
        }


        private void AddListaFunctiiLaDropDown(ComboBox Functii)
        {
            Functii.Items.Clear();
            foreach (DataGridViewRow row in ListaAngajati_GridView.Rows)
            {
                if (row.Cells[1].Value != null)
                {
                    Functii.Items.Add(row.Cells[1].Value.ToString());
                }
            }
        }


        private void Save_Button_Click(object sender, EventArgs e)
        {
            if (selectedRow == -1)
            {
                MessageBox.Show("Selectati un angajat pentru a-l modifica", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //indexul randului selectat
            ListaAngajati_GridView.Rows[selectedRow].Cells[0].Value = Nume_TextBox.Text;
            ListaAngajati_GridView.Rows[selectedRow].Cells[1].Value = Functie_DropDown.Text;


            //Validam ca numele sa nu fie gol
            if (Nume_TextBox.Text != "" && selectedRow != -1) UpdateAngajat();
        }

        private void UpdateAngajat()
        {
            string strUpdate = "UPDATE Pachete.tAngajati SET numeAngajat = @numeAngajat, codFunctie = (SELECT codFunctie FROM Pachete.tFunctii WHERE functie = @functieAngajat) WHERE codAngajat = @codAngajat";
            try
            {
                using (SqlCommand cmd = new SqlCommand(strUpdate, Global.con))
                {
                    cmd.Parameters.AddWithValue("@numeAngajat", Nume_TextBox.Text);
                    cmd.Parameters.AddWithValue("@functieAngajat", Functie_DropDown.Text);
                    cmd.Parameters.AddWithValue("@codAngajat", codAngajat);

                    Global.con.Open();
                    int n = cmd.ExecuteNonQuery(); //nr randuri afectate  
                    if (n == 0) throw new Exception("CodAngajat inexistent");

                    MessageBox.Show("Modificarile au fost salvate\n" + "in baza de date.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare: Modificare Esuata\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Global.con.Close();
            }
        }

        private void ExportXML_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = "ListaAngajati.xml";
            saveFileDialog.Filter = "XML files (*.xml)|*.xml";
            saveFileDialog.Title = "Save as XML File";
            saveFileDialog.DefaultExt = "xml";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                Global.dataSet.Tables["Angajati"].WriteXml(saveFileDialog.FileName);
                MessageBox.Show("Data exported successfully!", "Export XML", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ExportCSV_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = "ListaAngajati.csv";
            saveFileDialog.Filter = "CSV files (*.csv)|*.csv";
            saveFileDialog.Title = "Save as CSV File";
            saveFileDialog.DefaultExt = "csv";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                var sb = new System.Text.StringBuilder();
                var headers = ListaAngajati_GridView.Columns.Cast<DataGridViewColumn>();
                sb.AppendLine(string.Join(",", headers.Select(column => "\"" + column.HeaderText + "\"").ToArray()));

                foreach (DataGridViewRow row in ListaAngajati_GridView.Rows)
                {
                    var cells = row.Cells.Cast<DataGridViewCell>();
                    sb.AppendLine(string.Join(",", cells.Select(cell => "\"" + cell.Value?.ToString() + "\"").ToArray()));
                }

                System.IO.File.WriteAllText(saveFileDialog.FileName, sb.ToString());
                MessageBox.Show("Data exported successfully!", "Export CSV", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StergeAngajat();
        }

        void StergeAngajat()
        {
            if (selectedRow == -1)
            {
                MessageBox.Show("Selectati un angajat pentru a-l sterge", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string strDelete = "DELETE FROM Pachete.tAngajati WHERE codAngajat = @codAngajat";
            try
            {
                using (SqlCommand cmd = new SqlCommand(strDelete, Global.con))
                {
                    cmd.Parameters.AddWithValue("@codAngajat", codAngajat);

                    Global.con.Open();
                    int n = cmd.ExecuteNonQuery(); //nr randuri afectate  

                    if (n > 0)
                    {
                        MessageBox.Show("Angajat Sters cu succes.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Global.dataSet.Tables["Angajati"].Rows.RemoveAt(selectedRow);
                        selectedRow = -1;
                    }
                    else
                    {
                        MessageBox.Show("CodAngajat inexistent", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare: Stergere\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Global.con.Close();
            }
        }

        private void Functie_DropDown_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

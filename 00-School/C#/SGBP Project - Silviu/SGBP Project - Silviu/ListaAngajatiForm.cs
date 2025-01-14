using System;
using System.Collections.Generic;
using System.Data;
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
        string codFunctie;

        public ListaAngajatiForm()
        {
            InitializeComponent();
        }

        private void ListaAngajati_GridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < ListaAngajati_GridView.Rows.Count)
            {
                numeAngajat = ListaAngajati_GridView.Rows[e.RowIndex].Cells[0].Value.ToString();
                functieAngajat = ListaAngajati_GridView.Rows[e.RowIndex].Cells[1].Value.ToString();
                codFunctie = ListaAngajati_GridView.Rows[e.RowIndex].Cells[3].Value.ToString();
                codAngajat = ListaAngajati_GridView.Rows[e.RowIndex].Cells[2].Value.ToString();
                Nume_TextBox.Text = numeAngajat;
                Functie_DropDown.Text = functieAngajat;

                selectedRow = e.RowIndex;
            }
        }

        private void ListaAngajati_GridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void ListaAngajatiForm_Load(object sender, EventArgs e)
        {
            ListaAngajati_GridView.ReadOnly = true;
            ListaAngajati_GridView.AllowUserToAddRows = false; //taie ultimul rand din GridView ca sa arate mai frumos

            Global.angajatiDataAdapter = new SqlDataAdapter(
                "select numeAngajat, B.functie, A.codAngajat, B.codFunctie from Pachete.tAngajati as A inner JOIN Pachete.tFunctii as B on A.codFunctie=B.codFunctie", Global.con);
            Global.angajatiDataAdapter.Fill(Global.dataSet, "Angajati");

            ListaAngajati_GridView.DataSource = Global.dataSet;
            ListaAngajati_GridView.DataMember = "Angajati";

            ListaAngajati_GridView.Columns[0].Width = ListaAngajati_GridView.Columns[0].Width;
            ListaAngajati_GridView.Columns[1].Width = ListaAngajati_GridView.Columns[0].Width * 2;

            AdaugaValoriLaListaDeFunctii(Functie_DropDown);
            AdaugaValoriLaListaDeFunctii(FunctieInsert_DropDown);

            ListaAngajati_GridView.ClearSelection(); // Clear selection after data binding
        }


        private void AdaugaValoriLaListaDeFunctii(ComboBox Functii)
        {
            Functii.Items.Clear();
            var uniqueFunctii = new HashSet<string>();
            int rowCount = ListaAngajati_GridView.Rows.Count;
            for (int i = 0; i < rowCount; i++)
            {
                if (ListaAngajati_GridView.Rows[i].Cells[1].Value != null)
                {
                    uniqueFunctii.Add(ListaAngajati_GridView.Rows[i].Cells[1].Value.ToString());
                }
            }
            foreach (var functie in uniqueFunctii)
            {
                Functii.Items.Add(functie);
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
                    else { MessageBox.Show("CodAngajat inexistent", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
            catch (Exception ex) { MessageBox.Show("Eroare: Stergere\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally
            {
                Global.con.Close();
                Nume_TextBox.Text = "";
                Functie_DropDown.Text = "";
                numeAngajat = "";
                functieAngajat = "";
            }
        }

        void AdaugaAngajat()
        {
            if (string.IsNullOrWhiteSpace(NumeAdd.Text) || string.IsNullOrWhiteSpace(FunctieInsert_DropDown.Text))
            {
                MessageBox.Show("Completati toate campurile pentru a adauga un angajat", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string connectionString = Global.con.ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //PROCEDURA STOCATA
                SqlCommand command = new SqlCommand("adaugaAngajat", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@NumeAngajat", NumeAdd.Text);
                command.Parameters.AddWithValue("@CodFunctie", GetCodFunctie(FunctieInsert_DropDown.Text));  // Example function ID

                connection.Open();

                try
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Angajat adăugat cu succes!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Eroare la inserare: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    Global.con.Close();
                    NumeAdd.Text = "";
                    FunctieInsert_DropDown.Text = "";

                    RefreshGridView();
                }
            }
        }

        void RefreshGridView()
        {
            Global.dataSet.Tables["Angajati"].Clear();
            Global.angajatiDataAdapter.Fill(Global.dataSet, "Angajati");
            ListaAngajati_GridView.DataSource = Global.dataSet.Tables["Angajati"];
            ListaAngajati_GridView.ClearSelection();
            selectedRow = -1;

            ListaAngajati_GridView.Columns[0].Width = ListaAngajati_GridView.Columns[0].Width;
            ListaAngajati_GridView.Columns[1].Width = ListaAngajati_GridView.Columns[0].Width * 2;
        }


        private int GetLastInsertedCodAngajat()
        {
            string query = "SELECT MAX(codAngajat) FROM Pachete.tAngajati";
            using (SqlCommand cmd = new SqlCommand(query, Global.con))
            {
                Global.con.Open();
                int codAngajat = (int)cmd.ExecuteScalar();
                Global.con.Close();
                return codAngajat;
            }
        }

        private int GetCodFunctie(string functie)
        {
            string query = "SELECT codFunctie FROM Pachete.tFunctii WHERE functie = @functie";
            using (SqlCommand cmd = new SqlCommand(query, Global.con))
            {
                cmd.Parameters.AddWithValue("@functie", functie);
                Global.con.Open();
                int codFunctie = (int)cmd.ExecuteScalar();
                Global.con.Close();
                return codFunctie;
            }
        }

        private void Functie_DropDown_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AddAngajat_Click(object sender, EventArgs e)
        {
            AdaugaAngajat();
        }

        private void NumeAdd_TextChanged(object sender, EventArgs e)
        {

        }
        private int GetSelectedDropdownValueIndex(ComboBox dropdown)
        {
            return dropdown.SelectedIndex;
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            StergeAngajat();
        }
    }
}

using EstateDataAccess.Repository.SqlRepository;
using EstateDataAccess;
using EstateModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;
using System.IO;
using System.Configuration;
using System.Diagnostics;

namespace EstateConsoleUI
{

    public partial class EstateForms : Form
    {
        static EstateRepository Estates = RepositoryFactory.CreateEstateRepository();
        private BindingList<Estate> estateList;

        public EstateForms()
        {
            InitializeComponent();
        }

        private void EstateForms_Load(object sender, EventArgs e)
        {
            listView1.View = View.LargeIcon;

            listView1.Columns.Add("Pictures", 300);
            listView1.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.HeaderSize);


            // Trebuie sa le bagam in BindingList ca sa functioneze sortarea listei de tip <Estate>
            estateList = new BindingList<Estate>(Estates.GetAll());
            estates_dataGridView.DataSource = estateList;

            //estates_dataGridView.Sort(estates_dataGridView.Columns["Name"], ListSortDirection.Ascending);
        }

        void ImportAndSavePicture()
        {
            // Open file dialog to select an image
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                openFileDialog.Title = "Select an Image to Import";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Get the selected file path
                    string selectedFilePath = openFileDialog.FileName;

                    // Define folder structure and file name
                    string folderPath = ConfigurationManager.AppSettings["PicturesFolderPath"];
                    string estateId = Upload_TextBox.Text;
                    string destinationFolder = Path.Combine(folderPath, estateId);

                    string pictureName = $"img-{Guid.NewGuid()}{Path.GetExtension(selectedFilePath)}";
                    string fullPath = Path.Combine(destinationFolder, pictureName);

                    if (!Directory.Exists(destinationFolder))
                    {
                        Directory.CreateDirectory(destinationFolder);
                    }

                    try
                    {
                        // Copy the file to folder
                        File.Copy(selectedFilePath, fullPath);

                        MessageBox.Show($"Picture imported and saved to: {fullPath}");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error saving picture: {ex.Message}");
                    }
                }
                else
                {
                    MessageBox.Show("No file selected.");
                }
            }
        }

        private void FilterEstateByPrice()
        {
            string filterBy = Filter_ComboBox.Text;
            string filterComparison = FilterComparison_ComboBox.Text;
            string filterValue = FilterValue_ComboBox.Text;

            double filterValueDouble;
            bool isNumeric = double.TryParse(filterValue, out filterValueDouble);

            estateList = new BindingList<Estate>(Estates.GetAll().Where(e =>
            {
                var propertyValue = GetPropertyValue(e, filterBy);
                if (propertyValue == null) return false;

                if (isNumeric && propertyValue is double)
                {
                    double estateValue = (double)propertyValue;
                    switch (filterComparison)
                    {
                        case ">":
                            return estateValue > filterValueDouble;
                        case "<":
                            return estateValue < filterValueDouble;
                        case "=":
                            return estateValue == filterValueDouble;
                        default:
                            return false;
                    }
                }
                else if (propertyValue is string)
                {
                    string estateValue = propertyValue.ToString();
                    return estateValue.Contains(filterValue);
                }
                return false;
            }).ToList());

            estates_dataGridView.DataSource = estateList;
        }

        private void SortEstatesBy()
        {
            string sortBy = Sort_ComboBox.Text;
            bool ascending = Order_ComboBox.Text == "Ascending";

            //1. Sortam mai intai.
            var sortedList = ascending
        ? estateList.OrderBy(e => GetPropertyValue(e, sortBy)).ToList()
        : estateList.OrderByDescending(e => GetPropertyValue(e, sortBy)).ToList();

            //2. Update the DataGridView.
            estateList = new BindingList<Estate>(sortedList);
            estates_dataGridView.DataSource = estateList;
        }

        private object GetPropertyValue(Estate estate, string propertyName)
        {
            return estate.GetType().GetProperty(propertyName)?.GetValue(estate, null);
        }

        private void Button_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(TextBox_Delete_Id.Text);
                Estates.Delete(id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TextBox_Delete_Id_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label_EstateName_Click(object sender, EventArgs e)
        {

        }

        private void Button_VisitEstate_Click(object sender, EventArgs e)
        {


            if (TextBox_SearchById.Text != null)
            {
                try
                {
                    int id = int.Parse(TextBox_SearchById.Text);
                    Estate estate = Estates.GetById(id);

                    if (estate != null)
                    {
                        Label_EstateName.Text = "Name: " + estate.Name;
                        Label_EstateAddress.Text = "Address: " + estate.Address;
                        Label_EstatePrice.Text = "Price: $" + estate.Price.ToString();
                        Label_CreateDate.Text = "Date: " + estate.CreateDate.ToString();

                        DisplayPictures(id);
                    }
                    else
                    {
                        MessageBox.Show("No estate found with the given ID.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void DisplayPictures(int id)
        {
            string folderPath = ConfigurationManager.AppSettings["PicturesFolderPath"];

            listView1.Items.Clear();
            ImageList imgs = new ImageList();
            imgs.ImageSize = new Size(256, 256);

            folderPath = $"{folderPath}\\{id}";

            String[] paths = Directory.GetFiles(folderPath);
            try
            {
                foreach (String path in paths)
                {
                    imgs.Images.Add(Image.FromFile(path));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            //ADD IMAGES TO LIST VIEW
            listView1.LargeImageList = imgs; // Use SmallImageList for smaller icons


            for (int i = 0; i < imgs.Images.Count; i++)
            {
                ListViewItem item = new ListViewItem();
                item.ImageIndex = i;
                listView1.Items.Add(item);
            }
        }

        private void TextBox_SearchById_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button_Update_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(TextBox_Update_Id.Text);
                Estate estate = Estates.GetById(id);

                if (estate != null)
                {
                    if (TextBox_Update_Id.Text != null)
                    {
                        if (TextBox_Update_Name.Text != "") estate.Name = TextBox_Update_Name.Text;

                        if (TextBox_Update_Address.Text != "") estate.Address = TextBox_Update_Address.Text;
                        if (TextBox_Update_Price.Text != "") estate.Price = double.Parse(TextBox_Update_Price.Text);
                    }

                    Estates.Update(estate);
                    MessageBox.Show("Estate updated successfully. Values updated.");

                    //Reluam noile informatii.
                    TextBox_SearchById.Text = TextBox_Update_Id.Text;
                    Button_VisitEstate_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("No estate found with the given ID.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Create_Click(object sender, EventArgs e)
        {
            try
            {

                Estates.Create(new Estate
                {
                    Name = TextBox_Create_Name.Text,
                    Address = TextBox_Create_Address.Text,
                    Price = double.Parse(TextBox_Create_Price.Text),
                    CreateDate = DateTime.Now
                });


                MessageBox.Show("Estate created successfully!");

                //Reluam noile informatii.
                Label_EstateName.Text = "Name: " + TextBox_Create_Name.Text;
                Label_EstateAddress.Text = "Address: " + TextBox_Create_Address.Text;
                Label_EstatePrice.Text = "Price: $" + TextBox_Create_Price.Text;
                Label_CreateDate.Text = "Date: " + DateTime.Now.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void estates_dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Order_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SortEstatesBy();
        }

        private void Sort_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SortEstatesBy();
        }

        private void UploadPicture_Button_Click(object sender, EventArgs e)
        {
            ImportAndSavePicture();
        }

        private void Filter_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterEstateByPrice();
        }

        private void FilterComparison_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterEstateByPrice();
        }

        private void FilterValue_ComboBox_TextChanged(object sender, EventArgs e)
        {
            FilterEstateByPrice();
        }
    }
}

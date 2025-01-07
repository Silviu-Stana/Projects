using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ad.UserInterface;
using ProductManagement.BusinessModel;
using ProductManagement.DataAccess.Repositories;

namespace ProductManagement.UserInterface
{
    public partial class Form1 : Form
    {
        int LoggedInUserId = 0;
        bool LoggedInIsAdmin = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void LoginUsernameInput_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var categoryRepository = new CategoryRepository();
            var categories = categoryRepository.GetAll();

            SearchCategory.Items.Add("None");
            foreach (var category in categories) SearchCategory.Items.Add(category);
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            if (UsernameInput.Text == "" || PasswordInput.Text == "")
            {
                MessageBox.Show("You must fill out both fields!");
                return;
            }

            var userRepository = new UserRepository();
            var user = userRepository.Login(UsernameInput.Text, PasswordInput.Text);

            if (user == null) { MessageBox.Show("Wrong email or password!"); }
            else OnLoginSuccess();
        }

        void OnLoginSuccess()
        {
            LoginPanel.Visible = false;
            SearchResultsPanel.Visible = true;
            UserButtonsPanel.Visible = true;

            var userRepository = new UserRepository();
            var user = userRepository.GetByName(UsernameInput.Text);
            if (user.IsAdmin == true)
            {
                RegisterUser.Enabled = true;
                RegisterUser.Visible = true;
                LoggedInIsAdmin = true;
                WelcomeText.Text = "Welcome back, Admin!";
            }
            else
            {
                RegisterUser.Enabled = false;
                RegisterUser.Visible = false;
                LoggedInIsAdmin = false;
                WelcomeText.Text = "Welcome back, " + UsernameInput.Text + "!";
            }

            LoggedInUserId = user.Id;
        }


        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void SEARCH_Click(object sender, EventArgs e)
        {
            SearchResults.Controls.Clear();
            SearchResult(SearchBox.Text);
            ShowOrHideListExportButtons();
        }

        void ShowOrHideListExportButtons()
        {
            if (SearchResults.Controls.Count > 0)
            {
                ExportJSON.Visible = true;
                ExportToCSV.Visible = true;
            }
            else
            {
                ExportJSON.Visible = false;
                ExportToCSV.Visible = false;
            }
        }


        void SearchResult(string keyword)
        {
            var adRepository = new ProductRepository();
            var ads = adRepository.GetByTitlePattern(keyword, SearchCategory.Text, OrderByBox.Text);

            foreach (var ad in ads)
            {
                var searchResult = new ProductSearchResult(ad.Id, LoggedInUserId, LoggedInIsAdmin, ad.IsDisabled);

                searchResult.Id = ad.Id;
                searchResult.Visible = true;
                searchResult.Title = ad.Title;
                searchResult.Description = ad.Description;
                searchResult.Price = ad.Price.ToString() + "$";
                searchResult.IsDisabled = ad.IsDisabled;
                searchResult.Brand = "Brand: " + ad.Brand;

                searchResult.ProductImage = GetFirstImage(ad.Id);

                SearchResults.Controls.Add(searchResult);
            }


        }

        Image GetFirstImage(int adId)
        {
            string folderPath = Path.Combine("Pictures", adId.ToString());
            if (Directory.Exists(folderPath))
            {
                var files = Directory.GetFiles(folderPath);
                if (files.Length > 0)
                {
                    using (var stream = new MemoryStream(File.ReadAllBytes(files[0])))
                    {
                        return Image.FromStream(stream);
                    }
                }
            }
            return null;
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void SearchBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SEARCH.PerformClick();

                // Prevent the "ding" sound when Enter is pressed
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void LogoutButton_Click(object sender, EventArgs e)
        {
            LoginPanel.Visible = true;
            SearchResultsPanel.Visible = false;
            UserButtonsPanel.Visible = false;

            LoggedInUserId = 0;
            LoggedInIsAdmin = false;

            SearchResults.Controls.Clear();
        }

        private void WelcomeText_Click(object sender, EventArgs e)
        {

        }

        private void SearchCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void SearchCategory_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void NewAdButton_Click(object sender, EventArgs e)
        {
            Create newForm = new Create(0, LoggedInUserId);
            newForm.Show();
        }

        private void RegisterUser_Click(object sender, EventArgs e)
        {
            Register newForm = new Register();
            newForm.Show();
        }

        private void SortBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ExportToCSV_Click(object sender, EventArgs e)
        {
            if (SearchResults.Controls.Count == 0) { MessageBox.Show("No search results to export."); return; }

            var csv = new StringBuilder();
            csv.AppendLine("Id,Title,Description,Price,Brand,IsDisabled");

            foreach (ProductSearchResult result in SearchResults.Controls)
            {
                var newLine = string.Format("{0},{1},{2},{3},{4},{5}",
                    result.Id,
                    result.Title,
                    result.Description,
                    result.Price,
                    result.Brand,
                    result.IsDisabled);
                csv.AppendLine(newLine);
            }

            var saveFileDialog = new SaveFileDialog
            {
                Filter = "CSV file (*.csv)|*.csv",
                FileName = "SearchResults.csv"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog.FileName, csv.ToString());
                MessageBox.Show("Export successful!");
            }
        }





        private void ExportJSON_Click(object sender, EventArgs e)
        {
            if (SearchResults.Controls.Count == 0) { MessageBox.Show("No search results to export."); return; }

            var results = new List<object>();

            foreach (ProductSearchResult result in SearchResults.Controls)
            {
                results.Add(new
                {
                    Id = result.Id,
                    Title = result.Title,
                    Description = result.Description,
                    Price = result.Price,
                    Brand = result.Brand,
                    IsDisabled = result.IsDisabled
                });
            }

            var json = Newtonsoft.Json.JsonConvert.SerializeObject(results, Newtonsoft.Json.Formatting.Indented);

            var saveFileDialog = new SaveFileDialog
            {
                Filter = "JSON file (*.json)|*.json",
                FileName = "SearchResults.json"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog.FileName, json);
                MessageBox.Show("Export successful!");
            }
        }
    }
}

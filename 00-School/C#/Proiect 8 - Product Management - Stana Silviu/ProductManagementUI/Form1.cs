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

        public Form1()
        {
            InitializeComponent();
        }

        private void LoginUsernameInput_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //foreach do:     SearchCategory.Items.Add(item.ToString());
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
            WelcomeText.Text = "Welcome back, " + UsernameInput.Text + "!";

            //Only an admin can do this
            RegisterUser.Enabled = false;
            RegisterUser.Visible = false;

            var userRepository = new UserRepository();
            var user = userRepository.GetByName(UsernameInput.Text);
            if (user.IsAdmin == true)
            {
                RegisterUser.Enabled = true;
                RegisterUser.Visible = true;
                WelcomeText.Text = "Welcome back, Admin!";
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
        }

        void SearchResult(string keyword)
        {
            var adRepository = new ProductRepository();
            var ads = adRepository.GetByTitlePattern(keyword, SearchCategory.Text);

            foreach (var ad in ads)
            {
                var searchResult = new ProductSearchResult(LoggedInUserId, 13);

                searchResult.Id = ad.Id;
                searchResult.Visible = true;
                searchResult.Title = ad.Title;
                searchResult.Description = ad.Description;
                searchResult.Price = ad.Price.ToString() + "$";

                searchResult.ProductImage = GetFirstImage(ad.Id);

                SearchResults.Controls.Add(searchResult);
            }

            //TODO
            //THE 2ND searchResult paramter should be the IsAdmin
            //throw new NotImplementedException();

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
    }
}

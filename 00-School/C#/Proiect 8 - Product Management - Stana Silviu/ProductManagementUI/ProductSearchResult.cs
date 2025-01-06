using ProductManagement.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductManagement.UserInterface
{
    public partial class ProductSearchResult : UserControl
    {
        public ProductSearchResult(int LoggedInUserId, int UserId)
        {
            InitializeComponent();

            if (UserId == LoggedInUserId)
            {
                EditButton.Visible = true;
                DeleteButton.Visible = true;
            }
        }

        private void Title_Click(object sender, EventArgs e)
        {
            Ad ad = new Ad(Id);
            ad.Show();
        }

        public Image ProductImage
        {
            get { return PictureBox.Image; }
            set { PictureBox.Image = value; }
        }

        public int Id { get; set; }
        public int UserId { get; set; }

        public string Title
        {
            get { return TitleLabel.Text; }
            set { TitleLabel.Text = value; }
        }

        public string Description
        {
            get { return DescriptionLabel.Text; }
            set { DescriptionLabel.Text = value; }
        }

        public string Price
        {
            get { return PriceLabel.Text; }
            set { PriceLabel.Text = value; }
        }

        private void AdCard_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AdSearchResult_Load(object sender, EventArgs e)
        {

        }

        private void AdCard_MouseClick(object sender, MouseEventArgs e)
        {
        }

        private void PictureBox_Click(object sender, EventArgs e)
        {
            Ad ad = new Ad(Id);
            ad.Show();
        }

        private void PriceLabel_Click(object sender, EventArgs e)
        {
            Ad ad = new Ad(Id);
            ad.Show();
        }

        private void DescriptionLabel_Click(object sender, EventArgs e)
        {
            Ad ad = new Ad(Id);
            ad.Show();
        }

        private void AdCard_MouseDown(object sender, MouseEventArgs e)
        {
            Ad ad = new Ad(Id);
            ad.Show();
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            Create editAd = new Create(Id, UserId);
            editAd.Show();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            var adRepository = new ProductRepository();
            adRepository.Delete(Id);

            this.Dispose();
        }
    }
}

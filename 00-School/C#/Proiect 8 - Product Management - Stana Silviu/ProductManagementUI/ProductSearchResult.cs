using Ad.UserInterface;
using ProductManagement.BusinessModel;
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
        public Delete form;
        int ProductIdIs = 0, UserIdIs = 0;
        bool IsAdminLoggedIn = false;

        public ProductSearchResult(int productId, int userId, bool IsAdmin, bool isDisabled)
        {
            InitializeComponent();

            GetAverageUserRatingForProduct(productId);

            EditButton.Visible = true;
            if (IsAdmin)
            {
                DeleteButton.Visible = true;
                IsAdminLoggedIn = true;
            }

            ProductIdIs = productId;
            UserIdIs = userId;

            if (isDisabled) OnDisable();
            else OnEnable();

        }

        void GetAverageUserRatingForProduct(int productId)
        {
            var ratingRepository = new ProductRatingRepository();
            var rating = ratingRepository.GetAverageRating(productId);
            if (rating == 0) AvgRating.Text = "No ratings yet";
            else AvgRating.Text = "Average rating: " + rating.ToString("F1"); // Ensure floating point number with precision 1
        }

        public Image ProductImage
        {
            get { return PictureBox.Image; }
            set { PictureBox.Image = value; }
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public bool IsDisabled { get; set; }

        public string Title
        {
            get { return TitleLabel.Text; }
            set { TitleLabel.Text = value; }
        }

        public string Brand
        {
            get { return BrandLabel.Text; }
            set { BrandLabel.Text = value; }
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

        public void OpenProductWindow(object sender, EventArgs e)
        {

        }

        private void Title_Click(object sender, EventArgs e)
        {
            OpenProductInfoPage();
        }

        private void PictureBox_Click(object sender, EventArgs e)
        {
            OpenProductInfoPage();
        }

        private void PriceLabel_Click(object sender, EventArgs e)
        {
            OpenProductInfoPage();
        }

        private void DescriptionLabel_Click(object sender, EventArgs e)
        {
            OpenProductInfoPage();
        }

        private void AdCard_MouseDown(object sender, MouseEventArgs e)
        {
            OpenProductInfoPage();
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            Create editAd = new Create(ProductIdIs, UserIdIs);
            editAd.Show();
        }

        void OpenProductInfoPage()
        {
            Ad ad = new Ad(ProductIdIs, UserIdIs);
            ad.RatingChanged += (s, args) => GetAverageUserRatingForProduct(ProductIdIs);
            ad.Show();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            form = new Delete(Id);
            form.Show();

            form.ProductDeleted += (s, args) => OnDelete();
            form.ProductDisabled += (s, args) => OnDisable();
        }

        private void Enable_Click(object sender, EventArgs e)
        {

            OnEnable();
        }

        void OnDelete()
        {
            this.Dispose();
        }

        void OnEnable()
        {
            AdCard.BackColor = Color.White;
            TitleLabel.ForeColor = Color.Black;
            DescriptionLabel.ForeColor = Color.Black;
            PriceLabel.ForeColor = Color.Black;
            PictureBox.BackColor = Color.White;

            Enable.Visible = false;
            if (IsAdminLoggedIn) DeleteButton.Visible = true;

            var productRepository = new ProductRepository();
            var product = productRepository.GetById(ProductIdIs);
            product.IsDisabled = false;
            productRepository.Update(product);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        void OnDisable()
        {
            AdCard.BackColor = Color.LightGray;
            TitleLabel.ForeColor = Color.Gray;
            DescriptionLabel.ForeColor = Color.Gray;
            PriceLabel.ForeColor = Color.Gray;
            PictureBox.BackColor = Color.DarkGray;

            Enable.Visible = true;
            DeleteButton.Visible = false;
        }


    }
}

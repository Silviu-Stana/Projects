using ProductManagement.BusinessModel;
using ProductManagement.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductManagement.UserInterface
{
    public partial class Ad : Form
    {
        ProductRatingRepository ratingRepository = new ProductRatingRepository();
        ProductEvaluation rating;
        int UserIdIs, ProductIdIs;


        public Ad(int ProductId, int UserId)
        {
            InitializeComponent();

            UserIdIs = UserId;
            ProductIdIs = ProductId;

            LoadAdData(ProductId, UserId);
        }

        private async void LoadAdData(int ProductId, int UserId)
        {
            var pictureRepository = new PictureRepository();
            var picture = await Task.Run(() => pictureRepository.GetById(ProductId));

            var adRepository = new ProductRepository();
            var ad = await Task.Run(() => adRepository.GetById(ProductId));

            TitleLabel.Text = ad.Title;
            DescriptionLabel.Text = ad.Description;
            PriceLabel.Text = "Price: $" + ad.Price.ToString();
            BrandLabel.Text = "Brand: " + ad.Brand;
            FabricationDateLabel.Text = "Fabrication date: " + ad.FabricationDate.ToString("dd/MM/yyyy");


            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.FlowDirection = FlowDirection.LeftToRight;
            flowLayoutPanel1.WrapContents = false;

            rating = ratingRepository.GetById(ProductId, UserId);

            if (rating != null) Rate.Text = rating.Value.ToString();

            DisplayAllPictures(ProductId);
        }

        void DisplayAllPictures(int adId)
        {
            string folderPath = Path.Combine("Pictures", adId.ToString());
            if (Directory.Exists(folderPath))
            {
                var files = Directory.GetFiles(folderPath);
                for (int i = 0; i < files.Length; i++)
                {
                    PictureComponent pic = new PictureComponent
                    {
                        ProductImage = Image.FromFile(files[i])
                    };
                    flowLayoutPanel1.Controls.Add(pic);
                }
            }

            Rate.Parent.Focus(); // Unfocus Rating textbox
        }



        private void TitleLabel_Click(object sender, EventArgs e)
        {
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DescriptionLabel_Click(object sender, EventArgs e)
        {

        }

        private void PriceLabel_Click(object sender, EventArgs e)
        {

        }

        private void Ad_Load(object sender, EventArgs e)
        {

        }

        private void Rate_TextChanged(object sender, EventArgs e)
        {

        }

        public event EventHandler RatingChanged;

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void FabricationDateLabel_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (int.TryParse(Rate.Text, out int ratingValue) && ratingValue >= 1 && ratingValue <= 5)
            {
                RatingChanged?.Invoke(this, EventArgs.Empty);

                if (rating == null)
                {
                    ratingRepository.Create(new ProductEvaluation { UserId = UserIdIs, ProductId = ProductIdIs, Value = ratingValue });
                    MessageBox.Show($"product:{ProductIdIs}, user:{UserIdIs}");
                }
                else
                {
                    rating.Value = ratingValue;
                    ratingRepository.Update(rating);
                }
                Rate.Parent.Focus(); // Unfocus Rating textbox
            }
            else
            {
                MessageBox.Show("INVALID RATING\n(give one from 1 to 5)");
                Rate.Text = "";
                Rate.Parent.Focus(); // Unfocus Rating textbox
            }
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            RatingChanged = null;
        }

    }
}

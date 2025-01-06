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
        public Ad(int AdId)
        {
            InitializeComponent();

            LoadAdData(AdId);
        }

        private async void LoadAdData(int AdId)
        {
            var pictureRepository = new PictureRepository();
            var picture = await Task.Run(() => pictureRepository.GetById(AdId));

            var adRepository = new ProductRepository();
            var ad = await Task.Run(() => adRepository.GetById(AdId));

            TitleLabel.Text = ad.Title;
            DescriptionLabel.Text = ad.Description;
            PriceLabel.Text = "Price: $" + ad.Price.ToString();

            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.FlowDirection = FlowDirection.LeftToRight;
            flowLayoutPanel1.WrapContents = false;

            DisplayAllPictures(AdId);
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
    }
}

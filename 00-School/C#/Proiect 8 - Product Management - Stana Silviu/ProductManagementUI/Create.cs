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
    public partial class Create : Form
    {
        bool isEditMode = false;
        int UserIdIs = 0, ProductIdIs = 0;

        public Create(int ProductId, int UserId)
        {
            InitializeComponent();

            LoadCategoriesList();

            UserIdIs = UserId;
            ProductIdIs = ProductId;

            if (ProductId > 0) isEditMode = true;

            if (isEditMode) LoadAdData(ProductId);

        }

        private async void LoadAdData(int AdId)
        {
            var pictureRepository = new PictureRepository();
            var picture = await Task.Run(() => pictureRepository.GetById(AdId));

            var productRepository = new ProductRepository();
            var product = await Task.Run(() => productRepository.GetById(AdId));

            TitleBox.Text = product.Title;
            DescBox.Text = product.Description;
            PriceBox.Text = product.Price.ToString();
            BrandBox.Text = product.Brand.ToString();
            DateTimePicker.Value = product.FabricationDate;
            //SearchCategory.Text = ad.Category.ToString();

            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.FlowDirection = FlowDirection.LeftToRight;
            flowLayoutPanel1.WrapContents = false;

            DisplayAllPictures(AdId);

            EnableCheckboxForSavedCategories();
        }

        void LoadCategoriesList()
        {
            var categoryRepository = new CategoryRepository();
            var categories = categoryRepository.GetAll();

            Categories.Items.Clear(); // Clear existing items

            foreach (var category in categories)
            {
                Categories.Items.Add(new CategoryModel { CategoryName = category.CategoryName, Id = category.Id }, false);
            }
        }

        void DisplayAllPictures(int adId)
        {
            string folderPath = Path.Combine("Pictures", adId.ToString());
            if (Directory.Exists(folderPath))
            {
                var files = Directory.GetFiles(folderPath);
                for (int i = 0; i < files.Length; i++)
                {
                    //MemoryStream PREVENTS ERRORS WHEN COPYING FROM ONE DIRECTORY TO ANOTHER
                    using (var stream = new MemoryStream(File.ReadAllBytes(files[i])))
                    {
                        PictureComponent pic = new PictureComponent
                        {
                            ProductImage = Image.FromStream(stream)
                        };
                        flowLayoutPanel1.Controls.Add(pic);
                    }
                }
            }
        }

        bool HaveAtLeast1Picture()
        {
            return flowLayoutPanel1.Controls.Count > 0;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Create_Load(object sender, EventArgs e)
        {
            //foreach do:    SearchCategory.Items.Add(item.ToString());
        }

        private void Publish_Click(object sender, EventArgs e)
        {
            if (!HaveAtLeast1Picture())
            {
                MessageBox.Show("You must have at least 1 picture!");
                return;
            }

            if (TitleBox.Text.Length < 2)
            {
                MessageBox.Show("TITLE Required!");
                return;
            }

            if (DescBox.Text.Length < 1)
            {
                MessageBox.Show("DESCRIPTION Required");
                return;
            }

            if (PriceBox.Text.Length < 1)
            {
                MessageBox.Show("PRICE Required");
                return;
            }

            if (BrandBox.Text.Length < 1)
            {
                MessageBox.Show("BRAND name Required");
                return;
            }

            if (Categories.CheckedItems.Count == 0)
            {
                MessageBox.Show("You must select at least 1 CATEGORY");
                return;
            }

            if (!decimal.TryParse(PriceBox.Text, out decimal price) || price > 99999999.99m)
            {
                MessageBox.Show("PRICE must be LESS than 1 Billion DOLLARS\n(haha)");
                return;
            }


            if (isEditMode)
            {
                UpdateProduct();
            }
            else
            {
                CreateProduct();
            }
        }

        private async void UpdateProduct()
        {
            var adRepository = new ProductRepository();

            var ad = new ProductModel()
            {
                Id = ProductIdIs,
                Title = TitleBox.Text,
                Description = DescBox.Text,
                Price = Convert.ToDouble(PriceBox.Text),
                FabricationDate = DateTimePicker.Value,
                Brand = BrandBox.Text,
            };
            await Task.Run(() => adRepository.Update(ad));


            SaveProductCategoryToDatabase();

            this.Close();
        }

        void SaveProductCategoryToDatabase()
        {
            // Delete all categories (of this product) from the database
            var productCategoryRepository = new ProductCategoryRepository();
            productCategoryRepository.Delete(ProductIdIs);

            // Re-add all categories back to the product
            var selectedCategoryIds = GetSelectedCategoryIds();
            foreach (int id in selectedCategoryIds)
            {
                productCategoryRepository.Create(new ProductCategory { CategoryId = id, ProductId = ProductIdIs });
            }
        }

        void EnableCheckboxForSavedCategories()
        {
            var productCategoryRepository = new ProductCategoryRepository();
            var productCategories = productCategoryRepository.GetAllById(ProductIdIs);

            List<int> selectedCategoryIds = new List<int>();

            foreach (var item in productCategories)
            {
                selectedCategoryIds.Add(item.CategoryId);
            }

            // Copy the items to a list to prevent InvalidOperationException
            var itemsCopy = Categories.Items.Cast<object>().ToList();

            foreach (var item in itemsCopy)
            {
                var category = item as CategoryModel;
                if (category != null && selectedCategoryIds.Contains(category.Id))
                {
                    Categories.SetItemChecked(Categories.Items.IndexOf(category), true);
                }
            }
        }

        private List<int> GetSelectedCategoryIds()
        {
            List<int> selectedCategoryIds = new List<int>();

            foreach (var item in Categories.CheckedItems)
            {
                var category = item as CategoryModel;

                if (category != null) selectedCategoryIds.Add(category.Id);
                //MessageBox.Show(category.Id.ToString());
            }

            return selectedCategoryIds;
        }

        private async void CreateProduct()
        {
            var adRepository = new ProductRepository();

            var ad = new ProductModel()
            {
                Id = 0,
                Title = TitleBox.Text,
                Description = DescBox.Text,
                Price = Convert.ToDouble(PriceBox.Text),
                FabricationDate = DateTimePicker.Value,
                Brand = BrandBox.Text,
            };

            ProductModel NewlyCreatedAdd = new ProductModel();
            NewlyCreatedAdd = await Task.Run(() => adRepository.Create(ad));

            ProductIdIs = NewlyCreatedAdd.Id;

            // Copy pictures from Temp folder to Pictures/{AdId}
            SaveUploadedPictures();

            SaveProductCategoryToDatabase();

            this.Close();
        }

        void SaveUploadedPictures()
        {

            string tempDirectory = Path.Combine("Pictures", "Temp", UserIdIs.ToString());
            string targetDirectory = Path.Combine("Pictures", ProductIdIs.ToString());

            if (Directory.Exists(tempDirectory))
            {
                if (!Directory.Exists(targetDirectory)) Directory.CreateDirectory(targetDirectory);

                var files = Directory.GetFiles(tempDirectory);
                foreach (var file in files)
                {
                    string fileName = Path.GetFileName(file);
                    string destFile = Path.Combine(targetDirectory, fileName);


                    File.Move(file, destFile);
                }

                flowLayoutPanel1.Controls.Clear();
                Directory.Delete(tempDirectory, true);
            }
        }

        private void UploadPicture_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files (*.jpg;*.png)|*.jpg;*.png";
                openFileDialog.Multiselect = false;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedFilePath = openFileDialog.FileName;
                    int userId = UserIdIs;
                    string guid = Guid.NewGuid().ToString();
                    string fileExtension = Path.GetExtension(selectedFilePath);
                    string targetDirectory = Path.Combine("Pictures", "Temp", userId.ToString());
                    string targetFileName = $"{guid}{fileExtension}";
                    string targetFilePath = Path.Combine(targetDirectory, targetFileName);

                    if (!Directory.Exists(targetDirectory))
                    {
                        Directory.CreateDirectory(targetDirectory);
                    }

                    File.Copy(selectedFilePath, targetFilePath);

                    //MEMORY STREAM TO PREVENT ERRORS WHEN COPYING FROM ONE DIRECTORY TO ANOTHER
                    using (var stream = new MemoryStream(File.ReadAllBytes(targetFilePath)))
                    {
                        PictureComponent pic = new PictureComponent
                        {
                            ProductImage = Image.FromStream(stream)
                        };
                        flowLayoutPanel1.Controls.Add(pic);
                    }
                }
            }
        }

        private void PriceBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void PriceBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow (delete)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Block non-numeric input
            }
        }


        private void BrandBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void PhoneBox_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Categories_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void SearchCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

    }
}

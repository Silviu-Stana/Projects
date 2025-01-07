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

namespace Ad.UserInterface
{
    public partial class Delete : Form
    {
        int IdOfProductToDelete = 0;

        public Delete(int ProductId)
        {
            InitializeComponent();
            IdOfProductToDelete = ProductId;
        }

        private void Delete_Load(object sender, EventArgs e)
        {

        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            UnsubscribeAllListeners();
            this.Close();
        }

        void UnsubscribeAllListeners()
        {
            ProductDeleted = null;
            ProductDisabled = null;
        }

        public event EventHandler ProductDeleted;
        public event EventHandler ProductDisabled;

        private void Disable_Click(object sender, EventArgs e)
        {
            var productRepository = new ProductRepository();
            var product = productRepository.GetById(IdOfProductToDelete);
            product.IsDisabled = true;
            productRepository.Update(product);

            ProductDisabled?.Invoke(this, EventArgs.Empty);
            UnsubscribeAllListeners();
            this.Close();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            UnsubscribeAllListeners();
            base.OnFormClosing(e);
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            var productRepository = new ProductRepository();
            productRepository.Delete(IdOfProductToDelete);
            ProductDeleted?.Invoke(this, EventArgs.Empty);
            UnsubscribeAllListeners();
            this.Close();
        }
    }
}

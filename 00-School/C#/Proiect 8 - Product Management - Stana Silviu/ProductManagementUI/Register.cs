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
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        void OnRegisterSuccess()
        {
            var userRepository = new UserRepository();
            var user = userRepository.Register(UsernameInput.Text, PasswordInput.Text);

            MessageBox.Show("Register Success!");
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            if (UsernameInput.Text == "" || PasswordInput.Text == "")
            {
                MessageBox.Show("You must fill out both fields!");
                return;
            }

            var userRepository = new UserRepository();
            var user = userRepository.GetByName(UsernameInput.Text);

            if (user == null)
            {
                MessageBox.Show("Register Success!");
                OnRegisterSuccess();
            }
            else MessageBox.Show("Username already exists!");
        }
    }
}

namespace ProductManagement.UserInterface
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.UsernameInput = new System.Windows.Forms.TextBox();
            this.PasswordInput = new System.Windows.Forms.TextBox();
            this.LoginText = new System.Windows.Forms.Label();
            this.LoginTextPassword = new System.Windows.Forms.Label();
            this.LoginButton = new System.Windows.Forms.Button();
            this.LoginPanel = new System.Windows.Forms.Panel();
            this.LogoutButton = new System.Windows.Forms.Button();
            this.NewProductButton = new System.Windows.Forms.Button();
            this.WelcomeText = new System.Windows.Forms.Label();
            this.SEARCH = new System.Windows.Forms.Button();
            this.SearchBox = new System.Windows.Forms.TextBox();
            this.SearchResults = new System.Windows.Forms.FlowLayoutPanel();
            this.SearchResultsPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.SearchCategory = new System.Windows.Forms.ComboBox();
            this.UserButtonsPanel = new System.Windows.Forms.Panel();
            this.RegisterUser = new System.Windows.Forms.Button();
            this.LoginPanel.SuspendLayout();
            this.SearchResultsPanel.SuspendLayout();
            this.UserButtonsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // UsernameInput
            // 
            this.UsernameInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsernameInput.Location = new System.Drawing.Point(7, 79);
            this.UsernameInput.Name = "UsernameInput";
            this.UsernameInput.Size = new System.Drawing.Size(293, 30);
            this.UsernameInput.TabIndex = 0;
            this.UsernameInput.TextChanged += new System.EventHandler(this.LoginUsernameInput_TextChanged);
            // 
            // PasswordInput
            // 
            this.PasswordInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordInput.Location = new System.Drawing.Point(7, 163);
            this.PasswordInput.Name = "PasswordInput";
            this.PasswordInput.Size = new System.Drawing.Size(293, 30);
            this.PasswordInput.TabIndex = 1;
            // 
            // LoginText
            // 
            this.LoginText.AutoSize = true;
            this.LoginText.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginText.Location = new System.Drawing.Point(2, 47);
            this.LoginText.Name = "LoginText";
            this.LoginText.Size = new System.Drawing.Size(124, 29);
            this.LoginText.TabIndex = 2;
            this.LoginText.Text = "Username";
            // 
            // LoginTextPassword
            // 
            this.LoginTextPassword.AutoSize = true;
            this.LoginTextPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginTextPassword.Location = new System.Drawing.Point(2, 131);
            this.LoginTextPassword.Name = "LoginTextPassword";
            this.LoginTextPassword.Size = new System.Drawing.Size(120, 29);
            this.LoginTextPassword.TabIndex = 3;
            this.LoginTextPassword.Text = "Password";
            // 
            // LoginButton
            // 
            this.LoginButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.LoginButton.FlatAppearance.BorderSize = 5;
            this.LoginButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginButton.Location = new System.Drawing.Point(7, 216);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(139, 65);
            this.LoginButton.TabIndex = 4;
            this.LoginButton.Text = "Login";
            this.LoginButton.UseVisualStyleBackColor = false;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // LoginPanel
            // 
            this.LoginPanel.Controls.Add(this.UsernameInput);
            this.LoginPanel.Controls.Add(this.PasswordInput);
            this.LoginPanel.Controls.Add(this.LoginText);
            this.LoginPanel.Controls.Add(this.LoginTextPassword);
            this.LoginPanel.Controls.Add(this.LoginButton);
            this.LoginPanel.Location = new System.Drawing.Point(873, 209);
            this.LoginPanel.Name = "LoginPanel";
            this.LoginPanel.Size = new System.Drawing.Size(308, 330);
            this.LoginPanel.TabIndex = 10;
            // 
            // LogoutButton
            // 
            this.LogoutButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.LogoutButton.FlatAppearance.BorderSize = 5;
            this.LogoutButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogoutButton.Location = new System.Drawing.Point(1005, 6);
            this.LogoutButton.Name = "LogoutButton";
            this.LogoutButton.Size = new System.Drawing.Size(139, 39);
            this.LogoutButton.TabIndex = 10;
            this.LogoutButton.Text = "Logout";
            this.LogoutButton.UseVisualStyleBackColor = false;
            this.LogoutButton.Click += new System.EventHandler(this.LogoutButton_Click);
            // 
            // NewProductButton
            // 
            this.NewProductButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.NewProductButton.FlatAppearance.BorderSize = 5;
            this.NewProductButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewProductButton.Location = new System.Drawing.Point(815, 6);
            this.NewProductButton.Name = "NewProductButton";
            this.NewProductButton.Size = new System.Drawing.Size(171, 39);
            this.NewProductButton.TabIndex = 11;
            this.NewProductButton.Text = "+ New Product";
            this.NewProductButton.UseVisualStyleBackColor = false;
            this.NewProductButton.Click += new System.EventHandler(this.NewAdButton_Click);
            // 
            // WelcomeText
            // 
            this.WelcomeText.AutoSize = true;
            this.WelcomeText.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WelcomeText.Location = new System.Drawing.Point(23, 9);
            this.WelcomeText.Name = "WelcomeText";
            this.WelcomeText.Size = new System.Drawing.Size(363, 36);
            this.WelcomeText.TabIndex = 13;
            this.WelcomeText.Text = "Welcome back, username!";
            this.WelcomeText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.WelcomeText.Click += new System.EventHandler(this.WelcomeText_Click);
            // 
            // SEARCH
            // 
            this.SEARCH.BackColor = System.Drawing.SystemColors.ControlLight;
            this.SEARCH.FlatAppearance.BorderSize = 5;
            this.SEARCH.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SEARCH.Location = new System.Drawing.Point(556, 39);
            this.SEARCH.Name = "SEARCH";
            this.SEARCH.Size = new System.Drawing.Size(139, 39);
            this.SEARCH.TabIndex = 14;
            this.SEARCH.Text = "SEARCH";
            this.SEARCH.UseVisualStyleBackColor = false;
            this.SEARCH.Click += new System.EventHandler(this.SEARCH_Click);
            // 
            // SearchBox
            // 
            this.SearchBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchBox.Location = new System.Drawing.Point(15, 41);
            this.SearchBox.Name = "SearchBox";
            this.SearchBox.Size = new System.Drawing.Size(356, 38);
            this.SearchBox.TabIndex = 10;
            this.SearchBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SearchBox_KeyDown);
            // 
            // SearchResults
            // 
            this.SearchResults.AutoScroll = true;
            this.SearchResults.Location = new System.Drawing.Point(15, 112);
            this.SearchResults.Name = "SearchResults";
            this.SearchResults.Size = new System.Drawing.Size(775, 736);
            this.SearchResults.TabIndex = 16;
            this.SearchResults.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel1_Paint);
            // 
            // SearchResultsPanel
            // 
            this.SearchResultsPanel.Controls.Add(this.label1);
            this.SearchResultsPanel.Controls.Add(this.SearchCategory);
            this.SearchResultsPanel.Controls.Add(this.SearchResults);
            this.SearchResultsPanel.Controls.Add(this.SearchBox);
            this.SearchResultsPanel.Controls.Add(this.SEARCH);
            this.SearchResultsPanel.Location = new System.Drawing.Point(27, 67);
            this.SearchResultsPanel.Name = "SearchResultsPanel";
            this.SearchResultsPanel.Size = new System.Drawing.Size(834, 872);
            this.SearchResultsPanel.TabIndex = 17;
            this.SearchResultsPanel.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label1.Location = new System.Drawing.Point(374, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 18);
            this.label1.TabIndex = 18;
            this.label1.Text = "Product Category";
            // 
            // SearchCategory
            // 
            this.SearchCategory.DropDownWidth = 200;
            this.SearchCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchCategory.FormattingEnabled = true;
            this.SearchCategory.ItemHeight = 29;
            this.SearchCategory.Location = new System.Drawing.Point(377, 41);
            this.SearchCategory.Name = "SearchCategory";
            this.SearchCategory.Size = new System.Drawing.Size(173, 37);
            this.SearchCategory.TabIndex = 17;
            this.SearchCategory.SelectedIndexChanged += new System.EventHandler(this.SearchCategory_SelectedIndexChanged);
            this.SearchCategory.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SearchCategory_KeyPress);
            // 
            // UserButtonsPanel
            // 
            this.UserButtonsPanel.Controls.Add(this.RegisterUser);
            this.UserButtonsPanel.Controls.Add(this.WelcomeText);
            this.UserButtonsPanel.Controls.Add(this.LogoutButton);
            this.UserButtonsPanel.Controls.Add(this.NewProductButton);
            this.UserButtonsPanel.Location = new System.Drawing.Point(13, 13);
            this.UserButtonsPanel.Name = "UserButtonsPanel";
            this.UserButtonsPanel.Size = new System.Drawing.Size(1168, 48);
            this.UserButtonsPanel.TabIndex = 18;
            this.UserButtonsPanel.Visible = false;
            // 
            // RegisterUser
            // 
            this.RegisterUser.BackColor = System.Drawing.SystemColors.ControlLight;
            this.RegisterUser.FlatAppearance.BorderSize = 5;
            this.RegisterUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RegisterUser.Location = new System.Drawing.Point(391, 6);
            this.RegisterUser.Name = "RegisterUser";
            this.RegisterUser.Size = new System.Drawing.Size(232, 39);
            this.RegisterUser.TabIndex = 14;
            this.RegisterUser.Text = "Register New User";
            this.RegisterUser.UseVisualStyleBackColor = false;
            this.RegisterUser.Visible = false;
            this.RegisterUser.Click += new System.EventHandler(this.RegisterUser_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1290, 935);
            this.Controls.Add(this.LoginPanel);
            this.Controls.Add(this.SearchResultsPanel);
            this.Controls.Add(this.UserButtonsPanel);
            this.Name = "Form1";
            this.Text = "ACCOUNT PAGE";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.LoginPanel.ResumeLayout(false);
            this.LoginPanel.PerformLayout();
            this.SearchResultsPanel.ResumeLayout(false);
            this.SearchResultsPanel.PerformLayout();
            this.UserButtonsPanel.ResumeLayout(false);
            this.UserButtonsPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox UsernameInput;
        private System.Windows.Forms.TextBox PasswordInput;
        private System.Windows.Forms.Label LoginText;
        private System.Windows.Forms.Label LoginTextPassword;
        private System.Windows.Forms.Button LoginButton;
        private System.Windows.Forms.Panel LoginPanel;
        private System.Windows.Forms.Button LogoutButton;
        private System.Windows.Forms.Button NewProductButton;
        private System.Windows.Forms.Label WelcomeText;
        private System.Windows.Forms.Button SEARCH;
        private System.Windows.Forms.TextBox SearchBox;
        private System.Windows.Forms.FlowLayoutPanel SearchResults;
        private System.Windows.Forms.Panel SearchResultsPanel;
        private System.Windows.Forms.Panel UserButtonsPanel;
        private System.Windows.Forms.ComboBox SearchCategory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button RegisterUser;
    }
}


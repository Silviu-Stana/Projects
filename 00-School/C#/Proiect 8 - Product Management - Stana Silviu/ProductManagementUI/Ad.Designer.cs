namespace ProductManagement.UserInterface
{
    partial class Ad
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
            this.TitleLabel = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.DescriptionLabel = new System.Windows.Forms.Label();
            this.PriceLabel = new System.Windows.Forms.Label();
            this.PhoneLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Rate = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.BrandLabel = new System.Windows.Forms.Label();
            this.FabricationDateLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TitleLabel
            // 
            this.TitleLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.TitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLabel.Location = new System.Drawing.Point(304, 25);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(218, 29);
            this.TitleLabel.TabIndex = 11;
            this.TitleLabel.Text = "Your Ad Title Here!";
            this.TitleLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.TitleLabel.Click += new System.EventHandler(this.TitleLabel_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(33, 68);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(811, 237);
            this.flowLayoutPanel1.TabIndex = 12;
            this.flowLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel1_Paint);
            // 
            // DescriptionLabel
            // 
            this.DescriptionLabel.AutoSize = true;
            this.DescriptionLabel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.DescriptionLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DescriptionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DescriptionLabel.Location = new System.Drawing.Point(33, 320);
            this.DescriptionLabel.Name = "DescriptionLabel";
            this.DescriptionLabel.Size = new System.Drawing.Size(198, 26);
            this.DescriptionLabel.TabIndex = 13;
            this.DescriptionLabel.Text = "Your Description Here";
            this.DescriptionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.DescriptionLabel.Click += new System.EventHandler(this.DescriptionLabel_Click);
            // 
            // PriceLabel
            // 
            this.PriceLabel.AutoSize = true;
            this.PriceLabel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.PriceLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PriceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PriceLabel.Location = new System.Drawing.Point(31, 358);
            this.PriceLabel.Name = "PriceLabel";
            this.PriceLabel.Size = new System.Drawing.Size(61, 33);
            this.PriceLabel.TabIndex = 14;
            this.PriceLabel.Text = "$$$";
            this.PriceLabel.Click += new System.EventHandler(this.PriceLabel_Click);
            // 
            // PhoneLabel
            // 
            this.PhoneLabel.AutoSize = true;
            this.PhoneLabel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.PhoneLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PhoneLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PhoneLabel.Location = new System.Drawing.Point(31, 400);
            this.PhoneLabel.Name = "PhoneLabel";
            this.PhoneLabel.Size = new System.Drawing.Size(166, 33);
            this.PhoneLabel.TabIndex = 15;
            this.PhoneLabel.Text = "0700000000";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(591, 320);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(214, 29);
            this.label1.TabIndex = 16;
            this.label1.Text = "Rate Product: (1-5)";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Rate
            // 
            this.Rate.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F);
            this.Rate.Location = new System.Drawing.Point(596, 358);
            this.Rate.Name = "Rate";
            this.Rate.Size = new System.Drawing.Size(45, 40);
            this.Rate.TabIndex = 18;
            this.Rate.TextChanged += new System.EventHandler(this.Rate_TextChanged);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Gold;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.button1.Location = new System.Drawing.Point(647, 359);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(145, 41);
            this.button1.TabIndex = 19;
            this.button1.Text = "Save Rating";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // BrandLabel
            // 
            this.BrandLabel.AutoSize = true;
            this.BrandLabel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BrandLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BrandLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BrandLabel.Location = new System.Drawing.Point(33, 446);
            this.BrandLabel.Name = "BrandLabel";
            this.BrandLabel.Size = new System.Drawing.Size(88, 33);
            this.BrandLabel.TabIndex = 20;
            this.BrandLabel.Text = "Brand";
            this.BrandLabel.Click += new System.EventHandler(this.label2_Click);
            // 
            // FabricationDateLabel
            // 
            this.FabricationDateLabel.AutoSize = true;
            this.FabricationDateLabel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.FabricationDateLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FabricationDateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FabricationDateLabel.Location = new System.Drawing.Point(33, 488);
            this.FabricationDateLabel.Name = "FabricationDateLabel";
            this.FabricationDateLabel.Size = new System.Drawing.Size(231, 33);
            this.FabricationDateLabel.TabIndex = 21;
            this.FabricationDateLabel.Text = "Fabrication Date: ";
            this.FabricationDateLabel.Click += new System.EventHandler(this.FabricationDateLabel_Click);
            // 
            // Ad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 590);
            this.Controls.Add(this.FabricationDateLabel);
            this.Controls.Add(this.BrandLabel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Rate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.PhoneLabel);
            this.Controls.Add(this.PriceLabel);
            this.Controls.Add(this.DescriptionLabel);
            this.Controls.Add(this.TitleLabel);
            this.Name = "Ad";
            this.Text = "Ad";
            this.Load += new System.EventHandler(this.Ad_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label DescriptionLabel;
        private System.Windows.Forms.Label PriceLabel;
        private System.Windows.Forms.Label PhoneLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Rate;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label BrandLabel;
        private System.Windows.Forms.Label FabricationDateLabel;
    }
}
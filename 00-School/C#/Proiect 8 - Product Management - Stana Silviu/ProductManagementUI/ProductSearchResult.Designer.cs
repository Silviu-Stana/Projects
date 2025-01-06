namespace ProductManagement.UserInterface
{
    partial class ProductSearchResult
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.AdCard = new System.Windows.Forms.Panel();
            this.PriceLabel = new System.Windows.Forms.Label();
            this.DescriptionLabel = new System.Windows.Forms.Label();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.PictureBox = new System.Windows.Forms.PictureBox();
            this.EditButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.AdCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // AdCard
            // 
            this.AdCard.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.AdCard.Controls.Add(this.DeleteButton);
            this.AdCard.Controls.Add(this.EditButton);
            this.AdCard.Controls.Add(this.PriceLabel);
            this.AdCard.Controls.Add(this.DescriptionLabel);
            this.AdCard.Controls.Add(this.TitleLabel);
            this.AdCard.Controls.Add(this.PictureBox);
            this.AdCard.Location = new System.Drawing.Point(0, 0);
            this.AdCard.Name = "AdCard";
            this.AdCard.Size = new System.Drawing.Size(750, 154);
            this.AdCard.TabIndex = 1;
            this.AdCard.Paint += new System.Windows.Forms.PaintEventHandler(this.AdCard_Paint);
            this.AdCard.MouseClick += new System.Windows.Forms.MouseEventHandler(this.AdCard_MouseClick);
            this.AdCard.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AdCard_MouseDown);
            // 
            // PriceLabel
            // 
            this.PriceLabel.AutoSize = true;
            this.PriceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PriceLabel.Location = new System.Drawing.Point(201, 96);
            this.PriceLabel.Name = "PriceLabel";
            this.PriceLabel.Size = new System.Drawing.Size(52, 29);
            this.PriceLabel.TabIndex = 12;
            this.PriceLabel.Text = "$$$";
            this.PriceLabel.Click += new System.EventHandler(this.PriceLabel_Click);
            // 
            // DescriptionLabel
            // 
            this.DescriptionLabel.AutoSize = true;
            this.DescriptionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DescriptionLabel.Location = new System.Drawing.Point(202, 57);
            this.DescriptionLabel.Name = "DescriptionLabel";
            this.DescriptionLabel.Size = new System.Drawing.Size(145, 20);
            this.DescriptionLabel.TabIndex = 11;
            this.DescriptionLabel.Text = "Description here...";
            this.DescriptionLabel.Click += new System.EventHandler(this.DescriptionLabel_Click);
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLabel.Location = new System.Drawing.Point(201, 18);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(159, 29);
            this.TitleLabel.TabIndex = 10;
            this.TitleLabel.Text = "Ad title here...";
            this.TitleLabel.Click += new System.EventHandler(this.Title_Click);
            // 
            // PictureBox
            // 
            this.PictureBox.Location = new System.Drawing.Point(-3, 0);
            this.PictureBox.Name = "PictureBox";
            this.PictureBox.Size = new System.Drawing.Size(186, 154);
            this.PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureBox.TabIndex = 0;
            this.PictureBox.TabStop = false;
            this.PictureBox.Click += new System.EventHandler(this.PictureBox_Click);
            // 
            // EditButton
            // 
            this.EditButton.BackColor = System.Drawing.Color.LightSkyBlue;
            this.EditButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.EditButton.Location = new System.Drawing.Point(509, 106);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(106, 35);
            this.EditButton.TabIndex = 13;
            this.EditButton.Text = "Edit";
            this.EditButton.UseVisualStyleBackColor = false;
            this.EditButton.Visible = false;
            this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.BackColor = System.Drawing.Color.LightCoral;
            this.DeleteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.DeleteButton.Location = new System.Drawing.Point(625, 106);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(106, 35);
            this.DeleteButton.TabIndex = 14;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseVisualStyleBackColor = false;
            this.DeleteButton.Visible = false;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // AdSearchResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.AdCard);
            this.Name = "AdSearchResult";
            this.Size = new System.Drawing.Size(749, 169);
            this.Load += new System.EventHandler(this.AdSearchResult_Load);
            this.AdCard.ResumeLayout(false);
            this.AdCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel AdCard;
        private System.Windows.Forms.Label PriceLabel;
        private System.Windows.Forms.Label DescriptionLabel;
        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.PictureBox PictureBox;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button EditButton;
    }
}

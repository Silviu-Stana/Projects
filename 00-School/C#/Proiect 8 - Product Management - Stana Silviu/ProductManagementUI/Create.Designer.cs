namespace ProductManagement.UserInterface
{
    partial class Create
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.UploadPicture = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.PriceBox = new System.Windows.Forms.TextBox();
            this.DescBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TitleBox = new System.Windows.Forms.TextBox();
            this.Publish = new System.Windows.Forms.Button();
            this.Category = new System.Windows.Forms.Label();
            this.Categories = new System.Windows.Forms.CheckedListBox();
            this.Brand = new System.Windows.Forms.Label();
            this.BrandBox = new System.Windows.Forms.TextBox();
            this.DateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(176, 88);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(811, 237);
            this.flowLayoutPanel1.TabIndex = 17;
            // 
            // UploadPicture
            // 
            this.UploadPicture.BackColor = System.Drawing.Color.Gold;
            this.UploadPicture.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UploadPicture.Location = new System.Drawing.Point(33, 151);
            this.UploadPicture.Name = "UploadPicture";
            this.UploadPicture.Size = new System.Drawing.Size(97, 65);
            this.UploadPicture.TabIndex = 21;
            this.UploadPicture.Text = "Upload Picture";
            this.UploadPicture.UseVisualStyleBackColor = false;
            this.UploadPicture.Click += new System.EventHandler(this.UploadPicture_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(35, 381);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 33);
            this.label2.TabIndex = 23;
            this.label2.Text = "Cost: $";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(50, 335);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 34);
            this.label3.TabIndex = 22;
            this.label3.Text = "Desc:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PriceBox
            // 
            this.PriceBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PriceBox.Location = new System.Drawing.Point(172, 383);
            this.PriceBox.Name = "PriceBox";
            this.PriceBox.Size = new System.Drawing.Size(240, 33);
            this.PriceBox.TabIndex = 25;
            this.PriceBox.TextChanged += new System.EventHandler(this.PriceBox_TextChanged);
            this.PriceBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PriceBox_KeyPress);
            // 
            // DescBox
            // 
            this.DescBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DescBox.Location = new System.Drawing.Point(172, 338);
            this.DescBox.Name = "DescBox";
            this.DescBox.Size = new System.Drawing.Size(815, 33);
            this.DescBox.TabIndex = 26;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(62, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 33);
            this.label4.TabIndex = 28;
            this.label4.Text = "Title:";
            // 
            // TitleBox
            // 
            this.TitleBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleBox.Location = new System.Drawing.Point(176, 36);
            this.TitleBox.Name = "TitleBox";
            this.TitleBox.Size = new System.Drawing.Size(811, 33);
            this.TitleBox.TabIndex = 29;
            // 
            // Publish
            // 
            this.Publish.BackColor = System.Drawing.Color.LightGreen;
            this.Publish.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Publish.Location = new System.Drawing.Point(429, 697);
            this.Publish.Name = "Publish";
            this.Publish.Size = new System.Drawing.Size(197, 74);
            this.Publish.TabIndex = 30;
            this.Publish.Text = "Publish Changes";
            this.Publish.UseVisualStyleBackColor = false;
            this.Publish.Click += new System.EventHandler(this.Publish_Click);
            // 
            // Category
            // 
            this.Category.AutoSize = true;
            this.Category.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Category.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Category.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Category.Location = new System.Drawing.Point(20, 471);
            this.Category.Name = "Category";
            this.Category.Size = new System.Drawing.Size(118, 31);
            this.Category.TabIndex = 31;
            this.Category.Text = "Category:";
            // 
            // Categories
            // 
            this.Categories.CheckOnClick = true;
            this.Categories.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.Categories.FormattingEnabled = true;
            this.Categories.Location = new System.Drawing.Point(172, 471);
            this.Categories.Name = "Categories";
            this.Categories.Size = new System.Drawing.Size(193, 294);
            this.Categories.TabIndex = 33;
            this.Categories.SelectedIndexChanged += new System.EventHandler(this.Categories_SelectedIndexChanged);
            // 
            // Brand
            // 
            this.Brand.AutoSize = true;
            this.Brand.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Brand.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Brand.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.Brand.Location = new System.Drawing.Point(50, 426);
            this.Brand.Name = "Brand";
            this.Brand.Size = new System.Drawing.Size(88, 33);
            this.Brand.TabIndex = 34;
            this.Brand.Text = "Brand";
            // 
            // BrandBox
            // 
            this.BrandBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BrandBox.Location = new System.Drawing.Point(172, 427);
            this.BrandBox.Name = "BrandBox";
            this.BrandBox.Size = new System.Drawing.Size(240, 33);
            this.BrandBox.TabIndex = 35;
            this.BrandBox.TextChanged += new System.EventHandler(this.BrandBox_TextChanged);
            // 
            // DateTimePicker
            // 
            this.DateTimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.DateTimePicker.Location = new System.Drawing.Point(528, 426);
            this.DateTimePicker.MaxDate = new System.DateTime(2025, 1, 6, 0, 0, 0, 0);
            this.DateTimePicker.Name = "DateTimePicker";
            this.DateTimePicker.Size = new System.Drawing.Size(413, 34);
            this.DateTimePicker.TabIndex = 37;
            this.DateTimePicker.Value = new System.DateTime(2025, 1, 6, 0, 0, 0, 0);
            this.DateTimePicker.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(528, 383);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(224, 33);
            this.label1.TabIndex = 38;
            this.label1.Text = "Fabrication Date:";
            // 
            // Create
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1081, 783);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DateTimePicker);
            this.Controls.Add(this.BrandBox);
            this.Controls.Add(this.Brand);
            this.Controls.Add(this.Categories);
            this.Controls.Add(this.Category);
            this.Controls.Add(this.Publish);
            this.Controls.Add(this.TitleBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.DescBox);
            this.Controls.Add(this.PriceBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.UploadPicture);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "Create";
            this.Text = "Create";
            this.Load += new System.EventHandler(this.Create_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button UploadPicture;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox PriceBox;
        private System.Windows.Forms.TextBox DescBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TitleBox;
        private System.Windows.Forms.Button Publish;
        private System.Windows.Forms.Label Category;
        private System.Windows.Forms.CheckedListBox Categories;
        private System.Windows.Forms.Label Brand;
        private System.Windows.Forms.TextBox BrandBox;
        private System.Windows.Forms.DateTimePicker DateTimePicker;
        private System.Windows.Forms.Label label1;
    }
}
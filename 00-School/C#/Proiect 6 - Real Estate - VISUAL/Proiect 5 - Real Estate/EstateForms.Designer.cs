namespace EstateConsoleUI
{
    partial class EstateForms
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
            this.Button_Create = new System.Windows.Forms.Button();
            this.Button_Update = new System.Windows.Forms.Button();
            this.Button_VisitEstate = new System.Windows.Forms.Button();
            this.Button_Delete = new System.Windows.Forms.Button();
            this.label_searchById = new System.Windows.Forms.Label();
            this.TextBox_SearchById = new System.Windows.Forms.TextBox();
            this.TextBox_Delete_Id = new System.Windows.Forms.TextBox();
            this.Label_DeleteID = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TextBox_Create_Name = new System.Windows.Forms.TextBox();
            this.TextBox_Create_Address = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TextBox_Create_Price = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TextBox_Update_Id = new System.Windows.Forms.TextBox();
            this.TextBox_Update_Price = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TextBox_Update_Address = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.TextBox_Update_Name = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.Label_EstateAddress = new System.Windows.Forms.Label();
            this.Label_EstatePrice = new System.Windows.Forms.Label();
            this.Label_CreateDate = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.Label_EstateName = new System.Windows.Forms.Label();
            this.estates_dataGridView = new System.Windows.Forms.DataGridView();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.Order_ComboBox = new System.Windows.Forms.ComboBox();
            this.Sort_ComboBox = new System.Windows.Forms.ComboBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.Upload_TextBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.UploadPicture_Button = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.FilterComparison_ComboBox = new System.Windows.Forms.ComboBox();
            this.Filter_ComboBox = new System.Windows.Forms.ComboBox();
            this.FilterValue_ComboBox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.estates_dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // Button_Create
            // 
            this.Button_Create.BackColor = System.Drawing.Color.YellowGreen;
            this.Button_Create.Location = new System.Drawing.Point(115, 633);
            this.Button_Create.Name = "Button_Create";
            this.Button_Create.Size = new System.Drawing.Size(138, 39);
            this.Button_Create.TabIndex = 1;
            this.Button_Create.Text = "Create Estate";
            this.Button_Create.UseVisualStyleBackColor = false;
            this.Button_Create.Click += new System.EventHandler(this.Button_Create_Click);
            // 
            // Button_Update
            // 
            this.Button_Update.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Button_Update.Location = new System.Drawing.Point(115, 678);
            this.Button_Update.Name = "Button_Update";
            this.Button_Update.Size = new System.Drawing.Size(145, 39);
            this.Button_Update.TabIndex = 2;
            this.Button_Update.Text = "Update Estate";
            this.Button_Update.UseVisualStyleBackColor = false;
            this.Button_Update.Click += new System.EventHandler(this.Button_Update_Click);
            // 
            // Button_VisitEstate
            // 
            this.Button_VisitEstate.BackColor = System.Drawing.Color.Gold;
            this.Button_VisitEstate.Location = new System.Drawing.Point(115, 548);
            this.Button_VisitEstate.Name = "Button_VisitEstate";
            this.Button_VisitEstate.Size = new System.Drawing.Size(138, 33);
            this.Button_VisitEstate.TabIndex = 3;
            this.Button_VisitEstate.Text = "VISIT Estate";
            this.Button_VisitEstate.UseVisualStyleBackColor = false;
            this.Button_VisitEstate.Click += new System.EventHandler(this.Button_VisitEstate_Click);
            // 
            // Button_Delete
            // 
            this.Button_Delete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.Button_Delete.Location = new System.Drawing.Point(115, 723);
            this.Button_Delete.Name = "Button_Delete";
            this.Button_Delete.Size = new System.Drawing.Size(145, 39);
            this.Button_Delete.TabIndex = 4;
            this.Button_Delete.Text = "Delete Estate";
            this.Button_Delete.UseVisualStyleBackColor = false;
            this.Button_Delete.Click += new System.EventHandler(this.Button_Delete_Click);
            // 
            // label_searchById
            // 
            this.label_searchById.AutoSize = true;
            this.label_searchById.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label_searchById.Location = new System.Drawing.Point(110, 492);
            this.label_searchById.Name = "label_searchById";
            this.label_searchById.Size = new System.Drawing.Size(193, 25);
            this.label_searchById.TabIndex = 6;
            this.label_searchById.Text = "Search By Estate ID:";
            // 
            // TextBox_SearchById
            // 
            this.TextBox_SearchById.Location = new System.Drawing.Point(94, 520);
            this.TextBox_SearchById.Name = "TextBox_SearchById";
            this.TextBox_SearchById.Size = new System.Drawing.Size(209, 22);
            this.TextBox_SearchById.TabIndex = 7;
            this.TextBox_SearchById.TextChanged += new System.EventHandler(this.TextBox_SearchById_TextChanged);
            // 
            // TextBox_Delete_Id
            // 
            this.TextBox_Delete_Id.Location = new System.Drawing.Point(303, 737);
            this.TextBox_Delete_Id.Name = "TextBox_Delete_Id";
            this.TextBox_Delete_Id.Size = new System.Drawing.Size(55, 22);
            this.TextBox_Delete_Id.TabIndex = 8;
            this.TextBox_Delete_Id.TextChanged += new System.EventHandler(this.TextBox_Delete_Id_TextChanged);
            // 
            // Label_DeleteID
            // 
            this.Label_DeleteID.AutoSize = true;
            this.Label_DeleteID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Label_DeleteID.Location = new System.Drawing.Point(266, 733);
            this.Label_DeleteID.Name = "Label_DeleteID";
            this.Label_DeleteID.Size = new System.Drawing.Size(31, 25);
            this.Label_DeleteID.TabIndex = 9;
            this.Label_DeleteID.Text = "ID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(266, 682);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 25);
            this.label1.TabIndex = 10;
            this.label1.Text = "ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(266, 637);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 25);
            this.label2.TabIndex = 11;
            this.label2.Text = "Name";
            // 
            // TextBox_Create_Name
            // 
            this.TextBox_Create_Name.Location = new System.Drawing.Point(337, 641);
            this.TextBox_Create_Name.Name = "TextBox_Create_Name";
            this.TextBox_Create_Name.Size = new System.Drawing.Size(108, 22);
            this.TextBox_Create_Name.TabIndex = 12;
            // 
            // TextBox_Create_Address
            // 
            this.TextBox_Create_Address.Location = new System.Drawing.Point(541, 641);
            this.TextBox_Create_Address.Name = "TextBox_Create_Address";
            this.TextBox_Create_Address.Size = new System.Drawing.Size(132, 22);
            this.TextBox_Create_Address.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.Location = new System.Drawing.Point(454, 637);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 25);
            this.label3.TabIndex = 13;
            this.label3.Text = "Address";
            // 
            // TextBox_Create_Price
            // 
            this.TextBox_Create_Price.Location = new System.Drawing.Point(758, 641);
            this.TextBox_Create_Price.Name = "TextBox_Create_Price";
            this.TextBox_Create_Price.Size = new System.Drawing.Size(132, 22);
            this.TextBox_Create_Price.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label4.Location = new System.Drawing.Point(687, 637);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 25);
            this.label4.TabIndex = 15;
            this.label4.Text = "Price";
            // 
            // TextBox_Update_Id
            // 
            this.TextBox_Update_Id.Location = new System.Drawing.Point(303, 686);
            this.TextBox_Update_Id.Name = "TextBox_Update_Id";
            this.TextBox_Update_Id.Size = new System.Drawing.Size(55, 22);
            this.TextBox_Update_Id.TabIndex = 17;
            // 
            // TextBox_Update_Price
            // 
            this.TextBox_Update_Price.Location = new System.Drawing.Point(840, 687);
            this.TextBox_Update_Price.Name = "TextBox_Update_Price";
            this.TextBox_Update_Price.Size = new System.Drawing.Size(132, 22);
            this.TextBox_Update_Price.TabIndex = 23;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label5.Location = new System.Drawing.Point(777, 683);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 25);
            this.label5.TabIndex = 22;
            this.label5.Text = "Price";
            // 
            // TextBox_Update_Address
            // 
            this.TextBox_Update_Address.Location = new System.Drawing.Point(640, 686);
            this.TextBox_Update_Address.Name = "TextBox_Update_Address";
            this.TextBox_Update_Address.Size = new System.Drawing.Size(115, 22);
            this.TextBox_Update_Address.TabIndex = 21;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label6.Location = new System.Drawing.Point(553, 682);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 25);
            this.label6.TabIndex = 20;
            this.label6.Text = "Address";
            // 
            // TextBox_Update_Name
            // 
            this.TextBox_Update_Name.Location = new System.Drawing.Point(436, 686);
            this.TextBox_Update_Name.Name = "TextBox_Update_Name";
            this.TextBox_Update_Name.Size = new System.Drawing.Size(108, 22);
            this.TextBox_Update_Name.TabIndex = 19;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label7.Location = new System.Drawing.Point(365, 682);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 25);
            this.label7.TabIndex = 18;
            this.label7.Text = "Name";
            // 
            // Label_EstateAddress
            // 
            this.Label_EstateAddress.AutoSize = true;
            this.Label_EstateAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Label_EstateAddress.Location = new System.Drawing.Point(553, 491);
            this.Label_EstateAddress.Name = "Label_EstateAddress";
            this.Label_EstateAddress.Size = new System.Drawing.Size(0, 25);
            this.Label_EstateAddress.TabIndex = 25;
            this.Label_EstateAddress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label_EstatePrice
            // 
            this.Label_EstatePrice.AutoSize = true;
            this.Label_EstatePrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Label_EstatePrice.Location = new System.Drawing.Point(553, 516);
            this.Label_EstatePrice.Name = "Label_EstatePrice";
            this.Label_EstatePrice.Size = new System.Drawing.Size(0, 25);
            this.Label_EstatePrice.TabIndex = 26;
            this.Label_EstatePrice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label_CreateDate
            // 
            this.Label_CreateDate.AutoSize = true;
            this.Label_CreateDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Label_CreateDate.Location = new System.Drawing.Point(553, 552);
            this.Label_CreateDate.Name = "Label_CreateDate";
            this.Label_CreateDate.Size = new System.Drawing.Size(0, 25);
            this.Label_CreateDate.TabIndex = 27;
            this.Label_CreateDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(28, 12);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(2004, 378);
            this.listView1.TabIndex = 5;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // Label_EstateName
            // 
            this.Label_EstateName.AutoSize = true;
            this.Label_EstateName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Label_EstateName.Location = new System.Drawing.Point(454, 210);
            this.Label_EstateName.Name = "Label_EstateName";
            this.Label_EstateName.Size = new System.Drawing.Size(0, 25);
            this.Label_EstateName.TabIndex = 24;
            this.Label_EstateName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Label_EstateName.Click += new System.EventHandler(this.Label_EstateName_Click);
            // 
            // estates_dataGridView
            // 
            this.estates_dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.estates_dataGridView.Location = new System.Drawing.Point(1054, 450);
            this.estates_dataGridView.Name = "estates_dataGridView";
            this.estates_dataGridView.RowHeadersWidth = 51;
            this.estates_dataGridView.RowTemplate.Height = 24;
            this.estates_dataGridView.Size = new System.Drawing.Size(562, 411);
            this.estates_dataGridView.TabIndex = 28;
            this.estates_dataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.estates_dataGridView_CellContentClick);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label8.Location = new System.Drawing.Point(1259, 422);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(139, 25);
            this.label8.TabIndex = 29;
            this.label8.Text = "List of Estates:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label9.Location = new System.Drawing.Point(1678, 436);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(131, 31);
            this.label9.TabIndex = 31;
            this.label9.Text = "SORT BY:";
            // 
            // Order_ComboBox
            // 
            this.Order_ComboBox.FormattingEnabled = true;
            this.Order_ComboBox.Items.AddRange(new object[] {
            "Ascending",
            "Descending"});
            this.Order_ComboBox.Location = new System.Drawing.Point(1815, 475);
            this.Order_ComboBox.Name = "Order_ComboBox";
            this.Order_ComboBox.Size = new System.Drawing.Size(121, 24);
            this.Order_ComboBox.TabIndex = 32;
            this.Order_ComboBox.Text = "Ascending";
            this.Order_ComboBox.SelectedIndexChanged += new System.EventHandler(this.Order_ComboBox_SelectedIndexChanged);
            // 
            // Sort_ComboBox
            // 
            this.Sort_ComboBox.FormattingEnabled = true;
            this.Sort_ComboBox.Items.AddRange(new object[] {
            "House Name",
            "Address",
            "Price",
            "Creation Date",
            "Id"});
            this.Sort_ComboBox.Location = new System.Drawing.Point(1672, 477);
            this.Sort_ComboBox.Name = "Sort_ComboBox";
            this.Sort_ComboBox.Size = new System.Drawing.Size(121, 24);
            this.Sort_ComboBox.TabIndex = 33;
            this.Sort_ComboBox.Text = "Name";
            this.Sort_ComboBox.SelectedIndexChanged += new System.EventHandler(this.Sort_ComboBox_SelectedIndexChanged);
            // 
            // Upload_TextBox
            // 
            this.Upload_TextBox.Location = new System.Drawing.Point(541, 477);
            this.Upload_TextBox.Name = "Upload_TextBox";
            this.Upload_TextBox.Size = new System.Drawing.Size(79, 22);
            this.Upload_TextBox.TabIndex = 34;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label10.Location = new System.Drawing.Point(536, 445);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(97, 25);
            this.label10.TabIndex = 35;
            this.label10.Text = "Estate ID:";
            // 
            // UploadPicture_Button
            // 
            this.UploadPicture_Button.BackColor = System.Drawing.Color.Pink;
            this.UploadPicture_Button.Location = new System.Drawing.Point(510, 509);
            this.UploadPicture_Button.Name = "UploadPicture_Button";
            this.UploadPicture_Button.Size = new System.Drawing.Size(138, 33);
            this.UploadPicture_Button.TabIndex = 36;
            this.UploadPicture_Button.Text = "UPLOAD Picture";
            this.UploadPicture_Button.UseVisualStyleBackColor = false;
            this.UploadPicture_Button.Click += new System.EventHandler(this.UploadPicture_Button_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label11.Location = new System.Drawing.Point(1678, 533);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(145, 31);
            this.label11.TabIndex = 37;
            this.label11.Text = "FILTER BY:";
            // 
            // FilterComparison_ComboBox
            // 
            this.FilterComparison_ComboBox.FormattingEnabled = true;
            this.FilterComparison_ComboBox.Items.AddRange(new object[] {
            ">",
            ">=",
            "=",
            "<=",
            "<"});
            this.FilterComparison_ComboBox.Location = new System.Drawing.Point(1815, 579);
            this.FilterComparison_ComboBox.Name = "FilterComparison_ComboBox";
            this.FilterComparison_ComboBox.Size = new System.Drawing.Size(37, 24);
            this.FilterComparison_ComboBox.TabIndex = 38;
            this.FilterComparison_ComboBox.Text = ">";
            this.FilterComparison_ComboBox.SelectedIndexChanged += new System.EventHandler(this.FilterComparison_ComboBox_SelectedIndexChanged);
            // 
            // Filter_ComboBox
            // 
            this.Filter_ComboBox.FormattingEnabled = true;
            this.Filter_ComboBox.Items.AddRange(new object[] {
            "Price"});
            this.Filter_ComboBox.Location = new System.Drawing.Point(1672, 579);
            this.Filter_ComboBox.Name = "Filter_ComboBox";
            this.Filter_ComboBox.Size = new System.Drawing.Size(121, 24);
            this.Filter_ComboBox.TabIndex = 39;
            this.Filter_ComboBox.Text = "Price";
            this.Filter_ComboBox.SelectedIndexChanged += new System.EventHandler(this.Filter_ComboBox_SelectedIndexChanged);
            // 
            // FilterValue_ComboBox
            // 
            this.FilterValue_ComboBox.Location = new System.Drawing.Point(1867, 579);
            this.FilterValue_ComboBox.Name = "FilterValue_ComboBox";
            this.FilterValue_ComboBox.Size = new System.Drawing.Size(100, 22);
            this.FilterValue_ComboBox.TabIndex = 40;
            this.FilterValue_ComboBox.TextChanged += new System.EventHandler(this.FilterValue_ComboBox_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(1892, 559);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(42, 16);
            this.label12.TabIndex = 41;
            this.label12.Text = "Value";
            // 
            // EstateForms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2093, 873);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.FilterValue_ComboBox);
            this.Controls.Add(this.Filter_ComboBox);
            this.Controls.Add(this.FilterComparison_ComboBox);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.UploadPicture_Button);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.Upload_TextBox);
            this.Controls.Add(this.Sort_ComboBox);
            this.Controls.Add(this.Order_ComboBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.estates_dataGridView);
            this.Controls.Add(this.Label_EstateName);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.Label_CreateDate);
            this.Controls.Add(this.Label_EstatePrice);
            this.Controls.Add(this.Label_EstateAddress);
            this.Controls.Add(this.TextBox_Update_Price);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TextBox_Update_Address);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.TextBox_Update_Name);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.TextBox_Update_Id);
            this.Controls.Add(this.TextBox_Create_Price);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TextBox_Create_Address);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TextBox_Create_Name);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Label_DeleteID);
            this.Controls.Add(this.TextBox_Delete_Id);
            this.Controls.Add(this.TextBox_SearchById);
            this.Controls.Add(this.label_searchById);
            this.Controls.Add(this.Button_Delete);
            this.Controls.Add(this.Button_VisitEstate);
            this.Controls.Add(this.Button_Update);
            this.Controls.Add(this.Button_Create);
            this.Name = "EstateForms";
            this.Text = "EstateForms";
            this.Load += new System.EventHandler(this.EstateForms_Load);
            ((System.ComponentModel.ISupportInitialize)(this.estates_dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Button_Create;
        private System.Windows.Forms.Button Button_Update;
        private System.Windows.Forms.Button Button_VisitEstate;
        private System.Windows.Forms.Button Button_Delete;
        private System.Windows.Forms.Label label_searchById;
        private System.Windows.Forms.TextBox TextBox_SearchById;
        private System.Windows.Forms.TextBox TextBox_Delete_Id;
        private System.Windows.Forms.Label Label_DeleteID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TextBox_Create_Name;
        private System.Windows.Forms.TextBox TextBox_Create_Address;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TextBox_Create_Price;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TextBox_Update_Id;
        private System.Windows.Forms.TextBox TextBox_Update_Price;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TextBox_Update_Address;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TextBox_Update_Name;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label Label_EstateAddress;
        private System.Windows.Forms.Label Label_EstatePrice;
        private System.Windows.Forms.Label Label_CreateDate;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label Label_EstateName;
        private System.Windows.Forms.DataGridView estates_dataGridView;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox Order_ComboBox;
        private System.Windows.Forms.ComboBox Sort_ComboBox;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TextBox Upload_TextBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button UploadPicture_Button;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox FilterComparison_ComboBox;
        private System.Windows.Forms.ComboBox Filter_ComboBox;
        private System.Windows.Forms.TextBox FilterValue_ComboBox;
        private System.Windows.Forms.Label label12;
    }
}
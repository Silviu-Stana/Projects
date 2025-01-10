namespace SGBP_Project___Silviu
{
    partial class ListaAngajatiForm
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
            this.ListaAngajati_GridView = new System.Windows.Forms.DataGridView();
            this.ListaAngajatiLabel = new System.Windows.Forms.Label();
            this.SelectAngajat_Label1 = new System.Windows.Forms.Label();
            this.Nume_Label = new System.Windows.Forms.Label();
            this.Nume_TextBox = new System.Windows.Forms.TextBox();
            this.Functie_Label = new System.Windows.Forms.Label();
            this.Functie_DropDown = new System.Windows.Forms.ComboBox();
            this.Save_Button = new System.Windows.Forms.Button();
            this.ExportXML = new System.Windows.Forms.Button();
            this.ExportCSV = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.FunctieInsert_DropDown = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ListaAngajati_GridView)).BeginInit();
            this.SuspendLayout();
            // 
            // ListaAngajati_GridView
            // 
            this.ListaAngajati_GridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ListaAngajati_GridView.Location = new System.Drawing.Point(54, 139);
            this.ListaAngajati_GridView.Name = "ListaAngajati_GridView";
            this.ListaAngajati_GridView.RowHeadersWidth = 51;
            this.ListaAngajati_GridView.RowTemplate.Height = 24;
            this.ListaAngajati_GridView.Size = new System.Drawing.Size(502, 331);
            this.ListaAngajati_GridView.TabIndex = 0;
            this.ListaAngajati_GridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ListaAngajati_GridView_CellClick);
            // 
            // ListaAngajatiLabel
            // 
            this.ListaAngajatiLabel.AutoSize = true;
            this.ListaAngajatiLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListaAngajatiLabel.Location = new System.Drawing.Point(197, 75);
            this.ListaAngajatiLabel.Name = "ListaAngajatiLabel";
            this.ListaAngajatiLabel.Size = new System.Drawing.Size(214, 31);
            this.ListaAngajatiLabel.TabIndex = 1;
            this.ListaAngajatiLabel.Text = "Lista de Angajati";
            // 
            // SelectAngajat_Label1
            // 
            this.SelectAngajat_Label1.AutoSize = true;
            this.SelectAngajat_Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectAngajat_Label1.Location = new System.Drawing.Point(643, 139);
            this.SelectAngajat_Label1.Name = "SelectAngajat_Label1";
            this.SelectAngajat_Label1.Size = new System.Drawing.Size(212, 25);
            this.SelectAngajat_Label1.TabIndex = 2;
            this.SelectAngajat_Label1.Text = "Selecteaza Un Angajat";
            // 
            // Nume_Label
            // 
            this.Nume_Label.AutoSize = true;
            this.Nume_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Nume_Label.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.Nume_Label.Location = new System.Drawing.Point(648, 194);
            this.Nume_Label.Name = "Nume_Label";
            this.Nume_Label.Size = new System.Drawing.Size(64, 25);
            this.Nume_Label.TabIndex = 3;
            this.Nume_Label.Text = "Nume";
            // 
            // Nume_TextBox
            // 
            this.Nume_TextBox.Location = new System.Drawing.Point(730, 194);
            this.Nume_TextBox.Multiline = true;
            this.Nume_TextBox.Name = "Nume_TextBox";
            this.Nume_TextBox.Size = new System.Drawing.Size(100, 25);
            this.Nume_TextBox.TabIndex = 4;
            // 
            // Functie_Label
            // 
            this.Functie_Label.AutoSize = true;
            this.Functie_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Functie_Label.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.Functie_Label.Location = new System.Drawing.Point(648, 235);
            this.Functie_Label.Name = "Functie_Label";
            this.Functie_Label.Size = new System.Drawing.Size(76, 25);
            this.Functie_Label.TabIndex = 5;
            this.Functie_Label.Text = "Functie";
            // 
            // Functie_DropDown
            // 
            this.Functie_DropDown.FormattingEnabled = true;
            this.Functie_DropDown.Location = new System.Drawing.Point(730, 236);
            this.Functie_DropDown.Name = "Functie_DropDown";
            this.Functie_DropDown.Size = new System.Drawing.Size(204, 24);
            this.Functie_DropDown.TabIndex = 7;
            this.Functie_DropDown.SelectedIndexChanged += new System.EventHandler(this.Functie_DropDown_SelectedIndexChanged);
            // 
            // Save_Button
            // 
            this.Save_Button.BackColor = System.Drawing.SystemColors.HotTrack;
            this.Save_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Save_Button.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Save_Button.Location = new System.Drawing.Point(665, 275);
            this.Save_Button.Name = "Save_Button";
            this.Save_Button.Size = new System.Drawing.Size(190, 51);
            this.Save_Button.TabIndex = 8;
            this.Save_Button.Text = "Salveaza Date";
            this.Save_Button.UseVisualStyleBackColor = false;
            this.Save_Button.Click += new System.EventHandler(this.Save_Button_Click);
            // 
            // ExportXML
            // 
            this.ExportXML.BackColor = System.Drawing.Color.RoyalBlue;
            this.ExportXML.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExportXML.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.ExportXML.Location = new System.Drawing.Point(106, 489);
            this.ExportXML.Name = "ExportXML";
            this.ExportXML.Size = new System.Drawing.Size(176, 39);
            this.ExportXML.TabIndex = 9;
            this.ExportXML.Text = "Export XML";
            this.ExportXML.UseVisualStyleBackColor = false;
            this.ExportXML.Click += new System.EventHandler(this.ExportXML_Click);
            // 
            // ExportCSV
            // 
            this.ExportCSV.BackColor = System.Drawing.Color.ForestGreen;
            this.ExportCSV.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExportCSV.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.ExportCSV.Location = new System.Drawing.Point(288, 489);
            this.ExportCSV.Name = "ExportCSV";
            this.ExportCSV.Size = new System.Drawing.Size(176, 39);
            this.ExportCSV.TabIndex = 10;
            this.ExportCSV.Text = "Export CSV";
            this.ExportCSV.UseVisualStyleBackColor = false;
            this.ExportCSV.Click += new System.EventHandler(this.ExportCSV_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(643, 379);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(257, 25);
            this.label1.TabIndex = 11;
            this.label1.Text = "Adauga / Sterge Un Angajat";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.ForestGreen;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button1.Location = new System.Drawing.Point(665, 502);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(190, 51);
            this.button1.TabIndex = 16;
            this.button1.Text = "Adauga Angajat";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // FunctieInsert_DropDown
            // 
            this.FunctieInsert_DropDown.FormattingEnabled = true;
            this.FunctieInsert_DropDown.Location = new System.Drawing.Point(730, 463);
            this.FunctieInsert_DropDown.Name = "FunctieInsert_DropDown";
            this.FunctieInsert_DropDown.Size = new System.Drawing.Size(204, 24);
            this.FunctieInsert_DropDown.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.MediumSeaGreen;
            this.label2.Location = new System.Drawing.Point(648, 462);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 25);
            this.label2.TabIndex = 14;
            this.label2.Text = "Functie";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(730, 421);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 25);
            this.textBox1.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.MediumSeaGreen;
            this.label3.Location = new System.Drawing.Point(648, 421);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 25);
            this.label3.TabIndex = 12;
            this.label3.Text = "Nume";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Brown;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button2.Location = new System.Drawing.Point(861, 275);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(162, 51);
            this.button2.TabIndex = 17;
            this.button2.Text = "Sterge Angajat";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ListaAngajatiForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1245, 591);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.FunctieInsert_DropDown);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ExportCSV);
            this.Controls.Add(this.ExportXML);
            this.Controls.Add(this.Save_Button);
            this.Controls.Add(this.Functie_DropDown);
            this.Controls.Add(this.Functie_Label);
            this.Controls.Add(this.Nume_TextBox);
            this.Controls.Add(this.Nume_Label);
            this.Controls.Add(this.SelectAngajat_Label1);
            this.Controls.Add(this.ListaAngajatiLabel);
            this.Controls.Add(this.ListaAngajati_GridView);
            this.Name = "ListaAngajatiForm";
            this.Text = "ListaAngajatiForm";
            this.Load += new System.EventHandler(this.ListaAngajatiForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ListaAngajati_GridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView ListaAngajati_GridView;
        private System.Windows.Forms.Label ListaAngajatiLabel;
        private System.Windows.Forms.Label SelectAngajat_Label1;
        private System.Windows.Forms.Label Nume_Label;
        private System.Windows.Forms.TextBox Nume_TextBox;
        private System.Windows.Forms.Label Functie_Label;
        private System.Windows.Forms.ComboBox Functie_DropDown;
        private System.Windows.Forms.Button Save_Button;
        private System.Windows.Forms.Button ExportXML;
        private System.Windows.Forms.Button ExportCSV;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox FunctieInsert_DropDown;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button2;
    }
}
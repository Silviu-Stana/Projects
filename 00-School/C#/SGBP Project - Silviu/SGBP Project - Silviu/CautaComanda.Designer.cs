namespace SGBP_Project___Silviu
{
    partial class CautaComanda
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
            this.ListaClientiLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Client_GridView = new System.Windows.Forms.DataGridView();
            this.Comenzi_GridView = new System.Windows.Forms.DataGridView();
            this.Comanda_GridView = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.NrClienti_Label = new System.Windows.Forms.Label();
            this.TotalClienti = new System.Windows.Forms.GroupBox();
            this.Enable_NrOrders = new System.Windows.Forms.Label();
            this.Enable_Label1 = new System.Windows.Forms.Label();
            this.Enable_InfoBox = new System.Windows.Forms.GroupBox();
            this.Enable_Label2 = new System.Windows.Forms.Label();
            this.PretTotal_Label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.PretTotal_Label = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.SetDeliveryDate = new System.Windows.Forms.Button();
            this.DeliveryPanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.Client_GridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Comenzi_GridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Comanda_GridView)).BeginInit();
            this.TotalClienti.SuspendLayout();
            this.Enable_InfoBox.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.DeliveryPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ListaClientiLabel
            // 
            this.ListaClientiLabel.AutoSize = true;
            this.ListaClientiLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListaClientiLabel.Location = new System.Drawing.Point(113, 97);
            this.ListaClientiLabel.Name = "ListaClientiLabel";
            this.ListaClientiLabel.Size = new System.Drawing.Size(268, 31);
            this.ListaClientiLabel.TabIndex = 2;
            this.ListaClientiLabel.Text = "Selecteaza Un Client";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(663, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(301, 31);
            this.label1.TabIndex = 3;
            this.label1.Text = "Selecteaza O Comanda";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1363, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(214, 31);
            this.label2.TabIndex = 4;
            this.label2.Text = "Detalii Comanda";
            // 
            // Client_GridView
            // 
            this.Client_GridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Client_GridView.Location = new System.Drawing.Point(33, 155);
            this.Client_GridView.Name = "Client_GridView";
            this.Client_GridView.RowHeadersWidth = 51;
            this.Client_GridView.RowTemplate.Height = 24;
            this.Client_GridView.Size = new System.Drawing.Size(458, 334);
            this.Client_GridView.TabIndex = 5;
            this.Client_GridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Client_GridView_CellClick);
            this.Client_GridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Client_GridView_CellContentClick);
            // 
            // Comenzi_GridView
            // 
            this.Comenzi_GridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Comenzi_GridView.Location = new System.Drawing.Point(585, 155);
            this.Comenzi_GridView.Name = "Comenzi_GridView";
            this.Comenzi_GridView.RowHeadersWidth = 51;
            this.Comenzi_GridView.RowTemplate.Height = 24;
            this.Comenzi_GridView.Size = new System.Drawing.Size(458, 334);
            this.Comenzi_GridView.TabIndex = 6;
            this.Comenzi_GridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Comenzi_GridView_CellClick);
            this.Comenzi_GridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Comenzi_GridView_CellContentClick);
            // 
            // Comanda_GridView
            // 
            this.Comanda_GridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Comanda_GridView.Location = new System.Drawing.Point(1117, 155);
            this.Comanda_GridView.Name = "Comanda_GridView";
            this.Comanda_GridView.RowHeadersWidth = 51;
            this.Comanda_GridView.RowTemplate.Height = 24;
            this.Comanda_GridView.Size = new System.Drawing.Size(731, 334);
            this.Comanda_GridView.TabIndex = 7;
            this.Comanda_GridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Comanda_GridView_CellClick);
            this.Comanda_GridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Comanda_GridView_CellContentClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(151, 556);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(158, 31);
            this.label3.TabIndex = 8;
            this.label3.Text = "Total Clienti";
            // 
            // NrClienti_Label
            // 
            this.NrClienti_Label.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.NrClienti_Label.AutoSize = true;
            this.NrClienti_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NrClienti_Label.Location = new System.Drawing.Point(102, 66);
            this.NrClienti_Label.Name = "NrClienti_Label";
            this.NrClienti_Label.Size = new System.Drawing.Size(64, 46);
            this.NrClienti_Label.TabIndex = 9;
            this.NrClienti_Label.Text = "00";
            this.NrClienti_Label.Click += new System.EventHandler(this.NrClienti_Label_Click);
            // 
            // TotalClienti
            // 
            this.TotalClienti.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.TotalClienti.Controls.Add(this.NrClienti_Label);
            this.TotalClienti.Location = new System.Drawing.Point(89, 530);
            this.TotalClienti.Name = "TotalClienti";
            this.TotalClienti.Size = new System.Drawing.Size(282, 142);
            this.TotalClienti.TabIndex = 10;
            this.TotalClienti.TabStop = false;
            // 
            // Enable_NrOrders
            // 
            this.Enable_NrOrders.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Enable_NrOrders.AutoSize = true;
            this.Enable_NrOrders.BackColor = System.Drawing.SystemColors.Control;
            this.Enable_NrOrders.Enabled = false;
            this.Enable_NrOrders.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Enable_NrOrders.Location = new System.Drawing.Point(211, 115);
            this.Enable_NrOrders.Name = "Enable_NrOrders";
            this.Enable_NrOrders.Size = new System.Drawing.Size(42, 46);
            this.Enable_NrOrders.TabIndex = 12;
            this.Enable_NrOrders.Text = "0";
            this.Enable_NrOrders.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Enable_NrOrders.Visible = false;
            // 
            // Enable_Label1
            // 
            this.Enable_Label1.AutoSize = true;
            this.Enable_Label1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Enable_Label1.Enabled = false;
            this.Enable_Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Enable_Label1.Location = new System.Drawing.Point(52, 26);
            this.Enable_Label1.Name = "Enable_Label1";
            this.Enable_Label1.Size = new System.Drawing.Size(346, 31);
            this.Enable_Label1.TabIndex = 11;
            this.Enable_Label1.Text = "Nr. Comenzi Inregistrate de";
            this.Enable_Label1.Visible = false;
            // 
            // Enable_InfoBox
            // 
            this.Enable_InfoBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Enable_InfoBox.Controls.Add(this.Enable_Label2);
            this.Enable_InfoBox.Controls.Add(this.Enable_NrOrders);
            this.Enable_InfoBox.Controls.Add(this.Enable_Label1);
            this.Enable_InfoBox.Enabled = false;
            this.Enable_InfoBox.Location = new System.Drawing.Point(585, 530);
            this.Enable_InfoBox.Name = "Enable_InfoBox";
            this.Enable_InfoBox.Size = new System.Drawing.Size(458, 191);
            this.Enable_InfoBox.TabIndex = 13;
            this.Enable_InfoBox.TabStop = false;
            this.Enable_InfoBox.Visible = false;
            // 
            // Enable_Label2
            // 
            this.Enable_Label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Enable_Label2.AutoSize = true;
            this.Enable_Label2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Enable_Label2.Enabled = false;
            this.Enable_Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Enable_Label2.Location = new System.Drawing.Point(87, 66);
            this.Enable_Label2.Name = "Enable_Label2";
            this.Enable_Label2.Size = new System.Drawing.Size(311, 39);
            this.Enable_Label2.TabIndex = 13;
            this.Enable_Label2.Text = "NUME PRENUME";
            this.Enable_Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Enable_Label2.Visible = false;
            // 
            // PretTotal_Label2
            // 
            this.PretTotal_Label2.AutoSize = true;
            this.PretTotal_Label2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.PretTotal_Label2.Enabled = false;
            this.PretTotal_Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PretTotal_Label2.Location = new System.Drawing.Point(82, 26);
            this.PretTotal_Label2.Name = "PretTotal_Label2";
            this.PretTotal_Label2.Size = new System.Drawing.Size(132, 31);
            this.PretTotal_Label2.TabIndex = 14;
            this.PretTotal_Label2.Text = "Pret Total";
            this.PretTotal_Label2.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox2.Controls.Add(this.PretTotal_Label2);
            this.groupBox2.Controls.Add(this.PretTotal_Label);
            this.groupBox2.Enabled = false;
            this.groupBox2.Location = new System.Drawing.Point(1326, 530);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(304, 150);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Visible = false;
            // 
            // PretTotal_Label
            // 
            this.PretTotal_Label.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PretTotal_Label.AutoSize = true;
            this.PretTotal_Label.BackColor = System.Drawing.SystemColors.Control;
            this.PretTotal_Label.Enabled = false;
            this.PretTotal_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PretTotal_Label.Location = new System.Drawing.Point(116, 75);
            this.PretTotal_Label.Name = "PretTotal_Label";
            this.PretTotal_Label.Size = new System.Drawing.Size(64, 46);
            this.PretTotal_Label.TabIndex = 9;
            this.PretTotal_Label.Text = "00";
            this.PretTotal_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.PretTotal_Label.Visible = false;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Location = new System.Drawing.Point(10, 18);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(458, 30);
            this.dateTimePicker1.TabIndex = 16;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // SetDeliveryDate
            // 
            this.SetDeliveryDate.BackColor = System.Drawing.Color.SandyBrown;
            this.SetDeliveryDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.SetDeliveryDate.Location = new System.Drawing.Point(10, 54);
            this.SetDeliveryDate.Name = "SetDeliveryDate";
            this.SetDeliveryDate.Size = new System.Drawing.Size(200, 51);
            this.SetDeliveryDate.TabIndex = 17;
            this.SetDeliveryDate.Text = "Set Delivery Date";
            this.SetDeliveryDate.UseVisualStyleBackColor = false;
            this.SetDeliveryDate.Click += new System.EventHandler(this.SetDeliveryDate_Click);
            // 
            // DeliveryPanel
            // 
            this.DeliveryPanel.Controls.Add(this.SetDeliveryDate);
            this.DeliveryPanel.Controls.Add(this.dateTimePicker1);
            this.DeliveryPanel.Location = new System.Drawing.Point(575, 761);
            this.DeliveryPanel.Name = "DeliveryPanel";
            this.DeliveryPanel.Size = new System.Drawing.Size(493, 126);
            this.DeliveryPanel.TabIndex = 18;
            this.DeliveryPanel.Visible = false;
            // 
            // CautaComanda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2083, 990);
            this.Controls.Add(this.DeliveryPanel);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.Enable_InfoBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Comanda_GridView);
            this.Controls.Add(this.Comenzi_GridView);
            this.Controls.Add(this.Client_GridView);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ListaClientiLabel);
            this.Controls.Add(this.TotalClienti);
            this.Name = "CautaComanda";
            this.Text = "CautaComanda";
            this.Load += new System.EventHandler(this.CautaComanda_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Client_GridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Comenzi_GridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Comanda_GridView)).EndInit();
            this.TotalClienti.ResumeLayout(false);
            this.TotalClienti.PerformLayout();
            this.Enable_InfoBox.ResumeLayout(false);
            this.Enable_InfoBox.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.DeliveryPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ListaClientiLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView Client_GridView;
        private System.Windows.Forms.DataGridView Comenzi_GridView;
        private System.Windows.Forms.DataGridView Comanda_GridView;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label NrClienti_Label;
        private System.Windows.Forms.GroupBox TotalClienti;
        private System.Windows.Forms.Label Enable_NrOrders;
        private System.Windows.Forms.Label Enable_Label1;
        private System.Windows.Forms.GroupBox Enable_InfoBox;
        private System.Windows.Forms.Label Enable_Label2;
        private System.Windows.Forms.Label PretTotal_Label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label PretTotal_Label;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button SetDeliveryDate;
        private System.Windows.Forms.Panel DeliveryPanel;
    }
}
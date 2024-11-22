namespace Utilizare_XML
{
    partial class FrmImportXML
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
            this.btnImportXML = new System.Windows.Forms.Button();
            this.dgvMed = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMed)).BeginInit();
            this.SuspendLayout();
            // 
            // btnImportXML
            // 
            this.btnImportXML.Location = new System.Drawing.Point(472, 125);
            this.btnImportXML.Name = "btnImportXML";
            this.btnImportXML.Size = new System.Drawing.Size(116, 23);
            this.btnImportXML.TabIndex = 0;
            this.btnImportXML.Text = "Import XML";
            this.btnImportXML.UseVisualStyleBackColor = true;
            this.btnImportXML.Click += new System.EventHandler(this.btnImportXML_Click);
            // 
            // dgvMed
            // 
            this.dgvMed.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMed.Location = new System.Drawing.Point(40, 76);
            this.dgvMed.Name = "dgvMed";
            this.dgvMed.RowHeadersWidth = 51;
            this.dgvMed.RowTemplate.Height = 24;
            this.dgvMed.Size = new System.Drawing.Size(374, 212);
            this.dgvMed.TabIndex = 2;
            this.dgvMed.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMed_CellContentClick);
            // 
            // FrmImportXML
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvMed);
            this.Controls.Add(this.btnImportXML);
            this.Name = "FrmImportXML";
            this.Text = "FrmImportXML";
            ((System.ComponentModel.ISupportInitialize)(this.dgvMed)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnImportXML;
        private System.Windows.Forms.DataGridView dgvMed;
    }
}
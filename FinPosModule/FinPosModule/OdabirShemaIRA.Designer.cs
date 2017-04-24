namespace FinPosModule
{
    partial class OdabirShemaIRA
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
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("", -1);
            this.label1 = new System.Windows.Forms.Label();
            this.btnObracunOdustani = new System.Windows.Forms.Button();
            this.btnZaduzi = new System.Windows.Forms.Button();
            this.uceKonto = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            ((System.ComponentModel.ISupportInitialize)(this.uceKonto)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Odaberite shemu knjiženja";
            // 
            // btnObracunOdustani
            // 
            this.btnObracunOdustani.Location = new System.Drawing.Point(9, 74);
            this.btnObracunOdustani.Name = "btnObracunOdustani";
            this.btnObracunOdustani.Size = new System.Drawing.Size(69, 25);
            this.btnObracunOdustani.TabIndex = 110;
            this.btnObracunOdustani.Text = "Odustani";
            this.btnObracunOdustani.UseVisualStyleBackColor = true;
            this.btnObracunOdustani.Click += new System.EventHandler(this.btnObracunOdustani_Click);
            // 
            // btnZaduzi
            // 
            this.btnZaduzi.Location = new System.Drawing.Point(249, 74);
            this.btnZaduzi.Name = "btnZaduzi";
            this.btnZaduzi.Size = new System.Drawing.Size(69, 25);
            this.btnZaduzi.TabIndex = 111;
            this.btnZaduzi.Text = "Nastavi";
            this.btnZaduzi.UseVisualStyleBackColor = true;
            this.btnZaduzi.Click += new System.EventHandler(this.btnZaduzi_Click);
            // 
            // uceKonto
            // 
            this.uceKonto.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            ultraGridBand1.ColHeadersVisible = false;
            this.uceKonto.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            this.uceKonto.DisplayMember = "NAZIV";
            this.uceKonto.Location = new System.Drawing.Point(9, 46);
            this.uceKonto.Name = "uceKonto";
            this.uceKonto.Size = new System.Drawing.Size(309, 22);
            this.uceKonto.TabIndex = 117;
            this.uceKonto.UseAppStyling = false;
            this.uceKonto.ValueMember = "ID";
            // 
            // OdabirShemaIRA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.uceKonto);
            this.Controls.Add(this.btnZaduzi);
            this.Controls.Add(this.btnObracunOdustani);
            this.Controls.Add(this.label1);
            this.Name = "OdabirShemaIRA";
            this.Size = new System.Drawing.Size(352, 151);
            ((System.ComponentModel.ISupportInitialize)(this.uceKonto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnObracunOdustani;
        private System.Windows.Forms.Button btnZaduzi;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor uceKonto;
    }
}
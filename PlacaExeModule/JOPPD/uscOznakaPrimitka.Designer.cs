namespace JOPPD
{
    partial class uscOznakaPrimitka
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(uscRadnoVrijeme));
            this.lblValidationMessages = new System.Windows.Forms.Label();
            this.txtOznaka = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnSpremiNovi = new System.Windows.Forms.ToolStripButton();
            this.btnSpremiZatvori = new System.Windows.Forms.ToolStripButton();
            this.btnZatvori = new System.Windows.Forms.ToolStripButton();
            this.txtKratkiOpis = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.txtDugiOpis = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lblDugiOpis = new System.Windows.Forms.Label();
            this.lblKratkiOpis = new System.Windows.Forms.Label();
            this.lblOznaka = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.txtOznaka)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtKratkiOpis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDugiOpis)).BeginInit();
            this.SuspendLayout();
            // 
            // lblValidationMessages
            // 
            this.lblValidationMessages.AutoSize = true;
            this.lblValidationMessages.ForeColor = System.Drawing.Color.Red;
            this.lblValidationMessages.Location = new System.Drawing.Point(5, 21);
            this.lblValidationMessages.Name = "lblValidationMessages";
            this.lblValidationMessages.Padding = new System.Windows.Forms.Padding(0, 2, 0, 5);
            this.lblValidationMessages.Size = new System.Drawing.Size(0, 20);
            this.lblValidationMessages.TabIndex = 18;
            // 
            // txtOznaka
            // 
            this.txtOznaka.Location = new System.Drawing.Point(84, 52);
            this.txtOznaka.MaxLength = 4;
            this.txtOznaka.Name = "txtOznaka";
            this.txtOznaka.Size = new System.Drawing.Size(110, 21);
            this.txtOznaka.TabIndex = 1;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSpremiNovi,
            this.btnSpremiZatvori,
            this.btnZatvori});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(465, 25);
            this.toolStrip1.TabIndex = 22;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnSpremiNovi
            // 
            this.btnSpremiNovi.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnSpremiNovi.Image = ((System.Drawing.Image)(resources.GetObject("btnSpremiNovi.Image")));
            this.btnSpremiNovi.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSpremiNovi.Name = "btnSpremiNovi";
            this.btnSpremiNovi.Size = new System.Drawing.Size(80, 22);
            this.btnSpremiNovi.Text = "Spremi i novi";
            this.btnSpremiNovi.Click += new System.EventHandler(this.btnSpremiNovi_Click);
            // 
            // btnSpremiZatvori
            // 
            this.btnSpremiZatvori.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnSpremiZatvori.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSpremiZatvori.Name = "btnSpremiZatvori";
            this.btnSpremiZatvori.Size = new System.Drawing.Size(92, 22);
            this.btnSpremiZatvori.Text = "Spremi i zatvori";
            this.btnSpremiZatvori.Click += new System.EventHandler(this.btnSpremiZatvori_Click);
            // 
            // btnZatvori
            // 
            this.btnZatvori.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnZatvori.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnZatvori.Name = "btnZatvori";
            this.btnZatvori.Size = new System.Drawing.Size(103, 22);
            this.btnZatvori.Text = "Odustani i zatvori";
            this.btnZatvori.Click += new System.EventHandler(this.btnZatvori_Click);
            // 
            // txtKratkiOpis
            // 
            this.txtKratkiOpis.Location = new System.Drawing.Point(84, 79);
            this.txtKratkiOpis.MaxLength = 140;
            this.txtKratkiOpis.Multiline = true;
            this.txtKratkiOpis.Name = "txtKratkiOpis";
            this.txtKratkiOpis.Size = new System.Drawing.Size(362, 43);
            this.txtKratkiOpis.TabIndex = 23;
            // 
            // txtDugiOpis
            // 
            this.txtDugiOpis.Location = new System.Drawing.Point(84, 128);
            this.txtDugiOpis.MaxLength = 410;
            this.txtDugiOpis.Multiline = true;
            this.txtDugiOpis.Name = "txtDugiOpis";
            this.txtDugiOpis.Size = new System.Drawing.Size(362, 133);
            this.txtDugiOpis.TabIndex = 25;
            // 
            // lblDugiOpis
            // 
            this.lblDugiOpis.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDugiOpis.AutoSize = true;
            this.lblDugiOpis.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblDugiOpis.Location = new System.Drawing.Point(14, 132);
            this.lblDugiOpis.Name = "lblDugiOpis";
            this.lblDugiOpis.Size = new System.Drawing.Size(64, 13);
            this.lblDugiOpis.TabIndex = 28;
            this.lblDugiOpis.Text = "Dugi opis:";
            // 
            // lblKratkiOpis
            // 
            this.lblKratkiOpis.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblKratkiOpis.AutoSize = true;
            this.lblKratkiOpis.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblKratkiOpis.Location = new System.Drawing.Point(7, 83);
            this.lblKratkiOpis.Name = "lblKratkiOpis";
            this.lblKratkiOpis.Size = new System.Drawing.Size(71, 13);
            this.lblKratkiOpis.TabIndex = 27;
            this.lblKratkiOpis.Text = "Kratki opis:";
            // 
            // lblOznaka
            // 
            this.lblOznaka.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblOznaka.AutoSize = true;
            this.lblOznaka.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblOznaka.Location = new System.Drawing.Point(24, 56);
            this.lblOznaka.Name = "lblOznaka";
            this.lblOznaka.Size = new System.Drawing.Size(54, 13);
            this.lblOznaka.TabIndex = 26;
            this.lblOznaka.Text = "Oznaka:";
            // 
            // uscRadnoVrijeme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblDugiOpis);
            this.Controls.Add(this.lblKratkiOpis);
            this.Controls.Add(this.lblOznaka);
            this.Controls.Add(this.txtDugiOpis);
            this.Controls.Add(this.txtKratkiOpis);
            this.Controls.Add(this.txtOznaka);
            this.Controls.Add(this.lblValidationMessages);
            this.Controls.Add(this.toolStrip1);
            this.Name = "uscRadnoVrijeme";
            this.Size = new System.Drawing.Size(465, 305);
            this.Load += new System.EventHandler(this.uscRadnoVrijeme_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtOznaka)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtKratkiOpis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDugiOpis)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtOznaka;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnSpremiZatvori;
        private System.Windows.Forms.ToolStripButton btnZatvori;
        private System.Windows.Forms.Label lblValidationMessages;
        private System.Windows.Forms.ToolStripButton btnSpremiNovi;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtKratkiOpis;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtDugiOpis;
        private System.Windows.Forms.Label lblDugiOpis;
        private System.Windows.Forms.Label lblKratkiOpis;
        private System.Windows.Forms.Label lblOznaka;

    }
}

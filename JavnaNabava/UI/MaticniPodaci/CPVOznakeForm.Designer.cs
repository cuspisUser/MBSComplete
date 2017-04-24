namespace JavnaNabava.UI.MaticniPodaci
{
    partial class uscCPVOznake
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(uscCPVOznake));
            this.tlpCPVOznake = new System.Windows.Forms.TableLayoutPanel();
            this.lblValidationMessages = new System.Windows.Forms.Label();
            this.lblNaziv = new System.Windows.Forms.Label();
            this.uteNaziv = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.tspCPVOznake = new System.Windows.Forms.ToolStrip();
            this.tsbCPVOznakeSpremiNovi = new System.Windows.Forms.ToolStripButton();
            this.tsbCPVOznakeSpremiZatvori = new System.Windows.Forms.ToolStripButton();
            this.tsbCPVOznakeOdustani = new System.Windows.Forms.ToolStripButton();
            this.tlpCPVOznake.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uteNaziv)).BeginInit();
            this.tspCPVOznake.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpCPVOznake
            // 
            this.tlpCPVOznake.AutoSize = true;
            this.tlpCPVOznake.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tlpCPVOznake.ColumnCount = 2;
            this.tlpCPVOznake.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpCPVOznake.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 346F));
            this.tlpCPVOznake.Controls.Add(this.lblValidationMessages, 0, 0);
            this.tlpCPVOznake.Controls.Add(this.lblNaziv, 0, 1);
            this.tlpCPVOznake.Controls.Add(this.uteNaziv, 1, 1);
            this.tlpCPVOznake.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCPVOznake.Location = new System.Drawing.Point(0, 25);
            this.tlpCPVOznake.Name = "tlpCPVOznake";
            this.tlpCPVOznake.Padding = new System.Windows.Forms.Padding(5);
            this.tlpCPVOznake.RowCount = 3;
            this.tlpCPVOznake.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpCPVOznake.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tlpCPVOznake.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 12F));
            this.tlpCPVOznake.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tlpCPVOznake.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tlpCPVOznake.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tlpCPVOznake.Size = new System.Drawing.Size(405, 120);
            this.tlpCPVOznake.TabIndex = 21;
            // 
            // lblValidationMessages
            // 
            this.lblValidationMessages.AutoSize = true;
            this.lblValidationMessages.ForeColor = System.Drawing.Color.Red;
            this.lblValidationMessages.Location = new System.Drawing.Point(8, 5);
            this.lblValidationMessages.Name = "lblValidationMessages";
            this.lblValidationMessages.Padding = new System.Windows.Forms.Padding(0, 2, 0, 5);
            this.lblValidationMessages.Size = new System.Drawing.Size(0, 20);
            this.lblValidationMessages.TabIndex = 18;
            // 
            // lblNaziv
            // 
            this.lblNaziv.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblNaziv.AutoSize = true;
            this.lblNaziv.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblNaziv.Location = new System.Drawing.Point(8, 32);
            this.lblNaziv.Name = "lblNaziv";
            this.lblNaziv.Size = new System.Drawing.Size(43, 13);
            this.lblNaziv.TabIndex = 19;
            this.lblNaziv.Text = "Naziv:";
            // 
            // uteNaziv
            // 
            this.uteNaziv.Location = new System.Drawing.Point(57, 28);
            this.uteNaziv.MaxLength = 50;
            this.uteNaziv.Name = "uteNaziv";
            this.uteNaziv.Size = new System.Drawing.Size(220, 21);
            this.uteNaziv.TabIndex = 20;
            // 
            // tspCPVOznake
            // 
            this.tspCPVOznake.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbCPVOznakeSpremiNovi,
            this.tsbCPVOznakeSpremiZatvori,
            this.tsbCPVOznakeOdustani});
            this.tspCPVOznake.Location = new System.Drawing.Point(0, 0);
            this.tspCPVOznake.Name = "tspCPVOznake";
            this.tspCPVOznake.Size = new System.Drawing.Size(405, 25);
            this.tspCPVOznake.TabIndex = 20;
            this.tspCPVOznake.Text = "toolStrip1";
            // 
            // tsbCPVOznakeSpremiNovi
            // 
            this.tsbCPVOznakeSpremiNovi.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbCPVOznakeSpremiNovi.Image = ((System.Drawing.Image)(resources.GetObject("tsbCPVOznakeSpremiNovi.Image")));
            this.tsbCPVOznakeSpremiNovi.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCPVOznakeSpremiNovi.Name = "tsbCPVOznakeSpremiNovi";
            this.tsbCPVOznakeSpremiNovi.Size = new System.Drawing.Size(80, 22);
            this.tsbCPVOznakeSpremiNovi.Text = "Spremi i novi";
            this.tsbCPVOznakeSpremiNovi.Click += new System.EventHandler(this.tsbCPVOznakeSpremiNovi_Click);
            // 
            // tsbCPVOznakeSpremiZatvori
            // 
            this.tsbCPVOznakeSpremiZatvori.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbCPVOznakeSpremiZatvori.Image = ((System.Drawing.Image)(resources.GetObject("tsbCPVOznakeSpremiZatvori.Image")));
            this.tsbCPVOznakeSpremiZatvori.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCPVOznakeSpremiZatvori.Name = "tsbCPVOznakeSpremiZatvori";
            this.tsbCPVOznakeSpremiZatvori.Size = new System.Drawing.Size(92, 22);
            this.tsbCPVOznakeSpremiZatvori.Text = "Spremi i zatvori";
            this.tsbCPVOznakeSpremiZatvori.Click += new System.EventHandler(this.tsbCPVOznakeSpremiZatvori_Click);
            // 
            // tsbCPVOznakeOdustani
            // 
            this.tsbCPVOznakeOdustani.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbCPVOznakeOdustani.Image = ((System.Drawing.Image)(resources.GetObject("tsbCPVOznakeOdustani.Image")));
            this.tsbCPVOznakeOdustani.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCPVOznakeOdustani.Name = "tsbCPVOznakeOdustani";
            this.tsbCPVOznakeOdustani.Size = new System.Drawing.Size(103, 22);
            this.tsbCPVOznakeOdustani.Text = "Odustani i zatvori";
            this.tsbCPVOznakeOdustani.Click += new System.EventHandler(this.tsbCPVOznakeOdustani_Click);
            // 
            // uscCPVOznake
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlpCPVOznake);
            this.Controls.Add(this.tspCPVOznake);
            this.Name = "uscCPVOznake";
            this.Size = new System.Drawing.Size(405, 145);
            this.Load += new System.EventHandler(this.uscCPVOznake_Load);
            this.tlpCPVOznake.ResumeLayout(false);
            this.tlpCPVOznake.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uteNaziv)).EndInit();
            this.tspCPVOznake.ResumeLayout(false);
            this.tspCPVOznake.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpCPVOznake;
        private System.Windows.Forms.Label lblValidationMessages;
        private System.Windows.Forms.ToolStrip tspCPVOznake;
        private System.Windows.Forms.ToolStripButton tsbCPVOznakeSpremiNovi;
        private System.Windows.Forms.ToolStripButton tsbCPVOznakeSpremiZatvori;
        private System.Windows.Forms.ToolStripButton tsbCPVOznakeOdustani;
        private System.Windows.Forms.Label lblNaziv;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor uteNaziv;


    }
}

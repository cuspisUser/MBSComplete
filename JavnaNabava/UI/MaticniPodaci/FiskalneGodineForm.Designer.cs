namespace JavnaNabava.UI.MaticniPodaci
{
    partial class uscFiskalneGodine
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(uscFiskalneGodine));
            this.tlpVrsteNabave = new System.Windows.Forms.TableLayoutPanel();
            this.lblValidationMessages = new System.Windows.Forms.Label();
            this.lblNaziv = new System.Windows.Forms.Label();
            this.nudGodina = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.cbkAktivna = new System.Windows.Forms.CheckBox();
            this.tspVrsteNabave = new System.Windows.Forms.ToolStrip();
            this.tsbVrsteNabaveSpremiNovi = new System.Windows.Forms.ToolStripButton();
            this.tsbVrsteNabaveSpremiZatvori = new System.Windows.Forms.ToolStripButton();
            this.tsbVrsteNabaveOdustani = new System.Windows.Forms.ToolStripButton();
            this.tlpVrsteNabave.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudGodina)).BeginInit();
            this.tspVrsteNabave.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpVrsteNabave
            // 
            this.tlpVrsteNabave.AutoSize = true;
            this.tlpVrsteNabave.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tlpVrsteNabave.ColumnCount = 2;
            this.tlpVrsteNabave.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpVrsteNabave.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 335F));
            this.tlpVrsteNabave.Controls.Add(this.lblValidationMessages, 0, 0);
            this.tlpVrsteNabave.Controls.Add(this.lblNaziv, 0, 1);
            this.tlpVrsteNabave.Controls.Add(this.nudGodina, 1, 1);
            this.tlpVrsteNabave.Controls.Add(this.label1, 0, 2);
            this.tlpVrsteNabave.Controls.Add(this.cbkAktivna, 1, 2);
            this.tlpVrsteNabave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpVrsteNabave.Location = new System.Drawing.Point(0, 25);
            this.tlpVrsteNabave.Name = "tlpVrsteNabave";
            this.tlpVrsteNabave.Padding = new System.Windows.Forms.Padding(5);
            this.tlpVrsteNabave.RowCount = 4;
            this.tlpVrsteNabave.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpVrsteNabave.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tlpVrsteNabave.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            this.tlpVrsteNabave.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tlpVrsteNabave.Size = new System.Drawing.Size(405, 120);
            this.tlpVrsteNabave.TabIndex = 21;
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
            this.lblNaziv.Size = new System.Drawing.Size(51, 13);
            this.lblNaziv.TabIndex = 20;
            this.lblNaziv.Text = "Godina:";
            // 
            // nudGodina
            // 
            this.nudGodina.Location = new System.Drawing.Point(68, 28);
            this.nudGodina.Maximum = new decimal(new int[] {
            2100,
            0,
            0,
            0});
            this.nudGodina.Minimum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.nudGodina.Name = "nudGodina";
            this.nudGodina.Size = new System.Drawing.Size(120, 20);
            this.nudGodina.TabIndex = 21;
            this.nudGodina.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(8, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Aktivna:";
            // 
            // cbkAktivna
            // 
            this.cbkAktivna.Location = new System.Drawing.Point(68, 55);
            this.cbkAktivna.Name = "cbkAktivna";
            this.cbkAktivna.Size = new System.Drawing.Size(80, 14);
            this.cbkAktivna.TabIndex = 23;
            this.cbkAktivna.UseVisualStyleBackColor = true;
            // 
            // tspVrsteNabave
            // 
            this.tspVrsteNabave.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbVrsteNabaveSpremiNovi,
            this.tsbVrsteNabaveSpremiZatvori,
            this.tsbVrsteNabaveOdustani});
            this.tspVrsteNabave.Location = new System.Drawing.Point(0, 0);
            this.tspVrsteNabave.Name = "tspVrsteNabave";
            this.tspVrsteNabave.Size = new System.Drawing.Size(405, 25);
            this.tspVrsteNabave.TabIndex = 20;
            this.tspVrsteNabave.Text = "toolStrip1";
            // 
            // tsbVrsteNabaveSpremiNovi
            // 
            this.tsbVrsteNabaveSpremiNovi.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbVrsteNabaveSpremiNovi.Image = ((System.Drawing.Image)(resources.GetObject("tsbVrsteNabaveSpremiNovi.Image")));
            this.tsbVrsteNabaveSpremiNovi.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbVrsteNabaveSpremiNovi.Name = "tsbVrsteNabaveSpremiNovi";
            this.tsbVrsteNabaveSpremiNovi.Size = new System.Drawing.Size(80, 22);
            this.tsbVrsteNabaveSpremiNovi.Text = "Spremi i novi";
            this.tsbVrsteNabaveSpremiNovi.Click += new System.EventHandler(this.tsbVrsteNabaveSpremiNovi_Click);
            // 
            // tsbVrsteNabaveSpremiZatvori
            // 
            this.tsbVrsteNabaveSpremiZatvori.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbVrsteNabaveSpremiZatvori.Image = ((System.Drawing.Image)(resources.GetObject("tsbVrsteNabaveSpremiZatvori.Image")));
            this.tsbVrsteNabaveSpremiZatvori.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbVrsteNabaveSpremiZatvori.Name = "tsbVrsteNabaveSpremiZatvori";
            this.tsbVrsteNabaveSpremiZatvori.Size = new System.Drawing.Size(92, 22);
            this.tsbVrsteNabaveSpremiZatvori.Text = "Spremi i zatvori";
            this.tsbVrsteNabaveSpremiZatvori.Click += new System.EventHandler(this.tsbVrsteNabaveSpremiZatvori_Click);
            // 
            // tsbVrsteNabaveOdustani
            // 
            this.tsbVrsteNabaveOdustani.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbVrsteNabaveOdustani.Image = ((System.Drawing.Image)(resources.GetObject("tsbVrsteNabaveOdustani.Image")));
            this.tsbVrsteNabaveOdustani.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbVrsteNabaveOdustani.Name = "tsbVrsteNabaveOdustani";
            this.tsbVrsteNabaveOdustani.Size = new System.Drawing.Size(103, 22);
            this.tsbVrsteNabaveOdustani.Text = "Odustani i zatvori";
            this.tsbVrsteNabaveOdustani.Click += new System.EventHandler(this.tsbVrsteNabaveOdustani_Click);
            // 
            // uscFiskalneGodine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlpVrsteNabave);
            this.Controls.Add(this.tspVrsteNabave);
            this.Name = "uscFiskalneGodine";
            this.Size = new System.Drawing.Size(405, 145);
            this.Load += new System.EventHandler(this.uscFiskalneGodine_Load);
            this.tlpVrsteNabave.ResumeLayout(false);
            this.tlpVrsteNabave.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudGodina)).EndInit();
            this.tspVrsteNabave.ResumeLayout(false);
            this.tspVrsteNabave.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpVrsteNabave;
        private System.Windows.Forms.Label lblValidationMessages;
        private System.Windows.Forms.ToolStrip tspVrsteNabave;
        private System.Windows.Forms.ToolStripButton tsbVrsteNabaveSpremiNovi;
        private System.Windows.Forms.ToolStripButton tsbVrsteNabaveSpremiZatvori;
        private System.Windows.Forms.ToolStripButton tsbVrsteNabaveOdustani;
        private System.Windows.Forms.Label lblNaziv;
        private System.Windows.Forms.NumericUpDown nudGodina;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbkAktivna;


    }
}

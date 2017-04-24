namespace UcenickoFakturiranje.UI.MaticniPodaci
{
    partial class RazredForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RazredForm));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblValidationMessages = new System.Windows.Forms.Label();
            this.TextBoxNaziv = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.ToolStripButtonSpremi = new System.Windows.Forms.ToolStripButton();
            this.ToolStripButtonSpremiZatvori = new System.Windows.Forms.ToolStripButton();
            this.btnRazredOdustani = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TextBoxNaziv)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblValidationMessages, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.TextBoxNaziv, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 25);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(405, 120);
            this.tableLayoutPanel1.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(8, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Naziv:";
            // 
            // lblValidationMessages
            // 
            this.lblValidationMessages.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.lblValidationMessages, 2);
            this.lblValidationMessages.ForeColor = System.Drawing.Color.Red;
            this.lblValidationMessages.Location = new System.Drawing.Point(8, 5);
            this.lblValidationMessages.Name = "lblValidationMessages";
            this.lblValidationMessages.Padding = new System.Windows.Forms.Padding(0, 2, 0, 5);
            this.lblValidationMessages.Size = new System.Drawing.Size(0, 20);
            this.lblValidationMessages.TabIndex = 18;
            // 
            // TextBoxNaziv
            // 
            this.TextBoxNaziv.Location = new System.Drawing.Point(57, 28);
            this.TextBoxNaziv.MaxLength = 20;
            this.TextBoxNaziv.Name = "TextBoxNaziv";
            this.TextBoxNaziv.Size = new System.Drawing.Size(220, 21);
            this.TextBoxNaziv.TabIndex = 1;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripButtonSpremi,
            this.ToolStripButtonSpremiZatvori,
            this.btnRazredOdustani});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(405, 25);
            this.toolStrip1.TabIndex = 18;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // ToolStripButtonSpremi
            // 
            this.ToolStripButtonSpremi.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ToolStripButtonSpremi.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripButtonSpremi.Image")));
            this.ToolStripButtonSpremi.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripButtonSpremi.Name = "ToolStripButtonSpremi";
            this.ToolStripButtonSpremi.Size = new System.Drawing.Size(80, 22);
            this.ToolStripButtonSpremi.Text = "Spremi i novi";
            this.ToolStripButtonSpremi.Click += new System.EventHandler(this.ToolStripButtonSpremi_Click);
            // 
            // ToolStripButtonSpremiZatvori
            // 
            this.ToolStripButtonSpremiZatvori.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ToolStripButtonSpremiZatvori.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripButtonSpremiZatvori.Image")));
            this.ToolStripButtonSpremiZatvori.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripButtonSpremiZatvori.Name = "ToolStripButtonSpremiZatvori";
            this.ToolStripButtonSpremiZatvori.Size = new System.Drawing.Size(92, 22);
            this.ToolStripButtonSpremiZatvori.Text = "Spremi i zatvori";
            this.ToolStripButtonSpremiZatvori.Click += new System.EventHandler(this.ToolStripButtonSpremiZatvori_Click);
            // 
            // btnRazredOdustani
            // 
            this.btnRazredOdustani.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnRazredOdustani.Image = ((System.Drawing.Image)(resources.GetObject("btnRazredOdustani.Image")));
            this.btnRazredOdustani.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRazredOdustani.Name = "btnRazredOdustani";
            this.btnRazredOdustani.Size = new System.Drawing.Size(103, 22);
            this.btnRazredOdustani.Text = "Odustani i zatvori";
            this.btnRazredOdustani.Click += new System.EventHandler(this.btnRazredOdustani_Click);
            // 
            // RazredForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "RazredForm";
            this.Size = new System.Drawing.Size(405, 145);
            this.Load += new System.EventHandler(this.RazredForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TextBoxNaziv)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblValidationMessages;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor TextBoxNaziv;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton ToolStripButtonSpremi;
        private System.Windows.Forms.ToolStripButton ToolStripButtonSpremiZatvori;
        private System.Windows.Forms.ToolStripButton btnRazredOdustani;

    }
}

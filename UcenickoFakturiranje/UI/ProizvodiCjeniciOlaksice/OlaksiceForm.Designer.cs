namespace UcenickoFakturiranje.UI.ProizvodiCjeniciOlaksice
{
    partial class OlaksiceForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OlaksiceForm));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ultraNumericIznosOlaksice = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.ultraNumericPostotakOlaksice = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblValidationMessages = new System.Windows.Forms.Label();
            this.TextBoxNaziv = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.label3 = new System.Windows.Forms.Label();
            this.ultraTextEditor1 = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.ToolStripButtonSpremi = new System.Windows.Forms.ToolStripButton();
            this.ToolStripButtonSpremiZatvori = new System.Windows.Forms.ToolStripButton();
            this.btnOlaksiceZatvori = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraNumericIznosOlaksice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraNumericPostotakOlaksice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBoxNaziv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTextEditor1)).BeginInit();
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
            this.tableLayoutPanel1.Controls.Add(this.ultraNumericIznosOlaksice, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.ultraNumericPostotakOlaksice, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblValidationMessages, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.TextBoxNaziv, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 25);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(720, 216);
            this.tableLayoutPanel1.TabIndex = 23;
            // 
            // ultraNumericIznosOlaksice
            // 
            this.ultraNumericIznosOlaksice.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ultraNumericIznosOlaksice.Location = new System.Drawing.Point(133, 87);
            this.ultraNumericIznosOlaksice.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            this.ultraNumericIznosOlaksice.MaximumSize = new System.Drawing.Size(99999, 0);
            this.ultraNumericIznosOlaksice.MaxValue = 99999D;
            this.ultraNumericIznosOlaksice.Name = "ultraNumericIznosOlaksice";
            this.ultraNumericIznosOlaksice.Nullable = true;
            this.ultraNumericIznosOlaksice.NullText = " ";
            this.ultraNumericIznosOlaksice.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.ultraNumericIznosOlaksice.PromptChar = ' ';
            this.ultraNumericIznosOlaksice.Size = new System.Drawing.Size(151, 21);
            this.ultraNumericIznosOlaksice.TabIndex = 2;
            this.ultraNumericIznosOlaksice.ValueChanged += new System.EventHandler(this.numeric_ValueChanged);
            // 
            // ultraNumericPostotakOlaksice
            // 
            this.ultraNumericPostotakOlaksice.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ultraNumericPostotakOlaksice.Location = new System.Drawing.Point(133, 55);
            this.ultraNumericPostotakOlaksice.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            this.ultraNumericPostotakOlaksice.MaximumSize = new System.Drawing.Size(999, 0);
            this.ultraNumericPostotakOlaksice.MaxValue = 999D;
            this.ultraNumericPostotakOlaksice.Name = "ultraNumericPostotakOlaksice";
            this.ultraNumericPostotakOlaksice.Nullable = true;
            this.ultraNumericPostotakOlaksice.NullText = " ";
            this.ultraNumericPostotakOlaksice.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.ultraNumericPostotakOlaksice.PromptChar = ' ';
            this.ultraNumericPostotakOlaksice.Size = new System.Drawing.Size(151, 21);
            this.ultraNumericPostotakOlaksice.TabIndex = 1;
            this.ultraNumericPostotakOlaksice.ValueChanged += new System.EventHandler(this.numeric_ValueChanged);
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
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(8, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Postotak olakšice";
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
            this.TextBoxNaziv.Location = new System.Drawing.Point(133, 28);
            this.TextBoxNaziv.MaxLength = 300;
            this.TextBoxNaziv.Name = "TextBoxNaziv";
            this.TextBoxNaziv.Size = new System.Drawing.Size(400, 21);
            this.TextBoxNaziv.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(8, 79);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.label3.Size = new System.Drawing.Size(119, 37);
            this.label3.TabIndex = 24;
            this.label3.Text = "Iznos olakšice";
            // 
            // ultraTextEditor1
            // 
            this.ultraTextEditor1.Location = new System.Drawing.Point(133, 55);
            this.ultraTextEditor1.Name = "ultraTextEditor1";
            this.ultraTextEditor1.Size = new System.Drawing.Size(151, 21);
            this.ultraTextEditor1.TabIndex = 26;
            this.ultraTextEditor1.Text = "ultraTextEditor1";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripButtonSpremi,
            this.ToolStripButtonSpremiZatvori,
            this.btnOlaksiceZatvori});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(720, 25);
            this.toolStrip1.TabIndex = 22;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // ToolStripButtonSpremi
            // 
            this.ToolStripButtonSpremi.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ToolStripButtonSpremi.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripButtonSpremi.Name = "ToolStripButtonSpremi";
            this.ToolStripButtonSpremi.Size = new System.Drawing.Size(80, 22);
            this.ToolStripButtonSpremi.Text = "Spremi i novi";
            this.ToolStripButtonSpremi.Click += new System.EventHandler(this.ToolStripButtonSpremi_Click);
            // 
            // ToolStripButtonSpremiZatvori
            // 
            this.ToolStripButtonSpremiZatvori.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ToolStripButtonSpremiZatvori.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripButtonSpremiZatvori.Name = "ToolStripButtonSpremiZatvori";
            this.ToolStripButtonSpremiZatvori.Size = new System.Drawing.Size(92, 22);
            this.ToolStripButtonSpremiZatvori.Text = "Spremi i zatvori";
            this.ToolStripButtonSpremiZatvori.Click += new System.EventHandler(this.ToolStripButtonSpremiZatvori_Click);
            // 
            // btnOlaksiceZatvori
            // 
            this.btnOlaksiceZatvori.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnOlaksiceZatvori.Image = ((System.Drawing.Image)(resources.GetObject("btnOlaksiceZatvori.Image")));
            this.btnOlaksiceZatvori.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOlaksiceZatvori.Name = "btnOlaksiceZatvori";
            this.btnOlaksiceZatvori.Size = new System.Drawing.Size(103, 22);
            this.btnOlaksiceZatvori.Text = "Odustani i zatvori";
            this.btnOlaksiceZatvori.Click += new System.EventHandler(this.btnOlaksiceZatvori_Click);
            // 
            // OlaksiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "OlaksiceForm";
            this.Size = new System.Drawing.Size(720, 241);
            this.Load += new System.EventHandler(this.OlaksiceForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraNumericIznosOlaksice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraNumericPostotakOlaksice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBoxNaziv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTextEditor1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblValidationMessages;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton ToolStripButtonSpremi;
        private System.Windows.Forms.ToolStripButton ToolStripButtonSpremiZatvori;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor TextBoxNaziv;
        private System.Windows.Forms.Label label3;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor ultraTextEditor1;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor ultraNumericPostotakOlaksice;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor ultraNumericIznosOlaksice;
        private System.Windows.Forms.ToolStripButton btnOlaksiceZatvori;
    }
}

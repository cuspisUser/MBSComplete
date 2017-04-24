namespace UcenickoFakturiranje.UI.SkolskeGodineRazrednaOdjeljenja
{
    partial class UstanovaSkolskaGodinaForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UstanovaSkolskaGodinaForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.ToolStripButtonSpremi = new System.Windows.Forms.ToolStripButton();
            this.ToolStripButtonSpremiZatvori = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblValidationMessages = new System.Windows.Forms.Label();
            this.ComboBoxUstanova = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.ComboBoxSkolskaGodina = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.btnUstanovaSkolskaGodinaZatvori = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ComboBoxUstanova)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ComboBoxSkolskaGodina)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripButtonSpremi,
            this.ToolStripButtonSpremiZatvori,
            this.btnUstanovaSkolskaGodinaZatvori});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(532, 25);
            this.toolStrip1.TabIndex = 19;
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
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblValidationMessages, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.ComboBoxUstanova, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.ComboBoxSkolskaGodina, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 25);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(532, 146);
            this.tableLayoutPanel1.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(8, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ustanova:";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(8, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Školska godina:";
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
            // ComboBoxUstanova
            // 
            this.ComboBoxUstanova.DisplayMember = "Naziv";
            this.ComboBoxUstanova.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.ComboBoxUstanova.Location = new System.Drawing.Point(112, 28);
            this.ComboBoxUstanova.MaxDropDownItems = 20;
            this.ComboBoxUstanova.Name = "ComboBoxUstanova";
            this.ComboBoxUstanova.Size = new System.Drawing.Size(335, 21);
            this.ComboBoxUstanova.TabIndex = 21;
            this.ComboBoxUstanova.ValueMember = "ID";
            // 
            // ComboBoxSkolskaGodina
            // 
            this.ComboBoxSkolskaGodina.DisplayMember = "Naziv";
            this.ComboBoxSkolskaGodina.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.ComboBoxSkolskaGodina.Location = new System.Drawing.Point(112, 55);
            this.ComboBoxSkolskaGodina.MaxDropDownItems = 20;
            this.ComboBoxSkolskaGodina.Name = "ComboBoxSkolskaGodina";
            this.ComboBoxSkolskaGodina.Size = new System.Drawing.Size(335, 21);
            this.ComboBoxSkolskaGodina.TabIndex = 22;
            this.ComboBoxSkolskaGodina.ValueMember = "ID";
            // 
            // btnUstanovaSkolskaGodinaZatvori
            // 
            this.btnUstanovaSkolskaGodinaZatvori.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnUstanovaSkolskaGodinaZatvori.Image = ((System.Drawing.Image)(resources.GetObject("btnUstanovaSkolskaGodinaZatvori.Image")));
            this.btnUstanovaSkolskaGodinaZatvori.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUstanovaSkolskaGodinaZatvori.Name = "btnUstanovaSkolskaGodinaZatvori";
            this.btnUstanovaSkolskaGodinaZatvori.Size = new System.Drawing.Size(103, 22);
            this.btnUstanovaSkolskaGodinaZatvori.Text = "Odustani i zatvori";
            this.btnUstanovaSkolskaGodinaZatvori.Click += new System.EventHandler(this.btnUstanovaSkolskaGodinaZatvori_Click);
            // 
            // UstanovaSkolskaGodinaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "UstanovaSkolskaGodinaForm";
            this.Size = new System.Drawing.Size(532, 171);
            this.Load += new System.EventHandler(this.UstanovaSkolskaGodinaForm_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ComboBoxUstanova)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ComboBoxSkolskaGodina)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton ToolStripButtonSpremi;
        private System.Windows.Forms.ToolStripButton ToolStripButtonSpremiZatvori;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblValidationMessages;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor ComboBoxUstanova;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor ComboBoxSkolskaGodina;
        private System.Windows.Forms.ToolStripButton btnUstanovaSkolskaGodinaZatvori;
    }
}

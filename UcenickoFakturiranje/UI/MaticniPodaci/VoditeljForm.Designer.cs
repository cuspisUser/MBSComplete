namespace UcenickoFakturiranje.UI.MaticniPodaci
{
    partial class VoditeljForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VoditeljForm));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblValidationMessages = new System.Windows.Forms.Label();
            this.TextBoxIme = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.TextBoxPrezime = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.TextBoxOIB = new UcenickoFakturiranje.Controls.TextBoxNumericInteger();
            this.ComboBoxRadnoMjesto = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.CheckBoxAktivnost = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.ToolStripButtonSpremi = new System.Windows.Forms.ToolStripButton();
            this.ToolStripButtonSpremiZatvori = new System.Windows.Forms.ToolStripButton();
            this.btnVoditeljiZatvori = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TextBoxIme)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBoxPrezime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBoxOIB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ComboBoxRadnoMjesto)).BeginInit();
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
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblValidationMessages, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.TextBoxIme, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.TextBoxPrezime, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.TextBoxOIB, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.ComboBoxRadnoMjesto, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.CheckBoxAktivnost, 1, 5);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 25);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(436, 209);
            this.tableLayoutPanel1.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(8, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "OIB:";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(8, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ime:";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(8, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Prezime:";
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
            // TextBoxIme
            // 
            this.TextBoxIme.Location = new System.Drawing.Point(89, 28);
            this.TextBoxIme.MaxLength = 50;
            this.TextBoxIme.Name = "TextBoxIme";
            this.TextBoxIme.Size = new System.Drawing.Size(215, 21);
            this.TextBoxIme.TabIndex = 1;
            // 
            // TextBoxPrezime
            // 
            this.TextBoxPrezime.Location = new System.Drawing.Point(89, 55);
            this.TextBoxPrezime.MaxLength = 50;
            this.TextBoxPrezime.Name = "TextBoxPrezime";
            this.TextBoxPrezime.Size = new System.Drawing.Size(215, 21);
            this.TextBoxPrezime.TabIndex = 2;
            // 
            // TextBoxOIB
            // 
            this.TextBoxOIB.Location = new System.Drawing.Point(89, 82);
            this.TextBoxOIB.MaxLength = 11;
            this.TextBoxOIB.Name = "TextBoxOIB";
            this.TextBoxOIB.Size = new System.Drawing.Size(100, 21);
            this.TextBoxOIB.TabIndex = 3;
            // 
            // ComboBoxRadnoMjesto
            // 
            this.ComboBoxRadnoMjesto.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend;
            this.ComboBoxRadnoMjesto.DisplayMember = "RadnoMjesto";
            this.ComboBoxRadnoMjesto.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.ComboBoxRadnoMjesto.Location = new System.Drawing.Point(89, 109);
            this.ComboBoxRadnoMjesto.MaxDropDownItems = 20;
            this.ComboBoxRadnoMjesto.Name = "ComboBoxRadnoMjesto";
            this.ComboBoxRadnoMjesto.Size = new System.Drawing.Size(335, 21);
            this.ComboBoxRadnoMjesto.TabIndex = 4;
            this.ComboBoxRadnoMjesto.ValueMember = "ID";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 113);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Radno mjesto:";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Aktivan:";
            // 
            // CheckBoxAktivnost
            // 
            this.CheckBoxAktivnost.Checked = true;
            this.CheckBoxAktivnost.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBoxAktivnost.Location = new System.Drawing.Point(89, 136);
            this.CheckBoxAktivnost.Name = "CheckBoxAktivnost";
            this.CheckBoxAktivnost.Size = new System.Drawing.Size(22, 20);
            this.CheckBoxAktivnost.TabIndex = 20;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripButtonSpremi,
            this.ToolStripButtonSpremiZatvori,
            this.btnVoditeljiZatvori});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(436, 25);
            this.toolStrip1.TabIndex = 17;
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
            // btnVoditeljiZatvori
            // 
            this.btnVoditeljiZatvori.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnVoditeljiZatvori.Image = ((System.Drawing.Image)(resources.GetObject("btnVoditeljiZatvori.Image")));
            this.btnVoditeljiZatvori.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnVoditeljiZatvori.Name = "btnVoditeljiZatvori";
            this.btnVoditeljiZatvori.Size = new System.Drawing.Size(103, 22);
            this.btnVoditeljiZatvori.Text = "Odustani i zatvori";
            this.btnVoditeljiZatvori.Click += new System.EventHandler(this.btnVoditeljiZatvori_Click);
            // 
            // VoditeljForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "VoditeljForm";
            this.Size = new System.Drawing.Size(436, 234);
            this.Load += new System.EventHandler(this.VoditeljForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TextBoxIme)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBoxPrezime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBoxOIB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ComboBoxRadnoMjesto)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblValidationMessages;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor TextBoxIme;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor TextBoxPrezime;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor ComboBoxRadnoMjesto;
        private Controls.TextBoxNumericInteger TextBoxOIB;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton ToolStripButtonSpremi;
        private System.Windows.Forms.ToolStripButton ToolStripButtonSpremiZatvori;
        private System.Windows.Forms.Label label4;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor CheckBoxAktivnost;
        private System.Windows.Forms.ToolStripButton btnVoditeljiZatvori;

    }
}

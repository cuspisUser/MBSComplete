namespace JOPPD
{
    partial class uscOsobeVeze
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(uscOsobeVeze));
            this.lblValidationMessages = new System.Windows.Forms.Label();
            this.lblImePrezime = new System.Windows.Forms.Label();
            this.tsIzbornik = new System.Windows.Forms.ToolStrip();
            this.btnSpremiNovi = new System.Windows.Forms.ToolStripButton();
            this.btnSpremiZatvori = new System.Windows.Forms.ToolStripButton();
            this.btnZatvori = new System.Windows.Forms.ToolStripButton();
            this.uceOsoba = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.uceVrstaVeze1 = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.cbkVrstaVeze1 = new System.Windows.Forms.CheckBox();
            this.cbkVrstaVeze2 = new System.Windows.Forms.CheckBox();
            this.uceVrstaVeze2 = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.cbkVrstaVeze4 = new System.Windows.Forms.CheckBox();
            this.uceVrstaVeze4 = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.cbkVrstaVeze3 = new System.Windows.Forms.CheckBox();
            this.uceVrstaVeze3 = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.uceOsobaVeza4 = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.uceOsobaVeza3 = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.uceOsobaVeza2 = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.uceOsobaVeza1 = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.tsIzbornik.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uceOsoba)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uceVrstaVeze1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uceVrstaVeze2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uceVrstaVeze4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uceVrstaVeze3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uceOsobaVeza4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uceOsobaVeza3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uceOsobaVeza2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uceOsobaVeza1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblValidationMessages
            // 
            this.lblValidationMessages.AutoSize = true;
            this.lblValidationMessages.ForeColor = System.Drawing.Color.Red;
            this.lblValidationMessages.Location = new System.Drawing.Point(3, 25);
            this.lblValidationMessages.Name = "lblValidationMessages";
            this.lblValidationMessages.Padding = new System.Windows.Forms.Padding(0, 2, 0, 5);
            this.lblValidationMessages.Size = new System.Drawing.Size(0, 20);
            this.lblValidationMessages.TabIndex = 18;
            // 
            // lblImePrezime
            // 
            this.lblImePrezime.AutoSize = true;
            this.lblImePrezime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblImePrezime.Location = new System.Drawing.Point(39, 61);
            this.lblImePrezime.Name = "lblImePrezime";
            this.lblImePrezime.Size = new System.Drawing.Size(44, 13);
            this.lblImePrezime.TabIndex = 26;
            this.lblImePrezime.Text = "Učenik:";
            // 
            // tsIzbornik
            // 
            this.tsIzbornik.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSpremiNovi,
            this.btnSpremiZatvori,
            this.btnZatvori});
            this.tsIzbornik.Location = new System.Drawing.Point(0, 0);
            this.tsIzbornik.Name = "tsIzbornik";
            this.tsIzbornik.Size = new System.Drawing.Size(489, 25);
            this.tsIzbornik.TabIndex = 131;
            this.tsIzbornik.Text = "toolStrip1";
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
            // uceOsoba
            // 
            this.uceOsoba.DisplayMember = "Naziv";
            this.uceOsoba.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.uceOsoba.Location = new System.Drawing.Point(89, 57);
            this.uceOsoba.MaxDropDownItems = 20;
            this.uceOsoba.Name = "uceOsoba";
            this.uceOsoba.Size = new System.Drawing.Size(177, 21);
            this.uceOsoba.TabIndex = 134;
            this.uceOsoba.ValueMember = "ID";
            this.uceOsoba.ValueChanged += new System.EventHandler(this.uceOsoba_ValueChanged);
            // 
            // uceVrstaVeze1
            // 
            this.uceVrstaVeze1.DisplayMember = "Naziv";
            this.uceVrstaVeze1.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.uceVrstaVeze1.Location = new System.Drawing.Point(290, 116);
            this.uceVrstaVeze1.MaxDropDownItems = 20;
            this.uceVrstaVeze1.Name = "uceVrstaVeze1";
            this.uceVrstaVeze1.Size = new System.Drawing.Size(177, 21);
            this.uceVrstaVeze1.TabIndex = 137;
            this.uceVrstaVeze1.ValueMember = "ID";
            this.uceVrstaVeze1.Visible = false;
            this.uceVrstaVeze1.ValueChanged += new System.EventHandler(this.uceVrstaVeze1_ValueChanged);
            // 
            // cbkVrstaVeze1
            // 
            this.cbkVrstaVeze1.AutoSize = true;
            this.cbkVrstaVeze1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbkVrstaVeze1.Location = new System.Drawing.Point(14, 90);
            this.cbkVrstaVeze1.Name = "cbkVrstaVeze1";
            this.cbkVrstaVeze1.Size = new System.Drawing.Size(88, 17);
            this.cbkVrstaVeze1.TabIndex = 139;
            this.cbkVrstaVeze1.Text = "Veza učenik:";
            this.cbkVrstaVeze1.UseVisualStyleBackColor = true;
            this.cbkVrstaVeze1.Visible = false;
            this.cbkVrstaVeze1.CheckedChanged += new System.EventHandler(this.cbkVrstaVeze1_CheckedChanged);
            // 
            // cbkVrstaVeze2
            // 
            this.cbkVrstaVeze2.AutoSize = true;
            this.cbkVrstaVeze2.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbkVrstaVeze2.Location = new System.Drawing.Point(7, 149);
            this.cbkVrstaVeze2.Name = "cbkVrstaVeze2";
            this.cbkVrstaVeze2.Size = new System.Drawing.Size(96, 17);
            this.cbkVrstaVeze2.TabIndex = 141;
            this.cbkVrstaVeze2.Text = "Dodatna veza:";
            this.cbkVrstaVeze2.UseVisualStyleBackColor = true;
            this.cbkVrstaVeze2.Visible = false;
            this.cbkVrstaVeze2.CheckedChanged += new System.EventHandler(this.cbkVrstaVeze2_CheckedChanged);
            // 
            // uceVrstaVeze2
            // 
            this.uceVrstaVeze2.DisplayMember = "Naziv";
            this.uceVrstaVeze2.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.uceVrstaVeze2.Location = new System.Drawing.Point(290, 175);
            this.uceVrstaVeze2.MaxDropDownItems = 20;
            this.uceVrstaVeze2.Name = "uceVrstaVeze2";
            this.uceVrstaVeze2.Size = new System.Drawing.Size(177, 21);
            this.uceVrstaVeze2.TabIndex = 140;
            this.uceVrstaVeze2.ValueMember = "ID";
            this.uceVrstaVeze2.Visible = false;
            this.uceVrstaVeze2.ValueChanged += new System.EventHandler(this.uceVrstaVeze2_ValueChanged);
            // 
            // cbkVrstaVeze4
            // 
            this.cbkVrstaVeze4.AutoSize = true;
            this.cbkVrstaVeze4.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbkVrstaVeze4.Location = new System.Drawing.Point(7, 267);
            this.cbkVrstaVeze4.Name = "cbkVrstaVeze4";
            this.cbkVrstaVeze4.Size = new System.Drawing.Size(96, 17);
            this.cbkVrstaVeze4.TabIndex = 145;
            this.cbkVrstaVeze4.Text = "Dodatna veza:";
            this.cbkVrstaVeze4.UseVisualStyleBackColor = true;
            this.cbkVrstaVeze4.Visible = false;
            this.cbkVrstaVeze4.CheckedChanged += new System.EventHandler(this.cbkVrstaVeze4_CheckedChanged);
            // 
            // uceVrstaVeze4
            // 
            this.uceVrstaVeze4.DisplayMember = "Naziv";
            this.uceVrstaVeze4.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.uceVrstaVeze4.Location = new System.Drawing.Point(290, 293);
            this.uceVrstaVeze4.MaxDropDownItems = 20;
            this.uceVrstaVeze4.Name = "uceVrstaVeze4";
            this.uceVrstaVeze4.Size = new System.Drawing.Size(177, 21);
            this.uceVrstaVeze4.TabIndex = 144;
            this.uceVrstaVeze4.ValueMember = "ID";
            this.uceVrstaVeze4.Visible = false;
            // 
            // cbkVrstaVeze3
            // 
            this.cbkVrstaVeze3.AutoSize = true;
            this.cbkVrstaVeze3.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbkVrstaVeze3.Location = new System.Drawing.Point(7, 207);
            this.cbkVrstaVeze3.Name = "cbkVrstaVeze3";
            this.cbkVrstaVeze3.Size = new System.Drawing.Size(96, 17);
            this.cbkVrstaVeze3.TabIndex = 143;
            this.cbkVrstaVeze3.Text = "Dodatna veza:";
            this.cbkVrstaVeze3.UseVisualStyleBackColor = true;
            this.cbkVrstaVeze3.Visible = false;
            this.cbkVrstaVeze3.CheckedChanged += new System.EventHandler(this.cbkVrstaVeze3_CheckedChanged);
            // 
            // uceVrstaVeze3
            // 
            this.uceVrstaVeze3.DisplayMember = "Naziv";
            this.uceVrstaVeze3.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.uceVrstaVeze3.Location = new System.Drawing.Point(290, 234);
            this.uceVrstaVeze3.MaxDropDownItems = 20;
            this.uceVrstaVeze3.Name = "uceVrstaVeze3";
            this.uceVrstaVeze3.Size = new System.Drawing.Size(177, 21);
            this.uceVrstaVeze3.TabIndex = 142;
            this.uceVrstaVeze3.ValueMember = "ID";
            this.uceVrstaVeze3.Visible = false;
            this.uceVrstaVeze3.ValueChanged += new System.EventHandler(this.uceVrstaVeze3_ValueChanged);
            // 
            // uceOsobaVeza4
            // 
            this.uceOsobaVeza4.DisplayMember = "Naziv";
            this.uceOsobaVeza4.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.uceOsobaVeza4.Location = new System.Drawing.Point(89, 293);
            this.uceOsobaVeza4.MaxDropDownItems = 20;
            this.uceOsobaVeza4.Name = "uceOsobaVeza4";
            this.uceOsobaVeza4.Size = new System.Drawing.Size(177, 21);
            this.uceOsobaVeza4.TabIndex = 149;
            this.uceOsobaVeza4.ValueMember = "ID";
            this.uceOsobaVeza4.Visible = false;
            this.uceOsobaVeza4.ValueChanged += new System.EventHandler(this.uceOsobaVeza4_ValueChanged);
            // 
            // uceOsobaVeza3
            // 
            this.uceOsobaVeza3.DisplayMember = "Naziv";
            this.uceOsobaVeza3.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.uceOsobaVeza3.Location = new System.Drawing.Point(89, 234);
            this.uceOsobaVeza3.MaxDropDownItems = 20;
            this.uceOsobaVeza3.Name = "uceOsobaVeza3";
            this.uceOsobaVeza3.Size = new System.Drawing.Size(177, 21);
            this.uceOsobaVeza3.TabIndex = 148;
            this.uceOsobaVeza3.ValueMember = "ID";
            this.uceOsobaVeza3.Visible = false;
            this.uceOsobaVeza3.ValueChanged += new System.EventHandler(this.uceOsobaVeza3_ValueChanged);
            // 
            // uceOsobaVeza2
            // 
            this.uceOsobaVeza2.DisplayMember = "Naziv";
            this.uceOsobaVeza2.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.uceOsobaVeza2.Location = new System.Drawing.Point(89, 175);
            this.uceOsobaVeza2.MaxDropDownItems = 20;
            this.uceOsobaVeza2.Name = "uceOsobaVeza2";
            this.uceOsobaVeza2.Size = new System.Drawing.Size(177, 21);
            this.uceOsobaVeza2.TabIndex = 147;
            this.uceOsobaVeza2.ValueMember = "ID";
            this.uceOsobaVeza2.Visible = false;
            this.uceOsobaVeza2.ValueChanged += new System.EventHandler(this.uceOsobaVeza2_ValueChanged);
            // 
            // uceOsobaVeza1
            // 
            this.uceOsobaVeza1.DisplayMember = "Naziv";
            this.uceOsobaVeza1.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.uceOsobaVeza1.Location = new System.Drawing.Point(89, 116);
            this.uceOsobaVeza1.MaxDropDownItems = 20;
            this.uceOsobaVeza1.Name = "uceOsobaVeza1";
            this.uceOsobaVeza1.Size = new System.Drawing.Size(177, 21);
            this.uceOsobaVeza1.TabIndex = 146;
            this.uceOsobaVeza1.ValueMember = "ID";
            this.uceOsobaVeza1.Visible = false;
            this.uceOsobaVeza1.ValueChanged += new System.EventHandler(this.uceOsobaVeza1_ValueChanged);
            // 
            // uscOsobeVeze
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 364);
            this.ControlBox = false;
            this.Controls.Add(this.uceOsobaVeza4);
            this.Controls.Add(this.uceOsobaVeza3);
            this.Controls.Add(this.uceOsobaVeza2);
            this.Controls.Add(this.uceOsobaVeza1);
            this.Controls.Add(this.cbkVrstaVeze4);
            this.Controls.Add(this.uceVrstaVeze4);
            this.Controls.Add(this.cbkVrstaVeze3);
            this.Controls.Add(this.uceVrstaVeze3);
            this.Controls.Add(this.cbkVrstaVeze2);
            this.Controls.Add(this.uceVrstaVeze2);
            this.Controls.Add(this.cbkVrstaVeze1);
            this.Controls.Add(this.uceVrstaVeze1);
            this.Controls.Add(this.uceOsoba);
            this.Controls.Add(this.tsIzbornik);
            this.Controls.Add(this.lblImePrezime);
            this.Controls.Add(this.lblValidationMessages);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "uscOsobeVeze";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.uscOsobeVeze_Load);
            this.tsIzbornik.ResumeLayout(false);
            this.tsIzbornik.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uceOsoba)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uceVrstaVeze1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uceVrstaVeze2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uceVrstaVeze4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uceVrstaVeze3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uceOsobaVeza4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uceOsobaVeza3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uceOsobaVeza2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uceOsobaVeza1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblValidationMessages;
        private System.Windows.Forms.Label lblImePrezime;
        private System.Windows.Forms.ToolStrip tsIzbornik;
        private System.Windows.Forms.ToolStripButton btnSpremiNovi;
        private System.Windows.Forms.ToolStripButton btnSpremiZatvori;
        private System.Windows.Forms.ToolStripButton btnZatvori;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor uceOsoba;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor uceVrstaVeze1;
        private System.Windows.Forms.CheckBox cbkVrstaVeze1;
        private System.Windows.Forms.CheckBox cbkVrstaVeze2;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor uceVrstaVeze2;
        private System.Windows.Forms.CheckBox cbkVrstaVeze4;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor uceVrstaVeze4;
        private System.Windows.Forms.CheckBox cbkVrstaVeze3;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor uceVrstaVeze3;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor uceOsobaVeza4;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor uceOsobaVeza3;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor uceOsobaVeza2;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor uceOsobaVeza1;

    }
}

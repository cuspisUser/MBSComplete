namespace Materijalno.UI.Skladista
{
    partial class OtvaranjeSkladistaForm
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
            this.tspForm = new System.Windows.Forms.ToolStrip();
            this.tsbSpremiZatvori = new System.Windows.Forms.ToolStripButton();
            this.tsbSpremiNovi = new System.Windows.Forms.ToolStripButton();
            this.tsbOdustani = new System.Windows.Forms.ToolStripButton();
            this.lblValidationMessages = new System.Windows.Forms.Label();
            this.uceOrgJedinice = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.uteNazivSkladista = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.uceMjestoTroskova = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.uceTipSkladista = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.lblName6 = new System.Windows.Forms.Label();
            this.lblName4 = new System.Windows.Forms.Label();
            this.lblName2 = new System.Windows.Forms.Label();
            this.lblName1 = new System.Windows.Forms.Label();
            this.uteSifraSkladista = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbkPorez = new System.Windows.Forms.CheckBox();
            this.tspForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uceOrgJedinice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uteNazivSkladista)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uceMjestoTroskova)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uceTipSkladista)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uteSifraSkladista)).BeginInit();
            this.SuspendLayout();
            // 
            // tspForm
            // 
            this.tspForm.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbSpremiZatvori,
            this.tsbSpremiNovi,
            this.tsbOdustani});
            this.tspForm.Location = new System.Drawing.Point(0, 0);
            this.tspForm.Name = "tspForm";
            this.tspForm.Size = new System.Drawing.Size(437, 25);
            this.tspForm.TabIndex = 10;
            this.tspForm.Text = "toolStrip1";
            // 
            // tsbSpremiZatvori
            // 
            this.tsbSpremiZatvori.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbSpremiZatvori.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSpremiZatvori.Name = "tsbSpremiZatvori";
            this.tsbSpremiZatvori.Size = new System.Drawing.Size(92, 22);
            this.tsbSpremiZatvori.Text = "Spremi i zatvori";
            this.tsbSpremiZatvori.Click += new System.EventHandler(this.tsbSpremiZatvori_Click);
            // 
            // tsbSpremiNovi
            // 
            this.tsbSpremiNovi.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbSpremiNovi.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSpremiNovi.Name = "tsbSpremiNovi";
            this.tsbSpremiNovi.Size = new System.Drawing.Size(80, 22);
            this.tsbSpremiNovi.Text = "Spremi i novi";
            this.tsbSpremiNovi.Click += new System.EventHandler(this.tsbSpremiNovi_Click);
            // 
            // tsbOdustani
            // 
            this.tsbOdustani.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbOdustani.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbOdustani.Name = "tsbOdustani";
            this.tsbOdustani.Size = new System.Drawing.Size(103, 22);
            this.tsbOdustani.Text = "Odustani i zatvori";
            this.tsbOdustani.Click += new System.EventHandler(this.tsbOdustani_Click);
            // 
            // lblValidationMessages
            // 
            this.lblValidationMessages.AutoSize = true;
            this.lblValidationMessages.ForeColor = System.Drawing.Color.Red;
            this.lblValidationMessages.Location = new System.Drawing.Point(8, 25);
            this.lblValidationMessages.Name = "lblValidationMessages";
            this.lblValidationMessages.Padding = new System.Windows.Forms.Padding(0, 2, 0, 5);
            this.lblValidationMessages.Size = new System.Drawing.Size(0, 20);
            this.lblValidationMessages.TabIndex = 67;
            // 
            // uceOrgJedinice
            // 
            this.uceOrgJedinice.DisplayMember = "Naziv";
            this.uceOrgJedinice.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.uceOrgJedinice.Location = new System.Drawing.Point(132, 157);
            this.uceOrgJedinice.MaxDropDownItems = 20;
            this.uceOrgJedinice.Name = "uceOrgJedinice";
            this.uceOrgJedinice.Size = new System.Drawing.Size(246, 21);
            this.uceOrgJedinice.TabIndex = 6;
            this.uceOrgJedinice.ValueMember = "ID";
            // 
            // uteNazivSkladista
            // 
            this.uteNazivSkladista.Location = new System.Drawing.Point(132, 76);
            this.uteNazivSkladista.MaxLength = 50;
            this.uteNazivSkladista.Name = "uteNazivSkladista";
            this.uteNazivSkladista.Size = new System.Drawing.Size(246, 21);
            this.uteNazivSkladista.TabIndex = 2;
            // 
            // uceMjestoTroskova
            // 
            this.uceMjestoTroskova.DisplayMember = "Naziv";
            this.uceMjestoTroskova.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.uceMjestoTroskova.Location = new System.Drawing.Point(132, 129);
            this.uceMjestoTroskova.MaxDropDownItems = 20;
            this.uceMjestoTroskova.Name = "uceMjestoTroskova";
            this.uceMjestoTroskova.Size = new System.Drawing.Size(246, 21);
            this.uceMjestoTroskova.TabIndex = 5;
            this.uceMjestoTroskova.ValueMember = "ID";
            // 
            // uceTipSkladista
            // 
            this.uceTipSkladista.DisplayMember = "Naziv";
            this.uceTipSkladista.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.uceTipSkladista.Location = new System.Drawing.Point(132, 102);
            this.uceTipSkladista.MaxDropDownItems = 20;
            this.uceTipSkladista.Name = "uceTipSkladista";
            this.uceTipSkladista.Size = new System.Drawing.Size(246, 21);
            this.uceTipSkladista.TabIndex = 3;
            this.uceTipSkladista.ValueMember = "ID";
            // 
            // lblName6
            // 
            this.lblName6.AutoSize = true;
            this.lblName6.Location = new System.Drawing.Point(8, 161);
            this.lblName6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblName6.Name = "lblName6";
            this.lblName6.Size = new System.Drawing.Size(118, 13);
            this.lblName6.TabIndex = 87;
            this.lblName6.Text = "Organizacijska jedinica:";
            // 
            // lblName4
            // 
            this.lblName4.AutoSize = true;
            this.lblName4.Location = new System.Drawing.Point(8, 133);
            this.lblName4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblName4.Name = "lblName4";
            this.lblName4.Size = new System.Drawing.Size(73, 13);
            this.lblName4.TabIndex = 86;
            this.lblName4.Text = "Mjesto troška:";
            // 
            // lblName2
            // 
            this.lblName2.AutoSize = true;
            this.lblName2.Location = new System.Drawing.Point(8, 106);
            this.lblName2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblName2.Name = "lblName2";
            this.lblName2.Size = new System.Drawing.Size(69, 13);
            this.lblName2.TabIndex = 84;
            this.lblName2.Text = "Tip skladišta:";
            // 
            // lblName1
            // 
            this.lblName1.AutoSize = true;
            this.lblName1.Location = new System.Drawing.Point(8, 80);
            this.lblName1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblName1.Name = "lblName1";
            this.lblName1.Size = new System.Drawing.Size(81, 13);
            this.lblName1.TabIndex = 83;
            this.lblName1.Text = "Naziv skladišta:";
            // 
            // uteSifraSkladista
            // 
            this.uteSifraSkladista.Location = new System.Drawing.Point(132, 50);
            this.uteSifraSkladista.MaxLength = 50;
            this.uteSifraSkladista.Name = "uteSifraSkladista";
            this.uteSifraSkladista.Size = new System.Drawing.Size(246, 21);
            this.uteSifraSkladista.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 54);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 93;
            this.label1.Text = "Šifra skladišta:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 186);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 94;
            this.label2.Text = "Odbitak poreza:";
            // 
            // cbkPorez
            // 
            this.cbkPorez.AutoSize = true;
            this.cbkPorez.Location = new System.Drawing.Point(132, 185);
            this.cbkPorez.Name = "cbkPorez";
            this.cbkPorez.Size = new System.Drawing.Size(15, 14);
            this.cbkPorez.TabIndex = 95;
            this.cbkPorez.UseVisualStyleBackColor = true;
            // 
            // OtvaranjeSkladistaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbkPorez);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.uteSifraSkladista);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.uceOrgJedinice);
            this.Controls.Add(this.uteNazivSkladista);
            this.Controls.Add(this.uceMjestoTroskova);
            this.Controls.Add(this.uceTipSkladista);
            this.Controls.Add(this.lblName6);
            this.Controls.Add(this.lblName4);
            this.Controls.Add(this.lblName2);
            this.Controls.Add(this.lblName1);
            this.Controls.Add(this.lblValidationMessages);
            this.Controls.Add(this.tspForm);
            this.Name = "OtvaranjeSkladistaForm";
            this.Size = new System.Drawing.Size(437, 243);
            this.Load += new System.EventHandler(this.FormLoad);
            this.tspForm.ResumeLayout(false);
            this.tspForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uceOrgJedinice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uteNazivSkladista)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uceMjestoTroskova)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uceTipSkladista)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uteSifraSkladista)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tspForm;
        private System.Windows.Forms.ToolStripButton tsbSpremiZatvori;
        private System.Windows.Forms.ToolStripButton tsbOdustani;
        private System.Windows.Forms.Label lblValidationMessages;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor uceOrgJedinice;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor uteNazivSkladista;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor uceMjestoTroskova;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor uceTipSkladista;
        private System.Windows.Forms.Label lblName6;
        private System.Windows.Forms.Label lblName4;
        private System.Windows.Forms.Label lblName2;
        private System.Windows.Forms.Label lblName1;
        private System.Windows.Forms.ToolStripButton tsbSpremiNovi;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor uteSifraSkladista;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cbkPorez;


    }
}

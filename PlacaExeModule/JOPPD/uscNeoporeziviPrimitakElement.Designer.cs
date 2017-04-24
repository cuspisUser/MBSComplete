namespace JOPPD
{
    partial class uscNeoporeziviPrimitakElement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(uscNacinIsplateElement));
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem3 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem4 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem5 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem6 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem7 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem8 = new Infragistics.Win.ValueListItem();
            this.lblValidationMessages = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnSpremiNovi = new System.Windows.Forms.ToolStripButton();
            this.btnSpremiZatvori = new System.Windows.Forms.ToolStripButton();
            this.btnZatvori = new System.Windows.Forms.ToolStripButton();
            this.lblKratkiOpis = new System.Windows.Forms.Label();
            this.lblOznaka = new System.Windows.Forms.Label();
            this.ucbJOPPDOznaka = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.ucbElement = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ucbJOPPDOznaka)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucbElement)).BeginInit();
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
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSpremiNovi,
            this.btnSpremiZatvori,
            this.btnZatvori});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(574, 25);
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
            // lblKratkiOpis
            // 
            this.lblKratkiOpis.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblKratkiOpis.AutoSize = true;
            this.lblKratkiOpis.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblKratkiOpis.Location = new System.Drawing.Point(47, 82);
            this.lblKratkiOpis.Name = "lblKratkiOpis";
            this.lblKratkiOpis.Size = new System.Drawing.Size(56, 13);
            this.lblKratkiOpis.TabIndex = 27;
            this.lblKratkiOpis.Text = "Element:";
            // 
            // lblOznaka
            // 
            this.lblOznaka.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblOznaka.AutoSize = true;
            this.lblOznaka.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblOznaka.Location = new System.Drawing.Point(5, 55);
            this.lblOznaka.Name = "lblOznaka";
            this.lblOznaka.Size = new System.Drawing.Size(98, 13);
            this.lblOznaka.TabIndex = 26;
            this.lblOznaka.Text = "JOPPD Oznaka:";
            // 
            // ucbJOPPDOznaka
            // 
            this.ucbJOPPDOznaka.DisplayMember = "Naziv";
            this.ucbJOPPDOznaka.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            valueListItem1.DataValue = "-";
            valueListItem1.DisplayText = "- povlaka";
            valueListItem2.DataValue = "/";
            valueListItem2.DisplayText = "/ kosa crta";
            valueListItem3.DataValue = "\\";
            valueListItem3.DisplayText = "\\ kosa crta unatrag";
            valueListItem4.DataValue = ".";
            valueListItem4.DisplayText = ". tocka";
            this.ucbJOPPDOznaka.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem1,
            valueListItem2,
            valueListItem3,
            valueListItem4});
            this.ucbJOPPDOznaka.Location = new System.Drawing.Point(107, 51);
            this.ucbJOPPDOznaka.MaxDropDownItems = 20;
            this.ucbJOPPDOznaka.Name = "ucbJOPPDOznaka";
            this.ucbJOPPDOznaka.Size = new System.Drawing.Size(452, 21);
            this.ucbJOPPDOznaka.TabIndex = 103;
            this.ucbJOPPDOznaka.ValueMember = "ID";
            // 
            // ucbElement
            // 
            this.ucbElement.DisplayMember = "Naziv";
            this.ucbElement.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            valueListItem5.DataValue = "-";
            valueListItem5.DisplayText = "- povlaka";
            valueListItem6.DataValue = "/";
            valueListItem6.DisplayText = "/ kosa crta";
            valueListItem7.DataValue = "\\";
            valueListItem7.DisplayText = "\\ kosa crta unatrag";
            valueListItem8.DataValue = ".";
            valueListItem8.DisplayText = ". tocka";
            this.ucbElement.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem5,
            valueListItem6,
            valueListItem7,
            valueListItem8});
            this.ucbElement.Location = new System.Drawing.Point(107, 78);
            this.ucbElement.MaxDropDownItems = 20;
            this.ucbElement.Name = "ucbElement";
            this.ucbElement.Size = new System.Drawing.Size(452, 21);
            this.ucbElement.TabIndex = 104;
            this.ucbElement.ValueMember = "ID";
            // 
            // uscNacinIsplateElement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ucbElement);
            this.Controls.Add(this.ucbJOPPDOznaka);
            this.Controls.Add(this.lblKratkiOpis);
            this.Controls.Add(this.lblOznaka);
            this.Controls.Add(this.lblValidationMessages);
            this.Controls.Add(this.toolStrip1);
            this.Name = "uscNacinIsplateElement";
            this.Size = new System.Drawing.Size(574, 146);
            this.Load += new System.EventHandler(this.uscRadnoVrijeme_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ucbJOPPDOznaka)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucbElement)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnSpremiZatvori;
        private System.Windows.Forms.ToolStripButton btnZatvori;
        private System.Windows.Forms.Label lblValidationMessages;
        private System.Windows.Forms.ToolStripButton btnSpremiNovi;
        private System.Windows.Forms.Label lblKratkiOpis;
        private System.Windows.Forms.Label lblOznaka;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor ucbJOPPDOznaka;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor ucbElement;

    }
}

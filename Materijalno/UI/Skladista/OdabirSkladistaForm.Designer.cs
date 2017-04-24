namespace Materijalno.UI.Skladista
{
    partial class OdabirSkladistaForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OdabirSkladistaForm));
            this.tspForm = new System.Windows.Forms.ToolStrip();
            this.tsbOtvori = new System.Windows.Forms.ToolStripButton();
            this.tsbOdustani = new System.Windows.Forms.ToolStripButton();
            this.lblValidationMessages = new System.Windows.Forms.Label();
            this.uceSkladiste = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.lblName2 = new System.Windows.Forms.Label();
            this.tspForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uceSkladiste)).BeginInit();
            this.SuspendLayout();
            // 
            // tspForm
            // 
            this.tspForm.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbOtvori,
            this.tsbOdustani});
            this.tspForm.Location = new System.Drawing.Point(0, 0);
            this.tspForm.Name = "tspForm";
            this.tspForm.Size = new System.Drawing.Size(450, 25);
            this.tspForm.TabIndex = 20;
            this.tspForm.Text = "toolStrip1";
            // 
            // tsbOtvori
            // 
            this.tsbOtvori.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbOtvori.Image = ((System.Drawing.Image)(resources.GetObject("tsbOtvori.Image")));
            this.tsbOtvori.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbOtvori.Name = "tsbOtvori";
            this.tsbOtvori.Size = new System.Drawing.Size(49, 22);
            this.tsbOtvori.Text = "Prenesi";
            this.tsbOtvori.Click += new System.EventHandler(this.tsbSpremiZatvori_Click);
            // 
            // tsbOdustani
            // 
            this.tsbOdustani.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbOdustani.Image = ((System.Drawing.Image)(resources.GetObject("tsbOdustani.Image")));
            this.tsbOdustani.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbOdustani.Name = "tsbOdustani";
            this.tsbOdustani.Size = new System.Drawing.Size(59, 22);
            this.tsbOdustani.Text = "Odustani";
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
            // uceSkladiste
            // 
            this.uceSkladiste.DisplayMember = "Naziv";
            this.uceSkladiste.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.uceSkladiste.Location = new System.Drawing.Point(67, 49);
            this.uceSkladiste.MaxDropDownItems = 20;
            this.uceSkladiste.Name = "uceSkladiste";
            this.uceSkladiste.Size = new System.Drawing.Size(325, 21);
            this.uceSkladiste.TabIndex = 76;
            this.uceSkladiste.ValueMember = "ID";
            // 
            // lblName2
            // 
            this.lblName2.AutoSize = true;
            this.lblName2.Location = new System.Drawing.Point(4, 53);
            this.lblName2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblName2.Name = "lblName2";
            this.lblName2.Size = new System.Drawing.Size(53, 13);
            this.lblName2.TabIndex = 74;
            this.lblName2.Text = "Skladište:";
            // 
            // OdabirSkladistaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.uceSkladiste);
            this.Controls.Add(this.lblName2);
            this.Controls.Add(this.lblValidationMessages);
            this.Controls.Add(this.tspForm);
            this.Name = "OdabirSkladistaForm";
            this.Size = new System.Drawing.Size(450, 131);
            this.Load += new System.EventHandler(this.PrimkaForm_Load);
            this.tspForm.ResumeLayout(false);
            this.tspForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uceSkladiste)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tspForm;
        private System.Windows.Forms.ToolStripButton tsbOtvori;
        private System.Windows.Forms.ToolStripButton tsbOdustani;
        private System.Windows.Forms.Label lblValidationMessages;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor uceSkladiste;
        private System.Windows.Forms.Label lblName2;


    }
}

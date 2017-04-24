namespace Materijalno.UI.Izvjestaji
{
    partial class frmZakljucivanjeGodine
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmbInventura = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPrihvati = new System.Windows.Forms.Button();
            this.btnOdustani = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbGodina = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cmbInventura
            // 
            this.cmbInventura.DropDownHeight = 150;
            this.cmbInventura.DropDownWidth = 280;
            this.cmbInventura.FormattingEnabled = true;
            this.cmbInventura.IntegralHeight = false;
            this.cmbInventura.Location = new System.Drawing.Point(85, 18);
            this.cmbInventura.Name = "cmbInventura";
            this.cmbInventura.Size = new System.Drawing.Size(233, 21);
            this.cmbInventura.TabIndex = 0;
            this.cmbInventura.SelectedValueChanged += new System.EventHandler(this.cmbInventura_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Inventura:";
            // 
            // btnPrihvati
            // 
            this.btnPrihvati.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnPrihvati.Location = new System.Drawing.Point(19, 85);
            this.btnPrihvati.Name = "btnPrihvati";
            this.btnPrihvati.Size = new System.Drawing.Size(73, 26);
            this.btnPrihvati.TabIndex = 2;
            this.btnPrihvati.Text = "Prijenos";
            this.btnPrihvati.UseVisualStyleBackColor = true;
            this.btnPrihvati.Click += new System.EventHandler(this.btnPrihvati_Click);
            // 
            // btnOdustani
            // 
            this.btnOdustani.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnOdustani.Location = new System.Drawing.Point(245, 86);
            this.btnOdustani.Name = "btnOdustani";
            this.btnOdustani.Size = new System.Drawing.Size(73, 26);
            this.btnOdustani.TabIndex = 3;
            this.btnOdustani.Text = "Odustani";
            this.btnOdustani.UseVisualStyleBackColor = true;
            this.btnOdustani.Click += new System.EventHandler(this.btnOdustani_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Godina u koju se prenosi:";
            // 
            // cmbGodina
            // 
            this.cmbGodina.FormattingEnabled = true;
            this.cmbGodina.Location = new System.Drawing.Point(244, 52);
            this.cmbGodina.Name = "cmbGodina";
            this.cmbGodina.Size = new System.Drawing.Size(74, 21);
            this.cmbGodina.TabIndex = 5;
            // 
            // frmZakljucivanjeGodine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 132);
            this.Controls.Add(this.cmbGodina);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnOdustani);
            this.Controls.Add(this.btnPrihvati);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbInventura);
            this.Name = "frmZakljucivanjeGodine";
            this.Text = "Zaključivanje godine";
            this.Load += new System.EventHandler(this.frmZakljucivanjeGodine_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbInventura;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPrihvati;
        private System.Windows.Forms.Button btnOdustani;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbGodina;
    }
}
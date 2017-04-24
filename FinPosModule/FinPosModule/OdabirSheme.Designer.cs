namespace FinPosModule
{
    partial class OdabirSheme
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
            this.label1 = new System.Windows.Forms.Label();
            this.ucbShemaOsnovno = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.btnObracunOdustani = new System.Windows.Forms.Button();
            this.btnZaduzi = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.uceTipIRA = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.label3 = new System.Windows.Forms.Label();
            this.ucePartner = new Infragistics.Win.UltraWinGrid.UltraCombo();
            this.uceShemaDopunsko = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ucbShemaOsnovno)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uceTipIRA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucePartner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uceShemaDopunsko)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(182, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Shema knjiženja osnovno osiguranje:";
            // 
            // ucbShemaOsnovno
            // 
            this.ucbShemaOsnovno.DisplayMember = "NAZIV";
            this.ucbShemaOsnovno.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.ucbShemaOsnovno.Location = new System.Drawing.Point(9, 28);
            this.ucbShemaOsnovno.MaxDropDownItems = 20;
            this.ucbShemaOsnovno.Name = "ucbShemaOsnovno";
            this.ucbShemaOsnovno.Size = new System.Drawing.Size(253, 21);
            this.ucbShemaOsnovno.TabIndex = 109;
            this.ucbShemaOsnovno.ValueMember = "ID";
            // 
            // btnObracunOdustani
            // 
            this.btnObracunOdustani.Location = new System.Drawing.Point(9, 203);
            this.btnObracunOdustani.Name = "btnObracunOdustani";
            this.btnObracunOdustani.Size = new System.Drawing.Size(69, 25);
            this.btnObracunOdustani.TabIndex = 110;
            this.btnObracunOdustani.Text = "Odustani";
            this.btnObracunOdustani.UseVisualStyleBackColor = true;
            this.btnObracunOdustani.Click += new System.EventHandler(this.btnObracunOdustani_Click);
            // 
            // btnZaduzi
            // 
            this.btnZaduzi.Location = new System.Drawing.Point(193, 203);
            this.btnZaduzi.Name = "btnZaduzi";
            this.btnZaduzi.Size = new System.Drawing.Size(69, 25);
            this.btnZaduzi.TabIndex = 111;
            this.btnZaduzi.Text = "Zaduži";
            this.btnZaduzi.UseVisualStyleBackColor = true;
            this.btnZaduzi.Click += new System.EventHandler(this.btnZaduzi_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 112;
            this.label2.Text = "Partner:";
            // 
            // uceTipIRA
            // 
            this.uceTipIRA.DisplayMember = "NAZIV";
            this.uceTipIRA.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.uceTipIRA.Location = new System.Drawing.Point(9, 165);
            this.uceTipIRA.MaxDropDownItems = 20;
            this.uceTipIRA.Name = "uceTipIRA";
            this.uceTipIRA.Size = new System.Drawing.Size(253, 21);
            this.uceTipIRA.TabIndex = 115;
            this.uceTipIRA.ValueMember = "ID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 114;
            this.label3.Text = "Tip IRA:";
            // 
            // ucePartner
            // 
            this.ucePartner.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.ucePartner.DisplayMember = "Naziv";
            this.ucePartner.Location = new System.Drawing.Point(9, 118);
            this.ucePartner.Name = "ucePartner";
            this.ucePartner.Size = new System.Drawing.Size(253, 22);
            this.ucePartner.TabIndex = 116;
            this.ucePartner.UseAppStyling = false;
            this.ucePartner.ValueMember = "ID";
            // 
            // uceShemaDopunsko
            // 
            this.uceShemaDopunsko.DisplayMember = "NAZIV";
            this.uceShemaDopunsko.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.uceShemaDopunsko.Location = new System.Drawing.Point(9, 74);
            this.uceShemaDopunsko.MaxDropDownItems = 20;
            this.uceShemaDopunsko.Name = "uceShemaDopunsko";
            this.uceShemaDopunsko.Size = new System.Drawing.Size(253, 21);
            this.uceShemaDopunsko.TabIndex = 118;
            this.uceShemaDopunsko.ValueMember = "ID";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(188, 13);
            this.label4.TabIndex = 117;
            this.label4.Text = "Shema knjiženja dopunsko osiguranje:";
            // 
            // OdabirSheme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.uceShemaDopunsko);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ucePartner);
            this.Controls.Add(this.uceTipIRA);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnZaduzi);
            this.Controls.Add(this.btnObracunOdustani);
            this.Controls.Add(this.ucbShemaOsnovno);
            this.Controls.Add(this.label1);
            this.Name = "OdabirSheme";
            this.Size = new System.Drawing.Size(305, 269);
            ((System.ComponentModel.ISupportInitialize)(this.ucbShemaOsnovno)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uceTipIRA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucePartner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uceShemaDopunsko)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor ucbShemaOsnovno;
        private System.Windows.Forms.Button btnObracunOdustani;
        private System.Windows.Forms.Button btnZaduzi;
        private System.Windows.Forms.Label label2;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor uceTipIRA;
        private System.Windows.Forms.Label label3;
        private Infragistics.Win.UltraWinGrid.UltraCombo ucePartner;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor uceShemaDopunsko;
        private System.Windows.Forms.Label label4;
    }
}
namespace UcenickoFakturiranje.UI.MBS.DefiniranjePotrazivanje
{
    partial class uscPotrazivanja
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(uscPotrazivanja));
            this.lblValidationMessages = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tbSpremiZatvori = new System.Windows.Forms.ToolStripButton();
            this.tbOdustaniZatvori = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnRemoveZaLijekove = new System.Windows.Forms.Button();
            this.btnAddZaLijekove = new System.Windows.Forms.Button();
            this.lbxZaLijekove = new System.Windows.Forms.ListBox();
            this.uceKontoZaLijekove = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnRemoveSanitetski = new System.Windows.Forms.Button();
            this.btnAddSanitetski = new System.Windows.Forms.Button();
            this.uceKontoSanitetski = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.lbxSanitetski = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnRemoveZaEnergiju = new System.Windows.Forms.Button();
            this.uceKontoZaEnergiju = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.lbxZaEnergiju = new System.Windows.Forms.ListBox();
            this.btnAddZaEnergiju = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnRemoveZivezne = new System.Windows.Forms.Button();
            this.uceKontoZivezne = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.btnAddZivezne = new System.Windows.Forms.Button();
            this.lbxZivezne = new System.Windows.Forms.ListBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnRemoveZaOstale = new System.Windows.Forms.Button();
            this.uceKontoZaOstale = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.lbxZaOstale = new System.Windows.Forms.ListBox();
            this.btnAddZaOstale = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.btnRemoveZaProizvodne = new System.Windows.Forms.Button();
            this.uceKontoZaProizvodne = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.lbxZaProizvodne = new System.Windows.Forms.ListBox();
            this.btnAddZaProizvodne = new System.Windows.Forms.Button();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uceKontoZaLijekove)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uceKontoSanitetski)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uceKontoZaEnergiju)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uceKontoZivezne)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uceKontoZaOstale)).BeginInit();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uceKontoZaProizvodne)).BeginInit();
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
            this.tbSpremiZatvori,
            this.tbOdustaniZatvori});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(726, 25);
            this.toolStrip1.TabIndex = 22;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tbSpremiZatvori
            // 
            this.tbSpremiZatvori.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbSpremiZatvori.Image = ((System.Drawing.Image)(resources.GetObject("tbSpremiZatvori.Image")));
            this.tbSpremiZatvori.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbSpremiZatvori.Name = "tbSpremiZatvori";
            this.tbSpremiZatvori.Size = new System.Drawing.Size(92, 22);
            this.tbSpremiZatvori.Text = "Spremi i zatvori";
            this.tbSpremiZatvori.Click += new System.EventHandler(this.tbSpremiZatvori_Click);
            // 
            // tbOdustaniZatvori
            // 
            this.tbOdustaniZatvori.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbOdustaniZatvori.Image = ((System.Drawing.Image)(resources.GetObject("tbOdustaniZatvori.Image")));
            this.tbOdustaniZatvori.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbOdustaniZatvori.Name = "tbOdustaniZatvori";
            this.tbOdustaniZatvori.Size = new System.Drawing.Size(103, 22);
            this.tbOdustaniZatvori.Text = "Odustani i zatvori";
            this.tbOdustaniZatvori.Click += new System.EventHandler(this.tbOdustaniZatvori_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnRemoveZaLijekove);
            this.groupBox1.Controls.Add(this.btnAddZaLijekove);
            this.groupBox1.Controls.Add(this.lbxZaLijekove);
            this.groupBox1.Controls.Add(this.uceKontoZaLijekove);
            this.groupBox1.Location = new System.Drawing.Point(3, 45);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(680, 65);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Potraživanja od HZZO po osnovi pružanja zdravstvene zaštite";
            // 
            // btnRemoveZaLijekove
            // 
            this.btnRemoveZaLijekove.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnRemoveZaLijekove.Image = global::UcenickoFakturiranje.Resources.ImageResourcesNew.arrow_left;
            this.btnRemoveZaLijekove.Location = new System.Drawing.Point(306, 15);
            this.btnRemoveZaLijekove.Name = "btnRemoveZaLijekove";
            this.btnRemoveZaLijekove.Size = new System.Drawing.Size(35, 21);
            this.btnRemoveZaLijekove.TabIndex = 84;
            this.btnRemoveZaLijekove.UseVisualStyleBackColor = true;
            this.btnRemoveZaLijekove.Click += new System.EventHandler(this.btnRemoveZaLijekove_Click);
            // 
            // btnAddZaLijekove
            // 
            this.btnAddZaLijekove.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnAddZaLijekove.Image = global::UcenickoFakturiranje.Resources.ImageResourcesNew.arrow_right;
            this.btnAddZaLijekove.Location = new System.Drawing.Point(259, 15);
            this.btnAddZaLijekove.Name = "btnAddZaLijekove";
            this.btnAddZaLijekove.Size = new System.Drawing.Size(35, 21);
            this.btnAddZaLijekove.TabIndex = 83;
            this.btnAddZaLijekove.UseVisualStyleBackColor = true;
            this.btnAddZaLijekove.Click += new System.EventHandler(this.btnAddZaLijekove_Click);
            // 
            // lbxZaLijekove
            // 
            this.lbxZaLijekove.FormattingEnabled = true;
            this.lbxZaLijekove.Location = new System.Drawing.Point(346, 16);
            this.lbxZaLijekove.Name = "lbxZaLijekove";
            this.lbxZaLijekove.Size = new System.Drawing.Size(328, 43);
            this.lbxZaLijekove.Sorted = true;
            this.lbxZaLijekove.TabIndex = 81;
            // 
            // uceKontoZaLijekove
            // 
            this.uceKontoZaLijekove.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            this.uceKontoZaLijekove.DisplayMember = "Naziv";
            this.uceKontoZaLijekove.Location = new System.Drawing.Point(7, 38);
            this.uceKontoZaLijekove.MaxDropDownItems = 20;
            this.uceKontoZaLijekove.Name = "uceKontoZaLijekove";
            this.uceKontoZaLijekove.Size = new System.Drawing.Size(334, 21);
            this.uceKontoZaLijekove.TabIndex = 78;
            this.uceKontoZaLijekove.ValueMember = "ID";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnRemoveSanitetski);
            this.groupBox2.Controls.Add(this.btnAddSanitetski);
            this.groupBox2.Controls.Add(this.uceKontoSanitetski);
            this.groupBox2.Controls.Add(this.lbxSanitetski);
            this.groupBox2.Location = new System.Drawing.Point(3, 110);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(680, 65);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Potraživanja od HZZO-a temeljem ugovora za usluge izvan ugovorenog";
            // 
            // btnRemoveSanitetski
            // 
            this.btnRemoveSanitetski.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnRemoveSanitetski.Image = global::UcenickoFakturiranje.Resources.ImageResourcesNew.arrow_left;
            this.btnRemoveSanitetski.Location = new System.Drawing.Point(305, 15);
            this.btnRemoveSanitetski.Name = "btnRemoveSanitetski";
            this.btnRemoveSanitetski.Size = new System.Drawing.Size(35, 21);
            this.btnRemoveSanitetski.TabIndex = 88;
            this.btnRemoveSanitetski.UseVisualStyleBackColor = true;
            this.btnRemoveSanitetski.Click += new System.EventHandler(this.btnRemoveSanitetski_Click);
            // 
            // btnAddSanitetski
            // 
            this.btnAddSanitetski.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnAddSanitetski.Image = global::UcenickoFakturiranje.Resources.ImageResourcesNew.arrow_right;
            this.btnAddSanitetski.Location = new System.Drawing.Point(259, 15);
            this.btnAddSanitetski.Name = "btnAddSanitetski";
            this.btnAddSanitetski.Size = new System.Drawing.Size(35, 21);
            this.btnAddSanitetski.TabIndex = 87;
            this.btnAddSanitetski.UseVisualStyleBackColor = true;
            this.btnAddSanitetski.Click += new System.EventHandler(this.btnAddSanitetski_Click);
            // 
            // uceKontoSanitetski
            // 
            this.uceKontoSanitetski.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            this.uceKontoSanitetski.DisplayMember = "Naziv";
            this.uceKontoSanitetski.Location = new System.Drawing.Point(7, 38);
            this.uceKontoSanitetski.MaxDropDownItems = 20;
            this.uceKontoSanitetski.Name = "uceKontoSanitetski";
            this.uceKontoSanitetski.Size = new System.Drawing.Size(334, 21);
            this.uceKontoSanitetski.TabIndex = 85;
            this.uceKontoSanitetski.ValueMember = "ID";
            // 
            // lbxSanitetski
            // 
            this.lbxSanitetski.FormattingEnabled = true;
            this.lbxSanitetski.Location = new System.Drawing.Point(346, 16);
            this.lbxSanitetski.Name = "lbxSanitetski";
            this.lbxSanitetski.Size = new System.Drawing.Size(328, 43);
            this.lbxSanitetski.Sorted = true;
            this.lbxSanitetski.TabIndex = 86;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnRemoveZaEnergiju);
            this.groupBox3.Controls.Add(this.uceKontoZaEnergiju);
            this.groupBox3.Controls.Add(this.lbxZaEnergiju);
            this.groupBox3.Controls.Add(this.btnAddZaEnergiju);
            this.groupBox3.Location = new System.Drawing.Point(3, 235);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(680, 60);
            this.groupBox3.TabIndex = 26;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Potraživanja od HZZOzzr";
            // 
            // btnRemoveZaEnergiju
            // 
            this.btnRemoveZaEnergiju.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnRemoveZaEnergiju.Image = global::UcenickoFakturiranje.Resources.ImageResourcesNew.arrow_left;
            this.btnRemoveZaEnergiju.Location = new System.Drawing.Point(306, 10);
            this.btnRemoveZaEnergiju.Name = "btnRemoveZaEnergiju";
            this.btnRemoveZaEnergiju.Size = new System.Drawing.Size(35, 21);
            this.btnRemoveZaEnergiju.TabIndex = 96;
            this.btnRemoveZaEnergiju.UseVisualStyleBackColor = true;
            this.btnRemoveZaEnergiju.Click += new System.EventHandler(this.btnRemoveZaEnergiju_Click);
            // 
            // uceKontoZaEnergiju
            // 
            this.uceKontoZaEnergiju.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            this.uceKontoZaEnergiju.DisplayMember = "Naziv";
            this.uceKontoZaEnergiju.Location = new System.Drawing.Point(7, 33);
            this.uceKontoZaEnergiju.MaxDropDownItems = 20;
            this.uceKontoZaEnergiju.Name = "uceKontoZaEnergiju";
            this.uceKontoZaEnergiju.Size = new System.Drawing.Size(334, 21);
            this.uceKontoZaEnergiju.TabIndex = 93;
            this.uceKontoZaEnergiju.ValueMember = "ID";
            // 
            // lbxZaEnergiju
            // 
            this.lbxZaEnergiju.FormattingEnabled = true;
            this.lbxZaEnergiju.Location = new System.Drawing.Point(346, 11);
            this.lbxZaEnergiju.Name = "lbxZaEnergiju";
            this.lbxZaEnergiju.Size = new System.Drawing.Size(328, 43);
            this.lbxZaEnergiju.Sorted = true;
            this.lbxZaEnergiju.TabIndex = 94;
            // 
            // btnAddZaEnergiju
            // 
            this.btnAddZaEnergiju.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnAddZaEnergiju.Image = global::UcenickoFakturiranje.Resources.ImageResourcesNew.arrow_right;
            this.btnAddZaEnergiju.Location = new System.Drawing.Point(260, 10);
            this.btnAddZaEnergiju.Name = "btnAddZaEnergiju";
            this.btnAddZaEnergiju.Size = new System.Drawing.Size(35, 21);
            this.btnAddZaEnergiju.TabIndex = 95;
            this.btnAddZaEnergiju.UseVisualStyleBackColor = true;
            this.btnAddZaEnergiju.Click += new System.EventHandler(this.btnAddZaEnergiju_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnRemoveZivezne);
            this.groupBox4.Controls.Add(this.uceKontoZivezne);
            this.groupBox4.Controls.Add(this.btnAddZivezne);
            this.groupBox4.Controls.Add(this.lbxZivezne);
            this.groupBox4.Location = new System.Drawing.Point(3, 175);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(680, 60);
            this.groupBox4.TabIndex = 25;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Potraživanja od dopunskog zdravstvenog osiguranja";
            // 
            // btnRemoveZivezne
            // 
            this.btnRemoveZivezne.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnRemoveZivezne.Image = global::UcenickoFakturiranje.Resources.ImageResourcesNew.arrow_left;
            this.btnRemoveZivezne.Location = new System.Drawing.Point(306, 10);
            this.btnRemoveZivezne.Name = "btnRemoveZivezne";
            this.btnRemoveZivezne.Size = new System.Drawing.Size(35, 21);
            this.btnRemoveZivezne.TabIndex = 92;
            this.btnRemoveZivezne.UseVisualStyleBackColor = true;
            this.btnRemoveZivezne.Click += new System.EventHandler(this.btnRemoveZivezne_Click);
            // 
            // uceKontoZivezne
            // 
            this.uceKontoZivezne.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            this.uceKontoZivezne.DisplayMember = "Naziv";
            this.uceKontoZivezne.Location = new System.Drawing.Point(7, 33);
            this.uceKontoZivezne.MaxDropDownItems = 20;
            this.uceKontoZivezne.Name = "uceKontoZivezne";
            this.uceKontoZivezne.Size = new System.Drawing.Size(334, 21);
            this.uceKontoZivezne.TabIndex = 89;
            this.uceKontoZivezne.ValueMember = "ID";
            // 
            // btnAddZivezne
            // 
            this.btnAddZivezne.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnAddZivezne.Image = global::UcenickoFakturiranje.Resources.ImageResourcesNew.arrow_right;
            this.btnAddZivezne.Location = new System.Drawing.Point(260, 10);
            this.btnAddZivezne.Name = "btnAddZivezne";
            this.btnAddZivezne.Size = new System.Drawing.Size(35, 21);
            this.btnAddZivezne.TabIndex = 91;
            this.btnAddZivezne.UseVisualStyleBackColor = true;
            this.btnAddZivezne.Click += new System.EventHandler(this.btnAddZivezne_Click);
            // 
            // lbxZivezne
            // 
            this.lbxZivezne.FormattingEnabled = true;
            this.lbxZivezne.Location = new System.Drawing.Point(346, 11);
            this.lbxZivezne.Name = "lbxZivezne";
            this.lbxZivezne.Size = new System.Drawing.Size(328, 43);
            this.lbxZivezne.Sorted = true;
            this.lbxZivezne.TabIndex = 90;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnRemoveZaOstale);
            this.groupBox5.Controls.Add(this.uceKontoZaOstale);
            this.groupBox5.Controls.Add(this.lbxZaOstale);
            this.groupBox5.Controls.Add(this.btnAddZaOstale);
            this.groupBox5.Location = new System.Drawing.Point(3, 296);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(680, 72);
            this.groupBox5.TabIndex = 97;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Potraživanja od drugih zdravstvenih ustanova";
            // 
            // btnRemoveZaOstale
            // 
            this.btnRemoveZaOstale.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnRemoveZaOstale.Image = global::UcenickoFakturiranje.Resources.ImageResourcesNew.arrow_left;
            this.btnRemoveZaOstale.Location = new System.Drawing.Point(306, 10);
            this.btnRemoveZaOstale.Name = "btnRemoveZaOstale";
            this.btnRemoveZaOstale.Size = new System.Drawing.Size(35, 21);
            this.btnRemoveZaOstale.TabIndex = 96;
            this.btnRemoveZaOstale.UseVisualStyleBackColor = true;
            this.btnRemoveZaOstale.Click += new System.EventHandler(this.btnRemoveZaOstale_Click);
            // 
            // uceKontoZaOstale
            // 
            this.uceKontoZaOstale.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            this.uceKontoZaOstale.DisplayMember = "Naziv";
            this.uceKontoZaOstale.Location = new System.Drawing.Point(7, 33);
            this.uceKontoZaOstale.MaxDropDownItems = 20;
            this.uceKontoZaOstale.Name = "uceKontoZaOstale";
            this.uceKontoZaOstale.Size = new System.Drawing.Size(334, 21);
            this.uceKontoZaOstale.TabIndex = 93;
            this.uceKontoZaOstale.ValueMember = "ID";
            // 
            // lbxZaOstale
            // 
            this.lbxZaOstale.FormattingEnabled = true;
            this.lbxZaOstale.Location = new System.Drawing.Point(346, 11);
            this.lbxZaOstale.Name = "lbxZaOstale";
            this.lbxZaOstale.Size = new System.Drawing.Size(328, 43);
            this.lbxZaOstale.Sorted = true;
            this.lbxZaOstale.TabIndex = 94;
            // 
            // btnAddZaOstale
            // 
            this.btnAddZaOstale.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnAddZaOstale.Image = global::UcenickoFakturiranje.Resources.ImageResourcesNew.arrow_right;
            this.btnAddZaOstale.Location = new System.Drawing.Point(260, 10);
            this.btnAddZaOstale.Name = "btnAddZaOstale";
            this.btnAddZaOstale.Size = new System.Drawing.Size(35, 21);
            this.btnAddZaOstale.TabIndex = 95;
            this.btnAddZaOstale.UseVisualStyleBackColor = true;
            this.btnAddZaOstale.Click += new System.EventHandler(this.btnAddZaOstale_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.btnRemoveZaProizvodne);
            this.groupBox6.Controls.Add(this.uceKontoZaProizvodne);
            this.groupBox6.Controls.Add(this.lbxZaProizvodne);
            this.groupBox6.Controls.Add(this.btnAddZaProizvodne);
            this.groupBox6.Location = new System.Drawing.Point(0, 368);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(680, 60);
            this.groupBox6.TabIndex = 98;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Ostala potraživanja";
            // 
            // btnRemoveZaProizvodne
            // 
            this.btnRemoveZaProizvodne.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnRemoveZaProizvodne.Image = global::UcenickoFakturiranje.Resources.ImageResourcesNew.arrow_left;
            this.btnRemoveZaProizvodne.Location = new System.Drawing.Point(306, 10);
            this.btnRemoveZaProizvodne.Name = "btnRemoveZaProizvodne";
            this.btnRemoveZaProizvodne.Size = new System.Drawing.Size(35, 21);
            this.btnRemoveZaProizvodne.TabIndex = 96;
            this.btnRemoveZaProizvodne.UseVisualStyleBackColor = true;
            this.btnRemoveZaProizvodne.Click += new System.EventHandler(this.btnRemoveZaProizvodne_Click);
            // 
            // uceKontoZaProizvodne
            // 
            this.uceKontoZaProizvodne.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            this.uceKontoZaProizvodne.DisplayMember = "Naziv";
            this.uceKontoZaProizvodne.Location = new System.Drawing.Point(7, 33);
            this.uceKontoZaProizvodne.MaxDropDownItems = 20;
            this.uceKontoZaProizvodne.Name = "uceKontoZaProizvodne";
            this.uceKontoZaProizvodne.Size = new System.Drawing.Size(334, 21);
            this.uceKontoZaProizvodne.TabIndex = 93;
            this.uceKontoZaProizvodne.ValueMember = "ID";
            // 
            // lbxZaProizvodne
            // 
            this.lbxZaProizvodne.FormattingEnabled = true;
            this.lbxZaProizvodne.Location = new System.Drawing.Point(346, 11);
            this.lbxZaProizvodne.Name = "lbxZaProizvodne";
            this.lbxZaProizvodne.Size = new System.Drawing.Size(328, 43);
            this.lbxZaProizvodne.Sorted = true;
            this.lbxZaProizvodne.TabIndex = 94;
            // 
            // btnAddZaProizvodne
            // 
            this.btnAddZaProizvodne.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnAddZaProizvodne.Image = global::UcenickoFakturiranje.Resources.ImageResourcesNew.arrow_right;
            this.btnAddZaProizvodne.Location = new System.Drawing.Point(260, 10);
            this.btnAddZaProizvodne.Name = "btnAddZaProizvodne";
            this.btnAddZaProizvodne.Size = new System.Drawing.Size(35, 21);
            this.btnAddZaProizvodne.TabIndex = 95;
            this.btnAddZaProizvodne.UseVisualStyleBackColor = true;
            this.btnAddZaProizvodne.Click += new System.EventHandler(this.btnAddZaProizvodne_Click);
            // 
            // uscPotrazivanja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblValidationMessages);
            this.Controls.Add(this.toolStrip1);
            this.Name = "uscPotrazivanja";
            this.Size = new System.Drawing.Size(726, 531);
            this.Load += new System.EventHandler(this.Form_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uceKontoZaLijekove)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uceKontoSanitetski)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uceKontoZaEnergiju)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uceKontoZivezne)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uceKontoZaOstale)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uceKontoZaProizvodne)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tbSpremiZatvori;
        private System.Windows.Forms.ToolStripButton tbOdustaniZatvori;
        private System.Windows.Forms.Label lblValidationMessages;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor uceKontoZaLijekove;
        private System.Windows.Forms.ListBox lbxZaLijekove;
        private System.Windows.Forms.Button btnRemoveZaLijekove;
        private System.Windows.Forms.Button btnAddZaLijekove;
        private System.Windows.Forms.Button btnRemoveSanitetski;
        private System.Windows.Forms.Button btnAddSanitetski;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor uceKontoSanitetski;
        private System.Windows.Forms.ListBox lbxSanitetski;
        private System.Windows.Forms.Button btnRemoveZivezne;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor uceKontoZivezne;
        private System.Windows.Forms.Button btnAddZivezne;
        private System.Windows.Forms.ListBox lbxZivezne;
        private System.Windows.Forms.Button btnRemoveZaEnergiju;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor uceKontoZaEnergiju;
        private System.Windows.Forms.ListBox lbxZaEnergiju;
        private System.Windows.Forms.Button btnAddZaEnergiju;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnRemoveZaOstale;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor uceKontoZaOstale;
        private System.Windows.Forms.ListBox lbxZaOstale;
        private System.Windows.Forms.Button btnAddZaOstale;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button btnRemoveZaProizvodne;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor uceKontoZaProizvodne;
        private System.Windows.Forms.ListBox lbxZaProizvodne;
        private System.Windows.Forms.Button btnAddZaProizvodne;

    }
}

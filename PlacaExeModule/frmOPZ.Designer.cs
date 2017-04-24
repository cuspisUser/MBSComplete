partial class frmOPZ
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
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance97 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            this.btnOdustani = new System.Windows.Forms.Button();
            this.btnIspis = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpDatumOd = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.dtpDatumDo = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.label2 = new System.Windows.Forms.Label();
            this.btnXmlDatoteka = new System.Windows.Forms.Button();
            this.btnDohvat = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtMjesto = new System.Windows.Forms.TextBox();
            this.txtOIB = new System.Windows.Forms.TextBox();
            this.txtNaziv = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtBroj = new System.Windows.Forms.TextBox();
            this.txtUlica = new System.Windows.Forms.TextBox();
            this.txtTelefon = new System.Windows.Forms.TextBox();
            this.txtFax = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dgvPartneri = new System.Windows.Forms.DataGridView();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txtPDV = new Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit();
            this.txtSaPDVom = new Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.udtDatumIzrade = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.txtSastavioPrezime = new System.Windows.Forms.TextBox();
            this.txtSastavioIme = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.ttTelefon = new System.Windows.Forms.ToolTip(this.components);
            this.btnTemeljnica = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.lblBrojRedova = new System.Windows.Forms.Label();
            this.lblUkupanIznosKasnjenja = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDatumOd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDatumDo)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPartneri)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udtDatumIzrade)).BeginInit();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOdustani
            // 
            this.btnOdustani.Location = new System.Drawing.Point(5, 59);
            this.btnOdustani.Margin = new System.Windows.Forms.Padding(2);
            this.btnOdustani.Name = "btnOdustani";
            this.btnOdustani.Size = new System.Drawing.Size(58, 24);
            this.btnOdustani.TabIndex = 1;
            this.btnOdustani.Text = "Odustani";
            this.btnOdustani.UseVisualStyleBackColor = true;
            this.btnOdustani.Click += new System.EventHandler(this.btnOdustani_Click);
            // 
            // btnIspis
            // 
            this.btnIspis.Location = new System.Drawing.Point(97, 15);
            this.btnIspis.Margin = new System.Windows.Forms.Padding(2);
            this.btnIspis.Name = "btnIspis";
            this.btnIspis.Size = new System.Drawing.Size(83, 24);
            this.btnIspis.TabIndex = 2;
            this.btnIspis.Text = "Ispis";
            this.btnIspis.UseVisualStyleBackColor = true;
            this.btnIspis.Visible = false;
            this.btnIspis.Click += new System.EventHandler(this.btnGeneriraj_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(188, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Dospjeli, a nenaplaćeni računi na dan:";
            // 
            // dtpDatumOd
            // 
            this.dtpDatumOd.DateTime = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpDatumOd.Location = new System.Drawing.Point(7, 33);
            this.dtpDatumOd.Name = "dtpDatumOd";
            this.dtpDatumOd.Size = new System.Drawing.Size(198, 21);
            this.dtpDatumOd.TabIndex = 5;
            this.dtpDatumOd.Value = null;
            // 
            // dtpDatumDo
            // 
            this.dtpDatumDo.DateTime = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpDatumDo.Location = new System.Drawing.Point(950, 547);
            this.dtpDatumDo.Name = "dtpDatumDo";
            this.dtpDatumDo.Size = new System.Drawing.Size(192, 21);
            this.dtpDatumDo.TabIndex = 7;
            this.dtpDatumDo.Value = null;
            this.dtpDatumDo.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(950, 541);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "koji nisu naplaćeni do:";
            this.label2.Visible = false;
            // 
            // btnXmlDatoteka
            // 
            this.btnXmlDatoteka.Location = new System.Drawing.Point(5, 15);
            this.btnXmlDatoteka.Margin = new System.Windows.Forms.Padding(2);
            this.btnXmlDatoteka.Name = "btnXmlDatoteka";
            this.btnXmlDatoteka.Size = new System.Drawing.Size(83, 24);
            this.btnXmlDatoteka.TabIndex = 8;
            this.btnXmlDatoteka.Text = "Xml datoteka";
            this.btnXmlDatoteka.UseVisualStyleBackColor = true;
            this.btnXmlDatoteka.Click += new System.EventHandler(this.btnXmlDatoteka_Click);
            // 
            // btnDohvat
            // 
            this.btnDohvat.Location = new System.Drawing.Point(66, 59);
            this.btnDohvat.Margin = new System.Windows.Forms.Padding(2);
            this.btnDohvat.Name = "btnDohvat";
            this.btnDohvat.Size = new System.Drawing.Size(50, 24);
            this.btnDohvat.TabIndex = 9;
            this.btnDohvat.Text = "Dohvat";
            this.btnDohvat.UseVisualStyleBackColor = true;
            this.btnDohvat.Click += new System.EventHandler(this.btnDohvat_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnTemeljnica);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnDohvat);
            this.groupBox1.Controls.Add(this.btnOdustani);
            this.groupBox1.Controls.Add(this.dtpDatumOd);
            this.groupBox1.Location = new System.Drawing.Point(6, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(211, 96);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnXmlDatoteka);
            this.groupBox2.Controls.Add(this.btnIspis);
            this.groupBox2.Location = new System.Drawing.Point(438, 600);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(196, 48);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtMjesto);
            this.groupBox3.Controls.Add(this.txtOIB);
            this.groupBox3.Controls.Add(this.txtNaziv);
            this.groupBox3.Controls.Add(this.txtEmail);
            this.groupBox3.Controls.Add(this.txtBroj);
            this.groupBox3.Controls.Add(this.txtUlica);
            this.groupBox3.Controls.Add(this.txtTelefon);
            this.groupBox3.Controls.Add(this.txtFax);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(219, 7);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(932, 96);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "I. PODACI O POREZNOM OBVEZNIKU/PODNOSITELJU IZVJEŠĆA";
            // 
            // txtMjesto
            // 
            this.txtMjesto.Location = new System.Drawing.Point(97, 71);
            this.txtMjesto.Name = "txtMjesto";
            this.txtMjesto.Size = new System.Drawing.Size(237, 20);
            this.txtMjesto.TabIndex = 32;
            // 
            // txtOIB
            // 
            this.txtOIB.Location = new System.Drawing.Point(97, 46);
            this.txtOIB.Name = "txtOIB";
            this.txtOIB.Size = new System.Drawing.Size(237, 20);
            this.txtOIB.TabIndex = 31;
            // 
            // txtNaziv
            // 
            this.txtNaziv.Location = new System.Drawing.Point(97, 18);
            this.txtNaziv.Name = "txtNaziv";
            this.txtNaziv.Size = new System.Drawing.Size(237, 20);
            this.txtNaziv.TabIndex = 30;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(404, 71);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(226, 20);
            this.txtEmail.TabIndex = 29;
            // 
            // txtBroj
            // 
            this.txtBroj.Location = new System.Drawing.Point(404, 46);
            this.txtBroj.Name = "txtBroj";
            this.txtBroj.Size = new System.Drawing.Size(226, 20);
            this.txtBroj.TabIndex = 28;
            // 
            // txtUlica
            // 
            this.txtUlica.Location = new System.Drawing.Point(404, 18);
            this.txtUlica.Name = "txtUlica";
            this.txtUlica.Size = new System.Drawing.Size(226, 20);
            this.txtUlica.TabIndex = 27;
            // 
            // txtTelefon
            // 
            this.txtTelefon.Location = new System.Drawing.Point(700, 19);
            this.txtTelefon.Name = "txtTelefon";
            this.txtTelefon.Size = new System.Drawing.Size(226, 20);
            this.txtTelefon.TabIndex = 26;
            this.ttTelefon.SetToolTip(this.txtTelefon, "Format +3851666999");
            // 
            // txtFax
            // 
            this.txtFax.Location = new System.Drawing.Point(700, 46);
            this.txtFax.Name = "txtFax";
            this.txtFax.Size = new System.Drawing.Size(226, 20);
            this.txtFax.TabIndex = 25;
            this.ttTelefon.SetToolTip(this.txtFax, "Format: +3851666999");
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label15.Location = new System.Drawing.Point(635, 49);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(52, 12);
            this.label15.TabIndex = 24;
            this.label15.Text = "8. FAX:";
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label14.Location = new System.Drawing.Point(635, 24);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(64, 12);
            this.label14.TabIndex = 22;
            this.label14.Text = "7. TELEFON:";
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label13.Location = new System.Drawing.Point(339, 75);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(52, 12);
            this.label13.TabIndex = 20;
            this.label13.Text = "6. EMAIL:";
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label12.Location = new System.Drawing.Point(339, 49);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(52, 12);
            this.label12.TabIndex = 18;
            this.label12.Text = "5. BROJ:";
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label11.Location = new System.Drawing.Point(339, 22);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(60, 12);
            this.label11.TabIndex = 16;
            this.label11.Text = "4. ULICA:";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(7, 73);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 12);
            this.label5.TabIndex = 14;
            this.label5.Text = "3. MJESTO:";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(7, 50);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 12;
            this.label4.Text = "2. OIB:";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(7, 22);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 26);
            this.label3.TabIndex = 10;
            this.label3.Text = "1. NAZIV/IME I                    PREZIME:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dgvPartneri);
            this.groupBox4.Location = new System.Drawing.Point(8, 108);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1143, 419);
            this.groupBox4.TabIndex = 13;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "II. PODACI O DOSPJELIM, A NENAPLAĆENIM RAČUNIMA KOJI SU IZDANI SUKLADNO ODREDBAMA" +
    " ZAKONA O PDV-U";
            // 
            // dgvPartneri
            // 
            this.dgvPartneri.AllowUserToResizeColumns = false;
            this.dgvPartneri.AllowUserToResizeRows = false;
            this.dgvPartneri.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPartneri.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPartneri.Location = new System.Drawing.Point(3, 16);
            this.dgvPartneri.MultiSelect = false;
            this.dgvPartneri.Name = "dgvPartneri";
            this.dgvPartneri.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPartneri.Size = new System.Drawing.Size(1137, 400);
            this.dgvPartneri.TabIndex = 0;
            this.dgvPartneri.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPartneri_CellValueChanged);
            this.dgvPartneri.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvPartneri_RowsAdded);
            this.dgvPartneri.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgvPartneri_RowsRemoved);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label16);
            this.groupBox5.Controls.Add(this.txtPDV);
            this.groupBox5.Controls.Add(this.txtSaPDVom);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Location = new System.Drawing.Point(13, 534);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(610, 60);
            this.groupBox5.TabIndex = 14;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "III. PODACI O UKUPNO DOSPJELIM A NENAPLAĆENIM RAČUNIMA KOJI SU IZDANI SKULADNO OD" +
    "REDBAMA OPZ-A";
            // 
            // txtPDV
            // 
            appearance97.TextHAlignAsString = "Right";
            this.txtPDV.Appearance = appearance97;
            this.txtPDV.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtPDV.InputMask = "{LOC} n,nnn,nnn.nn";
            this.txtPDV.Location = new System.Drawing.Point(447, 33);
            this.txtPDV.Name = "txtPDV";
            this.txtPDV.PromptChar = ' ';
            this.txtPDV.Size = new System.Drawing.Size(148, 20);
            this.txtPDV.TabIndex = 128;
            this.txtPDV.Text = " ";
            this.txtPDV.UseAppStyling = false;
            // 
            // txtSaPDVom
            // 
            appearance1.TextHAlignAsString = "Right";
            this.txtSaPDVom.Appearance = appearance1;
            this.txtSaPDVom.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtSaPDVom.InputMask = "{LOC} n,nnn,nnn.nn";
            this.txtSaPDVom.Location = new System.Drawing.Point(207, 33);
            this.txtSaPDVom.Name = "txtSaPDVom";
            this.txtSaPDVom.PromptChar = ' ';
            this.txtSaPDVom.Size = new System.Drawing.Size(134, 20);
            this.txtSaPDVom.TabIndex = 127;
            this.txtSaPDVom.Text = " ";
            this.txtSaPDVom.UseAppStyling = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.Location = new System.Drawing.Point(373, 37);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 12);
            this.label6.TabIndex = 16;
            this.label6.Text = "IZNOS PDV-A:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label7.Location = new System.Drawing.Point(26, 37);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(179, 12);
            this.label7.TabIndex = 14;
            this.label7.Text = "UKUPAN IZNOS RAČUNA SA PDV-OM:";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label10);
            this.groupBox6.Controls.Add(this.udtDatumIzrade);
            this.groupBox6.Location = new System.Drawing.Point(629, 534);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(315, 60);
            this.groupBox6.TabIndex = 15;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "IV. DATUM";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label10.Location = new System.Drawing.Point(22, 22);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(81, 12);
            this.label10.TabIndex = 19;
            this.label10.Text = "DATUM IZRADE:";
            // 
            // udtDatumIzrade
            // 
            this.udtDatumIzrade.DateTime = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.udtDatumIzrade.Location = new System.Drawing.Point(108, 17);
            this.udtDatumIzrade.Name = "udtDatumIzrade";
            this.udtDatumIzrade.Size = new System.Drawing.Size(186, 21);
            this.udtDatumIzrade.TabIndex = 6;
            this.udtDatumIzrade.Value = null;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.txtSastavioPrezime);
            this.groupBox7.Controls.Add(this.txtSastavioIme);
            this.groupBox7.Controls.Add(this.label8);
            this.groupBox7.Controls.Add(this.label9);
            this.groupBox7.Location = new System.Drawing.Point(13, 600);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(419, 48);
            this.groupBox7.TabIndex = 16;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "V.OBRAČUN SASTAVIO (IME I PREZIME)";
            this.groupBox7.Enter += new System.EventHandler(this.groupBox7_Enter);
            // 
            // txtSastavioPrezime
            // 
            this.txtSastavioPrezime.Location = new System.Drawing.Point(244, 18);
            this.txtSastavioPrezime.Name = "txtSastavioPrezime";
            this.txtSastavioPrezime.Size = new System.Drawing.Size(169, 20);
            this.txtSastavioPrezime.TabIndex = 32;
            // 
            // txtSastavioIme
            // 
            this.txtSastavioIme.Location = new System.Drawing.Point(46, 18);
            this.txtSastavioIme.Name = "txtSastavioIme";
            this.txtSastavioIme.Size = new System.Drawing.Size(137, 20);
            this.txtSastavioIme.TabIndex = 31;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label8.Location = new System.Drawing.Point(188, 22);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 12);
            this.label8.TabIndex = 18;
            this.label8.Text = "PREZIME:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label9.Location = new System.Drawing.Point(19, 22);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(26, 12);
            this.label9.TabIndex = 16;
            this.label9.Text = "IME:";
            // 
            // btnTemeljnica
            // 
            this.btnTemeljnica.Location = new System.Drawing.Point(119, 59);
            this.btnTemeljnica.Margin = new System.Windows.Forms.Padding(2);
            this.btnTemeljnica.Name = "btnTemeljnica";
            this.btnTemeljnica.Size = new System.Drawing.Size(88, 24);
            this.btnTemeljnica.TabIndex = 10;
            this.btnTemeljnica.Text = "Početno stanje";
            this.btnTemeljnica.UseVisualStyleBackColor = true;
            this.btnTemeljnica.Click += new System.EventHandler(this.btnTemeljnica_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label16.Location = new System.Drawing.Point(26, 21);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(99, 9);
            this.label16.TabIndex = 129;
            this.label16.Text = "* ZA FIZIČKE OSOBE";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label17.Location = new System.Drawing.Point(674, 610);
            this.label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(118, 12);
            this.label17.TabIndex = 130;
            this.label17.Text = "UKUPAN BROJ REDOVA:";
            this.label17.Click += new System.EventHandler(this.label17_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label18.Location = new System.Drawing.Point(655, 630);
            this.label18.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(137, 12);
            this.label18.TabIndex = 131;
            this.label18.Text = "UKUPAN IZNOS KAŠNJENJA:";
            // 
            // lblBrojRedova
            // 
            this.lblBrojRedova.AutoSize = true;
            this.lblBrojRedova.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblBrojRedova.Location = new System.Drawing.Point(796, 610);
            this.lblBrojRedova.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBrojRedova.Name = "lblBrojRedova";
            this.lblBrojRedova.Size = new System.Drawing.Size(0, 12);
            this.lblBrojRedova.TabIndex = 20;
            // 
            // lblUkupanIznosKasnjenja
            // 
            this.lblUkupanIznosKasnjenja.AutoSize = true;
            this.lblUkupanIznosKasnjenja.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblUkupanIznosKasnjenja.Location = new System.Drawing.Point(796, 630);
            this.lblUkupanIznosKasnjenja.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUkupanIznosKasnjenja.Name = "lblUkupanIznosKasnjenja";
            this.lblUkupanIznosKasnjenja.Size = new System.Drawing.Size(0, 12);
            this.lblUkupanIznosKasnjenja.TabIndex = 132;
            // 
            // frmOPZ
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1163, 666);
            this.ControlBox = false;
            this.Controls.Add(this.lblUkupanIznosKasnjenja);
            this.Controls.Add(this.lblBrojRedova);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.dtpDatumDo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmOPZ";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OPZ obrazac";
            ((System.ComponentModel.ISupportInitialize)(this.dtpDatumOd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDatumDo)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPartneri)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udtDatumIzrade)).EndInit();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button btnOdustani;
    private System.Windows.Forms.Button btnIspis;
    private System.Windows.Forms.Label label1;
    private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor dtpDatumOd;
    private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor dtpDatumDo;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Button btnXmlDatoteka;
    private System.Windows.Forms.Button btnDohvat;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.GroupBox groupBox3;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.GroupBox groupBox4;
    private System.Windows.Forms.GroupBox groupBox5;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Label label7;
    private Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit txtPDV;
    private Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit txtSaPDVom;
    private System.Windows.Forms.GroupBox groupBox6;
    private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor udtDatumIzrade;
    private System.Windows.Forms.GroupBox groupBox7;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.Label label10;
    private System.Windows.Forms.Label label12;
    private System.Windows.Forms.Label label11;
    private System.Windows.Forms.DataGridView dgvPartneri;
    private System.Windows.Forms.Label label15;
    private System.Windows.Forms.Label label14;
    private System.Windows.Forms.Label label13;
    private System.Windows.Forms.TextBox txtMjesto;
    private System.Windows.Forms.TextBox txtOIB;
    private System.Windows.Forms.TextBox txtNaziv;
    private System.Windows.Forms.TextBox txtEmail;
    private System.Windows.Forms.TextBox txtBroj;
    private System.Windows.Forms.TextBox txtUlica;
    private System.Windows.Forms.TextBox txtTelefon;
    private System.Windows.Forms.TextBox txtFax;
    private System.Windows.Forms.TextBox txtSastavioPrezime;
    private System.Windows.Forms.TextBox txtSastavioIme;
    private System.Windows.Forms.ToolTip ttTelefon;
    private System.Windows.Forms.Button btnTemeljnica;
    private System.Windows.Forms.Label label16;
    private System.Windows.Forms.Label label17;
    private System.Windows.Forms.Label label18;
    private System.Windows.Forms.Label lblBrojRedova;
    private System.Windows.Forms.Label lblUkupanIznosKasnjenja;
}

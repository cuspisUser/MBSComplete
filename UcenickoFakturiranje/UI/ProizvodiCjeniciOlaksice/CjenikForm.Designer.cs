namespace UcenickoFakturiranje.UI.ProizvodiCjeniciOlaksice
{
    partial class CjenikForm
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
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("V_UF_CJENIK_STAVKE", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("CjenikID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ProizvodID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Naziv");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("FINPOREZSTOPA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("FINPOREZNAZIVPOREZ");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Cijena");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Olaksica");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OlaksicaPostotak");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn10 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OlaksicaIznos");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn11 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Iznos");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn12 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("FINPOREZIDPOREZ");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn13 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OlaksicaID");
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CjenikForm));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblValidationMessages = new System.Windows.Forms.Label();
            this.TextBoxNaziv = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.label3 = new System.Windows.Forms.Label();
            this.UltraGridStavke = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.vUFCJENIKSTAVKEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DateTimePickerDatumOd = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.DateTimePickerDatumDo = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnIzmjeniStavku = new System.Windows.Forms.Button();
            this.btnBrisiStavku = new System.Windows.Forms.Button();
            this.btnDodajStavku = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.ToolStripButtonSpremi = new System.Windows.Forms.ToolStripButton();
            this.ToolStripButtonSpremiZatvori = new System.Windows.Forms.ToolStripButton();
            this.btnCjenikOdustani = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TextBoxNaziv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltraGridStavke)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vUFCJENIKSTAVKEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateTimePickerDatumOd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateTimePickerDatumDo)).BeginInit();
            this.panel1.SuspendLayout();
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
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblValidationMessages, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.TextBoxNaziv, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.UltraGridStavke, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.DateTimePickerDatumOd, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.DateTimePickerDatumDo, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 5);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 25);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(854, 540);
            this.tableLayoutPanel1.TabIndex = 23;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(8, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Naziv:";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(8, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Vrijedi od:";
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
            // TextBoxNaziv
            // 
            this.TextBoxNaziv.Location = new System.Drawing.Point(133, 28);
            this.TextBoxNaziv.MaxLength = 500;
            this.TextBoxNaziv.Name = "TextBoxNaziv";
            this.TextBoxNaziv.Size = new System.Drawing.Size(400, 21);
            this.TextBoxNaziv.TabIndex = 50;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(8, 79);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.label3.Size = new System.Drawing.Size(119, 37);
            this.label3.TabIndex = 24;
            this.label3.Text = "Vrijedi do:";
            // 
            // UltraGridStavke
            // 
            this.UltraGridStavke.DataSource = this.vUFCJENIKSTAVKEBindingSource;
            appearance1.BackColor = System.Drawing.SystemColors.Window;
            appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.UltraGridStavke.DisplayLayout.Appearance = appearance1;
            ultraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn1.Hidden = true;
            ultraGridColumn2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn2.Header.VisiblePosition = 8;
            ultraGridColumn3.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn3.Header.VisiblePosition = 1;
            ultraGridColumn3.Hidden = true;
            ultraGridColumn4.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn4.Header.Caption = "Proizvod";
            ultraGridColumn4.Header.VisiblePosition = 2;
            ultraGridColumn5.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn5.Header.VisiblePosition = 9;
            ultraGridColumn6.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn6.Header.VisiblePosition = 10;
            ultraGridColumn7.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn7.Header.VisiblePosition = 3;
            ultraGridColumn8.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn8.Header.Caption = "Olakšica";
            ultraGridColumn8.Header.VisiblePosition = 4;
            ultraGridColumn8.Width = 149;
            ultraGridColumn9.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn9.Format = "N2";
            ultraGridColumn9.Header.Caption = "Postotak olakšice";
            ultraGridColumn9.Header.VisiblePosition = 5;
            ultraGridColumn10.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn10.Format = "N2";
            ultraGridColumn10.Header.Caption = "Iznos olakšice";
            ultraGridColumn10.Header.VisiblePosition = 6;
            ultraGridColumn11.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn11.Header.VisiblePosition = 11;
            ultraGridColumn12.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn12.Header.VisiblePosition = 12;
            ultraGridColumn13.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn13.Header.VisiblePosition = 7;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4,
            ultraGridColumn5,
            ultraGridColumn6,
            ultraGridColumn7,
            ultraGridColumn8,
            ultraGridColumn9,
            ultraGridColumn10,
            ultraGridColumn11,
            ultraGridColumn12,
            ultraGridColumn13});
            this.UltraGridStavke.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.UltraGridStavke.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.UltraGridStavke.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance2.BorderColor = System.Drawing.SystemColors.Window;
            this.UltraGridStavke.DisplayLayout.GroupByBox.Appearance = appearance2;
            appearance3.ForeColor = System.Drawing.SystemColors.GrayText;
            this.UltraGridStavke.DisplayLayout.GroupByBox.BandLabelAppearance = appearance3;
            this.UltraGridStavke.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance4.BackColor2 = System.Drawing.SystemColors.Control;
            appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance4.ForeColor = System.Drawing.SystemColors.GrayText;
            this.UltraGridStavke.DisplayLayout.GroupByBox.PromptAppearance = appearance4;
            this.UltraGridStavke.DisplayLayout.MaxColScrollRegions = 1;
            this.UltraGridStavke.DisplayLayout.MaxRowScrollRegions = 1;
            appearance5.BackColor = System.Drawing.SystemColors.Window;
            appearance5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.UltraGridStavke.DisplayLayout.Override.ActiveCellAppearance = appearance5;
            appearance6.BackColor = System.Drawing.SystemColors.Highlight;
            appearance6.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.UltraGridStavke.DisplayLayout.Override.ActiveRowAppearance = appearance6;
            this.UltraGridStavke.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.UltraGridStavke.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance7.BackColor = System.Drawing.SystemColors.Window;
            this.UltraGridStavke.DisplayLayout.Override.CardAreaAppearance = appearance7;
            appearance8.BorderColor = System.Drawing.Color.Silver;
            appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.UltraGridStavke.DisplayLayout.Override.CellAppearance = appearance8;
            this.UltraGridStavke.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.UltraGridStavke.DisplayLayout.Override.CellPadding = 0;
            appearance9.BackColor = System.Drawing.SystemColors.Control;
            appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance9.BorderColor = System.Drawing.SystemColors.Window;
            this.UltraGridStavke.DisplayLayout.Override.GroupByRowAppearance = appearance9;
            appearance10.TextHAlignAsString = "Left";
            this.UltraGridStavke.DisplayLayout.Override.HeaderAppearance = appearance10;
            this.UltraGridStavke.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.UltraGridStavke.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance11.BackColor = System.Drawing.SystemColors.Window;
            appearance11.BorderColor = System.Drawing.Color.Silver;
            this.UltraGridStavke.DisplayLayout.Override.RowAppearance = appearance11;
            this.UltraGridStavke.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance12.BackColor = System.Drawing.SystemColors.ControlLight;
            this.UltraGridStavke.DisplayLayout.Override.TemplateAddRowAppearance = appearance12;
            this.UltraGridStavke.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.UltraGridStavke.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.UltraGridStavke.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.UltraGridStavke.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UltraGridStavke.Location = new System.Drawing.Point(133, 149);
            this.UltraGridStavke.Name = "UltraGridStavke";
            this.UltraGridStavke.Size = new System.Drawing.Size(713, 325);
            this.UltraGridStavke.TabIndex = 60;
            this.UltraGridStavke.Text = "ultraGrid1";
            this.UltraGridStavke.DoubleClickRow += new Infragistics.Win.UltraWinGrid.DoubleClickRowEventHandler(this.UltraGridStavke_DoubleClickRow);
            // 
            // vUFCJENIKSTAVKEBindingSource
            // 
            this.vUFCJENIKSTAVKEBindingSource.DataSource = typeof(Mipsed7.DataAccessLayer.EntityFramework.V_UF_CJENIK_STAVKE);
            // 
            // DateTimePickerDatumOd
            // 
            this.DateTimePickerDatumOd.DateTime = new System.DateTime(2013, 8, 20, 0, 0, 0, 0);
            this.DateTimePickerDatumOd.Location = new System.Drawing.Point(133, 55);
            this.DateTimePickerDatumOd.Name = "DateTimePickerDatumOd";
            this.DateTimePickerDatumOd.Nullable = false;
            this.DateTimePickerDatumOd.Size = new System.Drawing.Size(89, 21);
            this.DateTimePickerDatumOd.TabIndex = 51;
            this.DateTimePickerDatumOd.Value = new System.DateTime(2013, 8, 20, 0, 0, 0, 0);
            // 
            // DateTimePickerDatumDo
            // 
            this.DateTimePickerDatumDo.DateTime = new System.DateTime(2013, 8, 20, 0, 0, 0, 0);
            this.DateTimePickerDatumDo.Location = new System.Drawing.Point(133, 82);
            this.DateTimePickerDatumDo.Name = "DateTimePickerDatumDo";
            this.DateTimePickerDatumDo.Size = new System.Drawing.Size(89, 21);
            this.DateTimePickerDatumDo.TabIndex = 52;
            this.DateTimePickerDatumDo.Value = new System.DateTime(2013, 8, 20, 0, 0, 0, 0);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnIzmjeniStavku);
            this.panel1.Controls.Add(this.btnBrisiStavku);
            this.panel1.Controls.Add(this.btnDodajStavku);
            this.panel1.Location = new System.Drawing.Point(133, 119);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(422, 24);
            this.panel1.TabIndex = 53;
            // 
            // btnIzmjeniStavku
            // 
            this.btnIzmjeniStavku.Location = new System.Drawing.Point(126, 1);
            this.btnIzmjeniStavku.Name = "btnIzmjeniStavku";
            this.btnIzmjeniStavku.Size = new System.Drawing.Size(109, 23);
            this.btnIzmjeniStavku.TabIndex = 2;
            this.btnIzmjeniStavku.Text = "Izmjeni stavku";
            this.btnIzmjeniStavku.UseVisualStyleBackColor = true;
            this.btnIzmjeniStavku.Click += new System.EventHandler(this.btnIzmjeniStavku_Click);
            // 
            // btnBrisiStavku
            // 
            this.btnBrisiStavku.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrisiStavku.Location = new System.Drawing.Point(249, 1);
            this.btnBrisiStavku.Name = "btnBrisiStavku";
            this.btnBrisiStavku.Size = new System.Drawing.Size(109, 23);
            this.btnBrisiStavku.TabIndex = 3;
            this.btnBrisiStavku.Text = "Briši stavku";
            this.btnBrisiStavku.UseVisualStyleBackColor = true;
            this.btnBrisiStavku.Click += new System.EventHandler(this.btnBrisiStavku_Click);
            // 
            // btnDodajStavku
            // 
            this.btnDodajStavku.Location = new System.Drawing.Point(3, 1);
            this.btnDodajStavku.Name = "btnDodajStavku";
            this.btnDodajStavku.Size = new System.Drawing.Size(109, 23);
            this.btnDodajStavku.TabIndex = 1;
            this.btnDodajStavku.Text = "Dodaj stavku";
            this.btnDodajStavku.UseVisualStyleBackColor = true;
            this.btnDodajStavku.Click += new System.EventHandler(this.ButtonPodProizvodDodaj_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripButtonSpremi,
            this.ToolStripButtonSpremiZatvori,
            this.btnCjenikOdustani});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(854, 25);
            this.toolStrip1.TabIndex = 22;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // ToolStripButtonSpremi
            // 
            this.ToolStripButtonSpremi.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ToolStripButtonSpremi.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripButtonSpremi.Name = "ToolStripButtonSpremi";
            this.ToolStripButtonSpremi.Size = new System.Drawing.Size(80, 22);
            this.ToolStripButtonSpremi.Text = "Spremi i novi";
            this.ToolStripButtonSpremi.Click += new System.EventHandler(this.ToolStripButtonSpremi_Click);
            // 
            // ToolStripButtonSpremiZatvori
            // 
            this.ToolStripButtonSpremiZatvori.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ToolStripButtonSpremiZatvori.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripButtonSpremiZatvori.Name = "ToolStripButtonSpremiZatvori";
            this.ToolStripButtonSpremiZatvori.Size = new System.Drawing.Size(92, 22);
            this.ToolStripButtonSpremiZatvori.Text = "Spremi i zatvori";
            this.ToolStripButtonSpremiZatvori.Click += new System.EventHandler(this.ToolStripButtonSpremiZatvori_Click);
            // 
            // btnCjenikOdustani
            // 
            this.btnCjenikOdustani.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnCjenikOdustani.Image = ((System.Drawing.Image)(resources.GetObject("btnCjenikOdustani.Image")));
            this.btnCjenikOdustani.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCjenikOdustani.Name = "btnCjenikOdustani";
            this.btnCjenikOdustani.Size = new System.Drawing.Size(103, 22);
            this.btnCjenikOdustani.Text = "Odustani i zatvori";
            this.btnCjenikOdustani.Click += new System.EventHandler(this.btnCjenikOdustani_Click);
            // 
            // CjenikForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "CjenikForm";
            this.Size = new System.Drawing.Size(854, 565);
            this.Load += new System.EventHandler(this.CjenikForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TextBoxNaziv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltraGridStavke)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vUFCJENIKSTAVKEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateTimePickerDatumOd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateTimePickerDatumDo)).EndInit();
            this.panel1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblValidationMessages;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton ToolStripButtonSpremi;
        private System.Windows.Forms.ToolStripButton ToolStripButtonSpremiZatvori;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor TextBoxNaziv;
        private System.Windows.Forms.Label label3;
        private Infragistics.Win.UltraWinGrid.UltraGrid UltraGridStavke;
        private System.Windows.Forms.Button btnDodajStavku;
        private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor DateTimePickerDatumOd;
        private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor DateTimePickerDatumDo;
        private System.Windows.Forms.Button btnBrisiStavku;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.BindingSource vUFCJENIKSTAVKEBindingSource;
        private System.Windows.Forms.Button btnIzmjeniStavku;
        private System.Windows.Forms.ToolStripButton btnCjenikOdustani;
    }
}

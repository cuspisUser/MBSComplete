using Infragistics.Win;
using Infragistics.Win.Misc;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win.UltraWinGrid;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Placa;
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Security.Permissions;
using System.Windows.Forms;

public class frmPregledRadnika : Form
{
    private IContainer components { get; set; }
    private OBRACUNDataSet.ObracunRadniciDataTable Obracunati;

    public frmPregledRadnika()
    {
        base.Load += new EventHandler(this.frmPregledRadnika_Load_1);
        this.Obracunati = new OBRACUNDataSet.ObracunRadniciDataTable();
        this.InitializeComponent();
    }

    private int BrojOznacenihRadnika()
    {
        int num2 = 0;
        int num4 = this.UltraGrid2.Rows.Count - 1;
        for (int i = 0; i <= num4; i++)
        {
            if (Conversions.ToBoolean(this.UltraGrid2.Rows[i].Cells["oznacen"].Value))
            {
                num2++;
            }
        }
        return num2;
    }

    [DebuggerNonUserCode]
    protected override void Dispose(bool disposing)
    {
        try
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
        }
        finally
        {
            base.Dispose(disposing);
        }
    }

    private void frmPregledRadnika_Load_1(object sender, EventArgs e)
    {
        new PregledRadnikaSvihDataAdapter().Fill(this.PregledRadnikaDataset2);
        if (this.Obracunati != null)
        {
            IEnumerator enumerator = null;
            try
            {
                enumerator = this.Obracunati.Rows.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    DataRow current = (DataRow) enumerator.Current;
                    DataRow[] rowArray = this.PregledRadnikaDataset2.RADNIK.Select("idradnik = " + current["idradnik"].ToString());
                    this.PregledRadnikaDataset2.RADNIK.RemoveRADNIKRow((PregledRadnikaSvihDataSet.RADNIKRow) rowArray[0]);
                }
            }
            finally
            {
                if (enumerator is IDisposable)
                {
                    (enumerator as IDisposable).Dispose();
                }
            }
        }
        new ORGDIODataAdapter().Fill(this.OrgdioDataSet1);
        DataRow row = this.OrgdioDataSet1.ORGDIO.NewRow();
        row["idorgdio"] = -1;
        row["organizacijskidio"] = "- svi -";
        this.OrgdioDataSet1.ORGDIO.Rows.Add(row);
        this.UltraCombo1.SelectedRow = this.UltraCombo1.Rows[this.UltraCombo1.Rows.Count - 1];
    }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
        UltraGridBand band = new UltraGridBand("ORGDIO", -1);
        UltraGridColumn column = new UltraGridColumn("IDORGDIO");
        UltraGridColumn column3 = new UltraGridColumn("ORGANIZACIJSKIDIO");
        Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
        UltraGridBand band2 = new UltraGridBand("RADNIK", -1);
        UltraGridColumn column4 = new UltraGridColumn("IDRADNIK");
        UltraGridColumn column5 = new UltraGridColumn("JMBG");
        UltraGridColumn column6 = new UltraGridColumn("PREZIME");
        UltraGridColumn column7 = new UltraGridColumn("IME");
        UltraGridColumn column8 = new UltraGridColumn("AKTIVAN");
        UltraGridColumn column9 = new UltraGridColumn("OPCINASTANOVANJAIDOPCINE");
        UltraGridColumn column10 = new UltraGridColumn("IDORGDIO");
        UltraGridColumn column2 = new UltraGridColumn("oznacen", 0);
        Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
        Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
        Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
        Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
        this.UltraButton1 = new UltraButton();
        this.UltraButton2 = new UltraButton();
        this.chkNeto = new UltraCheckEditor();
        this.chkBruto = new UltraCheckEditor();
        this.chkAktivni = new UltraCheckEditor();
        this.UltraButton3 = new UltraButton();
        this.UltraLabel1 = new UltraLabel();
        this.UltraLabel2 = new UltraLabel();
        this.UltraCombo1 = new UltraCombo();
        this.OrgdioDataSet1 = new ORGDIODataSet();
        this.UltraGrid2 = new UltraGrid();
        this.PregledRadnikaDataset2 = new PregledRadnikaSvihDataSet();
        ((ISupportInitialize) this.UltraCombo1).BeginInit();
        this.OrgdioDataSet1.BeginInit();
        ((ISupportInitialize) this.UltraGrid2).BeginInit();
        this.PregledRadnikaDataset2.BeginInit();
        this.SuspendLayout();
        this.UltraButton1.ButtonStyle = UIElementButtonStyle.WindowsVistaButton;
        System.Drawing.Point point = new System.Drawing.Point(12, 12);
        this.UltraButton1.Location = point;
        this.UltraButton1.Name = "UltraButton1";
        Size size = new System.Drawing.Size(0x7b, 0x17);
        this.UltraButton1.Size = size;
        this.UltraButton1.TabIndex = 1;
        this.UltraButton1.Text = "Dodaj oznake svima";
        this.UltraButton1.UseAppStyling = false;
        this.UltraButton1.UseOsThemes = DefaultableBoolean.False;
        this.UltraButton2.ButtonStyle = UIElementButtonStyle.WindowsVistaButton;
        point = new System.Drawing.Point(0x8d, 12);
        this.UltraButton2.Location = point;
        this.UltraButton2.Name = "UltraButton2";
        size = new System.Drawing.Size(0x80, 0x17);
        this.UltraButton2.Size = size;
        this.UltraButton2.TabIndex = 2;
        this.UltraButton2.Text = "Ukloni oznake svima";
        this.UltraButton2.UseAppStyling = false;
        this.UltraButton2.UseOsThemes = DefaultableBoolean.False;
        this.chkNeto.ButtonStyle = UIElementButtonStyle.WindowsVistaButton;
        point = new System.Drawing.Point(0x185, 0x2c);
        this.chkNeto.Location = point;
        this.chkNeto.Name = "chkNeto";
        size = new System.Drawing.Size(0x62, 20);
        this.chkNeto.Size = size;
        this.chkNeto.TabIndex = 40;
        this.chkNeto.Text = "Neto elemente";
        this.chkNeto.UseAppStyling = false;
        this.chkNeto.UseOsThemes = DefaultableBoolean.False;
        this.chkBruto.ButtonStyle = UIElementButtonStyle.WindowsVistaButton;
        point = new System.Drawing.Point(0x11f, 0x2b);
        this.chkBruto.Location = point;
        this.chkBruto.Name = "chkBruto";
        size = new System.Drawing.Size(0x63, 20);
        this.chkBruto.Size = size;
        this.chkBruto.TabIndex = 0x27;
        this.chkBruto.Text = "Bruto elemente";
        this.chkBruto.UseAppStyling = false;
        this.chkBruto.UseOsThemes = DefaultableBoolean.False;
        point = new System.Drawing.Point(12, 0x2a);
        this.chkAktivni.Location = point;
        this.chkAktivni.Name = "chkAktivni";
        size = new System.Drawing.Size(0x88, 20);
        this.chkAktivni.Size = size;
        this.chkAktivni.TabIndex = 0x2a;
        this.chkAktivni.Text = "Prikaži samo aktivne";
        this.chkAktivni.UseAppStyling = false;
        this.UltraButton3.ButtonStyle = UIElementButtonStyle.WindowsVistaButton;
        point = new System.Drawing.Point(0x113, 12);
        this.UltraButton3.Location = point;
        this.UltraButton3.Name = "UltraButton3";
        size = new System.Drawing.Size(0x7b, 0x17);
        this.UltraButton3.Size = size;
        this.UltraButton3.TabIndex = 0x2c;
        this.UltraButton3.Text = "Potvrda odabira";
        this.UltraButton3.UseAppStyling = false;
        this.UltraButton3.UseOsThemes = DefaultableBoolean.False;
        point = new System.Drawing.Point(0x9b, 0x2d);
        this.UltraLabel1.Location = point;
        this.UltraLabel1.Name = "UltraLabel1";
        size = new System.Drawing.Size(0x72, 0x17);
        this.UltraLabel1.Size = size;
        this.UltraLabel1.TabIndex = 0x2d;
        this.UltraLabel1.Text = "Prebaci iz zaduženja:";
        this.UltraLabel1.UseAppStyling = false;
        point = new System.Drawing.Point(0x194, 15);
        this.UltraLabel2.Location = point;
        this.UltraLabel2.Name = "UltraLabel2";
        size = new System.Drawing.Size(0x86, 0x17);
        this.UltraLabel2.Size = size;
        this.UltraLabel2.TabIndex = 0x2f;
        this.UltraLabel2.Text = "Prikaži zaposlenike iz OJ:";
        this.UltraLabel2.UseAppStyling = false;
        this.UltraCombo1.CharacterCasing = CharacterCasing.Normal;
        this.UltraCombo1.DataMember = "ORGDIO";
        this.UltraCombo1.DataSource = this.OrgdioDataSet1;
        column.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
        column.Header.VisiblePosition = 0;
        column3.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
        column3.Header.VisiblePosition = 1;
        band.Columns.AddRange(new object[] { column, column3 });
        this.UltraCombo1.DisplayLayout.BandsSerializer.Add(band);
        this.UltraCombo1.DisplayMember = "ORGANIZACIJSKIDIO";
        this.UltraCombo1.LimitToList = true;
        point = new System.Drawing.Point(540, 11);
        this.UltraCombo1.Location = point;
        this.UltraCombo1.Name = "UltraCombo1";
        size = new System.Drawing.Size(0xcf, 0x16);
        this.UltraCombo1.Size = size;
        this.UltraCombo1.TabIndex = 0x2e;
        this.UltraCombo1.Text = "UltraCombo1";
        this.UltraCombo1.UseAppStyling = false;
        this.UltraCombo1.ValueMember = "IDORGDIO";
        this.OrgdioDataSet1.DataSetName = "ORGDIODataSet";
        this.UltraGrid2.DataMember = "RADNIK";
        this.UltraGrid2.DataSource = this.PregledRadnikaDataset2;
        appearance.BackColor = Color.White;
        this.UltraGrid2.DisplayLayout.Appearance = appearance;
        column4.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
        column4.CellActivation = Activation.NoEdit;
        column4.Header.VisiblePosition = 1;
        column5.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
        column5.CellActivation = Activation.NoEdit;
        column5.Header.VisiblePosition = 2;
        column6.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
        column6.CellActivation = Activation.NoEdit;
        column6.Header.VisiblePosition = 3;
        column7.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
        column7.CellActivation = Activation.NoEdit;
        column7.Header.VisiblePosition = 4;
        column8.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
        column8.CellActivation = Activation.NoEdit;
        column8.Header.VisiblePosition = 5;
        column9.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
        column9.CellActivation = Activation.NoEdit;
        column9.Header.VisiblePosition = 6;
        column10.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
        column10.Header.VisiblePosition = 7;
        column2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
        column2.DataType = typeof(bool);
        column2.DefaultCellValue = false;
        column2.Header.Caption = "Označen";
        column2.Header.VisiblePosition = 0;
        band2.Columns.AddRange(new object[] { column4, column5, column6, column7, column8, column9, column10, column2 });
        band2.Override.RowSelectors = DefaultableBoolean.False;
        this.UltraGrid2.DisplayLayout.BandsSerializer.Add(band2);
        this.UltraGrid2.DisplayLayout.Override.AllowAddNew = AllowAddNew.No;
        this.UltraGrid2.DisplayLayout.Override.AllowDelete = DefaultableBoolean.False;
        this.UltraGrid2.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False;
        this.UltraGrid2.DisplayLayout.Override.BorderStyleCell = UIElementBorderStyle.None;
        appearance2.BackColor = Color.Transparent;
        this.UltraGrid2.DisplayLayout.Override.CardAreaAppearance = appearance2;
        this.UltraGrid2.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect;
        this.UltraGrid2.DisplayLayout.Override.CellPadding = 3;
        this.UltraGrid2.DisplayLayout.Override.ColumnAutoSizeMode = ColumnAutoSizeMode.AllRowsInBand;
        appearance3.TextHAlignAsString = "Left";
        this.UltraGrid2.DisplayLayout.Override.HeaderAppearance = appearance3;
        this.UltraGrid2.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortMulti;
        appearance4.BorderColor = Color.LightGray;
        appearance4.TextVAlignAsString = "Middle";
        this.UltraGrid2.DisplayLayout.Override.RowAppearance = appearance4;
        appearance5.BackColor = Color.LightSteelBlue;
        appearance5.BorderColor = Color.Black;
        appearance5.ForeColor = Color.Black;
        this.UltraGrid2.DisplayLayout.Override.SelectedRowAppearance = appearance5;
        this.UltraGrid2.DisplayLayout.Override.SelectTypeCell = SelectType.None;
        this.UltraGrid2.DisplayLayout.Override.SelectTypeCol = SelectType.None;
        this.UltraGrid2.DisplayLayout.Override.SelectTypeRow = SelectType.Single;
        this.UltraGrid2.DisplayLayout.RowConnectorStyle = RowConnectorStyle.None;
        this.UltraGrid2.DisplayLayout.ScrollBounds = ScrollBounds.ScrollToFill;
        this.UltraGrid2.DisplayLayout.ScrollStyle = ScrollStyle.Immediate;
        this.UltraGrid2.DisplayLayout.TabNavigation = TabNavigation.NextControl;
        this.UltraGrid2.DisplayLayout.ViewStyle = ViewStyle.SingleBand;
        point = new System.Drawing.Point(-1, 0x4e);
        this.UltraGrid2.Location = point;
        this.UltraGrid2.Name = "UltraGrid2";
        size = new System.Drawing.Size(800, 0x20f);
        this.UltraGrid2.Size = size;
        this.UltraGrid2.TabIndex = 0x2b;
        this.PregledRadnikaDataset2.DataSetName = "PregledRadnikaDataset2";
        size = new System.Drawing.Size(0x325, 0x25d);
        this.ClientSize = size;
        this.Controls.Add(this.UltraLabel2);
        this.Controls.Add(this.UltraCombo1);
        this.Controls.Add(this.UltraLabel1);
        this.Controls.Add(this.UltraButton3);
        this.Controls.Add(this.UltraGrid2);
        this.Controls.Add(this.chkAktivni);
        this.Controls.Add(this.chkNeto);
        this.Controls.Add(this.chkBruto);
        this.Controls.Add(this.UltraButton2);
        this.Controls.Add(this.UltraButton1);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "frmPregledRadnika";
        this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
        this.StartPosition = FormStartPosition.CenterScreen;



        this.UltraGrid2.InitializeLayout += new InitializeLayoutEventHandler(this.UltraGrid2_InitializeLayout);
        this.UltraGrid2.MouseDown += new MouseEventHandler(this.UltraGrid2_MouseDown);

        this.UltraCombo1.InitializeLayout += new InitializeLayoutEventHandler(this.UltraCombo1_InitializeLayout);
        this.UltraCombo1.ValueChanged += new EventHandler(this.UltraCombo1_ValueChanged);
        this.UltraCombo1.RowSelected += new RowSelectedEventHandler(this.UltraCombo1_RowSelected);

        this.UltraButton3.Click += new EventHandler(this.UltraButton3_Click);

        this.UltraButton2.Click += new EventHandler(this.UltraButton2_Click);

        this.UltraButton1.Click += new EventHandler(this.UltraButton1_Click);

        this.chkAktivni.CheckedChanged += new EventHandler(this.UltraCheckEditor1_CheckedChanged);




        ((ISupportInitialize) this.UltraCombo1).EndInit();
        this.OrgdioDataSet1.EndInit();
        ((ISupportInitialize) this.UltraGrid2).EndInit();
        this.PregledRadnikaDataset2.EndInit();
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    public void odaberi()
    {
        this.DialogResult = System.Windows.Forms.DialogResult.OK;
        this.Close();
    }

    private void Parametri_OznaciSve()
    {
        int num2 = this.UltraGrid2.Rows.Count - 1;
        for (int i = 0; i <= num2; i++)
        {
            if (Conversions.ToInteger(this.UltraCombo1.SelectedRow.Cells["idorgdio"].Value) == -1)
            {
                if (this.chkAktivni.Checked)
                {
                    if (Conversions.ToBoolean(this.UltraGrid2.Rows[i].Cells["aktivan"].Value))
                    {
                        this.UltraGrid2.Rows[i].Cells["oznacen"].Value = true;
                    }
                }
                else if (!this.chkAktivni.Checked)
                {
                    this.UltraGrid2.Rows[i].Cells["oznacen"].Value = true;
                }
            }
            else if (this.chkAktivni.Checked)
            {
                if (Conversions.ToBoolean(this.UltraGrid2.Rows[i].Cells["aktivan"].Value) & (this.Vrati1(RuntimeHelpers.GetObjectValue(this.UltraGrid2.Rows[i].Cells["idorgdio"].Value)) == Conversions.ToInteger(this.UltraCombo1.SelectedRow.Cells["idorgdio"].Value)))
                {
                    this.UltraGrid2.Rows[i].Cells["oznacen"].Value = true;
                }
            }
            else if (!this.chkAktivni.Checked & (this.Vrati1(RuntimeHelpers.GetObjectValue(this.UltraGrid2.Rows[i].Cells["idorgdio"].Value)) == Conversions.ToInteger(this.UltraCombo1.SelectedRow.Cells["idorgdio"].Value)))
            {
                this.UltraGrid2.Rows[i].Cells["oznacen"].Value = true;
            }
        }
        this.Text = "Odabrano: " + Conversions.ToString(this.BrojOznacenihRadnika()) + " zaposlenika";
    }

    private void Parametri_PrikaziSamoAktivne()
    {
        this.UltraGrid2.DisplayLayout.Bands[0].ColumnFilters.ClearAllFilters();
        if (this.Vrati1(RuntimeHelpers.GetObjectValue(this.UltraCombo1.SelectedRow.Cells["idorgdio"].Value)) == -1)
        {
            this.UltraGrid2.DisplayLayout.Bands[0].ColumnFilters["aktivan"].FilterConditions.Add(FilterComparisionOperator.Equals, 1);
        }
        else
        {
            this.UltraGrid2.DisplayLayout.Bands[0].ColumnFilters["aktivan"].FilterConditions.Add(FilterComparisionOperator.Equals, 1);
            this.UltraGrid2.DisplayLayout.Bands[0].ColumnFilters["IDORGDIO"].FilterConditions.Add(FilterComparisionOperator.Equals, RuntimeHelpers.GetObjectValue(this.UltraCombo1.SelectedRow.Cells["idorgdio"].Value));
        }
    }

    private void Parametri_PrikaziSve()
    {
        this.UltraGrid2.DisplayLayout.Bands[0].ColumnFilters.ClearAllFilters();
        if (this.Vrati1(RuntimeHelpers.GetObjectValue(this.UltraCombo1.SelectedRow.Cells["idorgdio"].Value)) == -1)
        {
            this.UltraGrid2.DisplayLayout.Bands[0].ColumnFilters.ClearAllFilters();
        }
        else
        {
            this.UltraGrid2.DisplayLayout.Bands[0].ColumnFilters["IDORGDIO"].FilterConditions.Add(FilterComparisionOperator.Equals, RuntimeHelpers.GetObjectValue(this.UltraCombo1.SelectedRow.Cells["idorgdio"].Value));
        }
    }

    private void Parametri_SkiniOznakeSvima()
    {
        int num2 = this.UltraGrid2.Rows.Count - 1;
        for (int i = 0; i <= num2; i++)
        {
            this.UltraGrid2.Rows[i].Cells["oznacen"].Value = false;
        }
        this.Text = "Odabrano: " + Conversions.ToString(this.BrojOznacenihRadnika()) + " zaposlenika";
    }

    private void UltraButton1_Click(object sender, EventArgs e)
    {
        this.Parametri_OznaciSve();
    }

    private void UltraButton2_Click(object sender, EventArgs e)
    {
        this.Parametri_SkiniOznakeSvima();
    }

    private void UltraButton3_Click(object sender, EventArgs e)
    {
        if (this.BrojOznacenihRadnika() == 0)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
        else
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
    }

    private void UltraCheckEditor1_CheckedChanged(object sender, EventArgs e)
    {
        if (this.chkAktivni.Checked)
        {
            this.Parametri_PrikaziSamoAktivne();
        }
        else
        {
            this.Parametri_PrikaziSve();
        }
    }

    private void UltraCombo1_InitializeLayout(object sender, InitializeLayoutEventArgs e)
    {
    }

    private void UltraCombo1_RowSelected(object sender, RowSelectedEventArgs e)
    {
        if (e.Row != null)
        {
            if (Operators.ConditionalCompareObjectEqual(e.Row.Cells["IDORGDIO"].Value, "-1", false))
            {
                this.UltraGrid2.DisplayLayout.Bands[0].ColumnFilters.ClearAllFilters();
                if (this.chkAktivni.Checked)
                {
                    this.Parametri_PrikaziSamoAktivne();
                }
                else
                {
                    this.Parametri_PrikaziSve();
                }
            }
            else if (this.chkAktivni.Checked)
            {
                this.Parametri_PrikaziSamoAktivne();
            }
            else
            {
                this.Parametri_PrikaziSve();
            }
        }
    }

    private void UltraCombo1_ValueChanged(object sender, EventArgs e)
    {
    }

    private void UltraGrid2_InitializeLayout(object sender, InitializeLayoutEventArgs e)
    {
    }

    private void UltraGrid2_MouseDown(object sender, MouseEventArgs e)
    {
        this.UltraGrid2.ActiveRow = null;
        if (e.Button == MouseButtons.Left)
        {
            UltraGridRow context = null;
            context = (UltraGridRow) this.UltraGrid2.DisplayLayout.UIElement.ElementFromPoint(e.Location).GetContext(typeof(UltraGridRow));
            if ((context != null) && context.IsDataRow)
            {
                context.Selected = true;
                context.Cells["oznacen"].Value = !Conversions.ToBoolean(context.Cells["oznacen"].Value);
            }
        }
        this.Text = "Odabrano: " + Conversions.ToString(this.BrojOznacenihRadnika()) + " zaposlenika";
    }

    private void UltraGrid2_MouseUp(object sender, MouseEventArgs e)
    {
    }

    public int Vrati1(object vnumber)
    {
        int num = 0;
        if (Information.IsDBNull(RuntimeHelpers.GetObjectValue(vnumber)) | (vnumber == null))
        {
            return -1;
        }
        if (!Versioned.IsNumeric(RuntimeHelpers.GetObjectValue(vnumber)))
        {
            return -1;
        }
        try
        {
            num = int.Parse(Conversions.ToString(vnumber));
        }
        catch (System.Exception exception1)
        {
            throw exception1;
            
            //num = -1;
        }
        return num;
    }

    [PermissionSet(SecurityAction.Demand, Name="FullTrust")]
    protected override void WndProc(ref Message m)
    {
        if ((m.Msg == 0x112) && (m.WParam.ToInt32() == 0xf060))
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
        else
        {
            base.WndProc(ref m);
        }
    }

    public bool Bruto
    {
        get
        {
            return this.chkBruto.Checked;
        }
    }

    private UltraCheckEditor chkAktivni;

    private UltraCheckEditor chkBruto;

    private UltraCheckEditor chkNeto;

    public bool Neto
    {
        get
        {
            return this.chkNeto.Checked;
        }
    }

    public object OdabraniRadnici
    {
        get
        {
            object obj2 = new object();
            if (this.UltraGrid2.Rows.Count != 0)
            {
                obj2 = this.UltraGrid2;
            }
            return obj2;
        }
        set
        {
            this.OdabraniRadnici = RuntimeHelpers.GetObjectValue(value);
        }
    }

    private ORGDIODataSet OrgdioDataSet1;

    private PregledRadnikaSvihDataSet PregledRadnikaDataset2;

    private UltraButton UltraButton1;

    private UltraButton UltraButton2;

    private UltraButton UltraButton3;

    private UltraCombo UltraCombo1;

    private UltraGrid UltraGrid2;

    private UltraLabel UltraLabel1;

    private UltraLabel UltraLabel2;

    public OBRACUNDataSet.ObracunRadniciDataTable VecUObracunu
    {
        set
        {
            this.Obracunati = value;
        }
    }
}


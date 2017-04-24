using Infragistics.Win;
using Infragistics.Win.Misc;
using Infragistics.Win.UltraWinGrid;
using Microsoft.VisualBasic.CompilerServices;
using Placa;
using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

public class frmPregledMjeseciGodina : Form
{
    private CurrencyManager cm;
    private IContainer components { get; set; }
    private DataRowView drv;

    public frmPregledMjeseciGodina()
    {
        base.Load += new EventHandler(this.frmPregledMjeseciGodina_Load);
        this.InitializeComponent();
    }

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

    private void frmPregledMjeseciGodina_Load(object sender, EventArgs e)
    {
        new vw_mjeseci_godine_isplateDataAdapter().Fill(this.Vw_mjeseci_godine_isplateDataSet1);
    }

    private void InitializeComponent()
    {
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("vw_mjeseci_godine_isplate", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MJESECISPLATE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("GODINAISPLATE");
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPregledMjeseciGodina));
            this.UltraGrid1 = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.Vw_mjeseci_godine_isplateDataSet1 = new Placa.vw_mjeseci_godine_isplateDataSet();
            this.UltraButton1 = new Infragistics.Win.Misc.UltraButton();
            this.CheckBox1 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.UltraGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Vw_mjeseci_godine_isplateDataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // UltraGrid1
            // 
            this.UltraGrid1.DataMember = "vw_mjeseci_godine_isplate";
            this.UltraGrid1.DataSource = this.Vw_mjeseci_godine_isplateDataSet1;
            appearance.BackColor = System.Drawing.Color.White;
            this.UltraGrid1.DisplayLayout.Appearance = appearance;
            ultraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn1.Header.Caption = "MJ Isp";
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn1.Width = 82;
            ultraGridColumn2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn2.Header.Caption = "God Isp";
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridColumn2.Width = 71;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2});
            this.UltraGrid1.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.UltraGrid1.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.UltraGrid1.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.UltraGrid1.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
            this.UltraGrid1.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None;
            appearance2.BackColor = System.Drawing.Color.Transparent;
            this.UltraGrid1.DisplayLayout.Override.CardAreaAppearance = appearance2;
            this.UltraGrid1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            this.UltraGrid1.DisplayLayout.Override.CellPadding = 3;
            this.UltraGrid1.DisplayLayout.Override.ColumnAutoSizeMode = Infragistics.Win.UltraWinGrid.ColumnAutoSizeMode.AllRowsInBand;
            appearance3.TextHAlignAsString = "Left";
            this.UltraGrid1.DisplayLayout.Override.HeaderAppearance = appearance3;
            this.UltraGrid1.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            appearance4.BorderColor = System.Drawing.Color.LightGray;
            appearance4.TextVAlignAsString = "Middle";
            this.UltraGrid1.DisplayLayout.Override.RowAppearance = appearance4;
            appearance5.BackColor = System.Drawing.Color.LightSteelBlue;
            appearance5.BorderColor = System.Drawing.Color.Black;
            appearance5.ForeColor = System.Drawing.Color.Black;
            this.UltraGrid1.DisplayLayout.Override.SelectedRowAppearance = appearance5;
            this.UltraGrid1.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.UltraGrid1.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.UltraGrid1.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
            this.UltraGrid1.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.None;
            this.UltraGrid1.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.UltraGrid1.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.UltraGrid1.DisplayLayout.TabNavigation = Infragistics.Win.UltraWinGrid.TabNavigation.NextControl;
            this.UltraGrid1.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.UltraGrid1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.UltraGrid1.Location = new System.Drawing.Point(0, 48);
            this.UltraGrid1.Name = "UltraGrid1";
            this.UltraGrid1.Size = new System.Drawing.Size(259, 569);
            this.UltraGrid1.TabIndex = 1;
            this.UltraGrid1.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.UltraGrid1_InitializeLayout);
            this.UltraGrid1.DoubleClickRow += new Infragistics.Win.UltraWinGrid.DoubleClickRowEventHandler(this.UltraGrid1_DoubleClickRow);
            // 
            // Vw_mjeseci_godine_isplateDataSet1
            // 
            this.Vw_mjeseci_godine_isplateDataSet1.DataSetName = "vw_mjeseci_godine_isplateDataSet";
            // 
            // UltraButton1
            // 
            this.UltraButton1.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaButton;
            this.UltraButton1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.UltraButton1.Location = new System.Drawing.Point(25, 12);
            this.UltraButton1.Name = "UltraButton1";
            this.UltraButton1.Size = new System.Drawing.Size(123, 23);
            this.UltraButton1.TabIndex = 46;
            this.UltraButton1.Text = "Odaberi";
            this.UltraButton1.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.UltraButton1.Click += new System.EventHandler(this.UltraButton1_Click);
            // 
            // CheckBox1
            // 
            this.CheckBox1.AutoSize = true;
            this.CheckBox1.Location = new System.Drawing.Point(155, 17);
            this.CheckBox1.Name = "CheckBox1";
            this.CheckBox1.Size = new System.Drawing.Size(86, 17);
            this.CheckBox1.TabIndex = 47;
            this.CheckBox1.Text = "Za volontere";
            this.CheckBox1.UseVisualStyleBackColor = true;
            // 
            // frmPregledMjeseciGodina
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(259, 617);
            this.Controls.Add(this.CheckBox1);
            this.Controls.Add(this.UltraButton1);
            this.Controls.Add(this.UltraGrid1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPregledMjeseciGodina";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mjeseci i godine isplate";
            ((System.ComponentModel.ISupportInitialize)(this.UltraGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Vw_mjeseci_godine_isplateDataSet1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    private void Odaberi()
    {
        this.cm = (CurrencyManager) this.BindingContext[this.Vw_mjeseci_godine_isplateDataSet1, "vw_mjeseci_godine_isplate"];
        if (this.cm.Count != 0)
        {
            this.drv = (DataRowView) this.cm.Current;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
    }

    private void UltraButton1_Click(object sender, EventArgs e)
    {
        this.Odaberi();
    }

    private void UltraGrid1_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
    {
        this.Odaberi();
    }

    private void UltraGrid1_InitializeLayout(object sender, InitializeLayoutEventArgs e)
    {
    }

    private CheckBox CheckBox1;

    public object OdabraniGodinaIsplate
    {
        get
        {
            object objectValue = new object();
            if ((this.drv != null) && (this.cm.Count != 0))
            {
                objectValue = RuntimeHelpers.GetObjectValue(this.drv["godinaisplate"]);
            }
            return objectValue;
        }
        set
        {
            this.OdabraniGodinaIsplate = RuntimeHelpers.GetObjectValue(value);
        }
    }

    public object OdabraniMjesecIsplate
    {
        get
        {
            object objectValue = new object();
            if ((this.drv != null) && (this.cm.Count != 0))
            {
                objectValue = RuntimeHelpers.GetObjectValue(this.drv["mjesecisplate"]);
            }
            return objectValue;
        }
        set
        {
            this.OdabraniMjesecIsplate = RuntimeHelpers.GetObjectValue(value);
        }
    }

    private UltraButton UltraButton1;

    private UltraGrid UltraGrid1;

    public short Volonteri
    {
        get
        {
            if (this.CheckBox1.Checked)
            {
                return 1;
            }
            return 0;
        }
    }

    private vw_mjeseci_godine_isplateDataSet Vw_mjeseci_godine_isplateDataSet1;
}


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

public class frmPregledMjeseciGodinaObracuna : Form
{
    private CurrencyManager cm;
    private IContainer components { get; set; }
    private DataRowView drv;

    public frmPregledMjeseciGodinaObracuna()
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
        new VW_MJESECI_GODINE_OBRACUNADataAdapter().Fill(this.VW_MJESECI_GODINE_OBRACUNADataSet1);
    }

    private void InitializeComponent()
    {
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("VW_MJESECI_GODINE_OBRACUNA", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MJESECOBRACUNA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("GODINAOBRACUNA", -1, null, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, false);
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPregledMjeseciGodinaObracuna));
            this.UltraGrid1 = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.VW_MJESECI_GODINE_OBRACUNADataSet1 = new Placa.VW_MJESECI_GODINE_OBRACUNADataSet();
            this.UltraButton1 = new Infragistics.Win.Misc.UltraButton();
            ((System.ComponentModel.ISupportInitialize)(this.UltraGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VW_MJESECI_GODINE_OBRACUNADataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // UltraGrid1
            // 
            this.UltraGrid1.DataMember = "VW_MJESECI_GODINE_OBRACUNA";
            this.UltraGrid1.DataSource = this.VW_MJESECI_GODINE_OBRACUNADataSet1;
            appearance.BackColor = System.Drawing.Color.White;
            this.UltraGrid1.DisplayLayout.Appearance = appearance;
            ultraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn1.Header.Caption = "MJ obračuna";
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn2.Header.Caption = "God obračuna";
            ultraGridColumn2.Header.VisiblePosition = 1;
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
            this.UltraGrid1.Size = new System.Drawing.Size(209, 569);
            this.UltraGrid1.TabIndex = 1;
            this.UltraGrid1.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.UltraGrid1_InitializeLayout);
            this.UltraGrid1.DoubleClickRow += new Infragistics.Win.UltraWinGrid.DoubleClickRowEventHandler(this.UltraGrid1_DoubleClickRow);
            // 
            // VW_MJESECI_GODINE_OBRACUNADataSet1
            // 
            this.VW_MJESECI_GODINE_OBRACUNADataSet1.DataSetName = "VW_MJESECI_GODINE_OBRACUNADataSet";
            // 
            // UltraButton1
            // 
            this.UltraButton1.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaButton;
            this.UltraButton1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.UltraButton1.Location = new System.Drawing.Point(47, 12);
            this.UltraButton1.Name = "UltraButton1";
            this.UltraButton1.Size = new System.Drawing.Size(123, 23);
            this.UltraButton1.TabIndex = 46;
            this.UltraButton1.Text = "Odaberi";
            this.UltraButton1.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.UltraButton1.Click += new System.EventHandler(this.UltraButton1_Click);
            // 
            // frmPregledMjeseciGodinaObracuna
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(209, 617);
            this.Controls.Add(this.UltraButton1);
            this.Controls.Add(this.UltraGrid1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPregledMjeseciGodinaObracuna";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mjeseci i godine obračuna";
            ((System.ComponentModel.ISupportInitialize)(this.UltraGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VW_MJESECI_GODINE_OBRACUNADataSet1)).EndInit();
            this.ResumeLayout(false);

    }

    private void Odaberi()
    {
        this.cm = (CurrencyManager) this.BindingContext[this.VW_MJESECI_GODINE_OBRACUNADataSet1, "VW_MJESECI_GODINE_OBRACUNA"];
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

    public object OdabraniGodinaObracuna
    {
        get
        {
            object objectValue = new object();
            if ((this.drv != null) && (this.cm.Count != 0))
            {
                objectValue = RuntimeHelpers.GetObjectValue(this.drv["godinaobracuna"]);
            }
            return objectValue;
        }
        set
        {
            this.OdabraniGodinaObracuna = RuntimeHelpers.GetObjectValue(value);
        }
    }

    public object OdabraniMjesecObracuna
    {
        get
        {
            object objectValue = new object();
            if ((this.drv != null) && (this.cm.Count != 0))
            {
                objectValue = RuntimeHelpers.GetObjectValue(this.drv["mjesecobracuna"]);
            }
            return objectValue;
        }
        set
        {
            this.OdabraniMjesecObracuna = RuntimeHelpers.GetObjectValue(value);
        }
    }

    private UltraButton UltraButton1;

    private UltraGrid UltraGrid1;

    private VW_MJESECI_GODINE_OBRACUNADataSet VW_MJESECI_GODINE_OBRACUNADataSet1;
}


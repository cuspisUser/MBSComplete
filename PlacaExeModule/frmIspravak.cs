using Infragistics.Win;
using Infragistics.Win.UltraDataGridView;
using Infragistics.Win.UltraWinMaskedEdit;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Placa;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

public class frmIspravak : Form
{
    private IContainer components;
    private ELEMENTDataAdapter DAELEMENT;
    private OBRACUNDataAdapter DAOBRACUN;
    private string godina;
    private string mjesec;

    public frmIspravak()
    {
        base.Load += new EventHandler(this.frmIspravak_Load);
        this.DAOBRACUN = new OBRACUNDataAdapter();
        this.DAELEMENT = new ELEMENTDataAdapter();
        this.InitializeComponent();
    }

    private void Button1_Click(object sender, EventArgs e)
    {
        frmPregledObracuna obracuna = new frmPregledObracuna();
        obracuna.ShowDialog();
        if ((obracuna.DialogResult != DialogResult.Cancel) && (obracuna.ObracunSelected != null))
        {
            this.DAELEMENT.Fill(this.ElementDataSet1);
            this.DAOBRACUN.FillByIDOBRACUN(this.ObracunDataSet1, Conversions.ToString(obracuna.ObracunSelected));
            this.godina = obracuna.ObracunSelected.ToString().Substring(0, 4);
            this.mjesec = obracuna.ObracunSelected.ToString().Substring(5, 2);
            this.DataGridView2.ReadOnly = false;
            this.DataGridView1.ReadOnly = false;
        }
    }

    private void Button2_Click(object sender, EventArgs e)
    {
        this.DAOBRACUN.Update(this.ObracunDataSet1);
    }

    private void DataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
    }

    private void DataGridView2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
    {
        this.DataGridView2.Rows[e.RowIndex].ErrorText = string.Empty;
    }

    private void DataGridView2_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
    {
        if (((this.DataGridView2.Columns[e.ColumnIndex].Name == "IDELEMENT") && (e.FormattedValue != null)) && string.IsNullOrEmpty(e.FormattedValue.ToString()))
        {
            this.DataGridView2.Rows[e.RowIndex].ErrorText = "NE MOŽE BITI PRAZNO";
            e.Cancel = true;
        }
    }

    private void DataGridView2_CellValuePushed(object sender, DataGridViewCellValueEventArgs e)
    {
    }

    private void DataGridView2_DataError(object sender, DataGridViewDataErrorEventArgs e)
    {
        if ((e.Exception != null) && (e.Context == DataGridViewDataErrorContexts.Commit))
        {
            MessageBox.Show("CustomerID value must be unique.");
        }
    }

    private void DataGridView2_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
    {
        DataGridViewRow row = e.Row;
        row.Cells["obriznos"].Value = 0;
        row.Cells["obrsatnica"].Value = 0;
        row.Cells["obrpostotak"].Value = 0;
        row.Cells["obrsati"].Value = 0;
        row.Cells["elementrazdobljeod"].Value = DateAndTime.DateSerial(Conversions.ToInteger(this.godina), Conversions.ToInteger(this.mjesec) - 1, 1);
        row.Cells["elementrazdobljedo"].Value = DateAndTime.DateSerial(Conversions.ToInteger(this.godina), Conversions.ToInteger(this.mjesec) - 1, DateTime.DaysInMonth(Conversions.ToInteger(this.godina), Conversions.ToInteger(this.mjesec) - 1));
        row = null;
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

    private void frmIspravak_Load(object sender, EventArgs e)
    {
        this.DataGridView2.ReadOnly = true;
        this.DataGridView1.ReadOnly = true;
    }

    private void InitializeComponent()
    {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIspravak));
            this.DataGridView1 = new System.Windows.Forms.DataGridView();
            this.IDOBRACUNDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDRADNIKDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PREZIMEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IMEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ObracunDataSet1 = new Placa.OBRACUNDataSet();
            this.DataGridView2 = new System.Windows.Forms.DataGridView();
            this.IDELEMENT = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ElementDataSet1 = new Placa.ELEMENTDataSet();
            this.ELEMENTRAZDOBLJEOD = new Infragistics.Win.UltraDataGridView.UltraDateTimeEditorColumn(this.components);
            this.ELEMENTRAZDOBLJEDO = new Infragistics.Win.UltraDataGridView.UltraDateTimeEditorColumn(this.components);
            this.OBRSATI = new Infragistics.Win.UltraDataGridView.UltraNumericEditorColumn(this.components);
            this.OBRSATNICA = new Infragistics.Win.UltraDataGridView.UltraNumericEditorColumn(this.components);
            this.OBRPOSTOTAK = new Infragistics.Win.UltraDataGridView.UltraNumericEditorColumn(this.components);
            this.OBRIZNOS = new Infragistics.Win.UltraDataGridView.UltraNumericEditorColumn(this.components);
            this.IDOBRACUNDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDRADNIKDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDELEMENTDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ELEMENTRAZDOBLJEODDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ELEMENTRAZDOBLJEDODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDOSNOVAOSIGURANJADataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NAZIVOSNOVAOSIGURANJADataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RAZDOBLJESESMIJEPREKLAPATIDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.OBRSATIDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OBRSATNICADataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OBRIZNOSDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NAZIVELEMENTDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDVRSTAELEMENTADataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NAZIVVRSTAELEMENTDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OBRPOSTOTAKDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ZBRAJASATEUFONDSATIDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Button1 = new System.Windows.Forms.Button();
            this.Button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ObracunDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElementDataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // DataGridView1
            // 
            this.DataGridView1.AutoGenerateColumns = false;
            this.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDOBRACUNDataGridViewTextBoxColumn,
            this.IDRADNIKDataGridViewTextBoxColumn,
            this.PREZIMEDataGridViewTextBoxColumn,
            this.IMEDataGridViewTextBoxColumn});
            this.DataGridView1.DataMember = "ObracunRadnici";
            this.DataGridView1.DataSource = this.ObracunDataSet1;
            this.DataGridView1.Location = new System.Drawing.Point(2, 44);
            this.DataGridView1.MultiSelect = false;
            this.DataGridView1.Name = "DataGridView1";
            this.DataGridView1.Size = new System.Drawing.Size(345, 549);
            this.DataGridView1.TabIndex = 1;
            // 
            // IDOBRACUNDataGridViewTextBoxColumn
            // 
            this.IDOBRACUNDataGridViewTextBoxColumn.DataPropertyName = "IDOBRACUN";
            this.IDOBRACUNDataGridViewTextBoxColumn.HeaderText = "IDOBRACUN";
            this.IDOBRACUNDataGridViewTextBoxColumn.Name = "IDOBRACUNDataGridViewTextBoxColumn";
            this.IDOBRACUNDataGridViewTextBoxColumn.Visible = false;
            // 
            // IDRADNIKDataGridViewTextBoxColumn
            // 
            this.IDRADNIKDataGridViewTextBoxColumn.DataPropertyName = "IDRADNIK";
            this.IDRADNIKDataGridViewTextBoxColumn.HeaderText = "IDRADNIK";
            this.IDRADNIKDataGridViewTextBoxColumn.Name = "IDRADNIKDataGridViewTextBoxColumn";
            // 
            // PREZIMEDataGridViewTextBoxColumn
            // 
            this.PREZIMEDataGridViewTextBoxColumn.DataPropertyName = "PREZIME";
            this.PREZIMEDataGridViewTextBoxColumn.HeaderText = "PREZIME";
            this.PREZIMEDataGridViewTextBoxColumn.Name = "PREZIMEDataGridViewTextBoxColumn";
            // 
            // IMEDataGridViewTextBoxColumn
            // 
            this.IMEDataGridViewTextBoxColumn.DataPropertyName = "IME";
            this.IMEDataGridViewTextBoxColumn.HeaderText = "IME";
            this.IMEDataGridViewTextBoxColumn.Name = "IMEDataGridViewTextBoxColumn";
            // 
            // ObracunDataSet1
            // 
            this.ObracunDataSet1.DataSetName = "OBRACUNDataSet";
            // 
            // DataGridView2
            // 
            this.DataGridView2.AutoGenerateColumns = false;
            this.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDELEMENT,
            this.ELEMENTRAZDOBLJEOD,
            this.ELEMENTRAZDOBLJEDO,
            this.OBRSATI,
            this.OBRSATNICA,
            this.OBRPOSTOTAK,
            this.OBRIZNOS,
            this.IDOBRACUNDataGridViewTextBoxColumn1,
            this.IDRADNIKDataGridViewTextBoxColumn1,
            this.IDELEMENTDataGridViewTextBoxColumn,
            this.ELEMENTRAZDOBLJEODDataGridViewTextBoxColumn,
            this.ELEMENTRAZDOBLJEDODataGridViewTextBoxColumn,
            this.IDOSNOVAOSIGURANJADataGridViewTextBoxColumn,
            this.NAZIVOSNOVAOSIGURANJADataGridViewTextBoxColumn,
            this.RAZDOBLJESESMIJEPREKLAPATIDataGridViewCheckBoxColumn,
            this.OBRSATIDataGridViewTextBoxColumn,
            this.OBRSATNICADataGridViewTextBoxColumn,
            this.OBRIZNOSDataGridViewTextBoxColumn,
            this.NAZIVELEMENTDataGridViewTextBoxColumn,
            this.IDVRSTAELEMENTADataGridViewTextBoxColumn,
            this.NAZIVVRSTAELEMENTDataGridViewTextBoxColumn,
            this.OBRPOSTOTAKDataGridViewTextBoxColumn,
            this.ZBRAJASATEUFONDSATIDataGridViewCheckBoxColumn});
            this.DataGridView2.DataMember = "ObracunRadnici.ObracunRadnici_ObracunElementi";
            this.DataGridView2.DataSource = this.ObracunDataSet1;
            this.DataGridView2.Location = new System.Drawing.Point(353, 44);
            this.DataGridView2.Name = "DataGridView2";
            this.DataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridView2.Size = new System.Drawing.Size(938, 549);
            this.DataGridView2.TabIndex = 2;
            this.DataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView2_CellContentClick);
            this.DataGridView2.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView2_CellEndEdit);
            this.DataGridView2.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.DataGridView2_CellValidating);
            this.DataGridView2.CellValuePushed += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.DataGridView2_CellValuePushed);
            this.DataGridView2.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.DataGridView2_DataError);
            this.DataGridView2.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.DataGridView2_DefaultValuesNeeded);
            // 
            // IDELEMENT
            // 
            this.IDELEMENT.DataPropertyName = "IDELEMENT";
            this.IDELEMENT.DataSource = this.ElementDataSet1;
            this.IDELEMENT.DisplayMember = "ELEMENT.NAZIVELEMENT";
            this.IDELEMENT.HeaderText = "IDELEMENT";
            this.IDELEMENT.Name = "IDELEMENT";
            this.IDELEMENT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.IDELEMENT.ValueMember = "ELEMENT.IDELEMENT";
            this.IDELEMENT.Width = 300;
            // 
            // ElementDataSet1
            // 
            this.ElementDataSet1.DataSetName = "ELEMENTDataSet";
            // 
            // ELEMENTRAZDOBLJEOD
            // 
            this.ELEMENTRAZDOBLJEOD.DataPropertyName = "ELEMENTRAZDOBLJEOD";
            this.ELEMENTRAZDOBLJEOD.DefaultNewRowValue = ((object)(resources.GetObject("ELEMENTRAZDOBLJEOD.DefaultNewRowValue")));
            this.ELEMENTRAZDOBLJEOD.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.ELEMENTRAZDOBLJEOD.DropDownCalendarAlignment = Infragistics.Win.DropDownListAlignment.Right;
            this.ELEMENTRAZDOBLJEOD.HeaderText = "ELEMENTRAZDOBLJEOD";
            this.ELEMENTRAZDOBLJEOD.MaskInput = "";
            this.ELEMENTRAZDOBLJEOD.Name = "ELEMENTRAZDOBLJEOD";
            this.ELEMENTRAZDOBLJEOD.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ELEMENTRAZDOBLJEOD.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ELEMENTRAZDOBLJEOD.SpinButtonAlignment = Infragistics.Win.SpinButtonDisplayStyle.None;
            // 
            // ELEMENTRAZDOBLJEDO
            // 
            this.ELEMENTRAZDOBLJEDO.DataPropertyName = "ELEMENTRAZDOBLJEDO";
            this.ELEMENTRAZDOBLJEDO.DefaultNewRowValue = ((object)(resources.GetObject("ELEMENTRAZDOBLJEDO.DefaultNewRowValue")));
            this.ELEMENTRAZDOBLJEDO.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Default;
            this.ELEMENTRAZDOBLJEDO.DropDownCalendarAlignment = Infragistics.Win.DropDownListAlignment.Right;
            this.ELEMENTRAZDOBLJEDO.HeaderText = "ELEMENTRAZDOBLJEDO";
            this.ELEMENTRAZDOBLJEDO.MaskInput = null;
            this.ELEMENTRAZDOBLJEDO.Name = "ELEMENTRAZDOBLJEDO";
            this.ELEMENTRAZDOBLJEDO.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ELEMENTRAZDOBLJEDO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ELEMENTRAZDOBLJEDO.SpinButtonAlignment = Infragistics.Win.SpinButtonDisplayStyle.None;
            // 
            // OBRSATI
            // 
            this.OBRSATI.DataPropertyName = "OBRSATI";
            this.OBRSATI.DefaultNewRowValue = ((object)(resources.GetObject("OBRSATI.DefaultNewRowValue")));
            this.OBRSATI.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Default;
            this.OBRSATI.HeaderText = "OBRSATI";
            this.OBRSATI.MaskClipMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.OBRSATI.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.OBRSATI.MaskInput = "nnn.nn";
            this.OBRSATI.Name = "OBRSATI";
            this.OBRSATI.PadChar = '\0';
            this.OBRSATI.PromptChar = '\0';
            this.OBRSATI.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.OBRSATI.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.OBRSATI.SpinButtonAlignment = Infragistics.Win.SpinButtonDisplayStyle.None;
            // 
            // OBRSATNICA
            // 
            this.OBRSATNICA.DataPropertyName = "OBRSATNICA";
            this.OBRSATNICA.DefaultNewRowValue = ((object)(resources.GetObject("OBRSATNICA.DefaultNewRowValue")));
            this.OBRSATNICA.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Default;
            this.OBRSATNICA.HeaderText = "OBRSATNICA";
            this.OBRSATNICA.MaskInput = "nnnnnnnn.nnnnnnnn";
            this.OBRSATNICA.Name = "OBRSATNICA";
            this.OBRSATNICA.PadChar = '\0';
            this.OBRSATNICA.PromptChar = '\0';
            this.OBRSATNICA.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.OBRSATNICA.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.OBRSATNICA.SpinButtonAlignment = Infragistics.Win.SpinButtonDisplayStyle.None;
            // 
            // OBRPOSTOTAK
            // 
            this.OBRPOSTOTAK.DataPropertyName = "OBRPOSTOTAK";
            this.OBRPOSTOTAK.DefaultNewRowValue = ((object)(resources.GetObject("OBRPOSTOTAK.DefaultNewRowValue")));
            this.OBRPOSTOTAK.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Default;
            this.OBRPOSTOTAK.HeaderText = "OBRPOSTOTAK";
            this.OBRPOSTOTAK.MaskInput = "nnn.nn";
            this.OBRPOSTOTAK.Name = "OBRPOSTOTAK";
            this.OBRPOSTOTAK.PadChar = '\0';
            this.OBRPOSTOTAK.PromptChar = '\0';
            this.OBRPOSTOTAK.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.OBRPOSTOTAK.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.OBRPOSTOTAK.SpinButtonAlignment = Infragistics.Win.SpinButtonDisplayStyle.None;
            // 
            // OBRIZNOS
            // 
            this.OBRIZNOS.DataPropertyName = "OBRIZNOS";
            this.OBRIZNOS.DefaultNewRowValue = ((object)(resources.GetObject("OBRIZNOS.DefaultNewRowValue")));
            this.OBRIZNOS.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Default;
            this.OBRIZNOS.HeaderText = "OBRIZNOS";
            this.OBRIZNOS.MaskInput = "nnnnn.nn";
            this.OBRIZNOS.Name = "OBRIZNOS";
            this.OBRIZNOS.PadChar = '\0';
            this.OBRIZNOS.PromptChar = '\0';
            this.OBRIZNOS.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.OBRIZNOS.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.OBRIZNOS.SpinButtonAlignment = Infragistics.Win.SpinButtonDisplayStyle.None;
            // 
            // IDOBRACUNDataGridViewTextBoxColumn1
            // 
            this.IDOBRACUNDataGridViewTextBoxColumn1.DataPropertyName = "IDOBRACUN";
            this.IDOBRACUNDataGridViewTextBoxColumn1.HeaderText = "IDOBRACUN";
            this.IDOBRACUNDataGridViewTextBoxColumn1.Name = "IDOBRACUNDataGridViewTextBoxColumn1";
            // 
            // IDRADNIKDataGridViewTextBoxColumn1
            // 
            this.IDRADNIKDataGridViewTextBoxColumn1.DataPropertyName = "IDRADNIK";
            this.IDRADNIKDataGridViewTextBoxColumn1.HeaderText = "IDRADNIK";
            this.IDRADNIKDataGridViewTextBoxColumn1.Name = "IDRADNIKDataGridViewTextBoxColumn1";
            // 
            // IDELEMENTDataGridViewTextBoxColumn
            // 
            this.IDELEMENTDataGridViewTextBoxColumn.DataPropertyName = "IDELEMENT";
            this.IDELEMENTDataGridViewTextBoxColumn.HeaderText = "IDELEMENT";
            this.IDELEMENTDataGridViewTextBoxColumn.Name = "IDELEMENTDataGridViewTextBoxColumn";
            // 
            // ELEMENTRAZDOBLJEODDataGridViewTextBoxColumn
            // 
            this.ELEMENTRAZDOBLJEODDataGridViewTextBoxColumn.DataPropertyName = "ELEMENTRAZDOBLJEOD";
            this.ELEMENTRAZDOBLJEODDataGridViewTextBoxColumn.HeaderText = "ELEMENTRAZDOBLJEOD";
            this.ELEMENTRAZDOBLJEODDataGridViewTextBoxColumn.Name = "ELEMENTRAZDOBLJEODDataGridViewTextBoxColumn";
            // 
            // ELEMENTRAZDOBLJEDODataGridViewTextBoxColumn
            // 
            this.ELEMENTRAZDOBLJEDODataGridViewTextBoxColumn.DataPropertyName = "ELEMENTRAZDOBLJEDO";
            this.ELEMENTRAZDOBLJEDODataGridViewTextBoxColumn.HeaderText = "ELEMENTRAZDOBLJEDO";
            this.ELEMENTRAZDOBLJEDODataGridViewTextBoxColumn.Name = "ELEMENTRAZDOBLJEDODataGridViewTextBoxColumn";
            // 
            // IDOSNOVAOSIGURANJADataGridViewTextBoxColumn
            // 
            this.IDOSNOVAOSIGURANJADataGridViewTextBoxColumn.DataPropertyName = "IDOSNOVAOSIGURANJA";
            this.IDOSNOVAOSIGURANJADataGridViewTextBoxColumn.HeaderText = "IDOSNOVAOSIGURANJA";
            this.IDOSNOVAOSIGURANJADataGridViewTextBoxColumn.Name = "IDOSNOVAOSIGURANJADataGridViewTextBoxColumn";
            // 
            // NAZIVOSNOVAOSIGURANJADataGridViewTextBoxColumn
            // 
            this.NAZIVOSNOVAOSIGURANJADataGridViewTextBoxColumn.DataPropertyName = "NAZIVOSNOVAOSIGURANJA";
            this.NAZIVOSNOVAOSIGURANJADataGridViewTextBoxColumn.HeaderText = "NAZIVOSNOVAOSIGURANJA";
            this.NAZIVOSNOVAOSIGURANJADataGridViewTextBoxColumn.Name = "NAZIVOSNOVAOSIGURANJADataGridViewTextBoxColumn";
            // 
            // RAZDOBLJESESMIJEPREKLAPATIDataGridViewCheckBoxColumn
            // 
            this.RAZDOBLJESESMIJEPREKLAPATIDataGridViewCheckBoxColumn.DataPropertyName = "RAZDOBLJESESMIJEPREKLAPATI";
            this.RAZDOBLJESESMIJEPREKLAPATIDataGridViewCheckBoxColumn.HeaderText = "RAZDOBLJESESMIJEPREKLAPATI";
            this.RAZDOBLJESESMIJEPREKLAPATIDataGridViewCheckBoxColumn.Name = "RAZDOBLJESESMIJEPREKLAPATIDataGridViewCheckBoxColumn";
            // 
            // OBRSATIDataGridViewTextBoxColumn
            // 
            this.OBRSATIDataGridViewTextBoxColumn.DataPropertyName = "OBRSATI";
            this.OBRSATIDataGridViewTextBoxColumn.HeaderText = "OBRSATI";
            this.OBRSATIDataGridViewTextBoxColumn.Name = "OBRSATIDataGridViewTextBoxColumn";
            // 
            // OBRSATNICADataGridViewTextBoxColumn
            // 
            this.OBRSATNICADataGridViewTextBoxColumn.DataPropertyName = "OBRSATNICA";
            this.OBRSATNICADataGridViewTextBoxColumn.HeaderText = "OBRSATNICA";
            this.OBRSATNICADataGridViewTextBoxColumn.Name = "OBRSATNICADataGridViewTextBoxColumn";
            // 
            // OBRIZNOSDataGridViewTextBoxColumn
            // 
            this.OBRIZNOSDataGridViewTextBoxColumn.DataPropertyName = "OBRIZNOS";
            this.OBRIZNOSDataGridViewTextBoxColumn.HeaderText = "OBRIZNOS";
            this.OBRIZNOSDataGridViewTextBoxColumn.Name = "OBRIZNOSDataGridViewTextBoxColumn";
            // 
            // NAZIVELEMENTDataGridViewTextBoxColumn
            // 
            this.NAZIVELEMENTDataGridViewTextBoxColumn.DataPropertyName = "NAZIVELEMENT";
            this.NAZIVELEMENTDataGridViewTextBoxColumn.HeaderText = "NAZIVELEMENT";
            this.NAZIVELEMENTDataGridViewTextBoxColumn.Name = "NAZIVELEMENTDataGridViewTextBoxColumn";
            // 
            // IDVRSTAELEMENTADataGridViewTextBoxColumn
            // 
            this.IDVRSTAELEMENTADataGridViewTextBoxColumn.DataPropertyName = "IDVRSTAELEMENTA";
            this.IDVRSTAELEMENTADataGridViewTextBoxColumn.HeaderText = "IDVRSTAELEMENTA";
            this.IDVRSTAELEMENTADataGridViewTextBoxColumn.Name = "IDVRSTAELEMENTADataGridViewTextBoxColumn";
            // 
            // NAZIVVRSTAELEMENTDataGridViewTextBoxColumn
            // 
            this.NAZIVVRSTAELEMENTDataGridViewTextBoxColumn.DataPropertyName = "NAZIVVRSTAELEMENT";
            this.NAZIVVRSTAELEMENTDataGridViewTextBoxColumn.HeaderText = "NAZIVVRSTAELEMENT";
            this.NAZIVVRSTAELEMENTDataGridViewTextBoxColumn.Name = "NAZIVVRSTAELEMENTDataGridViewTextBoxColumn";
            // 
            // OBRPOSTOTAKDataGridViewTextBoxColumn
            // 
            this.OBRPOSTOTAKDataGridViewTextBoxColumn.DataPropertyName = "OBRPOSTOTAK";
            this.OBRPOSTOTAKDataGridViewTextBoxColumn.HeaderText = "OBRPOSTOTAK";
            this.OBRPOSTOTAKDataGridViewTextBoxColumn.Name = "OBRPOSTOTAKDataGridViewTextBoxColumn";
            // 
            // ZBRAJASATEUFONDSATIDataGridViewCheckBoxColumn
            // 
            this.ZBRAJASATEUFONDSATIDataGridViewCheckBoxColumn.DataPropertyName = "ZBRAJASATEUFONDSATI";
            this.ZBRAJASATEUFONDSATIDataGridViewCheckBoxColumn.HeaderText = "ZBRAJASATEUFONDSATI";
            this.ZBRAJASATEUFONDSATIDataGridViewCheckBoxColumn.Name = "ZBRAJASATEUFONDSATIDataGridViewCheckBoxColumn";
            // 
            // Button1
            // 
            this.Button1.Location = new System.Drawing.Point(2, 12);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(75, 23);
            this.Button1.TabIndex = 0;
            this.Button1.Text = "Button1";
            this.Button1.UseVisualStyleBackColor = true;
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // Button2
            // 
            this.Button2.Location = new System.Drawing.Point(110, 12);
            this.Button2.Name = "Button2";
            this.Button2.Size = new System.Drawing.Size(75, 23);
            this.Button2.TabIndex = 3;
            this.Button2.Text = "Spremi";
            this.Button2.UseVisualStyleBackColor = true;
            this.Button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // frmIspravak
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1420, 585);
            this.Controls.Add(this.Button2);
            this.Controls.Add(this.Button1);
            this.Controls.Add(this.DataGridView2);
            this.Controls.Add(this.DataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmIspravak";
            this.Text = "frmIspravak";
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ObracunDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElementDataSet1)).EndInit();
            this.ResumeLayout(false);

    }

    private Button Button1;

    private Button Button2;

    private DataGridView DataGridView1;

    private DataGridView DataGridView2;

    private ELEMENTDataSet ElementDataSet1;

    private UltraDateTimeEditorColumn ELEMENTRAZDOBLJEDO;

    private DataGridViewTextBoxColumn ELEMENTRAZDOBLJEDODataGridViewTextBoxColumn;

    private UltraDateTimeEditorColumn ELEMENTRAZDOBLJEOD;

    private DataGridViewTextBoxColumn ELEMENTRAZDOBLJEODDataGridViewTextBoxColumn;

    private DataGridViewComboBoxColumn IDELEMENT;

    private DataGridViewTextBoxColumn IDELEMENTDataGridViewTextBoxColumn;

    private DataGridViewTextBoxColumn IDOBRACUNDataGridViewTextBoxColumn;

    private DataGridViewTextBoxColumn IDOBRACUNDataGridViewTextBoxColumn1;

    private DataGridViewTextBoxColumn IDOSNOVAOSIGURANJADataGridViewTextBoxColumn;

    private DataGridViewTextBoxColumn IDRADNIKDataGridViewTextBoxColumn;

    private DataGridViewTextBoxColumn IDRADNIKDataGridViewTextBoxColumn1;

    private DataGridViewTextBoxColumn IDVRSTAELEMENTADataGridViewTextBoxColumn;

    private DataGridViewTextBoxColumn IMEDataGridViewTextBoxColumn;

    private DataGridViewTextBoxColumn NAZIVELEMENTDataGridViewTextBoxColumn;

    private DataGridViewTextBoxColumn NAZIVOSNOVAOSIGURANJADataGridViewTextBoxColumn;

    private DataGridViewTextBoxColumn NAZIVVRSTAELEMENTDataGridViewTextBoxColumn;

    private OBRACUNDataSet ObracunDataSet1;

    private UltraNumericEditorColumn OBRIZNOS;

    private DataGridViewTextBoxColumn OBRIZNOSDataGridViewTextBoxColumn;

    private UltraNumericEditorColumn OBRPOSTOTAK;

    private DataGridViewTextBoxColumn OBRPOSTOTAKDataGridViewTextBoxColumn;

    private UltraNumericEditorColumn OBRSATI;

    private DataGridViewTextBoxColumn OBRSATIDataGridViewTextBoxColumn;

    private UltraNumericEditorColumn OBRSATNICA;

    private DataGridViewTextBoxColumn OBRSATNICADataGridViewTextBoxColumn;

    private DataGridViewTextBoxColumn PREZIMEDataGridViewTextBoxColumn;

    private DataGridViewCheckBoxColumn RAZDOBLJESESMIJEPREKLAPATIDataGridViewCheckBoxColumn;

    private DataGridViewCheckBoxColumn ZBRAJASATEUFONDSATIDataGridViewCheckBoxColumn;
}


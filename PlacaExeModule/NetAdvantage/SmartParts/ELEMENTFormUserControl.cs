namespace NetAdvantage.SmartParts
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.BuilderStrategies;
    using Deklarit.Win;
    using Infragistics.Win;
    using Infragistics.Win.Misc;
    using Infragistics.Win.UltraWinEditors;
    using Microsoft.Practices.CompositeUI;
    using Microsoft.Practices.CompositeUI.SmartParts;
    using Microsoft.Practices.ObjectBuilder;
    using NetAdvantage;
    using NetAdvantage.Controllers;
    using Placa;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Data;
    using System.Diagnostics;
    using System.Drawing;
    using System.Globalization;
    using System.Resources;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    [SmartPart]
    public class ELEMENTFormUserControl : UserControl, IBusinessComponentUserControl
    {
        [AccessedThroughProperty("checkPOSTAVLJAMZPZSVIMVIRMANIMA")]
        private UltraCheckEditor _checkPOSTAVLJAMZPZSVIMVIRMANIMA;
        [AccessedThroughProperty("checkRAZDOBLJESESMIJEPREKLAPATI")]
        private UltraCheckEditor _checkRAZDOBLJESESMIJEPREKLAPATI;
        [AccessedThroughProperty("checkZBRAJASATEUFONDSATI")]
        private UltraCheckEditor _checkZBRAJASATEUFONDSATI;
        [AccessedThroughProperty("contextMenu1")]
        private ContextMenu _contextMenu1;
        [AccessedThroughProperty("errorProvider1")]
        private ErrorProvider _errorProvider1;
        [AccessedThroughProperty("errorProviderValidator1")]
        private ErrorProviderValidator _errorProviderValidator1;
        [AccessedThroughProperty("label1EL")]
        private UltraLabel _label1EL;
        [AccessedThroughProperty("label1IDELEMENT")]
        private UltraLabel _label1IDELEMENT;
        [AccessedThroughProperty("label1IDOSNOVAOSIGURANJA")]
        private UltraLabel _label1IDOSNOVAOSIGURANJA;
        [AccessedThroughProperty("label1IDVRSTAELEMENTA")]
        private UltraLabel _label1IDVRSTAELEMENTA;
        [AccessedThroughProperty("label1MOELEMENT")]
        private UltraLabel _label1MOELEMENT;
        [AccessedThroughProperty("label1MZELEMENT")]
        private UltraLabel _label1MZELEMENT;
        [AccessedThroughProperty("label1NAZIVELEMENT")]
        private UltraLabel _label1NAZIVELEMENT;
        [AccessedThroughProperty("label1NAZIVOSNOVAOSIGURANJA")]
        private UltraLabel _label1NAZIVOSNOVAOSIGURANJA;
        [AccessedThroughProperty("label1NAZIVVRSTAELEMENT")]
        private UltraLabel _label1NAZIVVRSTAELEMENT;
        [AccessedThroughProperty("label1OPISPLACANJAELEMENT")]
        private UltraLabel _label1OPISPLACANJAELEMENT;
        [AccessedThroughProperty("label1POELEMENT")]
        private UltraLabel _label1POELEMENT;
        [AccessedThroughProperty("label1POSTAVLJAMZPZSVIMVIRMANIMA")]
        private UltraLabel _label1POSTAVLJAMZPZSVIMVIRMANIMA;

        [AccessedThroughProperty("lblOznaka")]
        private UltraLabel _lblOznaka;

        [AccessedThroughProperty("lblOznaka")]
        private ComboBox _cmbOznaka;

        [AccessedThroughProperty("label1POSTOTAK")]
        private UltraLabel _label1POSTOTAK;
        [AccessedThroughProperty("label1PZELEMENT")]
        private UltraLabel _label1PZELEMENT;
        [AccessedThroughProperty("label1RAZDOBLJESESMIJEPREKLAPATI")]
        private UltraLabel _label1RAZDOBLJESESMIJEPREKLAPATI;
        [AccessedThroughProperty("label1SIFRAOPISAPLACANJAELEMENT")]
        private UltraLabel _label1SIFRAOPISAPLACANJAELEMENT;
        [AccessedThroughProperty("label1ZBRAJASATEUFONDSATI")]
        private UltraLabel _label1ZBRAJASATEUFONDSATI;
        [AccessedThroughProperty("labelEL")]
        private UltraLabel _labelEL;
        [AccessedThroughProperty("labelNAZIVOSNOVAOSIGURANJA")]
        private UltraLabel _labelNAZIVOSNOVAOSIGURANJA;
        [AccessedThroughProperty("labelNAZIVVRSTAELEMENT")]
        private UltraLabel _labelNAZIVVRSTAELEMENT;
        [AccessedThroughProperty("SetNullItem")]
        private MenuItem _SetNullItem;
        [AccessedThroughProperty("textIDELEMENT")]
        private UltraNumericEditor _textIDELEMENT;
        [AccessedThroughProperty("textIDOSNOVAOSIGURANJA")]
        private UltraTextEditor _textIDOSNOVAOSIGURANJA;
        [AccessedThroughProperty("textIDVRSTAELEMENTA")]
        private UltraNumericEditor _textIDVRSTAELEMENTA;
        [AccessedThroughProperty("textMOELEMENT")]
        private UltraTextEditor _textMOELEMENT;
        [AccessedThroughProperty("textMZELEMENT")]
        private UltraTextEditor _textMZELEMENT;
        [AccessedThroughProperty("textNAZIVELEMENT")]
        private UltraTextEditor _textNAZIVELEMENT;
        [AccessedThroughProperty("textOPISPLACANJAELEMENT")]
        private UltraTextEditor _textOPISPLACANJAELEMENT;
        [AccessedThroughProperty("textPOELEMENT")]
        private UltraTextEditor _textPOELEMENT;
        [AccessedThroughProperty("textPOSTOTAK")]
        private UltraNumericEditor _textPOSTOTAK;
        [AccessedThroughProperty("textPZELEMENT")]
        private UltraTextEditor _textPZELEMENT;
        [AccessedThroughProperty("textSIFRAOPISAPLACANJAELEMENT")]
        private UltraTextEditor _textSIFRAOPISAPLACANJAELEMENT;
        [AccessedThroughProperty("toolTip1")]
        private System.Windows.Forms.ToolTip _toolTip1;
        private BindingSource bindingSourceELEMENT;
        private IContainer components = null;
        private ELEMENTDataSet dsELEMENTDataSet1;
        protected TableLayoutPanel layoutManagerformELEMENT;
        private bool m_AutoNumber = false;
        private GenericFormClass m_BaseMethods;
        private ELEMENTDataSet.ELEMENTRow m_CurrentRow;
        private ArrayList m_DataGrids = new ArrayList();
        private string m_FirstLevelName = "ELEMENT";
        private DataRow m_ForeignKeys;
        private string m_FrameworkDescription = StringResources.ELEMENTDescription;
        private DeklaritMode m_Mode;
        private bool Copy;

        public ELEMENTFormUserControl()
        {
            this.InitializeComponent();
            this.Localize();
            this.SetSize();
        }

        private void CallPromptOSNOVAOSIGURANJAIDOSNOVAOSIGURANJA(object sender, EditorButtonEventArgs e)
        {
            DataRow fillByRow = null;
            string fillMethod = "";
            DataRow result = this.ELEMENTController.SelectOSNOVAOSIGURANJAIDOSNOVAOSIGURANJA(fillMethod, fillByRow);
            this.UpdateValuesOSNOVAOSIGURANJAIDOSNOVAOSIGURANJA(result);
        }

        private void CallPromptVRSTAELEMENTIDVRSTAELEMENTA(object sender, EditorButtonEventArgs e)
        {
            DataRow fillByRow = null;
            string fillMethod = "";
            DataRow result = this.ELEMENTController.SelectVRSTAELEMENTIDVRSTAELEMENTA(fillMethod, fillByRow);
            this.UpdateValuesVRSTAELEMENTIDVRSTAELEMENTA(result);
        }

        private void CallViewOSNOVAOSIGURANJAIDOSNOVAOSIGURANJA(object sender, EventArgs e)
        {
            DataRow result = this.ELEMENTController.ShowOSNOVAOSIGURANJAIDOSNOVAOSIGURANJA(this.m_CurrentRow);
            this.UpdateValuesOSNOVAOSIGURANJAIDOSNOVAOSIGURANJA(result);
        }

        private void CallViewVRSTAELEMENTIDVRSTAELEMENTA(object sender, EventArgs e)
        {
            DataRow result = this.ELEMENTController.ShowVRSTAELEMENTIDVRSTAELEMENTA(this.m_CurrentRow);
            this.UpdateValuesVRSTAELEMENTIDVRSTAELEMENTA(result);
        }

        public void ChangeBinding()
        {
            this.bindingSourceELEMENT.DataSource = this.ELEMENTController.DataSet;
            this.dsELEMENTDataSet1 = this.ELEMENTController.DataSet;
        }

        [LocalCommandHandler("Close")]
        public void Close(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void contextMenu1_Popup(object sender, EventArgs e)
        {
            this.m_BaseMethods.ContextMenu1PopupBase(this.contextMenu1, this.m_CurrentRow);
        }

        [LocalCommandHandler("DeleteInstance")]
        public void Delete(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                IEnumerator enumerator = null;
                try
                {
                    enumerator = this.dsELEMENTDataSet1.ELEMENT.Rows.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        ((DataRow) enumerator.Current).Delete();
                    }
                }
                finally
                {
                    if (enumerator is IDisposable)
                    {
                        (enumerator as IDisposable).Dispose();
                    }
                }
                if (this.ELEMENTController.Update(this))
                {
                    this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
                }
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void ELEMENTFormUserControl_Load(object sender, EventArgs e)
        {
            this.Text = StringResources.ELEMENTDescription;
            this.errorProvider1.ContainerControl = this;
            FillOznakaUpdateCopy(m_Mode, Copy);
        }

        public void Initialize(DeklaritMode mode, DataRow foreignKeys, bool isCopy)
        {
            this.ChangeBinding();
            this.m_ForeignKeys = foreignKeys;
            this.RegisterBindingSources();
            this.m_Mode = mode;
            this.Copy = isCopy;
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "ELEMENT", this.m_Mode, this.dsELEMENTDataSet1, this.dsELEMENTDataSet1.ELEMENT.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            Binding binding2 = new Binding("CheckState", this.bindingSourceELEMENT, "RAZDOBLJESESMIJEPREKLAPATI", true);
            binding2.Format += new ConvertEventHandler(this.m_BaseMethods.BooleanFormat);
            binding2.Parse += new ConvertEventHandler(this.m_BaseMethods.BooleanParse);
            if (this.checkRAZDOBLJESESMIJEPREKLAPATI.DataBindings["CheckState"] != null)
            {
                this.checkRAZDOBLJESESMIJEPREKLAPATI.DataBindings.Remove(this.checkRAZDOBLJESESMIJEPREKLAPATI.DataBindings["CheckState"]);
            }
            this.checkRAZDOBLJESESMIJEPREKLAPATI.DataBindings.Add(binding2);
            this.checkRAZDOBLJESESMIJEPREKLAPATI.ThreeState = true;
            Binding binding3 = new Binding("CheckState", this.bindingSourceELEMENT, "ZBRAJASATEUFONDSATI", true);
            binding3.Format += new ConvertEventHandler(this.m_BaseMethods.BooleanFormat);
            binding3.Parse += new ConvertEventHandler(this.m_BaseMethods.BooleanParse);
            if (this.checkZBRAJASATEUFONDSATI.DataBindings["CheckState"] != null)
            {
                this.checkZBRAJASATEUFONDSATI.DataBindings.Remove(this.checkZBRAJASATEUFONDSATI.DataBindings["CheckState"]);
            }
            this.checkZBRAJASATEUFONDSATI.DataBindings.Add(binding3);
            Binding binding = new Binding("CheckState", this.bindingSourceELEMENT, "POSTAVLJAMZPZSVIMVIRMANIMA", true);
            binding.Format += new ConvertEventHandler(this.m_BaseMethods.BooleanFormat);
            binding.Parse += new ConvertEventHandler(this.m_BaseMethods.BooleanParse);
            if (this.checkPOSTAVLJAMZPZSVIMVIRMANIMA.DataBindings["CheckState"] != null)
            {
                this.checkPOSTAVLJAMZPZSVIMVIRMANIMA.DataBindings.Remove(this.checkPOSTAVLJAMZPZSVIMVIRMANIMA.DataBindings["CheckState"]);
            }
            this.checkPOSTAVLJAMZPZSVIMVIRMANIMA.DataBindings.Add(binding);
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = this.dsELEMENTDataSet1.ELEMENT[0];
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.m_CurrentRow = (ELEMENTDataSet.ELEMENTRow) ((DataRowView) this.bindingSourceELEMENT.AddNew()).Row;
                foreach (string str in DataSetUtil.CopyForeignKeyValues(this.m_CurrentRow, foreignKeys))
                {
                    this.m_BaseMethods.SetReadOnly(str, true);
                    this.m_BaseMethods.GetLabelControl(str).Visible = false;
                    this.m_BaseMethods.GetControl(str).Visible = false;
                }
            }
            this.SetFocusInFirstField();
        }

        private void FillOznakaUpdateCopy(DeklaritMode mode, bool copy)
        {
            if (mode == DeklaritMode.Update || copy)
            {
                Mipsed7.DataAccessLayer.SqlClient conn = new Mipsed7.DataAccessLayer.SqlClient();
                string oznaka = "";
                try
                {
                    oznaka = conn.ExecuteScalar("Select Oznaka From Element Where IDELEMENT = " + _textIDELEMENT.Value).ToString();
                }
                catch { oznaka = ""; }


                cmbOznaka.SelectedIndex = VratiOznaku(oznaka);
            }
        }


        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            this.components = new Container();
            ResourceManager manager = new ResourceManager(typeof(ELEMENTFormUserControl));
            this.contextMenu1 = new ContextMenu();
            this.SetNullItem = new MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new ErrorProvider();
            this.errorProviderValidator1 = new ErrorProviderValidator(this.components);
            this.bindingSourceELEMENT = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceELEMENT).BeginInit();
            this.layoutManagerformELEMENT = new TableLayoutPanel();
            this.layoutManagerformELEMENT.SuspendLayout();
            this.layoutManagerformELEMENT.AutoSize = true;
            this.layoutManagerformELEMENT.Dock = DockStyle.Fill;
            this.layoutManagerformELEMENT.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformELEMENT.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformELEMENT.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformELEMENT.Size = size;
            this.layoutManagerformELEMENT.ColumnCount = 2;
            this.layoutManagerformELEMENT.RowCount = 0x11;
            this.layoutManagerformELEMENT.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformELEMENT.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformELEMENT.RowStyles.Add(new RowStyle());
            this.layoutManagerformELEMENT.RowStyles.Add(new RowStyle());
            this.layoutManagerformELEMENT.RowStyles.Add(new RowStyle());
            this.layoutManagerformELEMENT.RowStyles.Add(new RowStyle());
            this.layoutManagerformELEMENT.RowStyles.Add(new RowStyle());
            this.layoutManagerformELEMENT.RowStyles.Add(new RowStyle());
            this.layoutManagerformELEMENT.RowStyles.Add(new RowStyle());
            this.layoutManagerformELEMENT.RowStyles.Add(new RowStyle());
            this.layoutManagerformELEMENT.RowStyles.Add(new RowStyle());
            this.layoutManagerformELEMENT.RowStyles.Add(new RowStyle());
            this.layoutManagerformELEMENT.RowStyles.Add(new RowStyle());
            this.layoutManagerformELEMENT.RowStyles.Add(new RowStyle());
            this.layoutManagerformELEMENT.RowStyles.Add(new RowStyle());
            this.layoutManagerformELEMENT.RowStyles.Add(new RowStyle());
            this.layoutManagerformELEMENT.RowStyles.Add(new RowStyle());
            this.layoutManagerformELEMENT.RowStyles.Add(new RowStyle());
            this.layoutManagerformELEMENT.RowStyles.Add(new RowStyle());
            this.label1IDELEMENT = new UltraLabel();
            this.textIDELEMENT = new UltraNumericEditor();
            this.label1NAZIVELEMENT = new UltraLabel();
            this.textNAZIVELEMENT = new UltraTextEditor();
            this.label1IDVRSTAELEMENTA = new UltraLabel();
            this.textIDVRSTAELEMENTA = new UltraNumericEditor();
            this.label1NAZIVVRSTAELEMENT = new UltraLabel();
            this.labelNAZIVVRSTAELEMENT = new UltraLabel();
            this.label1IDOSNOVAOSIGURANJA = new UltraLabel();
            this.textIDOSNOVAOSIGURANJA = new UltraTextEditor();
            this.label1NAZIVOSNOVAOSIGURANJA = new UltraLabel();
            this.labelNAZIVOSNOVAOSIGURANJA = new UltraLabel();
            this.label1RAZDOBLJESESMIJEPREKLAPATI = new UltraLabel();
            this.checkRAZDOBLJESESMIJEPREKLAPATI = new UltraCheckEditor();
            this.label1POSTOTAK = new UltraLabel();
            this.textPOSTOTAK = new UltraNumericEditor();
            this.label1ZBRAJASATEUFONDSATI = new UltraLabel();
            this.checkZBRAJASATEUFONDSATI = new UltraCheckEditor();
            this.label1MOELEMENT = new UltraLabel();
            this.textMOELEMENT = new UltraTextEditor();
            this.label1POELEMENT = new UltraLabel();
            this.textPOELEMENT = new UltraTextEditor();
            this.label1MZELEMENT = new UltraLabel();
            this.textMZELEMENT = new UltraTextEditor();
            this.label1PZELEMENT = new UltraLabel();
            this.textPZELEMENT = new UltraTextEditor();
            this.label1SIFRAOPISAPLACANJAELEMENT = new UltraLabel();
            this.textSIFRAOPISAPLACANJAELEMENT = new UltraTextEditor();
            this.label1OPISPLACANJAELEMENT = new UltraLabel();
            this.textOPISPLACANJAELEMENT = new UltraTextEditor();
            this.label1POSTAVLJAMZPZSVIMVIRMANIMA = new UltraLabel();
            this.checkPOSTAVLJAMZPZSVIMVIRMANIMA = new UltraCheckEditor();
            this.lblOznaka = new UltraLabel();
            this.cmbOznaka = new ComboBox();
            this.label1EL = new UltraLabel();
            this.labelEL = new UltraLabel();
            ((ISupportInitialize) this.textIDELEMENT).BeginInit();
            ((ISupportInitialize) this.textNAZIVELEMENT).BeginInit();
            ((ISupportInitialize) this.textIDVRSTAELEMENTA).BeginInit();
            ((ISupportInitialize) this.textIDOSNOVAOSIGURANJA).BeginInit();
            ((ISupportInitialize) this.textPOSTOTAK).BeginInit();
            ((ISupportInitialize) this.textMOELEMENT).BeginInit();
            ((ISupportInitialize) this.textPOELEMENT).BeginInit();
            ((ISupportInitialize) this.textMZELEMENT).BeginInit();
            ((ISupportInitialize) this.textPZELEMENT).BeginInit();
            ((ISupportInitialize) this.textSIFRAOPISAPLACANJAELEMENT).BeginInit();
            ((ISupportInitialize) this.textOPISPLACANJAELEMENT).BeginInit();
            this.dsELEMENTDataSet1 = new ELEMENTDataSet();
            this.dsELEMENTDataSet1.BeginInit();
            this.SuspendLayout();
            this.dsELEMENTDataSet1.DataSetName = "dsELEMENT";
            this.dsELEMENTDataSet1.Locale = new CultureInfo("hr-HR");
            this.bindingSourceELEMENT.DataSource = this.dsELEMENTDataSet1;
            this.bindingSourceELEMENT.DataMember = "ELEMENT";
            ((ISupportInitialize) this.bindingSourceELEMENT).BeginInit();
            point = new System.Drawing.Point(0, 0);
            this.label1IDELEMENT.Location = point;
            this.label1IDELEMENT.Name = "label1IDELEMENT";
            this.label1IDELEMENT.TabIndex = 1;
            this.label1IDELEMENT.Tag = "labelIDELEMENT";
            this.label1IDELEMENT.Text = "Šifra elementa:";
            this.label1IDELEMENT.StyleSetName = "FieldUltraLabel";
            this.label1IDELEMENT.AutoSize = true;
            this.label1IDELEMENT.Anchor = AnchorStyles.Left;
            this.label1IDELEMENT.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDELEMENT.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1IDELEMENT.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1IDELEMENT.ImageSize = size;
            this.label1IDELEMENT.Appearance.ForeColor = Color.Black;
            this.label1IDELEMENT.BackColor = Color.Transparent;
            this.layoutManagerformELEMENT.Controls.Add(this.label1IDELEMENT, 0, 0);
            this.layoutManagerformELEMENT.SetColumnSpan(this.label1IDELEMENT, 1);
            this.layoutManagerformELEMENT.SetRowSpan(this.label1IDELEMENT, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1IDELEMENT.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDELEMENT.MinimumSize = size;
            size = new System.Drawing.Size(0x6b, 0x17);
            this.label1IDELEMENT.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textIDELEMENT.Location = point;
            this.textIDELEMENT.Name = "textIDELEMENT";
            this.textIDELEMENT.Tag = "IDELEMENT";
            this.textIDELEMENT.TabIndex = 0;
            this.textIDELEMENT.Anchor = AnchorStyles.Left;
            this.textIDELEMENT.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textIDELEMENT.ReadOnly = false;
            this.textIDELEMENT.PromptChar = ' ';
            this.textIDELEMENT.Enter += new EventHandler(this.numericEditor_Enter);
            this.textIDELEMENT.DataBindings.Add(new Binding("Value", this.bindingSourceELEMENT, "IDELEMENT"));
            this.textIDELEMENT.NumericType = NumericType.Integer;
            this.textIDELEMENT.MaskInput = "{LOC}-nnnnnnnn";
            this.layoutManagerformELEMENT.Controls.Add(this.textIDELEMENT, 1, 0);
            this.layoutManagerformELEMENT.SetColumnSpan(this.textIDELEMENT, 1);
            this.layoutManagerformELEMENT.SetRowSpan(this.textIDELEMENT, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textIDELEMENT.Margin = padding;
            size = new System.Drawing.Size(0x48, 0x16);
            this.textIDELEMENT.MinimumSize = size;
            size = new System.Drawing.Size(0x48, 0x16);
            this.textIDELEMENT.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1NAZIVELEMENT.Location = point;
            this.label1NAZIVELEMENT.Name = "label1NAZIVELEMENT";
            this.label1NAZIVELEMENT.TabIndex = 1;
            this.label1NAZIVELEMENT.Tag = "labelNAZIVELEMENT";
            this.label1NAZIVELEMENT.Text = "Naziv elementa:";
            this.label1NAZIVELEMENT.StyleSetName = "FieldUltraLabel";
            this.label1NAZIVELEMENT.AutoSize = true;
            this.label1NAZIVELEMENT.Anchor = AnchorStyles.Left;
            this.label1NAZIVELEMENT.Appearance.TextVAlign = VAlign.Middle;
            this.label1NAZIVELEMENT.Appearance.ForeColor = Color.Black;
            this.label1NAZIVELEMENT.BackColor = Color.Transparent;
            this.layoutManagerformELEMENT.Controls.Add(this.label1NAZIVELEMENT, 0, 1);
            this.layoutManagerformELEMENT.SetColumnSpan(this.label1NAZIVELEMENT, 1);
            this.layoutManagerformELEMENT.SetRowSpan(this.label1NAZIVELEMENT, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1NAZIVELEMENT.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1NAZIVELEMENT.MinimumSize = size;
            size = new System.Drawing.Size(0x73, 0x17);
            this.label1NAZIVELEMENT.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textNAZIVELEMENT.Location = point;
            this.textNAZIVELEMENT.Name = "textNAZIVELEMENT";
            this.textNAZIVELEMENT.Tag = "NAZIVELEMENT";
            this.textNAZIVELEMENT.TabIndex = 0;
            this.textNAZIVELEMENT.Anchor = AnchorStyles.Left;
            this.textNAZIVELEMENT.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textNAZIVELEMENT.ReadOnly = false;
            this.textNAZIVELEMENT.DataBindings.Add(new Binding("Text", this.bindingSourceELEMENT, "NAZIVELEMENT"));
            this.textNAZIVELEMENT.MaxLength = 50;
            this.layoutManagerformELEMENT.Controls.Add(this.textNAZIVELEMENT, 1, 1);
            this.layoutManagerformELEMENT.SetColumnSpan(this.textNAZIVELEMENT, 1);
            this.layoutManagerformELEMENT.SetRowSpan(this.textNAZIVELEMENT, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textNAZIVELEMENT.Margin = padding;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textNAZIVELEMENT.MinimumSize = size;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textNAZIVELEMENT.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1IDVRSTAELEMENTA.Location = point;
            this.label1IDVRSTAELEMENTA.Name = "label1IDVRSTAELEMENTA";
            this.label1IDVRSTAELEMENTA.TabIndex = 1;
            this.label1IDVRSTAELEMENTA.Tag = "labelIDVRSTAELEMENTA";
            this.label1IDVRSTAELEMENTA.Text = "Šifra Vrste elementa:";
            this.label1IDVRSTAELEMENTA.StyleSetName = "FieldUltraLabel";
            this.label1IDVRSTAELEMENTA.AutoSize = true;
            this.label1IDVRSTAELEMENTA.Anchor = AnchorStyles.Left;
            this.label1IDVRSTAELEMENTA.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDVRSTAELEMENTA.Appearance.ForeColor = Color.Black;
            this.label1IDVRSTAELEMENTA.BackColor = Color.Transparent;
            this.layoutManagerformELEMENT.Controls.Add(this.label1IDVRSTAELEMENTA, 0, 2);
            this.layoutManagerformELEMENT.SetColumnSpan(this.label1IDVRSTAELEMENTA, 1);
            this.layoutManagerformELEMENT.SetRowSpan(this.label1IDVRSTAELEMENTA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1IDVRSTAELEMENTA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDVRSTAELEMENTA.MinimumSize = size;
            size = new System.Drawing.Size(0x92, 0x17);
            this.label1IDVRSTAELEMENTA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textIDVRSTAELEMENTA.Location = point;
            this.textIDVRSTAELEMENTA.Name = "textIDVRSTAELEMENTA";
            this.textIDVRSTAELEMENTA.Tag = "IDVRSTAELEMENTA";
            this.textIDVRSTAELEMENTA.TabIndex = 0;
            this.textIDVRSTAELEMENTA.Anchor = AnchorStyles.Left;
            this.textIDVRSTAELEMENTA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textIDVRSTAELEMENTA.ReadOnly = false;
            this.textIDVRSTAELEMENTA.PromptChar = ' ';
            this.textIDVRSTAELEMENTA.Enter += new EventHandler(this.numericEditor_Enter);
            this.textIDVRSTAELEMENTA.DataBindings.Add(new Binding("Value", this.bindingSourceELEMENT, "IDVRSTAELEMENTA"));
            this.textIDVRSTAELEMENTA.NumericType = NumericType.Integer;
            this.textIDVRSTAELEMENTA.MaskInput = "{LOC}-nnnn";
            EditorButton button2 = new EditorButton {
                Key = "editorButtonVRSTAELEMENTIDVRSTAELEMENTA",
                Tag = "editorButtonVRSTAELEMENTIDVRSTAELEMENTA",
                Text = "..."
            };
            this.textIDVRSTAELEMENTA.ButtonsRight.Add(button2);
            this.textIDVRSTAELEMENTA.EditorButtonClick += new EditorButtonEventHandler(this.CallPromptVRSTAELEMENTIDVRSTAELEMENTA);
            this.layoutManagerformELEMENT.Controls.Add(this.textIDVRSTAELEMENTA, 1, 2);
            this.layoutManagerformELEMENT.SetColumnSpan(this.textIDVRSTAELEMENTA, 1);
            this.layoutManagerformELEMENT.SetRowSpan(this.textIDVRSTAELEMENTA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textIDVRSTAELEMENTA.Margin = padding;
            size = new System.Drawing.Size(0x41, 0x16);
            this.textIDVRSTAELEMENTA.MinimumSize = size;
            size = new System.Drawing.Size(0x41, 0x16);
            this.textIDVRSTAELEMENTA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1NAZIVVRSTAELEMENT.Location = point;
            this.label1NAZIVVRSTAELEMENT.Name = "label1NAZIVVRSTAELEMENT";
            this.label1NAZIVVRSTAELEMENT.TabIndex = 1;
            this.label1NAZIVVRSTAELEMENT.Tag = "labelNAZIVVRSTAELEMENT";
            this.label1NAZIVVRSTAELEMENT.Text = "Naziv vrste elementa:";
            this.label1NAZIVVRSTAELEMENT.StyleSetName = "FieldUltraLabel";
            this.label1NAZIVVRSTAELEMENT.AutoSize = true;
            this.label1NAZIVVRSTAELEMENT.Anchor = AnchorStyles.Left;
            this.label1NAZIVVRSTAELEMENT.Appearance.TextVAlign = VAlign.Middle;
            this.label1NAZIVVRSTAELEMENT.Appearance.ForeColor = Color.Black;
            this.label1NAZIVVRSTAELEMENT.BackColor = Color.Transparent;
            this.layoutManagerformELEMENT.Controls.Add(this.label1NAZIVVRSTAELEMENT, 0, 3);
            this.layoutManagerformELEMENT.SetColumnSpan(this.label1NAZIVVRSTAELEMENT, 1);
            this.layoutManagerformELEMENT.SetRowSpan(this.label1NAZIVVRSTAELEMENT, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1NAZIVVRSTAELEMENT.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1NAZIVVRSTAELEMENT.MinimumSize = size;
            size = new System.Drawing.Size(150, 0x17);
            this.label1NAZIVVRSTAELEMENT.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelNAZIVVRSTAELEMENT.Location = point;
            this.labelNAZIVVRSTAELEMENT.Name = "labelNAZIVVRSTAELEMENT";
            this.labelNAZIVVRSTAELEMENT.Tag = "NAZIVVRSTAELEMENT";
            this.labelNAZIVVRSTAELEMENT.TabIndex = 0;
            this.labelNAZIVVRSTAELEMENT.Anchor = AnchorStyles.Left;
            this.labelNAZIVVRSTAELEMENT.BackColor = Color.Transparent;
            this.labelNAZIVVRSTAELEMENT.DataBindings.Add(new Binding("Text", this.bindingSourceELEMENT, "NAZIVVRSTAELEMENT"));
            this.labelNAZIVVRSTAELEMENT.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformELEMENT.Controls.Add(this.labelNAZIVVRSTAELEMENT, 1, 3);
            this.layoutManagerformELEMENT.SetColumnSpan(this.labelNAZIVVRSTAELEMENT, 1);
            this.layoutManagerformELEMENT.SetRowSpan(this.labelNAZIVVRSTAELEMENT, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelNAZIVVRSTAELEMENT.Margin = padding;
            size = new System.Drawing.Size(0xbf, 0x16);
            this.labelNAZIVVRSTAELEMENT.MinimumSize = size;
            size = new System.Drawing.Size(0xbf, 0x16);
            this.labelNAZIVVRSTAELEMENT.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1IDOSNOVAOSIGURANJA.Location = point;
            this.label1IDOSNOVAOSIGURANJA.Name = "label1IDOSNOVAOSIGURANJA";
            this.label1IDOSNOVAOSIGURANJA.TabIndex = 1;
            this.label1IDOSNOVAOSIGURANJA.Tag = "labelIDOSNOVAOSIGURANJA";
            this.label1IDOSNOVAOSIGURANJA.Text = "Šifra osnove osiguranja:";
            this.label1IDOSNOVAOSIGURANJA.StyleSetName = "FieldUltraLabel";
            this.label1IDOSNOVAOSIGURANJA.AutoSize = true;
            this.label1IDOSNOVAOSIGURANJA.Anchor = AnchorStyles.Left;
            this.label1IDOSNOVAOSIGURANJA.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDOSNOVAOSIGURANJA.Appearance.ForeColor = Color.Black;
            this.label1IDOSNOVAOSIGURANJA.BackColor = Color.Transparent;
            this.layoutManagerformELEMENT.Controls.Add(this.label1IDOSNOVAOSIGURANJA, 0, 4);
            this.layoutManagerformELEMENT.SetColumnSpan(this.label1IDOSNOVAOSIGURANJA, 1);
            this.layoutManagerformELEMENT.SetRowSpan(this.label1IDOSNOVAOSIGURANJA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1IDOSNOVAOSIGURANJA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDOSNOVAOSIGURANJA.MinimumSize = size;
            size = new System.Drawing.Size(0xa5, 0x17);
            this.label1IDOSNOVAOSIGURANJA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textIDOSNOVAOSIGURANJA.Location = point;
            this.textIDOSNOVAOSIGURANJA.Name = "textIDOSNOVAOSIGURANJA";
            this.textIDOSNOVAOSIGURANJA.Tag = "IDOSNOVAOSIGURANJA";
            this.textIDOSNOVAOSIGURANJA.TabIndex = 0;
            this.textIDOSNOVAOSIGURANJA.Anchor = AnchorStyles.Left;
            this.textIDOSNOVAOSIGURANJA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textIDOSNOVAOSIGURANJA.ReadOnly = false;
            this.textIDOSNOVAOSIGURANJA.DataBindings.Add(new Binding("Text", this.bindingSourceELEMENT, "IDOSNOVAOSIGURANJA"));
            this.textIDOSNOVAOSIGURANJA.Nullable = true;
            this.textIDOSNOVAOSIGURANJA.MaxLength = 2;
            EditorButton button = new EditorButton {
                Key = "editorButtonOSNOVAOSIGURANJAIDOSNOVAOSIGURANJA",
                Tag = "editorButtonOSNOVAOSIGURANJAIDOSNOVAOSIGURANJA",
                Text = "..."
            };
            this.textIDOSNOVAOSIGURANJA.ButtonsRight.Add(button);
            this.textIDOSNOVAOSIGURANJA.EditorButtonClick += new EditorButtonEventHandler(this.CallPromptOSNOVAOSIGURANJAIDOSNOVAOSIGURANJA);
            this.layoutManagerformELEMENT.Controls.Add(this.textIDOSNOVAOSIGURANJA, 1, 4);
            this.layoutManagerformELEMENT.SetColumnSpan(this.textIDOSNOVAOSIGURANJA, 1);
            this.layoutManagerformELEMENT.SetRowSpan(this.textIDOSNOVAOSIGURANJA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textIDOSNOVAOSIGURANJA.Margin = padding;
            size = new System.Drawing.Size(50, 0x16);
            this.textIDOSNOVAOSIGURANJA.MinimumSize = size;
            size = new System.Drawing.Size(50, 0x16);
            this.textIDOSNOVAOSIGURANJA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1NAZIVOSNOVAOSIGURANJA.Location = point;
            this.label1NAZIVOSNOVAOSIGURANJA.Name = "label1NAZIVOSNOVAOSIGURANJA";
            this.label1NAZIVOSNOVAOSIGURANJA.TabIndex = 1;
            this.label1NAZIVOSNOVAOSIGURANJA.Tag = "labelNAZIVOSNOVAOSIGURANJA";
            this.label1NAZIVOSNOVAOSIGURANJA.Text = "Naziv osnove osiguranja:";
            this.label1NAZIVOSNOVAOSIGURANJA.StyleSetName = "FieldUltraLabel";
            this.label1NAZIVOSNOVAOSIGURANJA.AutoSize = true;
            this.label1NAZIVOSNOVAOSIGURANJA.Anchor = AnchorStyles.Left;
            this.label1NAZIVOSNOVAOSIGURANJA.Appearance.TextVAlign = VAlign.Middle;
            this.label1NAZIVOSNOVAOSIGURANJA.Appearance.ForeColor = Color.Black;
            this.label1NAZIVOSNOVAOSIGURANJA.BackColor = Color.Transparent;
            this.layoutManagerformELEMENT.Controls.Add(this.label1NAZIVOSNOVAOSIGURANJA, 0, 5);
            this.layoutManagerformELEMENT.SetColumnSpan(this.label1NAZIVOSNOVAOSIGURANJA, 1);
            this.layoutManagerformELEMENT.SetRowSpan(this.label1NAZIVOSNOVAOSIGURANJA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1NAZIVOSNOVAOSIGURANJA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1NAZIVOSNOVAOSIGURANJA.MinimumSize = size;
            size = new System.Drawing.Size(0xab, 0x17);
            this.label1NAZIVOSNOVAOSIGURANJA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelNAZIVOSNOVAOSIGURANJA.Location = point;
            this.labelNAZIVOSNOVAOSIGURANJA.Name = "labelNAZIVOSNOVAOSIGURANJA";
            this.labelNAZIVOSNOVAOSIGURANJA.Tag = "NAZIVOSNOVAOSIGURANJA";
            this.labelNAZIVOSNOVAOSIGURANJA.TabIndex = 0;
            this.labelNAZIVOSNOVAOSIGURANJA.Anchor = AnchorStyles.Left;
            this.labelNAZIVOSNOVAOSIGURANJA.BackColor = Color.Transparent;
            this.labelNAZIVOSNOVAOSIGURANJA.DataBindings.Add(new Binding("Text", this.bindingSourceELEMENT, "NAZIVOSNOVAOSIGURANJA"));
            this.labelNAZIVOSNOVAOSIGURANJA.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformELEMENT.Controls.Add(this.labelNAZIVOSNOVAOSIGURANJA, 1, 5);
            this.layoutManagerformELEMENT.SetColumnSpan(this.labelNAZIVOSNOVAOSIGURANJA, 1);
            this.layoutManagerformELEMENT.SetRowSpan(this.labelNAZIVOSNOVAOSIGURANJA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelNAZIVOSNOVAOSIGURANJA.Margin = padding;
            size = new System.Drawing.Size(0x240, 0x16);
            this.labelNAZIVOSNOVAOSIGURANJA.MinimumSize = size;
            size = new System.Drawing.Size(0x240, 0x16);
            this.labelNAZIVOSNOVAOSIGURANJA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1RAZDOBLJESESMIJEPREKLAPATI.Location = point;
            this.label1RAZDOBLJESESMIJEPREKLAPATI.Name = "label1RAZDOBLJESESMIJEPREKLAPATI";
            this.label1RAZDOBLJESESMIJEPREKLAPATI.TabIndex = 1;
            this.label1RAZDOBLJESESMIJEPREKLAPATI.Tag = "labelRAZDOBLJESESMIJEPREKLAPATI";
            this.label1RAZDOBLJESESMIJEPREKLAPATI.Text = "Razdoblje se smije preklapati:";
            this.label1RAZDOBLJESESMIJEPREKLAPATI.StyleSetName = "FieldUltraLabel";
            this.label1RAZDOBLJESESMIJEPREKLAPATI.AutoSize = true;
            this.label1RAZDOBLJESESMIJEPREKLAPATI.Anchor = AnchorStyles.Left;
            this.label1RAZDOBLJESESMIJEPREKLAPATI.Appearance.TextVAlign = VAlign.Middle;
            this.label1RAZDOBLJESESMIJEPREKLAPATI.Appearance.ForeColor = Color.Black;
            this.label1RAZDOBLJESESMIJEPREKLAPATI.BackColor = Color.Transparent;
            this.layoutManagerformELEMENT.Controls.Add(this.label1RAZDOBLJESESMIJEPREKLAPATI, 0, 6);
            this.layoutManagerformELEMENT.SetColumnSpan(this.label1RAZDOBLJESESMIJEPREKLAPATI, 1);
            this.layoutManagerformELEMENT.SetRowSpan(this.label1RAZDOBLJESESMIJEPREKLAPATI, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1RAZDOBLJESESMIJEPREKLAPATI.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1RAZDOBLJESESMIJEPREKLAPATI.MinimumSize = size;
            size = new System.Drawing.Size(0xca, 0x17);
            this.label1RAZDOBLJESESMIJEPREKLAPATI.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.checkRAZDOBLJESESMIJEPREKLAPATI.Location = point;
            this.checkRAZDOBLJESESMIJEPREKLAPATI.Name = "checkRAZDOBLJESESMIJEPREKLAPATI";
            this.checkRAZDOBLJESESMIJEPREKLAPATI.Tag = "RAZDOBLJESESMIJEPREKLAPATI";
            this.checkRAZDOBLJESESMIJEPREKLAPATI.TabIndex = 0;
            this.checkRAZDOBLJESESMIJEPREKLAPATI.Anchor = AnchorStyles.Left;
            this.checkRAZDOBLJESESMIJEPREKLAPATI.BackColor = System.Drawing.SystemColors.ControlLight;
            this.checkRAZDOBLJESESMIJEPREKLAPATI.Enabled = false;
            this.layoutManagerformELEMENT.Controls.Add(this.checkRAZDOBLJESESMIJEPREKLAPATI, 1, 6);
            this.layoutManagerformELEMENT.SetColumnSpan(this.checkRAZDOBLJESESMIJEPREKLAPATI, 1);
            this.layoutManagerformELEMENT.SetRowSpan(this.checkRAZDOBLJESESMIJEPREKLAPATI, 1);
            padding = new Padding(0, 1, 3, 2);
            this.checkRAZDOBLJESESMIJEPREKLAPATI.Margin = padding;
            size = new System.Drawing.Size(13, 13);
            this.checkRAZDOBLJESESMIJEPREKLAPATI.MinimumSize = size;
            size = new System.Drawing.Size(13, 13);
            this.checkRAZDOBLJESESMIJEPREKLAPATI.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1POSTOTAK.Location = point;
            this.label1POSTOTAK.Name = "label1POSTOTAK";
            this.label1POSTOTAK.TabIndex = 1;
            this.label1POSTOTAK.Tag = "labelPOSTOTAK";
            this.label1POSTOTAK.Text = "Postotak:";
            this.label1POSTOTAK.StyleSetName = "FieldUltraLabel";
            this.label1POSTOTAK.AutoSize = true;
            this.label1POSTOTAK.Anchor = AnchorStyles.Left;
            this.label1POSTOTAK.Appearance.TextVAlign = VAlign.Middle;
            this.label1POSTOTAK.Appearance.ForeColor = Color.Black;
            this.label1POSTOTAK.BackColor = Color.Transparent;
            this.layoutManagerformELEMENT.Controls.Add(this.label1POSTOTAK, 0, 7);
            this.layoutManagerformELEMENT.SetColumnSpan(this.label1POSTOTAK, 1);
            this.layoutManagerformELEMENT.SetRowSpan(this.label1POSTOTAK, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1POSTOTAK.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1POSTOTAK.MinimumSize = size;
            size = new System.Drawing.Size(0x4a, 0x17);
            this.label1POSTOTAK.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textPOSTOTAK.Location = point;
            this.textPOSTOTAK.Name = "textPOSTOTAK";
            this.textPOSTOTAK.Tag = "POSTOTAK";
            this.textPOSTOTAK.TabIndex = 0;
            this.textPOSTOTAK.Anchor = AnchorStyles.Left;
            this.textPOSTOTAK.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textPOSTOTAK.ReadOnly = false;
            this.textPOSTOTAK.PromptChar = ' ';
            this.textPOSTOTAK.Enter += new EventHandler(this.numericEditor_Enter);
            this.textPOSTOTAK.DataBindings.Add(new Binding("Value", this.bindingSourceELEMENT, "POSTOTAK"));
            this.textPOSTOTAK.NumericType = NumericType.Double;
            this.textPOSTOTAK.MaxValue = 79228162514264337593543950335M;
            this.textPOSTOTAK.MinValue = -79228162514264337593543950335M;
            this.textPOSTOTAK.MaskInput = "{LOC}-nnn.nn";
            this.layoutManagerformELEMENT.Controls.Add(this.textPOSTOTAK, 1, 7);
            this.layoutManagerformELEMENT.SetColumnSpan(this.textPOSTOTAK, 1);
            this.layoutManagerformELEMENT.SetRowSpan(this.textPOSTOTAK, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textPOSTOTAK.Margin = padding;
            size = new System.Drawing.Size(0x37, 0x16);
            this.textPOSTOTAK.MinimumSize = size;
            size = new System.Drawing.Size(0x37, 0x16);
            this.textPOSTOTAK.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1ZBRAJASATEUFONDSATI.Location = point;
            this.label1ZBRAJASATEUFONDSATI.Name = "label1ZBRAJASATEUFONDSATI";
            this.label1ZBRAJASATEUFONDSATI.TabIndex = 1;
            this.label1ZBRAJASATEUFONDSATI.Tag = "labelZBRAJASATEUFONDSATI";
            this.label1ZBRAJASATEUFONDSATI.Text = "Sati ulaze u fond sati:";
            this.label1ZBRAJASATEUFONDSATI.StyleSetName = "FieldUltraLabel";
            this.label1ZBRAJASATEUFONDSATI.AutoSize = true;
            this.label1ZBRAJASATEUFONDSATI.Anchor = AnchorStyles.Left;
            this.label1ZBRAJASATEUFONDSATI.Appearance.TextVAlign = VAlign.Middle;
            this.label1ZBRAJASATEUFONDSATI.Appearance.ForeColor = Color.Black;
            this.label1ZBRAJASATEUFONDSATI.BackColor = Color.Transparent;
            this.layoutManagerformELEMENT.Controls.Add(this.label1ZBRAJASATEUFONDSATI, 0, 8);
            this.layoutManagerformELEMENT.SetColumnSpan(this.label1ZBRAJASATEUFONDSATI, 1);
            this.layoutManagerformELEMENT.SetRowSpan(this.label1ZBRAJASATEUFONDSATI, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1ZBRAJASATEUFONDSATI.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1ZBRAJASATEUFONDSATI.MinimumSize = size;
            size = new System.Drawing.Size(0x95, 0x17);
            this.label1ZBRAJASATEUFONDSATI.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.checkZBRAJASATEUFONDSATI.Location = point;
            this.checkZBRAJASATEUFONDSATI.Name = "checkZBRAJASATEUFONDSATI";
            this.checkZBRAJASATEUFONDSATI.Tag = "ZBRAJASATEUFONDSATI";
            this.checkZBRAJASATEUFONDSATI.TabIndex = 0;
            this.checkZBRAJASATEUFONDSATI.Anchor = AnchorStyles.Left;
            this.checkZBRAJASATEUFONDSATI.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.checkZBRAJASATEUFONDSATI.Enabled = true;
            this.layoutManagerformELEMENT.Controls.Add(this.checkZBRAJASATEUFONDSATI, 1, 8);
            this.layoutManagerformELEMENT.SetColumnSpan(this.checkZBRAJASATEUFONDSATI, 1);
            this.layoutManagerformELEMENT.SetRowSpan(this.checkZBRAJASATEUFONDSATI, 1);
            padding = new Padding(0, 1, 3, 2);
            this.checkZBRAJASATEUFONDSATI.Margin = padding;
            size = new System.Drawing.Size(13, 13);
            this.checkZBRAJASATEUFONDSATI.MinimumSize = size;
            size = new System.Drawing.Size(13, 13);
            this.checkZBRAJASATEUFONDSATI.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1MOELEMENT.Location = point;
            this.label1MOELEMENT.Name = "label1MOELEMENT";
            this.label1MOELEMENT.TabIndex = 1;
            this.label1MOELEMENT.Tag = "labelMOELEMENT";
            this.label1MOELEMENT.Text = "Model odobrenja:";
            this.label1MOELEMENT.StyleSetName = "FieldUltraLabel";
            this.label1MOELEMENT.AutoSize = true;
            this.label1MOELEMENT.Anchor = AnchorStyles.Left;
            this.label1MOELEMENT.Appearance.TextVAlign = VAlign.Middle;
            this.label1MOELEMENT.Appearance.ForeColor = Color.Black;
            this.label1MOELEMENT.BackColor = Color.Transparent;
            this.layoutManagerformELEMENT.Controls.Add(this.label1MOELEMENT, 0, 9);
            this.layoutManagerformELEMENT.SetColumnSpan(this.label1MOELEMENT, 1);
            this.layoutManagerformELEMENT.SetRowSpan(this.label1MOELEMENT, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1MOELEMENT.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1MOELEMENT.MinimumSize = size;
            size = new System.Drawing.Size(0x7b, 0x17);
            this.label1MOELEMENT.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textMOELEMENT.Location = point;
            this.textMOELEMENT.Name = "textMOELEMENT";
            this.textMOELEMENT.Tag = "MOELEMENT";
            this.textMOELEMENT.TabIndex = 0;
            this.textMOELEMENT.Anchor = AnchorStyles.Left;
            this.textMOELEMENT.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textMOELEMENT.ContextMenu = this.contextMenu1;
            this.textMOELEMENT.ReadOnly = false;
            this.textMOELEMENT.DataBindings.Add(new Binding("Text", this.bindingSourceELEMENT, "MOELEMENT"));
            this.textMOELEMENT.Nullable = true;
            this.textMOELEMENT.MaxLength = 2;
            this.layoutManagerformELEMENT.Controls.Add(this.textMOELEMENT, 1, 9);
            this.layoutManagerformELEMENT.SetColumnSpan(this.textMOELEMENT, 1);
            this.layoutManagerformELEMENT.SetRowSpan(this.textMOELEMENT, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textMOELEMENT.Margin = padding;
            size = new System.Drawing.Size(30, 0x16);
            this.textMOELEMENT.MinimumSize = size;
            size = new System.Drawing.Size(30, 0x16);
            this.textMOELEMENT.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1POELEMENT.Location = point;
            this.label1POELEMENT.Name = "label1POELEMENT";
            this.label1POELEMENT.TabIndex = 1;
            this.label1POELEMENT.Tag = "labelPOELEMENT";
            this.label1POELEMENT.Text = "Poziv na broj odobrenja:";
            this.label1POELEMENT.StyleSetName = "FieldUltraLabel";
            this.label1POELEMENT.AutoSize = true;
            this.label1POELEMENT.Anchor = AnchorStyles.Left;
            this.label1POELEMENT.Appearance.TextVAlign = VAlign.Middle;
            this.label1POELEMENT.Appearance.ForeColor = Color.Black;
            this.label1POELEMENT.BackColor = Color.Transparent;
            this.layoutManagerformELEMENT.Controls.Add(this.label1POELEMENT, 0, 10);
            this.layoutManagerformELEMENT.SetColumnSpan(this.label1POELEMENT, 1);
            this.layoutManagerformELEMENT.SetRowSpan(this.label1POELEMENT, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1POELEMENT.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1POELEMENT.MinimumSize = size;
            size = new System.Drawing.Size(0xa7, 0x17);
            this.label1POELEMENT.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textPOELEMENT.Location = point;
            this.textPOELEMENT.Name = "textPOELEMENT";
            this.textPOELEMENT.Tag = "POELEMENT";
            this.textPOELEMENT.TabIndex = 0;
            this.textPOELEMENT.Anchor = AnchorStyles.Left;
            this.textPOELEMENT.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textPOELEMENT.ContextMenu = this.contextMenu1;
            this.textPOELEMENT.ReadOnly = false;
            this.textPOELEMENT.DataBindings.Add(new Binding("Text", this.bindingSourceELEMENT, "POELEMENT"));
            this.textPOELEMENT.Nullable = true;
            this.textPOELEMENT.MaxLength = 0x16;
            this.layoutManagerformELEMENT.Controls.Add(this.textPOELEMENT, 1, 10);
            this.layoutManagerformELEMENT.SetColumnSpan(this.textPOELEMENT, 1);
            this.layoutManagerformELEMENT.SetRowSpan(this.textPOELEMENT, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textPOELEMENT.Margin = padding;
            size = new System.Drawing.Size(170, 0x16);
            this.textPOELEMENT.MinimumSize = size;
            size = new System.Drawing.Size(170, 0x16);
            this.textPOELEMENT.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1MZELEMENT.Location = point;
            this.label1MZELEMENT.Name = "label1MZELEMENT";
            this.label1MZELEMENT.TabIndex = 1;
            this.label1MZELEMENT.Tag = "labelMZELEMENT";
            this.label1MZELEMENT.Text = "Model zaduženja:";
            this.label1MZELEMENT.StyleSetName = "FieldUltraLabel";
            this.label1MZELEMENT.AutoSize = true;
            this.label1MZELEMENT.Anchor = AnchorStyles.Left;
            this.label1MZELEMENT.Appearance.TextVAlign = VAlign.Middle;
            this.label1MZELEMENT.Appearance.ForeColor = Color.Black;
            this.label1MZELEMENT.BackColor = Color.Transparent;
            this.layoutManagerformELEMENT.Controls.Add(this.label1MZELEMENT, 0, 11);
            this.layoutManagerformELEMENT.SetColumnSpan(this.label1MZELEMENT, 1);
            this.layoutManagerformELEMENT.SetRowSpan(this.label1MZELEMENT, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1MZELEMENT.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1MZELEMENT.MinimumSize = size;
            size = new System.Drawing.Size(0x7b, 0x17);
            this.label1MZELEMENT.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textMZELEMENT.Location = point;
            this.textMZELEMENT.Name = "textMZELEMENT";
            this.textMZELEMENT.Tag = "MZELEMENT";
            this.textMZELEMENT.TabIndex = 0;
            this.textMZELEMENT.Anchor = AnchorStyles.Left;
            this.textMZELEMENT.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textMZELEMENT.ContextMenu = this.contextMenu1;
            this.textMZELEMENT.ReadOnly = false;
            this.textMZELEMENT.DataBindings.Add(new Binding("Text", this.bindingSourceELEMENT, "MZELEMENT"));
            this.textMZELEMENT.Nullable = true;
            this.textMZELEMENT.MaxLength = 2;
            this.layoutManagerformELEMENT.Controls.Add(this.textMZELEMENT, 1, 11);
            this.layoutManagerformELEMENT.SetColumnSpan(this.textMZELEMENT, 1);
            this.layoutManagerformELEMENT.SetRowSpan(this.textMZELEMENT, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textMZELEMENT.Margin = padding;
            size = new System.Drawing.Size(30, 0x16);
            this.textMZELEMENT.MinimumSize = size;
            size = new System.Drawing.Size(30, 0x16);
            this.textMZELEMENT.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1PZELEMENT.Location = point;
            this.label1PZELEMENT.Name = "label1PZELEMENT";
            this.label1PZELEMENT.TabIndex = 1;
            this.label1PZELEMENT.Tag = "labelPZELEMENT";
            this.label1PZELEMENT.Text = "Poziv na broj zaduženja:";
            this.label1PZELEMENT.StyleSetName = "FieldUltraLabel";
            this.label1PZELEMENT.AutoSize = true;
            this.label1PZELEMENT.Anchor = AnchorStyles.Left;
            this.label1PZELEMENT.Appearance.TextVAlign = VAlign.Middle;
            this.label1PZELEMENT.Appearance.ForeColor = Color.Black;
            this.label1PZELEMENT.BackColor = Color.Transparent;
            this.layoutManagerformELEMENT.Controls.Add(this.label1PZELEMENT, 0, 12);
            this.layoutManagerformELEMENT.SetColumnSpan(this.label1PZELEMENT, 1);
            this.layoutManagerformELEMENT.SetRowSpan(this.label1PZELEMENT, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1PZELEMENT.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1PZELEMENT.MinimumSize = size;
            size = new System.Drawing.Size(0xa7, 0x17);
            this.label1PZELEMENT.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textPZELEMENT.Location = point;
            this.textPZELEMENT.Name = "textPZELEMENT";
            this.textPZELEMENT.Tag = "PZELEMENT";
            this.textPZELEMENT.TabIndex = 0;
            this.textPZELEMENT.Anchor = AnchorStyles.Left;
            this.textPZELEMENT.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textPZELEMENT.ContextMenu = this.contextMenu1;
            this.textPZELEMENT.ReadOnly = false;
            this.textPZELEMENT.DataBindings.Add(new Binding("Text", this.bindingSourceELEMENT, "PZELEMENT"));
            this.textPZELEMENT.Nullable = true;
            this.textPZELEMENT.MaxLength = 0x16;
            this.layoutManagerformELEMENT.Controls.Add(this.textPZELEMENT, 1, 12);
            this.layoutManagerformELEMENT.SetColumnSpan(this.textPZELEMENT, 1);
            this.layoutManagerformELEMENT.SetRowSpan(this.textPZELEMENT, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textPZELEMENT.Margin = padding;
            size = new System.Drawing.Size(170, 0x16);
            this.textPZELEMENT.MinimumSize = size;
            size = new System.Drawing.Size(170, 0x16);
            this.textPZELEMENT.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1SIFRAOPISAPLACANJAELEMENT.Location = point;
            this.label1SIFRAOPISAPLACANJAELEMENT.Name = "label1SIFRAOPISAPLACANJAELEMENT";
            this.label1SIFRAOPISAPLACANJAELEMENT.TabIndex = 1;
            this.label1SIFRAOPISAPLACANJAELEMENT.Tag = "labelSIFRAOPISAPLACANJAELEMENT";
            this.label1SIFRAOPISAPLACANJAELEMENT.Text = "Šifra opisa plaćanja:";
            this.label1SIFRAOPISAPLACANJAELEMENT.StyleSetName = "FieldUltraLabel";
            this.label1SIFRAOPISAPLACANJAELEMENT.AutoSize = true;
            this.label1SIFRAOPISAPLACANJAELEMENT.Anchor = AnchorStyles.Left;
            this.label1SIFRAOPISAPLACANJAELEMENT.Appearance.TextVAlign = VAlign.Middle;
            this.label1SIFRAOPISAPLACANJAELEMENT.Appearance.ForeColor = Color.Black;
            this.label1SIFRAOPISAPLACANJAELEMENT.BackColor = Color.Transparent;
            this.layoutManagerformELEMENT.Controls.Add(this.label1SIFRAOPISAPLACANJAELEMENT, 0, 13);
            this.layoutManagerformELEMENT.SetColumnSpan(this.label1SIFRAOPISAPLACANJAELEMENT, 1);
            this.layoutManagerformELEMENT.SetRowSpan(this.label1SIFRAOPISAPLACANJAELEMENT, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1SIFRAOPISAPLACANJAELEMENT.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1SIFRAOPISAPLACANJAELEMENT.MinimumSize = size;
            size = new System.Drawing.Size(0x8d, 0x17);
            this.label1SIFRAOPISAPLACANJAELEMENT.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textSIFRAOPISAPLACANJAELEMENT.Location = point;
            this.textSIFRAOPISAPLACANJAELEMENT.Name = "textSIFRAOPISAPLACANJAELEMENT";
            this.textSIFRAOPISAPLACANJAELEMENT.Tag = "SIFRAOPISAPLACANJAELEMENT";
            this.textSIFRAOPISAPLACANJAELEMENT.TabIndex = 0;
            this.textSIFRAOPISAPLACANJAELEMENT.Anchor = AnchorStyles.Left;
            this.textSIFRAOPISAPLACANJAELEMENT.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textSIFRAOPISAPLACANJAELEMENT.ContextMenu = this.contextMenu1;
            this.textSIFRAOPISAPLACANJAELEMENT.ReadOnly = false;
            this.textSIFRAOPISAPLACANJAELEMENT.DataBindings.Add(new Binding("Text", this.bindingSourceELEMENT, "SIFRAOPISAPLACANJAELEMENT"));
            this.textSIFRAOPISAPLACANJAELEMENT.Nullable = true;
            this.textSIFRAOPISAPLACANJAELEMENT.MaxLength = 2;
            this.layoutManagerformELEMENT.Controls.Add(this.textSIFRAOPISAPLACANJAELEMENT, 1, 13);
            this.layoutManagerformELEMENT.SetColumnSpan(this.textSIFRAOPISAPLACANJAELEMENT, 1);
            this.layoutManagerformELEMENT.SetRowSpan(this.textSIFRAOPISAPLACANJAELEMENT, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textSIFRAOPISAPLACANJAELEMENT.Margin = padding;
            size = new System.Drawing.Size(30, 0x16);
            this.textSIFRAOPISAPLACANJAELEMENT.MinimumSize = size;
            size = new System.Drawing.Size(30, 0x16);
            this.textSIFRAOPISAPLACANJAELEMENT.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1OPISPLACANJAELEMENT.Location = point;
            this.label1OPISPLACANJAELEMENT.Name = "label1OPISPLACANJAELEMENT";
            this.label1OPISPLACANJAELEMENT.TabIndex = 1;
            this.label1OPISPLACANJAELEMENT.Tag = "labelOPISPLACANJAELEMENT";
            this.label1OPISPLACANJAELEMENT.Text = "Opis plaćanja:";
            this.label1OPISPLACANJAELEMENT.StyleSetName = "FieldUltraLabel";
            this.label1OPISPLACANJAELEMENT.AutoSize = true;
            this.label1OPISPLACANJAELEMENT.Anchor = AnchorStyles.Left;
            this.label1OPISPLACANJAELEMENT.Appearance.TextVAlign = VAlign.Middle;
            this.label1OPISPLACANJAELEMENT.Appearance.ForeColor = Color.Black;
            this.label1OPISPLACANJAELEMENT.BackColor = Color.Transparent;
            this.layoutManagerformELEMENT.Controls.Add(this.label1OPISPLACANJAELEMENT, 0, 14);
            this.layoutManagerformELEMENT.SetColumnSpan(this.label1OPISPLACANJAELEMENT, 1);
            this.layoutManagerformELEMENT.SetRowSpan(this.label1OPISPLACANJAELEMENT, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1OPISPLACANJAELEMENT.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1OPISPLACANJAELEMENT.MinimumSize = size;
            size = new System.Drawing.Size(0x67, 0x17);
            this.label1OPISPLACANJAELEMENT.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textOPISPLACANJAELEMENT.Location = point;
            this.textOPISPLACANJAELEMENT.Name = "textOPISPLACANJAELEMENT";
            this.textOPISPLACANJAELEMENT.Tag = "OPISPLACANJAELEMENT";
            this.textOPISPLACANJAELEMENT.TabIndex = 0;
            this.textOPISPLACANJAELEMENT.Anchor = AnchorStyles.Left;
            this.textOPISPLACANJAELEMENT.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textOPISPLACANJAELEMENT.ContextMenu = this.contextMenu1;
            this.textOPISPLACANJAELEMENT.ReadOnly = false;
            this.textOPISPLACANJAELEMENT.DataBindings.Add(new Binding("Text", this.bindingSourceELEMENT, "OPISPLACANJAELEMENT"));
            this.textOPISPLACANJAELEMENT.Nullable = true;
            this.textOPISPLACANJAELEMENT.MaxLength = 0x24;
            this.layoutManagerformELEMENT.Controls.Add(this.textOPISPLACANJAELEMENT, 1, 14);
            this.layoutManagerformELEMENT.SetColumnSpan(this.textOPISPLACANJAELEMENT, 1);
            this.layoutManagerformELEMENT.SetRowSpan(this.textOPISPLACANJAELEMENT, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textOPISPLACANJAELEMENT.Margin = padding;
            size = new System.Drawing.Size(0x10c, 0x16);
            this.textOPISPLACANJAELEMENT.MinimumSize = size;
            size = new System.Drawing.Size(0x10c, 0x16);
            this.textOPISPLACANJAELEMENT.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1POSTAVLJAMZPZSVIMVIRMANIMA.Location = point;
            this.label1POSTAVLJAMZPZSVIMVIRMANIMA.Name = "label1POSTAVLJAMZPZSVIMVIRMANIMA";
            this.label1POSTAVLJAMZPZSVIMVIRMANIMA.TabIndex = 1;
            this.label1POSTAVLJAMZPZSVIMVIRMANIMA.Tag = "labelPOSTAVLJAMZPZSVIMVIRMANIMA";
            this.label1POSTAVLJAMZPZSVIMVIRMANIMA.Text = "MZ i PZ svim virmanima obračuna:";
            this.label1POSTAVLJAMZPZSVIMVIRMANIMA.StyleSetName = "FieldUltraLabel";
            this.label1POSTAVLJAMZPZSVIMVIRMANIMA.AutoSize = true;
            this.label1POSTAVLJAMZPZSVIMVIRMANIMA.Anchor = AnchorStyles.Left;
            this.label1POSTAVLJAMZPZSVIMVIRMANIMA.Appearance.TextVAlign = VAlign.Middle;
            this.label1POSTAVLJAMZPZSVIMVIRMANIMA.Appearance.ForeColor = Color.Black;
            this.label1POSTAVLJAMZPZSVIMVIRMANIMA.BackColor = Color.Transparent;
            this.layoutManagerformELEMENT.Controls.Add(this.label1POSTAVLJAMZPZSVIMVIRMANIMA, 0, 15);
            this.layoutManagerformELEMENT.SetColumnSpan(this.label1POSTAVLJAMZPZSVIMVIRMANIMA, 1);
            this.layoutManagerformELEMENT.SetRowSpan(this.label1POSTAVLJAMZPZSVIMVIRMANIMA, 1);

            this.lblOznaka.Location = point;
            this.lblOznaka.Name = "lblOznaka";
            this.lblOznaka.TabIndex = 1;
            this.lblOznaka.Tag = "";
            this.lblOznaka.Text = "Oznaka:";
            this.lblOznaka.StyleSetName = "FieldUltraLabel";
            this.lblOznaka.AutoSize = true;
            this.lblOznaka.Anchor = AnchorStyles.Left;
            this.lblOznaka.Appearance.TextVAlign = VAlign.Middle;
            this.lblOznaka.Appearance.ForeColor = Color.Black;
            this.lblOznaka.BackColor = Color.Transparent;
            this.layoutManagerformELEMENT.Controls.Add(this.lblOznaka, 0, 17);
            this.layoutManagerformELEMENT.SetColumnSpan(this.lblOznaka, 1);
            this.layoutManagerformELEMENT.SetRowSpan(this.lblOznaka, 1);
            
            padding = new Padding(3, 1, 5, 2);
            this.label1POSTAVLJAMZPZSVIMVIRMANIMA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1POSTAVLJAMZPZSVIMVIRMANIMA.MinimumSize = size;
            size = new System.Drawing.Size(0xe5, 0x17);
            this.label1POSTAVLJAMZPZSVIMVIRMANIMA.Size = size;
            point = new System.Drawing.Point(0, 0);

            this.checkPOSTAVLJAMZPZSVIMVIRMANIMA.Location = point;
            this.checkPOSTAVLJAMZPZSVIMVIRMANIMA.Name = "checkPOSTAVLJAMZPZSVIMVIRMANIMA";
            this.checkPOSTAVLJAMZPZSVIMVIRMANIMA.Tag = "POSTAVLJAMZPZSVIMVIRMANIMA";
            this.checkPOSTAVLJAMZPZSVIMVIRMANIMA.TabIndex = 0;
            this.checkPOSTAVLJAMZPZSVIMVIRMANIMA.Anchor = AnchorStyles.Left;
            this.checkPOSTAVLJAMZPZSVIMVIRMANIMA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.checkPOSTAVLJAMZPZSVIMVIRMANIMA.Enabled = true;
            this.layoutManagerformELEMENT.Controls.Add(this.checkPOSTAVLJAMZPZSVIMVIRMANIMA, 1, 15);
            this.layoutManagerformELEMENT.SetColumnSpan(this.checkPOSTAVLJAMZPZSVIMVIRMANIMA, 1);
            this.layoutManagerformELEMENT.SetRowSpan(this.checkPOSTAVLJAMZPZSVIMVIRMANIMA, 1);

            cmbOznaka.Location = point;
            cmbOznaka.Name = "cmbOznaka";
            cmbOznaka.Items.Add("1.1. redovan rad");
            cmbOznaka.Items.Add("1.2. redovit rad noću");
            cmbOznaka.Items.Add("1.3. redovit rad u dane blagdana");
            cmbOznaka.Items.Add("1.4. prekovremeni rad");
            cmbOznaka.Items.Add("1.5. prekovremeni rad noću");
            cmbOznaka.Items.Add("1.6. prekovremeni rad u dane blagdana");
            cmbOznaka.Items.Add("1.7. pravo na naknadu plaće");
            cmbOznaka.Items.Add("2. ostali oblici rada (Bruto)");
            cmbOznaka.Items.Add("3. propisani dodaci na plaću (Neto)");
            cmbOznaka.Items.Add("4. sati neopravdanog izostanka");
            cmbOznaka.Items.Add("5. otpremnina");
            cmbOznaka.Items.Add("6. druga mjerila za izracun otpremnine");
            cmbOznaka.Width = 200;
            this.layoutManagerformELEMENT.Controls.Add(this.cmbOznaka, 1, 17);
            this.layoutManagerformELEMENT.SetColumnSpan(this.cmbOznaka, 1);
            this.layoutManagerformELEMENT.SetRowSpan(this.cmbOznaka, 1);

            
            padding = new Padding(0, 1, 3, 2);
            this.checkPOSTAVLJAMZPZSVIMVIRMANIMA.Margin = padding;
            size = new System.Drawing.Size(13, 13);
            this.checkPOSTAVLJAMZPZSVIMVIRMANIMA.MinimumSize = size;
            size = new System.Drawing.Size(13, 13);
            this.checkPOSTAVLJAMZPZSVIMVIRMANIMA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1EL.Location = point;
            this.label1EL.Name = "label1EL";
            this.label1EL.TabIndex = 1;
            this.label1EL.Tag = "labelEL";
            this.label1EL.Text = "EL:";
            this.label1EL.StyleSetName = "FieldUltraLabel";
            this.label1EL.AutoSize = true;
            this.label1EL.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.label1EL.Appearance.TextVAlign = VAlign.Middle;
            this.label1EL.Appearance.ForeColor = Color.Black;
            this.label1EL.BackColor = Color.Transparent;
            this.layoutManagerformELEMENT.Controls.Add(this.label1EL, 0, 0x10);
            this.layoutManagerformELEMENT.SetColumnSpan(this.label1EL, 1);
            this.layoutManagerformELEMENT.SetRowSpan(this.label1EL, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1EL.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1EL.MinimumSize = size;
            size = new System.Drawing.Size(0x22, 0x17);
            this.label1EL.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelEL.Location = point;
            this.labelEL.Name = "labelEL";
            this.labelEL.Tag = "EL";
            this.labelEL.TabIndex = 0;
            this.labelEL.Anchor = AnchorStyles.Left;
            this.labelEL.BackColor = Color.Transparent;
            this.labelEL.DataBindings.Add(new Binding("Text", this.bindingSourceELEMENT, "EL"));
            this.labelEL.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformELEMENT.Controls.Add(this.labelEL, 1, 0x10);
            this.layoutManagerformELEMENT.SetColumnSpan(this.labelEL, 1);
            this.layoutManagerformELEMENT.SetRowSpan(this.labelEL, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelEL.Margin = padding;
            size = new System.Drawing.Size(0x240, 0x2c);
            this.labelEL.MinimumSize = size;
            size = new System.Drawing.Size(0x240, 0x2c);
            this.labelEL.Size = size;
            this.labelEL.Dock = DockStyle.Fill;
            this.Controls.Add(this.layoutManagerformELEMENT);
            this.SetNullItem.Index = 0;
            this.SetNullItem.Text = "Set Null";
            this.SetNullItem.Click += new EventHandler(this.SetNullItem_Click);
            this.contextMenu1.Popup += new EventHandler(this.contextMenu1_Popup);
            this.contextMenu1.MenuItems.AddRange(new MenuItem[] { this.SetNullItem });
            this.errorProvider1.DataSource = this.bindingSourceELEMENT;
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            this.Name = "ELEMENTFormUserControl";
            this.Text = "Elementi";
            this.AutoSize = true;
            this.AutoScroll = true;
            this.Load += new EventHandler(this.ELEMENTFormUserControl_Load);
            this.layoutManagerformELEMENT.ResumeLayout(false);
            this.layoutManagerformELEMENT.PerformLayout();
            ((ISupportInitialize) this.bindingSourceELEMENT).EndInit();
            ((ISupportInitialize) this.textIDELEMENT).EndInit();
            ((ISupportInitialize) this.textNAZIVELEMENT).EndInit();
            ((ISupportInitialize) this.textIDVRSTAELEMENTA).EndInit();
            ((ISupportInitialize) this.textIDOSNOVAOSIGURANJA).EndInit();
            ((ISupportInitialize) this.textPOSTOTAK).EndInit();
            ((ISupportInitialize) this.textMOELEMENT).EndInit();
            ((ISupportInitialize) this.textPOELEMENT).EndInit();
            ((ISupportInitialize) this.textMZELEMENT).EndInit();
            ((ISupportInitialize) this.textPZELEMENT).EndInit();
            ((ISupportInitialize) this.textSIFRAOPISAPLACANJAELEMENT).EndInit();
            ((ISupportInitialize) this.textOPISPLACANJAELEMENT).EndInit();
            this.dsELEMENTDataSet1.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private bool InValidState()
        {
            if ((this.ELEMENTController.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourceELEMENT, this.ELEMENTController.WorkItem, this))
            {
                return false;
            }
            if (!this.m_BaseMethods.IsDelete() && this.errorProviderValidator1.HasErrors)
            {
                return false;
            }
            return true;
        }

        private void Localize()
        {
            this.label1IDELEMENT.Text = StringResources.ELEMENTIDELEMENTDescription;
            this.label1NAZIVELEMENT.Text = StringResources.ELEMENTNAZIVELEMENTDescription;
            this.label1IDVRSTAELEMENTA.Text = StringResources.ELEMENTIDVRSTAELEMENTADescription;
            this.label1NAZIVVRSTAELEMENT.Text = StringResources.ELEMENTNAZIVVRSTAELEMENTDescription;
            this.label1IDOSNOVAOSIGURANJA.Text = StringResources.ELEMENTIDOSNOVAOSIGURANJADescription;
            this.label1NAZIVOSNOVAOSIGURANJA.Text = StringResources.ELEMENTNAZIVOSNOVAOSIGURANJADescription;
            this.label1RAZDOBLJESESMIJEPREKLAPATI.Text = StringResources.ELEMENTRAZDOBLJESESMIJEPREKLAPATIDescription;
            this.label1POSTOTAK.Text = StringResources.ELEMENTPOSTOTAKDescription;
            this.label1ZBRAJASATEUFONDSATI.Text = StringResources.ELEMENTZBRAJASATEUFONDSATIDescription;
            this.label1MOELEMENT.Text = StringResources.ELEMENTMOELEMENTDescription;
            this.label1POELEMENT.Text = StringResources.ELEMENTPOELEMENTDescription;
            this.label1MZELEMENT.Text = StringResources.ELEMENTMZELEMENTDescription;
            this.label1PZELEMENT.Text = StringResources.ELEMENTPZELEMENTDescription;
            this.label1SIFRAOPISAPLACANJAELEMENT.Text = StringResources.ELEMENTSIFRAOPISAPLACANJAELEMENTDescription;
            this.label1OPISPLACANJAELEMENT.Text = StringResources.ELEMENTOPISPLACANJAELEMENTDescription;
            this.label1POSTAVLJAMZPZSVIMVIRMANIMA.Text = StringResources.ELEMENTPOSTAVLJAMZPZSVIMVIRMANIMADescription;
            this.label1EL.Text = StringResources.ELEMENTELDescription;
        }

        private void mouseEnter_Text(object sender, EventArgs e)
        {
            this.m_BaseMethods.MouseEnterTextBase(this.toolTip1, this.m_CurrentRow, RuntimeHelpers.GetObjectValue(sender));
        }

        [LocalCommandHandler("NewBOLOVANJEFOND")]
        public void NewBOLOVANJEFONDHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.ELEMENTController.NewBOLOVANJEFOND(this.m_CurrentRow);
            }
        }

        [LocalCommandHandler("NewRAD1GELEMENTIVEZA")]
        public void NewRAD1GELEMENTIVEZAHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.ELEMENTController.NewRAD1GELEMENTIVEZA(this.m_CurrentRow);
            }
        }

        [LocalCommandHandler("NewRAD1MELEMENTIVEZA")]
        public void NewRAD1MELEMENTIVEZAHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.ELEMENTController.NewRAD1MELEMENTIVEZA(this.m_CurrentRow);
            }
        }

        private void numericEditor_Enter(object sender, EventArgs e)
        {
            ((UltraNumericEditor) sender).SelectAll();
        }

        private void RegisterBindingSources()
        {
            if (!this.ELEMENTController.WorkItem.Items.Contains("ELEMENT|ELEMENT"))
            {
                this.ELEMENTController.WorkItem.Items.Add(this.bindingSourceELEMENT, "ELEMENT|ELEMENT");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        public void ResumeBindingPostUpdate()
        {
            if ((this.dsELEMENTDataSet1.ELEMENT.Rows[0] != null) && this.m_BaseMethods.IsInsert())
            {
                this.m_Mode = DeklaritMode.Update;
                this.m_BaseMethods.Mode = this.m_Mode;
                this.m_BaseMethods.FormLoadStyle();
            }
        }

        string VratiOznaku(int index)
        {
            string oznaka = "";
            switch (index)
            {
                case 0:
                    oznaka = "1.1";
                    break;
                case 1:
                    oznaka = "1.2";
                    break;
                case 2:
                    oznaka = "1.3";
                    break;
                case 3:
                    oznaka = "1.4";
                    break;
                case 4:
                    oznaka = "1.5";
                    break;
                case 5:
                    oznaka = "1.6";
                    break;
                case 6:
                    oznaka = "1.7";
                    break;
                case 7:
                    oznaka = "2";
                    break;
                case 8:
                    oznaka = "3";
                    break;
                case 9:
                    oznaka = "4";
                    break;
                case 10:
                    oznaka = "5";
                    break;
                case 11:
                    oznaka = "6";
                    break;
                default:
                    oznaka = "0.0";
                    break;
            }
            return oznaka;
        }

        int VratiOznaku(string oznaka)
        {
            int index = -1;
            switch (oznaka)
            {
                case "1.1":
                    index = 0;
                    break;
                case "1.2":
                    index = 1;
                    break;
                case "1.3":
                    index = 2;
                    break;
                case "1.4":
                    index = 3;
                    break;
                case "1.5":
                    index = 4;
                    break;
                case "1.6":
                    index = 5;
                    break;
                case "1.7":
                    index = 6;
                    break;
                case "2":
                    index = 7;
                    break;
                case "3":
                    index = 8;
                    break;
                case "4":
                    index = 9;
                    break;
                case "5":
                    index = 10;
                    break;
                case "6":
                    index = 11;
                    break;
                default :
                    index = -1;
                    break;
            }
            return index;
        }

        private void UpisiOznaku(ComboBox cmbOznaka)
        {
            Mipsed7.DataAccessLayer.SqlClient conn = new Mipsed7.DataAccessLayer.SqlClient();

            if (cmbOznaka.SelectedIndex > -1)
            {
                conn.ExecuteNonQuery("Update Element Set Oznaka = '" + VratiOznaku(cmbOznaka.SelectedIndex) + "' Where IDELEMENT = " + _textIDELEMENT.Value);
            }
        }

        [LocalCommandHandler("Save")]
        public void Save(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.ELEMENTController.Update(this);

                UpisiOznaku(cmbOznaka);
            }
           
         }


        [LocalCommandHandler("SaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (this.InValidState() && this.ELEMENTController.Update(this))
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;

                UpisiOznaku(cmbOznaka);
            }

            
        }

        [LocalCommandHandler("SaveAndNew")]
        public void SaveAndNew(object sender, EventArgs e)
        {
            if (this.InValidState() && this.ELEMENTController.Update(this))
            {
                this.ELEMENTController.DataSet = new ELEMENTDataSet();
                DataSetUtil.AddEmptyRow(this.ELEMENTController.DataSet);
                this.ChangeBinding();
                this.m_CurrentRow = this.ELEMENTController.DataSet.ELEMENT[0];
                DataSetUtil.CopyForeignKeyValues(this.m_CurrentRow, this.m_ForeignKeys);
                this.SetFocusInFirstField();

                UpisiOznaku(cmbOznaka);
            }
        }

        private void SetFocusInFirstField()
        {
            this.textIDELEMENT.Focus();
        }

        private void SetNullItem_Click(object sender, EventArgs e)
        {
            this.m_BaseMethods.SetNullItemClickBase(RuntimeHelpers.GetObjectValue(sender), this.m_CurrentRow);
        }

        private void SetSize()
        {
        }

        private void ShowMessage(string msg)
        {
            MessageBox.Show(msg, this.m_FrameworkDescription, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void UpdateValuesOSNOVAOSIGURANJAIDOSNOVAOSIGURANJA(DataRow result)
        {
            if (result != null)
            {
                ((DataRowView) this.bindingSourceELEMENT.Current).Row["IDOSNOVAOSIGURANJA"] = RuntimeHelpers.GetObjectValue(result["IDOSNOVAOSIGURANJA"]);
                ((DataRowView) this.bindingSourceELEMENT.Current).Row["NAZIVOSNOVAOSIGURANJA"] = RuntimeHelpers.GetObjectValue(result["NAZIVOSNOVAOSIGURANJA"]);
                ((DataRowView) this.bindingSourceELEMENT.Current).Row["RAZDOBLJESESMIJEPREKLAPATI"] = RuntimeHelpers.GetObjectValue(result["RAZDOBLJESESMIJEPREKLAPATI"]);
                this.bindingSourceELEMENT.ResetCurrentItem();
            }
        }

        private void UpdateValuesVRSTAELEMENTIDVRSTAELEMENTA(DataRow result)
        {
            if (result != null)
            {
                ((DataRowView) this.bindingSourceELEMENT.Current).Row["IDVRSTAELEMENTA"] = RuntimeHelpers.GetObjectValue(result["IDVRSTAELEMENTA"]);
                ((DataRowView) this.bindingSourceELEMENT.Current).Row["NAZIVVRSTAELEMENT"] = RuntimeHelpers.GetObjectValue(result["NAZIVVRSTAELEMENT"]);
                this.bindingSourceELEMENT.ResetCurrentItem();
            }
        }

        [LocalCommandHandler("ViewBOLOVANJEFOND")]
        public void ViewBOLOVANJEFONDHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.ELEMENTController.ViewBOLOVANJEFOND(this.m_CurrentRow);
            }
        }

        [LocalCommandHandler("ViewRAD1GELEMENTIVEZA")]
        public void ViewRAD1GELEMENTIVEZAHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.ELEMENTController.ViewRAD1GELEMENTIVEZA(this.m_CurrentRow);
            }
        }

        [LocalCommandHandler("ViewRAD1MELEMENTIVEZA")]
        public void ViewRAD1MELEMENTIVEZAHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.ELEMENTController.ViewRAD1MELEMENTIVEZA(this.m_CurrentRow);
            }
        }

        protected virtual UltraCheckEditor checkPOSTAVLJAMZPZSVIMVIRMANIMA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._checkPOSTAVLJAMZPZSVIMVIRMANIMA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._checkPOSTAVLJAMZPZSVIMVIRMANIMA = value;
            }
        }

        protected virtual ComboBox cmbOznaka
        {
            [DebuggerNonUserCode]
            get
            {
                return this._cmbOznaka;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._cmbOznaka = value;
            }
        }

        protected virtual UltraCheckEditor checkRAZDOBLJESESMIJEPREKLAPATI
        {
            [DebuggerNonUserCode]
            get
            {
                return this._checkRAZDOBLJESESMIJEPREKLAPATI;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._checkRAZDOBLJESESMIJEPREKLAPATI = value;
            }
        }

        protected virtual UltraCheckEditor checkZBRAJASATEUFONDSATI
        {
            [DebuggerNonUserCode]
            get
            {
                return this._checkZBRAJASATEUFONDSATI;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._checkZBRAJASATEUFONDSATI = value;
            }
        }

        private ContextMenu contextMenu1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._contextMenu1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._contextMenu1 = value;
            }
        }

        [CreateNew, Browsable(false)]
        public NetAdvantage.Controllers.ELEMENTController ELEMENTController { get; set; }

        private ErrorProvider errorProvider1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._errorProvider1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._errorProvider1 = value;
            }
        }

        private ErrorProviderValidator errorProviderValidator1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._errorProviderValidator1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._errorProviderValidator1 = value;
            }
        }

        protected virtual UltraLabel label1EL
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1EL;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1EL = value;
            }
        }

        protected virtual UltraLabel label1IDELEMENT
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IDELEMENT;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IDELEMENT = value;
            }
        }

        protected virtual UltraLabel label1IDOSNOVAOSIGURANJA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IDOSNOVAOSIGURANJA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IDOSNOVAOSIGURANJA = value;
            }
        }

        protected virtual UltraLabel label1IDVRSTAELEMENTA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IDVRSTAELEMENTA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IDVRSTAELEMENTA = value;
            }
        }

        protected virtual UltraLabel label1MOELEMENT
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1MOELEMENT;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1MOELEMENT = value;
            }
        }

        protected virtual UltraLabel label1MZELEMENT
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1MZELEMENT;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1MZELEMENT = value;
            }
        }

        protected virtual UltraLabel label1NAZIVELEMENT
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1NAZIVELEMENT;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1NAZIVELEMENT = value;
            }
        }

        protected virtual UltraLabel label1NAZIVOSNOVAOSIGURANJA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1NAZIVOSNOVAOSIGURANJA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1NAZIVOSNOVAOSIGURANJA = value;
            }
        }

        protected virtual UltraLabel label1NAZIVVRSTAELEMENT
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1NAZIVVRSTAELEMENT;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1NAZIVVRSTAELEMENT = value;
            }
        }

        protected virtual UltraLabel label1OPISPLACANJAELEMENT
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1OPISPLACANJAELEMENT;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1OPISPLACANJAELEMENT = value;
            }
        }

        protected virtual UltraLabel label1POELEMENT
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1POELEMENT;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1POELEMENT = value;
            }
        }

        protected virtual UltraLabel label1POSTAVLJAMZPZSVIMVIRMANIMA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1POSTAVLJAMZPZSVIMVIRMANIMA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1POSTAVLJAMZPZSVIMVIRMANIMA = value;
            }
        }

        protected virtual UltraLabel lblOznaka
        {
            [DebuggerNonUserCode]
            get
            {
                return this._lblOznaka;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._lblOznaka = value;
            }
        }

        protected virtual UltraLabel label1POSTOTAK
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1POSTOTAK;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1POSTOTAK = value;
            }
        }

        protected virtual UltraLabel label1PZELEMENT
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1PZELEMENT;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1PZELEMENT = value;
            }
        }

        protected virtual UltraLabel label1RAZDOBLJESESMIJEPREKLAPATI
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1RAZDOBLJESESMIJEPREKLAPATI;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1RAZDOBLJESESMIJEPREKLAPATI = value;
            }
        }

        protected virtual UltraLabel label1SIFRAOPISAPLACANJAELEMENT
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1SIFRAOPISAPLACANJAELEMENT;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1SIFRAOPISAPLACANJAELEMENT = value;
            }
        }

        protected virtual UltraLabel label1ZBRAJASATEUFONDSATI
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1ZBRAJASATEUFONDSATI;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1ZBRAJASATEUFONDSATI = value;
            }
        }

        protected virtual UltraLabel labelEL
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelEL;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelEL = value;
            }
        }

        protected virtual UltraLabel labelNAZIVOSNOVAOSIGURANJA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelNAZIVOSNOVAOSIGURANJA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelNAZIVOSNOVAOSIGURANJA = value;
            }
        }

        protected virtual UltraLabel labelNAZIVVRSTAELEMENT
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelNAZIVVRSTAELEMENT;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelNAZIVVRSTAELEMENT = value;
            }
        }

        public DeklaritMode Mode
        {
            get
            {
                return this.m_Mode;
            }
            set
            {
                this.m_Mode = value;
            }
        }

        private MenuItem SetNullItem
        {
            [DebuggerNonUserCode]
            get
            {
                return this._SetNullItem;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._SetNullItem = value;
            }
        }

        protected virtual UltraNumericEditor textIDELEMENT
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textIDELEMENT;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textIDELEMENT = value;
            }
        }

        protected virtual UltraTextEditor textIDOSNOVAOSIGURANJA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textIDOSNOVAOSIGURANJA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textIDOSNOVAOSIGURANJA = value;
            }
        }

        protected virtual UltraNumericEditor textIDVRSTAELEMENTA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textIDVRSTAELEMENTA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textIDVRSTAELEMENTA = value;
            }
        }

        protected virtual UltraTextEditor textMOELEMENT
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textMOELEMENT;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textMOELEMENT = value;
            }
        }

        protected virtual UltraTextEditor textMZELEMENT
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textMZELEMENT;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textMZELEMENT = value;
            }
        }

        protected virtual UltraTextEditor textNAZIVELEMENT
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textNAZIVELEMENT;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textNAZIVELEMENT = value;
            }
        }

        protected virtual UltraTextEditor textOPISPLACANJAELEMENT
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textOPISPLACANJAELEMENT;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textOPISPLACANJAELEMENT = value;
            }
        }

        protected virtual UltraTextEditor textPOELEMENT
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textPOELEMENT;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textPOELEMENT = value;
            }
        }

        protected virtual UltraNumericEditor textPOSTOTAK
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textPOSTOTAK;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textPOSTOTAK = value;
            }
        }

        protected virtual UltraTextEditor textPZELEMENT
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textPZELEMENT;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textPZELEMENT = value;
            }
        }

        protected virtual UltraTextEditor textSIFRAOPISAPLACANJAELEMENT
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textSIFRAOPISAPLACANJAELEMENT;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textSIFRAOPISAPLACANJAELEMENT = value;
            }
        }

        private System.Windows.Forms.ToolTip toolTip1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._toolTip1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._toolTip1 = value;
            }
        }
    }
}


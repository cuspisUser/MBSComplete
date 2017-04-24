namespace NetAdvantage.SmartParts
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.BuilderStrategies;
    using Deklarit.Win;
    using Infragistics.Win;
    using Infragistics.Win.Misc;
    using Infragistics.Win.UltraWinEditors;
    using Infragistics.Win.UltraWinGrid;
    using Microsoft.Practices.CompositeUI;
    using Microsoft.Practices.CompositeUI.SmartParts;
    using Microsoft.Practices.ObjectBuilder;
    using Microsoft.VisualBasic.CompilerServices;
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
    public class UCENIKOBRACUNFormUserControl : UserControl, IBusinessComponentUserControl
    {
        [AccessedThroughProperty("checkAKTIVANZARSM")]
        private UltraCheckEditor _checkAKTIVANZARSM;
        [AccessedThroughProperty("contextMenu1")]
        private ContextMenu _contextMenu1;
        [AccessedThroughProperty("errorProvider1")]
        private ErrorProvider _errorProvider1;
        [AccessedThroughProperty("errorProviderValidator1")]
        private ErrorProviderValidator _errorProviderValidator1;
        [AccessedThroughProperty("grdLevelUCENIKOBRACUNUCENIKOBRACUNDETAIL")]
        private UltraGrid _grdLevelUCENIKOBRACUNUCENIKOBRACUNDETAIL;
        [AccessedThroughProperty("label1AKTIVANZARSM")]
        private UltraLabel _label1AKTIVANZARSM;
        [AccessedThroughProperty("label1OSNOVICAPODANU")]
        private UltraLabel _label1OSNOVICAPODANU;
        [AccessedThroughProperty("label1UCOBRGODINA")]
        private UltraLabel _label1UCOBRGODINA;
        [AccessedThroughProperty("label1UCOBRMJESEC")]
        private UltraLabel _label1UCOBRMJESEC;
        [AccessedThroughProperty("label1UCOBROPIS")]
        private UltraLabel _label1UCOBROPIS;
        [AccessedThroughProperty("SetNullItem")]
        private MenuItem _SetNullItem;
        [AccessedThroughProperty("textOSNOVICAPODANU")]
        private UltraNumericEditor _textOSNOVICAPODANU;
        [AccessedThroughProperty("textUCOBRGODINA")]
        private UltraNumericEditor _textUCOBRGODINA;
        [AccessedThroughProperty("textUCOBRMJESEC")]
        private UltraNumericEditor _textUCOBRMJESEC;
        [AccessedThroughProperty("textUCOBROPIS")]
        private UltraTextEditor _textUCOBROPIS;
        [AccessedThroughProperty("toolTip1")]
        private System.Windows.Forms.ToolTip _toolTip1;
        private BindingSource bindingSourceUCENIKOBRACUN;
        private BindingSource bindingSourceUCENIKOBRACUNUCENIKOBRACUNDETAIL;
        private IContainer components = null;
        private UCENIKOBRACUNDataSet dsUCENIKOBRACUNDataSet1;
        protected TableLayoutPanel layoutManagerformUCENIKOBRACUN;
        private bool m_AutoNumber = false;
        private GenericFormClass m_BaseMethods;
        private UCENIKOBRACUNDataSet.UCENIKOBRACUNRow m_CurrentRow;
        private ArrayList m_DataGrids = new ArrayList();
        private string m_FirstLevelName = "UCENIKOBRACUN";
        private DataRow m_ForeignKeys;
        private string m_FrameworkDescription = StringResources.UCENIKOBRACUNDescription;
        private DeklaritMode m_Mode;

        public UCENIKOBRACUNFormUserControl()
        {
            this.InitializeComponent();
            this.Localize();
            this.SetSize();
        }

        private void CallPromptInLinesUCENIKIDUCENIK(object sender, CellEventArgs e)
        {
            DataRow row3 = ((DataRowView) e.Cell.Row.ListObject).Row;
            DataRow fillByRow = null;
            DataRow row2 = this.UCENIKOBRACUNController.SelectUCENIKIDUCENIK("", fillByRow);
            if (row2 != null)
            {
                try
                {
                    row3["IDUCENIK"] = RuntimeHelpers.GetObjectValue(row2["IDUCENIK"]);
                    row3["PREZIMEUCENIK"] = RuntimeHelpers.GetObjectValue(row2["PREZIMEUCENIK"]);
                    row3["IMEUCENIK"] = RuntimeHelpers.GetObjectValue(row2["IMEUCENIK"]);
                    row3["RAZRED"] = RuntimeHelpers.GetObjectValue(row2["RAZRED"]);
                    row3["ODJELJENJE"] = RuntimeHelpers.GetObjectValue(row2["ODJELJENJE"]);
                }
                catch (ConstraintException exception1)
                {
                    throw exception1;
                    //ConstraintException exception = exception1;
                    //MessageBox.Show(exception.Message, "Data Error");
                }
                e.Cell.Value = RuntimeHelpers.GetObjectValue(((DataRowView) e.Cell.Row.ListObject).Row[e.Cell.Column.Key]);
            }
        }

        private void CellChanged(object sender, EventArgs e)
        {
            this.m_BaseMethods.CellChangedBase(this.dsUCENIKOBRACUNDataSet1, RuntimeHelpers.GetObjectValue(sender));
        }

        public void ChangeBinding()
        {
            this.bindingSourceUCENIKOBRACUN.DataSource = this.UCENIKOBRACUNController.DataSet;
            this.dsUCENIKOBRACUNDataSet1 = this.UCENIKOBRACUNController.DataSet;
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

        private static void CreateValueList(UltraGrid dataGrid1, string valueListName, DataView enumList, string Id, string Name, bool overrideList)
        {
            ValueList myValueList = null;
            if (overrideList && dataGrid1.DisplayLayout.ValueLists.Exists(valueListName))
            {
                myValueList = dataGrid1.DisplayLayout.ValueLists[valueListName];
                myValueList.ValueListItems.Clear();
            }
            if (!dataGrid1.DisplayLayout.ValueLists.Exists(valueListName))
            {
                myValueList = dataGrid1.DisplayLayout.ValueLists.Add(valueListName);
            }
            if (myValueList != null)
            {
                LoadValueList(myValueList, enumList, Id, Name);
            }
        }

        [LocalCommandHandler("DeleteInstance")]
        public void Delete(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                IEnumerator enumerator = null;
                try
                {
                    enumerator = this.dsUCENIKOBRACUNDataSet1.UCENIKOBRACUN.Rows.GetEnumerator();
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
                if (this.UCENIKOBRACUNController.Update(this))
                {
                    this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
                }
            }
        }

        private void dg_ClickCellButton(object sender, CellEventArgs e)
        {
            UltraGridColumn column = e.Cell.Column;
            if ((column.CellActivation == Activation.AllowEdit) && (Conversions.ToString(column.Tag) == "UCENIKIDUCENIK"))
            {
                this.CallPromptInLinesUCENIKIDUCENIK(RuntimeHelpers.GetObjectValue(sender), e);
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

        private void EndEditCurrentRow()
        {
            if (this.grdLevelUCENIKOBRACUNUCENIKOBRACUNDETAIL.ActiveRow != null)
            {
                this.grdLevelUCENIKOBRACUNUCENIKOBRACUNDETAIL.PerformAction(UltraGridAction.NextRow);
            }
        }

        private void grdLevelUCENIKOBRACUNUCENIKOBRACUNDETAIL_AfterRowInsert(object sender, RowEventArgs e)
        {
            //if (this.bindingSourceUCENIKOBRACUN.Current == typeof(DataRowView))
            //{
            //    DataRowView current = (DataRowView) this.bindingSourceUCENIKOBRACUN.Current;
            //    if (current.IsNew)
            //    {
            //        current.Row.SetParentRow(this.m_CurrentRow);
            //    }
            //}
        }

        private void grdLevelUCENIKOBRACUNUCENIKOBRACUNDETAIL_Enter(object sender, EventArgs e)
        {
            GenericFormClass.EndEditBindingSource(this.bindingSourceUCENIKOBRACUN, this.UCENIKOBRACUNController.WorkItem, this);
        }

        public void Initialize(DeklaritMode mode, DataRow foreignKeys, bool isCopy)
        {
            this.ChangeBinding();
            this.m_ForeignKeys = foreignKeys;
            this.RegisterBindingSources();
            this.m_Mode = mode;
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "UCENIKOBRACUN", this.m_Mode, this.dsUCENIKOBRACUNDataSet1, this.dsUCENIKOBRACUNDataSet1.UCENIKOBRACUN.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            Binding binding = new Binding("CheckState", this.bindingSourceUCENIKOBRACUN, "AKTIVANZARSM", true);
            binding.Format += new ConvertEventHandler(this.m_BaseMethods.BooleanFormat);
            binding.Parse += new ConvertEventHandler(this.m_BaseMethods.BooleanParse);
            if (this.checkAKTIVANZARSM.DataBindings["CheckState"] != null)
            {
                this.checkAKTIVANZARSM.DataBindings.Remove(this.checkAKTIVANZARSM.DataBindings["CheckState"]);
            }
            this.checkAKTIVANZARSM.DataBindings.Add(binding);
            if (!this.m_DataGrids.Contains(this.grdLevelUCENIKOBRACUNUCENIKOBRACUNDETAIL))
            {
                this.m_DataGrids.Add(this.grdLevelUCENIKOBRACUNUCENIKOBRACUNDETAIL);
            }
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = this.dsUCENIKOBRACUNDataSet1.UCENIKOBRACUN[0];
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.m_CurrentRow = (UCENIKOBRACUNDataSet.UCENIKOBRACUNRow) ((DataRowView) this.bindingSourceUCENIKOBRACUN.AddNew()).Row;
                foreach (string str in DataSetUtil.CopyForeignKeyValues(this.m_CurrentRow, foreignKeys))
                {
                    this.m_BaseMethods.SetReadOnly(str, true);
                    this.m_BaseMethods.GetLabelControl(str).Visible = false;
                    this.m_BaseMethods.GetControl(str).Visible = false;
                }
            }
            this.SetFocusInFirstField();
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            this.components = new Container();
            ResourceManager manager = new ResourceManager(typeof(UCENIKOBRACUNFormUserControl));
            this.contextMenu1 = new ContextMenu();
            this.SetNullItem = new MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new ErrorProvider();
            this.errorProviderValidator1 = new ErrorProviderValidator(this.components);
            this.bindingSourceUCENIKOBRACUN = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceUCENIKOBRACUN).BeginInit();
            this.bindingSourceUCENIKOBRACUNUCENIKOBRACUNDETAIL = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceUCENIKOBRACUNUCENIKOBRACUNDETAIL).BeginInit();
            this.layoutManagerformUCENIKOBRACUN = new TableLayoutPanel();
            this.layoutManagerformUCENIKOBRACUN.SuspendLayout();
            this.layoutManagerformUCENIKOBRACUN.AutoSize = true;
            this.layoutManagerformUCENIKOBRACUN.Dock = DockStyle.Fill;
            this.layoutManagerformUCENIKOBRACUN.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformUCENIKOBRACUN.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformUCENIKOBRACUN.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformUCENIKOBRACUN.Size = size;
            this.layoutManagerformUCENIKOBRACUN.ColumnCount = 2;
            this.layoutManagerformUCENIKOBRACUN.RowCount = 6;
            this.layoutManagerformUCENIKOBRACUN.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformUCENIKOBRACUN.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformUCENIKOBRACUN.RowStyles.Add(new RowStyle());
            this.layoutManagerformUCENIKOBRACUN.RowStyles.Add(new RowStyle());
            this.layoutManagerformUCENIKOBRACUN.RowStyles.Add(new RowStyle());
            this.layoutManagerformUCENIKOBRACUN.RowStyles.Add(new RowStyle());
            this.layoutManagerformUCENIKOBRACUN.RowStyles.Add(new RowStyle());
            this.layoutManagerformUCENIKOBRACUN.RowStyles.Add(new RowStyle());
            this.label1UCOBRMJESEC = new UltraLabel();
            this.textUCOBRMJESEC = new UltraNumericEditor();
            this.label1UCOBRGODINA = new UltraLabel();
            this.textUCOBRGODINA = new UltraNumericEditor();
            this.label1UCOBROPIS = new UltraLabel();
            this.textUCOBROPIS = new UltraTextEditor();
            this.label1OSNOVICAPODANU = new UltraLabel();
            this.textOSNOVICAPODANU = new UltraNumericEditor();
            this.label1AKTIVANZARSM = new UltraLabel();
            this.checkAKTIVANZARSM = new UltraCheckEditor();
            this.grdLevelUCENIKOBRACUNUCENIKOBRACUNDETAIL = new UltraGrid();
            ((ISupportInitialize) this.textUCOBRMJESEC).BeginInit();
            ((ISupportInitialize) this.textUCOBRGODINA).BeginInit();
            ((ISupportInitialize) this.textUCOBROPIS).BeginInit();
            ((ISupportInitialize) this.textOSNOVICAPODANU).BeginInit();
            ((ISupportInitialize) this.grdLevelUCENIKOBRACUNUCENIKOBRACUNDETAIL).BeginInit();
            UltraGridBand band = new UltraGridBand("UCENIKOBRACUNUCENIKOBRACUNDETAIL", -1);
            UltraGridColumn column9 = new UltraGridColumn("UCOBRMJESEC");
            UltraGridColumn column8 = new UltraGridColumn("UCOBRGODINA");
            UltraGridColumn column2 = new UltraGridColumn("IDUCENIK");
            UltraGridColumn column6 = new UltraGridColumn("PREZIMEUCENIK");
            UltraGridColumn column3 = new UltraGridColumn("IMEUCENIK");
            UltraGridColumn column = new UltraGridColumn("BROJDANAPRAKSE");
            UltraGridColumn column4 = new UltraGridColumn("OBRACUNOSNOVICEPRAKSA");
            UltraGridColumn column7 = new UltraGridColumn("RAZRED");
            UltraGridColumn column5 = new UltraGridColumn("ODJELJENJE");
            this.dsUCENIKOBRACUNDataSet1 = new UCENIKOBRACUNDataSet();
            this.dsUCENIKOBRACUNDataSet1.BeginInit();
            this.SuspendLayout();
            this.dsUCENIKOBRACUNDataSet1.DataSetName = "dsUCENIKOBRACUN";
            this.dsUCENIKOBRACUNDataSet1.Locale = new CultureInfo("hr-HR");
            this.bindingSourceUCENIKOBRACUN.DataSource = this.dsUCENIKOBRACUNDataSet1;
            this.bindingSourceUCENIKOBRACUN.DataMember = "UCENIKOBRACUN";
            ((ISupportInitialize) this.bindingSourceUCENIKOBRACUN).BeginInit();
            this.bindingSourceUCENIKOBRACUNUCENIKOBRACUNDETAIL.DataSource = this.bindingSourceUCENIKOBRACUN;
            this.bindingSourceUCENIKOBRACUNUCENIKOBRACUNDETAIL.DataMember = "UCENIKOBRACUN_UCENIKOBRACUNUCENIKOBRACUNDETAIL";
            point = new System.Drawing.Point(0, 0);
            this.label1UCOBRMJESEC.Location = point;
            this.label1UCOBRMJESEC.Name = "label1UCOBRMJESEC";
            this.label1UCOBRMJESEC.TabIndex = 1;
            this.label1UCOBRMJESEC.Tag = "labelUCOBRMJESEC";
            this.label1UCOBRMJESEC.Text = "Mjesec:";
            this.label1UCOBRMJESEC.StyleSetName = "FieldUltraLabel";
            this.label1UCOBRMJESEC.AutoSize = true;
            this.label1UCOBRMJESEC.Anchor = AnchorStyles.Left;
            this.label1UCOBRMJESEC.Appearance.TextVAlign = VAlign.Middle;
            this.label1UCOBRMJESEC.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1UCOBRMJESEC.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1UCOBRMJESEC.ImageSize = size;
            this.label1UCOBRMJESEC.Appearance.ForeColor = Color.Black;
            this.label1UCOBRMJESEC.BackColor = Color.Transparent;
            this.layoutManagerformUCENIKOBRACUN.Controls.Add(this.label1UCOBRMJESEC, 0, 0);
            this.layoutManagerformUCENIKOBRACUN.SetColumnSpan(this.label1UCOBRMJESEC, 1);
            this.layoutManagerformUCENIKOBRACUN.SetRowSpan(this.label1UCOBRMJESEC, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1UCOBRMJESEC.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1UCOBRMJESEC.MinimumSize = size;
            size = new System.Drawing.Size(0x3b, 0x17);
            this.label1UCOBRMJESEC.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textUCOBRMJESEC.Location = point;
            this.textUCOBRMJESEC.Name = "textUCOBRMJESEC";
            this.textUCOBRMJESEC.Tag = "UCOBRMJESEC";
            this.textUCOBRMJESEC.TabIndex = 0;
            this.textUCOBRMJESEC.Anchor = AnchorStyles.Left;
            this.textUCOBRMJESEC.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textUCOBRMJESEC.ReadOnly = false;
            this.textUCOBRMJESEC.PromptChar = ' ';
            this.textUCOBRMJESEC.Enter += new EventHandler(this.numericEditor_Enter);
            this.textUCOBRMJESEC.DataBindings.Add(new Binding("Value", this.bindingSourceUCENIKOBRACUN, "UCOBRMJESEC"));
            this.textUCOBRMJESEC.NumericType = NumericType.Integer;
            this.textUCOBRMJESEC.MaskInput = "{LOC}-nnnnn";
            this.layoutManagerformUCENIKOBRACUN.Controls.Add(this.textUCOBRMJESEC, 1, 0);
            this.layoutManagerformUCENIKOBRACUN.SetColumnSpan(this.textUCOBRMJESEC, 1);
            this.layoutManagerformUCENIKOBRACUN.SetRowSpan(this.textUCOBRMJESEC, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textUCOBRMJESEC.Margin = padding;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textUCOBRMJESEC.MinimumSize = size;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textUCOBRMJESEC.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1UCOBRGODINA.Location = point;
            this.label1UCOBRGODINA.Name = "label1UCOBRGODINA";
            this.label1UCOBRGODINA.TabIndex = 1;
            this.label1UCOBRGODINA.Tag = "labelUCOBRGODINA";
            this.label1UCOBRGODINA.Text = "Godina:";
            this.label1UCOBRGODINA.StyleSetName = "FieldUltraLabel";
            this.label1UCOBRGODINA.AutoSize = true;
            this.label1UCOBRGODINA.Anchor = AnchorStyles.Left;
            this.label1UCOBRGODINA.Appearance.TextVAlign = VAlign.Middle;
            this.label1UCOBRGODINA.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1UCOBRGODINA.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1UCOBRGODINA.ImageSize = size;
            this.label1UCOBRGODINA.Appearance.ForeColor = Color.Black;
            this.label1UCOBRGODINA.BackColor = Color.Transparent;
            this.layoutManagerformUCENIKOBRACUN.Controls.Add(this.label1UCOBRGODINA, 0, 1);
            this.layoutManagerformUCENIKOBRACUN.SetColumnSpan(this.label1UCOBRGODINA, 1);
            this.layoutManagerformUCENIKOBRACUN.SetRowSpan(this.label1UCOBRGODINA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1UCOBRGODINA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1UCOBRGODINA.MinimumSize = size;
            size = new System.Drawing.Size(60, 0x17);
            this.label1UCOBRGODINA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textUCOBRGODINA.Location = point;
            this.textUCOBRGODINA.Name = "textUCOBRGODINA";
            this.textUCOBRGODINA.Tag = "UCOBRGODINA";
            this.textUCOBRGODINA.TabIndex = 0;
            this.textUCOBRGODINA.Anchor = AnchorStyles.Left;
            this.textUCOBRGODINA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textUCOBRGODINA.ReadOnly = false;
            this.textUCOBRGODINA.PromptChar = ' ';
            this.textUCOBRGODINA.Enter += new EventHandler(this.numericEditor_Enter);
            this.textUCOBRGODINA.DataBindings.Add(new Binding("Value", this.bindingSourceUCENIKOBRACUN, "UCOBRGODINA"));
            this.textUCOBRGODINA.NumericType = NumericType.Integer;
            this.textUCOBRGODINA.MaskInput = "{LOC}-nnnnn";
            this.layoutManagerformUCENIKOBRACUN.Controls.Add(this.textUCOBRGODINA, 1, 1);
            this.layoutManagerformUCENIKOBRACUN.SetColumnSpan(this.textUCOBRGODINA, 1);
            this.layoutManagerformUCENIKOBRACUN.SetRowSpan(this.textUCOBRGODINA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textUCOBRGODINA.Margin = padding;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textUCOBRGODINA.MinimumSize = size;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textUCOBRGODINA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1UCOBROPIS.Location = point;
            this.label1UCOBROPIS.Name = "label1UCOBROPIS";
            this.label1UCOBROPIS.TabIndex = 1;
            this.label1UCOBROPIS.Tag = "labelUCOBROPIS";
            this.label1UCOBROPIS.Text = "Opis obračuna:";
            this.label1UCOBROPIS.StyleSetName = "FieldUltraLabel";
            this.label1UCOBROPIS.AutoSize = true;
            this.label1UCOBROPIS.Anchor = AnchorStyles.Left;
            this.label1UCOBROPIS.Appearance.TextVAlign = VAlign.Middle;
            this.label1UCOBROPIS.Appearance.ForeColor = Color.Black;
            this.label1UCOBROPIS.BackColor = Color.Transparent;
            this.layoutManagerformUCENIKOBRACUN.Controls.Add(this.label1UCOBROPIS, 0, 2);
            this.layoutManagerformUCENIKOBRACUN.SetColumnSpan(this.label1UCOBROPIS, 1);
            this.layoutManagerformUCENIKOBRACUN.SetRowSpan(this.label1UCOBROPIS, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1UCOBROPIS.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1UCOBROPIS.MinimumSize = size;
            size = new System.Drawing.Size(0x6c, 0x17);
            this.label1UCOBROPIS.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textUCOBROPIS.Location = point;
            this.textUCOBROPIS.Name = "textUCOBROPIS";
            this.textUCOBROPIS.Tag = "UCOBROPIS";
            this.textUCOBROPIS.TabIndex = 0;
            this.textUCOBROPIS.Anchor = AnchorStyles.Left;
            this.textUCOBROPIS.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textUCOBROPIS.ReadOnly = false;
            this.textUCOBROPIS.DataBindings.Add(new Binding("Text", this.bindingSourceUCENIKOBRACUN, "UCOBROPIS"));
            this.textUCOBROPIS.MaxLength = 50;
            this.layoutManagerformUCENIKOBRACUN.Controls.Add(this.textUCOBROPIS, 1, 2);
            this.layoutManagerformUCENIKOBRACUN.SetColumnSpan(this.textUCOBROPIS, 1);
            this.layoutManagerformUCENIKOBRACUN.SetRowSpan(this.textUCOBROPIS, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textUCOBROPIS.Margin = padding;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textUCOBROPIS.MinimumSize = size;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textUCOBROPIS.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1OSNOVICAPODANU.Location = point;
            this.label1OSNOVICAPODANU.Name = "label1OSNOVICAPODANU";
            this.label1OSNOVICAPODANU.TabIndex = 1;
            this.label1OSNOVICAPODANU.Tag = "labelOSNOVICAPODANU";
            this.label1OSNOVICAPODANU.Text = "Osnovica po danu za mjesec:";
            this.label1OSNOVICAPODANU.StyleSetName = "FieldUltraLabel";
            this.label1OSNOVICAPODANU.AutoSize = true;
            this.label1OSNOVICAPODANU.Anchor = AnchorStyles.Left;
            this.label1OSNOVICAPODANU.Appearance.TextVAlign = VAlign.Middle;
            this.label1OSNOVICAPODANU.Appearance.ForeColor = Color.Black;
            this.label1OSNOVICAPODANU.BackColor = Color.Transparent;
            this.layoutManagerformUCENIKOBRACUN.Controls.Add(this.label1OSNOVICAPODANU, 0, 3);
            this.layoutManagerformUCENIKOBRACUN.SetColumnSpan(this.label1OSNOVICAPODANU, 1);
            this.layoutManagerformUCENIKOBRACUN.SetRowSpan(this.label1OSNOVICAPODANU, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1OSNOVICAPODANU.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1OSNOVICAPODANU.MinimumSize = size;
            size = new System.Drawing.Size(0xc2, 0x17);
            this.label1OSNOVICAPODANU.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textOSNOVICAPODANU.Location = point;
            this.textOSNOVICAPODANU.Name = "textOSNOVICAPODANU";
            this.textOSNOVICAPODANU.Tag = "OSNOVICAPODANU";
            this.textOSNOVICAPODANU.TabIndex = 0;
            this.textOSNOVICAPODANU.Anchor = AnchorStyles.Left;
            this.textOSNOVICAPODANU.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textOSNOVICAPODANU.ReadOnly = false;
            this.textOSNOVICAPODANU.PromptChar = ' ';
            this.textOSNOVICAPODANU.Enter += new EventHandler(this.numericEditor_Enter);
            this.textOSNOVICAPODANU.DataBindings.Add(new Binding("Value", this.bindingSourceUCENIKOBRACUN, "OSNOVICAPODANU"));
            this.textOSNOVICAPODANU.NumericType = NumericType.Double;
            this.textOSNOVICAPODANU.MaxValue = 79228162514264337593543950335M;
            this.textOSNOVICAPODANU.MinValue = -79228162514264337593543950335M;
            this.textOSNOVICAPODANU.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            this.layoutManagerformUCENIKOBRACUN.Controls.Add(this.textOSNOVICAPODANU, 1, 3);
            this.layoutManagerformUCENIKOBRACUN.SetColumnSpan(this.textOSNOVICAPODANU, 1);
            this.layoutManagerformUCENIKOBRACUN.SetRowSpan(this.textOSNOVICAPODANU, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textOSNOVICAPODANU.Margin = padding;
            size = new System.Drawing.Size(0x66, 0x16);
            this.textOSNOVICAPODANU.MinimumSize = size;
            size = new System.Drawing.Size(0x66, 0x16);
            this.textOSNOVICAPODANU.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1AKTIVANZARSM.Location = point;
            this.label1AKTIVANZARSM.Name = "label1AKTIVANZARSM";
            this.label1AKTIVANZARSM.TabIndex = 1;
            this.label1AKTIVANZARSM.Tag = "labelAKTIVANZARSM";
            this.label1AKTIVANZARSM.Text = "AKTIVANZARSM:";
            this.label1AKTIVANZARSM.StyleSetName = "FieldUltraLabel";
            this.label1AKTIVANZARSM.AutoSize = true;
            this.label1AKTIVANZARSM.Anchor = AnchorStyles.Left;
            this.label1AKTIVANZARSM.Appearance.TextVAlign = VAlign.Middle;
            this.label1AKTIVANZARSM.Appearance.ForeColor = Color.Black;
            this.label1AKTIVANZARSM.BackColor = Color.Transparent;
            this.layoutManagerformUCENIKOBRACUN.Controls.Add(this.label1AKTIVANZARSM, 0, 4);
            this.layoutManagerformUCENIKOBRACUN.SetColumnSpan(this.label1AKTIVANZARSM, 1);
            this.layoutManagerformUCENIKOBRACUN.SetRowSpan(this.label1AKTIVANZARSM, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1AKTIVANZARSM.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1AKTIVANZARSM.MinimumSize = size;
            size = new System.Drawing.Size(120, 0x17);
            this.label1AKTIVANZARSM.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.checkAKTIVANZARSM.Location = point;
            this.checkAKTIVANZARSM.Name = "checkAKTIVANZARSM";
            this.checkAKTIVANZARSM.Tag = "AKTIVANZARSM";
            this.checkAKTIVANZARSM.TabIndex = 0;
            this.checkAKTIVANZARSM.Anchor = AnchorStyles.Left;
            this.checkAKTIVANZARSM.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.checkAKTIVANZARSM.Enabled = true;
            this.layoutManagerformUCENIKOBRACUN.Controls.Add(this.checkAKTIVANZARSM, 1, 4);
            this.layoutManagerformUCENIKOBRACUN.SetColumnSpan(this.checkAKTIVANZARSM, 1);
            this.layoutManagerformUCENIKOBRACUN.SetRowSpan(this.checkAKTIVANZARSM, 1);
            padding = new Padding(0, 1, 3, 2);
            this.checkAKTIVANZARSM.Margin = padding;
            size = new System.Drawing.Size(13, 13);
            this.checkAKTIVANZARSM.MinimumSize = size;
            size = new System.Drawing.Size(13, 13);
            this.checkAKTIVANZARSM.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.grdLevelUCENIKOBRACUNUCENIKOBRACUNDETAIL.Location = point;
            this.grdLevelUCENIKOBRACUNUCENIKOBRACUNDETAIL.Name = "grdLevelUCENIKOBRACUNUCENIKOBRACUNDETAIL";
            this.layoutManagerformUCENIKOBRACUN.Controls.Add(this.grdLevelUCENIKOBRACUNUCENIKOBRACUNDETAIL, 0, 5);
            this.layoutManagerformUCENIKOBRACUN.SetColumnSpan(this.grdLevelUCENIKOBRACUNUCENIKOBRACUNDETAIL, 2);
            this.layoutManagerformUCENIKOBRACUN.SetRowSpan(this.grdLevelUCENIKOBRACUNUCENIKOBRACUNDETAIL, 1);
            padding = new Padding(5, 10, 5, 10);
            this.grdLevelUCENIKOBRACUNUCENIKOBRACUNDETAIL.Margin = padding;
            size = new System.Drawing.Size(100, 100);
            this.grdLevelUCENIKOBRACUNUCENIKOBRACUNDETAIL.MinimumSize = size;
            size = new System.Drawing.Size(750, 200);
            this.grdLevelUCENIKOBRACUNUCENIKOBRACUNDETAIL.Size = size;
            this.grdLevelUCENIKOBRACUNUCENIKOBRACUNDETAIL.Dock = DockStyle.Fill;
            this.Controls.Add(this.layoutManagerformUCENIKOBRACUN);
            this.SetNullItem.Index = 0;
            this.SetNullItem.Text = "Set Null";
            this.SetNullItem.Click += new EventHandler(this.SetNullItem_Click);
            this.contextMenu1.Popup += new EventHandler(this.contextMenu1_Popup);
            this.contextMenu1.MenuItems.AddRange(new MenuItem[] { this.SetNullItem });
            this.errorProvider1.DataSource = this.bindingSourceUCENIKOBRACUN;
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            column9.CellActivation = Activation.Disabled;
            column9.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column9.Header.Caption = StringResources.UCENIKOBRACUNUCOBRMJESECDescription;
            column9.Width = 0x3a;
            appearance9.TextHAlign = HAlign.Right;
            column9.MaskInput = "{LOC}-nnnnn";
            column9.PromptChar = ' ';
            column9.Format = "";
            column9.CellAppearance = appearance9;
            column9.Hidden = true;
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            column8.CellActivation = Activation.Disabled;
            column8.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column8.Header.Caption = StringResources.UCENIKOBRACUNUCOBRGODINADescription;
            column8.Width = 0x3a;
            appearance8.TextHAlign = HAlign.Right;
            column8.MaskInput = "{LOC}-nnnnn";
            column8.PromptChar = ' ';
            column8.Format = "";
            column8.CellAppearance = appearance8;
            column8.Hidden = true;
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.UCENIKOBRACUNIDUCENIKDescription;
            column2.Width = 0x41;
            appearance2.TextHAlign = HAlign.Right;
            column2.MaskInput = "{LOC}-nnnnn";
            column2.PromptChar = ' ';
            column2.Format = "";
            column2.CellAppearance = appearance2;
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            column6.CellActivation = Activation.Disabled;
            column6.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column6.Header.Caption = StringResources.UCENIKOBRACUNPREZIMEUCENIKDescription;
            column6.Width = 0x128;
            column6.Format = "";
            column6.CellAppearance = appearance6;
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            column3.CellActivation = Activation.Disabled;
            column3.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column3.Header.Caption = StringResources.UCENIKOBRACUNIMEUCENIKDescription;
            column3.Width = 0x128;
            column3.Format = "";
            column3.CellAppearance = appearance3;
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.UCENIKOBRACUNBROJDANAPRAKSEDescription;
            column.Width = 0x7e;
            appearance.TextHAlign = HAlign.Right;
            column.MaskInput = "{LOC}-nnnnn";
            column.PromptChar = ' ';
            column.Format = "";
            column.CellAppearance = appearance;
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            column4.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column4.Header.Caption = StringResources.UCENIKOBRACUNOBRACUNOSNOVICEPRAKSADescription;
            column4.Width = 0x123;
            appearance4.TextHAlign = HAlign.Right;
            column4.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column4.PromptChar = ' ';
            column4.Format = "F2";
            column4.CellAppearance = appearance4;
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            column7.CellActivation = Activation.Disabled;
            column7.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column7.Header.Caption = StringResources.UCENIKOBRACUNRAZREDDescription;
            column7.Width = 0x3a;
            appearance7.TextHAlign = HAlign.Right;
            column7.MaskInput = "{LOC}-nnnnn";
            column7.PromptChar = ' ';
            column7.Format = "";
            column7.CellAppearance = appearance7;
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            column5.CellActivation = Activation.Disabled;
            column5.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column5.Header.Caption = StringResources.UCENIKOBRACUNODJELJENJEDescription;
            column5.Width = 0x56;
            column5.Format = "";
            column5.CellAppearance = appearance5;
            band.Columns.Add(column2);
            column2.Header.VisiblePosition = 0;
            band.Columns.Add(column6);
            column6.Header.VisiblePosition = 1;
            band.Columns.Add(column3);
            column3.Header.VisiblePosition = 2;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 3;
            band.Columns.Add(column4);
            column4.Header.VisiblePosition = 4;
            band.Columns.Add(column7);
            column7.Header.VisiblePosition = 5;
            band.Columns.Add(column5);
            column5.Header.VisiblePosition = 6;
            band.Columns.Add(column9);
            column9.Header.VisiblePosition = 7;
            band.Columns.Add(column8);
            column8.Header.VisiblePosition = 8;
            this.grdLevelUCENIKOBRACUNUCENIKOBRACUNDETAIL.Visible = true;
            this.grdLevelUCENIKOBRACUNUCENIKOBRACUNDETAIL.Name = "grdLevelUCENIKOBRACUNUCENIKOBRACUNDETAIL";
            this.grdLevelUCENIKOBRACUNUCENIKOBRACUNDETAIL.Tag = "UCENIKOBRACUNUCENIKOBRACUNDETAIL";
            this.grdLevelUCENIKOBRACUNUCENIKOBRACUNDETAIL.TabIndex = 11;
            this.grdLevelUCENIKOBRACUNUCENIKOBRACUNDETAIL.Dock = DockStyle.Fill;
            this.grdLevelUCENIKOBRACUNUCENIKOBRACUNDETAIL.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.grdLevelUCENIKOBRACUNUCENIKOBRACUNDETAIL.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.grdLevelUCENIKOBRACUNUCENIKOBRACUNDETAIL.DataSource = this.bindingSourceUCENIKOBRACUNUCENIKOBRACUNDETAIL;
            this.grdLevelUCENIKOBRACUNUCENIKOBRACUNDETAIL.Enter += new EventHandler(this.grdLevelUCENIKOBRACUNUCENIKOBRACUNDETAIL_Enter);
            this.grdLevelUCENIKOBRACUNUCENIKOBRACUNDETAIL.AfterRowInsert += new RowEventHandler(this.grdLevelUCENIKOBRACUNUCENIKOBRACUNDETAIL_AfterRowInsert);
            this.grdLevelUCENIKOBRACUNUCENIKOBRACUNDETAIL.AfterCellActivate += new EventHandler(this.CellChanged);
            this.grdLevelUCENIKOBRACUNUCENIKOBRACUNDETAIL.ClickCellButton += new CellEventHandler(this.dg_ClickCellButton);
            this.grdLevelUCENIKOBRACUNUCENIKOBRACUNDETAIL.DisplayLayout.Override.AllowAddNew = AllowAddNew.TemplateOnBottom;
            this.grdLevelUCENIKOBRACUNUCENIKOBRACUNDETAIL.DisplayLayout.BandsSerializer.Add(band);
            this.Name = "UCENIKOBRACUNFormUserControl";
            this.Text = "UCENIKOBRACUN";
            this.AutoSize = true;
            this.AutoScroll = true;
            this.Load += new EventHandler(this.UCENIKOBRACUNFormUserControl_Load);
            this.layoutManagerformUCENIKOBRACUN.ResumeLayout(false);
            this.layoutManagerformUCENIKOBRACUN.PerformLayout();
            ((ISupportInitialize) this.bindingSourceUCENIKOBRACUN).EndInit();
            ((ISupportInitialize) this.bindingSourceUCENIKOBRACUNUCENIKOBRACUNDETAIL).EndInit();
            ((ISupportInitialize) this.textUCOBRMJESEC).EndInit();
            ((ISupportInitialize) this.textUCOBRGODINA).EndInit();
            ((ISupportInitialize) this.textUCOBROPIS).EndInit();
            ((ISupportInitialize) this.textOSNOVICAPODANU).EndInit();
            ((ISupportInitialize) this.grdLevelUCENIKOBRACUNUCENIKOBRACUNDETAIL).EndInit();
            this.dsUCENIKOBRACUNDataSet1.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private bool InValidState()
        {
            if ((this.UCENIKOBRACUNController.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourceUCENIKOBRACUN, this.UCENIKOBRACUNController.WorkItem, this))
            {
                return false;
            }
            this.EndEditCurrentRow();
            if (!this.m_BaseMethods.IsDelete() && this.errorProviderValidator1.HasErrors)
            {
                return false;
            }
            return true;
        }

        private static void LoadValueList(ValueList myValueList, DataView enumList, string Id, string Name)
        {
            IEnumerator enumerator = null;
            try
            {
                enumerator = enumList.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    DataRowView current = (DataRowView) enumerator.Current;
                    DataRow row = current.Row;
                    ValueListItem item = new ValueListItem {
                        DataValue = RuntimeHelpers.GetObjectValue(row[Id]),
                        DisplayText = row[Name].ToString()
                    };
                    myValueList.ValueListItems.Add(item);
                }
            }
            finally
            {
                if (enumerator is IDisposable)
                {
                    (enumerator as IDisposable).Dispose();
                }
            }
            myValueList.Tag = enumList;
        }

        private void Localize()
        {
            this.label1UCOBRMJESEC.Text = StringResources.UCENIKOBRACUNUCOBRMJESECDescription;
            this.label1UCOBRGODINA.Text = StringResources.UCENIKOBRACUNUCOBRGODINADescription;
            this.label1UCOBROPIS.Text = StringResources.UCENIKOBRACUNUCOBROPISDescription;
            this.label1OSNOVICAPODANU.Text = StringResources.UCENIKOBRACUNOSNOVICAPODANUDescription;
            this.label1AKTIVANZARSM.Text = StringResources.UCENIKOBRACUNAKTIVANZARSMDescription;
        }

        private void mouseEnter_Text(object sender, EventArgs e)
        {
            this.m_BaseMethods.MouseEnterTextBase(this.toolTip1, this.m_CurrentRow, RuntimeHelpers.GetObjectValue(sender));
        }

        private void numericEditor_Enter(object sender, EventArgs e)
        {
            ((UltraNumericEditor) sender).SelectAll();
        }

        private void RegisterBindingSources()
        {
            if (!this.UCENIKOBRACUNController.WorkItem.Items.Contains("UCENIKOBRACUN|UCENIKOBRACUN"))
            {
                this.UCENIKOBRACUNController.WorkItem.Items.Add(this.bindingSourceUCENIKOBRACUN, "UCENIKOBRACUN|UCENIKOBRACUN");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        public void ResumeBindingPostUpdate()
        {
            if ((this.dsUCENIKOBRACUNDataSet1.UCENIKOBRACUN.Rows[0] != null) && this.m_BaseMethods.IsInsert())
            {
                this.m_Mode = DeklaritMode.Update;
                this.m_BaseMethods.Mode = this.m_Mode;
                this.m_BaseMethods.FormLoadStyle();
            }
        }

        [LocalCommandHandler("Save")]
        public void Save(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.UCENIKOBRACUNController.Update(this);
            }
        }

        [LocalCommandHandler("SaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (this.InValidState() && this.UCENIKOBRACUNController.Update(this))
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [LocalCommandHandler("SaveAndNew")]
        public void SaveAndNew(object sender, EventArgs e)
        {
            if (this.InValidState() && this.UCENIKOBRACUNController.Update(this))
            {
                this.UCENIKOBRACUNController.DataSet = new UCENIKOBRACUNDataSet();
                DataSetUtil.AddEmptyRow(this.UCENIKOBRACUNController.DataSet);
                this.ChangeBinding();
                this.m_CurrentRow = this.UCENIKOBRACUNController.DataSet.UCENIKOBRACUN[0];
                DataSetUtil.CopyForeignKeyValues(this.m_CurrentRow, this.m_ForeignKeys);
                this.SetFocusInFirstField();
            }
        }

        private void SetComboBoxColumnProperties()
        {
            UltraGridColumn gridColumn = FormHelperClass.GetGridColumn(this.grdLevelUCENIKOBRACUNUCENIKOBRACUNDETAIL, "IDUCENIK");
            gridColumn.Tag = "UCENIKIDUCENIK";
            gridColumn.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.EditButton;
            gridColumn.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
        }

        private void SetFocusInFirstField()
        {
            this.textUCOBRMJESEC.Focus();
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

        private void UCENIKOBRACUNFormUserControl_Load(object sender, EventArgs e)
        {
            this.Text = StringResources.UCENIKOBRACUNDescription;
            this.errorProvider1.ContainerControl = this;
            this.SetComboBoxColumnProperties();
        }

        protected virtual UltraCheckEditor checkAKTIVANZARSM
        {
            [DebuggerNonUserCode]
            get
            {
                return this._checkAKTIVANZARSM;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._checkAKTIVANZARSM = value;
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

        protected virtual UltraGrid grdLevelUCENIKOBRACUNUCENIKOBRACUNDETAIL
        {
            [DebuggerNonUserCode]
            get
            {
                return this._grdLevelUCENIKOBRACUNUCENIKOBRACUNDETAIL;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._grdLevelUCENIKOBRACUNUCENIKOBRACUNDETAIL = value;
            }
        }

        protected virtual UltraLabel label1AKTIVANZARSM
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1AKTIVANZARSM;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1AKTIVANZARSM = value;
            }
        }

        protected virtual UltraLabel label1OSNOVICAPODANU
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1OSNOVICAPODANU;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1OSNOVICAPODANU = value;
            }
        }

        protected virtual UltraLabel label1UCOBRGODINA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1UCOBRGODINA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1UCOBRGODINA = value;
            }
        }

        protected virtual UltraLabel label1UCOBRMJESEC
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1UCOBRMJESEC;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1UCOBRMJESEC = value;
            }
        }

        protected virtual UltraLabel label1UCOBROPIS
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1UCOBROPIS;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1UCOBROPIS = value;
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

        protected virtual UltraNumericEditor textOSNOVICAPODANU
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textOSNOVICAPODANU;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textOSNOVICAPODANU = value;
            }
        }

        protected virtual UltraNumericEditor textUCOBRGODINA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textUCOBRGODINA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textUCOBRGODINA = value;
            }
        }

        protected virtual UltraNumericEditor textUCOBRMJESEC
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textUCOBRMJESEC;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textUCOBRMJESEC = value;
            }
        }

        protected virtual UltraTextEditor textUCOBROPIS
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textUCOBROPIS;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textUCOBROPIS = value;
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

        [Browsable(false), CreateNew]
        public NetAdvantage.Controllers.UCENIKOBRACUNController UCENIKOBRACUNController { get; set; }
    }
}


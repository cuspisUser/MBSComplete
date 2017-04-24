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
    public class DDOBRACUNFormUserControl : UserControl, IBusinessComponentUserControl
    {
        [AccessedThroughProperty("checkDDZAKLJUCAN")]
        private UltraCheckEditor _checkDDZAKLJUCAN;
        [AccessedThroughProperty("contextMenu1")]
        private ContextMenu _contextMenu1;
        [AccessedThroughProperty("datePickerDDDATUMOBRACUNA")]
        private UltraDateTimeEditor _datePickerDDDATUMOBRACUNA;
        [AccessedThroughProperty("errorProvider1")]
        private ErrorProvider _errorProvider1;
        [AccessedThroughProperty("errorProviderValidator1")]
        private ErrorProviderValidator _errorProviderValidator1;
        [AccessedThroughProperty("grdLevelDDOBRACUNRadnici")]
        private UltraGrid _grdLevelDDOBRACUNRadnici;
        [AccessedThroughProperty("label1DDDATUMOBRACUNA")]
        private UltraLabel _label1DDDATUMOBRACUNA;
        [AccessedThroughProperty("label1DDOBRACUNIDOBRACUN")]
        private UltraLabel _label1DDOBRACUNIDOBRACUN;
        [AccessedThroughProperty("label1DDOPISOBRACUN")]
        private UltraLabel _label1DDOPISOBRACUN;
        [AccessedThroughProperty("label1DDRSM")]
        private UltraLabel _label1DDRSM;
        [AccessedThroughProperty("label1DDZAKLJUCAN")]
        private UltraLabel _label1DDZAKLJUCAN;
        [AccessedThroughProperty("SetNullItem")]
        private MenuItem _SetNullItem;
        [AccessedThroughProperty("textDDOBRACUNIDOBRACUN")]
        private UltraTextEditor _textDDOBRACUNIDOBRACUN;
        [AccessedThroughProperty("textDDOPISOBRACUN")]
        private UltraTextEditor _textDDOPISOBRACUN;
        [AccessedThroughProperty("textDDRSM")]
        private UltraTextEditor _textDDRSM;
        [AccessedThroughProperty("toolTip1")]
        private System.Windows.Forms.ToolTip _toolTip1;
        private BindingSource bindingSourceDDOBRACUN;
        private BindingSource bindingSourceDDOBRACUNRadnici;
        private IContainer components = null;
        private DDOBRACUNDataSet dsDDOBRACUNDataSet1;
        protected TableLayoutPanel layoutManagerformDDOBRACUN;
        private bool m_AutoNumber = false;
        private GenericFormClass m_BaseMethods;
        private DDOBRACUNDataSet.DDOBRACUNRow m_CurrentRow;
        private ArrayList m_DataGrids = new ArrayList();
        private string m_FirstLevelName = "DDOBRACUN";
        private DataRow m_ForeignKeys;
        private string m_FrameworkDescription = StringResources.DDOBRACUNDescription;
        private DeklaritMode m_Mode;

        public DDOBRACUNFormUserControl()
        {
            this.InitializeComponent();
            this.Localize();
            this.SetSize();
        }

        private void CallPromptInLinesDDIZDATAKDDIDIZDATAK(object sender, CellEventArgs e)
        {
            DataRow row3 = ((DataRowView) e.Cell.Row.ListObject).Row;
            DataRow fillByRow = null;
            DataRow row2 = this.DDOBRACUNController.SelectDDIZDATAKDDIDIZDATAK("", fillByRow);
            if (row2 != null)
            {
                try
                {
                    row3["DDIDIZDATAK"] = RuntimeHelpers.GetObjectValue(row2["DDIDIZDATAK"]);
                    row3["DDNAZIVIZDATKA"] = RuntimeHelpers.GetObjectValue(row2["DDNAZIVIZDATKA"]);
                    row3["DDPOSTOTAKIZDATKA"] = RuntimeHelpers.GetObjectValue(row2["DDPOSTOTAKIZDATKA"]);
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

        private void CallPromptInLinesDDKATEGORIJAIDKATEGORIJA(object sender, CellEventArgs e)
        {
            DataRow row3 = ((DataRowView) e.Cell.Row.ListObject).Row;
            DataRow fillByRow = null;
            DataRow row2 = this.DDOBRACUNController.SelectDDKATEGORIJAIDKATEGORIJA("", fillByRow);
            if (row2 != null)
            {
                try
                {
                    row3["IDKATEGORIJA"] = RuntimeHelpers.GetObjectValue(row2["IDKATEGORIJA"]);
                    row3["NAZIVKATEGORIJA"] = RuntimeHelpers.GetObjectValue(row2["NAZIVKATEGORIJA"]);
                    row3["IDKOLONAIDD"] = RuntimeHelpers.GetObjectValue(row2["IDKOLONAIDD"]);
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

        private void CallPromptInLinesDDRADNIKDDIDRADNIK(object sender, CellEventArgs e)
        {
            DataRow row3 = ((DataRowView) e.Cell.Row.ListObject).Row;
            DataRow fillByRow = null;
            DataRow row2 = this.DDOBRACUNController.SelectDDRADNIKDDIDRADNIK("", fillByRow);
            if (row2 != null)
            {
                try
                {
                    row3["DDIDRADNIK"] = RuntimeHelpers.GetObjectValue(row2["DDIDRADNIK"]);
                    row3["DDPREZIME"] = RuntimeHelpers.GetObjectValue(row2["DDPREZIME"]);
                    row3["DDIME"] = RuntimeHelpers.GetObjectValue(row2["DDIME"]);
                    row3["OPCINASTANOVANJAIDOPCINE"] = RuntimeHelpers.GetObjectValue(row2["OPCINASTANOVANJAIDOPCINE"]);
                    row3["DDPDVOBVEZNIK"] = RuntimeHelpers.GetObjectValue(row2["DDPDVOBVEZNIK"]);
                    row3["DDDRUGISTUP"] = RuntimeHelpers.GetObjectValue(row2["DDDRUGISTUP"]);
                    row3["DDOIB"] = RuntimeHelpers.GetObjectValue(row2["DDOIB"]);
                    row3["DDZRN"] = RuntimeHelpers.GetObjectValue(row2["DDZRN"]);
                    row3["IDBANKE"] = RuntimeHelpers.GetObjectValue(row2["IDBANKE"]);
                    row3["OPCINARADAIDOPCINE"] = RuntimeHelpers.GetObjectValue(row2["OPCINARADAIDOPCINE"]);
                    row3["NAZIVBANKE1"] = RuntimeHelpers.GetObjectValue(row2["NAZIVBANKE1"]);
                    row3["NAZIVBANKE2"] = RuntimeHelpers.GetObjectValue(row2["NAZIVBANKE2"]);
                    row3["NAZIVBANKE3"] = RuntimeHelpers.GetObjectValue(row2["NAZIVBANKE3"]);
                    row3["VBDIBANKE"] = RuntimeHelpers.GetObjectValue(row2["VBDIBANKE"]);
                    row3["ZRNBANKE"] = RuntimeHelpers.GetObjectValue(row2["ZRNBANKE"]);
                    row3["OPCINARADANAZIVOPCINE"] = RuntimeHelpers.GetObjectValue(row2["OPCINARADANAZIVOPCINE"]);
                    row3["OPCINASTANOVANJANAZIVOPCINE"] = RuntimeHelpers.GetObjectValue(row2["OPCINASTANOVANJANAZIVOPCINE"]);
                    row3["OPCINASTANOVANJAPRIREZ"] = RuntimeHelpers.GetObjectValue(row2["OPCINASTANOVANJAPRIREZ"]);
                    row3["OPCINASTANOVANJAVBDIOPCINA"] = RuntimeHelpers.GetObjectValue(row2["OPCINASTANOVANJAVBDIOPCINA"]);
                    row3["OPCINASTANOVANJAZRNOPCINA"] = RuntimeHelpers.GetObjectValue(row2["OPCINASTANOVANJAZRNOPCINA"]);
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

        private void CallPromptInLinesDDVRSTEPOSLADDIDVRSTAPOSLA(object sender, CellEventArgs e)
        {
            DataRow row3 = ((DataRowView) e.Cell.Row.ListObject).Row;
            DataRow fillByRow = null;
            DataRow row2 = this.DDOBRACUNController.SelectDDVRSTEPOSLADDIDVRSTAPOSLA("", fillByRow);
            if (row2 != null)
            {
                try
                {
                    row3["DDIDVRSTAPOSLA"] = RuntimeHelpers.GetObjectValue(row2["DDIDVRSTAPOSLA"]);
                    row3["DDNAZIVVRSTAPOSLA"] = RuntimeHelpers.GetObjectValue(row2["DDNAZIVVRSTAPOSLA"]);
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

        private void CallPromptInLinesDOPRINOSIDDOPRINOS(object sender, CellEventArgs e)
        {
            DataRow row3 = ((DataRowView) e.Cell.Row.ListObject).Row;
            DataRow fillByRow = null;
            DataRow row2 = this.DDOBRACUNController.SelectDOPRINOSIDDOPRINOS("", fillByRow);
            if (row2 != null)
            {
                try
                {
                    row3["IDDOPRINOS"] = RuntimeHelpers.GetObjectValue(row2["IDDOPRINOS"]);
                    row3["NAZIVDOPRINOS"] = RuntimeHelpers.GetObjectValue(row2["NAZIVDOPRINOS"]);
                    row3["IDVRSTADOPRINOS"] = RuntimeHelpers.GetObjectValue(row2["IDVRSTADOPRINOS"]);
                    row3["MODOPRINOS"] = RuntimeHelpers.GetObjectValue(row2["MODOPRINOS"]);
                    row3["PODOPRINOS"] = RuntimeHelpers.GetObjectValue(row2["PODOPRINOS"]);
                    row3["MZDOPRINOS"] = RuntimeHelpers.GetObjectValue(row2["MZDOPRINOS"]);
                    row3["PZDOPRINOS"] = RuntimeHelpers.GetObjectValue(row2["PZDOPRINOS"]);
                    row3["PRIMATELJDOPRINOS1"] = RuntimeHelpers.GetObjectValue(row2["PRIMATELJDOPRINOS1"]);
                    row3["PRIMATELJDOPRINOS2"] = RuntimeHelpers.GetObjectValue(row2["PRIMATELJDOPRINOS2"]);
                    row3["SIFRAOPISAPLACANJADOPRINOS"] = RuntimeHelpers.GetObjectValue(row2["SIFRAOPISAPLACANJADOPRINOS"]);
                    row3["OPISPLACANJADOPRINOS"] = RuntimeHelpers.GetObjectValue(row2["OPISPLACANJADOPRINOS"]);
                    row3["VBDIDOPRINOS"] = RuntimeHelpers.GetObjectValue(row2["VBDIDOPRINOS"]);
                    row3["ZRNDOPRINOS"] = RuntimeHelpers.GetObjectValue(row2["ZRNDOPRINOS"]);
                    row3["STOPA"] = RuntimeHelpers.GetObjectValue(row2["STOPA"]);
                    row3["NAZIVVRSTADOPRINOS"] = RuntimeHelpers.GetObjectValue(row2["NAZIVVRSTADOPRINOS"]);
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

        private void CallPromptInLinesKRIZNIPOREZIDKRIZNIPOREZ(object sender, CellEventArgs e)
        {
            DataRow row3 = ((DataRowView) e.Cell.Row.ListObject).Row;
            DataRow fillByRow = null;
            DataRow row2 = this.DDOBRACUNController.SelectKRIZNIPOREZIDKRIZNIPOREZ("", fillByRow);
            if (row2 != null)
            {
                try
                {
                    row3["IDKRIZNIPOREZ"] = RuntimeHelpers.GetObjectValue(row2["IDKRIZNIPOREZ"]);
                    row3["NAZIVKRIZNIPOREZ"] = RuntimeHelpers.GetObjectValue(row2["NAZIVKRIZNIPOREZ"]);
                    row3["KRIZNISTOPA"] = RuntimeHelpers.GetObjectValue(row2["KRIZNISTOPA"]);
                    row3["MOKRIZNI"] = RuntimeHelpers.GetObjectValue(row2["MOKRIZNI"]);
                    row3["POKRIZNI"] = RuntimeHelpers.GetObjectValue(row2["POKRIZNI"]);
                    row3["MZKRIZNI"] = RuntimeHelpers.GetObjectValue(row2["MZKRIZNI"]);
                    row3["PZKRIZNI"] = RuntimeHelpers.GetObjectValue(row2["PZKRIZNI"]);
                    row3["PRIMATELJKRIZNI1"] = RuntimeHelpers.GetObjectValue(row2["PRIMATELJKRIZNI1"]);
                    row3["PRIMATELJKRIZNI2"] = RuntimeHelpers.GetObjectValue(row2["PRIMATELJKRIZNI2"]);
                    row3["PRIMATELJKRIZNI3"] = RuntimeHelpers.GetObjectValue(row2["PRIMATELJKRIZNI3"]);
                    row3["SIFRAOPISAPLACANJAKRIZNI"] = RuntimeHelpers.GetObjectValue(row2["SIFRAOPISAPLACANJAKRIZNI"]);
                    row3["OPISPLACANJAKRIZNI"] = RuntimeHelpers.GetObjectValue(row2["OPISPLACANJAKRIZNI"]);
                    row3["VBDIKRIZNI"] = RuntimeHelpers.GetObjectValue(row2["VBDIKRIZNI"]);
                    row3["ZRNKRIZNI"] = RuntimeHelpers.GetObjectValue(row2["ZRNKRIZNI"]);
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

        private void CallPromptInLinesPOREZIDPOREZ(object sender, CellEventArgs e)
        {
            DataRow row3 = ((DataRowView) e.Cell.Row.ListObject).Row;
            DataRow fillByRow = null;
            DataRow row2 = this.DDOBRACUNController.SelectPOREZIDPOREZ("", fillByRow);
            if (row2 != null)
            {
                try
                {
                    row3["IDPOREZ"] = RuntimeHelpers.GetObjectValue(row2["IDPOREZ"]);
                    row3["NAZIVPOREZ"] = RuntimeHelpers.GetObjectValue(row2["NAZIVPOREZ"]);
                    row3["POREZMJESECNO"] = RuntimeHelpers.GetObjectValue(row2["POREZMJESECNO"]);
                    row3["STOPAPOREZA"] = RuntimeHelpers.GetObjectValue(row2["STOPAPOREZA"]);
                    row3["MZPOREZ"] = RuntimeHelpers.GetObjectValue(row2["MZPOREZ"]);
                    row3["PZPOREZ"] = RuntimeHelpers.GetObjectValue(row2["PZPOREZ"]);
                    row3["PRIMATELJPOREZ1"] = RuntimeHelpers.GetObjectValue(row2["PRIMATELJPOREZ1"]);
                    row3["PRIMATELJPOREZ2"] = RuntimeHelpers.GetObjectValue(row2["PRIMATELJPOREZ2"]);
                    row3["SIFRAOPISAPLACANJAPOREZ"] = RuntimeHelpers.GetObjectValue(row2["SIFRAOPISAPLACANJAPOREZ"]);
                    row3["OPISPLACANJAPOREZ"] = RuntimeHelpers.GetObjectValue(row2["OPISPLACANJAPOREZ"]);
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
            this.m_BaseMethods.CellChangedBase(this.dsDDOBRACUNDataSet1, RuntimeHelpers.GetObjectValue(sender));
        }

        public void ChangeBinding()
        {
            this.bindingSourceDDOBRACUN.DataSource = this.DDOBRACUNController.DataSet;
            this.dsDDOBRACUNDataSet1 = this.DDOBRACUNController.DataSet;
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

        private void DDOBRACUNFormUserControl_Load(object sender, EventArgs e)
        {
            this.Text = StringResources.DDOBRACUNDescription;
            this.errorProvider1.ContainerControl = this;
            this.SetComboBoxColumnProperties();
        }

        [LocalCommandHandler("DeleteInstance")]
        public void Delete(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                IEnumerator enumerator = null;
                try
                {
                    enumerator = this.dsDDOBRACUNDataSet1.DDOBRACUN.Rows.GetEnumerator();
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
                if (this.DDOBRACUNController.Update(this))
                {
                    this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
                }
            }
        }

        private void dg_ClickCellButton(object sender, CellEventArgs e)
        {
            UltraGridColumn column = e.Cell.Column;
            if (column.CellActivation == Activation.AllowEdit)
            {
                switch (Conversions.ToString(column.Tag))
                {
                    case "DDRADNIKDDIDRADNIK":
                        this.CallPromptInLinesDDRADNIKDDIDRADNIK(RuntimeHelpers.GetObjectValue(sender), e);
                        break;

                    case "DDKATEGORIJAIDKATEGORIJA":
                        this.CallPromptInLinesDDKATEGORIJAIDKATEGORIJA(RuntimeHelpers.GetObjectValue(sender), e);
                        break;

                    case "DDVRSTEPOSLADDIDVRSTAPOSLA":
                        this.CallPromptInLinesDDVRSTEPOSLADDIDVRSTAPOSLA(RuntimeHelpers.GetObjectValue(sender), e);
                        break;

                    case "DDIZDATAKDDIDIZDATAK":
                        this.CallPromptInLinesDDIZDATAKDDIDIZDATAK(RuntimeHelpers.GetObjectValue(sender), e);
                        break;

                    case "DOPRINOSIDDOPRINOS":
                        this.CallPromptInLinesDOPRINOSIDDOPRINOS(RuntimeHelpers.GetObjectValue(sender), e);
                        break;

                    case "POREZIDPOREZ":
                        this.CallPromptInLinesPOREZIDPOREZ(RuntimeHelpers.GetObjectValue(sender), e);
                        break;

                    case "KRIZNIPOREZIDKRIZNIPOREZ":
                        this.CallPromptInLinesKRIZNIPOREZIDKRIZNIPOREZ(RuntimeHelpers.GetObjectValue(sender), e);
                        break;
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

        private void EndEditCurrentRow()
        {
            if (this.grdLevelDDOBRACUNRadnici.ActiveRow != null)
            {
                this.grdLevelDDOBRACUNRadnici.PerformAction(UltraGridAction.NextRow);
            }
        }

        private void grdLevelDDOBRACUNRadnici_AfterRowInsert(object sender, RowEventArgs e)
        {
            //if (this.bindingSourceDDOBRACUN.Current == typeof(DataRowView))
            //{
            //    DataRowView current = (DataRowView) this.bindingSourceDDOBRACUN.Current;
            //    if (current.IsNew)
            //    {
            //        current.Row.SetParentRow(this.m_CurrentRow);
            //    }
            //}
        }

        private void grdLevelDDOBRACUNRadnici_Enter(object sender, EventArgs e)
        {
            GenericFormClass.EndEditBindingSource(this.bindingSourceDDOBRACUN, this.DDOBRACUNController.WorkItem, this);
        }

        public void Initialize(DeklaritMode mode, DataRow foreignKeys, bool isCopy)
        {
            this.ChangeBinding();
            this.m_ForeignKeys = foreignKeys;
            this.RegisterBindingSources();
            this.m_Mode = mode;
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "DDOBRACUN", this.m_Mode, this.dsDDOBRACUNDataSet1, this.dsDDOBRACUNDataSet1.DDOBRACUN.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            Binding binding = new Binding("Text", this.bindingSourceDDOBRACUN, "DDDATUMOBRACUNA", true);
            binding.Format += new ConvertEventHandler(this.m_BaseMethods.DateFormat);
            binding.Parse += new ConvertEventHandler(this.m_BaseMethods.DateParseNotNull);
            if (this.datePickerDDDATUMOBRACUNA.DataBindings["Text"] != null)
            {
                this.datePickerDDDATUMOBRACUNA.DataBindings.Remove(this.datePickerDDDATUMOBRACUNA.DataBindings["Text"]);
            }
            this.datePickerDDDATUMOBRACUNA.DataBindings.Add(binding);
            Binding binding2 = new Binding("CheckState", this.bindingSourceDDOBRACUN, "DDZAKLJUCAN", true);
            binding2.Format += new ConvertEventHandler(this.m_BaseMethods.BooleanFormat);
            binding2.Parse += new ConvertEventHandler(this.m_BaseMethods.BooleanParse);
            if (this.checkDDZAKLJUCAN.DataBindings["CheckState"] != null)
            {
                this.checkDDZAKLJUCAN.DataBindings.Remove(this.checkDDZAKLJUCAN.DataBindings["CheckState"]);
            }
            this.checkDDZAKLJUCAN.DataBindings.Add(binding2);
            if (!this.m_DataGrids.Contains(this.grdLevelDDOBRACUNRadnici))
            {
                this.m_DataGrids.Add(this.grdLevelDDOBRACUNRadnici);
            }
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = this.dsDDOBRACUNDataSet1.DDOBRACUN[0];
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.m_CurrentRow = (DDOBRACUNDataSet.DDOBRACUNRow) ((DataRowView) this.bindingSourceDDOBRACUN.AddNew()).Row;
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
            ResourceManager manager = new ResourceManager(typeof(DDOBRACUNFormUserControl));
            this.contextMenu1 = new ContextMenu();
            this.SetNullItem = new MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new ErrorProvider();
            this.errorProviderValidator1 = new ErrorProviderValidator(this.components);
            this.bindingSourceDDOBRACUN = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceDDOBRACUN).BeginInit();
            this.bindingSourceDDOBRACUNRadnici = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceDDOBRACUNRadnici).BeginInit();
            this.layoutManagerformDDOBRACUN = new TableLayoutPanel();
            this.layoutManagerformDDOBRACUN.SuspendLayout();
            this.layoutManagerformDDOBRACUN.AutoSize = true;
            this.layoutManagerformDDOBRACUN.Dock = DockStyle.Fill;
            this.layoutManagerformDDOBRACUN.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformDDOBRACUN.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformDDOBRACUN.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformDDOBRACUN.Size = size;
            this.layoutManagerformDDOBRACUN.ColumnCount = 2;
            this.layoutManagerformDDOBRACUN.RowCount = 6;
            this.layoutManagerformDDOBRACUN.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformDDOBRACUN.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformDDOBRACUN.RowStyles.Add(new RowStyle());
            this.layoutManagerformDDOBRACUN.RowStyles.Add(new RowStyle());
            this.layoutManagerformDDOBRACUN.RowStyles.Add(new RowStyle());
            this.layoutManagerformDDOBRACUN.RowStyles.Add(new RowStyle());
            this.layoutManagerformDDOBRACUN.RowStyles.Add(new RowStyle());
            this.layoutManagerformDDOBRACUN.RowStyles.Add(new RowStyle());
            this.label1DDOBRACUNIDOBRACUN = new UltraLabel();
            this.textDDOBRACUNIDOBRACUN = new UltraTextEditor();
            this.label1DDOPISOBRACUN = new UltraLabel();
            this.textDDOPISOBRACUN = new UltraTextEditor();
            this.label1DDDATUMOBRACUNA = new UltraLabel();
            this.datePickerDDDATUMOBRACUNA = new UltraDateTimeEditor();
            this.label1DDZAKLJUCAN = new UltraLabel();
            this.checkDDZAKLJUCAN = new UltraCheckEditor();
            this.label1DDRSM = new UltraLabel();
            this.textDDRSM = new UltraTextEditor();
            this.grdLevelDDOBRACUNRadnici = new UltraGrid();
            ((ISupportInitialize) this.textDDOBRACUNIDOBRACUN).BeginInit();
            ((ISupportInitialize) this.textDDOPISOBRACUN).BeginInit();
            ((ISupportInitialize) this.textDDRSM).BeginInit();
            ((ISupportInitialize) this.grdLevelDDOBRACUNRadnici).BeginInit();
            UltraGridBand band = new UltraGridBand("DDOBRACUNRadnici", -1);
            UltraGridColumn column28 = new UltraGridColumn("DDOBRACUNIDOBRACUN");
            UltraGridColumn column2 = new UltraGridColumn("DDIDRADNIK");
            UltraGridColumn column31 = new UltraGridColumn("DDPREZIME");
            UltraGridColumn column3 = new UltraGridColumn("DDIME");
            UltraGridColumn column54 = new UltraGridColumn("IDKATEGORIJA");
            UltraGridColumn column65 = new UltraGridColumn("NAZIVKATEGORIJA");
            UltraGridColumn column27 = new UltraGridColumn("DDOBRACUNATIPRIREZ");
            UltraGridColumn column26 = new UltraGridColumn("DDOBRACUNATIPDV");
            UltraGridColumn column66 = new UltraGridColumn("OPCINARADAIDOPCINE");
            UltraGridColumn column67 = new UltraGridColumn("OPCINARADANAZIVOPCINE");
            UltraGridColumn column68 = new UltraGridColumn("OPCINASTANOVANJAIDOPCINE");
            UltraGridColumn column69 = new UltraGridColumn("OPCINASTANOVANJANAZIVOPCINE");
            UltraGridColumn column70 = new UltraGridColumn("OPCINASTANOVANJAPRIREZ");
            UltraGridColumn column71 = new UltraGridColumn("OPCINASTANOVANJAVBDIOPCINA");
            UltraGridColumn column72 = new UltraGridColumn("OPCINASTANOVANJAZRNOPCINA");
            UltraGridColumn column53 = new UltraGridColumn("IDBANKE");
            UltraGridColumn column62 = new UltraGridColumn("NAZIVBANKE1");
            UltraGridColumn column63 = new UltraGridColumn("NAZIVBANKE2");
            UltraGridColumn column64 = new UltraGridColumn("NAZIVBANKE3");
            UltraGridColumn column89 = new UltraGridColumn("VBDIBANKE");
            UltraGridColumn column97 = new UltraGridColumn("ZRNBANKE");
            UltraGridColumn column30 = new UltraGridColumn("DDPDVOBVEZNIK");
            UltraGridColumn column = new UltraGridColumn("DDDRUGISTUP");
            UltraGridColumn column32 = new UltraGridColumn("DDSIFRAOPCINESTANOVANJA");
            UltraGridColumn column55 = new UltraGridColumn("IDKOLONAIDD");
            UltraGridColumn column29 = new UltraGridColumn("DDOIB");
            UltraGridColumn column33 = new UltraGridColumn("DDZRN");
            UltraGridBand band6 = new UltraGridBand("DDOBRACUNRadnici_DDOBRACUNRadniciVrstePosla", 0);
            UltraGridColumn column94 = new UltraGridColumn("DDOBRACUNIDOBRACUN");
            UltraGridColumn column90 = new UltraGridColumn("DDIDRADNIK");
            UltraGridColumn column91 = new UltraGridColumn("DDIDVRSTAPOSLA");
            UltraGridColumn column93 = new UltraGridColumn("DDNAZIVVRSTAPOSLA");
            UltraGridColumn column95 = new UltraGridColumn("DDSATI");
            UltraGridColumn column96 = new UltraGridColumn("DDSATNICA");
            UltraGridColumn column92 = new UltraGridColumn("DDIZNOS");
            UltraGridBand band4 = new UltraGridBand("DDOBRACUNRadnici_DDOBRACUNRadniciIzdaci", 0);
            UltraGridColumn column60 = new UltraGridColumn("DDOBRACUNIDOBRACUN");
            UltraGridColumn column57 = new UltraGridColumn("DDIDRADNIK");
            UltraGridColumn column56 = new UltraGridColumn("DDIDIZDATAK");
            UltraGridColumn column58 = new UltraGridColumn("DDNAZIVIZDATKA");
            UltraGridColumn column61 = new UltraGridColumn("DDPOSTOTAKIZDATKA");
            UltraGridColumn column59 = new UltraGridColumn("DDOBRACUNATIIZDATAK");
            UltraGridBand band3 = new UltraGridBand("DDOBRACUNRadnici_DDOBRACUNRadniciDoprinosi", 0);
            UltraGridColumn column36 = new UltraGridColumn("DDOBRACUNIDOBRACUN");
            UltraGridColumn column34 = new UltraGridColumn("DDIDRADNIK");
            UltraGridColumn column38 = new UltraGridColumn("IDDOPRINOS");
            UltraGridColumn column42 = new UltraGridColumn("NAZIVDOPRINOS");
            UltraGridColumn column39 = new UltraGridColumn("IDVRSTADOPRINOS");
            UltraGridColumn column43 = new UltraGridColumn("NAZIVVRSTADOPRINOS");
            UltraGridColumn column40 = new UltraGridColumn("MODOPRINOS");
            UltraGridColumn column45 = new UltraGridColumn("PODOPRINOS");
            UltraGridColumn column41 = new UltraGridColumn("MZDOPRINOS");
            UltraGridColumn column48 = new UltraGridColumn("PZDOPRINOS");
            UltraGridColumn column46 = new UltraGridColumn("PRIMATELJDOPRINOS1");
            UltraGridColumn column47 = new UltraGridColumn("PRIMATELJDOPRINOS2");
            UltraGridColumn column49 = new UltraGridColumn("SIFRAOPISAPLACANJADOPRINOS");
            UltraGridColumn column44 = new UltraGridColumn("OPISPLACANJADOPRINOS");
            UltraGridColumn column51 = new UltraGridColumn("VBDIDOPRINOS");
            UltraGridColumn column52 = new UltraGridColumn("ZRNDOPRINOS");
            UltraGridColumn column50 = new UltraGridColumn("STOPA");
            UltraGridColumn column35 = new UltraGridColumn("DDOBRACUNATIDOPRINOS");
            UltraGridColumn column37 = new UltraGridColumn("DDOSNOVICADOPRINOS");
            UltraGridBand band5 = new UltraGridBand("DDOBRACUNRadnici_DDOBRACUNRadniciPorezi", 0);
            UltraGridColumn column76 = new UltraGridColumn("DDOBRACUNIDOBRACUN");
            UltraGridColumn column73 = new UltraGridColumn("DDIDRADNIK");
            UltraGridColumn column79 = new UltraGridColumn("IDPOREZ");
            UltraGridColumn column81 = new UltraGridColumn("NAZIVPOREZ");
            UltraGridColumn column83 = new UltraGridColumn("POREZMJESECNO");
            UltraGridColumn column88 = new UltraGridColumn("STOPAPOREZA");
            UltraGridColumn column78 = new UltraGridColumn("DDPOPOREZ");
            UltraGridColumn column74 = new UltraGridColumn("DDMOPOREZ");
            UltraGridColumn column80 = new UltraGridColumn("MZPOREZ");
            UltraGridColumn column86 = new UltraGridColumn("PZPOREZ");
            UltraGridColumn column84 = new UltraGridColumn("PRIMATELJPOREZ1");
            UltraGridColumn column85 = new UltraGridColumn("PRIMATELJPOREZ2");
            UltraGridColumn column87 = new UltraGridColumn("SIFRAOPISAPLACANJAPOREZ");
            UltraGridColumn column82 = new UltraGridColumn("OPISPLACANJAPOREZ");
            UltraGridColumn column75 = new UltraGridColumn("DDOBRACUNATIPOREZ");
            UltraGridColumn column77 = new UltraGridColumn("DDOSNOVICAPOREZ");
            UltraGridBand band2 = new UltraGridBand("DDOBRACUNRadnici_DDOBRACUNRadniciDDKrizniPorez", 0);
            UltraGridColumn column5 = new UltraGridColumn("DDOBRACUNIDOBRACUN");
            UltraGridColumn column4 = new UltraGridColumn("DDIDRADNIK");
            UltraGridColumn column12 = new UltraGridColumn("IDKRIZNIPOREZ");
            UltraGridColumn column16 = new UltraGridColumn("NAZIVKRIZNIPOREZ");
            UltraGridColumn column13 = new UltraGridColumn("KRIZNISTOPA");
            UltraGridColumn column14 = new UltraGridColumn("MOKRIZNI");
            UltraGridColumn column18 = new UltraGridColumn("POKRIZNI");
            UltraGridColumn column15 = new UltraGridColumn("MZKRIZNI");
            UltraGridColumn column22 = new UltraGridColumn("PZKRIZNI");
            UltraGridColumn column19 = new UltraGridColumn("PRIMATELJKRIZNI1");
            UltraGridColumn column20 = new UltraGridColumn("PRIMATELJKRIZNI2");
            UltraGridColumn column21 = new UltraGridColumn("PRIMATELJKRIZNI3");
            UltraGridColumn column23 = new UltraGridColumn("SIFRAOPISAPLACANJAKRIZNI");
            UltraGridColumn column17 = new UltraGridColumn("OPISPLACANJAKRIZNI");
            UltraGridColumn column24 = new UltraGridColumn("VBDIKRIZNI");
            UltraGridColumn column25 = new UltraGridColumn("ZRNKRIZNI");
            UltraGridColumn column6 = new UltraGridColumn("DDOSNOVICAKRIZNI");
            UltraGridColumn column9 = new UltraGridColumn("DDPOREZKRIZNI");
            UltraGridColumn column7 = new UltraGridColumn("DDOSNOVICAPRETHODNA");
            UltraGridColumn column8 = new UltraGridColumn("DDOSNOVICAUKUPNA");
            UltraGridColumn column10 = new UltraGridColumn("DDPOREZPRETHODNI");
            UltraGridColumn column11 = new UltraGridColumn("DDPOREZUKUPNO");
            this.dsDDOBRACUNDataSet1 = new DDOBRACUNDataSet();
            this.dsDDOBRACUNDataSet1.BeginInit();
            this.SuspendLayout();
            this.dsDDOBRACUNDataSet1.DataSetName = "dsDDOBRACUN";
            this.dsDDOBRACUNDataSet1.Locale = new CultureInfo("hr-HR");
            this.bindingSourceDDOBRACUN.DataSource = this.dsDDOBRACUNDataSet1;
            this.bindingSourceDDOBRACUN.DataMember = "DDOBRACUN";
            ((ISupportInitialize) this.bindingSourceDDOBRACUN).BeginInit();
            this.bindingSourceDDOBRACUNRadnici.DataSource = this.bindingSourceDDOBRACUN;
            this.bindingSourceDDOBRACUNRadnici.DataMember = "DDOBRACUN_DDOBRACUNRadnici";
            point = new System.Drawing.Point(0, 0);
            this.label1DDOBRACUNIDOBRACUN.Location = point;
            this.label1DDOBRACUNIDOBRACUN.Name = "label1DDOBRACUNIDOBRACUN";
            this.label1DDOBRACUNIDOBRACUN.TabIndex = 1;
            this.label1DDOBRACUNIDOBRACUN.Tag = "labelDDOBRACUNIDOBRACUN";
            this.label1DDOBRACUNIDOBRACUN.Text = "Šifra obračuna:";
            this.label1DDOBRACUNIDOBRACUN.StyleSetName = "FieldUltraLabel";
            this.label1DDOBRACUNIDOBRACUN.AutoSize = true;
            this.label1DDOBRACUNIDOBRACUN.Anchor = AnchorStyles.Left;
            this.label1DDOBRACUNIDOBRACUN.Appearance.TextVAlign = VAlign.Middle;
            this.label1DDOBRACUNIDOBRACUN.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1DDOBRACUNIDOBRACUN.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1DDOBRACUNIDOBRACUN.ImageSize = size;
            this.label1DDOBRACUNIDOBRACUN.Appearance.ForeColor = Color.Black;
            this.label1DDOBRACUNIDOBRACUN.BackColor = Color.Transparent;
            this.layoutManagerformDDOBRACUN.Controls.Add(this.label1DDOBRACUNIDOBRACUN, 0, 0);
            this.layoutManagerformDDOBRACUN.SetColumnSpan(this.label1DDOBRACUNIDOBRACUN, 1);
            this.layoutManagerformDDOBRACUN.SetRowSpan(this.label1DDOBRACUNIDOBRACUN, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1DDOBRACUNIDOBRACUN.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1DDOBRACUNIDOBRACUN.MinimumSize = size;
            size = new System.Drawing.Size(0x6b, 0x17);
            this.label1DDOBRACUNIDOBRACUN.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textDDOBRACUNIDOBRACUN.Location = point;
            this.textDDOBRACUNIDOBRACUN.Name = "textDDOBRACUNIDOBRACUN";
            this.textDDOBRACUNIDOBRACUN.Tag = "DDOBRACUNIDOBRACUN";
            this.textDDOBRACUNIDOBRACUN.TabIndex = 0;
            this.textDDOBRACUNIDOBRACUN.Anchor = AnchorStyles.Left;
            this.textDDOBRACUNIDOBRACUN.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textDDOBRACUNIDOBRACUN.ReadOnly = false;
            this.textDDOBRACUNIDOBRACUN.DataBindings.Add(new Binding("Text", this.bindingSourceDDOBRACUN, "DDOBRACUNIDOBRACUN"));
            this.textDDOBRACUNIDOBRACUN.MaxLength = 11;
            this.layoutManagerformDDOBRACUN.Controls.Add(this.textDDOBRACUNIDOBRACUN, 1, 0);
            this.layoutManagerformDDOBRACUN.SetColumnSpan(this.textDDOBRACUNIDOBRACUN, 1);
            this.layoutManagerformDDOBRACUN.SetRowSpan(this.textDDOBRACUNIDOBRACUN, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textDDOBRACUNIDOBRACUN.Margin = padding;
            size = new System.Drawing.Size(0x5d, 0x16);
            this.textDDOBRACUNIDOBRACUN.MinimumSize = size;
            size = new System.Drawing.Size(0x5d, 0x16);
            this.textDDOBRACUNIDOBRACUN.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1DDOPISOBRACUN.Location = point;
            this.label1DDOPISOBRACUN.Name = "label1DDOPISOBRACUN";
            this.label1DDOPISOBRACUN.TabIndex = 1;
            this.label1DDOPISOBRACUN.Tag = "labelDDOPISOBRACUN";
            this.label1DDOPISOBRACUN.Text = "Opis:";
            this.label1DDOPISOBRACUN.StyleSetName = "FieldUltraLabel";
            this.label1DDOPISOBRACUN.AutoSize = true;
            this.label1DDOPISOBRACUN.Anchor = AnchorStyles.Left;
            this.label1DDOPISOBRACUN.Appearance.TextVAlign = VAlign.Middle;
            this.label1DDOPISOBRACUN.Appearance.ForeColor = Color.Black;
            this.label1DDOPISOBRACUN.BackColor = Color.Transparent;
            this.layoutManagerformDDOBRACUN.Controls.Add(this.label1DDOPISOBRACUN, 0, 1);
            this.layoutManagerformDDOBRACUN.SetColumnSpan(this.label1DDOPISOBRACUN, 1);
            this.layoutManagerformDDOBRACUN.SetRowSpan(this.label1DDOPISOBRACUN, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1DDOPISOBRACUN.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1DDOPISOBRACUN.MinimumSize = size;
            size = new System.Drawing.Size(0x2e, 0x17);
            this.label1DDOPISOBRACUN.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textDDOPISOBRACUN.Location = point;
            this.textDDOPISOBRACUN.Name = "textDDOPISOBRACUN";
            this.textDDOPISOBRACUN.Tag = "DDOPISOBRACUN";
            this.textDDOPISOBRACUN.TabIndex = 0;
            this.textDDOPISOBRACUN.Anchor = AnchorStyles.Left;
            this.textDDOPISOBRACUN.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textDDOPISOBRACUN.ReadOnly = false;
            this.textDDOPISOBRACUN.DataBindings.Add(new Binding("Text", this.bindingSourceDDOBRACUN, "DDOPISOBRACUN"));
            this.textDDOPISOBRACUN.MaxLength = 50;
            this.layoutManagerformDDOBRACUN.Controls.Add(this.textDDOPISOBRACUN, 1, 1);
            this.layoutManagerformDDOBRACUN.SetColumnSpan(this.textDDOPISOBRACUN, 1);
            this.layoutManagerformDDOBRACUN.SetRowSpan(this.textDDOPISOBRACUN, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textDDOPISOBRACUN.Margin = padding;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textDDOPISOBRACUN.MinimumSize = size;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textDDOPISOBRACUN.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1DDDATUMOBRACUNA.Location = point;
            this.label1DDDATUMOBRACUNA.Name = "label1DDDATUMOBRACUNA";
            this.label1DDDATUMOBRACUNA.TabIndex = 1;
            this.label1DDDATUMOBRACUNA.Tag = "labelDDDATUMOBRACUNA";
            this.label1DDDATUMOBRACUNA.Text = "Datum obračuna:";
            this.label1DDDATUMOBRACUNA.StyleSetName = "FieldUltraLabel";
            this.label1DDDATUMOBRACUNA.AutoSize = true;
            this.label1DDDATUMOBRACUNA.Anchor = AnchorStyles.Left;
            this.label1DDDATUMOBRACUNA.Appearance.TextVAlign = VAlign.Middle;
            this.label1DDDATUMOBRACUNA.Appearance.ForeColor = Color.Black;
            this.label1DDDATUMOBRACUNA.BackColor = Color.Transparent;
            this.layoutManagerformDDOBRACUN.Controls.Add(this.label1DDDATUMOBRACUNA, 0, 2);
            this.layoutManagerformDDOBRACUN.SetColumnSpan(this.label1DDDATUMOBRACUNA, 1);
            this.layoutManagerformDDOBRACUN.SetRowSpan(this.label1DDDATUMOBRACUNA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1DDDATUMOBRACUNA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1DDDATUMOBRACUNA.MinimumSize = size;
            size = new System.Drawing.Size(0x7a, 0x17);
            this.label1DDDATUMOBRACUNA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.datePickerDDDATUMOBRACUNA.Location = point;
            this.datePickerDDDATUMOBRACUNA.Name = "datePickerDDDATUMOBRACUNA";
            this.datePickerDDDATUMOBRACUNA.Tag = "DDDATUMOBRACUNA";
            this.datePickerDDDATUMOBRACUNA.TabIndex = 0;
            this.datePickerDDDATUMOBRACUNA.Anchor = AnchorStyles.Left;
            this.datePickerDDDATUMOBRACUNA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.datePickerDDDATUMOBRACUNA.Enabled = true;
            this.layoutManagerformDDOBRACUN.Controls.Add(this.datePickerDDDATUMOBRACUNA, 1, 2);
            this.layoutManagerformDDOBRACUN.SetColumnSpan(this.datePickerDDDATUMOBRACUNA, 1);
            this.layoutManagerformDDOBRACUN.SetRowSpan(this.datePickerDDDATUMOBRACUNA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.datePickerDDDATUMOBRACUNA.Margin = padding;
            size = new System.Drawing.Size(100, 0x16);
            this.datePickerDDDATUMOBRACUNA.MinimumSize = size;
            size = new System.Drawing.Size(100, 0x16);
            this.datePickerDDDATUMOBRACUNA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1DDZAKLJUCAN.Location = point;
            this.label1DDZAKLJUCAN.Name = "label1DDZAKLJUCAN";
            this.label1DDZAKLJUCAN.TabIndex = 1;
            this.label1DDZAKLJUCAN.Tag = "labelDDZAKLJUCAN";
            this.label1DDZAKLJUCAN.Text = "DDZAKLJUCAN:";
            this.label1DDZAKLJUCAN.StyleSetName = "FieldUltraLabel";
            this.label1DDZAKLJUCAN.AutoSize = true;
            this.label1DDZAKLJUCAN.Anchor = AnchorStyles.Left;
            this.label1DDZAKLJUCAN.Appearance.TextVAlign = VAlign.Middle;
            this.label1DDZAKLJUCAN.Appearance.ForeColor = Color.Black;
            this.label1DDZAKLJUCAN.BackColor = Color.Transparent;
            this.layoutManagerformDDOBRACUN.Controls.Add(this.label1DDZAKLJUCAN, 0, 3);
            this.layoutManagerformDDOBRACUN.SetColumnSpan(this.label1DDZAKLJUCAN, 1);
            this.layoutManagerformDDOBRACUN.SetRowSpan(this.label1DDZAKLJUCAN, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1DDZAKLJUCAN.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1DDZAKLJUCAN.MinimumSize = size;
            size = new System.Drawing.Size(0x6f, 0x17);
            this.label1DDZAKLJUCAN.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.checkDDZAKLJUCAN.Location = point;
            this.checkDDZAKLJUCAN.Name = "checkDDZAKLJUCAN";
            this.checkDDZAKLJUCAN.Tag = "DDZAKLJUCAN";
            this.checkDDZAKLJUCAN.TabIndex = 0;
            this.checkDDZAKLJUCAN.Anchor = AnchorStyles.Left;
            this.checkDDZAKLJUCAN.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.checkDDZAKLJUCAN.Enabled = true;
            this.layoutManagerformDDOBRACUN.Controls.Add(this.checkDDZAKLJUCAN, 1, 3);
            this.layoutManagerformDDOBRACUN.SetColumnSpan(this.checkDDZAKLJUCAN, 1);
            this.layoutManagerformDDOBRACUN.SetRowSpan(this.checkDDZAKLJUCAN, 1);
            padding = new Padding(0, 1, 3, 2);
            this.checkDDZAKLJUCAN.Margin = padding;
            size = new System.Drawing.Size(13, 13);
            this.checkDDZAKLJUCAN.MinimumSize = size;
            size = new System.Drawing.Size(13, 13);
            this.checkDDZAKLJUCAN.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1DDRSM.Location = point;
            this.label1DDRSM.Name = "label1DDRSM";
            this.label1DDRSM.TabIndex = 1;
            this.label1DDRSM.Tag = "labelDDRSM";
            this.label1DDRSM.Text = "DDRSM:";
            this.label1DDRSM.StyleSetName = "FieldUltraLabel";
            this.label1DDRSM.AutoSize = true;
            this.label1DDRSM.Anchor = AnchorStyles.Left;
            this.label1DDRSM.Appearance.TextVAlign = VAlign.Middle;
            this.label1DDRSM.Appearance.ForeColor = Color.Black;
            this.label1DDRSM.BackColor = Color.Transparent;
            this.layoutManagerformDDOBRACUN.Controls.Add(this.label1DDRSM, 0, 4);
            this.layoutManagerformDDOBRACUN.SetColumnSpan(this.label1DDRSM, 1);
            this.layoutManagerformDDOBRACUN.SetRowSpan(this.label1DDRSM, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1DDRSM.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1DDRSM.MinimumSize = size;
            size = new System.Drawing.Size(0x42, 0x17);
            this.label1DDRSM.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textDDRSM.Location = point;
            this.textDDRSM.Name = "textDDRSM";
            this.textDDRSM.Tag = "DDRSM";
            this.textDDRSM.TabIndex = 0;
            this.textDDRSM.Anchor = AnchorStyles.Left;
            this.textDDRSM.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textDDRSM.ContextMenu = this.contextMenu1;
            this.textDDRSM.ReadOnly = false;
            this.textDDRSM.DataBindings.Add(new Binding("Text", this.bindingSourceDDOBRACUN, "DDRSM"));
            this.textDDRSM.Nullable = true;
            this.textDDRSM.MaxLength = 4;
            this.layoutManagerformDDOBRACUN.Controls.Add(this.textDDRSM, 1, 4);
            this.layoutManagerformDDOBRACUN.SetColumnSpan(this.textDDRSM, 1);
            this.layoutManagerformDDOBRACUN.SetRowSpan(this.textDDRSM, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textDDRSM.Margin = padding;
            size = new System.Drawing.Size(0x2c, 0x16);
            this.textDDRSM.MinimumSize = size;
            size = new System.Drawing.Size(0x2c, 0x16);
            this.textDDRSM.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.grdLevelDDOBRACUNRadnici.Location = point;
            this.grdLevelDDOBRACUNRadnici.Name = "grdLevelDDOBRACUNRadnici";
            this.layoutManagerformDDOBRACUN.Controls.Add(this.grdLevelDDOBRACUNRadnici, 0, 5);
            this.layoutManagerformDDOBRACUN.SetColumnSpan(this.grdLevelDDOBRACUNRadnici, 2);
            this.layoutManagerformDDOBRACUN.SetRowSpan(this.grdLevelDDOBRACUNRadnici, 1);
            padding = new Padding(5, 10, 5, 10);
            this.grdLevelDDOBRACUNRadnici.Margin = padding;
            size = new System.Drawing.Size(100, 100);
            this.grdLevelDDOBRACUNRadnici.MinimumSize = size;
            size = new System.Drawing.Size(750, 200);
            this.grdLevelDDOBRACUNRadnici.Size = size;
            this.grdLevelDDOBRACUNRadnici.Dock = DockStyle.Fill;
            this.Controls.Add(this.layoutManagerformDDOBRACUN);
            this.SetNullItem.Index = 0;
            this.SetNullItem.Text = "Set Null";
            this.SetNullItem.Click += new EventHandler(this.SetNullItem_Click);
            this.contextMenu1.Popup += new EventHandler(this.contextMenu1_Popup);
            this.contextMenu1.MenuItems.AddRange(new MenuItem[] { this.SetNullItem });
            this.errorProvider1.DataSource = this.bindingSourceDDOBRACUN;
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            column28.CellActivation = Activation.Disabled;
            column28.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column28.Header.Caption = StringResources.DDOBRACUNDDOBRACUNIDOBRACUNDescription;
            column28.Width = 0x72;
            column28.Format = "";
            column28.CellAppearance = appearance28;
            column28.Hidden = true;
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.DDOBRACUNDDIDRADNIKDescription;
            column2.Width = 0x33;
            appearance2.TextHAlign = HAlign.Right;
            column2.MaskInput = "{LOC}-nnnnn";
            column2.PromptChar = ' ';
            column2.Format = "";
            column2.CellAppearance = appearance2;
            Infragistics.Win.Appearance appearance31 = new Infragistics.Win.Appearance();
            column31.CellActivation = Activation.Disabled;
            column31.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column31.Header.Caption = StringResources.DDOBRACUNDDPREZIMEDescription;
            column31.Width = 0x128;
            column31.Format = "";
            column31.CellAppearance = appearance31;
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            column3.CellActivation = Activation.Disabled;
            column3.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column3.Header.Caption = StringResources.DDOBRACUNDDIMEDescription;
            column3.Width = 0x128;
            column3.Format = "";
            column3.CellAppearance = appearance3;
            Infragistics.Win.Appearance appearance54 = new Infragistics.Win.Appearance();
            column54.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column54.Header.Caption = StringResources.DDOBRACUNIDKATEGORIJADescription;
            column54.Width = 0x63;
            appearance54.TextHAlign = HAlign.Right;
            column54.MaskInput = "{LOC}-nnnnn";
            column54.PromptChar = ' ';
            column54.Format = "";
            column54.CellAppearance = appearance54;
            Infragistics.Win.Appearance appearance65 = new Infragistics.Win.Appearance();
            column65.CellActivation = Activation.Disabled;
            column65.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column65.Header.Caption = StringResources.DDOBRACUNNAZIVKATEGORIJADescription;
            column65.Width = 0x128;
            column65.Format = "";
            column65.CellAppearance = appearance65;
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            column27.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column27.Header.Caption = StringResources.DDOBRACUNDDOBRACUNATIPRIREZDescription;
            column27.Width = 0x8f;
            appearance27.TextHAlign = HAlign.Right;
            column27.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column27.PromptChar = ' ';
            column27.Format = "F2";
            column27.CellAppearance = appearance27;
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            column26.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column26.Header.Caption = StringResources.DDOBRACUNDDOBRACUNATIPDVDescription;
            column26.Width = 0x7b;
            appearance26.TextHAlign = HAlign.Right;
            column26.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column26.PromptChar = ' ';
            column26.Format = "F2";
            column26.CellAppearance = appearance26;
            Infragistics.Win.Appearance appearance66 = new Infragistics.Win.Appearance();
            column66.CellActivation = Activation.Disabled;
            column66.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column66.Header.Caption = StringResources.DDOBRACUNOPCINARADAIDOPCINEDescription;
            column66.Width = 0x87;
            column66.Format = "";
            column66.CellAppearance = appearance66;
            Infragistics.Win.Appearance appearance67 = new Infragistics.Win.Appearance();
            column67.CellActivation = Activation.Disabled;
            column67.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column67.Header.Caption = StringResources.DDOBRACUNOPCINARADANAZIVOPCINEDescription;
            column67.Width = 0x128;
            column67.Format = "";
            column67.CellAppearance = appearance67;
            Infragistics.Win.Appearance appearance68 = new Infragistics.Win.Appearance();
            column68.CellActivation = Activation.Disabled;
            column68.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column68.Header.Caption = StringResources.DDOBRACUNOPCINASTANOVANJAIDOPCINEDescription;
            column68.Width = 0xb1;
            column68.Format = "";
            column68.CellAppearance = appearance68;
            Infragistics.Win.Appearance appearance69 = new Infragistics.Win.Appearance();
            column69.CellActivation = Activation.Disabled;
            column69.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column69.Header.Caption = StringResources.DDOBRACUNOPCINASTANOVANJANAZIVOPCINEDescription;
            column69.Width = 0x128;
            column69.Format = "";
            column69.CellAppearance = appearance69;
            Infragistics.Win.Appearance appearance70 = new Infragistics.Win.Appearance();
            column70.CellActivation = Activation.Disabled;
            column70.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column70.Header.Caption = StringResources.DDOBRACUNOPCINASTANOVANJAPRIREZDescription;
            column70.Width = 0xb7;
            appearance70.TextHAlign = HAlign.Right;
            column70.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column70.PromptChar = ' ';
            column70.Format = "F2";
            column70.CellAppearance = appearance70;
            Infragistics.Win.Appearance appearance71 = new Infragistics.Win.Appearance();
            column71.CellActivation = Activation.Disabled;
            column71.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column71.Header.Caption = StringResources.DDOBRACUNOPCINASTANOVANJAVBDIOPCINADescription;
            column71.Width = 0xfe;
            column71.Format = "";
            column71.CellAppearance = appearance71;
            Infragistics.Win.Appearance appearance72 = new Infragistics.Win.Appearance();
            column72.CellActivation = Activation.Disabled;
            column72.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column72.Header.Caption = StringResources.DDOBRACUNOPCINASTANOVANJAZRNOPCINADescription;
            column72.Width = 0xfe;
            column72.Format = "";
            column72.CellAppearance = appearance72;
            Infragistics.Win.Appearance appearance53 = new Infragistics.Win.Appearance();
            column53.CellActivation = Activation.Disabled;
            column53.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column53.Header.Caption = StringResources.DDOBRACUNIDBANKEDescription;
            column53.Width = 0x5c;
            appearance53.TextHAlign = HAlign.Right;
            column53.MaskInput = "{LOC}-nnnnn";
            column53.PromptChar = ' ';
            column53.Format = "";
            column53.CellAppearance = appearance53;
            Infragistics.Win.Appearance appearance62 = new Infragistics.Win.Appearance();
            column62.CellActivation = Activation.Disabled;
            column62.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column62.Header.Caption = StringResources.DDOBRACUNNAZIVBANKE1Description;
            column62.Width = 0x9c;
            column62.Format = "";
            column62.CellAppearance = appearance62;
            Infragistics.Win.Appearance appearance63 = new Infragistics.Win.Appearance();
            column63.CellActivation = Activation.Disabled;
            column63.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column63.Header.Caption = StringResources.DDOBRACUNNAZIVBANKE2Description;
            column63.Width = 0x9c;
            column63.Format = "";
            column63.CellAppearance = appearance63;
            Infragistics.Win.Appearance appearance64 = new Infragistics.Win.Appearance();
            column64.CellActivation = Activation.Disabled;
            column64.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column64.Header.Caption = StringResources.DDOBRACUNNAZIVBANKE3Description;
            column64.Width = 0x9c;
            column64.Format = "";
            column64.CellAppearance = appearance64;
            Infragistics.Win.Appearance appearance89 = new Infragistics.Win.Appearance();
            column89.CellActivation = Activation.Disabled;
            column89.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column89.Header.Caption = StringResources.DDOBRACUNVBDIBANKEDescription;
            column89.Width = 170;
            column89.Format = "";
            column89.CellAppearance = appearance89;
            Infragistics.Win.Appearance appearance97 = new Infragistics.Win.Appearance();
            column97.CellActivation = Activation.Disabled;
            column97.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column97.Header.Caption = StringResources.DDOBRACUNZRNBANKEDescription;
            column97.Width = 170;
            column97.Format = "";
            column97.CellAppearance = appearance97;
            Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
            column30.CellActivation = Activation.Disabled;
            column30.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column30.Header.Caption = StringResources.DDOBRACUNDDPDVOBVEZNIKDescription;
            column30.Width = 0x6b;
            column30.Format = "";
            column30.CellAppearance = appearance30;
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.CellActivation = Activation.Disabled;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.DDOBRACUNDDDRUGISTUPDescription;
            column.Width = 0x5d;
            column.Format = "";
            column.CellAppearance = appearance;
            Infragistics.Win.Appearance appearance32 = new Infragistics.Win.Appearance();
            column32.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column32.Header.Caption = StringResources.DDOBRACUNDDSIFRAOPCINESTANOVANJADescription;
            column32.Width = 0xb1;
            column32.Format = "";
            column32.CellAppearance = appearance32;
            Infragistics.Win.Appearance appearance55 = new Infragistics.Win.Appearance();
            column55.CellActivation = Activation.Disabled;
            column55.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column55.Header.Caption = StringResources.DDOBRACUNIDKOLONAIDDDescription;
            column55.Width = 0x8b;
            appearance55.TextHAlign = HAlign.Right;
            column55.MaskInput = "{LOC}-nnnnn";
            column55.PromptChar = ' ';
            column55.Format = "";
            column55.CellAppearance = appearance55;
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            column29.CellActivation = Activation.Disabled;
            column29.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column29.Header.Caption = StringResources.DDOBRACUNDDOIBDescription;
            column29.Width = 0x5d;
            column29.Format = "";
            column29.CellAppearance = appearance29;
            Infragistics.Win.Appearance appearance33 = new Infragistics.Win.Appearance();
            column33.CellActivation = Activation.Disabled;
            column33.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column33.Header.Caption = StringResources.DDOBRACUNDDZRNDescription;
            column33.Width = 0x56;
            column33.Format = "";
            column33.CellAppearance = appearance33;
            Infragistics.Win.Appearance appearance94 = new Infragistics.Win.Appearance();
            column94.CellActivation = Activation.Disabled;
            column94.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column94.Header.Caption = StringResources.DDOBRACUNDDOBRACUNIDOBRACUNDescription;
            column94.Width = 0x72;
            column94.Format = "";
            column94.CellAppearance = appearance94;
            column94.Hidden = true;
            Infragistics.Win.Appearance appearance90 = new Infragistics.Win.Appearance();
            column90.CellActivation = Activation.Disabled;
            column90.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column90.Header.Caption = StringResources.DDOBRACUNDDIDRADNIKDescription;
            column90.Width = 0x33;
            appearance90.TextHAlign = HAlign.Right;
            column90.MaskInput = "{LOC}-nnnnn";
            column90.PromptChar = ' ';
            column90.Format = "";
            column90.CellAppearance = appearance90;
            column90.Hidden = true;
            Infragistics.Win.Appearance appearance91 = new Infragistics.Win.Appearance();
            column91.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column91.Header.Caption = StringResources.DDOBRACUNDDIDVRSTAPOSLADescription;
            column91.Width = 0x33;
            appearance91.TextHAlign = HAlign.Right;
            column91.MaskInput = "{LOC}-nnnnn";
            column91.PromptChar = ' ';
            column91.Format = "";
            column91.CellAppearance = appearance91;
            Infragistics.Win.Appearance appearance93 = new Infragistics.Win.Appearance();
            column93.CellActivation = Activation.Disabled;
            column93.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column93.Header.Caption = StringResources.DDOBRACUNDDNAZIVVRSTAPOSLADescription;
            column93.Width = 0x128;
            column93.Format = "";
            column93.CellAppearance = appearance93;
            Infragistics.Win.Appearance appearance95 = new Infragistics.Win.Appearance();
            column95.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column95.Header.Caption = StringResources.DDOBRACUNDDSATIDescription;
            column95.Width = 0x3e;
            appearance95.TextHAlign = HAlign.Right;
            column95.MaskInput = "{LOC}-nnn.nn";
            column95.PromptChar = ' ';
            column95.Format = "F2";
            column95.CellAppearance = appearance95;
            Infragistics.Win.Appearance appearance96 = new Infragistics.Win.Appearance();
            column96.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column96.Header.Caption = StringResources.DDOBRACUNDDSATNICADescription;
            column96.Width = 0x66;
            appearance96.TextHAlign = HAlign.Right;
            column96.MaskInput = "{LOC}-nnnn.nnnnnnnn";
            column96.PromptChar = ' ';
            column96.Format = "F8";
            column96.CellAppearance = appearance96;
            Infragistics.Win.Appearance appearance92 = new Infragistics.Win.Appearance();
            column92.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column92.Header.Caption = StringResources.DDOBRACUNDDIZNOSDescription;
            column92.Width = 0x66;
            appearance92.TextHAlign = HAlign.Right;
            column92.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column92.PromptChar = ' ';
            column92.Format = "F2";
            column92.CellAppearance = appearance92;
            band6.Columns.Add(column90);
            column90.Header.VisiblePosition = 0;
            band6.Columns.Add(column91);
            column91.Header.VisiblePosition = 1;
            band6.Columns.Add(column93);
            column93.Header.VisiblePosition = 2;
            band6.Columns.Add(column95);
            column95.Header.VisiblePosition = 3;
            band6.Columns.Add(column96);
            column96.Header.VisiblePosition = 4;
            band6.Columns.Add(column92);
            column92.Header.VisiblePosition = 5;
            band6.Columns.Add(column94);
            column94.Header.VisiblePosition = 6;
            Infragistics.Win.Appearance appearance60 = new Infragistics.Win.Appearance();
            column60.CellActivation = Activation.Disabled;
            column60.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column60.Header.Caption = StringResources.DDOBRACUNDDOBRACUNIDOBRACUNDescription;
            column60.Width = 0x72;
            column60.Format = "";
            column60.CellAppearance = appearance60;
            column60.Hidden = true;
            Infragistics.Win.Appearance appearance57 = new Infragistics.Win.Appearance();
            column57.CellActivation = Activation.Disabled;
            column57.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column57.Header.Caption = StringResources.DDOBRACUNDDIDRADNIKDescription;
            column57.Width = 0x33;
            appearance57.TextHAlign = HAlign.Right;
            column57.MaskInput = "{LOC}-nnnnn";
            column57.PromptChar = ' ';
            column57.Format = "";
            column57.CellAppearance = appearance57;
            column57.Hidden = true;
            Infragistics.Win.Appearance appearance56 = new Infragistics.Win.Appearance();
            column56.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column56.Header.Caption = StringResources.DDOBRACUNDDIDIZDATAKDescription;
            column56.Width = 0x5c;
            appearance56.TextHAlign = HAlign.Right;
            column56.MaskInput = "{LOC}-nnnnn";
            column56.PromptChar = ' ';
            column56.Format = "";
            column56.CellAppearance = appearance56;
            Infragistics.Win.Appearance appearance58 = new Infragistics.Win.Appearance();
            column58.CellActivation = Activation.Disabled;
            column58.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column58.Header.Caption = StringResources.DDOBRACUNDDNAZIVIZDATKADescription;
            column58.Width = 0x128;
            column58.Format = "";
            column58.CellAppearance = appearance58;
            Infragistics.Win.Appearance appearance61 = new Infragistics.Win.Appearance();
            column61.CellActivation = Activation.Disabled;
            column61.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column61.Header.Caption = StringResources.DDOBRACUNDDPOSTOTAKIZDATKADescription;
            column61.Width = 0x88;
            appearance61.TextHAlign = HAlign.Right;
            column61.MaskInput = "{LOC}-nnn.nn";
            column61.PromptChar = ' ';
            column61.Format = "F2";
            column61.CellAppearance = appearance61;
            Infragistics.Win.Appearance appearance59 = new Infragistics.Win.Appearance();
            column59.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column59.Header.Caption = StringResources.DDOBRACUNDDOBRACUNATIIZDATAKDescription;
            column59.Width = 150;
            appearance59.TextHAlign = HAlign.Right;
            column59.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column59.PromptChar = ' ';
            column59.Format = "F2";
            column59.CellAppearance = appearance59;
            band4.Columns.Add(column57);
            column57.Header.VisiblePosition = 0;
            band4.Columns.Add(column56);
            column56.Header.VisiblePosition = 1;
            band4.Columns.Add(column58);
            column58.Header.VisiblePosition = 2;
            band4.Columns.Add(column61);
            column61.Header.VisiblePosition = 3;
            band4.Columns.Add(column59);
            column59.Header.VisiblePosition = 4;
            band4.Columns.Add(column60);
            column60.Header.VisiblePosition = 5;
            Infragistics.Win.Appearance appearance36 = new Infragistics.Win.Appearance();
            column36.CellActivation = Activation.Disabled;
            column36.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column36.Header.Caption = StringResources.DDOBRACUNDDOBRACUNIDOBRACUNDescription;
            column36.Width = 0x72;
            column36.Format = "";
            column36.CellAppearance = appearance36;
            column36.Hidden = true;
            Infragistics.Win.Appearance appearance34 = new Infragistics.Win.Appearance();
            column34.CellActivation = Activation.Disabled;
            column34.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column34.Header.Caption = StringResources.DDOBRACUNDDIDRADNIKDescription;
            column34.Width = 0x33;
            appearance34.TextHAlign = HAlign.Right;
            column34.MaskInput = "{LOC}-nnnnn";
            column34.PromptChar = ' ';
            column34.Format = "";
            column34.CellAppearance = appearance34;
            column34.Hidden = true;
            Infragistics.Win.Appearance appearance38 = new Infragistics.Win.Appearance();
            column38.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column38.Header.Caption = StringResources.DDOBRACUNIDDOPRINOSDescription;
            column38.Width = 0x77;
            appearance38.TextHAlign = HAlign.Right;
            column38.MaskInput = "{LOC}-nnnnnnnn";
            column38.PromptChar = ' ';
            column38.Format = "";
            column38.CellAppearance = appearance38;
            Infragistics.Win.Appearance appearance42 = new Infragistics.Win.Appearance();
            column42.CellActivation = Activation.Disabled;
            column42.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column42.Header.Caption = StringResources.DDOBRACUNNAZIVDOPRINOSDescription;
            column42.Width = 0x128;
            column42.Format = "";
            column42.CellAppearance = appearance42;
            Infragistics.Win.Appearance appearance39 = new Infragistics.Win.Appearance();
            column39.CellActivation = Activation.Disabled;
            column39.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column39.Header.Caption = StringResources.DDOBRACUNIDVRSTADOPRINOSDescription;
            column39.Width = 0x9f;
            appearance39.TextHAlign = HAlign.Right;
            column39.MaskInput = "{LOC}-nnnnn";
            column39.PromptChar = ' ';
            column39.Format = "";
            column39.CellAppearance = appearance39;
            Infragistics.Win.Appearance appearance43 = new Infragistics.Win.Appearance();
            column43.CellActivation = Activation.Disabled;
            column43.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column43.Header.Caption = StringResources.DDOBRACUNNAZIVVRSTADOPRINOSDescription;
            column43.Width = 0x128;
            column43.Format = "";
            column43.CellAppearance = appearance43;
            Infragistics.Win.Appearance appearance40 = new Infragistics.Win.Appearance();
            column40.CellActivation = Activation.Disabled;
            column40.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column40.Header.Caption = StringResources.DDOBRACUNMODOPRINOSDescription;
            column40.Width = 0xbf;
            column40.Format = "";
            column40.CellAppearance = appearance40;
            Infragistics.Win.Appearance appearance45 = new Infragistics.Win.Appearance();
            column45.CellActivation = Activation.Disabled;
            column45.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column45.Header.Caption = StringResources.DDOBRACUNPODOPRINOSDescription;
            column45.Width = 0xbf;
            column45.Format = "";
            column45.CellAppearance = appearance45;
            Infragistics.Win.Appearance appearance41 = new Infragistics.Win.Appearance();
            column41.CellActivation = Activation.Disabled;
            column41.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column41.Header.Caption = StringResources.DDOBRACUNMZDOPRINOSDescription;
            column41.Width = 0xbf;
            column41.Format = "";
            column41.CellAppearance = appearance41;
            Infragistics.Win.Appearance appearance48 = new Infragistics.Win.Appearance();
            column48.CellActivation = Activation.Disabled;
            column48.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column48.Header.Caption = StringResources.DDOBRACUNPZDOPRINOSDescription;
            column48.Width = 0xbf;
            column48.Format = "";
            column48.CellAppearance = appearance48;
            Infragistics.Win.Appearance appearance46 = new Infragistics.Win.Appearance();
            column46.CellActivation = Activation.Disabled;
            column46.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column46.Header.Caption = StringResources.DDOBRACUNPRIMATELJDOPRINOS1Description;
            column46.Width = 0x9c;
            column46.Format = "";
            column46.CellAppearance = appearance46;
            Infragistics.Win.Appearance appearance47 = new Infragistics.Win.Appearance();
            column47.CellActivation = Activation.Disabled;
            column47.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column47.Header.Caption = StringResources.DDOBRACUNPRIMATELJDOPRINOS2Description;
            column47.Width = 0xb1;
            column47.Format = "";
            column47.CellAppearance = appearance47;
            Infragistics.Win.Appearance appearance49 = new Infragistics.Win.Appearance();
            column49.CellActivation = Activation.Disabled;
            column49.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column49.Header.Caption = StringResources.DDOBRACUNSIFRAOPISAPLACANJADOPRINOSDescription;
            column49.Width = 0xe2;
            column49.Format = "";
            column49.CellAppearance = appearance49;
            Infragistics.Win.Appearance appearance44 = new Infragistics.Win.Appearance();
            column44.CellActivation = Activation.Disabled;
            column44.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column44.Header.Caption = StringResources.DDOBRACUNOPISPLACANJADOPRINOSDescription;
            column44.Width = 0x10c;
            column44.Format = "";
            column44.CellAppearance = appearance44;
            Infragistics.Win.Appearance appearance51 = new Infragistics.Win.Appearance();
            column51.CellActivation = Activation.Disabled;
            column51.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column51.Header.Caption = StringResources.DDOBRACUNVBDIDOPRINOSDescription;
            column51.Width = 0x80;
            column51.Format = "";
            column51.CellAppearance = appearance51;
            Infragistics.Win.Appearance appearance52 = new Infragistics.Win.Appearance();
            column52.CellActivation = Activation.Disabled;
            column52.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column52.Header.Caption = StringResources.DDOBRACUNZRNDOPRINOSDescription;
            column52.Width = 170;
            column52.Format = "";
            column52.CellAppearance = appearance52;
            Infragistics.Win.Appearance appearance50 = new Infragistics.Win.Appearance();
            column50.CellActivation = Activation.Disabled;
            column50.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column50.Header.Caption = StringResources.DDOBRACUNSTOPADescription;
            column50.Width = 0x37;
            appearance50.TextHAlign = HAlign.Right;
            column50.MaskInput = "{LOC}-nnn.nn";
            column50.PromptChar = ' ';
            column50.Format = "F2";
            column50.CellAppearance = appearance50;
            Infragistics.Win.Appearance appearance35 = new Infragistics.Win.Appearance();
            column35.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column35.Header.Caption = StringResources.DDOBRACUNDDOBRACUNATIDOPRINOSDescription;
            column35.Width = 0x9c;
            appearance35.TextHAlign = HAlign.Right;
            column35.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column35.PromptChar = ' ';
            column35.Format = "F2";
            column35.CellAppearance = appearance35;
            Infragistics.Win.Appearance appearance37 = new Infragistics.Win.Appearance();
            column37.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column37.Header.Caption = StringResources.DDOBRACUNDDOSNOVICADOPRINOSDescription;
            column37.Width = 0x8f;
            appearance37.TextHAlign = HAlign.Right;
            column37.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column37.PromptChar = ' ';
            column37.Format = "F2";
            column37.CellAppearance = appearance37;
            band3.Columns.Add(column34);
            column34.Header.VisiblePosition = 0;
            band3.Columns.Add(column38);
            column38.Header.VisiblePosition = 1;
            band3.Columns.Add(column42);
            column42.Header.VisiblePosition = 2;
            band3.Columns.Add(column39);
            column39.Header.VisiblePosition = 3;
            band3.Columns.Add(column43);
            column43.Header.VisiblePosition = 4;
            band3.Columns.Add(column40);
            column40.Header.VisiblePosition = 5;
            band3.Columns.Add(column45);
            column45.Header.VisiblePosition = 6;
            band3.Columns.Add(column41);
            column41.Header.VisiblePosition = 7;
            band3.Columns.Add(column48);
            column48.Header.VisiblePosition = 8;
            band3.Columns.Add(column46);
            column46.Header.VisiblePosition = 9;
            band3.Columns.Add(column47);
            column47.Header.VisiblePosition = 10;
            band3.Columns.Add(column49);
            column49.Header.VisiblePosition = 11;
            band3.Columns.Add(column44);
            column44.Header.VisiblePosition = 12;
            band3.Columns.Add(column51);
            column51.Header.VisiblePosition = 13;
            band3.Columns.Add(column52);
            column52.Header.VisiblePosition = 14;
            band3.Columns.Add(column50);
            column50.Header.VisiblePosition = 15;
            band3.Columns.Add(column35);
            column35.Header.VisiblePosition = 0x10;
            band3.Columns.Add(column37);
            column37.Header.VisiblePosition = 0x11;
            band3.Columns.Add(column36);
            column36.Header.VisiblePosition = 0x12;
            Infragistics.Win.Appearance appearance76 = new Infragistics.Win.Appearance();
            column76.CellActivation = Activation.Disabled;
            column76.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column76.Header.Caption = StringResources.DDOBRACUNDDOBRACUNIDOBRACUNDescription;
            column76.Width = 0x72;
            column76.Format = "";
            column76.CellAppearance = appearance76;
            column76.Hidden = true;
            Infragistics.Win.Appearance appearance73 = new Infragistics.Win.Appearance();
            column73.CellActivation = Activation.Disabled;
            column73.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column73.Header.Caption = StringResources.DDOBRACUNDDIDRADNIKDescription;
            column73.Width = 0x33;
            appearance73.TextHAlign = HAlign.Right;
            column73.MaskInput = "{LOC}-nnnnn";
            column73.PromptChar = ' ';
            column73.Format = "";
            column73.CellAppearance = appearance73;
            column73.Hidden = true;
            Infragistics.Win.Appearance appearance79 = new Infragistics.Win.Appearance();
            column79.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column79.Header.Caption = StringResources.DDOBRACUNIDPOREZDescription;
            column79.Width = 0x63;
            appearance79.TextHAlign = HAlign.Right;
            column79.MaskInput = "{LOC}-nnnnn";
            column79.PromptChar = ' ';
            column79.Format = "";
            column79.CellAppearance = appearance79;
            Infragistics.Win.Appearance appearance81 = new Infragistics.Win.Appearance();
            column81.CellActivation = Activation.Disabled;
            column81.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column81.Header.Caption = StringResources.DDOBRACUNNAZIVPOREZDescription;
            column81.Width = 0x128;
            column81.Format = "";
            column81.CellAppearance = appearance81;
            Infragistics.Win.Appearance appearance83 = new Infragistics.Win.Appearance();
            column83.CellActivation = Activation.Disabled;
            column83.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column83.Header.Caption = StringResources.DDOBRACUNPOREZMJESECNODescription;
            column83.Width = 0xd9;
            appearance83.TextHAlign = HAlign.Right;
            column83.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column83.PromptChar = ' ';
            column83.Format = "F2";
            column83.CellAppearance = appearance83;
            Infragistics.Win.Appearance appearance88 = new Infragistics.Win.Appearance();
            column88.CellActivation = Activation.Disabled;
            column88.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column88.Header.Caption = StringResources.DDOBRACUNSTOPAPOREZADescription;
            column88.Width = 0x66;
            appearance88.TextHAlign = HAlign.Right;
            column88.MaskInput = "{LOC}-nn.nn";
            column88.PromptChar = ' ';
            column88.Format = "F2";
            column88.CellAppearance = appearance88;
            Infragistics.Win.Appearance appearance78 = new Infragistics.Win.Appearance();
            column78.CellActivation = Activation.Disabled;
            column78.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column78.Header.Caption = StringResources.DDOBRACUNDDPOPOREZDescription;
            column78.Width = 170;
            column78.Format = "";
            column78.CellAppearance = appearance78;
            Infragistics.Win.Appearance appearance74 = new Infragistics.Win.Appearance();
            column74.CellActivation = Activation.Disabled;
            column74.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column74.Header.Caption = StringResources.DDOBRACUNDDMOPOREZDescription;
            column74.Width = 0x4f;
            column74.Format = "";
            column74.CellAppearance = appearance74;
            Infragistics.Win.Appearance appearance80 = new Infragistics.Win.Appearance();
            column80.CellActivation = Activation.Disabled;
            column80.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column80.Header.Caption = StringResources.DDOBRACUNMZPOREZDescription;
            column80.Width = 170;
            column80.Format = "";
            column80.CellAppearance = appearance80;
            Infragistics.Win.Appearance appearance86 = new Infragistics.Win.Appearance();
            column86.CellActivation = Activation.Disabled;
            column86.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column86.Header.Caption = StringResources.DDOBRACUNPZPOREZDescription;
            column86.Width = 0xe2;
            column86.Format = "";
            column86.CellAppearance = appearance86;
            Infragistics.Win.Appearance appearance84 = new Infragistics.Win.Appearance();
            column84.CellActivation = Activation.Disabled;
            column84.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column84.Header.Caption = StringResources.DDOBRACUNPRIMATELJPOREZ1Description;
            column84.Width = 0x9c;
            column84.Format = "";
            column84.CellAppearance = appearance84;
            Infragistics.Win.Appearance appearance85 = new Infragistics.Win.Appearance();
            column85.CellActivation = Activation.Disabled;
            column85.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column85.Header.Caption = StringResources.DDOBRACUNPRIMATELJPOREZ2Description;
            column85.Width = 0x9c;
            column85.Format = "";
            column85.CellAppearance = appearance85;
            Infragistics.Win.Appearance appearance87 = new Infragistics.Win.Appearance();
            column87.CellActivation = Activation.Disabled;
            column87.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column87.Header.Caption = StringResources.DDOBRACUNSIFRAOPISAPLACANJAPOREZDescription;
            column87.Width = 0xcd;
            column87.Format = "";
            column87.CellAppearance = appearance87;
            Infragistics.Win.Appearance appearance82 = new Infragistics.Win.Appearance();
            column82.CellActivation = Activation.Disabled;
            column82.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column82.Header.Caption = StringResources.DDOBRACUNOPISPLACANJAPOREZDescription;
            column82.Width = 0x10c;
            column82.Format = "";
            column82.CellAppearance = appearance82;
            Infragistics.Win.Appearance appearance75 = new Infragistics.Win.Appearance();
            column75.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column75.Header.Caption = StringResources.DDOBRACUNDDOBRACUNATIPOREZDescription;
            column75.Width = 0x88;
            appearance75.TextHAlign = HAlign.Right;
            column75.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column75.PromptChar = ' ';
            column75.Format = "F2";
            column75.CellAppearance = appearance75;
            Infragistics.Win.Appearance appearance77 = new Infragistics.Win.Appearance();
            column77.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column77.Header.Caption = StringResources.DDOBRACUNDDOSNOVICAPOREZDescription;
            column77.Width = 0x7b;
            appearance77.TextHAlign = HAlign.Right;
            column77.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column77.PromptChar = ' ';
            column77.Format = "F2";
            column77.CellAppearance = appearance77;
            band5.Columns.Add(column73);
            column73.Header.VisiblePosition = 0;
            band5.Columns.Add(column79);
            column79.Header.VisiblePosition = 1;
            band5.Columns.Add(column81);
            column81.Header.VisiblePosition = 2;
            band5.Columns.Add(column83);
            column83.Header.VisiblePosition = 3;
            band5.Columns.Add(column88);
            column88.Header.VisiblePosition = 4;
            band5.Columns.Add(column78);
            column78.Header.VisiblePosition = 5;
            band5.Columns.Add(column74);
            column74.Header.VisiblePosition = 6;
            band5.Columns.Add(column80);
            column80.Header.VisiblePosition = 7;
            band5.Columns.Add(column86);
            column86.Header.VisiblePosition = 8;
            band5.Columns.Add(column84);
            column84.Header.VisiblePosition = 9;
            band5.Columns.Add(column85);
            column85.Header.VisiblePosition = 10;
            band5.Columns.Add(column87);
            column87.Header.VisiblePosition = 11;
            band5.Columns.Add(column82);
            column82.Header.VisiblePosition = 12;
            band5.Columns.Add(column75);
            column75.Header.VisiblePosition = 13;
            band5.Columns.Add(column77);
            column77.Header.VisiblePosition = 14;
            band5.Columns.Add(column76);
            column76.Header.VisiblePosition = 15;
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            column5.CellActivation = Activation.Disabled;
            column5.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column5.Header.Caption = StringResources.DDOBRACUNDDOBRACUNIDOBRACUNDescription;
            column5.Width = 0x72;
            column5.Format = "";
            column5.CellAppearance = appearance5;
            column5.Hidden = true;
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            column4.CellActivation = Activation.Disabled;
            column4.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column4.Header.Caption = StringResources.DDOBRACUNDDIDRADNIKDescription;
            column4.Width = 0x33;
            appearance4.TextHAlign = HAlign.Right;
            column4.MaskInput = "{LOC}-nnnnn";
            column4.PromptChar = ' ';
            column4.Format = "";
            column4.CellAppearance = appearance4;
            column4.Hidden = true;
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            column12.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column12.Header.Caption = StringResources.DDOBRACUNIDKRIZNIPOREZDescription;
            column12.Width = 0x69;
            appearance12.TextHAlign = HAlign.Right;
            column12.MaskInput = "{LOC}-nnnnn";
            column12.PromptChar = ' ';
            column12.Format = "";
            column12.CellAppearance = appearance12;
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            column16.CellActivation = Activation.Disabled;
            column16.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column16.Header.Caption = StringResources.DDOBRACUNNAZIVKRIZNIPOREZDescription;
            column16.Width = 0x128;
            column16.Format = "";
            column16.CellAppearance = appearance16;
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            column13.CellActivation = Activation.Disabled;
            column13.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column13.Header.Caption = StringResources.DDOBRACUNKRIZNISTOPADescription;
            column13.Width = 0x60;
            appearance13.TextHAlign = HAlign.Right;
            column13.MaskInput = "{LOC}-nnn.nn";
            column13.PromptChar = ' ';
            column13.Format = "F2";
            column13.CellAppearance = appearance13;
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            column14.CellActivation = Activation.Disabled;
            column14.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column14.Header.Caption = StringResources.DDOBRACUNMOKRIZNIDescription;
            column14.Width = 0x48;
            column14.Format = "";
            column14.CellAppearance = appearance14;
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            column18.CellActivation = Activation.Disabled;
            column18.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column18.Header.Caption = StringResources.DDOBRACUNPOKRIZNIDescription;
            column18.Width = 170;
            column18.Format = "";
            column18.CellAppearance = appearance18;
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            column15.CellActivation = Activation.Disabled;
            column15.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column15.Header.Caption = StringResources.DDOBRACUNMZKRIZNIDescription;
            column15.Width = 0x48;
            column15.Format = "";
            column15.CellAppearance = appearance15;
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            column22.CellActivation = Activation.Disabled;
            column22.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column22.Header.Caption = StringResources.DDOBRACUNPZKRIZNIDescription;
            column22.Width = 170;
            column22.Format = "";
            column22.CellAppearance = appearance22;
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            column19.CellActivation = Activation.Disabled;
            column19.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column19.Header.Caption = StringResources.DDOBRACUNPRIMATELJKRIZNI1Description;
            column19.Width = 0x9c;
            column19.Format = "";
            column19.CellAppearance = appearance19;
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            column20.CellActivation = Activation.Disabled;
            column20.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column20.Header.Caption = StringResources.DDOBRACUNPRIMATELJKRIZNI2Description;
            column20.Width = 0x9c;
            column20.Format = "";
            column20.CellAppearance = appearance20;
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            column21.CellActivation = Activation.Disabled;
            column21.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column21.Header.Caption = StringResources.DDOBRACUNPRIMATELJKRIZNI3Description;
            column21.Width = 0x9c;
            column21.Format = "";
            column21.CellAppearance = appearance21;
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            column23.CellActivation = Activation.Disabled;
            column23.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column23.Header.Caption = StringResources.DDOBRACUNSIFRAOPISAPLACANJAKRIZNIDescription;
            column23.Width = 0xb8;
            column23.Format = "";
            column23.CellAppearance = appearance23;
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            column17.CellActivation = Activation.Disabled;
            column17.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column17.Header.Caption = StringResources.DDOBRACUNOPISPLACANJAKRIZNIDescription;
            column17.Width = 0x10c;
            column17.Format = "";
            column17.CellAppearance = appearance17;
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            column24.CellActivation = Activation.Disabled;
            column24.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column24.Header.Caption = StringResources.DDOBRACUNVBDIKRIZNIDescription;
            column24.Width = 0x56;
            column24.Format = "";
            column24.CellAppearance = appearance24;
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            column25.CellActivation = Activation.Disabled;
            column25.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column25.Header.Caption = StringResources.DDOBRACUNZRNKRIZNIDescription;
            column25.Width = 0x56;
            column25.Format = "";
            column25.CellAppearance = appearance25;
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            column6.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column6.Header.Caption = StringResources.DDOBRACUNDDOSNOVICAKRIZNIDescription;
            column6.Width = 0x81;
            appearance6.TextHAlign = HAlign.Right;
            column6.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column6.PromptChar = ' ';
            column6.Format = "F2";
            column6.CellAppearance = appearance6;
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            column9.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column9.Header.Caption = StringResources.DDOBRACUNDDPOREZKRIZNIDescription;
            column9.Width = 0x6d;
            appearance9.TextHAlign = HAlign.Right;
            column9.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column9.PromptChar = ' ';
            column9.Format = "F2";
            column9.CellAppearance = appearance9;
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            column7.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column7.Header.Caption = StringResources.DDOBRACUNDDOSNOVICAPRETHODNADescription;
            column7.Width = 150;
            appearance7.TextHAlign = HAlign.Right;
            column7.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column7.PromptChar = ' ';
            column7.Format = "F2";
            column7.CellAppearance = appearance7;
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            column8.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column8.Header.Caption = StringResources.DDOBRACUNDDOSNOVICAUKUPNADescription;
            column8.Width = 0x81;
            appearance8.TextHAlign = HAlign.Right;
            column8.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column8.PromptChar = ' ';
            column8.Format = "F2";
            column8.CellAppearance = appearance8;
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            column10.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column10.Header.Caption = StringResources.DDOBRACUNDDPOREZPRETHODNIDescription;
            column10.Width = 0x81;
            appearance10.TextHAlign = HAlign.Right;
            column10.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column10.PromptChar = ' ';
            column10.Format = "F2";
            column10.CellAppearance = appearance10;
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            column11.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column11.Header.Caption = StringResources.DDOBRACUNDDPOREZUKUPNODescription;
            column11.Width = 0x6d;
            appearance11.TextHAlign = HAlign.Right;
            column11.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column11.PromptChar = ' ';
            column11.Format = "F2";
            column11.CellAppearance = appearance11;
            band2.Columns.Add(column4);
            column4.Header.VisiblePosition = 0;
            band2.Columns.Add(column12);
            column12.Header.VisiblePosition = 1;
            band2.Columns.Add(column16);
            column16.Header.VisiblePosition = 2;
            band2.Columns.Add(column13);
            column13.Header.VisiblePosition = 3;
            band2.Columns.Add(column14);
            column14.Header.VisiblePosition = 4;
            band2.Columns.Add(column18);
            column18.Header.VisiblePosition = 5;
            band2.Columns.Add(column15);
            column15.Header.VisiblePosition = 6;
            band2.Columns.Add(column22);
            column22.Header.VisiblePosition = 7;
            band2.Columns.Add(column19);
            column19.Header.VisiblePosition = 8;
            band2.Columns.Add(column20);
            column20.Header.VisiblePosition = 9;
            band2.Columns.Add(column21);
            column21.Header.VisiblePosition = 10;
            band2.Columns.Add(column23);
            column23.Header.VisiblePosition = 11;
            band2.Columns.Add(column17);
            column17.Header.VisiblePosition = 12;
            band2.Columns.Add(column24);
            column24.Header.VisiblePosition = 13;
            band2.Columns.Add(column25);
            column25.Header.VisiblePosition = 14;
            band2.Columns.Add(column6);
            column6.Header.VisiblePosition = 15;
            band2.Columns.Add(column9);
            column9.Header.VisiblePosition = 0x10;
            band2.Columns.Add(column7);
            column7.Header.VisiblePosition = 0x11;
            band2.Columns.Add(column8);
            column8.Header.VisiblePosition = 0x12;
            band2.Columns.Add(column10);
            column10.Header.VisiblePosition = 0x13;
            band2.Columns.Add(column11);
            column11.Header.VisiblePosition = 20;
            band2.Columns.Add(column5);
            column5.Header.VisiblePosition = 0x15;
            band.Columns.Add(column2);
            column2.Header.VisiblePosition = 0;
            band.Columns.Add(column31);
            column31.Header.VisiblePosition = 1;
            band.Columns.Add(column3);
            column3.Header.VisiblePosition = 2;
            band.Columns.Add(column54);
            column54.Header.VisiblePosition = 3;
            band.Columns.Add(column65);
            column65.Header.VisiblePosition = 4;
            band.Columns.Add(column27);
            column27.Header.VisiblePosition = 5;
            band.Columns.Add(column26);
            column26.Header.VisiblePosition = 6;
            band.Columns.Add(column66);
            column66.Header.VisiblePosition = 7;
            band.Columns.Add(column67);
            column67.Header.VisiblePosition = 8;
            band.Columns.Add(column68);
            column68.Header.VisiblePosition = 9;
            band.Columns.Add(column69);
            column69.Header.VisiblePosition = 10;
            band.Columns.Add(column70);
            column70.Header.VisiblePosition = 11;
            band.Columns.Add(column71);
            column71.Header.VisiblePosition = 12;
            band.Columns.Add(column72);
            column72.Header.VisiblePosition = 13;
            band.Columns.Add(column53);
            column53.Header.VisiblePosition = 14;
            band.Columns.Add(column62);
            column62.Header.VisiblePosition = 15;
            band.Columns.Add(column63);
            column63.Header.VisiblePosition = 0x10;
            band.Columns.Add(column64);
            column64.Header.VisiblePosition = 0x11;
            band.Columns.Add(column89);
            column89.Header.VisiblePosition = 0x12;
            band.Columns.Add(column97);
            column97.Header.VisiblePosition = 0x13;
            band.Columns.Add(column30);
            column30.Header.VisiblePosition = 20;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 0x15;
            band.Columns.Add(column32);
            column32.Header.VisiblePosition = 0x16;
            band.Columns.Add(column55);
            column55.Header.VisiblePosition = 0x17;
            band.Columns.Add(column29);
            column29.Header.VisiblePosition = 0x18;
            band.Columns.Add(column33);
            column33.Header.VisiblePosition = 0x19;
            band.Columns.Add(column28);
            column28.Header.VisiblePosition = 0x1a;
            this.grdLevelDDOBRACUNRadnici.Visible = true;
            this.grdLevelDDOBRACUNRadnici.Name = "grdLevelDDOBRACUNRadnici";
            this.grdLevelDDOBRACUNRadnici.Tag = "DDOBRACUNRadnici";
            this.grdLevelDDOBRACUNRadnici.TabIndex = 11;
            this.grdLevelDDOBRACUNRadnici.Dock = DockStyle.Fill;
            this.grdLevelDDOBRACUNRadnici.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.grdLevelDDOBRACUNRadnici.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.grdLevelDDOBRACUNRadnici.DataSource = this.bindingSourceDDOBRACUNRadnici;
            this.grdLevelDDOBRACUNRadnici.Enter += new EventHandler(this.grdLevelDDOBRACUNRadnici_Enter);
            this.grdLevelDDOBRACUNRadnici.AfterRowInsert += new RowEventHandler(this.grdLevelDDOBRACUNRadnici_AfterRowInsert);
            this.grdLevelDDOBRACUNRadnici.AfterCellActivate += new EventHandler(this.CellChanged);
            this.grdLevelDDOBRACUNRadnici.ClickCellButton += new CellEventHandler(this.dg_ClickCellButton);
            this.grdLevelDDOBRACUNRadnici.DisplayLayout.Override.AllowAddNew = AllowAddNew.TemplateOnBottom;
            this.grdLevelDDOBRACUNRadnici.DisplayLayout.BandsSerializer.Add(band);
            this.grdLevelDDOBRACUNRadnici.DisplayLayout.BandsSerializer.Add(band6);
            this.grdLevelDDOBRACUNRadnici.DisplayLayout.BandsSerializer.Add(band4);
            this.grdLevelDDOBRACUNRadnici.DisplayLayout.BandsSerializer.Add(band3);
            this.grdLevelDDOBRACUNRadnici.DisplayLayout.BandsSerializer.Add(band5);
            this.grdLevelDDOBRACUNRadnici.DisplayLayout.BandsSerializer.Add(band2);
            this.Name = "DDOBRACUNFormUserControl";
            this.Text = "DDOBRACUN";
            this.AutoSize = true;
            this.AutoScroll = true;
            this.Load += new EventHandler(this.DDOBRACUNFormUserControl_Load);
            this.layoutManagerformDDOBRACUN.ResumeLayout(false);
            this.layoutManagerformDDOBRACUN.PerformLayout();
            ((ISupportInitialize) this.bindingSourceDDOBRACUN).EndInit();
            ((ISupportInitialize) this.bindingSourceDDOBRACUNRadnici).EndInit();
            ((ISupportInitialize) this.textDDOBRACUNIDOBRACUN).EndInit();
            ((ISupportInitialize) this.textDDOPISOBRACUN).EndInit();
            ((ISupportInitialize) this.textDDRSM).EndInit();
            ((ISupportInitialize) this.grdLevelDDOBRACUNRadnici).EndInit();
            this.dsDDOBRACUNDataSet1.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private bool InValidState()
        {
            if ((this.DDOBRACUNController.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourceDDOBRACUN, this.DDOBRACUNController.WorkItem, this))
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
            this.label1DDOBRACUNIDOBRACUN.Text = StringResources.DDOBRACUNDDOBRACUNIDOBRACUNDescription;
            this.label1DDOPISOBRACUN.Text = StringResources.DDOBRACUNDDOPISOBRACUNDescription;
            this.label1DDDATUMOBRACUNA.Text = StringResources.DDOBRACUNDDDATUMOBRACUNADescription;
            this.label1DDZAKLJUCAN.Text = StringResources.DDOBRACUNDDZAKLJUCANDescription;
            this.label1DDRSM.Text = StringResources.DDOBRACUNDDRSMDescription;
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
            if (!this.DDOBRACUNController.WorkItem.Items.Contains("DDOBRACUN|DDOBRACUN"))
            {
                this.DDOBRACUNController.WorkItem.Items.Add(this.bindingSourceDDOBRACUN, "DDOBRACUN|DDOBRACUN");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        public void ResumeBindingPostUpdate()
        {
            if ((this.dsDDOBRACUNDataSet1.DDOBRACUN.Rows[0] != null) && this.m_BaseMethods.IsInsert())
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
                this.DDOBRACUNController.Update(this);
            }
        }

        [LocalCommandHandler("SaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (this.InValidState() && this.DDOBRACUNController.Update(this))
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [LocalCommandHandler("SaveAndNew")]
        public void SaveAndNew(object sender, EventArgs e)
        {
            if (this.InValidState() && this.DDOBRACUNController.Update(this))
            {
                this.DDOBRACUNController.DataSet = new DDOBRACUNDataSet();
                DataSetUtil.AddEmptyRow(this.DDOBRACUNController.DataSet);
                this.ChangeBinding();
                this.m_CurrentRow = this.DDOBRACUNController.DataSet.DDOBRACUN[0];
                DataSetUtil.CopyForeignKeyValues(this.m_CurrentRow, this.m_ForeignKeys);
                this.SetFocusInFirstField();
            }
        }

        private void SetComboBoxColumnProperties()
        {
            UltraGridColumn gridColumn = FormHelperClass.GetGridColumn(this.grdLevelDDOBRACUNRadnici, "DDIDRADNIK");
            gridColumn.Tag = "DDRADNIKDDIDRADNIK";
            gridColumn.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.EditButton;
            gridColumn.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            UltraGridColumn column4 = FormHelperClass.GetGridColumn(this.grdLevelDDOBRACUNRadnici, "IDKATEGORIJA");
            column4.Tag = "DDKATEGORIJAIDKATEGORIJA";
            column4.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.EditButton;
            column4.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            UltraGridColumn column7 = FormHelperClass.GetGridColumn(this.grdLevelDDOBRACUNRadnici, "DDIDVRSTAPOSLA");
            column7.Tag = "DDVRSTEPOSLADDIDVRSTAPOSLA";
            column7.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.EditButton;
            column7.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            UltraGridColumn column5 = FormHelperClass.GetGridColumn(this.grdLevelDDOBRACUNRadnici, "DDIDIZDATAK");
            column5.Tag = "DDIZDATAKDDIDIZDATAK";
            column5.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.EditButton;
            column5.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            UltraGridColumn column3 = FormHelperClass.GetGridColumn(this.grdLevelDDOBRACUNRadnici, "IDDOPRINOS");
            column3.Tag = "DOPRINOSIDDOPRINOS";
            column3.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.EditButton;
            column3.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            UltraGridColumn column6 = FormHelperClass.GetGridColumn(this.grdLevelDDOBRACUNRadnici, "IDPOREZ");
            column6.Tag = "POREZIDPOREZ";
            column6.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.EditButton;
            column6.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            UltraGridColumn column2 = FormHelperClass.GetGridColumn(this.grdLevelDDOBRACUNRadnici, "IDKRIZNIPOREZ");
            column2.Tag = "KRIZNIPOREZIDKRIZNIPOREZ";
            column2.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.EditButton;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
        }

        private void SetFocusInFirstField()
        {
            this.textDDOBRACUNIDOBRACUN.Focus();
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

        protected virtual UltraCheckEditor checkDDZAKLJUCAN
        {
            [DebuggerNonUserCode]
            get
            {
                return this._checkDDZAKLJUCAN;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._checkDDZAKLJUCAN = value;
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

        protected virtual UltraDateTimeEditor datePickerDDDATUMOBRACUNA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._datePickerDDDATUMOBRACUNA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._datePickerDDDATUMOBRACUNA = value;
            }
        }

        [CreateNew, Browsable(false)]
        public NetAdvantage.Controllers.DDOBRACUNController DDOBRACUNController { get; set; }

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

        protected virtual UltraGrid grdLevelDDOBRACUNRadnici
        {
            [DebuggerNonUserCode]
            get
            {
                return this._grdLevelDDOBRACUNRadnici;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._grdLevelDDOBRACUNRadnici = value;
            }
        }

        protected virtual UltraLabel label1DDDATUMOBRACUNA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1DDDATUMOBRACUNA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1DDDATUMOBRACUNA = value;
            }
        }

        protected virtual UltraLabel label1DDOBRACUNIDOBRACUN
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1DDOBRACUNIDOBRACUN;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1DDOBRACUNIDOBRACUN = value;
            }
        }

        protected virtual UltraLabel label1DDOPISOBRACUN
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1DDOPISOBRACUN;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1DDOPISOBRACUN = value;
            }
        }

        protected virtual UltraLabel label1DDRSM
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1DDRSM;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1DDRSM = value;
            }
        }

        protected virtual UltraLabel label1DDZAKLJUCAN
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1DDZAKLJUCAN;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1DDZAKLJUCAN = value;
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

        protected virtual UltraTextEditor textDDOBRACUNIDOBRACUN
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textDDOBRACUNIDOBRACUN;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textDDOBRACUNIDOBRACUN = value;
            }
        }

        protected virtual UltraTextEditor textDDOPISOBRACUN
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textDDOPISOBRACUN;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textDDOPISOBRACUN = value;
            }
        }

        protected virtual UltraTextEditor textDDRSM
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textDDRSM;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textDDRSM = value;
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


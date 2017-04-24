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
    public class DOSIPZAGLAVLJEFormUserControl : UserControl, IBusinessComponentUserControl
    {
        [AccessedThroughProperty("checkDOSOZNACEN")]
        private UltraCheckEditor _checkDOSOZNACEN;
        [AccessedThroughProperty("contextMenu1")]
        private ContextMenu _contextMenu1;
        [AccessedThroughProperty("errorProvider1")]
        private ErrorProvider _errorProvider1;
        [AccessedThroughProperty("errorProviderValidator1")]
        private ErrorProviderValidator _errorProviderValidator1;
        [AccessedThroughProperty("grdLevelDOSIPZAGLAVLJELevel1")]
        private UltraGrid _grdLevelDOSIPZAGLAVLJELevel1;
        [AccessedThroughProperty("label1DOSIPIDENT")]
        private UltraLabel _label1DOSIPIDENT;
        [AccessedThroughProperty("label1DOSISPLATAUGODINI")]
        private UltraLabel _label1DOSISPLATAUGODINI;
        [AccessedThroughProperty("label1DOSISPLATAZAGODINU")]
        private UltraLabel _label1DOSISPLATAZAGODINU;
        [AccessedThroughProperty("label1DOSJMBG")]
        private UltraLabel _label1DOSJMBG;
        [AccessedThroughProperty("label1DOSOZNACEN")]
        private UltraLabel _label1DOSOZNACEN;
        [AccessedThroughProperty("SetNullItem")]
        private MenuItem _SetNullItem;
        [AccessedThroughProperty("textDOSIPIDENT")]
        private UltraTextEditor _textDOSIPIDENT;
        [AccessedThroughProperty("textDOSISPLATAUGODINI")]
        private UltraTextEditor _textDOSISPLATAUGODINI;
        [AccessedThroughProperty("textDOSISPLATAZAGODINU")]
        private UltraTextEditor _textDOSISPLATAZAGODINU;
        [AccessedThroughProperty("textDOSJMBG")]
        private UltraTextEditor _textDOSJMBG;
        [AccessedThroughProperty("toolTip1")]
        private System.Windows.Forms.ToolTip _toolTip1;
        private BindingSource bindingSourceDOSIPZAGLAVLJE;
        private BindingSource bindingSourceDOSIPZAGLAVLJELevel1;
        private IContainer components = null;
        private DOSIPZAGLAVLJEDataSet dsDOSIPZAGLAVLJEDataSet1;
        protected TableLayoutPanel layoutManagerformDOSIPZAGLAVLJE;
        private bool m_AutoNumber = false;
        private GenericFormClass m_BaseMethods;
        private DOSIPZAGLAVLJEDataSet.DOSIPZAGLAVLJERow m_CurrentRow;
        private ArrayList m_DataGrids = new ArrayList();
        private string m_FirstLevelName = "DOSIPZAGLAVLJE";
        private DataRow m_ForeignKeys;
        private string m_FrameworkDescription = StringResources.DOSIPZAGLAVLJEDescription;
        private DeklaritMode m_Mode;

        public DOSIPZAGLAVLJEFormUserControl()
        {
            this.InitializeComponent();
            this.Localize();
            this.SetSize();
        }

        private void CellChanged(object sender, EventArgs e)
        {
            this.m_BaseMethods.CellChangedBase(this.dsDOSIPZAGLAVLJEDataSet1, RuntimeHelpers.GetObjectValue(sender));
        }

        public void ChangeBinding()
        {
            this.bindingSourceDOSIPZAGLAVLJE.DataSource = this.DOSIPZAGLAVLJEController.DataSet;
            this.dsDOSIPZAGLAVLJEDataSet1 = this.DOSIPZAGLAVLJEController.DataSet;
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
                    enumerator = this.dsDOSIPZAGLAVLJEDataSet1.DOSIPZAGLAVLJE.Rows.GetEnumerator();
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
                if (this.DOSIPZAGLAVLJEController.Update(this))
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
                string str = Conversions.ToString(column.Tag);
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

        private void DOSIPZAGLAVLJEFormUserControl_Load(object sender, EventArgs e)
        {
            this.Text = StringResources.DOSIPZAGLAVLJEDescription;
            this.errorProvider1.ContainerControl = this;
        }

        private void EndEditCurrentRow()
        {
            if (this.grdLevelDOSIPZAGLAVLJELevel1.ActiveRow != null)
            {
                this.grdLevelDOSIPZAGLAVLJELevel1.PerformAction(UltraGridAction.NextRow);
            }
        }

        private void grdLevelDOSIPZAGLAVLJELevel1_AfterRowInsert(object sender, RowEventArgs e)
        {
            //if (this.bindingSourceDOSIPZAGLAVLJE.Current == typeof(DataRowView))
            //{
            //    DataRowView current = (DataRowView) this.bindingSourceDOSIPZAGLAVLJE.Current;
            //    if (current.IsNew)
            //    {
            //        current.Row.SetParentRow(this.m_CurrentRow);
            //    }
            //}
        }

        private void grdLevelDOSIPZAGLAVLJELevel1_Enter(object sender, EventArgs e)
        {
            GenericFormClass.EndEditBindingSource(this.bindingSourceDOSIPZAGLAVLJE, this.DOSIPZAGLAVLJEController.WorkItem, this);
        }

        public void Initialize(DeklaritMode mode, DataRow foreignKeys, bool isCopy)
        {
            this.ChangeBinding();
            this.m_ForeignKeys = foreignKeys;
            this.RegisterBindingSources();
            this.m_Mode = mode;
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "DOSIPZAGLAVLJE", this.m_Mode, this.dsDOSIPZAGLAVLJEDataSet1, this.dsDOSIPZAGLAVLJEDataSet1.DOSIPZAGLAVLJE.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            Binding binding = new Binding("CheckState", this.bindingSourceDOSIPZAGLAVLJE, "DOSOZNACEN", true);
            binding.Format += new ConvertEventHandler(this.m_BaseMethods.BooleanFormat);
            binding.Parse += new ConvertEventHandler(this.m_BaseMethods.BooleanParse);
            if (this.checkDOSOZNACEN.DataBindings["CheckState"] != null)
            {
                this.checkDOSOZNACEN.DataBindings.Remove(this.checkDOSOZNACEN.DataBindings["CheckState"]);
            }
            this.checkDOSOZNACEN.DataBindings.Add(binding);
            if (!this.m_DataGrids.Contains(this.grdLevelDOSIPZAGLAVLJELevel1))
            {
                this.m_DataGrids.Add(this.grdLevelDOSIPZAGLAVLJELevel1);
            }
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = this.dsDOSIPZAGLAVLJEDataSet1.DOSIPZAGLAVLJE[0];
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.m_CurrentRow = (DOSIPZAGLAVLJEDataSet.DOSIPZAGLAVLJERow) ((DataRowView) this.bindingSourceDOSIPZAGLAVLJE.AddNew()).Row;
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
            ResourceManager manager = new ResourceManager(typeof(DOSIPZAGLAVLJEFormUserControl));
            this.contextMenu1 = new ContextMenu();
            this.SetNullItem = new MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new ErrorProvider();
            this.errorProviderValidator1 = new ErrorProviderValidator(this.components);
            this.bindingSourceDOSIPZAGLAVLJE = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceDOSIPZAGLAVLJE).BeginInit();
            this.bindingSourceDOSIPZAGLAVLJELevel1 = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceDOSIPZAGLAVLJELevel1).BeginInit();
            this.layoutManagerformDOSIPZAGLAVLJE = new TableLayoutPanel();
            this.layoutManagerformDOSIPZAGLAVLJE.SuspendLayout();
            this.layoutManagerformDOSIPZAGLAVLJE.AutoSize = true;
            this.layoutManagerformDOSIPZAGLAVLJE.Dock = DockStyle.Fill;
            this.layoutManagerformDOSIPZAGLAVLJE.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformDOSIPZAGLAVLJE.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformDOSIPZAGLAVLJE.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformDOSIPZAGLAVLJE.Size = size;
            this.layoutManagerformDOSIPZAGLAVLJE.ColumnCount = 2;
            this.layoutManagerformDOSIPZAGLAVLJE.RowCount = 6;
            this.layoutManagerformDOSIPZAGLAVLJE.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformDOSIPZAGLAVLJE.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformDOSIPZAGLAVLJE.RowStyles.Add(new RowStyle());
            this.layoutManagerformDOSIPZAGLAVLJE.RowStyles.Add(new RowStyle());
            this.layoutManagerformDOSIPZAGLAVLJE.RowStyles.Add(new RowStyle());
            this.layoutManagerformDOSIPZAGLAVLJE.RowStyles.Add(new RowStyle());
            this.layoutManagerformDOSIPZAGLAVLJE.RowStyles.Add(new RowStyle());
            this.layoutManagerformDOSIPZAGLAVLJE.RowStyles.Add(new RowStyle());
            this.label1DOSIPIDENT = new UltraLabel();
            this.textDOSIPIDENT = new UltraTextEditor();
            this.label1DOSJMBG = new UltraLabel();
            this.textDOSJMBG = new UltraTextEditor();
            this.label1DOSISPLATAUGODINI = new UltraLabel();
            this.textDOSISPLATAUGODINI = new UltraTextEditor();
            this.label1DOSISPLATAZAGODINU = new UltraLabel();
            this.textDOSISPLATAZAGODINU = new UltraTextEditor();
            this.label1DOSOZNACEN = new UltraLabel();
            this.checkDOSOZNACEN = new UltraCheckEditor();
            this.grdLevelDOSIPZAGLAVLJELevel1 = new UltraGrid();
            ((ISupportInitialize) this.textDOSIPIDENT).BeginInit();
            ((ISupportInitialize) this.textDOSJMBG).BeginInit();
            ((ISupportInitialize) this.textDOSISPLATAUGODINI).BeginInit();
            ((ISupportInitialize) this.textDOSISPLATAZAGODINU).BeginInit();
            ((ISupportInitialize) this.grdLevelDOSIPZAGLAVLJELevel1).BeginInit();
            UltraGridBand band = new UltraGridBand("DOSIPZAGLAVLJELevel1", -1);
            UltraGridColumn column3 = new UltraGridColumn("DOSIPIDENT");
            UltraGridColumn column4 = new UltraGridColumn("DOSJMBG");
            UltraGridColumn column5 = new UltraGridColumn("DOSMJESECISPLATE");
            UltraGridColumn column2 = new UltraGridColumn("DOSIDOPCINESTANOVANJA");
            UltraGridColumn column8 = new UltraGridColumn("DOSUKUPNOBRUTO");
            UltraGridColumn column9 = new UltraGridColumn("DOSUKUPNODOPRINOSI");
            UltraGridColumn column11 = new UltraGridColumn("DOSUKUPNOOLAKSICE");
            UltraGridColumn column = new UltraGridColumn("DOSDOHODAK");
            UltraGridColumn column12 = new UltraGridColumn("DOSUKUPNOOO");
            UltraGridColumn column6 = new UltraGridColumn("DOSPOREZNAOSNOVICA");
            UltraGridColumn column13 = new UltraGridColumn("DOSUKUPNOPOREZIPRIREZ");
            UltraGridColumn column10 = new UltraGridColumn("DOSUKUPNONETOISPLATA");
            UltraGridColumn column7 = new UltraGridColumn("DOSPOSEBANPOREZ");
            this.dsDOSIPZAGLAVLJEDataSet1 = new DOSIPZAGLAVLJEDataSet();
            this.dsDOSIPZAGLAVLJEDataSet1.BeginInit();
            this.SuspendLayout();
            this.dsDOSIPZAGLAVLJEDataSet1.DataSetName = "dsDOSIPZAGLAVLJE";
            this.dsDOSIPZAGLAVLJEDataSet1.Locale = new CultureInfo("hr-HR");
            this.bindingSourceDOSIPZAGLAVLJE.DataSource = this.dsDOSIPZAGLAVLJEDataSet1;
            this.bindingSourceDOSIPZAGLAVLJE.DataMember = "DOSIPZAGLAVLJE";
            ((ISupportInitialize) this.bindingSourceDOSIPZAGLAVLJE).BeginInit();
            this.bindingSourceDOSIPZAGLAVLJELevel1.DataSource = this.bindingSourceDOSIPZAGLAVLJE;
            this.bindingSourceDOSIPZAGLAVLJELevel1.DataMember = "DOSIPZAGLAVLJE_DOSIPZAGLAVLJELevel1";
            point = new System.Drawing.Point(0, 0);
            this.label1DOSIPIDENT.Location = point;
            this.label1DOSIPIDENT.Name = "label1DOSIPIDENT";
            this.label1DOSIPIDENT.TabIndex = 1;
            this.label1DOSIPIDENT.Tag = "labelDOSIPIDENT";
            this.label1DOSIPIDENT.Text = "DOSIPIDENT:";
            this.label1DOSIPIDENT.StyleSetName = "FieldUltraLabel";
            this.label1DOSIPIDENT.AutoSize = true;
            this.label1DOSIPIDENT.Anchor = AnchorStyles.Left;
            this.label1DOSIPIDENT.Appearance.TextVAlign = VAlign.Middle;
            this.label1DOSIPIDENT.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1DOSIPIDENT.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1DOSIPIDENT.ImageSize = size;
            this.label1DOSIPIDENT.Appearance.ForeColor = Color.Black;
            this.label1DOSIPIDENT.BackColor = Color.Transparent;
            this.layoutManagerformDOSIPZAGLAVLJE.Controls.Add(this.label1DOSIPIDENT, 0, 0);
            this.layoutManagerformDOSIPZAGLAVLJE.SetColumnSpan(this.label1DOSIPIDENT, 1);
            this.layoutManagerformDOSIPZAGLAVLJE.SetRowSpan(this.label1DOSIPIDENT, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1DOSIPIDENT.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1DOSIPIDENT.MinimumSize = size;
            size = new System.Drawing.Size(0x61, 0x17);
            this.label1DOSIPIDENT.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textDOSIPIDENT.Location = point;
            this.textDOSIPIDENT.Name = "textDOSIPIDENT";
            this.textDOSIPIDENT.Tag = "DOSIPIDENT";
            this.textDOSIPIDENT.TabIndex = 0;
            this.textDOSIPIDENT.Anchor = AnchorStyles.Left;
            this.textDOSIPIDENT.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textDOSIPIDENT.ReadOnly = false;
            this.textDOSIPIDENT.DataBindings.Add(new Binding("Text", this.bindingSourceDOSIPZAGLAVLJE, "DOSIPIDENT"));
            this.textDOSIPIDENT.MaxLength = 2;
            this.layoutManagerformDOSIPZAGLAVLJE.Controls.Add(this.textDOSIPIDENT, 1, 0);
            this.layoutManagerformDOSIPZAGLAVLJE.SetColumnSpan(this.textDOSIPIDENT, 1);
            this.layoutManagerformDOSIPZAGLAVLJE.SetRowSpan(this.textDOSIPIDENT, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textDOSIPIDENT.Margin = padding;
            size = new System.Drawing.Size(30, 0x16);
            this.textDOSIPIDENT.MinimumSize = size;
            size = new System.Drawing.Size(30, 0x16);
            this.textDOSIPIDENT.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1DOSJMBG.Location = point;
            this.label1DOSJMBG.Name = "label1DOSJMBG";
            this.label1DOSJMBG.TabIndex = 1;
            this.label1DOSJMBG.Tag = "labelDOSJMBG";
            this.label1DOSJMBG.Text = "DOSJMBG:";
            this.label1DOSJMBG.StyleSetName = "FieldUltraLabel";
            this.label1DOSJMBG.AutoSize = true;
            this.label1DOSJMBG.Anchor = AnchorStyles.Left;
            this.label1DOSJMBG.Appearance.TextVAlign = VAlign.Middle;
            this.label1DOSJMBG.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1DOSJMBG.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1DOSJMBG.ImageSize = size;
            this.label1DOSJMBG.Appearance.ForeColor = Color.Black;
            this.label1DOSJMBG.BackColor = Color.Transparent;
            this.layoutManagerformDOSIPZAGLAVLJE.Controls.Add(this.label1DOSJMBG, 0, 1);
            this.layoutManagerformDOSIPZAGLAVLJE.SetColumnSpan(this.label1DOSJMBG, 1);
            this.layoutManagerformDOSIPZAGLAVLJE.SetRowSpan(this.label1DOSJMBG, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1DOSJMBG.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1DOSJMBG.MinimumSize = size;
            size = new System.Drawing.Size(0x4e, 0x17);
            this.label1DOSJMBG.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textDOSJMBG.Location = point;
            this.textDOSJMBG.Name = "textDOSJMBG";
            this.textDOSJMBG.Tag = "DOSJMBG";
            this.textDOSJMBG.TabIndex = 0;
            this.textDOSJMBG.Anchor = AnchorStyles.Left;
            this.textDOSJMBG.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textDOSJMBG.ReadOnly = false;
            this.textDOSJMBG.DataBindings.Add(new Binding("Text", this.bindingSourceDOSIPZAGLAVLJE, "DOSJMBG"));
            this.textDOSJMBG.MaxLength = 13;
            this.layoutManagerformDOSIPZAGLAVLJE.Controls.Add(this.textDOSJMBG, 1, 1);
            this.layoutManagerformDOSIPZAGLAVLJE.SetColumnSpan(this.textDOSJMBG, 1);
            this.layoutManagerformDOSIPZAGLAVLJE.SetRowSpan(this.textDOSJMBG, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textDOSJMBG.Margin = padding;
            size = new System.Drawing.Size(0x6b, 0x16);
            this.textDOSJMBG.MinimumSize = size;
            size = new System.Drawing.Size(0x6b, 0x16);
            this.textDOSJMBG.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1DOSISPLATAUGODINI.Location = point;
            this.label1DOSISPLATAUGODINI.Name = "label1DOSISPLATAUGODINI";
            this.label1DOSISPLATAUGODINI.TabIndex = 1;
            this.label1DOSISPLATAUGODINI.Tag = "labelDOSISPLATAUGODINI";
            this.label1DOSISPLATAUGODINI.Text = "DOSISPLATAUGODINI:";
            this.label1DOSISPLATAUGODINI.StyleSetName = "FieldUltraLabel";
            this.label1DOSISPLATAUGODINI.AutoSize = true;
            this.label1DOSISPLATAUGODINI.Anchor = AnchorStyles.Left;
            this.label1DOSISPLATAUGODINI.Appearance.TextVAlign = VAlign.Middle;
            this.label1DOSISPLATAUGODINI.Appearance.ForeColor = Color.Black;
            this.label1DOSISPLATAUGODINI.BackColor = Color.Transparent;
            this.layoutManagerformDOSIPZAGLAVLJE.Controls.Add(this.label1DOSISPLATAUGODINI, 0, 2);
            this.layoutManagerformDOSIPZAGLAVLJE.SetColumnSpan(this.label1DOSISPLATAUGODINI, 1);
            this.layoutManagerformDOSIPZAGLAVLJE.SetRowSpan(this.label1DOSISPLATAUGODINI, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1DOSISPLATAUGODINI.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1DOSISPLATAUGODINI.MinimumSize = size;
            size = new System.Drawing.Size(0x9e, 0x17);
            this.label1DOSISPLATAUGODINI.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textDOSISPLATAUGODINI.Location = point;
            this.textDOSISPLATAUGODINI.Name = "textDOSISPLATAUGODINI";
            this.textDOSISPLATAUGODINI.Tag = "DOSISPLATAUGODINI";
            this.textDOSISPLATAUGODINI.TabIndex = 0;
            this.textDOSISPLATAUGODINI.Anchor = AnchorStyles.Left;
            this.textDOSISPLATAUGODINI.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textDOSISPLATAUGODINI.ReadOnly = false;
            this.textDOSISPLATAUGODINI.DataBindings.Add(new Binding("Text", this.bindingSourceDOSIPZAGLAVLJE, "DOSISPLATAUGODINI"));
            this.textDOSISPLATAUGODINI.MaxLength = 4;
            this.layoutManagerformDOSIPZAGLAVLJE.Controls.Add(this.textDOSISPLATAUGODINI, 1, 2);
            this.layoutManagerformDOSIPZAGLAVLJE.SetColumnSpan(this.textDOSISPLATAUGODINI, 1);
            this.layoutManagerformDOSIPZAGLAVLJE.SetRowSpan(this.textDOSISPLATAUGODINI, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textDOSISPLATAUGODINI.Margin = padding;
            size = new System.Drawing.Size(0x2c, 0x16);
            this.textDOSISPLATAUGODINI.MinimumSize = size;
            size = new System.Drawing.Size(0x2c, 0x16);
            this.textDOSISPLATAUGODINI.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1DOSISPLATAZAGODINU.Location = point;
            this.label1DOSISPLATAZAGODINU.Name = "label1DOSISPLATAZAGODINU";
            this.label1DOSISPLATAZAGODINU.TabIndex = 1;
            this.label1DOSISPLATAZAGODINU.Tag = "labelDOSISPLATAZAGODINU";
            this.label1DOSISPLATAZAGODINU.Text = "DOSISPLATAZAGODINU:";
            this.label1DOSISPLATAZAGODINU.StyleSetName = "FieldUltraLabel";
            this.label1DOSISPLATAZAGODINU.AutoSize = true;
            this.label1DOSISPLATAZAGODINU.Anchor = AnchorStyles.Left;
            this.label1DOSISPLATAZAGODINU.Appearance.TextVAlign = VAlign.Middle;
            this.label1DOSISPLATAZAGODINU.Appearance.ForeColor = Color.Black;
            this.label1DOSISPLATAZAGODINU.BackColor = Color.Transparent;
            this.layoutManagerformDOSIPZAGLAVLJE.Controls.Add(this.label1DOSISPLATAZAGODINU, 0, 3);
            this.layoutManagerformDOSIPZAGLAVLJE.SetColumnSpan(this.label1DOSISPLATAZAGODINU, 1);
            this.layoutManagerformDOSIPZAGLAVLJE.SetRowSpan(this.label1DOSISPLATAZAGODINU, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1DOSISPLATAZAGODINU.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1DOSISPLATAZAGODINU.MinimumSize = size;
            size = new System.Drawing.Size(0xa8, 0x17);
            this.label1DOSISPLATAZAGODINU.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textDOSISPLATAZAGODINU.Location = point;
            this.textDOSISPLATAZAGODINU.Name = "textDOSISPLATAZAGODINU";
            this.textDOSISPLATAZAGODINU.Tag = "DOSISPLATAZAGODINU";
            this.textDOSISPLATAZAGODINU.TabIndex = 0;
            this.textDOSISPLATAZAGODINU.Anchor = AnchorStyles.Left;
            this.textDOSISPLATAZAGODINU.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textDOSISPLATAZAGODINU.ReadOnly = false;
            this.textDOSISPLATAZAGODINU.DataBindings.Add(new Binding("Text", this.bindingSourceDOSIPZAGLAVLJE, "DOSISPLATAZAGODINU"));
            this.textDOSISPLATAZAGODINU.MaxLength = 4;
            this.layoutManagerformDOSIPZAGLAVLJE.Controls.Add(this.textDOSISPLATAZAGODINU, 1, 3);
            this.layoutManagerformDOSIPZAGLAVLJE.SetColumnSpan(this.textDOSISPLATAZAGODINU, 1);
            this.layoutManagerformDOSIPZAGLAVLJE.SetRowSpan(this.textDOSISPLATAZAGODINU, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textDOSISPLATAZAGODINU.Margin = padding;
            size = new System.Drawing.Size(0x2c, 0x16);
            this.textDOSISPLATAZAGODINU.MinimumSize = size;
            size = new System.Drawing.Size(0x2c, 0x16);
            this.textDOSISPLATAZAGODINU.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1DOSOZNACEN.Location = point;
            this.label1DOSOZNACEN.Name = "label1DOSOZNACEN";
            this.label1DOSOZNACEN.TabIndex = 1;
            this.label1DOSOZNACEN.Tag = "labelDOSOZNACEN";
            this.label1DOSOZNACEN.Text = "DOSOZNACEN:";
            this.label1DOSOZNACEN.StyleSetName = "FieldUltraLabel";
            this.label1DOSOZNACEN.AutoSize = true;
            this.label1DOSOZNACEN.Anchor = AnchorStyles.Left;
            this.label1DOSOZNACEN.Appearance.TextVAlign = VAlign.Middle;
            this.label1DOSOZNACEN.Appearance.ForeColor = Color.Black;
            this.label1DOSOZNACEN.BackColor = Color.Transparent;
            this.layoutManagerformDOSIPZAGLAVLJE.Controls.Add(this.label1DOSOZNACEN, 0, 4);
            this.layoutManagerformDOSIPZAGLAVLJE.SetColumnSpan(this.label1DOSOZNACEN, 1);
            this.layoutManagerformDOSIPZAGLAVLJE.SetRowSpan(this.label1DOSOZNACEN, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1DOSOZNACEN.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1DOSOZNACEN.MinimumSize = size;
            size = new System.Drawing.Size(0x6a, 0x17);
            this.label1DOSOZNACEN.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.checkDOSOZNACEN.Location = point;
            this.checkDOSOZNACEN.Name = "checkDOSOZNACEN";
            this.checkDOSOZNACEN.Tag = "DOSOZNACEN";
            this.checkDOSOZNACEN.TabIndex = 0;
            this.checkDOSOZNACEN.Anchor = AnchorStyles.Left;
            this.checkDOSOZNACEN.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.checkDOSOZNACEN.Enabled = true;
            this.layoutManagerformDOSIPZAGLAVLJE.Controls.Add(this.checkDOSOZNACEN, 1, 4);
            this.layoutManagerformDOSIPZAGLAVLJE.SetColumnSpan(this.checkDOSOZNACEN, 1);
            this.layoutManagerformDOSIPZAGLAVLJE.SetRowSpan(this.checkDOSOZNACEN, 1);
            padding = new Padding(0, 1, 3, 2);
            this.checkDOSOZNACEN.Margin = padding;
            size = new System.Drawing.Size(13, 13);
            this.checkDOSOZNACEN.MinimumSize = size;
            size = new System.Drawing.Size(13, 13);
            this.checkDOSOZNACEN.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.grdLevelDOSIPZAGLAVLJELevel1.Location = point;
            this.grdLevelDOSIPZAGLAVLJELevel1.Name = "grdLevelDOSIPZAGLAVLJELevel1";
            this.layoutManagerformDOSIPZAGLAVLJE.Controls.Add(this.grdLevelDOSIPZAGLAVLJELevel1, 0, 5);
            this.layoutManagerformDOSIPZAGLAVLJE.SetColumnSpan(this.grdLevelDOSIPZAGLAVLJELevel1, 2);
            this.layoutManagerformDOSIPZAGLAVLJE.SetRowSpan(this.grdLevelDOSIPZAGLAVLJELevel1, 1);
            padding = new Padding(5, 10, 5, 10);
            this.grdLevelDOSIPZAGLAVLJELevel1.Margin = padding;
            size = new System.Drawing.Size(100, 100);
            this.grdLevelDOSIPZAGLAVLJELevel1.MinimumSize = size;
            size = new System.Drawing.Size(750, 200);
            this.grdLevelDOSIPZAGLAVLJELevel1.Size = size;
            this.grdLevelDOSIPZAGLAVLJELevel1.Dock = DockStyle.Fill;
            this.Controls.Add(this.layoutManagerformDOSIPZAGLAVLJE);
            this.SetNullItem.Index = 0;
            this.SetNullItem.Text = "Set Null";
            this.SetNullItem.Click += new EventHandler(this.SetNullItem_Click);
            this.contextMenu1.Popup += new EventHandler(this.contextMenu1_Popup);
            this.contextMenu1.MenuItems.AddRange(new MenuItem[] { this.SetNullItem });
            this.errorProvider1.DataSource = this.bindingSourceDOSIPZAGLAVLJE;
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            column3.CellActivation = Activation.Disabled;
            column3.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column3.Header.Caption = StringResources.DOSIPZAGLAVLJEDOSIPIDENTDescription;
            column3.Width = 0x56;
            column3.Format = "";
            column3.CellAppearance = appearance3;
            column3.Hidden = true;
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            column4.CellActivation = Activation.Disabled;
            column4.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column4.Header.Caption = StringResources.DOSIPZAGLAVLJEDOSJMBGDescription;
            column4.Width = 0x6b;
            column4.Format = "";
            column4.CellAppearance = appearance4;
            column4.Hidden = true;
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            column5.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column5.Header.Caption = StringResources.DOSIPZAGLAVLJEDOSMJESECISPLATEDescription;
            column5.Width = 0x80;
            column5.Format = "";
            column5.CellAppearance = appearance5;
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.DOSIPZAGLAVLJEDOSIDOPCINESTANOVANJADescription;
            column2.Width = 0xa3;
            column2.Format = "";
            column2.CellAppearance = appearance2;
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            column8.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column8.Header.Caption = StringResources.DOSIPZAGLAVLJEDOSUKUPNOBRUTODescription;
            column8.Width = 0x74;
            appearance8.TextHAlign = HAlign.Right;
            column8.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column8.PromptChar = ' ';
            column8.Format = "F2";
            column8.CellAppearance = appearance8;
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            column9.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column9.Header.Caption = StringResources.DOSIPZAGLAVLJEDOSUKUPNODOPRINOSIDescription;
            column9.Width = 0x8f;
            appearance9.TextHAlign = HAlign.Right;
            column9.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column9.PromptChar = ' ';
            column9.Format = "F2";
            column9.CellAppearance = appearance9;
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            column11.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column11.Header.Caption = StringResources.DOSIPZAGLAVLJEDOSUKUPNOOLAKSICEDescription;
            column11.Width = 0x88;
            appearance11.TextHAlign = HAlign.Right;
            column11.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column11.PromptChar = ' ';
            column11.Format = "F2";
            column11.CellAppearance = appearance11;
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.DOSIPZAGLAVLJEDOSDOHODAKDescription;
            column.Width = 0x66;
            appearance.TextHAlign = HAlign.Right;
            column.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column.PromptChar = ' ';
            column.Format = "F2";
            column.CellAppearance = appearance;
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            column12.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column12.Header.Caption = StringResources.DOSIPZAGLAVLJEDOSUKUPNOOODescription;
            column12.Width = 0x66;
            appearance12.TextHAlign = HAlign.Right;
            column12.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column12.PromptChar = ' ';
            column12.Format = "F2";
            column12.CellAppearance = appearance12;
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            column6.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column6.Header.Caption = StringResources.DOSIPZAGLAVLJEDOSPOREZNAOSNOVICADescription;
            column6.Width = 0x8f;
            appearance6.TextHAlign = HAlign.Right;
            column6.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column6.PromptChar = ' ';
            column6.Format = "F2";
            column6.CellAppearance = appearance6;
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            column13.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column13.Header.Caption = StringResources.DOSIPZAGLAVLJEDOSUKUPNOPOREZIPRIREZDescription;
            column13.Width = 0xa3;
            appearance13.TextHAlign = HAlign.Right;
            column13.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column13.PromptChar = ' ';
            column13.Format = "F2";
            column13.CellAppearance = appearance13;
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            column10.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column10.Header.Caption = StringResources.DOSIPZAGLAVLJEDOSUKUPNONETOISPLATADescription;
            column10.Width = 0x9c;
            appearance10.TextHAlign = HAlign.Right;
            column10.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column10.PromptChar = ' ';
            column10.Format = "F2";
            column10.CellAppearance = appearance10;
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            column7.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column7.Header.Caption = StringResources.DOSIPZAGLAVLJEDOSPOSEBANPOREZDescription;
            column7.Width = 0x7b;
            appearance7.TextHAlign = HAlign.Right;
            column7.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column7.PromptChar = ' ';
            column7.Format = "F2";
            column7.CellAppearance = appearance7;
            band.Columns.Add(column5);
            column5.Header.VisiblePosition = 0;
            band.Columns.Add(column2);
            column2.Header.VisiblePosition = 1;
            band.Columns.Add(column8);
            column8.Header.VisiblePosition = 2;
            band.Columns.Add(column9);
            column9.Header.VisiblePosition = 3;
            band.Columns.Add(column11);
            column11.Header.VisiblePosition = 4;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 5;
            band.Columns.Add(column12);
            column12.Header.VisiblePosition = 6;
            band.Columns.Add(column6);
            column6.Header.VisiblePosition = 7;
            band.Columns.Add(column13);
            column13.Header.VisiblePosition = 8;
            band.Columns.Add(column10);
            column10.Header.VisiblePosition = 9;
            band.Columns.Add(column7);
            column7.Header.VisiblePosition = 10;
            band.Columns.Add(column3);
            column3.Header.VisiblePosition = 11;
            band.Columns.Add(column4);
            column4.Header.VisiblePosition = 12;
            this.grdLevelDOSIPZAGLAVLJELevel1.Visible = true;
            this.grdLevelDOSIPZAGLAVLJELevel1.Name = "grdLevelDOSIPZAGLAVLJELevel1";
            this.grdLevelDOSIPZAGLAVLJELevel1.Tag = "DOSIPZAGLAVLJELevel1";
            this.grdLevelDOSIPZAGLAVLJELevel1.TabIndex = 11;
            this.grdLevelDOSIPZAGLAVLJELevel1.Dock = DockStyle.Fill;
            this.grdLevelDOSIPZAGLAVLJELevel1.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.grdLevelDOSIPZAGLAVLJELevel1.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.grdLevelDOSIPZAGLAVLJELevel1.DataSource = this.bindingSourceDOSIPZAGLAVLJELevel1;
            this.grdLevelDOSIPZAGLAVLJELevel1.Enter += new EventHandler(this.grdLevelDOSIPZAGLAVLJELevel1_Enter);
            this.grdLevelDOSIPZAGLAVLJELevel1.AfterRowInsert += new RowEventHandler(this.grdLevelDOSIPZAGLAVLJELevel1_AfterRowInsert);
            this.grdLevelDOSIPZAGLAVLJELevel1.AfterCellActivate += new EventHandler(this.CellChanged);
            this.grdLevelDOSIPZAGLAVLJELevel1.ClickCellButton += new CellEventHandler(this.dg_ClickCellButton);
            this.grdLevelDOSIPZAGLAVLJELevel1.DisplayLayout.Override.AllowAddNew = AllowAddNew.TemplateOnBottom;
            this.grdLevelDOSIPZAGLAVLJELevel1.DisplayLayout.BandsSerializer.Add(band);
            this.Name = "DOSIPZAGLAVLJEFormUserControl";
            this.Text = "DOSIPZAGLAVLJE";
            this.AutoSize = true;
            this.AutoScroll = true;
            this.Load += new EventHandler(this.DOSIPZAGLAVLJEFormUserControl_Load);
            this.layoutManagerformDOSIPZAGLAVLJE.ResumeLayout(false);
            this.layoutManagerformDOSIPZAGLAVLJE.PerformLayout();
            ((ISupportInitialize) this.bindingSourceDOSIPZAGLAVLJE).EndInit();
            ((ISupportInitialize) this.bindingSourceDOSIPZAGLAVLJELevel1).EndInit();
            ((ISupportInitialize) this.textDOSIPIDENT).EndInit();
            ((ISupportInitialize) this.textDOSJMBG).EndInit();
            ((ISupportInitialize) this.textDOSISPLATAUGODINI).EndInit();
            ((ISupportInitialize) this.textDOSISPLATAZAGODINU).EndInit();
            ((ISupportInitialize) this.grdLevelDOSIPZAGLAVLJELevel1).EndInit();
            this.dsDOSIPZAGLAVLJEDataSet1.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private bool InValidState()
        {
            if ((this.DOSIPZAGLAVLJEController.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourceDOSIPZAGLAVLJE, this.DOSIPZAGLAVLJEController.WorkItem, this))
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

        private void Localize()
        {
            this.label1DOSIPIDENT.Text = StringResources.DOSIPZAGLAVLJEDOSIPIDENTDescription;
            this.label1DOSJMBG.Text = StringResources.DOSIPZAGLAVLJEDOSJMBGDescription;
            this.label1DOSISPLATAUGODINI.Text = StringResources.DOSIPZAGLAVLJEDOSISPLATAUGODINIDescription;
            this.label1DOSISPLATAZAGODINU.Text = StringResources.DOSIPZAGLAVLJEDOSISPLATAZAGODINUDescription;
            this.label1DOSOZNACEN.Text = StringResources.DOSIPZAGLAVLJEDOSOZNACENDescription;
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
            if (!this.DOSIPZAGLAVLJEController.WorkItem.Items.Contains("DOSIPZAGLAVLJE|DOSIPZAGLAVLJE"))
            {
                this.DOSIPZAGLAVLJEController.WorkItem.Items.Add(this.bindingSourceDOSIPZAGLAVLJE, "DOSIPZAGLAVLJE|DOSIPZAGLAVLJE");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        public void ResumeBindingPostUpdate()
        {
            if ((this.dsDOSIPZAGLAVLJEDataSet1.DOSIPZAGLAVLJE.Rows[0] != null) && this.m_BaseMethods.IsInsert())
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
                this.DOSIPZAGLAVLJEController.Update(this);
            }
        }

        [LocalCommandHandler("SaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (this.InValidState() && this.DOSIPZAGLAVLJEController.Update(this))
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [LocalCommandHandler("SaveAndNew")]
        public void SaveAndNew(object sender, EventArgs e)
        {
            if (this.InValidState() && this.DOSIPZAGLAVLJEController.Update(this))
            {
                this.DOSIPZAGLAVLJEController.DataSet = new DOSIPZAGLAVLJEDataSet();
                DataSetUtil.AddEmptyRow(this.DOSIPZAGLAVLJEController.DataSet);
                this.ChangeBinding();
                this.m_CurrentRow = this.DOSIPZAGLAVLJEController.DataSet.DOSIPZAGLAVLJE[0];
                DataSetUtil.CopyForeignKeyValues(this.m_CurrentRow, this.m_ForeignKeys);
                this.SetFocusInFirstField();
            }
        }

        private void SetFocusInFirstField()
        {
            this.textDOSIPIDENT.Focus();
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

        protected virtual UltraCheckEditor checkDOSOZNACEN
        {
            [DebuggerNonUserCode]
            get
            {
                return this._checkDOSOZNACEN;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._checkDOSOZNACEN = value;
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

        [Browsable(false), CreateNew]
        public NetAdvantage.Controllers.DOSIPZAGLAVLJEController DOSIPZAGLAVLJEController { get; set; }

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

        protected virtual UltraGrid grdLevelDOSIPZAGLAVLJELevel1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._grdLevelDOSIPZAGLAVLJELevel1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._grdLevelDOSIPZAGLAVLJELevel1 = value;
            }
        }

        protected virtual UltraLabel label1DOSIPIDENT
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1DOSIPIDENT;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1DOSIPIDENT = value;
            }
        }

        protected virtual UltraLabel label1DOSISPLATAUGODINI
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1DOSISPLATAUGODINI;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1DOSISPLATAUGODINI = value;
            }
        }

        protected virtual UltraLabel label1DOSISPLATAZAGODINU
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1DOSISPLATAZAGODINU;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1DOSISPLATAZAGODINU = value;
            }
        }

        protected virtual UltraLabel label1DOSJMBG
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1DOSJMBG;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1DOSJMBG = value;
            }
        }

        protected virtual UltraLabel label1DOSOZNACEN
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1DOSOZNACEN;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1DOSOZNACEN = value;
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

        protected virtual UltraTextEditor textDOSIPIDENT
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textDOSIPIDENT;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textDOSIPIDENT = value;
            }
        }

        protected virtual UltraTextEditor textDOSISPLATAUGODINI
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textDOSISPLATAUGODINI;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textDOSISPLATAUGODINI = value;
            }
        }

        protected virtual UltraTextEditor textDOSISPLATAZAGODINU
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textDOSISPLATAZAGODINU;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textDOSISPLATAZAGODINU = value;
            }
        }

        protected virtual UltraTextEditor textDOSJMBG
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textDOSJMBG;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textDOSJMBG = value;
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


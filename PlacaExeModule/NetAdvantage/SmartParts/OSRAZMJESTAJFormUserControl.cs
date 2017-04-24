namespace NetAdvantage.SmartParts
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.BuilderStrategies;
    using Deklarit.Win;
    using Infragistics.Win;
    using Infragistics.Win.Misc;
    using Infragistics.Win.UltraWinEditors;
    using Microsoft.Practices.CompositeUI;
    using Microsoft.Practices.CompositeUI.EventBroker;
    using Microsoft.Practices.CompositeUI.SmartParts;
    using Microsoft.Practices.ObjectBuilder;
    using NetAdvantage;
    using NetAdvantage.Controllers;
    using NetAdvantage.Controls;
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
    public class OSRAZMJESTAJFormUserControl : UserControl, IBusinessComponentUserControl
    {
        [AccessedThroughProperty("comboIDLOKACIJE")]
        private LOKACIJEComboBox _comboIDLOKACIJE;
        [AccessedThroughProperty("contextMenu1")]
        private ContextMenu _contextMenu1;
        [AccessedThroughProperty("errorProvider1")]
        private ErrorProvider _errorProvider1;
        [AccessedThroughProperty("errorProviderValidator1")]
        private ErrorProviderValidator _errorProviderValidator1;
        [AccessedThroughProperty("label1IDLOKACIJE")]
        private UltraLabel _label1IDLOKACIJE;
        [AccessedThroughProperty("label1INVBROJ")]
        private UltraLabel _label1INVBROJ;
        [AccessedThroughProperty("label1KOLICINARASHODA")]
        private UltraLabel _label1KOLICINARASHODA;
        [AccessedThroughProperty("label1KOLICINAULAZA")]
        private UltraLabel _label1KOLICINAULAZA;
        [AccessedThroughProperty("SetNullItem")]
        private MenuItem _SetNullItem;
        [AccessedThroughProperty("textINVBROJ")]
        private UltraNumericEditor _textINVBROJ;
        [AccessedThroughProperty("textKOLICINARASHODA")]
        private UltraNumericEditor _textKOLICINARASHODA;
        [AccessedThroughProperty("textKOLICINAULAZA")]
        private UltraNumericEditor _textKOLICINAULAZA;
        [AccessedThroughProperty("toolTip1")]
        private System.Windows.Forms.ToolTip _toolTip1;
        private BindingSource bindingSourceOSRAZMJESTAJ;
        private IContainer components = null;
        private OSRAZMJESTAJDataSet dsOSRAZMJESTAJDataSet1;
        protected TableLayoutPanel layoutManagerformOSRAZMJESTAJ;
        private bool m_AutoNumber = false;
        private GenericFormClass m_BaseMethods;
        private OSRAZMJESTAJDataSet.OSRAZMJESTAJRow m_CurrentRow;
        private ArrayList m_DataGrids = new ArrayList();
        private string m_FirstLevelName = "OSRAZMJESTAJ";
        private DataRow m_ForeignKeys;
        private string m_FrameworkDescription = StringResources.OSRAZMJESTAJDescription;
        private DeklaritMode m_Mode;

        [EventPublication("topic://NetAdvantage/OpenBusinessComponent", PublicationScope.Global)]
        public event EventHandler<OpenComponentEventArgs> StartProcess;

        public OSRAZMJESTAJFormUserControl()
        {
            this.InitializeComponent();
            this.Localize();
            this.SetSize();
        }

        private void CallPromptOSINVBROJ(object sender, EditorButtonEventArgs e)
        {
            DataRow fillByRow = null;
            string fillMethod = "";
            DataRow result = this.OSRAZMJESTAJController.SelectOSINVBROJ(fillMethod, fillByRow);
            this.UpdateValuesOSINVBROJ(result);
        }

        private void CallViewOSINVBROJ(object sender, EventArgs e)
        {
            DataRow result = this.OSRAZMJESTAJController.ShowOSINVBROJ(this.m_CurrentRow);
            this.UpdateValuesOSINVBROJ(result);
        }

        public void ChangeBinding()
        {
            this.bindingSourceOSRAZMJESTAJ.DataSource = this.OSRAZMJESTAJController.DataSet;
            this.dsOSRAZMJESTAJDataSet1 = this.OSRAZMJESTAJController.DataSet;
        }

        [LocalCommandHandler("Close")]
        public void Close(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [EventSubscription("topic://NetAdvantage/BusinessComponentUpdated/LOKACIJE", Thread=ThreadOption.UserInterface)]
        public void comboIDLOKACIJE_Add(object sender, ComponentEventArgs e)
        {
            this.comboIDLOKACIJE.Fill();
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
                    enumerator = this.dsOSRAZMJESTAJDataSet1.OSRAZMJESTAJ.Rows.GetEnumerator();
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
                if (this.OSRAZMJESTAJController.Update(this))
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

        public void Initialize(DeklaritMode mode, DataRow foreignKeys, bool isCopy)
        {
            this.ChangeBinding();
            this.m_ForeignKeys = foreignKeys;
            this.RegisterBindingSources();
            this.m_Mode = mode;
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "OSRAZMJESTAJ", this.m_Mode, this.dsOSRAZMJESTAJDataSet1, this.dsOSRAZMJESTAJDataSet1.OSRAZMJESTAJ.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = this.dsOSRAZMJESTAJDataSet1.OSRAZMJESTAJ[0];
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.m_CurrentRow = (OSRAZMJESTAJDataSet.OSRAZMJESTAJRow) ((DataRowView) this.bindingSourceOSRAZMJESTAJ.AddNew()).Row;
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
            ResourceManager manager = new ResourceManager(typeof(OSRAZMJESTAJFormUserControl));
            this.contextMenu1 = new ContextMenu();
            this.SetNullItem = new MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new ErrorProvider();
            this.errorProviderValidator1 = new ErrorProviderValidator(this.components);
            this.bindingSourceOSRAZMJESTAJ = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceOSRAZMJESTAJ).BeginInit();
            this.layoutManagerformOSRAZMJESTAJ = new TableLayoutPanel();
            this.layoutManagerformOSRAZMJESTAJ.SuspendLayout();
            this.layoutManagerformOSRAZMJESTAJ.AutoSize = true;
            this.layoutManagerformOSRAZMJESTAJ.Dock = DockStyle.Fill;
            this.layoutManagerformOSRAZMJESTAJ.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformOSRAZMJESTAJ.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformOSRAZMJESTAJ.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformOSRAZMJESTAJ.Size = size;
            this.layoutManagerformOSRAZMJESTAJ.ColumnCount = 2;
            this.layoutManagerformOSRAZMJESTAJ.RowCount = 5;
            this.layoutManagerformOSRAZMJESTAJ.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformOSRAZMJESTAJ.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformOSRAZMJESTAJ.RowStyles.Add(new RowStyle());
            this.layoutManagerformOSRAZMJESTAJ.RowStyles.Add(new RowStyle());
            this.layoutManagerformOSRAZMJESTAJ.RowStyles.Add(new RowStyle());
            this.layoutManagerformOSRAZMJESTAJ.RowStyles.Add(new RowStyle());
            this.layoutManagerformOSRAZMJESTAJ.RowStyles.Add(new RowStyle());
            this.label1IDLOKACIJE = new UltraLabel();
            this.comboIDLOKACIJE = new LOKACIJEComboBox();
            this.label1INVBROJ = new UltraLabel();
            this.textINVBROJ = new UltraNumericEditor();
            this.label1KOLICINAULAZA = new UltraLabel();
            this.textKOLICINAULAZA = new UltraNumericEditor();
            this.label1KOLICINARASHODA = new UltraLabel();
            this.textKOLICINARASHODA = new UltraNumericEditor();
            ((ISupportInitialize) this.textINVBROJ).BeginInit();
            ((ISupportInitialize) this.textKOLICINAULAZA).BeginInit();
            ((ISupportInitialize) this.textKOLICINARASHODA).BeginInit();
            this.dsOSRAZMJESTAJDataSet1 = new OSRAZMJESTAJDataSet();
            this.dsOSRAZMJESTAJDataSet1.BeginInit();
            this.SuspendLayout();
            this.dsOSRAZMJESTAJDataSet1.DataSetName = "dsOSRAZMJESTAJ";
            this.dsOSRAZMJESTAJDataSet1.Locale = new CultureInfo("hr-HR");
            this.bindingSourceOSRAZMJESTAJ.DataSource = this.dsOSRAZMJESTAJDataSet1;
            this.bindingSourceOSRAZMJESTAJ.DataMember = "OSRAZMJESTAJ";
            ((ISupportInitialize) this.bindingSourceOSRAZMJESTAJ).BeginInit();
            point = new System.Drawing.Point(0, 0);
            this.label1IDLOKACIJE.Location = point;
            this.label1IDLOKACIJE.Name = "label1IDLOKACIJE";
            this.label1IDLOKACIJE.TabIndex = 1;
            this.label1IDLOKACIJE.Tag = "labelIDLOKACIJE";
            this.label1IDLOKACIJE.Text = "Lokacija:";
            this.label1IDLOKACIJE.StyleSetName = "FieldUltraLabel";
            this.label1IDLOKACIJE.AutoSize = true;
            this.label1IDLOKACIJE.Anchor = AnchorStyles.Left;
            this.label1IDLOKACIJE.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDLOKACIJE.Appearance.ForeColor = Color.Black;
            this.label1IDLOKACIJE.BackColor = Color.Transparent;
            this.layoutManagerformOSRAZMJESTAJ.Controls.Add(this.label1IDLOKACIJE, 0, 0);
            this.layoutManagerformOSRAZMJESTAJ.SetColumnSpan(this.label1IDLOKACIJE, 1);
            this.layoutManagerformOSRAZMJESTAJ.SetRowSpan(this.label1IDLOKACIJE, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1IDLOKACIJE.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDLOKACIJE.MinimumSize = size;
            size = new System.Drawing.Size(0x47, 0x17);
            this.label1IDLOKACIJE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.comboIDLOKACIJE.Location = point;
            this.comboIDLOKACIJE.Name = "comboIDLOKACIJE";
            this.comboIDLOKACIJE.Tag = "IDLOKACIJE";
            this.comboIDLOKACIJE.TabIndex = 0;
            this.comboIDLOKACIJE.Anchor = AnchorStyles.Left;
            this.comboIDLOKACIJE.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.comboIDLOKACIJE.DropDownStyle = DropDownStyle.DropDown;
            this.comboIDLOKACIJE.ComboBox.DropDownStyle = DropDownStyle.DropDown;
            this.comboIDLOKACIJE.ComboBox.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            this.comboIDLOKACIJE.Enabled = true;
            this.comboIDLOKACIJE.DataBindings.Add(new Binding("Value", this.bindingSourceOSRAZMJESTAJ, "IDLOKACIJE"));
            this.comboIDLOKACIJE.ShowPictureBox = true;
            this.comboIDLOKACIJE.PictureBoxClicked += new EventHandler(this.PictureBoxClickedIDLOKACIJE);
            this.comboIDLOKACIJE.ValueMember = "IDLOKACIJE";
            this.comboIDLOKACIJE.SelectionChanged += new EventHandler(this.SelectedIndexChangedIDLOKACIJE);
            this.layoutManagerformOSRAZMJESTAJ.Controls.Add(this.comboIDLOKACIJE, 1, 0);
            this.layoutManagerformOSRAZMJESTAJ.SetColumnSpan(this.comboIDLOKACIJE, 1);
            this.layoutManagerformOSRAZMJESTAJ.SetRowSpan(this.comboIDLOKACIJE, 1);
            padding = new Padding(0, 1, 3, 2);
            this.comboIDLOKACIJE.Margin = padding;
            size = new System.Drawing.Size(0x1dc, 0x17);
            this.comboIDLOKACIJE.MinimumSize = size;
            size = new System.Drawing.Size(0x1dc, 0x17);
            this.comboIDLOKACIJE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1INVBROJ.Location = point;
            this.label1INVBROJ.Name = "label1INVBROJ";
            this.label1INVBROJ.TabIndex = 1;
            this.label1INVBROJ.Tag = "labelINVBROJ";
            this.label1INVBROJ.Text = "Inventarni broj:";
            this.label1INVBROJ.StyleSetName = "FieldUltraLabel";
            this.label1INVBROJ.AutoSize = true;
            this.label1INVBROJ.Anchor = AnchorStyles.Left;
            this.label1INVBROJ.Appearance.TextVAlign = VAlign.Middle;
            this.label1INVBROJ.Appearance.ForeColor = Color.Black;
            this.label1INVBROJ.BackColor = Color.Transparent;
            this.layoutManagerformOSRAZMJESTAJ.Controls.Add(this.label1INVBROJ, 0, 1);
            this.layoutManagerformOSRAZMJESTAJ.SetColumnSpan(this.label1INVBROJ, 1);
            this.layoutManagerformOSRAZMJESTAJ.SetRowSpan(this.label1INVBROJ, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1INVBROJ.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1INVBROJ.MinimumSize = size;
            size = new System.Drawing.Size(0x72, 0x17);
            this.label1INVBROJ.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textINVBROJ.Location = point;
            this.textINVBROJ.Name = "textINVBROJ";
            this.textINVBROJ.Tag = "INVBROJ";
            this.textINVBROJ.TabIndex = 0;
            this.textINVBROJ.Anchor = AnchorStyles.Left;
            this.textINVBROJ.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textINVBROJ.ReadOnly = false;
            this.textINVBROJ.PromptChar = ' ';
            this.textINVBROJ.Enter += new EventHandler(this.numericEditor_Enter);
            this.textINVBROJ.DataBindings.Add(new Binding("Value", this.bindingSourceOSRAZMJESTAJ, "INVBROJ"));
            this.textINVBROJ.NumericType = NumericType.Double;
            this.textINVBROJ.MaxValue = 79228162514264337593543950335M;
            this.textINVBROJ.MinValue = -79228162514264337593543950335M;
            this.textINVBROJ.MaskInput = "{LOC}-nnnnnnnnnnnn";
            EditorButton button = new EditorButton {
                Key = "editorButtonOSINVBROJ",
                Tag = "editorButtonOSINVBROJ",
                Text = "..."
            };
            this.textINVBROJ.ButtonsRight.Add(button);
            this.textINVBROJ.EditorButtonClick += new EditorButtonEventHandler(this.CallPromptOSINVBROJ);
            this.layoutManagerformOSRAZMJESTAJ.Controls.Add(this.textINVBROJ, 1, 1);
            this.layoutManagerformOSRAZMJESTAJ.SetColumnSpan(this.textINVBROJ, 1);
            this.layoutManagerformOSRAZMJESTAJ.SetRowSpan(this.textINVBROJ, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textINVBROJ.Margin = padding;
            size = new System.Drawing.Size(0x77, 0x16);
            this.textINVBROJ.MinimumSize = size;
            size = new System.Drawing.Size(0x77, 0x16);
            this.textINVBROJ.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1KOLICINAULAZA.Location = point;
            this.label1KOLICINAULAZA.Name = "label1KOLICINAULAZA";
            this.label1KOLICINAULAZA.TabIndex = 1;
            this.label1KOLICINAULAZA.Tag = "labelKOLICINAULAZA";
            this.label1KOLICINAULAZA.Text = "Količina ulaza:";
            this.label1KOLICINAULAZA.StyleSetName = "FieldUltraLabel";
            this.label1KOLICINAULAZA.AutoSize = true;
            this.label1KOLICINAULAZA.Anchor = AnchorStyles.Left;
            this.label1KOLICINAULAZA.Appearance.TextVAlign = VAlign.Middle;
            this.label1KOLICINAULAZA.Appearance.ForeColor = Color.Black;
            this.label1KOLICINAULAZA.BackColor = Color.Transparent;
            this.layoutManagerformOSRAZMJESTAJ.Controls.Add(this.label1KOLICINAULAZA, 0, 2);
            this.layoutManagerformOSRAZMJESTAJ.SetColumnSpan(this.label1KOLICINAULAZA, 1);
            this.layoutManagerformOSRAZMJESTAJ.SetRowSpan(this.label1KOLICINAULAZA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1KOLICINAULAZA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1KOLICINAULAZA.MinimumSize = size;
            size = new System.Drawing.Size(0x69, 0x17);
            this.label1KOLICINAULAZA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textKOLICINAULAZA.Location = point;
            this.textKOLICINAULAZA.Name = "textKOLICINAULAZA";
            this.textKOLICINAULAZA.Tag = "KOLICINAULAZA";
            this.textKOLICINAULAZA.TabIndex = 0;
            this.textKOLICINAULAZA.Anchor = AnchorStyles.Left;
            this.textKOLICINAULAZA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textKOLICINAULAZA.ReadOnly = false;
            this.textKOLICINAULAZA.PromptChar = ' ';
            this.textKOLICINAULAZA.Enter += new EventHandler(this.numericEditor_Enter);
            this.textKOLICINAULAZA.DataBindings.Add(new Binding("Value", this.bindingSourceOSRAZMJESTAJ, "KOLICINAULAZA"));
            this.textKOLICINAULAZA.NumericType = NumericType.Double;
            this.textKOLICINAULAZA.MaxValue = 79228162514264337593543950335M;
            this.textKOLICINAULAZA.MinValue = -79228162514264337593543950335M;
            this.textKOLICINAULAZA.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            this.layoutManagerformOSRAZMJESTAJ.Controls.Add(this.textKOLICINAULAZA, 1, 2);
            this.layoutManagerformOSRAZMJESTAJ.SetColumnSpan(this.textKOLICINAULAZA, 1);
            this.layoutManagerformOSRAZMJESTAJ.SetRowSpan(this.textKOLICINAULAZA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textKOLICINAULAZA.Margin = padding;
            size = new System.Drawing.Size(0x66, 0x16);
            this.textKOLICINAULAZA.MinimumSize = size;
            size = new System.Drawing.Size(0x66, 0x16);
            this.textKOLICINAULAZA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1KOLICINARASHODA.Location = point;
            this.label1KOLICINARASHODA.Name = "label1KOLICINARASHODA";
            this.label1KOLICINARASHODA.TabIndex = 1;
            this.label1KOLICINARASHODA.Tag = "labelKOLICINARASHODA";
            this.label1KOLICINARASHODA.Text = "Količina rashoda:";
            this.label1KOLICINARASHODA.StyleSetName = "FieldUltraLabel";
            this.label1KOLICINARASHODA.AutoSize = true;
            this.label1KOLICINARASHODA.Anchor = AnchorStyles.Left;
            this.label1KOLICINARASHODA.Appearance.TextVAlign = VAlign.Middle;
            this.label1KOLICINARASHODA.Appearance.ForeColor = Color.Black;
            this.label1KOLICINARASHODA.BackColor = Color.Transparent;
            this.layoutManagerformOSRAZMJESTAJ.Controls.Add(this.label1KOLICINARASHODA, 0, 3);
            this.layoutManagerformOSRAZMJESTAJ.SetColumnSpan(this.label1KOLICINARASHODA, 1);
            this.layoutManagerformOSRAZMJESTAJ.SetRowSpan(this.label1KOLICINARASHODA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1KOLICINARASHODA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1KOLICINARASHODA.MinimumSize = size;
            size = new System.Drawing.Size(0x7a, 0x17);
            this.label1KOLICINARASHODA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textKOLICINARASHODA.Location = point;
            this.textKOLICINARASHODA.Name = "textKOLICINARASHODA";
            this.textKOLICINARASHODA.Tag = "KOLICINARASHODA";
            this.textKOLICINARASHODA.TabIndex = 0;
            this.textKOLICINARASHODA.Anchor = AnchorStyles.Left;
            this.textKOLICINARASHODA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textKOLICINARASHODA.ReadOnly = false;
            this.textKOLICINARASHODA.PromptChar = ' ';
            this.textKOLICINARASHODA.Enter += new EventHandler(this.numericEditor_Enter);
            this.textKOLICINARASHODA.DataBindings.Add(new Binding("Value", this.bindingSourceOSRAZMJESTAJ, "KOLICINARASHODA"));
            this.textKOLICINARASHODA.NumericType = NumericType.Double;
            this.textKOLICINARASHODA.MaxValue = 79228162514264337593543950335M;
            this.textKOLICINARASHODA.MinValue = -79228162514264337593543950335M;
            this.textKOLICINARASHODA.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            this.layoutManagerformOSRAZMJESTAJ.Controls.Add(this.textKOLICINARASHODA, 1, 3);
            this.layoutManagerformOSRAZMJESTAJ.SetColumnSpan(this.textKOLICINARASHODA, 1);
            this.layoutManagerformOSRAZMJESTAJ.SetRowSpan(this.textKOLICINARASHODA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textKOLICINARASHODA.Margin = padding;
            size = new System.Drawing.Size(0x66, 0x16);
            this.textKOLICINARASHODA.MinimumSize = size;
            size = new System.Drawing.Size(0x66, 0x16);
            this.textKOLICINARASHODA.Size = size;
            this.Controls.Add(this.layoutManagerformOSRAZMJESTAJ);
            this.SetNullItem.Index = 0;
            this.SetNullItem.Text = "Set Null";
            this.SetNullItem.Click += new EventHandler(this.SetNullItem_Click);
            this.contextMenu1.Popup += new EventHandler(this.contextMenu1_Popup);
            this.contextMenu1.MenuItems.AddRange(new MenuItem[] { this.SetNullItem });
            this.errorProvider1.DataSource = this.bindingSourceOSRAZMJESTAJ;
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            this.Name = "OSRAZMJESTAJFormUserControl";
            this.Text = "OSRAZMJESTAJ";
            this.AutoSize = true;
            this.AutoScroll = true;
            this.Load += new EventHandler(this.OSRAZMJESTAJFormUserControl_Load);
            this.layoutManagerformOSRAZMJESTAJ.ResumeLayout(false);
            this.layoutManagerformOSRAZMJESTAJ.PerformLayout();
            ((ISupportInitialize) this.bindingSourceOSRAZMJESTAJ).EndInit();
            ((ISupportInitialize) this.textINVBROJ).EndInit();
            ((ISupportInitialize) this.textKOLICINAULAZA).EndInit();
            ((ISupportInitialize) this.textKOLICINARASHODA).EndInit();
            this.dsOSRAZMJESTAJDataSet1.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private bool InValidState()
        {
            if ((this.OSRAZMJESTAJController.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourceOSRAZMJESTAJ, this.OSRAZMJESTAJController.WorkItem, this))
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
            this.label1IDLOKACIJE.Text = StringResources.OSRAZMJESTAJIDLOKACIJEDescription;
            this.label1INVBROJ.Text = StringResources.OSRAZMJESTAJINVBROJDescription;
            this.label1KOLICINAULAZA.Text = StringResources.OSRAZMJESTAJKOLICINAULAZADescription;
            this.label1KOLICINARASHODA.Text = StringResources.OSRAZMJESTAJKOLICINARASHODADescription;
        }

        private void mouseEnter_Text(object sender, EventArgs e)
        {
            this.m_BaseMethods.MouseEnterTextBase(this.toolTip1, this.m_CurrentRow, RuntimeHelpers.GetObjectValue(sender));
        }

        private void numericEditor_Enter(object sender, EventArgs e)
        {
            ((UltraNumericEditor) sender).SelectAll();
        }

        private void OSRAZMJESTAJFormUserControl_Load(object sender, EventArgs e)
        {
            this.Text = StringResources.OSRAZMJESTAJDescription;
            this.errorProvider1.ContainerControl = this;
        }

        private void PictureBoxClickedIDLOKACIJE(object sender, EventArgs e)
        {
            EventHandler<OpenComponentEventArgs> startProcessEvent = this.StartProcess;
            if (startProcessEvent != null)
            {
                startProcessEvent(RuntimeHelpers.GetObjectValue(sender), new OpenComponentEventArgs("LOKACIJE", null, DeklaritMode.Insert));
            }
        }

        private void RegisterBindingSources()
        {
            if (!this.OSRAZMJESTAJController.WorkItem.Items.Contains("OSRAZMJESTAJ|OSRAZMJESTAJ"))
            {
                this.OSRAZMJESTAJController.WorkItem.Items.Add(this.bindingSourceOSRAZMJESTAJ, "OSRAZMJESTAJ|OSRAZMJESTAJ");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        public void ResumeBindingPostUpdate()
        {
            if ((this.dsOSRAZMJESTAJDataSet1.OSRAZMJESTAJ.Rows[0] != null) && this.m_BaseMethods.IsInsert())
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
                this.OSRAZMJESTAJController.Update(this);
            }
        }

        [LocalCommandHandler("SaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (this.InValidState() && this.OSRAZMJESTAJController.Update(this))
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [LocalCommandHandler("SaveAndNew")]
        public void SaveAndNew(object sender, EventArgs e)
        {
            if (this.InValidState() && this.OSRAZMJESTAJController.Update(this))
            {
                this.OSRAZMJESTAJController.DataSet = new OSRAZMJESTAJDataSet();
                DataSetUtil.AddEmptyRow(this.OSRAZMJESTAJController.DataSet);
                this.ChangeBinding();
                this.m_CurrentRow = this.OSRAZMJESTAJController.DataSet.OSRAZMJESTAJ[0];
                DataSetUtil.CopyForeignKeyValues(this.m_CurrentRow, this.m_ForeignKeys);
                this.SetFocusInFirstField();
            }
        }

        private void SelectedIndexChangedIDLOKACIJE(object sender, EventArgs e)
        {
            if ((this.m_BaseMethods != null) && (this.comboIDLOKACIJE.SelectedItem != null))
            {
                DataRow row = ((DataRowView) this.comboIDLOKACIJE.SelectedItem.ListObject).Row;
                if (row != null)
                {
                    ((DataRowView) this.bindingSourceOSRAZMJESTAJ.Current).Row["IDLOKACIJE"] = RuntimeHelpers.GetObjectValue(row["IDLOKACIJE"]);
                    this.bindingSourceOSRAZMJESTAJ.ResetCurrentItem();
                }
            }
        }

        private void SetFocusInFirstField()
        {
            this.comboIDLOKACIJE.Focus();
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

        private void UpdateValuesOSINVBROJ(DataRow result)
        {
            if (result != null)
            {
                ((DataRowView) this.bindingSourceOSRAZMJESTAJ.Current).Row["INVBROJ"] = RuntimeHelpers.GetObjectValue(result["INVBROJ"]);
                this.bindingSourceOSRAZMJESTAJ.ResetCurrentItem();
            }
        }

        protected virtual LOKACIJEComboBox comboIDLOKACIJE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._comboIDLOKACIJE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._comboIDLOKACIJE = value;
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

        protected virtual UltraLabel label1IDLOKACIJE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IDLOKACIJE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IDLOKACIJE = value;
            }
        }

        protected virtual UltraLabel label1INVBROJ
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1INVBROJ;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1INVBROJ = value;
            }
        }

        protected virtual UltraLabel label1KOLICINARASHODA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1KOLICINARASHODA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1KOLICINARASHODA = value;
            }
        }

        protected virtual UltraLabel label1KOLICINAULAZA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1KOLICINAULAZA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1KOLICINAULAZA = value;
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

        [CreateNew, Browsable(false)]
        public NetAdvantage.Controllers.OSRAZMJESTAJController OSRAZMJESTAJController { get; set; }

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

        protected virtual UltraNumericEditor textINVBROJ
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textINVBROJ;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textINVBROJ = value;
            }
        }

        protected virtual UltraNumericEditor textKOLICINARASHODA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textKOLICINARASHODA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textKOLICINARASHODA = value;
            }
        }

        protected virtual UltraNumericEditor textKOLICINAULAZA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textKOLICINAULAZA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textKOLICINAULAZA = value;
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


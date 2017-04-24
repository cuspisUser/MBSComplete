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
    public class PROIZVODFormUserControl : UserControl, IBusinessComponentUserControl
    {
        [AccessedThroughProperty("comboFINPOREZIDPOREZ")]
        private FINPOREZComboBox _comboFINPOREZIDPOREZ;
        [AccessedThroughProperty("comboIDJEDINICAMJERE")]
        private JEDINICAMJEREComboBox _comboIDJEDINICAMJERE;
        [AccessedThroughProperty("contextMenu1")]
        private ContextMenu _contextMenu1;
        [AccessedThroughProperty("errorProvider1")]
        private ErrorProvider _errorProvider1;
        [AccessedThroughProperty("errorProviderValidator1")]
        private ErrorProviderValidator _errorProviderValidator1;
        [AccessedThroughProperty("label1CIJENA")]
        private UltraLabel _label1CIJENA;

        [AccessedThroughProperty("labelCIJENAPDV")]
        private UltraLabel _labelCIJENAPDV;
        [AccessedThroughProperty("uneCIJENAPDV")]
        private UltraNumericEditor _uneCIJENAPDV;


        #region MBS.Complete 27.04.2016
        [AccessedThroughProperty("lblGrupa")]
        private UltraLabel _lblGrupa;
        [AccessedThroughProperty("uceGrupa")]
        private UltraComboEditor _uceGrupa;
        #endregion


        [AccessedThroughProperty("label1FINPOREZIDPOREZ")]
        private UltraLabel _label1FINPOREZIDPOREZ;
        [AccessedThroughProperty("label1FINPOREZSTOPA")]
        private UltraLabel _label1FINPOREZSTOPA;
        [AccessedThroughProperty("label1IDJEDINICAMJERE")]
        private UltraLabel _label1IDJEDINICAMJERE;
        [AccessedThroughProperty("label1IDPROIZVOD")]
        private UltraLabel _label1IDPROIZVOD;
        [AccessedThroughProperty("label1NAZIVPROIZVOD")]
        private UltraLabel _label1NAZIVPROIZVOD;
        [AccessedThroughProperty("labelFINPOREZSTOPA")]
        private UltraLabel _labelFINPOREZSTOPA;
        [AccessedThroughProperty("SetNullItem")]
        private MenuItem _SetNullItem;
        [AccessedThroughProperty("textCIJENA")]
        private UltraNumericEditor _textCIJENA;
        [AccessedThroughProperty("textIDPROIZVOD")]
        private UltraNumericEditor _textIDPROIZVOD;
        [AccessedThroughProperty("textNAZIVPROIZVOD")]
        private UltraTextEditor _textNAZIVPROIZVOD;
        [AccessedThroughProperty("toolTip1")]
        private System.Windows.Forms.ToolTip _toolTip1;
        private BindingSource bindingSourcePROIZVOD;
        private IContainer components = null;
        private PROIZVODDataSet dsPROIZVODDataSet1;
        protected TableLayoutPanel layoutManagerformPROIZVOD;
        private bool m_AutoNumber = false;
        private GenericFormClass m_BaseMethods;
        private PROIZVODDataSet.PROIZVODRow m_CurrentRow;
        private ArrayList m_DataGrids = new ArrayList();
        private string m_FirstLevelName = "PROIZVOD";
        private DataRow m_ForeignKeys;
        private string m_FrameworkDescription = StringResources.PROIZVODDescription;
        private DeklaritMode m_Mode;

        private bool kontrola = false;

        [EventPublication("topic://NetAdvantage/OpenBusinessComponent", PublicationScope.Global)]
        public event EventHandler<OpenComponentEventArgs> StartProcess;

        public PROIZVODFormUserControl()
        {
            this.InitializeComponent();
            this.Localize();
            this.SetSize();

            FillGrupe();
        }

        private void FillGrupe()
        {
            Mipsed7.DataAccessLayer.SqlClient client = new Mipsed7.DataAccessLayer.SqlClient();

            uceGrupa.DataSource = client.GetDataTable("Select ID, Naziv From MT_GrupeProizvoda");
            uceGrupa.DataBind();
        }

        public void ChangeBinding()
        {
            this.bindingSourcePROIZVOD.DataSource = this.PROIZVODController.DataSet;
            this.dsPROIZVODDataSet1 = this.PROIZVODController.DataSet;
        }

        [LocalCommandHandler("Close")]
        public void Close(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [EventSubscription("topic://NetAdvantage/BusinessComponentUpdated/FINPOREZ", Thread=ThreadOption.UserInterface)]
        public void comboFINPOREZIDPOREZ_Add(object sender, ComponentEventArgs e)
        {
            this.comboFINPOREZIDPOREZ.Fill();
        }

        [EventSubscription("topic://NetAdvantage/BusinessComponentUpdated/JEDINICAMJERE", Thread=ThreadOption.UserInterface)]
        public void comboIDJEDINICAMJERE_Add(object sender, ComponentEventArgs e)
        {
            this.comboIDJEDINICAMJERE.Fill();
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
                    enumerator = this.dsPROIZVODDataSet1.PROIZVOD.Rows.GetEnumerator();
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
                if (this.PROIZVODController.Update(this))
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
            if (m_Mode == DeklaritMode.Update)
            {
                kontrola = true;
            }

            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "PROIZVOD", this.m_Mode, this.dsPROIZVODDataSet1, this.dsPROIZVODDataSet1.PROIZVOD.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            Binding binding = new Binding("Text", this.bindingSourcePROIZVOD, "FINPOREZSTOPA", true);
            binding.Format += new ConvertEventHandler(this.m_BaseMethods.NumericFormat);
            if (this.labelFINPOREZSTOPA.DataBindings["Text"] != null)
            {
                this.labelFINPOREZSTOPA.DataBindings.Remove(this.labelFINPOREZSTOPA.DataBindings["Text"]);
            }
            this.labelFINPOREZSTOPA.DataBindings.Add(binding);
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = this.dsPROIZVODDataSet1.PROIZVOD[0];
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.m_CurrentRow = (PROIZVODDataSet.PROIZVODRow) ((DataRowView) this.bindingSourcePROIZVOD.AddNew()).Row;
                foreach (string str in DataSetUtil.CopyForeignKeyValues(this.m_CurrentRow, foreignKeys))
                {
                    this.m_BaseMethods.SetReadOnly(str, true);
                    this.m_BaseMethods.GetLabelControl(str).Visible = false;
                    this.m_BaseMethods.GetControl(str).Visible = false;
                }
            }
            this.SetFocusInFirstField();

            if (this.m_BaseMethods.IsUpdate())
            {
                GetGrupa(m_CurrentRow.IDPROIZVOD);
            }
        }

        private void GetNextID()
        {
            Mipsed7.DataAccessLayer.SqlClient client = new Mipsed7.DataAccessLayer.SqlClient();

            textIDPROIZVOD.Value = client.ExecuteScalar("Select MAx(IDPROIZVOD) + 1 From PROIZVOD");
        }

        private void GetGrupa(object p)
        {
            Mipsed7.DataAccessLayer.SqlClient client = new Mipsed7.DataAccessLayer.SqlClient();

            Nullable<int> id = null;
            try
            {
                id = Convert.ToInt32(client.ExecuteScalar("Select idGrupa From Proizvod Where IDPROIZVOD = " + p));
            }
            catch { }

            uceGrupa.Value = id;
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            this.components = new Container();
            ResourceManager manager = new ResourceManager(typeof(PROIZVODFormUserControl));
            this.contextMenu1 = new ContextMenu();
            this.SetNullItem = new MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new ErrorProvider();
            this.errorProviderValidator1 = new ErrorProviderValidator(this.components);
            this.bindingSourcePROIZVOD = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourcePROIZVOD).BeginInit();
            this.layoutManagerformPROIZVOD = new TableLayoutPanel();
            this.layoutManagerformPROIZVOD.SuspendLayout();
            this.layoutManagerformPROIZVOD.AutoSize = true;
            this.layoutManagerformPROIZVOD.Dock = DockStyle.Fill;
            this.layoutManagerformPROIZVOD.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformPROIZVOD.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformPROIZVOD.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformPROIZVOD.Size = size;
            this.layoutManagerformPROIZVOD.ColumnCount = 2;
            this.layoutManagerformPROIZVOD.RowCount = 7;
            this.layoutManagerformPROIZVOD.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformPROIZVOD.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformPROIZVOD.RowStyles.Add(new RowStyle());
            this.layoutManagerformPROIZVOD.RowStyles.Add(new RowStyle());
            this.layoutManagerformPROIZVOD.RowStyles.Add(new RowStyle());
            this.layoutManagerformPROIZVOD.RowStyles.Add(new RowStyle());
            this.layoutManagerformPROIZVOD.RowStyles.Add(new RowStyle());
            this.layoutManagerformPROIZVOD.RowStyles.Add(new RowStyle());
            this.layoutManagerformPROIZVOD.RowStyles.Add(new RowStyle());
            this.label1IDPROIZVOD = new UltraLabel();
            this.textIDPROIZVOD = new UltraNumericEditor();
            this.label1NAZIVPROIZVOD = new UltraLabel();
            this.textNAZIVPROIZVOD = new UltraTextEditor();
            this.label1CIJENA = new UltraLabel();
            this.textCIJENA = new UltraNumericEditor();

            this.labelCIJENAPDV = new UltraLabel();
            this.uneCIJENAPDV = new UltraNumericEditor();

            #region MBS.Complete 27.04.2016
            lblGrupa = new UltraLabel();
            uceGrupa = new UltraComboEditor();
            #endregion

            this.label1IDJEDINICAMJERE = new UltraLabel();
            this.comboIDJEDINICAMJERE = new JEDINICAMJEREComboBox();
            this.label1FINPOREZIDPOREZ = new UltraLabel();
            this.comboFINPOREZIDPOREZ = new FINPOREZComboBox();
            this.label1FINPOREZSTOPA = new UltraLabel();
            this.labelFINPOREZSTOPA = new UltraLabel();
            ((ISupportInitialize) this.textIDPROIZVOD).BeginInit();
            ((ISupportInitialize) this.textNAZIVPROIZVOD).BeginInit();

            ((ISupportInitialize) this.textCIJENA).BeginInit();

            ((ISupportInitialize)this.uneCIJENAPDV).BeginInit();

            this.dsPROIZVODDataSet1 = new PROIZVODDataSet();
            this.dsPROIZVODDataSet1.BeginInit();
            this.SuspendLayout();
            this.dsPROIZVODDataSet1.DataSetName = "dsPROIZVOD";
            this.dsPROIZVODDataSet1.Locale = new CultureInfo("hr-HR");
            this.bindingSourcePROIZVOD.DataSource = this.dsPROIZVODDataSet1;
            this.bindingSourcePROIZVOD.DataMember = "PROIZVOD";
            ((ISupportInitialize) this.bindingSourcePROIZVOD).BeginInit();
            point = new System.Drawing.Point(0, 0);
            this.label1IDPROIZVOD.Location = point;
            this.label1IDPROIZVOD.Name = "label1IDPROIZVOD";
            this.label1IDPROIZVOD.TabIndex = 1;
            this.label1IDPROIZVOD.Tag = "labelIDPROIZVOD";
            this.label1IDPROIZVOD.Text = "Šif.proizvod:";
            this.label1IDPROIZVOD.StyleSetName = "FieldUltraLabel";
            this.label1IDPROIZVOD.AutoSize = true;
            this.label1IDPROIZVOD.Anchor = AnchorStyles.Left;
            this.label1IDPROIZVOD.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDPROIZVOD.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1IDPROIZVOD.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1IDPROIZVOD.ImageSize = size;
            this.label1IDPROIZVOD.Appearance.ForeColor = Color.Black;
            this.label1IDPROIZVOD.BackColor = Color.Transparent;
            this.layoutManagerformPROIZVOD.Controls.Add(this.label1IDPROIZVOD, 0, 0);
            this.layoutManagerformPROIZVOD.SetColumnSpan(this.label1IDPROIZVOD, 1);
            this.layoutManagerformPROIZVOD.SetRowSpan(this.label1IDPROIZVOD, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1IDPROIZVOD.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDPROIZVOD.MinimumSize = size;
            size = new System.Drawing.Size(90, 0x17);
            this.label1IDPROIZVOD.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textIDPROIZVOD.Location = point;
            this.textIDPROIZVOD.Name = "textIDPROIZVOD";
            this.textIDPROIZVOD.Tag = "IDPROIZVOD";
            this.textIDPROIZVOD.TabIndex = 0;
            this.textIDPROIZVOD.Anchor = AnchorStyles.Left;
            this.textIDPROIZVOD.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textIDPROIZVOD.ReadOnly = false;
            this.textIDPROIZVOD.PromptChar = ' ';
            this.textIDPROIZVOD.Enter += new EventHandler(this.numericEditor_Enter);
            this.textIDPROIZVOD.DataBindings.Add(new Binding("Value", this.bindingSourcePROIZVOD, "IDPROIZVOD"));
            this.textIDPROIZVOD.NumericType = NumericType.Integer;
            this.textIDPROIZVOD.MaskInput = "{LOC}-nnnnn";
            this.layoutManagerformPROIZVOD.Controls.Add(this.textIDPROIZVOD, 1, 0);
            this.layoutManagerformPROIZVOD.SetColumnSpan(this.textIDPROIZVOD, 1);
            this.layoutManagerformPROIZVOD.SetRowSpan(this.textIDPROIZVOD, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textIDPROIZVOD.Margin = padding;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textIDPROIZVOD.MinimumSize = size;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textIDPROIZVOD.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1NAZIVPROIZVOD.Location = point;
            this.label1NAZIVPROIZVOD.Name = "label1NAZIVPROIZVOD";
            this.label1NAZIVPROIZVOD.TabIndex = 1;
            this.label1NAZIVPROIZVOD.Tag = "labelNAZIVPROIZVOD";
            this.label1NAZIVPROIZVOD.Text = "Proizvod:";
            this.label1NAZIVPROIZVOD.StyleSetName = "FieldUltraLabel";
            this.label1NAZIVPROIZVOD.AutoSize = true;
            this.label1NAZIVPROIZVOD.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.label1NAZIVPROIZVOD.Appearance.TextVAlign = VAlign.Middle;
            this.label1NAZIVPROIZVOD.Appearance.ForeColor = Color.Black;
            this.label1NAZIVPROIZVOD.BackColor = Color.Transparent;
            this.layoutManagerformPROIZVOD.Controls.Add(this.label1NAZIVPROIZVOD, 0, 1);
            this.layoutManagerformPROIZVOD.SetColumnSpan(this.label1NAZIVPROIZVOD, 1);
            this.layoutManagerformPROIZVOD.SetRowSpan(this.label1NAZIVPROIZVOD, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1NAZIVPROIZVOD.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1NAZIVPROIZVOD.MinimumSize = size;
            size = new System.Drawing.Size(0x49, 0x17);
            this.label1NAZIVPROIZVOD.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textNAZIVPROIZVOD.Location = point;
            this.textNAZIVPROIZVOD.Name = "textNAZIVPROIZVOD";
            this.textNAZIVPROIZVOD.Tag = "NAZIVPROIZVOD";
            this.textNAZIVPROIZVOD.TabIndex = 0;
            this.textNAZIVPROIZVOD.Anchor = AnchorStyles.Left;
            this.textNAZIVPROIZVOD.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textNAZIVPROIZVOD.ReadOnly = false;
            this.textNAZIVPROIZVOD.DataBindings.Add(new Binding("Text", this.bindingSourcePROIZVOD, "NAZIVPROIZVOD"));
            this.textNAZIVPROIZVOD.Multiline = true;
            this.textNAZIVPROIZVOD.MaxLength = 500;
            this.layoutManagerformPROIZVOD.Controls.Add(this.textNAZIVPROIZVOD, 1, 1);
            this.layoutManagerformPROIZVOD.SetColumnSpan(this.textNAZIVPROIZVOD, 1);
            this.layoutManagerformPROIZVOD.SetRowSpan(this.textNAZIVPROIZVOD, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textNAZIVPROIZVOD.Margin = padding;
            size = new System.Drawing.Size(0x240, 110);
            this.textNAZIVPROIZVOD.MinimumSize = size;
            size = new System.Drawing.Size(0x240, 110);
            this.textNAZIVPROIZVOD.Size = size;
            this.textNAZIVPROIZVOD.Dock = DockStyle.Fill;
            
            point = new System.Drawing.Point(0, 0);
            this.label1CIJENA.Location = point;
            this.label1CIJENA.Name = "label1CIJENA";
            this.label1CIJENA.TabIndex = 1;
            this.label1CIJENA.Tag = "labelCIJENA";
            this.label1CIJENA.Text = "Osnovica:";
            this.label1CIJENA.StyleSetName = "FieldUltraLabel";
            this.label1CIJENA.AutoSize = true;
            this.label1CIJENA.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.label1CIJENA.Appearance.TextVAlign = VAlign.Middle;
            this.label1CIJENA.Appearance.ForeColor = Color.Black;
            this.label1CIJENA.BackColor = Color.Transparent;
            this.layoutManagerformPROIZVOD.Controls.Add(this.label1CIJENA, 0, 2);
            this.layoutManagerformPROIZVOD.SetColumnSpan(this.label1CIJENA, 1);
            this.layoutManagerformPROIZVOD.SetRowSpan(this.label1CIJENA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1CIJENA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1CIJENA.MinimumSize = size;
            size = new System.Drawing.Size(0x41, 0x17);
            this.label1CIJENA.Size = size;

            point = new System.Drawing.Point(0, 0);
            this.textCIJENA.Location = point;
            this.textCIJENA.Name = "textCIJENA";
            this.textCIJENA.Tag = "CIJENA";
            this.textCIJENA.TabIndex = 0;
            this.textCIJENA.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.textCIJENA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textCIJENA.ReadOnly = false;
            this.textCIJENA.PromptChar = ' ';
            this.textCIJENA.Enter += new EventHandler(this.numericEditor_Enter);
            this.textCIJENA.DataBindings.Add(new Binding("Value", this.bindingSourcePROIZVOD, "CIJENA"));
            this.textCIJENA.NumericType = NumericType.Double;
            this.textCIJENA.MaxValue = 79228162514264337593543950335M;
            this.textCIJENA.MinValue = -79228162514264337593543950335M;
            this.textCIJENA.MaskInput = "{LOC}-nnnnn.nnnn";
            this.layoutManagerformPROIZVOD.Controls.Add(this.textCIJENA, 1, 2);
            this.layoutManagerformPROIZVOD.SetColumnSpan(this.textCIJENA, 1);
            this.layoutManagerformPROIZVOD.SetRowSpan(this.textCIJENA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textCIJENA.Margin = padding;
            size = new System.Drawing.Size(0x52, 0x16);
            this.textCIJENA.MinimumSize = size;
            size = new System.Drawing.Size(0x52, 0x16);
            this.textCIJENA.Size = size;
            this.textCIJENA.ValueChanged += new System.EventHandler(this.textCIJENA_ValueChanged);

            point = new System.Drawing.Point(0, 0);
            this.uneCIJENAPDV.Location = point;
            this.uneCIJENAPDV.Name = "uneCIJENAPDV";
            this.uneCIJENAPDV.Tag = "CIJENAPDV";
            this.uneCIJENAPDV.TabIndex = 10;
            this.uneCIJENAPDV.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.uneCIJENAPDV.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.uneCIJENAPDV.ReadOnly = false;
            this.uneCIJENAPDV.PromptChar = ' ';
            this.uneCIJENAPDV.Enter += new EventHandler(this.numericEditor_Enter);
            this.uneCIJENAPDV.DataBindings.Add(new Binding("Value", this.bindingSourcePROIZVOD, "CIJENAPDV"));
            this.uneCIJENAPDV.NumericType = NumericType.Double;
            this.uneCIJENAPDV.MaxValue = 79228162514264337593543950335M;
            this.uneCIJENAPDV.MinValue = -79228162514264337593543950335M;
            this.uneCIJENAPDV.MaskInput = "{LOC}-nnnnn.nnnn";
            this.layoutManagerformPROIZVOD.Controls.Add(this.uneCIJENAPDV, 1, 6);
            this.layoutManagerformPROIZVOD.SetColumnSpan(this.uneCIJENAPDV, 1);
            this.layoutManagerformPROIZVOD.SetRowSpan(this.uneCIJENAPDV, 1);
            padding = new Padding(0, 1, 3, 2);
            this.uneCIJENAPDV.Margin = padding;
            size = new System.Drawing.Size(0x52, 0x16);
            this.uneCIJENAPDV.MinimumSize = size;
            size = new System.Drawing.Size(0x52, 0x16);
            this.uneCIJENAPDV.Size = size;
            this.uneCIJENAPDV.ValueChanged += new System.EventHandler(this.uneCIJENAPDV_ValueChanged);

            point = new System.Drawing.Point(0, 0);
            this.labelCIJENAPDV.Location = point;
            this.labelCIJENAPDV.Name = "labelCIJENAPDV";
            this.labelCIJENAPDV.TabIndex = 1;
            this.labelCIJENAPDV.Tag = "labelCIJENAPDV";
            this.labelCIJENAPDV.Text = "Cijena sa PDV-om:";
            this.labelCIJENAPDV.StyleSetName = "FieldUltraLabel";
            this.labelCIJENAPDV.AutoSize = true;
            this.labelCIJENAPDV.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.labelCIJENAPDV.Appearance.TextVAlign = VAlign.Middle;
            this.labelCIJENAPDV.Appearance.ForeColor = Color.Black;
            this.labelCIJENAPDV.BackColor = Color.Transparent;
            this.layoutManagerformPROIZVOD.Controls.Add(this.labelCIJENAPDV, 0, 6);
            this.layoutManagerformPROIZVOD.SetColumnSpan(this.labelCIJENAPDV, 1);
            this.layoutManagerformPROIZVOD.SetRowSpan(this.labelCIJENAPDV, 1);
            padding = new Padding(3, 1, 5, 2);
            this.labelCIJENAPDV.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.labelCIJENAPDV.MinimumSize = size;
            size = new System.Drawing.Size(0x41, 0x17);
            this.labelCIJENAPDV.Size = size;


            #region MBS.Complete 27.04.2016
            point = new System.Drawing.Point(0, 0);
            this.lblGrupa.Location = point;
            this.lblGrupa.Name = "lblGrupa";
            this.lblGrupa.TabIndex = 1;
            this.lblGrupa.Tag = "lblGrupa";
            this.lblGrupa.Text = "Grupa:";
            this.lblGrupa.StyleSetName = "FieldUltraLabel";
            this.lblGrupa.AutoSize = true;
            this.lblGrupa.Anchor = AnchorStyles.Left;
            this.lblGrupa.Appearance.TextVAlign = VAlign.Middle;
            this.lblGrupa.Appearance.ForeColor = Color.Black;
            this.lblGrupa.BackColor = Color.Transparent;
            this.layoutManagerformPROIZVOD.Controls.Add(this.lblGrupa, 0, 7);
            this.layoutManagerformPROIZVOD.SetColumnSpan(this.lblGrupa, 1);
            this.layoutManagerformPROIZVOD.SetRowSpan(this.lblGrupa, 1);
            padding = new Padding(3, 1, 5, 2);
            this.lblGrupa.Margin = padding;
            size = new System.Drawing.Size(25, 16);
            lblGrupa.Size = size;

            this.uceGrupa.DisplayMember = "Naziv";
            this.uceGrupa.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.uceGrupa.Location = point;
            this.uceGrupa.MaxDropDownItems = 20;
            this.uceGrupa.Name = "uceGrupa";
            this.uceGrupa.Size = new System.Drawing.Size(240, 21);
            this.uceGrupa.TabIndex = 76;
            this.uceGrupa.ValueMember = "ID";
            this.layoutManagerformPROIZVOD.Controls.Add(this.uceGrupa, 1, 7);
            this.layoutManagerformPROIZVOD.SetColumnSpan(this.uceGrupa, 1);
            this.layoutManagerformPROIZVOD.SetRowSpan(this.uceGrupa, 1);
            #endregion


            point = new System.Drawing.Point(0, 0);
            this.label1IDJEDINICAMJERE.Location = point;
            this.label1IDJEDINICAMJERE.Name = "label1IDJEDINICAMJERE";
            this.label1IDJEDINICAMJERE.TabIndex = 1;
            this.label1IDJEDINICAMJERE.Tag = "labelIDJEDINICAMJERE";
            this.label1IDJEDINICAMJERE.Text = "Šifra jed. mjere:";
            this.label1IDJEDINICAMJERE.StyleSetName = "FieldUltraLabel";
            this.label1IDJEDINICAMJERE.AutoSize = true;
            this.label1IDJEDINICAMJERE.Anchor = AnchorStyles.Left;
            this.label1IDJEDINICAMJERE.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDJEDINICAMJERE.Appearance.ForeColor = Color.Black;
            this.label1IDJEDINICAMJERE.BackColor = Color.Transparent;
            this.layoutManagerformPROIZVOD.Controls.Add(this.label1IDJEDINICAMJERE, 0, 3);
            this.layoutManagerformPROIZVOD.SetColumnSpan(this.label1IDJEDINICAMJERE, 1);
            this.layoutManagerformPROIZVOD.SetRowSpan(this.label1IDJEDINICAMJERE, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1IDJEDINICAMJERE.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDJEDINICAMJERE.MinimumSize = size;
            size = new System.Drawing.Size(0x73, 0x17);
            this.label1IDJEDINICAMJERE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.comboIDJEDINICAMJERE.Location = point;
            this.comboIDJEDINICAMJERE.Name = "comboIDJEDINICAMJERE";
            this.comboIDJEDINICAMJERE.Tag = "IDJEDINICAMJERE";
            this.comboIDJEDINICAMJERE.TabIndex = 0;
            this.comboIDJEDINICAMJERE.Anchor = AnchorStyles.Left;
            this.comboIDJEDINICAMJERE.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.comboIDJEDINICAMJERE.DropDownStyle = DropDownStyle.DropDown;
            this.comboIDJEDINICAMJERE.ComboBox.DropDownStyle = DropDownStyle.DropDown;
            this.comboIDJEDINICAMJERE.ComboBox.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            this.comboIDJEDINICAMJERE.Enabled = true;
            this.comboIDJEDINICAMJERE.DataBindings.Add(new Binding("Value", this.bindingSourcePROIZVOD, "IDJEDINICAMJERE"));
            this.comboIDJEDINICAMJERE.ShowPictureBox = true;
            this.comboIDJEDINICAMJERE.PictureBoxClicked += new EventHandler(this.PictureBoxClickedIDJEDINICAMJERE);
            this.comboIDJEDINICAMJERE.ValueMember = "IDJEDINICAMJERE";
            this.comboIDJEDINICAMJERE.SelectionChanged += new EventHandler(this.SelectedIndexChangedIDJEDINICAMJERE);
            this.layoutManagerformPROIZVOD.Controls.Add(this.comboIDJEDINICAMJERE, 1, 3);
            this.layoutManagerformPROIZVOD.SetColumnSpan(this.comboIDJEDINICAMJERE, 1);
            this.layoutManagerformPROIZVOD.SetRowSpan(this.comboIDJEDINICAMJERE, 1);
            padding = new Padding(0, 1, 3, 2);
            this.comboIDJEDINICAMJERE.Margin = padding;
            size = new System.Drawing.Size(0x196, 0x17);
            this.comboIDJEDINICAMJERE.MinimumSize = size;
            size = new System.Drawing.Size(0x196, 0x17);
            this.comboIDJEDINICAMJERE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1FINPOREZIDPOREZ.Location = point;
            this.label1FINPOREZIDPOREZ.Name = "label1FINPOREZIDPOREZ";
            this.label1FINPOREZIDPOREZ.TabIndex = 1;
            this.label1FINPOREZIDPOREZ.Tag = "labelFINPOREZIDPOREZ";
            this.label1FINPOREZIDPOREZ.Text = "FINPOREZIDPOREZ:";
            this.label1FINPOREZIDPOREZ.StyleSetName = "FieldUltraLabel";
            this.label1FINPOREZIDPOREZ.AutoSize = true;
            this.label1FINPOREZIDPOREZ.Anchor = AnchorStyles.Left;
            this.label1FINPOREZIDPOREZ.Appearance.TextVAlign = VAlign.Middle;
            this.label1FINPOREZIDPOREZ.Appearance.ForeColor = Color.Black;
            this.label1FINPOREZIDPOREZ.BackColor = Color.Transparent;
            this.layoutManagerformPROIZVOD.Controls.Add(this.label1FINPOREZIDPOREZ, 0, 4);
            this.layoutManagerformPROIZVOD.SetColumnSpan(this.label1FINPOREZIDPOREZ, 1);
            this.layoutManagerformPROIZVOD.SetRowSpan(this.label1FINPOREZIDPOREZ, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1FINPOREZIDPOREZ.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1FINPOREZIDPOREZ.MinimumSize = size;
            size = new System.Drawing.Size(0x8d, 0x17);
            this.label1FINPOREZIDPOREZ.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.comboFINPOREZIDPOREZ.Location = point;
            this.comboFINPOREZIDPOREZ.Name = "comboFINPOREZIDPOREZ";
            this.comboFINPOREZIDPOREZ.Tag = "FINPOREZIDPOREZ";
            this.comboFINPOREZIDPOREZ.TabIndex = 0;
            this.comboFINPOREZIDPOREZ.Anchor = AnchorStyles.Left;
            this.comboFINPOREZIDPOREZ.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.comboFINPOREZIDPOREZ.DropDownStyle = DropDownStyle.DropDown;
            this.comboFINPOREZIDPOREZ.ComboBox.DropDownStyle = DropDownStyle.DropDown;
            this.comboFINPOREZIDPOREZ.ComboBox.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            this.comboFINPOREZIDPOREZ.Enabled = true;
            this.comboFINPOREZIDPOREZ.DataBindings.Add(new Binding("Value", this.bindingSourcePROIZVOD, "FINPOREZIDPOREZ"));
            this.comboFINPOREZIDPOREZ.ShowPictureBox = true;
            this.comboFINPOREZIDPOREZ.PictureBoxClicked += new EventHandler(this.PictureBoxClickedFINPOREZIDPOREZ);
            this.comboFINPOREZIDPOREZ.ValueMember = "FINPOREZIDPOREZ";
            this.comboFINPOREZIDPOREZ.SelectionChanged += new EventHandler(this.SelectedIndexChangedFINPOREZIDPOREZ);
            this.layoutManagerformPROIZVOD.Controls.Add(this.comboFINPOREZIDPOREZ, 1, 4);
            this.layoutManagerformPROIZVOD.SetColumnSpan(this.comboFINPOREZIDPOREZ, 1);
            this.layoutManagerformPROIZVOD.SetRowSpan(this.comboFINPOREZIDPOREZ, 1);
            padding = new Padding(0, 1, 3, 2);
            this.comboFINPOREZIDPOREZ.Margin = padding;
            size = new System.Drawing.Size(0x10a, 0x17);
            this.comboFINPOREZIDPOREZ.MinimumSize = size;
            size = new System.Drawing.Size(0x10a, 0x17);
            this.comboFINPOREZIDPOREZ.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1FINPOREZSTOPA.Location = point;
            this.label1FINPOREZSTOPA.Name = "label1FINPOREZSTOPA";
            this.label1FINPOREZSTOPA.TabIndex = 1;
            this.label1FINPOREZSTOPA.Tag = "labelFINPOREZSTOPA";
            this.label1FINPOREZSTOPA.Text = "FINPOREZSTOPA:";
            this.label1FINPOREZSTOPA.StyleSetName = "FieldUltraLabel";
            this.label1FINPOREZSTOPA.AutoSize = true;
            this.label1FINPOREZSTOPA.Anchor = AnchorStyles.Left;
            this.label1FINPOREZSTOPA.Appearance.TextVAlign = VAlign.Middle;
            this.label1FINPOREZSTOPA.Appearance.ForeColor = Color.Black;
            this.label1FINPOREZSTOPA.BackColor = Color.Transparent;
            this.layoutManagerformPROIZVOD.Controls.Add(this.label1FINPOREZSTOPA, 0, 5);
            this.layoutManagerformPROIZVOD.SetColumnSpan(this.label1FINPOREZSTOPA, 1);
            this.layoutManagerformPROIZVOD.SetRowSpan(this.label1FINPOREZSTOPA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1FINPOREZSTOPA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1FINPOREZSTOPA.MinimumSize = size;
            size = new System.Drawing.Size(0x7d, 0x17);
            this.label1FINPOREZSTOPA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelFINPOREZSTOPA.Location = point;
            this.labelFINPOREZSTOPA.Name = "labelFINPOREZSTOPA";
            this.labelFINPOREZSTOPA.Tag = "FINPOREZSTOPA";
            this.labelFINPOREZSTOPA.TabIndex = 0;
            this.labelFINPOREZSTOPA.Anchor = AnchorStyles.Left;
            this.labelFINPOREZSTOPA.BackColor = Color.Transparent;
            this.labelFINPOREZSTOPA.Appearance.TextHAlign = HAlign.Left;
            this.labelFINPOREZSTOPA.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformPROIZVOD.Controls.Add(this.labelFINPOREZSTOPA, 1, 5);
            this.layoutManagerformPROIZVOD.SetColumnSpan(this.labelFINPOREZSTOPA, 1);
            this.layoutManagerformPROIZVOD.SetRowSpan(this.labelFINPOREZSTOPA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelFINPOREZSTOPA.Margin = padding;
            size = new System.Drawing.Size(0x37, 0x16);
            this.labelFINPOREZSTOPA.MinimumSize = size;
            size = new System.Drawing.Size(0x37, 0x16);
            this.labelFINPOREZSTOPA.Size = size;
            this.Controls.Add(this.layoutManagerformPROIZVOD);
            this.SetNullItem.Index = 0;
            this.SetNullItem.Text = "Set Null";
            this.SetNullItem.Click += new EventHandler(this.SetNullItem_Click);
            this.contextMenu1.Popup += new EventHandler(this.contextMenu1_Popup);
            this.contextMenu1.MenuItems.AddRange(new MenuItem[] { this.SetNullItem });
            this.errorProvider1.DataSource = this.bindingSourcePROIZVOD;
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            this.Name = "PROIZVODFormUserControl";
            this.Text = "PROIZVOD";
            this.AutoSize = true;
            this.AutoScroll = true;
            this.Load += new EventHandler(this.PROIZVODFormUserControl_Load);
            this.layoutManagerformPROIZVOD.ResumeLayout(false);
            this.layoutManagerformPROIZVOD.PerformLayout();
            ((ISupportInitialize) this.bindingSourcePROIZVOD).EndInit();
            ((ISupportInitialize) this.textIDPROIZVOD).EndInit();
            ((ISupportInitialize) this.textNAZIVPROIZVOD).EndInit();
            ((ISupportInitialize) this.textCIJENA).EndInit();
            ((ISupportInitialize)this.uneCIJENAPDV).EndInit();
            this.dsPROIZVODDataSet1.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void uneCIJENAPDV_ValueChanged(object sender, EventArgs e)
        {
            if (!kontrola)
            {
                if (comboFINPOREZIDPOREZ.Value != null && textCIJENA.Value != null)
                {
                    Mipsed7.DataAccessLayer.SqlClient client = new Mipsed7.DataAccessLayer.SqlClient();

                    try
                    {
                        textCIJENA.Value = Convert.ToDouble(uneCIJENAPDV.Value) / (1 + (Convert.ToDouble(client.ExecuteScalar("Select FINPOREZSTOPA From FINPOREZ Where FINPOREZIDPOREZ = " + (int)comboFINPOREZIDPOREZ.Value)) / 100));
                    }
                    catch { }
                }
            }
        }

        private void textCIJENA_ValueChanged(object sender, EventArgs e)
        {
            if (!kontrola)
            {
                if (comboFINPOREZIDPOREZ.Value != null && uneCIJENAPDV.Value != null)
                {
                    Mipsed7.DataAccessLayer.SqlClient client = new Mipsed7.DataAccessLayer.SqlClient();

                    try
                    {
                        double porez = Convert.ToDouble(client.ExecuteScalar("Select FINPOREZSTOPA From FINPOREZ Where FINPOREZIDPOREZ = " + (int)comboFINPOREZIDPOREZ.Value)) * Convert.ToDouble(textCIJENA.Value) / 100;
                        uneCIJENAPDV.Value = Convert.ToDouble(textCIJENA.Value) + porez;
                    }
                    catch { }
                }
            }
        }

        private bool InValidState()
        {
            if ((this.PROIZVODController.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourcePROIZVOD, this.PROIZVODController.WorkItem, this))
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
            this.label1IDPROIZVOD.Text = StringResources.PROIZVODIDPROIZVODDescription;
            this.label1NAZIVPROIZVOD.Text = StringResources.PROIZVODNAZIVPROIZVODDescription;
            this.label1CIJENA.Text = StringResources.PROIZVODCIJENADescription;
            this.label1IDJEDINICAMJERE.Text = StringResources.PROIZVODIDJEDINICAMJEREDescription;
            this.label1FINPOREZIDPOREZ.Text = StringResources.PROIZVODFINPOREZIDPOREZDescription;
            this.label1FINPOREZSTOPA.Text = StringResources.PROIZVODFINPOREZSTOPADescription;
            this.lblGrupa.Text = StringResources.GrupaDescripton;
        }

        private void mouseEnter_Text(object sender, EventArgs e)
        {
            this.m_BaseMethods.MouseEnterTextBase(this.toolTip1, this.m_CurrentRow, RuntimeHelpers.GetObjectValue(sender));
        }

        private void numericEditor_Enter(object sender, EventArgs e)
        {
            ((UltraNumericEditor) sender).SelectAll();
        }

        private void PictureBoxClickedFINPOREZIDPOREZ(object sender, EventArgs e)
        {
            EventHandler<OpenComponentEventArgs> startProcessEvent = this.StartProcess;
            if (startProcessEvent != null)
            {
                startProcessEvent(RuntimeHelpers.GetObjectValue(sender), new OpenComponentEventArgs("FINPOREZ", null, DeklaritMode.Insert));
            }
        }

        private void PictureBoxClickedIDJEDINICAMJERE(object sender, EventArgs e)
        {
            EventHandler<OpenComponentEventArgs> startProcessEvent = this.StartProcess;
            if (startProcessEvent != null)
            {
                startProcessEvent(RuntimeHelpers.GetObjectValue(sender), new OpenComponentEventArgs("JEDINICAMJERE", null, DeklaritMode.Insert));
            }
        }

        private void PROIZVODFormUserControl_Load(object sender, EventArgs e)
        {
            kontrola = false;
            this.Text = StringResources.PROIZVODDescription;
            this.errorProvider1.ContainerControl = this;

            if (m_Mode == DeklaritMode.Insert)
            {
                GetNextID();
            }
        }

        private void RegisterBindingSources()
        {
            if (!this.PROIZVODController.WorkItem.Items.Contains("PROIZVOD|PROIZVOD"))
            {
                this.PROIZVODController.WorkItem.Items.Add(this.bindingSourcePROIZVOD, "PROIZVOD|PROIZVOD");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        public void ResumeBindingPostUpdate()
        {
            if ((this.dsPROIZVODDataSet1.PROIZVOD.Rows[0] != null) && this.m_BaseMethods.IsInsert())
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
                this.PROIZVODController.Update(this);

                AddGrupa(textIDPROIZVOD.Value);
            }
        }

        [LocalCommandHandler("SaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (this.InValidState() && this.PROIZVODController.Update(this))
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;

                AddGrupa(textIDPROIZVOD.Value);
            }
        }

        [LocalCommandHandler("SaveAndNew")]
        public void SaveAndNew(object sender, EventArgs e)
        {
            if (this.InValidState() && this.PROIZVODController.Update(this))
            {
                this.PROIZVODController.DataSet = new PROIZVODDataSet();
                DataSetUtil.AddEmptyRow(this.PROIZVODController.DataSet);

                AddGrupa(textIDPROIZVOD.Value);

                this.ChangeBinding();
                this.m_CurrentRow = this.PROIZVODController.DataSet.PROIZVOD[0];
                DataSetUtil.CopyForeignKeyValues(this.m_CurrentRow, this.m_ForeignKeys);
                this.SetFocusInFirstField();
            }
        }

        private void AddGrupa(object p)
        {
            Mipsed7.DataAccessLayer.SqlClient client = new Mipsed7.DataAccessLayer.SqlClient();

            string year = mipsed.application.framework.Application.ActiveYear.ToString();

            if(uceGrupa.Value != null)
            {

                client.ExecuteNonQuery("Update Proizvod Set idGrupa = " + uceGrupa.Value + " Where IDPROIZVOD = " + p);

            }
        }

        private void SelectedIndexChangedFINPOREZIDPOREZ(object sender, EventArgs e)
        {
            if ((this.m_BaseMethods != null) && (this.comboFINPOREZIDPOREZ.SelectedItem != null))
            {
                DataRow row = ((DataRowView) this.comboFINPOREZIDPOREZ.SelectedItem.ListObject).Row;
                if (row != null)
                {
                    //((DataRowView) this.bindingSourcePROIZVOD.Current).Row["FINPOREZIDPOREZ"] = RuntimeHelpers.GetObjectValue(row["FINPOREZIDPOREZ"]);
                    //((DataRowView) this.bindingSourcePROIZVOD.Current).Row["FINPOREZSTOPA"] = RuntimeHelpers.GetObjectValue(row["FINPOREZSTOPA"]);
                    //this.bindingSourcePROIZVOD.ResetCurrentItem();

                    if (textCIJENA.Value != null)
                    {
                        if (textCIJENA.Value.ToString() != string.Empty)
                        {
                            double porez = Convert.ToDouble(RuntimeHelpers.GetObjectValue(row["FINPOREZSTOPA"])) * Convert.ToDouble(textCIJENA.Value) / 100;

                            uneCIJENAPDV.Value = Convert.ToDouble(textCIJENA.Value) + porez;
                        }
                    }
                    else if (uneCIJENAPDV.Value != null)
                    {
                        if (uneCIJENAPDV.Value.ToString() == string.Empty) 
                        {
                            textCIJENA.Value = Convert.ToDouble(uneCIJENAPDV.Value) / (1 + (Convert.ToDouble(RuntimeHelpers.GetObjectValue(row["FINPOREZSTOPA"])) / 100));
                        }
                    }
                }
            }
        }

        private void SelectedIndexChangedIDJEDINICAMJERE(object sender, EventArgs e)
        {
            if ((this.m_BaseMethods != null) && (this.comboIDJEDINICAMJERE.SelectedItem != null))
            {
                DataRow row = ((DataRowView) this.comboIDJEDINICAMJERE.SelectedItem.ListObject).Row;
                if (row != null)
                {
                    ((DataRowView) this.bindingSourcePROIZVOD.Current).Row["IDJEDINICAMJERE"] = RuntimeHelpers.GetObjectValue(row["IDJEDINICAMJERE"]);
                    ((DataRowView) this.bindingSourcePROIZVOD.Current).Row["NAZIVJEDINICAMJERE"] = RuntimeHelpers.GetObjectValue(row["NAZIVJEDINICAMJERE"]);
                    this.bindingSourcePROIZVOD.ResetCurrentItem();
                }
            }
        }

        private void SetFocusInFirstField()
        {
            this.textIDPROIZVOD.Focus();
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

        protected virtual FINPOREZComboBox comboFINPOREZIDPOREZ
        {
            [DebuggerNonUserCode]
            get
            {
                return this._comboFINPOREZIDPOREZ;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._comboFINPOREZIDPOREZ = value;
            }
        }

        protected virtual JEDINICAMJEREComboBox comboIDJEDINICAMJERE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._comboIDJEDINICAMJERE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._comboIDJEDINICAMJERE = value;
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

        protected virtual UltraLabel label1CIJENA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1CIJENA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1CIJENA = value;
            }
        }

        protected virtual UltraLabel labelCIJENAPDV
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelCIJENAPDV;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelCIJENAPDV = value;
            }
        }

        protected virtual UltraLabel label1FINPOREZIDPOREZ
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1FINPOREZIDPOREZ;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1FINPOREZIDPOREZ = value;
            }
        }

        protected virtual UltraLabel label1FINPOREZSTOPA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1FINPOREZSTOPA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1FINPOREZSTOPA = value;
            }
        }

        protected virtual UltraLabel label1IDJEDINICAMJERE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IDJEDINICAMJERE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IDJEDINICAMJERE = value;
            }
        }

        protected virtual UltraLabel label1IDPROIZVOD
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IDPROIZVOD;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IDPROIZVOD = value;
            }
        }

        protected virtual UltraLabel label1NAZIVPROIZVOD
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1NAZIVPROIZVOD;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1NAZIVPROIZVOD = value;
            }
        }

        protected virtual UltraLabel labelFINPOREZSTOPA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelFINPOREZSTOPA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelFINPOREZSTOPA = value;
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

        [Browsable(false), CreateNew]
        public NetAdvantage.Controllers.PROIZVODController PROIZVODController { get; set; }

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

        protected virtual UltraNumericEditor textCIJENA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textCIJENA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textCIJENA = value;
            }
        }

        #region MBS.Complete 27.04.2016
        protected virtual UltraLabel lblGrupa
        {
            [DebuggerNonUserCode]
            get
            {
                return this._lblGrupa;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._lblGrupa = value;
            }
        }

        protected virtual UltraComboEditor uceGrupa
        {
            [DebuggerNonUserCode]
            get
            {
                return this._uceGrupa;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._uceGrupa = value;
            }
        }
        #endregion


        protected virtual UltraNumericEditor uneCIJENAPDV
        {
            [DebuggerNonUserCode]
            get
            {
                return this._uneCIJENAPDV;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._uneCIJENAPDV = value;
            }
        }

        protected virtual UltraNumericEditor textIDPROIZVOD
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textIDPROIZVOD;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textIDPROIZVOD = value;
            }
        }

        protected virtual UltraTextEditor textNAZIVPROIZVOD
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textNAZIVPROIZVOD;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textNAZIVPROIZVOD = value;
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


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
    public class RAD1GELEMENTIVEZAFormUserControl : UserControl, IBusinessComponentUserControl
    {
        [AccessedThroughProperty("comboIDELEMENT")]
        private ELEMENTComboBox _comboIDELEMENT;
        [AccessedThroughProperty("comboRAD1GELEMENTIID")]
        private RAD1GELEMENTIComboBox _comboRAD1GELEMENTIID;
        [AccessedThroughProperty("contextMenu1")]
        private ContextMenu _contextMenu1;
        [AccessedThroughProperty("errorProvider1")]
        private ErrorProvider _errorProvider1;
        [AccessedThroughProperty("errorProviderValidator1")]
        private ErrorProviderValidator _errorProviderValidator1;
        [AccessedThroughProperty("label1IDELEMENT")]
        private UltraLabel _label1IDELEMENT;
        [AccessedThroughProperty("label1RAD1GELEMENTIID")]
        private UltraLabel _label1RAD1GELEMENTIID;
        [AccessedThroughProperty("SetNullItem")]
        private MenuItem _SetNullItem;
        [AccessedThroughProperty("toolTip1")]
        private System.Windows.Forms.ToolTip _toolTip1;
        private BindingSource bindingSourceRAD1GELEMENTIVEZA;
        private IContainer components = null;
        private RAD1GELEMENTIVEZADataSet dsRAD1GELEMENTIVEZADataSet1;
        protected TableLayoutPanel layoutManagerformRAD1GELEMENTIVEZA;
        private bool m_AutoNumber = false;
        private GenericFormClass m_BaseMethods;
        private RAD1GELEMENTIVEZADataSet.RAD1GELEMENTIVEZARow m_CurrentRow;
        private ArrayList m_DataGrids = new ArrayList();
        private string m_FirstLevelName = "RAD1GELEMENTIVEZA";
        private DataRow m_ForeignKeys;
        private string m_FrameworkDescription = StringResources.RAD1GELEMENTIVEZADescription;
        private DeklaritMode m_Mode;

        [EventPublication("topic://NetAdvantage/OpenBusinessComponent", PublicationScope.Global)]
        public event EventHandler<OpenComponentEventArgs> StartProcess;

        public RAD1GELEMENTIVEZAFormUserControl()
        {
            this.InitializeComponent();
            this.Localize();
            this.SetSize();
        }

        public void ChangeBinding()
        {
            this.bindingSourceRAD1GELEMENTIVEZA.DataSource = this.RAD1GELEMENTIVEZAController.DataSet;
            this.dsRAD1GELEMENTIVEZADataSet1 = this.RAD1GELEMENTIVEZAController.DataSet;
        }

        [LocalCommandHandler("Close")]
        public void Close(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [EventSubscription("topic://NetAdvantage/BusinessComponentUpdated/ELEMENT", Thread=ThreadOption.UserInterface)]
        public void comboIDELEMENT_Add(object sender, ComponentEventArgs e)
        {
            this.comboIDELEMENT.Fill();
        }

        [EventSubscription("topic://NetAdvantage/BusinessComponentUpdated/RAD1GELEMENTI", Thread=ThreadOption.UserInterface)]
        public void comboRAD1GELEMENTIID_Add(object sender, ComponentEventArgs e)
        {
            this.comboRAD1GELEMENTIID.Fill();
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
                    enumerator = this.dsRAD1GELEMENTIVEZADataSet1.RAD1GELEMENTIVEZA.Rows.GetEnumerator();
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
                if (this.RAD1GELEMENTIVEZAController.Update(this))
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
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "RAD1GELEMENTIVEZA", this.m_Mode, this.dsRAD1GELEMENTIVEZADataSet1, this.dsRAD1GELEMENTIVEZADataSet1.RAD1GELEMENTIVEZA.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = this.dsRAD1GELEMENTIVEZADataSet1.RAD1GELEMENTIVEZA[0];
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.m_CurrentRow = (RAD1GELEMENTIVEZADataSet.RAD1GELEMENTIVEZARow) ((DataRowView) this.bindingSourceRAD1GELEMENTIVEZA.AddNew()).Row;
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
            ResourceManager manager = new ResourceManager(typeof(RAD1GELEMENTIVEZAFormUserControl));
            this.contextMenu1 = new ContextMenu();
            this.SetNullItem = new MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new ErrorProvider();
            this.errorProviderValidator1 = new ErrorProviderValidator(this.components);
            this.bindingSourceRAD1GELEMENTIVEZA = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceRAD1GELEMENTIVEZA).BeginInit();
            this.layoutManagerformRAD1GELEMENTIVEZA = new TableLayoutPanel();
            this.layoutManagerformRAD1GELEMENTIVEZA.SuspendLayout();
            this.layoutManagerformRAD1GELEMENTIVEZA.AutoSize = true;
            this.layoutManagerformRAD1GELEMENTIVEZA.Dock = DockStyle.Fill;
            this.layoutManagerformRAD1GELEMENTIVEZA.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformRAD1GELEMENTIVEZA.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformRAD1GELEMENTIVEZA.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformRAD1GELEMENTIVEZA.Size = size;
            this.layoutManagerformRAD1GELEMENTIVEZA.ColumnCount = 2;
            this.layoutManagerformRAD1GELEMENTIVEZA.RowCount = 3;
            this.layoutManagerformRAD1GELEMENTIVEZA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformRAD1GELEMENTIVEZA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformRAD1GELEMENTIVEZA.RowStyles.Add(new RowStyle());
            this.layoutManagerformRAD1GELEMENTIVEZA.RowStyles.Add(new RowStyle());
            this.layoutManagerformRAD1GELEMENTIVEZA.RowStyles.Add(new RowStyle());
            this.label1RAD1GELEMENTIID = new UltraLabel();
            this.comboRAD1GELEMENTIID = new RAD1GELEMENTIComboBox();
            this.label1IDELEMENT = new UltraLabel();
            this.comboIDELEMENT = new ELEMENTComboBox();
            this.dsRAD1GELEMENTIVEZADataSet1 = new RAD1GELEMENTIVEZADataSet();
            this.dsRAD1GELEMENTIVEZADataSet1.BeginInit();
            this.SuspendLayout();
            this.dsRAD1GELEMENTIVEZADataSet1.DataSetName = "dsRAD1GELEMENTIVEZA";
            this.dsRAD1GELEMENTIVEZADataSet1.Locale = new CultureInfo("hr-HR");
            this.bindingSourceRAD1GELEMENTIVEZA.DataSource = this.dsRAD1GELEMENTIVEZADataSet1;
            this.bindingSourceRAD1GELEMENTIVEZA.DataMember = "RAD1GELEMENTIVEZA";
            ((ISupportInitialize) this.bindingSourceRAD1GELEMENTIVEZA).BeginInit();
            point = new System.Drawing.Point(0, 0);
            this.label1RAD1GELEMENTIID.Location = point;
            this.label1RAD1GELEMENTIID.Name = "label1RAD1GELEMENTIID";
            this.label1RAD1GELEMENTIID.TabIndex = 1;
            this.label1RAD1GELEMENTIID.Tag = "labelRAD1GELEMENTIID";
            this.label1RAD1GELEMENTIID.Text = "Element iz RAD1-G Obrasca:";
            this.label1RAD1GELEMENTIID.StyleSetName = "FieldUltraLabel";
            this.label1RAD1GELEMENTIID.AutoSize = true;
            this.label1RAD1GELEMENTIID.Anchor = AnchorStyles.Left;
            this.label1RAD1GELEMENTIID.Appearance.TextVAlign = VAlign.Middle;
            this.label1RAD1GELEMENTIID.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1RAD1GELEMENTIID.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1RAD1GELEMENTIID.ImageSize = size;
            this.label1RAD1GELEMENTIID.Appearance.ForeColor = Color.Black;
            this.label1RAD1GELEMENTIID.BackColor = Color.Transparent;
            this.layoutManagerformRAD1GELEMENTIVEZA.Controls.Add(this.label1RAD1GELEMENTIID, 0, 0);
            this.layoutManagerformRAD1GELEMENTIVEZA.SetColumnSpan(this.label1RAD1GELEMENTIID, 1);
            this.layoutManagerformRAD1GELEMENTIVEZA.SetRowSpan(this.label1RAD1GELEMENTIID, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1RAD1GELEMENTIID.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1RAD1GELEMENTIID.MinimumSize = size;
            size = new System.Drawing.Size(0xbc, 0x17);
            this.label1RAD1GELEMENTIID.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.comboRAD1GELEMENTIID.Location = point;
            this.comboRAD1GELEMENTIID.Name = "comboRAD1GELEMENTIID";
            this.comboRAD1GELEMENTIID.Tag = "RAD1GELEMENTIID";
            this.comboRAD1GELEMENTIID.TabIndex = 0;
            this.comboRAD1GELEMENTIID.Anchor = AnchorStyles.Left;
            this.comboRAD1GELEMENTIID.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.comboRAD1GELEMENTIID.DropDownStyle = DropDownStyle.DropDown;
            this.comboRAD1GELEMENTIID.ComboBox.DropDownStyle = DropDownStyle.DropDown;
            this.comboRAD1GELEMENTIID.ComboBox.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            this.comboRAD1GELEMENTIID.Enabled = true;
            this.comboRAD1GELEMENTIID.DataBindings.Add(new Binding("Value", this.bindingSourceRAD1GELEMENTIVEZA, "RAD1GELEMENTIID"));
            this.comboRAD1GELEMENTIID.ShowPictureBox = true;
            this.comboRAD1GELEMENTIID.PictureBoxClicked += new EventHandler(this.PictureBoxClickedRAD1GELEMENTIID);
            this.comboRAD1GELEMENTIID.ValueMember = "RAD1GELEMENTIID";
            this.comboRAD1GELEMENTIID.SelectionChanged += new EventHandler(this.SelectedIndexChangedRAD1GELEMENTIID);
            this.layoutManagerformRAD1GELEMENTIVEZA.Controls.Add(this.comboRAD1GELEMENTIID, 1, 0);
            this.layoutManagerformRAD1GELEMENTIVEZA.SetColumnSpan(this.comboRAD1GELEMENTIID, 1);
            this.layoutManagerformRAD1GELEMENTIVEZA.SetRowSpan(this.comboRAD1GELEMENTIID, 1);
            padding = new Padding(0, 1, 3, 2);
            this.comboRAD1GELEMENTIID.Margin = padding;
            size = new System.Drawing.Size(0x10a, 0x17);
            this.comboRAD1GELEMENTIID.MinimumSize = size;
            size = new System.Drawing.Size(0x10a, 0x17);
            this.comboRAD1GELEMENTIID.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1IDELEMENT.Location = point;
            this.label1IDELEMENT.Name = "label1IDELEMENT";
            this.label1IDELEMENT.TabIndex = 1;
            this.label1IDELEMENT.Tag = "labelIDELEMENT";
            this.label1IDELEMENT.Text = "Element u programu plaća:";
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
            this.layoutManagerformRAD1GELEMENTIVEZA.Controls.Add(this.label1IDELEMENT, 0, 1);
            this.layoutManagerformRAD1GELEMENTIVEZA.SetColumnSpan(this.label1IDELEMENT, 1);
            this.layoutManagerformRAD1GELEMENTIVEZA.SetRowSpan(this.label1IDELEMENT, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1IDELEMENT.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDELEMENT.MinimumSize = size;
            size = new System.Drawing.Size(0xb3, 0x17);
            this.label1IDELEMENT.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.comboIDELEMENT.Location = point;
            this.comboIDELEMENT.Name = "comboIDELEMENT";
            this.comboIDELEMENT.Tag = "IDELEMENT";
            this.comboIDELEMENT.TabIndex = 0;
            this.comboIDELEMENT.Anchor = AnchorStyles.Left;
            this.comboIDELEMENT.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.comboIDELEMENT.DropDownStyle = DropDownStyle.DropDown;
            this.comboIDELEMENT.ComboBox.DropDownStyle = DropDownStyle.DropDown;
            this.comboIDELEMENT.ComboBox.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            this.comboIDELEMENT.Enabled = true;
            this.comboIDELEMENT.DataBindings.Add(new Binding("Value", this.bindingSourceRAD1GELEMENTIVEZA, "IDELEMENT"));
            this.comboIDELEMENT.ShowPictureBox = true;
            this.comboIDELEMENT.PictureBoxClicked += new EventHandler(this.PictureBoxClickedIDELEMENT);
            this.comboIDELEMENT.ValueMember = "IDELEMENT";
            this.comboIDELEMENT.SelectionChanged += new EventHandler(this.SelectedIndexChangedIDELEMENT);
            this.layoutManagerformRAD1GELEMENTIVEZA.Controls.Add(this.comboIDELEMENT, 1, 1);
            this.layoutManagerformRAD1GELEMENTIVEZA.SetColumnSpan(this.comboIDELEMENT, 1);
            this.layoutManagerformRAD1GELEMENTIVEZA.SetRowSpan(this.comboIDELEMENT, 1);
            padding = new Padding(0, 1, 3, 2);
            this.comboIDELEMENT.Margin = padding;
            size = new System.Drawing.Size(0x268, 0x17);
            this.comboIDELEMENT.MinimumSize = size;
            size = new System.Drawing.Size(0x268, 0x17);
            this.comboIDELEMENT.Size = size;
            this.Controls.Add(this.layoutManagerformRAD1GELEMENTIVEZA);
            this.SetNullItem.Index = 0;
            this.SetNullItem.Text = "Set Null";
            this.SetNullItem.Click += new EventHandler(this.SetNullItem_Click);
            this.contextMenu1.Popup += new EventHandler(this.contextMenu1_Popup);
            this.contextMenu1.MenuItems.AddRange(new MenuItem[] { this.SetNullItem });
            this.errorProvider1.DataSource = this.bindingSourceRAD1GELEMENTIVEZA;
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            this.Name = "RAD1GELEMENTIVEZAFormUserControl";
            this.Text = "Veza elementi RAD1G i elementi";
            this.AutoSize = true;
            this.AutoScroll = true;
            this.Load += new EventHandler(this.RAD1GELEMENTIVEZAFormUserControl_Load);
            this.layoutManagerformRAD1GELEMENTIVEZA.ResumeLayout(false);
            this.layoutManagerformRAD1GELEMENTIVEZA.PerformLayout();
            ((ISupportInitialize) this.bindingSourceRAD1GELEMENTIVEZA).EndInit();
            this.dsRAD1GELEMENTIVEZADataSet1.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private bool InValidState()
        {
            if ((this.RAD1GELEMENTIVEZAController.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourceRAD1GELEMENTIVEZA, this.RAD1GELEMENTIVEZAController.WorkItem, this))
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
            this.label1RAD1GELEMENTIID.Text = StringResources.RAD1GELEMENTIVEZARAD1GELEMENTIIDDescription;
            this.label1IDELEMENT.Text = StringResources.RAD1GELEMENTIVEZAIDELEMENTDescription;
        }

        private void mouseEnter_Text(object sender, EventArgs e)
        {
            this.m_BaseMethods.MouseEnterTextBase(this.toolTip1, this.m_CurrentRow, RuntimeHelpers.GetObjectValue(sender));
        }

        private void numericEditor_Enter(object sender, EventArgs e)
        {
            ((UltraNumericEditor) sender).SelectAll();
        }

        private void PictureBoxClickedIDELEMENT(object sender, EventArgs e)
        {
            EventHandler<OpenComponentEventArgs> startProcessEvent = this.StartProcess;
            if (startProcessEvent != null)
            {
                startProcessEvent(RuntimeHelpers.GetObjectValue(sender), new OpenComponentEventArgs("ELEMENT", null, DeklaritMode.Insert));
            }
        }

        private void PictureBoxClickedRAD1GELEMENTIID(object sender, EventArgs e)
        {
            EventHandler<OpenComponentEventArgs> startProcessEvent = this.StartProcess;
            if (startProcessEvent != null)
            {
                startProcessEvent(RuntimeHelpers.GetObjectValue(sender), new OpenComponentEventArgs("RAD1GELEMENTI", null, DeklaritMode.Insert));
            }
        }

        private void RAD1GELEMENTIVEZAFormUserControl_Load(object sender, EventArgs e)
        {
            this.Text = StringResources.RAD1GELEMENTIVEZADescription;
            this.errorProvider1.ContainerControl = this;
        }

        private void RegisterBindingSources()
        {
            if (!this.RAD1GELEMENTIVEZAController.WorkItem.Items.Contains("RAD1GELEMENTIVEZA|RAD1GELEMENTIVEZA"))
            {
                this.RAD1GELEMENTIVEZAController.WorkItem.Items.Add(this.bindingSourceRAD1GELEMENTIVEZA, "RAD1GELEMENTIVEZA|RAD1GELEMENTIVEZA");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        public void ResumeBindingPostUpdate()
        {
            if ((this.dsRAD1GELEMENTIVEZADataSet1.RAD1GELEMENTIVEZA.Rows[0] != null) && this.m_BaseMethods.IsInsert())
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
                this.RAD1GELEMENTIVEZAController.Update(this);
            }
        }

        [LocalCommandHandler("SaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (this.InValidState() && this.RAD1GELEMENTIVEZAController.Update(this))
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [LocalCommandHandler("SaveAndNew")]
        public void SaveAndNew(object sender, EventArgs e)
        {
            if (this.InValidState() && this.RAD1GELEMENTIVEZAController.Update(this))
            {
                this.RAD1GELEMENTIVEZAController.DataSet = new RAD1GELEMENTIVEZADataSet();
                DataSetUtil.AddEmptyRow(this.RAD1GELEMENTIVEZAController.DataSet);
                this.ChangeBinding();
                this.m_CurrentRow = this.RAD1GELEMENTIVEZAController.DataSet.RAD1GELEMENTIVEZA[0];
                DataSetUtil.CopyForeignKeyValues(this.m_CurrentRow, this.m_ForeignKeys);
                this.SetFocusInFirstField();
            }
        }

        private void SelectedIndexChangedIDELEMENT(object sender, EventArgs e)
        {
            if ((this.m_BaseMethods != null) && (this.comboIDELEMENT.SelectedItem != null))
            {
                DataRow row = ((DataRowView) this.comboIDELEMENT.SelectedItem.ListObject).Row;
                if (row != null)
                {
                    ((DataRowView) this.bindingSourceRAD1GELEMENTIVEZA.Current).Row["IDELEMENT"] = RuntimeHelpers.GetObjectValue(row["IDELEMENT"]);
                    this.bindingSourceRAD1GELEMENTIVEZA.ResetCurrentItem();
                }
            }
        }

        private void SelectedIndexChangedRAD1GELEMENTIID(object sender, EventArgs e)
        {
            if ((this.m_BaseMethods != null) && (this.comboRAD1GELEMENTIID.SelectedItem != null))
            {
                DataRow row = ((DataRowView) this.comboRAD1GELEMENTIID.SelectedItem.ListObject).Row;
                if (row != null)
                {
                    ((DataRowView) this.bindingSourceRAD1GELEMENTIVEZA.Current).Row["RAD1GELEMENTIID"] = RuntimeHelpers.GetObjectValue(row["RAD1GELEMENTIID"]);
                    this.bindingSourceRAD1GELEMENTIVEZA.ResetCurrentItem();
                }
            }
        }

        private void SetFocusInFirstField()
        {
            this.comboRAD1GELEMENTIID.Focus();
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

        protected virtual ELEMENTComboBox comboIDELEMENT
        {
            [DebuggerNonUserCode]
            get
            {
                return this._comboIDELEMENT;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._comboIDELEMENT = value;
            }
        }

        protected virtual RAD1GELEMENTIComboBox comboRAD1GELEMENTIID
        {
            [DebuggerNonUserCode]
            get
            {
                return this._comboRAD1GELEMENTIID;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._comboRAD1GELEMENTIID = value;
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

        protected virtual UltraLabel label1RAD1GELEMENTIID
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1RAD1GELEMENTIID;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1RAD1GELEMENTIID = value;
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
        public NetAdvantage.Controllers.RAD1GELEMENTIVEZAController RAD1GELEMENTIVEZAController { get; set; }

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


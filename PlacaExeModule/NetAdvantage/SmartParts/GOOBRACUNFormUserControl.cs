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
    public class GOOBRACUNFormUserControl : UserControl, IBusinessComponentUserControl
    {
        private BindingSource bindingSourceGOOBRACUN;
        private IContainer components = null;
        private GOOBRACUNDataSet dsGOOBRACUNDataSet1;
        protected TableLayoutPanel layoutManagerformGOOBRACUN;
        private bool m_AutoNumber = true;
        private GenericFormClass m_BaseMethods;
        private GOOBRACUNDataSet.GOOBRACUNRow m_CurrentRow;
        private ArrayList m_DataGrids = new ArrayList();
        private string m_FirstLevelName = "GOOBRACUN";
        private DataRow m_ForeignKeys;
        private string m_FrameworkDescription = StringResources.GOOBRACUNDescription;
        private DeklaritMode m_Mode;

        [EventPublication("topic://NetAdvantage/OpenBusinessComponent", PublicationScope.Global)]
        public event EventHandler<OpenComponentEventArgs> StartProcess;

        public GOOBRACUNFormUserControl()
        {
            this.InitializeComponent();
            this.Localize();
            this.SetSize();
        }

        public void ChangeBinding()
        {
            this.bindingSourceGOOBRACUN.DataSource = this.GOOBRACUNController.DataSet;
            this.dsGOOBRACUNDataSet1 = this.GOOBRACUNController.DataSet;
        }

        [LocalCommandHandler("Close")]
        public void Close(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [EventSubscription("topic://NetAdvantage/BusinessComponentUpdated/RADNIK", Thread=ThreadOption.UserInterface)]
        public void comboIDRADNIK_Add(object sender, ComponentEventArgs e)
        {
            this.comboIDRADNIK.Fill();
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
                    enumerator = this.dsGOOBRACUNDataSet1.GOOBRACUN.Rows.GetEnumerator();
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
                if (this.GOOBRACUNController.Update(this))
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

        private void GOOBRACUNFormUserControl_Load(object sender, EventArgs e)
        {
            this.Text = StringResources.GOOBRACUNDescription;
            this.errorProvider1.ContainerControl = this;
        }

        public void Initialize(DeklaritMode mode, DataRow foreignKeys, bool isCopy)
        {
            this.ChangeBinding();
            this.m_ForeignKeys = foreignKeys;
            this.RegisterBindingSources();
            this.m_Mode = mode;
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "GOOBRACUN", this.m_Mode, this.dsGOOBRACUNDataSet1, this.dsGOOBRACUNDataSet1.GOOBRACUN.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = this.dsGOOBRACUNDataSet1.GOOBRACUN[0];
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.m_CurrentRow = (GOOBRACUNDataSet.GOOBRACUNRow) ((DataRowView) this.bindingSourceGOOBRACUN.AddNew()).Row;
                foreach (string str in DataSetUtil.CopyForeignKeyValues(this.m_CurrentRow, foreignKeys))
                {
                    this.m_BaseMethods.SetReadOnly(str, true);
                    this.m_BaseMethods.GetLabelControl(str).Visible = false;
                    this.m_BaseMethods.GetControl(str).Visible = false;
                }
            }
            this.SetFocusInFirstField();
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GOOBRACUNFormUserControl));
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.SetNullItem = new System.Windows.Forms.MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.bindingSourceGOOBRACUN = new System.Windows.Forms.BindingSource(this.components);
            this.dsGOOBRACUNDataSet1 = new Placa.GOOBRACUNDataSet();
            this.errorProviderValidator1 = new Deklarit.Win.ErrorProviderValidator(this.components);
            this.layoutManagerformGOOBRACUN = new System.Windows.Forms.TableLayoutPanel();
            this.label1IDRADNIK = new Infragistics.Win.Misc.UltraLabel();
            this.comboIDRADNIK = new NetAdvantage.Controls.PregledRadnikaComboBox();
            this.label1OLAKSICEISKORISTIVO = new Infragistics.Win.Misc.UltraLabel();
            this.textOLAKSICEISKORISTIVO = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.label1ODBICIISKORISTIVO = new Infragistics.Win.Misc.UltraLabel();
            this.textODBICIISKORISTIVO = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceGOOBRACUN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsGOOBRACUNDataSet1)).BeginInit();
            this.layoutManagerformGOOBRACUN.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textOLAKSICEISKORISTIVO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textODBICIISKORISTIVO)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenu1
            // 
            this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.SetNullItem});
            this.contextMenu1.Popup += new System.EventHandler(this.contextMenu1_Popup);
            // 
            // SetNullItem
            // 
            this.SetNullItem.Index = 0;
            this.SetNullItem.Text = "Set Null";
            this.SetNullItem.Click += new System.EventHandler(this.SetNullItem_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            this.errorProvider1.DataSource = this.bindingSourceGOOBRACUN;
            // 
            // bindingSourceGOOBRACUN
            // 
            this.bindingSourceGOOBRACUN.DataMember = "GOOBRACUN";
            this.bindingSourceGOOBRACUN.DataSource = this.dsGOOBRACUNDataSet1;
            // 
            // dsGOOBRACUNDataSet1
            // 
            this.dsGOOBRACUNDataSet1.DataSetName = "dsGOOBRACUN";
            this.dsGOOBRACUNDataSet1.Locale = new System.Globalization.CultureInfo("hr-HR");
            // 
            // errorProviderValidator1
            // 
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            this.errorProviderValidator1.ToolTipProvider = null;
            // 
            // layoutManagerformGOOBRACUN
            // 
            this.layoutManagerformGOOBRACUN.AutoSize = true;
            this.layoutManagerformGOOBRACUN.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.layoutManagerformGOOBRACUN.ColumnCount = 2;
            this.layoutManagerformGOOBRACUN.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformGOOBRACUN.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformGOOBRACUN.Controls.Add(this.label1IDRADNIK, 0, 0);
            this.layoutManagerformGOOBRACUN.Controls.Add(this.comboIDRADNIK, 1, 0);
            this.layoutManagerformGOOBRACUN.Controls.Add(this.label1OLAKSICEISKORISTIVO, 0, 1);
            this.layoutManagerformGOOBRACUN.Controls.Add(this.textOLAKSICEISKORISTIVO, 1, 1);
            this.layoutManagerformGOOBRACUN.Controls.Add(this.label1ODBICIISKORISTIVO, 0, 2);
            this.layoutManagerformGOOBRACUN.Controls.Add(this.textODBICIISKORISTIVO, 1, 2);
            this.errorProviderValidator1.SetDisplayName(this.layoutManagerformGOOBRACUN, "");
            this.layoutManagerformGOOBRACUN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutManagerformGOOBRACUN.Location = new System.Drawing.Point(0, 0);
            this.layoutManagerformGOOBRACUN.Name = "layoutManagerformGOOBRACUN";
            this.errorProviderValidator1.SetRegularExpression(this.layoutManagerformGOOBRACUN, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.layoutManagerformGOOBRACUN, "");
            this.errorProviderValidator1.SetRequired(this.layoutManagerformGOOBRACUN, false);
            this.errorProviderValidator1.SetRequiredMessage(this.layoutManagerformGOOBRACUN, "");
            this.layoutManagerformGOOBRACUN.RowCount = 4;
            this.layoutManagerformGOOBRACUN.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutManagerformGOOBRACUN.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutManagerformGOOBRACUN.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutManagerformGOOBRACUN.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutManagerformGOOBRACUN.Size = new System.Drawing.Size(731, 150);
            this.layoutManagerformGOOBRACUN.TabIndex = 0;
            // 
            // label1IDRADNIK
            // 
            this.label1IDRADNIK.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance1.ForeColor = System.Drawing.Color.Black;
            appearance1.TextVAlignAsString = "Middle";
            this.label1IDRADNIK.Appearance = appearance1;
            this.label1IDRADNIK.AutoSize = true;
            this.label1IDRADNIK.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1IDRADNIK, "");
            this.label1IDRADNIK.Location = new System.Drawing.Point(3, 5);
            this.label1IDRADNIK.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.label1IDRADNIK.Name = "label1IDRADNIK";
            this.errorProviderValidator1.SetRegularExpression(this.label1IDRADNIK, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1IDRADNIK, "");
            this.errorProviderValidator1.SetRequired(this.label1IDRADNIK, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1IDRADNIK, "");
            this.label1IDRADNIK.Size = new System.Drawing.Size(43, 14);
            this.label1IDRADNIK.StyleSetName = "FieldUltraLabel";
            this.label1IDRADNIK.TabIndex = 1;
            this.label1IDRADNIK.Tag = "labelIDRADNIK";
            this.label1IDRADNIK.Text = "Radnik:";
            // 
            // comboIDRADNIK
            // 
            this.comboIDRADNIK.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.comboIDRADNIK.BackColor = System.Drawing.Color.Transparent;
            this.comboIDRADNIK.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSourceGOOBRACUN, "IDRADNIK", true));
            this.comboIDRADNIK.DisplayMember = "SPOJENOPREZIME";
            this.errorProviderValidator1.SetDisplayName(this.comboIDRADNIK, "");
            this.comboIDRADNIK.DropDownStyle = Infragistics.Win.DropDownStyle.DropDown;
            this.comboIDRADNIK.Location = new System.Drawing.Point(112, 1);
            this.comboIDRADNIK.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.comboIDRADNIK.MinimumSize = new System.Drawing.Size(616, 23);
            this.comboIDRADNIK.Name = "comboIDRADNIK";
            this.errorProviderValidator1.SetRegularExpression(this.comboIDRADNIK, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.comboIDRADNIK, "");
            this.errorProviderValidator1.SetRequired(this.comboIDRADNIK, false);
            this.errorProviderValidator1.SetRequiredMessage(this.comboIDRADNIK, "");
            this.comboIDRADNIK.ShowPictureBox = true;
            this.comboIDRADNIK.Size = new System.Drawing.Size(616, 23);
            this.comboIDRADNIK.TabIndex = 0;
            this.comboIDRADNIK.Tag = "IDRADNIK";
            this.comboIDRADNIK.ValueMember = "IDRADNIK";
            this.comboIDRADNIK.PictureBoxClicked += new System.EventHandler(this.PictureBoxClickedIDRADNIK);
            this.comboIDRADNIK.SelectionChanged += new System.EventHandler(this.SelectedIndexChangedIDRADNIK);
            this.comboIDRADNIK.MouseEnter += new System.EventHandler(this.mouseEnter_Text);
            // 
            // label1OLAKSICEISKORISTIVO
            // 
            this.label1OLAKSICEISKORISTIVO.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance2.ForeColor = System.Drawing.Color.Black;
            appearance2.TextVAlignAsString = "Middle";
            this.label1OLAKSICEISKORISTIVO.Appearance = appearance2;
            this.label1OLAKSICEISKORISTIVO.AutoSize = true;
            this.label1OLAKSICEISKORISTIVO.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1OLAKSICEISKORISTIVO, "");
            this.label1OLAKSICEISKORISTIVO.Location = new System.Drawing.Point(3, 30);
            this.label1OLAKSICEISKORISTIVO.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.label1OLAKSICEISKORISTIVO.Name = "label1OLAKSICEISKORISTIVO";
            this.errorProviderValidator1.SetRegularExpression(this.label1OLAKSICEISKORISTIVO, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1OLAKSICEISKORISTIVO, "");
            this.errorProviderValidator1.SetRequired(this.label1OLAKSICEISKORISTIVO, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1OLAKSICEISKORISTIVO, "");
            this.label1OLAKSICEISKORISTIVO.Size = new System.Drawing.Size(102, 14);
            this.label1OLAKSICEISKORISTIVO.StyleSetName = "FieldUltraLabel";
            this.label1OLAKSICEISKORISTIVO.TabIndex = 1;
            this.label1OLAKSICEISKORISTIVO.Tag = "labelOLAKSICEISKORISTIVO";
            this.label1OLAKSICEISKORISTIVO.Text = "Iskoristivo olakšica:";
            // 
            // textOLAKSICEISKORISTIVO
            // 
            this.textOLAKSICEISKORISTIVO.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textOLAKSICEISKORISTIVO.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSourceGOOBRACUN, "OLAKSICEISKORISTIVO", true));
            this.errorProviderValidator1.SetDisplayName(this.textOLAKSICEISKORISTIVO, "");
            this.textOLAKSICEISKORISTIVO.Location = new System.Drawing.Point(112, 27);
            this.textOLAKSICEISKORISTIVO.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.textOLAKSICEISKORISTIVO.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            this.textOLAKSICEISKORISTIVO.MinimumSize = new System.Drawing.Size(102, 22);
            this.textOLAKSICEISKORISTIVO.Name = "textOLAKSICEISKORISTIVO";
            this.textOLAKSICEISKORISTIVO.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.textOLAKSICEISKORISTIVO.PromptChar = ' ';
            this.errorProviderValidator1.SetRegularExpression(this.textOLAKSICEISKORISTIVO, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.textOLAKSICEISKORISTIVO, "");
            this.errorProviderValidator1.SetRequired(this.textOLAKSICEISKORISTIVO, false);
            this.errorProviderValidator1.SetRequiredMessage(this.textOLAKSICEISKORISTIVO, "");
            this.textOLAKSICEISKORISTIVO.Size = new System.Drawing.Size(102, 22);
            this.textOLAKSICEISKORISTIVO.TabIndex = 0;
            this.textOLAKSICEISKORISTIVO.Tag = "OLAKSICEISKORISTIVO";
            this.textOLAKSICEISKORISTIVO.Enter += new System.EventHandler(this.numericEditor_Enter);
            this.textOLAKSICEISKORISTIVO.MouseEnter += new System.EventHandler(this.mouseEnter_Text);
            // 
            // label1ODBICIISKORISTIVO
            // 
            this.label1ODBICIISKORISTIVO.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance3.ForeColor = System.Drawing.Color.Black;
            appearance3.TextVAlignAsString = "Middle";
            this.label1ODBICIISKORISTIVO.Appearance = appearance3;
            this.label1ODBICIISKORISTIVO.AutoSize = true;
            this.label1ODBICIISKORISTIVO.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1ODBICIISKORISTIVO, "");
            this.label1ODBICIISKORISTIVO.Location = new System.Drawing.Point(3, 54);
            this.label1ODBICIISKORISTIVO.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.label1ODBICIISKORISTIVO.Name = "label1ODBICIISKORISTIVO";
            this.errorProviderValidator1.SetRegularExpression(this.label1ODBICIISKORISTIVO, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1ODBICIISKORISTIVO, "");
            this.errorProviderValidator1.SetRequired(this.label1ODBICIISKORISTIVO, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1ODBICIISKORISTIVO, "");
            this.label1ODBICIISKORISTIVO.Size = new System.Drawing.Size(104, 14);
            this.label1ODBICIISKORISTIVO.StyleSetName = "FieldUltraLabel";
            this.label1ODBICIISKORISTIVO.TabIndex = 1;
            this.label1ODBICIISKORISTIVO.Tag = "labelODBICIISKORISTIVO";
            this.label1ODBICIISKORISTIVO.Text = "Iskoristivo odbitaka:";
            // 
            // textODBICIISKORISTIVO
            // 
            this.textODBICIISKORISTIVO.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textODBICIISKORISTIVO.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSourceGOOBRACUN, "ODBICIISKORISTIVO", true));
            this.errorProviderValidator1.SetDisplayName(this.textODBICIISKORISTIVO, "");
            this.textODBICIISKORISTIVO.Location = new System.Drawing.Point(112, 51);
            this.textODBICIISKORISTIVO.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.textODBICIISKORISTIVO.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            this.textODBICIISKORISTIVO.MinimumSize = new System.Drawing.Size(102, 22);
            this.textODBICIISKORISTIVO.Name = "textODBICIISKORISTIVO";
            this.textODBICIISKORISTIVO.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.textODBICIISKORISTIVO.PromptChar = ' ';
            this.errorProviderValidator1.SetRegularExpression(this.textODBICIISKORISTIVO, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.textODBICIISKORISTIVO, "");
            this.errorProviderValidator1.SetRequired(this.textODBICIISKORISTIVO, false);
            this.errorProviderValidator1.SetRequiredMessage(this.textODBICIISKORISTIVO, "");
            this.textODBICIISKORISTIVO.Size = new System.Drawing.Size(102, 22);
            this.textODBICIISKORISTIVO.TabIndex = 0;
            this.textODBICIISKORISTIVO.Tag = "ODBICIISKORISTIVO";
            this.textODBICIISKORISTIVO.Enter += new System.EventHandler(this.numericEditor_Enter);
            this.textODBICIISKORISTIVO.MouseEnter += new System.EventHandler(this.mouseEnter_Text);
            // 
            // GOOBRACUNFormUserControl
            // 
            this.AutoScroll = true;
            this.AutoSize = true;
            this.Controls.Add(this.layoutManagerformGOOBRACUN);
            this.errorProviderValidator1.SetDisplayName(this, "");
            this.Name = "GOOBRACUNFormUserControl";
            this.errorProviderValidator1.SetRegularExpression(this, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this, "");
            this.errorProviderValidator1.SetRequired(this, false);
            this.errorProviderValidator1.SetRequiredMessage(this, "");
            this.Size = new System.Drawing.Size(731, 150);
            this.Load += new System.EventHandler(this.GOOBRACUNFormUserControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceGOOBRACUN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsGOOBRACUNDataSet1)).EndInit();
            this.layoutManagerformGOOBRACUN.ResumeLayout(false);
            this.layoutManagerformGOOBRACUN.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textOLAKSICEISKORISTIVO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textODBICIISKORISTIVO)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private bool InValidState()
        {
            if ((this.GOOBRACUNController.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourceGOOBRACUN, this.GOOBRACUNController.WorkItem, this))
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
            this.label1IDRADNIK.Text = StringResources.GOOBRACUNIDRADNIKDescription;
            this.label1OLAKSICEISKORISTIVO.Text = StringResources.GOOBRACUNOLAKSICEISKORISTIVODescription;
            this.label1ODBICIISKORISTIVO.Text = StringResources.GOOBRACUNODBICIISKORISTIVODescription;
        }

        private void mouseEnter_Text(object sender, EventArgs e)
        {
            this.m_BaseMethods.MouseEnterTextBase(this.toolTip1, this.m_CurrentRow, RuntimeHelpers.GetObjectValue(sender));
        }

        private void numericEditor_Enter(object sender, EventArgs e)
        {
            ((UltraNumericEditor) sender).SelectAll();
        }

        private void PictureBoxClickedIDRADNIK(object sender, EventArgs e)
        {
            EventHandler<OpenComponentEventArgs> startProcessEvent = this.StartProcess;
            if (startProcessEvent != null)
            {
                startProcessEvent(RuntimeHelpers.GetObjectValue(sender), new OpenComponentEventArgs("RADNIK", null, DeklaritMode.Insert));
            }
        }

        private void RegisterBindingSources()
        {
            if (!this.GOOBRACUNController.WorkItem.Items.Contains("GOOBRACUN|GOOBRACUN"))
            {
                this.GOOBRACUNController.WorkItem.Items.Add(this.bindingSourceGOOBRACUN, "GOOBRACUN|GOOBRACUN");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        public void ResumeBindingPostUpdate()
        {
            if ((this.dsGOOBRACUNDataSet1.GOOBRACUN.Rows[0] != null) && this.m_BaseMethods.IsInsert())
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
                this.GOOBRACUNController.Update(this);
            }
        }

        [LocalCommandHandler("SaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (this.InValidState() && this.GOOBRACUNController.Update(this))
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [LocalCommandHandler("SaveAndNew")]
        public void SaveAndNew(object sender, EventArgs e)
        {
            if (this.InValidState() && this.GOOBRACUNController.Update(this))
            {
                this.GOOBRACUNController.DataSet = new GOOBRACUNDataSet();
                DataSetUtil.AddEmptyRow(this.GOOBRACUNController.DataSet);
                this.ChangeBinding();
                this.m_CurrentRow = this.GOOBRACUNController.DataSet.GOOBRACUN[0];
                DataSetUtil.CopyForeignKeyValues(this.m_CurrentRow, this.m_ForeignKeys);
                this.SetFocusInFirstField();
            }
        }

        private void SelectedIndexChangedIDRADNIK(object sender, EventArgs e)
        {
            if ((this.m_BaseMethods != null) && (this.comboIDRADNIK.SelectedItem != null))
            {
                DataRow row = ((DataRowView) this.comboIDRADNIK.SelectedItem.ListObject).Row;
                if (row != null)
                {
                    ((DataRowView) this.bindingSourceGOOBRACUN.Current).Row["IDRADNIK"] = RuntimeHelpers.GetObjectValue(row["IDRADNIK"]);
                    ((DataRowView) this.bindingSourceGOOBRACUN.Current).Row["PREZIME"] = RuntimeHelpers.GetObjectValue(row["PREZIME"]);
                    ((DataRowView) this.bindingSourceGOOBRACUN.Current).Row["IME"] = RuntimeHelpers.GetObjectValue(row["IME"]);
                    ((DataRowView) this.bindingSourceGOOBRACUN.Current).Row["AKTIVAN"] = RuntimeHelpers.GetObjectValue(row["AKTIVAN"]);
                    this.bindingSourceGOOBRACUN.ResetCurrentItem();
                }
            }
        }

        private void SetFocusInFirstField()
        {
            this.comboIDRADNIK.Focus();
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

        private PregledRadnikaComboBox comboIDRADNIK;

        private ContextMenu contextMenu1;

        private ErrorProvider errorProvider1;

        private ErrorProviderValidator errorProviderValidator1;

        [Browsable(false), CreateNew]
        public NetAdvantage.Controllers.GOOBRACUNController GOOBRACUNController { get; set; }

        private UltraLabel label1IDRADNIK;

        private UltraLabel label1ODBICIISKORISTIVO;

        private UltraLabel label1OLAKSICEISKORISTIVO;

        public DeklaritMode Mode;

        private MenuItem SetNullItem;

        private UltraNumericEditor textODBICIISKORISTIVO;

        private UltraNumericEditor textOLAKSICEISKORISTIVO;

        private System.Windows.Forms.ToolTip toolTip1;
    }
}


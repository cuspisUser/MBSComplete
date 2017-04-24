using Deklarit.Practices.CompositeUI;
using Deklarit.Practices.CompositeUI.NetAdvantage;
using Deklarit.Practices.CompositeUI.Services;
using Infragistics.Win;
using Infragistics.Win.UltraWinStatusBar;
using Infragistics.Win.UltraWinToolbars;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.SmartParts;
using Microsoft.Practices.ObjectBuilder;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Deklarit.Practices.CompositeUI.NetAdvantage.Shell
{
    public class InstanceModalForm : Form, IModalForm, IBuilderAware
    {
        private UltraToolbarsDockArea _ModalFormShell_Toolbars_Dock_Area_Bottom;
        private UltraToolbarsDockArea _ModalFormShell_Toolbars_Dock_Area_Left;
        private UltraToolbarsDockArea _ModalFormShell_Toolbars_Dock_Area_Right;
        private UltraToolbarsDockArea _ModalFormShell_Toolbars_Dock_Area_Top;
        private IContainer components;
        private ImageList imageList1;
        private Deklarit.Practices.CompositeUI.FormOperation m_FormOperation;
        private Control m_FormUserControl;
        private Deklarit.Practices.CompositeUI.Services.ShortcutCommandInvokerService m_ShortcutCommandInvokerService;
        private Microsoft.Practices.CompositeUI.WorkItem m_WorkItem;
        private Panel panel1;
        private UltraStatusBar ultraStatusBar1;
        private UltraToolbarsManager ultraToolbarsManager1;

        public event EventHandler<WorkspaceEventArgs> WindowFormActivated;
        public event EventHandler<WorkspaceEventArgs> WindowFormClosed;
        public event EventHandler<WorkspaceCancelEventArgs> WindowFormClosing;

        public InstanceModalForm()
        {
            this.InitializeComponent();
            base.KeyPreview = true;
            base.KeyDown += new KeyEventHandler(this.MainShell_KeyDown);
        }

        [InjectionConstructor]
        public InstanceModalForm([ServiceDependency] Microsoft.Practices.CompositeUI.WorkItem workItem) : this()
        {
            this.m_WorkItem = workItem;
        }

        DialogResult IModalForm.ShowDialog()
        {
            return base.ShowDialog();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private WorkspaceCancelEventArgs FireWindowFormClosing(object smartPart)
        {
            WorkspaceCancelEventArgs e = new WorkspaceCancelEventArgs(smartPart);
            if (this.WindowFormClosing != null)
            {
                this.WindowFormClosing(this, e);
            }
            return e;
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar1 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("UltraToolbar1");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InstanceModalForm));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this._ModalFormShell_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._ModalFormShell_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._ModalFormShell_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._ModalFormShell_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.ultraStatusBar1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.ultraToolbarsManager1 = new Infragistics.Win.UltraWinToolbars.UltraToolbarsManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ultraToolbarsManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 17);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(184, 21);
            this.panel1.TabIndex = 1;
            this.panel1.Enter += new System.EventHandler(this.panel1_Enter);
            // 
            // _ModalFormShell_Toolbars_Dock_Area_Left
            // 
            this._ModalFormShell_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._ModalFormShell_Toolbars_Dock_Area_Left.BackColor = System.Drawing.SystemColors.Control;
            this._ModalFormShell_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this._ModalFormShell_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ModalFormShell_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(0, 17);
            this._ModalFormShell_Toolbars_Dock_Area_Left.Name = "_ModalFormShell_Toolbars_Dock_Area_Left";
            this._ModalFormShell_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(0, 21);
            this._ModalFormShell_Toolbars_Dock_Area_Left.ToolbarsManager = this.ultraToolbarsManager1;
            // 
            // _ModalFormShell_Toolbars_Dock_Area_Right
            // 
            this._ModalFormShell_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._ModalFormShell_Toolbars_Dock_Area_Right.BackColor = System.Drawing.SystemColors.Control;
            this._ModalFormShell_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            this._ModalFormShell_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ModalFormShell_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(184, 17);
            this._ModalFormShell_Toolbars_Dock_Area_Right.Name = "_ModalFormShell_Toolbars_Dock_Area_Right";
            this._ModalFormShell_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(0, 21);
            this._ModalFormShell_Toolbars_Dock_Area_Right.ToolbarsManager = this.ultraToolbarsManager1;
            // 
            // _ModalFormShell_Toolbars_Dock_Area_Top
            // 
            this._ModalFormShell_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._ModalFormShell_Toolbars_Dock_Area_Top.BackColor = System.Drawing.SystemColors.Control;
            this._ModalFormShell_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top;
            this._ModalFormShell_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ModalFormShell_Toolbars_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
            this._ModalFormShell_Toolbars_Dock_Area_Top.Name = "_ModalFormShell_Toolbars_Dock_Area_Top";
            this._ModalFormShell_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(184, 17);
            this._ModalFormShell_Toolbars_Dock_Area_Top.ToolbarsManager = this.ultraToolbarsManager1;
            // 
            // _ModalFormShell_Toolbars_Dock_Area_Bottom
            // 
            this._ModalFormShell_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._ModalFormShell_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.SystemColors.Control;
            this._ModalFormShell_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            this._ModalFormShell_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ModalFormShell_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 38);
            this._ModalFormShell_Toolbars_Dock_Area_Bottom.Name = "_ModalFormShell_Toolbars_Dock_Area_Bottom";
            this._ModalFormShell_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(184, 0);
            this._ModalFormShell_Toolbars_Dock_Area_Bottom.ToolbarsManager = this.ultraToolbarsManager1;
            // 
            // ultraStatusBar1
            // 
            this.ultraStatusBar1.Location = new System.Drawing.Point(0, 38);
            this.ultraStatusBar1.Name = "ultraStatusBar1";
            this.ultraStatusBar1.Size = new System.Drawing.Size(184, 23);
            this.ultraStatusBar1.TabIndex = 0;
            // 
            // ultraToolbarsManager1
            // 
            this.ultraToolbarsManager1.DesignerFlags = 1;
            this.ultraToolbarsManager1.DockWithinContainer = this;
            this.ultraToolbarsManager1.DockWithinContainerBaseType = typeof(System.Windows.Forms.Form);
            this.ultraToolbarsManager1.ImageListLarge = this.imageList1;
            this.ultraToolbarsManager1.ImageListSmall = this.imageList1;
            this.ultraToolbarsManager1.LockToolbars = true;
            this.ultraToolbarsManager1.RuntimeCustomizationOptions = Infragistics.Win.UltraWinToolbars.RuntimeCustomizationOptions.None;
            this.ultraToolbarsManager1.ShowFullMenusDelay = 500;
            this.ultraToolbarsManager1.ShowQuickCustomizeButton = false;
            ultraToolbar1.DockedColumn = 0;
            ultraToolbar1.DockedRow = 0;
            ultraToolbar1.IsMainMenuBar = true;
            ultraToolbar1.Settings.AllowCustomize = Infragistics.Win.DefaultableBoolean.False;
            ultraToolbar1.Settings.AllowDockBottom = Infragistics.Win.DefaultableBoolean.False;
            ultraToolbar1.Settings.AllowDockLeft = Infragistics.Win.DefaultableBoolean.False;
            ultraToolbar1.Settings.AllowDockRight = Infragistics.Win.DefaultableBoolean.False;
            ultraToolbar1.Settings.AllowDockTop = Infragistics.Win.DefaultableBoolean.False;
            ultraToolbar1.Settings.AllowFloating = Infragistics.Win.DefaultableBoolean.False;
            ultraToolbar1.Settings.AllowHiding = Infragistics.Win.DefaultableBoolean.False;
            ultraToolbar1.Settings.BorderStyleDocked = Infragistics.Win.UIElementBorderStyle.None;
            ultraToolbar1.Settings.GrabHandleStyle = Infragistics.Win.UltraWinToolbars.GrabHandleStyle.None;
            ultraToolbar1.Settings.ToolDisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            ultraToolbar1.Text = "UltraToolbar1";
            this.ultraToolbarsManager1.Toolbars.AddRange(new Infragistics.Win.UltraWinToolbars.UltraToolbar[] {
            ultraToolbar1});
            // 
            // InstanceModalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(184, 61);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this._ModalFormShell_Toolbars_Dock_Area_Left);
            this.Controls.Add(this._ModalFormShell_Toolbars_Dock_Area_Right);
            this.Controls.Add(this._ModalFormShell_Toolbars_Dock_Area_Top);
            this.Controls.Add(this._ModalFormShell_Toolbars_Dock_Area_Bottom);
            this.Controls.Add(this.ultraStatusBar1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "InstanceModalForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ModalFormShell";
            this.Load += new System.EventHandler(this.ModalFormShell_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ultraToolbarsManager1)).EndInit();
            this.ResumeLayout(false);

        }

        private void MainShell_KeyDown(object sender, KeyEventArgs e)
        {
            this.m_ShortcutCommandInvokerService.WorkItem = this.WorkItem;
            this.m_ShortcutCommandInvokerService.ExecuteKeyCommand(e.KeyCode | e.Modifiers, this);
        }

        private void ModalFormShell_Load(object sender, EventArgs e)
        {
            this.m_FormUserControl.Show();
            if (this.ultraToolbarsManager1.Toolbars[0].Tools.Count == 0)
            {
                this.ultraToolbarsManager1.Toolbars[0].IsMainMenuBar = false;
                this.ultraToolbarsManager1.Toolbars[0].Visible = false;
            }
        }

        protected override void OnActivated(EventArgs e)
        {
            if ((base.Controls.Count > 0) && (this.WindowFormActivated != null))
            {
                this.WindowFormActivated(this, new WorkspaceEventArgs(this.m_FormUserControl));
            }
            base.OnActivated(e);
            this.m_WorkItem.Services.Get<IUIMessageService>().MessageControl = this.ultraStatusBar1;
            this.WorkItem.Activate();
        }

        public void OnBuiltUp(string id)
        {
            if (!this.m_WorkItem.Services.Contains<IUIMessageService>())
            {
                this.m_WorkItem.Services.Add(typeof(IUIMessageService), new StatusBarUIMessageService(this.ultraStatusBar1));
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            if ((this.WindowFormClosed != null) && (base.Controls.Count > 0))
            {
                this.WindowFormClosed(this, new WorkspaceEventArgs(this.m_FormUserControl));
            }
            base.OnClosed(e);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (base.Controls.Count > 0)
            {
                WorkspaceCancelEventArgs args = this.FireWindowFormClosing(this.m_FormUserControl);
                e.Cancel = args.Cancel;
                if (!args.Cancel)
                {
                    this.m_FormUserControl.Hide();
                }
            }
            base.OnClosing(e);
        }

        public void OnTearingDown()
        {
            if (this.m_WorkItem.Services.Contains<IUIMessageService>())
            {
                this.m_WorkItem.Services.Remove(typeof(IUIMessageService));
            }
        }

        private void panel1_Enter(object sender, EventArgs e)
        {
            this.m_WorkItem.Services.Get<IUIMessageService>().MessageControl = this.ultraStatusBar1;
        }

        public Deklarit.Practices.CompositeUI.FormOperation FormOperation
        {
            get
            {
                return this.m_FormOperation;
            }
            set
            {
                this.m_FormOperation = value;
            }
        }

        public object MenuEntrySite
        {
            get
            {
                return this.ultraToolbarsManager1.Toolbars[0];
            }
        }

        [ServiceDependency(Type=typeof(Deklarit.Practices.CompositeUI.Services.ShortcutCommandInvokerService))]
        public Deklarit.Practices.CompositeUI.Services.ShortcutCommandInvokerService ShortcutCommandInvokerService
        {
            get
            {
                return this.m_ShortcutCommandInvokerService;
            }
            set
            {
                this.m_ShortcutCommandInvokerService = value;
            }
        }

        private int ToolbarHeight
        {
            get
            {
                return this.ultraToolbarsManager1.Toolbars[0].Height;
            }
        }

        private int ToolbarWidth
        {
            get
            {
                return this.ultraToolbarsManager1.Toolbars[0].Width;
            }
        }

        public Control UserControl
        {
            set
            {
                this.m_FormUserControl = value;
                this.m_FormUserControl.Dock = DockStyle.Fill;
                this.m_FormUserControl.Location = new Point(0, 0);
                this.m_FormUserControl.Padding = new Padding(0, 3, 0, 3);
                this.panel1.AutoSize = true;
                this.panel1.Controls.Add(this.m_FormUserControl);
                if (base.ClientSize.Width < this.ToolbarWidth)
                {
                    base.Width = ((Math.Max(this.ToolbarWidth, this.m_FormUserControl.Size.Width) + base.Margin.Left) + base.Margin.Right) + this.AutoScaleBaseSize.Width;
                }
            }
        }

        public Microsoft.Practices.CompositeUI.WorkItem WorkItem
        {
            get
            {
                return this.m_WorkItem;
            }
            set
            {
                this.m_WorkItem = value;
            }
        }
    }
}


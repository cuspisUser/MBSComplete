using Deklarit.Practices.CompositeUI;
using Deklarit.Practices.CompositeUI.NetAdvantage;
using Deklarit.Practices.CompositeUI.Services;
using Infragistics.Practices.CompositeUI.WinForms;
using Infragistics.Win;
using Infragistics.Win.UltraWinDock;
using Infragistics.Win.UltraWinToolbars;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.SmartParts;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Deklarit.Practices.CompositeUI.NetAdvantage.Shell
{
    public class WorkWithModalForm : Form, IModalForm
    {
        private UltraToolbarsDockArea _WorkWithModalForm_Toolbars_Dock_Area_Bottom;
        private UltraToolbarsDockArea _WorkWithModalForm_Toolbars_Dock_Area_Left;
        private UltraToolbarsDockArea _WorkWithModalForm_Toolbars_Dock_Area_Right;
        private UltraToolbarsDockArea _WorkWithModalForm_Toolbars_Dock_Area_Top;
        private AutoHideControl _WorkWithModalShellAutoHideControl;
        private UnpinnedTabArea _WorkWithModalShellUnpinnedTabAreaBottom;
        private UnpinnedTabArea _WorkWithModalShellUnpinnedTabAreaLeft;
        private UnpinnedTabArea _WorkWithModalShellUnpinnedTabAreaRight;
        private UnpinnedTabArea _WorkWithModalShellUnpinnedTabAreaTop;
        private IContainer components;
        private ImageList imageListExplorerbar;
        private Control m_Control;
        private Deklarit.Practices.CompositeUI.Services.ShortcutCommandInvokerService m_ShortcutCommandInvokerService;
        private object m_SiteControl;
        private Microsoft.Practices.CompositeUI.WorkItem m_WorkItem;
        private UltraDockWorkspace ultraDockWorkspace1;
        private UltraToolbarsManager ultraToolbarsManager1;
        private Panel WorkWithModalForm_Fill_Panel;

        public event EventHandler<WorkspaceEventArgs> WindowFormActivated;
        public event EventHandler<WorkspaceEventArgs> WindowFormClosed;
        public event EventHandler<WorkspaceCancelEventArgs> WindowFormClosing;

        public WorkWithModalForm(Microsoft.Practices.CompositeUI.WorkItem workItem, bool displayCommandsInTaskPane)
        {
            this.InitializeComponent();
            this.m_WorkItem = workItem;
            base.KeyPreview = true;
            base.KeyDown += new KeyEventHandler(this.MainShell_KeyDown);
            if (displayCommandsInTaskPane)
            {
                TaskPanel smartPart = workItem.SmartParts.AddNew<TaskPanel>();
                this.m_SiteControl = smartPart.ExplorerBar;
                this.ultraDockWorkspace1.Show(smartPart);
                this.ultraToolbarsManager1.Toolbars[0].Visible = false;
            }
            else
            {
                this.ultraToolbarsManager1.Toolbars[0].IsMainMenuBar = true;
                this.m_SiteControl = this.ultraToolbarsManager1.Toolbars[0];
            }
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
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar1 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("MainToolbar");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WorkWithModalForm));
            this.ultraDockWorkspace1 = new Infragistics.Practices.CompositeUI.WinForms.UltraDockWorkspace(this.components);
            this._WorkWithModalShellUnpinnedTabAreaLeft = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._WorkWithModalShellUnpinnedTabAreaRight = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._WorkWithModalShellUnpinnedTabAreaTop = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._WorkWithModalShellUnpinnedTabAreaBottom = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._WorkWithModalShellAutoHideControl = new Infragistics.Win.UltraWinDock.AutoHideControl();
            this.ultraToolbarsManager1 = new Infragistics.Win.UltraWinToolbars.UltraToolbarsManager(this.components);
            this.imageListExplorerbar = new System.Windows.Forms.ImageList(this.components);
            this.WorkWithModalForm_Fill_Panel = new System.Windows.Forms.Panel();
            this._WorkWithModalForm_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._WorkWithModalForm_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._WorkWithModalForm_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._WorkWithModalForm_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            ((System.ComponentModel.ISupportInitialize)(this.ultraDockWorkspace1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraToolbarsManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // ultraDockWorkspace1
            // 
            this.ultraDockWorkspace1.HostControl = this;
            this.ultraDockWorkspace1.WorkspaceName = "DockWorkWith";
            // 
            // _WorkWithModalShellUnpinnedTabAreaLeft
            // 
            this._WorkWithModalShellUnpinnedTabAreaLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this._WorkWithModalShellUnpinnedTabAreaLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._WorkWithModalShellUnpinnedTabAreaLeft.Location = new System.Drawing.Point(0, 17);
            this._WorkWithModalShellUnpinnedTabAreaLeft.Name = "_WorkWithModalShellUnpinnedTabAreaLeft";
            this._WorkWithModalShellUnpinnedTabAreaLeft.Owner = this.ultraDockWorkspace1;
            this._WorkWithModalShellUnpinnedTabAreaLeft.Size = new System.Drawing.Size(0, 441);
            this._WorkWithModalShellUnpinnedTabAreaLeft.TabIndex = 0;
            // 
            // _WorkWithModalShellUnpinnedTabAreaRight
            // 
            this._WorkWithModalShellUnpinnedTabAreaRight.Dock = System.Windows.Forms.DockStyle.Right;
            this._WorkWithModalShellUnpinnedTabAreaRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._WorkWithModalShellUnpinnedTabAreaRight.Location = new System.Drawing.Point(512, 17);
            this._WorkWithModalShellUnpinnedTabAreaRight.Name = "_WorkWithModalShellUnpinnedTabAreaRight";
            this._WorkWithModalShellUnpinnedTabAreaRight.Owner = this.ultraDockWorkspace1;
            this._WorkWithModalShellUnpinnedTabAreaRight.Size = new System.Drawing.Size(0, 441);
            this._WorkWithModalShellUnpinnedTabAreaRight.TabIndex = 1;
            // 
            // _WorkWithModalShellUnpinnedTabAreaTop
            // 
            this._WorkWithModalShellUnpinnedTabAreaTop.Dock = System.Windows.Forms.DockStyle.Top;
            this._WorkWithModalShellUnpinnedTabAreaTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._WorkWithModalShellUnpinnedTabAreaTop.Location = new System.Drawing.Point(0, 17);
            this._WorkWithModalShellUnpinnedTabAreaTop.Name = "_WorkWithModalShellUnpinnedTabAreaTop";
            this._WorkWithModalShellUnpinnedTabAreaTop.Owner = this.ultraDockWorkspace1;
            this._WorkWithModalShellUnpinnedTabAreaTop.Size = new System.Drawing.Size(512, 0);
            this._WorkWithModalShellUnpinnedTabAreaTop.TabIndex = 2;
            // 
            // _WorkWithModalShellUnpinnedTabAreaBottom
            // 
            this._WorkWithModalShellUnpinnedTabAreaBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._WorkWithModalShellUnpinnedTabAreaBottom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._WorkWithModalShellUnpinnedTabAreaBottom.Location = new System.Drawing.Point(0, 458);
            this._WorkWithModalShellUnpinnedTabAreaBottom.Name = "_WorkWithModalShellUnpinnedTabAreaBottom";
            this._WorkWithModalShellUnpinnedTabAreaBottom.Owner = this.ultraDockWorkspace1;
            this._WorkWithModalShellUnpinnedTabAreaBottom.Size = new System.Drawing.Size(512, 0);
            this._WorkWithModalShellUnpinnedTabAreaBottom.TabIndex = 3;
            // 
            // _WorkWithModalShellAutoHideControl
            // 
            this._WorkWithModalShellAutoHideControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._WorkWithModalShellAutoHideControl.Location = new System.Drawing.Point(0, 0);
            this._WorkWithModalShellAutoHideControl.Name = "_WorkWithModalShellAutoHideControl";
            this._WorkWithModalShellAutoHideControl.Owner = this.ultraDockWorkspace1;
            this._WorkWithModalShellAutoHideControl.Size = new System.Drawing.Size(0, 0);
            this._WorkWithModalShellAutoHideControl.TabIndex = 4;
            // 
            // ultraToolbarsManager1
            // 
            this.ultraToolbarsManager1.DesignerFlags = 0;
            this.ultraToolbarsManager1.DockWithinContainer = this;
            this.ultraToolbarsManager1.DockWithinContainerBaseType = typeof(System.Windows.Forms.Form);
            this.ultraToolbarsManager1.ImageListLarge = this.imageListExplorerbar;
            this.ultraToolbarsManager1.ImageListSmall = this.imageListExplorerbar;
            this.ultraToolbarsManager1.LockToolbars = true;
            this.ultraToolbarsManager1.RuntimeCustomizationOptions = Infragistics.Win.UltraWinToolbars.RuntimeCustomizationOptions.None;
            this.ultraToolbarsManager1.ShowFullMenusDelay = 500;
            this.ultraToolbarsManager1.ShowQuickCustomizeButton = false;
            ultraToolbar1.DockedColumn = 0;
            ultraToolbar1.DockedRow = 0;
            ultraToolbar1.Settings.AllowCustomize = Infragistics.Win.DefaultableBoolean.False;
            ultraToolbar1.Settings.AllowDockBottom = Infragistics.Win.DefaultableBoolean.False;
            ultraToolbar1.Settings.AllowDockLeft = Infragistics.Win.DefaultableBoolean.False;
            ultraToolbar1.Settings.AllowDockRight = Infragistics.Win.DefaultableBoolean.False;
            ultraToolbar1.Settings.AllowDockTop = Infragistics.Win.DefaultableBoolean.False;
            ultraToolbar1.Settings.AllowFloating = Infragistics.Win.DefaultableBoolean.False;
            ultraToolbar1.Settings.AllowHiding = Infragistics.Win.DefaultableBoolean.False;
            ultraToolbar1.Settings.BorderStyleDocked = Infragistics.Win.UIElementBorderStyle.None;
            ultraToolbar1.Settings.GrabHandleStyle = Infragistics.Win.UltraWinToolbars.GrabHandleStyle.None;
            ultraToolbar1.Text = "MainToolbar";
            this.ultraToolbarsManager1.Toolbars.AddRange(new Infragistics.Win.UltraWinToolbars.UltraToolbar[] {
            ultraToolbar1});
            this.ultraToolbarsManager1.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            // 
            // imageListExplorerbar
            // 
            this.imageListExplorerbar.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageListExplorerbar.ImageSize = new System.Drawing.Size(16, 16);
            this.imageListExplorerbar.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // WorkWithModalForm_Fill_Panel
            // 
            this.WorkWithModalForm_Fill_Panel.AutoSize = true;
            this.WorkWithModalForm_Fill_Panel.Cursor = System.Windows.Forms.Cursors.Default;
            this.WorkWithModalForm_Fill_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WorkWithModalForm_Fill_Panel.Location = new System.Drawing.Point(0, 17);
            this.WorkWithModalForm_Fill_Panel.Name = "WorkWithModalForm_Fill_Panel";
            this.WorkWithModalForm_Fill_Panel.Size = new System.Drawing.Size(512, 441);
            this.WorkWithModalForm_Fill_Panel.TabIndex = 5;
            // 
            // _WorkWithModalForm_Toolbars_Dock_Area_Left
            // 
            this._WorkWithModalForm_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._WorkWithModalForm_Toolbars_Dock_Area_Left.BackColor = System.Drawing.SystemColors.Control;
            this._WorkWithModalForm_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this._WorkWithModalForm_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._WorkWithModalForm_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(0, 17);
            this._WorkWithModalForm_Toolbars_Dock_Area_Left.Name = "_WorkWithModalForm_Toolbars_Dock_Area_Left";
            this._WorkWithModalForm_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(0, 441);
            this._WorkWithModalForm_Toolbars_Dock_Area_Left.ToolbarsManager = this.ultraToolbarsManager1;
            // 
            // _WorkWithModalForm_Toolbars_Dock_Area_Right
            // 
            this._WorkWithModalForm_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._WorkWithModalForm_Toolbars_Dock_Area_Right.BackColor = System.Drawing.SystemColors.Control;
            this._WorkWithModalForm_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            this._WorkWithModalForm_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._WorkWithModalForm_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(512, 17);
            this._WorkWithModalForm_Toolbars_Dock_Area_Right.Name = "_WorkWithModalForm_Toolbars_Dock_Area_Right";
            this._WorkWithModalForm_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(0, 441);
            this._WorkWithModalForm_Toolbars_Dock_Area_Right.ToolbarsManager = this.ultraToolbarsManager1;
            // 
            // _WorkWithModalForm_Toolbars_Dock_Area_Top
            // 
            this._WorkWithModalForm_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._WorkWithModalForm_Toolbars_Dock_Area_Top.BackColor = System.Drawing.SystemColors.Control;
            this._WorkWithModalForm_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top;
            this._WorkWithModalForm_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
            this._WorkWithModalForm_Toolbars_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
            this._WorkWithModalForm_Toolbars_Dock_Area_Top.Name = "_WorkWithModalForm_Toolbars_Dock_Area_Top";
            this._WorkWithModalForm_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(512, 17);
            this._WorkWithModalForm_Toolbars_Dock_Area_Top.ToolbarsManager = this.ultraToolbarsManager1;
            // 
            // _WorkWithModalForm_Toolbars_Dock_Area_Bottom
            // 
            this._WorkWithModalForm_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._WorkWithModalForm_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.SystemColors.Control;
            this._WorkWithModalForm_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            this._WorkWithModalForm_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._WorkWithModalForm_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 458);
            this._WorkWithModalForm_Toolbars_Dock_Area_Bottom.Name = "_WorkWithModalForm_Toolbars_Dock_Area_Bottom";
            this._WorkWithModalForm_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(512, 0);
            this._WorkWithModalForm_Toolbars_Dock_Area_Bottom.ToolbarsManager = this.ultraToolbarsManager1;
            // 
            // WorkWithModalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(512, 458);
            this.Controls.Add(this._WorkWithModalShellAutoHideControl);
            this.Controls.Add(this.WorkWithModalForm_Fill_Panel);
            this.Controls.Add(this._WorkWithModalShellUnpinnedTabAreaTop);
            this.Controls.Add(this._WorkWithModalShellUnpinnedTabAreaBottom);
            this.Controls.Add(this._WorkWithModalShellUnpinnedTabAreaLeft);
            this.Controls.Add(this._WorkWithModalShellUnpinnedTabAreaRight);
            this.Controls.Add(this._WorkWithModalForm_Toolbars_Dock_Area_Left);
            this.Controls.Add(this._WorkWithModalForm_Toolbars_Dock_Area_Right);
            this.Controls.Add(this._WorkWithModalForm_Toolbars_Dock_Area_Top);
            this.Controls.Add(this._WorkWithModalForm_Toolbars_Dock_Area_Bottom);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WorkWithModalForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "WorkWithModalShell";
            ((System.ComponentModel.ISupportInitialize)(this.ultraDockWorkspace1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraToolbarsManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void MainShell_KeyDown(object sender, KeyEventArgs e)
        {
            this.m_ShortcutCommandInvokerService.WorkItem = this.WorkItem;
            this.m_ShortcutCommandInvokerService.ExecuteKeyCommand(e.KeyCode | e.Modifiers, this);
        }

        protected override void OnActivated(EventArgs e)
        {
            if ((base.Controls.Count > 0) && (this.WindowFormActivated != null))
            {
                this.WindowFormActivated(this, new WorkspaceEventArgs(this.m_Control));
            }
            base.OnActivated(e);
        }

        protected override void OnClosed(EventArgs e)
        {
            if ((this.WindowFormClosed != null) && (base.Controls.Count > 0))
            {
                this.WindowFormClosed(this, new WorkspaceEventArgs(this.m_Control));
            }
            base.OnClosed(e);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (base.Controls.Count > 0)
            {
                WorkspaceCancelEventArgs args = this.FireWindowFormClosing(this.m_Control);
                e.Cancel = args.Cancel;
                if (!args.Cancel)
                {
                    this.m_Control.Hide();
                }
            }
            base.OnClosing(e);
        }

        public object MenuEntrySite
        {
            get
            {
                return this.m_SiteControl;
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

        private int ToolbarWidth
        {
            get
            {
                return this.ultraToolbarsManager1.Toolbars[0].Width;
            }
        }

        public Control UserControl
        {
            get
            {
                return this.m_Control;
            }
            set
            {
                this.m_Control = value;
                this.m_Control.Dock = DockStyle.Fill;
                this.m_Control.Location = new Point(0, 0);
                this.m_Control.Padding = new Padding(0, 3, 0, 3);

                if (this.Tag != null)
                    if (this.Tag.ToString() != "AutoSize=false")
                        this.AutoSize = true;

                this.WorkWithModalForm_Fill_Panel.Controls.Add(this.m_Control);
                if (this.ultraToolbarsManager1.Toolbars[0].Visible)
                {
                    if (base.ClientSize.Width < this.ToolbarWidth)
                    {
                        base.ClientSize = new Size(this.ToolbarWidth, base.ClientSize.Height);
                    }
                }
                else
                {
                    if (((System.Windows.Forms.UserControl)this.m_Control).Tag != null)
                        if (((System.Windows.Forms.UserControl)this.m_Control).Tag.ToString() != "AutoSize=false")
                            ((System.Windows.Forms.UserControl)this.m_Control).AutoSize = true;
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


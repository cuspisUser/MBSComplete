using Deklarit.Practices.CompositeUI.Services;
using Deklarit.Practices.CompositeUI.Workspaces;
using Infragistics.Practices.CompositeUI.WinForms;
using Infragistics.Win;
using Infragistics.Win.UltraWinDock;
using Infragistics.Win.UltraWinTabbedMdi;
using Infragistics.Win.UltraWinToolbars;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.Commands;
using Microsoft.Practices.CompositeUI.Services;
using Microsoft.Practices.CompositeUI.SmartParts;
using Microsoft.Practices.CompositeUI.Utility;
using Microsoft.Practices.ObjectBuilder;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;


namespace Deklarit.Practices.CompositeUI.NetAdvantage.Shell
{

    public class MainShell : Form
    {
        private UltraToolbarsDockArea _MainShell_Toolbars_Dock_Area_Bottom;
        private UltraToolbarsDockArea _MainShell_Toolbars_Dock_Area_Left;
        private UltraToolbarsDockArea _MainShell_Toolbars_Dock_Area_Right;
        private UltraToolbarsDockArea _MainShell_Toolbars_Dock_Area_Top;
        private AutoHideControl _MainShellAutoHideControl;
        private UnpinnedTabArea _MainShellUnpinnedTabAreaBottom;
        private UnpinnedTabArea _MainShellUnpinnedTabAreaLeft;
        private UnpinnedTabArea _MainShellUnpinnedTabAreaRight;
        private UnpinnedTabArea _MainShellUnpinnedTabAreaTop;
        private IContainer components;
        private ImageList imageListExplorerbar;
        private ShortcutCommandInvokerService m_ShortcutCommandInvokerService;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private UltraDockWorkspace ultraDockWorkspace1;
        private UltraMdiTabWorkspace ultraMdiTabWorkspace1;
        private UltraToolbarsManager ultraToolbarsManager1;
        private WorkItem workItem;

        public MainShell()
        {
            this.InitializeComponent();
            base.IsMdiContainer = true;
            base.KeyPreview = true;
            base.KeyDown += new KeyEventHandler(this.MainShell_KeyDown);
            this.ultraToolbarsManager1.DrawFilter = new HideQCDrawFilter();
            this.MainToolbar.Visible = false;
        }


        [InjectionConstructor]
        public MainShell(WorkItem workItem, IWorkItemTypeCatalogService workItemTypeCatalog)
            : this()
        {
            this.workItem = workItem;
            this.workItem.Workspaces.Add(this.ultraMdiTabWorkspace1, "main");
            this.workItem.WorkItems.Added += new EventHandler<DataEventArgs<WorkItem>>(this.WorkItems_Added);
            this.m_ShortcutCommandInvokerService = this.workItem.Services.AddNew<ShortcutCommandInvokerService>();
            this.workItem.Workspaces.Add(new ExtendedWindowWorkspace(this), "window");
        }

        private void Data_Activated(object sender, EventArgs e)
        {
            this.m_ShortcutCommandInvokerService.WorkItem = (WorkItem)sender;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar1 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("UltraToolbar1");
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar2 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("MainToolbar");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainShell));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.ultraMdiTabWorkspace1 = new Infragistics.Practices.CompositeUI.WinForms.UltraMdiTabWorkspace(this.components);
            this.imageListExplorerbar = new System.Windows.Forms.ImageList(this.components);
            this._MainShell_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.ultraToolbarsManager1 = new Infragistics.Win.UltraWinToolbars.UltraToolbarsManager(this.components);
            this._MainShell_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._MainShell_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._MainShell_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.ultraDockWorkspace1 = new Infragistics.Practices.CompositeUI.WinForms.UltraDockWorkspace(this.components);
            this._MainShellUnpinnedTabAreaLeft = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._MainShellUnpinnedTabAreaRight = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._MainShellUnpinnedTabAreaTop = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._MainShellUnpinnedTabAreaBottom = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._MainShellAutoHideControl = new Infragistics.Win.UltraWinDock.AutoHideControl();
            ((System.ComponentModel.ISupportInitialize)(this.ultraMdiTabWorkspace1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraToolbarsManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraDockWorkspace1)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(678, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // ultraMdiTabWorkspace1
            // 
            this.ultraMdiTabWorkspace1.MdiParent = this;
            // 
            // imageListExplorerbar
            // 
            this.imageListExplorerbar.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageListExplorerbar.ImageSize = new System.Drawing.Size(16, 16);
            this.imageListExplorerbar.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // _MainShell_Toolbars_Dock_Area_Left
            // 
            this._MainShell_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._MainShell_Toolbars_Dock_Area_Left.BackColor = System.Drawing.SystemColors.Control;
            this._MainShell_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this._MainShell_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._MainShell_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(0, 40);
            this._MainShell_Toolbars_Dock_Area_Left.Name = "_MainShell_Toolbars_Dock_Area_Left";
            this._MainShell_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(0, 388);
            this._MainShell_Toolbars_Dock_Area_Left.ToolbarsManager = this.ultraToolbarsManager1;
            // 
            // ultraToolbarsManager1
            // 
            this.ultraToolbarsManager1.DesignerFlags = 1;
            this.ultraToolbarsManager1.DockWithinContainer = this;
            this.ultraToolbarsManager1.DockWithinContainerBaseType = typeof(System.Windows.Forms.Form);
            this.ultraToolbarsManager1.ImageListLarge = this.imageListExplorerbar;
            this.ultraToolbarsManager1.ImageListSmall = this.imageListExplorerbar;
            this.ultraToolbarsManager1.LockToolbars = true;
            this.ultraToolbarsManager1.ShowFullMenusDelay = 500;
            ultraToolbar1.DockedColumn = 0;
            ultraToolbar1.DockedRow = 0;
            ultraToolbar1.IsMainMenuBar = true;
            ultraToolbar1.Text = "UltraToolbar1";
            ultraToolbar2.DockedColumn = 0;
            ultraToolbar2.DockedRow = 1;
            ultraToolbar2.Settings.AllowFloating = Infragistics.Win.DefaultableBoolean.False;
            ultraToolbar2.Settings.AllowHiding = Infragistics.Win.DefaultableBoolean.False;
            ultraToolbar2.Settings.FillEntireRow = Infragistics.Win.DefaultableBoolean.True;
            ultraToolbar2.Settings.ToolDisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageOnlyOnToolbars;
            ultraToolbar2.Text = "MainToolbar";
            this.ultraToolbarsManager1.Toolbars.AddRange(new Infragistics.Win.UltraWinToolbars.UltraToolbar[] {
            ultraToolbar1,
            ultraToolbar2});
            this.ultraToolbarsManager1.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            // 
            // _MainShell_Toolbars_Dock_Area_Right
            // 
            this._MainShell_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._MainShell_Toolbars_Dock_Area_Right.BackColor = System.Drawing.SystemColors.Control;
            this._MainShell_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            this._MainShell_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._MainShell_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(678, 40);
            this._MainShell_Toolbars_Dock_Area_Right.Name = "_MainShell_Toolbars_Dock_Area_Right";
            this._MainShell_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(0, 388);
            this._MainShell_Toolbars_Dock_Area_Right.ToolbarsManager = this.ultraToolbarsManager1;
            // 
            // _MainShell_Toolbars_Dock_Area_Top
            // 
            this._MainShell_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._MainShell_Toolbars_Dock_Area_Top.BackColor = System.Drawing.SystemColors.Control;
            this._MainShell_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top;
            this._MainShell_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
            this._MainShell_Toolbars_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
            this._MainShell_Toolbars_Dock_Area_Top.Name = "_MainShell_Toolbars_Dock_Area_Top";
            this._MainShell_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(678, 40);
            this._MainShell_Toolbars_Dock_Area_Top.ToolbarsManager = this.ultraToolbarsManager1;
            // 
            // _MainShell_Toolbars_Dock_Area_Bottom
            // 
            this._MainShell_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._MainShell_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.SystemColors.Control;
            this._MainShell_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            this._MainShell_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._MainShell_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 428);
            this._MainShell_Toolbars_Dock_Area_Bottom.Name = "_MainShell_Toolbars_Dock_Area_Bottom";
            this._MainShell_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(678, 0);
            this._MainShell_Toolbars_Dock_Area_Bottom.ToolbarsManager = this.ultraToolbarsManager1;
            // 
            // ultraDockWorkspace1
            // 
            this.ultraDockWorkspace1.DragWindowStyle = Infragistics.Win.UltraWinDock.DragWindowStyle.LayeredWindowWithIndicators;
            this.ultraDockWorkspace1.HostControl = this;
            this.ultraDockWorkspace1.WorkspaceName = "Dock";
            // 
            // _MainShellUnpinnedTabAreaLeft
            // 
            this._MainShellUnpinnedTabAreaLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this._MainShellUnpinnedTabAreaLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this._MainShellUnpinnedTabAreaLeft.Location = new System.Drawing.Point(0, 40);
            this._MainShellUnpinnedTabAreaLeft.Name = "_MainShellUnpinnedTabAreaLeft";
            this._MainShellUnpinnedTabAreaLeft.Owner = this.ultraDockWorkspace1;
            this._MainShellUnpinnedTabAreaLeft.Size = new System.Drawing.Size(0, 388);
            this._MainShellUnpinnedTabAreaLeft.TabIndex = 5;
            // 
            // _MainShellUnpinnedTabAreaRight
            // 
            this._MainShellUnpinnedTabAreaRight.Dock = System.Windows.Forms.DockStyle.Right;
            this._MainShellUnpinnedTabAreaRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this._MainShellUnpinnedTabAreaRight.Location = new System.Drawing.Point(678, 40);
            this._MainShellUnpinnedTabAreaRight.Name = "_MainShellUnpinnedTabAreaRight";
            this._MainShellUnpinnedTabAreaRight.Owner = this.ultraDockWorkspace1;
            this._MainShellUnpinnedTabAreaRight.Size = new System.Drawing.Size(0, 388);
            this._MainShellUnpinnedTabAreaRight.TabIndex = 6;
            // 
            // _MainShellUnpinnedTabAreaTop
            // 
            this._MainShellUnpinnedTabAreaTop.Dock = System.Windows.Forms.DockStyle.Top;
            this._MainShellUnpinnedTabAreaTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this._MainShellUnpinnedTabAreaTop.Location = new System.Drawing.Point(0, 40);
            this._MainShellUnpinnedTabAreaTop.Name = "_MainShellUnpinnedTabAreaTop";
            this._MainShellUnpinnedTabAreaTop.Owner = this.ultraDockWorkspace1;
            this._MainShellUnpinnedTabAreaTop.Size = new System.Drawing.Size(678, 0);
            this._MainShellUnpinnedTabAreaTop.TabIndex = 7;
            // 
            // _MainShellUnpinnedTabAreaBottom
            // 
            this._MainShellUnpinnedTabAreaBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._MainShellUnpinnedTabAreaBottom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this._MainShellUnpinnedTabAreaBottom.Location = new System.Drawing.Point(0, 428);
            this._MainShellUnpinnedTabAreaBottom.Name = "_MainShellUnpinnedTabAreaBottom";
            this._MainShellUnpinnedTabAreaBottom.Owner = this.ultraDockWorkspace1;
            this._MainShellUnpinnedTabAreaBottom.Size = new System.Drawing.Size(678, 0);
            this._MainShellUnpinnedTabAreaBottom.TabIndex = 8;
            // 
            // _MainShellAutoHideControl
            // 
            this._MainShellAutoHideControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this._MainShellAutoHideControl.Location = new System.Drawing.Point(0, 0);
            this._MainShellAutoHideControl.Name = "_MainShellAutoHideControl";
            this._MainShellAutoHideControl.Owner = this.ultraDockWorkspace1;
            this._MainShellAutoHideControl.Size = new System.Drawing.Size(0, 0);
            this._MainShellAutoHideControl.TabIndex = 9;
            // 
            // MainShell
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 450);
            this.Controls.Add(this._MainShellAutoHideControl);
            this.Controls.Add(this._MainShellUnpinnedTabAreaTop);
            this.Controls.Add(this._MainShellUnpinnedTabAreaBottom);
            this.Controls.Add(this._MainShellUnpinnedTabAreaLeft);
            this.Controls.Add(this._MainShellUnpinnedTabAreaRight);
            this.Controls.Add(this._MainShell_Toolbars_Dock_Area_Left);
            this.Controls.Add(this._MainShell_Toolbars_Dock_Area_Right);
            this.Controls.Add(this._MainShell_Toolbars_Dock_Area_Top);
            this.Controls.Add(this._MainShell_Toolbars_Dock_Area_Bottom);
            this.Controls.Add(this.statusStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainShell";
            this.Text = "MainShell";
            ((System.ComponentModel.ISupportInitialize)(this.ultraMdiTabWorkspace1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraToolbarsManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraDockWorkspace1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void MainShell_KeyDown(object sender, KeyEventArgs e)
        {
            this.m_ShortcutCommandInvokerService.ExecuteKeyCommand(e.KeyCode | e.Modifiers, this);
        }

        [CommandHandler("FileExit")]
        public void OnFileExit(object sender, EventArgs e)
        {
            base.Close();
        }

        private void WorkItems_Added(object sender, DataEventArgs<WorkItem> e)
        {
            e.Data.WorkItems.Added += new EventHandler<DataEventArgs<WorkItem>>(this.WorkItems_Added2);
        }

        private void WorkItems_Added2(object sender, DataEventArgs<WorkItem> e)
        {
            e.Data.Activated += new EventHandler(this.Data_Activated);
        }

        public IWorkspace DockWorkspace
        {
            get
            {
                return this.ultraDockWorkspace1;
            }
        }

        public ImageList ImageListExplorerBar
        {
            get
            {
                return this.imageListExplorerbar;
            }
        }

        private UltraToolbar MainMenu
        {
            get
            {
                return this.ultraToolbarsManager1.Toolbars[0];
            }
        }

        public UltraToolbar MainToolbar
        {
            get
            {
                return this.ultraToolbarsManager1.Toolbars[1];
            }
        }

        public object MenuStrip
        {
            get
            {
                return this.MainMenu;
            }
        }

        public object StatusStrip
        {
            get
            {
                return this.statusStrip1;
            }
        }

        private class HideQCDrawFilter : IUIElementDrawFilter
        {
            public bool DrawElement(DrawPhase drawPhase, ref UIElementDrawParams drawParams)
            {
                return true;
            }

            public DrawPhase GetPhasesToFilter(ref UIElementDrawParams drawParams)
            {
                if (drawParams.Element is QuickCustomizeToolUIElement)
                {
                    return DrawPhase.BeforeDrawElement;
                }
                return DrawPhase.None;
            }
        }
    }
}


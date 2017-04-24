using Deklarit.Resources;
using Infragistics.Practices.CompositeUI.WinForms;
using Infragistics.Win.UltraWinDock;
using Infragistics.Win.UltraWinExplorerBar;
using Microsoft.Practices.CompositeUI.SmartParts;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Deklarit.Practices.CompositeUI.NetAdvantage
{
    [SmartPart]
    public class MenuPanel : UserControl, ISmartPartInfoProvider
    {
        private IContainer components;
        private ImageList imageListExplorerbar;
        private UltraDockSmartPartInfo ultraDockSmartPartInfo1;
        private SmartPartInfoProvider infoProvider;
        private UltraExplorerBar ultraExplorerBar1;

        public MenuPanel()
        {
            this.InitializeComponent();
            this.ultraDockSmartPartInfo1.Description = Deklarit.Resources.Resources.MainMenu;
            this.ultraDockSmartPartInfo1.Title = Deklarit.Resources.Resources.MainMenu;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        public ISmartPartInfo GetSmartPartInfo(System.Type smartPartInfoType)
        {
            return this.infoProvider.GetSmartPartInfo(smartPartInfoType);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.infoProvider = new Microsoft.Practices.CompositeUI.SmartParts.SmartPartInfoProvider();
            this.ultraDockSmartPartInfo1 = new Infragistics.Practices.CompositeUI.WinForms.UltraDockSmartPartInfo();
            this.ultraExplorerBar1 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBar();
            this.imageListExplorerbar = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ultraExplorerBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // ultraDockSmartPartInfo1
            // 
            this.ultraDockSmartPartInfo1.AllowClose = false;
            this.ultraDockSmartPartInfo1.DefaultPaneStyle = Infragistics.Win.UltraWinDock.ChildPaneStyle.VerticalSplit;
            this.ultraDockSmartPartInfo1.Description = "Main Menu";
            this.ultraDockSmartPartInfo1.Pinned = true;
            this.ultraDockSmartPartInfo1.PreferredSize = new System.Drawing.Size(210, 100);
            this.ultraDockSmartPartInfo1.Title = "Main Menu";
            this.infoProvider.Items.Add(this.ultraDockSmartPartInfo1);
            // 
            // ultraExplorerBar1
            // 
            this.ultraExplorerBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraExplorerBar1.ImageListLarge = this.imageListExplorerbar;
            this.ultraExplorerBar1.ImageListSmall = this.imageListExplorerbar;
            this.ultraExplorerBar1.Location = new System.Drawing.Point(0, 0);
            this.ultraExplorerBar1.Name = "ultraExplorerBar1";
            this.ultraExplorerBar1.Size = new System.Drawing.Size(345, 150);
            this.ultraExplorerBar1.Style = Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarStyle.OutlookNavigationPane;
            this.ultraExplorerBar1.TabIndex = 0;
            // 
            // imageListExplorerbar
            // 
            this.imageListExplorerbar.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageListExplorerbar.ImageSize = new System.Drawing.Size(16, 16);
            this.imageListExplorerbar.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // MenuPanel
            // 
            this.Controls.Add(this.ultraExplorerBar1);
            this.Name = "MenuPanel";
            this.Size = new System.Drawing.Size(345, 150);
            ((System.ComponentModel.ISupportInitialize)(this.ultraExplorerBar1)).EndInit();
            this.ResumeLayout(false);

        }

        public UltraExplorerBar ExplorerBar
        {
            get
            {
                return this.ultraExplorerBar1;
            }
        }
    }
}


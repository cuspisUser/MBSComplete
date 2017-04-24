
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
    public class SearchPanel : UserControl, ISmartPartInfoProvider
    {
        private IContainer components;
        private ImageList imageListExplorerbar;
        private SmartPartInfoProvider infoProvider;
        private UltraDockSmartPartInfo ultraDockSmartPartInfo1;
        private UltraExplorerBar ultraExplorerBar1;

        public SearchPanel()
        {
            this.InitializeComponent();
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
            this.components = new Container();
            this.ultraExplorerBar1 = new UltraExplorerBar();
            this.imageListExplorerbar = new ImageList(this.components);
            this.ultraDockSmartPartInfo1 = new UltraDockSmartPartInfo();
            this.infoProvider = new SmartPartInfoProvider();
            ((ISupportInitialize) this.ultraExplorerBar1).BeginInit();
            base.SuspendLayout();
            this.ultraExplorerBar1.Dock = DockStyle.Fill;
            this.ultraExplorerBar1.ImageListLarge = this.imageListExplorerbar;
            this.ultraExplorerBar1.ImageListSmall = this.imageListExplorerbar;
            this.ultraExplorerBar1.Location = new Point(0, 0);
            this.ultraExplorerBar1.Name = "ultraExplorerBar1";
            this.ultraExplorerBar1.Size = new Size(150, 150);
            this.ultraExplorerBar1.TabIndex = 0;
            this.imageListExplorerbar.ColorDepth = ColorDepth.Depth8Bit;
            this.imageListExplorerbar.ImageSize = new Size(0x10, 0x10);
            this.imageListExplorerbar.TransparentColor = Color.Transparent;
            this.ultraDockSmartPartInfo1.DefaultLocation = DockedLocation.DockedBottom;
            this.ultraDockSmartPartInfo1.Description = "Search";
            this.ultraDockSmartPartInfo1.PreferredSize = new Size(140, 100);
            this.ultraDockSmartPartInfo1.Title = "Search";
            this.ultraDockSmartPartInfo1.Pinned = false;
            this.infoProvider.Items.Add(this.ultraDockSmartPartInfo1);
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            base.Controls.Add(this.ultraExplorerBar1);
            base.Name = "SearchPanel";
            ((ISupportInitialize) this.ultraExplorerBar1).EndInit();
            base.ResumeLayout(false);
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


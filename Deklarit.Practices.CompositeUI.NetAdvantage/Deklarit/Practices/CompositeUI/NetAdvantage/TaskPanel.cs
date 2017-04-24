namespace Deklarit.Practices.CompositeUI.NetAdvantage
{
    using Deklarit.Resources;
    using Infragistics.Practices.CompositeUI.WinForms;
    using Infragistics.Win.UltraWinDock;
    using Infragistics.Win.UltraWinExplorerBar;
    using Microsoft.Practices.CompositeUI.SmartParts;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    [SmartPart]
    public class TaskPanel : UserControl, ISmartPartInfoProvider
    {
        private IContainer components = null;
        private ImageList imageListExplorerbar;
        private SmartPartInfoProvider infoProvider;
        private UltraDockSmartPartInfo ultraDockSmartPartInfo1;
        private UltraExplorerBar ultraExplorerBar1;

        public TaskPanel()
        {
            this.InitializeComponent();
            this.ultraDockSmartPartInfo1.Description = Deklarit.Resources.Resources.Tasks;
            this.ultraDockSmartPartInfo1.Title = Deklarit.Resources.Resources.Tasks;
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
            ComponentResourceManager manager = new ComponentResourceManager(typeof(TaskPanel));
            this.ultraExplorerBar1 = new UltraExplorerBar();
            this.ultraDockSmartPartInfo1 = new UltraDockSmartPartInfo();
            this.infoProvider = new SmartPartInfoProvider();
            this.imageListExplorerbar = new ImageList(this.components);
            ((ISupportInitialize) this.ultraExplorerBar1).BeginInit();
            base.SuspendLayout();
            this.ultraExplorerBar1.Dock = DockStyle.Fill;
            this.ultraExplorerBar1.ImageListLarge = this.imageListExplorerbar;
            this.ultraExplorerBar1.ImageListSmall = this.imageListExplorerbar;
            this.ultraExplorerBar1.Location = new Point(0, 0);
            this.ultraExplorerBar1.Name = "ultraExplorerBar1";
            this.ultraExplorerBar1.Size = new Size(150, 150);
            this.ultraExplorerBar1.TabIndex = 0;
            this.ultraDockSmartPartInfo1.DefaultLocation = DockedLocation.DockedRight;
            this.ultraDockSmartPartInfo1.Description = "Tasks";
            this.ultraDockSmartPartInfo1.Pinned = true;
            this.ultraDockSmartPartInfo1.PreferredSize = new Size(180, 100);
            this.ultraDockSmartPartInfo1.Title = "Tasks";
            this.ultraDockSmartPartInfo1.AllowClose = false;
            this.infoProvider.Items.Add(this.ultraDockSmartPartInfo1);
            /*this.imageListExplorerbar.ImageStream = (ImageListStreamer) manager.GetObject("imageListExplorerbar.ImageStream");
            this.imageListExplorerbar.TransparentColor = Color.Transparent;
            this.imageListExplorerbar.Images.SetKeyName(0, "");
            this.imageListExplorerbar.Images.SetKeyName(1, "");
            this.imageListExplorerbar.Images.SetKeyName(2, "");
            this.imageListExplorerbar.Images.SetKeyName(3, "");
            this.imageListExplorerbar.Images.SetKeyName(4, "");
            this.imageListExplorerbar.Images.SetKeyName(5, "");
            this.imageListExplorerbar.Images.SetKeyName(6, "");
            this.imageListExplorerbar.Images.SetKeyName(7, "");
            this.imageListExplorerbar.Images.SetKeyName(8, "");
            this.imageListExplorerbar.Images.SetKeyName(9, "");
            this.imageListExplorerbar.Images.SetKeyName(10, "");
            this.imageListExplorerbar.Images.SetKeyName(11, "");
            this.imageListExplorerbar.Images.SetKeyName(12, "");
            this.imageListExplorerbar.Images.SetKeyName(13, "dataprovider.ico");*/
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            base.Controls.Add(this.ultraExplorerBar1);
            base.Name = "TaskPanel";
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


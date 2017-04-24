using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using Microsoft.Practices.CompositeUI.SmartParts;
using Deklarit.Practices.CompositeUI.Services;
using Deklarit.Resources;
using NetAdvantage.Controllers;
using NetAdvantage.WorkItems;
using Deklarit.Practices.CompositeUI;
using System.Data;

namespace ServisModule
{
    [SmartPart]
    public class RSSWorkWith : UserControl, ISmartPartInfoProvider, IFilteredView
    {
        private SmartPartInfoProvider infoProvider;

        private string m_FillByMethod = "";
        private DataRow m_FillByRow;
        private DataRow m_RowSelected { get; set; }
        private Deklarit.Practices.CompositeUI.WorkWithMode m_WorkWithMode;

        private WebBrowser webBrowser1;
        private SmartPartInfo smartPartInfo1;

        public RSSWorkWith()
        {
            this.InitializeComponent();
            this.smartPartInfo1 = new SmartPartInfo("RSS vijesti", string.Empty);
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);
        }

        private void InitializeComponent()
        {
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(0, 0);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(1131, 731);
            this.webBrowser1.TabIndex = 0;
            // 
            // RSSWorkWith
            // 
            this.Controls.Add(this.webBrowser1);
            this.Name = "RSSWorkWith";
            this.Size = new System.Drawing.Size(1131, 731);
            this.ResumeLayout(false);
        }

        protected override void OnLoad(EventArgs e)
        {
            this.Dock = DockStyle.Fill;

            LoadRSSNews();

            base.OnLoad(e);
        }

        private void LoadRSSNews()
        {
            this.webBrowser1.Url = new Uri("http://vugergrad.hr/index.php?id=148");
        }

        public DataRow FillByRow
        {
            set
            {
                this.m_FillByRow = value;
            }
        }

        public string FillMethod
        {
            set
            {
                this.m_FillByMethod = value;
            }
        }

        public DataRow SelectedRow
        {
            get
            {
                return this.m_RowSelected;
            }
        }

        Deklarit.Practices.CompositeUI.WorkWithMode Deklarit.Practices.CompositeUI.IFilteredView.WorkWithMode
        {
            set
            {
                this.m_WorkWithMode = value;
            }
        }

        public ISmartPartInfo GetSmartPartInfo(Type smartPartInfoType)
        {
            return this.infoProvider.GetSmartPartInfo(smartPartInfoType);
        }
    }
}

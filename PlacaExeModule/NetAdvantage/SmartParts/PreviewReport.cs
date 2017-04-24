namespace NetAdvantage.SmartParts
{
    using CrystalDecisions.CrystalReports.Engine;
    using CrystalDecisions.Windows.Forms;
    using Deklarit.Practices.CompositeUI;
    using Microsoft.Practices.CompositeUI;
    using Microsoft.Practices.CompositeUI.SmartParts;
    using Microsoft.Practices.ObjectBuilder;
    using NetAdvantage.Controllers;
    using NetAdvantage.WorkItems;
    using System;
    using System.Data;
    using System.Diagnostics;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;
    using System.Configuration;
    using CrystalDecisions.Shared;
    using CrystalDecisions.ReportSource;
    using CrystalDecisions.Web;


    [SmartPart]
    public class PreviewReport : UserControl, ISmartPartInfoProvider, IFilteredView
    {
        [AccessedThroughProperty("Preglednik")]
        private CrystalReportViewer _Preglednik;
        private SmartPartInfoProvider infoProvider;
        
        private SmartPartInfo smartPartInfo1;

        public PreviewReport()
        {
            base.Load += new EventHandler(this.UserControl1_Load);
            this.InitializeComponent();

            this.smartPartInfo1 = new SmartPartInfo("Pregled izvještaja", "Pregled izvještaja");
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);
        }


        public ISmartPartInfo GetSmartPartInfo(Type smartPartInfoType)
        {
            return this.infoProvider.GetSmartPartInfo(smartPartInfoType);
        }

        private void InitializeComponent()
        {
            this.Preglednik = new CrystalReportViewer();
            this.SuspendLayout();
            this.Preglednik.ActiveViewIndex = -1;
            this.Preglednik.BorderStyle = BorderStyle.FixedSingle;
            this.Preglednik.Dock = DockStyle.Fill;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.Preglednik.Location = point;
            this.Preglednik.Name = "Preglednik";
            this.Preglednik.ShowGroupTreeButton = false;
            this.Preglednik.ShowParameterPanelButton = false;
            Size size = new System.Drawing.Size(0x213, 0x1b2);
            this.Preglednik.Size = size;
            this.Preglednik.TabIndex = 0;
            this.Preglednik.ToolPanelView = ToolPanelViewType.None;
            this.Controls.Add(this.Preglednik);
            this.Name = "PreviewReport";
            size = new System.Drawing.Size(0x213, 0x1b2);
            this.Size = size;
            this.ResumeLayout(false);
        }

        private void Preglednik_DoubleClick(object sender, EventArgs e)
        {
            frmPregledIzvjestaja izvjestaja = new frmPregledIzvjestaja {
                Text = this.ParentForm.Text
            };
            PreviewReportWorkItem workItem = (PreviewReportWorkItem) this.Controller.WorkItem;
            object izvjestaj = workItem.Izvjestaj;
            izvjestaja.Postavi_Izvjestaj(ref izvjestaj);
            workItem.Izvjestaj = (ReportDocument) izvjestaj;
            izvjestaja.Show();
        }

        private void Preglednik_Load(object sender, EventArgs e)
        {
        }

        private void UltraButton1_Click(object sender, EventArgs e)
        {
            this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
            this.Preglednik.ReportSource = ((PreviewReportWorkItem) this.Controller.WorkItem).Izvjestaj;
        }

        [CreateNew]
        public PreviewReportControler Controller { get; set; }

        DataRow Deklarit.Practices.CompositeUI.IFilteredView.FillByRow
        {
            set
            {
            }
        }

        string Deklarit.Practices.CompositeUI.IFilteredView.FillMethod
        {
            set
            {
            }
        }

        DataRow Deklarit.Practices.CompositeUI.IFilteredView.SelectedRow
        {
            get
            {
                DataRow row = null;
                return row;
            }
        }

        Deklarit.Practices.CompositeUI.WorkWithMode Deklarit.Practices.CompositeUI.IFilteredView.WorkWithMode
        {
            set
            {
            }
        }

        public DataRow FillByRow
        {
            set
            {
            }
        }

        public string FillMethod
        {
            set
            {
            }
        }

        internal CrystalReportViewer Preglednik
        {
            [DebuggerNonUserCode]
            get
            {
                return this._Preglednik;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                EventHandler handler = new EventHandler(this.Preglednik_Load);
                EventHandler handler2 = new EventHandler(this.Preglednik_DoubleClick);
                if (this._Preglednik != null)
                {
                    this._Preglednik.Load -= handler;
                    this._Preglednik.DoubleClick -= handler2;
                }
                this._Preglednik = value;
                if (this._Preglednik != null)
                {
                    this._Preglednik.Load += handler;
                    this._Preglednik.DoubleClick += handler2;
                }
            }
        }

        public DataRow SelectedRow
        {
            get
            {
                DataRow row = null;
                return row;
            }
        }

        Deklarit.Practices.CompositeUI.WorkWithMode WorkWithMode
        {
            set
            {
            }
        }
    }
}


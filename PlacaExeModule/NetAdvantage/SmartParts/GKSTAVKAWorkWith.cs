namespace NetAdvantage.SmartParts
{
    using Deklarit;
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.BuilderStrategies;
    using Deklarit.Practices.CompositeUI.NetAdvantage.Services;
    using Deklarit.Practices.CompositeUI.Services;
    using Deklarit.Resources;
    using Infragistics.Win;
    using Infragistics.Win.Printing;
    using Infragistics.Win.UltraWinGrid;
    using Infragistics.Win.UltraWinGrid.ExcelExport;
    using Microsoft.Practices.CompositeUI;
    using Microsoft.Practices.CompositeUI.EventBroker;
    using Microsoft.Practices.CompositeUI.SmartParts;
    using Microsoft.Practices.ObjectBuilder;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using NetAdvantage;
    using NetAdvantage.Controllers;
    using NetAdvantage.WorkItems;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Diagnostics;
    using System.Drawing;
    using System.Resources;
    using Placa;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    [SmartPart]
    public class GKSTAVKAWorkWith : UserControl, ISmartPartInfoProvider, IFilteredView
    {
        [AccessedThroughProperty("userControlDataGridGKSTAVKA")]
        private GKSTAVKAUserDataGrid _userControlDataGridGKSTAVKA;
        private IContainer components = null;
        private SmartPartInfoProvider infoProvider;
        private string m_FillByMethod = "";
        private DataRow m_FillByRow;
        private DataRow m_RowSelected;
        private Deklarit.Practices.CompositeUI.WorkWithMode m_WorkWithMode;
        private SmartPartInfo smartPartInfo1;
        private UltraGridPrintDocument ultraGridPrintDocument1;
        private UltraPrintPreviewDialog ultraPrintPreviewDialog1;

        public GKSTAVKAWorkWith()
        {
            this.InitializeComponent();
            this.smartPartInfo1 = new SmartPartInfo(string.Format(Deklarit.Resources.Resources.WorkWithTitle, StringResources.GKSTAVKADescription), string.Format(Deklarit.Resources.Resources.WorkWithTitle, StringResources.GKSTAVKADescription));
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);
            this.userControlDataGridGKSTAVKA.DataGrid.AfterRowActivate += new EventHandler(this.DataGrid_AfterRowActivate);
        }

        [OnBuiltUp]
        public void AddSelectedRowProviderService()
        {
            UltraGridSelectedRowsProviderService<GKSTAVKADataSet> serviceInstance = new UltraGridSelectedRowsProviderService<GKSTAVKADataSet>(this.userControlDataGridGKSTAVKA.DataGrid);
            this.Controller.WorkItem.Services.Add(typeof(ISelectedRowsProviderService), serviceInstance);
        }

        [LocalCommandHandler("Copy")]
        public void CopyHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.Controller.Copy(this.CurrentDataRow);
            }
        }

        private void DataGrid_AfterRowActivate(object sender, EventArgs e)
        {
            if (this.CurrentDataRow != null)
            {
                this.Controller.CurrentRow = this.CurrentDataRow;
            }
        }

        private void DataGrid_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            if (!this.userControlDataGridGKSTAVKA.DataGrid.GridLoading && ((this.userControlDataGridGKSTAVKA.DataGrid.ActiveRow != null) && (this.userControlDataGridGKSTAVKA.DataGrid.ActiveCell != null)))
            {
                this.DefaultAction();
            }
        }

        private void DataGrid_SetFocus()
        {
            if ((this.userControlDataGridGKSTAVKA.DataGrid.Rows.Count > 0) && (this.userControlDataGridGKSTAVKA.DataGrid.Rows[0] != null))
            {
                this.userControlDataGridGKSTAVKA.DataGrid.Rows[0].Activate();
            }
        }

        private void DefaultAction()
        {
            if (this.InValidState())
            {
                this.Controller.Update(this.CurrentDataRow);
            }
        }

        [LocalCommandHandler("Delete")]
        public void DeleteHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.Controller.Delete(this.CurrentDataRow);
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

        [LocalCommandHandler("ExportExcel")]
        public void ExportExcelHandler(object sender, EventArgs e)
        {
            if (this.Controller.WorkItem.Status == WorkItemStatus.Active)
            {
                SaveFileDialog dialog = new SaveFileDialog {
                    DefaultExt = "xls",
                    Filter = "Excel file (*.xls)|*.xls"
                };
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    new UltraGridExcelExporter().Export(this.userControlDataGridGKSTAVKA.DataGrid, dialog.FileName);
                    Process.Start(dialog.FileName);
                }
            }
        }

        [LocalCommandHandler("FillAll")]
        public void FillAll(object sender, EventArgs e)
        {
            if (this.Controller.WorkItem.Status == WorkItemStatus.Active)
            {
                bool fillByPage = this.userControlDataGridGKSTAVKA.DataGrid.FillByPage;
                this.userControlDataGridGKSTAVKA.DataGrid.FillByPage = false;
                this.FillData();
                this.userControlDataGridGKSTAVKA.DataGrid.FillByPage = fillByPage;
            }
        }

        public virtual void FillData()
        {
            try
            {
                string fillByMethod = this.m_FillByMethod;
                if (fillByMethod == "FillByIDKONTO")
                {
                    this.FillFillByIDKONTO();
                }
                else if (fillByMethod == "FillByGKGODIDGODINE")
                {
                    this.FillFillByGKGODIDGODINE();
                }
                else if (fillByMethod == "FillByIDDOKUMENT")
                {
                    this.FillFillByIDDOKUMENT();
                }
                else if (fillByMethod == "FillByIDDOKUMENTBROJDOKUMENTA")
                {
                    this.FillFillByIDDOKUMENTBROJDOKUMENTA();
                }
                else if (fillByMethod == "FillByIDDOKUMENTBROJDOKUMENTAGKGODIDGODINE")
                {
                    this.FillFillByIDDOKUMENTBROJDOKUMENTAGKGODIDGODINE();
                }
                else if (fillByMethod == "FillByBROJSTAVKE")
                {
                    this.FillFillByBROJSTAVKE();
                }
                else if (fillByMethod == "FillByIDMJESTOTROSKA")
                {
                    this.FillFillByIDMJESTOTROSKA();
                }
                else if (fillByMethod == "FillByIDORGJED")
                {
                    this.FillFillByIDORGJED();
                }
                else if (fillByMethod == "FillByIDPARTNER")
                {
                    this.FillFillByIDPARTNER();
                }
                else
                {
                    this.userControlDataGridGKSTAVKA.FillMethod = "Fill";
                }
                this.userControlDataGridGKSTAVKA.Fill();
                if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
                {
                    ((GKSTAVKASelectionListWorkItem) this.Controller.WorkItem).DataSet = this.userControlDataGridGKSTAVKA.DataView.Table.DataSet;
                }
                else
                {
                    ((GKSTAVKAWorkWithWorkItem) this.Controller.WorkItem).DataSet = this.userControlDataGridGKSTAVKA.DataView.Table.DataSet;
                }
            }
            catch (System.Exception exception1)
            {
                throw exception1;
                
                
                
            }
        }

        private void FillFillByBROJSTAVKE()
        {
            string str = "";
            this.userControlDataGridGKSTAVKA.FillMethod = "FillByBROJSTAVKE";
            this.userControlDataGridGKSTAVKA.FillByBROJSTAVKEBROJSTAVKE = Conversions.ToInteger(this.GetValueFromRow("BROJSTAVKE", "BROJSTAVKE"));
            str = str + "," + this.userControlDataGridGKSTAVKA.FillByBROJSTAVKEBROJSTAVKE.ToString() + " ";
            if (FormHelperClass.GetDescription(this.m_FillByRow).Length == 0)
            {
                if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
                {
                    this.Text = Deklarit.Resources.Resources.Select + "GKSTAVKA " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
                }
                else
                {
                    this.Text = Deklarit.Resources.Resources.Workwith + "GKSTAVKA " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
                }
            }
        }

        private void FillFillByGKGODIDGODINE()
        {
            string str = "";
            this.userControlDataGridGKSTAVKA.FillMethod = "FillByGKGODIDGODINE";
            this.userControlDataGridGKSTAVKA.FillByGKGODIDGODINEGKGODIDGODINE = Conversions.ToShort(this.GetValueFromRow("IDGODINE", "GKGODIDGODINE"));
            str = str + "," + this.userControlDataGridGKSTAVKA.FillByGKGODIDGODINEGKGODIDGODINE.ToString() + " ";
            if (FormHelperClass.GetDescription(this.m_FillByRow).Length == 0)
            {
                if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
                {
                    this.Text = Deklarit.Resources.Resources.Select + "GKSTAVKA " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
                }
                else
                {
                    this.Text = Deklarit.Resources.Resources.Workwith + "GKSTAVKA " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
                }
            }
        }

        private void FillFillByIDDOKUMENT()
        {
            string str = "";
            this.userControlDataGridGKSTAVKA.FillMethod = "FillByIDDOKUMENT";
            this.userControlDataGridGKSTAVKA.FillByIDDOKUMENTIDDOKUMENT = Conversions.ToInteger(this.GetValueFromRow("IDDOKUMENT", "IDDOKUMENT"));
            str = str + "," + this.userControlDataGridGKSTAVKA.FillByIDDOKUMENTIDDOKUMENT.ToString() + " ";
            if (FormHelperClass.GetDescription(this.m_FillByRow).Length == 0)
            {
                if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
                {
                    this.Text = Deklarit.Resources.Resources.Select + "GKSTAVKA " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
                }
                else
                {
                    this.Text = Deklarit.Resources.Resources.Workwith + "GKSTAVKA " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
                }
            }
        }

        private void FillFillByIDDOKUMENTBROJDOKUMENTA()
        {
            string str = "";
            this.userControlDataGridGKSTAVKA.FillMethod = "FillByIDDOKUMENTBROJDOKUMENTA";
            this.userControlDataGridGKSTAVKA.FillByIDDOKUMENTBROJDOKUMENTAIDDOKUMENT = Conversions.ToInteger(this.GetValueFromRow("IDDOKUMENT", "IDDOKUMENT"));
            str = str + "," + this.userControlDataGridGKSTAVKA.FillByIDDOKUMENTBROJDOKUMENTAIDDOKUMENT.ToString() + " ";
            this.userControlDataGridGKSTAVKA.FillByIDDOKUMENTBROJDOKUMENTABROJDOKUMENTA = Conversions.ToInteger(this.GetValueFromRow("BROJDOKUMENTA", "BROJDOKUMENTA"));
            str = str + "," + this.userControlDataGridGKSTAVKA.FillByIDDOKUMENTBROJDOKUMENTABROJDOKUMENTA.ToString() + " ";
            if (FormHelperClass.GetDescription(this.m_FillByRow).Length == 0)
            {
                if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
                {
                    this.Text = Deklarit.Resources.Resources.Select + "GKSTAVKA " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
                }
                else
                {
                    this.Text = Deklarit.Resources.Resources.Workwith + "GKSTAVKA " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
                }
            }
        }

        private void FillFillByIDDOKUMENTBROJDOKUMENTAGKGODIDGODINE()
        {
            string str = "";
            this.userControlDataGridGKSTAVKA.FillMethod = "FillByIDDOKUMENTBROJDOKUMENTAGKGODIDGODINE";
            this.userControlDataGridGKSTAVKA.FillByIDDOKUMENTBROJDOKUMENTAGKGODIDGODINEIDDOKUMENT = Conversions.ToInteger(this.GetValueFromRow("IDDOKUMENT", "IDDOKUMENT"));
            str = str + "," + this.userControlDataGridGKSTAVKA.FillByIDDOKUMENTBROJDOKUMENTAGKGODIDGODINEIDDOKUMENT.ToString() + " ";
            this.userControlDataGridGKSTAVKA.FillByIDDOKUMENTBROJDOKUMENTAGKGODIDGODINEBROJDOKUMENTA = Conversions.ToInteger(this.GetValueFromRow("BROJDOKUMENTA", "BROJDOKUMENTA"));
            str = str + "," + this.userControlDataGridGKSTAVKA.FillByIDDOKUMENTBROJDOKUMENTAGKGODIDGODINEBROJDOKUMENTA.ToString() + " ";
            this.userControlDataGridGKSTAVKA.FillByIDDOKUMENTBROJDOKUMENTAGKGODIDGODINEGKGODIDGODINE = Conversions.ToShort(this.GetValueFromRow("IDGODINE", "GKGODIDGODINE"));
            str = str + "," + this.userControlDataGridGKSTAVKA.FillByIDDOKUMENTBROJDOKUMENTAGKGODIDGODINEGKGODIDGODINE.ToString() + " ";
            if (FormHelperClass.GetDescription(this.m_FillByRow).Length == 0)
            {
                if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
                {
                    this.Text = Deklarit.Resources.Resources.Select + "GKSTAVKA " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
                }
                else
                {
                    this.Text = Deklarit.Resources.Resources.Workwith + "GKSTAVKA " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
                }
            }
        }

        private void FillFillByIDKONTO()
        {
            string str = "";
            this.userControlDataGridGKSTAVKA.FillMethod = "FillByIDKONTO";
            this.userControlDataGridGKSTAVKA.FillByIDKONTOIDKONTO = Conversions.ToString(this.GetValueFromRow("IDKONTO", "IDKONTO"));
            str = str + "," + this.userControlDataGridGKSTAVKA.FillByIDKONTOIDKONTO.ToString() + " ";
            if (FormHelperClass.GetDescription(this.m_FillByRow).Length == 0)
            {
                if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
                {
                    this.Text = Deklarit.Resources.Resources.Select + "GKSTAVKA " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
                }
                else
                {
                    this.Text = Deklarit.Resources.Resources.Workwith + "GKSTAVKA " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
                }
            }
        }

        private void FillFillByIDMJESTOTROSKA()
        {
            string str = "";
            this.userControlDataGridGKSTAVKA.FillMethod = "FillByIDMJESTOTROSKA";
            this.userControlDataGridGKSTAVKA.FillByIDMJESTOTROSKAIDMJESTOTROSKA = Conversions.ToInteger(this.GetValueFromRow("IDMJESTOTROSKA", "IDMJESTOTROSKA"));
            str = str + "," + this.userControlDataGridGKSTAVKA.FillByIDMJESTOTROSKAIDMJESTOTROSKA.ToString() + " ";
            if (FormHelperClass.GetDescription(this.m_FillByRow).Length == 0)
            {
                if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
                {
                    this.Text = Deklarit.Resources.Resources.Select + "GKSTAVKA " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
                }
                else
                {
                    this.Text = Deklarit.Resources.Resources.Workwith + "GKSTAVKA " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
                }
            }
        }

        private void FillFillByIDORGJED()
        {
            string str = "";
            this.userControlDataGridGKSTAVKA.FillMethod = "FillByIDORGJED";
            this.userControlDataGridGKSTAVKA.FillByIDORGJEDIDORGJED = Conversions.ToInteger(this.GetValueFromRow("IDORGJED", "IDORGJED"));
            str = str + "," + this.userControlDataGridGKSTAVKA.FillByIDORGJEDIDORGJED.ToString() + " ";
            if (FormHelperClass.GetDescription(this.m_FillByRow).Length == 0)
            {
                if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
                {
                    this.Text = Deklarit.Resources.Resources.Select + "GKSTAVKA " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
                }
                else
                {
                    this.Text = Deklarit.Resources.Resources.Workwith + "GKSTAVKA " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
                }
            }
        }

        private void FillFillByIDPARTNER()
        {
            string str = "";
            this.userControlDataGridGKSTAVKA.FillMethod = "FillByIDPARTNER";
            this.userControlDataGridGKSTAVKA.FillByIDPARTNERIDPARTNER = Conversions.ToInteger(this.GetValueFromRow("IDPARTNER", "IDPARTNER"));
            str = str + "," + this.userControlDataGridGKSTAVKA.FillByIDPARTNERIDPARTNER.ToString() + " ";
            if (FormHelperClass.GetDescription(this.m_FillByRow).Length == 0)
            {
                if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
                {
                    this.Text = Deklarit.Resources.Resources.Select + "GKSTAVKA " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
                }
                else
                {
                    this.Text = Deklarit.Resources.Resources.Workwith + "GKSTAVKA " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
                }
            }
        }

        public ISmartPartInfo GetSmartPartInfo(Type smartPartInfoType)
        {
            return this.infoProvider.GetSmartPartInfo(smartPartInfoType);
        }

        private object GetValueFromRow(string fieldSuperTypeName, string fieldName)
        {
            if (this.m_FillByRow.Table.Columns.Contains(fieldSuperTypeName))
            {
                return this.m_FillByRow[fieldSuperTypeName];
            }
            return this.m_FillByRow[fieldName];
        }

        private void GKSTAVKAWorkWith_Load(object sender, EventArgs e)
        {
            if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
            {
                this.userControlDataGridGKSTAVKA.DataGrid.DoubleClick += new EventHandler(this.Select_Click);
                Size size = new System.Drawing.Size(600, 500);
                this.Parent.Parent.Size = size;
            }
            else
            {
                this.userControlDataGridGKSTAVKA.DataGrid.DoubleClickRow += new DoubleClickRowEventHandler(this.DataGrid_DoubleClickRow);
            }
            this.userControlDataGridGKSTAVKA.DataGrid.DisplayLayout.Override.AllowDelete = DefaultableBoolean.False;
            this.userControlDataGridGKSTAVKA.DataGrid.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False;
            this.userControlDataGridGKSTAVKA.DataGrid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No;
            this.userControlDataGridGKSTAVKA.DataGrid.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True;
            this.userControlDataGridGKSTAVKA.DataGrid.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortSingle;
            this.FillData();
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            this.components = new Container();
            ResourceManager manager = new ResourceManager(typeof(GKSTAVKAWorkWith));
            this.userControlDataGridGKSTAVKA = new GKSTAVKAUserDataGrid();
            this.ultraGridPrintDocument1 = new UltraGridPrintDocument(this.components);
            this.ultraPrintPreviewDialog1 = new UltraPrintPreviewDialog(this.components);
            this.SuspendLayout();
            this.userControlDataGridGKSTAVKA.Name = "userControlDataGridGKSTAVKA";
            this.userControlDataGridGKSTAVKA.Dock = DockStyle.Fill;
            this.userControlDataGridGKSTAVKA.DockPadding.All = 5;
            this.userControlDataGridGKSTAVKA.FillAtStartup = false;
            this.userControlDataGridGKSTAVKA.TabIndex = 6;
            Size size = new System.Drawing.Size(0x2d8, 400);
            this.userControlDataGridGKSTAVKA.Size = size;
            this.ultraGridPrintDocument1.Grid = this.userControlDataGridGKSTAVKA.DataGrid;
            this.Controls.Add(this.userControlDataGridGKSTAVKA);
            SizeF ef = new System.Drawing.SizeF(6f, 13f);
            this.AutoScaleDimensions = ef;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.DockPadding.All = 5;
            this.Name = "GKSTAVKAWorkWith";
            this.Text = "Work With GKSTAVKA";
            this.Load += new EventHandler(this.GKSTAVKAWorkWith_Load);
            this.ResumeLayout(false);
        }

        [LocalCommandHandler("Insert")]
        public void InsertHandler(object sender, EventArgs e)
        {
            if (this.Controller.WorkItem.Status == WorkItemStatus.Active)
            {
                this.Controller.Insert(this.m_FillByRow);
            }
        }

        private bool InValidState()
        {
            return ((this.Controller.WorkItem.Status == WorkItemStatus.Active) && (this.CurrentDataRow != null));
        }

        [LocalCommandHandler("Print")]
        public void PrintHandler(object sender, EventArgs e)
        {
            if (Information.IsNothing(this.ultraPrintPreviewDialog1.Document))
            {
                this.ultraPrintPreviewDialog1.Document = this.ultraGridPrintDocument1;
                this.ultraPrintPreviewDialog1.Name = "ultraPrintPreviewDialog1";
                this.ultraPrintPreviewDialog1.Document.DocumentName = "";
                this.ultraPrintPreviewDialog1.Text = "";
            }
            if (this.Controller.WorkItem.Status == WorkItemStatus.Active)
            {
                this.ultraPrintPreviewDialog1.ShowDialog(this);
            }
        }

        [EventSubscription("topic://NetAdvantage/BusinessComponentUpdated/GKSTAVKA", Thread=ThreadOption.UserInterface)]
        public void RefreshGrid(object sender, ComponentEventArgs args)
        {
            this.FillData();
        }

        [LocalCommandHandler("Refresh")]
        public void RefreshHandler(object sender, EventArgs e)
        {
            if (this.Controller.WorkItem.Status == WorkItemStatus.Active)
            {
                this.FillData();
            }
        }

        private void Select_Click(object sender, EventArgs e)
        {
            RowUIElement ancestor;
            UIElement lastElementEntered = this.userControlDataGridGKSTAVKA.DataGrid.DisplayLayout.UIElement.LastElementEntered;
            if (lastElementEntered is RowUIElement)
            {
                ancestor = (RowUIElement) lastElementEntered;
            }
            else
            {
                ancestor = (RowUIElement) lastElementEntered.GetAncestor(typeof(RowUIElement));
            }
            if (ancestor != null)
            {
                this.SelectHandler(RuntimeHelpers.GetObjectValue(sender), e);
            }
        }

        [LocalCommandHandler("Select")]
        public void SelectHandler(object sender, EventArgs e)
        {
            if (this.Controller.WorkItem.Status == WorkItemStatus.Active)
            {
                this.m_RowSelected = this.CurrentDataRow;
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void SetSmartPartInfoInformation()
        {
            if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
            {
                this.smartPartInfo1.Title = string.Format("{0} GKSTAVKA ", Deklarit.Resources.Resources.Select);
            }
            else
            {
                this.smartPartInfo1.Title = string.Format("{0} GKSTAVKA ", Deklarit.Resources.Resources.Workwith);
            }
            this.smartPartInfo1.Description = this.smartPartInfo1.Title;
        }

        private void ShowMessage(string msg)
        {
            MessageBox.Show(msg, this.smartPartInfo1.Description, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        [LocalCommandHandler("Update")]
        public void UpdateHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.Controller.Update(this.CurrentDataRow);
            }
        }

        [LocalCommandHandler("View")]
        public void View(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.Controller.View(this.CurrentDataRow);
            }
        }

        [CreateNew]
        public GKSTAVKAWorkWithController Controller { get; set; }

        private DataRow CurrentDataRow
        {
            get
            {
                if (this.userControlDataGridGKSTAVKA.DataGrid.CurrentRowIndex == -1)
                {
                    return null;
                }
                return this.userControlDataGridGKSTAVKA.DataView[this.userControlDataGridGKSTAVKA.DataGrid.CurrentRowIndex].Row;
            }
        }

        DataRow Deklarit.Practices.CompositeUI.IFilteredView.FillByRow
        {
            set
            {
                this.m_FillByRow = value;
                this.SetSmartPartInfoInformation();
            }
        }

        string Deklarit.Practices.CompositeUI.IFilteredView.FillMethod
        {
            set
            {
                this.m_FillByMethod = value;
            }
        }

        DataRow Deklarit.Practices.CompositeUI.IFilteredView.SelectedRow
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
                this.SetSmartPartInfoInformation();
            }
        }

        public DataRow FillByRow
        {
            set
            {
                this.m_FillByRow = value;
                this.SetSmartPartInfoInformation();
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

        private GKSTAVKAUserDataGrid userControlDataGridGKSTAVKA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._userControlDataGridGKSTAVKA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._userControlDataGridGKSTAVKA = value;
            }
        }

        Deklarit.Practices.CompositeUI.WorkWithMode WorkWithMode
        {
            set
            {
                this.m_WorkWithMode = value;
                this.SetSmartPartInfoInformation();
            }
        }
    }
}


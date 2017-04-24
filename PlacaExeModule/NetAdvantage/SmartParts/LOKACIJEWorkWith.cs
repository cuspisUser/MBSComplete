namespace NetAdvantage.SmartParts
{
    using Deklarit;
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.BuilderStrategies;
    using Deklarit.Practices.CompositeUI.NetAdvantage.Services;
    using Deklarit.Practices.CompositeUI.Services;
    using Deklarit.Resources;
    using Hlp;
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
    using NetAdvantage.Controllers;
    using NetAdvantage.WorkItems;
    using Placa;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Data;
    using System.Data.OleDb;
    using System.Diagnostics;
    using System.Drawing;
    using System.Resources;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    [SmartPart]
    public class LOKACIJEWorkWith : UserControl, ISmartPartInfoProvider, IFilteredView
    {
        [AccessedThroughProperty("userControlDataGridLOKACIJE")]
        private LOKACIJEUserDataGrid _userControlDataGridLOKACIJE;
        private IContainer components = null;
        private SmartPartInfoProvider infoProvider;
        private string m_FillByMethod = "";
        private DataRow m_FillByRow;
        private DataRow m_RowSelected;
        private Deklarit.Practices.CompositeUI.WorkWithMode m_WorkWithMode;
        private SmartPartInfo smartPartInfo1;
        private UltraGridPrintDocument ultraGridPrintDocument1;
        private UltraPrintPreviewDialog ultraPrintPreviewDialog1;

        public LOKACIJEWorkWith()
        {
            this.InitializeComponent();
            this.smartPartInfo1 = new SmartPartInfo(string.Format(Deklarit.Resources.Resources.WorkWithTitle, StringResources.LOKACIJEDescription), string.Format(Deklarit.Resources.Resources.WorkWithTitle, StringResources.LOKACIJEDescription));
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);
            this.userControlDataGridLOKACIJE.DataGrid.AfterRowActivate += new EventHandler(this.DataGrid_AfterRowActivate);
        }

        [OnBuiltUp]
        public void AddSelectedRowProviderService()
        {
            UltraGridSelectedRowsProviderService<LOKACIJEDataSet> serviceInstance = new UltraGridSelectedRowsProviderService<LOKACIJEDataSet>(this.userControlDataGridLOKACIJE.DataGrid);
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
            if (!this.userControlDataGridLOKACIJE.DataGrid.GridLoading && ((this.userControlDataGridLOKACIJE.DataGrid.ActiveRow != null) && (this.userControlDataGridLOKACIJE.DataGrid.ActiveCell != null)))
            {
                this.DefaultAction();
            }
        }

        private void DataGrid_SetFocus()
        {
            if ((this.userControlDataGridLOKACIJE.DataGrid.Rows.Count > 0) && (this.userControlDataGridLOKACIJE.DataGrid.Rows[0] != null))
            {
                this.userControlDataGridLOKACIJE.DataGrid.Rows[0].Activate();
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

        [LocalCommandHandler("DosImport")]
        public void DosImportHandler(object sender, EventArgs e)
        {
            LOKACIJEDataSet dataSet = new LOKACIJEDataSet();
            LOKACIJEDataAdapter adapter2 = new LOKACIJEDataAdapter();
            if (Interaction.MsgBox("Postojeće Lokacije biti će obrisane, želite li stvarno nastaviti???", MsgBoxStyle.YesNo, "Osnovna sredstva / SI") != MsgBoxResult.No)
            {
                IEnumerator enumerator = null;
                try
                {
                    enumerator = this.userControlDataGridLOKACIJE.DataGrid.DataSet.LOKACIJE.Rows.GetEnumerator();
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
                adapter2.Update(this.userControlDataGridLOKACIJE.DataGrid.DataSet);
                OpenFileDialog dialog = new OpenFileDialog {
                    InitialDirectory = @"c:\",
                    Filter = "txt files (*.dbf)|*.dbf|All files (*.*)|*.*",
                    FilterIndex = 2,
                    RestoreDirectory = true
                };
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string str3 = dialog.FileName.ToUpper().Replace(@"\OSM.DBF", "");
                    string prompt = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + str3 + ";Extended Properties=dBase IV;";
                    Interaction.MsgBox(prompt, MsgBoxStyle.OkOnly, null);
                    OleDbConnection selectConnection = new OleDbConnection(prompt);
                    OleDbDataAdapter adapter = new OleDbDataAdapter("select * from KORISNIK ORDER BY SIFRA", selectConnection);
                    DataSet set2 = new DataSet();
                    try
                    {
                        adapter.Fill(set2, "OSA");
                        if (Interaction.MsgBox("Broj pronađenih zapisa: " + Conversions.ToString(set2.Tables["OSA"].Rows.Count) + "\r\n\r\nŽelite li zadržati importirane zapise?", MsgBoxStyle.YesNo, null) == MsgBoxResult.No)
                        {
                            set2.RejectChanges();
                        }
                        else
                        {
                            DataRow row3;
                            IEnumerator enumerator2 = null;
                            int num = 1;
                            try
                            {
                                enumerator2 = set2.Tables["OSA"].Rows.GetEnumerator();
                                while (enumerator2.MoveNext())
                                {
                                    DataRow current = (DataRow) enumerator2.Current;
                                    row3 = dataSet.LOKACIJE.NewRow();
                                    row3["idlokacije"] = Conversions.ToInteger(DB.IzvuciSamoBrojke(Conversions.ToString(current["SIFRA"]), false));
                                    row3["opislokacije"] = DB.Ko437to852(Conversions.ToString(current["NAZIV"])).Substring(0, DB.Ko437to852(Conversions.ToString(current["NAZIV"])).Length - 1);
                                    dataSet.LOKACIJE.Rows.Add(row3);
                                    try
                                    {
                                        adapter2.Update(dataSet);
                                    }
                                    catch (System.Exception exception1)
                                    {
                                        throw exception1;
                                        
                                        
                                        
                                    }
                                    num++;
                                }
                            }
                            finally
                            {
                                if (enumerator2 is IDisposable)
                                {
                                    (enumerator2 as IDisposable).Dispose();
                                }
                            }
                            row3 = dataSet.LOKACIJE.NewRow();
                            row3["idlokacije"] = 0x270f;
                            row3["opislokacije"] = "Neraspoređeno";
                            dataSet.LOKACIJE.Rows.Add(row3);
                            try
                            {
                                adapter2.Update(dataSet);
                            }
                            catch (System.Exception exception4)
                            {
                                throw exception4;
                                //System.Exception exception2 = exception4;
                                //Interaction.MsgBox(exception2.Message, MsgBoxStyle.OkOnly, null);
                            }
                            MessageBox.Show("Importiranje lokacija završeno!", "Import", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            adapter2.Fill(this.userControlDataGridLOKACIJE.DataGrid.DataSet);
                        }
                    }
                    catch (System.Exception exception5)
                    {
                        throw exception5;
                        //System.Exception exception3 = exception5;
                        //Interaction.MsgBox("Greška prilikom prebacivanja podataka!" + exception3.Message, MsgBoxStyle.OkOnly, null);
                        
                    }
                }
            }
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
                    new UltraGridExcelExporter().Export(this.userControlDataGridLOKACIJE.DataGrid, dialog.FileName);
                    Process.Start(dialog.FileName);
                }
            }
        }

        [LocalCommandHandler("FillAll")]
        public void FillAll(object sender, EventArgs e)
        {
            if (this.Controller.WorkItem.Status == WorkItemStatus.Active)
            {
                bool fillByPage = this.userControlDataGridLOKACIJE.DataGrid.FillByPage;
                this.userControlDataGridLOKACIJE.DataGrid.FillByPage = false;
                this.FillData();
                this.userControlDataGridLOKACIJE.DataGrid.FillByPage = fillByPage;
            }
        }

        public virtual void FillData()
        {
            try
            {
                string fillByMethod = this.m_FillByMethod;
                this.userControlDataGridLOKACIJE.FillMethod = "Fill";
                this.userControlDataGridLOKACIJE.Fill();
                if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
                {
                    ((LOKACIJESelectionListWorkItem) this.Controller.WorkItem).DataSet = this.userControlDataGridLOKACIJE.DataView.Table.DataSet;
                }
                else
                {
                    ((LokacijeWorkWithWorkItem) this.Controller.WorkItem).DataSet = this.userControlDataGridLOKACIJE.DataView.Table.DataSet;
                }
            }
            catch (System.Exception exception1)
            {
                throw exception1;
                
                
                
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

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            this.components = new Container();
            ResourceManager manager = new ResourceManager(typeof(LOKACIJEWorkWith));
            this.userControlDataGridLOKACIJE = new LOKACIJEUserDataGrid();
            this.ultraGridPrintDocument1 = new UltraGridPrintDocument(this.components);
            this.ultraPrintPreviewDialog1 = new UltraPrintPreviewDialog(this.components);
            this.SuspendLayout();
            this.userControlDataGridLOKACIJE.Name = "userControlDataGridLOKACIJE";
            this.userControlDataGridLOKACIJE.Dock = DockStyle.Fill;
            this.userControlDataGridLOKACIJE.DockPadding.All = 5;
            this.userControlDataGridLOKACIJE.FillAtStartup = false;
            this.userControlDataGridLOKACIJE.TabIndex = 6;
            Size size = new System.Drawing.Size(0x2d8, 400);
            this.userControlDataGridLOKACIJE.Size = size;
            this.ultraGridPrintDocument1.Grid = this.userControlDataGridLOKACIJE.DataGrid;
            this.Controls.Add(this.userControlDataGridLOKACIJE);
            SizeF ef = new System.Drawing.SizeF(6f, 13f);
            this.AutoScaleDimensions = ef;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.DockPadding.All = 5;
            this.Name = "LOKACIJEWorkWith";
            this.Text = "Work With Lokacije OS-a i SI-a";
            this.Load += new EventHandler(this.LOKACIJEWorkWith_Load);
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

        private void LOKACIJEWorkWith_Load(object sender, EventArgs e)
        {
            if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
            {
                this.userControlDataGridLOKACIJE.DataGrid.DoubleClick += new EventHandler(this.Select_Click);
                Size size = new System.Drawing.Size(600, 500);
                this.Parent.Parent.Size = size;
            }
            else
            {
                this.userControlDataGridLOKACIJE.DataGrid.DoubleClickRow += new DoubleClickRowEventHandler(this.DataGrid_DoubleClickRow);
            }
            this.userControlDataGridLOKACIJE.DataGrid.DisplayLayout.Override.AllowDelete = DefaultableBoolean.False;
            this.userControlDataGridLOKACIJE.DataGrid.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False;
            this.userControlDataGridLOKACIJE.DataGrid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No;
            this.userControlDataGridLOKACIJE.DataGrid.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True;
            this.userControlDataGridLOKACIJE.DataGrid.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortSingle;
            this.userControlDataGridLOKACIJE.FillByPage = false;
            this.FillData();
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

        [EventSubscription("topic://NetAdvantage/BusinessComponentUpdated/LOKACIJE", Thread=ThreadOption.UserInterface)]
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
            UIElement lastElementEntered = this.userControlDataGridLOKACIJE.DataGrid.DisplayLayout.UIElement.LastElementEntered;
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
                this.smartPartInfo1.Title = string.Format("{0} Lokacije OS-a i SI-a ", Deklarit.Resources.Resources.Select);
            }
            else
            {
                this.smartPartInfo1.Title = string.Format("{0} Lokacije OS-a i SI-a ", Deklarit.Resources.Resources.Workwith);
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
        public LOKACIJEWorkWithController Controller { get; set; }

        private DataRow CurrentDataRow
        {
            get
            {
                if (this.userControlDataGridLOKACIJE.DataGrid.CurrentRowIndex == -1)
                {
                    return null;
                }
                return this.userControlDataGridLOKACIJE.DataView[this.userControlDataGridLOKACIJE.DataGrid.CurrentRowIndex].Row;
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

        private LOKACIJEUserDataGrid userControlDataGridLOKACIJE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._userControlDataGridLOKACIJE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._userControlDataGridLOKACIJE = value;
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


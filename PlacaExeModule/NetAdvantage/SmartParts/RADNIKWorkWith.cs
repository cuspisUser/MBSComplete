using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using Deklarit;
using Deklarit.Practices.CompositeUI;
using Deklarit.Practices.CompositeUI.BuilderStrategies;
using Deklarit.Practices.CompositeUI.NetAdvantage.Services;
using Deklarit.Practices.CompositeUI.Services;
using Deklarit.Practices.CompositeUI.Workspaces;
using Deklarit.Resources;
using Hlp;
using Infragistics.Win;
using Infragistics.Win.Misc;
using Infragistics.Win.Printing;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinGrid.ExcelExport;
using Microsoft.Office.Interop.Word;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.Commands;
using Microsoft.Practices.CompositeUI.EventBroker;
using Microsoft.Practices.CompositeUI.SmartParts;
using Microsoft.Practices.ObjectBuilder;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using My.Resources;
using NetAdvantage;
using NetAdvantage.Controllers;
using NetAdvantage.WorkItems;
using Placa;
using RadnikExtension;

namespace NetAdvantage.SmartParts
{

    [SmartPart]
    public class RADNIKWorkWith : UserControl, ISmartPartInfoProvider, IFilteredView
    {
        private IContainer components;
        private SmartPartInfoProvider infoProvider;
        private string m_FillByMethod;
        private DataRow m_FillByRow;
        private DataRow m_RowSelected;
        private Deklarit.Practices.CompositeUI.WorkWithMode m_WorkWithMode;
        private SmartPartInfo smartPartInfo1;
        private UltraDesktopAlert ultradesktopalert1;
        private UltraGridPrintDocument ultraGridPrintDocument1;
        private UltraPrintPreviewDialog ultraPrintPreviewDialog1;

        public RADNIKWorkWith()
        {
            base.Load += new EventHandler(this.RADNIKWorkWith_Load1);
            this.ultradesktopalert1 = new UltraDesktopAlert();
            this.components = null;
            this.m_FillByMethod = "";
            this.InitializeComponent();
            this.smartPartInfo1 = new SmartPartInfo(string.Format(Deklarit.Resources.Resources.WorkWithTitle, StringResources.RADNIKDescription), string.Format(Deklarit.Resources.Resources.WorkWithTitle, StringResources.RADNIKDescription));
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);
            this.userControlDataGridRADNIK.DataGrid.AfterRowActivate += new EventHandler(this.DataGrid_AfterRowActivate);
        }

        [OnBuiltUp]
        public void AddSelectedRowProviderService()
        {
            UltraGridSelectedRowsProviderService<RADNIKDataSet> serviceInstance = new UltraGridSelectedRowsProviderService<RADNIKDataSet>(this.userControlDataGridRADNIK.DataGrid);
            this.Controller.WorkItem.Services.Add(typeof(ISelectedRowsProviderService), serviceInstance);
        }

        public int BrRataDoZadObr(string IDOBRACUN, int IDRADNIK, int IDKREDITOR, DateTime DATUMUGOVORA, DataSet STANJEKREDITA)
        {
            decimal num2 = 0;
            decimal num3 = 0;
            string str = "#" + DATUMUGOVORA.ToString(DateTimeFormatInfo.InvariantInfo) + "#";
            DataRow[] rowArray = STANJEKREDITA.Tables[0].Select("IDRADNIK = " + Conversions.ToString(IDRADNIK) + " AND DATUMUGOVORA = " + str + " AND IDKREDITOR = " + Conversions.ToString(IDKREDITOR));
            DataRow[] rowArray2 = this.userControlDataGridRADNIK.DataGrid.DataSet.RADNIKKrediti.Select("IDRADNIK = " + Conversions.ToString(IDRADNIK) + " AND DATUMUGOVORA = " + str + " AND ZADKREDITIIDKREDITOR = " + Conversions.ToString(IDKREDITOR));
            if (rowArray.Length > 0)
            {
                num2 = Conversions.ToDecimal(rowArray[0]["BROJRATA"]);
            }
            else
            {
                num2 = new decimal();
            }
            if (rowArray2.Length > 0)
            {
                num3 = Conversions.ToDecimal(rowArray2[0]["ZADVECOTPLACENOBROJRATA"]);
            }
            else
            {
                num3 = new decimal();
            }
            return Convert.ToInt32(decimal.Add(num2, num3));
        }

        [LocalCommandHandler("cmdImportOIB")]
        public void cmdImportOIBHandler(object sender, EventArgs e)
        {
            this.Import_OIB();
        }

        [LocalCommandHandler("cmdImportPrintListe")]
        public void cmdImportpRINTlISTEHandler(object sender, EventArgs e)
        {
            this.ImportPrintListe();
        }

        [LocalCommandHandler("cmdIspisPlatnih")]
        public void cmdIspisPlatnihHandler(object sender, EventArgs e)
        {
            this.IspisiPlatne_Abeceda();
        }

        [LocalCommandHandler("cmdIspisiKreditePojedinacno")]
        public void CommandKreditPojedinacno(object sender, EventArgs e)
        {
            this.IspisiKredite_Pojedinacno();
        }

        [LocalCommandHandler("cmdIspisiObustavePojedinacno")]
        public void CommandObustavePojedinacno(object sender, EventArgs e)
        {
            this.IspisiObustave_Pojedinacno();
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
            if (!this.userControlDataGridRADNIK.DataGrid.GridLoading && ((this.userControlDataGridRADNIK.DataGrid.ActiveRow != null) && (this.userControlDataGridRADNIK.DataGrid.ActiveCell != null)))
            {
                this.DefaultAction();
            }
        }

        private void DataGrid_SetFocus()
        {
            if ((this.userControlDataGridRADNIK.DataGrid.Rows.Count > 0) && (this.userControlDataGridRADNIK.DataGrid.Rows[0] != null))
            {
                this.userControlDataGridRADNIK.DataGrid.Rows[0].Activate();
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
            if (ProvjeraRadnikaZAJOPPD())
            {
                if (this.InValidState())
                {
                    this.Controller.Delete(this.CurrentDataRow);
                }
            }
            else
            {
                MessageBox.Show("Postoji JOPPD obrazac za označenog radnika.\nPotrebno je prvo obrisati JOPPD obrazac da bi se mogao brisati radnik.", "Upozorenje");
            }
        }

        private bool ProvjeraRadnikaZAJOPPD()
        {
            Mipsed7.DataAccessLayer.SqlClient client = new Mipsed7.DataAccessLayer.SqlClient();

            try
            {
                string var = client.ExecuteScalar("Select ID From JOPPDAObracun Where OBRACUN_ID = '" + CurrentDataRow["IDRADNIK"].ToString() + "'").ToString();
                return false;
            }
            catch
            {
                return true;
            }
        }

        /*
        public void DesktopAlert()
        {
            this.ultradesktopalert1.FlatMode = true;
            this.ultradesktopalert1.AnimationSpeed = AnimationSpeed.Fast;
            UltraDesktopAlertShowWindowInfo windowInfo = new UltraDesktopAlertShowWindowInfo {
                Image = My.Resources.Resources.oko,
                Caption = string.Format("<a>{0}</a>", "Priprema platnih lista"),
                Text = string.Format("<a>{0}</a>", "Sačekajte trenutak"),
                FooterText = string.Format("<a>{0}</a>", "Mipsed obračun plaća"),
                Key = "MyWindow"
            };
            UltraDesktopAlertWindowInfo info2 = this.ultradesktopalert1.Show(windowInfo);
        }
        */

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
                    new UltraGridExcelExporter().Export(this.userControlDataGridRADNIK.DataGrid, dialog.FileName);
                    Process.Start(dialog.FileName);
                }
            }
        }

        [LocalCommandHandler("FillAll")]
        public void FillAll(object sender, EventArgs e)
        {
            if (this.Controller.WorkItem.Status == WorkItemStatus.Active)
            {
                bool fillByPage = this.userControlDataGridRADNIK.DataGrid.FillByPage;
                this.userControlDataGridRADNIK.DataGrid.FillByPage = false;
                this.FillData();
                this.userControlDataGridRADNIK.DataGrid.FillByPage = fillByPage;
            }
        }

        public virtual void FillData()
        {
            try
            {
                string fillByMethod = this.m_FillByMethod;
                if (fillByMethod == "FillByIDRADNOMJESTO")
                {
                    this.FillFillByIDRADNOMJESTO();
                }
                else if (fillByMethod == "FillByPOTREBNASTRUCNASPREMAIDSTRUCNASPREMA")
                {
                    this.FillFillByPOTREBNASTRUCNASPREMAIDSTRUCNASPREMA();
                }
                else if (fillByMethod == "FillByIDSTRUKA")
                {
                    this.FillFillByIDSTRUKA();
                }
                else if (fillByMethod == "FillByIDBRACNOSTANJE")
                {
                    this.FillFillByIDBRACNOSTANJE();
                }
                else if (fillByMethod == "FillByIDORGDIO")
                {
                    this.FillFillByIDORGDIO();
                }
                else if (fillByMethod == "FillByOPCINASTANOVANJAIDOPCINE")
                {
                    this.FillFillByOPCINASTANOVANJAIDOPCINE();
                }
                else if (fillByMethod == "FillByOPCINARADAIDOPCINE")
                {
                    this.FillFillByOPCINARADAIDOPCINE();
                }
                else if (fillByMethod == "FillByRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA")
                {
                    this.FillFillByRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA();
                }
                else if (fillByMethod == "FillByJMBG")
                {
                    this.FillFillByJMBG();
                }
                else if (fillByMethod == "FillByIDRADNOVRIJEME")
                {
                    this.FillFillByIDRADNOVRIJEME();
                }
                else if (fillByMethod == "FillByIDDRZAVLJANSTVO")
                {
                    this.FillFillByIDDRZAVLJANSTVO();
                }
                else if (fillByMethod == "FillByIDUGOVORORADU")
                {
                    this.FillFillByIDUGOVORORADU();
                }
                else if (fillByMethod == "FillByTRENUTNASTRUCNASPREMAIDSTRUCNASPREMA")
                {
                    this.FillFillByTRENUTNASTRUCNASPREMAIDSTRUCNASPREMA();
                }
                else if (fillByMethod == "FillByIDIPIDENT")
                {
                    this.FillFillByIDIPIDENT();
                }
                else if (fillByMethod == "FillByIDSPOL")
                {
                    this.FillFillByIDSPOL();
                }
                else if (fillByMethod == "FillByIDBANKE")
                {
                    this.FillFillByIDBANKE();
                }
                else if (fillByMethod == "FillByIDBENEFICIRANI")
                {
                    this.FillFillByIDBENEFICIRANI();
                }
                else if (fillByMethod == "FillByIDTITULA")
                {
                    this.FillFillByIDTITULA();
                }
                else
                {
                    this.userControlDataGridRADNIK.FillMethod = "Fill";
                }
                this.userControlDataGridRADNIK.Fill();
                if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
                {
                    ((RADNIKSelectionListWorkItem) this.Controller.WorkItem).DataSet = this.userControlDataGridRADNIK.DataView.Table.DataSet;
                }
                else
                {
                    ((RADNIKWorkWithWorkItem) this.Controller.WorkItem).DataSet = this.userControlDataGridRADNIK.DataView.Table.DataSet;
                }
            }
            catch (System.Exception exception1)
            {
                throw exception1;
                
                
                
            }
        }

        private void FillFillByIDBANKE()
        {
            string str = "";
            this.userControlDataGridRADNIK.FillMethod = "FillByIDBANKE";
            this.userControlDataGridRADNIK.FillByIDBANKEIDBANKE = Conversions.ToInteger(this.GetValueFromRow("IDBANKE", "IDBANKE"));
            str = str + "," + this.userControlDataGridRADNIK.FillByIDBANKEIDBANKE.ToString() + " ";
            if (FormHelperClass.GetDescription(this.m_FillByRow).Length == 0)
            {
                if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
                {
                    this.Text = Deklarit.Resources.Resources.Select + "Zaposlenici " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
                }
                else
                {
                    this.Text = Deklarit.Resources.Resources.Workwith + "Zaposlenici " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
                }
            }
        }

        private void FillFillByIDBENEFICIRANI()
        {
            string str = "";
            this.userControlDataGridRADNIK.FillMethod = "FillByIDBENEFICIRANI";
            this.userControlDataGridRADNIK.FillByIDBENEFICIRANIIDBENEFICIRANI = Conversions.ToString(this.GetValueFromRow("IDBENEFICIRANI", "IDBENEFICIRANI"));
            str = str + "," + this.userControlDataGridRADNIK.FillByIDBENEFICIRANIIDBENEFICIRANI.ToString() + " ";
            if (FormHelperClass.GetDescription(this.m_FillByRow).Length == 0)
            {
                if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
                {
                    this.Text = Deklarit.Resources.Resources.Select + "Zaposlenici " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
                }
                else
                {
                    this.Text = Deklarit.Resources.Resources.Workwith + "Zaposlenici " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
                }
            }
        }

        private void FillFillByIDBRACNOSTANJE()
        {
            string str = "";
            this.userControlDataGridRADNIK.FillMethod = "FillByIDBRACNOSTANJE";
            this.userControlDataGridRADNIK.FillByIDBRACNOSTANJEIDBRACNOSTANJE = Conversions.ToInteger(this.GetValueFromRow("IDBRACNOSTANJE", "IDBRACNOSTANJE"));
            str = str + "," + this.userControlDataGridRADNIK.FillByIDBRACNOSTANJEIDBRACNOSTANJE.ToString() + " ";
            if (FormHelperClass.GetDescription(this.m_FillByRow).Length == 0)
            {
                if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
                {
                    this.Text = Deklarit.Resources.Resources.Select + "Zaposlenici " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
                }
                else
                {
                    this.Text = Deklarit.Resources.Resources.Workwith + "Zaposlenici " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
                }
            }
        }

        private void FillFillByIDDRZAVLJANSTVO()
        {
            string str = "";
            this.userControlDataGridRADNIK.FillMethod = "FillByIDDRZAVLJANSTVO";
            this.userControlDataGridRADNIK.FillByIDDRZAVLJANSTVOIDDRZAVLJANSTVO = Conversions.ToInteger(this.GetValueFromRow("IDDRZAVLJANSTVO", "IDDRZAVLJANSTVO"));
            str = str + "," + this.userControlDataGridRADNIK.FillByIDDRZAVLJANSTVOIDDRZAVLJANSTVO.ToString() + " ";
            if (FormHelperClass.GetDescription(this.m_FillByRow).Length == 0)
            {
                if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
                {
                    this.Text = Deklarit.Resources.Resources.Select + "Zaposlenici " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
                }
                else
                {
                    this.Text = Deklarit.Resources.Resources.Workwith + "Zaposlenici " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
                }
            }
        }

        private void FillFillByIDIPIDENT()
        {
            string str = "";
            this.userControlDataGridRADNIK.FillMethod = "FillByIDIPIDENT";
            this.userControlDataGridRADNIK.FillByIDIPIDENTIDIPIDENT = Conversions.ToInteger(this.GetValueFromRow("IDIPIDENT", "IDIPIDENT"));
            str = str + "," + this.userControlDataGridRADNIK.FillByIDIPIDENTIDIPIDENT.ToString() + " ";
            if (FormHelperClass.GetDescription(this.m_FillByRow).Length == 0)
            {
                if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
                {
                    this.Text = Deklarit.Resources.Resources.Select + "Zaposlenici " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
                }
                else
                {
                    this.Text = Deklarit.Resources.Resources.Workwith + "Zaposlenici " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
                }
            }
        }

        private void FillFillByIDORGDIO()
        {
            string str = "";
            this.userControlDataGridRADNIK.FillMethod = "FillByIDORGDIO";
            this.userControlDataGridRADNIK.FillByIDORGDIOIDORGDIO = Conversions.ToInteger(this.GetValueFromRow("IDORGDIO", "IDORGDIO"));
            str = str + "," + this.userControlDataGridRADNIK.FillByIDORGDIOIDORGDIO.ToString() + " ";
            if (FormHelperClass.GetDescription(this.m_FillByRow).Length == 0)
            {
                if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
                {
                    this.Text = Deklarit.Resources.Resources.Select + "Zaposlenici " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
                }
                else
                {
                    this.Text = Deklarit.Resources.Resources.Workwith + "Zaposlenici " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
                }
            }
        }

        private void FillFillByIDRADNOMJESTO()
        {
            string str = "";
            this.userControlDataGridRADNIK.FillMethod = "FillByIDRADNOMJESTO";
            this.userControlDataGridRADNIK.FillByIDRADNOMJESTOIDRADNOMJESTO = Conversions.ToInteger(this.GetValueFromRow("IDRADNOMJESTO", "IDRADNOMJESTO"));
            str = str + "," + this.userControlDataGridRADNIK.FillByIDRADNOMJESTOIDRADNOMJESTO.ToString() + " ";
            if (FormHelperClass.GetDescription(this.m_FillByRow).Length == 0)
            {
                if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
                {
                    this.Text = Deklarit.Resources.Resources.Select + "Zaposlenici " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
                }
                else
                {
                    this.Text = Deklarit.Resources.Resources.Workwith + "Zaposlenici " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
                }
            }
        }

        private void FillFillByIDRADNOVRIJEME()
        {
            string str = "";
            this.userControlDataGridRADNIK.FillMethod = "FillByIDRADNOVRIJEME";
            this.userControlDataGridRADNIK.FillByIDRADNOVRIJEMEIDRADNOVRIJEME = Conversions.ToInteger(this.GetValueFromRow("IDRADNOVRIJEME", "IDRADNOVRIJEME"));
            str = str + "," + this.userControlDataGridRADNIK.FillByIDRADNOVRIJEMEIDRADNOVRIJEME.ToString() + " ";
            if (FormHelperClass.GetDescription(this.m_FillByRow).Length == 0)
            {
                if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
                {
                    this.Text = Deklarit.Resources.Resources.Select + "Zaposlenici " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
                }
                else
                {
                    this.Text = Deklarit.Resources.Resources.Workwith + "Zaposlenici " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
                }
            }
        }

        private void FillFillByIDSPOL()
        {
            string str = "";
            this.userControlDataGridRADNIK.FillMethod = "FillByIDSPOL";
            this.userControlDataGridRADNIK.FillByIDSPOLIDSPOL = Conversions.ToInteger(this.GetValueFromRow("IDSPOL", "IDSPOL"));
            str = str + "," + this.userControlDataGridRADNIK.FillByIDSPOLIDSPOL.ToString() + " ";
            if (FormHelperClass.GetDescription(this.m_FillByRow).Length == 0)
            {
                if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
                {
                    this.Text = Deklarit.Resources.Resources.Select + "Zaposlenici " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
                }
                else
                {
                    this.Text = Deklarit.Resources.Resources.Workwith + "Zaposlenici " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
                }
            }
        }

        private void FillFillByIDSTRUKA()
        {
            string str = "";
            this.userControlDataGridRADNIK.FillMethod = "FillByIDSTRUKA";
            this.userControlDataGridRADNIK.FillByIDSTRUKAIDSTRUKA = Conversions.ToInteger(this.GetValueFromRow("IDSTRUKA", "IDSTRUKA"));
            str = str + "," + this.userControlDataGridRADNIK.FillByIDSTRUKAIDSTRUKA.ToString() + " ";
            if (FormHelperClass.GetDescription(this.m_FillByRow).Length == 0)
            {
                if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
                {
                    this.Text = Deklarit.Resources.Resources.Select + "Zaposlenici " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
                }
                else
                {
                    this.Text = Deklarit.Resources.Resources.Workwith + "Zaposlenici " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
                }
            }
        }

        private void FillFillByIDTITULA()
        {
            string str = "";
            this.userControlDataGridRADNIK.FillMethod = "FillByIDTITULA";
            this.userControlDataGridRADNIK.FillByIDTITULAIDTITULA = Conversions.ToInteger(this.GetValueFromRow("IDTITULA", "IDTITULA"));
            str = str + "," + this.userControlDataGridRADNIK.FillByIDTITULAIDTITULA.ToString() + " ";
            if (FormHelperClass.GetDescription(this.m_FillByRow).Length == 0)
            {
                if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
                {
                    this.Text = Deklarit.Resources.Resources.Select + "Zaposlenici " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
                }
                else
                {
                    this.Text = Deklarit.Resources.Resources.Workwith + "Zaposlenici " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
                }
            }
        }

        private void FillFillByIDUGOVORORADU()
        {
            string str = "";
            this.userControlDataGridRADNIK.FillMethod = "FillByIDUGOVORORADU";
            this.userControlDataGridRADNIK.FillByIDUGOVORORADUIDUGOVORORADU = Conversions.ToInteger(this.GetValueFromRow("IDUGOVORORADU", "IDUGOVORORADU"));
            str = str + "," + this.userControlDataGridRADNIK.FillByIDUGOVORORADUIDUGOVORORADU.ToString() + " ";
            if (FormHelperClass.GetDescription(this.m_FillByRow).Length == 0)
            {
                if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
                {
                    this.Text = Deklarit.Resources.Resources.Select + "Zaposlenici " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
                }
                else
                {
                    this.Text = Deklarit.Resources.Resources.Workwith + "Zaposlenici " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
                }
            }
        }

        private void FillFillByJMBG()
        {
            string str = "";
            this.userControlDataGridRADNIK.FillMethod = "FillByJMBG";
            this.userControlDataGridRADNIK.FillByJMBGJMBG = Conversions.ToString(this.GetValueFromRow("JMBG", "JMBG"));
            str = str + "," + this.userControlDataGridRADNIK.FillByJMBGJMBG.ToString() + " ";
            if (FormHelperClass.GetDescription(this.m_FillByRow).Length == 0)
            {
                if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
                {
                    this.Text = Deklarit.Resources.Resources.Select + "Zaposlenici " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
                }
                else
                {
                    this.Text = Deklarit.Resources.Resources.Workwith + "Zaposlenici " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
                }
            }
        }

        private void FillFillByOPCINARADAIDOPCINE()
        {
            string str = "";
            this.userControlDataGridRADNIK.FillMethod = "FillByOPCINARADAIDOPCINE";
            this.userControlDataGridRADNIK.FillByOPCINARADAIDOPCINEOPCINARADAIDOPCINE = Conversions.ToString(this.GetValueFromRow("IDOPCINE", "OPCINARADAIDOPCINE"));
            str = str + "," + this.userControlDataGridRADNIK.FillByOPCINARADAIDOPCINEOPCINARADAIDOPCINE.ToString() + " ";
            if (FormHelperClass.GetDescription(this.m_FillByRow).Length == 0)
            {
                if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
                {
                    this.Text = Deklarit.Resources.Resources.Select + "Zaposlenici " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
                }
                else
                {
                    this.Text = Deklarit.Resources.Resources.Workwith + "Zaposlenici " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
                }
            }
        }

        private void FillFillByOPCINASTANOVANJAIDOPCINE()
        {
            string str = "";
            this.userControlDataGridRADNIK.FillMethod = "FillByOPCINASTANOVANJAIDOPCINE";
            this.userControlDataGridRADNIK.FillByOPCINASTANOVANJAIDOPCINEOPCINASTANOVANJAIDOPCINE = Conversions.ToString(this.GetValueFromRow("IDOPCINE", "OPCINASTANOVANJAIDOPCINE"));
            str = str + "," + this.userControlDataGridRADNIK.FillByOPCINASTANOVANJAIDOPCINEOPCINASTANOVANJAIDOPCINE.ToString() + " ";
            if (FormHelperClass.GetDescription(this.m_FillByRow).Length == 0)
            {
                if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
                {
                    this.Text = Deklarit.Resources.Resources.Select + "Zaposlenici " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
                }
                else
                {
                    this.Text = Deklarit.Resources.Resources.Workwith + "Zaposlenici " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
                }
            }
        }

        private void FillFillByPOTREBNASTRUCNASPREMAIDSTRUCNASPREMA()
        {
            string str = "";
            this.userControlDataGridRADNIK.FillMethod = "FillByPOTREBNASTRUCNASPREMAIDSTRUCNASPREMA";
            this.userControlDataGridRADNIK.FillByPOTREBNASTRUCNASPREMAIDSTRUCNASPREMAPOTREBNASTRUCNASPREMAIDSTRUCNASPREMA = Conversions.ToInteger(this.GetValueFromRow("IDSTRUCNASPREMA", "POTREBNASTRUCNASPREMAIDSTRUCNASPREMA"));
            str = str + "," + this.userControlDataGridRADNIK.FillByPOTREBNASTRUCNASPREMAIDSTRUCNASPREMAPOTREBNASTRUCNASPREMAIDSTRUCNASPREMA.ToString() + " ";
            if (FormHelperClass.GetDescription(this.m_FillByRow).Length == 0)
            {
                if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
                {
                    this.Text = Deklarit.Resources.Resources.Select + "Zaposlenici " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
                }
                else
                {
                    this.Text = Deklarit.Resources.Resources.Workwith + "Zaposlenici " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
                }
            }
        }

        private void FillFillByRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA()
        {
            string str = "";
            this.userControlDataGridRADNIK.FillMethod = "FillByRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA";
            this.userControlDataGridRADNIK.FillByRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSARADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA = Conversions.ToInteger(this.GetValueFromRow("IDSKUPPOREZAIDOPRINOSA", "RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA"));
            str = str + "," + this.userControlDataGridRADNIK.FillByRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSARADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA.ToString() + " ";
            if (FormHelperClass.GetDescription(this.m_FillByRow).Length == 0)
            {
                if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
                {
                    this.Text = Deklarit.Resources.Resources.Select + "Zaposlenici " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
                }
                else
                {
                    this.Text = Deklarit.Resources.Resources.Workwith + "Zaposlenici " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
                }
            }
        }

        private void FillFillByTRENUTNASTRUCNASPREMAIDSTRUCNASPREMA()
        {
            string str = "";
            this.userControlDataGridRADNIK.FillMethod = "FillByTRENUTNASTRUCNASPREMAIDSTRUCNASPREMA";
            this.userControlDataGridRADNIK.FillByTRENUTNASTRUCNASPREMAIDSTRUCNASPREMATRENUTNASTRUCNASPREMAIDSTRUCNASPREMA = Conversions.ToInteger(this.GetValueFromRow("IDSTRUCNASPREMA", "TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA"));
            str = str + "," + this.userControlDataGridRADNIK.FillByTRENUTNASTRUCNASPREMAIDSTRUCNASPREMATRENUTNASTRUCNASPREMAIDSTRUCNASPREMA.ToString() + " ";
            if (FormHelperClass.GetDescription(this.m_FillByRow).Length == 0)
            {
                if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
                {
                    this.Text = Deklarit.Resources.Resources.Select + "Zaposlenici " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
                }
                else
                {
                    this.Text = Deklarit.Resources.Resources.Workwith + "Zaposlenici " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
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

        public void Import_OIB()
        {
            OpenFileDialog dialog = new OpenFileDialog {
                Title = "Please Select a File",
                InitialDirectory = @"C\:Desktop",
                Filter = "Txt datoteke (*.txt)|*.txt|All files (*.*)|*.*",
                FileName = ""
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string path = dialog.FileName.ToString();
                Encoding encoding = Encoding.GetEncoding(0x4e2);
                StreamReader reader = new StreamReader(path, encoding);
                string[] strArray = reader.ReadToEnd().Split(new char[] { '\n' });
                int num2 = strArray.Length - 2;
                for (int i = 0; i <= num2; i++)
                {
                    IEnumerator enumerator = null;
                    string str3 = strArray[i];
                    string right = str3.Substring(14, 13);
                    string str5 = str3.Substring(0x1c, 11);
                    try
                    {
                        enumerator = this.userControlDataGridRADNIK.DataGrid.DataSet.RADNIK.Rows.GetEnumerator();
                        while (enumerator.MoveNext())
                        {
                            DataRow current = (DataRow) enumerator.Current;
                            if (Operators.ConditionalCompareObjectEqual(current["jmbg"], right, false))
                            {
                                current["oib"] = str5;
                            }
                        }
                    }
                    finally
                    {
                        if (enumerator is IDisposable)
                        {
                            (enumerator as IDisposable).Dispose();
                        }
                    }
                }
                new RADNIKDataAdapter().Update(this.userControlDataGridRADNIK.DataGrid.DataSet);
            }
        }

        public void ImportPrintListe()
        {
            OpenFileDialog dialog = new OpenFileDialog {
                Title = "Please Select a File",
                InitialDirectory = @"C\:Desktop",
                Filter = "DOC datoteke (*.doc)|*.doc|All files (*.*)|*.*",
                FileName = ""
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                int num = 0;
                int num2 = 0;
                int num3 = 0;
                IEnumerator enumerator = null;
                string str = dialog.FileName.ToString();
                Microsoft.Office.Interop.Word.Application application = new ApplicationClass();
                Document document = new DocumentClass();
                CultureInfo currentCulture = Thread.CurrentThread.CurrentCulture;
                Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                object obj3 = str;
                str = Conversions.ToString(obj3);

                object temp = System.Reflection.Missing.Value;

                document = application.Documents.Open(ref obj3, ref temp, ref temp, ref temp, ref temp, ref temp, ref temp, ref temp, ref temp, ref temp, ref temp, ref temp, ref temp, ref temp, ref temp, ref temp);
                // selektira cijeli dokument
                application.ActiveWindow.Selection.WholeStory();
                // kopira u clipboard
                application.ActiveWindow.Selection.Copy();
                // CIJELI dokument stavljamo u string
                string str3 = Clipboard.GetDataObject().GetData(DataFormats.Text).ToString();
                str3.Split(new char[0]);
                RADNIKDataSet dataSet = new RADNIKDataSet();
                POPISPROMJENAKOEFICIJENATA popispromjenakoeficijenata = new POPISPROMJENAKOEFICIJENATA();
                try
                {
                    enumerator = this.userControlDataGridRADNIK.DataGrid.DataSet.RADNIK.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        DataRow current = (DataRow) enumerator.Current;
                        if (DB.N2T(RuntimeHelpers.GetObjectValue(current["OIB"]), "") != "")
                        {
                            dataSet.RADNIK.ImportRow(current);
                        }
                    }
                }
                finally
                {
                    if (enumerator is IDisposable)
                    {
                        (enumerator as IDisposable).Dispose();
                    }
                }
                int num6 = str3.Split(new char[] { '\n' }).Length - 1;
                for (int i = 0; i <= num6; i++)
                {
                    try
                    {
                        string[] strArray = this.SplitWords(str3.Split(new char[] { '\n' })[i]);
                        int num7 = strArray.Length - 1;
                        for (int j = 0; j <= num7; j++)
                        {
                            if (((Strings.Len(strArray[j]) == 13) & Versioned.IsNumeric(strArray[j])) && (dataSet.RADNIK.Select("oib = '" + strArray[j + 1] + "'").Length > 0))
                            {
                                IEnumerator enumerator2 = null;
                                DataRow row = popispromjenakoeficijenata.DataTable1.NewRow();
                                try
                                {
                                    enumerator2 = dataSet.RADNIK.Rows.GetEnumerator();
                                    while (enumerator2.MoveNext())
                                    {
                                        DataRow row3 = (DataRow) enumerator2.Current;
                                        if (Operators.ConditionalCompareObjectEqual(row3["oib"], strArray[j + 1], false))
                                        {
                                            // OBSOLETE
                                            // IEnumerator enumerator3 = null;
                                            num3++;
                                            // ovo se korisiti za REPORTE
                                            row["prezimeime"] = Operators.AddObject(Operators.AddObject(row3["prezime"], " "), row3["ime"]);
                                            row["oObr"] = RuntimeHelpers.GetObjectValue(row3["koeficijent"]);
                                            row["pObr"] = Conversions.ToDecimal(strArray[j - 1].Replace(",", "."));
                                            row["oURE"] = 0.0;
                                            row["pURE"] = 0.0;
                                            if (Operators.ConditionalCompareObjectNotEqual(row3["koeficijent"], Conversions.ToDecimal(strArray[j - 1].Replace(",", ".")), false))
                                            {
                                                row3["koeficijent"] = Conversions.ToDecimal(strArray[j - 1].Replace(",", "."));
                                                num++;
                                            }
                                            try
                                            {
                                                string idRadnik = row3["idradnik"].ToString();

                                                // novi koeficijent iz print liste
                                                decimal dodatniKoeficijent = Conversions.ToDecimal(strArray[j - 2].Replace(",", "."));

                                                Mipsed7.DataAccessLayer.SqlClient db = new Mipsed7.DataAccessLayer.SqlClient();

                                                // iz programa
                                                row["oURE"] = Convert.ToDecimal(db.ExecuteScalar("SELECT DODATNIKOEFICIJENT FROM dbo.RADNIKLevel7 WHERE IDGRUPEKOEF = 1 AND IDRADNIK = " + idRadnik));
                                                // novi    
                                                row["pURE"] = dodatniKoeficijent;

                                                int rowsAffected = db.ExecuteNonQuery("UPDATE dbo.RADNIKLevel7 SET DODATNIKOEFICIJENT = " + dodatniKoeficijent.ToString().Replace(",", ".") + " WHERE IDGRUPEKOEF = 1 AND IDRADNIK = " + idRadnik);

                                                // ako nije bilo redova za update-anje, napravi insert
                                                if (rowsAffected == 0)
                                                {
                                                    rowsAffected = db.ExecuteNonQuery("INSERT INTO dbo.RADNIKLevel7 (IDRADNIK, IDGRUPEKOEF, DODATNIKOEFICIJENT) VALUES (" + idRadnik + ", 1, " + dodatniKoeficijent.ToString().Replace(",", ".") + ")");
                                                }

                                                num2 = num2 + rowsAffected;

                                                // OBSOLETE
                                                /*
                                                enumerator3 = dataSet.RADNIKLevel7.Rows.GetEnumerator();
                                                while (enumerator3.MoveNext())
                                                {
                                                    DataRow row4 = (DataRow) enumerator3.Current;
                                                    if (Operators.ConditionalCompareObjectEqual(row4["idradnik"], row3["idradnik"], false))
                                                    {
                                                        row["oURE"] = RuntimeHelpers.GetObjectValue(row4["dodatnikoeficijent"]);
                                                        row["pURE"] = Conversions.ToDecimal(strArray[j - 2].Replace(",", "."));
                                                        if (Operators.ConditionalCompareObjectNotEqual(row4["dodatnikoeficijent"], Conversions.ToDecimal(strArray[j - 2].Replace(",", ".")), false))
                                                        {
                                                            row4["dodatnikoeficijent"] = Conversions.ToDecimal(strArray[j - 2].Replace(",", "."));
                                                            num2++;
                                                        }
                                                    }
                                                }
                                                */
                                            }
                                            catch (System.Exception exception)
                                            {
                                                throw exception;
                                            }
                                        }
                                    }
                                }
                                finally
                                {
                                    if (enumerator2 is IDisposable)
                                    {
                                        (enumerator2 as IDisposable).Dispose();
                                    }
                                }
                                popispromjenakoeficijenata.DataTable1.Rows.Add(row);
                            }
                        }
                    }
                    catch (System.Exception exception1)
                    {
                        throw exception1;
                    }
                }
                Interaction.MsgBox("Broj zaposlenika " + Conversions.ToString(num3), MsgBoxStyle.OkOnly, null);
                Interaction.MsgBox("Broj promijenjenih obračunskih koeficijenata " + Conversions.ToString(num), MsgBoxStyle.OkOnly, null);
                Interaction.MsgBox("Broj promijenjenih uredbenih sa stažem koeficijenata " + Conversions.ToString(num2), MsgBoxStyle.OkOnly, null);
                if (Interaction.MsgBox("Želite li spremiti promjene?", MsgBoxStyle.YesNo, "") == MsgBoxResult.Yes)
                {
                    new RADNIKDataAdapter().Update(dataSet);
                }
                object saveChanges = false;
                
                //document.Close(ref saveChanges, ref temp, ref temp);
                ((Microsoft.Office.Interop.Word._Document)document).Close(ref saveChanges, ref temp, ref temp);

                saveChanges = TriState.False;

                //application.Quit(ref saveChanges, ref temp, ref temp);
                ((_Application)application).Quit(ref saveChanges, ref temp, ref temp);
               
                ExtendedWindowSmartPartInfo info = new ExtendedWindowSmartPartInfo {
                    StartPosition = FormStartPosition.CenterParent,
                    Modal = true,
                    Title = "Pregled izvještaja - Lista promjena koeficijenata",
                    Description = "Pregled izvještaja - Lista promjena koeficijenata",
                    Icon = ImageResourcesNew.mbs
                };
                ExtendedWindowWorkspace workspace = new ExtendedWindowWorkspace();
                PreviewReportWorkItem item = this.Controller.WorkItem.Items.Get<PreviewReportWorkItem>("Pregled");
                if (item == null)
                {
                    item = this.Controller.WorkItem.Items.AddNew<PreviewReportWorkItem>("Pregled");
                }
                ReportDocument document2 = new ReportDocument();
                document2.Load(System.Windows.Forms.Application.StartupPath + @"\Izvjestaji\rptListaKoeficijenata.rpt");
                document2.SetDataSource(popispromjenakoeficijenata);
                item.Izvjestaj = document2;
                item.Show(item.Workspaces["main"], info);
            }
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.userControlDataGridRADNIK = new NetAdvantage.SmartParts.RADNIKUserDataGrid();
            this.ultraGridPrintDocument1 = new Infragistics.Win.UltraWinGrid.UltraGridPrintDocument(this.components);
            this.ultraPrintPreviewDialog1 = new Infragistics.Win.Printing.UltraPrintPreviewDialog(this.components);
            this.SuspendLayout();
            // 
            // userControlDataGridRADNIK
            // 
            this.userControlDataGridRADNIK.Description = "Work with Zaposlenici";
            this.userControlDataGridRADNIK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlDataGridRADNIK.FillAtStartup = false;
            this.userControlDataGridRADNIK.FillByIDBANKEIDBANKE = 0;
            this.userControlDataGridRADNIK.FillByIDBENEFICIRANIIDBENEFICIRANI = null;
            this.userControlDataGridRADNIK.FillByIDBRACNOSTANJEIDBRACNOSTANJE = 0;
            this.userControlDataGridRADNIK.FillByIDDRZAVLJANSTVOIDDRZAVLJANSTVO = 0;
            this.userControlDataGridRADNIK.FillByIDIPIDENTIDIPIDENT = 0;
            this.userControlDataGridRADNIK.FillByIDORGDIOIDORGDIO = 0;
            this.userControlDataGridRADNIK.FillByIDRADNOMJESTOIDRADNOMJESTO = 0;
            this.userControlDataGridRADNIK.FillByIDRADNOVRIJEMEIDRADNOVRIJEME = 0;
            this.userControlDataGridRADNIK.FillByIDSPOLIDSPOL = 0;
            this.userControlDataGridRADNIK.FillByIDSTRUKAIDSTRUKA = 0;
            this.userControlDataGridRADNIK.FillByIDTITULAIDTITULA = 0;
            this.userControlDataGridRADNIK.FillByIDUGOVORORADUIDUGOVORORADU = 0;
            this.userControlDataGridRADNIK.FillByJMBGJMBG = null;
            this.userControlDataGridRADNIK.FillByOPCINARADAIDOPCINEOPCINARADAIDOPCINE = null;
            this.userControlDataGridRADNIK.FillByOPCINASTANOVANJAIDOPCINEOPCINASTANOVANJAIDOPCINE = null;
            this.userControlDataGridRADNIK.FillByPage = false;
            this.userControlDataGridRADNIK.FillByPOTREBNASTRUCNASPREMAIDSTRUCNASPREMAPOTREBNASTRUCNASPREMAIDSTRUCNASPREMA = 0;
            this.userControlDataGridRADNIK.FillByRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSARADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA = 0;
            this.userControlDataGridRADNIK.FillByTRENUTNASTRUCNASPREMAIDSTRUCNASPREMATRENUTNASTRUCNASPREMAIDSTRUCNASPREMA = 0;
            this.userControlDataGridRADNIK.Location = new System.Drawing.Point(5, 5);
            this.userControlDataGridRADNIK.Name = "userControlDataGridRADNIK";
            this.userControlDataGridRADNIK.Padding = new System.Windows.Forms.Padding(5);
            this.userControlDataGridRADNIK.Size = new System.Drawing.Size(140, 140);
            this.userControlDataGridRADNIK.TabIndex = 6;
            this.userControlDataGridRADNIK.Title = "Work with Zaposlenici";
            // 
            // ultraGridPrintDocument1
            // 
            this.ultraGridPrintDocument1.Grid = this.userControlDataGridRADNIK.DataGrid;
            // 
            // ultraPrintPreviewDialog1
            // 
            this.ultraPrintPreviewDialog1.Name = "ultraPrintPreviewDialog1";
            // 
            // RADNIKWorkWith
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.userControlDataGridRADNIK);
            this.Name = "RADNIKWorkWith";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Load += new System.EventHandler(this.RADNIKWorkWith_Load);
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

        [LocalCommandHandler("IspisEvidencijeORadnicima")]
        public void IspisEvidencijeORadnicimaHandler(object sender, EventArgs e)
        {
            frmUvjetiEvidencijaRadnika radnika = new frmUvjetiEvidencijaRadnika();
            if (radnika.ShowDialog() == DialogResult.OK)
            {
                DataRow[] rowArray;
                string str2 = Conversions.ToString(radnika.__Sort);
                string str = Conversions.ToString(radnika.__Vrsta);
                KORISNIKDataAdapter adapter = new KORISNIKDataAdapter();
                KORISNIKDataSet dataSet = new KORISNIKDataSet();
                adapter.Fill(dataSet);
                ExtendedWindowSmartPartInfo info = new ExtendedWindowSmartPartInfo {
                    StartPosition = FormStartPosition.CenterParent,
                    Modal = true,
                    Title = "Pregled izvještaja - Evidencija o radnicima",
                    Description = "Pregled izvještaja - Evidencija o radnicima",
                    Icon = ImageResourcesNew.mbs
                };
                ExtendedWindowWorkspace workspace = new ExtendedWindowWorkspace();
                PreviewReportWorkItem item = this.Controller.WorkItem.Items.Get<PreviewReportWorkItem>("Pregled");
                if (item == null)
                {
                    item = this.Controller.WorkItem.Items.AddNew<PreviewReportWorkItem>("Pregled");
                }
                ReportDocument document = new ReportDocument();
                document.Load(System.Windows.Forms.Application.StartupPath + @"\Izvjestaji\rptEvidencijaRadnik.rpt");
                RADNIKDataSet set2 = new RADNIKDataSet();
                if (str2 == "1")
                {
                    rowArray = this.userControlDataGridRADNIK.DataGrid.DataSet.RADNIK.Select("", "PREZIME", DataViewRowState.CurrentRows);
                }
                else
                {
                    rowArray = this.userControlDataGridRADNIK.DataGrid.DataSet.RADNIK.Select("", "IDRADNIK", DataViewRowState.CurrentRows);
                }
                int num2 = rowArray.Length - 1;
                for (int i = 0; i <= num2; i++)
                {
                    if (Conversions.ToBoolean(Operators.AndObject(str == "1", Operators.CompareObjectEqual(rowArray[i]["aktivan"], true, false))))
                    {
                        set2.RADNIK.ImportRow(rowArray[i]);
                    }
                    else if (Conversions.ToBoolean(Operators.AndObject(str == "0", Operators.OrObject(Operators.CompareObjectEqual(rowArray[i]["aktivan"], true, false), Operators.CompareObjectEqual(rowArray[i]["aktivan"], false, false)))))
                    {
                        set2.RADNIK.ImportRow(rowArray[i]);
                    }
                }
                document.SetDataSource(set2);
                document.SetParameterValue("naziv", RuntimeHelpers.GetObjectValue(dataSet.KORISNIK.Rows[0]["korisnik1naziv"]));
                document.SetParameterValue("adresa", Operators.ConcatenateObject(Operators.ConcatenateObject(dataSet.KORISNIK.Rows[0]["korisnik1adresa"], " "), dataSet.KORISNIK.Rows[0]["korisnik1mjesto"]));
                document.SetParameterValue("oib", RuntimeHelpers.GetObjectValue(dataSet.KORISNIK.Rows[0]["korisnikoib"]));
                item.Izvjestaj = document;
                item.Show(item.Workspaces["main"], info);
            }
        }

        [LocalCommandHandler("PopisRadnika")]
        public void IspisiHandler(object sender, EventArgs e)
        {
            this.IspisiPopisRadnika();
        }

        public void IspisiKredite()
        {
            ExtendedWindowSmartPartInfo info = new ExtendedWindowSmartPartInfo {
                StartPosition = FormStartPosition.CenterParent,
                Modal = true,
                Title = "Pregled izvještaja - Zaduženi krediti",
                Description = "Pregled izvještaja - Zaduženi krediti",
                Icon = ImageResourcesNew.mbs
            };
            ExtendedWindowWorkspace workspace = new ExtendedWindowWorkspace();
            PreviewReportWorkItem item = this.Controller.WorkItem.Items.Get<PreviewReportWorkItem>("Pregled");
            if (item == null)
            {
                item = this.Controller.WorkItem.Items.AddNew<PreviewReportWorkItem>("Pregled");
            }
            ReportDocument document = new ReportDocument();
            document.Load(System.Windows.Forms.Application.StartupPath + @"\Izvjestaji\zaduzenikrediti.rpt");
            document.SetDataSource(this.userControlDataGridRADNIK.DataGrid.DataSet);
            item.Izvjestaj = document;
            item.Show(item.Workspaces["main"], info);
        }

        public void IspisiKredite_Pojedinacno()
        {
            if (this.CurrentDataRow == null)
            {
                Interaction.MsgBox("Odaberite zaposlenika za ispis", MsgBoxStyle.OkOnly, null);
            }
            else
            {
                ExtendedWindowSmartPartInfo info = new ExtendedWindowSmartPartInfo {
                    StartPosition = FormStartPosition.CenterParent,
                    Modal = true,
                    Title = "Pregled izvještaja - Zaduženi krediti",
                    Description = "Pregled izvještaja - Zaduženi krediti",
                    Icon = ImageResourcesNew.mbs
                };
                ExtendedWindowWorkspace workspace = new ExtendedWindowWorkspace();
                PreviewReportWorkItem item = this.Controller.WorkItem.Items.Get<PreviewReportWorkItem>("Pregled");
                if (item == null)
                {
                    item = this.Controller.WorkItem.Items.AddNew<PreviewReportWorkItem>("Pregled");
                }
                ReportDocument document = new ReportDocument();
                document.Load(System.Windows.Forms.Application.StartupPath + @"\Izvjestaji\zaduzenikrediti.rpt");
                document.SetDataSource(this.userControlDataGridRADNIK.DataGrid.DataSet);
                UltraGridRow row = this.userControlDataGridRADNIK.DataGrid.Selected.Rows[0];
                document.RecordSelectionFormula = "{radnikkrediti.IDRADNIK} = " + Conversions.ToString(row.Cells["idradnik"].Value);
                item.Izvjestaj = document;
                item.Show(item.Workspaces["main"], info);
            }
        }

        [LocalCommandHandler("cmdIspisiKredite")]
        public void IspisiKrediteHandler(object sender, EventArgs e)
        {
            this.IspisiKredite();
        }

        public void IspisiObustave()
        {
            ExtendedWindowSmartPartInfo info = new ExtendedWindowSmartPartInfo {
                StartPosition = FormStartPosition.CenterParent,
                Modal = true,
                Title = "Pregled izvještaja - Zadužene obustave",
                Description = "Pregled izvještaja - Zadužene obustave",
                Icon = ImageResourcesNew.mbs
            };
            ExtendedWindowWorkspace workspace = new ExtendedWindowWorkspace();
            PreviewReportWorkItem item = this.Controller.WorkItem.Items.Get<PreviewReportWorkItem>("Pregled");
            if (item == null)
            {
                item = this.Controller.WorkItem.Items.AddNew<PreviewReportWorkItem>("Pregled");
            }
            ReportDocument document = new ReportDocument();
            document.Load(System.Windows.Forms.Application.StartupPath + @"\Izvjestaji\rptZaduzeneObustave.rpt");
            document.SetDataSource(this.userControlDataGridRADNIK.DataGrid.DataSet);
            item.Izvjestaj = document;
            item.Show(item.Workspaces["main"], info);
        }

        public void IspisiObustave_Pojedinacno()
        {
            if (this.CurrentDataRow == null)
            {
                Interaction.MsgBox("Odaberite zaposlenika za ispis!", MsgBoxStyle.OkOnly, null);
            }
            else
            {
                ReportDocument document = new ReportDocument();
                document.Load(System.Windows.Forms.Application.StartupPath + @"\Izvjestaji\rptZaduzeneObustave.rpt");
                document.SetDataSource(this.userControlDataGridRADNIK.DataGrid.DataSet);

                if (this.userControlDataGridRADNIK.DataGrid.Selected.Rows.Count > 0)
                {
                    UltraGridRow row = this.userControlDataGridRADNIK.DataGrid.Selected.Rows[0];
                    document.RecordSelectionFormula = "{radnikobustava.IDRADNIK} = " + Conversions.ToString(row.Cells["idradnik"].Value);

                    ExtendedWindowSmartPartInfo info = new ExtendedWindowSmartPartInfo
                    {
                        StartPosition = FormStartPosition.CenterParent,
                        Modal = true,
                        Title = "Pregled izvještaja - Zadužene obustave",
                        Description = "Pregled izvještaja - Zadužene obustave",
                        Icon = ImageResourcesNew.mbs
                    };
                    ExtendedWindowWorkspace workspace = new ExtendedWindowWorkspace();
                    PreviewReportWorkItem item = this.Controller.WorkItem.Items.Get<PreviewReportWorkItem>("Pregled");
                    if (item == null)
                    {
                        item = this.Controller.WorkItem.Items.AddNew<PreviewReportWorkItem>("Pregled");
                    }
                    item.Izvjestaj = document;
                    item.Show(item.Workspaces["main"], info);
                }
                else
                {
                    MessageBox.Show("Molimo, odaberite radnika!");
                }
            }
        }

        [LocalCommandHandler("cmdIspisiObustave")]
        public void IspisiObustaveHandler(object sender, EventArgs e)
        {
            this.IspisiObustave();
        }

        public void IspisiPlatne_Abeceda()
        {
            frmOdabirZaIspisPlatne platne = new frmOdabirZaIspisPlatne();
            if (platne.ShowDialog() != DialogResult.Cancel)
            {
                int num3 = 0;
                IEnumerator enumerator3 = null;
                //sthis.DesktopAlert();
                S_PLACA_SIFREOBRACUNADataAdapter adapter = new S_PLACA_SIFREOBRACUNADataAdapter();
                S_PLACA_SIFREOBRACUNADataSet dataSet = new S_PLACA_SIFREOBRACUNADataSet();
                adapter.Fill(dataSet, platne.__ODGODINAMJESEC.Substring(0, 4), platne.__ODGODINAMJESEC.Substring(5, 2), platne.__DOGODINAMJESEC.Substring(0, 4), platne.__DOGODINAMJESEC.Substring(5, 2));
                int num2 = dataSet.S_PLACA_SIFREOBRACUNA.Rows.Count - 1;
                string[] strArray = new string[num2 + 1];
                int num4 = num2;
                for (int i = 0; i <= num4; i++)
                {
                    strArray[i] = Conversions.ToString(dataSet.S_PLACA_SIFREOBRACUNA.Rows[i]["IDOBRACUN"]);
                }
                OBRACUNDataAdapter adapter3 = new OBRACUNDataAdapter();
                S_OD_STANJE_KREDITADataSet sTANJEKREDITA = new S_OD_STANJE_KREDITADataSet();
                S_OD_STANJE_OBUSTAVADataSet stanjeobustava = new S_OD_STANJE_OBUSTAVADataSet();
                OBRACUNDataSet set4 = new OBRACUNDataSet();
                ReportDocument document = new ReportDocument();
                ExtendedWindowSmartPartInfo info = new ExtendedWindowSmartPartInfo {
                    StartPosition = FormStartPosition.CenterParent,
                    Modal = true,
                    Title = "Pregled izvještaja",
                    Description = "Pregled",
                    Icon = ImageResourcesNew.mbs
                };
                OBRACUNDataSet set2 = new OBRACUNDataSet();
                set4.EnforceConstraints = false;
                int num5 = num2;
                for (num3 = 0; num3 <= num5; num3++)
                {
                    adapter3.FillByIDOBRACUN(set4, strArray[num3]);
                }
                int num6 = num2;
                for (num3 = 0; num3 <= num6; num3++)
                {
                    DataRow current;
                    IEnumerator enumerator = null;
                    IEnumerator enumerator2 = null;
                    try
                    {
                        enumerator = set4.OBRACUNKrediti.Rows.GetEnumerator();
                        while (enumerator.MoveNext())
                        {
                            current = (DataRow) enumerator.Current;
                            current["dosadaobustavljeno"] = this.ObsDoZadObr(strArray[num3], Conversions.ToInteger(current["IDRADNIK"]), Conversions.ToInteger(current["IDKREDITOR"]), Conversions.ToDate(current["DATUMUGOVORA"]), sTANJEKREDITA);
                            current["BRRATADOSADA"] = this.BrRataDoZadObr(strArray[num3], Conversions.ToInteger(current["IDRADNIK"]), Conversions.ToInteger(current["IDKREDITOR"]), Conversions.ToDate(current["DATUMUGOVORA"]), sTANJEKREDITA);
                        }
                    }
                    finally
                    {
                        if (enumerator is IDisposable)
                        {
                            (enumerator as IDisposable).Dispose();
                        }
                    }
                    try
                    {
                        enumerator2 = set4.OBRACUNObustave.Rows.GetEnumerator();
                        while (enumerator2.MoveNext())
                        {
                            current = (DataRow) enumerator2.Current;
                            current["obustavljenodosada"] = this.Obustave_Iznos(strArray[num3], Conversions.ToInteger(current["IDRADNIK"]), Conversions.ToInteger(current["idobustava"]), stanjeobustava);
                            current["obustavljenodosadabrojrata"] = this.Obustave_BrojRata(strArray[num3], Conversions.ToInteger(current["IDRADNIK"]), Conversions.ToInteger(current["idobustava"]), stanjeobustava);
                            current["OBUSTAVLJENODOSATAUMANJENOZAISPLATUIZKASE"] = this.Obustave_StanjeKase(strArray[num3], Conversions.ToInteger(current["IDRADNIK"]), Conversions.ToInteger(current["idobustava"]), stanjeobustava);
                        }
                    }
                    finally
                    {
                        if (enumerator2 is IDisposable)
                        {
                            (enumerator2 as IDisposable).Dispose();
                        }
                    }
                }
                DataSet set = new DataSet();
                try
                {
                    enumerator3 = set4.Tables.GetEnumerator();
                    while (enumerator3.MoveNext())
                    {
                        System.Data.DataTable table = (System.Data.DataTable) enumerator3.Current;
                        if (table.TableName == "ObracunRadnici")
                        {
                            System.Data.DataTable table2 = new System.Data.DataTable();
                            table2 = new DataView(table) { Sort = "prezime" }.ToTable();
                            set.Tables.Add(table2);
                        }
                        else
                        {
                            set.Tables.Add(table.Copy());
                        }
                    }
                }
                finally
                {
                    if (enumerator3 is IDisposable)
                    {
                        (enumerator3 as IDisposable).Dispose();
                    }
                }
                document.Load(System.Windows.Forms.Application.StartupPath + @"\Izvjestaji\rptPlatnaListaOrg.rpt");
                document.SetDataSource(set4);
                document.RecordSelectionFormula = Conversions.ToString(Operators.ConcatenateObject("{obracunradnici.IDRADNIK} = ", this.CurrentDataRow["idradnik"]));
                KORISNIKDataSet set3 = new KORISNIKDataSet();
                new KORISNIKDataAdapter().Fill(set3);
                string str6 = Conversions.ToString(set3.KORISNIK.Rows[0]["korisnik1naziv"]);
                string str5 = Conversions.ToString(set3.KORISNIK.Rows[0]["KORISNIKOIB"]);
                string str = Conversions.ToString(set3.KORISNIK.Rows[0]["korisnik1adresa"]);
                string str2 = Conversions.ToString(set3.KORISNIK.Rows[0]["korisnik1mjesto"]);
                string str8 = Conversions.ToString(set3.KORISNIK.Rows[0]["KONTAKTTELEFON"]);
                string str4 = Conversions.ToString(set3.KORISNIK.Rows[0]["KONTAKTFAX"]);
                string str3 = "";
                DataRow[] rowArray = set3.KORISNIKLevel1.Select("vbdikorisnik <> '1001005'");
                if (rowArray.Length > 0)
                {
                    str3 = Conversions.ToString(Operators.AddObject(Operators.AddObject(rowArray[0]["vbdikorisnik"], "-"), rowArray[0]["zirokorisnik"]));
                }
                else
                {
                    str3 = "";
                }
                document.SetParameterValue("ADRESA2", str2);
                document.SetParameterValue("ADRESA", str);
                document.SetParameterValue("USTANOVA", str6 + " Žrn:" + str3);
                document.SetParameterValue("MB", str5);
                document.SetParameterValue("TELEFON", str8);
                document.SetParameterValue("FAX", str4);
                ExtendedWindowWorkspace workspace = new ExtendedWindowWorkspace();
                PreviewReportWorkItem item = this.Controller.WorkItem.Items.Get<PreviewReportWorkItem>("Pregled");
                if (item == null)
                {
                    item = this.Controller.WorkItem.Items.AddNew<PreviewReportWorkItem>("Pregled");
                }
                item.Izvjestaj = document;
                item.Show(item.Workspaces["main"]);
                this.ultradesktopalert1.CloseAll();
            }
        }

        public void IspisiPopisRadnika()
        {
            ExtendedWindowSmartPartInfo smartPartInfo = new ExtendedWindowSmartPartInfo {
                StartPosition = FormStartPosition.CenterParent,
                Modal = true,
                Title = "Ispis zaposlenika",
                Description = "Ispis zaposlenika",
                Icon = ImageResourcesNew.mbs
            };
            ExtendedWindowWorkspace workspace = new ExtendedWindowWorkspace();
            IspisZaposlenika smartPart = this.Controller.WorkItem.Items.AddNew<IspisZaposlenika>();
            workspace.Show(smartPart, smartPartInfo);
        }

        

        // Funkcionalnost "Neto u bruto" deaktivirana
        
        [CommandHandler("NetoUBruto")]
        public void NetoUBrutoCommandHandler(object sender, EventArgs e)
        {
            ExtendedWindowSmartPartInfo smartPartInfo = new ExtendedWindowSmartPartInfo {
                StartPosition = FormStartPosition.CenterParent,
                Modal = true,
                ControlBox = true,
                Title = "Neto u bruto",
                Icon = ImageResourcesNew.mbs
            };
            ExtendedWindowWorkspace workspace = new ExtendedWindowWorkspace();
            NetoUBrutoObracun smartPart = this.Controller.WorkItem.Items.AddNew<NetoUBrutoObracun>();
            smartPart.radnik = Conversions.ToInteger(this.CurrentDataRow["idradnik"]);
            workspace.Show(smartPart, smartPartInfo);
        }
        

        public decimal ObsDoZadObr(string IDOBRACUN, int IDRADNIK, int IDKREDITOR, DateTime DATUMUGOVORA, DataSet STANJEKREDITA)
        {
            decimal num = 0;
            decimal num2 = 0;
            string str = "#" + DATUMUGOVORA.ToString(DateTimeFormatInfo.InvariantInfo) + "#";
            DataRow[] rowArray = STANJEKREDITA.Tables[0].Select("IDRADNIK = " + Conversions.ToString(IDRADNIK) + " AND DATUMUGOVORA = " + str + " AND IDKREDITOR = " + Conversions.ToString(IDKREDITOR));
            DataRow[] rowArray2 = this.userControlDataGridRADNIK.DataGrid.DataSet.RADNIKKrediti.Select("IDRADNIK = " + Conversions.ToString(IDRADNIK) + " AND DATUMUGOVORA = " + str + " AND ZADKREDITIIDKREDITOR = " + Conversions.ToString(IDKREDITOR));
            if (rowArray.Length > 0)
            {
                num = Conversions.ToDecimal(rowArray[0]["OTPLACENO"]);
            }
            else
            {
                num = new decimal();
            }
            if (rowArray2.Length > 0)
            {
                num2 = Conversions.ToDecimal(rowArray2[0]["ZADVECOTPLACENOUKUPNIIZNOS"]);
            }
            else
            {
                num2 = new decimal();
            }
            return decimal.Add(num, num2);
        }

        public decimal Obustave_BrojRata(string IDOBRACUN, int IDRADNIK, int IDobustava, DataSet stanjeobustava)
        {
            DataRow[] rowArray = stanjeobustava.Tables[0].Select("IDRADNIK = " + Conversions.ToString(IDRADNIK) + " AND IDobustava = " + Conversions.ToString(IDobustava));
            if (rowArray.Length > 0)
            {
                return Conversions.ToDecimal(rowArray[0]["brojrata"]);
            }
            return new decimal();
        }

        public decimal Obustave_Iznos(string IDOBRACUN, int IDRADNIK, int IDobustava, DataSet stanjeobustava)
        {
            decimal num = 0;
            decimal num2 = 0;
            DataRow[] rowArray = stanjeobustava.Tables[0].Select("IDRADNIK = " + Conversions.ToString(IDRADNIK) + " AND IDobustava = " + Conversions.ToString(IDobustava));
            DataRow[] rowArray2 = this.userControlDataGridRADNIK.DataGrid.DataSet.RADNIKObustava.Select("IDRADNIK = " + Conversions.ToString(IDRADNIK) + " AND zadobustavaidobustava = " + Conversions.ToString(IDobustava));
            if (rowArray.Length > 0)
            {
                num = Conversions.ToDecimal(rowArray[0]["OTPLACENO"]);
            }
            else
            {
                num = new decimal();
            }
            if (rowArray2.Length > 0)
            {
                num2 = Conversions.ToDecimal(rowArray2[0]["zadsaldokasa"]);
            }
            else
            {
                num2 = new decimal();
            }
            return decimal.Add(num, num2);
        }

        public decimal Obustave_StanjeKase(string IDOBRACUN, int IDRADNIK, int IDobustava, DataSet stanjeobustava)
        {
            decimal num = 0;
            decimal num2 = 0;
            decimal num3 = 0;
            DataRow[] rowArray = stanjeobustava.Tables[0].Select("IDRADNIK = " + Conversions.ToString(IDRADNIK) + " AND IDobustava = " + Conversions.ToString(IDobustava));
            DataRow[] rowArray2 = this.userControlDataGridRADNIK.DataGrid.DataSet.RADNIKObustava.Select("IDRADNIK = " + Conversions.ToString(IDRADNIK) + " AND zadobustavaidobustava = " + Conversions.ToString(IDobustava));
            DataRow[] rowArray3 = this.userControlDataGridRADNIK.DataGrid.DataSet.RADNIKObustava.Select("IDRADNIK = " + Conversions.ToString(IDRADNIK) + " AND zadobustavaidobustava = " + Conversions.ToString(IDobustava));
            if (rowArray.Length > 0)
            {
                num = Conversions.ToDecimal(rowArray[0]["OTPLACENO"]);
            }
            else
            {
                num = new decimal();
            }
            if (rowArray2.Length > 0)
            {
                num2 = Conversions.ToDecimal(rowArray2[0]["zadsaldokasa"]);
            }
            else
            {
                num2 = new decimal();
            }
            if (rowArray3.Length > 0)
            {
                num3 = Conversions.ToDecimal(rowArray3[0]["zadisplacenokasa"]);
            }
            else
            {
                num3 = new decimal();
            }
            return decimal.Subtract(decimal.Add(num, num2), num3);
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

        private void RADNIKWorkWith_Load(object sender, EventArgs e)
        {
            if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
            {
                this.userControlDataGridRADNIK.DataGrid.DoubleClick += new EventHandler(this.Select_Click);
                Size size = new System.Drawing.Size(600, 500);
                this.Parent.Parent.Size = size;
            }
            else
            {
                this.userControlDataGridRADNIK.DataGrid.DoubleClickRow += new DoubleClickRowEventHandler(this.DataGrid_DoubleClickRow);
            }
            this.userControlDataGridRADNIK.DataGrid.DisplayLayout.Override.AllowDelete = DefaultableBoolean.False;
            this.userControlDataGridRADNIK.DataGrid.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False;
            this.userControlDataGridRADNIK.DataGrid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No;
            this.userControlDataGridRADNIK.DataGrid.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True;
            this.userControlDataGridRADNIK.DataGrid.DisplayLayout.ViewStyleBand = ViewStyleBand.OutlookGroupBy;
            this.userControlDataGridRADNIK.DataGrid.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortSingle;
            this.userControlDataGridRADNIK.FillByPage = false;
            this.FillData();
        }

        private void RADNIKWorkWith_Load1(object sender, EventArgs e)
        {
        }

        [EventSubscription("topic://NetAdvantage/BusinessComponentUpdated/RADNIK", Thread=ThreadOption.UserInterface)]
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
            UIElement lastElementEntered = this.userControlDataGridRADNIK.DataGrid.DisplayLayout.UIElement.LastElementEntered;
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
                this.smartPartInfo1.Title = string.Format("{0} Zaposlenici ", Deklarit.Resources.Resources.Select);
            }
            else
            {
                this.smartPartInfo1.Title = string.Format("{0} Zaposlenici ", Deklarit.Resources.Resources.Workwith);
            }
            this.smartPartInfo1.Description = this.smartPartInfo1.Title;
        }

        private void ShowMessage(string msg)
        {
            MessageBox.Show(msg, this.smartPartInfo1.Description, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private string[] SplitWords(string s)
        {
            return Regex.Split(s, @"\s+");
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
        public RADNIKWorkWithController Controller { get; set; }

        private DataRow CurrentDataRow
        {
            get
            {
                if (this.userControlDataGridRADNIK.DataGrid.CurrentRowIndex == -1)
                {
                    return null;
                }
                return this.userControlDataGridRADNIK.DataView[this.userControlDataGridRADNIK.DataGrid.CurrentRowIndex].Row;
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

        private RADNIKUserDataGrid userControlDataGridRADNIK;

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


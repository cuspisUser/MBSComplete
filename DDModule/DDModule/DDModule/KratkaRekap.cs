
using CrystalDecisions.CrystalReports.Engine;
using DDModule;
//using DDModule.Controllers;
using Deklarit.Practices.CompositeUI;
using Deklarit.Practices.CompositeUI.Workspaces;
using Infragistics.Win;
using Infragistics.Win.UltraWinDock;
using Infragistics.Win.UltraWinGrid;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.SmartParts;
using Microsoft.Practices.ObjectBuilder;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using NetAdvantage.WorkItems;
using mipsed.application.framework;
using Placa;
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using NetAdvantage.SmartParts;
using KratkaRekapNamespace;


namespace DDModule.DDModule
{

    [SmartPart]
    public class KratkaRekap : UserControl, ISmartPartInfoProvider, IFilteredView
    {
        [AccessedThroughProperty("_KratkaRekapAutoHideControl")]
        private AutoHideControl __KratkaRekapAutoHideControl;
        [AccessedThroughProperty("_KratkaRekapUnpinnedTabAreaBottom")]
        private UnpinnedTabArea __KratkaRekapUnpinnedTabAreaBottom;
        [AccessedThroughProperty("_KratkaRekapUnpinnedTabAreaLeft")]
        private UnpinnedTabArea __KratkaRekapUnpinnedTabAreaLeft;
        [AccessedThroughProperty("_KratkaRekapUnpinnedTabAreaRight")]
        private UnpinnedTabArea __KratkaRekapUnpinnedTabAreaRight;
        [AccessedThroughProperty("_KratkaRekapUnpinnedTabAreaTop")]
        private UnpinnedTabArea __KratkaRekapUnpinnedTabAreaTop;
        [AccessedThroughProperty("Dataset11")]
        private dsTotali _Dataset11;
        [AccessedThroughProperty("daTotaliUstanove")]
        private SqlDataAdapter _daTotaliUstanove;
        [AccessedThroughProperty("DsTotaliUstanove1")]
        private dsTotaliUstanove _DsTotaliUstanove1;
        [AccessedThroughProperty("SqlCommand1")]
        private SqlCommand _SqlCommand1;
        [AccessedThroughProperty("SqlConnection1")]
        private SqlConnection _SqlConnection1;
        [AccessedThroughProperty("SqlSelectCommand1")]
        private SqlCommand _SqlSelectCommand1;
        [AccessedThroughProperty("Totali1BindingSource")]
        private BindingSource _Totali1BindingSource;
        [AccessedThroughProperty("Totali1BindingSource1")]
        private BindingSource _Totali1BindingSource1;
        [AccessedThroughProperty("UltraDockManager1")]
        private UltraDockManager _UltraDockManager1;
        [AccessedThroughProperty("UltraGrid3")]
        private UltraGrid _UltraGrid3;
        private IContainer components;
        private string GODINAOBRACUNA { get; set; }
        private SmartPartInfoProvider infoProvider;
        private string m_idobracun;
        private string m_opisobracuna;
        private string MJESECOBRACUNA { get; set; }
        private string OPIS;
        private SmartPartInfo smartPartInfo1;

        public KratkaRekap()
        {
            base.Load += new EventHandler(this.KratkaRekap_Load);
            this.InitializeComponent();
            this.smartPartInfo1 = new SmartPartInfo("Rekapitulacija obračuna", "Rekapitulacija obračuna");
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);
        }

        public ISmartPartInfo GetSmartPartInfo(Type smartPartInfoType)
        {
            ISmartPartInfo info = null;
            return info;
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            ComponentResourceManager manager = new ComponentResourceManager(typeof(KratkaRekap));
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            UltraGridBand band = new UltraGridBand("REKAPITULACIJA", -1);
            UltraGridColumn column = new UltraGridColumn("opis");
            UltraGridColumn column2 = new UltraGridColumn("iznos");
            UltraGridColumn column3 = new UltraGridColumn("sati");
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            this.daTotaliUstanove = new SqlDataAdapter();
            this.SqlSelectCommand1 = new SqlCommand();
            this.SqlConnection1 = new SqlConnection();
            this.SqlCommand1 = new SqlCommand();
            this.UltraDockManager1 = new UltraDockManager(this.components);
            this._KratkaRekapUnpinnedTabAreaLeft = new UnpinnedTabArea();
            this._KratkaRekapUnpinnedTabAreaRight = new UnpinnedTabArea();
            this._KratkaRekapUnpinnedTabAreaTop = new UnpinnedTabArea();
            this._KratkaRekapUnpinnedTabAreaBottom = new UnpinnedTabArea();
            this._KratkaRekapAutoHideControl = new AutoHideControl();
            this.UltraGrid3 = new UltraGrid();
            this.Totali1BindingSource1 = new BindingSource(this.components);
            this.Dataset11 = new dsTotali();
            this.Totali1BindingSource = new BindingSource(this.components);
            ((ISupportInitialize) this.UltraDockManager1).BeginInit();
            ((ISupportInitialize) this.UltraGrid3).BeginInit();
            ((ISupportInitialize) this.Totali1BindingSource1).BeginInit();
            this.Dataset11.BeginInit();
            ((ISupportInitialize) this.Totali1BindingSource).BeginInit();
            this.SuspendLayout();
            this.daTotaliUstanove.SelectCommand = this.SqlSelectCommand1;
            this.daTotaliUstanove.TableMappings.AddRange(new DataTableMapping[] { new DataTableMapping("Table", "V_OD_OBRACUN_RADNIK_TOTALI", new DataColumnMapping[] { 
                new DataColumnMapping("IDOBRACUN", "IDOBRACUN"), new DataColumnMapping("UKUPNOBRUTO", "UKUPNOBRUTO"), new DataColumnMapping("UKUPNOOSNOVICAZADOPRINOS", "UKUPNOOSNOVICAZADOPRINOS"), new DataColumnMapping("UKUPNODOPRINOSI", "UKUPNODOPRINOSI"), new DataColumnMapping("UKUPNOOO", "UKUPNOOO"), new DataColumnMapping("UKUPNOOLAKSICE", "UKUPNOOLAKSICE"), new DataColumnMapping("UKUPNOPOREZNOPRIZNATEOLAKSICE", "UKUPNOPOREZNOPRIZNATEOLAKSICE"), new DataColumnMapping("POREZNAOSNOVICA", "POREZNAOSNOVICA"), new DataColumnMapping("UKUPNOPOREZ", "UKUPNOPOREZ"), new DataColumnMapping("UKUPNOPRIREZ", "UKUPNOPRIREZ"), new DataColumnMapping("UKUPNOPOREZIPRIREZ", "UKUPNOPOREZIPRIREZ"), new DataColumnMapping("NETOPLACA", "NETOPLACA"), new DataColumnMapping("UKUPNONETONAKNADE", "UKUPNONETONAKNADE"), new DataColumnMapping("NETOPRIMANJA", "NETOPRIMANJA"), new DataColumnMapping("UKUPNOOBUSTAVE", "UKUPNOOBUSTAVE"), new DataColumnMapping("UKUPNOZAISPLATU", "UKUPNOZAISPLATU"), 
                new DataColumnMapping("UKUPNODOPRINOSINA", "UKUPNODOPRINOSINA")
             }) });
            this.SqlSelectCommand1.CommandText = manager.GetString("SqlSelectCommand1.CommandText");
            this.SqlSelectCommand1.Connection = this.SqlConnection1;
            this.SqlSelectCommand1.Parameters.AddRange(new SqlParameter[] { new SqlParameter("@idobracun", SqlDbType.NVarChar, 11, "DDOBRACUNIDOBRACUN") });
            this.SqlConnection1.ConnectionString = @"Data Source=SRECKO\SQLEXPRESS;Initial Catalog=NovaPlaca;Integrated Security=True";
            this.SqlConnection1.FireInfoMessageEventOnUserErrors = false;
            this.SqlCommand1.CommandText = "dbo.[S_OD_REKAP_ELEMENATA_OBRACUN]";
            this.SqlCommand1.CommandType = CommandType.StoredProcedure;
            this.SqlCommand1.Connection = this.SqlConnection1;
            this.UltraDockManager1.HostControl = this;
            this._KratkaRekapUnpinnedTabAreaLeft.Dock = DockStyle.Left;
            this._KratkaRekapUnpinnedTabAreaLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xee);
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this._KratkaRekapUnpinnedTabAreaLeft.Location = point;
            this._KratkaRekapUnpinnedTabAreaLeft.Name = "_KratkaRekapUnpinnedTabAreaLeft";
            this._KratkaRekapUnpinnedTabAreaLeft.Owner = this.UltraDockManager1;
            Size size = new System.Drawing.Size(0, 0x284);
            this._KratkaRekapUnpinnedTabAreaLeft.Size = size;
            this._KratkaRekapUnpinnedTabAreaLeft.TabIndex = 0xcb;
            this._KratkaRekapUnpinnedTabAreaRight.Dock = DockStyle.Right;
            this._KratkaRekapUnpinnedTabAreaRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xee);
            point = new System.Drawing.Point(0x357, 0);
            this._KratkaRekapUnpinnedTabAreaRight.Location = point;
            this._KratkaRekapUnpinnedTabAreaRight.Name = "_KratkaRekapUnpinnedTabAreaRight";
            this._KratkaRekapUnpinnedTabAreaRight.Owner = this.UltraDockManager1;
            size = new System.Drawing.Size(0, 0x284);
            this._KratkaRekapUnpinnedTabAreaRight.Size = size;
            this._KratkaRekapUnpinnedTabAreaRight.TabIndex = 0xcc;
            this._KratkaRekapUnpinnedTabAreaTop.Dock = DockStyle.Top;
            this._KratkaRekapUnpinnedTabAreaTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xee);
            point = new System.Drawing.Point(0, 0);
            this._KratkaRekapUnpinnedTabAreaTop.Location = point;
            this._KratkaRekapUnpinnedTabAreaTop.Name = "_KratkaRekapUnpinnedTabAreaTop";
            this._KratkaRekapUnpinnedTabAreaTop.Owner = this.UltraDockManager1;
            size = new System.Drawing.Size(0x357, 0);
            this._KratkaRekapUnpinnedTabAreaTop.Size = size;
            this._KratkaRekapUnpinnedTabAreaTop.TabIndex = 0xcd;
            this._KratkaRekapUnpinnedTabAreaBottom.Dock = DockStyle.Bottom;
            this._KratkaRekapUnpinnedTabAreaBottom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xee);
            point = new System.Drawing.Point(0, 0x284);
            this._KratkaRekapUnpinnedTabAreaBottom.Location = point;
            this._KratkaRekapUnpinnedTabAreaBottom.Name = "_KratkaRekapUnpinnedTabAreaBottom";
            this._KratkaRekapUnpinnedTabAreaBottom.Owner = this.UltraDockManager1;
            size = new System.Drawing.Size(0x357, 0);
            this._KratkaRekapUnpinnedTabAreaBottom.Size = size;
            this._KratkaRekapUnpinnedTabAreaBottom.TabIndex = 0xce;
            this._KratkaRekapAutoHideControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xee);
            point = new System.Drawing.Point(0, 0);
            this._KratkaRekapAutoHideControl.Location = point;
            this._KratkaRekapAutoHideControl.Name = "_KratkaRekapAutoHideControl";
            this._KratkaRekapAutoHideControl.Owner = this.UltraDockManager1;
            size = new System.Drawing.Size(0, 0);
            this._KratkaRekapAutoHideControl.Size = size;
            this._KratkaRekapAutoHideControl.TabIndex = 0xcf;
            this.UltraGrid3.DataMember = "REKAPITULACIJA";
            this.UltraGrid3.DataSource = this.Totali1BindingSource1;
            appearance.BackColor = Color.WhiteSmoke;
            appearance.ForeColor = Color.MidnightBlue;
            appearance.TextHAlignAsString = "Left";
            this.UltraGrid3.DisplayLayout.Appearance = appearance;
            this.UltraGrid3.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
            column.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column.Header.VisiblePosition = 0;
            column.Width = 0x202;
            column2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column2.Header.VisiblePosition = 1;
            column2.Width = 0xa1;
            column3.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column3.Header.VisiblePosition = 2;
            column3.Width = 0xa1;
            band.Columns.AddRange(new object[] { column, column2, column3 });
            this.UltraGrid3.DisplayLayout.BandsSerializer.Add(band);
            this.UltraGrid3.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            appearance2.BackColor = Color.LightSteelBlue;
            appearance2.ForeColor = Color.MidnightBlue;
            appearance2.ThemedElementAlpha = Alpha.Transparent;
            this.UltraGrid3.DisplayLayout.CaptionAppearance = appearance2;
            appearance3.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance3.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance3.BackGradientStyle = GradientStyle.Vertical;
            appearance3.BorderColor = System.Drawing.SystemColors.Window;
            this.UltraGrid3.DisplayLayout.GroupByBox.Appearance = appearance3;
            appearance4.ForeColor = System.Drawing.SystemColors.GrayText;
            this.UltraGrid3.DisplayLayout.GroupByBox.BandLabelAppearance = appearance4;
            this.UltraGrid3.DisplayLayout.MaxBandDepth = 1;
            this.UltraGrid3.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect;
            this.UltraGrid3.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortSingle;
            this.UltraGrid3.DisplayLayout.ViewStyle = ViewStyle.SingleBand;
            this.UltraGrid3.Dock = DockStyle.Fill;
            this.UltraGrid3.Font = new System.Drawing.Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xee);
            point = new System.Drawing.Point(0, 0);
            this.UltraGrid3.Location = point;
            this.UltraGrid3.Name = "UltraGrid3";
            size = new System.Drawing.Size(0x357, 0x284);
            this.UltraGrid3.Size = size;
            this.UltraGrid3.TabIndex = 0xca;
            this.UltraGrid3.TabStop = false;
            this.UltraGrid3.Text = "Rekapitulacija";
            this.UltraGrid3.UseOsThemes = DefaultableBoolean.False;
            this.Totali1BindingSource1.DataSource = this.Dataset11;
            this.Totali1BindingSource1.Position = 0;
            this.Dataset11.DataSetName = "Totali";
            this.Dataset11.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
            this.Totali1BindingSource.DataSource = this.Dataset11;
            this.Totali1BindingSource.Position = 0;
            this.Controls.Add(this._KratkaRekapAutoHideControl);
            this.Controls.Add(this.UltraGrid3);
            this.Controls.Add(this._KratkaRekapUnpinnedTabAreaTop);
            this.Controls.Add(this._KratkaRekapUnpinnedTabAreaBottom);
            this.Controls.Add(this._KratkaRekapUnpinnedTabAreaLeft);
            this.Controls.Add(this._KratkaRekapUnpinnedTabAreaRight);
            this.Name = "KratkaRekap";
            size = new System.Drawing.Size(0x357, 0x284);
            this.Size = size;
            ((ISupportInitialize) this.UltraDockManager1).EndInit();
            ((ISupportInitialize) this.UltraGrid3).EndInit();
            ((ISupportInitialize) this.Totali1BindingSource1).EndInit();
            this.Dataset11.EndInit();
            ((ISupportInitialize) this.Totali1BindingSource).EndInit();
            this.ResumeLayout(false);
        }

        public void Ispisi()
        {
            ReportDocument document = new ReportDocument();
            document.Load(System.Windows.Forms.Application.StartupPath + @"\DDIzvjestaji\rptRekapitulacijaObracun.rpt");
            document.SetDataSource(this.Dataset11);
            ExtendedWindowWorkspace workspace = new ExtendedWindowWorkspace();
            PreviewReportWorkItem item = this.Controller.WorkItem.Items.Get<PreviewReportWorkItem>("Pregled");
            if (item == null)
            {
                item = this.Controller.WorkItem.Items.AddNew<PreviewReportWorkItem>("Pregled");
            }
            int num2 = Conversions.ToInteger(this.m_idobracun.Substring(5, 2));
            int num = Conversions.ToInteger(this.m_idobracun.Substring(0, 4));
            KORISNIKDataAdapter adapter = new KORISNIKDataAdapter();
            KORISNIKDataSet dataSet = new KORISNIKDataSet();
            adapter.Fill(dataSet);
            document.SetParameterValue("naziv", RuntimeHelpers.GetObjectValue(dataSet.KORISNIK.Rows[0]["KORISNIK1NAZIV"]));
            document.SetParameterValue("ADRESA", Operators.AddObject(Operators.AddObject(dataSet.KORISNIK.Rows[0]["KORISNIK1ADRESA"], " "), dataSet.KORISNIK.Rows[0]["KORISNIK1MJESTO"]));
            document.SetParameterValue("oib", RuntimeHelpers.GetObjectValue(dataSet.KORISNIK.Rows[0]["KORISNIKOIB"]));
            document.SetParameterValue("TELEFONfax", Operators.AddObject(Operators.AddObject(dataSet.KORISNIK.Rows[0]["KONTAKTTELEFON"], " "), dataSet.KORISNIK.Rows[0]["KONTAKTFAX"]));
            document.SetParameterValue("obracun", this.m_idobracun);
            document.SetParameterValue("opisObracuna", this.m_opisobracuna);
            item.Izvjestaj = document;
            item.Activate();
            item.Show(item.Workspaces["main"]);
        }

        [LocalCommandHandler("IspisiCommand")]
        public void IspisiHandler(object sender, EventArgs e)
        {
            this.Ispisi();
        }

        [LocalCommandHandler("IzlazCommand")]
        public void IzlazHandler(object sender, EventArgs e)
        {
            this.Controller.WorkItem.Workspaces["main"].Close(RuntimeHelpers.GetObjectValue(this.Controller.WorkItem.Workspaces["main"].ActiveSmartPart));
        }

        [LocalCommandHandler("KontirajCommand")]
        public void KontirajHandler(object sender, EventArgs e)
        {
            SHEMADDDataAdapter adapter = new SHEMADDDataAdapter();
            SHEMADDDataSet dataSet = new SHEMADDDataSet();
            GKSTAVKADataSet set2 = new GKSTAVKADataSet();
            GKSTAVKADataAdapter adapter3 = new GKSTAVKADataAdapter();
            int num = Conversions.ToInteger(Operators.AddObject(this.NUMERACIJA(), 1));
            SHEMADDSelectionListWorkItem item = this.Controller.WorkItem.Items.AddNew<SHEMADDSelectionListWorkItem>("test");
            DataRow row3 = item.ShowModal(true, "", null);
            item.Terminate();
            if (row3 != null)
            {
                DataRow row2;
                DataRow current;
                IEnumerator enumerator = null;
                this.OPIS = "test";
                this.OPIS = this.m_opisobracuna + " " + this.MJESECOBRACUNA + "/" + this.GODINAOBRACUNA + " šifra obr. " + this.m_idobracun;
                adapter.FillByIDSHEMADD(dataSet, Conversions.ToInteger(row3["idshemadd"]));
                decimal num2 = Conversions.ToDecimal(this.DsTotaliUstanove1.Tables[1].Rows[0]["uKUPNOBRUTO"]);
                if (dataSet.SHEMADDSHEMADDSTANDARD.Select("idddvrsteiznosa=8").Length > 0)
                {
                    row2 = set2.GKSTAVKA.NewRow();
                    row2["datumdokumenta"] = DateAndTime.Today;
                    row2["brojdokumenta"] = num;
                    row2["brojstavke"] = 1;
                    row2["iddokument"] = 0x3e6;
                    row2["OPIS"] = this.OPIS;
                    row2["zatvoreniiznos"] = 0;
                    row2["statusgk"] = 0;
                    row2["IDKONTO"] = RuntimeHelpers.GetObjectValue(dataSet.SHEMADDSHEMADDSTANDARD.Select("idddvrsteiznosa=8")[0]["KONTODDVRSTAIZNOSAIDKONTO"]);
                    row2["IDMJESTOTROSKA"] = RuntimeHelpers.GetObjectValue(dataSet.SHEMADDSHEMADDSTANDARD.Select("idddvrsteiznosa=8")[0]["MTDDVRSTAIZNOSAIDMJESTOTROSKA"]);
                    row2["IDORGJED"] = RuntimeHelpers.GetObjectValue(dataSet.SHEMADD.Rows[0]["SHEMADDOJIDORGJED"]);
                    row2["GKGODIDGODINE"] = mipsed.application.framework.Application.ActiveYear;
                    if (Operators.ConditionalCompareObjectEqual(dataSet.SHEMADDSHEMADDSTANDARD.Select("idddvrsteiznosa=8")[0]["STRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA"], 1, false))
                    {
                        row2["duguje"] = RuntimeHelpers.GetObjectValue(this.DsTotaliUstanove1.Tables[1].Rows[0]["uKUPNOBRUTO"]);
                        row2["potrazuje"] = 0;
                    }
                    else
                    {
                        row2["potrazuje"] = RuntimeHelpers.GetObjectValue(this.DsTotaliUstanove1.Tables[1].Rows[0]["uKUPNOBRUTO"]);
                        row2["duguje"] = 0;
                    }
                    set2.GKSTAVKA.Rows.Add(row2);
                }
                S_DD_REKAP_DOPRINOSDataAdapter adapter2 = new S_DD_REKAP_DOPRINOSDataAdapter();
                S_DD_REKAP_DOPRINOSDataSet set3 = new S_DD_REKAP_DOPRINOSDataSet();
                adapter2.Fill(set3, this.m_idobracun);
                try
                {
                    enumerator = dataSet.SHEMADDSHEMADDDOPRINOS.Rows.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        current = (DataRow) enumerator.Current;
                        if (set3.S_DD_REKAP_DOPRINOS.Select(Conversions.ToString(Operators.ConcatenateObject("sifra = ", current["SHEMADDDOPRINOSIDDOPRINOS"]))).Length > 0)
                        {
                            row2 = set2.GKSTAVKA.NewRow();
                            row2["datumdokumenta"] = DateAndTime.Today;
                            row2["brojdokumenta"] = num;
                            row2["brojstavke"] = 1;
                            row2["iddokument"] = 0x3e6;
                            row2["OPIS"] = this.OPIS;
                            row2["zatvoreniiznos"] = 0;
                            row2["statusgk"] = 0;
                            row2["IDKONTO"] = RuntimeHelpers.GetObjectValue(current["KONTODOPIDKONTO"]);
                            row2["IDMJESTOTROSKA"] = RuntimeHelpers.GetObjectValue(current["MTDOPIDMJESTOTROSKA"]);
                            row2["IDORGJED"] = RuntimeHelpers.GetObjectValue(dataSet.SHEMADD.Rows[0]["SHEMADDOJIDORGJED"]);
                            row2["GKGODIDGODINE"] = mipsed.application.framework.Application.ActiveYear;
                            if (Operators.ConditionalCompareObjectEqual(current["STRANEDOPIDSTRANEKNJIZENJA"], 1, false))
                            {
                                row2["duguje"] = RuntimeHelpers.GetObjectValue(set3.S_DD_REKAP_DOPRINOS.Select(Conversions.ToString(Operators.ConcatenateObject("sifra = ", current["SHEMADDDOPRINOSIDDOPRINOS"])))[0]["iznos"]);
                                row2["potrazuje"] = 0;
                            }
                            else
                            {
                                row2["potrazuje"] = RuntimeHelpers.GetObjectValue(set3.S_DD_REKAP_DOPRINOS.Select(Conversions.ToString(Operators.ConcatenateObject("sifra = ", current["SHEMADDDOPRINOSIDDOPRINOS"])))[0]["iznos"]);
                                row2["duguje"] = 0;
                            }
                            set2.GKSTAVKA.Rows.Add(row2);
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
                foreach (DataRow row in dataSet.SHEMADDSHEMADDSTANDARD.Select("idddvrsteiznosa=9"))
                {
                    row2 = set2.GKSTAVKA.NewRow();
                    row2["datumdokumenta"] = DateAndTime.Today;
                    row2["brojdokumenta"] = num;
                    row2["brojstavke"] = 1;
                    row2["iddokument"] = 0x3e6;
                    row2["OPIS"] = this.OPIS;
                    row2["zatvoreniiznos"] = 0;
                    row2["statusgk"] = 0;
                    row2["IDKONTO"] = RuntimeHelpers.GetObjectValue(row["KONTODDVRSTAIZNOSAIDKONTO"]);
                    row2["IDMJESTOTROSKA"] = RuntimeHelpers.GetObjectValue(row["MTDDVRSTAIZNOSAIDMJESTOTROSKA"]);
                    row2["IDORGJED"] = RuntimeHelpers.GetObjectValue(dataSet.SHEMADD.Rows[0]["SHEMADDOJIDORGJED"]);
                    row2["GKGODIDGODINE"] = mipsed.application.framework.Application.ActiveYear;
                    if (Operators.ConditionalCompareObjectEqual(row["STRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA"], 1, false))
                    {
                        row2["duguje"] = RuntimeHelpers.GetObjectValue(this.DsTotaliUstanove1.Tables[1].Rows[0]["ukupnoporez"]);
                        row2["potrazuje"] = 0;
                    }
                    else
                    {
                        row2["potrazuje"] = RuntimeHelpers.GetObjectValue(this.DsTotaliUstanove1.Tables[1].Rows[0]["ukupnoporez"]);
                        row2["duguje"] = 0;
                    }
                    set2.GKSTAVKA.Rows.Add(row2);
                }
                foreach (DataRow row in dataSet.SHEMADDSHEMADDSTANDARD.Select("idddvrsteiznosa=10"))
                {
                    row2 = set2.GKSTAVKA.NewRow();
                    row2["datumdokumenta"] = DateAndTime.Today;
                    row2["brojdokumenta"] = num;
                    row2["brojstavke"] = 1;
                    row2["iddokument"] = 0x3e6;
                    row2["OPIS"] = this.OPIS;
                    row2["zatvoreniiznos"] = 0;
                    row2["statusgk"] = 0;
                    row2["IDKONTO"] = RuntimeHelpers.GetObjectValue(row["KONTODDVRSTAIZNOSAIDKONTO"]);
                    row2["IDMJESTOTROSKA"] = RuntimeHelpers.GetObjectValue(row["MTDDVRSTAIZNOSAIDMJESTOTROSKA"]);
                    row2["IDORGJED"] = RuntimeHelpers.GetObjectValue(dataSet.SHEMADD.Rows[0]["SHEMADDOJIDORGJED"]);
                    row2["GKGODIDGODINE"] = mipsed.application.framework.Application.ActiveYear;
                    if (Operators.ConditionalCompareObjectEqual(row["STRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA"], 1, false))
                    {
                        row2["duguje"] = RuntimeHelpers.GetObjectValue(this.DsTotaliUstanove1.Tables[1].Rows[0]["ukupnoprirez"]);
                        row2["potrazuje"] = 0;
                    }
                    else
                    {
                        row2["potrazuje"] = RuntimeHelpers.GetObjectValue(this.DsTotaliUstanove1.Tables[1].Rows[0]["ukupnoprirez"]);
                        row2["duguje"] = 0;
                    }
                    set2.GKSTAVKA.Rows.Add(row2);
                }
                foreach (DataRow row in dataSet.SHEMADDSHEMADDSTANDARD.Select("idddvrsteiznosa=11"))
                {
                    row2 = set2.GKSTAVKA.NewRow();
                    row2["datumdokumenta"] = DateAndTime.Today;
                    row2["brojdokumenta"] = num;
                    row2["brojstavke"] = 1;
                    row2["iddokument"] = 0x3e6;
                    row2["OPIS"] = this.OPIS;
                    row2["zatvoreniiznos"] = 0;
                    row2["statusgk"] = 0;
                    row2["IDKONTO"] = RuntimeHelpers.GetObjectValue(row["KONTODDVRSTAIZNOSAIDKONTO"]);
                    row2["IDMJESTOTROSKA"] = RuntimeHelpers.GetObjectValue(row["MTDDVRSTAIZNOSAIDMJESTOTROSKA"]);
                    row2["IDORGJED"] = RuntimeHelpers.GetObjectValue(dataSet.SHEMADD.Rows[0]["SHEMADDOJIDORGJED"]);
                    row2["GKGODIDGODINE"] = mipsed.application.framework.Application.ActiveYear;
                    if (Operators.ConditionalCompareObjectEqual(row["STRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA"], 1, false))
                    {
                        row2["duguje"] = RuntimeHelpers.GetObjectValue(this.DsTotaliUstanove1.Tables[1].Rows[0]["porezkrizni"]);
                        row2["potrazuje"] = 0;
                    }
                    else
                    {
                        row2["potrazuje"] = RuntimeHelpers.GetObjectValue(this.DsTotaliUstanove1.Tables[1].Rows[0]["porezkrizni"]);
                        row2["duguje"] = 0;
                    }
                    set2.GKSTAVKA.Rows.Add(row2);
                }
                foreach (DataRow row in dataSet.SHEMADDSHEMADDSTANDARD.Select("idddvrsteiznosa=12"))
                {
                    row2 = set2.GKSTAVKA.NewRow();
                    row2["datumdokumenta"] = DateAndTime.Today;
                    row2["brojdokumenta"] = num;
                    row2["brojstavke"] = 1;
                    row2["iddokument"] = 0x3e6;
                    row2["OPIS"] = this.OPIS;
                    row2["zatvoreniiznos"] = 0;
                    row2["statusgk"] = 0;
                    row2["IDKONTO"] = RuntimeHelpers.GetObjectValue(row["KONTODDVRSTAIZNOSAIDKONTO"]);
                    row2["IDMJESTOTROSKA"] = RuntimeHelpers.GetObjectValue(row["MTDDVRSTAIZNOSAIDMJESTOTROSKA"]);
                    row2["IDORGJED"] = RuntimeHelpers.GetObjectValue(dataSet.SHEMADD.Rows[0]["SHEMADDOJIDORGJED"]);
                    row2["GKGODIDGODINE"] = mipsed.application.framework.Application.ActiveYear;
                    if (Operators.ConditionalCompareObjectEqual(row["STRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA"], 1, false))
                    {
                        row2["duguje"] = Operators.SubtractObject(this.DsTotaliUstanove1.Tables[1].Rows[0]["netoplaca"], this.DsTotaliUstanove1.Tables[1].Rows[0]["porezkrizni"]);
                        row2["potrazuje"] = 0;
                    }
                    else
                    {
                        row2["potrazuje"] = Operators.SubtractObject(this.DsTotaliUstanove1.Tables[1].Rows[0]["netoplaca"], this.DsTotaliUstanove1.Tables[1].Rows[0]["porezkrizni"]);
                        row2["duguje"] = 0;
                    }
                    set2.GKSTAVKA.Rows.Add(row2);
                }
                foreach (DataRow row in dataSet.SHEMADDSHEMADDSTANDARD.Select("idddvrsteiznosa=14"))
                {
                    row2 = set2.GKSTAVKA.NewRow();
                    row2["datumdokumenta"] = DateAndTime.Today;
                    row2["brojdokumenta"] = num;
                    row2["brojstavke"] = 1;
                    row2["iddokument"] = 0x3e6;
                    row2["OPIS"] = this.OPIS;
                    row2["zatvoreniiznos"] = 0;
                    row2["statusgk"] = 0;
                    row2["IDKONTO"] = RuntimeHelpers.GetObjectValue(row["KONTODDVRSTAIZNOSAIDKONTO"]);
                    row2["IDMJESTOTROSKA"] = RuntimeHelpers.GetObjectValue(row["MTDDVRSTAIZNOSAIDMJESTOTROSKA"]);
                    row2["IDORGJED"] = RuntimeHelpers.GetObjectValue(dataSet.SHEMADD.Rows[0]["SHEMADDOJIDORGJED"]);
                    row2["GKGODIDGODINE"] = mipsed.application.framework.Application.ActiveYear;
                    if (Operators.ConditionalCompareObjectEqual(row["STRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA"], 1, false))
                    {
                        row2["duguje"] = Operators.AddObject(this.DsTotaliUstanove1.Tables[1].Rows[0]["uKUPNOBRUTO"], this.DsTotaliUstanove1.Tables[1].Rows[0]["ukupnodoprinosina"]);
                        row2["potrazuje"] = 0;
                    }
                    else
                    {
                        row2["potrazuje"] = Operators.AddObject(this.DsTotaliUstanove1.Tables[1].Rows[0]["uKUPNOBRUTO"], this.DsTotaliUstanove1.Tables[1].Rows[0]["ukupnodoprinosina"]);
                        row2["duguje"] = 0;
                    }
                    set2.GKSTAVKA.Rows.Add(row2);
                }
                ExtendedWindowSmartPartInfo smartPartInfo = new ExtendedWindowSmartPartInfo {
                    StartPosition = FormStartPosition.CenterParent,
                    Modal = true,
                    ControlBox = false,
                    Title = "Pretpregled temeljnice prije knjiženja",
                    Icon = ImageResourcesNew.mbs
                };
                ExtendedWindowWorkspace workspace = new ExtendedWindowWorkspace();
                PregledTemeljnice smartPart = this.Controller.WorkItem.Items.AddNew<PregledTemeljnice>();
                smartPart.GkstavkaDataSet1.Merge(set2);
                workspace.Show(smartPart, smartPartInfo);
                if (smartPart.ParentForm.DialogResult == DialogResult.OK)
                {
                    IEnumerator enumerator2 = null;
                    try
                    {
                        enumerator2 = set2.GKSTAVKA.GetEnumerator();
                        while (enumerator2.MoveNext())
                        {
                            current = (DataRow) enumerator2.Current;
                            current.BeginEdit();
                            current["datumdokumenta"] = RuntimeHelpers.GetObjectValue(smartPart.datumdok.Value);
                            current.EndEdit();
                        }
                    }
                    finally
                    {
                        if (enumerator2 is IDisposable)
                        {
                            (enumerator2 as IDisposable).Dispose();
                        }
                    }
                    adapter3.Update(set2);
                    Interaction.MsgBox("Knjiženje uspješno izvršeno. Kreiran je broj dokumenta: " + Conversions.ToString(num), MsgBoxStyle.Information, "MBS.Complete");
                }
            }
        }

        private void KratkaRekap_Load(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection
            {
                ConnectionString = Configuration.ConnectionString
            };

            this.m_idobracun = ((KratkaRekapWorkItem) this.Controller.WorkItem).Obracun;
            this.m_opisobracuna = ((KratkaRekapWorkItem) this.Controller.WorkItem).opisobracuna;
            this.SqlCommand1.Connection = connection;
            this.Text = "Rekapitulacija drugog dohotka za obračun :" + this.m_idobracun + " <ESC za izlaz> <F4 za ispis> ";

            this.daTotaliUstanove.SelectCommand.Connection = connection;
            this.daTotaliUstanove.SelectCommand.Parameters[0].Value = this.m_idobracun;
            this.DsTotaliUstanove1 = new dsTotaliUstanove();
            this.DsTotaliUstanove1.EnforceConstraints = false;
            this.daTotaliUstanove.Fill(this.DsTotaliUstanove1);

            s_od_rekap_doprinosDataAdapter adapter = new s_od_rekap_doprinosDataAdapter();
            s_od_rekap_doprinosDataSet dataSet = new s_od_rekap_doprinosDataSet();
            adapter.Fill(dataSet, this.m_idobracun);
            
            DataRow row = this.Dataset11.REKAPITULACIJA.NewRow();
            row["OPIS"] = "Ukupni bruto";
            row["IZNOS"] = string.Format("{0:0.00}", RuntimeHelpers.GetObjectValue(this.DsTotaliUstanove1.Tables[1].Rows[0]["uKUPNOBRUTO"]));
            this.Dataset11.REKAPITULACIJA.Rows.Add(row);
            
            row = this.Dataset11.REKAPITULACIJA.NewRow();
            row["OPIS"] = "Ukupno izdaci";
            row["IZNOS"] = string.Format("{0:0.00}", RuntimeHelpers.GetObjectValue(this.DsTotaliUstanove1.Tables[1].Rows[0]["ukupnoizdaci"]));
            this.Dataset11.REKAPITULACIJA.Rows.Add(row);
            
            row = this.Dataset11.REKAPITULACIJA.NewRow();
            row["OPIS"] = "Osnovica za obračun doprinosa";
            row["IZNOS"] = string.Format("{0:0.00}", Operators.SubtractObject(this.DsTotaliUstanove1.Tables[1].Rows[0]["uKUPNOBRUTO"], this.DsTotaliUstanove1.Tables[1].Rows[0]["ukupnoizdaci"]));
            this.Dataset11.REKAPITULACIJA.Rows.Add(row);
            
            row = this.Dataset11.REKAPITULACIJA.NewRow();
            row["OPIS"] = "Ukupno doprinosi iz plaće";
            row["IZNOS"] = string.Format("{0:0.00}", RuntimeHelpers.GetObjectValue(this.DsTotaliUstanove1.Tables[1].Rows[0]["ukupnodoprinosi"]));
            this.Dataset11.REKAPITULACIJA.Rows.Add(row);
            
            row = this.Dataset11.REKAPITULACIJA.NewRow();
            row["OPIS"] = "Porezna osnovica";
            row["IZNOS"] = string.Format("{0:0.00}", RuntimeHelpers.GetObjectValue(this.DsTotaliUstanove1.Tables[1].Rows[0]["poreznaosnovica"]));
            this.Dataset11.REKAPITULACIJA.Rows.Add(row);
            
            row = this.Dataset11.REKAPITULACIJA.NewRow();
            row["OPIS"] = "Porez";
            row["IZNOS"] = string.Format("{0:0.00}", RuntimeHelpers.GetObjectValue(this.DsTotaliUstanove1.Tables[1].Rows[0]["ukupnoporez"]));
            this.Dataset11.REKAPITULACIJA.Rows.Add(row);
            
            row = this.Dataset11.REKAPITULACIJA.NewRow();
            row["OPIS"] = "Prirez";
            row["IZNOS"] = string.Format("{0:0.00}", RuntimeHelpers.GetObjectValue(this.DsTotaliUstanove1.Tables[1].Rows[0]["ukupnoprirez"]));
            this.Dataset11.REKAPITULACIJA.Rows.Add(row);
            
            row = this.Dataset11.REKAPITULACIJA.NewRow();
            row["OPIS"] = "Porez i prirez";
            row["IZNOS"] = string.Format("{0:0.00}", RuntimeHelpers.GetObjectValue(this.DsTotaliUstanove1.Tables[1].Rows[0]["ukupnoporeziprirez"]));
            this.Dataset11.REKAPITULACIJA.Rows.Add(row);
            
            row = this.Dataset11.REKAPITULACIJA.NewRow();
            row["OPIS"] = "Neto drugi dohodak";
            row["IZNOS"] = string.Format("{0:0.00}", RuntimeHelpers.GetObjectValue(this.DsTotaliUstanove1.Tables[1].Rows[0]["netoplaca"]));
            this.Dataset11.REKAPITULACIJA.Rows.Add(row);
            
            row = this.Dataset11.REKAPITULACIJA.NewRow();
            row["OPIS"] = "Posebni porez na neto drugi dohodak";
            row["IZNOS"] = string.Format("{0:0.00}", RuntimeHelpers.GetObjectValue(this.DsTotaliUstanove1.Tables[1].Rows[0]["porezkrizni"]));
            this.Dataset11.REKAPITULACIJA.Rows.Add(row);
            
            row = this.Dataset11.REKAPITULACIJA.NewRow();
            row["OPIS"] = "Neto drugi dohodak umanjen za posebni porez";
            row["IZNOS"] = string.Format("{0:0.00}", Operators.SubtractObject(this.DsTotaliUstanove1.Tables[1].Rows[0]["netoplaca"], this.DsTotaliUstanove1.Tables[1].Rows[0]["porezkrizni"]));
            this.Dataset11.REKAPITULACIJA.Rows.Add(row);
            
            row = this.Dataset11.REKAPITULACIJA.NewRow();
            row["OPIS"] = "PDV";
            row["IZNOS"] = string.Format("{0:0.00}", RuntimeHelpers.GetObjectValue(this.DsTotaliUstanove1.Tables[1].Rows[0]["pdv"]));
            this.Dataset11.REKAPITULACIJA.Rows.Add(row);
            
            row = this.Dataset11.REKAPITULACIJA.NewRow();
            row["OPIS"] = "Ukupno za isplatu";
            row["IZNOS"] = string.Format("{0:0.00}", RuntimeHelpers.GetObjectValue(this.DsTotaliUstanove1.Tables[1].Rows[0]["zaisplatu"]));
            this.Dataset11.REKAPITULACIJA.Rows.Add(row);
            
            row = this.Dataset11.REKAPITULACIJA.NewRow();
            row["OPIS"] = "Ukupno doprinosi na plaću";
            row["IZNOS"] = string.Format("{0:0.00}", RuntimeHelpers.GetObjectValue(this.DsTotaliUstanove1.Tables[1].Rows[0]["ukupnodoprinosina"]));
            this.Dataset11.REKAPITULACIJA.Rows.Add(row);
            
            row = this.Dataset11.REKAPITULACIJA.NewRow();
            row["OPIS"] = "Trošak obračuna (bruto + doprinosi na + PDV";
            row["IZNOS"] = string.Format("{0:0.00}", Operators.AddObject(Operators.AddObject(this.DsTotaliUstanove1.Tables[1].Rows[0]["uKUPNOBRUTO"], this.DsTotaliUstanove1.Tables[1].Rows[0]["ukupnodoprinosina"]), this.DsTotaliUstanove1.Tables[1].Rows[0]["pdv"]));
            this.Dataset11.REKAPITULACIJA.Rows.Add(row);
        }

        public object NUMERACIJA()
        {
            object objectValue = new object();
            SqlConnection connection = new SqlConnection
            {
                ConnectionString = Mipsed7.Core.ApplicationDatabaseInformation.ConnectionString
            };
            SqlCommand command = new SqlCommand
            {
                CommandType = CommandType.Text,
                CommandText = "SELECT MAX(CAST(BROJDOKUMENTA AS INTEGER)) FROM GKSTAVKA WHERE IDDOKUMENT = @IDDOKUMENT AND gkgodidgodine =@GODINA"
            };
            command.Parameters.AddWithValue("@IDDOKUMENT", 0x3e6);
            command.Parameters.AddWithValue("@GODINA", SqlDbType.VarChar).Value = mipsed.application.framework.Application.ActiveYear;
            command.Connection = connection;
            connection.Open();

            objectValue = RuntimeHelpers.GetObjectValue(command.ExecuteScalar());
            if (Information.IsDBNull(RuntimeHelpers.GetObjectValue(objectValue)))
            {
                objectValue = 0;
            }

            connection.Close();
            return objectValue;
        }

        private void UltraGrid1_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
        }

        private void UltraGrid3_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
        }

        internal AutoHideControl _KratkaRekapAutoHideControl
        {
            [DebuggerNonUserCode]
            get
            {
                return this.__KratkaRekapAutoHideControl;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this.__KratkaRekapAutoHideControl = value;
            }
        }

        internal UnpinnedTabArea _KratkaRekapUnpinnedTabAreaBottom
        {
            [DebuggerNonUserCode]
            get
            {
                return this.__KratkaRekapUnpinnedTabAreaBottom;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this.__KratkaRekapUnpinnedTabAreaBottom = value;
            }
        }

        internal UnpinnedTabArea _KratkaRekapUnpinnedTabAreaLeft
        {
            [DebuggerNonUserCode]
            get
            {
                return this.__KratkaRekapUnpinnedTabAreaLeft;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this.__KratkaRekapUnpinnedTabAreaLeft = value;
            }
        }

        internal UnpinnedTabArea _KratkaRekapUnpinnedTabAreaRight
        {
            [DebuggerNonUserCode]
            get
            {
                return this.__KratkaRekapUnpinnedTabAreaRight;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this.__KratkaRekapUnpinnedTabAreaRight = value;
            }
        }

        internal UnpinnedTabArea _KratkaRekapUnpinnedTabAreaTop
        {
            [DebuggerNonUserCode]
            get
            {
                return this.__KratkaRekapUnpinnedTabAreaTop;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this.__KratkaRekapUnpinnedTabAreaTop = value;
            }
        }

        [CreateNew]
        public KratkaRekapController Controller { get; set; }

        internal dsTotali Dataset11
        {
            [DebuggerNonUserCode]
            get
            {
                return this._Dataset11;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._Dataset11 = value;
            }
        }

        internal SqlDataAdapter daTotaliUstanove
        {
            [DebuggerNonUserCode]
            get
            {
                return this._daTotaliUstanove;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._daTotaliUstanove = value;
            }
        }

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

        internal dsTotaliUstanove DsTotaliUstanove1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._DsTotaliUstanove1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._DsTotaliUstanove1 = value;
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

        public DataRow SelectedRow
        {
            get
            {
                DataRow row = null;
                return row;
            }
        }

        internal SqlCommand SqlCommand1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._SqlCommand1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._SqlCommand1 = value;
            }
        }

        internal SqlConnection SqlConnection1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._SqlConnection1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._SqlConnection1 = value;
            }
        }

        internal SqlCommand SqlSelectCommand1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._SqlSelectCommand1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._SqlSelectCommand1 = value;
            }
        }

        internal BindingSource Totali1BindingSource
        {
            [DebuggerNonUserCode]
            get
            {
                return this._Totali1BindingSource;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._Totali1BindingSource = value;
            }
        }

        internal BindingSource Totali1BindingSource1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._Totali1BindingSource1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._Totali1BindingSource1 = value;
            }
        }

        private UltraDockManager UltraDockManager1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._UltraDockManager1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._UltraDockManager1 = value;
            }
        }

        private UltraGrid UltraGrid3
        {
            [DebuggerNonUserCode]
            get
            {
                return this._UltraGrid3;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                InitializeLayoutEventHandler handler = new InitializeLayoutEventHandler(this.UltraGrid3_InitializeLayout);
                if (this._UltraGrid3 != null)
                {
                    this._UltraGrid3.InitializeLayout -= handler;
                }
                this._UltraGrid3 = value;
                if (this._UltraGrid3 != null)
                {
                    this._UltraGrid3.InitializeLayout += handler;
                }
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


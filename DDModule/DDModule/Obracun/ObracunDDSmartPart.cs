
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using DDModule;
using DDModule.DDModule;
using DDModule.DDModule.Controllers;
using DDModule.My.Resources;
using Deklarit.Data;
using Deklarit.Practices.CompositeUI;
using Deklarit.Practices.CompositeUI.Workspaces;
using Hlp;
using Infragistics.Win;
using Infragistics.Win.Misc;
using Infragistics.Win.UltraWinDock;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinToolbars;
using Infragistics.Win.UltraWinToolTip;
using Infragistics.Win.UltraWinTree;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.Commands;
using Microsoft.Practices.CompositeUI.SmartParts;
using Microsoft.Practices.ObjectBuilder;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Mipsed7.DataAccessLayer;
using NetAdvantage.WorkItems;
using Placa;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DDModule.Obracun
{

    [SmartPart]
    public class ObracunDDSmartPart : UserControl, ISmartPartInfoProvider, IFilteredView
    {
        private bool __ddisablePromjenuPozicije;
        private fmProgress __frmProgress;
        private BackgroundWorker bw;
        private IContainer components;
        private DDKATEGORIJADataAdapter dakategorija;
        private KORISNIKDataAdapter dakorisnik;
        private DDOBRACUNDataAdapter DAOBRACUN;
        public DateTime datumobracuna;
        private KORISNIKDataSet dsKorisnik;
        private S_DD_KRIZNI_POREZDataSet DSKRIZNI;
        private DataView dvDoprinosiIZ;
        private DataView dvDoprinosiNA;
        private DataView dvIzdaci;
        private DataView dvPorezi;
        public DataView dvVrstePosla;
        private SmartPartInfoProvider infoProvider;
        private bool moguceispravke;
        private bool obracunavakrizni;
        private object onemoguci_posebni;
        private SqlCommand S_OD_REKAP_ISPLATA;
        public string sifraobracuna;
        private SmartPartInfo smartPartInfo1;
        private SqlCommand sRekapDoprinosa;
        public string txtOpisObracunaDD;

        //db - 18.01.2017
        SqlClient client = null;

        public ObracunDDSmartPart()
        {
            base.Load += new EventHandler(this.ObracunSmartPart_Load);
            this.sRekapDoprinosa = new SqlCommand();
            this.S_OD_REKAP_ISPLATA = new SqlCommand();
            this.obracunavakrizni = false;
            this.DSKRIZNI = new S_DD_KRIZNI_POREZDataSet();
            this.onemoguci_posebni = true;
            this.dsKorisnik = new KORISNIKDataSet();
            this.dakorisnik = new KORISNIKDataAdapter();
            this.moguceispravke = true;
            this.dvDoprinosiIZ = new DataView();
            this.dvDoprinosiNA = new DataView();
            this.dvPorezi = new DataView();
            this.dvIzdaci = new DataView();
            this.dvVrstePosla = new DataView();
            this.dakategorija = new DDKATEGORIJADataAdapter();
            this.DAOBRACUN = new DDOBRACUNDataAdapter();
            this.smartPartInfo1 = new SmartPartInfo("Obračun drugog dohotka", "Obračun drugog dohotka");
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);
            this.InitializeComponent();

            client = new SqlClient();
        }

        private void CurrencyManager_PositionChanged(object sender, EventArgs e)
        {
            if (!this.__ddisablePromjenuPozicije && (this.CurrencyManager.Count != 0))
            {
                DataRowView current = (DataRowView) this.CurrencyManager.Current;
                this.dvVrstePosla.RowFilter = "DDIDRADNIK = " + Conversions.ToString(this.AktivnaOsobaDD());
                this.Pokreni_Zbirni_Izracun_DD(false);
            }
        }

        private string Aktivna_Osoba_Prezime_Ime()
        {
            try
            {
                if (this.CurrencyManager.Count > 0)
                {
                    return (DB.N2T(RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(this.CurrencyManager.Current, new object[] { "ddPREZIME" }, null)), "") + " " + DB.N2T(RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(this.CurrencyManager.Current, new object[] { "ddIME" }, null)), ""));
                }
            }
            catch (System.Exception exception1)
            {
                throw exception1;
            }
            return "";
        }

        private int AktivnaOsobaDD()
        {
            try
            {
                if (this.CurrencyManager.Count > 0)
                {
                    return Conversions.ToInteger(NewLateBinding.LateIndexGet(this.CurrencyManager.Current, new object[] { "ddIDRADNIK" }, null));
                }
            }
            catch (System.Exception exception1)
            {
                throw exception1;
            }
            return 0;
        }

        private void Brisanje_Oznacenih_Osoba_Iz_obracuna()
        {
            if (this.MoguceMijenjatiObracun())
            {
                if (this.Broj_Oznacenih_Osoba() == 0)
                {
                    MessageBox.Show("Nema označenih osoba!", "Drugi dohodak", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    if (this.Broj_Oznacenih_Osoba() == this.UltraGrid1.Rows.Count)
                    {
                        if (MessageBox.Show("Želite li da uklonim sve osobe iz obračuna?", "Drugi dohodak", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        {
                            return;
                        }
                    }
                    else if (MessageBox.Show("Želite li da uklonim sve osobe iz obračuna?", "Drugi dohodak", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        return;
                    }
                    this.Cursor = Cursors.WaitCursor;
                    this.__ddisablePromjenuPozicije = true;
                    for (int i = this.UltraGrid1.Rows.Count - 1; i >= 0; i += -1)
                    {
                        if (Conversions.ToBoolean(this.UltraGrid1.Rows[i].Cells["oznacen"].Value))
                        {
                            this.UltraGrid1.ActiveRow = this.UltraGrid1.Rows[i];
                            ((DataRowView) this.BindingContext[this.DdobracunDataSet1, "ddOBRACUNRADNICI"].Current).Delete();
                        }
                    }
                    try
                    {
                        this.DAOBRACUN.Update(this.DdobracunDataSet1);
                    }
                    catch (System.Exception exception1)
                    {
                        throw exception1;
                    }

                    if (this.DdobracunDataSet1.DDOBRACUNRadnici.Rows.Count == 0)
                    {
                        ((DataRowView)this.BindingContext[this.DdobracunDataSet1, "ddOBRACUN"].Current).Delete();
                        this.BindingContext[this.DdobracunDataSet1, "ddOBRACUN"].EndCurrentEdit();
                        try
                        {
                            this.DAOBRACUN.Update(this.DdobracunDataSet1);
                        }
                        catch (System.Exception exception3)
                        {
                            throw exception3;
                        }
                        this.ZapocniPonovo();

                        this.ListBox1.Items.Clear();
                        this.ListBox1.Items.Add("TRENUTNO NEMA OTVORENOG OBRAČUNA");
                        this.sifraobracuna = "";
                        this.ultraSifraObracuna.Text = "";
                        this.ultraSifraObracuna.Value = null;
                        this.__ddisablePromjenuPozicije = false;
                        this.CurrencyManager_PositionChanged(null, null);
                    }

                    this.Cursor = Cursors.Default;
                    this.BrojOsobaUObracunu();
                }
            }
        }

        private void BrisanjeVrstePosla()
        {
            if (this.MoguceMijenjatiObracun())
            {
                CurrencyManager manager = (CurrencyManager) this.BindingContext[this.DsRekapitulacija1, "dtRekap"];
                if (manager.Count != 0)
                {
                    DataRowView current = (DataRowView) manager.Current;
                    if (Versioned.IsNumeric(RuntimeHelpers.GetObjectValue(current["sifraelementa"])))
                    {
                        this.dvVrstePosla.Sort = "ddidvrstaposla";
                        this.dvVrstePosla.RowFilter = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("ddidvrstaposla = ", current["sifraelementa"]), " AND ddIDRADNIK = "), this.AktivnaOsobaDD()));
                        ((DataRowView) this.BindingContext[this.dvVrstePosla].Current).Delete();
                        this.Pokreni_Zbirni_Izracun_DD(true);
                    }
                }
            }
        }

        private int Broj_Oznacenih_Osoba()
        {
            int num2 = 0;
            int num4 = this.UltraGrid1.Rows.Count - 1;
            for (int i = 0; i <= num4; i++)
            {
                if (Conversions.ToBoolean(this.UltraGrid1.Rows[i].Cells["oznacen"].Value))
                {
                    num2++;
                }
            }
            return num2;
        }

        public void BrojOsobaUObracunu()
        {
        }

        public void DefaultParametriObracunaDrugogDohotka()
        {
            SqlConnection connection = new SqlConnection();
            SqlCommand command = new SqlCommand();
            connection.ConnectionString = Configuration.ConnectionString;
            command.Connection = connection;
            command.CommandText = "select max(DDOBRACUNidobracun) from DDobracun WHERE  DDOBRACUNIDOBRACUN like '" + Conversions.ToString(DateAndTime.Year(this.datumobracuna)) + "-" + string.Format("{0:00}", DateAndTime.Month(this.datumobracuna)) + "-%'";
            connection.Open();
            try
            {
                int num = 0;
                string str = DB.N2T(RuntimeHelpers.GetObjectValue(command.ExecuteScalar()), "").ToString().TrimEnd(new char[0]);
                if (str == "")
                {
                    num = 1;
                }
                else
                {
                    num = int.Parse(str.Remove(0, 8)) + 1;
                }
                this.sifraobracuna = Conversions.ToString(DateAndTime.Year(this.datumobracuna)) + "-" + string.Format("{0:00}", DateAndTime.Month(this.datumobracuna)) + "-" + string.Format("{0:000}", num);
                this.ultraSifraObracuna.Text = Conversions.ToString(DateAndTime.Year(this.datumobracuna)) + "-" + string.Format("{0:00}", DateAndTime.Month(this.datumobracuna)) + "-" + string.Format("{0:000}", num);
            }
            catch (System.Exception exception1)
            {
                throw exception1;
                
                
                
            }
            connection.Close();
        }

        [LocalCommandHandler("DodajRadnike")]
        public void DodajRadnikeHandler(object sender, EventArgs e)
        {
            this.Parametri_DodajOznaceneRadnike();
            this.BrojOsobaUObracunu();
        }

        private object Dohvati_Podatke_O_Zadnjem_ObracunuDD(string sIDObracun)
        {
            string str = string.Empty;
            SqlCommand command = new SqlCommand();
            SqlConnection connection = new SqlConnection {
                ConnectionString = Configuration.ConnectionString
            };
            command.CommandText = "SELECT ISNULL(MAX(ddOBRACUN.ddOBRACUNIDOBRACUN), @idobracun) FROM DDOBRACUN  WHERE (ddOBRACUN.DDOBRACUNIDOBRACUN = @idobracun)";
            command.CommandType = CommandType.Text;
            command.Connection = connection;
            command.Parameters.Add("@idobracun", SqlDbType.VarChar).Value = sIDObracun;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                str = reader.GetString(0);
            }
            else
            {
                str = "";
            }
            reader.Close();
            connection.Close();
            return str;
        }

        private void DoneChildFormInit(object sender, RunWorkerCompletedEventArgs e)
        {
            this.bw.Dispose();
            this.__frmProgress.Close();
            this.DAOBRACUN.Update(this.DdobracunDataSet1);
            DataRowView current = (DataRowView) this.BindingContext[this.DdobracunDataSet1.DDOBRACUNRadnici].Current;
            current = (DataRowView) this.CurrencyManager.Current;
            this.PlatnaListaDD_Na_Ekran(current, true);
        }

        private void Drugi_Dohodak_Izracunaj_Za_Sve()
        {
            this.bw = new BackgroundWorker();
            this.bw.DoWork += new DoWorkEventHandler(this.InitChildFormData);
            this.bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.DoneChildFormInit);
            this.bw.ProgressChanged += new ProgressChangedEventHandler(this.PerformingActions);
            this.bw.WorkerReportsProgress = true;
            this.bw.WorkerSupportsCancellation = false;
            this.__frmProgress = new fmProgress();
            this.bw.RunWorkerAsync();
            this.__frmProgress.ShowDialog();
        }

        public ISmartPartInfo GetSmartPartInfo(Type smartPartInfoType)
        {
            return this.infoProvider.GetSmartPartInfo(smartPartInfoType);
        }

        private void InitChildFormData(object sender, DoWorkEventArgs e)
        {
            int num = 0;
            this.__ddisablePromjenuPozicije = true;
            if (this.moguceispravke)
            {
                int count = this.BindingContext[this.DdobracunDataSet1.DDOBRACUNRadnici].Count;
                int num4 = this.BindingContext[this.DdobracunDataSet1.DDOBRACUNRadnici].Count - 1;
                num = 0;
                while (num <= num4)
                {
                    this.BindingContext[this.DdobracunDataSet1.DDOBRACUNRadnici].Position = num;
                    DataRowView current = (DataRowView) this.BindingContext[this.DdobracunDataSet1.DDOBRACUNRadnici].Current;
                    this.Izracun_Drugog_Dohotka(this.DdobracunDataSet1, current);
                    decimal num3 = new decimal((((double) num) / ((double) count)) * 100.0);
                    this.bw.ReportProgress(Convert.ToInt32(num3));
                    num++;
                }
            }
            this.__ddisablePromjenuPozicije = false;
            e.Result = num;
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("DDOBRACUNRadnici", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DDOBRACUNIDOBRACUN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DDIDRADNIK");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DDPREZIME");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DDIME");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDKATEGORIJA", -1, "UltraDropDown1", 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, false);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVKATEGORIJA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DDOBRACUNATIPRIREZ");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DDOBRACUNATIPDV");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OPCINARADAIDOPCINE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn10 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OPCINARADANAZIVOPCINE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn11 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OPCINASTANOVANJAIDOPCINE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn12 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OPCINASTANOVANJANAZIVOPCINE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn13 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OPCINASTANOVANJAPRIREZ");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn14 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OPCINASTANOVANJAVBDIOPCINA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn15 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OPCINASTANOVANJAZRNOPCINA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn16 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDBANKE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn17 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVBANKE1");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn18 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVBANKE2");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn19 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVBANKE3");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn20 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("VBDIBANKE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn21 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ZRNBANKE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn22 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DDPDVOBVEZNIK");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn23 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DDDRUGISTUP");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn24 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DDSIFRAOPCINESTANOVANJA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn25 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDKOLONAIDD");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn26 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DDOIB");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn27 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DDZRN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn28 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DDOBRACUNRadnici_DDOBRACUNRadniciDDKrizniPorez");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn29 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DDOBRACUNRadnici_DDOBRACUNRadniciPorezi");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn30 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DDOBRACUNRadnici_DDOBRACUNRadniciDoprinosi");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn31 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DDOBRACUNRadnici_DDOBRACUNRadniciIzdaci");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn32 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DDOBRACUNRadnici_DDOBRACUNRadniciVrstePosla");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn33 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("oznacen", 0);
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand2 = new Infragistics.Win.UltraWinGrid.UltraGridBand("DDOBRACUNRadnici_DDOBRACUNRadniciDDKrizniPorez", 0);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn34 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DDOBRACUNIDOBRACUN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn35 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DDIDRADNIK");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn36 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDKRIZNIPOREZ");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn37 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVKRIZNIPOREZ");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn38 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("KRIZNISTOPA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn39 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MOKRIZNI");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn40 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("POKRIZNI");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn41 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MZKRIZNI");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn42 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PZKRIZNI");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn43 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PRIMATELJKRIZNI1");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn44 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PRIMATELJKRIZNI2");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn45 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PRIMATELJKRIZNI3");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn46 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("SIFRAOPISAPLACANJAKRIZNI");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn47 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OPISPLACANJAKRIZNI");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn48 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("VBDIKRIZNI");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn49 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ZRNKRIZNI");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn50 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DDOSNOVICAKRIZNI");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn51 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DDPOREZKRIZNI");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn52 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DDOSNOVICAPRETHODNA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn53 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DDOSNOVICAUKUPNA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn54 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DDPOREZPRETHODNI");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn55 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DDPOREZUKUPNO");
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand3 = new Infragistics.Win.UltraWinGrid.UltraGridBand("DDOBRACUNRadnici_DDOBRACUNRadniciPorezi", 0);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn56 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DDOBRACUNIDOBRACUN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn57 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DDIDRADNIK");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn58 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDPOREZ");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn59 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVPOREZ");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn60 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("POREZMJESECNO");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn61 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("STOPAPOREZA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn62 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DDPOPOREZ");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn63 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DDMOPOREZ");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn64 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MZPOREZ");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn65 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PZPOREZ");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn66 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PRIMATELJPOREZ1");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn67 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PRIMATELJPOREZ2");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn68 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("SIFRAOPISAPLACANJAPOREZ");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn69 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OPISPLACANJAPOREZ");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn70 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DDOBRACUNATIPOREZ");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn71 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DDOSNOVICAPOREZ");
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand4 = new Infragistics.Win.UltraWinGrid.UltraGridBand("DDOBRACUNRadnici_DDOBRACUNRadniciDoprinosi", 0);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn72 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DDOBRACUNIDOBRACUN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn73 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DDIDRADNIK");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn74 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDDOPRINOS");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn75 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVDOPRINOS");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn76 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDVRSTADOPRINOS");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn77 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVVRSTADOPRINOS");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn78 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MODOPRINOS");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn79 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PODOPRINOS");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn80 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MZDOPRINOS");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn81 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PZDOPRINOS");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn82 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PRIMATELJDOPRINOS1");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn83 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PRIMATELJDOPRINOS2");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn84 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("SIFRAOPISAPLACANJADOPRINOS");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn85 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OPISPLACANJADOPRINOS");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn86 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("VBDIDOPRINOS");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn87 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ZRNDOPRINOS");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn88 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("STOPA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn89 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DDOBRACUNATIDOPRINOS");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn90 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DDOSNOVICADOPRINOS");
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand5 = new Infragistics.Win.UltraWinGrid.UltraGridBand("DDOBRACUNRadnici_DDOBRACUNRadniciIzdaci", 0);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn91 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DDOBRACUNIDOBRACUN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn92 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DDIDRADNIK");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn93 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DDIDIZDATAK");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn94 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DDNAZIVIZDATKA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn95 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DDPOSTOTAKIZDATKA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn96 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DDOBRACUNATIIZDATAK");
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand6 = new Infragistics.Win.UltraWinGrid.UltraGridBand("DDOBRACUNRadnici_DDOBRACUNRadniciVrstePosla", 0);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn97 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DDOBRACUNIDOBRACUN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn98 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DDIDRADNIK");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn99 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DDIDVRSTAPOSLA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn100 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DDNAZIVVRSTAPOSLA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn101 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DDSATI");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn102 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DDSATNICA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn103 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DDIZNOS");
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo2 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Desni klik miša za označavanje osobe", Infragistics.Win.ToolTipImage.Default, "", Infragistics.Win.DefaultableBoolean.True);
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand8 = new Infragistics.Win.UltraWinGrid.UltraGridBand("DDKATEGORIJA", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn111 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDKATEGORIJA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn112 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVKATEGORIJA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn113 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDKOLONAIDD");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn114 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVKOLONAIDD");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn115 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DDKATEGORIJA_DDKATEGORIJAIzdaci");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn116 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DDKATEGORIJA_DDKATEGORIJALevel3");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn117 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DDKATEGORIJA_DDKATEGORIJALevel1");
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand9 = new Infragistics.Win.UltraWinGrid.UltraGridBand("DDKATEGORIJA_DDKATEGORIJAIzdaci", 0);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn118 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDKATEGORIJA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn119 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DDIDIZDATAK");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn120 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DDNAZIVIZDATKA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn121 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DDPOSTOTAKIZDATKA");
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand10 = new Infragistics.Win.UltraWinGrid.UltraGridBand("DDKATEGORIJA_DDKATEGORIJALevel3", 0);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn122 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDKATEGORIJA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn123 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDDOPRINOS");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn124 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVDOPRINOS");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn125 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDVRSTADOPRINOS");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn126 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVVRSTADOPRINOS");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn127 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MODOPRINOS");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn128 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PODOPRINOS");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn129 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MZDOPRINOS");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn130 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PZDOPRINOS");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn131 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PRIMATELJDOPRINOS1");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn132 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PRIMATELJDOPRINOS2");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn133 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("SIFRAOPISAPLACANJADOPRINOS");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn134 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OPISPLACANJADOPRINOS");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn135 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("VBDIDOPRINOS");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn136 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ZRNDOPRINOS");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn137 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("STOPA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn138 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DOPRINOSDRUGOGSTUPA");
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand11 = new Infragistics.Win.UltraWinGrid.UltraGridBand("DDKATEGORIJA_DDKATEGORIJALevel1", 0);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn139 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDKATEGORIJA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn140 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDPOREZ");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn141 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVPOREZ");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn142 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("POREZMJESECNO");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn143 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("STOPAPOREZA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn144 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DDMOPOREZ");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn145 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DDPOPOREZ");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn146 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MZPOREZ");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn147 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PZPOREZ");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn148 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PRIMATELJPOREZ1");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn149 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PRIMATELJPOREZ2");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn150 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("SIFRAOPISAPLACANJAPOREZ");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn151 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OPISPLACANJAPOREZ");
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand7 = new Infragistics.Win.UltraWinGrid.UltraGridBand("dtRekap", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn104 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Opis");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn105 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Iznos");
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn106 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("SIFRAELEMENTA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn107 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("vrstaelementa");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn108 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("BROJSATI");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn109 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("od");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn110 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("do");
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Platna lista odabranog djelatnika", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar1 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("UltraToolbar1");
            Infragistics.Win.UltraWinToolbars.ButtonTool tool = new Infragistics.Win.UltraWinToolbars.ButtonTool("Oznaci");
            Infragistics.Win.UltraWinToolbars.ButtonTool tool6 = new Infragistics.Win.UltraWinToolbars.ButtonTool("UkloniOznake");
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar2 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("BrutoElementi");
            Infragistics.Win.UltraWinToolbars.ButtonTool tool9 = new Infragistics.Win.UltraWinToolbars.ButtonTool("DodajBruto");
            Infragistics.Win.UltraWinToolbars.ButtonTool tool10 = new Infragistics.Win.UltraWinToolbars.ButtonTool("IzmjeniBruto");
            Infragistics.Win.UltraWinToolbars.ButtonTool tool11 = new Infragistics.Win.UltraWinToolbars.ButtonTool("BrisiBruto");
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.TaskPaneTool tool20 = new Infragistics.Win.UltraWinToolbars.TaskPaneTool("TaskPaneTool1");
            Infragistics.Win.UltraWinToolbars.ButtonTool tool7 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Oznaci");
            Infragistics.Win.UltraWinToolbars.ButtonTool tool8 = new Infragistics.Win.UltraWinToolbars.ButtonTool("UkloniOznake");
            Infragistics.Win.UltraWinToolbars.ButtonTool tool12 = new Infragistics.Win.UltraWinToolbars.ButtonTool("DodajBruto");
            Infragistics.Win.UltraWinToolbars.ButtonTool tool13 = new Infragistics.Win.UltraWinToolbars.ButtonTool("IzmjeniBruto");
            Infragistics.Win.UltraWinToolbars.ButtonTool tool2 = new Infragistics.Win.UltraWinToolbars.ButtonTool("BrisiBruto");
            Infragistics.Win.UltraWinToolbars.ButtonTool tool3 = new Infragistics.Win.UltraWinToolbars.ButtonTool("DodajNeto");
            Infragistics.Win.UltraWinToolbars.ButtonTool tool4 = new Infragistics.Win.UltraWinToolbars.ButtonTool("IzmjeniNeto");
            Infragistics.Win.UltraWinToolbars.ButtonTool tool5 = new Infragistics.Win.UltraWinToolbars.ButtonTool("BrisiNeto");
            Infragistics.Win.UltraWinToolbars.ControlContainerTool tool17 = new Infragistics.Win.UltraWinToolbars.ControlContainerTool("ControlContainerTool1");
            Infragistics.Win.UltraWinToolbars.ControlContainerTool tool18 = new Infragistics.Win.UltraWinToolbars.ControlContainerTool("ControlContainerTool2");
            Infragistics.Win.UltraWinToolbars.ControlContainerTool tool19 = new Infragistics.Win.UltraWinToolbars.ControlContainerTool("ControlContainerTool3");
            Infragistics.Win.UltraWinToolbars.ControlContainerTool tool14 = new Infragistics.Win.UltraWinToolbars.ControlContainerTool("ControlContainerTool4");
            Infragistics.Win.UltraWinToolbars.ControlContainerTool tool15 = new Infragistics.Win.UltraWinToolbars.ControlContainerTool("ControlContainerTool5");
            Infragistics.Win.UltraWinToolbars.ControlContainerTool tool16 = new Infragistics.Win.UltraWinToolbars.ControlContainerTool("ControlContainerTool6");
            Infragistics.Win.UltraWinDock.DockAreaPane dockAreaPane1 = new Infragistics.Win.UltraWinDock.DockAreaPane(Infragistics.Win.UltraWinDock.DockedLocation.DockedLeft, new System.Guid("9326f8c6-d5e3-4578-b49e-c5117fa16df8"));
            Infragistics.Win.UltraWinDock.DockableControlPane dockableControlPane1 = new Infragistics.Win.UltraWinDock.DockableControlPane(new System.Guid("fec2e4c4-2fbb-486e-a163-e66d8a1db2c8"), new System.Guid("00000000-0000-0000-0000-000000000000"), -1, new System.Guid("9326f8c6-d5e3-4578-b49e-c5117fa16df8"), -1);
            Infragistics.Win.UltraWinDock.DockAreaPane dockAreaPane2 = new Infragistics.Win.UltraWinDock.DockAreaPane(Infragistics.Win.UltraWinDock.DockedLocation.DockedLeft, new System.Guid("f0de9771-b75d-4dbe-a368-c52e13b18f9a"));
            Infragistics.Win.UltraWinDock.DockableControlPane dockableControlPane2 = new Infragistics.Win.UltraWinDock.DockableControlPane(new System.Guid("b7f4ed86-767b-48df-873b-650943329d5f"), new System.Guid("00000000-0000-0000-0000-000000000000"), -1, new System.Guid("f0de9771-b75d-4dbe-a368-c52e13b18f9a"), -1);
            this.Panel1 = new System.Windows.Forms.Panel();
            this.ultraSifraObracuna = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ListBox1 = new System.Windows.Forms.ListBox();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.UltraGrid1 = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.DdobracunDataSet1 = new Placa.DDOBRACUNDataSet();
            this.UltraDropDown1 = new Infragistics.Win.UltraWinGrid.UltraDropDown();
            this.DdkategorijaDataSet1 = new Placa.DDKATEGORIJADataSet();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.UltraGrid2 = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.DsRekapitulacija1 = new datasetRekapitulacijaEkran();
            this._Panel2_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.UltraToolbarsManager1 = new Infragistics.Win.UltraWinToolbars.UltraToolbarsManager(this.components);
            this._Panel2_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.UltraToolbarsDockArea3 = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.UltraToolbarsDockArea4 = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._Panel2_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._Panel2_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.UltraToolbarsDockArea2 = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.BackgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.UltraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.UltraDesktopAlert1 = new Infragistics.Win.Misc.UltraDesktopAlert(this.components);
            this.UltraDockManager1 = new Infragistics.Win.UltraWinDock.UltraDockManager(this.components);
            this._ObracunDDSmartPartUnpinnedTabAreaLeft = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._ObracunDDSmartPartUnpinnedTabAreaRight = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._ObracunDDSmartPartUnpinnedTabAreaTop = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._ObracunDDSmartPartUnpinnedTabAreaBottom = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._ObracunDDSmartPartAutoHideControl = new Infragistics.Win.UltraWinDock.AutoHideControl();
            this.WindowDockingArea1 = new Infragistics.Win.UltraWinDock.WindowDockingArea();
            this.DockableWindow1 = new Infragistics.Win.UltraWinDock.DockableWindow();
            this.WindowDockingArea2 = new Infragistics.Win.UltraWinDock.WindowDockingArea();
            this.DockableWindow2 = new Infragistics.Win.UltraWinDock.DockableWindow();
            this.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraSifraObracuna)).BeginInit();
            this.GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UltraGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DdobracunDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltraDropDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DdkategorijaDataSet1)).BeginInit();
            this.Panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UltraGrid2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DsRekapitulacija1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltraToolbarsManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltraDesktopAlert1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltraDockManager1)).BeginInit();
            this.WindowDockingArea1.SuspendLayout();
            this.DockableWindow1.SuspendLayout();
            this.WindowDockingArea2.SuspendLayout();
            this.DockableWindow2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.Panel1.Controls.Add(this.ultraSifraObracuna);
            this.Panel1.Controls.Add(this.ListBox1);
            this.Panel1.Controls.Add(this.GroupBox1);
            this.Panel1.ForeColor = System.Drawing.Color.Transparent;
            this.Panel1.Location = new System.Drawing.Point(0, 18);
            this.Panel1.Margin = new System.Windows.Forms.Padding(0);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(610, 914);
            this.Panel1.TabIndex = 71;
            // 
            // ultraSifraObracuna
            // 
            this.ultraSifraObracuna.Location = new System.Drawing.Point(482, 3);
            this.ultraSifraObracuna.Name = "ultraSifraObracuna";
            this.ultraSifraObracuna.Size = new System.Drawing.Size(125, 21);
            this.ultraSifraObracuna.TabIndex = 71;
            this.ultraSifraObracuna.Text = "ultraSifraObracuna";
            this.ultraSifraObracuna.Visible = false;
            // 
            // ListBox1
            // 
            this.ListBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(191)))));
            this.ListBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ListBox1.FormattingEnabled = true;
            this.ListBox1.Location = new System.Drawing.Point(3, 2);
            this.ListBox1.Name = "ListBox1";
            this.ListBox1.Size = new System.Drawing.Size(606, 82);
            this.ListBox1.TabIndex = 59;
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.UltraGrid1);
            this.GroupBox1.Controls.Add(this.UltraDropDown1);
            this.GroupBox1.Location = new System.Drawing.Point(0, 87);
            this.GroupBox1.Margin = new System.Windows.Forms.Padding(0);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(620, 824);
            this.GroupBox1.TabIndex = 58;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Osobe u obračunu";
            // 
            // UltraGrid1
            // 
            this.UltraGrid1.DataMember = "DDOBRACUNRadnici";
            this.UltraGrid1.DataSource = this.DdobracunDataSet1;
            this.UltraGrid1.MouseDown += new MouseEventHandler(UltraGrid1_MouseDown);
            appearance8.BackColor = System.Drawing.Color.AliceBlue;
            this.UltraGrid1.DisplayLayout.Appearance = appearance8;
            ultraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn1.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn1.Hidden = true;
            ultraGridColumn2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn2.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridColumn2.Width = 53;
            ultraGridColumn3.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn3.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn3.Header.VisiblePosition = 3;
            ultraGridColumn4.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn4.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn4.Header.VisiblePosition = 4;
            ultraGridColumn5.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn5.Header.Caption = "Kategorija ";
            ultraGridColumn5.Header.VisiblePosition = 5;
            ultraGridColumn5.Width = 136;
            ultraGridColumn6.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn6.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn6.Header.VisiblePosition = 6;
            ultraGridColumn6.Hidden = true;
            ultraGridColumn7.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn7.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn7.Header.VisiblePosition = 7;
            ultraGridColumn7.Hidden = true;
            ultraGridColumn8.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn8.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn8.Header.VisiblePosition = 9;
            ultraGridColumn8.Hidden = true;
            ultraGridColumn9.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn9.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn9.Header.VisiblePosition = 10;
            ultraGridColumn9.Hidden = true;
            ultraGridColumn10.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn10.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn10.Header.VisiblePosition = 11;
            ultraGridColumn10.Hidden = true;
            ultraGridColumn11.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn11.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn11.Header.VisiblePosition = 12;
            ultraGridColumn11.Hidden = true;
            ultraGridColumn12.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn12.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn12.Header.VisiblePosition = 14;
            ultraGridColumn12.Hidden = true;
            ultraGridColumn13.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn13.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn13.Header.VisiblePosition = 16;
            ultraGridColumn13.Hidden = true;
            ultraGridColumn14.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn14.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn14.Header.VisiblePosition = 18;
            ultraGridColumn14.Hidden = true;
            ultraGridColumn15.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn15.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn15.Header.VisiblePosition = 19;
            ultraGridColumn15.Hidden = true;
            ultraGridColumn16.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn16.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn16.Header.VisiblePosition = 20;
            ultraGridColumn16.Hidden = true;
            ultraGridColumn17.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn17.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn17.Header.VisiblePosition = 21;
            ultraGridColumn17.Hidden = true;
            ultraGridColumn18.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn18.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn18.Header.VisiblePosition = 22;
            ultraGridColumn18.Hidden = true;
            ultraGridColumn19.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn19.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn19.Header.VisiblePosition = 23;
            ultraGridColumn19.Hidden = true;
            ultraGridColumn20.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn20.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn20.Header.VisiblePosition = 24;
            ultraGridColumn20.Hidden = true;
            ultraGridColumn21.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn21.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn21.Header.VisiblePosition = 29;
            ultraGridColumn21.Hidden = true;
            ultraGridColumn22.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn22.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn22.Header.VisiblePosition = 31;
            ultraGridColumn22.Hidden = true;
            ultraGridColumn23.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn23.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn23.Header.VisiblePosition = 32;
            ultraGridColumn23.Hidden = true;
            ultraGridColumn24.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn24.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn24.Header.VisiblePosition = 27;
            ultraGridColumn24.Hidden = true;
            ultraGridColumn25.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn25.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn25.Header.VisiblePosition = 25;
            ultraGridColumn25.Hidden = true;
            ultraGridColumn26.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn26.Header.VisiblePosition = 26;
            ultraGridColumn27.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn27.Header.VisiblePosition = 28;
            ultraGridColumn28.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn28.Header.VisiblePosition = 30;
            ultraGridColumn29.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn29.Header.VisiblePosition = 8;
            ultraGridColumn30.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn30.Header.VisiblePosition = 13;
            ultraGridColumn31.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn31.Header.VisiblePosition = 15;
            ultraGridColumn32.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn32.Header.VisiblePosition = 17;
            ultraGridColumn33.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn33.DataType = typeof(bool);
            ultraGridColumn33.DefaultCellValue = false;
            ultraGridColumn33.Header.Caption = "Označen";
            ultraGridColumn33.Header.VisiblePosition = 2;
            ultraGridColumn33.Width = 53;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4,
            ultraGridColumn5,
            ultraGridColumn6,
            ultraGridColumn7,
            ultraGridColumn8,
            ultraGridColumn9,
            ultraGridColumn10,
            ultraGridColumn11,
            ultraGridColumn12,
            ultraGridColumn13,
            ultraGridColumn14,
            ultraGridColumn15,
            ultraGridColumn16,
            ultraGridColumn17,
            ultraGridColumn18,
            ultraGridColumn19,
            ultraGridColumn20,
            ultraGridColumn21,
            ultraGridColumn22,
            ultraGridColumn23,
            ultraGridColumn24,
            ultraGridColumn25,
            ultraGridColumn26,
            ultraGridColumn27,
            ultraGridColumn28,
            ultraGridColumn29,
            ultraGridColumn30,
            ultraGridColumn31,
            ultraGridColumn32,
            ultraGridColumn33});
            ultraGridBand1.GroupHeaderLines = 2;
            ultraGridBand1.Header.Caption = "";
            ultraGridBand1.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            ultraGridBand1.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True;
            ultraGridBand1.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.Edit;
            appearance16.BackColor = System.Drawing.Color.White;
            ultraGridBand1.Override.HeaderAppearance = appearance16;
            ultraGridBand1.Override.HeaderPlacement = Infragistics.Win.UltraWinGrid.HeaderPlacement.FixedOnTop;
            ultraGridColumn34.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn34.Header.VisiblePosition = 0;
            ultraGridColumn35.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn35.Header.VisiblePosition = 1;
            ultraGridColumn36.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn36.Header.VisiblePosition = 2;
            ultraGridColumn37.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn37.Header.VisiblePosition = 3;
            ultraGridColumn38.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn38.Header.VisiblePosition = 4;
            ultraGridColumn39.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn39.Header.VisiblePosition = 5;
            ultraGridColumn40.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn40.Header.VisiblePosition = 6;
            ultraGridColumn41.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn41.Header.VisiblePosition = 7;
            ultraGridColumn42.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn42.Header.VisiblePosition = 8;
            ultraGridColumn43.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn43.Header.VisiblePosition = 9;
            ultraGridColumn44.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn44.Header.VisiblePosition = 10;
            ultraGridColumn45.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn45.Header.VisiblePosition = 11;
            ultraGridColumn46.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn46.Header.VisiblePosition = 12;
            ultraGridColumn47.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn47.Header.VisiblePosition = 13;
            ultraGridColumn48.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn48.Header.VisiblePosition = 14;
            ultraGridColumn49.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn49.Header.VisiblePosition = 15;
            ultraGridColumn50.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn50.Header.VisiblePosition = 16;
            ultraGridColumn51.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn51.Header.VisiblePosition = 17;
            ultraGridColumn52.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn52.Header.VisiblePosition = 18;
            ultraGridColumn53.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn53.Header.VisiblePosition = 19;
            ultraGridColumn54.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn54.Header.VisiblePosition = 20;
            ultraGridColumn55.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn55.Header.VisiblePosition = 21;
            ultraGridBand2.Columns.AddRange(new object[] {
            ultraGridColumn34,
            ultraGridColumn35,
            ultraGridColumn36,
            ultraGridColumn37,
            ultraGridColumn38,
            ultraGridColumn39,
            ultraGridColumn40,
            ultraGridColumn41,
            ultraGridColumn42,
            ultraGridColumn43,
            ultraGridColumn44,
            ultraGridColumn45,
            ultraGridColumn46,
            ultraGridColumn47,
            ultraGridColumn48,
            ultraGridColumn49,
            ultraGridColumn50,
            ultraGridColumn51,
            ultraGridColumn52,
            ultraGridColumn53,
            ultraGridColumn54,
            ultraGridColumn55});
            ultraGridColumn56.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn56.Header.VisiblePosition = 0;
            ultraGridColumn57.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn57.Header.VisiblePosition = 1;
            ultraGridColumn58.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn58.Header.VisiblePosition = 2;
            ultraGridColumn59.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn59.Header.VisiblePosition = 3;
            ultraGridColumn60.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn60.Header.VisiblePosition = 4;
            ultraGridColumn61.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn61.Header.VisiblePosition = 5;
            ultraGridColumn62.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn62.Header.VisiblePosition = 6;
            ultraGridColumn63.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn63.Header.VisiblePosition = 7;
            ultraGridColumn64.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn64.Header.VisiblePosition = 8;
            ultraGridColumn65.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn65.Header.VisiblePosition = 9;
            ultraGridColumn66.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn66.Header.VisiblePosition = 10;
            ultraGridColumn67.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn67.Header.VisiblePosition = 11;
            ultraGridColumn68.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn68.Header.VisiblePosition = 12;
            ultraGridColumn69.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn69.Header.VisiblePosition = 13;
            ultraGridColumn70.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn70.Header.VisiblePosition = 14;
            ultraGridColumn71.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn71.Header.VisiblePosition = 15;
            ultraGridBand3.Columns.AddRange(new object[] {
            ultraGridColumn56,
            ultraGridColumn57,
            ultraGridColumn58,
            ultraGridColumn59,
            ultraGridColumn60,
            ultraGridColumn61,
            ultraGridColumn62,
            ultraGridColumn63,
            ultraGridColumn64,
            ultraGridColumn65,
            ultraGridColumn66,
            ultraGridColumn67,
            ultraGridColumn68,
            ultraGridColumn69,
            ultraGridColumn70,
            ultraGridColumn71});
            ultraGridColumn72.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn72.Header.VisiblePosition = 0;
            ultraGridColumn73.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn73.Header.VisiblePosition = 1;
            ultraGridColumn74.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn74.Header.VisiblePosition = 2;
            ultraGridColumn75.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn75.Header.VisiblePosition = 3;
            ultraGridColumn76.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn76.Header.VisiblePosition = 4;
            ultraGridColumn77.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn77.Header.VisiblePosition = 5;
            ultraGridColumn78.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn78.Header.VisiblePosition = 6;
            ultraGridColumn79.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn79.Header.VisiblePosition = 7;
            ultraGridColumn80.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn80.Header.VisiblePosition = 8;
            ultraGridColumn81.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn81.Header.VisiblePosition = 9;
            ultraGridColumn82.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn82.Header.VisiblePosition = 10;
            ultraGridColumn83.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn83.Header.VisiblePosition = 11;
            ultraGridColumn84.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn84.Header.VisiblePosition = 12;
            ultraGridColumn85.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn85.Header.VisiblePosition = 13;
            ultraGridColumn86.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn86.Header.VisiblePosition = 14;
            ultraGridColumn87.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn87.Header.VisiblePosition = 15;
            ultraGridColumn88.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn88.Header.VisiblePosition = 16;
            ultraGridColumn89.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn89.Header.VisiblePosition = 17;
            ultraGridColumn90.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn90.Header.VisiblePosition = 18;
            ultraGridBand4.Columns.AddRange(new object[] {
            ultraGridColumn72,
            ultraGridColumn73,
            ultraGridColumn74,
            ultraGridColumn75,
            ultraGridColumn76,
            ultraGridColumn77,
            ultraGridColumn78,
            ultraGridColumn79,
            ultraGridColumn80,
            ultraGridColumn81,
            ultraGridColumn82,
            ultraGridColumn83,
            ultraGridColumn84,
            ultraGridColumn85,
            ultraGridColumn86,
            ultraGridColumn87,
            ultraGridColumn88,
            ultraGridColumn89,
            ultraGridColumn90});
            ultraGridColumn91.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn91.Header.VisiblePosition = 0;
            ultraGridColumn92.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn92.Header.VisiblePosition = 1;
            ultraGridColumn93.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn93.Header.VisiblePosition = 2;
            ultraGridColumn94.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn94.Header.VisiblePosition = 3;
            ultraGridColumn95.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn95.Header.VisiblePosition = 4;
            ultraGridColumn96.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn96.Header.VisiblePosition = 5;
            ultraGridBand5.Columns.AddRange(new object[] {
            ultraGridColumn91,
            ultraGridColumn92,
            ultraGridColumn93,
            ultraGridColumn94,
            ultraGridColumn95,
            ultraGridColumn96});
            ultraGridColumn97.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn97.Header.VisiblePosition = 0;
            ultraGridColumn98.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn98.Header.VisiblePosition = 1;
            ultraGridColumn99.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn99.Header.VisiblePosition = 2;
            ultraGridColumn100.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn100.Header.VisiblePosition = 3;
            ultraGridColumn101.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn101.Header.VisiblePosition = 4;
            ultraGridColumn102.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn102.Header.VisiblePosition = 5;
            ultraGridColumn103.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn103.Header.VisiblePosition = 6;
            ultraGridBand6.Columns.AddRange(new object[] {
            ultraGridColumn97,
            ultraGridColumn98,
            ultraGridColumn99,
            ultraGridColumn100,
            ultraGridColumn101,
            ultraGridColumn102,
            ultraGridColumn103});
            this.UltraGrid1.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.UltraGrid1.DisplayLayout.BandsSerializer.Add(ultraGridBand2);
            this.UltraGrid1.DisplayLayout.BandsSerializer.Add(ultraGridBand3);
            this.UltraGrid1.DisplayLayout.BandsSerializer.Add(ultraGridBand4);
            this.UltraGrid1.DisplayLayout.BandsSerializer.Add(ultraGridBand5);
            this.UltraGrid1.DisplayLayout.BandsSerializer.Add(ultraGridBand6);
            this.UltraGrid1.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.UltraGrid1.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.UltraGrid1.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True;
            this.UltraGrid1.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None;
            appearance10.BackColor = System.Drawing.Color.Transparent;
            this.UltraGrid1.DisplayLayout.Override.CardAreaAppearance = appearance10;
            this.UltraGrid1.DisplayLayout.Override.CellPadding = 3;
            appearance11.TextHAlignAsString = "Left";
            this.UltraGrid1.DisplayLayout.Override.HeaderAppearance = appearance11;
            this.UltraGrid1.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle;
            appearance12.BorderColor = System.Drawing.Color.LightGray;
            appearance12.TextVAlignAsString = "Middle";
            this.UltraGrid1.DisplayLayout.Override.RowAppearance = appearance12;
            appearance13.BackColor = System.Drawing.Color.LightSteelBlue;
            appearance13.BorderColor = System.Drawing.Color.Black;
            appearance13.ForeColor = System.Drawing.Color.Black;
            this.UltraGrid1.DisplayLayout.Override.SelectedRowAppearance = appearance13;
            this.UltraGrid1.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.None;
            this.UltraGrid1.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.UltraGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UltraGrid1.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UltraGrid1.Location = new System.Drawing.Point(3, 16);
            this.UltraGrid1.Margin = new System.Windows.Forms.Padding(0);
            this.UltraGrid1.Name = "UltraGrid1";
            this.UltraGrid1.Size = new System.Drawing.Size(614, 805);
            this.UltraGrid1.TabIndex = 70;
            ultraToolTipInfo2.Enabled = Infragistics.Win.DefaultableBoolean.True;
            ultraToolTipInfo2.ToolTipText = "Desni klik miša za označavanje osobe";
            this.UltraToolTipManager1.SetUltraToolTip(this.UltraGrid1, ultraToolTipInfo2);
            // 
            // DdobracunDataSet1
            // 
            this.DdobracunDataSet1.DataSetName = "DDOBRACUNDataSet";
            // 
            // UltraDropDown1
            // 
            this.UltraDropDown1.DataMember = "DDKATEGORIJA";
            this.UltraDropDown1.DataSource = this.DdkategorijaDataSet1;
            appearance24.BackColor = System.Drawing.Color.White;
            this.UltraDropDown1.DisplayLayout.Appearance = appearance24;
            ultraGridColumn111.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn111.Header.Caption = "Šifra";
            ultraGridColumn111.Header.VisiblePosition = 0;
            ultraGridColumn111.Width = 43;
            ultraGridColumn112.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn112.Header.VisiblePosition = 1;
            ultraGridColumn112.Width = 273;
            ultraGridColumn113.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn113.Header.VisiblePosition = 2;
            ultraGridColumn113.Hidden = true;
            ultraGridColumn114.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn114.Header.VisiblePosition = 3;
            ultraGridColumn114.Hidden = true;
            ultraGridColumn115.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn115.Header.VisiblePosition = 4;
            ultraGridColumn116.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn116.Header.VisiblePosition = 5;
            ultraGridColumn117.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn117.Header.VisiblePosition = 6;
            ultraGridBand8.Columns.AddRange(new object[] {
            ultraGridColumn111,
            ultraGridColumn112,
            ultraGridColumn113,
            ultraGridColumn114,
            ultraGridColumn115,
            ultraGridColumn116,
            ultraGridColumn117});
            ultraGridColumn118.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn118.Header.VisiblePosition = 0;
            ultraGridColumn119.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn119.Header.VisiblePosition = 1;
            ultraGridColumn120.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn120.Header.VisiblePosition = 2;
            ultraGridColumn121.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn121.Header.VisiblePosition = 3;
            ultraGridBand9.Columns.AddRange(new object[] {
            ultraGridColumn118,
            ultraGridColumn119,
            ultraGridColumn120,
            ultraGridColumn121});
            ultraGridColumn122.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn122.Header.VisiblePosition = 0;
            ultraGridColumn123.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn123.Header.VisiblePosition = 1;
            ultraGridColumn124.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn124.Header.VisiblePosition = 2;
            ultraGridColumn125.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn125.Header.VisiblePosition = 3;
            ultraGridColumn126.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn126.Header.VisiblePosition = 4;
            ultraGridColumn127.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn127.Header.VisiblePosition = 5;
            ultraGridColumn128.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn128.Header.VisiblePosition = 6;
            ultraGridColumn129.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn129.Header.VisiblePosition = 7;
            ultraGridColumn130.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn130.Header.VisiblePosition = 8;
            ultraGridColumn131.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn131.Header.VisiblePosition = 9;
            ultraGridColumn132.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn132.Header.VisiblePosition = 10;
            ultraGridColumn133.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn133.Header.VisiblePosition = 11;
            ultraGridColumn134.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn134.Header.VisiblePosition = 12;
            ultraGridColumn135.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn135.Header.VisiblePosition = 13;
            ultraGridColumn136.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn136.Header.VisiblePosition = 14;
            ultraGridColumn137.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn137.Header.VisiblePosition = 15;
            ultraGridColumn138.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn138.Header.VisiblePosition = 16;
            ultraGridBand10.Columns.AddRange(new object[] {
            ultraGridColumn122,
            ultraGridColumn123,
            ultraGridColumn124,
            ultraGridColumn125,
            ultraGridColumn126,
            ultraGridColumn127,
            ultraGridColumn128,
            ultraGridColumn129,
            ultraGridColumn130,
            ultraGridColumn131,
            ultraGridColumn132,
            ultraGridColumn133,
            ultraGridColumn134,
            ultraGridColumn135,
            ultraGridColumn136,
            ultraGridColumn137,
            ultraGridColumn138});
            ultraGridColumn139.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn139.Header.VisiblePosition = 0;
            ultraGridColumn140.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn140.Header.VisiblePosition = 1;
            ultraGridColumn141.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn141.Header.VisiblePosition = 2;
            ultraGridColumn142.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn142.Header.VisiblePosition = 3;
            ultraGridColumn143.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn143.Header.VisiblePosition = 4;
            ultraGridColumn144.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn144.Header.VisiblePosition = 5;
            ultraGridColumn145.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn145.Header.VisiblePosition = 6;
            ultraGridColumn146.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn146.Header.VisiblePosition = 7;
            ultraGridColumn147.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn147.Header.VisiblePosition = 8;
            ultraGridColumn148.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn148.Header.VisiblePosition = 9;
            ultraGridColumn149.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn149.Header.VisiblePosition = 10;
            ultraGridColumn150.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn150.Header.VisiblePosition = 11;
            ultraGridColumn151.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn151.Header.VisiblePosition = 12;
            ultraGridBand11.Columns.AddRange(new object[] {
            ultraGridColumn139,
            ultraGridColumn140,
            ultraGridColumn141,
            ultraGridColumn142,
            ultraGridColumn143,
            ultraGridColumn144,
            ultraGridColumn145,
            ultraGridColumn146,
            ultraGridColumn147,
            ultraGridColumn148,
            ultraGridColumn149,
            ultraGridColumn150,
            ultraGridColumn151});
            this.UltraDropDown1.DisplayLayout.BandsSerializer.Add(ultraGridBand8);
            this.UltraDropDown1.DisplayLayout.BandsSerializer.Add(ultraGridBand9);
            this.UltraDropDown1.DisplayLayout.BandsSerializer.Add(ultraGridBand10);
            this.UltraDropDown1.DisplayLayout.BandsSerializer.Add(ultraGridBand11);
            this.UltraDropDown1.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None;
            appearance.BackColor = System.Drawing.Color.Transparent;
            this.UltraDropDown1.DisplayLayout.Override.CardAreaAppearance = appearance;
            this.UltraDropDown1.DisplayLayout.Override.CellPadding = 3;
            appearance5.TextHAlignAsString = "Left";
            this.UltraDropDown1.DisplayLayout.Override.HeaderAppearance = appearance5;
            appearance6.BorderColor = System.Drawing.Color.LightGray;
            appearance6.TextVAlignAsString = "Middle";
            this.UltraDropDown1.DisplayLayout.Override.RowAppearance = appearance6;
            this.UltraDropDown1.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance7.BackColor = System.Drawing.Color.LightSteelBlue;
            appearance7.BorderColor = System.Drawing.Color.Black;
            appearance7.ForeColor = System.Drawing.Color.Black;
            this.UltraDropDown1.DisplayLayout.Override.SelectedRowAppearance = appearance7;
            this.UltraDropDown1.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.None;
            this.UltraDropDown1.DisplayMember = "NAZIVKATEGORIJA";
            this.UltraDropDown1.Location = new System.Drawing.Point(378, 182);
            this.UltraDropDown1.Name = "UltraDropDown1";
            this.UltraDropDown1.Size = new System.Drawing.Size(336, 109);
            this.UltraDropDown1.TabIndex = 70;
            this.UltraDropDown1.ValueMember = "IDKATEGORIJA";
            this.UltraDropDown1.Visible = false;
            this.UltraDropDown1.AfterCloseUp += new Infragistics.Win.UltraWinGrid.DropDownEventHandler(this.UltraDropDown1_AfterCloseUp);
            // 
            // DdkategorijaDataSet1
            // 
            this.DdkategorijaDataSet1.DataSetName = "DDKATEGORIJADataSet";
            // 
            // Panel2
            // 
            this.Panel2.Controls.Add(this.UltraGrid2);
            this.Panel2.Controls.Add(this._Panel2_Toolbars_Dock_Area_Left);
            this.Panel2.Controls.Add(this._Panel2_Toolbars_Dock_Area_Right);
            this.Panel2.Controls.Add(this.UltraToolbarsDockArea3);
            this.Panel2.Controls.Add(this.UltraToolbarsDockArea4);
            this.Panel2.Controls.Add(this._Panel2_Toolbars_Dock_Area_Top);
            this.Panel2.Controls.Add(this._Panel2_Toolbars_Dock_Area_Bottom);
            this.Panel2.Controls.Add(this.UltraToolbarsDockArea2);
            this.Panel2.Location = new System.Drawing.Point(0, 18);
            this.Panel2.Margin = new System.Windows.Forms.Padding(0);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(1161, 914);
            this.Panel2.TabIndex = 77;
            // 
            // UltraGrid2
            // 
            this.UltraGrid2.DataMember = "dtRekap";
            this.UltraGrid2.DataSource = this.DsRekapitulacija1;
            appearance4.BackColor = System.Drawing.Color.AliceBlue;
            this.UltraGrid2.DisplayLayout.Appearance = appearance4;
            ultraGridColumn104.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn104.Header.VisiblePosition = 0;
            ultraGridColumn104.Width = 259;
            ultraGridColumn105.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            appearance3.TextHAlignAsString = "Right";
            ultraGridColumn105.CellAppearance = appearance3;
            ultraGridColumn105.Header.VisiblePosition = 1;
            ultraGridColumn105.Width = 75;
            ultraGridColumn106.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn106.Header.VisiblePosition = 2;
            ultraGridColumn106.Hidden = true;
            ultraGridColumn107.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn107.Header.VisiblePosition = 3;
            ultraGridColumn107.Hidden = true;
            ultraGridColumn108.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn108.Header.Caption = "Sati";
            ultraGridColumn108.Header.VisiblePosition = 4;
            ultraGridColumn108.Width = 70;
            ultraGridColumn109.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn109.Header.VisiblePosition = 5;
            ultraGridColumn110.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn110.Header.VisiblePosition = 6;
            ultraGridBand7.Columns.AddRange(new object[] {
            ultraGridColumn104,
            ultraGridColumn105,
            ultraGridColumn106,
            ultraGridColumn107,
            ultraGridColumn108,
            ultraGridColumn109,
            ultraGridColumn110});
            ultraGridBand7.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            this.UltraGrid2.DisplayLayout.BandsSerializer.Add(ultraGridBand7);
            this.UltraGrid2.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.True;
            this.UltraGrid2.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.UltraGrid2.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.UltraGrid2.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
            this.UltraGrid2.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None;
            appearance9.BackColor = System.Drawing.Color.Transparent;
            this.UltraGrid2.DisplayLayout.Override.CardAreaAppearance = appearance9;
            this.UltraGrid2.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            this.UltraGrid2.DisplayLayout.Override.CellPadding = 3;
            this.UltraGrid2.DisplayLayout.Override.ColumnAutoSizeMode = Infragistics.Win.UltraWinGrid.ColumnAutoSizeMode.AllRowsInBand;
            appearance14.TextHAlignAsString = "Left";
            this.UltraGrid2.DisplayLayout.Override.HeaderAppearance = appearance14;
            this.UltraGrid2.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            appearance15.BorderColor = System.Drawing.Color.LightGray;
            appearance15.TextVAlignAsString = "Middle";
            this.UltraGrid2.DisplayLayout.Override.RowAppearance = appearance15;
            appearance17.BackColor = System.Drawing.Color.LightSteelBlue;
            appearance17.BorderColor = System.Drawing.Color.Black;
            appearance17.ForeColor = System.Drawing.Color.Black;
            this.UltraGrid2.DisplayLayout.Override.SelectedRowAppearance = appearance17;
            this.UltraGrid2.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.UltraGrid2.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.UltraGrid2.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
            this.UltraGrid2.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.None;
            this.UltraGrid2.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.UltraGrid2.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.UltraGrid2.DisplayLayout.TabNavigation = Infragistics.Win.UltraWinGrid.TabNavigation.NextControl;
            this.UltraGrid2.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.UltraGrid2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UltraGrid2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UltraGrid2.Location = new System.Drawing.Point(0, 52);
            this.UltraGrid2.Margin = new System.Windows.Forms.Padding(0);
            this.UltraGrid2.Name = "UltraGrid2";
            this.UltraGrid2.Size = new System.Drawing.Size(1161, 862);
            this.UltraGrid2.TabIndex = 68;
            ultraToolTipInfo1.ToolTipText = "Platna lista odabranog djelatnika";
            this.UltraToolTipManager1.SetUltraToolTip(this.UltraGrid2, ultraToolTipInfo1);
            this.UltraGrid2.UseFlatMode = Infragistics.Win.DefaultableBoolean.False;
            this.UltraGrid2.DoubleClickRow += new Infragistics.Win.UltraWinGrid.DoubleClickRowEventHandler(this.UltraGrid2_DoubleClickRow);
            this.UltraGrid2.InitializeRow += new InitializeRowEventHandler(UltraGrid2_InitializeRow);
            // 
            // DsRekapitulacija1
            // 
            this.DsRekapitulacija1.DataSetName = "dsRekapitulacija";
            this.DsRekapitulacija1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // _Panel2_Toolbars_Dock_Area_Left
            // 
            this._Panel2_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._Panel2_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this._Panel2_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this._Panel2_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._Panel2_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(0, 52);
            this._Panel2_Toolbars_Dock_Area_Left.Name = "_Panel2_Toolbars_Dock_Area_Left";
            this._Panel2_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(0, 862);
            this._Panel2_Toolbars_Dock_Area_Left.ToolbarsManager = this.UltraToolbarsManager1;
            // 
            // UltraToolbarsManager1
            // 
            this.UltraToolbarsManager1.DesignerFlags = 1;
            this.UltraToolbarsManager1.DockWithinContainer = this.Panel2;
            this.UltraToolbarsManager1.MenuAnimationStyle = Infragistics.Win.UltraWinToolbars.MenuAnimationStyle.Unfold;
            this.UltraToolbarsManager1.Office2007UICompatibility = false;
            this.UltraToolbarsManager1.ShowFullMenusDelay = 500;
            this.UltraToolbarsManager1.Style = Infragistics.Win.UltraWinToolbars.ToolbarStyle.Office2007;
            ultraToolbar1.DockedColumn = 0;
            ultraToolbar1.DockedRow = 0;
            ultraToolbar1.FloatingLocation = new System.Drawing.Point(877, 461);
            ultraToolbar1.FloatingSize = new System.Drawing.Size(219, 66);
            ultraToolbar1.NonInheritedTools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            tool,
            tool6});
            ultraToolbar1.Text = "UltraToolbar1";
            ultraToolbar2.DockedColumn = 0;
            ultraToolbar2.DockedRow = 1;
            tool9.InstanceProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            tool10.InstanceProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            tool11.InstanceProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            ultraToolbar2.NonInheritedTools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            tool9,
            tool10,
            tool11});
            ultraToolbar2.Settings.CaptionPlacement = Infragistics.Win.TextPlacement.RightOfImage;
            ultraToolbar2.Text = "BrutoElementi";
            this.UltraToolbarsManager1.Toolbars.AddRange(new Infragistics.Win.UltraWinToolbars.UltraToolbar[] {
            ultraToolbar1,
            ultraToolbar2});
            this.UltraToolbarsManager1.ToolbarSettings.AllowCustomize = Infragistics.Win.DefaultableBoolean.False;
            this.UltraToolbarsManager1.ToolbarSettings.AllowDockBottom = Infragistics.Win.DefaultableBoolean.False;
            this.UltraToolbarsManager1.ToolbarSettings.AllowHiding = Infragistics.Win.DefaultableBoolean.False;
            appearance22.FontData.BoldAsString = "True";
            appearance22.FontData.Name = "Tahoma";
            this.UltraToolbarsManager1.ToolbarSettings.Appearance = appearance22;
            this.UltraToolbarsManager1.ToolbarSettings.CaptionPlacement = Infragistics.Win.TextPlacement.RightOfImage;
            this.UltraToolbarsManager1.ToolbarSettings.FillEntireRow = Infragistics.Win.DefaultableBoolean.True;
            tool20.SharedProps.Caption = "TaskPaneTool1";
            tool20.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            tool7.SharedProps.Caption = "Označi sve";
            tool7.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            tool8.SharedProps.Caption = "Ukloni oznake";
            tool8.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            tool12.SharedProps.Caption = "Dodaj VP";
            tool13.SharedProps.Caption = "Izmjeni VP";
            tool2.SharedProps.Caption = "Briši VP";
            tool3.SharedProps.Caption = "DodajNeto";
            tool3.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            tool4.SharedProps.Caption = "IzmjeniNeto";
            tool5.SharedProps.Caption = "BrisiNeto";
            tool17.SharedProps.Caption = "ControlContainerTool1";
            tool18.SharedProps.Caption = "ControlContainerTool2";
            tool19.SharedProps.Caption = "ControlContainerTool3";
            tool19.SharedProps.Width = 186;
            tool14.SharedProps.Caption = "ControlContainerTool4";
            tool15.SharedProps.Caption = "ControlContainerTool5";
            tool16.CanSetWidth = true;
            tool16.SharedProps.Caption = "ControlContainerTool6";
            tool16.SharedProps.Width = 173;
            this.UltraToolbarsManager1.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            tool20,
            tool7,
            tool8,
            tool12,
            tool13,
            tool2,
            tool3,
            tool4,
            tool5,
            tool17,
            tool18,
            tool19,
            tool14,
            tool15,
            tool16});
            this.UltraToolbarsManager1.ToolClick += new Infragistics.Win.UltraWinToolbars.ToolClickEventHandler(this.UltraToolbarsManager1_ToolClick);
            // 
            // _Panel2_Toolbars_Dock_Area_Right
            // 
            this._Panel2_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._Panel2_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this._Panel2_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            this._Panel2_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._Panel2_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(1161, 52);
            this._Panel2_Toolbars_Dock_Area_Right.Name = "_Panel2_Toolbars_Dock_Area_Right";
            this._Panel2_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(0, 862);
            this._Panel2_Toolbars_Dock_Area_Right.ToolbarsManager = this.UltraToolbarsManager1;
            // 
            // UltraToolbarsDockArea3
            // 
            this.UltraToolbarsDockArea3.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.UltraToolbarsDockArea3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.UltraToolbarsDockArea3.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this.UltraToolbarsDockArea3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.UltraToolbarsDockArea3.Location = new System.Drawing.Point(0, 52);
            this.UltraToolbarsDockArea3.Name = "UltraToolbarsDockArea3";
            this.UltraToolbarsDockArea3.Size = new System.Drawing.Size(0, 862);
            this.UltraToolbarsDockArea3.ToolbarsManager = this.UltraToolbarsManager1;
            // 
            // UltraToolbarsDockArea4
            // 
            this.UltraToolbarsDockArea4.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.UltraToolbarsDockArea4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.UltraToolbarsDockArea4.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            this.UltraToolbarsDockArea4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.UltraToolbarsDockArea4.Location = new System.Drawing.Point(1161, 52);
            this.UltraToolbarsDockArea4.Name = "UltraToolbarsDockArea4";
            this.UltraToolbarsDockArea4.Size = new System.Drawing.Size(0, 862);
            this.UltraToolbarsDockArea4.ToolbarsManager = this.UltraToolbarsManager1;
            // 
            // _Panel2_Toolbars_Dock_Area_Top
            // 
            this._Panel2_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._Panel2_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this._Panel2_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top;
            this._Panel2_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
            this._Panel2_Toolbars_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
            this._Panel2_Toolbars_Dock_Area_Top.Name = "_Panel2_Toolbars_Dock_Area_Top";
            this._Panel2_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(1161, 52);
            this._Panel2_Toolbars_Dock_Area_Top.ToolbarsManager = this.UltraToolbarsManager1;
            // 
            // _Panel2_Toolbars_Dock_Area_Bottom
            // 
            this._Panel2_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._Panel2_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this._Panel2_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            this._Panel2_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._Panel2_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 914);
            this._Panel2_Toolbars_Dock_Area_Bottom.Name = "_Panel2_Toolbars_Dock_Area_Bottom";
            this._Panel2_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(1161, 0);
            this._Panel2_Toolbars_Dock_Area_Bottom.ToolbarsManager = this.UltraToolbarsManager1;
            // 
            // UltraToolbarsDockArea2
            // 
            this.UltraToolbarsDockArea2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.UltraToolbarsDockArea2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.UltraToolbarsDockArea2.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            this.UltraToolbarsDockArea2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.UltraToolbarsDockArea2.Location = new System.Drawing.Point(0, 914);
            this.UltraToolbarsDockArea2.Name = "UltraToolbarsDockArea2";
            this.UltraToolbarsDockArea2.Size = new System.Drawing.Size(1161, 0);
            this.UltraToolbarsDockArea2.ToolbarsManager = this.UltraToolbarsManager1;
            // 
            // BackgroundWorker1
            // 
            this.BackgroundWorker1.WorkerReportsProgress = true;
            // 
            // UltraToolTipManager1
            // 
            this.UltraToolTipManager1.ContainingControl = this;
            this.UltraToolTipManager1.DisplayStyle = Infragistics.Win.ToolTipDisplayStyle.Office2007;
            this.UltraToolTipManager1.ToolTipImage = Infragistics.Win.ToolTipImage.Info;
            // 
            // UltraDockManager1
            // 
            dockAreaPane1.ChildPaneStyle = Infragistics.Win.UltraWinDock.ChildPaneStyle.VerticalSplit;
            dockAreaPane1.DockedBefore = new System.Guid("f0de9771-b75d-4dbe-a368-c52e13b18f9a");
            dockableControlPane1.Control = this.Panel1;
            dockableControlPane1.OriginalControlBounds = new System.Drawing.Rectangle(3, 3, 907, 165);
            dockableControlPane1.Size = new System.Drawing.Size(100, 100);
            dockableControlPane1.Text = "Obračun drugog dohotka - podaci o trenutnom obračunu";
            dockAreaPane1.Panes.AddRange(new Infragistics.Win.UltraWinDock.DockablePaneBase[] {
            dockableControlPane1});
            dockAreaPane1.Size = new System.Drawing.Size(610, 932);
            dockableControlPane2.Control = this.Panel2;
            dockableControlPane2.OriginalControlBounds = new System.Drawing.Rectangle(50, 283, 603, 791);
            dockableControlPane2.Size = new System.Drawing.Size(100, 100);
            dockableControlPane2.Text = "Pregled obračunatih iznosa po osobi";
            dockAreaPane2.Panes.AddRange(new Infragistics.Win.UltraWinDock.DockablePaneBase[] {
            dockableControlPane2});
            dockAreaPane2.Size = new System.Drawing.Size(1161, 932);
            this.UltraDockManager1.DockAreas.AddRange(new Infragistics.Win.UltraWinDock.DockAreaPane[] {
            dockAreaPane1,
            dockAreaPane2});
            this.UltraDockManager1.HostControl = this;
            this.UltraDockManager1.UseAppStyling = false;
            this.UltraDockManager1.WindowStyle = Infragistics.Win.UltraWinDock.WindowStyle.Office2007;
            // 
            // _ObracunDDSmartPartUnpinnedTabAreaLeft
            // 
            this._ObracunDDSmartPartUnpinnedTabAreaLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this._ObracunDDSmartPartUnpinnedTabAreaLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._ObracunDDSmartPartUnpinnedTabAreaLeft.Location = new System.Drawing.Point(0, 0);
            this._ObracunDDSmartPartUnpinnedTabAreaLeft.Name = "_ObracunDDSmartPartUnpinnedTabAreaLeft";
            this._ObracunDDSmartPartUnpinnedTabAreaLeft.Owner = this.UltraDockManager1;
            this._ObracunDDSmartPartUnpinnedTabAreaLeft.Size = new System.Drawing.Size(0, 932);
            this._ObracunDDSmartPartUnpinnedTabAreaLeft.TabIndex = 72;
            // 
            // _ObracunDDSmartPartUnpinnedTabAreaRight
            // 
            this._ObracunDDSmartPartUnpinnedTabAreaRight.Dock = System.Windows.Forms.DockStyle.Right;
            this._ObracunDDSmartPartUnpinnedTabAreaRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._ObracunDDSmartPartUnpinnedTabAreaRight.Location = new System.Drawing.Point(1781, 0);
            this._ObracunDDSmartPartUnpinnedTabAreaRight.Name = "_ObracunDDSmartPartUnpinnedTabAreaRight";
            this._ObracunDDSmartPartUnpinnedTabAreaRight.Owner = this.UltraDockManager1;
            this._ObracunDDSmartPartUnpinnedTabAreaRight.Size = new System.Drawing.Size(0, 932);
            this._ObracunDDSmartPartUnpinnedTabAreaRight.TabIndex = 73;
            // 
            // _ObracunDDSmartPartUnpinnedTabAreaTop
            // 
            this._ObracunDDSmartPartUnpinnedTabAreaTop.Dock = System.Windows.Forms.DockStyle.Top;
            this._ObracunDDSmartPartUnpinnedTabAreaTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._ObracunDDSmartPartUnpinnedTabAreaTop.Location = new System.Drawing.Point(0, 0);
            this._ObracunDDSmartPartUnpinnedTabAreaTop.Name = "_ObracunDDSmartPartUnpinnedTabAreaTop";
            this._ObracunDDSmartPartUnpinnedTabAreaTop.Owner = this.UltraDockManager1;
            this._ObracunDDSmartPartUnpinnedTabAreaTop.Size = new System.Drawing.Size(1781, 0);
            this._ObracunDDSmartPartUnpinnedTabAreaTop.TabIndex = 74;
            // 
            // _ObracunDDSmartPartUnpinnedTabAreaBottom
            // 
            this._ObracunDDSmartPartUnpinnedTabAreaBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._ObracunDDSmartPartUnpinnedTabAreaBottom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._ObracunDDSmartPartUnpinnedTabAreaBottom.Location = new System.Drawing.Point(0, 932);
            this._ObracunDDSmartPartUnpinnedTabAreaBottom.Name = "_ObracunDDSmartPartUnpinnedTabAreaBottom";
            this._ObracunDDSmartPartUnpinnedTabAreaBottom.Owner = this.UltraDockManager1;
            this._ObracunDDSmartPartUnpinnedTabAreaBottom.Size = new System.Drawing.Size(1781, 0);
            this._ObracunDDSmartPartUnpinnedTabAreaBottom.TabIndex = 75;
            // 
            // _ObracunDDSmartPartAutoHideControl
            // 
            this._ObracunDDSmartPartAutoHideControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._ObracunDDSmartPartAutoHideControl.Location = new System.Drawing.Point(0, 0);
            this._ObracunDDSmartPartAutoHideControl.Name = "_ObracunDDSmartPartAutoHideControl";
            this._ObracunDDSmartPartAutoHideControl.Owner = this.UltraDockManager1;
            this._ObracunDDSmartPartAutoHideControl.Size = new System.Drawing.Size(0, 810);
            this._ObracunDDSmartPartAutoHideControl.TabIndex = 76;
            // 
            // WindowDockingArea1
            // 
            this.WindowDockingArea1.Controls.Add(this.DockableWindow1);
            this.WindowDockingArea1.Dock = System.Windows.Forms.DockStyle.Left;
            this.WindowDockingArea1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.WindowDockingArea1.Location = new System.Drawing.Point(0, 0);
            this.WindowDockingArea1.Name = "WindowDockingArea1";
            this.WindowDockingArea1.Owner = this.UltraDockManager1;
            this.WindowDockingArea1.Size = new System.Drawing.Size(615, 932);
            this.WindowDockingArea1.TabIndex = 78;
            // 
            // DockableWindow1
            // 
            this.DockableWindow1.Controls.Add(this.Panel1);
            this.DockableWindow1.Location = new System.Drawing.Point(0, 0);
            this.DockableWindow1.Name = "DockableWindow1";
            this.DockableWindow1.Owner = this.UltraDockManager1;
            this.DockableWindow1.Size = new System.Drawing.Size(610, 932);
            this.DockableWindow1.TabIndex = 80;
            // 
            // WindowDockingArea2
            // 
            this.WindowDockingArea2.Controls.Add(this.DockableWindow2);
            this.WindowDockingArea2.Dock = System.Windows.Forms.DockStyle.Left;
            this.WindowDockingArea2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.WindowDockingArea2.Location = new System.Drawing.Point(615, 0);
            this.WindowDockingArea2.Name = "WindowDockingArea2";
            this.WindowDockingArea2.Owner = this.UltraDockManager1;
            this.WindowDockingArea2.Size = new System.Drawing.Size(1166, 932);
            this.WindowDockingArea2.TabIndex = 79;
            // 
            // DockableWindow2
            // 
            this.DockableWindow2.Controls.Add(this.Panel2);
            this.DockableWindow2.Location = new System.Drawing.Point(0, 0);
            this.DockableWindow2.Name = "DockableWindow2";
            this.DockableWindow2.Owner = this.UltraDockManager1;
            this.DockableWindow2.Size = new System.Drawing.Size(1161, 932);
            this.DockableWindow2.TabIndex = 81;
            // 
            // ObracunDDSmartPart
            // 
            this.Controls.Add(this._ObracunDDSmartPartAutoHideControl);
            this.Controls.Add(this.WindowDockingArea2);
            this.Controls.Add(this.WindowDockingArea1);
            this.Controls.Add(this._ObracunDDSmartPartUnpinnedTabAreaTop);
            this.Controls.Add(this._ObracunDDSmartPartUnpinnedTabAreaBottom);
            this.Controls.Add(this._ObracunDDSmartPartUnpinnedTabAreaLeft);
            this.Controls.Add(this._ObracunDDSmartPartUnpinnedTabAreaRight);
            this.Name = "ObracunDDSmartPart";
            this.Size = new System.Drawing.Size(1781, 932);
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraSifraObracuna)).EndInit();
            this.GroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.UltraGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DdobracunDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltraDropDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DdkategorijaDataSet1)).EndInit();
            this.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.UltraGrid2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DsRekapitulacija1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltraToolbarsManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltraDesktopAlert1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltraDockManager1)).EndInit();
            this.WindowDockingArea1.ResumeLayout(false);
            this.DockableWindow1.ResumeLayout(false);
            this.WindowDockingArea2.ResumeLayout(false);
            this.DockableWindow2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        //iskopirana metoda iz mipseda7 18.01.2017
        public void IspisiPlatne()
        {
            ReportDocument rpt = new ReportDocument();
            ExtendedWindowSmartPartInfo info = new ExtendedWindowSmartPartInfo {
                StartPosition = FormStartPosition.CenterParent,
                Modal = true,
                Title = "Pregled izvještaja",
                Description = "Pregled",
                Icon = ImageResourcesNew.mbs
            };

            //db - 17.01.2017
            Dictionary<int, string> oznaceni = VratiOznaceneRadnike(UltraGrid1.Rows);

            //db - 18.01.2017
            if (oznaceni.Count == 0)
            {
                MessageBox.Show("Potrebno je odabrati radnika.");
                return;//povratak ukoliko nema nijedan označeni
            }

            rpt.Load(System.Windows.Forms.Application.StartupPath + @"\DDIzvjestaji\rptPlatnaListaxx.rpt");

            Mipsed7.DataAccessLayer.SqlClient conn = new Mipsed7.DataAccessLayer.SqlClient();
            try
            {
                ConnectionInfo connInfo = new ConnectionInfo();
                connInfo.ServerName = Mipsed7.Core.ApplicationDatabaseInformation.ServerName;
                connInfo.DatabaseName = Mipsed7.Core.ApplicationDatabaseInformation.DatabaseName;
                connInfo.UserID = Mipsed7.Core.ApplicationDatabaseInformation.SqlUserName;
                connInfo.Password = Mipsed7.Core.ApplicationDatabaseInformation.SqlPassword;

                TableLogOnInfo tableLogOnInfo = new TableLogOnInfo();
                tableLogOnInfo.ConnectionInfo = connInfo;

                foreach (Table table in rpt.Database.Tables)
                {
                    table.ApplyLogOnInfo(tableLogOnInfo);
                    table.LogOnInfo.ConnectionInfo.ServerName = connInfo.ServerName;
                    table.LogOnInfo.ConnectionInfo.DatabaseName = connInfo.DatabaseName;
                    table.LogOnInfo.ConnectionInfo.UserID = connInfo.UserID;
                    table.LogOnInfo.ConnectionInfo.Password = connInfo.Password;
                }
            }
            catch (Exception exp) { MessageBox.Show(exp.Message); }
            

            KORISNIKDataSet dataSet = new KORISNIKDataSet();
            new KORISNIKDataAdapter().Fill(dataSet);

            DateTime dat = Convert.ToDateTime(this.DdobracunDataSet1.DDOBRACUN.Rows[0]["dddatumobracuna"]);
         
            //db - 17.1.2017
            rpt.SetDataSource(GetRadniciIspisOznaceni(oznaceni));
                     
            if (dataSet.KORISNIK.Rows.Count > 0)
            {                
                rpt.SetParameterValue("ADRESA", RuntimeHelpers.GetObjectValue(dataSet.KORISNIK.Rows[0]["KORISNIK1ADRESA"]));
                rpt.SetParameterValue("NAZIV", RuntimeHelpers.GetObjectValue(dataSet.KORISNIK.Rows[0]["KORISNIK1NAZIV"]));
                rpt.SetParameterValue("OIB", RuntimeHelpers.GetObjectValue(dataSet.KORISNIK.Rows[0]["KORISNIKOIB"]));
                rpt.SetParameterValue("FAX", RuntimeHelpers.GetObjectValue(dataSet.KORISNIK.Rows[0]["KONTAKTFAX"]));
                rpt.SetParameterValue("TEL", RuntimeHelpers.GetObjectValue(dataSet.KORISNIK.Rows[0]["KONTAKTTELEFON"]));

                rpt.SetParameterValue("DDIznos", 0);  //ovo bespotrebno govno sam ostavio samo zato jer je taj parametar zakopan u nekoj formuli kao krpelj, i ne da mi se vise gubiti vrijeme na to. ukratko, NEMA efekta na report, posto koristim DDIznos koji sam dokvatio preko view-a. taj nacin je uostalom i tocan. ovaj nije.
            }                      

            int nMjesec = DateAndTime.Month(Conversions.ToDate(this.DdobracunDataSet1.DDOBRACUN.Rows[0]["dddatumobracuna"]));
            rpt.SetParameterValue("MJESEC", DB.MjesecNazivPlatna(nMjesec) + "/" + Conversions.ToString(DateAndTime.Year(Conversions.ToDate(this.DdobracunDataSet1.DDOBRACUN.Rows[0]["dddatumobracuna"]))));

            ExtendedWindowWorkspace workspace = new ExtendedWindowWorkspace();
            PreviewReportWorkItem item = this.Controller.WorkItem.Items.Get<PreviewReportWorkItem>("Pregled");
            if (item == null)
            {
                item = this.Controller.WorkItem.Items.AddNew<PreviewReportWorkItem>("Pregled");
            }
            item.Izvjestaj = rpt;
            item.Show(item.Workspaces["main"]);
        }

        //db - 18.01.2017
        private Dictionary<int, string> VratiOznaceneRadnike(RowsCollection rowsCollection)
        {
            Dictionary<int, string> oznaceni = new Dictionary<int, string>();

            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow row in rowsCollection)
            {
                if (row.Cells["oznacen"].Value.ToString() == "True")
                {
                    oznaceni.Add(Convert.ToInt32(row.Cells["DDIDRADNIK"].Value), Convert.ToString(row.Cells["DDOBRACUNIDOBRACUN"].Value));
                }
            }

            return oznaceni;
        }

        //db - 18.01.2017
        internal DataTable GetRadniciIspisOznaceni(Dictionary<int, string> oznaceni)
        {
            string where = string.Empty;
            int counter = 0;
            foreach (KeyValuePair<int, string> row in oznaceni)
            {
                counter++;

                if (counter < oznaceni.Count && oznaceni.Count > 1)
                {
                    where += "( DDIDRADNIK = " + row.Key + " And DDOBRACUNIDOBRACUN = '" + row.Value.ToString() + "' and IDVRSTADOPRINOS = 1 ) OR";
                }
                else
                {
                    where += "( DDIDRADNIK = " + row.Key + " And DDOBRACUNIDOBRACUN = '" + row.Value.ToString() + "' and IDVRSTADOPRINOS = 1 ) ";
                }

                if (oznaceni.Count == 0)
                {
                    where = " ( DDOBRACUNIDOBRACUN = '2017-01-001' and IDVRSTADOPRINOS = 1 ) ";
                }

            }

            DataTable racuni = client.GetDataTable("select distinct * from v_DDDoprinosNA Where " + where);

            return racuni;
        }


        public void IspisiPlatne_Abeceda()
        {
            IEnumerator enumerator = null;
            ReportDocument document = new ReportDocument();
            ExtendedWindowSmartPartInfo info = new ExtendedWindowSmartPartInfo {
                StartPosition = FormStartPosition.CenterParent,
                Modal = true,
                Title = "Pregled izvještaja",
                Description = "Pregled",
                Icon = ImageResourcesNew.mbs
            };
            DataSet set = new DataSet();
            try
            {
                enumerator = this.DdobracunDataSet1.Tables.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    DataTable current = (DataTable) enumerator.Current;
                    if (current.TableName == "DDOBRACUNRadnici")
                    {
                        DataTable table = new DataTable();
                        table = new DataView(current) { Sort = "DDprezime" }.ToTable();
                        set.Tables.Add(table);
                    }
                    else
                    {
                        set.Tables.Add(current.Copy());
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
            document.Load(System.Windows.Forms.Application.StartupPath + @"\DDIzvjestaji\rptPlatnaListaxx.rpt");
            document.SetDataSource(set);
            KORISNIKDataSet dataSet = new KORISNIKDataSet();
            new KORISNIKDataAdapter().Fill(dataSet);
            string str6 = Conversions.ToString(dataSet.KORISNIK.Rows[0]["korisnik1naziv"]);
            string str5 = Conversions.ToString(dataSet.KORISNIK.Rows[0]["MBKORISNIK"]);
            string str = Conversions.ToString(dataSet.KORISNIK.Rows[0]["korisnik1adresa"]);
            string str2 = Conversions.ToString(dataSet.KORISNIK.Rows[0]["korisnik1mjesto"]);
            string str8 = Conversions.ToString(dataSet.KORISNIK.Rows[0]["KONTAKTTELEFON"]);
            string str4 = Conversions.ToString(dataSet.KORISNIK.Rows[0]["KONTAKTFAX"]);
            document.SetParameterValue("ADRESA_FIRME2", str2);
            document.SetParameterValue("ADRESA_FIRME", str);
            document.SetParameterValue("NAZIV_FIRME", str6);
            document.SetParameterValue("MATICNIBROJ", str5);
            document.SetParameterValue("TELEFON", str8);
            document.SetParameterValue("FAX", str4);
            int nMjesec = DateAndTime.Month(Conversions.ToDate(this.DdobracunDataSet1.DDOBRACUN.Rows[0]["dddatumobracuna"]));
            document.SetParameterValue("mjesec_rijecima", DB.MjesecNazivPlatna(nMjesec));
            ExtendedWindowWorkspace workspace = new ExtendedWindowWorkspace();
            PreviewReportWorkItem item = this.Controller.WorkItem.Items.Get<PreviewReportWorkItem>("Pregled");
            if (item == null)
            {
                item = this.Controller.WorkItem.Items.AddNew<PreviewReportWorkItem>("Pregled");
            }
            item.Izvjestaj = document;
            item.Show(item.Workspaces["main"]);
        }

        [LocalCommandHandler("IspisiPlatneAbecedaCommnd")]
        public void IspisiPlatnebecedaHandler(object sender, EventArgs e)
        {
            this.IspisiPlatne_Abeceda();
        }

        [LocalCommandHandler("IspisiPlatneCommand")]
        public void IspisiPlatneHandler(object sender, EventArgs e)
        {
            this.IspisiPlatne();
        }

        [LocalCommandHandler("Izlaz")]
        public void IzlazHanlder(object sender, EventArgs e)
        {
            if (Interaction.MsgBox("Želite li spremiti promjene", MsgBoxStyle.YesNo, null) == MsgBoxResult.Yes)
            {
                this.Save_DD_To_Database();
            }
            this.Controller.WorkItem.Workspaces["main"].Close(RuntimeHelpers.GetObjectValue(this.Controller.WorkItem.Workspaces["main"].ActiveSmartPart));
        }

        private void IzmjenaVrstePosla()
        {
            CurrencyManager manager = (CurrencyManager) this.BindingContext[this.DsRekapitulacija1, "dtRekap"];
            if (manager.Count != 0)
            {
                DataRowView current = (DataRowView) manager.Current;
                if (Versioned.IsNumeric(RuntimeHelpers.GetObjectValue(current["sifraelementa"])) && this.MoguceMijenjatiObracun())
                {
                    frmUnosVrstePosla posla = new frmUnosVrstePosla {
                        ___ParentForm = this,
                        Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("Izmjeni vrstu posla (", NewLateBinding.LateIndexGet(this.BindingContext[this.dvVrstePosla].Current, new object[] { "ddidvrstaposla" }, null)), ") na trenutnoj osobi ("), this.AktivnaOsobaDD()), " - "), this.Aktivna_Osoba_Prezime_Ime()), ")"))
                    };
                    posla.lblSifEle.Text = "Vrsta posla:";
                    posla.cbSifra.ReadOnly = true;
                    this.dvVrstePosla.Sort = "ddIDvrstaposla";
                    posla._dv = this.dvVrstePosla;
                    this.dvVrstePosla.RowFilter = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("ddidvrstaposla=", current["sifraelementa"]), "AND ddIDRADNIK = "), this.AktivnaOsobaDD()));
                    posla._drvVrstaPosla = (DataRowView) this.BindingContext[this.dvVrstePosla].Current;
                    posla.cbSifra.Enabled = false;
                    if (posla.ShowDialog() == DialogResult.OK)
                    {
                        this.Pokreni_Zbirni_Izracun_DD(true);
                    }
                    posla.Dispose();
                }
            }
        }

        private void Izracun_Drugog_Dohotka(DDOBRACUNDataSet drObracunDD, DataRowView drvObracunDD)
        {
            DDOBRACUNDataSet.DDOBRACUNRadniciDoprinosiRow row;
            int num = 0;
            decimal num4 = 0;
            this.BindingContext[this.DdobracunDataSet1.DDOBRACUNRadnici].EndCurrentEdit();
            this.PocistiObracunatoDrugiDohodak(this.sifraobracuna, Conversions.ToInteger(drvObracunDD["ddidradnik"]));
            decimal left = this.SumaBrutoDrugogDohotka(RuntimeHelpers.GetObjectValue(drvObracunDD["ddidradnik"]));
            this.dvDoprinosiNA.Table = this.DdkategorijaDataSet1.DDKATEGORIJALevel3;
            this.dvDoprinosiNA.RowFilter = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("idkategorija = ", drvObracunDD["idkategorija"]), " AND idvrstadoprinos = 1"));
            this.dvDoprinosiIZ.Table = this.DdkategorijaDataSet1.DDKATEGORIJALevel3;
            this.dvDoprinosiIZ.RowFilter = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("idkategorija = ", drvObracunDD["idkategorija"]), " AND idvrstadoprinos = 2 AND DOPRINOSDRUGOGSTUPA = "), drvObracunDD["DDDRUGISTUP"]));
            this.dvIzdaci.Table = this.DdkategorijaDataSet1.DDKATEGORIJAIzdaci;
            this.dvIzdaci.RowFilter = Conversions.ToString(Operators.ConcatenateObject("idkategorija = ", drvObracunDD["idkategorija"]));
            decimal num7 = left;
            decimal num3 = left;
            decimal num5 = new decimal();
            int num14 = this.dvIzdaci.Count - 1;
            for (num = 0; num <= num14; num++)
            {
                DDOBRACUNDataSet.DDOBRACUNRadniciIzdaciRow row2 = (DDOBRACUNDataSet.DDOBRACUNRadniciIzdaciRow) this.DdobracunDataSet1.DDOBRACUNRadniciIzdaci.NewRow();
                row2["ddobracunidobracun"] = this.sifraobracuna;
                row2["ddidizdatak"] = RuntimeHelpers.GetObjectValue(this.dvIzdaci[num].Row["ddidizdatak"]);
                row2["ddobracunatiizdatak"] = DB.RoundUP(Operators.DivideObject(Operators.MultiplyObject(left, this.dvIzdaci[num].Row["ddpostotakizdatka"]), 100));
                row2["ddidradnik"] = RuntimeHelpers.GetObjectValue(drvObracunDD["ddidradnik"]);
                if (Operators.ConditionalCompareObjectGreater(row2["ddobracunatiizdatak"], 0, false))
                {
                    this.DdobracunDataSet1.DDOBRACUNRadniciIzdaci.Rows.Add(row2);
                    num7 = Conversions.ToDecimal(Operators.SubtractObject(num7, row2["ddobracunatiizdatak"]));
                    num5 = Conversions.ToDecimal(Operators.AddObject(num5, row2["ddobracunatiizdatak"]));
                }
            }
            this.BindingContext[this.DdobracunDataSet1.DDOBRACUNRadniciIzdaci].EndCurrentEdit();
            int num15 = this.dvDoprinosiIZ.Count - 1;
            for (num = 0; num <= num15; num++)
            {
                row = (DDOBRACUNDataSet.DDOBRACUNRadniciDoprinosiRow) this.DdobracunDataSet1.DDOBRACUNRadniciDoprinosi.NewRow();
                decimal num6 = DB.RoundUP(Operators.DivideObject(Operators.MultiplyObject(num7, this.dvDoprinosiIZ[num].Row["stopa"]), 100));
                row["ddobracunidobracun"] = this.sifraobracuna;
                row["iddoprinos"] = RuntimeHelpers.GetObjectValue(this.dvDoprinosiIZ[num].Row["iddoprinos"]);
                row["ddobracunatidoprinos"] = num6;
                row["ddosnovicadoprinos"] = num7;
                row["ddidradnik"] = RuntimeHelpers.GetObjectValue(drvObracunDD["DDidradnik"]);
                if (Operators.ConditionalCompareObjectGreater(row["DDobracunatidoprinos"], 0, false))
                {
                    this.DdobracunDataSet1.DDOBRACUNRadniciDoprinosi.Rows.Add(row);
                    num3 = decimal.Subtract(num3, num6);
                    num4 = decimal.Add(num4, num6);
                }
            }
            int num16 = this.dvDoprinosiNA.Count - 1;
            for (num = 0; num <= num16; num++)
            {
                row = (DDOBRACUNDataSet.DDOBRACUNRadniciDoprinosiRow) this.DdobracunDataSet1.DDOBRACUNRadniciDoprinosi.NewRow();
                row["ddobracunidobracun"] = this.sifraobracuna;
                row["iddoprinos"] = RuntimeHelpers.GetObjectValue(this.dvDoprinosiNA[num].Row["iddoprinos"]);

                //db - 03.02.2017
                row["ddObracunatidoprinos"] = DB.RoundUP(Operators.DivideObject(Operators.MultiplyObject(num7, this.dvDoprinosiNA[num].Row["stopa"]), 100));
                //row["ddObracunatidoprinos"] = DB.RoundUP(Operators.DivideObject(Operators.MultiplyObject(left, this.dvDoprinosiNA[num].Row["stopa"]), 100));
               
                //db - 03.02.2017
                // row["ddosnovicadoprinos"] = left;
                row["ddosnovicadoprinos"] = num7;

                row["ddidradnik"] = RuntimeHelpers.GetObjectValue(drvObracunDD["DDidradnik"]);
                if (Operators.ConditionalCompareObjectGreater(row["ddObracunatidoprinos"], 0, false))
                {
                    this.DdobracunDataSet1.DDOBRACUNRadniciDoprinosi.Rows.Add(row);
                }
            }
            this.BindingContext[this.DdobracunDataSet1.DDOBRACUNRadniciDoprinosi].EndCurrentEdit();
            decimal num8 = decimal.Subtract(num3, num5);
            this.dvPorezi.Table = this.DdkategorijaDataSet1.DDKATEGORIJALevel1;
            this.dvPorezi.RowFilter = Conversions.ToString(Operators.ConcatenateObject("idkategorija = ", drvObracunDD["idkategorija"]));
            decimal num9 = new decimal();
            int num17 = this.dvPorezi.Count - 1;
            for (num = 0; num <= num17; num++)
            {
                decimal num13 = 0;
                DDOBRACUNDataSet.DDOBRACUNRadniciPoreziRow row3 = (DDOBRACUNDataSet.DDOBRACUNRadniciPoreziRow) this.DdobracunDataSet1.DDOBRACUNRadniciPorezi.NewRow();
                row3["ddobracunidobracun"] = this.sifraobracuna;
                row3["idporez"] = RuntimeHelpers.GetObjectValue(this.dvPorezi[num].Row["idporez"]);
                row3["DDobracunatiporez"] = num13;
                row3["DDosnovicaporez"] = num8;
                num13 = DB.RoundUP(Operators.DivideObject(Operators.MultiplyObject(num8, this.dvPorezi[num].Row["stopaporeza"]), 100));
                row3["DDobracunatiporez"] = num13;
                row3["DDosnovicaporez"] = num8;
                row3["DDIDRADNIK"] = RuntimeHelpers.GetObjectValue(drvObracunDD["DDIDRADNIK"]);
                this.DdobracunDataSet1.DDOBRACUNRadniciPorezi.Rows.Add(row3);
                num9 = decimal.Add(num9, num13);
            }
            decimal num10 = DB.RoundUP(Operators.DivideObject(Operators.MultiplyObject(num9, drvObracunDD["OPCINASTANOVANJAPRIREZ"]), 100));
            drvObracunDD["ddobracunatiprirez"] = num10;
            this.BindingContext[this.DdobracunDataSet1.DDOBRACUNRadniciPorezi].EndCurrentEdit();
            decimal num11 = decimal.Subtract(decimal.Subtract(decimal.Subtract(left, num4), num9), num10);
            decimal num12 = decimal.Subtract(decimal.Subtract(decimal.Subtract(left, num4), num9), num10);
            if (Operators.ConditionalCompareObjectEqual(drvObracunDD["ddpdvobveznik"], true, false))
            {
                drvObracunDD["ddobracunatipdv"] = DB.RoundUP(decimal.Divide(decimal.Multiply(left, 25M), 100M));
            }
        }

        private void Kontrola_GotFocus(object sender, EventArgs e)
        {
            NewLateBinding.LateCall(sender, null, "SelectAll", new object[0], null, null, null, true);
        }

        [CommandHandler("ListaIznosaCommand")]
        public void ListaIznosaCommandHandler(object sender, EventArgs e)
        {
            if (this.sifraobracuna == "")
            {
                Interaction.MsgBox("Trenutno nema otvorenog obračuna!", MsgBoxStyle.Information, "Drugi dohodak");
            }
            else
            {
                SqlConnection connection = new SqlConnection {
                    ConnectionString = Configuration.ConnectionString
                };
                ReportDocument document = new ReportDocument();
                document.Load(System.Windows.Forms.Application.StartupPath + @"\DDIzvjestaji\rptListaIznosaRadnikadd.rpt");
                S_DD_LISTA_IZNOSA_RADNIKADataAdapter adapter2 = new S_DD_LISTA_IZNOSA_RADNIKADataAdapter();
                S_DD_LISTA_IZNOSA_RADNIKADataSet dataSet = new S_DD_LISTA_IZNOSA_RADNIKADataSet();
                int sORT = 0;
                adapter2.Fill(dataSet, this.sifraobracuna, sORT);
                string str2 = this.DdobracunDataSet1.DDOBRACUN.Rows[0]["DDOBRACUNIDOBRACUN"].ToString().Substring(5, 2);
                string str = this.DdobracunDataSet1.DDOBRACUN.Rows[0]["DDOBRACUNIDOBRACUN"].ToString().Substring(0, 4);
                ((TextObject) document.ReportDefinition.ReportObjects["txtNaslov"]).Text = "LISTA IZNOSA DRUGOG DOHOTKA ZA OBRAČUN: " + this.DdobracunDataSet1.DDOBRACUN.Rows[0]["DDOBRACUNIDOBRACUN"].ToString() + "  (MJESEC ISPLATE: " + str2 + " / " + str + ")";
                document.SetDataSource(dataSet);
                KORISNIKDataAdapter adapter = new KORISNIKDataAdapter();
                KORISNIKDataSet set = new KORISNIKDataSet();
                adapter.Fill(set);
                document.SetParameterValue("NAZIV_FIRME", RuntimeHelpers.GetObjectValue(set.KORISNIK.Rows[0]["KORISNIK1NAZIV"]));
                document.SetParameterValue("ADRESA_FIRME", RuntimeHelpers.GetObjectValue(set.KORISNIK.Rows[0]["KORISNIK1ADRESA"]));
                document.SetParameterValue("ADRESA_FIRME2", RuntimeHelpers.GetObjectValue(set.KORISNIK.Rows[0]["KORISNIK1MJESTO"]));
                document.SetParameterValue("MATICNI_BROJ", RuntimeHelpers.GetObjectValue(set.KORISNIK.Rows[0]["MBKORISNIK"]));
                document.SetParameterValue("TELEFON", RuntimeHelpers.GetObjectValue(set.KORISNIK.Rows[0]["KONTAKTTELEFON"]));
                document.SetParameterValue("FAX", RuntimeHelpers.GetObjectValue(set.KORISNIK.Rows[0]["KONTAKTFAX"]));
                ExtendedWindowSmartPartInfo info = new ExtendedWindowSmartPartInfo {
                    StartPosition = FormStartPosition.CenterParent,
                    Modal = true,
                    Title = "Pregled izvještaja - Lista iznosa drugog dohotka",
                    Description = "Pregled izvještaja - Lista iznosa drugog dohotka",
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
        }

        private bool MoguceMijenjatiObracun()
        {
            if (!this.moguceispravke)
            {
                MessageBox.Show("Izmjene nisu moguće na trenutnom obračunu!\r\n\r\nNapomena: Izmjene je moguće raditi samo na zadnjem obračunu u nekom mjesecu.", "Obračun plaće", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return this.moguceispravke;
        }

        public decimal NetoUBruto_DopIz()
        {
            object obj2 = new object();
            object obj5 = new object();
            DataView view = new DataView {
                Table = this.DdkategorijaDataSet1.DDKATEGORIJALevel3,
                RowFilter = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("idkategorija = ", NewLateBinding.LateIndexGet(this.CurrencyManager.Current, new object[] { "idkategorija" }, null)), " AND idvrstadoprinos = 2"))
            };
            decimal left = new decimal();
            if (ObjectFlowControl.ForLoopControl.ForLoopInitObj(obj2, 0, view.Count - 1, 1, ref obj5, ref obj2))
            {
                do
                {
                    left = Conversions.ToDecimal(Operators.AddObject(left, view[Conversions.ToInteger(obj2)].Row["stopa"]));
                }
                while (ObjectFlowControl.ForLoopControl.ForNextCheckObj(obj2, obj5, ref obj2));
            }
            return decimal.Divide(left, 2M);
        }

        public decimal NetoUBruto_DopNa()
        {
            object obj2 = new object();
            object obj5 = new object();
            DataView view = new DataView {
                Table = this.DdkategorijaDataSet1.DDKATEGORIJALevel3,
                RowFilter = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("idkategorija = ", NewLateBinding.LateIndexGet(this.CurrencyManager.Current, new object[] { "idkategorija" }, null)), " AND idvrstadoprinos = 1"))
            };
            decimal left = new decimal();
            if (ObjectFlowControl.ForLoopControl.ForLoopInitObj(obj2, 0, view.Count - 1, 1, ref obj5, ref obj2))
            {
                do
                {
                    left = Conversions.ToDecimal(Operators.AddObject(left, view[Conversions.ToInteger(obj2)].Row["stopa"]));
                }
                while (ObjectFlowControl.ForLoopControl.ForNextCheckObj(obj2, obj5, ref obj2));
            }
            return left;
        }

        public decimal NetoUBruto_Izdaci()
        {
            object obj2 = new object();
            object obj5 = new object();
            this.dvIzdaci.Table = this.DdkategorijaDataSet1.DDKATEGORIJAIzdaci;
            this.dvIzdaci.RowFilter = Conversions.ToString(Operators.ConcatenateObject("idkategorija = ", NewLateBinding.LateIndexGet(this.CurrencyManager.Current, new object[] { "idkategorija" }, null)));
            decimal left = new decimal();
            if (ObjectFlowControl.ForLoopControl.ForLoopInitObj(obj2, 0, this.dvIzdaci.Count - 1, 1, ref obj5, ref obj2))
            {
                do
                {
                    left = Conversions.ToDecimal(Operators.AddObject(left, this.dvIzdaci[Conversions.ToInteger(obj2)].Row["ddpostotakizdatka"]));
                }
                while (ObjectFlowControl.ForLoopControl.ForNextCheckObj(obj2, obj5, ref obj2));
            }
            return left;
        }

        public decimal NetoUBruto_Porez()
        {
            this.dvPorezi.Table = this.DdkategorijaDataSet1.DDKATEGORIJALevel1;
            this.dvPorezi.RowFilter = Conversions.ToString(Operators.ConcatenateObject("idkategorija = ", NewLateBinding.LateIndexGet(this.CurrencyManager.Current, new object[] { "idkategorija" }, null)));
            decimal left = new decimal();
            int num4 = this.dvPorezi.Count - 1;
            for (int i = 0; i <= num4; i++)
            {
                left = Conversions.ToDecimal(Operators.AddObject(left, this.dvPorezi[i].Row["stopaporeza"]));
            }
            return left;
        }

        public decimal NetoUBruto_Prirez()
        {
            return Conversions.ToDecimal(NewLateBinding.LateIndexGet(this.CurrencyManager.Current, new object[] { "opcinastanovanjaprirez" }, null));
        }

        public bool NetoUBrutoPdv()
        {
            return Operators.ConditionalCompareObjectEqual(NewLateBinding.LateIndexGet(this.CurrencyManager.Current, new object[] { "ddpdvobveznik" }, null), true, false);
        }

        private void ObracunSmartPart_Load(object sender, EventArgs e)
        {
            this.dvVrstePosla.Table = this.DdobracunDataSet1.DDOBRACUNRadniciVrstePosla;
            this.dakategorija.Fill(this.DdkategorijaDataSet1);
            this.ZapocniPonovo();
            this.dakorisnik.Fill(this.dsKorisnik);
            this.UltraGrid2.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.Select;
            this.UltraGrid2.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.UltraGrid1.Text = "";
            this.datumobracuna = DateAndTime.Today;
        }

        [LocalCommandHandler("ObrisiRadnike")]
        public void ObrisiRadnikeHandler(object sender, EventArgs e)
        {
            this.Brisanje_Oznacenih_Osoba_Iz_obracuna();
        }

        private void Oznaci_Sve_Osobe()
        {
            int num2 = this.UltraGrid1.Rows.Count - 1;
            for (int i = 0; i <= num2; i++)
            {
                this.UltraGrid1.Rows[i].Cells["oznacen"].Value = true;
            }
            try
            {
                this.BindingContext[this.DdobracunDataSet1.DDOBRACUNRadnici].EndCurrentEdit();
            }
            catch (System.Exception exception1)
            {
                throw exception1;
                
                
            }
        }

        private void Parametri_DodajOznaceneRadnike()
        {
            if (this.DdobracunDataSet1.DDOBRACUN.Rows.Count == 0)
            {
                MessageBox.Show("Osobe možete dodavati u obračun tek kada je obračun kreiran!", "Drugi dohodak", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (this.MoguceMijenjatiObracun())
            {
                this.__ddisablePromjenuPozicije = true;
                frmPregledRadnika radnika = new frmPregledRadnika {
                    VecUObracunu = this.DdobracunDataSet1.DDOBRACUNRadnici
                };
                radnika.ShowDialog();
                int num = 0;
                UltraGrid odabraniRadnici = new UltraGrid();
                odabraniRadnici = (UltraGrid) radnika.OdabraniRadnici;
                if (odabraniRadnici != null)
                {
                    int num3 = odabraniRadnici.Rows.Count - 1;
                    int num2 = 0;
                    while (num2 <= num3)
                    {
                        if (Operators.ConditionalCompareObjectEqual(odabraniRadnici.Rows[num2].Cells["oznacen"].Value, true, false))
                        {
                            num++;
                        }
                        num2++;
                    }
                    if (num == 0)
                    {
                        Interaction.MsgBox("Nema označenih radnika", MsgBoxStyle.OkOnly, null);
                    }
                    else
                    {
                        this.Cursor = Cursors.Default;
                        this.CurrencyManager = (CurrencyManager) this.BindingContext[this.DdobracunDataSet1, "ddOBRACUNRADNICI"];
                        this.CurrencyManager.PositionChanged += new EventHandler(this.CurrencyManager_PositionChanged);
                        this.CurrencyManager_PositionChanged(null, null);
                        this.__ddisablePromjenuPozicije = true;
                        int num4 = odabraniRadnici.Rows.Count - 1;
                        for (num2 = 0; num2 <= num4; num2++)
                        {
                            if (Operators.ConditionalCompareObjectEqual(odabraniRadnici.Rows[num2].Cells["oznacen"].Value, true, false))
                            {
                                bool flag = false;
                                DDOBRACUNDataSet.DDOBRACUNRadniciRow row = (DDOBRACUNDataSet.DDOBRACUNRadniciRow) this.DdobracunDataSet1.DDOBRACUNRadnici.NewRow();
                                row["ddobracunidobracun"] = this.sifraobracuna;
                                row["ddidradnik"] = RuntimeHelpers.GetObjectValue(odabraniRadnici.Rows[num2].Cells["ddidradnik"].Value);
                                row["idkategorija"] = 1;
                                row["ddobracunatiprirez"] = 0;
                                row["ddobracunatipdv"] = 0;
                                row["ddsifraopcinestanovanja"] = RuntimeHelpers.GetObjectValue(odabraniRadnici.Rows[num2].Cells["opcinastanovanjaidopcine"].Value);
                                this.DdobracunDataSet1.DDOBRACUNRadnici.Rows.Add(row);
                                if (flag)
                                {
                                    this.BindingContext[this.DdobracunDataSet1, "ddOBRACUNradnici"].Position = this.BindingContext[this.DdobracunDataSet1, "ddOBRACUNradnici"].Count;
                                    DataRowView current = (DataRowView) this.BindingContext[this.DdobracunDataSet1, "ddOBRACUNradnici"].Current;
                                }
                            }
                        }
                        this.__ddisablePromjenuPozicije = false;
                        this.CurrencyManager_PositionChanged(null, null);
                        this.Cursor = Cursors.Default;
                    }
                }
            }
        }

        private void PerformingActions(object sender, ProgressChangedEventArgs e)
        {
        }

        private void PlatnaListaDD_Na_Ekran(DataRowView DRV, bool threadoperacija = false)
        {
            DataRow current;
            decimal num5 = 0;
            decimal num8 = 0;
            decimal num9 = 0;
            decimal num10 = 0;
            decimal num11 = 0;
            IEnumerator enumerator = null;
            IEnumerator enumerator2 = null;
            IEnumerator enumerator3 = null;
            IEnumerator enumerator4 = null;
            IEnumerator enumerator5 = null;
            IEnumerator enumerator6 = null;
            this.DsRekapitulacija1.dtRekap.Clear();
            DataRow row2 = this.DsRekapitulacija1.dtRekap.NewRow();
            row2["opis"] = this.Aktivna_Osoba_Prezime_Ime();
            this.DsRekapitulacija1.dtRekap.Rows.Add(row2);
            decimal num = this.SumaBrutoDrugogDohotka(RuntimeHelpers.GetObjectValue(DRV["ddidradnik"]));
            decimal num7 = num;
            row2 = this.DsRekapitulacija1.dtRekap.NewRow();
            row2["opis"] = Operators.ConcatenateObject("Kategorija:", DRV["nazivkategorija"]);
            this.DsRekapitulacija1.dtRekap.Rows.Add(row2);
            try
            {
                enumerator = this.DdobracunDataSet1.DDOBRACUNRadniciVrstePosla.Rows.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    current = (DataRow) enumerator.Current;
                    if (Operators.ConditionalCompareObjectEqual(current["ddidradnik"], DRV["ddidradnik"], false))
                    {
                        row2 = this.DsRekapitulacija1.dtRekap.NewRow();
                        row2["opis"] = Operators.ConcatenateObject(" > ", current["ddnazivvrstaposla"]);
                        row2["iznos"] = string.Format("{0:#,##0.00}", RuntimeHelpers.GetObjectValue(current["ddiznos"]));
                        row2["sifraelementa"] = RuntimeHelpers.GetObjectValue(current["ddidvrstaposla"]);
                        row2["brojsati"] = string.Format("{0:#,##0.00}", RuntimeHelpers.GetObjectValue(current["ddsati"]));
                        this.DsRekapitulacija1.dtRekap.Rows.Add(row2);
                        num8 = Conversions.ToDecimal(Operators.AddObject(num8, row2["iznos"]));
                        num9 = Conversions.ToDecimal(Operators.AddObject(num9, row2["brojsati"]));
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
            row2 = this.DsRekapitulacija1.dtRekap.NewRow();
            row2["opis"] = "Ukupno bruto primanja";
            row2["iznos"] = string.Format("{0:#,##0.00}", num8);
            row2["brojsati"] = string.Format("{0:#,##0.00}", num9);
            this.DsRekapitulacija1.dtRekap.Rows.Add(row2);
            try
            {
                enumerator2 = this.DdobracunDataSet1.DDOBRACUNRadniciIzdaci.Rows.GetEnumerator();
                while (enumerator2.MoveNext())
                {
                    current = (DataRow) enumerator2.Current;
                    if (Operators.ConditionalCompareObjectEqual(current["ddidradnik"], DRV["ddidradnik"], false))
                    {
                        row2 = this.DsRekapitulacija1.dtRekap.NewRow();
                        row2["opis"] = Operators.ConcatenateObject(" > ", current["DDNAZIVIZDATKA"]);
                        row2["iznos"] = string.Format("{0:#,##0.00}", RuntimeHelpers.GetObjectValue(current["ddobracunatiIZDATAK"]));
                        this.DsRekapitulacija1.dtRekap.Rows.Add(row2);
                        num8 = Conversions.ToDecimal(Operators.SubtractObject(num8, current["ddobracunatiIZDATAK"]));
                        num5 = Conversions.ToDecimal(Operators.AddObject(num5, current["ddobracunatiIZDATAK"]));
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
            row2 = this.DsRekapitulacija1.dtRekap.NewRow();
            row2["opis"] = "Doprinosi iz plaće";
            row2["iznos"] = "";
            this.DsRekapitulacija1.dtRekap.Rows.Add(row2);
            decimal left = num;
            try
            {
                enumerator3 = this.DdobracunDataSet1.DDOBRACUNRadniciDoprinosi.Rows.GetEnumerator();
                while (enumerator3.MoveNext())
                {
                    current = (DataRow) enumerator3.Current;
                    if (Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectEqual(current["ddidradnik"], DRV["ddidradnik"], false), Operators.CompareObjectEqual(current["idvrstadoprinos"], 2, false))))
                    {
                        decimal num3 = 0;
                        row2 = this.DsRekapitulacija1.dtRekap.NewRow();
                        row2["opis"] = Operators.ConcatenateObject(" > ", current["nazivdoprinos"]);
                        row2["iznos"] = string.Format("{0:#,##0.00}", RuntimeHelpers.GetObjectValue(current["ddobracunatidoprinos"]));
                        this.DsRekapitulacija1.dtRekap.Rows.Add(row2);
                        left = Conversions.ToDecimal(Operators.SubtractObject(left, current["ddobracunatidoprinos"]));
                        num3 = Conversions.ToDecimal(Operators.AddObject(num3, current["ddobracunatidoprinos"]));
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
            row2 = this.DsRekapitulacija1.dtRekap.NewRow();
            row2["opis"] = "Porezna osnovica";
            row2["iznos"] = string.Format("{0:#,##0.00}", decimal.Subtract(left, num5));
            this.DsRekapitulacija1.dtRekap.Rows.Add(row2);
            try
            {
                enumerator4 = this.DdobracunDataSet1.DDOBRACUNRadniciPorezi.Rows.GetEnumerator();
                while (enumerator4.MoveNext())
                {
                    current = (DataRow) enumerator4.Current;
                    if (Operators.ConditionalCompareObjectEqual(current["ddidradnik"], DRV["ddidradnik"], false))
                    {
                        row2 = this.DsRekapitulacija1.dtRekap.NewRow();
                        row2["opis"] = Operators.ConcatenateObject(" > ", current["nazivporez"]);
                        row2["iznos"] = string.Format("{0:#,##0.00}", RuntimeHelpers.GetObjectValue(current["ddobracunatiporez"]));
                        this.DsRekapitulacija1.dtRekap.Rows.Add(row2);
                        num11 = Conversions.ToDecimal(Operators.AddObject(num11, current["ddobracunatiporez"]));
                    }
                }
            }
            finally
            {
                if (enumerator4 is IDisposable)
                {
                    (enumerator4 as IDisposable).Dispose();
                }
            }
            row2 = this.DsRekapitulacija1.dtRekap.NewRow();
            row2["opis"] = "Ukupno porez";
            row2["iznos"] = string.Format("{0:#,##0.00}", num11);
            this.DsRekapitulacija1.dtRekap.Rows.Add(row2);
            decimal num12 = Conversions.ToDecimal(this.DdobracunDataSet1.DDOBRACUNRadnici.Compute("Sum(ddobracunatiprirez)", Conversions.ToString(Operators.ConcatenateObject("ddidradnik=  ", DRV["ddidradnik"]))));
            row2 = this.DsRekapitulacija1.dtRekap.NewRow();
            row2["opis"] = "Prirez";
            row2["iznos"] = string.Format("{0:#,##0.00}", num12);
            this.DsRekapitulacija1.dtRekap.Rows.Add(row2);
            row2 = this.DsRekapitulacija1.dtRekap.NewRow();
            row2["opis"] = "Ukupno porez i prirez";
            row2["iznos"] = string.Format("{0:#,##0.00}", decimal.Add(num12, num11));
            this.DsRekapitulacija1.dtRekap.Rows.Add(row2);
            row2 = this.DsRekapitulacija1.dtRekap.NewRow();
            row2["opis"] = "Neto";
            row2["iznos"] = string.Format("{0:#,##0.00}", decimal.Subtract(decimal.Subtract(left, num12), num11));
            this.DsRekapitulacija1.dtRekap.Rows.Add(row2);
            try
            {
                enumerator5 = this.DdobracunDataSet1.DDOBRACUNRadniciDDKrizniPorez.Rows.GetEnumerator();
                while (enumerator5.MoveNext())
                {
                    current = (DataRow) enumerator5.Current;
                    if (Operators.ConditionalCompareObjectEqual(current["DDidradnik"], DRV["DDidradnik"], false))
                    {
                        num10 = Conversions.ToDecimal(Operators.AddObject(num10, current["DDporezkrizni"]));
                    }
                }
            }
            finally
            {
                if (enumerator5 is IDisposable)
                {
                    (enumerator5 as IDisposable).Dispose();
                }
            }
            if (decimal.Compare(num10, decimal.Zero) > 0)
            {
                row2 = this.DsRekapitulacija1.dtRekap.NewRow();
                row2["opis"] = "Pos.por.na net.plaće";
                row2["iznos"] = string.Format("{0:#,##0.00}", num10);
                this.DsRekapitulacija1.dtRekap.Rows.Add(row2);
                row2 = this.DsRekapitulacija1.dtRekap.NewRow();
                row2["opis"] = "Neto umanjen za pos.por:";
                row2["iznos"] = string.Format("{0:#,##0.00}", decimal.Subtract(decimal.Subtract(decimal.Subtract(left, num12), num11), num10));
                this.DsRekapitulacija1.dtRekap.Rows.Add(row2);
            }
            decimal num6 = Conversions.ToDecimal(this.DdobracunDataSet1.DDOBRACUNRadnici.Compute("Sum(ddobracunatipdv)", Conversions.ToString(Operators.ConcatenateObject("ddidradnik=  ", DRV["ddidradnik"]))));
            row2 = this.DsRekapitulacija1.dtRekap.NewRow();
            row2["opis"] = "PDV %";
            row2["iznos"] = string.Format("{0:#,##0.00}", num6);
            this.DsRekapitulacija1.dtRekap.Rows.Add(row2);
            row2 = this.DsRekapitulacija1.dtRekap.NewRow();
            row2["opis"] = "Neto-pos.por + PDV";
            row2["iznos"] = string.Format("{0:#,##0.00}", decimal.Add(decimal.Subtract(decimal.Subtract(decimal.Subtract(left, num12), num11), num10), num6));
            this.DsRekapitulacija1.dtRekap.Rows.Add(row2);
            try
            {
                enumerator6 = this.DdobracunDataSet1.DDOBRACUNRadniciDoprinosi.Rows.GetEnumerator();
                while (enumerator6.MoveNext())
                {
                    current = (DataRow) enumerator6.Current;
                    if (Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectEqual(current["ddidradnik"], DRV["ddidradnik"], false), Operators.CompareObjectEqual(current["idvrstadoprinos"], 1, false))))
                    {
                        decimal num4 = 0;
                        row2 = this.DsRekapitulacija1.dtRekap.NewRow();
                        row2["opis"] = Operators.ConcatenateObject(" > ", current["nazivdoprinos"]);
                        row2["iznos"] = string.Format("{0:#,##0.00}", RuntimeHelpers.GetObjectValue(current["ddobracunatidoprinos"]));
                        this.DsRekapitulacija1.dtRekap.Rows.Add(row2);
                        num4 = Conversions.ToDecimal(Operators.AddObject(num4, current["ddobracunatidoprinos"]));
                    }
                }
            }
            finally
            {
                if (enumerator6 is IDisposable)
                {
                    (enumerator6 as IDisposable).Dispose();
                }
            }
        }

        private void PocistiObracunatoDrugiDohodak(string sifraobr, int sifraradnika)
        {
            SqlCommand command = new SqlCommand();
            SqlConnection connection = new SqlConnection {
                ConnectionString = Configuration.ConnectionString
            };
            connection.Open();
            DataView defaultView = this.DdobracunDataSet1.DDOBRACUNRadniciDDKrizniPorez.DefaultView;
            defaultView.RowFilter = "DDidradnik= " + Conversions.ToString(sifraradnika);
            for (int i = defaultView.Count - 1; i >= 0; i += -1)
            {
                defaultView.Table.Rows.Remove(defaultView[i].Row);
            }
            defaultView = this.DdobracunDataSet1.DDOBRACUNRadniciPorezi.DefaultView;
            defaultView.RowFilter = "ddidradnik= " + Conversions.ToString(sifraradnika);
            for (int j = defaultView.Count - 1; j >= 0; j += -1)
            {
                defaultView.Table.Rows.Remove(defaultView[j].Row);
            }
            defaultView = this.DdobracunDataSet1.DDOBRACUNRadniciDoprinosi.DefaultView;
            defaultView.RowFilter = "ddidradnik= " + Conversions.ToString(sifraradnika);
            for (int k = defaultView.Count - 1; k >= 0; k += -1)
            {
                defaultView.Table.Rows.Remove(defaultView[k].Row);
            }
            defaultView = this.DdobracunDataSet1.DDOBRACUNRadniciIzdaci.DefaultView;
            defaultView.RowFilter = "ddidradnik= " + Conversions.ToString(sifraradnika);
            for (int m = defaultView.Count - 1; m >= 0; m += -1)
            {
                defaultView.Table.Rows.Remove(defaultView[m].Row);
            }
            SqlParameter[] parameterArray = new SqlParameter[2];
            parameterArray[0] = new SqlParameter("@IDOBRACUN", SqlDbType.VarChar, 11);
            parameterArray[0].Value = this.sifraobracuna;
            parameterArray[1] = new SqlParameter("@IDradnik", SqlDbType.Int);
            parameterArray[1].Value = sifraradnika;
            DataSet set = new DataSet();
            SqlCommand command2 = new SqlCommand {
                CommandType = CommandType.StoredProcedure,
                CommandText = "S_DD_POCISTIRADNIKA"
            };
            command2.Parameters.Add(parameterArray[0]);
            command2.Parameters.Add(parameterArray[1]);
            command2.Connection = connection;
            try
            {
                command2.ExecuteNonQuery();
            }
            catch (System.Exception exception1)
            {
                throw exception1;
                
                //this.Cursor = Cursors.Default;
            }
            connection.Close();
        }

        public void Podaci_O_Zadnjem_Obracunu()
        {
            SqlConnection connection = new SqlConnection();
            SqlCommand command = new SqlCommand();
            connection.ConnectionString = Configuration.ConnectionString;
            command.Connection = connection;
            command.CommandText = "select max(idobracun) from obracun";
            connection.Open();
            try
            {
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                if (!reader.IsDBNull(0))
                {
                    OBRACUNDataAdapter adapter = new OBRACUNDataAdapter();
                    OBRACUNDataSet set = new OBRACUNDataSet();
                }
                else
                {
                    this.txtOpisObracunaDD = "";
                }
            }
            catch (System.Exception exception1)
            {
                throw exception1;
                
                
                
            }
            connection.Close();
        }

        private void Pokreni_Zbirni_Izracun_DD(bool bForsirajObracun = false)
        {
            DataRowView current;
            if (this.moguceispravke && (this.DdobracunDataSet1.HasChanges() | bForsirajObracun))
            {
                current = (DataRowView) this.CurrencyManager.Current;
                this.Izracun_Drugog_Dohotka(this.DdobracunDataSet1, current);
            }
            this.DAOBRACUN.Update(this.DdobracunDataSet1);
            current = (DataRowView) this.CurrencyManager.Current;
            this.PlatnaListaDD_Na_Ekran(current, false);
        }

        public void PregledObracuna()
        {
            frmPregledObracuna obracuna = new frmPregledObracuna();
            obracuna.ShowDialog();
            if (obracuna.DialogResult != DialogResult.Cancel)
            {
                if (obracuna.OdabraniObracun != null)
                {
                    if (Operators.ConditionalCompareObjectEqual(obracuna.OdabraniObracun, this.Dohvati_Podatke_O_Zadnjem_ObracunuDD(Conversions.ToString(obracuna.OdabraniObracun)), false))
                    {
                        this.moguceispravke = true;
                    }
                    else
                    {
                        this.moguceispravke = false;
                    }
                    this.__ddisablePromjenuPozicije = true;
                    this.CurrencyManager = (CurrencyManager) this.BindingContext[this.DdobracunDataSet1, "ddOBRACUNradnici"];
                    this.DdobracunDataSet1.Clear();
                    this.DAOBRACUN.FillByDDOBRACUNIDOBRACUN(this.DdobracunDataSet1, Conversions.ToString(obracuna.OdabraniObracun));
                    if (this.DdobracunDataSet1.DDOBRACUNRadniciDDKrizniPorez.Rows.Count > 0)
                    {
                        this.onemoguci_posebni = true;
                        this.obracunavakrizni = true;
                        this.onemoguci_posebni = false;
                    }
                    this.ultraSifraObracuna.Text = Conversions.ToString(this.DdobracunDataSet1.DDOBRACUN.Rows[0]["DDOBRACUNidobracun"]);
                    this.sifraobracuna = Conversions.ToString(this.DdobracunDataSet1.DDOBRACUN.Rows[0]["DDOBRACUNidobracun"]);
                    this.datumobracuna = Conversions.ToDate(this.DdobracunDataSet1.DDOBRACUN.Rows[0]["DDDATUMOBRACUNA"]);
                    this.txtOpisObracunaDD = Conversions.ToString(this.DdobracunDataSet1.DDOBRACUN.Rows[0]["DDOPISOBRACUN"]);
                    this.ListBox1.Items.Clear();
                    this.ListBox1.Items.Add(" ");
                    this.ListBox1.Items.Add("Šifra obračuna:" + this.sifraobracuna);
                    this.ListBox1.Items.Add("Datum obračuna staža:" + Conversions.ToString(this.datumobracuna));
                    this.ListBox1.Items.Add("Opis obračuna --->>>" + this.txtOpisObracunaDD);
                    this.__ddisablePromjenuPozicije = false;
                    this.CurrencyManager_PositionChanged(null, null);
                    this.UltraGrid1.Select();
                    this.Puni_KRIZNI_NETO(Conversions.ToString(obracuna.OdabraniObracun), obracuna.OdabraniObracun.ToString().Substring(5, 2), obracuna.OdabraniObracun.ToString().Substring(0, 4));
                }
                this.BrojOsobaUObracunu();
            }
        }

        public void Puni_KRIZNI_NETO(string sifraobr, string MJESECISPLATE, string GODINAISPLATE)
        {
            S_DD_KRIZNI_POREZDataAdapter adapter = new S_DD_KRIZNI_POREZDataAdapter();
            this.DSKRIZNI.S_DD_KRIZNI_POREZ.Clear();
            adapter.Fill(this.DSKRIZNI, sifraobr, MJESECISPLATE, GODINAISPLATE);
        }

        [LocalCommandHandler("Rekapitulacija")]
        public void Rekap(object sender, EventArgs e)
        {
            if (this.sifraobracuna == "")
            {
                Interaction.MsgBox("Trenutno nema otvorenog obračuna!", MsgBoxStyle.Information, "Drugi dohodak");
            }
            else
            {
                this.Save_DD_To_Database();
                ExtendedWindowSmartPartInfo info = new ExtendedWindowSmartPartInfo {
                    StartPosition = FormStartPosition.CenterParent,
                    Modal = true,
                    Title = "Rekapitulacija obračuna",
                    Description = "Rekapitulacija obračuna",
                    Icon = ImageResourcesNew.mbs
                };
                ExtendedWindowWorkspace workspace = new ExtendedWindowWorkspace();
                KratkaRekapWorkItem item = this.Controller.WorkItem.Items.Get<KratkaRekapWorkItem>("Pregled");
                if (item == null)
                {
                    item = this.Controller.WorkItem.Items.AddNew<KratkaRekapWorkItem>("Pregled");
                }
                item.Obracun = Conversions.ToString(this.DdobracunDataSet1.DDOBRACUN.Rows[0]["ddobracunidobracun"]);
                item.opisobracuna = DB.N2T(this.txtOpisObracunaDD, "");
                item.Show(item.Workspaces["main"], info);
            }
        }

        [CommandHandler("RSMCommand")]
        public void RSMCommandHandler(object sender, EventArgs e)
        {
            if (this.sifraobracuna == "")
            {
                Interaction.MsgBox("Trenutno nema otvorenog obračuna!", MsgBoxStyle.Information, "Drugi dohodak");
            }
            else
            {
                ExtendedWindowWorkspace workspace = new ExtendedWindowWorkspace();
                RSMObrazacWorkItem item = this.Controller.WorkItem.Items.Get<RSMObrazacWorkItem>("RSMA");
                if (item == null)
                {
                    item = this.Controller.WorkItem.Items.AddNew<RSMObrazacWorkItem>("RSMA");
                }
                item.Show(item.Workspaces["main"]);
            }
        }
        
        public void Save_DD_To_Database()
        {
            try
            {
                this.DAOBRACUN.Update(this.DdobracunDataSet1);
            }
            catch (System.Exception exception1)
            {
                throw exception1;
            }
        }

        [LocalCommandHandler("OtvoriPostojeci")]
        public void StalnaZaduzenjaHandler(object sender, EventArgs e)
        {
            this.PregledObracuna();
        }

        public decimal SumaBrutoDrugogDohotka(object sifraradnika)
        {
            return DB.N20(RuntimeHelpers.GetObjectValue(this.dvVrstePosla.Table.Compute("SUM(ddiznos)", Conversions.ToString(Operators.ConcatenateObject("ddidradnik=  ", sifraradnika)))));
        }

        private void Ukloni_Oznake_Svim_Osobama()
        {
            int num2 = this.UltraGrid1.Rows.Count - 1;
            for (int i = 0; i <= num2; i++)
            {
                this.UltraGrid1.Rows[i].Cells["oznacen"].Value = false;
            }
            try
            {
                this.BindingContext[this.DdobracunDataSet1.DDOBRACUNRadnici].EndCurrentEdit();
            }
            catch (System.Exception exception1)
            {
                throw exception1;   
            }
        }

        private void UkupnoKriznog_i_neto(int sifraradnika, string sifraobr, ref decimal decNetoPlaca, ref decimal decObracunatiKrizni)
        {
            decNetoPlaca = new decimal();
            decObracunatiKrizni = new decimal();
            DataRow[] rowArray = this.DSKRIZNI.S_DD_KRIZNI_POREZ.Select("DDIDRADNIK = " + Conversions.ToString(sifraradnika));
            if (rowArray.Length > 0)
            {
                decNetoPlaca = Conversions.ToDecimal(rowArray[0]["netoplaca"]);
                decObracunatiKrizni = Conversions.ToDecimal(rowArray[0]["porezkrizni"]);
            }
            else
            {
                decNetoPlaca = new decimal();
                decObracunatiKrizni = new decimal();
            }
        }

        private void UltraCheckEditor3_CheckedChanged_1(object sender, EventArgs e)
        {
            if (!Conversions.ToBoolean(this.onemoguci_posebni))
            {
                this.obracunavakrizni = !this.obracunavakrizni;
                if (this.obracunavakrizni)
                {
                }
                this.Drugi_Dohodak_Izracunaj_Za_Sve();
            }
        }

        private void UltraDropDown1_AfterCloseUp(object sender, DropDownEventArgs e)
        {
            CurrencyManager manager = (CurrencyManager) this.BindingContext[this.DdobracunDataSet1, "DDOBRACUNRadnici"];
            DataRowView current = (DataRowView) manager.Current;
            current["idkategorija"] = RuntimeHelpers.GetObjectValue(this.UltraDropDown1.SelectedRow.Cells["idkategorija"].Value);
            this.BindingContext[this.DdobracunDataSet1, "DDOBRACUNRadnici"].EndCurrentEdit();
            this.Pokreni_Zbirni_Izracun_DD(true);
        }

        private void UltraFormattedLinkLabel1_EditorButtonClick1(object sender, EditorButtonEventArgs e)
        {
            if ((e.Button.Key == "DodajB") && (this.Broj_Oznacenih_Osoba() == 0))
            {
                this.UnosVrstePosla();
            }
            if (e.Button.Key == "IzmjeniB")
            {
                this.IzmjenaVrstePosla();
            }
            if ((e.Button.Key == "BrisiB") && (this.Broj_Oznacenih_Osoba() <= 1))
            {
                this.BrisanjeVrstePosla();
            }
        }

        private void UltraFormattedLinkLabel3_EditorButtonClick(object sender, EditorButtonEventArgs e)
        {
            if (e.Button.Key == "Oznaci")
            {
                this.Oznaci_Sve_Osobe();
            }
            if (e.Button.Key == "Ukloni")
            {
                this.Ukloni_Oznake_Svim_Osobama();
            }
        }

        private void UltraGrid1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                UltraGridRow context = null;
                UIElement element = null;
                UltraGridCell cell = null;

                element = this.UltraGrid1.DisplayLayout.UIElement.ElementFromPoint(e.Location);
                context = (UltraGridRow)element.GetContext(typeof(UltraGridRow));
                cell = (UltraGridCell)element.GetContext(typeof(UltraGridCell));

                if (((context != null && cell != null) && context.IsDataRow) && (cell.Column.Key == "oznacen"))
                {
                    context.Selected = true;
                    context.Cells["oznacen"].Value = Operators.NotObject(context.Cells["oznacen"].Value);
                }

                if (this.CurrencyManager.Count > 0)
                {
                    DataRowView current = (DataRowView)this.CurrencyManager.Current;
                    this.PlatnaListaDD_Na_Ekran(current, false);
                }
            }
        }

        private void UltraGrid2_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            this.IzmjenaVrstePosla();
        }

        private void UltraGrid2_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            if (e.Row.Index == 0)
            {
                e.Row.Appearance.FontData.Bold = DefaultableBoolean.True;
                e.Row.Appearance.FontData.SizeInPoints = 10;
            }

            if (Operators.ConditionalCompareObjectEqual(e.Row.Cells["opis"].Value, "Ukupno bruto primanja", false))
            {
                e.Row.Appearance.FontData.Bold = DefaultableBoolean.True;
            }
            if (Operators.ConditionalCompareObjectEqual(e.Row.Cells["opis"].Value, "Neto plaća", false))
            {
                e.Row.Appearance.FontData.Bold = DefaultableBoolean.True;
            }
            if (Operators.ConditionalCompareObjectEqual(e.Row.Cells["opis"].Value, "Neto primanja", false))
            {
                e.Row.Appearance.FontData.Bold = DefaultableBoolean.True;
            }
            if (Operators.ConditionalCompareObjectEqual(e.Row.Cells["opis"].Value, "ZA ISPLATU", false))
            {
                e.Row.Appearance.FontData.Bold = DefaultableBoolean.True;
            }
        }

        private void UltraToolbarsManager1_ToolClick(object sender, ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "Oznaci":
                    this.Oznaci_Sve_Osobe();
                    break;

                case "UkloniOznake":
                    this.Ukloni_Oznake_Svim_Osobama();
                    break;

                case "DodajBruto":
                    this.UnosVrstePosla();
                    break;

                case "IzmjeniBruto":
                    this.IzmjenaVrstePosla();
                    break;

                case "BrisiBruto":
                    this.BrisanjeVrstePosla();
                    break;
            }
        }

        private void UnosVrstePosla()
        {
            if (this.MoguceMijenjatiObracun())
            {
                frmUnosVrstePosla posla = new frmUnosVrstePosla {
                    ___ParentForm = this,
                    Text = "Unesi vrstu posla na trenutnoj osobi (" + Conversions.ToString(this.AktivnaOsobaDD()) + " - " + this.Aktivna_Osoba_Prezime_Ime() + ")"
                };
                posla.lblSifEle.Text = "Vrsta posla:";
                posla._dv = this.dvVrstePosla;
                this.BindingContext[posla._dv].AddNew();
                NewLateBinding.LateIndexSetComplex(this.BindingContext[posla._dv].Current, new object[] { "DDOBRACUNIDOBRACUN", this.sifraobracuna }, null, false, true);
                NewLateBinding.LateIndexSetComplex(this.BindingContext[posla._dv].Current, new object[] { "DDIDRADNIK", RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(this.CurrencyManager.Current, new object[] { "DDIDRADNIK" }, null)) }, null, false, true);
                NewLateBinding.LateIndexSetComplex(this.BindingContext[posla._dv].Current, new object[] { "DDSATI", 0 }, null, false, true);
                NewLateBinding.LateIndexSetComplex(this.BindingContext[posla._dv].Current, new object[] { "DDSATNICA", 0 }, null, false, true);
                NewLateBinding.LateIndexSetComplex(this.BindingContext[posla._dv].Current, new object[] { "DDIZNOS", 0 }, null, false, true);
                posla._drvVrstaPosla = (DataRowView) this.BindingContext[posla._dv].Current;
                if (posla.ShowDialog() == DialogResult.OK)
                {
                    this.BindingContext[this.DdobracunDataSet1.DDOBRACUNRadniciVrstePosla].EndCurrentEdit();
                }
                posla.Dispose();
                this.Pokreni_Zbirni_Izracun_DD(true);
            }
        }

        [CommandHandler("VirmaniCommand")]
        public void VirmaniCommandHandler(object sender, EventArgs e)
        {
            if (this.sifraobracuna == "")
            {
                Interaction.MsgBox("Trenutno nema otvorenog obračuna!", MsgBoxStyle.Information, "Drugi dohodak");
            }
            else
            {
                ExtendedWindowWorkspace workspace = new ExtendedWindowWorkspace();
                VirmaniWorkItemUser user = this.Controller.WorkItem.Items.Get<VirmaniWorkItemUser>("Virmani");
                if (user == null)
                {
                    user = this.Controller.WorkItem.Items.AddNew<VirmaniWorkItemUser>("Virmani");
                }

                JOPPD.SifraJOPPDObrazac identifikator = new JOPPD.SifraJOPPDObrazac(user);
                identifikator.Show();
            }
        }

        private void Zapocni_Novi_Obracun_Drugog_Dohotka()
        {
            frmUnosPodatakaOObracunu obracunu = new frmUnosPodatakaOObracunu();
            if (obracunu.ShowDialog() == DialogResult.Cancel)
            {
                Interaction.MsgBox("Odustali ste od kreiranja obračuna!", MsgBoxStyle.Information, "Drugi dohodak");
            }
            else
            {
                frmPregledRadnika radnika = new frmPregledRadnika();
                radnika.ShowDialog();
                if (radnika.DialogResult != DialogResult.Cancel)
                {
                    int num2 = 0;
                    int num = 0;
                    UltraGrid odabraniRadnici = new UltraGrid();
                    odabraniRadnici = (UltraGrid) radnika.OdabraniRadnici;
                    int num3 = odabraniRadnici.Rows.Count - 1;
                    for (num2 = 0; num2 <= num3; num2++)
                    {
                        if (Operators.ConditionalCompareObjectEqual(odabraniRadnici.Rows[num2].Cells["oznacen"].Value, true, false))
                        {
                            num++;
                        }
                    }
                    if (num == 0)
                    {
                        Interaction.MsgBox("Nema označenih radnika", MsgBoxStyle.OkOnly, null);
                    }
                    else
                    {
                        this.datumobracuna = Convert.ToDateTime(obracunu.datumobracunastaza.Value);
                        this.txtOpisObracunaDD = obracunu.txtOpisObracuna.Text;
                        this.DefaultParametriObracunaDrugogDohotka();
                        this.Cursor = Cursors.Default;
                        this.moguceispravke = true;
                        this.CurrencyManager = (CurrencyManager) this.BindingContext[this.DdobracunDataSet1, "ddobracunradnici"];
                        this.CurrencyManager_PositionChanged(null, null);
                        this.__ddisablePromjenuPozicije = true;
                        DataRow row = this.DdobracunDataSet1.DDOBRACUN.NewRow();
                        row["dddatumobracuna"] = this.datumobracuna;
                        row["ddobracunidobracun"] = this.sifraobracuna;
                        row["ddzakljucan"] = false;
                        if (Strings.Trim(this.txtOpisObracunaDD) == "")
                        {
                            row["ddOPISOBRACUN"] = " ";
                        }
                        else
                        {
                            row["ddOPISOBRACUN"] = this.txtOpisObracunaDD;
                        }
                        this.ListBox1.Items.Clear();
                        this.ListBox1.Items.Add(" ");
                        this.ListBox1.Items.Add("Šifra obračuna:" + this.sifraobracuna);
                        this.ListBox1.Items.Add("Datum obračuna staža:" + Conversions.ToString(this.datumobracuna));
                        this.ListBox1.Items.Add("Opis obračuna --->>>" + this.txtOpisObracunaDD);
                        this.DdobracunDataSet1.DDOBRACUN.Rows.Add(row);
                        this.BindingContext[this.DdobracunDataSet1.DDOBRACUN].EndCurrentEdit();
                        int num4 = odabraniRadnici.Rows.Count - 1;
                        for (num2 = 0; num2 <= num4; num2++)
                        {
                            if (Operators.ConditionalCompareObjectEqual(odabraniRadnici.Rows[num2].Cells["oznacen"].Value, true, false))
                            {
                                DataRow row2 = this.DdobracunDataSet1.DDOBRACUNRadnici.NewRow();
                                row2["ddobracunidobracun"] = this.sifraobracuna;
                                row2["ddidradnik"] = RuntimeHelpers.GetObjectValue(odabraniRadnici.Rows[num2].Cells["ddidradnik"].Value);
                                row2["idkategorija"] = 1;
                                row2["ddobracunatiprirez"] = 0;
                                row2["ddobracunatipdv"] = 0;
                                row2["ddsifraopcinestanovanja"] = RuntimeHelpers.GetObjectValue(odabraniRadnici.Rows[num2].Cells["opcinastanovanjaidopcine"].Value);
                                this.DdobracunDataSet1.DDOBRACUNRadnici.Rows.Add(row2);
                            }
                        }
                        this.BindingContext[this.DdobracunDataSet1.DDOBRACUNRadnici].EndCurrentEdit();
                        try
                        {
                            this.DAOBRACUN.Update(this.DdobracunDataSet1);
                        }
                        catch (System.Exception exception1)
                        {
                            throw exception1;
                        }

                        this.Drugi_Dohodak_Izracunaj_Za_Sve();
                        this.__ddisablePromjenuPozicije = false;
                        this.CurrencyManager_PositionChanged(null, null);
                        this.Cursor = Cursors.Default;
                        this.Puni_KRIZNI_NETO(this.sifraobracuna, this.sifraobracuna.ToString().Substring(5, 2), this.sifraobracuna.ToString().Substring(0, 4));
                    }
                }
            }
        }

        [LocalCommandHandler("ZapocniNovi")]
        public void ZapocniNoviHandler(object sender, EventArgs e)
        {
            if (this.DdobracunDataSet1.DDOBRACUN.Rows.Count == 0)
            {
                this.Zapocni_Novi_Obracun_Drugog_Dohotka();
            }
            else if (Interaction.MsgBox("Trenutno je otvoren obračun " + this.sifraobracuna + " želite li otvoriti novi obračun???", MsgBoxStyle.YesNo, null) == MsgBoxResult.Yes)
            {
                this.ListBox1.Items.Clear();
                this.__ddisablePromjenuPozicije = true;
                this.DdobracunDataSet1.DDOBRACUNRadniciDDKrizniPorez.Clear();
                this.DdobracunDataSet1.DDOBRACUNRadniciPorezi.Clear();
                this.DdobracunDataSet1.DDOBRACUNRadniciIzdaci.Clear();
                this.DdobracunDataSet1.DDOBRACUNRadniciDoprinosi.Clear();
                this.DdobracunDataSet1.DDOBRACUNRadniciVrstePosla.Clear();
                this.DdobracunDataSet1.DDOBRACUNRadnici.Clear();
                this.DdobracunDataSet1.DDOBRACUN.Clear();
                this.__ddisablePromjenuPozicije = false;
                this.Zapocni_Novi_Obracun_Drugog_Dohotka();
            }
        }

        public void ZapocniPonovo()
        {
            this.moguceispravke = false;
            this.Podaci_O_Zadnjem_Obracunu();
            this.sifraobracuna = "";
            this.DsRekapitulacija1.Clear();
            this.DdobracunDataSet1.Clear();
            this.datumobracuna = DateAndTime.Today;
        }

        private CurrencyManager CurrencyManager;

        private AutoHideControl _ObracunDDSmartPartAutoHideControl;

        private UnpinnedTabArea _ObracunDDSmartPartUnpinnedTabAreaBottom;

        private UnpinnedTabArea _ObracunDDSmartPartUnpinnedTabAreaLeft;

        private UnpinnedTabArea _ObracunDDSmartPartUnpinnedTabAreaRight;

        private UnpinnedTabArea _ObracunDDSmartPartUnpinnedTabAreaTop;

        private UltraToolbarsDockArea _Panel2_Toolbars_Dock_Area_Bottom;

        private UltraToolbarsDockArea _Panel2_Toolbars_Dock_Area_Left;

        private UltraToolbarsDockArea _Panel2_Toolbars_Dock_Area_Right;

        private UltraToolbarsDockArea _Panel2_Toolbars_Dock_Area_Top;

        private BackgroundWorker BackgroundWorker1;

        [CreateNew]
        public ObracunControler Controller { get; set; }

        private DDKATEGORIJADataSet DdkategorijaDataSet1;

        private DDOBRACUNDataSet DdobracunDataSet1;

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

        private DockableWindow DockableWindow1;

        private DockableWindow DockableWindow2;

        private datasetRekapitulacijaEkran DsRekapitulacija1;

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

        private GroupBox GroupBox1;

        private ListBox ListBox1;

        private Panel Panel1;

        private Panel Panel2;

        public DataRow SelectedRow
        {
            get
            {
                DataRow row = null;
                return row;
            }
        }

        private UltraDesktopAlert UltraDesktopAlert1;

        private UltraDockManager UltraDockManager1;

        private UltraDropDown UltraDropDown1;

        private UltraGrid UltraGrid1;

        private UltraGrid UltraGrid2;

        private UltraTextEditor ultraSifraObracuna;

        private UltraToolbarsDockArea UltraToolbarsDockArea2;

        private UltraToolbarsDockArea UltraToolbarsDockArea3;

        private UltraToolbarsDockArea UltraToolbarsDockArea4;

        private UltraToolbarsManager UltraToolbarsManager1;

        private UltraToolTipManager UltraToolTipManager1;

        private WindowDockingArea WindowDockingArea1;

        private WindowDockingArea WindowDockingArea2;

        Deklarit.Practices.CompositeUI.WorkWithMode WorkWithMode
        {
            set
            {
            }
        }
    }
}


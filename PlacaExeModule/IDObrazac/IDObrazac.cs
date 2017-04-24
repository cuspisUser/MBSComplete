using CrystalDecisions.CrystalReports.Engine;
using Deklarit.Practices.CompositeUI;
using Deklarit.Practices.CompositeUI.Workspaces;
using Hlp;
using Infragistics.Win;
using Infragistics.Win.Misc;
using Infragistics.Win.UltraWinDock;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinMaskedEdit;
using Infragistics.Win.UltraWinTabControl;
using Infragistics.Win.UltraWinTabs;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.SmartParts;
using Microsoft.Practices.ObjectBuilder;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using NetAdvantage.Controllers;
using NetAdvantage.WorkItems;
using Placa;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Xml.Serialization;


namespace IDObrazacNamespace
{
    [SmartPart]
    public class IDObrazac : UserControl, ISmartPartInfoProvider, IFilteredView
    {
        private IContainer components;
        private sp_id_detaljiDataAdapter detalji;
        private sp_id_detaljiDataSet DSDETALJI;
        private sp_id_zaglavljeDataSet DSZAGLAVLJE;
        private SmartPartInfoProvider infoProvider;
        private SmartPartInfo smartPartInfo1;
        private string strMI = string.Empty;
        private string strGI = string.Empty;
        private string strSifraObracuna = string.Empty;
        private sp_id_zaglavljeDataAdapter ZAGLAVLJE;

        public IDObrazac()
        {
            base.Load += new EventHandler(this.IDObrazac_Load);
            this.strMI = null;
            this.strGI = null;
            this.strSifraObracuna = null;
            this.detalji = new sp_id_detaljiDataAdapter();
            this.ZAGLAVLJE = new sp_id_zaglavljeDataAdapter();
            this.DSDETALJI = new sp_id_detaljiDataSet();
            this.DSZAGLAVLJE = new sp_id_zaglavljeDataSet();
            this.smartPartInfo1 = new SmartPartInfo("ID Obrazac", "IDObrazac");
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);
            this.InitializeComponent();
        }

        public void Eletronicki_Obrazac()
        {
            decimal num = 0;
            decimal num2 = 0;
            sPorezIprirezPremaOpciniGraduObracunatiPorez[] porezArray = null;
            decimal num3 = 0;
            KORISNIKDataAdapter adapter = new KORISNIKDataAdapter();
            KORISNIKDataSet dataSet = new KORISNIKDataSet();
            adapter.Fill(dataSet);
            sObrazacID o = new sObrazacID();
            sIDmetapodaci dmetapodaci = new sIDmetapodaci();
            sNaslovTemeljni temeljni7 = new sNaslovTemeljni();
            sAutorTemeljni temeljni2 = new sAutorTemeljni();
            sDatumTemeljni temeljni3 = new sDatumTemeljni();
            sFormatTemeljni temeljni4 = new sFormatTemeljni();
            sJezikTemeljni temeljni6 = new sJezikTemeljni();
            sIdentifikatorTemeljni temeljni5 = new sIdentifikatorTemeljni();
            sUskladjenost uskladjenost = new sUskladjenost();
            sTipTemeljni temeljni8 = new sTipTemeljni();
            sAdresantTemeljni temeljni = new sAdresantTemeljni();
            temeljni7.Value = "ID obrazac";
            temeljni7.dc = "http://purl.org/dc/elements/1.1/title";
            temeljni2.Value = "VugerGRAD d.o.o.";
            temeljni2.dc = "http://purl.org/dc/elements/1.1/creator";
            temeljni3.Value = DateAndTime.Now.ToString("s");
            temeljni3.dc = "http://purl.org/dc/elements/1.1/date";
            temeljni4.Value = PlacaExe.tFormat.textxml;
            temeljni4.dc = "http://purl.org/dc/elements/1.1/format";
            temeljni6.Value = PlacaExe.tJezik.hrHR;
            temeljni6.dc = "http://purl.org/dc/elements/1.1/language";

            temeljni5.Value = Guid.NewGuid().ToString(); //"dc0e2097-c43b-41f3-a095-dcf327268fad";
            temeljni5.dc = "http://purl.org/dc/elements/1.1/identifier";

            uskladjenost.Value = "ObrazacID-v3-0";
            uskladjenost.dc = "http://purl.org/dc/terms/conformsTo";
            temeljni8.Value = PlacaExe.tTip.Elektroničkiobrazac;
            temeljni8.dc = "http://purl.org/dc/elements/1.1/type";
            temeljni.Value = "Ministarstvo Financija, Porezna uprava, Zagreb";
            dmetapodaci.Naslov = temeljni7;
            dmetapodaci.Autor = temeljni2;
            dmetapodaci.Datum = temeljni3;
            dmetapodaci.Format = temeljni4;
            dmetapodaci.Jezik = temeljni6;
            dmetapodaci.Identifikator = temeljni5;
            dmetapodaci.Uskladjenost = uskladjenost;
            dmetapodaci.Tip = temeljni8;
            dmetapodaci.Adresant = temeljni;
            o.verzijaSheme = "3.0";
            o.Metapodaci = dmetapodaci;
            sZaglavlje zaglavlje = new sZaglavlje();
            sZaglavljePodnositeljZahtjeva zahtjeva = new sZaglavljePodnositeljZahtjeva();
            sAdresa adresa = new sAdresa();
            sRazdoblje razdoblje = new sRazdoblje();

            zahtjeva.Naziv = Conversions.ToString(dataSet.KORISNIK[0]["KORISNIK1NAZIV"]);
            zahtjeva.OIB = Conversions.ToString(dataSet.KORISNIK[0]["KORISNIKOIB"]);
            adresa.Ulica = dataSet.KORISNIK[0]["KORISNIK1ADRESA"].ToString().Replace(DB.IzvuciSamoBrojke(dataSet.KORISNIK[0]["KORISNIK1ADRESA"].ToString(), false), "");
            adresa.Broj = DB.IzvuciSamoBrojke(dataSet.KORISNIK[0]["KORISNIK1ADRESA"].ToString(), false);
            adresa.Mjesto = Conversions.ToString(dataSet.KORISNIK[0]["KORISNIK1MJESTO"]);
            zahtjeva.Adresa = adresa;
            zaglavlje.PodnositeljZahtjeva = zahtjeva;
            zaglavlje.PodrucniUred = Conversions.ToString(dataSet.KORISNIK[0]["NADLEZNAPU"]);
            if (Operators.ConditionalCompareObjectEqual(this.DsIDObrazac1.sp_id_zaglavlje[0]["identifikator"], 1, false))
            {
                zaglavlje.Identifikator = sIdentifikator.Item1;
            }
            if (Operators.ConditionalCompareObjectEqual(this.DsIDObrazac1.sp_id_zaglavlje[0]["identifikator"], 11, false))
            {
                zaglavlje.Identifikator = sIdentifikator.Item12;
            }
            zaglavlje.Ispostava = Conversions.ToString(dataSet.KORISNIK[0]["BROJCANAOZNAKAPU"]);
            razdoblje.DatumOd = DateAndTime.DateSerial(Conversions.ToInteger(this.strGI), Conversions.ToInteger(this.strMI), 1);
            razdoblje.DatumDo = DateAndTime.DateSerial(Conversions.ToInteger(this.strGI), Conversions.ToInteger(this.strMI), DateTime.DaysInMonth(Conversions.ToInteger(this.strGI), Conversions.ToInteger(this.strMI)));
            zaglavlje.Razdoblje = razdoblje;
            o.Zaglavlje = zaglavlje;
            sIsplaceniPrimiciIObracunPoreza poreza = new sIsplaceniPrimiciIObracunPoreza();
            sTijelo tijelo = new sTijelo();
            poreza.Podatak100 = Conversions.ToDecimal(this.DsIDObrazac1.sp_id_zaglavlje[0]["REDAK_II_1"]);
            poreza.Podatak200 = Conversions.ToDecimal(this.DsIDObrazac1.sp_id_zaglavlje[0]["REDAK_II_2"]);
            poreza.Podatak210 = Conversions.ToDecimal(this.DsIDObrazac1.sp_id_zaglavlje[0]["REDAK_II_2_1_1"]);
            poreza.Podatak220 = Conversions.ToDecimal(this.DsIDObrazac1.sp_id_zaglavlje[0]["REDAK_II_2_1_2"]);
            poreza.Podatak230 = Conversions.ToDecimal(this.DsIDObrazac1.sp_id_zaglavlje[0]["REDAK_II_2_1_3"]);
            poreza.Podatak300 = Conversions.ToDecimal(this.DsIDObrazac1.sp_id_zaglavlje[0]["REDAK_II_3"]);
            poreza.Podatak400 = Conversions.ToDecimal(this.DsIDObrazac1.sp_id_zaglavlje[0]["REDAK_II_4"]);
            poreza.Podatak500 = Conversions.ToDecimal(this.DsIDObrazac1.sp_id_zaglavlje[0]["REDAK_II_5"]);
            poreza.Podatak600 = Conversions.ToDecimal(this.DsIDObrazac1.sp_id_zaglavlje[0]["REDAK_II_6"]);
            poreza.Podatak610 = Conversions.ToDecimal(this.DsIDObrazac1.sp_id_zaglavlje[0]["REDAK_II_6_1"]);
            poreza.Podatak620 = Conversions.ToDecimal(this.DsIDObrazac1.sp_id_zaglavlje[0]["REDAK_II_6_2"]);
            poreza.Podatak700 = Conversions.ToDecimal(this.DsIDObrazac1.sp_id_zaglavlje[0]["REDAK_II_7"]);
            poreza.Podatak800 = Conversions.ToString(this.DsIDObrazac1.sp_id_zaglavlje[0]["REDAK_II_8"]);
            sDoprinosiUkupno ukupno = new sDoprinosiUkupno {
                Podatak110 = Conversions.ToDecimal(this.DsIDObrazac1.sp_id_zaglavlje[0]["REDAK_III_1_1"]),
                Podatak120 = Conversions.ToDecimal(this.DsIDObrazac1.sp_id_zaglavlje[0]["REDAK_III_1_2"]),
                Podatak210 = Conversions.ToDecimal(this.DsIDObrazac1.sp_id_zaglavlje[0]["REDAK_III_2_1"]),
                Podatak220 = Conversions.ToDecimal(this.DsIDObrazac1.sp_id_zaglavlje[0]["REDAK_III_2_2"]),
                Podatak310 = Conversions.ToDecimal(this.DsIDObrazac1.sp_id_zaglavlje[0]["REDAK_III_3_1"]),
                Podatak320 = Conversions.ToDecimal(this.DsIDObrazac1.sp_id_zaglavlje[0]["REDAK_III_3_2"]),
                Podatak330 = Conversions.ToDecimal(this.DsIDObrazac1.sp_id_zaglavlje[0]["REDAK_III_3_3"]),
                Podatak410 = Conversions.ToDecimal(this.DsIDObrazac1.sp_id_zaglavlje[0]["REDAK_III_4_1"]),
                Podatak420 = Conversions.ToDecimal(this.DsIDObrazac1.sp_id_zaglavlje[0]["REDAK_III_4_2"]),
                Podatak500 = Conversions.ToString(this.DsIDObrazac1.sp_id_zaglavlje[0]["REDAK_III_5"])
            };
            porezArray = (sPorezIprirezPremaOpciniGraduObracunatiPorez[]) Utils.CopyArray((Array) porezArray, new sPorezIprirezPremaOpciniGraduObracunatiPorez[this.DsIDObrazac1.sp_id_detalji.Rows.Count + 1]);
            int num5 = this.DsIDObrazac1.sp_id_detalji.Rows.Count - 1;
            for (int i = 0; i <= num5; i++)
            {
                porezArray[i] = new sPorezIprirezPremaOpciniGraduObracunatiPorez();
                sPorezIprirezPremaOpciniGraduObracunatiPorez porez = porezArray[i];
                porez.Poreza = Conversions.ToDecimal(this.DsIDObrazac1.sp_id_detalji.Rows[i]["obracunaniporez"]);
                num = Conversions.ToDecimal(Operators.AddObject(num, this.DsIDObrazac1.sp_id_detalji.Rows[i]["obracunaniporez"]));
                porez.Prireza = Conversions.ToDecimal(this.DsIDObrazac1.sp_id_detalji.Rows[i]["obracunaniprirez"]);
                num2 = Conversions.ToDecimal(Operators.AddObject(num2, this.DsIDObrazac1.sp_id_detalji.Rows[i]["obracunaniprirez"]));
                porez.Ukupno = Conversions.ToDecimal(this.DsIDObrazac1.sp_id_detalji.Rows[i]["obracunanoukupno"]);
                num3 = Conversions.ToDecimal(Operators.AddObject(num3, this.DsIDObrazac1.sp_id_detalji.Rows[i]["obracunanoukupno"]));
                porez.Sifra = Conversions.ToString(this.DsIDObrazac1.sp_id_detalji.Rows[i]["idopcine"]);
                porez = null;
            }
            sUkupno ukupno2 = new sUkupno {
                Poreza = num,
                Prireza = num2,
                Ukupno = num3
            };
            tijelo.IsplaceniPrimiciIObracunPoreza = poreza;
            tijelo.DoprinosiUkupno = ukupno;
            tijelo.ObracunatiPorezi = porezArray;
            tijelo.Ukupno = ukupno2;
            o.Tijelo = tijelo;
            try
            {
                SaveFileDialog dialog2 = new SaveFileDialog {
                    InitialDirectory = Conversions.ToString(0),
                    FileName = "ID-" + this.strGI + "-" + this.strMI + ".xml",
                    RestoreDirectory = true
                };
                SaveFileDialog dialog = dialog2;
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    using (TextWriter writer = new StreamWriter(dialog.FileName))
                    {
                        XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
                        namespaces.Add("", "http://e-porezna.porezna-uprava.hr/sheme/zahtjevi/ObrazacID/v3-0");
                        new XmlSerializer(typeof(sObrazacID), "http://e-porezna.porezna-uprava.hr/sheme/zahtjevi/ObrazacID/v3-0").Serialize(writer, o, namespaces);
                        writer.Close();
                    }
                    Interaction.MsgBox("Datoteka uspješno  spremljena u: " + dialog.FileName, MsgBoxStyle.OkOnly, null);
                }
            }
            catch (System.Exception exception1)
            {
                throw exception1;
            }
        }

        [LocalCommandHandler("eporeznaID2011")]
        public void eporeznaID2011Handler(object sender, EventArgs e)
        {
            this.Eletronicki_Obrazac();
        }

        public ISmartPartInfo GetSmartPartInfo(Type smartPartInfoType)
        {
            return this.infoProvider.GetSmartPartInfo(smartPartInfoType);
        }

        private void IDObrazac_Load(object sender, EventArgs e)
        {
            this.III_3_1.DataBindings.Add(new Binding("Value", this.DsIDObrazac1, "sp_id_zaglavlje.REDAK_III_3_1", true));
            this.Identifikator.DataBindings.Add(new Binding("Value", this.DsIDObrazac1, "sp_id_zaglavlje.identifikator", true));
            this.oib.DataBindings.Add(new Binding("Value", this.DsIDObrazac1, "sp_id_zaglavlje.maticnibroj", true));
            this.Adresa.DataBindings.Add(new Binding("Value", this.DsIDObrazac1, "sp_id_zaglavlje.punaadresa", true));
            this.NazivUstanove.DataBindings.Add(new Binding("Value", this.DsIDObrazac1, "sp_id_zaglavlje.nazivfirme", true));
            this.udteDatumSastavljanja.DataBindings.Add(new Binding("Value", this.DsIDObrazac1, "sp_id_zaglavlje.DatumSastavljanja", true));
            this.III_5.DataBindings.Add(new Binding("Value", this.DsIDObrazac1, "sp_id_zaglavlje.Redak_III_5", true));
            this.III_4_2.DataBindings.Add(new Binding("Value", this.DsIDObrazac1, "sp_id_zaglavlje.Redak_III_4_2", true));
            this.III_4_1.DataBindings.Add(new Binding("Value", this.DsIDObrazac1, "sp_id_zaglavlje.Redak_III_4_1", true));
            this.III_3_3.DataBindings.Add(new Binding("Value", this.DsIDObrazac1, "sp_id_zaglavlje.Redak_III_3_3", true));
            this.III_3_2.DataBindings.Add(new Binding("Value", this.DsIDObrazac1, "sp_id_zaglavlje.Redak_III_3_2", true));
            this.III_2_2.DataBindings.Add(new Binding("Value", this.DsIDObrazac1, "sp_id_zaglavlje.Redak_III_2_2", true));
            this.III_2_1.DataBindings.Add(new Binding("Value", this.DsIDObrazac1, "sp_id_zaglavlje.Redak_III_2_1", true));
            this.III_1_2.DataBindings.Add(new Binding("Value", this.DsIDObrazac1, "sp_id_zaglavlje.Redak_III_1_2", true));
            this.III_1_1.DataBindings.Add(new Binding("Value", this.DsIDObrazac1, "sp_id_zaglavlje.Redak_III_1_1", true));
            this.II_8.DataBindings.Add(new Binding("Value", this.DsIDObrazac1, "sp_id_zaglavlje.Redak_II_8", true));
            this.II_7.DataBindings.Add(new Binding("Value", this.DsIDObrazac1, "sp_id_zaglavlje.Redak_II_7", true));
            this.II_6_2.DataBindings.Add(new Binding("Value", this.DsIDObrazac1, "sp_id_zaglavlje.Redak_II_6_2", true));
            this.II_6_1.DataBindings.Add(new Binding("Value", this.DsIDObrazac1, "sp_id_zaglavlje.Redak_II_6_1", true));
            this.II_6.DataBindings.Add(new Binding("Value", this.DsIDObrazac1, "sp_id_zaglavlje.Redak_II_6", true));
            this.II_5.DataBindings.Add(new Binding("Value", this.DsIDObrazac1, "sp_id_zaglavlje.Redak_II_5", true));
            this.II_4.DataBindings.Add(new Binding("Value", this.DsIDObrazac1, "sp_id_zaglavlje.Redak_II_4", true));
            this.II_3.DataBindings.Add(new Binding("Value", this.DsIDObrazac1, "sp_id_zaglavlje.Redak_II_3", true));
            this.II_2_2_3.DataBindings.Add(new Binding("Value", this.DsIDObrazac1, "sp_id_zaglavlje.Redak_II_2_2_3", true));
            this.II_2_2_2.DataBindings.Add(new Binding("Value", this.DsIDObrazac1, "sp_id_zaglavlje.Redak_II_2_2_2", true));
            this.II_2_2_1.DataBindings.Add(new Binding("Value", this.DsIDObrazac1, "sp_id_zaglavlje.Redak_II_2_2_1", true));
            this.II_2_2.DataBindings.Add(new Binding("Value", this.DsIDObrazac1, "sp_id_zaglavlje.Redak_II_2_2", true));
            this.II_2_1_3.DataBindings.Add(new Binding("Value", this.DsIDObrazac1, "sp_id_zaglavlje.Redak_II_2_1_3", true));
            this.II_2_1_2.DataBindings.Add(new Binding("Value", this.DsIDObrazac1, "sp_id_zaglavlje.Redak_II_2_1_2", true));
            this.II_2_1_1.DataBindings.Add(new Binding("Value", this.DsIDObrazac1, "sp_id_zaglavlje.Redak_II_2_1_1", true));
            this.II_2_1.DataBindings.Add(new Binding("Value", this.DsIDObrazac1, "sp_id_zaglavlje.Redak_II_2_1", true));
            this.II_2.DataBindings.Add(new Binding("Value", this.DsIDObrazac1, "sp_id_zaglavlje.Redak_II_2", true));
            this.II_1.DataBindings.Add(new Binding("Value", this.DsIDObrazac1, "sp_id_zaglavlje.Redak_II_1", true));
            InfraCustom.PostaviSelectAllSvimEditKontrolama(this);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance79 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance77 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance41 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance40 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance39 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance38 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance80 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance74 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance73 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance72 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance71 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance70 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance69 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance68 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance66 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance65 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance64 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance63 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance62 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance81 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance78 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance67 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance56 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance34 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance45 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance75 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance76 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance61 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance60 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance59 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance58 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance57 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance55 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance54 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance53 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance52 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance51 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance50 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance49 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance48 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance47 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance46 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance44 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance43 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance42 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("sp_id_detalji", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ididobrasca");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("REDNIBROJ");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDOPCINE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVOPCINE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("obracunaniporez");
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("obracunaniprirez");
            Infragistics.Win.Appearance appearance32 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance33 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("obracunanoukupno");
            Infragistics.Win.Appearance appearance35 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance36 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance31 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinTabControl.UltraTab tab = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab tab2 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            this.UltraTabPageControl7 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.UltraGroupBox2 = new Infragistics.Win.Misc.UltraGroupBox();
            this.UltraLabel38 = new Infragistics.Win.Misc.UltraLabel();
            this.UltraLabel37 = new Infragistics.Win.Misc.UltraLabel();
            this.UltraLabel4 = new Infragistics.Win.Misc.UltraLabel();
            this.UltraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.UltraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.UltraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.NazivUstanove = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.Adresa = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.oib = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.Godina = new System.Windows.Forms.Label();
            this.Identifikator = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.Mjesec = new System.Windows.Forms.Label();
            this.UltraGroupBox4 = new Infragistics.Win.Misc.UltraGroupBox();
            this.udteDatumSastavljanja = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.UltraLabel39 = new Infragistics.Win.Misc.UltraLabel();
            this.UltraLabel34 = new Infragistics.Win.Misc.UltraLabel();
            this.UltraLabel33 = new Infragistics.Win.Misc.UltraLabel();
            this.UltraLabel32 = new Infragistics.Win.Misc.UltraLabel();
            this.UltraLabel31 = new Infragistics.Win.Misc.UltraLabel();
            this.UltraLabel30 = new Infragistics.Win.Misc.UltraLabel();
            this.UltraLabel29 = new Infragistics.Win.Misc.UltraLabel();
            this.UltraLabel28 = new Infragistics.Win.Misc.UltraLabel();
            this.UltraLabel27 = new Infragistics.Win.Misc.UltraLabel();
            this.UltraLabel26 = new Infragistics.Win.Misc.UltraLabel();
            this.UltraLabel25 = new Infragistics.Win.Misc.UltraLabel();
            this.UltraLabel24 = new Infragistics.Win.Misc.UltraLabel();
            this.UltraLabel23 = new Infragistics.Win.Misc.UltraLabel();
            this.III_1_1 = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.III_1_2 = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.III_2_1 = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.III_2_2 = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.III_3_1 = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.III_3_2 = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.III_5 = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.III_3_3 = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.III_4_2 = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.III_4_1 = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.UltraLabel35 = new Infragistics.Win.Misc.UltraLabel();
            this.UltraLabel36 = new Infragistics.Win.Misc.UltraLabel();
            this.UltraGroupBox3 = new Infragistics.Win.Misc.UltraGroupBox();
            this.UltraLabel22 = new Infragistics.Win.Misc.UltraLabel();
            this.UltraLabel21 = new Infragistics.Win.Misc.UltraLabel();
            this.UltraLabel20 = new Infragistics.Win.Misc.UltraLabel();
            this.UltraLabel19 = new Infragistics.Win.Misc.UltraLabel();
            this.UltraLabel18 = new Infragistics.Win.Misc.UltraLabel();
            this.UltraLabel17 = new Infragistics.Win.Misc.UltraLabel();
            this.UltraLabel16 = new Infragistics.Win.Misc.UltraLabel();
            this.UltraLabel15 = new Infragistics.Win.Misc.UltraLabel();
            this.UltraLabel14 = new Infragistics.Win.Misc.UltraLabel();
            this.UltraLabel13 = new Infragistics.Win.Misc.UltraLabel();
            this.UltraLabel12 = new Infragistics.Win.Misc.UltraLabel();
            this.UltraLabel11 = new Infragistics.Win.Misc.UltraLabel();
            this.UltraLabel10 = new Infragistics.Win.Misc.UltraLabel();
            this.UltraLabel9 = new Infragistics.Win.Misc.UltraLabel();
            this.UltraLabel8 = new Infragistics.Win.Misc.UltraLabel();
            this.UltraLabel7 = new Infragistics.Win.Misc.UltraLabel();
            this.UltraLabel6 = new Infragistics.Win.Misc.UltraLabel();
            this.UltraLabel5 = new Infragistics.Win.Misc.UltraLabel();
            this.II_1 = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.II_2 = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.II_2_1 = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.II_2_1_1 = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.II_2_1_2 = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.II_2_1_3 = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.II_8 = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.II_2_2 = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.II_7 = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.II_2_2_1 = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.II_6_2 = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.II_2_2_2 = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.II_6_1 = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.II_2_2_3 = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.II_6 = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.II_3 = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.II_5 = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.II_4 = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.UltraTabPageControl6 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.UltraGrid1 = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.DsIDObrazac1 = new dsIdObrazac();
            this.SqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
            this.SqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
            this.daDetalji = new System.Data.SqlClient.SqlDataAdapter();
            this.daZaglavlje = new System.Data.SqlClient.SqlDataAdapter();
            this.TAB1 = new Infragistics.Win.UltraWinTabControl.UltraTabControl();
            this.UltraTabSharedControlsPage2 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.UltraDockManager1 = new Infragistics.Win.UltraWinDock.UltraDockManager(this.components);
            this._IDObrazacUnpinnedTabAreaLeft = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._IDObrazacUnpinnedTabAreaRight = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._IDObrazacUnpinnedTabAreaTop = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._IDObrazacUnpinnedTabAreaBottom = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._IDObrazacAutoHideControl = new Infragistics.Win.UltraWinDock.AutoHideControl();
            this.UltraTabPageControl7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UltraGroupBox2)).BeginInit();
            this.UltraGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NazivUstanove)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Adresa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.oib)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Identifikator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltraGroupBox4)).BeginInit();
            this.UltraGroupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udteDatumSastavljanja)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.III_1_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.III_1_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.III_2_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.III_2_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.III_3_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.III_3_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.III_5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.III_3_3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.III_4_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.III_4_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltraGroupBox3)).BeginInit();
            this.UltraGroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.II_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.II_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.II_2_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.II_2_1_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.II_2_1_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.II_2_1_3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.II_8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.II_2_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.II_7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.II_2_2_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.II_6_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.II_2_2_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.II_6_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.II_2_2_3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.II_6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.II_3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.II_5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.II_4)).BeginInit();
            this.UltraTabPageControl6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UltraGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DsIDObrazac1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TAB1)).BeginInit();
            this.TAB1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UltraDockManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // UltraTabPageControl7
            // 
            this.UltraTabPageControl7.AutoScroll = true;
            this.UltraTabPageControl7.Controls.Add(this.UltraGroupBox2);
            this.UltraTabPageControl7.Controls.Add(this.UltraGroupBox4);
            this.UltraTabPageControl7.Controls.Add(this.UltraGroupBox3);
            this.UltraTabPageControl7.Location = new System.Drawing.Point(1, 24);
            this.UltraTabPageControl7.Name = "UltraTabPageControl7";
            this.UltraTabPageControl7.Size = new System.Drawing.Size(1106, 908);
            // 
            // UltraGroupBox2
            // 
            this.UltraGroupBox2.Controls.Add(this.UltraLabel38);
            this.UltraGroupBox2.Controls.Add(this.UltraLabel37);
            this.UltraGroupBox2.Controls.Add(this.UltraLabel4);
            this.UltraGroupBox2.Controls.Add(this.UltraLabel3);
            this.UltraGroupBox2.Controls.Add(this.UltraLabel2);
            this.UltraGroupBox2.Controls.Add(this.UltraLabel1);
            this.UltraGroupBox2.Controls.Add(this.NazivUstanove);
            this.UltraGroupBox2.Controls.Add(this.Adresa);
            this.UltraGroupBox2.Controls.Add(this.oib);
            this.UltraGroupBox2.Controls.Add(this.Godina);
            this.UltraGroupBox2.Controls.Add(this.Identifikator);
            this.UltraGroupBox2.Controls.Add(this.Mjesec);
            this.UltraGroupBox2.Location = new System.Drawing.Point(3, 3);
            this.UltraGroupBox2.Name = "UltraGroupBox2";
            this.UltraGroupBox2.Size = new System.Drawing.Size(741, 114);
            this.UltraGroupBox2.TabIndex = 74;
            this.UltraGroupBox2.Text = "PODACI O PODNOSITELJU IZVJEŠĆA";
            this.UltraGroupBox2.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            this.UltraGroupBox2.Click += new System.EventHandler(this.UltraGroupBox2_Click);
            // 
            // UltraLabel38
            // 
            appearance79.BackColor = System.Drawing.Color.Transparent;
            this.UltraLabel38.Appearance = appearance79;
            this.UltraLabel38.AutoSize = true;
            this.UltraLabel38.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UltraLabel38.Location = new System.Drawing.Point(278, 20);
            this.UltraLabel38.Name = "UltraLabel38";
            this.UltraLabel38.Size = new System.Drawing.Size(42, 13);
            this.UltraLabel38.TabIndex = 79;
            this.UltraLabel38.Text = "GODINE";
            this.UltraLabel38.UseAppStyling = false;
            // 
            // UltraLabel37
            // 
            appearance77.BackColor = System.Drawing.Color.Transparent;
            this.UltraLabel37.Appearance = appearance77;
            this.UltraLabel37.AutoSize = true;
            this.UltraLabel37.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UltraLabel37.Location = new System.Drawing.Point(11, 20);
            this.UltraLabel37.Name = "UltraLabel37";
            this.UltraLabel37.Size = new System.Drawing.Size(120, 13);
            this.UltraLabel37.TabIndex = 78;
            this.UltraLabel37.Text = "ID OBRAZAC U MJESECU";
            this.UltraLabel37.UseAppStyling = false;
            this.UltraLabel37.Click += new System.EventHandler(this.UltraLabel37_Click);
            // 
            // UltraLabel4
            // 
            appearance41.BackColor = System.Drawing.Color.Transparent;
            this.UltraLabel4.Appearance = appearance41;
            this.UltraLabel4.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UltraLabel4.Location = new System.Drawing.Point(11, 91);
            this.UltraLabel4.Name = "UltraLabel4";
            this.UltraLabel4.Size = new System.Drawing.Size(187, 23);
            this.UltraLabel4.TabIndex = 77;
            this.UltraLabel4.Text = "IDENTIFIKATOR";
            this.UltraLabel4.UseAppStyling = false;
            // 
            // UltraLabel3
            // 
            appearance40.BackColor = System.Drawing.Color.Transparent;
            this.UltraLabel3.Appearance = appearance40;
            this.UltraLabel3.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UltraLabel3.Location = new System.Drawing.Point(11, 75);
            this.UltraLabel3.Name = "UltraLabel3";
            this.UltraLabel3.Size = new System.Drawing.Size(187, 23);
            this.UltraLabel3.TabIndex = 76;
            this.UltraLabel3.Text = "POREZNI BROJ";
            this.UltraLabel3.UseAppStyling = false;
            // 
            // UltraLabel2
            // 
            appearance39.BackColor = System.Drawing.Color.Transparent;
            this.UltraLabel2.Appearance = appearance39;
            this.UltraLabel2.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UltraLabel2.Location = new System.Drawing.Point(11, 59);
            this.UltraLabel2.Name = "UltraLabel2";
            this.UltraLabel2.Size = new System.Drawing.Size(217, 23);
            this.UltraLabel2.TabIndex = 75;
            this.UltraLabel2.Text = "ADRESA";
            this.UltraLabel2.UseAppStyling = false;
            // 
            // UltraLabel1
            // 
            appearance38.BackColor = System.Drawing.Color.Transparent;
            this.UltraLabel1.Appearance = appearance38;
            this.UltraLabel1.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UltraLabel1.Location = new System.Drawing.Point(11, 43);
            this.UltraLabel1.Name = "UltraLabel1";
            this.UltraLabel1.Size = new System.Drawing.Size(248, 23);
            this.UltraLabel1.TabIndex = 74;
            this.UltraLabel1.Text = "NAZIV / IME I PREZIME";
            this.UltraLabel1.UseAppStyling = false;
            this.UltraLabel1.Click += new System.EventHandler(this.UltraLabel1_Click);
            // 
            // NazivUstanove
            // 
            this.NazivUstanove.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.NazivUstanove.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.NazivUstanove.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.NazivUstanove.Location = new System.Drawing.Point(287, 43);
            this.NazivUstanove.MaxLength = 100;
            this.NazivUstanove.Name = "NazivUstanove";
            this.NazivUstanove.Size = new System.Drawing.Size(446, 16);
            this.NazivUstanove.TabIndex = 39;
            this.NazivUstanove.UseAppStyling = false;
            this.NazivUstanove.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // Adresa
            // 
            this.Adresa.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.Adresa.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.Adresa.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Adresa.Location = new System.Drawing.Point(287, 59);
            this.Adresa.MaxLength = 100;
            this.Adresa.Name = "Adresa";
            this.Adresa.Size = new System.Drawing.Size(446, 16);
            this.Adresa.TabIndex = 40;
            this.Adresa.UseAppStyling = false;
            this.Adresa.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // oib
            // 
            appearance12.TextHAlignAsString = "Right";
            this.oib.Appearance = appearance12;
            this.oib.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.oib.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.oib.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.oib.Location = new System.Drawing.Point(287, 75);
            this.oib.MaxLength = 13;
            this.oib.Name = "oib";
            this.oib.Size = new System.Drawing.Size(144, 16);
            this.oib.TabIndex = 41;
            this.oib.UseAppStyling = false;
            this.oib.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // Godina
            // 
            this.Godina.AutoSize = true;
            this.Godina.BackColor = System.Drawing.Color.Transparent;
            this.Godina.Font = new System.Drawing.Font("Verdana", 6.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Godina.Location = new System.Drawing.Point(356, 20);
            this.Godina.Name = "Godina";
            this.Godina.Size = new System.Drawing.Size(35, 12);
            this.Godina.TabIndex = 73;
            this.Godina.Text = "_____";
            this.Godina.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Identifikator
            // 
            appearance.TextHAlignAsString = "Right";
            this.Identifikator.Appearance = appearance;
            this.Identifikator.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.Identifikator.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.Identifikator.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Identifikator.Location = new System.Drawing.Point(287, 91);
            this.Identifikator.MaxLength = 1;
            this.Identifikator.Name = "Identifikator";
            this.Identifikator.Size = new System.Drawing.Size(20, 16);
            this.Identifikator.TabIndex = 42;
            this.Identifikator.UseAppStyling = false;
            this.Identifikator.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // Mjesec
            // 
            this.Mjesec.AutoSize = true;
            this.Mjesec.BackColor = System.Drawing.Color.Transparent;
            this.Mjesec.Font = new System.Drawing.Font("Verdana", 6.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Mjesec.Location = new System.Drawing.Point(162, 20);
            this.Mjesec.Name = "Mjesec";
            this.Mjesec.Size = new System.Drawing.Size(77, 12);
            this.Mjesec.TabIndex = 72;
            this.Mjesec.Text = "____________";
            this.Mjesec.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UltraGroupBox4
            // 
            this.UltraGroupBox4.Controls.Add(this.udteDatumSastavljanja);
            this.UltraGroupBox4.Controls.Add(this.UltraLabel39);
            this.UltraGroupBox4.Controls.Add(this.UltraLabel34);
            this.UltraGroupBox4.Controls.Add(this.UltraLabel33);
            this.UltraGroupBox4.Controls.Add(this.UltraLabel32);
            this.UltraGroupBox4.Controls.Add(this.UltraLabel31);
            this.UltraGroupBox4.Controls.Add(this.UltraLabel30);
            this.UltraGroupBox4.Controls.Add(this.UltraLabel29);
            this.UltraGroupBox4.Controls.Add(this.UltraLabel28);
            this.UltraGroupBox4.Controls.Add(this.UltraLabel27);
            this.UltraGroupBox4.Controls.Add(this.UltraLabel26);
            this.UltraGroupBox4.Controls.Add(this.UltraLabel25);
            this.UltraGroupBox4.Controls.Add(this.UltraLabel24);
            this.UltraGroupBox4.Controls.Add(this.UltraLabel23);
            this.UltraGroupBox4.Controls.Add(this.III_1_1);
            this.UltraGroupBox4.Controls.Add(this.III_1_2);
            this.UltraGroupBox4.Controls.Add(this.III_2_1);
            this.UltraGroupBox4.Controls.Add(this.III_2_2);
            this.UltraGroupBox4.Controls.Add(this.III_3_1);
            this.UltraGroupBox4.Controls.Add(this.III_3_2);
            this.UltraGroupBox4.Controls.Add(this.III_5);
            this.UltraGroupBox4.Controls.Add(this.III_3_3);
            this.UltraGroupBox4.Controls.Add(this.III_4_2);
            this.UltraGroupBox4.Controls.Add(this.III_4_1);
            this.UltraGroupBox4.Controls.Add(this.UltraLabel35);
            this.UltraGroupBox4.Controls.Add(this.UltraLabel36);
            this.UltraGroupBox4.Location = new System.Drawing.Point(3, 478);
            this.UltraGroupBox4.Name = "UltraGroupBox4";
            this.UltraGroupBox4.Size = new System.Drawing.Size(741, 529);
            this.UltraGroupBox4.TabIndex = 76;
            this.UltraGroupBox4.Text = "OBRAČUNANI DOPRINOSI UKUPNO";
            this.UltraGroupBox4.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            this.UltraGroupBox4.Click += new System.EventHandler(this.UltraGroupBox4_Click);
            // 
            // udteDatumSastavljanja
            // 
            this.udteDatumSastavljanja.Location = new System.Drawing.Point(590, 298);
            this.udteDatumSastavljanja.Name = "udteDatumSastavljanja";
            this.udteDatumSastavljanja.Size = new System.Drawing.Size(144, 21);
            this.udteDatumSastavljanja.TabIndex = 86;
            // 
            // UltraLabel39
            // 
            appearance80.BackColor = System.Drawing.Color.Transparent;
            this.UltraLabel39.Appearance = appearance80;
            this.UltraLabel39.AutoSize = true;
            this.UltraLabel39.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UltraLabel39.Location = new System.Drawing.Point(11, 298);
            this.UltraLabel39.Name = "UltraLabel39";
            this.UltraLabel39.Size = new System.Drawing.Size(111, 13);
            this.UltraLabel39.TabIndex = 85;
            this.UltraLabel39.Text = "DATUM SASTAVLJANJA";
            this.UltraLabel39.UseAppStyling = false;
            // 
            // UltraLabel34
            // 
            appearance74.BackColor = System.Drawing.Color.Transparent;
            this.UltraLabel34.Appearance = appearance74;
            this.UltraLabel34.AutoSize = true;
            this.UltraLabel34.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UltraLabel34.Location = new System.Drawing.Point(10, 117);
            this.UltraLabel34.Name = "UltraLabel34";
            this.UltraLabel34.Size = new System.Drawing.Size(338, 13);
            this.UltraLabel34.TabIndex = 82;
            this.UltraLabel34.Text = "- dodatni doprinos za staž osiguranja kosi se računa s poveć. trajanjem";
            this.UltraLabel34.UseAppStyling = false;
            // 
            // UltraLabel33
            // 
            appearance73.BackColor = System.Drawing.Color.Transparent;
            this.UltraLabel33.Appearance = appearance73;
            this.UltraLabel33.AutoSize = true;
            this.UltraLabel33.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UltraLabel33.Location = new System.Drawing.Point(10, 56);
            this.UltraLabel33.Name = "UltraLabel33";
            this.UltraLabel33.Size = new System.Drawing.Size(336, 13);
            this.UltraLabel33.TabIndex = 81;
            this.UltraLabel33.Text = "- dodatni doprinos za staž osiguranja koji se računa s poveć. trajanjem";
            // 
            // UltraLabel32
            // 
            appearance72.BackColor = System.Drawing.Color.Transparent;
            this.UltraLabel32.Appearance = appearance72;
            this.UltraLabel32.AutoSize = true;
            this.UltraLabel32.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UltraLabel32.Location = new System.Drawing.Point(11, 276);
            this.UltraLabel32.Name = "UltraLabel32";
            this.UltraLabel32.Size = new System.Drawing.Size(105, 13);
            this.UltraLabel32.TabIndex = 80;
            this.UltraLabel32.Text = "Broj osiguranih osoba";
            this.UltraLabel32.UseAppStyling = false;
            // 
            // UltraLabel31
            // 
            appearance71.BackColor = System.Drawing.Color.Transparent;
            this.UltraLabel31.Appearance = appearance71;
            this.UltraLabel31.AutoSize = true;
            this.UltraLabel31.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UltraLabel31.Location = new System.Drawing.Point(11, 258);
            this.UltraLabel31.Name = "UltraLabel31";
            this.UltraLabel31.Size = new System.Drawing.Size(319, 13);
            this.UltraLabel31.TabIndex = 79;
            this.UltraLabel31.Text = "- posebni doprinos za poticanje zapošljavanja osoba s invaliditetom";
            this.UltraLabel31.UseAppStyling = false;
            // 
            // UltraLabel30
            // 
            appearance70.BackColor = System.Drawing.Color.Transparent;
            this.UltraLabel30.Appearance = appearance70;
            this.UltraLabel30.AutoSize = true;
            this.UltraLabel30.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UltraLabel30.Location = new System.Drawing.Point(11, 240);
            this.UltraLabel30.Name = "UltraLabel30";
            this.UltraLabel30.Size = new System.Drawing.Size(132, 13);
            this.UltraLabel30.TabIndex = 78;
            this.UltraLabel30.Text = "- doprinos za zapošljavanje";
            this.UltraLabel30.UseAppStyling = false;
            // 
            // UltraLabel29
            // 
            appearance69.BackColor = System.Drawing.Color.Transparent;
            this.UltraLabel29.Appearance = appearance69;
            this.UltraLabel29.AutoSize = true;
            this.UltraLabel29.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UltraLabel29.Location = new System.Drawing.Point(9, 197);
            this.UltraLabel29.Name = "UltraLabel29";
            this.UltraLabel29.Size = new System.Drawing.Size(307, 13);
            this.UltraLabel29.TabIndex = 77;
            this.UltraLabel29.Text = "- posebni doprinos za korištenje zdrastvene zaštite u inozemstvu";
            this.UltraLabel29.UseAppStyling = false;
            // 
            // UltraLabel28
            // 
            appearance68.BackColor = System.Drawing.Color.Transparent;
            this.UltraLabel28.Appearance = appearance68;
            this.UltraLabel28.AutoSize = true;
            this.UltraLabel28.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UltraLabel28.Location = new System.Drawing.Point(9, 179);
            this.UltraLabel28.Name = "UltraLabel28";
            this.UltraLabel28.Size = new System.Drawing.Size(284, 13);
            this.UltraLabel28.TabIndex = 76;
            this.UltraLabel28.Text = "- doprinos za zdrastveno osiguranje zaštite zdravlja na radu";
            this.UltraLabel28.UseAppStyling = false;
            // 
            // UltraLabel27
            // 
            appearance66.BackColor = System.Drawing.Color.Transparent;
            this.UltraLabel27.Appearance = appearance66;
            this.UltraLabel27.AutoSize = true;
            this.UltraLabel27.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UltraLabel27.Location = new System.Drawing.Point(9, 161);
            this.UltraLabel27.Name = "UltraLabel27";
            this.UltraLabel27.Size = new System.Drawing.Size(177, 13);
            this.UltraLabel27.TabIndex = 75;
            this.UltraLabel27.Text = "- doprinos za zdravstveno osiguranje";
            this.UltraLabel27.UseAppStyling = false;
            // 
            // UltraLabel26
            // 
            appearance65.BackColor = System.Drawing.Color.Transparent;
            this.UltraLabel26.Appearance = appearance65;
            this.UltraLabel26.AutoSize = true;
            this.UltraLabel26.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UltraLabel26.Location = new System.Drawing.Point(10, 99);
            this.UltraLabel26.Name = "UltraLabel26";
            this.UltraLabel26.Size = new System.Drawing.Size(292, 13);
            this.UltraLabel26.TabIndex = 74;
            this.UltraLabel26.Text = "- doprinosi za mir. osig. na temelju ind. kapitalizirane štednje";
            this.UltraLabel26.UseAppStyling = false;
            // 
            // UltraLabel25
            // 
            appearance64.BackColor = System.Drawing.Color.Transparent;
            this.UltraLabel25.Appearance = appearance64;
            this.UltraLabel25.AutoSize = true;
            this.UltraLabel25.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UltraLabel25.Location = new System.Drawing.Point(11, 80);
            this.UltraLabel25.Name = "UltraLabel25";
            this.UltraLabel25.Size = new System.Drawing.Size(309, 13);
            this.UltraLabel25.TabIndex = 73;
            this.UltraLabel25.Text = "Doprinosi za mirovinsko osiguranje na temelju ind. kapit. štednje";
            this.UltraLabel25.UseAppStyling = false;
            // 
            // UltraLabel24
            // 
            appearance63.BackColor = System.Drawing.Color.Transparent;
            this.UltraLabel24.Appearance = appearance63;
            this.UltraLabel24.AutoSize = true;
            this.UltraLabel24.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UltraLabel24.Location = new System.Drawing.Point(10, 38);
            this.UltraLabel24.Name = "UltraLabel24";
            this.UltraLabel24.Size = new System.Drawing.Size(173, 13);
            this.UltraLabel24.TabIndex = 72;
            this.UltraLabel24.Text = "- doprinosi za mirovinsko osiguranje";
            this.UltraLabel24.UseAppStyling = false;
            // 
            // UltraLabel23
            // 
            appearance62.BackColor = System.Drawing.Color.Transparent;
            this.UltraLabel23.Appearance = appearance62;
            this.UltraLabel23.AutoSize = true;
            this.UltraLabel23.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UltraLabel23.Location = new System.Drawing.Point(11, 20);
            this.UltraLabel23.Name = "UltraLabel23";
            this.UltraLabel23.Size = new System.Drawing.Size(339, 13);
            this.UltraLabel23.TabIndex = 71;
            this.UltraLabel23.Text = "Doprinosi za mirovinsko osiguranje na temelju generacijske solidarnosti";
            this.UltraLabel23.UseAppStyling = false;
            // 
            // III_1_1
            // 
            appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance4.BorderAlpha = Infragistics.Win.Alpha.Transparent;
            appearance4.ForeColor = System.Drawing.Color.MidnightBlue;
            this.III_1_1.Appearance = appearance4;
            this.III_1_1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.III_1_1.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.III_1_1.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2003;
            this.III_1_1.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.III_1_1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.III_1_1.Location = new System.Drawing.Point(621, 38);
            this.III_1_1.MaskInput = "{LOC}n,nnn,nnn,nnn.nn";
            this.III_1_1.MaxValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.III_1_1.MinValue = 0;
            this.III_1_1.Name = "III_1_1";
            this.III_1_1.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.III_1_1.PromptChar = ' ';
            this.III_1_1.Size = new System.Drawing.Size(112, 16);
            this.III_1_1.TabIndex = 61;
            this.III_1_1.TabNavigation = Infragistics.Win.UltraWinMaskedEdit.MaskedEditTabNavigation.NextControl;
            this.III_1_1.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.III_1_1.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // III_1_2
            // 
            appearance3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance3.BorderAlpha = Infragistics.Win.Alpha.Transparent;
            appearance3.ForeColor = System.Drawing.Color.MidnightBlue;
            this.III_1_2.Appearance = appearance3;
            this.III_1_2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.III_1_2.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.III_1_2.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2003;
            this.III_1_2.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.III_1_2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.III_1_2.Location = new System.Drawing.Point(621, 56);
            this.III_1_2.MaskInput = "{LOC}n,nnn,nnn,nnn.nn";
            this.III_1_2.MaxValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.III_1_2.MinValue = 0;
            this.III_1_2.Name = "III_1_2";
            this.III_1_2.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.III_1_2.PromptChar = ' ';
            this.III_1_2.Size = new System.Drawing.Size(112, 16);
            this.III_1_2.TabIndex = 62;
            this.III_1_2.TabNavigation = Infragistics.Win.UltraWinMaskedEdit.MaskedEditTabNavigation.NextControl;
            this.III_1_2.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.III_1_2.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // III_2_1
            // 
            appearance2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance2.BorderAlpha = Infragistics.Win.Alpha.Transparent;
            appearance2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.III_2_1.Appearance = appearance2;
            this.III_2_1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.III_2_1.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.III_2_1.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2003;
            this.III_2_1.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.III_2_1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.III_2_1.Location = new System.Drawing.Point(621, 99);
            this.III_2_1.MaskInput = "{LOC}n,nnn,nnn,nnn.nn";
            this.III_2_1.MaxValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.III_2_1.MinValue = 0;
            this.III_2_1.Name = "III_2_1";
            this.III_2_1.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.III_2_1.PromptChar = ' ';
            this.III_2_1.Size = new System.Drawing.Size(112, 16);
            this.III_2_1.TabIndex = 63;
            this.III_2_1.TabNavigation = Infragistics.Win.UltraWinMaskedEdit.MaskedEditTabNavigation.NextControl;
            this.III_2_1.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.III_2_1.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // III_2_2
            // 
            appearance81.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance81.BorderAlpha = Infragistics.Win.Alpha.Transparent;
            appearance81.ForeColor = System.Drawing.Color.MidnightBlue;
            this.III_2_2.Appearance = appearance81;
            this.III_2_2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.III_2_2.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.III_2_2.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2003;
            this.III_2_2.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.III_2_2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.III_2_2.Location = new System.Drawing.Point(621, 117);
            this.III_2_2.MaskInput = "{LOC}n,nnn,nnn,nnn.nn";
            this.III_2_2.MaxValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.III_2_2.MinValue = 0;
            this.III_2_2.Name = "III_2_2";
            this.III_2_2.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.III_2_2.PromptChar = ' ';
            this.III_2_2.Size = new System.Drawing.Size(112, 16);
            this.III_2_2.TabIndex = 64;
            this.III_2_2.TabNavigation = Infragistics.Win.UltraWinMaskedEdit.MaskedEditTabNavigation.NextControl;
            this.III_2_2.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.III_2_2.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // III_3_1
            // 
            appearance78.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance78.BorderAlpha = Infragistics.Win.Alpha.Transparent;
            appearance78.ForeColor = System.Drawing.Color.MidnightBlue;
            this.III_3_1.Appearance = appearance78;
            this.III_3_1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.III_3_1.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.III_3_1.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2003;
            this.III_3_1.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.III_3_1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.III_3_1.Location = new System.Drawing.Point(621, 161);
            this.III_3_1.MaskInput = "{LOC}n,nnn,nnn,nnn.nn";
            this.III_3_1.MaxValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.III_3_1.MinValue = 0;
            this.III_3_1.Name = "III_3_1";
            this.III_3_1.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.III_3_1.PromptChar = ' ';
            this.III_3_1.Size = new System.Drawing.Size(112, 16);
            this.III_3_1.TabIndex = 65;
            this.III_3_1.TabNavigation = Infragistics.Win.UltraWinMaskedEdit.MaskedEditTabNavigation.NextControl;
            this.III_3_1.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.III_3_1.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // III_3_2
            // 
            appearance67.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance67.BorderAlpha = Infragistics.Win.Alpha.Transparent;
            appearance67.ForeColor = System.Drawing.Color.MidnightBlue;
            this.III_3_2.Appearance = appearance67;
            this.III_3_2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.III_3_2.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.III_3_2.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2003;
            this.III_3_2.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.III_3_2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.III_3_2.Location = new System.Drawing.Point(621, 179);
            this.III_3_2.MaskInput = "{LOC}n,nnn,nnn,nnn.nn";
            this.III_3_2.MaxValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.III_3_2.MinValue = 0;
            this.III_3_2.Name = "III_3_2";
            this.III_3_2.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.III_3_2.PromptChar = ' ';
            this.III_3_2.Size = new System.Drawing.Size(112, 16);
            this.III_3_2.TabIndex = 66;
            this.III_3_2.TabNavigation = Infragistics.Win.UltraWinMaskedEdit.MaskedEditTabNavigation.NextControl;
            this.III_3_2.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.III_3_2.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // III_5
            // 
            appearance23.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance23.BorderAlpha = Infragistics.Win.Alpha.Transparent;
            appearance23.ForeColor = System.Drawing.Color.MidnightBlue;
            this.III_5.Appearance = appearance23;
            this.III_5.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.III_5.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.III_5.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2003;
            this.III_5.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.III_5.ForeColor = System.Drawing.Color.MidnightBlue;
            this.III_5.Location = new System.Drawing.Point(621, 276);
            this.III_5.MaskInput = "{LOC}n,nnn,nnn,nnn";
            this.III_5.MaxValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.III_5.MinValue = 0;
            this.III_5.Name = "III_5";
            this.III_5.PromptChar = ' ';
            this.III_5.Size = new System.Drawing.Size(112, 16);
            this.III_5.TabIndex = 70;
            this.III_5.TabNavigation = Infragistics.Win.UltraWinMaskedEdit.MaskedEditTabNavigation.NextControl;
            this.III_5.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.III_5.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // III_3_3
            // 
            appearance56.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance56.BorderAlpha = Infragistics.Win.Alpha.Transparent;
            appearance56.ForeColor = System.Drawing.Color.MidnightBlue;
            this.III_3_3.Appearance = appearance56;
            this.III_3_3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.III_3_3.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.III_3_3.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2003;
            this.III_3_3.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.III_3_3.ForeColor = System.Drawing.Color.MidnightBlue;
            this.III_3_3.Location = new System.Drawing.Point(621, 197);
            this.III_3_3.MaskInput = "{LOC}n,nnn,nnn,nnn.nn";
            this.III_3_3.MaxValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.III_3_3.MinValue = 0;
            this.III_3_3.Name = "III_3_3";
            this.III_3_3.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.III_3_3.PromptChar = ' ';
            this.III_3_3.Size = new System.Drawing.Size(112, 16);
            this.III_3_3.TabIndex = 67;
            this.III_3_3.TabNavigation = Infragistics.Win.UltraWinMaskedEdit.MaskedEditTabNavigation.NextControl;
            this.III_3_3.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.III_3_3.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // III_4_2
            // 
            appearance34.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance34.BorderAlpha = Infragistics.Win.Alpha.Transparent;
            appearance34.ForeColor = System.Drawing.Color.MidnightBlue;
            this.III_4_2.Appearance = appearance34;
            this.III_4_2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.III_4_2.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.III_4_2.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2003;
            this.III_4_2.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.III_4_2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.III_4_2.Location = new System.Drawing.Point(621, 258);
            this.III_4_2.MaskInput = "{LOC}n,nnn,nnn,nnn.nn";
            this.III_4_2.MaxValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.III_4_2.MinValue = 0;
            this.III_4_2.Name = "III_4_2";
            this.III_4_2.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.III_4_2.PromptChar = ' ';
            this.III_4_2.Size = new System.Drawing.Size(112, 16);
            this.III_4_2.TabIndex = 69;
            this.III_4_2.TabNavigation = Infragistics.Win.UltraWinMaskedEdit.MaskedEditTabNavigation.NextControl;
            this.III_4_2.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.III_4_2.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // III_4_1
            // 
            appearance45.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance45.BorderAlpha = Infragistics.Win.Alpha.Transparent;
            appearance45.ForeColor = System.Drawing.Color.MidnightBlue;
            this.III_4_1.Appearance = appearance45;
            this.III_4_1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.III_4_1.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.III_4_1.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2003;
            this.III_4_1.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.III_4_1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.III_4_1.Location = new System.Drawing.Point(621, 240);
            this.III_4_1.MaskInput = "{LOC}n,nnn,nnn,nnn.nn";
            this.III_4_1.MaxValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.III_4_1.MinValue = 0;
            this.III_4_1.Name = "III_4_1";
            this.III_4_1.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.III_4_1.PromptChar = ' ';
            this.III_4_1.Size = new System.Drawing.Size(112, 16);
            this.III_4_1.TabIndex = 68;
            this.III_4_1.TabNavigation = Infragistics.Win.UltraWinMaskedEdit.MaskedEditTabNavigation.NextControl;
            this.III_4_1.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.III_4_1.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // UltraLabel35
            // 
            appearance75.BackColor = System.Drawing.Color.Transparent;
            this.UltraLabel35.Appearance = appearance75;
            this.UltraLabel35.AutoSize = true;
            this.UltraLabel35.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UltraLabel35.Location = new System.Drawing.Point(10, 143);
            this.UltraLabel35.Name = "UltraLabel35";
            this.UltraLabel35.Size = new System.Drawing.Size(209, 13);
            this.UltraLabel35.TabIndex = 83;
            this.UltraLabel35.Text = "Doprinosi za obvezna zdrastvena osiguranja";
            this.UltraLabel35.UseAppStyling = false;
            // 
            // UltraLabel36
            // 
            appearance76.BackColor = System.Drawing.Color.Transparent;
            this.UltraLabel36.Appearance = appearance76;
            this.UltraLabel36.AutoSize = true;
            this.UltraLabel36.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UltraLabel36.Location = new System.Drawing.Point(10, 223);
            this.UltraLabel36.Name = "UltraLabel36";
            this.UltraLabel36.Size = new System.Drawing.Size(163, 13);
            this.UltraLabel36.TabIndex = 84;
            this.UltraLabel36.Text = "Doprinosi za slučaj nezaposlenosti";
            this.UltraLabel36.UseAppStyling = false;
            // 
            // UltraGroupBox3
            // 
            this.UltraGroupBox3.Controls.Add(this.UltraLabel22);
            this.UltraGroupBox3.Controls.Add(this.UltraLabel21);
            this.UltraGroupBox3.Controls.Add(this.UltraLabel20);
            this.UltraGroupBox3.Controls.Add(this.UltraLabel19);
            this.UltraGroupBox3.Controls.Add(this.UltraLabel18);
            this.UltraGroupBox3.Controls.Add(this.UltraLabel17);
            this.UltraGroupBox3.Controls.Add(this.UltraLabel16);
            this.UltraGroupBox3.Controls.Add(this.UltraLabel15);
            this.UltraGroupBox3.Controls.Add(this.UltraLabel14);
            this.UltraGroupBox3.Controls.Add(this.UltraLabel13);
            this.UltraGroupBox3.Controls.Add(this.UltraLabel12);
            this.UltraGroupBox3.Controls.Add(this.UltraLabel11);
            this.UltraGroupBox3.Controls.Add(this.UltraLabel10);
            this.UltraGroupBox3.Controls.Add(this.UltraLabel9);
            this.UltraGroupBox3.Controls.Add(this.UltraLabel8);
            this.UltraGroupBox3.Controls.Add(this.UltraLabel7);
            this.UltraGroupBox3.Controls.Add(this.UltraLabel6);
            this.UltraGroupBox3.Controls.Add(this.UltraLabel5);
            this.UltraGroupBox3.Controls.Add(this.II_1);
            this.UltraGroupBox3.Controls.Add(this.II_2);
            this.UltraGroupBox3.Controls.Add(this.II_2_1);
            this.UltraGroupBox3.Controls.Add(this.II_2_1_1);
            this.UltraGroupBox3.Controls.Add(this.II_2_1_2);
            this.UltraGroupBox3.Controls.Add(this.II_2_1_3);
            this.UltraGroupBox3.Controls.Add(this.II_8);
            this.UltraGroupBox3.Controls.Add(this.II_2_2);
            this.UltraGroupBox3.Controls.Add(this.II_7);
            this.UltraGroupBox3.Controls.Add(this.II_2_2_1);
            this.UltraGroupBox3.Controls.Add(this.II_6_2);
            this.UltraGroupBox3.Controls.Add(this.II_2_2_2);
            this.UltraGroupBox3.Controls.Add(this.II_6_1);
            this.UltraGroupBox3.Controls.Add(this.II_2_2_3);
            this.UltraGroupBox3.Controls.Add(this.II_6);
            this.UltraGroupBox3.Controls.Add(this.II_3);
            this.UltraGroupBox3.Controls.Add(this.II_5);
            this.UltraGroupBox3.Controls.Add(this.II_4);
            this.UltraGroupBox3.Location = new System.Drawing.Point(3, 123);
            this.UltraGroupBox3.Name = "UltraGroupBox3";
            this.UltraGroupBox3.Size = new System.Drawing.Size(741, 349);
            this.UltraGroupBox3.TabIndex = 75;
            this.UltraGroupBox3.Text = "PODACI O ISPLAĆENIM PRIMICIMA I OBRAČUNU POREZA";
            this.UltraGroupBox3.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // UltraLabel22
            // 
            appearance61.BackColor = System.Drawing.Color.Transparent;
            this.UltraLabel22.Appearance = appearance61;
            this.UltraLabel22.AutoSize = true;
            this.UltraLabel22.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UltraLabel22.Location = new System.Drawing.Point(10, 327);
            this.UltraLabel22.Name = "UltraLabel22";
            this.UltraLabel22.Size = new System.Drawing.Size(263, 13);
            this.UltraLabel22.TabIndex = 78;
            this.UltraLabel22.Text = "Broj radnika i ostalih primatelja, odnosno umirovljenika";
            this.UltraLabel22.UseAppStyling = false;
            // 
            // UltraLabel21
            // 
            appearance60.BackColor = System.Drawing.Color.Transparent;
            this.UltraLabel21.Appearance = appearance60;
            this.UltraLabel21.AutoSize = true;
            this.UltraLabel21.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UltraLabel21.Location = new System.Drawing.Point(10, 309);
            this.UltraLabel21.Name = "UltraLabel21";
            this.UltraLabel21.Size = new System.Drawing.Size(195, 13);
            this.UltraLabel21.TabIndex = 77;
            this.UltraLabel21.Text = "UPLAĆEN POREZ NA DOHODAK I PRIREZ";
            this.UltraLabel21.UseAppStyling = false;
            // 
            // UltraLabel20
            // 
            appearance59.BackColor = System.Drawing.Color.Transparent;
            this.UltraLabel20.Appearance = appearance59;
            this.UltraLabel20.AutoSize = true;
            this.UltraLabel20.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UltraLabel20.Location = new System.Drawing.Point(10, 291);
            this.UltraLabel20.Name = "UltraLabel20";
            this.UltraLabel20.Size = new System.Drawing.Size(130, 13);
            this.UltraLabel20.TabIndex = 76;
            this.UltraLabel20.Text = "- prirez porezu na dohodak";
            this.UltraLabel20.UseAppStyling = false;
            // 
            // UltraLabel19
            // 
            appearance58.BackColor = System.Drawing.Color.Transparent;
            this.UltraLabel19.Appearance = appearance58;
            this.UltraLabel19.AutoSize = true;
            this.UltraLabel19.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UltraLabel19.Location = new System.Drawing.Point(10, 273);
            this.UltraLabel19.Name = "UltraLabel19";
            this.UltraLabel19.Size = new System.Drawing.Size(94, 13);
            this.UltraLabel19.TabIndex = 75;
            this.UltraLabel19.Text = "- porez na dohodak";
            this.UltraLabel19.UseAppStyling = false;
            // 
            // UltraLabel18
            // 
            appearance57.BackColor = System.Drawing.Color.Transparent;
            this.UltraLabel18.Appearance = appearance57;
            this.UltraLabel18.AutoSize = true;
            this.UltraLabel18.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UltraLabel18.Location = new System.Drawing.Point(10, 255);
            this.UltraLabel18.Name = "UltraLabel18";
            this.UltraLabel18.Size = new System.Drawing.Size(274, 13);
            this.UltraLabel18.TabIndex = 74;
            this.UltraLabel18.Text = "OBRAČUNAN POREZ NA DOHODAK I PRIREZ (6.1. + 6.2.)";
            this.UltraLabel18.UseAppStyling = false;
            // 
            // UltraLabel17
            // 
            appearance55.BackColor = System.Drawing.Color.Transparent;
            this.UltraLabel17.Appearance = appearance55;
            this.UltraLabel17.AutoSize = true;
            this.UltraLabel17.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UltraLabel17.Location = new System.Drawing.Point(10, 237);
            this.UltraLabel17.Name = "UltraLabel17";
            this.UltraLabel17.Size = new System.Drawing.Size(276, 13);
            this.UltraLabel17.TabIndex = 73;
            this.UltraLabel17.Text = "POREZNA OSNOVICA (3.-4., članak 45. stavak 4. Zakona)";
            this.UltraLabel17.UseAppStyling = false;
            // 
            // UltraLabel16
            // 
            appearance54.BackColor = System.Drawing.Color.Transparent;
            this.UltraLabel16.Appearance = appearance54;
            this.UltraLabel16.AutoSize = true;
            this.UltraLabel16.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UltraLabel16.Location = new System.Drawing.Point(10, 219);
            this.UltraLabel16.Name = "UltraLabel16";
            this.UltraLabel16.Size = new System.Drawing.Size(239, 13);
            this.UltraLabel16.TabIndex = 72;
            this.UltraLabel16.Text = "OSOBNI ODBICI (članak 36. stavci 1. i 2. Zakona)";
            this.UltraLabel16.UseAppStyling = false;
            // 
            // UltraLabel15
            // 
            appearance53.BackColor = System.Drawing.Color.Transparent;
            this.UltraLabel15.Appearance = appearance53;
            this.UltraLabel15.AutoSize = true;
            this.UltraLabel15.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UltraLabel15.Location = new System.Drawing.Point(10, 201);
            this.UltraLabel15.Name = "UltraLabel15";
            this.UltraLabel15.Size = new System.Drawing.Size(150, 13);
            this.UltraLabel15.TabIndex = 71;
            this.UltraLabel15.Text = "DOHODAK (članak 13. Zakona)";
            this.UltraLabel15.UseAppStyling = false;
            this.UltraLabel15.Click += new System.EventHandler(this.UltraLabel15_Click);
            // 
            // UltraLabel14
            // 
            appearance52.BackColor = System.Drawing.Color.Transparent;
            this.UltraLabel14.Appearance = appearance52;
            this.UltraLabel14.AutoSize = true;
            this.UltraLabel14.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UltraLabel14.Location = new System.Drawing.Point(10, 183);
            this.UltraLabel14.Name = "UltraLabel14";
            this.UltraLabel14.Size = new System.Drawing.Size(179, 13);
            this.UltraLabel14.TabIndex = 70;
            this.UltraLabel14.Text = "- dobrovoljnog mirovinkog osiguranja";
            this.UltraLabel14.UseAppStyling = false;
            this.UltraLabel14.Click += new System.EventHandler(this.UltraLabel14_Click);
            // 
            // UltraLabel13
            // 
            appearance51.BackColor = System.Drawing.Color.Transparent;
            this.UltraLabel13.Appearance = appearance51;
            this.UltraLabel13.AutoSize = true;
            this.UltraLabel13.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UltraLabel13.Location = new System.Drawing.Point(10, 165);
            this.UltraLabel13.Name = "UltraLabel13";
            this.UltraLabel13.Size = new System.Drawing.Size(227, 13);
            this.UltraLabel13.TabIndex = 69;
            this.UltraLabel13.Text = "- dopunskog i privatnog zdrastvenog osiguranja";
            this.UltraLabel13.UseAppStyling = false;
            // 
            // UltraLabel12
            // 
            appearance50.BackColor = System.Drawing.Color.Transparent;
            this.UltraLabel12.Appearance = appearance50;
            this.UltraLabel12.AutoSize = true;
            this.UltraLabel12.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UltraLabel12.Location = new System.Drawing.Point(10, 147);
            this.UltraLabel12.Name = "UltraLabel12";
            this.UltraLabel12.Size = new System.Drawing.Size(193, 13);
            this.UltraLabel12.TabIndex = 68;
            this.UltraLabel12.Text = "- životno osiguranje s obilježjem štednje";
            this.UltraLabel12.UseAppStyling = false;
            // 
            // UltraLabel11
            // 
            appearance49.BackColor = System.Drawing.Color.Transparent;
            this.UltraLabel11.Appearance = appearance49;
            this.UltraLabel11.AutoSize = true;
            this.UltraLabel11.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UltraLabel11.Location = new System.Drawing.Point(10, 129);
            this.UltraLabel11.Name = "UltraLabel11";
            this.UltraLabel11.Size = new System.Drawing.Size(237, 13);
            this.UltraLabel11.TabIndex = 67;
            this.UltraLabel11.Text = "Uplaćene premije osiguranja (od 2.1.1. do 2.2.3.)";
            this.UltraLabel11.UseAppStyling = false;
            // 
            // UltraLabel10
            // 
            appearance48.BackColor = System.Drawing.Color.Transparent;
            this.UltraLabel10.Appearance = appearance48;
            this.UltraLabel10.AutoSize = true;
            this.UltraLabel10.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UltraLabel10.Location = new System.Drawing.Point(10, 111);
            this.UltraLabel10.Name = "UltraLabel10";
            this.UltraLabel10.Size = new System.Drawing.Size(264, 13);
            this.UltraLabel10.TabIndex = 66;
            this.UltraLabel10.Text = "- ostali doprinosi obračunani i obustavljeni od primitaka";
            this.UltraLabel10.UseAppStyling = false;
            // 
            // UltraLabel9
            // 
            appearance47.BackColor = System.Drawing.Color.Transparent;
            this.UltraLabel9.Appearance = appearance47;
            this.UltraLabel9.AutoSize = true;
            this.UltraLabel9.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UltraLabel9.Location = new System.Drawing.Point(10, 93);
            this.UltraLabel9.Name = "UltraLabel9";
            this.UltraLabel9.Size = new System.Drawing.Size(307, 13);
            this.UltraLabel9.TabIndex = 65;
            this.UltraLabel9.Text = "- za mirovinsko osiguranje na temelju individualne kapit. štednje";
            this.UltraLabel9.UseAppStyling = false;
            // 
            // UltraLabel8
            // 
            appearance46.BackColor = System.Drawing.Color.Transparent;
            this.UltraLabel8.Appearance = appearance46;
            this.UltraLabel8.AutoSize = true;
            this.UltraLabel8.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UltraLabel8.Location = new System.Drawing.Point(10, 75);
            this.UltraLabel8.Name = "UltraLabel8";
            this.UltraLabel8.Size = new System.Drawing.Size(299, 13);
            this.UltraLabel8.TabIndex = 64;
            this.UltraLabel8.Text = "- za mirovinsko osiguranje na temelju generacijske solidarnosti";
            this.UltraLabel8.UseAppStyling = false;
            // 
            // UltraLabel7
            // 
            appearance44.BackColor = System.Drawing.Color.Transparent;
            this.UltraLabel7.Appearance = appearance44;
            this.UltraLabel7.AutoSize = true;
            this.UltraLabel7.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UltraLabel7.Location = new System.Drawing.Point(10, 57);
            this.UltraLabel7.Name = "UltraLabel7";
            this.UltraLabel7.Size = new System.Drawing.Size(324, 13);
            this.UltraLabel7.TabIndex = 63;
            this.UltraLabel7.Text = "Uplaćeni doprinosi iz osnovice za obvezna osig. (od 2.1.1. do 2.1.3.)";
            this.UltraLabel7.UseAppStyling = false;
            // 
            // UltraLabel6
            // 
            appearance43.BackColor = System.Drawing.Color.Transparent;
            this.UltraLabel6.Appearance = appearance43;
            this.UltraLabel6.AutoSize = true;
            this.UltraLabel6.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UltraLabel6.Location = new System.Drawing.Point(10, 39);
            this.UltraLabel6.Name = "UltraLabel6";
            this.UltraLabel6.Size = new System.Drawing.Size(193, 13);
            this.UltraLabel6.TabIndex = 62;
            this.UltraLabel6.Text = "IZDACI (2.1. + 2.2., članak 16. Zakona)";
            this.UltraLabel6.UseAppStyling = false;
            // 
            // UltraLabel5
            // 
            appearance42.BackColor = System.Drawing.Color.Transparent;
            this.UltraLabel5.Appearance = appearance42;
            this.UltraLabel5.AutoSize = true;
            this.UltraLabel5.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UltraLabel5.Location = new System.Drawing.Point(10, 21);
            this.UltraLabel5.Name = "UltraLabel5";
            this.UltraLabel5.Size = new System.Drawing.Size(193, 13);
            this.UltraLabel5.TabIndex = 61;
            this.UltraLabel5.Text = "ISPLAĆENI PRIMICI (članak 14. Zakona)";
            this.UltraLabel5.UseAppStyling = false;
            this.UltraLabel5.Click += new System.EventHandler(this.UltraLabel5_Click);
            // 
            // II_1
            // 
            appearance24.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance24.BorderAlpha = Infragistics.Win.Alpha.Transparent;
            appearance24.ForeColor = System.Drawing.Color.MidnightBlue;
            this.II_1.Appearance = appearance24;
            this.II_1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.II_1.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.II_1.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2003;
            this.II_1.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.II_1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.II_1.Location = new System.Drawing.Point(621, 21);
            this.II_1.MaskInput = "{LOC}n,nnn,nnn,nnn.nn";
            this.II_1.MaxValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.II_1.MinValue = 0;
            this.II_1.Name = "II_1";
            this.II_1.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.II_1.PromptChar = ' ';
            this.II_1.Size = new System.Drawing.Size(112, 16);
            this.II_1.TabIndex = 43;
            this.II_1.TabNavigation = Infragistics.Win.UltraWinMaskedEdit.MaskedEditTabNavigation.NextControl;
            this.II_1.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.II_1.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // II_2
            // 
            appearance22.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance22.BorderAlpha = Infragistics.Win.Alpha.Transparent;
            appearance22.ForeColor = System.Drawing.Color.MidnightBlue;
            this.II_2.Appearance = appearance22;
            this.II_2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.II_2.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.II_2.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2003;
            this.II_2.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.II_2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.II_2.Location = new System.Drawing.Point(621, 39);
            this.II_2.MaskInput = "{LOC}n,nnn,nnn,nnn.nn";
            this.II_2.MaxValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.II_2.MinValue = 0;
            this.II_2.Name = "II_2";
            this.II_2.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.II_2.PromptChar = ' ';
            this.II_2.Size = new System.Drawing.Size(112, 16);
            this.II_2.TabIndex = 44;
            this.II_2.TabNavigation = Infragistics.Win.UltraWinMaskedEdit.MaskedEditTabNavigation.NextControl;
            this.II_2.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.II_2.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // II_2_1
            // 
            appearance21.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance21.BorderAlpha = Infragistics.Win.Alpha.Transparent;
            appearance21.ForeColor = System.Drawing.Color.MidnightBlue;
            this.II_2_1.Appearance = appearance21;
            this.II_2_1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.II_2_1.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.II_2_1.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2003;
            this.II_2_1.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.II_2_1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.II_2_1.Location = new System.Drawing.Point(621, 57);
            this.II_2_1.MaskInput = "{LOC}n,nnn,nnn,nnn.nn";
            this.II_2_1.MaxValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.II_2_1.MinValue = 0;
            this.II_2_1.Name = "II_2_1";
            this.II_2_1.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.II_2_1.PromptChar = ' ';
            this.II_2_1.Size = new System.Drawing.Size(112, 16);
            this.II_2_1.TabIndex = 45;
            this.II_2_1.TabNavigation = Infragistics.Win.UltraWinMaskedEdit.MaskedEditTabNavigation.NextControl;
            this.II_2_1.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.II_2_1.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // II_2_1_1
            // 
            appearance20.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance20.BorderAlpha = Infragistics.Win.Alpha.Transparent;
            appearance20.ForeColor = System.Drawing.Color.MidnightBlue;
            this.II_2_1_1.Appearance = appearance20;
            this.II_2_1_1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.II_2_1_1.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.II_2_1_1.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2003;
            this.II_2_1_1.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.II_2_1_1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.II_2_1_1.Location = new System.Drawing.Point(621, 75);
            this.II_2_1_1.MaskInput = "{LOC}n,nnn,nnn,nnn.nn";
            this.II_2_1_1.MaxValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.II_2_1_1.MinValue = 0;
            this.II_2_1_1.Name = "II_2_1_1";
            this.II_2_1_1.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.II_2_1_1.PromptChar = ' ';
            this.II_2_1_1.Size = new System.Drawing.Size(112, 16);
            this.II_2_1_1.TabIndex = 46;
            this.II_2_1_1.TabNavigation = Infragistics.Win.UltraWinMaskedEdit.MaskedEditTabNavigation.NextControl;
            this.II_2_1_1.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.II_2_1_1.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // II_2_1_2
            // 
            appearance19.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance19.BorderAlpha = Infragistics.Win.Alpha.Transparent;
            appearance19.ForeColor = System.Drawing.Color.MidnightBlue;
            this.II_2_1_2.Appearance = appearance19;
            this.II_2_1_2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.II_2_1_2.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.II_2_1_2.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2003;
            this.II_2_1_2.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.II_2_1_2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.II_2_1_2.Location = new System.Drawing.Point(621, 93);
            this.II_2_1_2.MaskInput = "{LOC}n,nnn,nnn,nnn.nn";
            this.II_2_1_2.MaxValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.II_2_1_2.MinValue = 0;
            this.II_2_1_2.Name = "II_2_1_2";
            this.II_2_1_2.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.II_2_1_2.PromptChar = ' ';
            this.II_2_1_2.Size = new System.Drawing.Size(112, 16);
            this.II_2_1_2.TabIndex = 47;
            this.II_2_1_2.TabNavigation = Infragistics.Win.UltraWinMaskedEdit.MaskedEditTabNavigation.NextControl;
            this.II_2_1_2.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.II_2_1_2.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // II_2_1_3
            // 
            appearance18.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance18.BorderAlpha = Infragistics.Win.Alpha.Transparent;
            appearance18.ForeColor = System.Drawing.Color.MidnightBlue;
            this.II_2_1_3.Appearance = appearance18;
            this.II_2_1_3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.II_2_1_3.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.II_2_1_3.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2003;
            this.II_2_1_3.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.II_2_1_3.ForeColor = System.Drawing.Color.MidnightBlue;
            this.II_2_1_3.Location = new System.Drawing.Point(621, 111);
            this.II_2_1_3.MaskInput = "{LOC}n,nnn,nnn,nnn.nn";
            this.II_2_1_3.MaxValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.II_2_1_3.MinValue = 0;
            this.II_2_1_3.Name = "II_2_1_3";
            this.II_2_1_3.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.II_2_1_3.PromptChar = ' ';
            this.II_2_1_3.Size = new System.Drawing.Size(112, 16);
            this.II_2_1_3.TabIndex = 48;
            this.II_2_1_3.TabNavigation = Infragistics.Win.UltraWinMaskedEdit.MaskedEditTabNavigation.NextControl;
            this.II_2_1_3.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.II_2_1_3.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // II_8
            // 
            appearance5.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance5.BorderAlpha = Infragistics.Win.Alpha.Transparent;
            appearance5.ForeColor = System.Drawing.Color.MidnightBlue;
            this.II_8.Appearance = appearance5;
            this.II_8.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.II_8.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.II_8.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2003;
            this.II_8.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.II_8.ForeColor = System.Drawing.Color.MidnightBlue;
            this.II_8.Location = new System.Drawing.Point(621, 327);
            this.II_8.MaskInput = "{LOC}n,nnn,nnn,nnn";
            this.II_8.MaxValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.II_8.MinValue = 0;
            this.II_8.Name = "II_8";
            this.II_8.PromptChar = ' ';
            this.II_8.Size = new System.Drawing.Size(112, 16);
            this.II_8.TabIndex = 60;
            this.II_8.TabNavigation = Infragistics.Win.UltraWinMaskedEdit.MaskedEditTabNavigation.NextControl;
            this.II_8.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.II_8.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // II_2_2
            // 
            appearance17.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance17.BorderAlpha = Infragistics.Win.Alpha.Transparent;
            appearance17.ForeColor = System.Drawing.Color.MidnightBlue;
            this.II_2_2.Appearance = appearance17;
            this.II_2_2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.II_2_2.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.II_2_2.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2003;
            this.II_2_2.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.II_2_2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.II_2_2.Location = new System.Drawing.Point(621, 129);
            this.II_2_2.MaskInput = "{LOC}n,nnn,nnn,nnn.nn";
            this.II_2_2.MaxValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.II_2_2.MinValue = 0;
            this.II_2_2.Name = "II_2_2";
            this.II_2_2.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.II_2_2.PromptChar = ' ';
            this.II_2_2.Size = new System.Drawing.Size(112, 16);
            this.II_2_2.TabIndex = 49;
            this.II_2_2.TabNavigation = Infragistics.Win.UltraWinMaskedEdit.MaskedEditTabNavigation.NextControl;
            this.II_2_2.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.II_2_2.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // II_7
            // 
            appearance6.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance6.BorderAlpha = Infragistics.Win.Alpha.Transparent;
            appearance6.ForeColor = System.Drawing.Color.MidnightBlue;
            this.II_7.Appearance = appearance6;
            this.II_7.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.II_7.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.II_7.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2003;
            this.II_7.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.II_7.ForeColor = System.Drawing.Color.MidnightBlue;
            this.II_7.Location = new System.Drawing.Point(621, 309);
            this.II_7.MaskInput = "{LOC}-n,nnn,nnn,nnn.nn";
            this.II_7.MaxValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.II_7.MinValue = -9999999;
            this.II_7.Name = "II_7";
            this.II_7.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.II_7.PromptChar = ' ';
            this.II_7.Size = new System.Drawing.Size(112, 16);
            this.II_7.TabIndex = 59;
            this.II_7.TabNavigation = Infragistics.Win.UltraWinMaskedEdit.MaskedEditTabNavigation.NextControl;
            this.II_7.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.II_7.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // II_2_2_1
            // 
            appearance16.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance16.BorderAlpha = Infragistics.Win.Alpha.Transparent;
            appearance16.ForeColor = System.Drawing.Color.MidnightBlue;
            this.II_2_2_1.Appearance = appearance16;
            this.II_2_2_1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.II_2_2_1.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.II_2_2_1.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2003;
            this.II_2_2_1.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.II_2_2_1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.II_2_2_1.Location = new System.Drawing.Point(621, 147);
            this.II_2_2_1.MaskInput = "{LOC}n,nnn,nnn,nnn.nn";
            this.II_2_2_1.MaxValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.II_2_2_1.MinValue = 0;
            this.II_2_2_1.Name = "II_2_2_1";
            this.II_2_2_1.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.II_2_2_1.PromptChar = ' ';
            this.II_2_2_1.Size = new System.Drawing.Size(112, 16);
            this.II_2_2_1.TabIndex = 50;
            this.II_2_2_1.TabNavigation = Infragistics.Win.UltraWinMaskedEdit.MaskedEditTabNavigation.NextControl;
            this.II_2_2_1.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.II_2_2_1.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // II_6_2
            // 
            appearance7.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance7.BorderAlpha = Infragistics.Win.Alpha.Transparent;
            appearance7.ForeColor = System.Drawing.Color.MidnightBlue;
            this.II_6_2.Appearance = appearance7;
            this.II_6_2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.II_6_2.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.II_6_2.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2003;
            this.II_6_2.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.II_6_2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.II_6_2.Location = new System.Drawing.Point(621, 291);
            this.II_6_2.MaskInput = "{LOC}-n,nnn,nnn,nnn.nn";
            this.II_6_2.MaxValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.II_6_2.MinValue = -9999999;
            this.II_6_2.Name = "II_6_2";
            this.II_6_2.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.II_6_2.PromptChar = ' ';
            this.II_6_2.Size = new System.Drawing.Size(112, 16);
            this.II_6_2.TabIndex = 58;
            this.II_6_2.TabNavigation = Infragistics.Win.UltraWinMaskedEdit.MaskedEditTabNavigation.NextControl;
            this.II_6_2.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.II_6_2.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // II_2_2_2
            // 
            appearance15.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance15.BorderAlpha = Infragistics.Win.Alpha.Transparent;
            appearance15.ForeColor = System.Drawing.Color.MidnightBlue;
            this.II_2_2_2.Appearance = appearance15;
            this.II_2_2_2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.II_2_2_2.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.II_2_2_2.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2003;
            this.II_2_2_2.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.II_2_2_2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.II_2_2_2.Location = new System.Drawing.Point(621, 165);
            this.II_2_2_2.MaskInput = "{LOC}n,nnn,nnn,nnn.nn";
            this.II_2_2_2.MaxValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.II_2_2_2.MinValue = 0;
            this.II_2_2_2.Name = "II_2_2_2";
            this.II_2_2_2.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.II_2_2_2.PromptChar = ' ';
            this.II_2_2_2.Size = new System.Drawing.Size(112, 16);
            this.II_2_2_2.TabIndex = 51;
            this.II_2_2_2.TabNavigation = Infragistics.Win.UltraWinMaskedEdit.MaskedEditTabNavigation.NextControl;
            this.II_2_2_2.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.II_2_2_2.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // II_6_1
            // 
            appearance8.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance8.BorderAlpha = Infragistics.Win.Alpha.Transparent;
            appearance8.ForeColor = System.Drawing.Color.MidnightBlue;
            this.II_6_1.Appearance = appearance8;
            this.II_6_1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.II_6_1.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.II_6_1.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2003;
            this.II_6_1.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.II_6_1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.II_6_1.Location = new System.Drawing.Point(621, 273);
            this.II_6_1.MaskInput = "{LOC}-n,nnn,nnn,nnn.nn";
            this.II_6_1.MaxValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.II_6_1.MinValue = -9999999;
            this.II_6_1.Name = "II_6_1";
            this.II_6_1.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.II_6_1.PromptChar = ' ';
            this.II_6_1.Size = new System.Drawing.Size(112, 16);
            this.II_6_1.TabIndex = 57;
            this.II_6_1.TabNavigation = Infragistics.Win.UltraWinMaskedEdit.MaskedEditTabNavigation.NextControl;
            this.II_6_1.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.II_6_1.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // II_2_2_3
            // 
            appearance14.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance14.BorderAlpha = Infragistics.Win.Alpha.Transparent;
            appearance14.ForeColor = System.Drawing.Color.MidnightBlue;
            this.II_2_2_3.Appearance = appearance14;
            this.II_2_2_3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.II_2_2_3.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.II_2_2_3.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2003;
            this.II_2_2_3.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.II_2_2_3.ForeColor = System.Drawing.Color.MidnightBlue;
            this.II_2_2_3.Location = new System.Drawing.Point(621, 183);
            this.II_2_2_3.MaskInput = "{LOC}n,nnn,nnn,nnn.nn";
            this.II_2_2_3.MaxValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.II_2_2_3.MinValue = 0;
            this.II_2_2_3.Name = "II_2_2_3";
            this.II_2_2_3.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.II_2_2_3.PromptChar = ' ';
            this.II_2_2_3.Size = new System.Drawing.Size(112, 16);
            this.II_2_2_3.TabIndex = 52;
            this.II_2_2_3.TabNavigation = Infragistics.Win.UltraWinMaskedEdit.MaskedEditTabNavigation.NextControl;
            this.II_2_2_3.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.II_2_2_3.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // II_6
            // 
            appearance9.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance9.BorderAlpha = Infragistics.Win.Alpha.Transparent;
            appearance9.ForeColor = System.Drawing.Color.MidnightBlue;
            this.II_6.Appearance = appearance9;
            this.II_6.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.II_6.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.II_6.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2003;
            this.II_6.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.II_6.ForeColor = System.Drawing.Color.MidnightBlue;
            this.II_6.Location = new System.Drawing.Point(621, 255);
            this.II_6.MaskInput = "{LOC}-n,nnn,nnn,nnn.nn";
            this.II_6.MaxValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.II_6.MinValue = 0;
            this.II_6.Name = "II_6";
            this.II_6.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.II_6.PromptChar = ' ';
            this.II_6.Size = new System.Drawing.Size(112, 16);
            this.II_6.TabIndex = 56;
            this.II_6.TabNavigation = Infragistics.Win.UltraWinMaskedEdit.MaskedEditTabNavigation.NextControl;
            this.II_6.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.II_6.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // II_3
            // 
            appearance13.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance13.BorderAlpha = Infragistics.Win.Alpha.Transparent;
            appearance13.ForeColor = System.Drawing.Color.MidnightBlue;
            this.II_3.Appearance = appearance13;
            this.II_3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.II_3.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.II_3.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2003;
            this.II_3.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.II_3.ForeColor = System.Drawing.Color.MidnightBlue;
            this.II_3.Location = new System.Drawing.Point(621, 201);
            this.II_3.MaskInput = "{LOC}n,nnn,nnn,nnn.nn";
            this.II_3.MaxValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.II_3.MinValue = 0;
            this.II_3.Name = "II_3";
            this.II_3.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.II_3.PromptChar = ' ';
            this.II_3.Size = new System.Drawing.Size(112, 16);
            this.II_3.TabIndex = 53;
            this.II_3.TabNavigation = Infragistics.Win.UltraWinMaskedEdit.MaskedEditTabNavigation.NextControl;
            this.II_3.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.II_3.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // II_5
            // 
            appearance10.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance10.BorderAlpha = Infragistics.Win.Alpha.Transparent;
            appearance10.ForeColor = System.Drawing.Color.MidnightBlue;
            this.II_5.Appearance = appearance10;
            this.II_5.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.II_5.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.II_5.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2003;
            this.II_5.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.II_5.ForeColor = System.Drawing.Color.MidnightBlue;
            this.II_5.Location = new System.Drawing.Point(621, 237);
            this.II_5.MaskInput = "{LOC}n,nnn,nnn,nnn.nn";
            this.II_5.MaxValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.II_5.MinValue = 0;
            this.II_5.Name = "II_5";
            this.II_5.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.II_5.PromptChar = ' ';
            this.II_5.Size = new System.Drawing.Size(112, 16);
            this.II_5.TabIndex = 55;
            this.II_5.TabNavigation = Infragistics.Win.UltraWinMaskedEdit.MaskedEditTabNavigation.NextControl;
            this.II_5.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.II_5.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // II_4
            // 
            appearance11.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance11.BorderAlpha = Infragistics.Win.Alpha.Transparent;
            appearance11.ForeColor = System.Drawing.Color.MidnightBlue;
            this.II_4.Appearance = appearance11;
            this.II_4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.II_4.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.II_4.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2003;
            this.II_4.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.II_4.ForeColor = System.Drawing.Color.MidnightBlue;
            this.II_4.Location = new System.Drawing.Point(621, 219);
            this.II_4.MaskInput = "{LOC}n,nnn,nnn,nnn.nn";
            this.II_4.MaxValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.II_4.MinValue = 0;
            this.II_4.Name = "II_4";
            this.II_4.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.II_4.PromptChar = ' ';
            this.II_4.Size = new System.Drawing.Size(112, 16);
            this.II_4.TabIndex = 54;
            this.II_4.TabNavigation = Infragistics.Win.UltraWinMaskedEdit.MaskedEditTabNavigation.NextControl;
            this.II_4.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.II_4.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // UltraTabPageControl6
            // 
            this.UltraTabPageControl6.Controls.Add(this.UltraGrid1);
            this.UltraTabPageControl6.Location = new System.Drawing.Point(-10000, -10000);
            this.UltraTabPageControl6.Name = "UltraTabPageControl6";
            this.UltraTabPageControl6.Size = new System.Drawing.Size(1106, 908);
            // 
            // UltraGrid1
            // 
            this.UltraGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.UltraGrid1.DataMember = "sp_id_zaglavlje.sp_id_zaglavlje_sp_id_detalji";
            this.UltraGrid1.DataSource = this.DsIDObrazac1;
            appearance26.BackColor = System.Drawing.Color.White;
            appearance26.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(167)))), ((int)(((byte)(191)))));
            appearance26.BackGradientStyle = Infragistics.Win.GradientStyle.ForwardDiagonal;
            this.UltraGrid1.DisplayLayout.Appearance = appearance26;
            this.UltraGrid1.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
            ultraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn1.Hidden = true;
            ultraGridColumn2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn2.Header.Caption = "Rbr";
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridColumn2.Width = 89;
            ultraGridColumn3.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn3.Header.Caption = "Općina";
            ultraGridColumn3.Header.VisiblePosition = 2;
            ultraGridColumn3.Width = 219;
            ultraGridColumn4.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn4.Header.Caption = "Naziv";
            ultraGridColumn4.Header.VisiblePosition = 3;
            ultraGridColumn4.Width = 224;
            ultraGridColumn5.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            appearance1.TextHAlignAsString = "Right";
            ultraGridColumn5.CellAppearance = appearance1;
            appearance25.TextHAlignAsString = "Right";
            ultraGridColumn5.Header.Appearance = appearance25;
            ultraGridColumn5.Header.Caption = "Porez";
            ultraGridColumn5.Header.VisiblePosition = 4;
            ultraGridColumn5.Width = 184;
            ultraGridColumn6.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            appearance32.TextHAlignAsString = "Right";
            ultraGridColumn6.CellAppearance = appearance32;
            appearance33.TextHAlignAsString = "Right";
            ultraGridColumn6.Header.Appearance = appearance33;
            ultraGridColumn6.Header.Caption = "Prirez";
            ultraGridColumn6.Header.VisiblePosition = 5;
            ultraGridColumn6.Width = 184;
            ultraGridColumn7.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            appearance35.TextHAlignAsString = "Right";
            ultraGridColumn7.CellAppearance = appearance35;
            appearance36.TextHAlignAsString = "Right";
            ultraGridColumn7.Header.Appearance = appearance36;
            ultraGridColumn7.Header.Caption = "Ukupno";
            ultraGridColumn7.Header.VisiblePosition = 6;
            ultraGridColumn7.Width = 184;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4,
            ultraGridColumn5,
            ultraGridColumn6,
            ultraGridColumn7});
            this.UltraGrid1.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.UltraGrid1.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            this.UltraGrid1.DisplayLayout.InterBandSpacing = 10;
            this.UltraGrid1.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.UltraGrid1.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.UltraGrid1.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
            appearance27.BackColor = System.Drawing.Color.Transparent;
            this.UltraGrid1.DisplayLayout.Override.CardAreaAppearance = appearance27;
            this.UltraGrid1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            this.UltraGrid1.DisplayLayout.Override.ColumnAutoSizeMode = Infragistics.Win.UltraWinGrid.ColumnAutoSizeMode.AllRowsInBand;
            appearance28.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(249)))));
            appearance28.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(167)))), ((int)(((byte)(191)))));
            appearance28.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance28.ForeColor = System.Drawing.Color.Black;
            appearance28.TextHAlignAsString = "Left";
            appearance28.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.UltraGrid1.DisplayLayout.Override.HeaderAppearance = appearance28;
            this.UltraGrid1.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            appearance29.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(167)))), ((int)(((byte)(191)))));
            this.UltraGrid1.DisplayLayout.Override.RowAppearance = appearance29;
            appearance30.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(249)))));
            appearance30.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(167)))), ((int)(((byte)(191)))));
            appearance30.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.UltraGrid1.DisplayLayout.Override.RowSelectorAppearance = appearance30;
            this.UltraGrid1.DisplayLayout.Override.RowSelectorWidth = 12;
            this.UltraGrid1.DisplayLayout.Override.RowSpacingBefore = 2;
            appearance31.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(167)))), ((int)(((byte)(191)))));
            appearance31.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(249)))));
            appearance31.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance31.ForeColor = System.Drawing.Color.Black;
            this.UltraGrid1.DisplayLayout.Override.SelectedRowAppearance = appearance31;
            this.UltraGrid1.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.UltraGrid1.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.UltraGrid1.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
            this.UltraGrid1.DisplayLayout.RowConnectorColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(167)))), ((int)(((byte)(191)))));
            this.UltraGrid1.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Solid;
            this.UltraGrid1.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.UltraGrid1.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.UltraGrid1.DisplayLayout.TabNavigation = Infragistics.Win.UltraWinGrid.TabNavigation.NextControl;
            this.UltraGrid1.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.UltraGrid1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UltraGrid1.Location = new System.Drawing.Point(4, 4);
            this.UltraGrid1.Name = "UltraGrid1";
            this.UltraGrid1.Size = new System.Drawing.Size(1098, 899);
            this.UltraGrid1.TabIndex = 0;
            this.UltraGrid1.Text = "UltraGrid1";
            // 
            // DsIDObrazac1
            // 
            this.DsIDObrazac1.DataSetName = "dsIDObrazac";
            this.DsIDObrazac1.Locale = new System.Globalization.CultureInfo("hr-HR");
            this.DsIDObrazac1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // SqlSelectCommand2
            // 
            this.SqlSelectCommand2.CommandText = "EXEC S_OD_ID_OBRAZAC_DETALJI";
            // 
            // SqlSelectCommand1
            // 
            this.SqlSelectCommand1.CommandText = "EXEC S_OD_ID_OBRAZAC_ZAGLAVLJE";
            // 
            // daDetalji
            // 
            this.daDetalji.SelectCommand = this.SqlSelectCommand2;
            // 
            // daZaglavlje
            // 
            this.daZaglavlje.SelectCommand = this.SqlSelectCommand1;
            // 
            // TAB1
            // 
            this.TAB1.BackColorInternal = System.Drawing.Color.LightSteelBlue;
            this.TAB1.Controls.Add(this.UltraTabSharedControlsPage2);
            this.TAB1.Controls.Add(this.UltraTabPageControl6);
            this.TAB1.Controls.Add(this.UltraTabPageControl7);
            this.TAB1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TAB1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.TAB1.Location = new System.Drawing.Point(0, 0);
            this.TAB1.Name = "TAB1";
            this.TAB1.ScrollButtons = Infragistics.Win.UltraWinTabs.TabScrollButtons.Always;
            this.TAB1.SharedControlsPage = this.UltraTabSharedControlsPage2;
            this.TAB1.Size = new System.Drawing.Size(1108, 933);
            this.TAB1.TabIndex = 194;
            tab.Key = "stranica1";
            tab.TabPage = this.UltraTabPageControl7;
            tab.Text = "Prva stranica";
            tab2.Key = "stranica2";
            tab2.TabPage = this.UltraTabPageControl6;
            tab2.Text = "Porez i prirez prema općini/gradu";
            this.TAB1.Tabs.AddRange(new Infragistics.Win.UltraWinTabControl.UltraTab[] {
            tab,
            tab2});
            this.TAB1.TabSize = new System.Drawing.Size(0, 23);
            this.TAB1.TabsPerRow = 5;
            this.TAB1.UseAppStyling = false;
            this.TAB1.ViewStyle = Infragistics.Win.UltraWinTabControl.ViewStyle.Office2007;
            // 
            // UltraTabSharedControlsPage2
            // 
            this.UltraTabSharedControlsPage2.Location = new System.Drawing.Point(-10000, -10000);
            this.UltraTabSharedControlsPage2.Name = "UltraTabSharedControlsPage2";
            this.UltraTabSharedControlsPage2.Size = new System.Drawing.Size(1106, 908);
            // 
            // UltraDockManager1
            // 
            this.UltraDockManager1.HostControl = this;
            // 
            // _IDObrazacUnpinnedTabAreaLeft
            // 
            this._IDObrazacUnpinnedTabAreaLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this._IDObrazacUnpinnedTabAreaLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._IDObrazacUnpinnedTabAreaLeft.Location = new System.Drawing.Point(0, 0);
            this._IDObrazacUnpinnedTabAreaLeft.Name = "_IDObrazacUnpinnedTabAreaLeft";
            this._IDObrazacUnpinnedTabAreaLeft.Owner = this.UltraDockManager1;
            this._IDObrazacUnpinnedTabAreaLeft.Size = new System.Drawing.Size(0, 933);
            this._IDObrazacUnpinnedTabAreaLeft.TabIndex = 195;
            // 
            // _IDObrazacUnpinnedTabAreaRight
            // 
            this._IDObrazacUnpinnedTabAreaRight.Dock = System.Windows.Forms.DockStyle.Right;
            this._IDObrazacUnpinnedTabAreaRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._IDObrazacUnpinnedTabAreaRight.Location = new System.Drawing.Point(1108, 0);
            this._IDObrazacUnpinnedTabAreaRight.Name = "_IDObrazacUnpinnedTabAreaRight";
            this._IDObrazacUnpinnedTabAreaRight.Owner = this.UltraDockManager1;
            this._IDObrazacUnpinnedTabAreaRight.Size = new System.Drawing.Size(0, 933);
            this._IDObrazacUnpinnedTabAreaRight.TabIndex = 196;
            // 
            // _IDObrazacUnpinnedTabAreaTop
            // 
            this._IDObrazacUnpinnedTabAreaTop.Dock = System.Windows.Forms.DockStyle.Top;
            this._IDObrazacUnpinnedTabAreaTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._IDObrazacUnpinnedTabAreaTop.Location = new System.Drawing.Point(0, 0);
            this._IDObrazacUnpinnedTabAreaTop.Name = "_IDObrazacUnpinnedTabAreaTop";
            this._IDObrazacUnpinnedTabAreaTop.Owner = this.UltraDockManager1;
            this._IDObrazacUnpinnedTabAreaTop.Size = new System.Drawing.Size(1108, 0);
            this._IDObrazacUnpinnedTabAreaTop.TabIndex = 197;
            // 
            // _IDObrazacUnpinnedTabAreaBottom
            // 
            this._IDObrazacUnpinnedTabAreaBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._IDObrazacUnpinnedTabAreaBottom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._IDObrazacUnpinnedTabAreaBottom.Location = new System.Drawing.Point(0, 933);
            this._IDObrazacUnpinnedTabAreaBottom.Name = "_IDObrazacUnpinnedTabAreaBottom";
            this._IDObrazacUnpinnedTabAreaBottom.Owner = this.UltraDockManager1;
            this._IDObrazacUnpinnedTabAreaBottom.Size = new System.Drawing.Size(1108, 0);
            this._IDObrazacUnpinnedTabAreaBottom.TabIndex = 198;
            // 
            // _IDObrazacAutoHideControl
            // 
            this._IDObrazacAutoHideControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._IDObrazacAutoHideControl.Location = new System.Drawing.Point(0, 0);
            this._IDObrazacAutoHideControl.Name = "_IDObrazacAutoHideControl";
            this._IDObrazacAutoHideControl.Owner = this.UltraDockManager1;
            this._IDObrazacAutoHideControl.Size = new System.Drawing.Size(0, 0);
            this._IDObrazacAutoHideControl.TabIndex = 199;
            // 
            // IDObrazac
            // 
            this.Controls.Add(this._IDObrazacAutoHideControl);
            this.Controls.Add(this.TAB1);
            this.Controls.Add(this._IDObrazacUnpinnedTabAreaTop);
            this.Controls.Add(this._IDObrazacUnpinnedTabAreaBottom);
            this.Controls.Add(this._IDObrazacUnpinnedTabAreaLeft);
            this.Controls.Add(this._IDObrazacUnpinnedTabAreaRight);
            this.Name = "IDObrazac";
            this.Size = new System.Drawing.Size(1108, 933);
            this.UltraTabPageControl7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.UltraGroupBox2)).EndInit();
            this.UltraGroupBox2.ResumeLayout(false);
            this.UltraGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NazivUstanove)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Adresa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.oib)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Identifikator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltraGroupBox4)).EndInit();
            this.UltraGroupBox4.ResumeLayout(false);
            this.UltraGroupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udteDatumSastavljanja)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.III_1_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.III_1_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.III_2_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.III_2_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.III_3_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.III_3_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.III_5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.III_3_3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.III_4_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.III_4_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltraGroupBox3)).EndInit();
            this.UltraGroupBox3.ResumeLayout(false);
            this.UltraGroupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.II_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.II_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.II_2_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.II_2_1_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.II_2_1_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.II_2_1_3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.II_8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.II_2_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.II_7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.II_2_2_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.II_6_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.II_2_2_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.II_6_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.II_2_2_3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.II_6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.II_3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.II_5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.II_4)).EndInit();
            this.UltraTabPageControl6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.UltraGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DsIDObrazac1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TAB1)).EndInit();
            this.TAB1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.UltraDockManager1)).EndInit();
            this.ResumeLayout(false);

        }

        private void Ispis_ID_Obrasca_Papir()
        {
            this.BindingContext[this.DsIDObrazac1.sp_id_zaglavlje].EndCurrentEdit();
            this.BindingContext[this.DsIDObrazac1.sp_id_detalji].EndCurrentEdit();
            ReportDocument document = new ReportDocument();
            ExtendedWindowSmartPartInfo info = new ExtendedWindowSmartPartInfo {
                StartPosition = FormStartPosition.CenterParent,
                Modal = true,
                Title = "Pregled izvještaja - ID Obrazac",
                Description = "Pregled izvještaja - ID Obrazac",
                Icon = ImageResourcesNew.mbs
            };
            document.Load(System.Windows.Forms.Application.StartupPath + @"\Izvjestaji\rptObrazacID.rpt");
            document.SetDataSource(this.DsIDObrazac1);
            if (this.strSifraObracuna != null)
            {
                this.strMI = string.Format("{0:00}", this.strMI);
                this.strGI = string.Format("{0:0000}", this.strGI);
                this.strGI = string.Format("{0} obračun {1}", this.strGI, this.strSifraObracuna);
                document.SetParameterValue("mjesec_ime", DB.MjesecNazivDativ(Conversions.ToInteger(this.strMI)).ToUpper());
                document.SetParameterValue("godina", this.strGI);
            }
            else
            {
                this.strMI = string.Format("{0:00}", this.strMI);
                this.strGI = string.Format("{0:0000}", this.strGI);
                document.SetParameterValue("mjesec_ime", DB.MjesecNazivDativ(Conversions.ToInteger(this.strMI)).ToUpper());
                document.SetParameterValue("godina", this.strGI);
            }
            ExtendedWindowWorkspace workspace = new ExtendedWindowWorkspace();
            PreviewReportWorkItem item = this.Controller.WorkItem.Items.Get<PreviewReportWorkItem>("Pregled");
            if (item == null)
            {
                item = this.Controller.WorkItem.Items.AddNew<PreviewReportWorkItem>("Pregled");
            }
            item.Izvjestaj = document;
            item.Show(item.Workspaces["main"], info);
        }

        private void Ispis_ID_Obrasca_Papir2011()
        {
            this.BindingContext[this.DsIDObrazac1.sp_id_zaglavlje].EndCurrentEdit();
            this.BindingContext[this.DsIDObrazac1.sp_id_detalji].EndCurrentEdit();
            ReportDocument document = new ReportDocument();
            ExtendedWindowSmartPartInfo info = new ExtendedWindowSmartPartInfo
            {
                StartPosition = FormStartPosition.CenterParent,
                Modal = true,
                Title = "Pregled izvještaja - ID Obrazac / 2011",
                Description = "Pregled izvještaja - ID Obrazac / 2011",
                Icon = ImageResourcesNew.mbs
            };
            document.Load(System.Windows.Forms.Application.StartupPath + @"\Izvjestaji\rptObrazacID2011.rpt");
            document.SetDataSource(this.DsIDObrazac1);

            if (string.IsNullOrWhiteSpace(this.strMI))
            {
                MessageBox.Show("Izvještaj nije moguće generirati, ukoliko nije postavljen mjesec!", "Greška u izvještaju");
                return;
            }

            if (this.strSifraObracuna != null)
            {
                this.strMI = string.Format("{0:00}", this.strMI);
                this.strGI = string.Format("{0:0000}", this.strGI);
                this.strGI = string.Format("{0} obračun {1}", this.strGI, this.strSifraObracuna);
                document.SetParameterValue("mjesec_ime", DB.MjesecNazivDativ(Conversions.ToInteger(this.strMI)).ToUpper());
                document.SetParameterValue("godina", this.strGI);
            }
            else
            {
                this.strMI = string.Format("{0:00}", this.strMI);
                this.strGI = string.Format("{0:0000}", this.strGI);
                document.SetParameterValue("mjesec_ime", DB.MjesecNazivDativ(Conversions.ToInteger(this.strMI)).ToUpper());
                document.SetParameterValue("godina", this.strGI);
            }
            ExtendedWindowWorkspace workspace = new ExtendedWindowWorkspace();
            PreviewReportWorkItem item = this.Controller.WorkItem.Items.Get<PreviewReportWorkItem>("Pregled");
            if (item == null)
            {
                item = this.Controller.WorkItem.Items.AddNew<PreviewReportWorkItem>("Pregled");
            }
            item.Izvjestaj = document;
            item.Show(item.Workspaces["main"], info);
        }

        [LocalCommandHandler("Ispis2011")]
        public void Ispis2011Handler(object sender, EventArgs e)
        {
            this.Ispis_ID_Obrasca_Papir2011();
        }

        [LocalCommandHandler("Ispis")]
        public void IspisHandler(object sender, EventArgs e)
        {
            this.Ispis_ID_Obrasca_Papir();
        }

        public void OtvoriObracun()
        {
            SqlConnection connection2 = new SqlConnection {
                ConnectionString = Configuration.ConnectionString
            };
            SqlConnection connection = connection2;
            using (frmPregledObracuna obracuna = new frmPregledObracuna())
            {
                obracuna.ShowDialog();
                if ((obracuna.DialogResult != DialogResult.Cancel) && (obracuna.ObracunSelected != null))
                {
                    this.DSZAGLAVLJE.Clear();
                    this.DSDETALJI.Clear();
                    this.strMI = Conversions.ToString(obracuna.OdabraniMjesecIsplate);
                    this.strGI = Conversions.ToString(obracuna.OdabraniGodinaIsplate);
                    this.strSifraObracuna = Conversions.ToString(obracuna.ObracunSelected);
                    this.ZAGLAVLJE.Fill(this.DSZAGLAVLJE, Conversions.ToString(obracuna.ObracunSelected), null, null, 0);
                    this.detalji.Fill(this.DSDETALJI, Conversions.ToString(obracuna.ObracunSelected), null, null, 0);
                    this.DsIDObrazac1.Clear();
                    this.DsIDObrazac1.Merge(this.DSDETALJI.sp_id_detalji);
                    this.DsIDObrazac1.Merge(this.DSZAGLAVLJE.sp_id_zaglavlje);
                    this.Mjesec.Text = DB.MjesecNazivDativ(Conversions.ToInteger(this.strMI)).ToUpper();
                    this.Godina.Text = string.Format("{0}. obračun {1}", this.strGI, this.strSifraObracuna);
                }
            }
        }

        public void OtvoriObracun_Za_Mjesec()
        {
            SqlConnection connection = new SqlConnection {
                ConnectionString = Configuration.ConnectionString
            };
            frmPregledMjeseciGodina godina = new frmPregledMjeseciGodina();
            godina.ShowDialog();
            if ((godina.DialogResult != DialogResult.Cancel) && ((godina.OdabraniGodinaIsplate != null) & (godina.OdabraniMjesecIsplate != null)))
            {
                this.DSZAGLAVLJE.Clear();
                this.DSDETALJI.Clear();
                this.strMI = Conversions.ToString(godina.OdabraniMjesecIsplate);
                this.strGI = Conversions.ToString(godina.OdabraniGodinaIsplate);
                this.ZAGLAVLJE.Fill(this.DSZAGLAVLJE, null, Conversions.ToString(godina.OdabraniMjesecIsplate), Conversions.ToString(godina.OdabraniGodinaIsplate), godina.Volonteri);
                this.detalji.Fill(this.DSDETALJI, null, Conversions.ToString(godina.OdabraniMjesecIsplate), Conversions.ToString(godina.OdabraniGodinaIsplate), godina.Volonteri);
                this.Mjesec.Text = DB.MjesecNazivDativ(Conversions.ToInteger(this.strMI)).ToUpper();
                this.Godina.Text = this.strGI + ".";
                this.DsIDObrazac1.Clear();
                this.DsIDObrazac1.Merge(this.DSDETALJI.sp_id_detalji);
                this.DsIDObrazac1.Merge(this.DSZAGLAVLJE.sp_id_zaglavlje);
            }
        }

        private void UltraGroupBox2_Click(object sender, EventArgs e)
        {
        }

        private void UltraGroupBox4_Click(object sender, EventArgs e)
        {
        }

        private void UltraLabel1_Click(object sender, EventArgs e)
        {
        }

        private void UltraLabel14_Click(object sender, EventArgs e)
        {
        }

        private void UltraLabel15_Click(object sender, EventArgs e)
        {
        }

        private void UltraLabel37_Click(object sender, EventArgs e)
        {
        }

        private void UltraLabel5_Click(object sender, EventArgs e)
        {
        }

        [LocalCommandHandler("ZaMjesec")]
        public void ZaMjesecHandler(object sender, EventArgs e)
        {
            this.OtvoriObracun_Za_Mjesec();
        }

        [LocalCommandHandler("ZaObracun")]
        public void ZaObracun1Handler(object sender, EventArgs e)
        {
            this.OtvoriObracun();
        }

        private AutoHideControl _IDObrazacAutoHideControl;

        private UnpinnedTabArea _IDObrazacUnpinnedTabAreaBottom;

        private UnpinnedTabArea _IDObrazacUnpinnedTabAreaLeft;

        private UnpinnedTabArea _IDObrazacUnpinnedTabAreaRight;

        private UnpinnedTabArea _IDObrazacUnpinnedTabAreaTop;

        private UltraTextEditor Adresa;

        [CreateNew]
        public RSmObrazacController Controller { get; set; }

        private SqlDataAdapter daDetalji;

        private SqlDataAdapter daZaglavlje;

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

        private dsIdObrazac DsIDObrazac1;

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

        private Label Godina;

        private UltraTextEditor Identifikator;

        private UltraNumericEditor II_1;

        private UltraNumericEditor II_2;

        private UltraNumericEditor II_2_1;

        private UltraNumericEditor II_2_1_1;

        private UltraNumericEditor II_2_1_2;

        private UltraNumericEditor II_2_1_3;

        private UltraNumericEditor II_2_2;

        private UltraNumericEditor II_2_2_1;

        private UltraNumericEditor II_2_2_2;

        private UltraNumericEditor II_2_2_3;

        private UltraNumericEditor II_3;

        private UltraNumericEditor II_4;

        private UltraNumericEditor II_5;

        private UltraNumericEditor II_6;

        private UltraNumericEditor II_6_1;

        private UltraNumericEditor II_6_2;

        private UltraNumericEditor II_7;

        private UltraNumericEditor II_8;

        private UltraNumericEditor III_1_1;

        private UltraNumericEditor III_1_2;

        private UltraNumericEditor III_2_1;

        private UltraNumericEditor III_2_2;

        private UltraNumericEditor III_3_1;

        private UltraNumericEditor III_3_2;

        private UltraNumericEditor III_3_3;

        private UltraNumericEditor III_4_1;

        private UltraNumericEditor III_4_2;

        private UltraNumericEditor III_5;

        private Label Mjesec;

        public UltraTextEditor NazivUstanove;

        public UltraTextEditor oib;

        public DataRow SelectedRow
        {
            get
            {
                DataRow row = null;
                return row;
            }
        }

        private SqlCommand SqlSelectCommand1;

        private SqlCommand SqlSelectCommand2;

        private UltraTabControl TAB1;

        private UltraDateTimeEditor udteDatumSastavljanja;

        private UltraDockManager UltraDockManager1;

        private UltraGrid UltraGrid1;

        private UltraGroupBox UltraGroupBox2;

        private UltraGroupBox UltraGroupBox3;

        private UltraGroupBox UltraGroupBox4;

        private UltraLabel UltraLabel1;

        private UltraLabel UltraLabel10;

        private UltraLabel UltraLabel11;

        private UltraLabel UltraLabel12;

        private UltraLabel UltraLabel13;

        private UltraLabel UltraLabel14;

        private UltraLabel UltraLabel15;

        private UltraLabel UltraLabel16;

        private UltraLabel UltraLabel17;

        private UltraLabel UltraLabel18;

        private UltraLabel UltraLabel19;

        private UltraLabel UltraLabel2;

        private UltraLabel UltraLabel20;

        private UltraLabel UltraLabel21;

        private UltraLabel UltraLabel22;

        private UltraLabel UltraLabel23;

        private UltraLabel UltraLabel24;

        private UltraLabel UltraLabel25;

        private UltraLabel UltraLabel26;

        private UltraLabel UltraLabel27;

        private UltraLabel UltraLabel28;

        private UltraLabel UltraLabel29;

        private UltraLabel UltraLabel3;

        private UltraLabel UltraLabel30;

        private UltraLabel UltraLabel31;

        private UltraLabel UltraLabel32;

        private UltraLabel UltraLabel33;

        private UltraLabel UltraLabel34;

        private UltraLabel UltraLabel35;

        private UltraLabel UltraLabel36;

        private UltraLabel UltraLabel37;

        private UltraLabel UltraLabel38;

        private UltraLabel UltraLabel39;

        private UltraLabel UltraLabel4;

        private UltraLabel UltraLabel5;

        private UltraLabel UltraLabel6;

        private UltraLabel UltraLabel7;

        private UltraLabel UltraLabel8;

        private UltraLabel UltraLabel9;

        private UltraTabPageControl UltraTabPageControl6;

        private UltraTabPageControl UltraTabPageControl7;

        private UltraTabSharedControlsPage UltraTabSharedControlsPage2;

        Deklarit.Practices.CompositeUI.WorkWithMode WorkWithMode
        {
            set
            {
            }
        }
    }
}


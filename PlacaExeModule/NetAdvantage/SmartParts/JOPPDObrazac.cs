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
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.SmartParts;
using Microsoft.Practices.ObjectBuilder;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using My.Resources;
using NetAdvantage.Controllers;
using NetAdvantage.WorkItems;
using mipsed.application.framework;
using Placa;
using RSM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Text;
using System.Xml.Serialization;
using System.Xml;

namespace NetAdvantage.SmartParts
{
    [SmartPart]
    public class JOPPDObrazac : UserControl, ISmartPartInfoProvider, IFilteredView
    {
        private IContainer components;

        private int? JOPPDID = null;
        private bool? IsObracunHonorara = null;
        private bool? IsObracunPutniNalog = null;
        private bool? IsObracunPlace = null;
        private bool? IsObracunPraksa = null;
        private bool? IsObracunRazno = null;
        private bool? IsVirmaniInvalid = null;

        private static string vrsta_izvjesca = "";
        
        private KORISNIKDataAdapter dataAdapterKorisnik;
        private KORISNIKDataSet dataSetKorisnik;

        private int broj_radnika = 0;
        private int broj_redaka = 0;
        private bool kontrola_broj = false;

        private SmartPartInfoProvider infoProvider;
        private UltraLabel ultraLabel1;
        private UltraLabel lblBrojOsoba;
        private UltraLabel lblBrojRedakaNaStraniB;
        private Panel panel1;
        private UltraMaskedEdit txtUkupno_VII;
        private UltraLabel ultraLabel77;
        private UltraLabel ultraLabel73;
        private UltraLabel ultraLabel74;
        private UltraMaskedEdit txtUkupno_VI_4_2;
        private UltraLabel ultraLabel75;
        private UltraLabel ultraLabel76;
        private UltraMaskedEdit txtUkupno_VI_4_1;
        private UltraLabel ultraLabel72;
        private UltraLabel ultraLabel64;
        private UltraLabel ultraLabel65;
        private UltraMaskedEdit txtUkupno_VI_3_10;
        private UltraLabel ultraLabel66;
        private UltraLabel ultraLabel67;
        private UltraMaskedEdit txtUkupno_VI_3_9;
        private UltraLabel ultraLabel68;
        private UltraLabel ultraLabel69;
        private UltraMaskedEdit txtUkupno_VI_3_8;
        private UltraLabel ultraLabel70;
        private UltraLabel ultraLabel71;
        private UltraMaskedEdit txtUkupno_VI_3_7;
        private UltraLabel ultraLabel57;
        private UltraLabel ultraLabel58;
        private UltraMaskedEdit txtUkupno_VI_3_6;
        private UltraLabel ultraLabel59;
        private UltraLabel ultraLabel60;
        private UltraMaskedEdit txtUkupno_VI_3_5;
        private UltraLabel ultraLabel62;
        private UltraLabel ultraLabel63;
        private UltraMaskedEdit txtUkupno_VI_3_4;
        private UltraLabel ultraLabel51;
        private UltraLabel ultraLabel52;
        private UltraMaskedEdit txtUkupno_VI_3_3;
        private UltraLabel ultraLabel53;
        private UltraLabel ultraLabel54;
        private UltraMaskedEdit txtUkupno_VI_3_2;
        private UltraLabel ultraLabel55;
        private UltraLabel ultraLabel56;
        private UltraMaskedEdit txtUkupno_VI_3_1;
        private UltraLabel ultraLabel61;
        private UltraLabel ultraLabel43;
        private UltraLabel ultraLabel44;
        private UltraMaskedEdit txtUkupno_VI_2_5;
        private UltraLabel ultraLabel45;
        private UltraLabel ultraLabel46;
        private UltraMaskedEdit txtUkupno_VI_2_4;
        private UltraLabel ultraLabel47;
        private UltraLabel ultraLabel48;
        private UltraMaskedEdit txtUkupno_VI_2_3;
        private UltraLabel ultraLabel49;
        private UltraLabel ultraLabel50;
        private UltraMaskedEdit txtUkupno_VI_2_2;
        private UltraLabel ultraLabel41;
        private UltraLabel ultraLabel42;
        private UltraMaskedEdit txtUkupno_VI_2_1;
        private UltraLabel ultraLabel40;
        private UltraLabel ultraLabel38;
        private UltraLabel ultraLabel39;
        private UltraMaskedEdit txtUkupno_VI_1_6;
        private UltraLabel ultraLabel36;
        private UltraLabel ultraLabel37;
        private UltraMaskedEdit txtUkupno_VI_1_5;
        private UltraLabel ultraLabel34;
        private UltraLabel ultraLabel35;
        private UltraMaskedEdit txtUkupno_VI_1_4;
        private UltraLabel ultraLabel32;
        private UltraLabel ultraLabel33;
        private UltraMaskedEdit txtUkupno_VI_1_3;
        private UltraLabel ultraLabel30;
        private UltraLabel ultraLabel31;
        private UltraMaskedEdit txtUkupno_VI_1_2;
        private UltraLabel ultraLabel28;
        private UltraLabel ultraLabel29;
        private UltraMaskedEdit txtUkupno_VI_1_1;
        private UltraLabel ultraLabel27;
        private UltraLabel ultraLabel26;
        private UltraLabel ultraLabel24;
        private UltraLabel ultraLabel25;
        private UltraMaskedEdit txtUkupno_V_5;
        private UltraLabel ultraLabel22;
        private UltraLabel ultraLabel23;
        private UltraMaskedEdit txtUkupno_V_4;
        private UltraLabel ultraLabel20;
        private UltraLabel ultraLabel21;
        private UltraMaskedEdit txtUkupno_V_3;
        private UltraLabel ultraLabel18;
        private UltraLabel ultraLabel19;
        private UltraMaskedEdit txtUkupno_V_2;
        private UltraLabel ultraLabel16;
        private UltraLabel ultraLabel17;
        private UltraMaskedEdit txtUkupno_V_1_2;
        private UltraLabel ultraLabel14;
        private UltraLabel ultraLabel15;
        private UltraMaskedEdit txtUkupno_V_1_1;
        private UltraLabel ultraLabel4;
        private UltraLabel ultraLabel3;
        private UltraLabel UltraLabel13;
        private UltraMaskedEdit txtUkupno_V_1;
        private Label label1;
        private UltraLabel lblVrstaIzvjesca;
        private UltraLabel lblOznakaIzvjesca;
        private UltraLabel lblIzvjesceNaDan;
        private UltraLabel ultraLabel2;
        private UltraLabel lblOznakaPodnositelja;
        private SmartPartInfo smartPartInfo1;
        private UltraMaskedEdit txtUkupnoVIII;
        private UltraLabel ultraLabel78;
        private UltraLabel ultraLabel80;
        private DataGridView dgvJOPPDB;
        private UltraLabel lblOznakaPod;
        private UltraLabel UltraLabel12;
        private UltraLabel ultraLabel79;
        private UltraLabel ultraLabel81;
        private UltraMaskedEdit txtUkupno_V_6;
        private WindowDockingArea WindowDockingArea1;
        private DockableWindow dockableWindow3;
        private WindowDockingArea WindowDockingArea2;
        private DockableWindow dockableWindow2;
        private WindowDockingArea WindowDockingArea3;
        private DockableWindow dockableWindow1;
        private UltraLabel ultraLabel84;
        private UltraLabel ultraLabel85;
        private UltraMaskedEdit txtUkupno_VI_2_6;
        private UltraLabel ultraLabel82;
        private UltraLabel ultraLabel83;
        private UltraMaskedEdit txtUkupno_VI_1_7;
        private UltraLabel ultraLabel92;
        private UltraLabel ultraLabel93;
        private UltraMaskedEdit txtUkupno_VI_4_4;
        private UltraLabel ultraLabel90;
        private UltraLabel ultraLabel91;
        private UltraMaskedEdit txtUkupno_VI_4_3;
        private UltraLabel ultraLabel88;
        private UltraLabel ultraLabel89;
        private UltraMaskedEdit txtUkupno_VI_3_12;
        private UltraLabel ultraLabel86;
        private UltraLabel ultraLabel87;
        private UltraMaskedEdit txtUkupno_VI_3_11;
        private UltraMaskedEdit txtUkupnoIX;
        private UltraLabel ultraLabel95;
        private UltraLabel ultraLabel94;
        private UltraLabel ultraLabel98;
        private UltraLabel ultraLabel99;
        private UltraMaskedEdit txtIznosNaknade;
        private UltraLabel ultraLabel100;
        private UltraLabel ultraLabel101;
        private UltraMaskedEdit txtBrojOsoba;
        private UltraLabel ultraLabel96;
        private UltraMaskedEdit txtUkupnoX;
        private UltraLabel ultraLabel97;
        Mipsed7.DataAccessLayer.SqlClient client;

        public JOPPDObrazac()
        {
            base.Load += new EventHandler(this.JOPPDObrazacLoad);
            smartPartInfo1 = new SmartPartInfo("JOPPDObrazac", "JOPPD Obrazac");
            infoProvider = new SmartPartInfoProvider();
            infoProvider.Items.Add(this.smartPartInfo1);
            InitializeComponent();

            // initialize adapters
            dataAdapterKorisnik = new KORISNIKDataAdapter();
            client = new Mipsed7.DataAccessLayer.SqlClient();
            dataSetKorisnik = new KORISNIKDataSet();

        }

        private void JOPPDObrazacLoad(object sender, EventArgs e)
        {
            this.dataAdapterKorisnik.Fill(this.dataSetKorisnik);
             
            txtNazivImePrezime.Text = dataSetKorisnik.KORISNIK.Rows[0]["KORISNIK1NAZIV"].ToString();
            txtAdresa.Text = string.Format("{0}, {1}", dataSetKorisnik.KORISNIK.Rows[0]["KORISNIK1ADRESA"].ToString(), dataSetKorisnik.KORISNIK.Rows[0]["KORISNIK1MJESTO"].ToString());
            txtAdresaElektronickePoste.Text = dataSetKorisnik.KORISNIK.Rows[0]["EMAIL"].ToString();
            txtOIB.Text = dataSetKorisnik.KORISNIK.Rows[0]["KORISNIKOIB"].ToString();
            try
            {
                lblOznakaPod.Text = client.ExecuteScalar("Select OznakaPodnositelja From JOPPDA Where ID = '" + JOPPDID + "'").ToString();
            }
            catch { }
           
        }

        private void LoadFormSettings_ObracunHonorara()
        {
            //dockableControlPane2.Text = "PODACI O OBVEZNIKU PLAĆANJA";
            //dockableControlPane3.Text = "SUMARNI PODACI PO OBVEZNIKU PLAĆANJA";
        }

        private static FileStream GetFileStream(string pathName)
        {
            return new FileStream(pathName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
        }

        public static string GetSHA1Hash(string pathName)
        {
            string str3 = "";
            FileStream inputStream = null;
            SHA1CryptoServiceProvider provider = new SHA1CryptoServiceProvider();
            try
            {
                inputStream = GetFileStream(pathName);
                byte[] buffer = provider.ComputeHash(inputStream);
                inputStream.Close();
                str3 = BitConverter.ToString(buffer).Replace("-", "");
            }
            catch (System.Exception exception1)
            {
                throw exception1;                
            }
            return str3;
        }

        public ISmartPartInfo GetSmartPartInfo(Type smartPartInfoType)
        {
            return this.infoProvider.GetSmartPartInfo(smartPartInfoType);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance33 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance34 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance37 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance36 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance125 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance134 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance135 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance136 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance60 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance61 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance62 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance57 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance31 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance143 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance144 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance145 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance142 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance58 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance116 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance68 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance131 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance67 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance130 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance128 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance129 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance132 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance133 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance66 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance63 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance64 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance65 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance50 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance155 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance140 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance141 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance146 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance147 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance148 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance149 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance150 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance151 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance137 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance138 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance139 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance85 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance86 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance87 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance88 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance89 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance90 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance91 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance92 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance93 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance40 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance41 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance42 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance38 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance39 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance54 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance55 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance56 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance117 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance118 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance119 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance120 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance121 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance122 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance123 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance32 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance35 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance104 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance105 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance106 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance107 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance108 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance109 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance110 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance111 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance112 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance113 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance114 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance115 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance94 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance59 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance126 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance127 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance70 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance71 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance72 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance73 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance74 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance75 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance76 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance77 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance78 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance79 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance80 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance81 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance82 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance83 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance84 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance69 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance124 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance43 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance44 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance45 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance46 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance47 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance48 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance95 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance96 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance97 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance98 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance99 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance100 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance101 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance102 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance103 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance51 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance49 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance52 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance53 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinDock.DockAreaPane dockAreaPane1 = new Infragistics.Win.UltraWinDock.DockAreaPane(Infragistics.Win.UltraWinDock.DockedLocation.DockedTop, new System.Guid("66586438-bb94-4fce-9f59-dc9003d2692b"));
            Infragistics.Win.UltraWinDock.DockableControlPane dockableControlPane1 = new Infragistics.Win.UltraWinDock.DockableControlPane(new System.Guid("4f0e7f4c-2844-487c-9d86-7b72e0ac126b"), new System.Guid("00000000-0000-0000-0000-000000000000"), -1, new System.Guid("66586438-bb94-4fce-9f59-dc9003d2692b"), -1);
            Infragistics.Win.UltraWinDock.DockAreaPane dockAreaPane2 = new Infragistics.Win.UltraWinDock.DockAreaPane(Infragistics.Win.UltraWinDock.DockedLocation.DockedTop, new System.Guid("6b0b8893-11bd-4a7c-98c2-fcfef42d1774"));
            Infragistics.Win.UltraWinDock.DockableControlPane dockableControlPane2 = new Infragistics.Win.UltraWinDock.DockableControlPane(new System.Guid("46156825-a4aa-4922-8d21-2cca4d618672"), new System.Guid("00000000-0000-0000-0000-000000000000"), -1, new System.Guid("6b0b8893-11bd-4a7c-98c2-fcfef42d1774"), -1);
            Infragistics.Win.UltraWinDock.DockAreaPane dockAreaPane3 = new Infragistics.Win.UltraWinDock.DockAreaPane(Infragistics.Win.UltraWinDock.DockedLocation.DockedTop, new System.Guid("923a1938-2fc8-4c0f-a4f7-e2e55ee1844d"));
            Infragistics.Win.UltraWinDock.DockableControlPane dockableControlPane3 = new Infragistics.Win.UltraWinDock.DockableControlPane(new System.Guid("b8feaf98-5370-4cd3-9c4d-6679c28a3006"), new System.Guid("00000000-0000-0000-0000-000000000000"), -1, new System.Guid("923a1938-2fc8-4c0f-a4f7-e2e55ee1844d"), -1);
            this.UltraGroupBox1 = new Infragistics.Win.Misc.UltraGroupBox();
            this.lblIzvjesceNaDan = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.lblOznakaIzvjesca = new Infragistics.Win.Misc.UltraLabel();
            this.lblVrstaIzvjesca = new Infragistics.Win.Misc.UltraLabel();
            this.lblBrojOsoba = new Infragistics.Win.Misc.UltraLabel();
            this.lblBrojRedakaNaStraniB = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.UltraLabel7 = new Infragistics.Win.Misc.UltraLabel();
            this.UltraLabel6 = new Infragistics.Win.Misc.UltraLabel();
            this.UltraLabel5 = new Infragistics.Win.Misc.UltraLabel();
            this.UltraGroupBox2 = new Infragistics.Win.Misc.UltraGroupBox();
            this.lblOznakaPod = new Infragistics.Win.Misc.UltraLabel();
            this.lblOznakaPodnositelja = new Infragistics.Win.Misc.UltraLabel();
            this.UltraLabel12 = new Infragistics.Win.Misc.UltraLabel();
            this.UltraLabel11 = new Infragistics.Win.Misc.UltraLabel();
            this.UltraLabel10 = new Infragistics.Win.Misc.UltraLabel();
            this.UltraLabel9 = new Infragistics.Win.Misc.UltraLabel();
            this.UltraLabel8 = new Infragistics.Win.Misc.UltraLabel();
            this.txtOIB = new Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit();
            this.txtAdresaElektronickePoste = new Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit();
            this.txtNazivImePrezime = new Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit();
            this.txtAdresa = new Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit();
            this.UltraGroupBox3 = new Infragistics.Win.Misc.UltraGroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ultraLabel98 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel99 = new Infragistics.Win.Misc.UltraLabel();
            this.txtIznosNaknade = new Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit();
            this.ultraLabel100 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel101 = new Infragistics.Win.Misc.UltraLabel();
            this.txtBrojOsoba = new Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit();
            this.ultraLabel96 = new Infragistics.Win.Misc.UltraLabel();
            this.txtUkupnoX = new Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit();
            this.ultraLabel97 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel95 = new Infragistics.Win.Misc.UltraLabel();
            this.txtUkupnoIX = new Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit();
            this.ultraLabel94 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel92 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel93 = new Infragistics.Win.Misc.UltraLabel();
            this.txtUkupno_VI_4_4 = new Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit();
            this.ultraLabel90 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel91 = new Infragistics.Win.Misc.UltraLabel();
            this.txtUkupno_VI_4_3 = new Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit();
            this.ultraLabel88 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel89 = new Infragistics.Win.Misc.UltraLabel();
            this.txtUkupno_VI_3_12 = new Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit();
            this.ultraLabel86 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel87 = new Infragistics.Win.Misc.UltraLabel();
            this.txtUkupno_VI_3_11 = new Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit();
            this.ultraLabel84 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel85 = new Infragistics.Win.Misc.UltraLabel();
            this.txtUkupno_VI_2_6 = new Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit();
            this.ultraLabel82 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel83 = new Infragistics.Win.Misc.UltraLabel();
            this.txtUkupno_VI_1_7 = new Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit();
            this.ultraLabel79 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel81 = new Infragistics.Win.Misc.UltraLabel();
            this.txtUkupno_V_6 = new Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit();
            this.ultraLabel80 = new Infragistics.Win.Misc.UltraLabel();
            this.txtUkupnoVIII = new Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit();
            this.ultraLabel78 = new Infragistics.Win.Misc.UltraLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtUkupno_VII = new Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit();
            this.ultraLabel77 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel73 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel74 = new Infragistics.Win.Misc.UltraLabel();
            this.txtUkupno_VI_4_2 = new Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit();
            this.ultraLabel75 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel76 = new Infragistics.Win.Misc.UltraLabel();
            this.txtUkupno_VI_4_1 = new Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit();
            this.ultraLabel72 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel64 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel65 = new Infragistics.Win.Misc.UltraLabel();
            this.txtUkupno_VI_3_10 = new Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit();
            this.ultraLabel66 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel67 = new Infragistics.Win.Misc.UltraLabel();
            this.txtUkupno_VI_3_9 = new Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit();
            this.ultraLabel68 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel69 = new Infragistics.Win.Misc.UltraLabel();
            this.txtUkupno_VI_3_8 = new Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit();
            this.ultraLabel70 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel71 = new Infragistics.Win.Misc.UltraLabel();
            this.txtUkupno_VI_3_7 = new Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit();
            this.ultraLabel57 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel58 = new Infragistics.Win.Misc.UltraLabel();
            this.txtUkupno_VI_3_6 = new Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit();
            this.ultraLabel59 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel60 = new Infragistics.Win.Misc.UltraLabel();
            this.txtUkupno_VI_3_5 = new Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit();
            this.ultraLabel62 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel63 = new Infragistics.Win.Misc.UltraLabel();
            this.txtUkupno_VI_3_4 = new Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit();
            this.ultraLabel51 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel52 = new Infragistics.Win.Misc.UltraLabel();
            this.txtUkupno_VI_3_3 = new Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit();
            this.ultraLabel53 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel54 = new Infragistics.Win.Misc.UltraLabel();
            this.txtUkupno_VI_3_2 = new Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit();
            this.ultraLabel55 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel56 = new Infragistics.Win.Misc.UltraLabel();
            this.txtUkupno_VI_3_1 = new Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit();
            this.ultraLabel61 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel43 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel44 = new Infragistics.Win.Misc.UltraLabel();
            this.txtUkupno_VI_2_5 = new Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit();
            this.ultraLabel45 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel46 = new Infragistics.Win.Misc.UltraLabel();
            this.txtUkupno_VI_2_4 = new Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit();
            this.ultraLabel47 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel48 = new Infragistics.Win.Misc.UltraLabel();
            this.txtUkupno_VI_2_3 = new Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit();
            this.ultraLabel49 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel50 = new Infragistics.Win.Misc.UltraLabel();
            this.txtUkupno_VI_2_2 = new Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit();
            this.ultraLabel41 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel42 = new Infragistics.Win.Misc.UltraLabel();
            this.txtUkupno_VI_2_1 = new Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit();
            this.ultraLabel40 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel38 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel39 = new Infragistics.Win.Misc.UltraLabel();
            this.txtUkupno_VI_1_6 = new Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit();
            this.ultraLabel36 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel37 = new Infragistics.Win.Misc.UltraLabel();
            this.txtUkupno_VI_1_5 = new Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit();
            this.ultraLabel34 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel35 = new Infragistics.Win.Misc.UltraLabel();
            this.txtUkupno_VI_1_4 = new Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit();
            this.ultraLabel32 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel33 = new Infragistics.Win.Misc.UltraLabel();
            this.txtUkupno_VI_1_3 = new Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit();
            this.ultraLabel30 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel31 = new Infragistics.Win.Misc.UltraLabel();
            this.txtUkupno_VI_1_2 = new Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit();
            this.ultraLabel28 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel29 = new Infragistics.Win.Misc.UltraLabel();
            this.txtUkupno_VI_1_1 = new Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit();
            this.ultraLabel27 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel26 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel24 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel25 = new Infragistics.Win.Misc.UltraLabel();
            this.txtUkupno_V_5 = new Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit();
            this.ultraLabel22 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel23 = new Infragistics.Win.Misc.UltraLabel();
            this.txtUkupno_V_4 = new Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit();
            this.ultraLabel20 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel21 = new Infragistics.Win.Misc.UltraLabel();
            this.txtUkupno_V_3 = new Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit();
            this.ultraLabel18 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel19 = new Infragistics.Win.Misc.UltraLabel();
            this.txtUkupno_V_2 = new Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit();
            this.ultraLabel16 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel17 = new Infragistics.Win.Misc.UltraLabel();
            this.txtUkupno_V_1_2 = new Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit();
            this.ultraLabel14 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel15 = new Infragistics.Win.Misc.UltraLabel();
            this.txtUkupno_V_1_1 = new Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit();
            this.ultraLabel4 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.UltraLabel13 = new Infragistics.Win.Misc.UltraLabel();
            this.txtUkupno_V_1 = new Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit();
            this.UltraDockManager1 = new Infragistics.Win.UltraWinDock.UltraDockManager(this.components);
            this._RSMObrazacUnpinnedTabAreaLeft = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._RSMObrazacUnpinnedTabAreaRight = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._RSMObrazacUnpinnedTabAreaTop = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._RSMObrazacUnpinnedTabAreaBottom = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._RSMObrazacAutoHideControl = new Infragistics.Win.UltraWinDock.AutoHideControl();
            this.dgvJOPPDB = new System.Windows.Forms.DataGridView();
            this.WindowDockingArea3 = new Infragistics.Win.UltraWinDock.WindowDockingArea();
            this.dockableWindow1 = new Infragistics.Win.UltraWinDock.DockableWindow();
            this.WindowDockingArea2 = new Infragistics.Win.UltraWinDock.WindowDockingArea();
            this.dockableWindow2 = new Infragistics.Win.UltraWinDock.DockableWindow();
            this.WindowDockingArea1 = new Infragistics.Win.UltraWinDock.WindowDockingArea();
            this.dockableWindow3 = new Infragistics.Win.UltraWinDock.DockableWindow();
            ((System.ComponentModel.ISupportInitialize)(this.UltraGroupBox1)).BeginInit();
            this.UltraGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UltraGroupBox2)).BeginInit();
            this.UltraGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UltraGroupBox3)).BeginInit();
            this.UltraGroupBox3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UltraDockManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvJOPPDB)).BeginInit();
            this.WindowDockingArea3.SuspendLayout();
            this.dockableWindow1.SuspendLayout();
            this.WindowDockingArea2.SuspendLayout();
            this.dockableWindow2.SuspendLayout();
            this.WindowDockingArea1.SuspendLayout();
            this.dockableWindow3.SuspendLayout();
            this.SuspendLayout();
            // 
            // UltraGroupBox1
            // 
            this.UltraGroupBox1.Controls.Add(this.lblIzvjesceNaDan);
            this.UltraGroupBox1.Controls.Add(this.ultraLabel2);
            this.UltraGroupBox1.Controls.Add(this.lblOznakaIzvjesca);
            this.UltraGroupBox1.Controls.Add(this.lblVrstaIzvjesca);
            this.UltraGroupBox1.Controls.Add(this.lblBrojOsoba);
            this.UltraGroupBox1.Controls.Add(this.lblBrojRedakaNaStraniB);
            this.UltraGroupBox1.Controls.Add(this.ultraLabel1);
            this.UltraGroupBox1.Controls.Add(this.UltraLabel7);
            this.UltraGroupBox1.Controls.Add(this.UltraLabel6);
            this.UltraGroupBox1.Controls.Add(this.UltraLabel5);
            this.UltraGroupBox1.Location = new System.Drawing.Point(0, 18);
            this.UltraGroupBox1.Name = "UltraGroupBox1";
            this.UltraGroupBox1.Size = new System.Drawing.Size(800, 159);
            this.UltraGroupBox1.TabIndex = 7;
            this.UltraGroupBox1.UseAppStyling = false;
            this.UltraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // lblIzvjesceNaDan
            // 
            appearance27.BackColor = System.Drawing.Color.Transparent;
            this.lblIzvjesceNaDan.Appearance = appearance27;
            this.lblIzvjesceNaDan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblIzvjesceNaDan.Location = new System.Drawing.Point(115, 73);
            this.lblIzvjesceNaDan.Name = "lblIzvjesceNaDan";
            this.lblIzvjesceNaDan.Size = new System.Drawing.Size(215, 20);
            this.lblIzvjesceNaDan.TabIndex = 113;
            this.lblIzvjesceNaDan.UseAppStyling = false;
            // 
            // ultraLabel2
            // 
            appearance29.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel2.Appearance = appearance29;
            this.ultraLabel2.Location = new System.Drawing.Point(7, 73);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(91, 23);
            this.ultraLabel2.TabIndex = 112;
            this.ultraLabel2.Text = "Na dan";
            this.ultraLabel2.UseAppStyling = false;
            // 
            // lblOznakaIzvjesca
            // 
            appearance33.BackColor = System.Drawing.Color.Transparent;
            this.lblOznakaIzvjesca.Appearance = appearance33;
            this.lblOznakaIzvjesca.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblOznakaIzvjesca.Location = new System.Drawing.Point(114, 11);
            this.lblOznakaIzvjesca.Name = "lblOznakaIzvjesca";
            this.lblOznakaIzvjesca.Size = new System.Drawing.Size(215, 20);
            this.lblOznakaIzvjesca.TabIndex = 111;
            this.lblOznakaIzvjesca.UseAppStyling = false;
            // 
            // lblVrstaIzvjesca
            // 
            appearance19.BackColor = System.Drawing.Color.Transparent;
            this.lblVrstaIzvjesca.Appearance = appearance19;
            this.lblVrstaIzvjesca.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblVrstaIzvjesca.Location = new System.Drawing.Point(115, 46);
            this.lblVrstaIzvjesca.Name = "lblVrstaIzvjesca";
            this.lblVrstaIzvjesca.Size = new System.Drawing.Size(215, 20);
            this.lblVrstaIzvjesca.TabIndex = 110;
            this.lblVrstaIzvjesca.UseAppStyling = false;
            // 
            // lblBrojOsoba
            // 
            appearance1.BackColor = System.Drawing.Color.Transparent;
            this.lblBrojOsoba.Appearance = appearance1;
            this.lblBrojOsoba.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblBrojOsoba.Location = new System.Drawing.Point(319, 99);
            this.lblBrojOsoba.Name = "lblBrojOsoba";
            this.lblBrojOsoba.Size = new System.Drawing.Size(215, 20);
            this.lblBrojOsoba.TabIndex = 109;
            this.lblBrojOsoba.UseAppStyling = false;
            // 
            // lblBrojRedakaNaStraniB
            // 
            appearance25.BackColor = System.Drawing.Color.Transparent;
            this.lblBrojRedakaNaStraniB.Appearance = appearance25;
            this.lblBrojRedakaNaStraniB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblBrojRedakaNaStraniB.Location = new System.Drawing.Point(319, 132);
            this.lblBrojRedakaNaStraniB.Name = "lblBrojRedakaNaStraniB";
            this.lblBrojRedakaNaStraniB.Size = new System.Drawing.Size(215, 20);
            this.lblBrojRedakaNaStraniB.TabIndex = 108;
            this.lblBrojRedakaNaStraniB.UseAppStyling = false;
            // 
            // ultraLabel1
            // 
            appearance34.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel1.Appearance = appearance34;
            this.ultraLabel1.Location = new System.Drawing.Point(7, 14);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(92, 23);
            this.ultraLabel1.TabIndex = 15;
            this.ultraLabel1.Text = "Oznaka izvješća";
            this.ultraLabel1.UseAppStyling = false;
            // 
            // UltraLabel7
            // 
            appearance26.BackColor = System.Drawing.Color.Transparent;
            this.UltraLabel7.Appearance = appearance26;
            this.UltraLabel7.Location = new System.Drawing.Point(7, 44);
            this.UltraLabel7.Name = "UltraLabel7";
            this.UltraLabel7.Size = new System.Drawing.Size(91, 23);
            this.UltraLabel7.TabIndex = 14;
            this.UltraLabel7.Text = "Vrsta izvješća";
            this.UltraLabel7.UseAppStyling = false;
            // 
            // UltraLabel6
            // 
            appearance37.BackColor = System.Drawing.Color.Transparent;
            this.UltraLabel6.Appearance = appearance37;
            this.UltraLabel6.Location = new System.Drawing.Point(6, 100);
            this.UltraLabel6.Name = "UltraLabel6";
            this.UltraLabel6.Size = new System.Drawing.Size(215, 17);
            this.UltraLabel6.TabIndex = 13;
            this.UltraLabel6.Text = "Broj osoba za koje se podnosi izvješće";
            this.UltraLabel6.UseAppStyling = false;
            // 
            // UltraLabel5
            // 
            appearance12.BackColor = System.Drawing.Color.Transparent;
            this.UltraLabel5.Appearance = appearance12;
            this.UltraLabel5.Location = new System.Drawing.Point(6, 132);
            this.UltraLabel5.Name = "UltraLabel5";
            this.UltraLabel5.Size = new System.Drawing.Size(302, 18);
            this.UltraLabel5.TabIndex = 12;
            this.UltraLabel5.Text = "Broj redaka na popisu pojedinačnih obračuna sa stranice B";
            this.UltraLabel5.UseAppStyling = false;
            // 
            // UltraGroupBox2
            // 
            this.UltraGroupBox2.Controls.Add(this.lblOznakaPod);
            this.UltraGroupBox2.Controls.Add(this.lblOznakaPodnositelja);
            this.UltraGroupBox2.Controls.Add(this.UltraLabel12);
            this.UltraGroupBox2.Controls.Add(this.UltraLabel11);
            this.UltraGroupBox2.Controls.Add(this.UltraLabel10);
            this.UltraGroupBox2.Controls.Add(this.UltraLabel9);
            this.UltraGroupBox2.Controls.Add(this.UltraLabel8);
            this.UltraGroupBox2.Controls.Add(this.txtOIB);
            this.UltraGroupBox2.Controls.Add(this.txtAdresaElektronickePoste);
            this.UltraGroupBox2.Controls.Add(this.txtNazivImePrezime);
            this.UltraGroupBox2.Controls.Add(this.txtAdresa);
            this.UltraGroupBox2.Location = new System.Drawing.Point(0, 18);
            this.UltraGroupBox2.Name = "UltraGroupBox2";
            this.UltraGroupBox2.Size = new System.Drawing.Size(800, 142);
            this.UltraGroupBox2.TabIndex = 9;
            this.UltraGroupBox2.UseAppStyling = false;
            this.UltraGroupBox2.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // lblOznakaPod
            // 
            appearance5.BackColor = System.Drawing.Color.Transparent;
            this.lblOznakaPod.Appearance = appearance5;
            this.lblOznakaPod.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Solid;
            this.lblOznakaPod.Location = new System.Drawing.Point(168, 113);
            this.lblOznakaPod.Name = "lblOznakaPod";
            this.lblOznakaPod.Size = new System.Drawing.Size(115, 20);
            this.lblOznakaPod.TabIndex = 19;
            this.lblOznakaPod.UseAppStyling = false;
            // 
            // lblOznakaPodnositelja
            // 
            appearance13.BackColor = System.Drawing.Color.Transparent;
            this.lblOznakaPodnositelja.Appearance = appearance13;
            this.lblOznakaPodnositelja.AutoSize = true;
            this.lblOznakaPodnositelja.Location = new System.Drawing.Point(291, 113);
            this.lblOznakaPodnositelja.Name = "lblOznakaPodnositelja";
            this.lblOznakaPodnositelja.Size = new System.Drawing.Size(0, 0);
            this.lblOznakaPodnositelja.TabIndex = 18;
            this.lblOznakaPodnositelja.UseAppStyling = false;
            // 
            // UltraLabel12
            // 
            appearance18.BackColor = System.Drawing.Color.Transparent;
            this.UltraLabel12.Appearance = appearance18;
            this.UltraLabel12.Location = new System.Drawing.Point(7, 113);
            this.UltraLabel12.Name = "UltraLabel12";
            this.UltraLabel12.Size = new System.Drawing.Size(126, 23);
            this.UltraLabel12.TabIndex = 17;
            this.UltraLabel12.Text = "5. Oznaka podnositelja";
            this.UltraLabel12.UseAppStyling = false;
            // 
            // UltraLabel11
            // 
            appearance4.BackColor = System.Drawing.Color.Transparent;
            this.UltraLabel11.Appearance = appearance4;
            this.UltraLabel11.Location = new System.Drawing.Point(7, 87);
            this.UltraLabel11.Name = "UltraLabel11";
            this.UltraLabel11.Size = new System.Drawing.Size(126, 23);
            this.UltraLabel11.TabIndex = 16;
            this.UltraLabel11.Text = "4. OIB";
            this.UltraLabel11.UseAppStyling = false;
            // 
            // UltraLabel10
            // 
            appearance3.BackColor = System.Drawing.Color.Transparent;
            this.UltraLabel10.Appearance = appearance3;
            this.UltraLabel10.Location = new System.Drawing.Point(7, 62);
            this.UltraLabel10.Name = "UltraLabel10";
            this.UltraLabel10.Size = new System.Drawing.Size(155, 23);
            this.UltraLabel10.TabIndex = 15;
            this.UltraLabel10.Text = "3. Adresa elektroničke pošte";
            this.UltraLabel10.UseAppStyling = false;
            // 
            // UltraLabel9
            // 
            appearance2.BackColor = System.Drawing.Color.Transparent;
            this.UltraLabel9.Appearance = appearance2;
            this.UltraLabel9.Location = new System.Drawing.Point(7, 35);
            this.UltraLabel9.Name = "UltraLabel9";
            this.UltraLabel9.Size = new System.Drawing.Size(126, 23);
            this.UltraLabel9.TabIndex = 14;
            this.UltraLabel9.Text = "2. Adresa";
            this.UltraLabel9.UseAppStyling = false;
            // 
            // UltraLabel8
            // 
            appearance36.BackColor = System.Drawing.Color.Transparent;
            this.UltraLabel8.Appearance = appearance36;
            this.UltraLabel8.Location = new System.Drawing.Point(7, 9);
            this.UltraLabel8.Name = "UltraLabel8";
            this.UltraLabel8.Size = new System.Drawing.Size(155, 23);
            this.UltraLabel8.TabIndex = 13;
            this.UltraLabel8.Text = "1. Naziv / ime i prezime";
            this.UltraLabel8.UseAppStyling = false;
            // 
            // txtOIB
            // 
            this.txtOIB.AutoSize = false;
            this.txtOIB.Location = new System.Drawing.Point(168, 84);
            this.txtOIB.Name = "txtOIB";
            this.txtOIB.PromptChar = ' ';
            this.txtOIB.Size = new System.Drawing.Size(115, 20);
            this.txtOIB.TabIndex = 4;
            this.txtOIB.UseAppStyling = false;
            // 
            // txtAdresaElektronickePoste
            // 
            this.txtAdresaElektronickePoste.AutoSize = false;
            this.txtAdresaElektronickePoste.Location = new System.Drawing.Point(168, 58);
            this.txtAdresaElektronickePoste.Name = "txtAdresaElektronickePoste";
            this.txtAdresaElektronickePoste.PromptChar = ' ';
            this.txtAdresaElektronickePoste.Size = new System.Drawing.Size(388, 20);
            this.txtAdresaElektronickePoste.TabIndex = 3;
            this.txtAdresaElektronickePoste.UseAppStyling = false;
            // 
            // txtNazivImePrezime
            // 
            this.txtNazivImePrezime.AutoSize = false;
            this.txtNazivImePrezime.Location = new System.Drawing.Point(168, 6);
            this.txtNazivImePrezime.Name = "txtNazivImePrezime";
            this.txtNazivImePrezime.PromptChar = ' ';
            this.txtNazivImePrezime.Size = new System.Drawing.Size(590, 20);
            this.txtNazivImePrezime.TabIndex = 2;
            this.txtNazivImePrezime.UseAppStyling = false;
            // 
            // txtAdresa
            // 
            this.txtAdresa.AutoSize = false;
            this.txtAdresa.Location = new System.Drawing.Point(168, 32);
            this.txtAdresa.Name = "txtAdresa";
            this.txtAdresa.PromptChar = ' ';
            this.txtAdresa.Size = new System.Drawing.Size(590, 20);
            this.txtAdresa.TabIndex = 1;
            this.txtAdresa.UseAppStyling = false;
            // 
            // UltraGroupBox3
            // 
            appearance125.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.UltraGroupBox3.Appearance = appearance125;
            this.UltraGroupBox3.Controls.Add(this.panel1);
            this.UltraGroupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UltraGroupBox3.Location = new System.Drawing.Point(0, 18);
            this.UltraGroupBox3.Name = "UltraGroupBox3";
            this.UltraGroupBox3.Size = new System.Drawing.Size(800, 264);
            this.UltraGroupBox3.TabIndex = 10;
            this.UltraGroupBox3.UseAppStyling = false;
            this.UltraGroupBox3.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.panel1.Controls.Add(this.ultraLabel98);
            this.panel1.Controls.Add(this.ultraLabel99);
            this.panel1.Controls.Add(this.txtIznosNaknade);
            this.panel1.Controls.Add(this.ultraLabel100);
            this.panel1.Controls.Add(this.ultraLabel101);
            this.panel1.Controls.Add(this.txtBrojOsoba);
            this.panel1.Controls.Add(this.ultraLabel96);
            this.panel1.Controls.Add(this.txtUkupnoX);
            this.panel1.Controls.Add(this.ultraLabel97);
            this.panel1.Controls.Add(this.ultraLabel95);
            this.panel1.Controls.Add(this.txtUkupnoIX);
            this.panel1.Controls.Add(this.ultraLabel94);
            this.panel1.Controls.Add(this.ultraLabel92);
            this.panel1.Controls.Add(this.ultraLabel93);
            this.panel1.Controls.Add(this.txtUkupno_VI_4_4);
            this.panel1.Controls.Add(this.ultraLabel90);
            this.panel1.Controls.Add(this.ultraLabel91);
            this.panel1.Controls.Add(this.txtUkupno_VI_4_3);
            this.panel1.Controls.Add(this.ultraLabel88);
            this.panel1.Controls.Add(this.ultraLabel89);
            this.panel1.Controls.Add(this.txtUkupno_VI_3_12);
            this.panel1.Controls.Add(this.ultraLabel86);
            this.panel1.Controls.Add(this.ultraLabel87);
            this.panel1.Controls.Add(this.txtUkupno_VI_3_11);
            this.panel1.Controls.Add(this.ultraLabel84);
            this.panel1.Controls.Add(this.ultraLabel85);
            this.panel1.Controls.Add(this.txtUkupno_VI_2_6);
            this.panel1.Controls.Add(this.ultraLabel82);
            this.panel1.Controls.Add(this.ultraLabel83);
            this.panel1.Controls.Add(this.txtUkupno_VI_1_7);
            this.panel1.Controls.Add(this.ultraLabel79);
            this.panel1.Controls.Add(this.ultraLabel81);
            this.panel1.Controls.Add(this.txtUkupno_V_6);
            this.panel1.Controls.Add(this.ultraLabel80);
            this.panel1.Controls.Add(this.txtUkupnoVIII);
            this.panel1.Controls.Add(this.ultraLabel78);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtUkupno_VII);
            this.panel1.Controls.Add(this.ultraLabel77);
            this.panel1.Controls.Add(this.ultraLabel73);
            this.panel1.Controls.Add(this.ultraLabel74);
            this.panel1.Controls.Add(this.txtUkupno_VI_4_2);
            this.panel1.Controls.Add(this.ultraLabel75);
            this.panel1.Controls.Add(this.ultraLabel76);
            this.panel1.Controls.Add(this.txtUkupno_VI_4_1);
            this.panel1.Controls.Add(this.ultraLabel72);
            this.panel1.Controls.Add(this.ultraLabel64);
            this.panel1.Controls.Add(this.ultraLabel65);
            this.panel1.Controls.Add(this.txtUkupno_VI_3_10);
            this.panel1.Controls.Add(this.ultraLabel66);
            this.panel1.Controls.Add(this.ultraLabel67);
            this.panel1.Controls.Add(this.txtUkupno_VI_3_9);
            this.panel1.Controls.Add(this.ultraLabel68);
            this.panel1.Controls.Add(this.ultraLabel69);
            this.panel1.Controls.Add(this.txtUkupno_VI_3_8);
            this.panel1.Controls.Add(this.ultraLabel70);
            this.panel1.Controls.Add(this.ultraLabel71);
            this.panel1.Controls.Add(this.txtUkupno_VI_3_7);
            this.panel1.Controls.Add(this.ultraLabel57);
            this.panel1.Controls.Add(this.ultraLabel58);
            this.panel1.Controls.Add(this.txtUkupno_VI_3_6);
            this.panel1.Controls.Add(this.ultraLabel59);
            this.panel1.Controls.Add(this.ultraLabel60);
            this.panel1.Controls.Add(this.txtUkupno_VI_3_5);
            this.panel1.Controls.Add(this.ultraLabel62);
            this.panel1.Controls.Add(this.ultraLabel63);
            this.panel1.Controls.Add(this.txtUkupno_VI_3_4);
            this.panel1.Controls.Add(this.ultraLabel51);
            this.panel1.Controls.Add(this.ultraLabel52);
            this.panel1.Controls.Add(this.txtUkupno_VI_3_3);
            this.panel1.Controls.Add(this.ultraLabel53);
            this.panel1.Controls.Add(this.ultraLabel54);
            this.panel1.Controls.Add(this.txtUkupno_VI_3_2);
            this.panel1.Controls.Add(this.ultraLabel55);
            this.panel1.Controls.Add(this.ultraLabel56);
            this.panel1.Controls.Add(this.txtUkupno_VI_3_1);
            this.panel1.Controls.Add(this.ultraLabel61);
            this.panel1.Controls.Add(this.ultraLabel43);
            this.panel1.Controls.Add(this.ultraLabel44);
            this.panel1.Controls.Add(this.txtUkupno_VI_2_5);
            this.panel1.Controls.Add(this.ultraLabel45);
            this.panel1.Controls.Add(this.ultraLabel46);
            this.panel1.Controls.Add(this.txtUkupno_VI_2_4);
            this.panel1.Controls.Add(this.ultraLabel47);
            this.panel1.Controls.Add(this.ultraLabel48);
            this.panel1.Controls.Add(this.txtUkupno_VI_2_3);
            this.panel1.Controls.Add(this.ultraLabel49);
            this.panel1.Controls.Add(this.ultraLabel50);
            this.panel1.Controls.Add(this.txtUkupno_VI_2_2);
            this.panel1.Controls.Add(this.ultraLabel41);
            this.panel1.Controls.Add(this.ultraLabel42);
            this.panel1.Controls.Add(this.txtUkupno_VI_2_1);
            this.panel1.Controls.Add(this.ultraLabel40);
            this.panel1.Controls.Add(this.ultraLabel38);
            this.panel1.Controls.Add(this.ultraLabel39);
            this.panel1.Controls.Add(this.txtUkupno_VI_1_6);
            this.panel1.Controls.Add(this.ultraLabel36);
            this.panel1.Controls.Add(this.ultraLabel37);
            this.panel1.Controls.Add(this.txtUkupno_VI_1_5);
            this.panel1.Controls.Add(this.ultraLabel34);
            this.panel1.Controls.Add(this.ultraLabel35);
            this.panel1.Controls.Add(this.txtUkupno_VI_1_4);
            this.panel1.Controls.Add(this.ultraLabel32);
            this.panel1.Controls.Add(this.ultraLabel33);
            this.panel1.Controls.Add(this.txtUkupno_VI_1_3);
            this.panel1.Controls.Add(this.ultraLabel30);
            this.panel1.Controls.Add(this.ultraLabel31);
            this.panel1.Controls.Add(this.txtUkupno_VI_1_2);
            this.panel1.Controls.Add(this.ultraLabel28);
            this.panel1.Controls.Add(this.ultraLabel29);
            this.panel1.Controls.Add(this.txtUkupno_VI_1_1);
            this.panel1.Controls.Add(this.ultraLabel27);
            this.panel1.Controls.Add(this.ultraLabel26);
            this.panel1.Controls.Add(this.ultraLabel24);
            this.panel1.Controls.Add(this.ultraLabel25);
            this.panel1.Controls.Add(this.txtUkupno_V_5);
            this.panel1.Controls.Add(this.ultraLabel22);
            this.panel1.Controls.Add(this.ultraLabel23);
            this.panel1.Controls.Add(this.txtUkupno_V_4);
            this.panel1.Controls.Add(this.ultraLabel20);
            this.panel1.Controls.Add(this.ultraLabel21);
            this.panel1.Controls.Add(this.txtUkupno_V_3);
            this.panel1.Controls.Add(this.ultraLabel18);
            this.panel1.Controls.Add(this.ultraLabel19);
            this.panel1.Controls.Add(this.txtUkupno_V_2);
            this.panel1.Controls.Add(this.ultraLabel16);
            this.panel1.Controls.Add(this.ultraLabel17);
            this.panel1.Controls.Add(this.txtUkupno_V_1_2);
            this.panel1.Controls.Add(this.ultraLabel14);
            this.panel1.Controls.Add(this.ultraLabel15);
            this.panel1.Controls.Add(this.txtUkupno_V_1_1);
            this.panel1.Controls.Add(this.ultraLabel4);
            this.panel1.Controls.Add(this.ultraLabel3);
            this.panel1.Controls.Add(this.UltraLabel13);
            this.panel1.Controls.Add(this.txtUkupno_V_1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(794, 261);
            this.panel1.TabIndex = 116;
            this.panel1.MouseEnter += new System.EventHandler(this.panel1_MouseEnter);
            // 
            // ultraLabel98
            // 
            appearance134.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel98.Appearance = appearance134;
            this.ultraLabel98.AutoSize = true;
            this.ultraLabel98.Location = new System.Drawing.Point(28, 1464);
            this.ultraLabel98.Name = "ultraLabel98";
            this.ultraLabel98.Size = new System.Drawing.Size(14, 14);
            this.ultraLabel98.TabIndex = 250;
            this.ultraLabel98.Text = "2.";
            this.ultraLabel98.UseAppStyling = false;
            // 
            // ultraLabel99
            // 
            appearance135.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel99.Appearance = appearance135;
            this.ultraLabel99.Location = new System.Drawing.Point(44, 1464);
            this.ultraLabel99.Name = "ultraLabel99";
            this.ultraLabel99.Size = new System.Drawing.Size(526, 18);
            this.ultraLabel99.TabIndex = 249;
            this.ultraLabel99.Text = "Iznos obračunane naknade";
            this.ultraLabel99.UseAppStyling = false;
            // 
            // txtIznosNaknade
            // 
            appearance136.TextHAlignAsString = "Right";
            this.txtIznosNaknade.Appearance = appearance136;
            this.txtIznosNaknade.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtIznosNaknade.InputMask = "{LOC} n,nnn,nnn.nn";
            this.txtIznosNaknade.Location = new System.Drawing.Point(599, 1461);
            this.txtIznosNaknade.Name = "txtIznosNaknade";
            this.txtIznosNaknade.PromptChar = ' ';
            this.txtIznosNaknade.Size = new System.Drawing.Size(100, 20);
            this.txtIznosNaknade.TabIndex = 248;
            this.txtIznosNaknade.Text = " ";
            this.txtIznosNaknade.UseAppStyling = false;
            // 
            // ultraLabel100
            // 
            appearance60.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel100.Appearance = appearance60;
            this.ultraLabel100.AutoSize = true;
            this.ultraLabel100.Location = new System.Drawing.Point(28, 1440);
            this.ultraLabel100.Name = "ultraLabel100";
            this.ultraLabel100.Size = new System.Drawing.Size(14, 14);
            this.ultraLabel100.TabIndex = 247;
            this.ultraLabel100.Text = "1.";
            this.ultraLabel100.UseAppStyling = false;
            // 
            // ultraLabel101
            // 
            appearance61.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel101.Appearance = appearance61;
            this.ultraLabel101.Location = new System.Drawing.Point(44, 1440);
            this.ultraLabel101.Name = "ultraLabel101";
            this.ultraLabel101.Size = new System.Drawing.Size(526, 18);
            this.ultraLabel101.TabIndex = 246;
            this.ultraLabel101.Text = "Broj osoba s invaliditetom koje je obveznik bio dužan zaposliti";
            this.ultraLabel101.UseAppStyling = false;
            // 
            // txtBrojOsoba
            // 
            appearance62.TextHAlignAsString = "Right";
            this.txtBrojOsoba.Appearance = appearance62;
            this.txtBrojOsoba.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtBrojOsoba.InputMask = "nnnnnnnnn";
            this.txtBrojOsoba.Location = new System.Drawing.Point(599, 1437);
            this.txtBrojOsoba.MaxValue = 0;
            this.txtBrojOsoba.MinValue = 0;
            this.txtBrojOsoba.Name = "txtBrojOsoba";
            this.txtBrojOsoba.PromptChar = ' ';
            this.txtBrojOsoba.Size = new System.Drawing.Size(100, 20);
            this.txtBrojOsoba.TabIndex = 245;
            this.txtBrojOsoba.Text = " ";
            this.txtBrojOsoba.UseAppStyling = false;
            // 
            // ultraLabel96
            // 
            appearance57.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel96.Appearance = appearance57;
            this.ultraLabel96.AutoSize = true;
            this.ultraLabel96.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ultraLabel96.Location = new System.Drawing.Point(25, 1406);
            this.ultraLabel96.Name = "ultraLabel96";
            this.ultraLabel96.Size = new System.Drawing.Size(15, 14);
            this.ultraLabel96.TabIndex = 244;
            this.ultraLabel96.Text = "X.";
            this.ultraLabel96.UseAppStyling = false;
            // 
            // txtUkupnoX
            // 
            appearance30.TextHAlignAsString = "Right";
            this.txtUkupnoX.Appearance = appearance30;
            this.txtUkupnoX.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtUkupnoX.InputMask = "{LOC} n,nnn,nnn.nn";
            this.txtUkupnoX.Location = new System.Drawing.Point(599, 1400);
            this.txtUkupnoX.Name = "txtUkupnoX";
            this.txtUkupnoX.PromptChar = ' ';
            this.txtUkupnoX.Size = new System.Drawing.Size(100, 20);
            this.txtUkupnoX.TabIndex = 243;
            this.txtUkupnoX.Text = " ";
            this.txtUkupnoX.UseAppStyling = false;
            // 
            // ultraLabel97
            // 
            appearance31.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel97.Appearance = appearance31;
            this.ultraLabel97.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ultraLabel97.Location = new System.Drawing.Point(44, 1406);
            this.ultraLabel97.Name = "ultraLabel97";
            this.ultraLabel97.Size = new System.Drawing.Size(473, 28);
            this.ultraLabel97.TabIndex = 242;
            this.ultraLabel97.Text = "Podaci o broju osoba i naknadi utvrđenoj sukladno odredbama zakona o profesionaln" +
    "oj rehabilitaciji i zapošljavanju osoba s invaliditetom";
            this.ultraLabel97.UseAppStyling = false;
            // 
            // ultraLabel95
            // 
            appearance143.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel95.Appearance = appearance143;
            this.ultraLabel95.AutoSize = true;
            this.ultraLabel95.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ultraLabel95.Location = new System.Drawing.Point(21, 1374);
            this.ultraLabel95.Name = "ultraLabel95";
            this.ultraLabel95.Size = new System.Drawing.Size(19, 14);
            this.ultraLabel95.TabIndex = 241;
            this.ultraLabel95.Text = "IX.";
            this.ultraLabel95.UseAppStyling = false;
            // 
            // txtUkupnoIX
            // 
            appearance144.TextHAlignAsString = "Right";
            this.txtUkupnoIX.Appearance = appearance144;
            this.txtUkupnoIX.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtUkupnoIX.InputMask = "{LOC} n,nnn,nnn.nn";
            this.txtUkupnoIX.Location = new System.Drawing.Point(599, 1368);
            this.txtUkupnoIX.Name = "txtUkupnoIX";
            this.txtUkupnoIX.PromptChar = ' ';
            this.txtUkupnoIX.Size = new System.Drawing.Size(100, 20);
            this.txtUkupnoIX.TabIndex = 240;
            this.txtUkupnoIX.Text = " ";
            this.txtUkupnoIX.UseAppStyling = false;
            // 
            // ultraLabel94
            // 
            appearance145.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel94.Appearance = appearance145;
            this.ultraLabel94.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ultraLabel94.Location = new System.Drawing.Point(44, 1374);
            this.ultraLabel94.Name = "ultraLabel94";
            this.ultraLabel94.Size = new System.Drawing.Size(473, 28);
            this.ultraLabel94.TabIndex = 239;
            this.ultraLabel94.Text = "Ukupan iznos neoporezivih primitaka nerezidenata koje isplaćuju neprofitne organi" +
    "zacije do propisanog iznosa";
            this.ultraLabel94.UseAppStyling = false;
            // 
            // ultraLabel92
            // 
            appearance142.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel92.Appearance = appearance142;
            this.ultraLabel92.AutoSize = true;
            this.ultraLabel92.Location = new System.Drawing.Point(35, 1273);
            this.ultraLabel92.Name = "ultraLabel92";
            this.ultraLabel92.Size = new System.Drawing.Size(14, 14);
            this.ultraLabel92.TabIndex = 238;
            this.ultraLabel92.Text = "4.";
            this.ultraLabel92.UseAppStyling = false;
            // 
            // ultraLabel93
            // 
            appearance58.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel93.Appearance = appearance58;
            this.ultraLabel93.Location = new System.Drawing.Point(67, 1273);
            this.ultraLabel93.Name = "ultraLabel93";
            this.ultraLabel93.Size = new System.Drawing.Size(526, 30);
            this.ultraLabel93.TabIndex = 237;
            this.ultraLabel93.Text = "Ukupan iznos doprinosa za zapošljavanje po osnovi obavljanja samostalne djelatnos" +
    "ti  za osobe koje su same za sebe obvezne obračunati doprinose";
            this.ultraLabel93.UseAppStyling = false;
            // 
            // txtUkupno_VI_4_4
            // 
            appearance116.TextHAlignAsString = "Right";
            this.txtUkupno_VI_4_4.Appearance = appearance116;
            this.txtUkupno_VI_4_4.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtUkupno_VI_4_4.InputMask = "{LOC} n,nnn,nnn.nn";
            this.txtUkupno_VI_4_4.Location = new System.Drawing.Point(599, 1270);
            this.txtUkupno_VI_4_4.Name = "txtUkupno_VI_4_4";
            this.txtUkupno_VI_4_4.PromptChar = ' ';
            this.txtUkupno_VI_4_4.Size = new System.Drawing.Size(100, 20);
            this.txtUkupno_VI_4_4.TabIndex = 236;
            this.txtUkupno_VI_4_4.Text = " ";
            this.txtUkupno_VI_4_4.UseAppStyling = false;
            // 
            // ultraLabel90
            // 
            appearance68.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel90.Appearance = appearance68;
            this.ultraLabel90.AutoSize = true;
            this.ultraLabel90.Location = new System.Drawing.Point(35, 1249);
            this.ultraLabel90.Name = "ultraLabel90";
            this.ultraLabel90.Size = new System.Drawing.Size(14, 14);
            this.ultraLabel90.TabIndex = 235;
            this.ultraLabel90.Text = "3.";
            this.ultraLabel90.UseAppStyling = false;
            // 
            // ultraLabel91
            // 
            appearance131.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel91.Appearance = appearance131;
            this.ultraLabel91.Location = new System.Drawing.Point(67, 1249);
            this.ultraLabel91.Name = "ultraLabel91";
            this.ultraLabel91.Size = new System.Drawing.Size(526, 18);
            this.ultraLabel91.TabIndex = 234;
            this.ultraLabel91.Text = "Ukupan iznos doprinosa za zapošljavanje po osnovi podzetničke plaće";
            this.ultraLabel91.UseAppStyling = false;
            // 
            // txtUkupno_VI_4_3
            // 
            appearance67.TextHAlignAsString = "Right";
            this.txtUkupno_VI_4_3.Appearance = appearance67;
            this.txtUkupno_VI_4_3.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtUkupno_VI_4_3.InputMask = "{LOC} n,nnn,nnn.nn";
            this.txtUkupno_VI_4_3.Location = new System.Drawing.Point(599, 1246);
            this.txtUkupno_VI_4_3.Name = "txtUkupno_VI_4_3";
            this.txtUkupno_VI_4_3.PromptChar = ' ';
            this.txtUkupno_VI_4_3.Size = new System.Drawing.Size(100, 20);
            this.txtUkupno_VI_4_3.TabIndex = 233;
            this.txtUkupno_VI_4_3.Text = " ";
            this.txtUkupno_VI_4_3.UseAppStyling = false;
            // 
            // ultraLabel88
            // 
            appearance130.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel88.Appearance = appearance130;
            this.ultraLabel88.AutoSize = true;
            this.ultraLabel88.Location = new System.Drawing.Point(35, 1143);
            this.ultraLabel88.Name = "ultraLabel88";
            this.ultraLabel88.Size = new System.Drawing.Size(20, 14);
            this.ultraLabel88.TabIndex = 232;
            this.ultraLabel88.Text = "12.";
            this.ultraLabel88.UseAppStyling = false;
            // 
            // ultraLabel89
            // 
            appearance128.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel89.Appearance = appearance128;
            this.ultraLabel89.Location = new System.Drawing.Point(67, 1143);
            this.ultraLabel89.Name = "ultraLabel89";
            this.ultraLabel89.Size = new System.Drawing.Size(526, 30);
            this.ultraLabel89.TabIndex = 231;
            this.ultraLabel89.Text = "Ukupan iznos doprinosa za zaštitu zdravlja na radu po osnovi obavljanja samostaln" +
    "e djelatnosti za osobe koje su samoe za sebe obvezne obračunati doprinose";
            this.ultraLabel89.UseAppStyling = false;
            // 
            // txtUkupno_VI_3_12
            // 
            appearance129.TextHAlignAsString = "Right";
            this.txtUkupno_VI_3_12.Appearance = appearance129;
            this.txtUkupno_VI_3_12.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtUkupno_VI_3_12.InputMask = "{LOC} n,nnn,nnn.nn";
            this.txtUkupno_VI_3_12.Location = new System.Drawing.Point(599, 1140);
            this.txtUkupno_VI_3_12.Name = "txtUkupno_VI_3_12";
            this.txtUkupno_VI_3_12.PromptChar = ' ';
            this.txtUkupno_VI_3_12.Size = new System.Drawing.Size(100, 20);
            this.txtUkupno_VI_3_12.TabIndex = 230;
            this.txtUkupno_VI_3_12.Text = " ";
            this.txtUkupno_VI_3_12.UseAppStyling = false;
            // 
            // ultraLabel86
            // 
            appearance132.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel86.Appearance = appearance132;
            this.ultraLabel86.AutoSize = true;
            this.ultraLabel86.Location = new System.Drawing.Point(35, 1112);
            this.ultraLabel86.Name = "ultraLabel86";
            this.ultraLabel86.Size = new System.Drawing.Size(20, 14);
            this.ultraLabel86.TabIndex = 229;
            this.ultraLabel86.Text = "11.";
            this.ultraLabel86.UseAppStyling = false;
            // 
            // ultraLabel87
            // 
            appearance133.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel87.Appearance = appearance133;
            this.ultraLabel87.Location = new System.Drawing.Point(67, 1112);
            this.ultraLabel87.Name = "ultraLabel87";
            this.ultraLabel87.Size = new System.Drawing.Size(526, 30);
            this.ultraLabel87.TabIndex = 228;
            this.ultraLabel87.Text = "Ukupan iznos doprinosa za zdravstveno osiguranje po osnovi obavljanja samostalne " +
    "djelatnosti za osobe koje su samoe za sebe obvezne obračunati doprinose";
            this.ultraLabel87.UseAppStyling = false;
            // 
            // txtUkupno_VI_3_11
            // 
            appearance66.TextHAlignAsString = "Right";
            this.txtUkupno_VI_3_11.Appearance = appearance66;
            this.txtUkupno_VI_3_11.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtUkupno_VI_3_11.InputMask = "{LOC} n,nnn,nnn.nn";
            this.txtUkupno_VI_3_11.Location = new System.Drawing.Point(599, 1109);
            this.txtUkupno_VI_3_11.Name = "txtUkupno_VI_3_11";
            this.txtUkupno_VI_3_11.PromptChar = ' ';
            this.txtUkupno_VI_3_11.Size = new System.Drawing.Size(100, 20);
            this.txtUkupno_VI_3_11.TabIndex = 227;
            this.txtUkupno_VI_3_11.Text = " ";
            this.txtUkupno_VI_3_11.UseAppStyling = false;
            // 
            // ultraLabel84
            // 
            appearance63.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel84.Appearance = appearance63;
            this.ultraLabel84.AutoSize = true;
            this.ultraLabel84.Location = new System.Drawing.Point(35, 780);
            this.ultraLabel84.Name = "ultraLabel84";
            this.ultraLabel84.Size = new System.Drawing.Size(14, 14);
            this.ultraLabel84.TabIndex = 226;
            this.ultraLabel84.Text = "6.";
            this.ultraLabel84.UseAppStyling = false;
            // 
            // ultraLabel85
            // 
            appearance64.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel85.Appearance = appearance64;
            this.ultraLabel85.Location = new System.Drawing.Point(67, 780);
            this.ultraLabel85.Name = "ultraLabel85";
            this.ultraLabel85.Size = new System.Drawing.Size(526, 30);
            this.ultraLabel85.TabIndex = 225;
            this.ultraLabel85.Text = "Ukupan iznos doprinosa za mirovinsko osiguranje na temelju individualne kapitaliz" +
    "irane štednje po osnovi obavljanja samostalne djelatnosti za osobe koje su same " +
    "za sebe obvezne obračunati doprinose";
            this.ultraLabel85.UseAppStyling = false;
            // 
            // txtUkupno_VI_2_6
            // 
            appearance65.TextHAlignAsString = "Right";
            this.txtUkupno_VI_2_6.Appearance = appearance65;
            this.txtUkupno_VI_2_6.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtUkupno_VI_2_6.InputMask = "{LOC} n,nnn,nnn.nn";
            this.txtUkupno_VI_2_6.Location = new System.Drawing.Point(599, 777);
            this.txtUkupno_VI_2_6.Name = "txtUkupno_VI_2_6";
            this.txtUkupno_VI_2_6.PromptChar = ' ';
            this.txtUkupno_VI_2_6.Size = new System.Drawing.Size(100, 20);
            this.txtUkupno_VI_2_6.TabIndex = 224;
            this.txtUkupno_VI_2_6.Text = " ";
            this.txtUkupno_VI_2_6.UseAppStyling = false;
            // 
            // ultraLabel82
            // 
            appearance8.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel82.Appearance = appearance8;
            this.ultraLabel82.AutoSize = true;
            this.ultraLabel82.Location = new System.Drawing.Point(35, 545);
            this.ultraLabel82.Name = "ultraLabel82";
            this.ultraLabel82.Size = new System.Drawing.Size(14, 14);
            this.ultraLabel82.TabIndex = 223;
            this.ultraLabel82.Text = "7.";
            this.ultraLabel82.UseAppStyling = false;
            // 
            // ultraLabel83
            // 
            appearance9.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel83.Appearance = appearance9;
            this.ultraLabel83.Location = new System.Drawing.Point(67, 545);
            this.ultraLabel83.Name = "ultraLabel83";
            this.ultraLabel83.Size = new System.Drawing.Size(526, 30);
            this.ultraLabel83.TabIndex = 222;
            this.ultraLabel83.Text = "Ukupan iznos doprinosa za mirovinsko osiguranje na temelju generacijske solidarno" +
    "sti po osnovi obavljanja samostalne djelatnosti za osobe koje su same obvezne ob" +
    "racunati doprinos";
            this.ultraLabel83.UseAppStyling = false;
            // 
            // txtUkupno_VI_1_7
            // 
            appearance10.TextHAlignAsString = "Right";
            this.txtUkupno_VI_1_7.Appearance = appearance10;
            this.txtUkupno_VI_1_7.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtUkupno_VI_1_7.InputMask = "{LOC} n,nnn,nnn.nn";
            this.txtUkupno_VI_1_7.Location = new System.Drawing.Point(599, 542);
            this.txtUkupno_VI_1_7.Name = "txtUkupno_VI_1_7";
            this.txtUkupno_VI_1_7.PromptChar = ' ';
            this.txtUkupno_VI_1_7.Size = new System.Drawing.Size(100, 20);
            this.txtUkupno_VI_1_7.TabIndex = 221;
            this.txtUkupno_VI_1_7.Text = " ";
            this.txtUkupno_VI_1_7.UseAppStyling = false;
            // 
            // ultraLabel79
            // 
            appearance11.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel79.Appearance = appearance11;
            this.ultraLabel79.AutoSize = true;
            this.ultraLabel79.Location = new System.Drawing.Point(35, 253);
            this.ultraLabel79.Name = "ultraLabel79";
            this.ultraLabel79.Size = new System.Drawing.Size(14, 14);
            this.ultraLabel79.TabIndex = 220;
            this.ultraLabel79.Text = "6.";
            this.ultraLabel79.UseAppStyling = false;
            // 
            // ultraLabel81
            // 
            appearance7.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel81.Appearance = appearance7;
            this.ultraLabel81.Location = new System.Drawing.Point(67, 253);
            this.ultraLabel81.Name = "ultraLabel81";
            this.ultraLabel81.Size = new System.Drawing.Size(526, 17);
            this.ultraLabel81.TabIndex = 219;
            this.ultraLabel81.Text = "Ukupan iznos predujma poreza na dohodak i prireza porezu na dohodak po osnovi doh" +
    "otka od kamata";
            this.ultraLabel81.UseAppStyling = false;
            // 
            // txtUkupno_V_6
            // 
            appearance28.TextHAlignAsString = "Right";
            this.txtUkupno_V_6.Appearance = appearance28;
            this.txtUkupno_V_6.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtUkupno_V_6.InputMask = "{LOC} n,nnn,nnn.nn";
            this.txtUkupno_V_6.Location = new System.Drawing.Point(599, 250);
            this.txtUkupno_V_6.Name = "txtUkupno_V_6";
            this.txtUkupno_V_6.PromptChar = ' ';
            this.txtUkupno_V_6.Size = new System.Drawing.Size(100, 20);
            this.txtUkupno_V_6.TabIndex = 218;
            this.txtUkupno_V_6.Text = " ";
            this.txtUkupno_V_6.UseAppStyling = false;
            // 
            // ultraLabel80
            // 
            appearance50.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel80.Appearance = appearance50;
            this.ultraLabel80.AutoSize = true;
            this.ultraLabel80.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ultraLabel80.Location = new System.Drawing.Point(44, 1353);
            this.ultraLabel80.Name = "ultraLabel80";
            this.ultraLabel80.Size = new System.Drawing.Size(316, 14);
            this.ultraLabel80.TabIndex = 217;
            this.ultraLabel80.Text = "NA TEMELJU INDIVIDUALNE KAPITALIZIRANE ŠTEDNJE";
            this.ultraLabel80.UseAppStyling = false;
            // 
            // txtUkupnoVIII
            // 
            appearance20.TextHAlignAsString = "Right";
            this.txtUkupnoVIII.Appearance = appearance20;
            this.txtUkupnoVIII.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtUkupnoVIII.InputMask = "{LOC} n,nnn,nnn.nn";
            this.txtUkupnoVIII.Location = new System.Drawing.Point(599, 1338);
            this.txtUkupnoVIII.Name = "txtUkupnoVIII";
            this.txtUkupnoVIII.PromptChar = ' ';
            this.txtUkupnoVIII.Size = new System.Drawing.Size(100, 20);
            this.txtUkupnoVIII.TabIndex = 216;
            this.txtUkupnoVIII.Text = " ";
            this.txtUkupnoVIII.UseAppStyling = false;
            this.txtUkupnoVIII.MaskChanged += new Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit.MaskChangedEventHandler(this.ultraMaskedEdit1_MaskChanged);
            // 
            // ultraLabel78
            // 
            appearance155.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel78.Appearance = appearance155;
            this.ultraLabel78.AutoSize = true;
            this.ultraLabel78.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ultraLabel78.Location = new System.Drawing.Point(14, 1338);
            this.ultraLabel78.Name = "ultraLabel78";
            this.ultraLabel78.Size = new System.Drawing.Size(427, 14);
            this.ultraLabel78.TabIndex = 215;
            this.ultraLabel78.Text = "VIII.    NAPLAĆENA KAMATA ZA DOPRINOSE ZA MIROVNISKO OSIGURANJE ";
            this.ultraLabel78.UseAppStyling = false;
            this.ultraLabel78.Click += new System.EventHandler(this.ultraLabel78_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 1198);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 214;
            // 
            // txtUkupno_VII
            // 
            appearance140.TextHAlignAsString = "Right";
            this.txtUkupno_VII.Appearance = appearance140;
            this.txtUkupno_VII.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtUkupno_VII.InputMask = "{LOC} n,nnn,nnn.nn";
            this.txtUkupno_VII.Location = new System.Drawing.Point(599, 1308);
            this.txtUkupno_VII.Name = "txtUkupno_VII";
            this.txtUkupno_VII.PromptChar = ' ';
            this.txtUkupno_VII.Size = new System.Drawing.Size(100, 20);
            this.txtUkupno_VII.TabIndex = 213;
            this.txtUkupno_VII.Text = " ";
            this.txtUkupno_VII.UseAppStyling = false;
            // 
            // ultraLabel77
            // 
            appearance141.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel77.Appearance = appearance141;
            this.ultraLabel77.AutoSize = true;
            this.ultraLabel77.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ultraLabel77.Location = new System.Drawing.Point(14, 1311);
            this.ultraLabel77.Name = "ultraLabel77";
            this.ultraLabel77.Size = new System.Drawing.Size(227, 14);
            this.ultraLabel77.TabIndex = 212;
            this.ultraLabel77.Text = "VII.    ISPLAĆENI NEOPOREZIVI PRIMICI";
            this.ultraLabel77.UseAppStyling = false;
            // 
            // ultraLabel73
            // 
            appearance146.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel73.Appearance = appearance146;
            this.ultraLabel73.AutoSize = true;
            this.ultraLabel73.Location = new System.Drawing.Point(35, 1225);
            this.ultraLabel73.Name = "ultraLabel73";
            this.ultraLabel73.Size = new System.Drawing.Size(14, 14);
            this.ultraLabel73.TabIndex = 211;
            this.ultraLabel73.Text = "2.";
            this.ultraLabel73.UseAppStyling = false;
            // 
            // ultraLabel74
            // 
            appearance147.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel74.Appearance = appearance147;
            this.ultraLabel74.Location = new System.Drawing.Point(67, 1225);
            this.ultraLabel74.Name = "ultraLabel74";
            this.ultraLabel74.Size = new System.Drawing.Size(526, 18);
            this.ultraLabel74.TabIndex = 210;
            this.ultraLabel74.Text = "Ukupan iznos posebnog doprinosa za zapošljavanje osoba s invaliditetom";
            this.ultraLabel74.UseAppStyling = false;
            // 
            // txtUkupno_VI_4_2
            // 
            appearance148.TextHAlignAsString = "Right";
            this.txtUkupno_VI_4_2.Appearance = appearance148;
            this.txtUkupno_VI_4_2.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtUkupno_VI_4_2.InputMask = "{LOC} n,nnn,nnn.nn";
            this.txtUkupno_VI_4_2.Location = new System.Drawing.Point(599, 1222);
            this.txtUkupno_VI_4_2.Name = "txtUkupno_VI_4_2";
            this.txtUkupno_VI_4_2.PromptChar = ' ';
            this.txtUkupno_VI_4_2.Size = new System.Drawing.Size(100, 20);
            this.txtUkupno_VI_4_2.TabIndex = 209;
            this.txtUkupno_VI_4_2.Text = " ";
            this.txtUkupno_VI_4_2.UseAppStyling = false;
            // 
            // ultraLabel75
            // 
            appearance149.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel75.Appearance = appearance149;
            this.ultraLabel75.AutoSize = true;
            this.ultraLabel75.Location = new System.Drawing.Point(35, 1201);
            this.ultraLabel75.Name = "ultraLabel75";
            this.ultraLabel75.Size = new System.Drawing.Size(14, 14);
            this.ultraLabel75.TabIndex = 208;
            this.ultraLabel75.Text = "1.";
            this.ultraLabel75.UseAppStyling = false;
            // 
            // ultraLabel76
            // 
            appearance150.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel76.Appearance = appearance150;
            this.ultraLabel76.Location = new System.Drawing.Point(67, 1201);
            this.ultraLabel76.Name = "ultraLabel76";
            this.ultraLabel76.Size = new System.Drawing.Size(526, 18);
            this.ultraLabel76.TabIndex = 207;
            this.ultraLabel76.Text = "Ukupan iznos doprinosa za zapošljavanje";
            this.ultraLabel76.UseAppStyling = false;
            // 
            // txtUkupno_VI_4_1
            // 
            appearance151.TextHAlignAsString = "Right";
            this.txtUkupno_VI_4_1.Appearance = appearance151;
            this.txtUkupno_VI_4_1.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtUkupno_VI_4_1.InputMask = "{LOC} n,nnn,nnn.nn";
            this.txtUkupno_VI_4_1.Location = new System.Drawing.Point(599, 1198);
            this.txtUkupno_VI_4_1.Name = "txtUkupno_VI_4_1";
            this.txtUkupno_VI_4_1.PromptChar = ' ';
            this.txtUkupno_VI_4_1.Size = new System.Drawing.Size(100, 20);
            this.txtUkupno_VI_4_1.TabIndex = 206;
            this.txtUkupno_VI_4_1.Text = " ";
            this.txtUkupno_VI_4_1.UseAppStyling = false;
            // 
            // ultraLabel72
            // 
            appearance6.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel72.Appearance = appearance6;
            this.ultraLabel72.AutoSize = true;
            this.ultraLabel72.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ultraLabel72.Location = new System.Drawing.Point(35, 1180);
            this.ultraLabel72.Name = "ultraLabel72";
            this.ultraLabel72.Size = new System.Drawing.Size(213, 14);
            this.ultraLabel72.TabIndex = 205;
            this.ultraLabel72.Text = "VI.4. DOPRINOS ZA ZAPOŠLJAVANJE";
            this.ultraLabel72.UseAppStyling = false;
            // 
            // ultraLabel64
            // 
            appearance137.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel64.Appearance = appearance137;
            this.ultraLabel64.AutoSize = true;
            this.ultraLabel64.Location = new System.Drawing.Point(35, 1080);
            this.ultraLabel64.Name = "ultraLabel64";
            this.ultraLabel64.Size = new System.Drawing.Size(20, 14);
            this.ultraLabel64.TabIndex = 204;
            this.ultraLabel64.Text = "10.";
            this.ultraLabel64.UseAppStyling = false;
            // 
            // ultraLabel65
            // 
            appearance138.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel65.Appearance = appearance138;
            this.ultraLabel65.Location = new System.Drawing.Point(67, 1080);
            this.ultraLabel65.Name = "ultraLabel65";
            this.ultraLabel65.Size = new System.Drawing.Size(526, 30);
            this.ultraLabel65.TabIndex = 203;
            this.ultraLabel65.Text = "Ukupan iznos posebnog doprinosa za zaštitu zdravlja na radu - za osobe osigurane " +
    "u određenim \r\nokolnostima";
            this.ultraLabel65.UseAppStyling = false;
            // 
            // txtUkupno_VI_3_10
            // 
            appearance139.TextHAlignAsString = "Right";
            this.txtUkupno_VI_3_10.Appearance = appearance139;
            this.txtUkupno_VI_3_10.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtUkupno_VI_3_10.InputMask = "{LOC} n,nnn,nnn.nn";
            this.txtUkupno_VI_3_10.Location = new System.Drawing.Point(599, 1077);
            this.txtUkupno_VI_3_10.Name = "txtUkupno_VI_3_10";
            this.txtUkupno_VI_3_10.PromptChar = ' ';
            this.txtUkupno_VI_3_10.Size = new System.Drawing.Size(100, 20);
            this.txtUkupno_VI_3_10.TabIndex = 202;
            this.txtUkupno_VI_3_10.Text = " ";
            this.txtUkupno_VI_3_10.UseAppStyling = false;
            // 
            // ultraLabel66
            // 
            appearance85.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel66.Appearance = appearance85;
            this.ultraLabel66.AutoSize = true;
            this.ultraLabel66.Location = new System.Drawing.Point(35, 1048);
            this.ultraLabel66.Name = "ultraLabel66";
            this.ultraLabel66.Size = new System.Drawing.Size(14, 14);
            this.ultraLabel66.TabIndex = 201;
            this.ultraLabel66.Text = "9.";
            this.ultraLabel66.UseAppStyling = false;
            // 
            // ultraLabel67
            // 
            appearance86.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel67.Appearance = appearance86;
            this.ultraLabel67.Location = new System.Drawing.Point(67, 1048);
            this.ultraLabel67.Name = "ultraLabel67";
            this.ultraLabel67.Size = new System.Drawing.Size(526, 30);
            this.ultraLabel67.TabIndex = 200;
            this.ultraLabel67.Text = "Ukupan iznos doprinosa za zaštitu zdravlja na radu - za osiguranike za koje se do" +
    "prinos uplaćuje\r\nprema posebnim propisima";
            this.ultraLabel67.UseAppStyling = false;
            // 
            // txtUkupno_VI_3_9
            // 
            appearance87.TextHAlignAsString = "Right";
            this.txtUkupno_VI_3_9.Appearance = appearance87;
            this.txtUkupno_VI_3_9.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtUkupno_VI_3_9.InputMask = "{LOC} n,nnn,nnn.nn";
            this.txtUkupno_VI_3_9.Location = new System.Drawing.Point(599, 1045);
            this.txtUkupno_VI_3_9.Name = "txtUkupno_VI_3_9";
            this.txtUkupno_VI_3_9.PromptChar = ' ';
            this.txtUkupno_VI_3_9.Size = new System.Drawing.Size(100, 20);
            this.txtUkupno_VI_3_9.TabIndex = 199;
            this.txtUkupno_VI_3_9.Text = " ";
            this.txtUkupno_VI_3_9.UseAppStyling = false;
            // 
            // ultraLabel68
            // 
            appearance88.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel68.Appearance = appearance88;
            this.ultraLabel68.AutoSize = true;
            this.ultraLabel68.Location = new System.Drawing.Point(35, 1016);
            this.ultraLabel68.Name = "ultraLabel68";
            this.ultraLabel68.Size = new System.Drawing.Size(14, 14);
            this.ultraLabel68.TabIndex = 198;
            this.ultraLabel68.Text = "8.";
            this.ultraLabel68.UseAppStyling = false;
            // 
            // ultraLabel69
            // 
            appearance89.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel69.Appearance = appearance89;
            this.ultraLabel69.Location = new System.Drawing.Point(67, 1016);
            this.ultraLabel69.Name = "ultraLabel69";
            this.ultraLabel69.Size = new System.Drawing.Size(526, 30);
            this.ultraLabel69.TabIndex = 197;
            this.ultraLabel69.Text = "Ukupan iznos doprinosa za zdravstveno osiguranje - za osiguranike za koje se dopr" +
    "inos uplaćuje prema\r\nposebnim propisima";
            this.ultraLabel69.UseAppStyling = false;
            // 
            // txtUkupno_VI_3_8
            // 
            appearance90.TextHAlignAsString = "Right";
            this.txtUkupno_VI_3_8.Appearance = appearance90;
            this.txtUkupno_VI_3_8.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtUkupno_VI_3_8.InputMask = "{LOC} n,nnn,nnn.nn";
            this.txtUkupno_VI_3_8.Location = new System.Drawing.Point(599, 1013);
            this.txtUkupno_VI_3_8.Name = "txtUkupno_VI_3_8";
            this.txtUkupno_VI_3_8.PromptChar = ' ';
            this.txtUkupno_VI_3_8.Size = new System.Drawing.Size(100, 20);
            this.txtUkupno_VI_3_8.TabIndex = 196;
            this.txtUkupno_VI_3_8.Text = " ";
            this.txtUkupno_VI_3_8.UseAppStyling = false;
            // 
            // ultraLabel70
            // 
            appearance91.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel70.Appearance = appearance91;
            this.ultraLabel70.AutoSize = true;
            this.ultraLabel70.Location = new System.Drawing.Point(35, 984);
            this.ultraLabel70.Name = "ultraLabel70";
            this.ultraLabel70.Size = new System.Drawing.Size(14, 14);
            this.ultraLabel70.TabIndex = 195;
            this.ultraLabel70.Text = "7.";
            this.ultraLabel70.UseAppStyling = false;
            // 
            // ultraLabel71
            // 
            appearance92.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel71.Appearance = appearance92;
            this.ultraLabel71.Location = new System.Drawing.Point(67, 984);
            this.ultraLabel71.Name = "ultraLabel71";
            this.ultraLabel71.Size = new System.Drawing.Size(526, 30);
            this.ultraLabel71.TabIndex = 194;
            this.ultraLabel71.Text = "Ukupan iznos posebnog doprinosa za zdravstveno osiguranje – za obveznike po osnov" +
    "i korisnika mirovina";
            this.ultraLabel71.UseAppStyling = false;
            // 
            // txtUkupno_VI_3_7
            // 
            appearance93.TextHAlignAsString = "Right";
            this.txtUkupno_VI_3_7.Appearance = appearance93;
            this.txtUkupno_VI_3_7.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtUkupno_VI_3_7.InputMask = "{LOC} n,nnn,nnn.nn";
            this.txtUkupno_VI_3_7.Location = new System.Drawing.Point(599, 981);
            this.txtUkupno_VI_3_7.Name = "txtUkupno_VI_3_7";
            this.txtUkupno_VI_3_7.PromptChar = ' ';
            this.txtUkupno_VI_3_7.Size = new System.Drawing.Size(100, 20);
            this.txtUkupno_VI_3_7.TabIndex = 193;
            this.txtUkupno_VI_3_7.Text = " ";
            this.txtUkupno_VI_3_7.UseAppStyling = false;
            // 
            // ultraLabel57
            // 
            appearance40.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel57.Appearance = appearance40;
            this.ultraLabel57.AutoSize = true;
            this.ultraLabel57.Location = new System.Drawing.Point(35, 960);
            this.ultraLabel57.Name = "ultraLabel57";
            this.ultraLabel57.Size = new System.Drawing.Size(14, 14);
            this.ultraLabel57.TabIndex = 192;
            this.ultraLabel57.Text = "6.";
            this.ultraLabel57.UseAppStyling = false;
            // 
            // ultraLabel58
            // 
            appearance41.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel58.Appearance = appearance41;
            this.ultraLabel58.Location = new System.Drawing.Point(67, 960);
            this.ultraLabel58.Name = "ultraLabel58";
            this.ultraLabel58.Size = new System.Drawing.Size(526, 18);
            this.ultraLabel58.TabIndex = 191;
            this.ultraLabel58.Text = "Ukupan iznos posebnog doprinosa za korištenje zdravstvene zaštite u inozemstvu";
            this.ultraLabel58.UseAppStyling = false;
            // 
            // txtUkupno_VI_3_6
            // 
            appearance42.TextHAlignAsString = "Right";
            this.txtUkupno_VI_3_6.Appearance = appearance42;
            this.txtUkupno_VI_3_6.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtUkupno_VI_3_6.InputMask = "{LOC} n,nnn,nnn.nn";
            this.txtUkupno_VI_3_6.Location = new System.Drawing.Point(599, 957);
            this.txtUkupno_VI_3_6.Name = "txtUkupno_VI_3_6";
            this.txtUkupno_VI_3_6.PromptChar = ' ';
            this.txtUkupno_VI_3_6.Size = new System.Drawing.Size(100, 20);
            this.txtUkupno_VI_3_6.TabIndex = 190;
            this.txtUkupno_VI_3_6.Text = " ";
            this.txtUkupno_VI_3_6.UseAppStyling = false;
            // 
            // ultraLabel59
            // 
            appearance17.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel59.Appearance = appearance17;
            this.ultraLabel59.AutoSize = true;
            this.ultraLabel59.Location = new System.Drawing.Point(35, 936);
            this.ultraLabel59.Name = "ultraLabel59";
            this.ultraLabel59.Size = new System.Drawing.Size(14, 14);
            this.ultraLabel59.TabIndex = 189;
            this.ultraLabel59.Text = "5.";
            this.ultraLabel59.UseAppStyling = false;
            // 
            // ultraLabel60
            // 
            appearance38.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel60.Appearance = appearance38;
            this.ultraLabel60.Location = new System.Drawing.Point(67, 936);
            this.ultraLabel60.Name = "ultraLabel60";
            this.ultraLabel60.Size = new System.Drawing.Size(526, 18);
            this.ultraLabel60.TabIndex = 188;
            this.ultraLabel60.Text = "Ukupan iznos doprinosa za zdravstveno osiguranje po osnovi drugog dohotka";
            this.ultraLabel60.UseAppStyling = false;
            // 
            // txtUkupno_VI_3_5
            // 
            appearance39.TextHAlignAsString = "Right";
            this.txtUkupno_VI_3_5.Appearance = appearance39;
            this.txtUkupno_VI_3_5.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtUkupno_VI_3_5.InputMask = "{LOC} n,nnn,nnn.nn";
            this.txtUkupno_VI_3_5.Location = new System.Drawing.Point(599, 933);
            this.txtUkupno_VI_3_5.Name = "txtUkupno_VI_3_5";
            this.txtUkupno_VI_3_5.PromptChar = ' ';
            this.txtUkupno_VI_3_5.Size = new System.Drawing.Size(100, 20);
            this.txtUkupno_VI_3_5.TabIndex = 187;
            this.txtUkupno_VI_3_5.Text = " ";
            this.txtUkupno_VI_3_5.UseAppStyling = false;
            // 
            // ultraLabel62
            // 
            appearance14.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel62.Appearance = appearance14;
            this.ultraLabel62.AutoSize = true;
            this.ultraLabel62.Location = new System.Drawing.Point(35, 912);
            this.ultraLabel62.Name = "ultraLabel62";
            this.ultraLabel62.Size = new System.Drawing.Size(14, 14);
            this.ultraLabel62.TabIndex = 186;
            this.ultraLabel62.Text = "4.";
            this.ultraLabel62.UseAppStyling = false;
            // 
            // ultraLabel63
            // 
            appearance15.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel63.Appearance = appearance15;
            this.ultraLabel63.Location = new System.Drawing.Point(67, 912);
            this.ultraLabel63.Name = "ultraLabel63";
            this.ultraLabel63.Size = new System.Drawing.Size(526, 18);
            this.ultraLabel63.TabIndex = 185;
            this.ultraLabel63.Text = "Ukupan iznos doprinosa za zaštitu zdravlja na radu po osnovi poduzetničke plaće";
            this.ultraLabel63.UseAppStyling = false;
            // 
            // txtUkupno_VI_3_4
            // 
            appearance16.TextHAlignAsString = "Right";
            this.txtUkupno_VI_3_4.Appearance = appearance16;
            this.txtUkupno_VI_3_4.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtUkupno_VI_3_4.InputMask = "{LOC} n,nnn,nnn.nn";
            this.txtUkupno_VI_3_4.Location = new System.Drawing.Point(599, 909);
            this.txtUkupno_VI_3_4.Name = "txtUkupno_VI_3_4";
            this.txtUkupno_VI_3_4.PromptChar = ' ';
            this.txtUkupno_VI_3_4.Size = new System.Drawing.Size(100, 20);
            this.txtUkupno_VI_3_4.TabIndex = 184;
            this.txtUkupno_VI_3_4.Text = " ";
            this.txtUkupno_VI_3_4.UseAppStyling = false;
            // 
            // ultraLabel51
            // 
            appearance54.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel51.Appearance = appearance54;
            this.ultraLabel51.AutoSize = true;
            this.ultraLabel51.Location = new System.Drawing.Point(35, 888);
            this.ultraLabel51.Name = "ultraLabel51";
            this.ultraLabel51.Size = new System.Drawing.Size(14, 14);
            this.ultraLabel51.TabIndex = 183;
            this.ultraLabel51.Text = "3.";
            this.ultraLabel51.UseAppStyling = false;
            // 
            // ultraLabel52
            // 
            appearance55.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel52.Appearance = appearance55;
            this.ultraLabel52.Location = new System.Drawing.Point(67, 888);
            this.ultraLabel52.Name = "ultraLabel52";
            this.ultraLabel52.Size = new System.Drawing.Size(526, 18);
            this.ultraLabel52.TabIndex = 182;
            this.ultraLabel52.Text = "Ukupan iznos doprinosa za zdravstveno osiguranje po osnovi poduzetničke plaće";
            this.ultraLabel52.UseAppStyling = false;
            // 
            // txtUkupno_VI_3_3
            // 
            appearance56.TextHAlignAsString = "Right";
            this.txtUkupno_VI_3_3.Appearance = appearance56;
            this.txtUkupno_VI_3_3.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtUkupno_VI_3_3.InputMask = "{LOC} n,nnn,nnn.nn";
            this.txtUkupno_VI_3_3.Location = new System.Drawing.Point(599, 885);
            this.txtUkupno_VI_3_3.Name = "txtUkupno_VI_3_3";
            this.txtUkupno_VI_3_3.PromptChar = ' ';
            this.txtUkupno_VI_3_3.Size = new System.Drawing.Size(100, 20);
            this.txtUkupno_VI_3_3.TabIndex = 181;
            this.txtUkupno_VI_3_3.Text = " ";
            this.txtUkupno_VI_3_3.UseAppStyling = false;
            // 
            // ultraLabel53
            // 
            appearance117.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel53.Appearance = appearance117;
            this.ultraLabel53.AutoSize = true;
            this.ultraLabel53.Location = new System.Drawing.Point(35, 864);
            this.ultraLabel53.Name = "ultraLabel53";
            this.ultraLabel53.Size = new System.Drawing.Size(14, 14);
            this.ultraLabel53.TabIndex = 180;
            this.ultraLabel53.Text = "2.";
            this.ultraLabel53.UseAppStyling = false;
            // 
            // ultraLabel54
            // 
            appearance118.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel54.Appearance = appearance118;
            this.ultraLabel54.Location = new System.Drawing.Point(67, 864);
            this.ultraLabel54.Name = "ultraLabel54";
            this.ultraLabel54.Size = new System.Drawing.Size(526, 18);
            this.ultraLabel54.TabIndex = 179;
            this.ultraLabel54.Text = "Ukupan iznos doprinosa za zaštitu zdravlja na radu po osnovi radnog odnosa";
            this.ultraLabel54.UseAppStyling = false;
            // 
            // txtUkupno_VI_3_2
            // 
            appearance119.TextHAlignAsString = "Right";
            this.txtUkupno_VI_3_2.Appearance = appearance119;
            this.txtUkupno_VI_3_2.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtUkupno_VI_3_2.InputMask = "{LOC} n,nnn,nnn.nn";
            this.txtUkupno_VI_3_2.Location = new System.Drawing.Point(599, 861);
            this.txtUkupno_VI_3_2.Name = "txtUkupno_VI_3_2";
            this.txtUkupno_VI_3_2.PromptChar = ' ';
            this.txtUkupno_VI_3_2.Size = new System.Drawing.Size(100, 20);
            this.txtUkupno_VI_3_2.TabIndex = 178;
            this.txtUkupno_VI_3_2.Text = " ";
            this.txtUkupno_VI_3_2.UseAppStyling = false;
            // 
            // ultraLabel55
            // 
            appearance120.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel55.Appearance = appearance120;
            this.ultraLabel55.AutoSize = true;
            this.ultraLabel55.Location = new System.Drawing.Point(35, 840);
            this.ultraLabel55.Name = "ultraLabel55";
            this.ultraLabel55.Size = new System.Drawing.Size(14, 14);
            this.ultraLabel55.TabIndex = 177;
            this.ultraLabel55.Text = "1.";
            this.ultraLabel55.UseAppStyling = false;
            // 
            // ultraLabel56
            // 
            appearance121.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel56.Appearance = appearance121;
            this.ultraLabel56.Location = new System.Drawing.Point(67, 840);
            this.ultraLabel56.Name = "ultraLabel56";
            this.ultraLabel56.Size = new System.Drawing.Size(526, 18);
            this.ultraLabel56.TabIndex = 176;
            this.ultraLabel56.Text = "Ukupan iznos doprinosa za zdravstveno osiguranje po osnovi radnog odnosa";
            this.ultraLabel56.UseAppStyling = false;
            // 
            // txtUkupno_VI_3_1
            // 
            appearance122.TextHAlignAsString = "Right";
            this.txtUkupno_VI_3_1.Appearance = appearance122;
            this.txtUkupno_VI_3_1.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtUkupno_VI_3_1.InputMask = "{LOC} n,nnn,nnn.nn";
            this.txtUkupno_VI_3_1.Location = new System.Drawing.Point(599, 837);
            this.txtUkupno_VI_3_1.Name = "txtUkupno_VI_3_1";
            this.txtUkupno_VI_3_1.PromptChar = ' ';
            this.txtUkupno_VI_3_1.Size = new System.Drawing.Size(100, 20);
            this.txtUkupno_VI_3_1.TabIndex = 175;
            this.txtUkupno_VI_3_1.Text = " ";
            this.txtUkupno_VI_3_1.UseAppStyling = false;
            // 
            // ultraLabel61
            // 
            appearance123.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel61.Appearance = appearance123;
            this.ultraLabel61.AutoSize = true;
            this.ultraLabel61.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ultraLabel61.Location = new System.Drawing.Point(33, 815);
            this.ultraLabel61.Name = "ultraLabel61";
            this.ultraLabel61.Size = new System.Drawing.Size(282, 14);
            this.ultraLabel61.TabIndex = 174;
            this.ultraLabel61.Text = "VI.3. DOPRINOS ZA ZDRAVSTVENO OSIGURANJE";
            this.ultraLabel61.UseAppStyling = false;
            // 
            // ultraLabel43
            // 
            appearance24.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel43.Appearance = appearance24;
            this.ultraLabel43.AutoSize = true;
            this.ultraLabel43.Location = new System.Drawing.Point(35, 754);
            this.ultraLabel43.Name = "ultraLabel43";
            this.ultraLabel43.Size = new System.Drawing.Size(14, 14);
            this.ultraLabel43.TabIndex = 173;
            this.ultraLabel43.Text = "5.";
            this.ultraLabel43.UseAppStyling = false;
            // 
            // ultraLabel44
            // 
            appearance32.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel44.Appearance = appearance32;
            this.ultraLabel44.Location = new System.Drawing.Point(67, 754);
            this.ultraLabel44.Name = "ultraLabel44";
            this.ultraLabel44.Size = new System.Drawing.Size(526, 30);
            this.ultraLabel44.TabIndex = 172;
            this.ultraLabel44.Text = "Ukupan iznos dodatnog doprinosa za mirovinsko osiguranje na temelju individualne " +
    "kapitalizirane";
            this.ultraLabel44.UseAppStyling = false;
            // 
            // txtUkupno_VI_2_5
            // 
            appearance35.TextHAlignAsString = "Right";
            this.txtUkupno_VI_2_5.Appearance = appearance35;
            this.txtUkupno_VI_2_5.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtUkupno_VI_2_5.InputMask = "{LOC} n,nnn,nnn.nn";
            this.txtUkupno_VI_2_5.Location = new System.Drawing.Point(599, 751);
            this.txtUkupno_VI_2_5.Name = "txtUkupno_VI_2_5";
            this.txtUkupno_VI_2_5.PromptChar = ' ';
            this.txtUkupno_VI_2_5.Size = new System.Drawing.Size(100, 20);
            this.txtUkupno_VI_2_5.TabIndex = 171;
            this.txtUkupno_VI_2_5.Text = " ";
            this.txtUkupno_VI_2_5.UseAppStyling = false;
            // 
            // ultraLabel45
            // 
            appearance104.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel45.Appearance = appearance104;
            this.ultraLabel45.AutoSize = true;
            this.ultraLabel45.Location = new System.Drawing.Point(35, 718);
            this.ultraLabel45.Name = "ultraLabel45";
            this.ultraLabel45.Size = new System.Drawing.Size(14, 14);
            this.ultraLabel45.TabIndex = 170;
            this.ultraLabel45.Text = "4.";
            this.ultraLabel45.UseAppStyling = false;
            // 
            // ultraLabel46
            // 
            appearance105.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel46.Appearance = appearance105;
            this.ultraLabel46.Location = new System.Drawing.Point(67, 718);
            this.ultraLabel46.Name = "ultraLabel46";
            this.ultraLabel46.Size = new System.Drawing.Size(526, 30);
            this.ultraLabel46.TabIndex = 169;
            this.ultraLabel46.Text = "Ukupan iznos doprinosa za mirovinsko osiguranje na temelju individualne kapitaliz" +
    "irane štednje za osiguranike za koje se doprinos uplaćuje prema posebnim propisi" +
    "ma";
            this.ultraLabel46.UseAppStyling = false;
            // 
            // txtUkupno_VI_2_4
            // 
            appearance106.TextHAlignAsString = "Right";
            this.txtUkupno_VI_2_4.Appearance = appearance106;
            this.txtUkupno_VI_2_4.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtUkupno_VI_2_4.InputMask = "{LOC} n,nnn,nnn.nn";
            this.txtUkupno_VI_2_4.Location = new System.Drawing.Point(599, 715);
            this.txtUkupno_VI_2_4.Name = "txtUkupno_VI_2_4";
            this.txtUkupno_VI_2_4.PromptChar = ' ';
            this.txtUkupno_VI_2_4.Size = new System.Drawing.Size(100, 20);
            this.txtUkupno_VI_2_4.TabIndex = 168;
            this.txtUkupno_VI_2_4.Text = " ";
            this.txtUkupno_VI_2_4.UseAppStyling = false;
            // 
            // ultraLabel47
            // 
            appearance107.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel47.Appearance = appearance107;
            this.ultraLabel47.AutoSize = true;
            this.ultraLabel47.Location = new System.Drawing.Point(35, 682);
            this.ultraLabel47.Name = "ultraLabel47";
            this.ultraLabel47.Size = new System.Drawing.Size(14, 14);
            this.ultraLabel47.TabIndex = 167;
            this.ultraLabel47.Text = "3.";
            this.ultraLabel47.UseAppStyling = false;
            // 
            // ultraLabel48
            // 
            appearance108.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel48.Appearance = appearance108;
            this.ultraLabel48.Location = new System.Drawing.Point(67, 682);
            this.ultraLabel48.Name = "ultraLabel48";
            this.ultraLabel48.Size = new System.Drawing.Size(526, 30);
            this.ultraLabel48.TabIndex = 166;
            this.ultraLabel48.Text = "Ukupan iznos doprinosa za mirovinsko osiguranje na temelju individualne kapitaliz" +
    "irane štednje po osnovi poduzetniĉke plaće";
            this.ultraLabel48.UseAppStyling = false;
            // 
            // txtUkupno_VI_2_3
            // 
            appearance109.TextHAlignAsString = "Right";
            this.txtUkupno_VI_2_3.Appearance = appearance109;
            this.txtUkupno_VI_2_3.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtUkupno_VI_2_3.InputMask = "{LOC} n,nnn,nnn.nn";
            this.txtUkupno_VI_2_3.Location = new System.Drawing.Point(599, 679);
            this.txtUkupno_VI_2_3.Name = "txtUkupno_VI_2_3";
            this.txtUkupno_VI_2_3.PromptChar = ' ';
            this.txtUkupno_VI_2_3.Size = new System.Drawing.Size(100, 20);
            this.txtUkupno_VI_2_3.TabIndex = 165;
            this.txtUkupno_VI_2_3.Text = " ";
            this.txtUkupno_VI_2_3.UseAppStyling = false;
            // 
            // ultraLabel49
            // 
            appearance110.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel49.Appearance = appearance110;
            this.ultraLabel49.AutoSize = true;
            this.ultraLabel49.Location = new System.Drawing.Point(35, 646);
            this.ultraLabel49.Name = "ultraLabel49";
            this.ultraLabel49.Size = new System.Drawing.Size(14, 14);
            this.ultraLabel49.TabIndex = 164;
            this.ultraLabel49.Text = "2.";
            this.ultraLabel49.UseAppStyling = false;
            // 
            // ultraLabel50
            // 
            appearance111.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel50.Appearance = appearance111;
            this.ultraLabel50.Location = new System.Drawing.Point(67, 646);
            this.ultraLabel50.Name = "ultraLabel50";
            this.ultraLabel50.Size = new System.Drawing.Size(526, 30);
            this.ultraLabel50.TabIndex = 163;
            this.ultraLabel50.Text = "Ukupan iznos doprinosa za mirovinsko osiguranje na temelju individualne kapitaliz" +
    "irane štednje po osnovi drugog dohotka";
            this.ultraLabel50.UseAppStyling = false;
            // 
            // txtUkupno_VI_2_2
            // 
            appearance112.TextHAlignAsString = "Right";
            this.txtUkupno_VI_2_2.Appearance = appearance112;
            this.txtUkupno_VI_2_2.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtUkupno_VI_2_2.InputMask = "{LOC} n,nnn,nnn.nn";
            this.txtUkupno_VI_2_2.Location = new System.Drawing.Point(599, 643);
            this.txtUkupno_VI_2_2.Name = "txtUkupno_VI_2_2";
            this.txtUkupno_VI_2_2.PromptChar = ' ';
            this.txtUkupno_VI_2_2.Size = new System.Drawing.Size(100, 20);
            this.txtUkupno_VI_2_2.TabIndex = 162;
            this.txtUkupno_VI_2_2.Text = " ";
            this.txtUkupno_VI_2_2.UseAppStyling = false;
            // 
            // ultraLabel41
            // 
            appearance113.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel41.Appearance = appearance113;
            this.ultraLabel41.AutoSize = true;
            this.ultraLabel41.Location = new System.Drawing.Point(35, 610);
            this.ultraLabel41.Name = "ultraLabel41";
            this.ultraLabel41.Size = new System.Drawing.Size(14, 14);
            this.ultraLabel41.TabIndex = 161;
            this.ultraLabel41.Text = "1.";
            this.ultraLabel41.UseAppStyling = false;
            // 
            // ultraLabel42
            // 
            appearance114.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel42.Appearance = appearance114;
            this.ultraLabel42.Location = new System.Drawing.Point(67, 610);
            this.ultraLabel42.Name = "ultraLabel42";
            this.ultraLabel42.Size = new System.Drawing.Size(526, 30);
            this.ultraLabel42.TabIndex = 160;
            this.ultraLabel42.Text = "Ukupan iznos doprinosa za mirovinsko osiguranje na temelju individualne kapitaliz" +
    "irane štednje po osnovi radnog odnosa";
            this.ultraLabel42.UseAppStyling = false;
            // 
            // txtUkupno_VI_2_1
            // 
            appearance115.TextHAlignAsString = "Right";
            this.txtUkupno_VI_2_1.Appearance = appearance115;
            this.txtUkupno_VI_2_1.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtUkupno_VI_2_1.InputMask = "{LOC} n,nnn,nnn.nn";
            this.txtUkupno_VI_2_1.Location = new System.Drawing.Point(599, 607);
            this.txtUkupno_VI_2_1.Name = "txtUkupno_VI_2_1";
            this.txtUkupno_VI_2_1.PromptChar = ' ';
            this.txtUkupno_VI_2_1.Size = new System.Drawing.Size(100, 20);
            this.txtUkupno_VI_2_1.TabIndex = 159;
            this.txtUkupno_VI_2_1.Text = " ";
            this.txtUkupno_VI_2_1.UseAppStyling = false;
            // 
            // ultraLabel40
            // 
            appearance94.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel40.Appearance = appearance94;
            this.ultraLabel40.AutoSize = true;
            this.ultraLabel40.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ultraLabel40.Location = new System.Drawing.Point(33, 586);
            this.ultraLabel40.Name = "ultraLabel40";
            this.ultraLabel40.Size = new System.Drawing.Size(584, 14);
            this.ultraLabel40.TabIndex = 158;
            this.ultraLabel40.Text = "VI.2. DOPRINOS ZA MIROVINSKO OSIGURANJE NA TEMELJU INDIVIDUALNE KAPITALIZIRANE ŠT" +
    "EDNJE";
            this.ultraLabel40.UseAppStyling = false;
            // 
            // ultraLabel38
            // 
            appearance59.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel38.Appearance = appearance59;
            this.ultraLabel38.AutoSize = true;
            this.ultraLabel38.Location = new System.Drawing.Point(35, 513);
            this.ultraLabel38.Name = "ultraLabel38";
            this.ultraLabel38.Size = new System.Drawing.Size(14, 14);
            this.ultraLabel38.TabIndex = 157;
            this.ultraLabel38.Text = "6.";
            this.ultraLabel38.UseAppStyling = false;
            // 
            // ultraLabel39
            // 
            appearance126.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel39.Appearance = appearance126;
            this.ultraLabel39.Location = new System.Drawing.Point(67, 513);
            this.ultraLabel39.Name = "ultraLabel39";
            this.ultraLabel39.Size = new System.Drawing.Size(526, 30);
            this.ultraLabel39.TabIndex = 156;
            this.ultraLabel39.Text = "Ukupan iznos dodatnog doprinosa za mirovinsko osiguranje na temelju generacijske " +
    "solidarnosti za staž osiguranja koji se računa s povećanim trajanjem";
            this.ultraLabel39.UseAppStyling = false;
            // 
            // txtUkupno_VI_1_6
            // 
            appearance127.TextHAlignAsString = "Right";
            this.txtUkupno_VI_1_6.Appearance = appearance127;
            this.txtUkupno_VI_1_6.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtUkupno_VI_1_6.InputMask = "{LOC} n,nnn,nnn.nn";
            this.txtUkupno_VI_1_6.Location = new System.Drawing.Point(599, 510);
            this.txtUkupno_VI_1_6.Name = "txtUkupno_VI_1_6";
            this.txtUkupno_VI_1_6.PromptChar = ' ';
            this.txtUkupno_VI_1_6.Size = new System.Drawing.Size(100, 20);
            this.txtUkupno_VI_1_6.TabIndex = 155;
            this.txtUkupno_VI_1_6.Text = " ";
            this.txtUkupno_VI_1_6.UseAppStyling = false;
            // 
            // ultraLabel36
            // 
            appearance70.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel36.Appearance = appearance70;
            this.ultraLabel36.AutoSize = true;
            this.ultraLabel36.Location = new System.Drawing.Point(35, 477);
            this.ultraLabel36.Name = "ultraLabel36";
            this.ultraLabel36.Size = new System.Drawing.Size(14, 14);
            this.ultraLabel36.TabIndex = 154;
            this.ultraLabel36.Text = "5.";
            this.ultraLabel36.UseAppStyling = false;
            // 
            // ultraLabel37
            // 
            appearance71.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel37.Appearance = appearance71;
            this.ultraLabel37.Location = new System.Drawing.Point(67, 477);
            this.ultraLabel37.Name = "ultraLabel37";
            this.ultraLabel37.Size = new System.Drawing.Size(526, 30);
            this.ultraLabel37.TabIndex = 153;
            this.ultraLabel37.Text = "Ukupan iznos posebnog doprinosa za mirovinsko osiguranje na temelju generacijske " +
    "solidarnosti za osobe osigurane u određenim okolnostima";
            this.ultraLabel37.UseAppStyling = false;
            // 
            // txtUkupno_VI_1_5
            // 
            appearance72.TextHAlignAsString = "Right";
            this.txtUkupno_VI_1_5.Appearance = appearance72;
            this.txtUkupno_VI_1_5.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtUkupno_VI_1_5.InputMask = "{LOC} n,nnn,nnn.nn";
            this.txtUkupno_VI_1_5.Location = new System.Drawing.Point(599, 474);
            this.txtUkupno_VI_1_5.Name = "txtUkupno_VI_1_5";
            this.txtUkupno_VI_1_5.PromptChar = ' ';
            this.txtUkupno_VI_1_5.Size = new System.Drawing.Size(100, 20);
            this.txtUkupno_VI_1_5.TabIndex = 152;
            this.txtUkupno_VI_1_5.Text = " ";
            this.txtUkupno_VI_1_5.UseAppStyling = false;
            // 
            // ultraLabel34
            // 
            appearance73.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel34.Appearance = appearance73;
            this.ultraLabel34.AutoSize = true;
            this.ultraLabel34.Location = new System.Drawing.Point(35, 441);
            this.ultraLabel34.Name = "ultraLabel34";
            this.ultraLabel34.Size = new System.Drawing.Size(14, 14);
            this.ultraLabel34.TabIndex = 151;
            this.ultraLabel34.Text = "4.";
            this.ultraLabel34.UseAppStyling = false;
            // 
            // ultraLabel35
            // 
            appearance74.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel35.Appearance = appearance74;
            this.ultraLabel35.Location = new System.Drawing.Point(67, 441);
            this.ultraLabel35.Name = "ultraLabel35";
            this.ultraLabel35.Size = new System.Drawing.Size(526, 30);
            this.ultraLabel35.TabIndex = 150;
            this.ultraLabel35.Text = "Ukupan iznos doprinosa za mirovinsko osiguranje na temelju generacijske solidarno" +
    "sti za osiguranike za koje se doprinos uplaćuje prema posebnim propisima";
            this.ultraLabel35.UseAppStyling = false;
            // 
            // txtUkupno_VI_1_4
            // 
            appearance75.TextHAlignAsString = "Right";
            this.txtUkupno_VI_1_4.Appearance = appearance75;
            this.txtUkupno_VI_1_4.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtUkupno_VI_1_4.InputMask = "{LOC} n,nnn,nnn.nn";
            this.txtUkupno_VI_1_4.Location = new System.Drawing.Point(599, 438);
            this.txtUkupno_VI_1_4.Name = "txtUkupno_VI_1_4";
            this.txtUkupno_VI_1_4.PromptChar = ' ';
            this.txtUkupno_VI_1_4.Size = new System.Drawing.Size(100, 20);
            this.txtUkupno_VI_1_4.TabIndex = 149;
            this.txtUkupno_VI_1_4.Text = " ";
            this.txtUkupno_VI_1_4.UseAppStyling = false;
            // 
            // ultraLabel32
            // 
            appearance76.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel32.Appearance = appearance76;
            this.ultraLabel32.AutoSize = true;
            this.ultraLabel32.Location = new System.Drawing.Point(35, 405);
            this.ultraLabel32.Name = "ultraLabel32";
            this.ultraLabel32.Size = new System.Drawing.Size(14, 14);
            this.ultraLabel32.TabIndex = 148;
            this.ultraLabel32.Text = "3.";
            this.ultraLabel32.UseAppStyling = false;
            // 
            // ultraLabel33
            // 
            appearance77.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel33.Appearance = appearance77;
            this.ultraLabel33.Location = new System.Drawing.Point(67, 405);
            this.ultraLabel33.Name = "ultraLabel33";
            this.ultraLabel33.Size = new System.Drawing.Size(526, 30);
            this.ultraLabel33.TabIndex = 147;
            this.ultraLabel33.Text = "Ukupan iznos doprinosa za mirovinsko osiguranje na temelju generacijske solidarno" +
    "sti po osnovi poduzetničke plaće";
            this.ultraLabel33.UseAppStyling = false;
            // 
            // txtUkupno_VI_1_3
            // 
            appearance78.TextHAlignAsString = "Right";
            this.txtUkupno_VI_1_3.Appearance = appearance78;
            this.txtUkupno_VI_1_3.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtUkupno_VI_1_3.InputMask = "{LOC} n,nnn,nnn.nn";
            this.txtUkupno_VI_1_3.Location = new System.Drawing.Point(599, 402);
            this.txtUkupno_VI_1_3.Name = "txtUkupno_VI_1_3";
            this.txtUkupno_VI_1_3.PromptChar = ' ';
            this.txtUkupno_VI_1_3.Size = new System.Drawing.Size(100, 20);
            this.txtUkupno_VI_1_3.TabIndex = 146;
            this.txtUkupno_VI_1_3.Text = " ";
            this.txtUkupno_VI_1_3.UseAppStyling = false;
            // 
            // ultraLabel30
            // 
            appearance79.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel30.Appearance = appearance79;
            this.ultraLabel30.AutoSize = true;
            this.ultraLabel30.Location = new System.Drawing.Point(35, 369);
            this.ultraLabel30.Name = "ultraLabel30";
            this.ultraLabel30.Size = new System.Drawing.Size(14, 14);
            this.ultraLabel30.TabIndex = 145;
            this.ultraLabel30.Text = "2.";
            this.ultraLabel30.UseAppStyling = false;
            // 
            // ultraLabel31
            // 
            appearance80.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel31.Appearance = appearance80;
            this.ultraLabel31.Location = new System.Drawing.Point(67, 369);
            this.ultraLabel31.Name = "ultraLabel31";
            this.ultraLabel31.Size = new System.Drawing.Size(526, 30);
            this.ultraLabel31.TabIndex = 144;
            this.ultraLabel31.Text = "Ukupan iznos doprinosa za mirovinsko osiguranje na temelju generacijske solidarno" +
    "sti po osnovi drugog dohotka";
            this.ultraLabel31.UseAppStyling = false;
            // 
            // txtUkupno_VI_1_2
            // 
            appearance81.TextHAlignAsString = "Right";
            this.txtUkupno_VI_1_2.Appearance = appearance81;
            this.txtUkupno_VI_1_2.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtUkupno_VI_1_2.InputMask = "{LOC} n,nnn,nnn.nn";
            this.txtUkupno_VI_1_2.Location = new System.Drawing.Point(599, 366);
            this.txtUkupno_VI_1_2.Name = "txtUkupno_VI_1_2";
            this.txtUkupno_VI_1_2.PromptChar = ' ';
            this.txtUkupno_VI_1_2.Size = new System.Drawing.Size(100, 20);
            this.txtUkupno_VI_1_2.TabIndex = 143;
            this.txtUkupno_VI_1_2.Text = " ";
            this.txtUkupno_VI_1_2.UseAppStyling = false;
            // 
            // ultraLabel28
            // 
            appearance82.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel28.Appearance = appearance82;
            this.ultraLabel28.AutoSize = true;
            this.ultraLabel28.Location = new System.Drawing.Point(35, 333);
            this.ultraLabel28.Name = "ultraLabel28";
            this.ultraLabel28.Size = new System.Drawing.Size(14, 14);
            this.ultraLabel28.TabIndex = 142;
            this.ultraLabel28.Text = "1.";
            this.ultraLabel28.UseAppStyling = false;
            // 
            // ultraLabel29
            // 
            appearance83.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel29.Appearance = appearance83;
            this.ultraLabel29.Location = new System.Drawing.Point(67, 333);
            this.ultraLabel29.Name = "ultraLabel29";
            this.ultraLabel29.Size = new System.Drawing.Size(526, 30);
            this.ultraLabel29.TabIndex = 141;
            this.ultraLabel29.Text = "Ukupan iznos doprinosa za mirovinsko osiguranje na temelju generacijske solidarno" +
    "sti po osnovi radnog odnosa";
            this.ultraLabel29.UseAppStyling = false;
            // 
            // txtUkupno_VI_1_1
            // 
            appearance84.TextHAlignAsString = "Right";
            this.txtUkupno_VI_1_1.Appearance = appearance84;
            this.txtUkupno_VI_1_1.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtUkupno_VI_1_1.InputMask = "{LOC} n,nnn,nnn.nn";
            this.txtUkupno_VI_1_1.Location = new System.Drawing.Point(599, 330);
            this.txtUkupno_VI_1_1.Name = "txtUkupno_VI_1_1";
            this.txtUkupno_VI_1_1.PromptChar = ' ';
            this.txtUkupno_VI_1_1.Size = new System.Drawing.Size(100, 20);
            this.txtUkupno_VI_1_1.TabIndex = 140;
            this.txtUkupno_VI_1_1.Text = " ";
            this.txtUkupno_VI_1_1.UseAppStyling = false;
            // 
            // ultraLabel27
            // 
            appearance69.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel27.Appearance = appearance69;
            this.ultraLabel27.AutoSize = true;
            this.ultraLabel27.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ultraLabel27.Location = new System.Drawing.Point(33, 308);
            this.ultraLabel27.Name = "ultraLabel27";
            this.ultraLabel27.Size = new System.Drawing.Size(529, 14);
            this.ultraLabel27.TabIndex = 139;
            this.ultraLabel27.Text = "VI.1. DOPRINOS ZA MIROVINSKO OSIGURANJE NA TEMELJU GENERACIJSKE SOLIDARNOSTI";
            this.ultraLabel27.UseAppStyling = false;
            // 
            // ultraLabel26
            // 
            appearance124.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel26.Appearance = appearance124;
            this.ultraLabel26.AutoSize = true;
            this.ultraLabel26.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ultraLabel26.Location = new System.Drawing.Point(14, 288);
            this.ultraLabel26.Name = "ultraLabel26";
            this.ultraLabel26.Size = new System.Drawing.Size(358, 14);
            this.ultraLabel26.TabIndex = 138;
            this.ultraLabel26.Text = "VI. PODACI O UKUPNOM IZNOSU OBRAĈUNANOG DOPRINOSA";
            this.ultraLabel26.UseAppStyling = false;
            // 
            // ultraLabel24
            // 
            appearance21.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel24.Appearance = appearance21;
            this.ultraLabel24.AutoSize = true;
            this.ultraLabel24.Location = new System.Drawing.Point(35, 220);
            this.ultraLabel24.Name = "ultraLabel24";
            this.ultraLabel24.Size = new System.Drawing.Size(14, 14);
            this.ultraLabel24.TabIndex = 137;
            this.ultraLabel24.Text = "5.";
            this.ultraLabel24.UseAppStyling = false;
            // 
            // ultraLabel25
            // 
            appearance22.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel25.Appearance = appearance22;
            this.ultraLabel25.Location = new System.Drawing.Point(67, 220);
            this.ultraLabel25.Name = "ultraLabel25";
            this.ultraLabel25.Size = new System.Drawing.Size(526, 30);
            this.ultraLabel25.TabIndex = 136;
            this.ultraLabel25.Text = "Ukupan iznos predujma poreza na dohodak i prireza porezu na dohodak po osnovi pri" +
    "mitka od kojeg se utvrđuje drugi dohodak";
            this.ultraLabel25.UseAppStyling = false;
            // 
            // txtUkupno_V_5
            // 
            appearance23.TextHAlignAsString = "Right";
            this.txtUkupno_V_5.Appearance = appearance23;
            this.txtUkupno_V_5.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtUkupno_V_5.InputMask = "{LOC} n,nnn,nnn.nn";
            this.txtUkupno_V_5.Location = new System.Drawing.Point(599, 217);
            this.txtUkupno_V_5.Name = "txtUkupno_V_5";
            this.txtUkupno_V_5.PromptChar = ' ';
            this.txtUkupno_V_5.Size = new System.Drawing.Size(100, 20);
            this.txtUkupno_V_5.TabIndex = 135;
            this.txtUkupno_V_5.Text = " ";
            this.txtUkupno_V_5.UseAppStyling = false;
            // 
            // ultraLabel22
            // 
            appearance43.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel22.Appearance = appearance43;
            this.ultraLabel22.AutoSize = true;
            this.ultraLabel22.Location = new System.Drawing.Point(35, 184);
            this.ultraLabel22.Name = "ultraLabel22";
            this.ultraLabel22.Size = new System.Drawing.Size(14, 14);
            this.ultraLabel22.TabIndex = 134;
            this.ultraLabel22.Text = "4.";
            this.ultraLabel22.UseAppStyling = false;
            // 
            // ultraLabel23
            // 
            appearance44.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel23.Appearance = appearance44;
            this.ultraLabel23.Location = new System.Drawing.Point(67, 184);
            this.ultraLabel23.Name = "ultraLabel23";
            this.ultraLabel23.Size = new System.Drawing.Size(526, 30);
            this.ultraLabel23.TabIndex = 133;
            this.ultraLabel23.Text = "Ukupan iznos predujma poreza na dohodak i prireza porezu na dohodak po osnovi doh" +
    "otka od osiguranja";
            this.ultraLabel23.UseAppStyling = false;
            // 
            // txtUkupno_V_4
            // 
            appearance45.TextHAlignAsString = "Right";
            this.txtUkupno_V_4.Appearance = appearance45;
            this.txtUkupno_V_4.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtUkupno_V_4.InputMask = "{LOC} n,nnn,nnn.nn";
            this.txtUkupno_V_4.Location = new System.Drawing.Point(599, 181);
            this.txtUkupno_V_4.Name = "txtUkupno_V_4";
            this.txtUkupno_V_4.PromptChar = ' ';
            this.txtUkupno_V_4.Size = new System.Drawing.Size(100, 20);
            this.txtUkupno_V_4.TabIndex = 132;
            this.txtUkupno_V_4.Text = " ";
            this.txtUkupno_V_4.UseAppStyling = false;
            // 
            // ultraLabel20
            // 
            appearance46.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel20.Appearance = appearance46;
            this.ultraLabel20.AutoSize = true;
            this.ultraLabel20.Location = new System.Drawing.Point(35, 148);
            this.ultraLabel20.Name = "ultraLabel20";
            this.ultraLabel20.Size = new System.Drawing.Size(14, 14);
            this.ultraLabel20.TabIndex = 131;
            this.ultraLabel20.Text = "3.";
            this.ultraLabel20.UseAppStyling = false;
            // 
            // ultraLabel21
            // 
            appearance47.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel21.Appearance = appearance47;
            this.ultraLabel21.Location = new System.Drawing.Point(67, 148);
            this.ultraLabel21.Name = "ultraLabel21";
            this.ultraLabel21.Size = new System.Drawing.Size(526, 30);
            this.ultraLabel21.TabIndex = 130;
            this.ultraLabel21.Text = "Ukupan iznos predujma poreza na dohodak i prireza porezu na dohodak po osnovi doh" +
    "otka od imovinskih prava";
            this.ultraLabel21.UseAppStyling = false;
            // 
            // txtUkupno_V_3
            // 
            appearance48.TextHAlignAsString = "Right";
            this.txtUkupno_V_3.Appearance = appearance48;
            this.txtUkupno_V_3.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtUkupno_V_3.InputMask = "{LOC} n,nnn,nnn.nn";
            this.txtUkupno_V_3.Location = new System.Drawing.Point(599, 145);
            this.txtUkupno_V_3.Name = "txtUkupno_V_3";
            this.txtUkupno_V_3.PromptChar = ' ';
            this.txtUkupno_V_3.Size = new System.Drawing.Size(100, 20);
            this.txtUkupno_V_3.TabIndex = 129;
            this.txtUkupno_V_3.Text = " ";
            this.txtUkupno_V_3.UseAppStyling = false;
            // 
            // ultraLabel18
            // 
            appearance95.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel18.Appearance = appearance95;
            this.ultraLabel18.AutoSize = true;
            this.ultraLabel18.Location = new System.Drawing.Point(35, 124);
            this.ultraLabel18.Name = "ultraLabel18";
            this.ultraLabel18.Size = new System.Drawing.Size(14, 14);
            this.ultraLabel18.TabIndex = 128;
            this.ultraLabel18.Text = "2.";
            this.ultraLabel18.UseAppStyling = false;
            // 
            // ultraLabel19
            // 
            appearance96.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel19.Appearance = appearance96;
            this.ultraLabel19.Location = new System.Drawing.Point(67, 124);
            this.ultraLabel19.Name = "ultraLabel19";
            this.ultraLabel19.Size = new System.Drawing.Size(526, 18);
            this.ultraLabel19.TabIndex = 127;
            this.ultraLabel19.Text = "Ukupan iznos predujma poreza na dohodak i prireza porezu na dohodak po osnovi doh" +
    "otka od kapitala";
            this.ultraLabel19.UseAppStyling = false;
            // 
            // txtUkupno_V_2
            // 
            appearance97.TextHAlignAsString = "Right";
            this.txtUkupno_V_2.Appearance = appearance97;
            this.txtUkupno_V_2.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtUkupno_V_2.InputMask = "{LOC} n,nnn,nnn.nn";
            this.txtUkupno_V_2.Location = new System.Drawing.Point(599, 121);
            this.txtUkupno_V_2.Name = "txtUkupno_V_2";
            this.txtUkupno_V_2.PromptChar = ' ';
            this.txtUkupno_V_2.Size = new System.Drawing.Size(100, 20);
            this.txtUkupno_V_2.TabIndex = 126;
            this.txtUkupno_V_2.Text = " ";
            this.txtUkupno_V_2.UseAppStyling = false;
            // 
            // ultraLabel16
            // 
            appearance98.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel16.Appearance = appearance98;
            this.ultraLabel16.AutoSize = true;
            this.ultraLabel16.Location = new System.Drawing.Point(35, 100);
            this.ultraLabel16.Name = "ultraLabel16";
            this.ultraLabel16.Size = new System.Drawing.Size(23, 14);
            this.ultraLabel16.TabIndex = 125;
            this.ultraLabel16.Text = "1.2.";
            this.ultraLabel16.UseAppStyling = false;
            // 
            // ultraLabel17
            // 
            appearance99.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel17.Appearance = appearance99;
            this.ultraLabel17.Location = new System.Drawing.Point(67, 100);
            this.ultraLabel17.Name = "ultraLabel17";
            this.ultraLabel17.Size = new System.Drawing.Size(526, 18);
            this.ultraLabel17.TabIndex = 124;
            this.ultraLabel17.Text = "Ukupan zbroj stupaca 14.1. i 14.2. sa stranice B pod oznakom stjecatelja primitka" +
    "/osiguranika (mirovina)";
            this.ultraLabel17.UseAppStyling = false;
            // 
            // txtUkupno_V_1_2
            // 
            appearance100.TextHAlignAsString = "Right";
            this.txtUkupno_V_1_2.Appearance = appearance100;
            this.txtUkupno_V_1_2.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtUkupno_V_1_2.InputMask = "{LOC} n,nnn,nnn.nn";
            this.txtUkupno_V_1_2.Location = new System.Drawing.Point(599, 97);
            this.txtUkupno_V_1_2.Name = "txtUkupno_V_1_2";
            this.txtUkupno_V_1_2.PromptChar = ' ';
            this.txtUkupno_V_1_2.Size = new System.Drawing.Size(100, 20);
            this.txtUkupno_V_1_2.TabIndex = 123;
            this.txtUkupno_V_1_2.Text = " ";
            this.txtUkupno_V_1_2.UseAppStyling = false;
            this.txtUkupno_V_1_2.ValueChanged += new System.EventHandler(this.txtUkupno_V_1_1_ValueChanged);
            // 
            // ultraLabel14
            // 
            appearance101.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel14.Appearance = appearance101;
            this.ultraLabel14.AutoSize = true;
            this.ultraLabel14.Location = new System.Drawing.Point(35, 76);
            this.ultraLabel14.Name = "ultraLabel14";
            this.ultraLabel14.Size = new System.Drawing.Size(23, 14);
            this.ultraLabel14.TabIndex = 122;
            this.ultraLabel14.Text = "1.1.";
            this.ultraLabel14.UseAppStyling = false;
            // 
            // ultraLabel15
            // 
            appearance102.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel15.Appearance = appearance102;
            this.ultraLabel15.Location = new System.Drawing.Point(67, 76);
            this.ultraLabel15.Name = "ultraLabel15";
            this.ultraLabel15.Size = new System.Drawing.Size(526, 18);
            this.ultraLabel15.TabIndex = 121;
            this.ultraLabel15.Text = "Ukupan zbroj stupaca 14.1. i 14.2. sa stranice B pod oznakom stjecatelja primitka" +
    "/osiguranika (plaća)";
            this.ultraLabel15.UseAppStyling = false;
            // 
            // txtUkupno_V_1_1
            // 
            appearance103.TextHAlignAsString = "Right";
            this.txtUkupno_V_1_1.Appearance = appearance103;
            this.txtUkupno_V_1_1.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtUkupno_V_1_1.InputMask = "{LOC} n,nnn,nnn.nn";
            this.txtUkupno_V_1_1.Location = new System.Drawing.Point(599, 73);
            this.txtUkupno_V_1_1.Name = "txtUkupno_V_1_1";
            this.txtUkupno_V_1_1.PromptChar = ' ';
            this.txtUkupno_V_1_1.Size = new System.Drawing.Size(100, 20);
            this.txtUkupno_V_1_1.TabIndex = 120;
            this.txtUkupno_V_1_1.Text = " ";
            this.txtUkupno_V_1_1.UseAppStyling = false;
            this.txtUkupno_V_1_1.ValueChanged += new System.EventHandler(this.txtUkupno_V_1_1_ValueChanged);
            // 
            // ultraLabel4
            // 
            appearance51.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel4.Appearance = appearance51;
            this.ultraLabel4.AutoSize = true;
            this.ultraLabel4.Location = new System.Drawing.Point(35, 40);
            this.ultraLabel4.Name = "ultraLabel4";
            this.ultraLabel4.Size = new System.Drawing.Size(14, 14);
            this.ultraLabel4.TabIndex = 119;
            this.ultraLabel4.Text = "1.";
            this.ultraLabel4.UseAppStyling = false;
            // 
            // ultraLabel3
            // 
            appearance49.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel3.Appearance = appearance49;
            this.ultraLabel3.AutoSize = true;
            this.ultraLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ultraLabel3.Location = new System.Drawing.Point(14, 15);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(677, 14);
            this.ultraLabel3.TabIndex = 118;
            this.ultraLabel3.Text = "V. PODACI O UKUPNOM IZNOSU OBRAĈUNANOM PREDUJMU POREZU NA DOHODAK I PRIREZU POREZ" +
    "A NA DOHODAK";
            this.ultraLabel3.UseAppStyling = false;
            // 
            // UltraLabel13
            // 
            appearance52.BackColor = System.Drawing.Color.Transparent;
            this.UltraLabel13.Appearance = appearance52;
            this.UltraLabel13.Location = new System.Drawing.Point(67, 40);
            this.UltraLabel13.Name = "UltraLabel13";
            this.UltraLabel13.Size = new System.Drawing.Size(526, 30);
            this.UltraLabel13.TabIndex = 117;
            this.UltraLabel13.Text = "Ukupan iznos predujma poreza na dohodak i prireza porezu na dohodak po osnovi nes" +
    "amostalnog rada (1.1.+1.2.)";
            this.UltraLabel13.UseAppStyling = false;
            // 
            // txtUkupno_V_1
            // 
            appearance53.TextHAlignAsString = "Right";
            this.txtUkupno_V_1.Appearance = appearance53;
            this.txtUkupno_V_1.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtUkupno_V_1.InputMask = "{LOC} n,nnn,nnn.nn";
            this.txtUkupno_V_1.Location = new System.Drawing.Point(599, 37);
            this.txtUkupno_V_1.Name = "txtUkupno_V_1";
            this.txtUkupno_V_1.PromptChar = ' ';
            this.txtUkupno_V_1.ReadOnly = true;
            this.txtUkupno_V_1.Size = new System.Drawing.Size(100, 20);
            this.txtUkupno_V_1.TabIndex = 116;
            this.txtUkupno_V_1.Text = " ";
            this.txtUkupno_V_1.UseAppStyling = false;
            // 
            // UltraDockManager1
            // 
            dockAreaPane1.DockedBefore = new System.Guid("6b0b8893-11bd-4a7c-98c2-fcfef42d1774");
            dockableControlPane1.Control = this.UltraGroupBox1;
            dockableControlPane1.OriginalControlBounds = new System.Drawing.Rectangle(52, 50, 200, 110);
            dockableControlPane1.Size = new System.Drawing.Size(100, 100);
            dockableControlPane1.Text = "OSNOVNI PODACI";
            dockAreaPane1.Panes.AddRange(new Infragistics.Win.UltraWinDock.DockablePaneBase[] {
            dockableControlPane1});
            dockAreaPane1.Settings.AllowMinimize = Infragistics.Win.DefaultableBoolean.True;
            dockAreaPane1.Size = new System.Drawing.Size(800, 177);
            dockAreaPane2.DockedBefore = new System.Guid("923a1938-2fc8-4c0f-a4f7-e2e55ee1844d");
            dockableControlPane2.Control = this.UltraGroupBox2;
            dockableControlPane2.OriginalControlBounds = new System.Drawing.Rectangle(3, 133, 680, 189);
            dockableControlPane2.Size = new System.Drawing.Size(100, 100);
            dockableControlPane2.Text = "PODACI O PODNOSITELJU IZVJEŠĆA";
            dockAreaPane2.Panes.AddRange(new Infragistics.Win.UltraWinDock.DockablePaneBase[] {
            dockableControlPane2});
            dockAreaPane2.Size = new System.Drawing.Size(800, 160);
            dockableControlPane3.Control = this.UltraGroupBox3;
            dockableControlPane3.OriginalControlBounds = new System.Drawing.Rectangle(3, 328, 680, 189);
            dockableControlPane3.Size = new System.Drawing.Size(100, 100);
            dockableControlPane3.Text = "SUMARNI PODACI PO PODNOSITELJU IZVJEŠĆA";
            dockAreaPane3.Panes.AddRange(new Infragistics.Win.UltraWinDock.DockablePaneBase[] {
            dockableControlPane3});
            dockAreaPane3.Size = new System.Drawing.Size(800, 282);
            this.UltraDockManager1.DockAreas.AddRange(new Infragistics.Win.UltraWinDock.DockAreaPane[] {
            dockAreaPane1,
            dockAreaPane2,
            dockAreaPane3});
            this.UltraDockManager1.HostControl = this;
            this.UltraDockManager1.WindowStyle = Infragistics.Win.UltraWinDock.WindowStyle.Office2007;
            // 
            // _RSMObrazacUnpinnedTabAreaLeft
            // 
            this._RSMObrazacUnpinnedTabAreaLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this._RSMObrazacUnpinnedTabAreaLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._RSMObrazacUnpinnedTabAreaLeft.Location = new System.Drawing.Point(0, 0);
            this._RSMObrazacUnpinnedTabAreaLeft.Name = "_RSMObrazacUnpinnedTabAreaLeft";
            this._RSMObrazacUnpinnedTabAreaLeft.Owner = this.UltraDockManager1;
            this._RSMObrazacUnpinnedTabAreaLeft.Size = new System.Drawing.Size(0, 835);
            this._RSMObrazacUnpinnedTabAreaLeft.TabIndex = 2;
            // 
            // _RSMObrazacUnpinnedTabAreaRight
            // 
            this._RSMObrazacUnpinnedTabAreaRight.Dock = System.Windows.Forms.DockStyle.Right;
            this._RSMObrazacUnpinnedTabAreaRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._RSMObrazacUnpinnedTabAreaRight.Location = new System.Drawing.Point(800, 0);
            this._RSMObrazacUnpinnedTabAreaRight.Name = "_RSMObrazacUnpinnedTabAreaRight";
            this._RSMObrazacUnpinnedTabAreaRight.Owner = this.UltraDockManager1;
            this._RSMObrazacUnpinnedTabAreaRight.Size = new System.Drawing.Size(0, 835);
            this._RSMObrazacUnpinnedTabAreaRight.TabIndex = 3;
            // 
            // _RSMObrazacUnpinnedTabAreaTop
            // 
            this._RSMObrazacUnpinnedTabAreaTop.Dock = System.Windows.Forms.DockStyle.Top;
            this._RSMObrazacUnpinnedTabAreaTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._RSMObrazacUnpinnedTabAreaTop.Location = new System.Drawing.Point(0, 0);
            this._RSMObrazacUnpinnedTabAreaTop.Name = "_RSMObrazacUnpinnedTabAreaTop";
            this._RSMObrazacUnpinnedTabAreaTop.Owner = this.UltraDockManager1;
            this._RSMObrazacUnpinnedTabAreaTop.Size = new System.Drawing.Size(800, 0);
            this._RSMObrazacUnpinnedTabAreaTop.TabIndex = 4;
            // 
            // _RSMObrazacUnpinnedTabAreaBottom
            // 
            this._RSMObrazacUnpinnedTabAreaBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._RSMObrazacUnpinnedTabAreaBottom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._RSMObrazacUnpinnedTabAreaBottom.Location = new System.Drawing.Point(0, 835);
            this._RSMObrazacUnpinnedTabAreaBottom.Name = "_RSMObrazacUnpinnedTabAreaBottom";
            this._RSMObrazacUnpinnedTabAreaBottom.Owner = this.UltraDockManager1;
            this._RSMObrazacUnpinnedTabAreaBottom.Size = new System.Drawing.Size(800, 0);
            this._RSMObrazacUnpinnedTabAreaBottom.TabIndex = 5;
            // 
            // _RSMObrazacAutoHideControl
            // 
            this._RSMObrazacAutoHideControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._RSMObrazacAutoHideControl.Location = new System.Drawing.Point(0, 0);
            this._RSMObrazacAutoHideControl.Name = "_RSMObrazacAutoHideControl";
            this._RSMObrazacAutoHideControl.Owner = this.UltraDockManager1;
            this._RSMObrazacAutoHideControl.Size = new System.Drawing.Size(0, 0);
            this._RSMObrazacAutoHideControl.TabIndex = 6;
            // 
            // dgvJOPPDB
            // 
            this.dgvJOPPDB.AllowUserToResizeRows = false;
            this.dgvJOPPDB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvJOPPDB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvJOPPDB.Location = new System.Drawing.Point(0, 634);
            this.dgvJOPPDB.Name = "dgvJOPPDB";
            this.dgvJOPPDB.RowHeadersVisible = false;
            this.dgvJOPPDB.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvJOPPDB.Size = new System.Drawing.Size(800, 201);
            this.dgvJOPPDB.TabIndex = 15;
            // 
            // WindowDockingArea3
            // 
            this.WindowDockingArea3.Controls.Add(this.dockableWindow1);
            this.WindowDockingArea3.Dock = System.Windows.Forms.DockStyle.Top;
            this.WindowDockingArea3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.WindowDockingArea3.Location = new System.Drawing.Point(0, 0);
            this.WindowDockingArea3.Name = "WindowDockingArea3";
            this.WindowDockingArea3.Owner = this.UltraDockManager1;
            this.WindowDockingArea3.Size = new System.Drawing.Size(800, 182);
            this.WindowDockingArea3.TabIndex = 12;
            // 
            // dockableWindow1
            // 
            this.dockableWindow1.Controls.Add(this.UltraGroupBox1);
            this.dockableWindow1.Location = new System.Drawing.Point(0, 0);
            this.dockableWindow1.Name = "dockableWindow1";
            this.dockableWindow1.Owner = this.UltraDockManager1;
            this.dockableWindow1.Size = new System.Drawing.Size(800, 177);
            this.dockableWindow1.TabIndex = 16;
            // 
            // WindowDockingArea2
            // 
            this.WindowDockingArea2.Controls.Add(this.dockableWindow2);
            this.WindowDockingArea2.Dock = System.Windows.Forms.DockStyle.Top;
            this.WindowDockingArea2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.WindowDockingArea2.Location = new System.Drawing.Point(0, 182);
            this.WindowDockingArea2.Name = "WindowDockingArea2";
            this.WindowDockingArea2.Owner = this.UltraDockManager1;
            this.WindowDockingArea2.Size = new System.Drawing.Size(800, 165);
            this.WindowDockingArea2.TabIndex = 11;
            // 
            // dockableWindow2
            // 
            this.dockableWindow2.Controls.Add(this.UltraGroupBox2);
            this.dockableWindow2.Location = new System.Drawing.Point(0, 0);
            this.dockableWindow2.Name = "dockableWindow2";
            this.dockableWindow2.Owner = this.UltraDockManager1;
            this.dockableWindow2.Size = new System.Drawing.Size(800, 160);
            this.dockableWindow2.TabIndex = 17;
            // 
            // WindowDockingArea1
            // 
            this.WindowDockingArea1.Controls.Add(this.dockableWindow3);
            this.WindowDockingArea1.Dock = System.Windows.Forms.DockStyle.Top;
            this.WindowDockingArea1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.WindowDockingArea1.Location = new System.Drawing.Point(0, 347);
            this.WindowDockingArea1.Name = "WindowDockingArea1";
            this.WindowDockingArea1.Owner = this.UltraDockManager1;
            this.WindowDockingArea1.Size = new System.Drawing.Size(800, 287);
            this.WindowDockingArea1.TabIndex = 8;
            // 
            // dockableWindow3
            // 
            this.dockableWindow3.Controls.Add(this.UltraGroupBox3);
            this.dockableWindow3.Location = new System.Drawing.Point(0, 0);
            this.dockableWindow3.Name = "dockableWindow3";
            this.dockableWindow3.Owner = this.UltraDockManager1;
            this.dockableWindow3.Size = new System.Drawing.Size(800, 282);
            this.dockableWindow3.TabIndex = 18;
            // 
            // JOPPDObrazac
            // 
            this.AutoScroll = true;
            this.Controls.Add(this._RSMObrazacAutoHideControl);
            this.Controls.Add(this.dgvJOPPDB);
            this.Controls.Add(this.WindowDockingArea1);
            this.Controls.Add(this.WindowDockingArea2);
            this.Controls.Add(this.WindowDockingArea3);
            this.Controls.Add(this._RSMObrazacUnpinnedTabAreaTop);
            this.Controls.Add(this._RSMObrazacUnpinnedTabAreaBottom);
            this.Controls.Add(this._RSMObrazacUnpinnedTabAreaLeft);
            this.Controls.Add(this._RSMObrazacUnpinnedTabAreaRight);
            this.Name = "JOPPDObrazac";
            this.Size = new System.Drawing.Size(800, 835);
            ((System.ComponentModel.ISupportInitialize)(this.UltraGroupBox1)).EndInit();
            this.UltraGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.UltraGroupBox2)).EndInit();
            this.UltraGroupBox2.ResumeLayout(false);
            this.UltraGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UltraGroupBox3)).EndInit();
            this.UltraGroupBox3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UltraDockManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvJOPPDB)).EndInit();
            this.WindowDockingArea3.ResumeLayout(false);
            this.dockableWindow1.ResumeLayout(false);
            this.WindowDockingArea2.ResumeLayout(false);
            this.dockableWindow2.ResumeLayout(false);
            this.WindowDockingArea1.ResumeLayout(false);
            this.dockableWindow3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        void panel1_MouseEnter(object sender, EventArgs e)
        {
            this.panel1.Focus();
        }

        [LocalCommandHandler("Otvori")]
        public void OtvoriHandler(object sender, EventArgs e)
        {
            frmPregledObrazacaOPPD frmPregledObracunaJOPPD = new frmPregledObrazacaOPPD();
            if (frmPregledObracunaJOPPD.ShowDialog() == DialogResult.OK)
            {
                this.JOPPDID = frmPregledObracunaJOPPD.JOPPDID;
                int vrsta = frmPregledObracunaJOPPD.id_vrsta;
                lblOznakaPod.Text = vrsta.ToString();
                kontrola_broj = true;
                OtvoriJOPPD_StranicaA();
                OtvoriJOPPD_StranicaB();
            }
        }

        [LocalCommandHandler("PonovnoStvori")]
        public void PonovnoStvoriHandler(object sender, EventArgs e)
        {
            this.PonovnoStvoriObrazac();
        }

        [LocalCommandHandler("PotvrdiIzmjene")]
        public void PotvrdiIzmjeneHandler(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Jeste li sigurni da želite potvrditi JOPPDB obrazac i izgenerirati JOPPDA obrazac.", 
                                                        "JOPPD obrazac", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                //punjenje strane b
                if (ProvjeraSvihUnosaStranaB())
                {
                    if (NapuniJOPPDBStranu())
                    {
                        //punjenje strane A
                        NapuniJOPPDAStranu();
                    }

                    lblBrojOsoba.Text = client.ExecuteScalar(string.Format("SELECT COUNT(DISTINCT OIBStjecatelja) FROM dbo.JOPPDB WHERE dbo.JOPPDB.JOPPDAID = {0}", this.JOPPDID.Value)).ToString();
                    lblBrojRedakaNaStraniB.Text = client.ExecuteScalar(string.Format("SELECT COUNT(1) FROM dbo.JOPPDB WHERE dbo.JOPPDB.JOPPDAID = {0}", this.JOPPDID.Value)).ToString();
                }
            }
        }

        private bool ProvjeraSvihUnosaStranaB()
        {
            bool row_is_empty = false;

            for (int i = 0; i < dgvJOPPDB.Rows.Count - 1; i++) 
            {
                foreach (DataGridViewCell cell in dgvJOPPDB.Rows[i].Cells)
                {
                    if (cell.Value.ToString() == string.Empty)
                    {
                        row_is_empty = true;
                        break;
                    }  
                }
            }
            if (row_is_empty)
            {
                MessageBox.Show("Sva polja unutar JOPPDB obrazca moraju biti popunjena!\nPopunite sva polja i pokušajte ponovno.");
                return false;
            }
            return true;
        }

        private void NapuniJOPPDAStranu()
        {
            txtUkupno_V_1_1.Value = VratiVrijednost("Select Sum(PorezNaDohodak) + Sum(Prirez) From JOPPDB Where JOPPDAID = '" + JOPPDID + 
                                   "' And (OznakaStjecatelja Between '0001' And '0039' OR OznakaStjecatelja = '0201' OR OznakaStjecatelja = '5403')");

            txtUkupno_V_1_2.Value = VratiVrijednost("Select Sum(PorezNaDohodak) + Sum(Prirez) From JOPPDB Where JOPPDAID = '" + JOPPDID + 
                                    "' And (OznakaStjecatelja Between '0101' And '0119' OR OznakaStjecatelja = '0121')");

            txtUkupno_V_2.Value = VratiVrijednost("Select Sum(PorezNaDohodak) + Sum(Prirez) From JOPPDB Where JOPPDAID = '" + JOPPDID + 
                                    "' And OznakaStjecatelja Between '1001' And '1009'");

            txtUkupno_V_3.Value = VratiVrijednost("Select Sum(PorezNaDohodak), Sum(Prirez) From JOPPDB Where JOPPDAID = '" + JOPPDID + 
                                    "' And OznakaStjecatelja Between '2001' And '2009'");

            txtUkupno_V_4.Value = VratiVrijednost("Select Sum(PorezNaDohodak) + Sum(Prirez) From JOPPDB Where JOPPDAID = '" + JOPPDID + 
                                    "' And OznakaStjecatelja Between '3001' And '3009'");

            txtUkupno_V_5.Value = VratiVrijednost("Select Sum(PorezNaDohodak) + Sum(Prirez) From JOPPDB Where JOPPDAID = '" + JOPPDID + 
                                    "' And (OznakaStjecatelja Between '4001' And '4009' OR OznakaStjecatelja = '5501')");

            txtUkupno_VI_1_1.Value = VratiVrijednost("Select Sum(DoprinosMirovinsko) From JOPPDB Where JOPPDAID = '" + JOPPDID + 
                                    "' And (OznakaStjecatelja Between '0001' And '0003' OR OznakaStjecatelja Between '0005' And '0010' " +
                                    "OR OznakaStjecatelja Between '0021' And '0029' OR OznakaStjecatelja Between '5701' And '5799')");

            txtUkupno_VI_1_2.Value = VratiVrijednost("Select Sum(DoprinosMirovinsko) From JOPPDB Where JOPPDAID = '" + JOPPDID +
                                    "' And OznakaStjecatelja Between '0201' And '4002'");

            txtUkupno_VI_1_3.Value = VratiVrijednost("Select Sum(DoprinosMirovinsko) From JOPPDB Where JOPPDAID = '" + JOPPDID + 
                                    "' And OznakaStjecatelja Between '0031' And '0039'");

            txtUkupno_VI_1_4.Value = VratiVrijednost("Select Sum(DoprinosMirovinsko) From JOPPDB Where JOPPDAID = '" + JOPPDID + 
                                    "' And (OznakaStjecatelja Between '5401' And '5403' OR OznakaStjecatelja = '5608')");

            txtUkupno_VI_1_5.Value = VratiVrijednost("Select Sum(DoprinosMirovinsko) From JOPPDB Where JOPPDAID = '" + JOPPDID + 
                                    "' And OznakaStjecatelja IN ('5302', '5501', '5604', '5606', '5607')");

            txtUkupno_VI_1_6.Value = VratiVrijednost("Select Sum(DodatniDoprinosMirovinsko) From JOPPDB Where JOPPDAID = '" + JOPPDID + "'");

            txtUkupno_VI_2_1.Value = VratiVrijednost("Select Sum(DoprinosMirovinskoII) From JOPPDB Where JOPPDAID = '" + JOPPDID + 
                                    "' And (OznakaStjecatelja Between '0001' And '0003' OR OznakaStjecatelja Between '0005' And '0010' " + 
                                    "OR OznakaStjecatelja Between '0021' And '0029' OR OznakaStjecatelja Between '5701' And '5799')");

            txtUkupno_VI_2_2.Value = VratiVrijednost("Select Sum(DoprinosMirovinskoII) From JOPPDB Where JOPPDAID = '" + JOPPDID + 
                                    "' And OznakaStjecatelja Between '0201' And '4002'");

            txtUkupno_VI_2_3.Value = VratiVrijednost("Select Sum(DoprinosMirovinskoII) From JOPPDB Where JOPPDAID = '" + JOPPDID + 
                                    "' And OznakaStjecatelja Between '0031' And '0039'");

            txtUkupno_VI_2_4.Value = VratiVrijednost("Select Sum(DoprinosMirovinskoII) From JOPPDB Where JOPPDAID = '" + JOPPDID + 
                                    "' And (OznakaStjecatelja Between '5101' And '5103' OR OznakaStjecatelja Between '5201' And '5299' " + 
                                    "OR OznakaStjecatelja Between '5401' And '5403' OR OznakaStjecatelja IN ('5301','5608'))");

            txtUkupno_VI_2_5.Value = VratiVrijednost("Select Sum(DodatniDoprinosMirovinskoII) From JOPPDB Where JOPPDAID = '" + JOPPDID + "'");

            txtUkupno_VI_3_1.Value = VratiVrijednost("Select Sum(DoprinosZdravstveno) From JOPPDB Where JOPPDAID = '" + JOPPDID + 
                                    "' And (OznakaStjecatelja Between '0021' And '0029' OR OznakaStjecatelja Between '5701' And '5799' " + 
                                    "OR OznakaStjecatelja IN('0001','0005','0008','0009'))");

            txtUkupno_VI_3_2.Value = VratiVrijednost("Select Sum(DoprinosZastita) From JOPPDB Where JOPPDAID = '" + JOPPDID + 
                                    "' And (OznakaStjecatelja Between '0021' And '0029' OR OznakaStjecatelja Between '5701' And '5799' " + 
                                    "OR OznakaStjecatelja IN('0001','0005','0008','0009'))");

            txtUkupno_VI_3_3.Value = VratiVrijednost("Select Sum(DoprinosZdravstveno) From JOPPDB Where JOPPDAID = '" + JOPPDID + 
                                    "' And OznakaStjecatelja Between '0031' And '0039'");

            txtUkupno_VI_3_4.Value = VratiVrijednost("Select Sum(DoprinosZastita) From JOPPDB Where JOPPDAID = '" + JOPPDID + 
                                    "' And OznakaStjecatelja Between '0031' And '0039'");

            txtUkupno_VI_3_5.Value = VratiVrijednost("Select Sum(DoprinosZdravstveno) From JOPPDB Where JOPPDAID = '" + JOPPDID +
                                   "' And OznakaStjecatelja IN ('0201','4002','4001')"); //db - 17.01.2017 dodano '4001'

            txtUkupno_VI_3_6.Value = VratiVrijednost("Select Sum(PosebanDoprinosZdravstveno) From JOPPDB Where JOPPDAID = '" + JOPPDID + 
                                    "' And (OznakaStjecatelja Between '0001' And '0039' OR OznakaStjecatelja Between '5001' And '5009' OR OznakaStjecatelja = '5402')");

            txtUkupno_VI_3_7.Value = VratiVrijednost("Select Sum(DoprinosZdravstveno) From JOPPDB Where JOPPDAID = '" + JOPPDID + 
                                    "' And OznakaStjecatelja Between '0101' And '0119'");

            txtUkupno_VI_3_8.Value = VratiVrijednost("Select Sum(DoprinosZdravstveno) From JOPPDB Where JOPPDAID = '" + JOPPDID + 
                                    "' And OznakaStjecatelja IN('5401','5403','5601','5602','5603','5605','5608')");

            txtUkupno_VI_3_9.Value = VratiVrijednost("Select Sum(DoprinosZastita) From JOPPDB Where JOPPDAID = '" + JOPPDID + 
                                    "' And OznakaStjecatelja IN('5401','5403','5608')");

            txtUkupno_VI_3_10.Value = VratiVrijednost("Select Sum(DoprinosZastita) From JOPPDB Where JOPPDAID = '" + JOPPDID + 
                                    "' And OznakaStjecatelja IN('5302','5501','5604','5606','5607')");

            txtUkupno_VI_4_1.Value = VratiVrijednost("Select Sum(DoprinosZaposljavanje) From JOPPDB Where JOPPDAID = '" + JOPPDID + "'");

            txtUkupno_VI_4_2.Value = VratiVrijednost("Select Sum(PosebanDoprinosZaposljavanje) From JOPPDB Where JOPPDAID = '" + JOPPDID + "'");

            txtUkupno_VII.Value = VratiVrijednost("Select Sum(NeoporezivPrimitak) From JOPPDB Where JOPPDAID = '" + JOPPDID + "'");

            txtUkupnoVIII.Value = VratiVrijednost("Select Sum(DodatniDoprinosMirovinskoII) From JOPPDB Where JOPPDAID = '" + JOPPDID + "' And OznakaPrimitka = '5721'");

            //novi dio 2015
            txtUkupno_V_6.Value = 0;
            txtUkupno_VI_1_7.Value = 0;
            txtUkupno_VI_2_6.Value = 0;
            txtUkupno_VI_3_11.Value = 0;
            txtUkupno_VI_3_12.Value = 0;
            txtUkupno_VI_4_3.Value = 0;
            txtUkupno_VI_4_4.Value = 0;
            txtUkupnoIX.Value = 0;
            txtUkupnoX.Value = 0;

            if (VirmaniZaInvalide(JOPPDID) ||vrsta_izvjesca == "4")
            {
                txtBrojOsoba.Value = VratiVrijednost("Select Distinct BrojOsoba From Korisnik");
                txtIznosNaknade.Value = VratiVrijednost("Select Distinct StopaZainvalide From Korisnik");
            }
            else
            {
                txtBrojOsoba.Value = 0;
                txtIznosNaknade.Value = 0;
            }

        }

        private bool VirmaniZaInvalide(int? JOPPDID)
        {
            int exist = Convert.ToInt32(client.ExecuteScalar("Select Count(IDVIRMAN) From VIRMANI Inner Join JOPPDAObracun on VIRMANI.SIFRAOBRACUNAVIRMAN = JOPPDAObracun.Obracun_ID " +
                                                "Where JOPPDAObracun.JOPPDA_ID = '" + JOPPDID + "' and VIRMANI.PRI2 = 'Naknada za invalide'").ToString());

            if (exist > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private decimal VratiVrijednost(string upit)
        {
            try
            {
                DataTable tblUpit = client.GetDataTable(upit);
                if (tblUpit.Rows[0][0] != null)
                {
                    return Convert.ToDecimal(tblUpit.Rows[0][0]);
                }
                else
                    return 0;
            }
            catch
            {
                return 0;
            }
        }

        private bool NapuniJOPPDBStranu()
        {
            SqlCommand sqlUpit = new SqlCommand();

            sqlUpit.Connection = client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;
            sqlUpit.CommandText = "Delete From JOPPDB Where JOPPDAID = '" + dgvJOPPDB.Rows[0].Cells["JOPPDAID"].Value + "'";

            try
            {
                sqlUpit.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Dogodila se greška prilikom potvrde JOPPDB obrazca!\nKontaktirajte administratora.");
                return false;
            }

            string sati_rada = string.Empty;
            string neodradeni_sati_rada = string.Empty;
            string razdoblje_od = string.Empty;
            string razdoblje_do = string.Empty;
            string primitak = string.Empty;
            string osnovica = string.Empty;
            string doprinos_mirovinsko = string.Empty;
            string doprinos_mirovinskoII = string.Empty;
            string doprinos_zdravstveno = string.Empty;
            string doprinos_zastita = string.Empty;
            string doprinos_zaposljavanje = string.Empty;
            string dodatni_doprinos_mirovinsko = string.Empty;
            string dodatni_doprinos_mirovinskoII = string.Empty;
            string poseban_doprinos_zdravstveno = string.Empty;
            string poseban_doprinos_zaposljavanje = string.Empty;
            string izdatak = string.Empty;
            string izdatak_doprinos_mirovinsko = string.Empty;
            string dohodak = string.Empty;
            string osobni_odbitak = string.Empty;
            string porezna_osnovica = string.Empty;
            string porez_na_dohodak = string.Empty;
            string prirez = string.Empty;
            string obracunati_primitak = string.Empty;
            string isplata = string.Empty;
            string neoporeziv_primitak = string.Empty;
            int brojac = 0;

            foreach (DataGridViewRow red in dgvJOPPDB.Rows)
            {
                brojac++;

                if (red.Cells[0].Value == null)
                    continue;

                sati_rada = red.Cells["SatiRada"].Value.ToString().Replace(',', '.');
                neodradeni_sati_rada = red.Cells["NeodradeniSatiRada"].Value.ToString().Replace(',', '.');
                razdoblje_do = Convert.ToDateTime(red.Cells["RazdobljeDo"].Value.ToString()).ToString("yyyy.MM.dd");
                razdoblje_od = Convert.ToDateTime(red.Cells["RazdobljeoD"].Value.ToString()).ToString("yyyy.MM.dd");
                primitak = red.Cells["Primitak"].Value.ToString().Replace(',', '.');
                osnovica = red.Cells["Osnovica"].Value.ToString().Replace(',', '.');
                doprinos_mirovinsko = red.Cells["DoprinosMirovinsko"].Value.ToString().Replace(',', '.');
                doprinos_mirovinskoII = red.Cells["DoprinosMirovinskoII"].Value.ToString().Replace(',', '.');
                doprinos_zdravstveno = red.Cells["DoprinosZdravstveno"].Value.ToString().Replace(',', '.');
                doprinos_zastita = red.Cells["DoprinosZastita"].Value.ToString().Replace(',', '.');
                doprinos_zaposljavanje = red.Cells["DoprinosZaposljavanje"].Value.ToString().Replace(',', '.');
                dodatni_doprinos_mirovinsko = red.Cells["DodatniDoprinosMirovinsko"].Value.ToString().Replace(',', '.');
                dodatni_doprinos_mirovinskoII = red.Cells["DodatniDoprinosMirovinskoII"].Value.ToString().Replace(',', '.');
                poseban_doprinos_zdravstveno = red.Cells["PosebanDoprinosZdravstveno"].Value.ToString().Replace(',', '.');
                poseban_doprinos_zaposljavanje = red.Cells["PosebanDoprinosZaposljavanje"].Value.ToString().Replace(',', '.');
                izdatak = red.Cells["Izdatak"].Value.ToString().Replace(',', '.');
                izdatak_doprinos_mirovinsko = red.Cells["IzdatakDoprinosMirovinsko"].Value.ToString().Replace(',', '.');
                dohodak = red.Cells["Dohodak"].Value.ToString().Replace(',', '.');
                osobni_odbitak = red.Cells["OsobniOdbitak"].Value.ToString().Replace(',', '.');
                porezna_osnovica = red.Cells["PoreznaOsnovica"].Value.ToString().Replace(',', '.');
                porez_na_dohodak = red.Cells["PorezNaDohodak"].Value.ToString().Replace(',', '.');
                prirez = red.Cells["Prirez"].Value.ToString().Replace(',', '.');
                obracunati_primitak = red.Cells["ObracunatiPrimitak"].Value.ToString().Replace(',', '.');
                isplata = red.Cells["Isplata"].Value.ToString().Replace(',', '.');
                neoporeziv_primitak = red.Cells["NeoporezivPrimitak"].Value.ToString().Replace(',', '.');

                sqlUpit.Connection = client.sqlConnection;
                sqlUpit.CommandType = CommandType.Text;
                sqlUpit.CommandText = "Insert Into JOPPDB (JOPPDAID, RedniBroj, SifraOpcinePrebivalista, SifraOpcineRada, OIBStjecatelja, ImePrezimeStjecatelja, OznakaStjecatelja, " +
                                      "OznakaPrimitka, ObvezaDodatnogDoprinosa, ObvezaPosebnogDoprinosa, OznakaMjesecaOsiguranje, OznakaRadnogVremena, SatiRada, RazdobljeOd, " +
                                      "RazdobljeDo, Primitak, Osnovica, DoprinosMirovinsko, DoprinosMirovinskoII, DoprinosZdravstveno, DoprinosZastita, DoprinosZaposljavanje, " +
                                      "DodatniDoprinosMirovinsko, DodatniDoprinosMirovinskoII, PosebanDoprinosZdravstveno, PosebanDoprinosZaposljavanje, Izdatak, " +
                                      "IzdatakDoprinosMirovinsko, Dohodak, OsobniOdbitak, PoreznaOsnovica, PorezNaDohodak, Prirez, OznakaNeoporezivogPrimitka, NeoporezivPrimitak, " +
                                      "OznakaNacinaIsplate, Isplata, ObracunatiPrimitak, NeodradeniSatiRada) Values (" + red.Cells["JOPPDAID"].Value + ", " + red.Cells["RedniBroj"].Value + ",  " +
                                      "'" + red.Cells["SifraOpcinePrebivalista"].Value + "', '" + red.Cells["SifraOpcineRada"].Value + "', '" + red.Cells["OIBStjecatelja"].Value + "', " +
                                      "'" + red.Cells["ImePrezimeStjecatelja"].Value + "', '" + red.Cells["OznakaStjecatelja"].Value + "', '" + red.Cells["OznakaPrimitka"].Value + "', " +
                                      "" + red.Cells["ObvezaDodatnogDoprinosa"].Value + ", " + red.Cells["ObvezaPosebnogDoprinosa"].Value + ", " + red.Cells["OznakaMjesecaOsiguranje"].Value + ", " +
                                      "" + red.Cells["OznakaRadnogVremena"].Value + ", " + sati_rada + ", '" + razdoblje_od + "', " +
                                      "'" + razdoblje_do + "', '" + primitak + "', '" + osnovica + "', '" + doprinos_mirovinsko + "', " +
                                      "'" + doprinos_mirovinskoII + "', '" + doprinos_zdravstveno + "', '" + doprinos_zastita + "', " +
                                      "'" + doprinos_zaposljavanje + "', '" + dodatni_doprinos_mirovinsko + "', '" + dodatni_doprinos_mirovinskoII + "', " +
                                      "'" + poseban_doprinos_zdravstveno + "', '" + poseban_doprinos_zaposljavanje + "', '" + izdatak + "', " +
                                      "'" + izdatak_doprinos_mirovinsko + "', '" + dohodak + "', '" + osobni_odbitak + "', " +
                                      "'" + porezna_osnovica + "', '" + porez_na_dohodak + "', '" + prirez + "', '" + red.Cells["OznakaNeoporezivogPrimitka"].Value + "', " +
                                      "'" + neoporeziv_primitak + "', '" + red.Cells["OznakaNacinaIsplate"].Value + "', '" + isplata + "', '" + obracunati_primitak + "', " + neodradeni_sati_rada + ")";

                try
                {
                    sqlUpit.ExecuteNonQuery();
                }
                catch (Exception greska)
                {
                    MessageBox.Show("Dogodila se greška prilikom potvrde JOPPDB obrazca!\nBroj reda: '" + brojac + "'\nKontaktirajte administratora.\n"+ greska.Message);
                    return false;
                }
            }
            return true;
        }

        private void UpisOznakeIzvjesca(string oznaka, bool? placa, bool? honorar, bool? putni_nalog, bool? praksa)
        {
            DataTable tblObracuni = new DataTable();

            if (placa == true)
            {
                tblObracuni = client.GetDataTable("Select Obracun_ID From JOPPDAObracun Where JOPPDA_ID = '" + JOPPDID + "' And Vrsta = 0");
                foreach (DataRow red in tblObracuni.Rows)
                {
                    client.ExecuteNonQuery("Update OBRACUN Set IDENTIFIKATOROBRASCA = '" + oznaka + "' Where IDOBRACUN = '" + red["Obracun_ID"].ToString() + "'");
                }
            }
            if (honorar == true)
            {
                tblObracuni = client.GetDataTable("Select Obracun_ID From JOPPDAObracun Where JOPPDA_ID = '" + JOPPDID + "' And Vrsta = 1");
                foreach (DataRow red in tblObracuni.Rows)
                {
                    client.ExecuteNonQuery("Update DDOBRACUN Set DDRSM = '" + oznaka + "' Where DDOBRACUNIDOBRACUN = '" + red["Obracun_ID"].ToString() + "'");
                }
            }
            if (putni_nalog == true)
            {
                tblObracuni = client.GetDataTable("Select Obracun_ID From JOPPDAObracun Where JOPPDA_ID = '" + JOPPDID + "' And Vrsta = 2");
                foreach (DataRow red in tblObracuni.Rows)
                {
                    client.ExecuteNonQuery("Update RegistarPutnihNaloga Set JOPPD_OznakaIzvjesca = '" + oznaka + "' Where ID = '" + red["Obracun_ID"].ToString() + "'");
                }
            }
            //if (praksa == true)
            //{
            //    tblObracuni = client.GetDataTable("Select Obracun_ID From JOPPDAObracun Where JOPPDA_ID = '" + JOPPDID + "' And Vrsta = 3");
            //}
        }

        public void PonovnoStvoriObrazac()
        {
            JOPPD.frmJOPPDIdentifikator frmJOPPDIdentifikator = new JOPPD.frmJOPPDIdentifikator();
            if(frmJOPPDIdentifikator.ShowDialog() == DialogResult.OK)
            {
                JOPPDID = frmJOPPDIdentifikator.JOPPDID;
                IsObracunPlace = frmJOPPDIdentifikator.ISObracunPlace;
                IsObracunHonorara = frmJOPPDIdentifikator.ISObracunHonorara;
                IsObracunPutniNalog = frmJOPPDIdentifikator.ISObracunPutniNalog;
                IsObracunPraksa = frmJOPPDIdentifikator.ISObracunPraksa;
                int vrsta = frmJOPPDIdentifikator.id_vrsta;
                lblOznakaPod.Text = vrsta.ToString();
                IsObracunRazno = frmJOPPDIdentifikator.ISObracunRazno;

                if (IsObracunPraksa == true)
                {
                    vrsta = 6;
                }

                if (frmJOPPDIdentifikator.vrstaIzvjescaID == 1 || frmJOPPDIdentifikator.vrstaIzvjescaID == 4)
                {

                    DataTable tblJOPPDB = client.GetDataTable("SET FMTONLY ON;SELECT [JOPPDAID],[RedniBroj],[SifraOpcinePrebivalista],[SifraOpcineRada],[OIBStjecatelja],[ImePrezimeStjecatelja]," +
                                    "[OznakaStjecatelja],[OznakaPrimitka],[ObvezaDodatnogDoprinosa],[ObvezaPosebnogDoprinosa],[OznakaMjesecaOsiguranje],[OznakaRadnogVremena],[SatiRada],[NeodradeniSatiRada], " +
                                    "[RazdobljeOd],[RazdobljeDo],[Primitak],[Osnovica],[DoprinosMirovinsko],[DoprinosMirovinskoII],[DoprinosZdravstveno],[DoprinosZastita],[DoprinosZaposljavanje], " +
                                    "[DodatniDoprinosMirovinsko],[DodatniDoprinosMirovinskoII],[PosebanDoprinosZdravstveno],[PosebanDoprinosZaposljavanje],[Izdatak],[IzdatakDoprinosMirovinsko], " +
                                    "[Dohodak],[OsobniOdbitak],[PoreznaOsnovica],[PorezNaDohodak],[Prirez],[OznakaNeoporezivogPrimitka],[NeoporezivPrimitak],[OznakaNacinaIsplate],[Isplata],[ObracunatiPrimitak] " +
                                    "FROM JOPPDB; SET FMTONLY OFF;");

                    this.Cursor = Cursors.WaitCursor;
                    using (JOPPD.frmWaitProgress element = new JOPPD.frmWaitProgress())
                    {
                        int redniBroj = 0;
                        element.Show();
                        if (IsObracunPlace == true)
                        {
                            element.Text = "Generiranje u tijeku...{Plaće}.";
                            redniBroj = GenerirajJOPPDPlaceVolonteriStranicaB(redniBroj, ref tblJOPPDB, false, string.Empty, null, string.Empty);
                        }
                        if (IsObracunHonorara == true)
                        {
                            element.Text = "Generiranje u tijeku...{Honorari}.";
                            redniBroj = GenerirajJOPPDHonorariStranicaB(element, redniBroj, ref tblJOPPDB);
                        }
                        if (IsObracunPutniNalog == true)
                        {
                            element.Text = "Generiranje u tijeku...{Putni nalog}.";
                            redniBroj = GenerirajJOPPDPutniNalogStranicaB(element, redniBroj, ref tblJOPPDB);
                        }
                        if (IsObracunPraksa == true)
                        {
                            element.Text = "Generiranje u tijeku...{Praksa}.";
                            redniBroj = GenerirajJOPPDPraksaStranicaB(element, redniBroj, ref tblJOPPDB);

                            
                            lblOznakaPod.Text = vrsta.ToString();
                        }
                        if (IsObracunRazno == true)
                        {
                            element.Text = "Generiranje u tijeku...{Obračuni razno}.";
                            redniBroj = GenerirajJOPPDObracunRaznoStranicaB(element, redniBroj, ref tblJOPPDB);
                        }
                        if (IsVirmaniInvalid == true)
                        {
                            element.Text = "Generiranje u tijeku...{Virman invalidi}.";
                            redniBroj = GenerirajJOPPDVirmanInvalidi(element, redniBroj, ref tblJOPPDB);
                        }

                        kontrola_broj = false;
                        OtvoriJOPPD_StranicaA();

                        UpisOznakeIzvjesca(lblOznakaIzvjesca.Text.Trim(), IsObracunPlace, IsObracunHonorara, IsObracunPutniNalog, IsObracunPraksa);
                    }

                    dgvJOPPDB.DataSource = tblJOPPDB;

                }
                else if (frmJOPPDIdentifikator.vrstaIzvjescaID == 2)
                {
                    //DataTable tblJOPPDB = client.GetDataTable("SELECT '" + JOPPDID + "' As JOPPDAID, [RedniBroj], [SifraOpcinePrebivalista], [SifraOpcineRada], [OIBStjecatelja], [ImePrezimeStjecatelja], " +
                    //                        "[OznakaStjecatelja], [OznakaPrimitka], [ObvezaDodatnogDoprinosa], [ObvezaPosebnogDoprinosa], [OznakaMjesecaOsiguranje], [OznakaRadnogVremena], " +
                    //                        "[SatiRada], [NeodradeniSatiRada], [RazdobljeOd], [RazdobljeDo], '0.00' As Primitak, '0.00' As Osnovica, '0.00' As DoprinosMirovinsko, '0.00' As DoprinosMirovinskoII, '0.00' As DoprinosZdravstveno, " +
                    //                        "'0.00' As DoprinosZastita, '0.00' As DoprinosZaposljavanje, '0.00' As DodatniDoprinosMirovinsko, '0.00' As DodatniDoprinosMirovinskoII, '0.00' As PosebanDoprinosZdravstveno, " + 
                    //                        "'0.00' As PosebanDoprinosZaposljavanje, '0.00' As Izdatak, '0.00' As IzdatakDoprinosMirovinsko, '0.00' As Dohodak, '0.00' As OsobniOdbitak, '0.00' As PoreznaOsnovica, '0.00' As PorezNaDohodak, " +
                    //                        "'0.00' As Prirez, '0' As OznakaNeoporezivogPrimitka, '0.00' As NeoporezivPrimitak, '0' As OznakaNacinaIsplate, '0.00' As Isplata, '0.00' As ObracunatiPrimitak FROM [JOPPDB] " +
                    //                        "Where JOPPDAID = '" + frmJOPPDIdentifikator.id_joppda + "'");


                    DataTable tblJOPPDB = client.GetDataTable("SELECT '" + JOPPDID + "' As JOPPDAID,[RedniBroj],[SifraOpcinePrebivalista],[SifraOpcineRada],[OIBStjecatelja],[ImePrezimeStjecatelja]," +
                                    "[OznakaStjecatelja],[OznakaPrimitka],[ObvezaDodatnogDoprinosa],[ObvezaPosebnogDoprinosa],[OznakaMjesecaOsiguranje],[OznakaRadnogVremena],[SatiRada], [NeodradeniSatiRada], " +
                                    "[RazdobljeOd],[RazdobljeDo],[Primitak],[Osnovica],[DoprinosMirovinsko],[DoprinosMirovinskoII],[DoprinosZdravstveno],[DoprinosZastita],[DoprinosZaposljavanje], " +
                                    "[DodatniDoprinosMirovinsko],[DodatniDoprinosMirovinskoII],[PosebanDoprinosZdravstveno],[PosebanDoprinosZaposljavanje],[Izdatak],[IzdatakDoprinosMirovinsko], " +
                                    "[Dohodak],[OsobniOdbitak],[PoreznaOsnovica],[PorezNaDohodak],[Prirez],[OznakaNeoporezivogPrimitka],[NeoporezivPrimitak],[OznakaNacinaIsplate],[Isplata],[ObracunatiPrimitak] " +
                                    "FROM JOPPDB Where JOPPDAID = '" + frmJOPPDIdentifikator.id_joppda + "'");

                    OtvoriJOPPD_StranicaA();

                    dgvJOPPDB.DataSource = tblJOPPDB;

                }
                else if (frmJOPPDIdentifikator.vrstaIzvjescaID == 3)
                {
                    DataTable tblJOPPDB = client.GetDataTable("SELECT '" + JOPPDID + "' As JOPPDAID,[RedniBroj],[SifraOpcinePrebivalista],[SifraOpcineRada],[OIBStjecatelja],[ImePrezimeStjecatelja]," +
                                    "[OznakaStjecatelja],[OznakaPrimitka],[ObvezaDodatnogDoprinosa],[ObvezaPosebnogDoprinosa],[OznakaMjesecaOsiguranje],[OznakaRadnogVremena],[SatiRada], [NeodradeniSatiRada], " +
                                    "[RazdobljeOd],[RazdobljeDo],[Primitak],[Osnovica],[DoprinosMirovinsko],[DoprinosMirovinskoII],[DoprinosZdravstveno],[DoprinosZastita],[DoprinosZaposljavanje], " +
                                    "[DodatniDoprinosMirovinsko],[DodatniDoprinosMirovinskoII],[PosebanDoprinosZdravstveno],[PosebanDoprinosZaposljavanje],[Izdatak],[IzdatakDoprinosMirovinsko], " +
                                    "[Dohodak],[OsobniOdbitak],[PoreznaOsnovica],[PorezNaDohodak],[Prirez],[OznakaNeoporezivogPrimitka],[NeoporezivPrimitak],[OznakaNacinaIsplate],[Isplata],[ObracunatiPrimitak] " +
                                    "FROM JOPPDB Where JOPPDAID = '" + frmJOPPDIdentifikator.id_joppda + "' And OIBStjecatelja IN(" + frmJOPPDIdentifikator.dopuna_oib + ")");

                    OtvoriJOPPD_StranicaA();

                    dgvJOPPDB.DataSource = tblJOPPDB;
                }

                if (dgvJOPPDB.Rows.Count > 0)
                {
                    dgvJOPPDB.Columns["Primitak"].DefaultCellStyle.Format = "N2";
                    dgvJOPPDB.Columns["Osnovica"].DefaultCellStyle.Format = "N2";
                    dgvJOPPDB.Columns["DoprinosMirovinsko"].DefaultCellStyle.Format = "N2";
                    dgvJOPPDB.Columns["DoprinosMirovinskoII"].DefaultCellStyle.Format = "N2";
                    dgvJOPPDB.Columns["DoprinosZdravstveno"].DefaultCellStyle.Format = "N2";
                    dgvJOPPDB.Columns["DoprinosZastita"].DefaultCellStyle.Format = "N2";
                    dgvJOPPDB.Columns["DoprinosZaposljavanje"].DefaultCellStyle.Format = "N2";
                    dgvJOPPDB.Columns["DodatniDoprinosMirovinsko"].DefaultCellStyle.Format = "N2";
                    dgvJOPPDB.Columns["DodatniDoprinosMirovinskoII"].DefaultCellStyle.Format = "N2";
                    dgvJOPPDB.Columns["PosebanDoprinosZdravstveno"].DefaultCellStyle.Format = "N2";
                    dgvJOPPDB.Columns["PosebanDoprinosZaposljavanje"].DefaultCellStyle.Format = "N2";
                    dgvJOPPDB.Columns["Izdatak"].DefaultCellStyle.Format = "N2";
                    dgvJOPPDB.Columns["IzdatakDoprinosMirovinsko"].DefaultCellStyle.Format = "N2";
                    dgvJOPPDB.Columns["Dohodak"].DefaultCellStyle.Format = "N2";
                    dgvJOPPDB.Columns["OsobniOdbitak"].DefaultCellStyle.Format = "N2";
                    dgvJOPPDB.Columns["PoreznaOsnovica"].DefaultCellStyle.Format = "N2";
                    dgvJOPPDB.Columns["PorezNaDohodak"].DefaultCellStyle.Format = "N2";
                    dgvJOPPDB.Columns["Prirez"].DefaultCellStyle.Format = "N2";
                    dgvJOPPDB.Columns["NeoporezivPrimitak"].DefaultCellStyle.Format = "N2";
                    dgvJOPPDB.Columns["Isplata"].DefaultCellStyle.Format = "N2";
                    dgvJOPPDB.Columns["ObracunatiPrimitak"].DefaultCellStyle.Format = "N2";
                }

                this.Cursor = Cursors.Default;
            }
        }

        private void OtvoriJOPPD_StranicaB()
        {
            DataTable tblJOPPDB = client.GetDataTable("SELECT JOPPDAID, RedniBroj, SifraOpcinePrebivalista, SifraOpcineRada, OIBStjecatelja, ImePrezimeStjecatelja, " +
                                  "OznakaStjecatelja, OznakaPrimitka, ObvezaDodatnogDoprinosa, ObvezaPosebnogDoprinosa, OznakaMjesecaOsiguranje, OznakaRadnogVremena, SatiRada, NeodradeniSatiRada, " + 
                                  "RazdobljeOd, RazdobljeDo, Primitak, Osnovica, DoprinosMirovinsko, DoprinosMirovinskoII, DoprinosZdravstveno, DoprinosZastita, DoprinosZaposljavanje, " + 
                                  "DodatniDoprinosMirovinsko, DodatniDoprinosMirovinskoII, PosebanDoprinosZdravstveno, PosebanDoprinosZaposljavanje, Izdatak, IzdatakDoprinosMirovinsko, " + 
                                  "Dohodak, OsobniOdbitak, PoreznaOsnovica, PorezNaDohodak, Prirez, OznakaNeoporezivogPrimitka, NeoporezivPrimitak, OznakaNacinaIsplate, Isplata, ObracunatiPrimitak " +
                                  "FROM JOPPDB WHERE JOPPDAID = '" + JOPPDID.GetValueOrDefault(0) + "'");

            dgvJOPPDB.DataSource = tblJOPPDB;

            if (dgvJOPPDB.Rows.Count > 0)
            {
                dgvJOPPDB.Columns["Primitak"].DefaultCellStyle.Format = "N2";
                dgvJOPPDB.Columns["Osnovica"].DefaultCellStyle.Format = "N2";
                dgvJOPPDB.Columns["DoprinosMirovinsko"].DefaultCellStyle.Format = "N2";
                dgvJOPPDB.Columns["DoprinosMirovinskoII"].DefaultCellStyle.Format = "N2";
                dgvJOPPDB.Columns["DoprinosZdravstveno"].DefaultCellStyle.Format = "N2";
                dgvJOPPDB.Columns["DoprinosZastita"].DefaultCellStyle.Format = "N2";
                dgvJOPPDB.Columns["DoprinosZaposljavanje"].DefaultCellStyle.Format = "N2";
                dgvJOPPDB.Columns["DodatniDoprinosMirovinsko"].DefaultCellStyle.Format = "N2";
                dgvJOPPDB.Columns["DodatniDoprinosMirovinskoII"].DefaultCellStyle.Format = "N2";
                dgvJOPPDB.Columns["PosebanDoprinosZdravstveno"].DefaultCellStyle.Format = "N2";
                dgvJOPPDB.Columns["PosebanDoprinosZaposljavanje"].DefaultCellStyle.Format = "N2";
                dgvJOPPDB.Columns["Izdatak"].DefaultCellStyle.Format = "N2";
                dgvJOPPDB.Columns["IzdatakDoprinosMirovinsko"].DefaultCellStyle.Format = "N2";
                dgvJOPPDB.Columns["Dohodak"].DefaultCellStyle.Format = "N2";
                dgvJOPPDB.Columns["OsobniOdbitak"].DefaultCellStyle.Format = "N2";
                dgvJOPPDB.Columns["PoreznaOsnovica"].DefaultCellStyle.Format = "N2";
                dgvJOPPDB.Columns["PorezNaDohodak"].DefaultCellStyle.Format = "N2";
                dgvJOPPDB.Columns["Prirez"].DefaultCellStyle.Format = "N2";
                dgvJOPPDB.Columns["NeoporezivPrimitak"].DefaultCellStyle.Format = "N2";
                dgvJOPPDB.Columns["Isplata"].DefaultCellStyle.Format = "N2";
                dgvJOPPDB.Columns["ObracunatiPrimitak"].DefaultCellStyle.Format = "N2";
            }
        }


        /// <summary>
        /// generiranje svih podataka za stranicu b honorari
        /// </summary>
        /// <param name="element"></param>
        //private int GenerirajJOPPDHonorariStranicaB(JOPPD.frmWaitProgress element, int redniBroj, ref DataTable tblJOPPDB)
        //{
        //    string sifraOpcinePrebivalista = string.Empty;
        //    string sifraOpcineRada = string.Empty;
        //    string oibStjecatelja = string.Empty;
        //    string imePrezimeStjecatelja = string.Empty;
        //    string oznakaStjecatelja = string.Empty;
        //    string oznakaPrimitka = string.Empty;
        //    decimal obvezaDodatnogDoprinosa = 0;
        //    decimal obvezaPosebnogDoprinosa = 0;
        //    decimal oznakaMjesecaOsiguranje = 0;
        //    decimal oznakaRadnogVremena = 0;
        //    decimal satiRada = 0;
        //    decimal neodradeniSatiRada = 0;
        //    DateTime razdobljeOd = DateTime.MinValue;
        //    DateTime razdobljeDo = DateTime.MinValue;
        //    decimal primitak = 0;
        //    decimal osnovica = 0;
        //    decimal doprinosMirovinsko = 0;
        //    decimal doprinosMirovinskoII = 0;
        //    decimal doprinosZdravstveno = 0;
        //    decimal doprinosZastita = 0;
        //    decimal doprinosZaposljavanje = 0;
        //    decimal dodatniDoprinosMirovinsko = 0;
        //    decimal dodatniDoprinosMirovinskoII = 0;
        //    decimal posebanDoprinosZdravstveno = 0;
        //    decimal posebanDoprinosZaposljavanje = 0;
        //    decimal izdatak = 0;
        //    decimal izdatakDoprinosMirovinsko = 0;
        //    decimal dohodak = 0;
        //    decimal osobniOdbitak = 0;
        //    decimal poreznaOsnovica = 0;
        //    decimal porezNaDohodak = 0;
        //    decimal prirez = 0;
        //    string oznakaNeoporezivogPrimitka = string.Empty;
        //    decimal neoporezivPrimitak = 0;
        //    decimal oznakaNacinaIsplate = 0;
        //    decimal isplata = 0;
        //    decimal obracun_primitak = 0;
        //    int brojac = 1;
        //    string id_radnik = "";
        //    int? vrste_posla = 0;
        //    string id_obracun = string.Empty;

        //    // Get IDOBRACUN
        //    string odabrani_obracuni = string.Empty;
        //    DataTable tblObracuni = client.GetDataTable("Select Obracun_ID From JOPPDAObracun Where JOPPDA_ID = '" + JOPPDID.Value + "' And Vrsta = 1");
        //    int broj_obracuna = tblObracuni.Rows.Count;
        //    for (int i = 0; i < tblObracuni.Rows.Count; i++)
        //    {
        //        broj_obracuna--;
        //        if (broj_obracuna == 0)
        //        {
        //            odabrani_obracuni += "'" + tblObracuni.Rows[i][0].ToString().Trim() + "'";
        //        }
        //        else
        //        {
        //            odabrani_obracuni += "'" + tblObracuni.Rows[i][0].ToString().Trim() + "',";
        //        }
        //    }

        //    DataTable tblRadnici = client.GetDataTable("SELECT DDOBRACUNRadnici.DDOBRACUNIDOBRACUN, DDOBRACUNRadnici.DDIDRADNIK, DDOBRACUNRadnici.IDKATEGORIJA, DDOBRACUNRadnici.DDOBRACUNATIPRIREZ, " +
        //                           "DDOBRACUNRadnici.DDOBRACUNATIPDV, DDOBRACUNRadnici.OPCINASTANOVANJAIDOPCINE, DDOBRACUNRadnici.DDSIFRAOPCINESTANOVANJA, DDOBRACUNRadnici.IDKOLONAIDD, " + 
        //                           "DDRADNIK.DDOIB, (DDRADNIK.DDIME +  ' ' + DDRADNIK.DDPREZIME) As 'Ime i prezime', DDOBRACUN.DDDATUMOBRACUNA FROM DDOBRACUNRadnici " + 
        //                           "Inner Join DDRADNIK On DDOBRACUNRadnici.DDIDRADNIK = DDRADNIK.DDIDRADNIK " + 
        //                           "Inner Join DDOBRACUN On DDOBRACUNRadnici.DDOBRACUNIDOBRACUN = DDOBRACUN.DDOBRACUNIDOBRACUN " +
        //                           "Where DDOBRACUN.DDOBRACUNIDOBRACUN IN (" + odabrani_obracuni + ")");

        //    foreach (DataRow radnik in tblRadnici.Rows)
        //    {
        //        element.Text = "Generiranje u tijeku...{Honorari}. Molimo pričekajte...{" + brojac + "}";

        //        id_radnik = radnik["DDIDRADNIK"].ToString();

        //        redniBroj++;
        //        sifraOpcinePrebivalista = "0" + radnik["OPCINASTANOVANJAIDOPCINE"].ToString();
        //        sifraOpcineRada = "00000";
        //        oibStjecatelja = radnik["DDOIB"].ToString();
        //        imePrezimeStjecatelja = radnik["Ime i prezime"].ToString();
        //        obvezaDodatnogDoprinosa = 0;
        //        obvezaPosebnogDoprinosa = 0;
        //        oznakaMjesecaOsiguranje = 0;
        //        oznakaRadnogVremena = 0;
        //        satiRada = 0;
        //        osobniOdbitak = 0;
        //        doprinosZastita = 0;
        //        doprinosZaposljavanje = 0;
        //        dodatniDoprinosMirovinsko = 0;
        //        dodatniDoprinosMirovinskoII = 0;
        //        posebanDoprinosZdravstveno = 0;
        //        obracun_primitak = 0;
        //        posebanDoprinosZaposljavanje = 0;
        //        oznakaNeoporezivogPrimitka = "0";
        //        neoporezivPrimitak = 0;
        //        oznakaNacinaIsplate = 2;
        //        id_obracun = radnik["DDOBRACUNIDOBRACUN"].ToString();

        //        int godina = Convert.ToDateTime(radnik["DDDATUMOBRACUNA"]).Date.Year;

        //        razdobljeDo = new DateTime(godina, 12, 31);
        //        razdobljeOd = new DateTime(godina, 1, 1);

        //        primitak = Convert.ToDecimal(client.GetDataTable("Select DDIZNOS From DDOBRACUNRadniciVrstePosla Where DDOBRACUNIDOBRACUN  = '" + id_obracun + "' " + 
        //                    "And DDIDRADNIK = '" + id_radnik + "'").Rows[0][0]);

        //        try
        //        {
        //            porezNaDohodak = Convert.ToDecimal(client.GetDataTable("Select DDOBRACUNATIPOREZ From DDOBRACUNRadniciPorezi Where DDOBRACUNIDOBRACUN = '" +
        //                                               id_obracun + "' And DDIDRADNIK = '" + id_radnik + "'").Rows[0][0]);
        //        }
        //        catch 
        //        {
        //            porezNaDohodak = 0;
        //        }

        //        prirez = Convert.ToDecimal(radnik["DDOBRACUNATIPRIREZ"]);


        //        if (radnik["IDKATEGORIJA"].ToString() == "1" | radnik["IDKATEGORIJA"].ToString() == "5")
        //        {
        //            osnovica = primitak;

        //            try
        //            {

        //                doprinosMirovinsko = Convert.ToDecimal(client.GetDataTable("Select DDOBRACUNATIDOPRINOS From DDOBRACUNRadniciDoprinosi Where DDOBRACUNIDOBRACUN = '" + 
        //                                                       id_obracun + "' And DDIDRADNIK = '" + id_radnik + "' And (IDDOPRINOS = 8 OR IDDOPRINOS = 10)").Rows[0][0]);
        //            }
        //            catch
        //            {
        //                doprinosMirovinsko = 0;
        //            }

        //            try
        //            {
        //                doprinosMirovinskoII = Convert.ToDecimal(client.GetDataTable("Select DDOBRACUNATIDOPRINOS From DDOBRACUNRadniciDoprinosi Where DDOBRACUNIDOBRACUN = '" + 
        //                                                         id_obracun + "' And DDIDRADNIK = '" + id_radnik + "' And IDDOPRINOS = 9").Rows[0][0]);
        //            }
        //            catch 
        //            {
        //                doprinosMirovinskoII = 0;
        //            }

        //            try
        //            {
        //                doprinosZdravstveno = Convert.ToDecimal(client.GetDataTable("Select DDOBRACUNATIDOPRINOS From DDOBRACUNRadniciDoprinosi Where DDOBRACUNIDOBRACUN = '" + 
        //                                                        id_obracun + "' And DDIDRADNIK = '" + id_radnik + "' And IDDOPRINOS = 11").Rows[0][0]);
        //            }
        //            catch 
        //            {
        //                doprinosZdravstveno = 0;
        //            }

        //            izdatak = 0;
        //            izdatakDoprinosMirovinsko = doprinosMirovinsko + doprinosMirovinskoII;
        //            dohodak = primitak - izdatakDoprinosMirovinsko - izdatak;
        //            poreznaOsnovica = dohodak - osobniOdbitak;
        //            oznakaStjecatelja = "4002";

        //            vrste_posla = IsDbNull<int>(client.ExecuteScalar("Select DDIDVrstaPosla From DDOBRACUNRadniciVrstePosla Where DDOBRACUNIDOBRACUN = '" + id_obracun + 
        //                                                             "' And DDIDRADNIK = '" + id_radnik + "'"));

        //            if (vrste_posla == 999)
        //            {
        //                oznakaPrimitka = "4014";
        //            }
        //            else
        //            {
        //                oznakaPrimitka = "4030";
        //            }

        //            if (vrste_posla == 998)
        //            {
        //                oznakaNacinaIsplate = 4;
        //            }

        //            if (vrste_posla == 997)
        //            {
        //                oznakaPrimitka = "4032";
        //            }

        //            if (vrste_posla == 996)
        //            {
        //                oznakaPrimitka = "4032";
        //                oznakaNacinaIsplate = 4;
        //            }
        //        }
        //        else if (radnik["IDKATEGORIJA"].ToString() == "2")
        //        {
        //            osnovica = 0;
        //            doprinosMirovinsko = 0;
        //            doprinosMirovinskoII = 0;
        //            doprinosZdravstveno = 0;
        //            izdatak = 0;
        //            izdatakDoprinosMirovinsko = doprinosMirovinsko + doprinosMirovinskoII;
        //            dohodak = primitak - izdatakDoprinosMirovinsko - izdatak;
        //            poreznaOsnovica = dohodak - osobniOdbitak;
        //            oznakaStjecatelja = "4001";
        //            oznakaPrimitka = "4016";

        //            if (vrste_posla == 997)
        //            {
        //                oznakaPrimitka = "4032";
        //            }

        //            if (vrste_posla == 998)
        //            {
        //                oznakaNacinaIsplate = 4;
        //            }

        //            if (vrste_posla == 996)
        //            {
        //                oznakaPrimitka = "4032";
        //                oznakaNacinaIsplate = 4;
        //            }
        //        }
        //        else if (radnik["IDKATEGORIJA"].ToString() == "3")
        //        {
        //            osnovica = 0;
        //            doprinosMirovinsko = 0;
        //            doprinosMirovinskoII = 0;
        //            doprinosZdravstveno = 0;
        //            izdatakDoprinosMirovinsko = doprinosMirovinsko + doprinosMirovinskoII;

        //            izdatak = Convert.ToDecimal(client.GetDataTable("Select DDOBRACUNATIIZDATAK From DDOBRACUNRadniciIzdaci Where DDOBRACUNIDOBRACUN = '" + 
        //                                        id_obracun + "' And DDIDRADNIK = '" + id_radnik + "'").Rows[0][0]);

        //            dohodak = primitak - izdatakDoprinosMirovinsko - izdatak;
        //            poreznaOsnovica = dohodak - osobniOdbitak;

        //            oznakaStjecatelja = "4001";
        //            oznakaPrimitka = "4001";
        //        }
        //        else if (radnik["IDKATEGORIJA"].ToString() == "4")
        //        {
        //            osnovica = 0;
        //            doprinosMirovinsko = 0;
        //            doprinosMirovinskoII = 0;
        //            doprinosZdravstveno = 0;
        //            izdatakDoprinosMirovinsko = doprinosMirovinsko + doprinosMirovinskoII;

        //            izdatak = Convert.ToDecimal(client.ExecuteScalar("Select Sum(DDOBRACUNATIIZDATAK) From DDOBRACUNRadniciIzdaci Where DDOBRACUNIDOBRACUN = '" +
        //                                        id_obracun + "' And DDIDRADNIK = '" + id_radnik + "'"));

        //            dohodak = primitak - izdatakDoprinosMirovinsko - izdatak;
        //            poreznaOsnovica = dohodak - osobniOdbitak;

        //            oznakaStjecatelja = "4001";
        //            oznakaPrimitka = "4002";
        //        }

        //        isplata = primitak - doprinosMirovinsko - doprinosMirovinskoII - porezNaDohodak - prirez; 

        //        tblJOPPDB.Rows.Add(this.JOPPDID.Value, redniBroj, sifraOpcinePrebivalista, sifraOpcineRada, oibStjecatelja, imePrezimeStjecatelja, oznakaStjecatelja, 
        //        oznakaPrimitka, obvezaDodatnogDoprinosa, obvezaPosebnogDoprinosa, oznakaMjesecaOsiguranje, oznakaRadnogVremena, satiRada, neodradeniSatiRada, razdobljeOd, razdobljeDo, 
        //        primitak, osnovica, doprinosMirovinsko, doprinosMirovinskoII, doprinosZdravstveno, doprinosZastita, doprinosZaposljavanje, dodatniDoprinosMirovinsko,
        //        dodatniDoprinosMirovinskoII, posebanDoprinosZdravstveno, posebanDoprinosZaposljavanje, izdatak, izdatakDoprinosMirovinsko, dohodak, osobniOdbitak, 
        //        poreznaOsnovica, porezNaDohodak, prirez, oznakaNeoporezivogPrimitka, neoporezivPrimitak, oznakaNacinaIsplate, isplata, obracun_primitak);
        //        brojac++;
        //    }

        //    return redniBroj;
        //}
        
        /// <summary>
        ///17.11.2017 - Iskopirana cijela metoda iz MIPSED7 
        /// </summary>
        /// <param name="element"></param>
        /// <param name="redniBroj"></param>
        /// <param name="tblJOPPDB"></param>
        /// <returns></returns>
        private int GenerirajJOPPDHonorariStranicaB(JOPPD.frmWaitProgress element, int redniBroj, ref DataTable tblJOPPDB)
        {
            string sifraOpcinePrebivalista = string.Empty;
            string sifraOpcineRada = string.Empty;
            string oibStjecatelja = string.Empty;
            string imePrezimeStjecatelja = string.Empty;
            string oznakaStjecatelja = string.Empty;
            string oznakaPrimitka = string.Empty;
            decimal obvezaDodatnogDoprinosa = 0;
            decimal obvezaPosebnogDoprinosa = 0;
            decimal oznakaMjesecaOsiguranje = 0;
            decimal oznakaRadnogVremena = 0;
            decimal satiRada = 0;
            decimal neodradeniSatiRada = 0;
            DateTime razdobljeOd = DateTime.MinValue;
            DateTime razdobljeDo = DateTime.MinValue;
            decimal primitak = 0;
            decimal osnovica = 0;
            decimal doprinosMirovinsko = 0;
            decimal doprinosMirovinskoII = 0;
            decimal doprinosZdravstveno = 0;
            decimal doprinosZastita = 0;
            decimal doprinosZaposljavanje = 0;
            decimal dodatniDoprinosMirovinsko = 0;
            decimal dodatniDoprinosMirovinskoII = 0;
            decimal posebanDoprinosZdravstveno = 0;
            decimal posebanDoprinosZaposljavanje = 0;
            decimal izdatak = 0;
            decimal izdatakDoprinosMirovinsko = 0;
            decimal dohodak = 0;
            decimal osobniOdbitak = 0;
            decimal poreznaOsnovica = 0;
            decimal porezNaDohodak = 0;
            decimal prirez = 0;
            string oznakaNeoporezivogPrimitka = string.Empty;
            decimal neoporezivPrimitak = 0;
            decimal oznakaNacinaIsplate = 0;
            decimal isplata = 0;
            decimal obracun_primitak = 0;
            int brojac = 1;
            string id_radnik = "";
            int? vrste_posla = 0;
            string id_obracun = string.Empty;

            // Get IDOBRACUN
            string odabrani_obracuni = string.Empty;
            DataTable tblObracuni = client.GetDataTable("Select Obracun_ID From JOPPDAObracun Where JOPPDA_ID = '" + JOPPDID.Value + "' And Vrsta = 1");
            int broj_obracuna = tblObracuni.Rows.Count;
            for (int i = 0; i < tblObracuni.Rows.Count; i++)
            {
                broj_obracuna--;
                if (broj_obracuna == 0)
                {
                    odabrani_obracuni += "'" + tblObracuni.Rows[i][0].ToString().Trim() + "'";
                }
                else
                {
                    odabrani_obracuni += "'" + tblObracuni.Rows[i][0].ToString().Trim() + "',";
                }
            }

            DataTable tblRadnici = client.GetDataTable("SELECT DDOBRACUNRadnici.DDOBRACUNIDOBRACUN, DDOBRACUNRadnici.DDIDRADNIK, DDOBRACUNRadnici.IDKATEGORIJA, DDOBRACUNRadnici.DDOBRACUNATIPRIREZ, " +
                                   "DDOBRACUNRadnici.DDOBRACUNATIPDV, DDOBRACUNRadnici.OPCINASTANOVANJAIDOPCINE, DDOBRACUNRadnici.DDSIFRAOPCINESTANOVANJA, DDOBRACUNRadnici.IDKOLONAIDD, " +
                                   "DDRADNIK.DDOIB, (DDRADNIK.DDIME +  ' ' + DDRADNIK.DDPREZIME) As 'Ime i prezime', DDOBRACUN.DDDATUMOBRACUNA FROM DDOBRACUNRadnici " +
                                   "Inner Join DDRADNIK On DDOBRACUNRadnici.DDIDRADNIK = DDRADNIK.DDIDRADNIK " +
                                   "Inner Join DDOBRACUN On DDOBRACUNRadnici.DDOBRACUNIDOBRACUN = DDOBRACUN.DDOBRACUNIDOBRACUN " +
                                   "Where DDOBRACUN.DDOBRACUNIDOBRACUN IN (" + odabrani_obracuni + ")");

            foreach (DataRow radnik in tblRadnici.Rows)
            {
                element.Text = "Generiranje u tijeku...{Honorari}. Molimo pričekajte...{" + brojac + "}";

                id_radnik = radnik["DDIDRADNIK"].ToString();

                redniBroj++;
                sifraOpcinePrebivalista = "0" + radnik["OPCINASTANOVANJAIDOPCINE"].ToString();
                sifraOpcineRada = "00000";
                oibStjecatelja = radnik["DDOIB"].ToString();
                imePrezimeStjecatelja = radnik["Ime i prezime"].ToString();
                obvezaDodatnogDoprinosa = 0;
                obvezaPosebnogDoprinosa = 0;
                oznakaMjesecaOsiguranje = 0;
                oznakaRadnogVremena = 0;
                satiRada = 0;
                osobniOdbitak = 0;
                doprinosZastita = 0;
                doprinosZaposljavanje = 0;
                dodatniDoprinosMirovinsko = 0;
                dodatniDoprinosMirovinskoII = 0;
                posebanDoprinosZdravstveno = 0;
                obracun_primitak = 0;
                posebanDoprinosZaposljavanje = 0;
                oznakaNeoporezivogPrimitka = "0";
                neoporezivPrimitak = 0;
                oznakaNacinaIsplate = 2;
                id_obracun = radnik["DDOBRACUNIDOBRACUN"].ToString();

                int godina = Convert.ToDateTime(radnik["DDDATUMOBRACUNA"]).Date.Year;

                razdobljeDo = new DateTime(godina, 12, 31);
                razdobljeOd = new DateTime(godina, 1, 1);

                primitak = Convert.ToDecimal(client.GetDataTable("Select DDIZNOS From DDOBRACUNRadniciVrstePosla Where DDOBRACUNIDOBRACUN  = '" + id_obracun + "' " +
                            "And DDIDRADNIK = '" + id_radnik + "'").Rows[0][0]);

                try
                {
                    porezNaDohodak = Convert.ToDecimal(client.GetDataTable("Select DDOBRACUNATIPOREZ From DDOBRACUNRadniciPorezi Where DDOBRACUNIDOBRACUN = '" +
                                                       id_obracun + "' And DDIDRADNIK = '" + id_radnik + "'").Rows[0][0]);
                }
                catch
                {
                    porezNaDohodak = 0;
                }

                prirez = Convert.ToDecimal(radnik["DDOBRACUNATIPRIREZ"]);


                if (radnik["IDKATEGORIJA"].ToString() == "1" | radnik["IDKATEGORIJA"].ToString() == "5" | radnik["IDKATEGORIJA"].ToString() == "7" | radnik["IDKATEGORIJA"].ToString() == "9")
                {
                    osnovica = primitak;

                    try
                    {

                        doprinosMirovinsko = Convert.ToDecimal(client.GetDataTable("Select DDOBRACUNATIDOPRINOS From DDOBRACUNRadniciDoprinosi Where DDOBRACUNIDOBRACUN = '" +
                                                               id_obracun + "' And DDIDRADNIK = '" + id_radnik + "' And (IDDOPRINOS = 8 OR IDDOPRINOS = 10)").Rows[0][0]);
                    }
                    catch
                    {
                        doprinosMirovinsko = 0;
                    }

                    try
                    {
                        doprinosMirovinskoII = Convert.ToDecimal(client.GetDataTable("Select DDOBRACUNATIDOPRINOS From DDOBRACUNRadniciDoprinosi Where DDOBRACUNIDOBRACUN = '" +
                                                                 id_obracun + "' And DDIDRADNIK = '" + id_radnik + "' And IDDOPRINOS = 9").Rows[0][0]);
                    }
                    catch
                    {
                        doprinosMirovinskoII = 0;
                    }

                    try
                    {
                        doprinosZdravstveno = Convert.ToDecimal(client.GetDataTable("Select DDOBRACUNATIDOPRINOS From DDOBRACUNRadniciDoprinosi Where DDOBRACUNIDOBRACUN = '" +
                                                                id_obracun + "' And DDIDRADNIK = '" + id_radnik + "' And IDDOPRINOS = 11").Rows[0][0]);
                    }
                    catch
                    {
                        doprinosZdravstveno = 0;
                    }

                    izdatak = 0;
                    izdatakDoprinosMirovinsko = doprinosMirovinsko + doprinosMirovinskoII;
                    dohodak = primitak - izdatakDoprinosMirovinsko - izdatak;
                    poreznaOsnovica = dohodak - osobniOdbitak;

                    oznakaStjecatelja = "4002";

                    vrste_posla = IsDbNull<int>(client.ExecuteScalar("Select DDIDVrstaPosla From DDOBRACUNRadniciVrstePosla Where DDOBRACUNIDOBRACUN = '" + id_obracun +
                                                                     "' And DDIDRADNIK = '" + id_radnik + "'"));

                    if (vrste_posla == 999)
                    {
                        oznakaPrimitka = "4014";
                    }
                    else
                    {
                        oznakaPrimitka = "4030";
                    }


                    if (vrste_posla == 998)
                    {
                        oznakaNacinaIsplate = 4;
                    }

                    if (vrste_posla == 997)
                    {
                        oznakaPrimitka = "4032";
                    }

                    if (vrste_posla == 996)
                    {
                        oznakaPrimitka = "4032";
                        oznakaNacinaIsplate = 4;
                    }

                    //if (radnik["IDKATEGORIJA"].ToString() == "5" && vrste_posla == 999)
                    //{
                    //    oznakaPrimitka = "4014";
                    //    oznakaStjecatelja = "4002";
                    //}
                }

                //--dodano branimir 27.12.2016.--
                else if (radnik["IDKATEGORIJA"].ToString() == "990" | radnik["IDKATEGORIJA"].ToString() == "986" | radnik["IDKATEGORIJA"].ToString() == "984" | radnik["IDKATEGORIJA"].ToString() == "982")
                {
                    osnovica = primitak;
                    oznakaStjecatelja = "4002";

                    try
                    {

                        doprinosMirovinsko = Convert.ToDecimal(client.GetDataTable("Select DDOBRACUNATIDOPRINOS From DDOBRACUNRadniciDoprinosi Where DDOBRACUNIDOBRACUN = '" +
                                                               id_obracun + "' And DDIDRADNIK = '" + id_radnik + "' And (IDDOPRINOS = 987 OR IDDOPRINOS = 989)").Rows[0][0]);
                    }
                    catch
                    {
                        doprinosMirovinsko = 0;
                    }

                    try
                    {
                        doprinosMirovinskoII = Convert.ToDecimal(client.GetDataTable("Select DDOBRACUNATIDOPRINOS From DDOBRACUNRadniciDoprinosi Where DDOBRACUNIDOBRACUN = '" +
                                                                 id_obracun + "' And DDIDRADNIK = '" + id_radnik + "' And IDDOPRINOS = 988").Rows[0][0]);
                    }
                    catch
                    {
                        doprinosMirovinskoII = 0;
                    }

                    try
                    {
                        doprinosZdravstveno = Convert.ToDecimal(client.GetDataTable("Select DDOBRACUNATIDOPRINOS From DDOBRACUNRadniciDoprinosi Where DDOBRACUNIDOBRACUN = '" +
                                                                id_obracun + "' And DDIDRADNIK = '" + id_radnik + "' And IDDOPRINOS = 990").Rows[0][0]);
                    }
                    catch
                    {
                        doprinosZdravstveno = 0;
                    }

                    izdatak = 0;
                    izdatakDoprinosMirovinsko = doprinosMirovinsko + doprinosMirovinskoII;
                    dohodak = primitak - izdatakDoprinosMirovinsko - izdatak;
                    poreznaOsnovica = dohodak - osobniOdbitak;

                    vrste_posla = IsDbNull<int>(client.ExecuteScalar("Select DDIDVrstaPosla From DDOBRACUNRadniciVrstePosla Where DDOBRACUNIDOBRACUN = '" + id_obracun +
                                                                     "' And DDIDRADNIK = '" + id_radnik + "'"));

                    if (vrste_posla == 999)
                    {
                        oznakaPrimitka = "4014";
                    }
                    else
                    {
                        oznakaPrimitka = "4030";
                    }


                    if (vrste_posla == 998)
                    {
                        oznakaNacinaIsplate = 4;
                    }

                    if (vrste_posla == 997)
                    {
                        oznakaPrimitka = "4032";
                    }

                    if (vrste_posla == 996)
                    {
                        oznakaPrimitka = "4032";
                        oznakaNacinaIsplate = 4;
                    }
                }
                //staro
                else if (radnik["IDKATEGORIJA"].ToString() == "2" | radnik["IDKATEGORIJA"].ToString() == "6" | radnik["IDKATEGORIJA"].ToString() == "8" | radnik["IDKATEGORIJA"].ToString() == "10")
                {
                    osnovica = 0;
                    doprinosMirovinsko = 0;
                    doprinosMirovinskoII = 0;
                    doprinosZdravstveno = 0;
                    izdatak = 0;
                    izdatakDoprinosMirovinsko = doprinosMirovinsko + doprinosMirovinskoII;
                    dohodak = primitak - izdatakDoprinosMirovinsko - izdatak;
                    poreznaOsnovica = dohodak - osobniOdbitak;
                    oznakaStjecatelja = "4001";

                    //db - 7.11.2016.
                    vrste_posla = IsDbNull<int>(client.ExecuteScalar("Select DDIDVrstaPosla From DDOBRACUNRadniciVrstePosla Where DDOBRACUNIDOBRACUN = '" + id_obracun +
                                                                 "' And DDIDRADNIK = '" + id_radnik + "'"));

                    oznakaPrimitka = "4016";

                    if (vrste_posla == 997)
                    {
                        oznakaPrimitka = "4032";
                    }

                    if (vrste_posla == 998)
                    {
                        oznakaNacinaIsplate = 4;
                    }

                    if (vrste_posla == 996)
                    {
                        oznakaPrimitka = "4032";
                        oznakaNacinaIsplate = 4;
                    }
                }
                //--dodano branimir 27.12.2016.--
                else if (radnik["IDKATEGORIJA"].ToString() == "989" | radnik["IDKATEGORIJA"].ToString() == "985" | radnik["IDKATEGORIJA"].ToString() == "983" | radnik["IDKATEGORIJA"].ToString() == "981")
                {
                    osnovica = primitak;

                    try
                    {

                        doprinosMirovinsko = Convert.ToDecimal(client.GetDataTable("Select DDOBRACUNATIDOPRINOS From DDOBRACUNRadniciDoprinosi Where DDOBRACUNIDOBRACUN = '" +
                                                               id_obracun + "' And DDIDRADNIK = '" + id_radnik + "' And (IDDOPRINOS = 987 OR IDDOPRINOS = 989)").Rows[0][0]);
                    }
                    catch
                    {
                        doprinosMirovinsko = 0;
                    }

                    try
                    {
                        doprinosMirovinskoII = Convert.ToDecimal(client.GetDataTable("Select DDOBRACUNATIDOPRINOS From DDOBRACUNRadniciDoprinosi Where DDOBRACUNIDOBRACUN = '" +
                                                                 id_obracun + "' And DDIDRADNIK = '" + id_radnik + "' And IDDOPRINOS = 988").Rows[0][0]);
                    }
                    catch
                    {
                        doprinosMirovinskoII = 0;
                    }

                    try
                    {
                        doprinosZdravstveno = Convert.ToDecimal(client.GetDataTable("Select DDOBRACUNATIDOPRINOS From DDOBRACUNRadniciDoprinosi Where DDOBRACUNIDOBRACUN = '" +
                                                                id_obracun + "' And DDIDRADNIK = '" + id_radnik + "' And IDDOPRINOS = 990").Rows[0][0]);
                    }
                    catch
                    {
                        doprinosZdravstveno = 0;
                    }

                    izdatak = 0;
                    izdatakDoprinosMirovinsko = doprinosMirovinsko + doprinosMirovinskoII;
                    dohodak = primitak - izdatakDoprinosMirovinsko - izdatak;
                    poreznaOsnovica = dohodak - osobniOdbitak;
                    oznakaStjecatelja = "4002";

                    //db - 7.11.2016.
                    vrste_posla = IsDbNull<int>(client.ExecuteScalar("Select DDIDVrstaPosla From DDOBRACUNRadniciVrstePosla Where DDOBRACUNIDOBRACUN = '" + id_obracun +
                                                                 "' And DDIDRADNIK = '" + id_radnik + "'"));

                    oznakaPrimitka = "4030";

                    if (vrste_posla == 997)
                    {
                        oznakaPrimitka = "4032";
                    }

                    if (vrste_posla == 998)
                    {
                        oznakaNacinaIsplate = 4;
                    }

                    if (vrste_posla == 996)
                    {
                        oznakaPrimitka = "4032";
                        oznakaNacinaIsplate = 4;
                    }
                }
                //staro
                else if (radnik["IDKATEGORIJA"].ToString() == "3")
                {
                    osnovica = 0;
                    doprinosMirovinsko = 0;
                    doprinosMirovinskoII = 0;
                    doprinosZdravstveno = 0;
                    izdatakDoprinosMirovinsko = doprinosMirovinsko + doprinosMirovinskoII;

                    izdatak = Convert.ToDecimal(client.GetDataTable("Select DDOBRACUNATIIZDATAK From DDOBRACUNRadniciIzdaci Where DDOBRACUNIDOBRACUN = '" +
                                                id_obracun + "' And DDIDRADNIK = '" + id_radnik + "'").Rows[0][0]);

                    dohodak = primitak - izdatakDoprinosMirovinsko - izdatak;
                    poreznaOsnovica = dohodak - osobniOdbitak;

                    oznakaStjecatelja = "4001";
                    oznakaPrimitka = "4001";
                }
                //--dodano branimir 27.12.2016.--
                else if (radnik["IDKATEGORIJA"].ToString() == "988")
                {

                    oznakaStjecatelja = "4002";
                    oznakaPrimitka = "4001";

                    izdatak = Convert.ToDecimal(client.GetDataTable("Select DDOBRACUNATIIZDATAK From DDOBRACUNRadniciIzdaci Where DDOBRACUNIDOBRACUN = '" +
                                               id_obracun + "' And DDIDRADNIK = '" + id_radnik + "'").Rows[0][0]);

                    osnovica = primitak - izdatak;

                    try
                    {

                        doprinosMirovinsko = Convert.ToDecimal(client.GetDataTable("Select DDOBRACUNATIDOPRINOS From DDOBRACUNRadniciDoprinosi Where DDOBRACUNIDOBRACUN = '" +
                                                               id_obracun + "' And DDIDRADNIK = '" + id_radnik + "' And (IDDOPRINOS = 987 OR IDDOPRINOS = 989)").Rows[0][0]);
                    }
                    catch
                    {
                        doprinosMirovinsko = 0;
                    }

                    try
                    {
                        doprinosMirovinskoII = Convert.ToDecimal(client.GetDataTable("Select DDOBRACUNATIDOPRINOS From DDOBRACUNRadniciDoprinosi Where DDOBRACUNIDOBRACUN = '" +
                                                                 id_obracun + "' And DDIDRADNIK = '" + id_radnik + "' And IDDOPRINOS = 988").Rows[0][0]);
                    }
                    catch
                    {
                        doprinosMirovinskoII = 0;
                    }

                    try
                    {
                        doprinosZdravstveno = Convert.ToDecimal(client.GetDataTable("Select DDOBRACUNATIDOPRINOS From DDOBRACUNRadniciDoprinosi Where DDOBRACUNIDOBRACUN = '" +
                                                                id_obracun + "' And DDIDRADNIK = '" + id_radnik + "' And IDDOPRINOS = 990").Rows[0][0]);
                    }
                    catch
                    {
                        doprinosZdravstveno = 0;
                    }

                    izdatakDoprinosMirovinsko = doprinosMirovinsko + doprinosMirovinskoII;
                    dohodak = primitak - izdatakDoprinosMirovinsko - izdatak;
                    poreznaOsnovica = dohodak - osobniOdbitak;
                }
                else if (radnik["IDKATEGORIJA"].ToString() == "4")
                {
                    osnovica = 0;
                    doprinosMirovinsko = 0;
                    doprinosMirovinskoII = 0;
                    doprinosZdravstveno = 0;
                    izdatakDoprinosMirovinsko = doprinosMirovinsko + doprinosMirovinskoII;

                    izdatak = Convert.ToDecimal(client.ExecuteScalar("Select Sum(DDOBRACUNATIIZDATAK) From DDOBRACUNRadniciIzdaci Where DDOBRACUNIDOBRACUN = '" +
                                                id_obracun + "' And DDIDRADNIK = '" + id_radnik + "'"));

                    dohodak = primitak - izdatakDoprinosMirovinsko - izdatak;
                    poreznaOsnovica = dohodak - osobniOdbitak;

                    oznakaStjecatelja = "4001";
                    oznakaPrimitka = "4002";
                }
                //--dodano branimir 27.12.2016.--
                else if (radnik["IDKATEGORIJA"].ToString() == "987")
                {

                    oznakaStjecatelja = "4002";
                    oznakaPrimitka = "4002";

                    izdatak = Convert.ToDecimal(client.ExecuteScalar("Select Sum(DDOBRACUNATIIZDATAK) From DDOBRACUNRadniciIzdaci Where DDOBRACUNIDOBRACUN = '" +
                                                id_obracun + "' And DDIDRADNIK = '" + id_radnik + "'"));

                    osnovica = primitak - izdatak;

                    try
                    {

                        doprinosMirovinsko = Convert.ToDecimal(client.GetDataTable("Select DDOBRACUNATIDOPRINOS From DDOBRACUNRadniciDoprinosi Where DDOBRACUNIDOBRACUN = '" +
                                                               id_obracun + "' And DDIDRADNIK = '" + id_radnik + "' And (IDDOPRINOS = 987 OR IDDOPRINOS = 989)").Rows[0][0]);
                    }
                    catch
                    {
                        doprinosMirovinsko = 0;
                    }

                    try
                    {
                        doprinosMirovinskoII = Convert.ToDecimal(client.GetDataTable("Select DDOBRACUNATIDOPRINOS From DDOBRACUNRadniciDoprinosi Where DDOBRACUNIDOBRACUN = '" +
                                                                 id_obracun + "' And DDIDRADNIK = '" + id_radnik + "' And IDDOPRINOS = 988").Rows[0][0]);
                    }
                    catch
                    {
                        doprinosMirovinskoII = 0;
                    }

                    try
                    {
                        doprinosZdravstveno = Convert.ToDecimal(client.GetDataTable("Select DDOBRACUNATIDOPRINOS From DDOBRACUNRadniciDoprinosi Where DDOBRACUNIDOBRACUN = '" +
                                                                id_obracun + "' And DDIDRADNIK = '" + id_radnik + "' And IDDOPRINOS = 990").Rows[0][0]);
                    }
                    catch
                    {
                        doprinosZdravstveno = 0;
                    }

                    izdatakDoprinosMirovinsko = doprinosMirovinsko + doprinosMirovinskoII;
                    dohodak = primitak - izdatakDoprinosMirovinsko - izdatak;
                    poreznaOsnovica = dohodak - osobniOdbitak;
                }
                //--dodano branimir 4.1.2017.--
                else if (radnik["IDKATEGORIJA"].ToString() == "985")
                {
                    osnovica = primitak;

                    try
                    {

                        doprinosMirovinsko = Convert.ToDecimal(client.GetDataTable("Select DDOBRACUNATIDOPRINOS From DDOBRACUNRadniciDoprinosi Where DDOBRACUNIDOBRACUN = '" +
                                                               id_obracun + "' And DDIDRADNIK = '" + id_radnik + "' And (IDDOPRINOS = 987 OR IDDOPRINOS = 989)").Rows[0][0]);
                    }
                    catch
                    {
                        doprinosMirovinsko = 0;
                    }

                    try
                    {
                        doprinosMirovinskoII = Convert.ToDecimal(client.GetDataTable("Select DDOBRACUNATIDOPRINOS From DDOBRACUNRadniciDoprinosi Where DDOBRACUNIDOBRACUN = '" +
                                                                 id_obracun + "' And DDIDRADNIK = '" + id_radnik + "' And IDDOPRINOS = 988").Rows[0][0]);
                    }
                    catch
                    {
                        doprinosMirovinskoII = 0;
                    }

                    try
                    {
                        doprinosZdravstveno = Convert.ToDecimal(client.GetDataTable("Select DDOBRACUNATIDOPRINOS From DDOBRACUNRadniciDoprinosi Where DDOBRACUNIDOBRACUN = '" +
                                                                id_obracun + "' And DDIDRADNIK = '" + id_radnik + "' And IDDOPRINOS = 990").Rows[0][0]);
                    }
                    catch
                    {
                        doprinosZdravstveno = 0;
                    }

                    izdatak = 0;
                    izdatakDoprinosMirovinsko = doprinosMirovinsko + doprinosMirovinskoII;
                    dohodak = primitak - izdatakDoprinosMirovinsko - izdatak;
                    poreznaOsnovica = dohodak - osobniOdbitak;
                    oznakaStjecatelja = "4002";

                    //db - 7.11.2016.
                    vrste_posla = IsDbNull<int>(client.ExecuteScalar("Select DDIDVrstaPosla From DDOBRACUNRadniciVrstePosla Where DDOBRACUNIDOBRACUN = '" + id_obracun +
                                                                 "' And DDIDRADNIK = '" + id_radnik + "'"));

                    oznakaPrimitka = "4016";

                    if (vrste_posla == 997)
                    {
                        oznakaPrimitka = "4032";
                    }

                    if (vrste_posla == 998)
                    {
                        oznakaNacinaIsplate = 4;
                    }

                    if (vrste_posla == 996)
                    {
                        oznakaPrimitka = "4032";
                        oznakaNacinaIsplate = 4;
                    }

                }

                isplata = primitak - doprinosMirovinsko - doprinosMirovinskoII - porezNaDohodak - prirez;

                tblJOPPDB.Rows.Add(this.JOPPDID.Value, redniBroj, sifraOpcinePrebivalista, sifraOpcineRada, oibStjecatelja, imePrezimeStjecatelja, oznakaStjecatelja,
                oznakaPrimitka, obvezaDodatnogDoprinosa, obvezaPosebnogDoprinosa, oznakaMjesecaOsiguranje, oznakaRadnogVremena, satiRada, neodradeniSatiRada, razdobljeOd, razdobljeDo,
                primitak, osnovica, doprinosMirovinsko, doprinosMirovinskoII, doprinosZdravstveno, doprinosZastita, doprinosZaposljavanje, dodatniDoprinosMirovinsko,
                dodatniDoprinosMirovinskoII, posebanDoprinosZdravstveno, posebanDoprinosZaposljavanje, izdatak, izdatakDoprinosMirovinsko, dohodak, osobniOdbitak,
                poreznaOsnovica, porezNaDohodak, prirez, oznakaNeoporezivogPrimitka, neoporezivPrimitak, oznakaNacinaIsplate, isplata, obracun_primitak);
                brojac++;
            }

            return redniBroj;
        }

        private int GenerirajJOPPDPraksaStranicaB(JOPPD.frmWaitProgress element, int redniBroj, ref DataTable tblJOPPDB)
        {
            string sifraOpcinePrebivalista = string.Empty;
            string sifraOpcineRada = string.Empty;
            string oibStjecatelja = string.Empty;
            string imePrezimeStjecatelja = string.Empty;
            string oznakaStjecatelja = string.Empty;
            string oznakaPrimitka = string.Empty;
            decimal obvezaDodatnogDoprinosa = 0;
            decimal obvezaPosebnogDoprinosa = 0;
            decimal oznakaMjesecaOsiguranje = 0;
            decimal oznakaRadnogVremena = 0;
            decimal satiRada = 0;
            decimal neodradeniSatiRada = 0;
            DateTime razdobljeOd = DateTime.MinValue;
            DateTime razdobljeDo = DateTime.MinValue;
            decimal primitak = 0;
            decimal osnovica = 0;
            decimal doprinosMirovinsko = 0;
            decimal doprinosMirovinskoII = 0;
            decimal doprinosZdravstveno = 0;
            decimal doprinosZastita = 0;
            decimal doprinosZaposljavanje = 0;
            decimal dodatniDoprinosMirovinsko = 0;
            decimal dodatniDoprinosMirovinskoII = 0;
            decimal posebanDoprinosZdravstveno = 0;
            decimal posebanDoprinosZaposljavanje = 0;
            decimal izdatak = 0;
            decimal izdatakDoprinosMirovinsko = 0;
            decimal dohodak = 0;
            decimal osobniOdbitak = 0;
            decimal poreznaOsnovica = 0;
            decimal porezNaDohodak = 0;
            decimal prirez = 0;
            string oznakaNeoporezivogPrimitka = string.Empty;
            decimal neoporezivPrimitak = 0;
            decimal oznakaNacinaIsplate = 0;
            decimal isplata = 0;
            decimal obracun_primitak = 0;
            int brojac = 1;
            string id_radnik = "";
            string [] mjeseci= null;
            int mjesec = 0;
            int godina = 0;
            int zadnji_dan = 0;
            string mjesec_str = "";
            string godina_str = "";

            // Get IDOBRACUN
            string odabrani_obracuni_mjesec = string.Empty;
            string odabrani_obracuni_godina = string.Empty;
            DataTable tblObracuni = client.GetDataTable("Select Obracun_ID From JOPPDAObracun Where JOPPDA_ID = '" + JOPPDID.Value + "' And Vrsta = 3");
            int broj_obracuna = tblObracuni.Rows.Count;
            for (int i = 0; i < tblObracuni.Rows.Count; i++)
            {
                broj_obracuna--;
                if (broj_obracuna == 0)
                {
                    odabrani_obracuni_mjesec += "'" + tblObracuni.Rows[i][0].ToString().Trim().Split('-')[0] + "'";
                    odabrani_obracuni_godina += "'" + tblObracuni.Rows[i][0].ToString().Trim().Split('-')[1] + "'";
                }
                else
                {
                    odabrani_obracuni_mjesec += "'" + tblObracuni.Rows[i][0].ToString().Trim().Split('-')[0] + "',";
                    odabrani_obracuni_godina += "'" + tblObracuni.Rows[i][0].ToString().Trim().Split('-')[1] + "',";
                }
            }

            DataTable tblRadnici = client.GetDataTable("SELECT DISTINCT IDUCENIK From UCENIKOBRACUNUCENIKOBRACUNDETAIL Where UCOBRMJESEC IN (" + odabrani_obracuni_mjesec + ") " + 
                                                       "And UCOBRGODINA IN (" + odabrani_obracuni_godina + ")");

            foreach (DataRow radnik in tblRadnici.Rows)
            {
                element.Text = "Generiranje u tijeku...{Praksa}. Molimo pričekajte...{" + brojac + "}";

                id_radnik = radnik["IDUCENIK"].ToString();

                redniBroj++;

                sifraOpcineRada = "00000";
                oznakaStjecatelja = "5606";
                oznakaPrimitka = "5110";
                obvezaDodatnogDoprinosa = 0;
                obvezaPosebnogDoprinosa = 0;
                oznakaMjesecaOsiguranje = 0;
                oznakaRadnogVremena = 0;
                satiRada = 0;

                mjeseci = odabrani_obracuni_mjesec.Split(',');
                Array.Sort(mjeseci);
                mjesec_str = mjeseci[0].Replace("'","");
                mjesec = Convert.ToInt32(mjesec_str);
                godina_str = odabrani_obracuni_godina.Split(',')[0].Replace("'","");
                godina = Convert.ToInt32(godina_str);
                razdobljeOd = new DateTime(godina, mjesec, 1);

                mjesec_str = mjeseci[mjeseci.Length - 1].Replace("'","");
                mjesec = Convert.ToInt32(mjesec_str);
                zadnji_dan = DateTime.DaysInMonth(godina, mjesec);
                razdobljeDo = new DateTime(godina, mjesec, zadnji_dan);


                primitak = 0;
                doprinosMirovinskoII = 0;
                doprinosZdravstveno = 0;
                doprinosZaposljavanje = 0;
                dodatniDoprinosMirovinsko = 0;
                dodatniDoprinosMirovinskoII = 0;
                posebanDoprinosZdravstveno = 0;
                posebanDoprinosZaposljavanje = 0;
                izdatak = 0;
                izdatakDoprinosMirovinsko = 0;
                dohodak = 0;
                osobniOdbitak = 0;
                poreznaOsnovica = 0;
                porezNaDohodak = 0;
                prirez = 0;
                oznakaNeoporezivogPrimitka = "0";
                neoporezivPrimitak = 0;
                oznakaNacinaIsplate = 0;
                isplata = 0;
                obracun_primitak = 0;

                imePrezimeStjecatelja = client.ExecuteScalar("Select IMEUCENIK + ' ' + PREZIMEUCENIK From Ucenik Where IDUCENIK = '" + id_radnik + "'").ToString();

                try
                {
                    sifraOpcinePrebivalista = "0" + client.ExecuteScalar("Select IDOPCINE From OPCINA Inner Join POSTANSKIBROJEVI ON Upper(OPCINA.NAZIVOPCINE) = Upper(POSTANSKIBROJEVI.NAZIVPOSTE) " +
                                                                   "Inner Join UCENIK ON POSTANSKIBROJEVI.POSTANSKIBROJ = UCENIK.POSTANSKIBROJ Where UCENIK.IDUCENIK = '" + id_radnik + "'").ToString();
                }
                catch 
                {
                    sifraOpcinePrebivalista = "0" + client.ExecuteScalar("Select ID_Opcina From Ucenik Where UCENIK.IDUCENIK = '" + id_radnik + "'").ToString();

                    if (sifraOpcinePrebivalista == "0")
                    {
                        MessageBox.Show("Učenik '" + imePrezimeStjecatelja + "' nema dodjeljenu opčinu.\nDodjelite svim učenicima opčinu i pokušajte ponovno.");
                        break;
                    }
                }
                oibStjecatelja = client.ExecuteScalar("Select OIBUCENIK From Ucenik Where IDUCENIK = '" + id_radnik + "'").ToString();

                osnovica =  Convert.ToDecimal(client.ExecuteScalar("Select SUM(OBRACUNOSNOVICEPRAKSA) From UCENIKOBRACUNUCENIKOBRACUNDETAIL Where IDUCENIK = '" + id_radnik
                                              + "' And UCOBRMJESEC IN (" + odabrani_obracuni_mjesec + ") And UCOBRGODINA IN (" + odabrani_obracuni_godina + ")"));

                doprinosMirovinsko = Math.Round(osnovica * 0.05M, 2);
                doprinosZastita = Math.Round(doprinosMirovinsko * 0.1M, 2);

                tblJOPPDB.Rows.Add(this.JOPPDID.Value, redniBroj, sifraOpcinePrebivalista, sifraOpcineRada, oibStjecatelja, imePrezimeStjecatelja, oznakaStjecatelja,
                oznakaPrimitka, obvezaDodatnogDoprinosa, obvezaPosebnogDoprinosa, oznakaMjesecaOsiguranje, oznakaRadnogVremena, satiRada, neodradeniSatiRada, razdobljeOd, razdobljeDo,
                primitak, osnovica, doprinosMirovinsko, doprinosMirovinskoII, doprinosZdravstveno, doprinosZastita, doprinosZaposljavanje, dodatniDoprinosMirovinsko,
                dodatniDoprinosMirovinskoII, posebanDoprinosZdravstveno, posebanDoprinosZaposljavanje, izdatak, izdatakDoprinosMirovinsko, dohodak, osobniOdbitak,
                poreznaOsnovica, porezNaDohodak, prirez, oznakaNeoporezivogPrimitka, neoporezivPrimitak, oznakaNacinaIsplate, isplata, obracun_primitak);
                brojac++;
            }
            return redniBroj;
        }

        private int GenerirajJOPPDObracunRaznoStranicaB(JOPPD.frmWaitProgress element, int redniBroj, ref DataTable tblJOPPDB)
        {
            string sifraOpcinePrebivalista = string.Empty;
            string sifraOpcineRada = string.Empty;
            string oibStjecatelja = string.Empty;
            string imePrezimeStjecatelja = string.Empty;
            string oznakaStjecatelja = string.Empty;
            string oznakaPrimitka = string.Empty;
            decimal obvezaDodatnogDoprinosa = 0;
            decimal obvezaPosebnogDoprinosa = 0;
            decimal oznakaMjesecaOsiguranje = 0;
            decimal oznakaRadnogVremena = 0;
            decimal satiRada = 0;
            decimal neodradeniSatiRada = 0;
            DateTime razdobljeOd = DateTime.MinValue;
            DateTime razdobljeDo = DateTime.MinValue;
            decimal primitak = 0;
            decimal osnovica = 0;
            decimal doprinosMirovinsko = 0;
            decimal doprinosMirovinskoII = 0;
            decimal doprinosZdravstveno = 0;
            decimal doprinosZastita = 0;
            decimal doprinosZaposljavanje = 0;
            decimal dodatniDoprinosMirovinsko = 0;
            decimal dodatniDoprinosMirovinskoII = 0;
            decimal posebanDoprinosZdravstveno = 0;
            decimal posebanDoprinosZaposljavanje = 0;
            decimal izdatak = 0;
            decimal izdatakDoprinosMirovinsko = 0;
            decimal dohodak = 0;
            decimal osobniOdbitak = 0;
            decimal poreznaOsnovica = 0;
            decimal porezNaDohodak = 0;
            decimal prirez = 0;
            string oznakaNeoporezivogPrimitka = string.Empty;
            decimal neoporezivPrimitak = 0;
            decimal oznakaNacinaIsplate = 0;
            decimal isplata = 0;
            decimal obracun_primitak = 0;
            string vrsta_obracuna = "";
            int zadnji_dan = 0;
            byte mjesec;
            Int16 godina;
            string ime;
            string prezime;

            // Get IDOBRACUN
            string odabrani_obracuni = string.Empty;
            DataTable tblObracuni = client.GetDataTable("Select Obracun_ID From JOPPDAObracun Where JOPPDA_ID = '" + JOPPDID.Value + "' And Vrsta = 4");
            int broj_obracuna = tblObracuni.Rows.Count;
            for (int i = 0; i < tblObracuni.Rows.Count; i++)
            {
                broj_obracuna--;
                if (broj_obracuna == 0)
                {
                    odabrani_obracuni += "'" + tblObracuni.Rows[i][0].ToString().Trim() + "'";
                }
                else
                {
                    odabrani_obracuni += "'" + tblObracuni.Rows[i][0].ToString().Trim() + "',";
                }
            }


            DataTable tblBrojRedovaJOPPD = new DataTable();
            tblBrojRedovaJOPPD.Columns.Add("VrstaObracuna", typeof(string));
            tblBrojRedovaJOPPD.Columns.Add("Mjesec", typeof(int));
            tblBrojRedovaJOPPD.Columns.Add("Godina", typeof(int));
            tblBrojRedovaJOPPD.Columns.Add("Oznaka", typeof(decimal));
            tblBrojRedovaJOPPD.Columns.Add("Iznos", typeof(decimal));
            tblBrojRedovaJOPPD.Columns.Add("Ime", typeof(string));
            tblBrojRedovaJOPPD.Columns.Add("Prezime", typeof(string));
            tblBrojRedovaJOPPD.Columns.Add("ID_Opcina", typeof(string));
            tblBrojRedovaJOPPD.Columns.Add("OIB", typeof(string));


            DataTable vrsta = client.GetDataTable("Select Sifra, VrstaObracuna From JOPPDObracunRazno Where Sifra IN (" + odabrani_obracuni + ")");
            DataTable tblRadnici = new DataTable();

            foreach (DataRow row in vrsta.Rows)
            {
                if (row["VrstaObracuna"].ToString() == "SocijalnaNaknada")
                {
                    tblRadnici = client.GetDataTable("Select VrstaObracuna, Mjesec, Godina, Oznaka, Iznos, UF_Ucenik.Ime, UF_Ucenik.Prezime, UF_Ucenik.ID_Opcina, UF_Ucenik.OIB " +
                                   "From JOPPDObracunRazno Inner Join JOPPDObracunRaznoStavke On JOPPDObracunRazno.ID = JOPPDObracunRaznoStavke.ID_JOPPDObracunRazno " +
                                   "Inner Join JOPPDOznakaNacinaIsplate On JOPPDObracunRaznoStavke.ID_JOPPDOznakaNacinaIsplate = JOPPDOznakaNacinaIsplate.ID " +
                                   "Inner Join UF_Ucenik On JOPPDObracunRaznoStavke.ID_UF_Ucenik = UF_Ucenik.ID " +
                                   "Where JOPPDObracunRazno.Sifra = '" + row["Sifra"].ToString() + "' And Oznaka In (1,2,4,6)");
                }
                else
                {
                    tblRadnici = client.GetDataTable("Select VrstaObracuna, Mjesec, Godina, Oznaka, Iznos, UF_Ucenik.Ime, UF_Ucenik.Prezime, UF_Ucenik.ID_Opcina, UF_Ucenik.OIB " +
                                   "From JOPPDObracunRazno Inner Join JOPPDObracunRaznoStavke On JOPPDObracunRazno.ID = JOPPDObracunRaznoStavke.ID_JOPPDObracunRazno " +
                                   "Inner Join JOPPDOznakaNacinaIsplate On JOPPDObracunRaznoStavke.ID_JOPPDOznakaNacinaIsplate = JOPPDOznakaNacinaIsplate.ID " +
                                   "Inner Join UF_Ucenik On JOPPDObracunRaznoStavke.ID_UF_Ucenik = UF_Ucenik.ID " +
                                   "Where JOPPDObracunRazno.Sifra = '" + row["Sifra"].ToString() + "'");
                }

                foreach (DataRow row2 in tblRadnici.Rows)
                {
                    tblBrojRedovaJOPPD.Rows.Add(row2["VrstaObracuna"].ToString(), row2["Mjesec"].ToString(), row2["Godina"].ToString(), row2["Oznaka"].ToString(), row2["Iznos"].ToString(), 
                                                row2["Ime"].ToString(), row2["Prezime"].ToString(), row2["ID_Opcina"].ToString(), row2["OIB"].ToString());
                }
            }

            foreach (DataRow radnik in tblBrojRedovaJOPPD.Rows)
            {
                element.Text = "Generiranje u tijeku...{Obračuni razno}. Molimo pričekajte...{" + redniBroj + "}";

                vrsta_obracuna = radnik["VrstaObracuna"].ToString();
                oznakaNacinaIsplate = Convert.ToDecimal(radnik["Oznaka"]);
                mjesec = Convert.ToByte(radnik["Mjesec"]);
                godina = Convert.ToInt16(radnik["Godina"]);
                oibStjecatelja = radnik["OIB"].ToString();
                sifraOpcinePrebivalista = radnik["ID_Opcina"].ToString();
                prezime = radnik["Prezime"].ToString();
                ime = radnik["Ime"].ToString();
                neoporezivPrimitak = Convert.ToDecimal(radnik["Iznos"]);

                obvezaDodatnogDoprinosa = 0;
                obvezaPosebnogDoprinosa = 0;
                oznakaMjesecaOsiguranje = 0;
                oznakaRadnogVremena = 0;
                satiRada = 0;
                primitak = 0;
                osnovica = 0;
                doprinosMirovinsko = 0;
                doprinosMirovinskoII = 0;
                doprinosZdravstveno = 0;
                doprinosZastita = 0;
                doprinosZaposljavanje = 0;
                dodatniDoprinosMirovinsko = 0;
                dodatniDoprinosMirovinskoII = 0;
                posebanDoprinosZdravstveno = 0;
                posebanDoprinosZaposljavanje = 0;
                izdatak = 0;
                izdatakDoprinosMirovinsko = 0;
                dohodak = 0;
                osobniOdbitak = 0;
                poreznaOsnovica = 0;
                porezNaDohodak = 0;
                prirez = 0;
                obracun_primitak = 0;
                sifraOpcineRada = "00000";

                if (sifraOpcinePrebivalista.Length == 0)
                {
                    MessageBox.Show("Opčina prebivališta nije dodjeljena svim osobama.\n\rDodjelite opčine i pokušajte ponovno.");
                    break;
                }

                if (vrsta_obracuna == JOPPD.Enums.Vrstaobracuna.PrijevozNezaposleni.ToString())
                {
                    oznakaStjecatelja = "0000";
                    oznakaNeoporezivogPrimitka = "27";
                    oznakaPrimitka = "0000";
                }
                else if (vrsta_obracuna == JOPPD.Enums.Vrstaobracuna.NagradeNatjecanja.ToString())
                {
                    oznakaStjecatelja = "0000";
                    oznakaNeoporezivogPrimitka = "14";
                    oznakaPrimitka = "0000";
                }
                else if (vrsta_obracuna == JOPPD.Enums.Vrstaobracuna.NagradePraksa.ToString())
                {
                    oznakaStjecatelja = "0000";
                    oznakaNeoporezivogPrimitka = "13";
                    oznakaPrimitka = "0000";
                }
                else if (vrsta_obracuna == JOPPD.Enums.Vrstaobracuna.Stipendije.ToString())
                {
                    oznakaStjecatelja = "0000";
                    oznakaNeoporezivogPrimitka = "28";
                    oznakaPrimitka = "0000";
                }
                else if (vrsta_obracuna == JOPPD.Enums.Vrstaobracuna.StudentServisNeoporezivo.ToString())
                {
                    oznakaStjecatelja = "5501";
                    oznakaNeoporezivogPrimitka = "15";
                    oznakaPrimitka = "5104";
                    osnovica = neoporezivPrimitak;
                    doprinosMirovinsko = osnovica * (IsDbNull<decimal>(GetDoprinosMirovinskoObracunRazno()) / 100);
                    doprinosZastita = osnovica * (IsDbNull<decimal>(GetDoprinosZastitaObracunRazno()) / 100);

                }
                else if (vrsta_obracuna == JOPPD.Enums.Vrstaobracuna.StudentServisOporezivo.ToString())
                {
                    oznakaStjecatelja = "5501";
                    oznakaNeoporezivogPrimitka = "0";
                    oznakaPrimitka = "5104";
                    primitak = neoporezivPrimitak;
                    neoporezivPrimitak = 0;
                    osnovica = primitak;
                    doprinosMirovinsko = osnovica * (IsDbNull<decimal>(GetDoprinosMirovinskoObracunRazno()) / 100);
                    doprinosZastita = osnovica * (IsDbNull<decimal>(GetDoprinosZastitaObracunRazno()) / 100);
                    dohodak = primitak;
                    poreznaOsnovica = primitak;
                    porezNaDohodak = poreznaOsnovica * (IsDbNull<decimal>(GetPorezObracunRazno()) / 100);
                    prirez = porezNaDohodak * (IsDbNull<decimal>(GetPrirezObracunRazno(sifraOpcinePrebivalista)) / 100);
                    isplata = dohodak - porezNaDohodak - prirez;
                }
                else if (vrsta_obracuna == JOPPD.Enums.Vrstaobracuna.SocijalnaNaknada.ToString())
                {
                    oznakaStjecatelja = "0000";
                    oznakaNeoporezivogPrimitka = "07";
                    oznakaPrimitka = "0000";

                }

                imePrezimeStjecatelja = ime + " " + prezime;

                zadnji_dan = DateTime.DaysInMonth(godina, mjesec);
                razdobljeDo = new DateTime(godina, mjesec, zadnji_dan);
                razdobljeOd = new DateTime(godina, mjesec, 1);

                isplata = neoporezivPrimitak;

                sifraOpcinePrebivalista = "0" + sifraOpcinePrebivalista;

                redniBroj++;

                tblJOPPDB.Rows.Add(this.JOPPDID.Value, redniBroj, sifraOpcinePrebivalista, sifraOpcineRada, oibStjecatelja, imePrezimeStjecatelja, oznakaStjecatelja,
                oznakaPrimitka, obvezaDodatnogDoprinosa, obvezaPosebnogDoprinosa, oznakaMjesecaOsiguranje, oznakaRadnogVremena, satiRada, neodradeniSatiRada, razdobljeOd, razdobljeDo,
                primitak, osnovica, doprinosMirovinsko, doprinosMirovinskoII, doprinosZdravstveno, doprinosZastita, doprinosZaposljavanje, dodatniDoprinosMirovinsko,
                dodatniDoprinosMirovinskoII, posebanDoprinosZdravstveno, posebanDoprinosZaposljavanje, izdatak, izdatakDoprinosMirovinsko, dohodak, osobniOdbitak,
                poreznaOsnovica, porezNaDohodak, prirez, oznakaNeoporezivogPrimitka, neoporezivPrimitak, oznakaNacinaIsplate, isplata, obracun_primitak);
            }
            return redniBroj;
        }

        private int GenerirajJOPPDPutniNalogStranicaB(JOPPD.frmWaitProgress element, int redniBroj, ref DataTable tblJOPPDB)
        {
            string sifraOpcinePrebivalista = string.Empty;
            string sifraOpcineRada = string.Empty;
            string oibStjecatelja = string.Empty;
            string imePrezimeStjecatelja = string.Empty;
            string oznakaStjecatelja = string.Empty;
            string oznakaPrimitka = string.Empty;
            decimal obvezaDodatnogDoprinosa = 0;
            decimal obvezaPosebnogDoprinosa = 0;
            decimal oznakaMjesecaOsiguranje = 0;
            decimal oznakaRadnogVremena = 0;
            decimal satiRada = 0;
            decimal neodradeniSatiRada = 0;
            DateTime razdobljeOd = DateTime.MinValue;
            DateTime razdobljeDo = DateTime.MinValue;
            decimal primitak = 0;
            decimal osnovica = 0;
            decimal doprinosMirovinsko = 0;
            decimal doprinosMirovinskoII = 0;
            decimal doprinosZdravstveno = 0;
            decimal doprinosZastita = 0;
            decimal doprinosZaposljavanje = 0;
            decimal dodatniDoprinosMirovinsko = 0;
            decimal dodatniDoprinosMirovinskoII = 0;
            decimal posebanDoprinosZdravstveno = 0;
            decimal posebanDoprinosZaposljavanje = 0;
            decimal izdatak = 0;
            decimal izdatakDoprinosMirovinsko = 0;
            decimal dohodak = 0;
            decimal osobniOdbitak = 0;
            decimal poreznaOsnovica = 0;
            decimal porezNaDohodak = 0;
            decimal prirez = 0;
            string oznakaNeoporezivogPrimitka = string.Empty;
            decimal neoporezivPrimitak = 0;
            decimal oznakaNacinaIsplate = 0;
            decimal isplata = 0;
            decimal obracun_primitak = 0;
            string id_radnik = "";
            int zadnji_dan = 0;
            string id_nacin_isplate = "";
            string vlastit_trosak = string.Empty;
            string vrsta_djelatnika = string.Empty;
            string dnevnica = string.Empty;

            // Get IDOBRACUN
            string odabrani_obracuni = string.Empty;
            DataTable tblObracuni = client.GetDataTable("Select Obracun_ID From JOPPDAObracun Where JOPPDA_ID = '" + JOPPDID.Value + "' And Vrsta = 2");
            int broj_obracuna = tblObracuni.Rows.Count;
            for (int i = 0; i < tblObracuni.Rows.Count; i++)
            {
                broj_obracuna--;
                if (broj_obracuna == 0)
                {
                    odabrani_obracuni += "'" + tblObracuni.Rows[i][0].ToString().Trim() + "'";
                }
                else
                {
                    odabrani_obracuni += "'" + tblObracuni.Rows[i][0].ToString().Trim() + "',";
                }
            }

            DataTable tblRadnici = client.GetDataTable("SELECT DISTINCT ID_Radnik, ID_NacinIsplate, VrstaDjelatnika From RegistarPutnihNaloga Where ID IN (" + odabrani_obracuni + ") And DatumObracuna is not null");

            DataTable tblBrojRedovaJOPPD = new DataTable();
            tblBrojRedovaJOPPD.Columns.Add("ID_Radnik", typeof(int));
            tblBrojRedovaJOPPD.Columns.Add("ID_NacinIsplate", typeof(int));
            tblBrojRedovaJOPPD.Columns.Add("TroskoviVlastitogVozila", typeof(bool));
            tblBrojRedovaJOPPD.Columns.Add("VrstaDjelatnika", typeof(string));
            tblBrojRedovaJOPPD.Columns.Add("Dnevnica", typeof(bool));

            foreach (DataRow red in tblRadnici.Rows)
            {
                if (client.ExecuteScalar("Select Neprofitni From Korisnik").ToString() != "True")
                {
                    if (ProvjeraVlastitogVozila(red["ID_Radnik"].ToString(), red["ID_NacinIsplate"].ToString(), odabrani_obracuni))
                    {
                        tblBrojRedovaJOPPD.Rows.Add(red["ID_Radnik"].ToString(), red["ID_NacinIsplate"].ToString(), true, red["VrstaDjelatnika"].ToString(), false);
                    }
                    if (ProvjeraDnevnice(red["ID_Radnik"].ToString(), red["ID_NacinIsplate"].ToString(), odabrani_obracuni))
                    {
                        tblBrojRedovaJOPPD.Rows.Add(red["ID_Radnik"].ToString(), red["ID_NacinIsplate"].ToString(), false, red["VrstaDjelatnika"].ToString(), true);
                    }
                }
                else
                {
                    tblBrojRedovaJOPPD.Rows.Add(red["ID_Radnik"].ToString(), red["ID_NacinIsplate"].ToString(), true, red["VrstaDjelatnika"].ToString(), true);
                }
            }


            foreach (DataRow radnik in tblBrojRedovaJOPPD.Rows)
            {
                element.Text = "Generiranje u tijeku...{Putni nalozi}. Molimo pričekajte...{" + redniBroj + "}";

                id_radnik = radnik["ID_Radnik"].ToString();
                id_nacin_isplate = radnik["ID_NacinIsplate"].ToString();
                vlastit_trosak = radnik["TroskoviVlastitogVozila"].ToString();
                vrsta_djelatnika = radnik["VrstaDjelatnika"].ToString();
                dnevnica = radnik["Dnevnica"].ToString();

                oznakaStjecatelja = "0000";
                oznakaPrimitka = "0000";
                obvezaDodatnogDoprinosa = 0;
                obvezaPosebnogDoprinosa = 0;
                oznakaMjesecaOsiguranje = 0;
                oznakaRadnogVremena = 0;
                satiRada = 0;
                primitak = 0;
                osnovica = 0;
                doprinosMirovinsko = 0;
                doprinosMirovinskoII = 0;
                doprinosZdravstveno = 0;
                doprinosZastita = 0;
                doprinosZaposljavanje = 0;
                dodatniDoprinosMirovinsko = 0;
                dodatniDoprinosMirovinskoII = 0;
                posebanDoprinosZdravstveno = 0;
                posebanDoprinosZaposljavanje = 0;
                izdatak = 0;
                izdatakDoprinosMirovinsko = 0;
                dohodak = 0;
                osobniOdbitak = 0;
                poreznaOsnovica = 0;
                porezNaDohodak = 0;
                prirez = 0;

                //else
                //{
                //    oznakaNeoporezivogPrimitka = "52";
                //}

                if (vlastit_trosak == "True")
                {
                    oznakaNeoporezivogPrimitka = "18";
                }

                if (dnevnica == "True")
                {
                    oznakaNeoporezivogPrimitka = "17";
                }

                if (client.ExecuteScalar("Select Neprofitni From Korisnik").ToString() == "True")
                {
                    oznakaNeoporezivogPrimitka = "52";
                }

                obracun_primitak = 0;

                if (vrsta_djelatnika == "1")
                {
                    sifraOpcinePrebivalista = "0" + IsDbNull<string>(GetOpcinaPrebivalistePutniNalog(id_radnik, "OPCINASTANOVANJAIDOPCINE", "RADNIK", "IDRADNIK"));
                    sifraOpcineRada = "0" + IsDbNull<string>(GetOpcinaRadaPutniNalog(id_radnik, "OPCINARADAIDOPCINE", "RADNIK", "IDRADNIK"));
                    oibStjecatelja = IsDbNull<string>(GetOIBPutniNalog(id_radnik, "OIB", "RADNIK", "IDRADNIK"));
                    imePrezimeStjecatelja = IsDbNull<string>(GetDataFromTableByID("IME + ' ' + PREZIME as ImePrezime", "RADNIK", string.Format("IDRADNIK = {0}", id_radnik)));
                }
                else if (vrsta_djelatnika == "2")
                {
                    sifraOpcinePrebivalista = "0" + IsDbNull<string>(GetOpcinaPrebivalistePutniNalog(id_radnik, "OPCINASTANOVANJAIDOPCINE", "DDRADNIK", "DDIDRADNIK"));
                    sifraOpcineRada = "0" + IsDbNull<string>(GetOpcinaRadaPutniNalog(id_radnik, "OPCINARADAIDOPCINE", "DDRADNIK", "DDIDRADNIK"));
                    oibStjecatelja = IsDbNull<string>(GetOIBPutniNalog(id_radnik, "DDOIB", "DDRADNIK", "DDIDRADNIK"));
                    imePrezimeStjecatelja = IsDbNull<string>(GetDataFromTableByID("DDIME + ' ' + DDPREZIME as ImePrezime", "DDRADNIK", string.Format("DDIDRADNIK = {0}", id_radnik)));
                }

                DateTime datum = IsDbNull<DateTime>(GetDatumPutniNalog(id_radnik, odabrani_obracuni));
                zadnji_dan = DateTime.DaysInMonth(datum.Year, datum.Month);
                razdobljeDo = new DateTime(datum.Year, datum.Month, zadnji_dan);
                razdobljeOd = new DateTime(datum.Year, datum.Month, 1);

                neoporezivPrimitak = IsDbNull<decimal>(GetNeoporeziviPrimitakPutniNalog(id_radnik, id_nacin_isplate, vlastit_trosak, odabrani_obracuni, dnevnica));

                oznakaNacinaIsplate = IsDbNull<decimal>(GetNacinIsplate(id_nacin_isplate));

                isplata = neoporezivPrimitak;

                if (neoporezivPrimitak != 0)
                {
                    redniBroj++;

                    tblJOPPDB.Rows.Add(this.JOPPDID.Value, redniBroj, sifraOpcinePrebivalista, sifraOpcineRada, oibStjecatelja, imePrezimeStjecatelja, oznakaStjecatelja,
                    oznakaPrimitka, obvezaDodatnogDoprinosa, obvezaPosebnogDoprinosa, oznakaMjesecaOsiguranje, oznakaRadnogVremena, satiRada, neodradeniSatiRada, razdobljeOd, razdobljeDo,
                    primitak, osnovica, doprinosMirovinsko, doprinosMirovinskoII, doprinosZdravstveno, doprinosZastita, doprinosZaposljavanje, dodatniDoprinosMirovinsko,
                    dodatniDoprinosMirovinskoII, posebanDoprinosZdravstveno, posebanDoprinosZaposljavanje, izdatak, izdatakDoprinosMirovinsko, dohodak, osobniOdbitak,
                    poreznaOsnovica, porezNaDohodak, prirez, oznakaNeoporezivogPrimitka, neoporezivPrimitak, oznakaNacinaIsplate, isplata, obracun_primitak);
                }
            }
            return redniBroj;
        }

        private int GenerirajJOPPDVirmanInvalidi(JOPPD.frmWaitProgress element, int redniBroj, ref DataTable tblJOPPDB)
        {
            return 0;
        }
        
        /// <summary>
        /// Generiranje svih podataka potrebnih za stranicu B place
        /// </summary>
        public int GenerirajJOPPDPlaceVolonteriStranicaB(int redniBroj, ref DataTable tblJOPPDB, bool cop, string id_obracun_cop, int? id_joppda, string file_name)
        {
           
            // Get IDOBRACUN
            string odabrani_obracuni = string.Empty;
            if (!cop)
            {
                DataTable tblObracuni = client.GetDataTable("Select Obracun_ID From JOPPDAObracun Where JOPPDA_ID = '" + JOPPDID.Value + "' And Vrsta = 0");
                int broj_obracuna = tblObracuni.Rows.Count;
                for (int i = 0; i < tblObracuni.Rows.Count; i++)
                {
                    broj_obracuna--;
                    if (broj_obracuna == 0)
                    {
                        odabrani_obracuni += "'" + tblObracuni.Rows[i][0].ToString().Trim() + "'";
                    }
                    else
                    {
                        odabrani_obracuni += "'" + tblObracuni.Rows[i][0].ToString().Trim() + "',";
                    }
                }
            }
            else
            {
                odabrani_obracuni = "'" + id_obracun_cop + "'";
            }

            string sifraOpcinePrebivalista = string.Empty;
            string sifraOpcineRada = string.Empty;
            string oibStjecatelja = string.Empty;
            string imePrezimeStjecatelja = string.Empty;
            string oznakaStjecatelja = string.Empty;
            string oznakaPrimitka = string.Empty;
            decimal obvezaDodatnogDoprinosa = 0;
            decimal obvezaPosebnogDoprinosa = 0;
            decimal oznakaMjesecaOsiguranje = 0;
            decimal oznakaRadnogVremena = 0;
            decimal satiRada = 0;
            decimal neodradeniSatiRada = 0;
            DateTime razdobljeOd = DateTime.Now;
            DateTime razdobljeDo = DateTime.Now;
            decimal primitak = 0;
            decimal osnovica = 0;
            decimal doprinosMirovinsko = 0;
            decimal doprinosMirovinskoII = 0;
            decimal doprinosZdravstveno = 0;
            decimal doprinosZastita = 0;
            decimal doprinosZaposljavanje = 0;
            decimal dodatniDoprinosMirovinsko = 0;
            decimal dodatniDoprinosMirovinskoII = 0;
            decimal posebanDoprinosZdravstveno = 0;
            decimal posebanDoprinosZaposljavanje = 0;
            decimal izdatak = 0;
            decimal izdatakDoprinosMirovinsko = 0;
            decimal dohodak = 0;
            decimal osobniOdbitak = 0;
            decimal poreznaOsnovica = 0;
            decimal porezNaDohodak = 0;
            decimal prirez = 0;
            string oznakaNeoporezivogPrimitka = string.Empty;
            decimal neoporezivPrimitak = 0;
            decimal oznakaNacinaIsplate = 0;
            decimal isplata = 0;
            decimal obracun_primitak = 0;

            int radnikID = 0;
            int elementID = 0;
            int doprinosID = 0;
            decimal doprinosStopa = 0;
            decimal tjedniFondSati = 0;
            bool njegaDjeteta = false;
            bool koristenjeMinimalneMaksimalneOsnovice = false;
            int cop_counter = 0;
            string old_oib_cop = "";

            DataTable tblRadnici = client.GetDataTable("Select Distinct ObracunElementi.IDOBRACUN, ObracunElementi.IDRADNIK, ObracunElementi.IDVRSTAELEMENTA, ObracunElementi.OznakaMjeseca, Radnik.IDIPIDENT, " +
                                                       "RADNIK.RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA From ObracunElementi Inner Join RADNIK ON ObracunElementi.IDRADNIK = RADNIK.IDRADNIK " +
                                                       "Where IDOBRACUN IN (" + odabrani_obracuni + ")");

            DataTable tblBrojRedovaJOPPD = new DataTable();
            tblBrojRedovaJOPPD.Columns.Add("IDRADNIK", typeof(int));
            tblBrojRedovaJOPPD.Columns.Add("IznosPrimitka", typeof(decimal));
            tblBrojRedovaJOPPD.Columns.Add("IDELEMENTA", typeof(int));
            tblBrojRedovaJOPPD.Columns.Add("IPIDENT", typeof(int));
            tblBrojRedovaJOPPD.Columns.Add("SKUPINAPOREZA", typeof(int));
            tblBrojRedovaJOPPD.Columns.Add("ObracunID", typeof(string));
            tblBrojRedovaJOPPD.Columns.Add("OznakaMjeseca", typeof(int));

            int id_radnik = 0;
            decimal iznos_primitka = 0;
            string obracun_id = string.Empty;

            int id_vrsta_elementa = 0;
            int oznaka_mjeseca = 0;
            string sqlQuery = string.Empty;
            int id_skupina_poreza = 0;
            int id_ip_identfikatora = 0;
            decimal? iznos_obracun_elemnta = null;

            DataTable tblObracunElementi = client.GetDataTable("Select ObracunElementi.IDOBRACUN, ObracunElementi.OBRIZNOS, ObracunElementi.IDRADNIK, JOPPDOznakaPrimitkaElement.JOPPDOznakaPrimitkaID, " +
                                            "JOPPDOznakaNacinaIsplateElement.JOPPDOznakaNacinaIsplateID, JOPPDOznakaStjecateljaPrimitkaElement.JOPPDOznakaStjecateljaPrimitkaID, " +
                                            "JOPPDOznakaNeoporezivogPrimitkaElement.JOPPDOznakaNeoporezivogPrimitkaID, ObracunElementi.IDELEMENT, ObracunElementi.IDVRSTAELEMENTA From ObracunElementi " +
                                            "Inner Join JOPPDOznakaPrimitkaElement ON ObracunElementi.IDELEMENT = JOPPDOznakaPrimitkaElement.IDELEMENT " +
                                            "Inner Join JOPPDOznakaNacinaIsplateElement ON ObracunElementi.IDELEMENT = JOPPDOznakaNacinaIsplateElement.IDELEMENT " +
                                            "Inner Join JOPPDOznakaStjecateljaPrimitkaElement ON ObracunElementi.IDELEMENT = JOPPDOznakaStjecateljaPrimitkaElement.IDELEMENT " +
                                            "Inner Join JOPPDOznakaNeoporezivogPrimitkaElement ON ObracunElementi.IDELEMENT = JOPPDOznakaNeoporezivogPrimitkaElement.IDELEMENT " +
                                            "Where IDOBRACUN IN (" + odabrani_obracuni + ")");

            
            #region dohvat redova

            foreach (DataRow radnik in tblRadnici.Rows)
            {
                id_radnik = IsDbNull<int>(radnik["IDRADNIK"]);
                obracun_id = radnik["IDOBRACUN"].ToString();
                id_vrsta_elementa =  IsDbNull<int>(radnik["IDVRSTAELEMENTA"]);
                oznaka_mjeseca = IsDbNull<int>(radnik["OznakaMjeseca"]);
                id_skupina_poreza = IsDbNull<int>(radnik["RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA"]);
                id_ip_identfikatora = IsDbNull<int>(radnik["IDIPIDENT"]);

                elementID = IsDbNull<int>(client.ExecuteScalar("Select IDELEMENT From ObracunElementi Where IDOBRACUN IN (" + odabrani_obracuni + ") And IDRADNIK = '" + id_radnik +
                                                               "' And IDVRSTAELEMENTA = '" + id_vrsta_elementa + "' And OznakaMjeseca = '" + oznaka_mjeseca + "'"));

                if (id_vrsta_elementa == 2)
                {
                    iznos_obracun_elemnta = IsDbNull<decimal>(client.ExecuteScalar("Select Sum(OBRIZNOS) From ObracunElementi Where IDOBRACUN IN (" + odabrani_obracuni + ") And IDRADNIK = '" + id_radnik +
                                                                                   "' And IDVRSTAELEMENTA = '" + id_vrsta_elementa + "' And OznakaMjeseca = '" + oznaka_mjeseca + "'"));
                }
                else
                {
                    iznos_obracun_elemnta = IsDbNull<decimal>(client.ExecuteScalar("Select OBRIZNOS From ObracunElementi Where IDOBRACUN IN (" + odabrani_obracuni + ") And IDRADNIK = '" + id_radnik +
                                                                                   "' And IDVRSTAELEMENTA = '" + id_vrsta_elementa + "' And OznakaMjeseca = '" + oznaka_mjeseca + "'"));
                }

                tblBrojRedovaJOPPD.Rows.Add(id_radnik, iznos_obracun_elemnta, elementID, id_ip_identfikatora, id_skupina_poreza, obracun_id, oznaka_mjeseca);
            }


            #endregion
            broj_redaka = tblBrojRedovaJOPPD.Rows.Count;
            // za sve radnike i elemente u obračunu, generiramo podatke za B stranicu
            foreach (DataRow radnikElement in tblBrojRedovaJOPPD.Rows)
            {
                redniBroj++;
                
                radnikID = (int)radnikElement["IDRADNIK"];

                elementID = (int)radnikElement["IDELEMENTA"];
                iznos_primitka = (decimal)radnikElement["IznosPrimitka"];
                obracun_id = radnikElement["ObracunID"].ToString();
                oznaka_mjeseca = IsDbNull<int>(radnikElement["OznakaMjeseca"]);

                sifraOpcinePrebivalista = "0" + IsDbNull<string>(GetDataFromObracunByRadnikID("SIFRAOPCINESTANOVANJA", "ObracunRadnici", obracun_id, radnikID));
                oibStjecatelja = IsDbNull<string>(GetDataFromTableByID("OIB", "RADNIK", string.Format("IDRADNIK = {0}", radnikID)));
                imePrezimeStjecatelja = IsDbNull<string>(GetDataFromTableByID("IME + ' ' + PREZIME as ImePrezime", "RADNIK", string.Format("IDRADNIK = {0}", radnikID)));
                satiRada = IsDbNull<decimal>(GetSatiRadiByRadnikIDElementID("OBRSATI", obracun_id, radnikID, elementID));
                razdobljeOd = IsDbNull<DateTime>(GetDataFromObracunElementByRadnikIDElementIDRazdobljeMin("ELEMENTRAZDOBLJEOD", obracun_id, radnikID, elementID));
                razdobljeDo = IsDbNull<DateTime>(GetDataFromObracunElementByRadnikIDElementIDRazdobljeMax("ELEMENTRAZDOBLJEDO", obracun_id, radnikID, elementID));

                oznakaMjesecaOsiguranje = oznaka_mjeseca;

                neodradeniSatiRada = IsDbNull<decimal>(GetNeodradeniSatiRada(obracun_id, radnikID, elementID));


                //podesavanje iznaka za cop
                if (old_oib_cop.Length == 0)
                {
                    cop_counter = 0;
                    old_oib_cop = oibStjecatelja;
                }
                else if (old_oib_cop == oibStjecatelja)
                {
                    cop_counter++;
                }
                else if (old_oib_cop != oibStjecatelja)
                {
                    cop_counter = 0;
                    old_oib_cop = oibStjecatelja;
                }


                #region stalno_zaposleni_sa_pk_karticom_kod_poslodavca(ip = 3 po sudskim rijesenjima)
                if ((int)radnikElement["IPIDENT"] == 1 | (int)radnikElement["IPIDENT"] == 3)
                {
                    oznakaStjecatelja = GetOznakaStjecateljaPrimitkaByElementId(elementID, cop, file_name, oibStjecatelja, cop_counter);
                    oznakaPrimitka = GetOznakaPrimitkaByElementId(elementID, cop, file_name, oibStjecatelja, cop_counter);

                    obvezaDodatnogDoprinosa = IsDbNull<decimal>(GetDataFromTableByID("IDBENEFICIRANI", "RADNIK", string.Format("IDRADNIK = {0}", radnikID)));

                    doprinosID = 6;
                    doprinosStopa = IsDbNull<decimal>(GetDataFromTableByID("STOPA", "DOPRINOS", string.Format("IDDOPRINOS = {0}", doprinosID)));

                    if (doprinosStopa == 0.0M)
                        obvezaPosebnogDoprinosa = 0;
                    else if (doprinosStopa == 0.1M)
                        obvezaPosebnogDoprinosa = 1;
                    else if (doprinosStopa == 0.2M)
                        obvezaPosebnogDoprinosa = 2;


                    tjedniFondSati = IsDbNull<decimal>(GetDataFromTableByID("TJEDNIFONDSATI", "RADNIK", string.Format("IDRADNIK = {0}", radnikID)));
                    //njegaDjeteta = IsDbNull<bool>(GetDataFromTableByID("NJEGADJETETA", "RADNIK", string.Format("IDRADNIK = {0}", radnikID)));

                    if (tjedniFondSati == 0)
                        oznakaRadnogVremena = 0;
                    else if (tjedniFondSati == 40)
                        oznakaRadnogVremena = 1;
                    else if (0 < tjedniFondSati && tjedniFondSati < 40)
                        oznakaRadnogVremena = 2;
                    else if (njegaDjeteta)
                        oznakaRadnogVremena = 3;

                    primitak = IsDbNull<decimal>(GetDataFromObracunElementByRadnikIDElementIDPrimitak("OBRIZNOS", obracun_id, radnikID, elementID));

                    koristenjeMinimalneMaksimalneOsnovice = IsDbNull<bool>(GetDataFromTableByID("UZIMAUOBZIROSNOVICEDOPRINOSA", "RADNIK", string.Format("IDRADNIK = {0}", radnikID)));

                    if (koristenjeMinimalneMaksimalneOsnovice)
                    {
                        decimal minDoprinos = IsDbNull<decimal>(GetDataFromTableByID("MINDOPRINOS", "DOPRINOS", "IDDOPRINOS = 1"));
                        decimal maxDoprinos = IsDbNull<decimal>(GetDataFromTableByID("MAXDOPRINOS", "DOPRINOS", "IDDOPRINOS = 7"));

                        if (minDoprinos > primitak)
                            osnovica = minDoprinos;
                        else if (maxDoprinos > primitak)
                            osnovica = maxDoprinos;
                        else
                            osnovica = primitak;
                    }
                    else
                    {
                        osnovica = primitak;
                    }

                    sqlQuery = "Select Distinct IDVRSTAELEMENTA From ObracunElementi Where IDELEMENT = '" + elementID + "' And IDRADNIK = '" + radnikID + "' And IDOBRACUN = '" + obracun_id + "'";
                    id_vrsta_elementa = Convert.ToInt32(client.ExecuteScalar(sqlQuery));

                    if (id_vrsta_elementa == 2)
                    {
                        doprinosMirovinsko = IsDbNull<decimal>(GetDoprinosMirovinski("SUM(OBRACUNATIDOPRINOS)", obracun_id, radnikID));

                        doprinosMirovinskoII = IsDbNull<decimal>(GetDoprinosMirovinski2("SUM(OBRACUNATIDOPRINOS)", obracun_id, radnikID));

                        doprinosZdravstveno = IsDbNull<decimal>(GetDoprinosZdravstveno("SUM(OBRACUNATIDOPRINOS)", obracun_id, radnikID));

                        doprinosZastita = IsDbNull<decimal>(GetDoprinosZastita("SUM(OBRACUNATIDOPRINOS)", obracun_id, radnikID));

                        doprinosZaposljavanje = IsDbNull<decimal>(GetDoprinosZaposljavanje("SUM(OBRACUNATIDOPRINOS)", obracun_id, radnikID));

                        posebanDoprinosZaposljavanje = IsDbNull<decimal>(GetPosebanDoprinosZaposljavanje("OBRACUNATIDOPRINOS", obracun_id, radnikID));

                        dodatniDoprinosMirovinsko = 0;
                        dodatniDoprinosMirovinskoII = 0;
                        posebanDoprinosZdravstveno = 0;
                        izdatak = 0;

                        izdatakDoprinosMirovinsko = doprinosMirovinsko + doprinosMirovinskoII;
                        dohodak = primitak - izdatakDoprinosMirovinsko;
                        if (IsDbNull<decimal>(GetDataFromObracunByRadnikID("ODBITAKPRIJEKOREKCIJE", "ObracunRadnici", obracun_id, radnikID)) > 0)
                        {
                            osobniOdbitak = IsDbNull<decimal>(GetDataFromObracunByRadnikID("ODBITAKPRIJEKOREKCIJE", "ObracunRadnici", obracun_id, radnikID));
                        }
                        else
                        {
                            osobniOdbitak = IsDbNull<decimal>(GetDataFromObracunByRadnikID("ISKORISTENOOO", "ObracunRadnici", obracun_id, radnikID));
                        }
                        poreznaOsnovica = dohodak - osobniOdbitak;
                        porezNaDohodak = IsDbNull<decimal>(GetDataFromObracunByRadnikID("SUM(OBRACUNATIPOREZ)", "ObracunPorezi", obracun_id, radnikID));
                        prirez = IsDbNull<decimal>(GetDataFromObracunByRadnikID("SUM(OBRACUNATIPRIREZ)", "ObracunRadnici", obracun_id, radnikID));

                        oznakaNeoporezivogPrimitka = "0";
                        neoporezivPrimitak = 0;

                        oznakaNacinaIsplate = GetOznakaNacinaIsplateByElementId(elementID, cop, file_name, oibStjecatelja, cop_counter);
                        isplata = IsDbNull<decimal>(GetDataFromTableByID("NETOPLACA", "VW_PLACA_ZAPOSLENIK_UKUPNO", string.Format("IDOBRACUN = '{0}' AND IDRADNIK = {1}", obracun_id, radnikID)));

                        obracun_primitak = osnovica;
                    }
                    else
                    {
                        doprinosMirovinsko = 0;
                        doprinosMirovinskoII = 0;
                        doprinosZdravstveno = 0;
                        doprinosZastita = 0;
                        doprinosZaposljavanje = 0;
                        posebanDoprinosZaposljavanje = 0;
                        dodatniDoprinosMirovinsko = 0;
                        dodatniDoprinosMirovinskoII = 0;
                        posebanDoprinosZdravstveno = 0;
                        izdatak = 0;
                        izdatakDoprinosMirovinsko = 0;
                        dohodak = 0;
                        osobniOdbitak = 0;
                        poreznaOsnovica = 0;
                        porezNaDohodak = 0;
                        prirez = 0;
                        oznakaNacinaIsplate = GetOznakaNacinaIsplateByElementId(elementID, cop, file_name, oibStjecatelja, cop_counter);
                        oznakaNeoporezivogPrimitka = GetOznakaNeoporezivogPrimitkaByElementId(elementID, cop, file_name, oibStjecatelja, cop_counter);
                        neoporezivPrimitak = iznos_primitka;
                        isplata = iznos_primitka;

                        obracun_primitak = osnovica;
                    }
                }
                #endregion
                
                #region stalno zaposleni sa nepunim radnim veremenom (pk kartica nije kod poslodavca)
                else if ((int)radnikElement["IPIDENT"] == 2)
                {
                    oznakaStjecatelja = GetOznakaStjecateljaPrimitkaByElementId(elementID, cop, file_name, oibStjecatelja, cop_counter);
                    oznakaPrimitka = GetOznakaPrimitkaByElementId(elementID, cop, file_name, oibStjecatelja, cop_counter);

                    obvezaDodatnogDoprinosa = IsDbNull<decimal>(GetDataFromTableByID("IDBENEFICIRANI", "RADNIK", string.Format("IDRADNIK = {0}", radnikID)));

                    doprinosID = 6;
                    doprinosStopa = IsDbNull<decimal>(GetDataFromTableByID("STOPA", "DOPRINOS", string.Format("IDDOPRINOS = {0}", doprinosID)));

                    if (doprinosStopa == 0.0M)
                        obvezaPosebnogDoprinosa = 0;
                    else if (doprinosStopa == 0.1M)
                        obvezaPosebnogDoprinosa = 1;
                    else if (doprinosStopa == 0.2M)
                        obvezaPosebnogDoprinosa = 2;

                    tjedniFondSati = IsDbNull<decimal>(GetDataFromTableByID("TJEDNIFONDSATI", "RADNIK", string.Format("IDRADNIK = {0}", radnikID)));
                    //njegaDjeteta = IsDbNull<bool>(GetDataFromTableByID("NJEGADJETETA", "RADNIK", string.Format("IDRADNIK = {0}", radnikID)));

                    if (tjedniFondSati == 0)
                        oznakaRadnogVremena = 0;
                    else if (tjedniFondSati == 40)
                        oznakaRadnogVremena = 1;
                    else if (0 < tjedniFondSati && tjedniFondSati < 40)
                        oznakaRadnogVremena = 2;
                    else if (njegaDjeteta)
                        oznakaRadnogVremena = 3;

                    primitak = IsDbNull<decimal>(GetDataFromObracunElementByRadnikIDElementIDPrimitak("OBRIZNOS", obracun_id, radnikID, elementID));

                    koristenjeMinimalneMaksimalneOsnovice = IsDbNull<bool>(GetDataFromTableByID("UZIMAUOBZIROSNOVICEDOPRINOSA", "RADNIK", string.Format("IDRADNIK = {0}", radnikID)));

                    if (koristenjeMinimalneMaksimalneOsnovice)
                    {
                        decimal minDoprinos = IsDbNull<decimal>(GetDataFromTableByID("MINDOPRINOS", "DOPRINOS", "IDDOPRINOS = 1"));
                        decimal maxDoprinos = IsDbNull<decimal>(GetDataFromTableByID("MAXDOPRINOS", "DOPRINOS", "IDDOPRINOS = 7"));

                        if (minDoprinos > primitak)
                            osnovica = minDoprinos;
                        else if (maxDoprinos > primitak)
                            osnovica = maxDoprinos;
                        else
                            osnovica = primitak;
                    }
                    else
                    {
                        osnovica = primitak;
                    }

                    sqlQuery = "Select Distinct IDVRSTAELEMENTA From ObracunElementi Where IDELEMENT = '" + elementID + "' And IDRADNIK = '" + radnikID + "' And IDOBRACUN = '" + obracun_id + "'";
                    id_vrsta_elementa = Convert.ToInt32(client.ExecuteScalar(sqlQuery));

                    if (id_vrsta_elementa == 2)
                    {
                        doprinosMirovinsko = IsDbNull<decimal>(GetDoprinosMirovinski("SUM(OBRACUNATIDOPRINOS)", obracun_id, radnikID));

                        doprinosMirovinskoII = IsDbNull<decimal>(GetDoprinosMirovinski2("SUM(OBRACUNATIDOPRINOS)", obracun_id, radnikID));
                        doprinosZdravstveno = IsDbNull<decimal>(GetDoprinosZdravstveno("SUM(OBRACUNATIDOPRINOS)", obracun_id, radnikID));
                        doprinosZastita = IsDbNull<decimal>(GetDoprinosZastita("SUM(OBRACUNATIDOPRINOS)", obracun_id, radnikID));
                        doprinosZaposljavanje = IsDbNull<decimal>(GetDoprinosZaposljavanje("SUM(OBRACUNATIDOPRINOS)", obracun_id, radnikID));
                        posebanDoprinosZaposljavanje = IsDbNull<decimal>(GetPosebanDoprinosZaposljavanje("OBRACUNATIDOPRINOS", obracun_id, radnikID));

                        dodatniDoprinosMirovinsko = 0;
                        dodatniDoprinosMirovinskoII = 0;
                        posebanDoprinosZdravstveno = 0;
                        izdatak = 0;

                        izdatakDoprinosMirovinsko = doprinosMirovinsko + doprinosMirovinskoII;
                        dohodak = primitak - izdatakDoprinosMirovinsko;
                        osobniOdbitak = 0;
                        poreznaOsnovica = dohodak - osobniOdbitak;
                        porezNaDohodak = IsDbNull<decimal>(GetDataFromObracunByRadnikID("SUM(OBRACUNATIPOREZ)", "ObracunPorezi", obracun_id, radnikID));
                        prirez = IsDbNull<decimal>(GetDataFromObracunByRadnikID("SUM(OBRACUNATIPRIREZ)", "ObracunRadnici", obracun_id, radnikID));

                        oznakaNeoporezivogPrimitka = "0";
                        neoporezivPrimitak = 0;

                        oznakaNacinaIsplate = GetOznakaNacinaIsplateByElementId(elementID, cop, file_name, oibStjecatelja, cop_counter);
                        isplata = IsDbNull<decimal>(GetDataFromTableByID("NETOPLACA", "VW_PLACA_ZAPOSLENIK_UKUPNO", string.Format("IDOBRACUN = '{0}' AND IDRADNIK = {1}", obracun_id, radnikID)));

                        obracun_primitak = osnovica;
                    }
                    else
                    {
                        doprinosMirovinsko = 0;
                        doprinosMirovinskoII = 0;
                        doprinosZdravstveno = 0;
                        doprinosZastita = 0;
                        doprinosZaposljavanje = 0;
                        posebanDoprinosZaposljavanje = 0;
                        dodatniDoprinosMirovinsko = 0;
                        dodatniDoprinosMirovinskoII = 0;
                        posebanDoprinosZdravstveno = 0;
                        izdatak = 0;
                        izdatakDoprinosMirovinsko = 0;
                        dohodak = 0;
                        osobniOdbitak = 0;
                        poreznaOsnovica = 0;
                        porezNaDohodak = 0;
                        prirez = 0;
                        oznakaNacinaIsplate = GetOznakaNacinaIsplateByElementId(elementID, cop, file_name, oibStjecatelja, cop_counter);
                        oznakaNeoporezivogPrimitka = GetOznakaNeoporezivogPrimitkaByElementId(elementID, cop, file_name, oibStjecatelja, cop_counter);
                        neoporezivPrimitak = iznos_primitka;
                        isplata = iznos_primitka;

                        obracun_primitak = osnovica;
                    }
                }
                #endregion

                #region volonteri
                else if ((int)radnikElement["IPIDENT"] == 11)
                {
                    if ((int)radnikElement["SKUPINAPOREZA"] == 96)
                    {
                        oznakaStjecatelja = GetOznakaStjecateljaPrimitkaByElementId(elementID, cop, file_name, oibStjecatelja, cop_counter);
                        oznakaPrimitka = "5703";

                        obvezaDodatnogDoprinosa = 0;
                        obvezaPosebnogDoprinosa = 0;

                        doprinosID = 6;
                        doprinosStopa = IsDbNull<decimal>(GetDataFromTableByID("STOPA", "DOPRINOS", string.Format("IDDOPRINOS = {0}", doprinosID)));

                        tjedniFondSati = IsDbNull<decimal>(GetDataFromTableByID("TJEDNIFONDSATI", "RADNIK", string.Format("IDRADNIK = {0}", radnikID)));
                        //njegaDjeteta = IsDbNull<bool>(GetDataFromTableByID("NJEGADJETETA", "RADNIK", string.Format("IDRADNIK = {0}", radnikID)));

                        if (tjedniFondSati == 0)
                            oznakaRadnogVremena = 0;
                        else if (tjedniFondSati == 40)
                            oznakaRadnogVremena = 1;
                        else if (0 < tjedniFondSati && tjedniFondSati < 40)
                            oznakaRadnogVremena = 2;
                        else if (njegaDjeteta)
                            oznakaRadnogVremena = 3;

                        primitak = 0;

                        osnovica = IsDbNull<decimal>(OsnovicaVolonteri("OBRIZNOS", "ObracunElementi", radnikID, obracun_id));

                        sqlQuery = "Select Distinct IDVRSTAELEMENTA From ObracunElementi Where IDELEMENT = '" + elementID + "' And IDRADNIK = '" + radnikID + "' And IDOBRACUN = '" + obracun_id + "'";
                        id_vrsta_elementa = Convert.ToInt32(client.ExecuteScalar(sqlQuery));

                        if (id_vrsta_elementa == 2)
                        {
                            doprinosMirovinsko = IsDbNull<decimal>(GetDoprinosMirovinski("SUM(OBRACUNATIDOPRINOS)", obracun_id, radnikID));

                            doprinosMirovinskoII = IsDbNull<decimal>(GetDoprinosMirovinski2("SUM(OBRACUNATIDOPRINOS)", obracun_id, radnikID));
                            doprinosZdravstveno = 0;
                            doprinosZastita = 0;
                            doprinosZaposljavanje = IsDbNull<decimal>(GetDoprinosZaposljavanje("SUM(OBRACUNATIDOPRINOS)", obracun_id, radnikID));
                            posebanDoprinosZaposljavanje = IsDbNull<decimal>(GetPosebanDoprinosZaposljavanje("OBRACUNATIDOPRINOS", obracun_id, radnikID));

                            dodatniDoprinosMirovinsko = 0;
                            dodatniDoprinosMirovinskoII = 0;
                            posebanDoprinosZdravstveno = 0;
                            izdatak = 0;

                            izdatakDoprinosMirovinsko = 0;
                            dohodak = primitak - izdatakDoprinosMirovinsko;
                            osobniOdbitak = 0;
                            poreznaOsnovica = dohodak - osobniOdbitak;
                            porezNaDohodak = 0;
                            prirez = 0;
                            oznakaNeoporezivogPrimitka = "0";
                            neoporezivPrimitak = 0;
                            oznakaNacinaIsplate = 0;
                            isplata = 0;
                            obracun_primitak = 0;
                        }
                        else
                        {
                            doprinosMirovinsko = 0;
                            doprinosMirovinskoII = 0;
                            doprinosZdravstveno = 0;
                            doprinosZastita = 0;
                            doprinosZaposljavanje = 0;
                            posebanDoprinosZaposljavanje = 0;
                            dodatniDoprinosMirovinsko = 0;
                            dodatniDoprinosMirovinskoII = 0;
                            posebanDoprinosZdravstveno = 0;
                            izdatak = 0;
                            izdatakDoprinosMirovinsko = 0;
                            dohodak = 0;
                            osobniOdbitak = 0;
                            poreznaOsnovica = 0;
                            porezNaDohodak = 0;
                            prirez = 0;
                            oznakaNacinaIsplate = GetOznakaNacinaIsplateByElementId(elementID, cop, file_name, oibStjecatelja, cop_counter);
                            oznakaNeoporezivogPrimitka = GetOznakaNeoporezivogPrimitkaByElementId(elementID, cop, file_name, oibStjecatelja, cop_counter);
                            neoporezivPrimitak = iznos_primitka;
                            isplata = iznos_primitka;

                            obracun_primitak = 0;
                        }
                    }
                    else if ((int)radnikElement["SKUPINAPOREZA"] == 97)
                    {
                        oznakaStjecatelja = GetOznakaStjecateljaPrimitkaByElementId(elementID, cop, file_name, oibStjecatelja, cop_counter);
                        oznakaPrimitka = "5701";

                        obvezaDodatnogDoprinosa = IsDbNull<decimal>(GetDataFromTableByID("IDBENEFICIRANI", "RADNIK", string.Format("IDRADNIK = {0}", radnikID)));

                        doprinosID = 6;
                        doprinosStopa = IsDbNull<decimal>(GetDataFromTableByID("STOPA", "DOPRINOS", string.Format("IDDOPRINOS = {0}", doprinosID)));

                        obvezaPosebnogDoprinosa = 0;

                        tjedniFondSati = IsDbNull<decimal>(GetDataFromTableByID("TJEDNIFONDSATI", "RADNIK", string.Format("IDRADNIK = {0}", radnikID)));
                        //njegaDjeteta = IsDbNull<bool>(GetDataFromTableByID("NJEGADJETETA", "RADNIK", string.Format("IDRADNIK = {0}", radnikID)));

                        if (tjedniFondSati == 0)
                            oznakaRadnogVremena = 0;
                        else if (tjedniFondSati == 40)
                            oznakaRadnogVremena = 1;
                        else if (0 < tjedniFondSati && tjedniFondSati < 40)
                            oznakaRadnogVremena = 2;
                        else if (njegaDjeteta)
                            oznakaRadnogVremena = 3;

                        primitak = 0;

                        osnovica = IsDbNull<decimal>(GetDataFromTableByID("OBRIZNOS", "ObracunElementi", "IDOBRACUN = '" + obracun_id + "' And IDRADNIK = '" + radnikID + "'"));

                        sqlQuery = "Select Distinct IDVRSTAELEMENTA From ObracunElementi Where IDELEMENT = '" + elementID + "' And IDRADNIK = '" + radnikID + "' And IDOBRACUN = '" + obracun_id + "'";
                        id_vrsta_elementa = Convert.ToInt32(client.ExecuteScalar(sqlQuery));

                        if (id_vrsta_elementa == 2)
                        {
                            doprinosMirovinsko = IsDbNull<decimal>(GetDoprinosMirovinski("SUM(OBRACUNATIDOPRINOS)", obracun_id, radnikID));

                            doprinosMirovinskoII = IsDbNull<decimal>(GetDoprinosMirovinski2("SUM(OBRACUNATIDOPRINOS)", obracun_id, radnikID));
                            doprinosZdravstveno = IsDbNull<decimal>(GetDoprinosZdravstveno("SUM(OBRACUNATIDOPRINOS)", obracun_id, radnikID));
                            doprinosZastita = IsDbNull<decimal>(GetDoprinosZastita("SUM(OBRACUNATIDOPRINOS)", obracun_id, radnikID));
                            doprinosZaposljavanje = 0;
                            posebanDoprinosZaposljavanje = 0;

                            dodatniDoprinosMirovinsko = 0;
                            dodatniDoprinosMirovinskoII = 0;
                            posebanDoprinosZdravstveno = 0;
                            izdatak = 0;
                            izdatakDoprinosMirovinsko = 0;
                            dohodak = primitak - izdatakDoprinosMirovinsko;
                            osobniOdbitak = 0;
                            poreznaOsnovica = dohodak - osobniOdbitak;
                            porezNaDohodak = 0;
                            prirez = 0;
                            oznakaNeoporezivogPrimitka = "0";
                            neoporezivPrimitak = 0;
                            oznakaNacinaIsplate = 0;
                            isplata = 0;
                            obracun_primitak = 0;
                        }
                        else
                        {
                            doprinosMirovinsko = 0;
                            doprinosMirovinskoII = 0;
                            doprinosZdravstveno = 0;
                            doprinosZastita = 0;
                            doprinosZaposljavanje = 0;
                            posebanDoprinosZaposljavanje = 0;
                            dodatniDoprinosMirovinsko = 0;
                            dodatniDoprinosMirovinskoII = 0;
                            posebanDoprinosZdravstveno = 0;
                            izdatak = 0;
                            izdatakDoprinosMirovinsko = 0;
                            dohodak = 0;
                            osobniOdbitak = 0;
                            poreznaOsnovica = 0;
                            porezNaDohodak = 0;
                            prirez = 0;
                            oznakaNacinaIsplate = GetOznakaNacinaIsplateByElementId(elementID, cop, file_name, oibStjecatelja, cop_counter);
                            oznakaNeoporezivogPrimitka = GetOznakaNeoporezivogPrimitkaByElementId(elementID, cop, file_name, oibStjecatelja, cop_counter);
                            neoporezivPrimitak = iznos_primitka;
                            isplata = iznos_primitka;
                            obracun_primitak = 0;

                        }
                    }
                }
                #endregion

                if ((oznakaStjecatelja == "5201" | oznakaStjecatelja == "5203" | oznakaStjecatelja == "5207" | oznakaStjecatelja == "5204" | oznakaStjecatelja == "5201"
                    | oznakaStjecatelja == "5210" | oznakaStjecatelja == "5205" | oznakaStjecatelja == "5206" | oznakaStjecatelja == "5208"
                    | oznakaStjecatelja == "5209" | oznakaStjecatelja == "5211") & oznakaPrimitka == "0000")
                {
                    sifraOpcineRada = "00000";
                    obvezaDodatnogDoprinosa = 0;
                    obvezaPosebnogDoprinosa = 0;
                    oznakaRadnogVremena = 0;
                }
                else
                {
                    sifraOpcineRada = "0" + IsDbNull<string>(GetDataFromTableByID("OPCINARADAIDOPCINE", "RADNIK", string.Format("IDRADNIK = {0}", radnikID)));
                }

                if (oznakaStjecatelja == "0000" & oznakaPrimitka == "0000")
                {
                    obvezaDodatnogDoprinosa = 0;
                    obvezaPosebnogDoprinosa = 0;
                    oznakaMjesecaOsiguranje = 0;
                    oznakaRadnogVremena = 0;
                    satiRada = 0.000M;
                }

                if ((oznakaStjecatelja == "5203" | oznakaStjecatelja == "5207" | oznakaStjecatelja == "5204"
                    | oznakaStjecatelja == "5205" | oznakaStjecatelja == "5206" | oznakaStjecatelja == "5208"
                    | oznakaStjecatelja == "5210" | oznakaStjecatelja == "5211") & oznakaPrimitka == "0000")
                {
                    oznakaNeoporezivogPrimitka = "0";
                    oznakaNacinaIsplate = 0;
                }
                if (oznakaPrimitka == "0021" | oznakaPrimitka == "0027" | oznakaPrimitka == "0028")
                {
                    razdobljeDo = new DateTime(razdobljeOd.Year, 12, 31);
                    razdobljeOd = new DateTime(razdobljeOd.Year, 1, 1);
                    obracun_primitak = 0;
                }

                if ((int)radnikElement["SKUPINAPOREZA"] == 98 | (int)radnikElement["SKUPINAPOREZA"] == 99 | (int)radnikElement["SKUPINAPOREZA"] == 100 | (int)radnikElement["SKUPINAPOREZA"] == 101 & oznakaPrimitka != "0000")
                {
                    oznakaStjecatelja = "0002";
                }

                //ubaceno zbog gopa
                if (elementID == 9997)
                {
                    satiRada = 0;
                    iznos_primitka = 0;
                    osnovica = 0;
                    doprinosMirovinsko = 0;
                    doprinosMirovinskoII = 0;
                    doprinosZdravstveno = 0;
                    doprinosZastita = 0;
                    doprinosZaposljavanje = 0;
                    dodatniDoprinosMirovinsko = 0;
                    dodatniDoprinosMirovinskoII = 0;
                    posebanDoprinosZaposljavanje = 0;
                    posebanDoprinosZdravstveno = 0;
                    izdatakDoprinosMirovinsko = 0;
                    dohodak = 0;
                    osobniOdbitak = IsDbNull<decimal>(GetDataFromObracunByRadnikID("ISKORISTENOOO", "ObracunRadnici", obracun_id, radnikID)) - IsDbNull<decimal>(GetDataFromObracunByRadnikID("ODBITAKPRIJEKOREKCIJE", "ObracunRadnici", obracun_id, radnikID));
                    poreznaOsnovica = -osobniOdbitak;
                    izdatak = 0;
                    obracun_primitak = 0;
                    neoporezivPrimitak = 0;
                    obvezaPosebnogDoprinosa = 0;

                    porezNaDohodak = GetPorezNaDohodakGOP(obracun_id, radnikID);
                    prirez = GetPrirezGOP(radnikID, obracun_id);

                    isplata = (porezNaDohodak + prirez) * -1;

                    razdobljeOd = new DateTime(DateTime.Now.Year, 1, 1);
                    razdobljeDo = new DateTime(DateTime.Now.Year, 12, 31);
                }

                //korekcija lipa kada se radi uvoz joppda iz gop joppda 
                if (cop)
                {
                    porezNaDohodak = Convert.ToDecimal(OznakeIzXMLa(file_name, "P141", oibStjecatelja, cop_counter).Replace('.', ','));
                    prirez = Convert.ToDecimal(OznakeIzXMLa(file_name, "P142", oibStjecatelja, cop_counter).Replace('.', ','));
                    isplata = Convert.ToDecimal(OznakeIzXMLa(file_name, "P162", oibStjecatelja, cop_counter).Replace('.', ','));
                }


                //korekcija isplate kada osoba ima gop red 
                if(IsDbNull<string>(client.ExecuteScalar("Select IDPOREZ From ObracunPorezi Where IDPOREZ = 999 And IDOBRACUN = '" + obracun_id + "' And IDRADNIK = '" + radnikID + "'")) != null
                    && oznakaRadnogVremena != 0 && elementID != 9997)
                {
                    isplata = isplata + (GetPorezNaDohodakGOP(obracun_id, radnikID) + GetPrirezGOP(radnikID, obracun_id));

                }

                //05.02.2015
                obvezaPosebnogDoprinosa = 0;

                if (!cop)
                {
                    tblJOPPDB.Rows.Add(this.JOPPDID.Value, redniBroj, sifraOpcinePrebivalista, sifraOpcineRada, oibStjecatelja, imePrezimeStjecatelja,
                        oznakaStjecatelja, oznakaPrimitka, obvezaDodatnogDoprinosa, obvezaPosebnogDoprinosa, oznakaMjesecaOsiguranje, oznakaRadnogVremena, satiRada, neodradeniSatiRada,
                        razdobljeOd, razdobljeDo, primitak, osnovica, doprinosMirovinsko, doprinosMirovinskoII, doprinosZdravstveno, doprinosZastita, doprinosZaposljavanje,
                        dodatniDoprinosMirovinsko, dodatniDoprinosMirovinskoII, posebanDoprinosZdravstveno, posebanDoprinosZaposljavanje, izdatak, izdatakDoprinosMirovinsko,
                        dohodak, osobniOdbitak, poreznaOsnovica, porezNaDohodak, prirez, oznakaNeoporezivogPrimitka, neoporezivPrimitak, oznakaNacinaIsplate, isplata, obracun_primitak);
                }
                else
                {
                    tblJOPPDB.Rows.Add(id_joppda, redniBroj, sifraOpcinePrebivalista, sifraOpcineRada, oibStjecatelja, imePrezimeStjecatelja,
                        oznakaStjecatelja, oznakaPrimitka, obvezaDodatnogDoprinosa, obvezaPosebnogDoprinosa, oznakaMjesecaOsiguranje, oznakaRadnogVremena, satiRada, neodradeniSatiRada,
                        razdobljeOd, razdobljeDo, primitak, osnovica, doprinosMirovinsko, doprinosMirovinskoII, doprinosZdravstveno, doprinosZastita, doprinosZaposljavanje,
                        dodatniDoprinosMirovinsko, dodatniDoprinosMirovinskoII, posebanDoprinosZdravstveno, posebanDoprinosZaposljavanje, izdatak, izdatakDoprinosMirovinsko,
                        dohodak, osobniOdbitak, poreznaOsnovica, porezNaDohodak, prirez, oznakaNeoporezivogPrimitka, neoporezivPrimitak, oznakaNacinaIsplate, isplata, obracun_primitak);
                }
            }

            return redniBroj;
        }

        private object GetDoprinosMirovinskoObracunRazno()
        {
            string sqlQuery = "Select Stopa From Doprinos Where IDDOPRINOS = 12";

            return client.ExecuteScalar(sqlQuery);
        }

        private object GetDoprinosZastitaObracunRazno()
        {
            string sqlQuery = "Select Stopa From Doprinos Where IDDOPRINOS = 4";

            return client.ExecuteScalar(sqlQuery);
        }

        private object GetPorezObracunRazno()
        {
            string sqlQuery = "Select StopaPoreza From Porez Where IDPOREZ = 7";

            return client.ExecuteScalar(sqlQuery);
        }

        private object GetPrirezObracunRazno(string sifra_opcine)
        {
            string sqlQuery = "Select PRIREZ From Opcina Where IDOPCINE = '" + sifra_opcine + "'";

            return client.ExecuteScalar(sqlQuery);
        }

        private object GetOpcinaPrebivalistePutniNalog(string id_radnik, string column, string table, string where)
        {
            string sqlQuery = "Select " + column + " From " + table + " Where " + where + " = '" + id_radnik + "'";

            return client.ExecuteScalar(sqlQuery);
        }

        private object GetOpcinaRadaPutniNalog(string id_radnik, string column, string table, string where)
        {
            string sqlQuery = "Select " + column + " From " + table + " Where " + where + " = '" + id_radnik + "'";

            return client.ExecuteScalar(sqlQuery);
        }

        private object GetOIBPutniNalog(string id_radnik, string column, string table, string where)
        {
            string sqlQuery = "Select " + column + " From " + table + " Where " + where + " = '" + id_radnik + "'";

            return client.ExecuteScalar(sqlQuery);
        }

        private bool ProvjeraVlastitogVozila(string id_radnik, string id_nacin_ispalte, string id_obracun)
        {
            bool vlastito_vozilo = false;

            string sqlQuery = "Select TroskoviVlastitogVozila From RegistarPutnihNaloga Where ID_Radnik = '" + id_radnik + "' And ID_NacinIsplate = '" + id_nacin_ispalte + "' And ID IN (" + id_obracun + ")";

            DataTable tbl = client.GetDataTable(sqlQuery);

            foreach (DataRow red in tbl.Rows)
            {
                if (Convert.ToDecimal(red["TroskoviVlastitogVozila"]) > 0)
                {
                    vlastito_vozilo = true;
                }
                
            }

            return vlastito_vozilo;
        }

        private bool ProvjeraDnevnice(string id_radnik, string id_nacin_ispalte, string id_obracun)
        {
            bool dnevnica = false;

            string sqlQuery = "Select Dnevnice From RegistarPutnihNaloga Where ID_Radnik = '" + id_radnik + "' And ID_NacinIsplate = '" + id_nacin_ispalte + "' And ID IN (" + id_obracun + ")";

            DataTable tbl = client.GetDataTable(sqlQuery);

            foreach (DataRow red in tbl.Rows)
            {
                decimal parser;
                if (decimal.TryParse(red["Dnevnice"].ToString(), out parser))
                {
                    if (Convert.ToDecimal(red["Dnevnice"].ToString()) > 0)
                    {
                        dnevnica = true;
                    }
                }

            }

            return dnevnica;
        }

        private string GetNacinIsplate(string id_nacin_isplate)
        {
            string oznaka = string.Empty;

            oznaka = client.ExecuteScalar("Select Oznaka From JOPPDOznakaNacinaIsplate Where ID = '" + id_nacin_isplate + "'").ToString();

            return oznaka;
        }

        private object GetNeoporeziviPrimitakPutniNalog(string id_radnik, string id_nacin_isplate, string vlastito_trosak, string id_obracun, string dnevnica)
        {
            string sqlQuery = string.Empty;
            string troskovi1 = string.Empty;
            string troskovi2 = string.Empty;
            string troskovi3 = string.Empty;
            string troskovi4 = string.Empty;
            decimal neoporezivi_primitak = 0;

            if (dnevnica == "False")
            {
                if (vlastito_trosak == "False")
                {
                    //troskovi1 = client.ExecuteScalar("Select Sum(Dnevnice) From RegistarPutnihNaloga Where " +
                    //                                 "ID_Radnik = '" + id_radnik + "' And ID_NacinIsplate = '" + id_nacin_isplate + "' And ID IN (" + id_obracun + ")").ToString();

                    if (troskovi1.Length == 0)
                        troskovi1 = "0";

                    troskovi2 = client.ExecuteScalar("Select Sum(OstaliTroskovi) From RegistarPutnihNaloga Where " +
                                                     "ID_Radnik = '" + id_radnik + "' And ID_NacinIsplate = '" + id_nacin_isplate + "' And ID IN (" + id_obracun + ")").ToString();


                    if (troskovi2.Length == 0)
                        troskovi2 = "0";

                    troskovi3 = client.ExecuteScalar("Select Sum(TroskoviSmjestaja) From RegistarPutnihNaloga Where " +
                                                     "ID_Radnik = '" + id_radnik + "' And ID_NacinIsplate = '" + id_nacin_isplate + "' And ID In (" + id_obracun + ")").ToString();

                    if (troskovi3.Length == 0)
                        troskovi3 = "0";

                    troskovi4 = client.ExecuteScalar("Select Sum(TroskoviPutovanja) From RegistarPutnihNaloga Where " +
                                                     "ID_Radnik = '" + id_radnik + "' And ID_NacinIsplate = '" + id_nacin_isplate + "' And ID IN (" + id_obracun + ")").ToString();

                    if (troskovi4.Length == 0)
                        troskovi4 = "0";
                }
                else
                {
                    troskovi1 = client.ExecuteScalar("Select Sum(TroskoviVlastitogVozila) From RegistarPutnihNaloga Where " +
                                                     "ID_Radnik = '" + id_radnik + "' And ID_NacinIsplate = '" + id_nacin_isplate + "' And ID In (" + id_obracun + ")").ToString();

                    if (troskovi1.Length == 0)
                        troskovi1 = "0";

                    if (troskovi2.Length == 0)
                        troskovi2 = "0";

                    if (troskovi3.Length == 0)
                        troskovi3 = "0";

                    if (troskovi4.Length == 0)
                        troskovi4 = "0";
                }
                neoporezivi_primitak = Convert.ToDecimal(troskovi1) + Convert.ToDecimal(troskovi2) + Convert.ToDecimal(troskovi3) + Convert.ToDecimal(troskovi4);
            }
            else if (dnevnica == "True" && vlastito_trosak == "True")
            {
                troskovi1 = client.ExecuteScalar("Select Sum(Dnevnice) + SUM(TroskoviVlastitogVozila) From RegistarPutnihNaloga Where " +
                                                 "ID_Radnik = '" + id_radnik + "' And ID_NacinIsplate = '" + id_nacin_isplate + "' And ID IN (" + id_obracun + ")").ToString();

                neoporezivi_primitak = Convert.ToDecimal(troskovi1);
            }
            else
            {
                troskovi1 = client.ExecuteScalar("Select Sum(Dnevnice) From RegistarPutnihNaloga Where " +
                                                 "ID_Radnik = '" + id_radnik + "' And ID_NacinIsplate = '" + id_nacin_isplate + "' And ID IN (" + id_obracun + ")").ToString();

                neoporezivi_primitak = Convert.ToDecimal(troskovi1);

            }

            return neoporezivi_primitak;
        }

        /// <summary>
        /// Univerzalna funkcija za dohvat jednog podatka, u jednom obračunu za jednog radnika
        /// </summary>
        /// <param name="columnName"></param>
        /// <param name="tableName"></param>
        /// <param name="obracunID"></param>
        /// <param name="radnikID"></param>
        /// <returns></returns>
        private object GetDataFromObracunByRadnikID(string columnName, string tableName, string obracunID, int radnikID)
        {
            string sqlQuery = "";
            if (tableName == "ObracunPorezi")
            {
                sqlQuery = string.Format("SELECT {0} FROM dbo.{1} WHERE IDOBRACUN = '{2}' AND IDRADNIK = {3} And IDPOREZ <> 999", columnName, tableName, obracunID, radnikID);
            }
            else
            {
                sqlQuery = string.Format("SELECT {0} FROM dbo.{1} WHERE IDOBRACUN = '{2}' AND IDRADNIK = {3}", columnName, tableName, obracunID, radnikID);
            }

            return client.ExecuteScalar(sqlQuery);
        }

        private object GetDoprinosMirovinski(string columnName, string obracunID, int radnikID)
        {
            string sqlQuery = string.Format("SELECT {0} FROM dbo.ObracunDoprinosi WHERE IDOBRACUN = '{1}' AND IDRADNIK = {2} AND (SuBSTRING(PODOPRINOS, 0, 5) = '8168' OR SuBSTRING(PODOPRINOS, 0, 5) = '8109')", columnName, obracunID, radnikID);

            return client.ExecuteScalar(sqlQuery);
        }

        private object GetDoprinosMirovinski2(string columnName, string obracunID, int radnikID)
        {
            string sqlQuery = string.Format("SELECT {0} FROM dbo.ObracunDoprinosi WHERE IDOBRACUN = '{1}' AND IDRADNIK = {2} AND (SuBSTRING(PODOPRINOS, 0, 5) = '2283' OR SuBSTRING(PODOPRINOS, 0, 5) = '2003')", columnName, obracunID, radnikID);

            return client.ExecuteScalar(sqlQuery);
        }

        private object GetDoprinosZdravstveno(string columnName, string obracunID, int radnikID)
        {
            string sqlQuery = string.Format("SELECT {0} FROM dbo.ObracunDoprinosi WHERE IDOBRACUN = '{1}' AND IDRADNIK = {2} AND (SuBSTRING(PODOPRINOS, 0, 5) = '8486' OR SuBSTRING(PODOPRINOS, 0, 5) = '8400')", columnName, obracunID, radnikID);

            return client.ExecuteScalar(sqlQuery);
        }

        private object GetDoprinosZastita(string columnName, string obracunID, int radnikID)
        {
            string sqlQuery = string.Format("SELECT {0} FROM dbo.ObracunDoprinosi WHERE IDOBRACUN = '{1}' AND IDRADNIK = {2} AND (SuBSTRING(PODOPRINOS, 0, 5) = '8630' OR SuBSTRING(PODOPRINOS, 0, 5) = '8559')", columnName, obracunID, radnikID);

            return client.ExecuteScalar(sqlQuery);
        }

        private object GetDoprinosZaposljavanje(string columnName, string obracunID, int radnikID)
        {
            string sqlQuery = string.Format("SELECT {0} FROM dbo.ObracunDoprinosi WHERE IDOBRACUN = '{1}' AND IDRADNIK = {2} AND (SuBSTRING(PODOPRINOS, 0, 5) = '8753' OR SuBSTRING(PODOPRINOS, 0, 5) = '8702')", columnName, obracunID, radnikID);

            return client.ExecuteScalar(sqlQuery);
        }

        private object GetPosebanDoprinosZaposljavanje(string columnName, string obracunID, int radnikID)
        {
            string sqlQuery = string.Format("SELECT {0} FROM dbo.ObracunDoprinosi WHERE IDOBRACUN = '{1}' AND IDRADNIK = {2} AND (SUBSTRING(PODOPRINOS, 0, 5) = '8761' OR SUBSTRING(PODOPRINOS, 0, 5) = '8729' OR SUBSTRING(PODOPRINOS, 0, 5) = '8176')", columnName, obracunID, radnikID);

            return client.ExecuteScalar(sqlQuery);
        }

        /// <summary>
        /// Univerzalna funkcija za dohvat jednog podatka, u jednom obračunu za jednog radnika po jednom elementu
        /// </summary>
        /// <param name="columnName"></param>
        /// <param name="obracunID"></param>
        /// <param name="radnikID"></param>
        /// <param name="elementID"></param>
        /// <returns></returns>
        private object GetDataFromObracunElementByRadnikIDElementID(string columnName, string obracunID, int radnikID, int elementID)
        {
            int id_vrsta_elementa = 0;
            string sqlQuery = string.Empty;

            sqlQuery = "Select Distinct IDVRSTAELEMENTA From ObracunElementi Where IDELEMENT = '" + elementID + "' And IDRADNIK = '" + radnikID + "' And IDOBRACUN = '" + obracunID + "'";

            id_vrsta_elementa = Convert.ToInt32(client.ExecuteScalar(sqlQuery));

            sqlQuery = "Select Sum(" + columnName + ") From ObracunElementi Where IDVRSTAELEMENTA = '" + id_vrsta_elementa + "' And IDRADNIK = '" + radnikID + "' And IDOBRACUN = '" + obracunID + "'";


            return client.ExecuteScalar(sqlQuery);
        }

        private object GetSatiRadiByRadnikIDElementID(string columnName, string obracunID, int radnikID, int elementID)
        {
            int id_vrsta_elementa = 0;
            string sqlQuery = string.Empty;

            sqlQuery = "Select Distinct IDVRSTAELEMENTA From ObracunElementi Where IDELEMENT = '" + elementID + "' And IDRADNIK = '" + radnikID + "' And IDOBRACUN = '" + obracunID + "'";

            id_vrsta_elementa = Convert.ToInt32(client.ExecuteScalar(sqlQuery));

            if (id_vrsta_elementa == 1)
            {
                sqlQuery = "Select Sum(" + columnName + ") From ObracunElementi Inner Join ELEMENT ON ObracunElementi.IDELEMENT = ELEMENT.IDELEMENT " +
                           "Where ObracunElementi.IDVRSTAELEMENTA = '" + id_vrsta_elementa + "' And ObracunElementi.IDRADNIK = '" + radnikID +
                           "' And ObracunElementi.IDOBRACUN = '" + obracunID + "' And ELEMENT.ZBRAJASATEUFONDSATI = 1 And ObracunElementi.IDELEMENT = '" + elementID + "' " +
                           "And ELEMENT.IDELEMENT Not IN (10,11,12,20,50,51,62,63,64,1010,1005)";
            }
            else if (id_vrsta_elementa == 2)
            {
                sqlQuery = "Select Sum(" + columnName + ") From ObracunElementi Inner Join ELEMENT ON ObracunElementi.IDELEMENT = ELEMENT.IDELEMENT " +
                           "Where ObracunElementi.IDVRSTAELEMENTA = '" + id_vrsta_elementa + "' And ObracunElementi.IDRADNIK = '" + radnikID +
                           "' And ObracunElementi.IDOBRACUN = '" + obracunID + "' And ELEMENT.ZBRAJASATEUFONDSATI = 1 " +
                           "And ELEMENT.IDELEMENT Not IN (10,11,12,20,50,51,62,63,64,1010,1005)";
            }

            return client.ExecuteScalar(sqlQuery);
        }

        private object GetNeodradeniSatiRada(string obracun_id, int radnikID, int elementID)
        {
            int id_vrsta_elementa = 0;
            string sqlQuery = string.Empty;

            sqlQuery = "Select Distinct IDVRSTAELEMENTA From ObracunElementi Where IDELEMENT = '" + elementID + "' And IDRADNIK = '" + radnikID + "' And IDOBRACUN = '" + obracun_id + "'";

            id_vrsta_elementa = Convert.ToInt32(client.ExecuteScalar(sqlQuery));

            if (id_vrsta_elementa == 1)
            {
                sqlQuery = "Select Sum(OBRSATI) From ObracunElementi Inner Join ELEMENT ON ObracunElementi.IDELEMENT = ELEMENT.IDELEMENT " +
                           "Where ObracunElementi.IDVRSTAELEMENTA = '" + id_vrsta_elementa + "' And ObracunElementi.IDRADNIK = '" + radnikID +
                           "' And ObracunElementi.IDOBRACUN = '" + obracun_id + "' And ELEMENT.ZBRAJASATEUFONDSATI = 1 And ObracunElementi.IDELEMENT = '" + elementID + "' " +
                           "And ELEMENT.IDELEMENT IN (10,11,12,20,50,51,62,63,64,1010,1005)";
            }
            else if (id_vrsta_elementa == 2)
            {
                sqlQuery = "Select Sum(OBRSATI) From ObracunElementi Inner Join ELEMENT ON ObracunElementi.IDELEMENT = ELEMENT.IDELEMENT " +
                           "Where ObracunElementi.IDVRSTAELEMENTA = '" + id_vrsta_elementa + "' And ObracunElementi.IDRADNIK = '" + radnikID +
                           "' And ObracunElementi.IDOBRACUN = '" + obracun_id + "' And ELEMENT.ZBRAJASATEUFONDSATI = 1 " +
                           "And ELEMENT.IDELEMENT IN (10,11,12,20,50,51,62,63,64,1010,1005)";
            }

            return client.ExecuteScalar(sqlQuery);
        }

        private object GetDataFromObracunElementByRadnikIDElementIDPrimitak(string columnName, string obracunID, int radnikID, int elementID)
        {
            int id_vrsta_elementa = 0;
            string sqlQuery = string.Empty;

            sqlQuery = "Select Distinct IDVRSTAELEMENTA From ObracunElementi Where IDELEMENT = '" + elementID + "' And IDRADNIK = '" + radnikID + "' And IDOBRACUN = '" + obracunID + "'";

            id_vrsta_elementa = Convert.ToInt32(client.ExecuteScalar(sqlQuery));

            if (id_vrsta_elementa == 2)
            {
                sqlQuery = "Select Sum(" + columnName + ") From ObracunElementi Where IDVRSTAELEMENTA = '" + id_vrsta_elementa + "' And IDRADNIK = '" + radnikID + "' And IDOBRACUN = '" + obracunID + "'";
                return client.ExecuteScalar(sqlQuery);
            }
            else
            {
                return 0;
            }                
        }

        private object GetDataFromObracunElementByRadnikIDElementIDRazdobljeMin(string columnName, string obracunID, int radnikID, int elementID)
        {
            int id_vrsta_elementa = 0;
            string sqlQuery = string.Empty;

            sqlQuery = "Select Distinct IDVRSTAELEMENTA From ObracunElementi Where IDELEMENT = '" + elementID + "' And IDRADNIK = '" + radnikID + "' And IDOBRACUN = '" + obracunID + "'";

            id_vrsta_elementa = Convert.ToInt32(client.ExecuteScalar(sqlQuery));

            if (id_vrsta_elementa == 1 || id_vrsta_elementa == 3)
            {
                sqlQuery = "Select Min(" + columnName + ") From ObracunElementi Where IDVRSTAELEMENTA = '" + id_vrsta_elementa + "' And IDRADNIK = '" + radnikID +
                           "' And IDOBRACUN = '" + obracunID + "' And IDELEMENT = '" + elementID + "'";
            }
            else if (id_vrsta_elementa == 2)
            {
                sqlQuery = "Select Min(" + columnName + ") From ObracunElementi Where IDVRSTAELEMENTA = '" + id_vrsta_elementa + "' And IDRADNIK = '" + radnikID +
                           "' And IDOBRACUN = '" + obracunID + "'";
            }

            return client.ExecuteScalar(sqlQuery);
        }

        private bool ProvjeriIspaltaPoslodavac(string id_radnik, string id_nacin_isplate)
        {
            bool isplate_poslodavac = false;
            string podatak = string.Empty;
            string sqlQuery = string.Empty;
            sqlQuery = "Select ID From RegistarPutnihNaloga Where ID_Radnik = '" + id_radnik + "' And ID_NacinIsplate = '" + id_nacin_isplate + 
                       "' And (IsTroskoviSmjestaja = 1 OR IsDrugiTroskovi = 1 OR IsTroskoviPutovanja = 1)";

            podatak = client.ExecuteScalar(sqlQuery).ToString();

            if (podatak.Length > 0)
                isplate_poslodavac = true;

            return isplate_poslodavac;
        }

        private object GetDataFromObracunElementByRadnikIDElementIDRazdobljeMax(string columnName, string obracunID, int radnikID, int elementID)
        {
            int id_vrsta_elementa = 0;
            string sqlQuery = string.Empty;

            sqlQuery = "Select Distinct IDVRSTAELEMENTA From ObracunElementi Where IDELEMENT = '" + elementID + "' And IDRADNIK = '" + radnikID + "' And IDOBRACUN = '" + obracunID + "'";

            id_vrsta_elementa = Convert.ToInt32(client.ExecuteScalar(sqlQuery));

            if (id_vrsta_elementa == 1 ||id_vrsta_elementa == 3)
            {
                sqlQuery = "Select Max(" + columnName + ") From ObracunElementi Where IDVRSTAELEMENTA = '" + id_vrsta_elementa + "' And IDRADNIK = '" + radnikID +
                       "' And IDOBRACUN = '" + obracunID + "' And ObracunElementi.IDELEMENT = '" + elementID + "'";
            }
            else if (id_vrsta_elementa == 2)
            {
                sqlQuery = "Select Max(" + columnName + ") From ObracunElementi Where IDVRSTAELEMENTA = '" + id_vrsta_elementa + "' And IDRADNIK = '" + radnikID +
                       "' And IDOBRACUN = '" + obracunID + "'";
            }

            return client.ExecuteScalar(sqlQuery);
        }

        /// <summary>
        /// Univerzalna funkcija za dohvat jednog podatka po određenim uvjetima
        /// </summary>
        /// <param name="columnName"></param>
        /// <param name="tableName"></param>
        /// <param name="whereCondition"></param>
        /// <returns></returns>
        private object GetDataFromTableByID(string columnName, string tableName, string whereCondition)
        {
            string sqlQuery = string.Format("SELECT {0} FROM dbo.{1} {2}", columnName, tableName, (!string.IsNullOrEmpty(whereCondition) ? " WHERE " + whereCondition : string.Empty));

            return IsDbNull<string>(client.ExecuteScalar(sqlQuery));
        }

        private decimal GetPorezNaDohodakGOP(string id_obracun, int id_radnik)
        {
            string sqlQuery = "Select OBRACUNATIPOREZ From ObracunPorezi Where IDPOREZ = 999 And IDOBRACUN = '" + id_obracun + "' And IDRADNIK = " + id_radnik;

            return IsDbNull<decimal>(client.ExecuteScalar(sqlQuery));
        }

        private decimal GetPrirezGOP(int id_radnik, string id_obracun)
        {
            string sqlQuery = "Select KOREKCIJAPRIREZA From ObracunRadnici Where IDOBRACUN = '" + id_obracun + "' And IDRADNIK = " + id_radnik;

            return IsDbNull<decimal>(client.ExecuteScalar(sqlQuery));
        }

        private object GetDatumPutniNalog(string id_radnik, string obracuni)
        {
            string sqlQuery = "Select DatumObracuna From RegistarPutnihNaloga Where ID_RADNIK = '" + id_radnik + "' And ID IN(" + obracuni + ")";

            return client.ExecuteScalar(sqlQuery);
        }

        private object OsnovicaVolonteri(string columnName, string tableName, int id_radnik, string id_obracun)
        {
            string sqlQuery = string.Format("SELECT " + columnName + " From " + tableName + " Where IDOBRACUN = '" + id_obracun + "' And IDRADNIK = " + id_radnik);

            return IsDbNull<string>(client.ExecuteScalar(sqlQuery));
        }

        /// <summary>
        /// Dohvat oznake stjecatelja po ID-u elementa
        /// </summary>
        /// <param name="elementID"></param>
        /// <returns></returns>
        private string GetOznakaStjecateljaPrimitkaByElementId(int elementID, bool cop, string file_name, string oib, int counter)
        {
            if (!cop)
            {
                string sqlQuery = string.Format("SELECT Oznaka FROM dbo.JOPPDOznakaStjecateljaPrimitka " +
                    "INNER JOIN dbo.JOPPDOznakaStjecateljaPrimitkaElement ON dbo.JOPPDOznakaStjecateljaPrimitka.ID = dbo.JOPPDOznakaStjecateljaPrimitkaElement.JOPPDOznakaStjecateljaPrimitkaID " +
                    "WHERE IDELEMENT = {0}", elementID);

                return IsDbNull<string>(client.ExecuteScalar(sqlQuery));
            }
            else
            {
                return OznakeIzXMLa(file_name, "P61", oib, counter);
            }
        }

        private string OznakeIzXMLa(string file_name, string oznaka, string oib, int counter)
        {
            XmlDocument objekt = new XmlDocument();
            objekt.Load(file_name);
            bool vrsta = false;
            int counter_foreach = 0;

            XmlNodeList nodes = objekt.GetElementsByTagName("ns1:P");

            //prvjera dali su jedan ili vise redova u datoteci
            //ukoliko je jedan counter je uvijek 0, u suprotnom se povecava 
            int broj_redova = 0;
            foreach (XmlNode node in nodes)
            {
                if (node.ChildNodes[3].InnerText.Trim() == oib)
                {
                    broj_redova++;
                }
            }
            if (broj_redova == 1)
            {
                counter = 0;
            }

            foreach (XmlNode node in nodes)
            {
                vrsta = true;
                if (node.ChildNodes[3].InnerText.Trim() == oib)
                {
                    if (counter_foreach == counter)
                    {
                        if (oznaka == "P61")
                        {
                            counter_foreach = 0;
                            return node.ChildNodes[5].InnerText;
                        }
                        else if (oznaka == "P62")
                        {
                            counter_foreach = 0;
                            return node.ChildNodes[6].InnerText;
                        }
                        else if (oznaka == "P161")
                        {
                            counter_foreach = 0;
                            return node.ChildNodes[35].InnerText;
                        }
                        else if (oznaka == "P151")
                        {
                            counter_foreach = 0;
                            return node.ChildNodes[33].InnerText;
                        }
                        else if (oznaka == "P141")
                        {
                            return node.ChildNodes[31].InnerText;
                        }
                        else if (oznaka == "P142")
                        {
                            return node.ChildNodes[32].InnerText;
                        }
                        else if (oznaka == "P162")
                        {
                            return node.ChildNodes[36].InnerText;
                        }
                    }
                    counter_foreach++;
                }
            }

            if (!vrsta)
            {
                nodes = objekt.GetElementsByTagName("P");

                foreach (XmlNode node in nodes)
                {
                    vrsta = true;
                    if (node.ChildNodes[3].InnerText.Trim() == oib)
                    {
                        if (counter_foreach == counter)
                        {
                            if (oznaka == "P61")
                            {
                                return node.ChildNodes[5].InnerText;
                            }
                            else if (oznaka == "P62")
                            {
                                return node.ChildNodes[6].InnerText;
                            }
                            else if (oznaka == "P161")
                            {
                                return node.ChildNodes[35].InnerText;
                            }
                            else if (oznaka == "P151")
                            {
                                return node.ChildNodes[33].InnerText;
                            }
                            else if (oznaka == "P141")
                            {
                                return node.ChildNodes[31].InnerText;
                            }
                            else if (oznaka == "P142")
                            {
                                return node.ChildNodes[32].InnerText;
                            }
                            else if (oznaka == "P162")
                            {
                                return node.ChildNodes[36].InnerText;
                            }
                        }
                        counter_foreach++;
                    }
                }
            }

            return "0";
        }

        /// <summary>
        /// Dohvat oznake primitka po ID-u elementa
        /// </summary>
        /// <param name="elementID"></param>
        /// <returns></returns>
        private string GetOznakaPrimitkaByElementId(int elementID, bool cop, string file_name, string oib, int counter)
        {
            if (!cop)
            {
                string sqlQuery = string.Format("SELECT Oznaka FROM dbo.JOPPDOznakaPrimitka " +
                    "INNER JOIN dbo.JOPPDOznakaPrimitkaElement ON dbo.JOPPDOznakaPrimitka.ID = dbo.JOPPDOznakaPrimitkaElement.JOPPDOznakaPrimitkaID " +
                    "WHERE IDELEMENT = {0}", elementID);

                return IsDbNull<string>(client.ExecuteScalar(sqlQuery));
            }
            else
            {
                return OznakeIzXMLa(file_name, "P62", oib, counter);
            }
        }

        /// <summary>
        /// Dohvat oznake neoporezivog primitka po ID-u elementa
        /// </summary>
        /// <param name="elementID"></param>
        /// <returns></returns>
        private string GetOznakaNeoporezivogPrimitkaByElementId(int elementID, bool cop, string file_name, string oib, int counter)
        {
            if (!cop)
            {
                string sqlQuery = string.Format("SELECT Oznaka FROM dbo.JOPPDOznakaNeoporezivogPrimitka " +
                    "INNER JOIN dbo.JOPPDOznakaNeoporezivogPrimitkaElement ON dbo.JOPPDOznakaNeoporezivogPrimitka.ID = dbo.JOPPDOznakaNeoporezivogPrimitkaElement.JOPPDOznakaNeoporezivogPrimitkaID " +
                    "WHERE IDELEMENT = {0}", elementID);

                return IsDbNull<string>(client.ExecuteScalar(sqlQuery));
            }
            else
            {
                return OznakeIzXMLa(file_name, "P151", oib, counter);
            }
        }

        /// <summary>
        /// Dohvat oznake načina isplate po ID-u elementa
        /// </summary>
        /// <param name="elementID"></param>
        /// <returns></returns>
        private decimal GetOznakaNacinaIsplateByElementId(int elementID, bool cop, string file_name, string oib, int counter)
        {
            if (!cop)
            {
                string sqlQuery = string.Format("SELECT Oznaka FROM dbo.JOPPDOznakaNacinaIsplate " +
                    "INNER JOIN dbo.JOPPDOznakaNacinaIsplateElement ON dbo.JOPPDOznakaNacinaIsplate.ID = dbo.JOPPDOznakaNacinaIsplateElement.JOPPDOznakaNacinaIsplateID " +
                    "WHERE IDELEMENT = {0}", elementID);

                return IsDbNull<decimal>(client.ExecuteScalar(sqlQuery));
            }
            else
            {
                return Convert.ToDecimal(OznakeIzXMLa(file_name, "P161", oib, counter));
            }
        }

        /// <summary>
        /// Dohvat liste ID-eva svih radnika u jednom obračunu DOHOTKA
        /// </summary>
        /// <param name="obracunID"></param>
        /// <returns></returns>
        [Obsolete("Ova funkcija se više ne koristi nakon nove funkcije GetObracunDohotka_RadniciElementi().", true)]
        private List<int> GetObracunDohotka_Radnici(string obracunID)
        {
            string sqlQuery = string.Format("SELECT DISTINCT IDRADNIK FROM dbo.ObracunRadnici WHERE IDIPIDENT <> 11 AND IDOBRACUN = '{0}'", obracunID);

            // fill DataTable with radnici
            DataTable dtRadnici = client.GetDataTable(sqlQuery);

            List<int> radnici = new List<int>();

            foreach (DataRow drRadnik in dtRadnici.Rows)
                radnici.Add((int)drRadnik["IDRADNIK"]);

            return radnici;
        }

        /// <summary>
        /// Dohvat liste ID-eva svih radnika i elemenata u jednom obračunu DOHOTKA
        /// </summary>
        /// <param name="obracunID"></param>
        /// <returns></returns>
        private List<KeyValuePair<int, int>> GetObracunDohotka_RadniciElementi(string obracunID)
        {
            string sqlQuery = string.Format("SELECT DISTINCT dbo.ObracunElementi.IDRADNIK, dbo.ObracunElementi.IDELEMENT " + 
                "FROM dbo.ObracunElementi " +
                "INNER JOIN dbo.ObracunRadnici ON dbo.ObracunElementi.IDOBRACUN = dbo.ObracunRadnici.IDOBRACUN " +
                "AND dbo.ObracunElementi.IDRADNIK = dbo.ObracunRadnici.IDRADNIK " +
                "WHERE dbo.ObracunElementi.IDOBRACUN = '{0}' AND IDIPIDENT <> 11 " +
                "ORDER BY dbo.ObracunElementi.IDRADNIK, dbo.ObracunElementi.IDELEMENT", obracunID);

            // fill DataTable with elementi
            DataTable dtElementi = client.GetDataTable(sqlQuery);

            List<KeyValuePair<int, int>> elementi = new List<KeyValuePair<int,int>>();

            foreach (DataRow drElement in dtElementi.Rows)
                elementi.Add(new KeyValuePair<int,int>((int)drElement["IDRADNIK"], (int)drElement["IDELEMENT"]));

            return elementi;
        }

        public void OtvoriJOPPD_StranicaA()
        {
            DataRow dr_joppda = client.GetDataTable("Select OznakaIzvjesca, OznakaIzvjescaDatum, JOPPDAVrstaIzvjesca.Sifra, JOPPDAVrstaIzvjesca.Naziv " + 
                                                    "From JOPPDA Inner join JOPPDAVrstaIzvjesca ON JOPPDA.VrstaIzvjescaID = JOPPDAVrstaIzvjesca.ID " + 
                                                    "Where JOPPDA.ID = '" + JOPPDID.Value + "'").Rows[0];

            lblOznakaIzvjesca.Text = dr_joppda["OznakaIzvjesca"].ToString();
            lblVrstaIzvjesca.Text = string.Format("{0:N0} - {1}", dr_joppda["Sifra"].ToString(), dr_joppda["Naziv"].ToString());
            lblIzvjesceNaDan.Text = Convert.ToDateTime(dr_joppda["OznakaIzvjescaDatum"]).ToString("dd.MM.yyyy");

            vrsta_izvjesca = dr_joppda["Sifra"].ToString();
            //lblObracun.Text = dr_joppda["ObracunID"].ToString();

            if (kontrola_broj)
            {
                lblBrojOsoba.Text = client.ExecuteScalar(string.Format("SELECT COUNT(DISTINCT OIBStjecatelja) FROM dbo.JOPPDB WHERE dbo.JOPPDB.JOPPDAID = {0}", this.JOPPDID.Value)).ToString();
                lblBrojRedakaNaStraniB.Text = client.ExecuteScalar(string.Format("SELECT COUNT(1) FROM dbo.JOPPDB WHERE dbo.JOPPDB.JOPPDAID = {0}", this.JOPPDID.Value)).ToString();
            }
            else
            {
                lblBrojOsoba.Text = broj_radnika.ToString();
                lblBrojRedakaNaStraniB.Text = broj_redaka.ToString();
            }
        }

        /// <summary>
        /// If value is DBNull, then return "returnValue"
        /// </summary>
        /// <param name="value">Value to cast</param>
        /// <param name="returnValue"></param>
        /// <returns></returns>
        public T IsDbNull<T>(object value)
        {
            if (value != DBNull.Value && value != null)
            {
                // return (T)value; // CAST
                return (T)Convert.ChangeType(value, typeof(T)); // CONVERT
            }

            return default(T);
        }

        /// <summary>
        /// Vraca guid od hashcoda
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        static Guid StringToGUID(string value)
        {
            // Create a new instance of the MD5CryptoServiceProvider object.
            MD5 md5Hasher = MD5.Create();
            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(value));
            return new Guid(data);
        }

        [LocalCommandHandler("JOPPDDatoteka")]
        public void JOPPDDatotekaHandler(object sender, EventArgs e)
        {
            DataRow korisnik = client.GetDataTable("Select KORISNIK1NAZIV, KORISNIK1ADRESA, KORISNIK1MJESTO, KORISNIKOIB, KONTAKTOSOBA, EMAIL From KORISNIK").Rows[0];

            JOPPD.sObrazacJOPPD obrazac = new JOPPD.sObrazacJOPPD();

            JOPPD.sJOPPDmetapodaci podaci = new JOPPD.sJOPPDmetapodaci();

            string kontak_ime = "";
            string kontakt_prezime = "";

            if (korisnik["KONTAKTOSOBA"].ToString() != "")
            {
                string[] ime = korisnik["KONTAKTOSOBA"].ToString().Split(' ');

                if (ime.Length > 1)
                {
                    kontak_ime = ime[0];
                    kontakt_prezime = ime[1];
                }
                else
                {
                    MessageBox.Show("U modulu Korisnik šifarnici za korisnika aplikacije nisu popunjeni svi podaci.\nUnesite kontakt osobu.");
                    return;
                }
            }
            else
            {
                MessageBox.Show("U modulu Korisnik šifarnici za korisnika aplikacije nisu popunjeni svi podaci.\nUnesite kontakt osobu.");
                return;
            }

            //punjenje metapodataka
            podaci.Adresant = new JOPPD.sAdresantTemeljni();
            podaci.Adresant.Value = "Ministarstvo Financija, Porezna uprava, Zagreb";

            podaci.Autor = new JOPPD.sAutorTemeljni();
            podaci.Autor.dc = "http://purl.org/dc/elements/1.1/creator";
            podaci.Autor.Value = kontak_ime + " " + kontakt_prezime;

            podaci.Datum = new JOPPD.sDatumTemeljni();
            podaci.Datum.Value = DateTime.Now;
            podaci.Datum.dc = "http://purl.org/dc/elements/1.1/date";

            podaci.Format = new JOPPD.sFormatTemeljni();
            podaci.Format.Value = JOPPD.tFormat.textxml;
            podaci.Format.dc = "http://purl.org/dc/elements/1.1/format";

            podaci.Identifikator = new JOPPD.sIdentifikatorTemeljni();
            podaci.Identifikator.Value = StringToGUID(podaci.Identifikator.GetHashCode().ToString()).ToString();
            podaci.Identifikator.dc = "http://purl.org/dc/elements/1.1/identifier";

            podaci.Jezik = new JOPPD.sJezikTemeljni();
            podaci.Jezik.dc = "http://purl.org/dc/elements/1.1/language";
            podaci.Jezik.Value = JOPPD.tJezik.hrHR;

            podaci.Naslov = new JOPPD.sNaslovTemeljni();
            podaci.Naslov.Value = "Izvješće o primicima, porezu na dohodak i prirezu te doprinosima za obvezna osiguranja";
            podaci.Naslov.dc = "http://purl.org/dc/elements/1.1/title";

            podaci.Tip = new JOPPD.sTipTemeljni();
            podaci.Tip.Value = JOPPD.tTip.Elektroničkiobrazac;
            podaci.Tip.dc = "http://purl.org/dc/elements/1.1/type";

            podaci.Uskladjenost = new JOPPD.sUskladjenost();
            podaci.Uskladjenost.Value = "ObrazacJOPPD-v1-1";
            podaci.Uskladjenost.dc = "http://purl.org/dc/terms/conformsTo";

            obrazac.verzijaSheme = "1.1";

            obrazac.Metapodaci = podaci;

            //punjenje strane A
            JOPPD.sStranaA strana_a = new JOPPD.sStranaA();
            strana_a.BrojOsoba = lblBrojOsoba.Text.ToString().Trim();
            strana_a.BrojRedaka = lblBrojRedakaNaStraniB.Text.ToString().Trim();
            strana_a.DatumIzvjesca = Convert.ToDateTime(lblIzvjesceNaDan.Text);

            strana_a.Doprinosi = new JOPPD.sDoprinosi();
            strana_a.Doprinosi.GeneracijskaSolidarnost = new JOPPD.sGeneracijskaSolidarnost();
            strana_a.Doprinosi.GeneracijskaSolidarnost.P1 = decimal.Round(Conversions.ToDecimal(txtUkupno_VI_1_1.Value), 2);
            strana_a.Doprinosi.GeneracijskaSolidarnost.P2 = decimal.Round(Conversions.ToDecimal(txtUkupno_VI_1_2.Value), 2);
            strana_a.Doprinosi.GeneracijskaSolidarnost.P3 = decimal.Round(Conversions.ToDecimal(txtUkupno_VI_1_3.Value), 2);
            strana_a.Doprinosi.GeneracijskaSolidarnost.P4 = decimal.Round(Conversions.ToDecimal(txtUkupno_VI_1_4.Value), 2);
            strana_a.Doprinosi.GeneracijskaSolidarnost.P5 = decimal.Round(Conversions.ToDecimal(txtUkupno_VI_1_5.Value), 2);
            strana_a.Doprinosi.GeneracijskaSolidarnost.P6 = decimal.Round(Conversions.ToDecimal(txtUkupno_VI_1_6.Value), 2);
            
            strana_a.Doprinosi.KapitaliziranaStednja = new JOPPD.sKapitaliziranaStednja();
            strana_a.Doprinosi.KapitaliziranaStednja.P1 = decimal.Round(Conversions.ToDecimal(txtUkupno_VI_2_1.Value), 2);
            strana_a.Doprinosi.KapitaliziranaStednja.P2 = decimal.Round(Conversions.ToDecimal(txtUkupno_VI_2_2.Value), 2);
            strana_a.Doprinosi.KapitaliziranaStednja.P3 = decimal.Round(Conversions.ToDecimal(txtUkupno_VI_2_3.Value), 2);
            strana_a.Doprinosi.KapitaliziranaStednja.P4 = decimal.Round(Conversions.ToDecimal(txtUkupno_VI_2_4.Value), 2);
            strana_a.Doprinosi.KapitaliziranaStednja.P5 = decimal.Round(Conversions.ToDecimal(txtUkupno_VI_2_5.Value), 2);

            strana_a.Doprinosi.Zaposljavanje = new JOPPD.sZaposljavanje();
            strana_a.Doprinosi.Zaposljavanje.P1 = decimal.Round(Conversions.ToDecimal(txtUkupno_VI_4_1.Value), 2);
            strana_a.Doprinosi.Zaposljavanje.P2 = decimal.Round(Conversions.ToDecimal(txtUkupno_VI_4_2.Value), 2);
            strana_a.Doprinosi.Zaposljavanje.P3 = 0.00M;

            strana_a.Doprinosi.ZdravstvenoOsiguranje = new JOPPD.sZdravstvenoOsiguranje();
            strana_a.Doprinosi.ZdravstvenoOsiguranje.P1 = decimal.Round(Conversions.ToDecimal(txtUkupno_VI_3_1.Value), 2);
            strana_a.Doprinosi.ZdravstvenoOsiguranje.P2 = decimal.Round(Conversions.ToDecimal(txtUkupno_VI_3_2.Value), 2);
            strana_a.Doprinosi.ZdravstvenoOsiguranje.P3 = decimal.Round(Conversions.ToDecimal(txtUkupno_VI_3_3.Value), 2);
            strana_a.Doprinosi.ZdravstvenoOsiguranje.P4 = decimal.Round(Conversions.ToDecimal(txtUkupno_VI_3_4.Value), 2);
            strana_a.Doprinosi.ZdravstvenoOsiguranje.P5 = decimal.Round(Conversions.ToDecimal(txtUkupno_VI_3_5.Value), 2);
            strana_a.Doprinosi.ZdravstvenoOsiguranje.P6 = decimal.Round(Conversions.ToDecimal(txtUkupno_VI_3_6.Value), 2);
            strana_a.Doprinosi.ZdravstvenoOsiguranje.P7 = decimal.Round(Conversions.ToDecimal(txtUkupno_VI_3_7.Value), 2);
            strana_a.Doprinosi.ZdravstvenoOsiguranje.P8 = decimal.Round(Conversions.ToDecimal(txtUkupno_VI_3_8.Value), 2);
            strana_a.Doprinosi.ZdravstvenoOsiguranje.P9 = decimal.Round(Conversions.ToDecimal(txtUkupno_VI_3_9.Value), 2);
            strana_a.Doprinosi.ZdravstvenoOsiguranje.P10 = decimal.Round(Conversions.ToDecimal(txtUkupno_VI_3_10.Value), 2);

            strana_a.IsplaceniNeoporeziviPrimici = decimal.Round(Conversions.ToDecimal(txtUkupno_VII.Value), 2);

            strana_a.IzvjesceSastavio = new JOPPD.sIzvjesceSastavio();
            strana_a.IzvjesceSastavio.Ime = kontak_ime;
            strana_a.IzvjesceSastavio.Prezime = kontakt_prezime;

            strana_a.UkupniNeoporeziviPrimiciSpecified = false;

            strana_a.KamataMO2 = decimal.Round(Conversions.ToDecimal(txtUkupnoVIII.Value), 2);

            string mjesto = korisnik["KORISNIK1MJESTO"].ToString().Trim();
            string [] ulica_polje = korisnik["KORISNIK1ADRESA"].ToString().Split(' ');
            string ulica = "";
            string broj = "";
            int broj_slogova = ulica_polje.Length;

            if (broj_slogova > 1)
            {
                broj = ulica_polje[broj_slogova - 1];

                for (int i = 0; i < broj_slogova - 1; i++)
                {
                    ulica += ulica_polje[i] + " ";
                }
            }
            else
            {
                MessageBox.Show("U modulu Korisnik šifarnici za korisnika aplikacije nisu popunjeni svi podaci.\nPotreban je naziv i kućni broj u adresi.");
                return;
            }

            if (lblOznakaPod.Text == "6")
            {
                strana_a.ObveznikPlacanja = new JOPPD.sObveznikPlacanja();
                strana_a.ObveznikPlacanja.Adresa = new JOPPD.sAdresa();
                strana_a.ObveznikPlacanja.Adresa.Broj = "38";
                strana_a.ObveznikPlacanja.Adresa.Mjesto = "Zagreb";
                strana_a.ObveznikPlacanja.Adresa.Ulica = "Donje Svetice";
                strana_a.ObveznikPlacanja.Email = "odgojiobrazovanje@mzos.hr";
                strana_a.ObveznikPlacanja.OIB = "49508397045";
                strana_a.ObveznikPlacanja.Items = new string[1];
                strana_a.ObveznikPlacanja.Items[0] = "Ministarstvo znanosti, obrazovanja i sporta";
                strana_a.ObveznikPlacanja.ItemsElementName = new JOPPD.ItemsChoiceType1[1];
                strana_a.ObveznikPlacanja.ItemsElementName[0] = JOPPD.ItemsChoiceType1.Naziv;

            }
            else
            {
                strana_a.ObveznikPlacanja = new JOPPD.sObveznikPlacanja();
                strana_a.ObveznikPlacanja.Adresa = new JOPPD.sAdresa();
                strana_a.ObveznikPlacanja.Adresa.Broj = broj;
                strana_a.ObveznikPlacanja.Adresa.Mjesto = mjesto;
                strana_a.ObveznikPlacanja.Adresa.Ulica = ulica.TrimEnd();
                strana_a.ObveznikPlacanja.Email = txtAdresaElektronickePoste.Text.Trim();
                strana_a.ObveznikPlacanja.OIB = txtOIB.Text.Trim();
                strana_a.ObveznikPlacanja.Items = new string[1];
                strana_a.ObveznikPlacanja.Items[0] = txtNazivImePrezime.Text.Trim();
                strana_a.ObveznikPlacanja.ItemsElementName = new JOPPD.ItemsChoiceType1[1];
                strana_a.ObveznikPlacanja.ItemsElementName[0] = JOPPD.ItemsChoiceType1.Naziv;
            }

            strana_a.PodnositeljIzvjesca = new JOPPD.sPodnositeljIzvjesca();
            strana_a.PodnositeljIzvjesca.Oznaka = OznakaPodnositelja(lblOznakaPod.Text);
            strana_a.PodnositeljIzvjesca.OIB = txtOIB.Text.Trim();
            strana_a.PodnositeljIzvjesca.Email = txtAdresaElektronickePoste.Text.Trim();
            strana_a.PodnositeljIzvjesca.Adresa = new JOPPD.sAdresa();
            strana_a.PodnositeljIzvjesca.Adresa.Broj = broj;
            strana_a.PodnositeljIzvjesca.Adresa.Mjesto = mjesto;
            strana_a.PodnositeljIzvjesca.Adresa.Ulica = ulica.TrimEnd();
            strana_a.PodnositeljIzvjesca.Items = new string[1];
            strana_a.PodnositeljIzvjesca.Items[0] = txtNazivImePrezime.Text.Trim();
            strana_a.PodnositeljIzvjesca.ItemsElementName = new JOPPD.ItemsChoiceType[1];
            strana_a.PodnositeljIzvjesca.ItemsElementName[0] = JOPPD.ItemsChoiceType.Naziv;

            strana_a.PredujamPoreza = new JOPPD.sPredujamPoreza();
            strana_a.PredujamPoreza.P1 = decimal.Round(Conversions.ToDecimal(txtUkupno_V_1.Value), 2);
            strana_a.PredujamPoreza.P2 = decimal.Round(Conversions.ToDecimal(txtUkupno_V_2.Value), 2);
            strana_a.PredujamPoreza.P3 = decimal.Round(Conversions.ToDecimal(txtUkupno_V_3.Value), 2);
            strana_a.PredujamPoreza.P4 = decimal.Round(Conversions.ToDecimal(txtUkupno_V_4.Value), 2);
            strana_a.PredujamPoreza.P5 = decimal.Round(Conversions.ToDecimal(txtUkupno_V_5.Value), 2);
            strana_a.PredujamPoreza.P11 = decimal.Round(Conversions.ToDecimal(txtUkupno_V_1_1.Value), 2);
            strana_a.PredujamPoreza.P12 = decimal.Round(Conversions.ToDecimal(txtUkupno_V_1_2.Value), 2);

            string vrsta_izvjesca = client.GetDataTable("Select Sifra From JOPPDAVrstaIzvjesca Inner Join JOPPDA ON JOPPDAVrstaIzvjesca.ID = " +
                                    "JOPPDA.VrstaIzvjescaID Where JOPPDA.ID = '" + JOPPDID + "'").Rows[0]["Sifra"].ToString();

            strana_a.OznakaIzvjesca = lblOznakaIzvjesca.Text.Trim();

            if (vrsta_izvjesca == "1")
                strana_a.VrstaIzvjesca = JOPPD.tVrstaIzvjesca.Item1;
            else if (vrsta_izvjesca == "2")
                strana_a.VrstaIzvjesca = JOPPD.tVrstaIzvjesca.Item2;
            else if (vrsta_izvjesca == "3")
                strana_a.VrstaIzvjesca = JOPPD.tVrstaIzvjesca.Item3;
            else if (vrsta_izvjesca == "4")
                strana_a.VrstaIzvjesca = JOPPD.tVrstaIzvjesca.Item4;


            //novo virmani invalidi 23.02.2015
            strana_a.NaknadaZaposljavanjeInvalida = new JOPPD.sNaknadaZaposljavanjeInvalida();
            strana_a.NaknadaZaposljavanjeInvalida.P1 = txtBrojOsoba.Text.Trim();
            strana_a.NaknadaZaposljavanjeInvalida.P2Specified = true;
            if (Conversions.ToDecimal(txtIznosNaknade.Value) > 0)
            {
                strana_a.NaknadaZaposljavanjeInvalida.P2 = decimal.Round(Conversions.ToDecimal(txtIznosNaknade.Value), 2);
            }
            else
            {
                strana_a.NaknadaZaposljavanjeInvalida.P2 = 0M;
            }
            
            obrazac.StranaA = strana_a;

            //punjene strane B
            DataTable tblJOPPDB = client.GetDataTable("SELECT JOPPDAID, RedniBroj, SifraOpcinePrebivalista,SifraOpcineRada, " +
                                    "OIBStjecatelja, ImePrezimeStjecatelja, OznakaStjecatelja, OznakaPrimitka, ObvezaDodatnogDoprinosa, " +
                                    "ObvezaPosebnogDoprinosa, OznakaMjesecaOsiguranje, OznakaRadnogVremena, SatiRada, NeodradeniSatiRada, RazdobljeOd, RazdobljeDo, " + 
                                    "Primitak, Osnovica, DoprinosMirovinsko, DoprinosMirovinskoII, DoprinosZdravstveno, DoprinosZastita, DoprinosZaposljavanje, " +
                                    "DodatniDoprinosMirovinsko, DodatniDoprinosMirovinskoII, PosebanDoprinosZdravstveno, PosebanDoprinosZaposljavanje, Izdatak, " +
                                    "IzdatakDoprinosMirovinsko, Dohodak, OsobniOdbitak, PoreznaOsnovica, PorezNaDohodak, Prirez, OznakaNeoporezivogPrimitka, " +
                                    "NeoporezivPrimitak, OznakaNacinaIsplate, Isplata, ObracunatiPrimitak FROM JOPPDB Where JOPPDAID = '" + JOPPDID + "'");
            int brojac = 0;

            JOPPD.sPrimateljiP[] primatelj = new JOPPD.sPrimateljiP[tblJOPPDB.Rows.Count];

            foreach (DataRow red in tblJOPPDB.Rows)
            {
                //osobe unutar istog primatelja
                primatelj[brojac] = new JOPPD.sPrimateljiP();
                primatelj[brojac].P1 = Convert.ToInt32(red["RedniBroj"]);
                primatelj[brojac].P10 = Convert.ToInt32(red["SatiRada"]);
                primatelj[brojac].P101 = Convert.ToDateTime(red["RazdobljeOd"]);
                primatelj[brojac].P102 = Convert.ToDateTime(red["RazdobljeDo"]);
                primatelj[brojac].P11 = decimal.Round(Conversions.ToDecimal(red["Primitak"]), 2);
                primatelj[brojac].P12 = decimal.Round(Conversions.ToDecimal(red["Osnovica"]), 2);
                primatelj[brojac].P121 = decimal.Round(Conversions.ToDecimal(red["DoprinosMirovinsko"]), 2);
                primatelj[brojac].P122 = decimal.Round(Conversions.ToDecimal(red["DoprinosMirovinskoII"]), 2);
                primatelj[brojac].P123 = decimal.Round(Conversions.ToDecimal(red["DoprinosZdravstveno"]), 2);
                primatelj[brojac].P124 = decimal.Round(Conversions.ToDecimal(red["DoprinosZastita"]), 2);
                primatelj[brojac].P125 = decimal.Round(Conversions.ToDecimal(red["DoprinosZaposljavanje"]), 2);
                primatelj[brojac].P126 = decimal.Round(Conversions.ToDecimal(red["DodatniDoprinosMirovinsko"]), 2);
                primatelj[brojac].P127 = decimal.Round(Conversions.ToDecimal(red["DodatniDoprinosMirovinskoII"]), 2);
                primatelj[brojac].P128 = decimal.Round(Conversions.ToDecimal(red["PosebanDoprinosZdravstveno"]), 2);
                primatelj[brojac].P129 = decimal.Round(Conversions.ToDecimal(red["PosebanDoprinosZaposljavanje"]), 2);
                primatelj[brojac].P131 = decimal.Round(Conversions.ToDecimal(red["Izdatak"]), 2);
                primatelj[brojac].P132 = decimal.Round(Conversions.ToDecimal(red["IzdatakDoprinosMirovinsko"]), 2);
                primatelj[brojac].P133 = decimal.Round(Conversions.ToDecimal(red["Dohodak"]), 2);
                primatelj[brojac].P134 = decimal.Round(Conversions.ToDecimal(red["OsobniOdbitak"]), 2);
                primatelj[brojac].P135 = decimal.Round(Conversions.ToDecimal(red["PoreznaOsnovica"]), 2);
                primatelj[brojac].P141 = decimal.Round(Conversions.ToDecimal(red["PorezNaDohodak"]), 2); 
                primatelj[brojac].P142 = decimal.Round(Conversions.ToDecimal(red["Prirez"]), 2);
                primatelj[brojac].P162 = decimal.Round(Conversions.ToDecimal(red["Isplata"]), 2);
                primatelj[brojac].P17 = decimal.Round(Conversions.ToDecimal(red["ObracunatiPrimitak"]), 2);
                primatelj[brojac].P152 = decimal.Round(Conversions.ToDecimal(red["NeoporezivPrimitak"]), 2);

                primatelj[brojac].P2 = red["SifraOpcinePrebivalista"].ToString();
                primatelj[brojac].P3 = red["SifraOpcineRada"].ToString();
                primatelj[brojac].P4 = red["OIBStjecatelja"].ToString();
                primatelj[brojac].P5 = red["ImePrezimeStjecatelja"].ToString();

                primatelj[brojac].P151 = OznakaNeoporezivogPrimitka(red["OznakaNeoporezivogPrimitka"].ToString());
                primatelj[brojac].P161 = OznakaNacinaIsplate(red["OznakaNacinaIsplate"].ToString());
                primatelj[brojac].P61 = OznakaStjecatelja(red["OznakaStjecatelja"].ToString());
                primatelj[brojac].P62 = OznakaPrimici(red["OznakaPrimitka"].ToString());
                primatelj[brojac].P8 = OznakaMjesec(red["OznakaMjesecaOsiguranje"].ToString());
                primatelj[brojac].P9 = OznakaRadnoVrijeme(red["OznakaRadnogVremena"].ToString());
                primatelj[brojac].P72 = OznakaInvaliditet(red["ObvezaPosebnogDoprinosa"].ToString());
                primatelj[brojac].P71 = OznakaMO(red["ObvezaDodatnogDoprinosa"].ToString());
                primatelj[brojac].P100 = Convert.ToInt32(red["NeodradeniSatiRada"]);

                brojac++;
            }

            obrazac.StranaB = new JOPPD.sPrimateljiP[1][];
            obrazac.StranaB[0] = primatelj;

            //zapis u xml file
            try
            {
                SaveFileDialog dialog2 = new SaveFileDialog
                {
                    FileName = "JOPPD-" + DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year + ".xml",
                    RestoreDirectory = true
                };

                SaveFileDialog dialog = dialog2;
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    using (TextWriter writer = new StreamWriter(dialog.FileName))
                    {
                        XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
                        namespaces.Add("ns1", "http://e-porezna.porezna-uprava.hr/sheme/zahtjevi/ObrazacJOPPD/v1-1");
                        new XmlSerializer(typeof(JOPPD.sObrazacJOPPD), "http://e-porezna.porezna-uprava.hr/sheme/zahtjevi/ObrazacJOPPD/v1-1").Serialize(writer, obrazac, namespaces);

                        writer.Close();
                    }
                    MessageBox.Show("Datoteka uspješno spremljena u: " + dialog.FileName);

                    string xmlText = File.ReadAllText(dialog.FileName);
                    string utf = xmlText.Replace("utf-8", "UTF-8");
                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(utf);
                    doc.Save(dialog.FileName);

                }
            }
            catch (Exception greska)
            {
                MessageBox.Show("Dogodila se greška prilikom kreiranja JOPPD xml datoteke!!!\nKontaktirajete administratora.\n" + greska.Message);
            }
        }

        private JOPPD.tOznakaPodnositelja OznakaPodnositelja(string oznaka_podnositelja)
        {
            JOPPD.tOznakaPodnositelja vrati = JOPPD.tOznakaPodnositelja.Item1;

            switch (oznaka_podnositelja)
            {
                case "1":
                    vrati = JOPPD.tOznakaPodnositelja.Item1;
                    break;
                case "2":
                    vrati = JOPPD.tOznakaPodnositelja.Item2;
                    break;
                case "3":
                    vrati = JOPPD.tOznakaPodnositelja.Item3;
                    break;
                case "4":
                    vrati = JOPPD.tOznakaPodnositelja.Item4;
                    break;
                case "5":
                    vrati = JOPPD.tOznakaPodnositelja.Item5;
                    break;
                case "6":
                    vrati = JOPPD.tOznakaPodnositelja.Item6;
                    break;
                case "7":
                    vrati = JOPPD.tOznakaPodnositelja.Item7;
                    break;
                case "8":
                    vrati = JOPPD.tOznakaPodnositelja.Item8;
                    break;
                case "9":
                    vrati = JOPPD.tOznakaPodnositelja.Item9;
                    break;
                case "10":
                    vrati = JOPPD.tOznakaPodnositelja.Item10;
                    break;
                case "11":
                    vrati = JOPPD.tOznakaPodnositelja.Item11;
                    break;
                case "12":
                    vrati = JOPPD.tOznakaPodnositelja.Item12;
                    break;
                case "13":
                    vrati = JOPPD.tOznakaPodnositelja.Item13;
                    break;
            }
            return vrati;
        }

        private JOPPD.tOznakaRadnoVrijeme OznakaRadnoVrijeme(string oznaka_radno_vrijeme)
        {
            JOPPD.tOznakaRadnoVrijeme vrati = JOPPD.tOznakaRadnoVrijeme.Item0;

            switch (oznaka_radno_vrijeme)
            {
                case "0":
                    vrati = JOPPD.tOznakaRadnoVrijeme.Item0;
                    break;
                case "1":
                    vrati = JOPPD.tOznakaRadnoVrijeme.Item1;
                    break;
                case "2":
                    vrati = JOPPD.tOznakaRadnoVrijeme.Item2;
                    break;
                case "3":
                    vrati = JOPPD.tOznakaRadnoVrijeme.Item3;
                    break;
            }
            return vrati;
        }

        private JOPPD.tOznakaMjesec OznakaMjesec(string oznaka_mjesec)
        {
            JOPPD.tOznakaMjesec vrati = JOPPD.tOznakaMjesec.Item0;

            switch (oznaka_mjesec)
            {
                case "0":
                    vrati = JOPPD.tOznakaMjesec.Item0;
                    break;
                case "1":
                    vrati = JOPPD.tOznakaMjesec.Item1;
                    break;
                case "2":
                    vrati = JOPPD.tOznakaMjesec.Item2;
                    break;
                case "3":
                    vrati = JOPPD.tOznakaMjesec.Item3;
                    break;
                case "4":
                    vrati = JOPPD.tOznakaMjesec.Item4;
                    break;
                case "5":
                    vrati = JOPPD.tOznakaMjesec.Item5;
                    break;
            }
            return vrati;
        }

        private JOPPD.tOznakaInvaliditet OznakaInvaliditet(string oznaka_invaliditiet)
        {
            JOPPD.tOznakaInvaliditet vrati = JOPPD.tOznakaInvaliditet.Item0;

            switch (oznaka_invaliditiet)
            {
                case "0":
                    vrati = JOPPD.tOznakaInvaliditet.Item0;
                    break;
                case "1":
                    vrati = JOPPD.tOznakaInvaliditet.Item1;
                    break;
                case "2":
                    vrati = JOPPD.tOznakaInvaliditet.Item2;
                    break;
            }
            return vrati;
        }

        private JOPPD.tOznakaMO OznakaMO(string oznaka_mo)
        {
            JOPPD.tOznakaMO vrati = JOPPD.tOznakaMO.Item0;

            switch (oznaka_mo)
            {
                case "0":
                    vrati = JOPPD.tOznakaMO.Item0;
                    break;
                case "1":
                    vrati = JOPPD.tOznakaMO.Item1;
                    break;
                case "2":
                    vrati = JOPPD.tOznakaMO.Item2;
                    break;
                case "3":
                    vrati = JOPPD.tOznakaMO.Item3;
                    break;
                case "4":
                    vrati = JOPPD.tOznakaMO.Item4;
                    break;
            }
            return vrati;
        }

        private JOPPD.tOznakaPrimici OznakaPrimici(string oznaka_primici)
        {
            JOPPD.tOznakaPrimici vrati = JOPPD.tOznakaPrimici.Item0000;

            switch (oznaka_primici)
            {
                case "0000":
                    vrati = JOPPD.tOznakaPrimici.Item0000;
                    break;
                case "0001":
                    vrati = JOPPD.tOznakaPrimici.Item0001;
                    break;
                case "0002":
                    vrati = JOPPD.tOznakaPrimici.Item0002;
                    break;
                case "0003":
                    vrati = JOPPD.tOznakaPrimici.Item0003;
                    break;
                case "0004":
                    vrati = JOPPD.tOznakaPrimici.Item0004;
                    break;
                case "0021":
                    vrati = JOPPD.tOznakaPrimici.Item0021;
                    break;
                case "0022":
                    vrati = JOPPD.tOznakaPrimici.Item0022;
                    break;
                case "0023":
                    vrati = JOPPD.tOznakaPrimici.Item0023;
                    break;
                case "0024":
                    vrati = JOPPD.tOznakaPrimici.Item0024;
                    break;
                case "0025":
                    vrati = JOPPD.tOznakaPrimici.Item0025;
                    break;
                case "0026":
                    vrati = JOPPD.tOznakaPrimici.Item0026;
                    break;
                case "0027":
                    vrati = JOPPD.tOznakaPrimici.Item0027;
                    break;
                case "0028":
                    vrati = JOPPD.tOznakaPrimici.Item0028;
                    break;
                case "0041":
                    vrati = JOPPD.tOznakaPrimici.Item0041;
                    break;
                case "0042":
                    vrati = JOPPD.tOznakaPrimici.Item0042;
                    break;
                case "0043":
                    vrati = JOPPD.tOznakaPrimici.Item0043;
                    break;
                case "0044":
                    vrati = JOPPD.tOznakaPrimici.Item0044;
                    break;
                case "0045":
                    vrati = JOPPD.tOznakaPrimici.Item0045;
                    break;
                case "0046":
                    vrati = JOPPD.tOznakaPrimici.Item0046;
                    break;
                case "0051":
                    vrati = JOPPD.tOznakaPrimici.Item0051;
                    break;
                case "0052":
                    vrati = JOPPD.tOznakaPrimici.Item0052;
                    break;
                case "0061":
                    vrati = JOPPD.tOznakaPrimici.Item0061;
                    break;
                case "0062":
                    vrati = JOPPD.tOznakaPrimici.Item0062;
                    break;
                case "0063":
                    vrati = JOPPD.tOznakaPrimici.Item0063;
                    break;
                case "0064":
                    vrati = JOPPD.tOznakaPrimici.Item0064;
                    break;
                case "0071":
                    vrati = JOPPD.tOznakaPrimici.Item0071;
                    break;
                case "0081":
                    vrati = JOPPD.tOznakaPrimici.Item0081;
                    break;
                case "0082":
                    vrati = JOPPD.tOznakaPrimici.Item0082;
                    break;
                case "0083":
                    vrati = JOPPD.tOznakaPrimici.Item0083;
                    break;
                case "0084":
                    vrati = JOPPD.tOznakaPrimici.Item0084;
                    break;
                case "0086":
                    vrati = JOPPD.tOznakaPrimici.Item0086;
                    break;
                case "0091":
                    vrati = JOPPD.tOznakaPrimici.Item0091;
                    break;
                case "0101":
                    vrati = JOPPD.tOznakaPrimici.Item0101;
                    break;
                case "0102":
                    vrati = JOPPD.tOznakaPrimici.Item0102;
                    break;
                case "0103":
                    vrati = JOPPD.tOznakaPrimici.Item0103;
                    break;
                case "0201":
                    vrati = JOPPD.tOznakaPrimici.Item0201;
                    break;
                case "0202":
                    vrati = JOPPD.tOznakaPrimici.Item0202;
                    break;
                case "0203":
                    vrati = JOPPD.tOznakaPrimici.Item0203;
                    break;
                case "0204":
                    vrati = JOPPD.tOznakaPrimici.Item0204;
                    break;
                case "0205":
                    vrati = JOPPD.tOznakaPrimici.Item0205;
                    break;
                case "0206":
                    vrati = JOPPD.tOznakaPrimici.Item0206;
                    break;
                case "0207":
                    vrati = JOPPD.tOznakaPrimici.Item0207;
                    break;
                case "0208":
                    vrati = JOPPD.tOznakaPrimici.Item0208;
                    break;
                case "0209":
                    vrati = JOPPD.tOznakaPrimici.Item0209;
                    break;
                case "0210":
                    vrati = JOPPD.tOznakaPrimici.Item0210;
                    break;
                case "0211":
                    vrati = JOPPD.tOznakaPrimici.Item0211;
                    break;
                case "0212":
                    vrati = JOPPD.tOznakaPrimici.Item0212;
                    break;
                case "0213":
                    vrati = JOPPD.tOznakaPrimici.Item0213;
                    break;
                case "0214":
                    vrati = JOPPD.tOznakaPrimici.Item0214;
                    break;
                case "0301":
                    vrati = JOPPD.tOznakaPrimici.Item0301;
                    break;
                case "0302":
                    vrati = JOPPD.tOznakaPrimici.Item0302;
                    break;
                case "0303":
                    vrati = JOPPD.tOznakaPrimici.Item0303;
                    break;
                case "0321":
                    vrati = JOPPD.tOznakaPrimici.Item0321;
                    break;
                case "0322":
                    vrati = JOPPD.tOznakaPrimici.Item0322;
                    break;
                case "0323":
                    vrati = JOPPD.tOznakaPrimici.Item0323;
                    break;
                case "0331":
                    vrati = JOPPD.tOznakaPrimici.Item0331;
                    break;
                case "0332":
                    vrati = JOPPD.tOznakaPrimici.Item0332;
                    break;
                case "0333":
                    vrati = JOPPD.tOznakaPrimici.Item0333;
                    break;
                case "0334":
                    vrati = JOPPD.tOznakaPrimici.Item0334;
                    break;
                case "0401":
                    vrati = JOPPD.tOznakaPrimici.Item0401;
                    break;
                case "0402":
                    vrati = JOPPD.tOznakaPrimici.Item0402;
                    break;
                case "0403":
                    vrati = JOPPD.tOznakaPrimici.Item0403;
                    break;
                case "0404":
                    vrati = JOPPD.tOznakaPrimici.Item0404;
                    break;
                case "0405":
                    vrati = JOPPD.tOznakaPrimici.Item0405;
                    break;
                case "0406":
                    vrati = JOPPD.tOznakaPrimici.Item0406;
                    break;
                case "1001":
                    vrati = JOPPD.tOznakaPrimici.Item1001;
                    break;
                case "1002":
                    vrati = JOPPD.tOznakaPrimici.Item1002;
                    break;
                case "1003":
                    vrati = JOPPD.tOznakaPrimici.Item1003;
                    break;
                case "1004":
                    vrati = JOPPD.tOznakaPrimici.Item1004;
                    break;
                case "1005":
                    vrati = JOPPD.tOznakaPrimici.Item1005;
                    break;
                case "2001":
                    vrati = JOPPD.tOznakaPrimici.Item2001;
                    break;
                case "3001":
                    vrati = JOPPD.tOznakaPrimici.Item3001;
                    break;
                case "3002":
                    vrati = JOPPD.tOznakaPrimici.Item3002;
                    break;
                case "4001":
                    vrati = JOPPD.tOznakaPrimici.Item4001;
                    break;
                case "4002":
                    vrati = JOPPD.tOznakaPrimici.Item4002;
                    break;
                case "4003":
                    vrati = JOPPD.tOznakaPrimici.Item4003;
                    break;
                case "4004":
                    vrati = JOPPD.tOznakaPrimici.Item4004;
                    break;
                case "4005":
                    vrati = JOPPD.tOznakaPrimici.Item4005;
                    break;
                case "4006":
                    vrati = JOPPD.tOznakaPrimici.Item4006;
                    break;
                case "4007":
                    vrati = JOPPD.tOznakaPrimici.Item4007;
                    break;
                case "4008":
                    vrati = JOPPD.tOznakaPrimici.Item4008;
                    break;
                case "4009":
                    vrati = JOPPD.tOznakaPrimici.Item4009;
                    break;
                case "4010":
                    vrati = JOPPD.tOznakaPrimici.Item4010;
                    break;
                case "4011":
                    vrati = JOPPD.tOznakaPrimici.Item4011;
                    break;
                case "4012":
                    vrati = JOPPD.tOznakaPrimici.Item4012;
                    break;
                case "4013":
                    vrati = JOPPD.tOznakaPrimici.Item4013;
                    break;
                case "4014":
                    vrati = JOPPD.tOznakaPrimici.Item4014;
                    break;
                case "4015":
                    vrati = JOPPD.tOznakaPrimici.Item4015;
                    break;
                case "4016":
                    vrati = JOPPD.tOznakaPrimici.Item4016;
                    break;
                case "4017":
                    vrati = JOPPD.tOznakaPrimici.Item4017;
                    break;
                case "4018":
                    vrati = JOPPD.tOznakaPrimici.Item4018;
                    break;
                case "4019":
                    vrati = JOPPD.tOznakaPrimici.Item4019;
                    break;
                case "4020":
                    vrati = JOPPD.tOznakaPrimici.Item4020;
                    break;
                case "4021":
                    vrati = JOPPD.tOznakaPrimici.Item4021;
                    break;
                case "4022":
                    vrati = JOPPD.tOznakaPrimici.Item4022;
                    break;
                case "4023":
                    vrati = JOPPD.tOznakaPrimici.Item4023;
                    break;
                case "4024":
                    vrati = JOPPD.tOznakaPrimici.Item4024;
                    break;
                case "4025":
                    vrati = JOPPD.tOznakaPrimici.Item4025;
                    break;
                case "4026":
                    vrati = JOPPD.tOznakaPrimici.Item4026;
                    break;
                case "4027":
                    vrati = JOPPD.tOznakaPrimici.Item4027;
                    break;
                case "4028":
                    vrati = JOPPD.tOznakaPrimici.Item4028;
                    break;
                case "4029":
                    vrati = JOPPD.tOznakaPrimici.Item4029;
                    break;
                case "4030":
                    vrati = JOPPD.tOznakaPrimici.Item4030;
                    break;
                case "4031":
                    vrati = JOPPD.tOznakaPrimici.Item4031;
                    break;
                case "4032":
                    vrati = JOPPD.tOznakaPrimici.Item4032;
                    break;
                case "4033":
                    vrati = JOPPD.tOznakaPrimici.Item4033;
                    break;
                case "4034":
                    vrati = JOPPD.tOznakaPrimici.Item4034;
                    break;
                case "4035":
                    vrati = JOPPD.tOznakaPrimici.Item4035;
                    break;
                case "4036":
                    vrati = JOPPD.tOznakaPrimici.Item4036;
                    break;
                case "4037":
                    vrati = JOPPD.tOznakaPrimici.Item4037;
                    break;
                case "5001":
                    vrati = JOPPD.tOznakaPrimici.Item5001;
                    break;
                case "5002":
                    vrati = JOPPD.tOznakaPrimici.Item5002;
                    break;
                case "5003":
                    vrati = JOPPD.tOznakaPrimici.Item5003;
                    break;
                case "5004":
                    vrati = JOPPD.tOznakaPrimici.Item5004;
                    break;
                case "5005":
                    vrati = JOPPD.tOznakaPrimici.Item5005;
                    break;
                case "5101":
                    vrati = JOPPD.tOznakaPrimici.Item5101;
                    break;
                case "5102":
                    vrati = JOPPD.tOznakaPrimici.Item5102;
                    break;
                case "5103":
                    vrati = JOPPD.tOznakaPrimici.Item5103;
                    break;
                case "5104":
                    vrati = JOPPD.tOznakaPrimici.Item5104;
                    break;
                case "5105":
                    vrati = JOPPD.tOznakaPrimici.Item5105;
                    break;
                case "5106":
                    vrati = JOPPD.tOznakaPrimici.Item5106;
                    break;
                case "5107":
                    vrati = JOPPD.tOznakaPrimici.Item5107;
                    break;
                case "5108":
                    vrati = JOPPD.tOznakaPrimici.Item5108;
                    break;
                case "5109":
                    vrati = JOPPD.tOznakaPrimici.Item5109;
                    break;
                case "5110":
                    vrati = JOPPD.tOznakaPrimici.Item5110;
                    break;
                case "5111":
                    vrati = JOPPD.tOznakaPrimici.Item5111;
                    break;
                case "5112":
                    vrati = JOPPD.tOznakaPrimici.Item5112;
                    break;
                case "5701":
                    vrati = JOPPD.tOznakaPrimici.Item5701;
                    break;
                case "5702":
                    vrati = JOPPD.tOznakaPrimici.Item5702;
                    break;
                case "5703":
                    vrati = JOPPD.tOznakaPrimici.Item5703;
                    break;
                case "5721":
                    vrati = JOPPD.tOznakaPrimici.Item5721;
                    break;
            }
            return vrati;
        }

        private JOPPD.tOznakaStjecatelja OznakaStjecatelja(string oznaka_stjecatelja)
        {
            JOPPD.tOznakaStjecatelja vrati = JOPPD.tOznakaStjecatelja.Item0000;

            switch (oznaka_stjecatelja)
            {
                case "0000":
                    vrati = JOPPD.tOznakaStjecatelja.Item0000;
                    break;
                case "0001":
                    vrati = JOPPD.tOznakaStjecatelja.Item0001;
                    break;
                case "0002":
                    vrati = JOPPD.tOznakaStjecatelja.Item0002;
                    break;
                case "0003":
                    vrati = JOPPD.tOznakaStjecatelja.Item0003;
                    break;
                case "0004":
                    vrati = JOPPD.tOznakaStjecatelja.Item0004;
                    break;
                case "0005":
                    vrati = JOPPD.tOznakaStjecatelja.Item0005;
                    break;
                case "0006":
                    vrati = JOPPD.tOznakaStjecatelja.Item0006;
                    break;
                case "0007":
                    vrati = JOPPD.tOznakaStjecatelja.Item0007;
                    break;
                case "0008":
                    vrati = JOPPD.tOznakaStjecatelja.Item0008;
                    break;
                case "0009":
                    vrati = JOPPD.tOznakaStjecatelja.Item0009;
                    break;
                case "0010":
                    vrati = JOPPD.tOznakaStjecatelja.Item0010;
                    break;
                case "0021":
                    vrati = JOPPD.tOznakaStjecatelja.Item0021;
                    break;
                case "0022":
                    vrati = JOPPD.tOznakaStjecatelja.Item0022;
                    break;
                case "0023":
                    vrati = JOPPD.tOznakaStjecatelja.Item0023;
                    break;
                case "0024":
                    vrati = JOPPD.tOznakaStjecatelja.Item0024;
                    break;
                case "0031":
                    vrati = JOPPD.tOznakaStjecatelja.Item0031;
                    break;
                case "0032":
                    vrati = JOPPD.tOznakaStjecatelja.Item0032;
                    break;
                case "0033":
                    vrati = JOPPD.tOznakaStjecatelja.Item0033;
                    break;
                case "0101":
                    vrati = JOPPD.tOznakaStjecatelja.Item0101;
                    break;
                case "0102":
                    vrati = JOPPD.tOznakaStjecatelja.Item0102;
                    break;
                case "0103":
                    vrati = JOPPD.tOznakaStjecatelja.Item0103;
                    break;
                case "0104":
                    vrati = JOPPD.tOznakaStjecatelja.Item0104;
                    break;
                case "0105":
                    vrati = JOPPD.tOznakaStjecatelja.Item0105;
                    break;
                case "0106":
                    vrati = JOPPD.tOznakaStjecatelja.Item0106;
                    break;
                case "0107":
                    vrati = JOPPD.tOznakaStjecatelja.Item0107;
                    break;
                case "0108":
                    vrati = JOPPD.tOznakaStjecatelja.Item0108;
                    break;
                case "0121":
                    vrati = JOPPD.tOznakaStjecatelja.Item0121;
                    break;
                case "0201":
                    vrati = JOPPD.tOznakaStjecatelja.Item0201;
                    break;
                case "1001":
                    vrati = JOPPD.tOznakaStjecatelja.Item1001;
                    break;
                case "2001":
                    vrati = JOPPD.tOznakaStjecatelja.Item2001;
                    break;
                case "3001":
                    vrati = JOPPD.tOznakaStjecatelja.Item3001;
                    break;
                case "4001":
                    vrati = JOPPD.tOznakaStjecatelja.Item4001;
                    break;
                case "4002":
                    vrati = JOPPD.tOznakaStjecatelja.Item4002;
                    break;
                case "5001":
                    vrati = JOPPD.tOznakaStjecatelja.Item5001;
                    break;
                case "5002":
                    vrati = JOPPD.tOznakaStjecatelja.Item5002;
                    break;
                case "5101":
                    vrati = JOPPD.tOznakaStjecatelja.Item5101;
                    break;
                case "5102":
                    vrati = JOPPD.tOznakaStjecatelja.Item5102;
                    break;
                case "5103":
                    vrati = JOPPD.tOznakaStjecatelja.Item5103;
                    break;
                case "5104":
                    vrati = JOPPD.tOznakaStjecatelja.Item5104;
                    break;
                case "5201":
                    vrati = JOPPD.tOznakaStjecatelja.Item5201;
                    break;
                case "5202":
                    vrati = JOPPD.tOznakaStjecatelja.Item5202;
                    break;
                case "5203":
                    vrati = JOPPD.tOznakaStjecatelja.Item5203;
                    break;
                case "5204":
                    vrati = JOPPD.tOznakaStjecatelja.Item5204;
                    break;
                case "5205":
                    vrati = JOPPD.tOznakaStjecatelja.Item5205;
                    break;
                case "5206":
                    vrati = JOPPD.tOznakaStjecatelja.Item5206;
                    break;
                case "5207":
                    vrati = JOPPD.tOznakaStjecatelja.Item5207;
                    break;
                case "5208":
                    vrati = JOPPD.tOznakaStjecatelja.Item5208;
                    break;
                case "5209":
                    vrati = JOPPD.tOznakaStjecatelja.Item5209;
                    break;
                case "5210":
                    vrati = JOPPD.tOznakaStjecatelja.Item5210;
                    break;
                case "5211":
                    vrati = JOPPD.tOznakaStjecatelja.Item5211;
                    break;
                case "5212":
                    vrati = JOPPD.tOznakaStjecatelja.Item5212;
                    break;
                case "5213":
                    vrati = JOPPD.tOznakaStjecatelja.Item5213;
                    break;
                case "5301":
                    vrati = JOPPD.tOznakaStjecatelja.Item5301;
                    break;
                case "5302":
                    vrati = JOPPD.tOznakaStjecatelja.Item5302;
                    break;
                case "5401":
                    vrati = JOPPD.tOznakaStjecatelja.Item5401;
                    break;
                case "5402":
                    vrati = JOPPD.tOznakaStjecatelja.Item5402;
                    break;
                case "5403":
                    vrati = JOPPD.tOznakaStjecatelja.Item5403;
                    break;
                case "5501":
                    vrati = JOPPD.tOznakaStjecatelja.Item5501;
                    break;
                case "5601":
                    vrati = JOPPD.tOznakaStjecatelja.Item5601;
                    break;
                case "5602":
                    vrati = JOPPD.tOznakaStjecatelja.Item5602;
                    break;
                case "5603":
                    vrati = JOPPD.tOznakaStjecatelja.Item5603;
                    break;
                case "5604":
                    vrati = JOPPD.tOznakaStjecatelja.Item5604;
                    break;
                case "5605":
                    vrati = JOPPD.tOznakaStjecatelja.Item5605;
                    break;
                case "5606":
                    vrati = JOPPD.tOznakaStjecatelja.Item5606;
                    break;
                case "5607":
                    vrati = JOPPD.tOznakaStjecatelja.Item5607;
                    break;
                case "5608":
                    vrati = JOPPD.tOznakaStjecatelja.Item5608;
                    break;
                case "5701":
                    vrati = JOPPD.tOznakaStjecatelja.Item5701;
                    break;
                case "5702":
                    vrati = JOPPD.tOznakaStjecatelja.Item5702;
                    break;
            }
            return vrati;
        }

        private JOPPD.tOznakaNeoporezivogPrimitka OznakaNeoporezivogPrimitka (string oznaka_neoporezivog_primitka)
        {
            JOPPD.tOznakaNeoporezivogPrimitka vrati = JOPPD.tOznakaNeoporezivogPrimitka.Item0;

            switch (oznaka_neoporezivog_primitka)
            {
                case "0":
                    vrati = JOPPD.tOznakaNeoporezivogPrimitka.Item0;
                    break;
                case "01":
                    vrati = JOPPD.tOznakaNeoporezivogPrimitka.Item01;
                    break;
                case "02":
                    vrati = JOPPD.tOznakaNeoporezivogPrimitka.Item02;
                    break;
                case "03":
                    vrati = JOPPD.tOznakaNeoporezivogPrimitka.Item03;
                    break;
                case "04":
                    vrati = JOPPD.tOznakaNeoporezivogPrimitka.Item04;
                    break;
                case "05":
                    vrati = JOPPD.tOznakaNeoporezivogPrimitka.Item05;
                    break;
                case "06":
                    vrati = JOPPD.tOznakaNeoporezivogPrimitka.Item06;
                    break;
                case "07":
                    vrati = JOPPD.tOznakaNeoporezivogPrimitka.Item07;
                    break;
                case "08":
                    vrati = JOPPD.tOznakaNeoporezivogPrimitka.Item08;
                    break;
                case "09":
                    vrati = JOPPD.tOznakaNeoporezivogPrimitka.Item09;
                    break;
                case "10":
                    vrati = JOPPD.tOznakaNeoporezivogPrimitka.Item10;
                    break;
                case "11":
                    vrati = JOPPD.tOznakaNeoporezivogPrimitka.Item11;
                    break;
                case "12":
                    vrati = JOPPD.tOznakaNeoporezivogPrimitka.Item12;
                    break;
                case "13":
                    vrati = JOPPD.tOznakaNeoporezivogPrimitka.Item13;
                    break;
                case "14":
                    vrati = JOPPD.tOznakaNeoporezivogPrimitka.Item14;
                    break;
                case "15":
                    vrati = JOPPD.tOznakaNeoporezivogPrimitka.Item15;
                    break;
                case "16":
                    vrati = JOPPD.tOznakaNeoporezivogPrimitka.Item16;
                    break;
                case "17":
                    vrati = JOPPD.tOznakaNeoporezivogPrimitka.Item17;
                    break;
                case "18":
                    vrati = JOPPD.tOznakaNeoporezivogPrimitka.Item18;
                    break;
                case "19":
                    vrati = JOPPD.tOznakaNeoporezivogPrimitka.Item19;
                    break;
                case "20":
                    vrati = JOPPD.tOznakaNeoporezivogPrimitka.Item20;
                    break;
                case "21":
                    vrati = JOPPD.tOznakaNeoporezivogPrimitka.Item21;
                    break;
                case "22":
                    vrati = JOPPD.tOznakaNeoporezivogPrimitka.Item22;
                    break;
                case "23":
                    vrati = JOPPD.tOznakaNeoporezivogPrimitka.Item23;
                    break;
                case "24":
                    vrati = JOPPD.tOznakaNeoporezivogPrimitka.Item24;
                    break;
                case "25":
                    vrati = JOPPD.tOznakaNeoporezivogPrimitka.Item25;
                    break;
                case "26":
                    vrati = JOPPD.tOznakaNeoporezivogPrimitka.Item26;
                    break;
                case "27":
                    vrati = JOPPD.tOznakaNeoporezivogPrimitka.Item27;
                    break;
                case "28":
                    vrati = JOPPD.tOznakaNeoporezivogPrimitka.Item28;
                    break;
                case "29":
                    vrati = JOPPD.tOznakaNeoporezivogPrimitka.Item29;
                    break;
                case "30":
                    vrati = JOPPD.tOznakaNeoporezivogPrimitka.Item30;
                    break;
                case "31":
                    vrati = JOPPD.tOznakaNeoporezivogPrimitka.Item31;
                    break;
                case "32":
                    vrati = JOPPD.tOznakaNeoporezivogPrimitka.Item32;
                    break;
                case "33":
                    vrati = JOPPD.tOznakaNeoporezivogPrimitka.Item33;
                    break;
                case "34":
                    vrati = JOPPD.tOznakaNeoporezivogPrimitka.Item34;
                    break;
                case "35":
                    vrati = JOPPD.tOznakaNeoporezivogPrimitka.Item35;
                    break;
                case "36":
                    vrati = JOPPD.tOznakaNeoporezivogPrimitka.Item36;
                    break;
                case "37":
                    vrati = JOPPD.tOznakaNeoporezivogPrimitka.Item37;
                    break;
                case "38":
                    vrati = JOPPD.tOznakaNeoporezivogPrimitka.Item38;
                    break;
                case "39":
                    vrati = JOPPD.tOznakaNeoporezivogPrimitka.Item39;
                    break;
                case "40":
                    vrati = JOPPD.tOznakaNeoporezivogPrimitka.Item40;
                    break;
                case "41":
                    vrati = JOPPD.tOznakaNeoporezivogPrimitka.Item41;
                    break;
                case "42":
                    vrati = JOPPD.tOznakaNeoporezivogPrimitka.Item42;
                    break;
                case "43":
                    vrati = JOPPD.tOznakaNeoporezivogPrimitka.Item43;
                    break;
                case "44":
                    vrati = JOPPD.tOznakaNeoporezivogPrimitka.Item44;
                    break;
                case "45":
                    vrati = JOPPD.tOznakaNeoporezivogPrimitka.Item45;
                    break;
                case "46":
                    vrati = JOPPD.tOznakaNeoporezivogPrimitka.Item46;
                    break;
                case "47":
                    vrati = JOPPD.tOznakaNeoporezivogPrimitka.Item47;
                    break;
                case "48":
                    vrati = JOPPD.tOznakaNeoporezivogPrimitka.Item48;
                    break;
                case "49":
                    vrati = JOPPD.tOznakaNeoporezivogPrimitka.Item49;
                    break;
                case "50":
                    vrati = JOPPD.tOznakaNeoporezivogPrimitka.Item50;
                    break;
                case "51":
                    vrati = JOPPD.tOznakaNeoporezivogPrimitka.Item51;
                    break;
                case "52":
                    vrati = JOPPD.tOznakaNeoporezivogPrimitka.Item52;
                    break;
            }
            return vrati;
        }

        private JOPPD.tOznakaNacinaIsplate OznakaNacinaIsplate(string oznaka_nacina_ispalte)
        {
            JOPPD.tOznakaNacinaIsplate vrati = JOPPD.tOznakaNacinaIsplate.Item0;

            switch (oznaka_nacina_ispalte)
            {
                case "0":
                    vrati = JOPPD.tOznakaNacinaIsplate.Item0;
                    break;
                case "1":
                    vrati = JOPPD.tOznakaNacinaIsplate.Item1;
                    break;
                case "2":
                    vrati = JOPPD.tOznakaNacinaIsplate.Item2;
                    break;
                case "3":
                    vrati = JOPPD.tOznakaNacinaIsplate.Item3;
                    break;
                case "4":
                    vrati = JOPPD.tOznakaNacinaIsplate.Item4;
                    break;
                case "5":
                    vrati = JOPPD.tOznakaNacinaIsplate.Item5;
                    break;
                case "6":
                    vrati = JOPPD.tOznakaNacinaIsplate.Item6;
                    break;
                case "7":
                    vrati = JOPPD.tOznakaNacinaIsplate.Item7;
                    break;
            }
            return vrati;
        }

        [LocalCommandHandler("JOPPDStranicaB")]
        public void JOPPDStranicaBHandler(object sender, EventArgs e)
        {
            MessageBox.Show("Prije generiranja izvještaja Stranice B potrebno je potvrditi podatke.\nAko niste molimo kliknite na Potvrdi podatke.");
            string oib_podositelja = txtOIB.Text.Trim();
            string oznaka_izvjesca = lblOznakaIzvjesca.Text.Trim();
            string vrsta_izvjesca = lblVrstaIzvjesca.Text.Trim();

            DataTable tblStranaB = client.GetDataTable("SELECT JOPPDAID, RedniBroj, SifraOpcinePrebivalista, SifraOpcineRada, OIBStjecatelja, ImePrezimeStjecatelja, " +
            "OznakaStjecatelja, OznakaPrimitka, ObvezaDodatnogDoprinosa, ObvezaPosebnogDoprinosa, OznakaMjesecaOsiguranje, OznakaRadnogVremena, SatiRada, NeodradeniSatiRada, RazdobljeOd, " +
            "RazdobljeDo, Primitak, Osnovica, DoprinosMirovinsko, DoprinosMirovinskoII, DoprinosZdravstveno, DoprinosZastita, DoprinosZaposljavanje, DodatniDoprinosMirovinsko, " +
            "DodatniDoprinosMirovinskoII, PosebanDoprinosZdravstveno, PosebanDoprinosZaposljavanje, Izdatak, IzdatakDoprinosMirovinsko, Dohodak, OsobniOdbitak, PoreznaOsnovica, " +
            "PorezNaDohodak, Prirez, OznakaNeoporezivogPrimitka, NeoporezivPrimitak, OznakaNacinaIsplate, Isplata, ObracunatiPrimitak From JOPPDB Where JOPPDAID = '" + JOPPDID.Value + "'");

            ReportDocument document = new ReportDocument();
            document.Load(System.Windows.Forms.Application.StartupPath + @"\Izvjestaji\rptJOPPDStranaB.rpt");

            // Set connection string from config in existing LogonProperties
            document.DataSourceConnections[0].SetConnection(Mipsed7.Core.ApplicationDatabaseInformation.ServerName, Mipsed7.Core.ApplicationDatabaseInformation.DatabaseName, true);
            document.DataSourceConnections[0].SetLogon(Mipsed7.Core.ApplicationDatabaseInformation.SqlUserName, Mipsed7.Core.ApplicationDatabaseInformation.SqlPassword);
            document.DataSourceConnections[0].IntegratedSecurity = false;

            document.SetDataSource(tblStranaB);
            document.SetParameterValue("oib_podnositelja", oib_podositelja);
            document.SetParameterValue("oznaka_izvjesca", oznaka_izvjesca);
            document.SetParameterValue("vrsta_izvjesca", vrsta_izvjesca);

            ExtendedWindowWorkspace workspace = new ExtendedWindowWorkspace();
            PreviewReportWorkItem item = this.Controller.WorkItem.Items.Get<PreviewReportWorkItem>("Pregled");
            if (item == null)
            {
                item = this.Controller.WorkItem.Items.AddNew<PreviewReportWorkItem>("Pregled");
            }
            item.Izvjestaj = document;
            item.Activate();
            item.Show(item.Workspaces["main"]);

        }

        [LocalCommandHandler("JOPPDStranicaA")]
        public void JOPPDStranicaAHandler(object sender, EventArgs e)
        {
            if (ValidacijaUnosaStranaA())
            {

                ReportDocument document = new ReportDocument();

                //if (DateTime.Now > new DateTime(2015, 02, 27))
                //{
                //    document.Load(System.Windows.Forms.Application.StartupPath + @"\Izvjestaji\rptJOPPDStranaA.rpt");
                //}
                //else
                //{
                //    document.Load(System.Windows.Forms.Application.StartupPath + @"\Izvjestaji\rptJOPPDStranaAOld.rpt");
                //}

                document.Load(System.Windows.Forms.Application.StartupPath + @"\Izvjestaji\rptJOPPDStranaA.rpt");

                //document.SetDataSource(tblStranaB);
                document.SetParameterValue("oznaka_izvjesca", lblOznakaIzvjesca.Text.Trim());
                document.SetParameterValue("vrsta_izvjesca", lblVrstaIzvjesca.Text.Trim());
                document.SetParameterValue("naziv_ime_prezime", txtNazivImePrezime.Text.Trim());

                document.SetParameterValue("adresa", txtAdresa.Text.Trim());
                document.SetParameterValue("email", txtAdresaElektronickePoste.Text.Trim());
                document.SetParameterValue("oib", txtOIB.Text.Trim());
                document.SetParameterValue("oznaka_podnositelja", lblOznakaPod.Text);
                document.SetParameterValue("broj_osoba", lblBrojOsoba.Text.Trim());
                document.SetParameterValue("broj_redaka", lblBrojRedakaNaStraniB.Text.Trim());

                if (lblOznakaPod.Text == "6")
                {
                    document.SetParameterValue("obveznik_ime", "Ministarstvo znanosti, obrazovanja i sporta");
                    document.SetParameterValue("obveznik_adresa", "Donje Svetice 38, Zagreb");
                    document.SetParameterValue("obveznik_email", "odgojiobrazovanje@mzos.hr");
                    document.SetParameterValue("obveznik_oib", "49508397045");
                    document.SetParameterValue("obveznik_oznaka_pod", "");
                }
                else
                {
                    document.SetParameterValue("obveznik_ime", "");
                    document.SetParameterValue("obveznik_adresa", "");
                    document.SetParameterValue("obveznik_email", "");
                    document.SetParameterValue("obveznik_oib", "");
                    document.SetParameterValue("obveznik_oznaka_pod", "");
                }

                document.SetParameterValue("izracun_V.1.1.", txtUkupno_V_1_1.Text.Trim());
                document.SetParameterValue("izracun_V.1.2.", txtUkupno_V_1_2.Text.Trim());
                document.SetParameterValue("izracun_V.2.", txtUkupno_V_2.Text.Trim());
                document.SetParameterValue("izracun_V.3.", txtUkupno_V_3.Text.Trim());
                document.SetParameterValue("izracun_V.4.", txtUkupno_V_4.Text.Trim());
                document.SetParameterValue("izracun_V.5.", txtUkupno_V_5.Text.Trim());
                document.SetParameterValue("izracun_VI.1.1.", txtUkupno_VI_1_1.Text.Trim());
                document.SetParameterValue("izracun_VI.1.2.", txtUkupno_VI_1_2.Text.Trim());
                document.SetParameterValue("izracun_VI.1.3.", txtUkupno_VI_1_3.Text.Trim());
                document.SetParameterValue("izracun_VI.1.4.", txtUkupno_VI_1_4.Text.Trim());
                document.SetParameterValue("izracun_VI.1.5.", txtUkupno_VI_1_5.Text.Trim());
                document.SetParameterValue("izracun_VI.1.6.", txtUkupno_VI_1_6.Text.Trim());
                document.SetParameterValue("izracun_VI.2.1.", txtUkupno_VI_2_1.Text.Trim());
                document.SetParameterValue("izracun_VI.2.2.", txtUkupno_VI_2_2.Text.Trim());
                document.SetParameterValue("izracun_VI.2.3.", txtUkupno_VI_2_3.Text.Trim());
                document.SetParameterValue("izracun_VI.2.4.", txtUkupno_VI_2_4.Text.Trim());
                document.SetParameterValue("izracun_VI.2.5.", txtUkupno_VI_2_5.Text.Trim());
                document.SetParameterValue("izracun_VI.3.1.", txtUkupno_VI_3_1.Text.Trim());
                document.SetParameterValue("izracun_VI.3.2.", txtUkupno_VI_3_2.Text.Trim());
                document.SetParameterValue("izracun_VI.3.10.", txtUkupno_VI_3_10.Text.Trim());
                document.SetParameterValue("izracun_VI.3.3.", txtUkupno_VI_3_3.Text.Trim());
                document.SetParameterValue("izracun_VI.3.4.", txtUkupno_VI_3_4.Text.Trim());
                document.SetParameterValue("izracun_VI.3.5.", txtUkupno_VI_3_5.Text.Trim());
                document.SetParameterValue("izracun_VI.3.6.", txtUkupno_VI_3_6.Text.Trim());
                document.SetParameterValue("izracun_VI.3.7.", txtUkupno_VI_3_7.Text.Trim());
                document.SetParameterValue("izracun_VI.3.8.", txtUkupno_VI_3_8.Text.Trim());
                document.SetParameterValue("izracun_VI.3.9.", txtUkupno_VI_3_9.Text.Trim());
                document.SetParameterValue("izracun_VI.4.1.", txtUkupno_VI_4_1.Text.Trim());
                document.SetParameterValue("izracun_VI.4.2.", txtUkupno_VI_4_2.Text.Trim());
                document.SetParameterValue("izracun_VII.", txtUkupno_VII.Text.Trim());
                document.SetParameterValue("izracun_VIII.", txtUkupnoVIII.Text.Trim());

                //novo 2015
                //if (DateTime.Now > new DateTime(2015, 02, 27))
                //{
                //    document.SetParameterValue("BrojOsoba", txtBrojOsoba.Text.Trim());
                //    document.SetParameterValue("IznosNaknade", txtIznosNaknade.Text.Trim());
                //}
                document.SetParameterValue("BrojOsoba", txtBrojOsoba.Text.Trim());
                document.SetParameterValue("IznosNaknade", txtIznosNaknade.Text.Trim());

                ExtendedWindowWorkspace workspace = new ExtendedWindowWorkspace();
                PreviewReportWorkItem item = this.Controller.WorkItem.Items.Get<PreviewReportWorkItem>("Pregled");
                if (item == null)
                {
                    item = this.Controller.WorkItem.Items.AddNew<PreviewReportWorkItem>("Pregled");
                }
                item.Izvjestaj = document;
                item.Activate();
                item.Show(item.Workspaces["main"]);
            }
            else
            {
                MessageBox.Show("Ako su podaci u obrascu ispravni prije generiranja izvještaja\ni datoteke kliknite na Potvrdi podatke.");
            }
        }

        private bool ValidacijaUnosaStranaA()
        {
            bool kontrola = true;
            foreach (Control control in panel1.Controls)
            {
                if (control is UltraMaskedEdit)
                {
                    if (control.Text.Trim().Length == 0)
                    {
                        kontrola = false;
                        break;
                    }
                }
            }
            return kontrola;
        }

        private void UltraGrid1_AfterCellUpdate(object sender, CellEventArgs e)
        {

        }

        private AutoHideControl _RSMObrazacAutoHideControl;

        private UnpinnedTabArea _RSMObrazacUnpinnedTabAreaBottom;

        private UnpinnedTabArea _RSMObrazacUnpinnedTabAreaLeft;

        private UnpinnedTabArea _RSMObrazacUnpinnedTabAreaRight;

        private UnpinnedTabArea _RSMObrazacUnpinnedTabAreaTop;

        private UltraMaskedEdit txtOIB;

        [CreateNew]
        public RSmObrazacController Controller { get; set; }

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

        private UltraMaskedEdit txtAdresa;

        private UltraMaskedEdit txtNazivImePrezime;

        private UltraMaskedEdit txtAdresaElektronickePoste;

        public DataRow SelectedRow
        {
            get
            {
                DataRow row = null;
                return row;
            }
        }

        private UltraDockManager UltraDockManager1;

        private UltraGroupBox UltraGroupBox1;

        private UltraGroupBox UltraGroupBox2;

        private UltraGroupBox UltraGroupBox3;

        private UltraLabel UltraLabel10;

        private UltraLabel UltraLabel11;

        private UltraLabel UltraLabel5;

        private UltraLabel UltraLabel6;

        private UltraLabel UltraLabel7;

        private UltraLabel UltraLabel8;

        private UltraLabel UltraLabel9;

        Deklarit.Practices.CompositeUI.WorkWithMode WorkWithMode
        {
            set
            {
            }
        }

        private void ultraLabel78_Click(object sender, EventArgs e)
        {

        }

        private void ultraMaskedEdit1_MaskChanged(object sender, MaskChangedEventArgs e)
        {

        }

        private void txtUkupno_V_1_1_ValueChanged(object sender, EventArgs e)
        {
            decimal prvi = 0;
            decimal drugi = 0;
            try
            {
                prvi = Convert.ToDecimal(txtUkupno_V_1_1.Value);
            }
            catch
            {
                prvi = 0;
            }
            try
            {
                drugi = Convert.ToDecimal(txtUkupno_V_1_2.Value);
            }
            catch
            {
                drugi = 0;
            }
            txtUkupno_V_1.Value = prvi + drugi;
        }

	}
}

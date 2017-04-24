using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Practices.CompositeUI.SmartParts;
using Deklarit.Practices.CompositeUI;
using Microsoft.Practices.ObjectBuilder;
using Microsoft.Practices.CompositeUI.Commands;
using Infragistics.Win.UltraWinGrid.ExcelExport;
using System.Diagnostics;
using System.Collections;
using System.Net;
using System.Net.Sockets;

namespace Chat
{
    [SmartPart]
    public partial class uscChat : UserControl, ISmartPartInfoProvider, IFilteredView
    {
        #region Univerzalan kod koji se koristi za forme (Controller, WorkWith, itd...)

        private SmartPartInfo smartPartInfo1;
        private SmartPartInfoProvider infoProvider;
        private DataRow m_FillByRow;
        private DataRow m_RowSelected { get; set; }
        private string m_FillByMethod = "";
        private Deklarit.Practices.CompositeUI.WorkWithMode m_WorkWithMode;

        public ISmartPartInfo GetSmartPartInfo(Type smartPartInfoType)
        {
            return this.infoProvider.GetSmartPartInfo(smartPartInfoType);
        }

        [CreateNew]
        public Microsoft.Practices.CompositeUI.Controller Controller { get; set; }

        DataRow Deklarit.Practices.CompositeUI.IFilteredView.FillByRow
        {
            set
            {
                this.m_FillByRow = value;
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
            }
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

        Deklarit.Practices.CompositeUI.WorkWithMode WorkWithMode
        {
            set
            {
                this.m_WorkWithMode = value;
            }
        }

        #endregion

        public static ChatService.ChatService chat_service = new ChatService.ChatService();
        Mipsed7.DataAccessLayer.SqlClient client = new Mipsed7.DataAccessLayer.SqlClient();
        private bool userFlag = true;
        static public int iUserCnt = 0;
        static public string strCacheUser = string.Empty;
        public static string oib_korisnika;

        #region Svojstva

        public static string pKorisnickoIme { get; set; }
        static string pLozinka { get; set; }
        static string pIme { get; set; }
        public static bool pValidiran { get; set; }
        static bool pBlokiran { get; set; }
        static int pID_Korisnika { get; set;}

        static string pPoruka { get; set; }
        static public ArrayList pArrayUsera {get; set;}

        #endregion

        #region Metode

        public uscChat()
        {
            InitializeComponent();

            this.smartPartInfo1 = new SmartPartInfo("Chat", "Chat");
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);

            oib_korisnika = client.ExecuteScalar("Select KORISNIKOIB From Korisnik").ToString();
            PodesavanjePanela();
            pArrayUsera = new ArrayList();
            if (ProvjeraKorisnika())
            {
                PaljenjeServisa();
            }
        }

        private bool ProvjeraKorisnika()
        {
            string connection_string = string.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3};",
                                                     "mssql6.mojsite.com,1555", "vugergrad_chat", "vugergrad_chat", "chatajMO2010");

            client = new Mipsed7.DataAccessLayer.SqlClient(connection_string);

            object oib_chat = client.ExecuteScalar("Select OIB FROM Korisnici Where OIB = '" + oib_korisnika + "'");

            if (oib_chat != null)
            {
                pValidiran = Convert.ToBoolean(client.ExecuteScalar("Select Validiran From Korisnici Where OIB = '" + oib_korisnika + "'"));

                if (pValidiran)
                {
                    pBlokiran = Convert.ToBoolean(client.ExecuteScalar("Select Blokiran From Korisnici Where OIB = '" + oib_korisnika + "'"));

                    if (!pBlokiran)
                    {
                        pKorisnickoIme = client.ExecuteScalar("Select KorisnickoIme From Korisnici Where OIB = '" + oib_korisnika + "'").ToString();
                        pID_Korisnika = Convert.ToInt32(client.ExecuteScalar("Select ID From Korisnici Where OIB = '" + oib_korisnika + "'"));
                        btnPosaljiPoruku.Enabled = true;
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Vaš pristup chatu je blokiran od strane administratora.\nZa pomoć se obratite u Tools for Schools.");
                        btnPosaljiPoruku.Enabled = false;
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("Da bi pristupili chatu potrebno je napraviti registraciju.");
                    btnPosaljiPoruku.Enabled = false;

                    using (frmRegistracija registracija = new frmRegistracija())
                    {
                        if (registracija.ShowDialog() == DialogResult.OK)
                        {
                            UpdateKorisnika();
                            if (ProvjeraKorisnika())
                            {
                                PaljenjeServisa();
                            }
                        }
                    }

                    return false;
                }
            }
            else
            {
                MessageBox.Show("Vaš OIB se ne nalazi na listi osoba koje imaju pristup chatu.\nZa aktiviranje chata javite se u Tools for Schools.");
                btnPosaljiPoruku.Enabled = false;
                return false;
            }
        }

        private void PaljenjeServisa()
        {
            try
            {
                pKorisnickoIme = pKorisnickoIme;
                chat_service.Url = chat_service.Url;//@"http://localhost:1856/ChatService.asmx";
                chat_service.AddUser(pKorisnickoIme);
                tmrOkidac.Enabled = true;
            }
            catch (Exception greska)
            {
                MessageBox.Show("Greška kod spajanja na server. [PaljenjeServisa]\n" + greska.Message);
            }
        }

        private void PodesavanjePanela()
        {
            spcMain.SplitterDistance = 40;
            spcMain.IsSplitterFixed = true;
            spcMain.Panel1MinSize = 40;

            spcUnos.SplitterDistance = 60;
            spcUnos.IsSplitterFixed = true;
            spcUnos.Panel1MinSize = 60;

            spcPrikaz.SplitterDistance = 200;
            spcPrikaz.IsSplitterFixed = true;
            spcPrikaz.Panel1MinSize = 200;
        }

        private void PrikazKorisnika()
        {
            try
            {
                string strUList = chat_service.GetUsers();
                iUserCnt = String.Compare(strCacheUser, strUList);
                if (iUserCnt != 0)
                {
                    lstOnlineKorisnici.Clear();
                    string[] strUsers = strUList.Split('|');
                    strCacheUser = strUList;
                    for (int i = 0; i < strUsers.Length - 1; i++)
                    {
                        if (strUsers[i].ToUpper() != pKorisnickoIme.Trim().ToUpper())
                        {
                            lstOnlineKorisnici.Items.Add(strUsers[i], 0);
                        }
                    }
                }
            }
            catch (Exception greska)
            {
                MessageBox.Show("Greška kod spajanja na server [PrikazKorisnika].\n" + greska.Message);
            }
        }

        private void DohvatPoruke()
        {
            try
            {
                ArrayList objekt = new ArrayList(chat_service.ReceiveMessage());

                if (objekt.Count > 0)
                {
                    string tekst_za_box = string.Empty;

                    string[] array = (string[])objekt.ToArray(typeof(string));

                    for (int i = array.Length - 1; i >= 0; i--)
                    {
                        if (array[i].Substring(0, 7) == "Ser@ver")
                        { }
                        else
                        {
                            pPoruka = array[i];
                            string[] strUser = pPoruka.Split(new[] { ";*;" }, StringSplitOptions.RemoveEmptyEntries);
                            userFlag = true;
                            for (int j = 0; j < pArrayUsera.Count; j++)
                            {
                                if (strUser[0] == pArrayUsera[j].ToString())
                                    userFlag = false;
                            }
                            tekst_za_box += "\n" + strUser[0] + strUser[1];
                        }
                    }

                    if (userFlag == true && rtbPrikazPoruka.Text != tekst_za_box)
                    {
                        rtbPrikazPoruka.Text = tekst_za_box;

                        rtbPrikazPoruka.Select(rtbPrikazPoruka.Lines.Length - 1, 1);
                    }
                }
            }
            catch (Exception greska)
            {
                MessageBox.Show("Greška kod spajanja na server. [DohvatPoruke]\n" + greska.Message);
            }
        }

        public static void MicanjeUseraKodGasenja()
        {
            try
            {
                chat_service.RemoveUser(pKorisnickoIme);
            }
            catch { }
        }

        private void UpdateKorisnika()
        {
            string connection_string = string.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3};",
                                                     "mssql6.mojsite.com,1555", "vugergrad_chat", "vugergrad_chat", "chatajMO2010");

            client = new Mipsed7.DataAccessLayer.SqlClient(connection_string);

            string stari_korisnik = client.ExecuteScalar("Select KorisnickoIme From Korisnici Where OIB = '" + oib_korisnika + "'").ToString();

            client.ExecuteNonQuery("Update Korisnici Set KorisnickoIme = '" + pKorisnickoIme + "', Validiran = '" + pValidiran + "' " + 
                                   "Where OIB = '" + oib_korisnika + "'");

            chat_service.RemoveUser(stari_korisnik);
        }

        private string LocalIPAddress()
        {
            IPHostEntry host;
            string localIP = "";
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    localIP = ip.ToString();
                    break;
                }
            }
            return localIP;
        }

        #endregion

        #region Dogadaji

        [CommandHandler("Registracija")]
        public void Insert(object sender, EventArgs e)
        {
            using(frmRegistracija registracija = new frmRegistracija())
            {
                if (registracija.ShowDialog() == DialogResult.OK)
                {
                    UpdateKorisnika();
                    if (ProvjeraKorisnika())
                    {
                        PaljenjeServisa();
                    }
                }
            }
        }

        private void btnPosaljiPoruku_Click(object sender, EventArgs e)
        {
            try
            {
                if (rtbUnosPoruke.Text.Trim().Length > 0 && rtbUnosPoruke.Rtf.Trim().Length < 300)
                {
                    chat_service.SendMessage(pKorisnickoIme, rtbUnosPoruke.Text, DateTime.Now.ToString("HH:mm:ss"),
                                             LocalIPAddress(), System.Environment.MachineName, pID_Korisnika);
                    rtbUnosPoruke.ScrollToCaret();
                    rtbUnosPoruke.Clear();
                    rtbUnosPoruke.Focus();
                }
                else
                {
                    if (rtbUnosPoruke.Text.Trim().Length == 0)
                    {
                        MessageBox.Show("Poruka mora sadržavati barem jedan znak!!!!");
                    }
                    if (rtbUnosPoruke.Text.Trim().Length > 300)
                    {
                        MessageBox.Show("Poruka smije sadržavati najviše 300 znakova!!!!");
                    }
                }
            }
            catch
            {
                MessageBox.Show("Error in connecting to the chat server. Please try again.");
            }
        }

        private void rtbUnosPoruke_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (btnPosaljiPoruku.Enabled == true)
                {
                    btnPosaljiPoruku_Click(null, null);
                }
            }
        }

        private void tmrOkidac_Tick(object sender, EventArgs e)
        {
            PrikazKorisnika();
            DohvatPoruke();
        }

        #endregion

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mipsed7.DataAccessLayer;
using Placa;

namespace Materijalno.UI.Izvjestaji
{
    public partial class frmZakljucivanjeGodine : Form
    {
        #region svojstva

        public static int pSkladiste
        {
            get;
            set;
        }

        //db - 26.1.2017
        public static int pInventura
        {
            get;
            set;
        }

        public static int pSort
        {
            get;
            set;
        }
        public static Nullable<DateTime> naDan { get; set; }

        SqlClient client = null;

        bool _loadMode;

        #endregion

        public frmZakljucivanjeGodine()
        {
            InitializeComponent();

            client = new SqlClient();
        }

        private void NapuniInventure()
        {
            DataTable dtInv = new DataTable();

            SqlCommand com = new SqlCommand("select inv.ID, ('Skladište: ' + skladiste.Naziv +' na datum: ' + convert(varchar(10), inv.DatumInventure, 105)) as Opis from MT_Inventura inv left join MT_Skladista skladiste on inv.IDSKladiste = skladiste.ID");
            client.GetDataTable(com);

            SqlDataAdapter da = new SqlDataAdapter(com);
            da.Fill(dtInv);

            cmbInventura.DataSource = dtInv;
            cmbInventura.DisplayMember = "Opis";
            cmbInventura.ValueMember = "ID";

            pInventura = Convert.ToInt32(cmbInventura.SelectedValue);
        }

        private void NapuniGodine()
        {
            DataTable dtGod = new DataTable();

            SqlCommand com = new SqlCommand("select IDGODINE as Godine from GODINE order by IDGODINE desc");
            client.GetDataTable(com);

            SqlDataAdapter da = new SqlDataAdapter(com);
            da.Fill(dtGod);

            cmbGodina.DataSource = dtGod;
            cmbGodina.DisplayMember = "GODINE";
            cmbGodina.ValueMember = "GODINE";

            cmbGodina.SelectedIndex = 0;
        }

        private void frmZakljucivanjeGodine_Load(object sender, EventArgs e)
        {
            _loadMode = true;

            NapuniInventure();
            NapuniGodine();

            _loadMode = false;
        }

        private void btnOdustani_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //db - 26.1.2017
        private void btnPrihvati_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Ova radnja će izvršiti prijenos odabrane inventure na početno stanje. \n Želite li nastaviti?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                return;
            }
            else
            {
                //tu sad ide logika za upis PRVO u MT_Primka kao početno stanje, a onda i ostalo u MT_PrimkaStavke
                //1. dohvat inventure
                //2. dohvat stavaka za inventuru
                //3. dohvat zadnje primke
                //4. provjera datuma zadnje primke               
                //5. unos u primku
                //6. unos u primkastavke

                SqlConnection conn = new SqlConnection();
                conn = client.sqlConnection;

                if (client.sqlConnection.State == ConnectionState.Closed) conn.Open();

                //1.
                DataTable dtInventura = new DataTable();
                SqlCommand com = new SqlCommand("select * from MT_Inventura where ID = '" + pInventura + "' ");
                dtInventura = client.GetDataTable(com);

                //2.
                DataTable dtInventuraStavke = new DataTable();
                SqlCommand comm = new SqlCommand("select * from MT_InventuraStavka left join PROIZVOD on PROIZVOD.IDPROIZVOD = MT_InventuraStavka.ID_Proizvod left join FINPOREZ on FINPOREZ.FINPOREZIDPOREZ = PROIZVOD.FINPOREZIDPOREZ where ID_Inventura = '" + pInventura + "' ");
                dtInventuraStavke = client.GetDataTable(comm);


                //dohvat posljednjeg zapisa iz baze po ID-u, tablice MT_Primka
                SqlCommand coomm = new SqlCommand("select Top 1 * from MT_Primka order by ID desc", conn);
                DataTable dtZadnjaPrimka = new DataTable();
                SqlDataAdapter daZadnjaPrimka = new SqlDataAdapter(coomm);
                daZadnjaPrimka.Fill(dtZadnjaPrimka);


                ////db - 06.02.2017    
                int godinaZadnjegZapisa = 0;
                int sifraPrimkeZadnjePrimke = 0;
                DateTime datumZadnjePrimke = DateTime.MinValue;

                if (dtZadnjaPrimka.Rows.Count > 0) //ukoliko postoji zapis, vadi se godina njegovog datuma
                {
                    SqlCommand provjeraPostojanja = new SqlCommand("select Top 1 DATEPART(yyyy, DatumNastajanja) from MT_Primka order by ID desc", conn);
                    godinaZadnjegZapisa = Convert.ToInt32(provjeraPostojanja.ExecuteScalar());

                    sifraPrimkeZadnjePrimke = Convert.ToInt32(dtZadnjaPrimka.Rows[0]["SifraPrimke"]);
                    datumZadnjePrimke = Convert.ToDateTime(dtZadnjaPrimka.Rows[0]["DatumNastajanja"]);
                }

                //db - 06.02.2017                
                int odabranaGodina = Convert.ToInt32(cmbGodina.Text);

                //SQLCOMMAND ZA UPIS  INVENTURE U PRIMKE
                //dodati provjeru da li već postoji takvo početno stanje uneseno za tu inventuru, paziti i na to da prva ŠifraPrimke bude 1!! Ukoliko postoji, dohvatiti ŠifruPrimke i uvećati obavezno +1 prije unosa u bazu
                SqlCommand upisPrimke = new SqlCommand("spInventuraPocetnoPrimka");
                upisPrimke.Connection = conn;
                upisPrimke.CommandType = CommandType.StoredProcedure;

                //dohvat id-a primke unesene
                string query = "Select @@Identity";
                int id_primke = 0;

                KORISNIKDataSet set2 = new KORISNIKDataSet();
                new KORISNIKDataAdapter().Fill(set2);
                string idKorisnik = set2.KORISNIK.Rows[0]["IDKORISNIK"].ToString();

                string datumInventure = "";
                try
                {
                    datumInventure = cmbInventura.Text.Substring(cmbInventura.Text.Length - 10, 10);
                    DateTime dat = Convert.ToDateTime(datumInventure);
                }
                catch { }

                //ukoliko je dtZadnjaPrimka.Rows.Count == 0 ili 
                if ((odabranaGodina - godinaZadnjegZapisa) == 1) //IMA ZAPISA PRIMKI U PROŠLOJ GODINI, ALI NEMA U NOVOJ
                {
                    string prvidatum = "01.01." + odabranaGodina;

                    upisPrimke.Parameters.AddWithValue("@SifraPrimke", 1);
                    upisPrimke.Parameters.AddWithValue("@DatumNastajanja", Convert.ToDateTime(prvidatum));
                    upisPrimke.Parameters.AddWithValue("@ID_Partnera", idKorisnik);
                    upisPrimke.Parameters.AddWithValue("@ID_Dokumenta", 1);
                    upisPrimke.Parameters.AddWithValue("@DatumDokumentaDobavljaca", Convert.ToDateTime(prvidatum));
                    upisPrimke.Parameters.AddWithValue("@ID_Skladista", dtInventura.Rows[0]["IDSkladiste"]);
                    upisPrimke.Parameters.AddWithValue("@ID_Narudzbenice", DBNull.Value);
                    upisPrimke.Parameters.AddWithValue("@NetoPrimke", DBNull.Value);
                    upisPrimke.Parameters.AddWithValue("@PDVPrimke", DBNull.Value);
                    upisPrimke.Parameters.AddWithValue("@BrutoPrimke", DBNull.Value);
                    upisPrimke.Parameters.AddWithValue("@ZavisniTransport", DBNull.Value);
                    upisPrimke.Parameters.AddWithValue("@ZavisniCarina", DBNull.Value);
                    upisPrimke.Parameters.AddWithValue("@ZavisniOstalo", DBNull.Value);
                    upisPrimke.Parameters.AddWithValue("@BrojUlaznogDokumenta", "INVENTURA NA " + datumInventure.ToString());
                    upisPrimke.Parameters.AddWithValue("@Preneseno", 1);
                    upisPrimke.Parameters.AddWithValue("@TS", DateTime.Now);
                    upisPrimke.Parameters.AddWithValue("@Opis", cmbInventura.Text);
                }
                else if ((odabranaGodina - godinaZadnjegZapisa) == odabranaGodina) //NEMA NIKAKVIH ZAPISA PRIMKI U PROŠLOJ GODINI, PRVI ZAPIS UOPĆE SE UNOSI
                {
                    string prvidatum = "01.01." + odabranaGodina;

                    upisPrimke.Parameters.AddWithValue("@SifraPrimke", 1);
                    upisPrimke.Parameters.AddWithValue("@DatumNastajanja", Convert.ToDateTime(prvidatum));
                    upisPrimke.Parameters.AddWithValue("@ID_Partnera", idKorisnik);
                    upisPrimke.Parameters.AddWithValue("@ID_Dokumenta", 1);
                    upisPrimke.Parameters.AddWithValue("@DatumDokumentaDobavljaca", Convert.ToDateTime(prvidatum));
                    upisPrimke.Parameters.AddWithValue("@ID_Skladista", dtInventura.Rows[0]["IDSkladiste"]);
                    upisPrimke.Parameters.AddWithValue("@ID_Narudzbenice", DBNull.Value);
                    upisPrimke.Parameters.AddWithValue("@NetoPrimke", DBNull.Value);
                    upisPrimke.Parameters.AddWithValue("@PDVPrimke", DBNull.Value);
                    upisPrimke.Parameters.AddWithValue("@BrutoPrimke", DBNull.Value);
                    upisPrimke.Parameters.AddWithValue("@ZavisniTransport", DBNull.Value);
                    upisPrimke.Parameters.AddWithValue("@ZavisniCarina", DBNull.Value);
                    upisPrimke.Parameters.AddWithValue("@ZavisniOstalo", DBNull.Value);
                    upisPrimke.Parameters.AddWithValue("@BrojUlaznogDokumenta", "INVENTURA NA " + datumInventure.ToString());
                    upisPrimke.Parameters.AddWithValue("@Preneseno", 1);
                    upisPrimke.Parameters.AddWithValue("@TS", DateTime.Now);
                    upisPrimke.Parameters.AddWithValue("@Opis", cmbInventura.Text);
                }
                else//VEĆ IMA ZAPISANIH PRIMKI U TEKUĆOJ GODINI
                {
                    upisPrimke.Parameters.AddWithValue("@SifraPrimke", Convert.ToInt32(dtZadnjaPrimka.Rows[0]["SifraPrimke"]) + 1);
                    upisPrimke.Parameters.AddWithValue("@DatumNastajanja", DateTime.Now); //???? ostaviti ovo???
                    upisPrimke.Parameters.AddWithValue("@ID_Partnera", idKorisnik);
                    upisPrimke.Parameters.AddWithValue("@ID_Dokumenta", 1);
                    upisPrimke.Parameters.AddWithValue("@DatumDokumentaDobavljaca", Convert.ToDateTime(DateTime.Now)); //???? ostaviti ovo???
                    upisPrimke.Parameters.AddWithValue("@ID_Skladista", dtInventura.Rows[0]["IDSkladiste"]);
                    upisPrimke.Parameters.AddWithValue("@ID_Narudzbenice", DBNull.Value);
                    upisPrimke.Parameters.AddWithValue("@NetoPrimke", DBNull.Value);
                    upisPrimke.Parameters.AddWithValue("@PDVPrimke", DBNull.Value);
                    upisPrimke.Parameters.AddWithValue("@BrutoPrimke", DBNull.Value);
                    upisPrimke.Parameters.AddWithValue("@ZavisniTransport", DBNull.Value);
                    upisPrimke.Parameters.AddWithValue("@ZavisniCarina", DBNull.Value);
                    upisPrimke.Parameters.AddWithValue("@ZavisniOstalo", DBNull.Value);
                    upisPrimke.Parameters.AddWithValue("@BrojUlaznogDokumenta", "INVENTURA NA " + datumInventure.ToString());
                    upisPrimke.Parameters.AddWithValue("@Preneseno", 1);
                    upisPrimke.Parameters.AddWithValue("@TS", DateTime.Now);
                    upisPrimke.Parameters.AddWithValue("@Opis", cmbInventura.Text);
                }

                try
                {
                    upisPrimke.ExecuteNonQuery();

                    upisPrimke.CommandType = CommandType.Text;
                    upisPrimke.CommandText = query;
                    id_primke = Convert.ToInt32(upisPrimke.ExecuteScalar());
                }
                catch (SqlException ex) { MessageBox.Show("Desila se greška tijekom prijenosa!"); return; }
                catch (Exception ex) { MessageBox.Show("Desila se greška tijekom prijenosa!"); return; }
                

                //UPIS  INVENTURE U PRIMKA STAVKE
                for (int i = 0; i < dtInventuraStavke.Rows.Count; i++)
                {
                    //tu ide upis u MT_PrimkaStavke
                    SqlCommand upisPrimkaStavke = new SqlCommand("spInventuraPocetnoPrimkaStavke");
                    upisPrimkaStavke.Connection = conn;
                    upisPrimkaStavke.CommandType = CommandType.StoredProcedure;

                    decimal cijena;
                    decimal cijenaPDV = Convert.ToDecimal(dtInventuraStavke.Rows[i]["CijenaPDV1"]);
                    decimal PDV = Convert.ToDecimal(dtInventuraStavke.Rows[i]["FINPOREZSTOPA"]) / 100;
                    decimal predPorez = Convert.ToDecimal(set2.KORISNIK.Rows[0]["PredPorez"]) / 100;

                    cijena = cijenaPDV / (1 + PDV - (PDV * predPorez));

                    int id_proizvod = Convert.ToInt32(dtInventuraStavke.Rows[i]["ID_Proizvod"]);
                    int id_jedinicamjere = Convert.ToInt32(dtInventuraStavke.Rows[i]["IDJEDINICAMJERE"]);
                    int id_porez = Convert.ToInt32(dtInventuraStavke.Rows[i]["FINPOREZIDPOREZ"]);
                    decimal kolicina = dtInventuraStavke.Rows[i]["StvarnaKolicina"] == DBNull.Value ? 0 : Convert.ToDecimal(dtInventuraStavke.Rows[i]["StvarnaKolicina"]);

                    upisPrimkaStavke.Parameters.AddWithValue("@ID_Primke", id_primke); //za ovo 'spInventuraPocetnoPrimka' treba vratiti zadnji ID
                    upisPrimkaStavke.Parameters.AddWithValue("@ID_Proizvoda", id_proizvod); //dtInventuraStavke
                    upisPrimkaStavke.Parameters.AddWithValue("@ID_JedinicaMjere", id_jedinicamjere); //dtInventuraStavke
                    upisPrimkaStavke.Parameters.AddWithValue("@Cijena", cijena);
                    upisPrimkaStavke.Parameters.AddWithValue("@ID_Porez", id_porez); //dtInventuraStavke - finporezidporez
                    upisPrimkaStavke.Parameters.AddWithValue("@Kolicina", kolicina); //dtInventuraStavke - stvarna kolicina
                    upisPrimkaStavke.Parameters.AddWithValue("@CijenaPDV", cijenaPDV);// dtInventuraStavke - cijenaPdv
                    upisPrimkaStavke.Parameters.AddWithValue("@RedniBroj", i + 1);
                    upisPrimkaStavke.Parameters.AddWithValue("@RedniBrojDan", 1);

                    try
                    {
                        upisPrimkaStavke.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        BrisiPrimku(id_primke, conn);
                        MessageBox.Show("Desila se greška tijekom prijenosa!");
                        return;
                    }
                    catch (Exception ex)
                    {
                        BrisiPrimku(id_primke, conn);
                        MessageBox.Show("Desila se greška tijekom prijenosa!");
                        return;
                    }
                }

                MessageBox.Show("Inventura prenešena!");

                //tu ide signalizacija u MT_Inventura (Prebaceno) da je uneseno
                SqlCommand okidanjeFlagaPrebaceno = new SqlCommand("update MT_Inventura set Prebaceno = 1 where ID = '" + pInventura + "' ");
                okidanjeFlagaPrebaceno.Connection = conn;
                okidanjeFlagaPrebaceno.CommandType = CommandType.Text;
                okidanjeFlagaPrebaceno.ExecuteNonQuery();

                conn.Close();
            }

        }

        private void cmbInventura_SelectedValueChanged(object sender, EventArgs e)
        {
            if (_loadMode) return;

            pInventura = Convert.ToInt32(cmbInventura.SelectedValue);
        }

        /// <summary>
        /// Briše unešenu primku ukoliko je došlo do pucanja prilikom unosa u mt_primkastavke
        /// </summary>
        /// <param name="id"></param>
        /// <param name="con"></param>
        private void BrisiPrimku(int id, SqlConnection con)
        {
            try
            {
                SqlCommand com = new SqlCommand("delete from MT_PrimkaStavke where ID_Primke = '" + id + "' ");
                com.Connection = con;
                com.ExecuteNonQuery();

                SqlCommand comm = new SqlCommand("delete from MT_Primka where ID = '" + id + "' ");
                comm.Connection = con;
                comm.ExecuteNonQuery();
            }
            catch { }
        }
    }
}

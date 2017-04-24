using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mipsed7.DataAccessLayer.EntityFramework;
using UcenickoFakturiranje.Utils.Exceptions;
using System.Data;
using Mipsed7.DataAccessLayer;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace UcenickoFakturiranje.BusinessLogic
{
    public class Potrazivanja :Base, IDisposable
    {
        SqlClient client = null;
        public Potrazivanja()
            : base()
        {
            client = new SqlClient();
        }

        public void Dispose()
        {

        }

        #region Properties

        public ListBox.ObjectCollection ZaLijekove { get; set; }
        public ListBox.ObjectCollection ZaSanitetski { get; set; }
        public ListBox.ObjectCollection Zivezne { get; set; }
        public ListBox.ObjectCollection ZaEnergiju { get; set; }
        public ListBox.ObjectCollection ZaOstale { get; set; }
        public ListBox.ObjectCollection ZaProizvodne { get; set; }

        #endregion


        internal bool Delete(StringBuilder message)
        {
            try
            {
                client.ExecuteNonQuery("Delete from DefiniranjePotrazivanjaStavke");
                return true;
            }
            catch (Exception error) 
            {
                message.Append(error.Message);
                return false; 
            }
        }

        internal bool Insert(StringBuilder message, Obveze objekt)
        {
            throw new NotImplementedException();
        }

        internal bool Update(StringBuilder message, Potrazivanja objekt)
        {
            if (Delete(message))
            {
                string konto;
                try
                {
                    foreach (var item in ZaLijekove)
                    {
                        konto = item.ToString().Split('|')[0].Trim();
                        client.ExecuteNonQuery("Insert Into DefiniranjePotrazivanjaStavke (idDefiniranjePotrazivanja, idKonto) Values (1, '" + konto + "')");
                    }

                    foreach (var item in ZaSanitetski)
                    {
                        konto = item.ToString().Split('|')[0].Trim();
                        client.ExecuteNonQuery("Insert Into DefiniranjePotrazivanjaStavke (idDefiniranjePotrazivanja, idKonto) Values (2, '" + konto + "')");
                    }

                    foreach (var item in Zivezne)
                    {
                        konto = item.ToString().Split('|')[0].Trim();
                        client.ExecuteNonQuery("Insert Into DefiniranjePotrazivanjaStavke (idDefiniranjePotrazivanja, idKonto) Values (3, '" + konto + "')");
                    }

                    foreach (var item in ZaEnergiju)
                    {
                        konto = item.ToString().Split('|')[0].Trim();
                        client.ExecuteNonQuery("Insert Into DefiniranjePotrazivanjaStavke (idDefiniranjePotrazivanja, idKonto) Values (4, '" + konto + "')");
                    }

                    foreach (var item in ZaOstale)
                    {
                        konto = item.ToString().Split('|')[0].Trim();
                        client.ExecuteNonQuery("Insert Into DefiniranjePotrazivanjaStavke (idDefiniranjePotrazivanja, idKonto) Values (5, '" + konto + "')");
                    }

                    foreach (var item in ZaProizvodne)
                    {
                        konto = item.ToString().Split('|')[0].Trim();
                        client.ExecuteNonQuery("Insert Into DefiniranjePotrazivanjaStavke (idDefiniranjePotrazivanja, idKonto) Values (6, '" + konto + "')");
                    }

                    return true;
                }
                catch (Exception error)
                {
                    message.Append(error.Message);
                }
            }

            return false;
        }

        internal object GetSelected()
        {
            throw new NotImplementedException();
        }

        internal object GetKonto()
        {
            return client.GetDataTable("Select IDKONTO, (IDKONTO + ' | ' + NAZIVKONTO) As Naziv From KONTO");
        }

        internal List<ListKonto> GetZaLijekove(int vrsta)
        {
            List<ListKonto> list = new List<ListKonto>();

            DataTable konto = client.GetDataTable("Select KONTO.IDKONTO + ' | ' + KONTO.NAZIVKONTO From DefiniranjePotrazivanjaStavke Inner Join " +
                              "KONTO On DefiniranjePotrazivanjaStavke.idKonto = KONTO.IDKONTO Where idDefiniranjePotrazivanja = " + vrsta + " Order by KONTO.IDKONTO");

            ListKonto listKonto;

            foreach (DataRow item in konto.Rows)
            {
                listKonto = new ListKonto(); 
                listKonto.konto = item[0].ToString();
                list.Add(listKonto);
            }

            return list;
        }
    }
}

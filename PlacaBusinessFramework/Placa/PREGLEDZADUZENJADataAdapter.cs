namespace Placa
{
    using Deklarit.Data;
    using Deklarit.Utils;
    using Hlp;
    using Microsoft.VisualBasic;
    using System;
    using System.Collections;
    using System.Data;
    using System.Data.Common;
    using System.Reflection;
    using System.Resources;
    using System.Runtime.CompilerServices;
    using System.Threading;

    public class PREGLEDZADUZENJADataAdapter : IDataAdapter, IPREGLEDZADUZENJADataAdapter
    {
        private static string[] attributeNames = new string[] { "T1.[IDPARTNER]", "T4.[NAZIVPARTNER]", "T4.[PARTNEROIB]", "T2.[NAZIVPROIZVOD]", "T1.[IDPROIZVOD]", "T1.[IDZADUZENJE]", "T1.[KOLICINAZADUZENJA]", "T1.[CIJENAZADUZENJA]", "T3.[FINPOREZSTOPA]", "T1.[RABATZADUZENJA]", "T1.[UGOVORBROJ]", "T1.[DATUMUGOVORA]", "T1.[AKTIVNO]" };
        private ReadWriteCommand cmPARTNERZADUZENJESelect1;
        private ReadWriteCommand cmPARTNERZADUZENJESelect2;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        private DbParameter[] fillDataParameters;
        private string filterCondition;
        private string filterString;
        private bool m__AKTIVNOIsNull;
        private bool m__CIJENAZADUZENJAIsNull;
        private bool m__DATUMUGOVORAIsNull;
        private bool m__FINPOREZIDPOREZIsNull;
        private bool m__FINPOREZSTOPAIsNull;
        private bool m__IDPARTNERIsNull;
        private bool m__IDPROIZVODIsNull;
        private bool m__IDZADUZENJEIsNull;
        private bool m__IZNOSRABATAZADUZENJEIsNull;
        private bool m__IZNOSZADUZENJAIsNull;
        private bool m__KOLICINAZADUZENJAIsNull;
        private bool m__NAZIVPARTNERIsNull;
        private bool m__NAZIVPROIZVODIsNull;
        private bool m__PARTNEROIBIsNull;
        private bool m__RABATZADUZENJAIsNull;
        private bool m__UGOVORBROJIsNull;
        private bool m_AKTIVNO;
        private decimal m_CIJENAZADUZENJA;
        private decimal m_CIJENAZAFAKTURU;
        private DateTime m_DATUMUGOVORA;
        private int m_FINPOREZIDPOREZ;
        private decimal m_FINPOREZSTOPA;
        private int m_IDPARTNER;
        private int m_IDPROIZVOD;
        private int m_IDZADUZENJE;
        private decimal m_IZNOSRABATAZADUZENJE;
        private decimal m_IZNOSZADUZENJA;
        private decimal m_KOLICINAZADUZENJA;
        private string m_NAZIVPARTNER;
        private string m_NAZIVPROIZVOD;
        private string m_PARTNEROIB;
        private decimal m_RABATZADUZENJA;
        private int m_RecordCount;
        private string m_UGOVORBROJ;
        private string m_WhereString;
        private ArrayList orderArray;
        private string orderString;
        private IDataReader PARTNERZADUZENJESelect1;
        private IDataReader PARTNERZADUZENJESelect2;
        private PREGLEDZADUZENJADataSet PREGLEDZADUZENJASet;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private string reverseOrderString;
        private PREGLEDZADUZENJADataSet.PARTNERZADUZENJERow rowPARTNERZADUZENJE;
        private string scmdbuf;

        public PREGLEDZADUZENJADataAdapter()
        {
            this.Init_order_Partnerzaduzenje();
            this.orderString = GetOrderString(this.Order, true);
            this.reverseOrderString = GetOrderString(this.Order, false);
        }

        private void AddRowPartnerzaduzenje()
        {
            this.PREGLEDZADUZENJASet.PARTNERZADUZENJE.AddPARTNERZADUZENJERow(this.rowPARTNERZADUZENJE);
            this.rowPARTNERZADUZENJE.AcceptChanges();
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        public void executePrivate(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE " + this.filterString + "  T1.[AKTIVNO] = 1";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  T1.[IDPARTNER], T4.[NAZIVPARTNER], T4.[PARTNEROIB], T2.[NAZIVPROIZVOD], T1.[IDPROIZVOD], T1.[IDZADUZENJE], T1.[KOLICINAZADUZENJA], T1.[CIJENAZADUZENJA], T3.[FINPOREZSTOPA], T1.[RABATZADUZENJA], T1.[UGOVORBROJ], T1.[DATUMUGOVORA], T1.[AKTIVNO], T2.[FINPOREZIDPOREZ] FROM ((([PARTNERZADUZENJE] T1 INNER JOIN [PROIZVOD] T2 ON T2.[IDPROIZVOD] = T1.[IDPROIZVOD]) INNER JOIN [FINPOREZ] T3 ON T3.[FINPOREZIDPOREZ] = T2.[FINPOREZIDPOREZ]) INNER JOIN [PARTNER] T4 ON T4.[IDPARTNER] = T1.[IDPARTNER])" + this.m_WhereString + "" + this.orderString + "";
                }
                else
                {
                    string[] strArray = new string[] { "SELECT TOP ", (startRow + maxRows).ToString(), "  T1.[IDPARTNER], T4.[NAZIVPARTNER], T4.[PARTNEROIB], T2.[NAZIVPROIZVOD], T1.[IDPROIZVOD], T1.[IDZADUZENJE], T1.[KOLICINAZADUZENJA], T1.[CIJENAZADUZENJA], T3.[FINPOREZSTOPA], T1.[RABATZADUZENJA], T1.[UGOVORBROJ], T1.[DATUMUGOVORA], T1.[AKTIVNO], T2.[FINPOREZIDPOREZ] FROM ((([PARTNERZADUZENJE] T1 INNER JOIN [PROIZVOD] T2 ON T2.[IDPROIZVOD] = T1.[IDPROIZVOD]) INNER JOIN [FINPOREZ] T3 ON T3.[FINPOREZIDPOREZ] = T2.[FINPOREZIDPOREZ]) INNER JOIN [PARTNER] T4 ON T4.[IDPARTNER] = T1.[IDPARTNER])", this.m_WhereString, "", this.orderString, "" };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT T1.[IDPARTNER], T4.[NAZIVPARTNER], T4.[PARTNEROIB], T2.[NAZIVPROIZVOD], T1.[IDPROIZVOD], T1.[IDZADUZENJE], T1.[KOLICINAZADUZENJA], T1.[CIJENAZADUZENJA], T3.[FINPOREZSTOPA], T1.[RABATZADUZENJA], T1.[UGOVORBROJ], T1.[DATUMUGOVORA], T1.[AKTIVNO], T2.[FINPOREZIDPOREZ] FROM ((([PARTNERZADUZENJE] T1 INNER JOIN [PROIZVOD] T2 ON T2.[IDPROIZVOD] = T1.[IDPROIZVOD]) INNER JOIN [FINPOREZ] T3 ON T3.[FINPOREZIDPOREZ] = T2.[FINPOREZIDPOREZ]) INNER JOIN [PARTNER] T4 ON T4.[IDPARTNER] = T1.[IDPARTNER])" + this.m_WhereString + "" + this.orderString + " ";
            }
            this.cmPARTNERZADUZENJESelect2 = this.connDefault.GetCommand(this.scmdbuf, false);
            this.cmPARTNERZADUZENJESelect2.ErrorMask |= ErrorMask.Lock;
            this.PARTNERZADUZENJESelect2 = this.cmPARTNERZADUZENJESelect2.FetchData();
            while (this.cmPARTNERZADUZENJESelect2.HasMoreRows && (startRow > 0))
            {
                startRow--;
                this.cmPARTNERZADUZENJESelect2.HasMoreRows = this.PARTNERZADUZENJESelect2.Read();
            }
            int num = 0;
            while (this.cmPARTNERZADUZENJESelect2.HasMoreRows && (num != maxRows))
            {
                this.m_IDPARTNER = this.dsDefault.Db.GetInt32(this.PARTNERZADUZENJESelect2, 0, ref this.m__IDPARTNERIsNull);
                this.m_NAZIVPARTNER = this.dsDefault.Db.GetString(this.PARTNERZADUZENJESelect2, 1, ref this.m__NAZIVPARTNERIsNull).TrimEnd(new char[] { ' ' });
                this.m_PARTNEROIB = this.dsDefault.Db.GetString(this.PARTNERZADUZENJESelect2, 2, ref this.m__PARTNEROIBIsNull);
                this.m_NAZIVPROIZVOD = this.dsDefault.Db.GetString(this.PARTNERZADUZENJESelect2, 3, ref this.m__NAZIVPROIZVODIsNull);
                this.m_IDPROIZVOD = this.dsDefault.Db.GetInt32(this.PARTNERZADUZENJESelect2, 4, ref this.m__IDPROIZVODIsNull);
                this.m_IDZADUZENJE = this.dsDefault.Db.GetInt32(this.PARTNERZADUZENJESelect2, 5, ref this.m__IDZADUZENJEIsNull);
                this.m_KOLICINAZADUZENJA = this.dsDefault.Db.GetDecimal(this.PARTNERZADUZENJESelect2, 6, ref this.m__KOLICINAZADUZENJAIsNull);
                this.m_CIJENAZADUZENJA = this.dsDefault.Db.GetDecimal(this.PARTNERZADUZENJESelect2, 7, ref this.m__CIJENAZADUZENJAIsNull);
                this.m_FINPOREZSTOPA = this.dsDefault.Db.GetDecimal(this.PARTNERZADUZENJESelect2, 8, ref this.m__FINPOREZSTOPAIsNull);
                this.m_RABATZADUZENJA = this.dsDefault.Db.GetDecimal(this.PARTNERZADUZENJESelect2, 9, ref this.m__RABATZADUZENJAIsNull);
                this.m_UGOVORBROJ = this.dsDefault.Db.GetString(this.PARTNERZADUZENJESelect2, 10, ref this.m__UGOVORBROJIsNull);
                this.m_DATUMUGOVORA = this.dsDefault.Db.GetDateTime(this.PARTNERZADUZENJESelect2, 11, ref this.m__DATUMUGOVORAIsNull);
                this.m_AKTIVNO = this.dsDefault.Db.GetBoolean(this.PARTNERZADUZENJESelect2, 12, ref this.m__AKTIVNOIsNull);
                this.m_FINPOREZIDPOREZ = this.dsDefault.Db.GetInt32(this.PARTNERZADUZENJESelect2, 13, ref this.m__FINPOREZIDPOREZIsNull);
                this.m_NAZIVPROIZVOD = this.dsDefault.Db.GetString(this.PARTNERZADUZENJESelect2, 3, ref this.m__NAZIVPROIZVODIsNull);
                this.m_FINPOREZIDPOREZ = this.dsDefault.Db.GetInt32(this.PARTNERZADUZENJESelect2, 13, ref this.m__FINPOREZIDPOREZIsNull);
                this.m_FINPOREZSTOPA = this.dsDefault.Db.GetDecimal(this.PARTNERZADUZENJESelect2, 8, ref this.m__FINPOREZSTOPAIsNull);
                this.m_NAZIVPARTNER = this.dsDefault.Db.GetString(this.PARTNERZADUZENJESelect2, 1, ref this.m__NAZIVPARTNERIsNull).TrimEnd(new char[] { ' ' });
                this.m_PARTNEROIB = this.dsDefault.Db.GetString(this.PARTNERZADUZENJESelect2, 2, ref this.m__PARTNEROIBIsNull);
                this.m_IZNOSZADUZENJA = decimal.Multiply(this.m_CIJENAZADUZENJA, this.m_KOLICINAZADUZENJA);
                if (!this.m__IZNOSZADUZENJAIsNull)
                {
                    this.m_IZNOSRABATAZADUZENJE = DB.RoundUP(decimal.Divide(decimal.Multiply(this.m_IZNOSZADUZENJA, this.m_RABATZADUZENJA), 100M));
                }
                if (!this.m__IZNOSZADUZENJAIsNull && !this.m__IZNOSRABATAZADUZENJEIsNull)
                {
                    this.m_CIJENAZAFAKTURU = decimal.Subtract(this.m_IZNOSZADUZENJA, this.m_IZNOSRABATAZADUZENJE);
                }
                this.rowPARTNERZADUZENJE = this.PREGLEDZADUZENJASet.PARTNERZADUZENJE.NewPARTNERZADUZENJERow();
                this.rowPARTNERZADUZENJE["IDPARTNER"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__IDPARTNERIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_IDPARTNER));
                this.rowPARTNERZADUZENJE["NAZIVPARTNER"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__NAZIVPARTNERIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_NAZIVPARTNER));
                this.rowPARTNERZADUZENJE["PARTNEROIB"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__PARTNEROIBIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_PARTNEROIB));
                this.rowPARTNERZADUZENJE["NAZIVPROIZVOD"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__NAZIVPROIZVODIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_NAZIVPROIZVOD));
                this.rowPARTNERZADUZENJE["IDPROIZVOD"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__IDPROIZVODIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_IDPROIZVOD));
                this.rowPARTNERZADUZENJE["IDZADUZENJE"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__IDZADUZENJEIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_IDZADUZENJE));
                this.rowPARTNERZADUZENJE["KOLICINAZADUZENJA"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__KOLICINAZADUZENJAIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_KOLICINAZADUZENJA));
                this.rowPARTNERZADUZENJE["CIJENAZADUZENJA"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__CIJENAZADUZENJAIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_CIJENAZADUZENJA));
                this.rowPARTNERZADUZENJE["FINPOREZSTOPA"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__FINPOREZSTOPAIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_FINPOREZSTOPA));
                this.rowPARTNERZADUZENJE.IZNOSZADUZENJA = this.m_IZNOSZADUZENJA;
                this.rowPARTNERZADUZENJE["RABATZADUZENJA"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__RABATZADUZENJAIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_RABATZADUZENJA));
                this.rowPARTNERZADUZENJE.IZNOSRABATAZADUZENJE = this.m_IZNOSRABATAZADUZENJE;
                this.rowPARTNERZADUZENJE.CIJENAZAFAKTURU = this.m_CIJENAZAFAKTURU;
                this.rowPARTNERZADUZENJE["UGOVORBROJ"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__UGOVORBROJIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_UGOVORBROJ));
                this.rowPARTNERZADUZENJE["DATUMUGOVORA"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__DATUMUGOVORAIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_DATUMUGOVORA));
                this.rowPARTNERZADUZENJE["AKTIVNO"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__AKTIVNOIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_AKTIVNO));
                this.AddRowPartnerzaduzenje();
                num++;
                this.cmPARTNERZADUZENJESelect2.HasMoreRows = this.PARTNERZADUZENJESelect2.Read();
            }
            this.PARTNERZADUZENJESelect2.Close();
            this.Cleanup();
        }

        public virtual int Fill(PREGLEDZADUZENJADataSet dataSet)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.PREGLEDZADUZENJASet = dataSet;
            this.rowPARTNERZADUZENJE = this.PREGLEDZADUZENJASet.PARTNERZADUZENJE.NewPARTNERZADUZENJERow();
            this.orderString = GetOrderString(this.Order, true);
            this.reverseOrderString = GetOrderString(this.Order, false);
            try
            {
                this.executePrivate(0, -1);
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int Fill(DataSet dataSet)
        {
            this.PREGLEDZADUZENJASet = (PREGLEDZADUZENJADataSet) dataSet;
            if (this.PREGLEDZADUZENJASet != null)
            {
                return this.Fill(this.PREGLEDZADUZENJASet);
            }
            this.PREGLEDZADUZENJASet = new PREGLEDZADUZENJADataSet();
            this.Fill(this.PREGLEDZADUZENJASet);
            dataSet.Merge(this.PREGLEDZADUZENJASet);
            return 0;
        }

        public virtual int FillPage(PREGLEDZADUZENJADataSet dataSet, int startRow, int maxRows)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.PREGLEDZADUZENJASet = dataSet;
            this.rowPARTNERZADUZENJE = this.PREGLEDZADUZENJASet.PARTNERZADUZENJE.NewPARTNERZADUZENJERow();
            this.orderString = GetOrderString(this.Order, true);
            this.reverseOrderString = GetOrderString(this.Order, false);
            try
            {
                this.executePrivate(startRow, maxRows);
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillPage(DataSet dataSet, int startRow, int maxRows)
        {
            this.PREGLEDZADUZENJASet = (PREGLEDZADUZENJADataSet) dataSet;
            if (this.PREGLEDZADUZENJASet != null)
            {
                return this.FillPage(this.PREGLEDZADUZENJASet, startRow, maxRows);
            }
            this.PREGLEDZADUZENJASet = new PREGLEDZADUZENJADataSet();
            this.FillPage(this.PREGLEDZADUZENJASet, startRow, maxRows);
            dataSet.Merge(this.PREGLEDZADUZENJASet);
            return 0;
        }

        public virtual DataTable[] FillSchema(DataSet dataSet, SchemaType schemaType)
        {
            DataTable[] array = new DataTable[dataSet.Tables.Count + 1];
            dataSet.Tables.CopyTo(array, dataSet.Tables.Count);
            return array;
        }

        public static string GetAttributeName(Attribute attribute)
        {
            return attributeNames[(int) attribute];
        }

        public virtual IDataParameter[] GetFillParameters()
        {
            if (this.fillDataParameters == null)
            {
                DbProviderFactory factory = DbProviderFactories.GetFactory("System.Data.SqlClient");
                this.fillDataParameters = new DbParameter[0];
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount()
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            string str = " WHERE T1.[AKTIVNO] = 1";
            this.scmdbuf = "SELECT COUNT(*) FROM ((([PARTNERZADUZENJE] T1 INNER JOIN [PROIZVOD] T2 ON T2.[IDPROIZVOD] = T1.[IDPROIZVOD]) INNER JOIN [FINPOREZ] T3 ON T3.[FINPOREZIDPOREZ] = T2.[FINPOREZIDPOREZ]) INNER JOIN [PARTNER] T4 ON T4.[IDPARTNER] = T1.[IDPARTNER])" + str + "  ";
            this.cmPARTNERZADUZENJESelect1 = this.connDefault.GetCommand(this.scmdbuf, false);
            this.cmPARTNERZADUZENJESelect1.ErrorMask |= ErrorMask.Lock;
            this.PARTNERZADUZENJESelect1 = this.cmPARTNERZADUZENJESelect1.FetchData();
            if (this.PARTNERZADUZENJESelect1.IsDBNull(0))
            {
                this.m_RecordCount = 0;
            }
            else
            {
                this.m_RecordCount = this.PARTNERZADUZENJESelect1.GetInt32(0);
            }
            this.PARTNERZADUZENJESelect1.Close();
            return this.m_RecordCount;
        }

        public static string GetOrderString(ArrayList ListOrder, bool AscendingOrder)
        {
            IEnumerator enumerator = null;
            string str2 = "";
            string str3 = "";
            if (ListOrder.Count > 0)
            {
                str3 = " ORDER BY ";
            }
            try
            {
                enumerator = ListOrder.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    OrderAttribute current = (OrderAttribute) enumerator.Current;
                    if (current.OrderAttributeAscending == AscendingOrder)
                    {
                        str2 = str2 + str3 + " " + current.OrderAttributeString;
                    }
                    else
                    {
                        str2 = str2 + str3 + " " + current.OrderAttributeString + " DESC";
                    }
                    str3 = ", ";
                }
            }
            finally
            {
                if (enumerator is IDisposable)
                {
                    (enumerator as IDisposable).Dispose();
                }
            }
            return str2;
        }

        public virtual int GetRecordCount()
        {
            int internalRecordCount;
            try
            {
                internalRecordCount = this.GetInternalRecordCount();
            }
            finally
            {
                this.Cleanup();
            }
            return internalRecordCount;
        }

        private void Init_order_Partnerzaduzenje()
        {
            this.Order = new ArrayList();
        }

        private void Initialize()
        {
            this.resourceManager = Deklarit.Utils.ResourceManager.Instance;
            this.resourceManagerTables = new System.Resources.ResourceManager("Tables", Assembly.GetExecutingAssembly());
            this.scmdbuf = "";
            this.m_WhereString = "";
            this.m_RecordCount = 0;
            this.m__IDPARTNERIsNull = false;
            this.m_IDPARTNER = 0;
            this.m__NAZIVPARTNERIsNull = false;
            this.m_NAZIVPARTNER = "";
            this.m__PARTNEROIBIsNull = false;
            this.m_PARTNEROIB = "";
            this.m__NAZIVPROIZVODIsNull = false;
            this.m_NAZIVPROIZVOD = "";
            this.m__IDPROIZVODIsNull = false;
            this.m_IDPROIZVOD = 0;
            this.m__IDZADUZENJEIsNull = false;
            this.m_IDZADUZENJE = 0;
            this.m__KOLICINAZADUZENJAIsNull = false;
            this.m_KOLICINAZADUZENJA = new decimal();
            this.m__CIJENAZADUZENJAIsNull = false;
            this.m_CIJENAZADUZENJA = new decimal();
            this.m__FINPOREZSTOPAIsNull = false;
            this.m_FINPOREZSTOPA = new decimal();
            this.m__RABATZADUZENJAIsNull = false;
            this.m_RABATZADUZENJA = new decimal();
            this.m__UGOVORBROJIsNull = false;
            this.m_UGOVORBROJ = "";
            this.m__DATUMUGOVORAIsNull = false;
            this.m_DATUMUGOVORA = DateTime.MinValue;
            this.m__AKTIVNOIsNull = false;
            this.m_AKTIVNO = false;
            this.m__FINPOREZIDPOREZIsNull = false;
            this.m_FINPOREZIDPOREZ = 0;
            this.m_IZNOSZADUZENJA = new decimal();
            this.m_IZNOSRABATAZADUZENJE = new decimal();
            this.m__IZNOSZADUZENJAIsNull = false;
            this.m_CIJENAZAFAKTURU = new decimal();
            this.m__IZNOSRABATAZADUZENJEIsNull = false;
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        public virtual int Update(DataSet dataSet)
        {
            throw new InvalidOperationException();
        }

        public string Filter
        {
            get
            {
                return this.filterCondition;
            }
            set
            {
                this.filterCondition = value;
                this.filterString = QueryHelper.AddFilterString(this.filterCondition);
            }
        }

        public System.Data.MissingMappingAction MissingMappingAction
        {
            get
            {
                return System.Data.MissingMappingAction.Passthrough;
            }
            set
            {
            }
        }

        System.Data.MissingSchemaAction MissingSchemaAction
        {
            get
            {
                return System.Data.MissingSchemaAction.Ignore;
            }
            set
            {
            }
        }

        public ArrayList Order
        {
            get
            {
                return this.orderArray;
            }
            set
            {
                this.orderArray = value;
            }
        }

        string Placa.IPREGLEDZADUZENJADataAdapter.Filter
        {
            get
            {
                return this.filterCondition;
            }
            set
            {
                this.filterCondition = value;
                this.filterString = QueryHelper.AddFilterString(this.filterCondition);
            }
        }

        System.Data.MissingMappingAction System.Data.IDataAdapter.MissingMappingAction
        {
            get
            {
                return System.Data.MissingMappingAction.Passthrough;
            }
            set
            {
            }
        }

        System.Data.MissingSchemaAction System.Data.IDataAdapter.MissingSchemaAction
        {
            get
            {
                return System.Data.MissingSchemaAction.Ignore;
            }
            set
            {
            }
        }

        ITableMappingCollection System.Data.IDataAdapter.TableMappings
        {
            get
            {
                return new DataTableMappingCollection();
            }
        }

        ITableMappingCollection TableMappings
        {
            get
            {
                return new DataTableMappingCollection();
            }
        }

        public IDbTransaction Transaction
        {
            get
            {
                return this.daCurrentTransaction;
            }
            set
            {
                this.daCurrentTransaction = value;
            }
        }

        public enum Attribute
        {
            IDPARTNER,
            NAZIVPARTNER,
            PARTNEROIB,
            NAZIVPROIZVOD,
            IDPROIZVOD,
            IDZADUZENJE,
            KOLICINAZADUZENJA,
            CIJENAZADUZENJA,
            FINPOREZSTOPA,
            RABATZADUZENJA,
            UGOVORBROJ,
            DATUMUGOVORA,
            AKTIVNO
        }

        public class OrderAttribute
        {
            public bool OrderAttributeAscending;
            public PREGLEDZADUZENJADataAdapter.Attribute OrderAttributeName;
            public string OrderAttributeString;

            public OrderAttribute(PREGLEDZADUZENJADataAdapter.Attribute orderAttributeName)
            {
                this.OrderAttributeName = orderAttributeName;
                this.OrderAttributeAscending = true;
                this.OrderAttributeString = PREGLEDZADUZENJADataAdapter.attributeNames[(int) this.OrderAttributeName];
            }

            public OrderAttribute(PREGLEDZADUZENJADataAdapter.Attribute orderAttributeName, bool orderAttributeAscending)
            {
                this.OrderAttributeName = orderAttributeName;
                this.OrderAttributeAscending = orderAttributeAscending;
                this.OrderAttributeString = PREGLEDZADUZENJADataAdapter.attributeNames[(int) this.OrderAttributeName];
            }
        }
    }
}


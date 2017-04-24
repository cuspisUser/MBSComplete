namespace Placa
{
    using Deklarit.Data;
    using Deklarit.Utils;
    using Microsoft.VisualBasic;
    using System;
    using System.Collections;
    using System.Data;
    using System.Data.Common;
    using System.Reflection;
    using System.Resources;
    using System.Runtime.CompilerServices;
    using System.Threading;

    public class PregledObracunaDataAdapter : IDataAdapter, IPregledObracunaDataAdapter
    {
        private static string[] attributeNames = new string[] { 
            "[IDOBRACUN]", "[VRSTAOBRACUNA]", "[MJESECOBRACUNA]", "[GODINAOBRACUNA]", "[MJESECISPLATE]", "[GODINAISPLATE]", "[DATUMISPLATE]", "[tjednifondsatiobracun]", "[MJESECNIFONDSATIOBRACUN]", "[OSNOVNIOO]", "[OBRACUNSKAOSNOVICA]", "[DATUMOBRACUNASTAZA]", "[OBRPOSTOTNIH]", "[OBRFIKSNIH]", "[OBRKREDITNIH]", "[ZAKLJ]", 
            "[SVRHAOBRACUNA]", "[IDENTIFIKATOROBRASCA]"
         };
        private ReadWriteCommand cmPregledObracunaSelect1;
        private ReadWriteCommand cmPregledObracunaSelect2;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        private DbParameter[] fillDataParameters;
        private string filterCondition;
        private string filterString;
        private string filterStringCond;
        private bool m__DATUMISPLATEIsNull;
        private bool m__DATUMOBRACUNASTAZAIsNull;
        private bool m__GODINAISPLATEIsNull;
        private bool m__GODINAOBRACUNAIsNull;
        private bool m__IDENTIFIKATOROBRASCAIsNull;
        private bool m__IDOBRACUNIsNull;
        private bool m__MJESECISPLATEIsNull;
        private bool m__MJESECNIFONDSATIOBRACUNIsNull;
        private bool m__MJESECOBRACUNAIsNull;
        private bool m__OBRACUNSKAOSNOVICAIsNull;
        private bool m__OBRFIKSNIHIsNull;
        private bool m__OBRKREDITNIHIsNull;
        private bool m__OBRPOSTOTNIHIsNull;
        private bool m__OSNOVNIOOIsNull;
        private bool m__SVRHAOBRACUNAIsNull;
        private bool m__tjednifondsatiobracunIsNull;
        private bool m__VRSTAOBRACUNAIsNull;
        private bool m__ZAKLJIsNull;
        private DateTime m_DATUMISPLATE;
        private DateTime m_DATUMOBRACUNASTAZA;
        private string m_GODINAISPLATE;
        private string m_GODINAOBRACUNA;
        private string m_IDENTIFIKATOROBRASCA;
        private string m_IDOBRACUN;
        private string m_MJESECISPLATE;
        private short m_MJESECNIFONDSATIOBRACUN;
        private string m_MJESECOBRACUNA;
        private decimal m_OBRACUNSKAOSNOVICA;
        private bool m_OBRFIKSNIH;
        private bool m_OBRKREDITNIH;
        private bool m_OBRPOSTOTNIH;
        private decimal m_OSNOVNIOO;
        private int m_RecordCount;
        private string m_SVRHAOBRACUNA;
        private short m_tjednifondsatiobracun;
        private string m_VRSTAOBRACUNA;
        private string m_WhereString;
        private bool m_ZAKLJ;
        private ArrayList orderArray;
        private string orderString;
        private IDataReader PregledObracunaSelect1;
        private IDataReader PregledObracunaSelect2;
        private PregledObracunaDataSet PregledObracunaSet;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private string reverseOrderString;
        private PregledObracunaDataSet.PregledObracunaRow rowPregledObracuna;
        private string scmdbuf;

        public PregledObracunaDataAdapter()
        {
            this.Init_order_Pregledobracuna();
            this.orderString = GetOrderString(this.Order, true);
            this.reverseOrderString = GetOrderString(this.Order, false);
        }

        private void AddRowPregledobracuna()
        {
            this.PregledObracunaSet.PregledObracuna.AddPregledObracunaRow(this.rowPregledObracuna);
            this.rowPregledObracuna.AcceptChanges();
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        public void executePrivate(int startRow, int maxRows)
        {
            this.m_WhereString = "" + this.filterString + "  ";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  [IDOBRACUN], [VRSTAOBRACUNA], [MJESECOBRACUNA], [GODINAOBRACUNA], [MJESECISPLATE], [GODINAISPLATE], [DATUMISPLATE], [tjednifondsatiobracun], [MJESECNIFONDSATIOBRACUN], [OSNOVNIOO], [OBRACUNSKAOSNOVICA], [DATUMOBRACUNASTAZA], [OBRPOSTOTNIH], [OBRFIKSNIH], [OBRKREDITNIH], [ZAKLJ], [SVRHAOBRACUNA], [IDENTIFIKATOROBRASCA] FROM [vwPregledObracuna]" + this.m_WhereString + "" + this.orderString + "";
                }
                else
                {
                    string[] strArray = new string[] { "SELECT TOP ", (startRow + maxRows).ToString(), "  [IDOBRACUN], [VRSTAOBRACUNA], [MJESECOBRACUNA], [GODINAOBRACUNA], [MJESECISPLATE], [GODINAISPLATE], [DATUMISPLATE], [tjednifondsatiobracun], [MJESECNIFONDSATIOBRACUN], [OSNOVNIOO], [OBRACUNSKAOSNOVICA], [DATUMOBRACUNASTAZA], [OBRPOSTOTNIH], [OBRFIKSNIH], [OBRKREDITNIH], [ZAKLJ], [SVRHAOBRACUNA], [IDENTIFIKATOROBRASCA] FROM [vwPregledObracuna]", this.m_WhereString, "", this.orderString, "" };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT [IDOBRACUN], [VRSTAOBRACUNA], [MJESECOBRACUNA], [GODINAOBRACUNA], [MJESECISPLATE], [GODINAISPLATE], [DATUMISPLATE], [tjednifondsatiobracun], [MJESECNIFONDSATIOBRACUN], [OSNOVNIOO], [OBRACUNSKAOSNOVICA], [DATUMOBRACUNASTAZA], [OBRPOSTOTNIH], [OBRFIKSNIH], [OBRKREDITNIH], [ZAKLJ], [SVRHAOBRACUNA], [IDENTIFIKATOROBRASCA] FROM [vwPregledObracuna]" + this.m_WhereString + "" + this.orderString + " ";
            }
            this.cmPregledObracunaSelect2 = this.connDefault.GetCommand(this.scmdbuf, true);
            this.cmPregledObracunaSelect2.ErrorMask |= ErrorMask.Lock;
            this.PregledObracunaSelect2 = this.cmPregledObracunaSelect2.FetchData();
            while (this.cmPregledObracunaSelect2.HasMoreRows && (startRow > 0))
            {
                startRow--;
                this.cmPregledObracunaSelect2.HasMoreRows = this.PregledObracunaSelect2.Read();
            }
            int num = 0;
            while (this.cmPregledObracunaSelect2.HasMoreRows && (num != maxRows))
            {
                this.m_IDOBRACUN = this.dsDefault.Db.GetString(this.PregledObracunaSelect2, 0, ref this.m__IDOBRACUNIsNull);
                this.m_VRSTAOBRACUNA = this.dsDefault.Db.GetString(this.PregledObracunaSelect2, 1, ref this.m__VRSTAOBRACUNAIsNull);
                this.m_MJESECOBRACUNA = this.dsDefault.Db.GetString(this.PregledObracunaSelect2, 2, ref this.m__MJESECOBRACUNAIsNull);
                this.m_GODINAOBRACUNA = this.dsDefault.Db.GetString(this.PregledObracunaSelect2, 3, ref this.m__GODINAOBRACUNAIsNull);
                this.m_MJESECISPLATE = this.dsDefault.Db.GetString(this.PregledObracunaSelect2, 4, ref this.m__MJESECISPLATEIsNull);
                this.m_GODINAISPLATE = this.dsDefault.Db.GetString(this.PregledObracunaSelect2, 5, ref this.m__GODINAISPLATEIsNull);
                this.m_DATUMISPLATE = this.dsDefault.Db.GetDateTime(this.PregledObracunaSelect2, 6, ref this.m__DATUMISPLATEIsNull);
                this.m_tjednifondsatiobracun = this.dsDefault.Db.GetInt16(this.PregledObracunaSelect2, 7, ref this.m__tjednifondsatiobracunIsNull);
                this.m_MJESECNIFONDSATIOBRACUN = this.dsDefault.Db.GetInt16(this.PregledObracunaSelect2, 8, ref this.m__MJESECNIFONDSATIOBRACUNIsNull);
                this.m_OSNOVNIOO = this.dsDefault.Db.GetDecimal(this.PregledObracunaSelect2, 9, ref this.m__OSNOVNIOOIsNull);
                this.m_OBRACUNSKAOSNOVICA = this.dsDefault.Db.GetDecimal(this.PregledObracunaSelect2, 10, ref this.m__OBRACUNSKAOSNOVICAIsNull);
                this.m_DATUMOBRACUNASTAZA = this.dsDefault.Db.GetDateTime(this.PregledObracunaSelect2, 11, ref this.m__DATUMOBRACUNASTAZAIsNull);
                this.m_OBRPOSTOTNIH = this.dsDefault.Db.GetBoolean(this.PregledObracunaSelect2, 12, ref this.m__OBRPOSTOTNIHIsNull);
                this.m_OBRFIKSNIH = this.dsDefault.Db.GetBoolean(this.PregledObracunaSelect2, 13, ref this.m__OBRFIKSNIHIsNull);
                this.m_OBRKREDITNIH = this.dsDefault.Db.GetBoolean(this.PregledObracunaSelect2, 14, ref this.m__OBRKREDITNIHIsNull);
                this.m_ZAKLJ = this.dsDefault.Db.GetBoolean(this.PregledObracunaSelect2, 15, ref this.m__ZAKLJIsNull);
                this.m_SVRHAOBRACUNA = this.dsDefault.Db.GetString(this.PregledObracunaSelect2, 0x10, ref this.m__SVRHAOBRACUNAIsNull);
                this.m_IDENTIFIKATOROBRASCA = this.dsDefault.Db.GetString(this.PregledObracunaSelect2, 0x11, ref this.m__IDENTIFIKATOROBRASCAIsNull);
                this.rowPregledObracuna = this.PregledObracunaSet.PregledObracuna.NewPregledObracunaRow();
                this.rowPregledObracuna["IDOBRACUN"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__IDOBRACUNIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_IDOBRACUN));
                this.rowPregledObracuna["VRSTAOBRACUNA"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__VRSTAOBRACUNAIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_VRSTAOBRACUNA));
                this.rowPregledObracuna["MJESECOBRACUNA"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__MJESECOBRACUNAIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_MJESECOBRACUNA));
                this.rowPregledObracuna["GODINAOBRACUNA"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__GODINAOBRACUNAIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_GODINAOBRACUNA));
                this.rowPregledObracuna["MJESECISPLATE"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__MJESECISPLATEIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_MJESECISPLATE));
                this.rowPregledObracuna["GODINAISPLATE"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__GODINAISPLATEIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_GODINAISPLATE));
                this.rowPregledObracuna["DATUMISPLATE"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__DATUMISPLATEIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_DATUMISPLATE));
                this.rowPregledObracuna["tjednifondsatiobracun"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__tjednifondsatiobracunIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_tjednifondsatiobracun));
                this.rowPregledObracuna["MJESECNIFONDSATIOBRACUN"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__MJESECNIFONDSATIOBRACUNIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_MJESECNIFONDSATIOBRACUN));
                this.rowPregledObracuna["OSNOVNIOO"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__OSNOVNIOOIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_OSNOVNIOO));
                this.rowPregledObracuna["OBRACUNSKAOSNOVICA"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__OBRACUNSKAOSNOVICAIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_OBRACUNSKAOSNOVICA));
                this.rowPregledObracuna["DATUMOBRACUNASTAZA"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__DATUMOBRACUNASTAZAIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_DATUMOBRACUNASTAZA));
                this.rowPregledObracuna["OBRPOSTOTNIH"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__OBRPOSTOTNIHIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_OBRPOSTOTNIH));
                this.rowPregledObracuna["OBRFIKSNIH"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__OBRFIKSNIHIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_OBRFIKSNIH));
                this.rowPregledObracuna["OBRKREDITNIH"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__OBRKREDITNIHIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_OBRKREDITNIH));
                this.rowPregledObracuna["ZAKLJ"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__ZAKLJIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_ZAKLJ));
                this.rowPregledObracuna["SVRHAOBRACUNA"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__SVRHAOBRACUNAIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_SVRHAOBRACUNA));
                this.rowPregledObracuna["IDENTIFIKATOROBRASCA"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__IDENTIFIKATOROBRASCAIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_IDENTIFIKATOROBRASCA));
                this.AddRowPregledobracuna();
                num++;
                this.cmPregledObracunaSelect2.HasMoreRows = this.PregledObracunaSelect2.Read();
            }
            this.PregledObracunaSelect2.Close();
            this.Cleanup();
        }

        public virtual int Fill(PregledObracunaDataSet dataSet)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.PregledObracunaSet = dataSet;
            this.rowPregledObracuna = this.PregledObracunaSet.PregledObracuna.NewPregledObracunaRow();
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
            this.PregledObracunaSet = (PregledObracunaDataSet) dataSet;
            if (this.PregledObracunaSet != null)
            {
                return this.Fill(this.PregledObracunaSet);
            }
            this.PregledObracunaSet = new PregledObracunaDataSet();
            this.Fill(this.PregledObracunaSet);
            dataSet.Merge(this.PregledObracunaSet);
            return 0;
        }

        public virtual int FillPage(PregledObracunaDataSet dataSet, int startRow, int maxRows)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.PregledObracunaSet = dataSet;
            this.rowPregledObracuna = this.PregledObracunaSet.PregledObracuna.NewPregledObracunaRow();
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
            this.PregledObracunaSet = (PregledObracunaDataSet) dataSet;
            if (this.PregledObracunaSet != null)
            {
                return this.FillPage(this.PregledObracunaSet, startRow, maxRows);
            }
            this.PregledObracunaSet = new PregledObracunaDataSet();
            this.FillPage(this.PregledObracunaSet, startRow, maxRows);
            dataSet.Merge(this.PregledObracunaSet);
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
            string str = "";
            this.scmdbuf = "SELECT COUNT(*) FROM [vwPregledObracuna]" + str + "  ";
            this.cmPregledObracunaSelect1 = this.connDefault.GetCommand(this.scmdbuf, true);
            this.cmPregledObracunaSelect1.ErrorMask |= ErrorMask.Lock;
            this.PregledObracunaSelect1 = this.cmPregledObracunaSelect1.FetchData();
            if (this.PregledObracunaSelect1.IsDBNull(0))
            {
                this.m_RecordCount = 0;
            }
            else
            {
                this.m_RecordCount = this.PregledObracunaSelect1.GetInt32(0);
            }
            this.PregledObracunaSelect1.Close();
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

        private void Init_order_Pregledobracuna()
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
            this.m__IDOBRACUNIsNull = false;
            this.m_IDOBRACUN = "";
            this.m__VRSTAOBRACUNAIsNull = false;
            this.m_VRSTAOBRACUNA = "";
            this.m__MJESECOBRACUNAIsNull = false;
            this.m_MJESECOBRACUNA = "";
            this.m__GODINAOBRACUNAIsNull = false;
            this.m_GODINAOBRACUNA = "";
            this.m__MJESECISPLATEIsNull = false;
            this.m_MJESECISPLATE = "";
            this.m__GODINAISPLATEIsNull = false;
            this.m_GODINAISPLATE = "";
            this.m__DATUMISPLATEIsNull = false;
            this.m_DATUMISPLATE = DateTime.MinValue;
            this.m__tjednifondsatiobracunIsNull = false;
            this.m_tjednifondsatiobracun = 0;
            this.m__MJESECNIFONDSATIOBRACUNIsNull = false;
            this.m_MJESECNIFONDSATIOBRACUN = 0;
            this.m__OSNOVNIOOIsNull = false;
            this.m_OSNOVNIOO = new decimal();
            this.m__OBRACUNSKAOSNOVICAIsNull = false;
            this.m_OBRACUNSKAOSNOVICA = new decimal();
            this.m__DATUMOBRACUNASTAZAIsNull = false;
            this.m_DATUMOBRACUNASTAZA = DateTime.MinValue;
            this.m__OBRPOSTOTNIHIsNull = false;
            this.m_OBRPOSTOTNIH = false;
            this.m__OBRFIKSNIHIsNull = false;
            this.m_OBRFIKSNIH = false;
            this.m__OBRKREDITNIHIsNull = false;
            this.m_OBRKREDITNIH = false;
            this.m__ZAKLJIsNull = false;
            this.m_ZAKLJ = false;
            this.m__SVRHAOBRACUNAIsNull = false;
            this.m_SVRHAOBRACUNA = "";
            this.m__IDENTIFIKATOROBRASCAIsNull = false;
            this.m_IDENTIFIKATOROBRASCA = "";
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
                this.filterString = QueryHelper.GetFilterString(this.filterCondition);
                this.filterStringCond = QueryHelper.AddFilterString(this.filterCondition);
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

        string Placa.IPregledObracunaDataAdapter.Filter
        {
            get
            {
                return this.filterCondition;
            }
            set
            {
                this.filterCondition = value;
                this.filterString = QueryHelper.GetFilterString(this.filterCondition);
                this.filterStringCond = QueryHelper.AddFilterString(this.filterCondition);
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
            IDOBRACUN,
            VRSTAOBRACUNA,
            MJESECOBRACUNA,
            GODINAOBRACUNA,
            MJESECISPLATE,
            GODINAISPLATE,
            DATUMISPLATE,
            tjednifondsatiobracun,
            MJESECNIFONDSATIOBRACUN,
            OSNOVNIOO,
            OBRACUNSKAOSNOVICA,
            DATUMOBRACUNASTAZA,
            OBRPOSTOTNIH,
            OBRFIKSNIH,
            OBRKREDITNIH,
            ZAKLJ,
            SVRHAOBRACUNA,
            IDENTIFIKATOROBRASCA
        }

        public class OrderAttribute
        {
            public bool OrderAttributeAscending;
            public PregledObracunaDataAdapter.Attribute OrderAttributeName;
            public string OrderAttributeString;

            public OrderAttribute(PregledObracunaDataAdapter.Attribute orderAttributeName)
            {
                this.OrderAttributeName = orderAttributeName;
                this.OrderAttributeAscending = true;
                this.OrderAttributeString = PregledObracunaDataAdapter.attributeNames[(int) this.OrderAttributeName];
            }

            public OrderAttribute(PregledObracunaDataAdapter.Attribute orderAttributeName, bool orderAttributeAscending)
            {
                this.OrderAttributeName = orderAttributeName;
                this.OrderAttributeAscending = orderAttributeAscending;
                this.OrderAttributeString = PregledObracunaDataAdapter.attributeNames[(int) this.OrderAttributeName];
            }
        }
    }
}


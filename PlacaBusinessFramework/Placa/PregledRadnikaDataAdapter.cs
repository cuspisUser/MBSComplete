namespace Placa
{
    using Deklarit.Data;
    using Deklarit.Utils;
    using Microsoft.VisualBasic;
    using System;
    using System.Collections;
    using System.Data;
    using System.Data.Common;
    using System.Globalization;
    using System.Reflection;
    using System.Resources;
    using System.Runtime.CompilerServices;
    using System.Threading;

    public class PregledRadnikaDataAdapter : IDataAdapter, IPregledRadnikaDataAdapter
    {
        private static string[] attributeNames = new string[] { "TM1.[IDRADNIK]", "TM1.[JMBG]", "TM1.[PREZIME]", "TM1.[IME]", "TM1.[AKTIVAN]", "TM1.[OPCINASTANOVANJAIDOPCINE]" };
        private ReadWriteCommand cmRADNIKSelect1;
        private ReadWriteCommand cmRADNIKSelect2;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        private DbParameter[] fillDataParameters;
        private string filterCondition;
        private string filterString;
        private string filterStringCond;
        private bool m__AKTIVANIsNull;
        private bool m__IDRADNIKIsNull;
        private bool m__IMEIsNull;
        private bool m__JMBGIsNull;
        private bool m__OPCINASTANOVANJAIDOPCINEIsNull;
        private bool m__PREZIMEIsNull;
        private bool m_AKTIVAN;
        private int m_IDRADNIK;
        private string m_IME;
        private string m_JMBG;
        private string m_OPCINASTANOVANJAIDOPCINE;
        private string m_PREZIME;
        private int m_RecordCount;
        private string m_SPOJENOPREZIME;
        private string m_WhereString;
        private ArrayList orderArray;
        private string orderString;
        private PregledRadnikaDataSet PregledRadnikaSet;
        private IDataReader RADNIKSelect1;
        private IDataReader RADNIKSelect2;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private string reverseOrderString;
        private PregledRadnikaDataSet.RADNIKRow rowRADNIK;
        private string scmdbuf;

        public PregledRadnikaDataAdapter()
        {
            this.Init_order_Radnik();
            this.orderString = GetOrderString(this.Order, true);
            this.reverseOrderString = GetOrderString(this.Order, false);
        }

        private void AddRowRadnik()
        {
            this.PregledRadnikaSet.RADNIK.AddRADNIKRow(this.rowRADNIK);
            this.rowRADNIK.AcceptChanges();
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
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  TM1.[IDRADNIK], TM1.[JMBG], TM1.[PREZIME], TM1.[IME], TM1.[AKTIVAN], TM1.[OPCINASTANOVANJAIDOPCINE]  FROM [RADNIK] TM1" + this.m_WhereString + "" + this.orderString + "";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  TM1.[IDRADNIK], TM1.[JMBG], TM1.[PREZIME], TM1.[IME], TM1.[AKTIVAN], TM1.[OPCINASTANOVANJAIDOPCINE], ROW_NUMBER() OVER  ( ", this.orderString, " ) AS DK_PAGENUM   FROM [RADNIK] TM1 ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT TM1.[IDRADNIK], TM1.[JMBG], TM1.[PREZIME], TM1.[IME], TM1.[AKTIVAN], TM1.[OPCINASTANOVANJAIDOPCINE] FROM [RADNIK] TM1" + this.m_WhereString + "" + this.orderString + " ";
            }
            this.cmRADNIKSelect2 = this.connDefault.GetCommand(this.scmdbuf, false);
            this.cmRADNIKSelect2.ErrorMask |= ErrorMask.Lock;
            this.RADNIKSelect2 = this.cmRADNIKSelect2.FetchData();
            int num = 0;
            while (this.cmRADNIKSelect2.HasMoreRows && (num != maxRows))
            {
                this.m_IDRADNIK = this.dsDefault.Db.GetInt32(this.RADNIKSelect2, 0, ref this.m__IDRADNIKIsNull);
                this.m_JMBG = this.dsDefault.Db.GetString(this.RADNIKSelect2, 1, ref this.m__JMBGIsNull);
                this.m_PREZIME = this.dsDefault.Db.GetString(this.RADNIKSelect2, 2, ref this.m__PREZIMEIsNull);
                this.m_IME = this.dsDefault.Db.GetString(this.RADNIKSelect2, 3, ref this.m__IMEIsNull);
                this.m_AKTIVAN = this.dsDefault.Db.GetBoolean(this.RADNIKSelect2, 4, ref this.m__AKTIVANIsNull);
                this.m_OPCINASTANOVANJAIDOPCINE = this.dsDefault.Db.GetString(this.RADNIKSelect2, 5, ref this.m__OPCINASTANOVANJAIDOPCINEIsNull);
                this.m_SPOJENOPREZIME = this.m_PREZIME + " " + this.m_IME;
                this.rowRADNIK = this.PregledRadnikaSet.RADNIK.NewRADNIKRow();
                this.rowRADNIK["IDRADNIK"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__IDRADNIKIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_IDRADNIK));
                this.rowRADNIK["JMBG"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__JMBGIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_JMBG));
                this.rowRADNIK["PREZIME"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__PREZIMEIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_PREZIME));
                this.rowRADNIK["IME"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__IMEIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_IME));
                this.rowRADNIK["AKTIVAN"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__AKTIVANIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_AKTIVAN));
                this.rowRADNIK["OPCINASTANOVANJAIDOPCINE"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__OPCINASTANOVANJAIDOPCINEIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_OPCINASTANOVANJAIDOPCINE));
                this.rowRADNIK.SPOJENOPREZIME = this.m_SPOJENOPREZIME;
                this.AddRowRadnik();
                num++;
                this.cmRADNIKSelect2.HasMoreRows = this.RADNIKSelect2.Read();
            }
            this.RADNIKSelect2.Close();
            this.Cleanup();
        }

        public virtual int Fill(PregledRadnikaDataSet dataSet)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.PregledRadnikaSet = dataSet;
            this.rowRADNIK = this.PregledRadnikaSet.RADNIK.NewRADNIKRow();
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
            this.PregledRadnikaSet = (PregledRadnikaDataSet) dataSet;
            if (this.PregledRadnikaSet != null)
            {
                return this.Fill(this.PregledRadnikaSet);
            }
            this.PregledRadnikaSet = new PregledRadnikaDataSet();
            this.Fill(this.PregledRadnikaSet);
            dataSet.Merge(this.PregledRadnikaSet);
            return 0;
        }

        public virtual int FillPage(PregledRadnikaDataSet dataSet, int startRow, int maxRows)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.PregledRadnikaSet = dataSet;
            this.rowRADNIK = this.PregledRadnikaSet.RADNIK.NewRADNIKRow();
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
            this.PregledRadnikaSet = (PregledRadnikaDataSet) dataSet;
            if (this.PregledRadnikaSet != null)
            {
                return this.FillPage(this.PregledRadnikaSet, startRow, maxRows);
            }
            this.PregledRadnikaSet = new PregledRadnikaDataSet();
            this.FillPage(this.PregledRadnikaSet, startRow, maxRows);
            dataSet.Merge(this.PregledRadnikaSet);
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
            this.scmdbuf = "SELECT COUNT(*) FROM [RADNIK]" + str + "  ";
            this.cmRADNIKSelect1 = this.connDefault.GetCommand(this.scmdbuf, false);
            this.cmRADNIKSelect1.ErrorMask |= ErrorMask.Lock;
            this.RADNIKSelect1 = this.cmRADNIKSelect1.FetchData();
            if (this.RADNIKSelect1.IsDBNull(0))
            {
                this.m_RecordCount = 0;
            }
            else
            {
                this.m_RecordCount = this.RADNIKSelect1.GetInt32(0);
            }
            this.RADNIKSelect1.Close();
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

        private void Init_order_Radnik()
        {
            this.Order = new ArrayList();
            this.Order.Add(new OrderAttribute(Attribute.PREZIME, true));
            this.Order.Add(new OrderAttribute(Attribute.IME, true));
        }

        private void Initialize()
        {
            this.resourceManager = Deklarit.Utils.ResourceManager.Instance;
            this.resourceManagerTables = new System.Resources.ResourceManager("Tables", Assembly.GetExecutingAssembly());
            this.scmdbuf = "";
            this.m_WhereString = "";
            this.m_RecordCount = 0;
            this.m__IDRADNIKIsNull = false;
            this.m_IDRADNIK = 0;
            this.m__JMBGIsNull = false;
            this.m_JMBG = "";
            this.m__PREZIMEIsNull = false;
            this.m_PREZIME = "";
            this.m__IMEIsNull = false;
            this.m_IME = "";
            this.m__AKTIVANIsNull = false;
            this.m_AKTIVAN = false;
            this.m__OPCINASTANOVANJAIDOPCINEIsNull = false;
            this.m_OPCINASTANOVANJAIDOPCINE = "";
            this.m_SPOJENOPREZIME = "";
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

        string Placa.IPregledRadnikaDataAdapter.Filter
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
            IDRADNIK,
            JMBG,
            PREZIME,
            IME,
            AKTIVAN,
            OPCINASTANOVANJAIDOPCINE
        }

        public class OrderAttribute
        {
            public bool OrderAttributeAscending;
            public PregledRadnikaDataAdapter.Attribute OrderAttributeName;
            public string OrderAttributeString;

            public OrderAttribute(PregledRadnikaDataAdapter.Attribute orderAttributeName)
            {
                this.OrderAttributeName = orderAttributeName;
                this.OrderAttributeAscending = true;
                this.OrderAttributeString = PregledRadnikaDataAdapter.attributeNames[(int) this.OrderAttributeName];
            }

            public OrderAttribute(PregledRadnikaDataAdapter.Attribute orderAttributeName, bool orderAttributeAscending)
            {
                this.OrderAttributeName = orderAttributeName;
                this.OrderAttributeAscending = orderAttributeAscending;
                this.OrderAttributeString = PregledRadnikaDataAdapter.attributeNames[(int) this.OrderAttributeName];
            }
        }
    }
}


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

    public class V_DD_PREGLED_OBRACUNADataAdapter : IDataAdapter, IV_DD_PREGLED_OBRACUNADataAdapter
    {
        private static string[] attributeNames = new string[] { "TM1.[DDOBRACUNIDOBRACUN]", "TM1.[DDOPISOBRACUN]", "TM1.[DDDATUMOBRACUNA]", "TM1.[DDZAKLJUCAN]", "TM1.[DDRSM]" };
        private ReadWriteCommand cmV_DD_PREGLED_OBRACUNASelect1;
        private ReadWriteCommand cmV_DD_PREGLED_OBRACUNASelect2;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        private DbParameter[] fillDataParameters;
        private string filterCondition;
        private string filterString;
        private string filterStringCond;
        private bool m__DDDATUMOBRACUNAIsNull;
        private bool m__DDOBRACUNIDOBRACUNIsNull;
        private bool m__DDOPISOBRACUNIsNull;
        private bool m__DDRSMIsNull;
        private bool m__DDZAKLJUCANIsNull;
        private DateTime m_DDDATUMOBRACUNA;
        private string m_DDOBRACUNIDOBRACUN;
        private string m_DDOPISOBRACUN;
        private string m_DDRSM;
        private bool m_DDZAKLJUCAN;
        private int m_RecordCount;
        private string m_WhereString;
        private ArrayList orderArray;
        private string orderString;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private string reverseOrderString;
        private V_DD_PREGLED_OBRACUNADataSet.V_DD_PREGLED_OBRACUNARow rowV_DD_PREGLED_OBRACUNA;
        private string scmdbuf;
        private IDataReader V_DD_PREGLED_OBRACUNASelect1;
        private IDataReader V_DD_PREGLED_OBRACUNASelect2;
        private V_DD_PREGLED_OBRACUNADataSet V_DD_PREGLED_OBRACUNASet;

        public V_DD_PREGLED_OBRACUNADataAdapter()
        {
            this.Init_order_V_dd_pregled_obracuna();
            this.orderString = GetOrderString(this.Order, true);
            this.reverseOrderString = GetOrderString(this.Order, false);
        }

        private void AddRowV_dd_pregled_obracuna()
        {
            this.V_DD_PREGLED_OBRACUNASet.V_DD_PREGLED_OBRACUNA.AddV_DD_PREGLED_OBRACUNARow(this.rowV_DD_PREGLED_OBRACUNA);
            this.rowV_DD_PREGLED_OBRACUNA.AcceptChanges();
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
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  TM1.[DDOBRACUNIDOBRACUN], TM1.[DDOPISOBRACUN], TM1.[DDDATUMOBRACUNA], TM1.[DDZAKLJUCAN], TM1.[DDRSM]  FROM [VW_DD_PREGLED_OBRACUNA] TM1" + this.m_WhereString + "" + this.orderString + "";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  TM1.[DDOBRACUNIDOBRACUN], TM1.[DDOPISOBRACUN], TM1.[DDDATUMOBRACUNA], TM1.[DDZAKLJUCAN], TM1.[DDRSM], ROW_NUMBER() OVER  ( ", this.orderString, " ) AS DK_PAGENUM   FROM [VW_DD_PREGLED_OBRACUNA] TM1 ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT TM1.[DDOBRACUNIDOBRACUN], TM1.[DDOPISOBRACUN], TM1.[DDDATUMOBRACUNA], TM1.[DDZAKLJUCAN], TM1.[DDRSM] FROM [VW_DD_PREGLED_OBRACUNA] TM1" + this.m_WhereString + "" + this.orderString + " ";
            }
            this.cmV_DD_PREGLED_OBRACUNASelect2 = this.connDefault.GetCommand(this.scmdbuf, true);
            this.cmV_DD_PREGLED_OBRACUNASelect2.ErrorMask |= ErrorMask.Lock;
            this.V_DD_PREGLED_OBRACUNASelect2 = this.cmV_DD_PREGLED_OBRACUNASelect2.FetchData();
            int num = 0;
            while (this.cmV_DD_PREGLED_OBRACUNASelect2.HasMoreRows && (num != maxRows))
            {
                this.m_DDOBRACUNIDOBRACUN = this.dsDefault.Db.GetString(this.V_DD_PREGLED_OBRACUNASelect2, 0, ref this.m__DDOBRACUNIDOBRACUNIsNull);
                this.m_DDOPISOBRACUN = this.dsDefault.Db.GetString(this.V_DD_PREGLED_OBRACUNASelect2, 1, ref this.m__DDOPISOBRACUNIsNull);
                this.m_DDDATUMOBRACUNA = this.dsDefault.Db.GetDateTime(this.V_DD_PREGLED_OBRACUNASelect2, 2, ref this.m__DDDATUMOBRACUNAIsNull);
                this.m_DDZAKLJUCAN = this.dsDefault.Db.GetBoolean(this.V_DD_PREGLED_OBRACUNASelect2, 3, ref this.m__DDZAKLJUCANIsNull);
                this.m_DDRSM = this.dsDefault.Db.GetString(this.V_DD_PREGLED_OBRACUNASelect2, 4, ref this.m__DDRSMIsNull);
                this.rowV_DD_PREGLED_OBRACUNA = this.V_DD_PREGLED_OBRACUNASet.V_DD_PREGLED_OBRACUNA.NewV_DD_PREGLED_OBRACUNARow();
                this.rowV_DD_PREGLED_OBRACUNA["DDOBRACUNIDOBRACUN"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__DDOBRACUNIDOBRACUNIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_DDOBRACUNIDOBRACUN));
                this.rowV_DD_PREGLED_OBRACUNA["DDOPISOBRACUN"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__DDOPISOBRACUNIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_DDOPISOBRACUN));
                this.rowV_DD_PREGLED_OBRACUNA["DDDATUMOBRACUNA"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__DDDATUMOBRACUNAIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_DDDATUMOBRACUNA));
                this.rowV_DD_PREGLED_OBRACUNA["DDZAKLJUCAN"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__DDZAKLJUCANIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_DDZAKLJUCAN));
                this.rowV_DD_PREGLED_OBRACUNA["DDRSM"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__DDRSMIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_DDRSM));
                this.AddRowV_dd_pregled_obracuna();
                num++;
                this.cmV_DD_PREGLED_OBRACUNASelect2.HasMoreRows = this.V_DD_PREGLED_OBRACUNASelect2.Read();
            }
            this.V_DD_PREGLED_OBRACUNASelect2.Close();
            this.Cleanup();
        }

        public virtual int Fill(V_DD_PREGLED_OBRACUNADataSet dataSet)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.V_DD_PREGLED_OBRACUNASet = dataSet;
            this.rowV_DD_PREGLED_OBRACUNA = this.V_DD_PREGLED_OBRACUNASet.V_DD_PREGLED_OBRACUNA.NewV_DD_PREGLED_OBRACUNARow();
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
            this.V_DD_PREGLED_OBRACUNASet = (V_DD_PREGLED_OBRACUNADataSet) dataSet;
            if (this.V_DD_PREGLED_OBRACUNASet != null)
            {
                return this.Fill(this.V_DD_PREGLED_OBRACUNASet);
            }
            this.V_DD_PREGLED_OBRACUNASet = new V_DD_PREGLED_OBRACUNADataSet();
            this.Fill(this.V_DD_PREGLED_OBRACUNASet);
            dataSet.Merge(this.V_DD_PREGLED_OBRACUNASet);
            return 0;
        }

        public virtual int FillPage(V_DD_PREGLED_OBRACUNADataSet dataSet, int startRow, int maxRows)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.V_DD_PREGLED_OBRACUNASet = dataSet;
            this.rowV_DD_PREGLED_OBRACUNA = this.V_DD_PREGLED_OBRACUNASet.V_DD_PREGLED_OBRACUNA.NewV_DD_PREGLED_OBRACUNARow();
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
            this.V_DD_PREGLED_OBRACUNASet = (V_DD_PREGLED_OBRACUNADataSet) dataSet;
            if (this.V_DD_PREGLED_OBRACUNASet != null)
            {
                return this.FillPage(this.V_DD_PREGLED_OBRACUNASet, startRow, maxRows);
            }
            this.V_DD_PREGLED_OBRACUNASet = new V_DD_PREGLED_OBRACUNADataSet();
            this.FillPage(this.V_DD_PREGLED_OBRACUNASet, startRow, maxRows);
            dataSet.Merge(this.V_DD_PREGLED_OBRACUNASet);
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
            this.scmdbuf = "SELECT COUNT(*) FROM [VW_DD_PREGLED_OBRACUNA]" + str + "  ";
            this.cmV_DD_PREGLED_OBRACUNASelect1 = this.connDefault.GetCommand(this.scmdbuf, true);
            this.cmV_DD_PREGLED_OBRACUNASelect1.ErrorMask |= ErrorMask.Lock;
            this.V_DD_PREGLED_OBRACUNASelect1 = this.cmV_DD_PREGLED_OBRACUNASelect1.FetchData();
            if (this.V_DD_PREGLED_OBRACUNASelect1.IsDBNull(0))
            {
                this.m_RecordCount = 0;
            }
            else
            {
                this.m_RecordCount = this.V_DD_PREGLED_OBRACUNASelect1.GetInt32(0);
            }
            this.V_DD_PREGLED_OBRACUNASelect1.Close();
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

        private void Init_order_V_dd_pregled_obracuna()
        {
            this.Order = new ArrayList();
            this.Order.Add(new OrderAttribute(Attribute.DDOBRACUNIDOBRACUN, false));
        }

        private void Initialize()
        {
            this.resourceManager = Deklarit.Utils.ResourceManager.Instance;
            this.resourceManagerTables = new System.Resources.ResourceManager("Tables", Assembly.GetExecutingAssembly());
            this.scmdbuf = "";
            this.m_WhereString = "";
            this.m_RecordCount = 0;
            this.m__DDOBRACUNIDOBRACUNIsNull = false;
            this.m_DDOBRACUNIDOBRACUN = "";
            this.m__DDOPISOBRACUNIsNull = false;
            this.m_DDOPISOBRACUN = "";
            this.m__DDDATUMOBRACUNAIsNull = false;
            this.m_DDDATUMOBRACUNA = DateTime.MinValue;
            this.m__DDZAKLJUCANIsNull = false;
            this.m_DDZAKLJUCAN = false;
            this.m__DDRSMIsNull = false;
            this.m_DDRSM = "";
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

        string Placa.IV_DD_PREGLED_OBRACUNADataAdapter.Filter
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
            DDOBRACUNIDOBRACUN,
            DDOPISOBRACUN,
            DDDATUMOBRACUNA,
            DDZAKLJUCAN,
            DDRSM
        }

        public class OrderAttribute
        {
            public bool OrderAttributeAscending;
            public V_DD_PREGLED_OBRACUNADataAdapter.Attribute OrderAttributeName;
            public string OrderAttributeString;

            public OrderAttribute(V_DD_PREGLED_OBRACUNADataAdapter.Attribute orderAttributeName)
            {
                this.OrderAttributeName = orderAttributeName;
                this.OrderAttributeAscending = true;
                this.OrderAttributeString = V_DD_PREGLED_OBRACUNADataAdapter.attributeNames[(int) this.OrderAttributeName];
            }

            public OrderAttribute(V_DD_PREGLED_OBRACUNADataAdapter.Attribute orderAttributeName, bool orderAttributeAscending)
            {
                this.OrderAttributeName = orderAttributeName;
                this.OrderAttributeAscending = orderAttributeAscending;
                this.OrderAttributeString = V_DD_PREGLED_OBRACUNADataAdapter.attributeNames[(int) this.OrderAttributeName];
            }
        }
    }
}


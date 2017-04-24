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

    public class V_DD_GODINE_ISPLATEDataAdapter : IDataAdapter, IV_DD_GODINE_ISPLATEDataAdapter
    {
        private static string[] attributeNames = new string[] { "[GODINAISPLATE]" };
        private ReadWriteCommand cmV_DD_GODINE_ISPLATESelect1;
        private ReadWriteCommand cmV_DD_GODINE_ISPLATESelect2;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        private DbParameter[] fillDataParameters;
        private string filterCondition;
        private string filterString;
        private string filterStringCond;
        private bool m__GODINAISPLATEIsNull;
        private string m_GODINAISPLATE;
        private int m_RecordCount;
        private string m_WhereString;
        private ArrayList orderArray;
        private string orderString;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private string reverseOrderString;
        private V_DD_GODINE_ISPLATEDataSet.V_DD_GODINE_ISPLATERow rowV_DD_GODINE_ISPLATE;
        private string scmdbuf;
        private IDataReader V_DD_GODINE_ISPLATESelect1;
        private IDataReader V_DD_GODINE_ISPLATESelect2;
        private V_DD_GODINE_ISPLATEDataSet V_DD_GODINE_ISPLATESet;

        public V_DD_GODINE_ISPLATEDataAdapter()
        {
            this.Init_order_V_dd_godine_isplate();
            this.orderString = GetOrderString(this.Order, true);
            this.reverseOrderString = GetOrderString(this.Order, false);
        }

        private void AddRowV_dd_godine_isplate()
        {
            this.V_DD_GODINE_ISPLATESet.V_DD_GODINE_ISPLATE.AddV_DD_GODINE_ISPLATERow(this.rowV_DD_GODINE_ISPLATE);
            this.rowV_DD_GODINE_ISPLATE.AcceptChanges();
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
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  [GODINAISPLATE] FROM [VW_DD_GODINE_ISPLATE]" + this.m_WhereString + "" + this.orderString + "";
                }
                else
                {
                    string[] strArray = new string[] { "SELECT TOP ", (startRow + maxRows).ToString(), "  [GODINAISPLATE] FROM [VW_DD_GODINE_ISPLATE]", this.m_WhereString, "", this.orderString, "" };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT [GODINAISPLATE] FROM [VW_DD_GODINE_ISPLATE]" + this.m_WhereString + "" + this.orderString + " ";
            }
            this.cmV_DD_GODINE_ISPLATESelect2 = this.connDefault.GetCommand(this.scmdbuf, true);
            this.cmV_DD_GODINE_ISPLATESelect2.ErrorMask |= ErrorMask.Lock;
            this.V_DD_GODINE_ISPLATESelect2 = this.cmV_DD_GODINE_ISPLATESelect2.FetchData();
            while (this.cmV_DD_GODINE_ISPLATESelect2.HasMoreRows && (startRow > 0))
            {
                startRow--;
                this.cmV_DD_GODINE_ISPLATESelect2.HasMoreRows = this.V_DD_GODINE_ISPLATESelect2.Read();
            }
            int num = 0;
            while (this.cmV_DD_GODINE_ISPLATESelect2.HasMoreRows && (num != maxRows))
            {
                this.m_GODINAISPLATE = this.dsDefault.Db.GetString(this.V_DD_GODINE_ISPLATESelect2, 0, ref this.m__GODINAISPLATEIsNull);
                this.rowV_DD_GODINE_ISPLATE = this.V_DD_GODINE_ISPLATESet.V_DD_GODINE_ISPLATE.NewV_DD_GODINE_ISPLATERow();
                this.rowV_DD_GODINE_ISPLATE["GODINAISPLATE"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__GODINAISPLATEIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_GODINAISPLATE));
                this.AddRowV_dd_godine_isplate();
                num++;
                this.cmV_DD_GODINE_ISPLATESelect2.HasMoreRows = this.V_DD_GODINE_ISPLATESelect2.Read();
            }
            this.V_DD_GODINE_ISPLATESelect2.Close();
            this.Cleanup();
        }

        public virtual int Fill(V_DD_GODINE_ISPLATEDataSet dataSet)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.V_DD_GODINE_ISPLATESet = dataSet;
            this.rowV_DD_GODINE_ISPLATE = this.V_DD_GODINE_ISPLATESet.V_DD_GODINE_ISPLATE.NewV_DD_GODINE_ISPLATERow();
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
            this.V_DD_GODINE_ISPLATESet = (V_DD_GODINE_ISPLATEDataSet) dataSet;
            if (this.V_DD_GODINE_ISPLATESet != null)
            {
                return this.Fill(this.V_DD_GODINE_ISPLATESet);
            }
            this.V_DD_GODINE_ISPLATESet = new V_DD_GODINE_ISPLATEDataSet();
            this.Fill(this.V_DD_GODINE_ISPLATESet);
            dataSet.Merge(this.V_DD_GODINE_ISPLATESet);
            return 0;
        }

        public virtual int FillPage(V_DD_GODINE_ISPLATEDataSet dataSet, int startRow, int maxRows)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.V_DD_GODINE_ISPLATESet = dataSet;
            this.rowV_DD_GODINE_ISPLATE = this.V_DD_GODINE_ISPLATESet.V_DD_GODINE_ISPLATE.NewV_DD_GODINE_ISPLATERow();
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
            this.V_DD_GODINE_ISPLATESet = (V_DD_GODINE_ISPLATEDataSet) dataSet;
            if (this.V_DD_GODINE_ISPLATESet != null)
            {
                return this.FillPage(this.V_DD_GODINE_ISPLATESet, startRow, maxRows);
            }
            this.V_DD_GODINE_ISPLATESet = new V_DD_GODINE_ISPLATEDataSet();
            this.FillPage(this.V_DD_GODINE_ISPLATESet, startRow, maxRows);
            dataSet.Merge(this.V_DD_GODINE_ISPLATESet);
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
            this.scmdbuf = "SELECT COUNT(*) FROM [VW_DD_GODINE_ISPLATE]" + str + "  ";
            this.cmV_DD_GODINE_ISPLATESelect1 = this.connDefault.GetCommand(this.scmdbuf, true);
            this.cmV_DD_GODINE_ISPLATESelect1.ErrorMask |= ErrorMask.Lock;
            this.V_DD_GODINE_ISPLATESelect1 = this.cmV_DD_GODINE_ISPLATESelect1.FetchData();
            if (this.V_DD_GODINE_ISPLATESelect1.IsDBNull(0))
            {
                this.m_RecordCount = 0;
            }
            else
            {
                this.m_RecordCount = this.V_DD_GODINE_ISPLATESelect1.GetInt32(0);
            }
            this.V_DD_GODINE_ISPLATESelect1.Close();
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

        private void Init_order_V_dd_godine_isplate()
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
            this.m__GODINAISPLATEIsNull = false;
            this.m_GODINAISPLATE = "";
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

        string Placa.IV_DD_GODINE_ISPLATEDataAdapter.Filter
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
            GODINAISPLATE
        }

        public class OrderAttribute
        {
            public bool OrderAttributeAscending;
            public V_DD_GODINE_ISPLATEDataAdapter.Attribute OrderAttributeName;
            public string OrderAttributeString;

            public OrderAttribute(V_DD_GODINE_ISPLATEDataAdapter.Attribute orderAttributeName)
            {
                this.OrderAttributeName = orderAttributeName;
                this.OrderAttributeAscending = true;
                this.OrderAttributeString = V_DD_GODINE_ISPLATEDataAdapter.attributeNames[(int) this.OrderAttributeName];
            }

            public OrderAttribute(V_DD_GODINE_ISPLATEDataAdapter.Attribute orderAttributeName, bool orderAttributeAscending)
            {
                this.OrderAttributeName = orderAttributeName;
                this.OrderAttributeAscending = orderAttributeAscending;
                this.OrderAttributeString = V_DD_GODINE_ISPLATEDataAdapter.attributeNames[(int) this.OrderAttributeName];
            }
        }
    }
}


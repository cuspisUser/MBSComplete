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

    public class vw_mjeseci_godine_isplateDataAdapter : IDataAdapter, Ivw_mjeseci_godine_isplateDataAdapter
    {
        private static string[] attributeNames = new string[] { "TM1.[mjesecisplate]", "TM1.[godinaisplate]" };
        private ReadWriteCommand cmvw_mjeseci_godine_isplateSelect1;
        private ReadWriteCommand cmvw_mjeseci_godine_isplateSelect2;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        private DbParameter[] fillDataParameters;
        private string filterCondition;
        private string filterString;
        private string filterStringCond;
        private bool m__GODINAISPLATEIsNull;
        private bool m__MJESECISPLATEIsNull;
        private string m_GODINAISPLATE;
        private string m_MJESECISPLATE;
        private int m_RecordCount;
        private string m_WhereString;
        private ArrayList orderArray;
        private string orderString;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private string reverseOrderString;
        private vw_mjeseci_godine_isplateDataSet.vw_mjeseci_godine_isplateRow rowvw_mjeseci_godine_isplate;
        private string scmdbuf;
        private IDataReader vw_mjeseci_godine_isplateSelect1;
        private IDataReader vw_mjeseci_godine_isplateSelect2;
        private vw_mjeseci_godine_isplateDataSet vw_mjeseci_godine_isplateSet;

        public vw_mjeseci_godine_isplateDataAdapter()
        {
            this.Init_order_Vw_mjeseci_godine_isplate();
            this.orderString = GetOrderString(this.Order, true);
            this.reverseOrderString = GetOrderString(this.Order, false);
        }

        private void AddRowVw_mjeseci_godine_isplate()
        {
            this.vw_mjeseci_godine_isplateSet.vw_mjeseci_godine_isplate.Addvw_mjeseci_godine_isplateRow(this.rowvw_mjeseci_godine_isplate);
            this.rowvw_mjeseci_godine_isplate.AcceptChanges();
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
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  TM1.[mjesecisplate], TM1.[godinaisplate]  FROM [VW_PLACA_DD_MJESECI_GODINE_ISPLATE] TM1" + this.m_WhereString + "" + this.orderString + "";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  TM1.[mjesecisplate], TM1.[godinaisplate], ROW_NUMBER() OVER  ( ", this.orderString, " ) AS DK_PAGENUM   FROM [VW_PLACA_DD_MJESECI_GODINE_ISPLATE] TM1 ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT TM1.[mjesecisplate], TM1.[godinaisplate] FROM [VW_PLACA_DD_MJESECI_GODINE_ISPLATE] TM1" + this.m_WhereString + "" + this.orderString + " ";
            }
            this.cmvw_mjeseci_godine_isplateSelect2 = this.connDefault.GetCommand(this.scmdbuf, true);
            this.cmvw_mjeseci_godine_isplateSelect2.ErrorMask |= ErrorMask.Lock;
            this.vw_mjeseci_godine_isplateSelect2 = this.cmvw_mjeseci_godine_isplateSelect2.FetchData();
            int num = 0;
            while (this.cmvw_mjeseci_godine_isplateSelect2.HasMoreRows && (num != maxRows))
            {
                this.m_MJESECISPLATE = this.dsDefault.Db.GetString(this.vw_mjeseci_godine_isplateSelect2, 0, ref this.m__MJESECISPLATEIsNull);
                this.m_GODINAISPLATE = this.dsDefault.Db.GetString(this.vw_mjeseci_godine_isplateSelect2, 1, ref this.m__GODINAISPLATEIsNull);
                this.rowvw_mjeseci_godine_isplate = this.vw_mjeseci_godine_isplateSet.vw_mjeseci_godine_isplate.Newvw_mjeseci_godine_isplateRow();
                this.rowvw_mjeseci_godine_isplate["MJESECISPLATE"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__MJESECISPLATEIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_MJESECISPLATE));
                this.rowvw_mjeseci_godine_isplate["GODINAISPLATE"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__GODINAISPLATEIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_GODINAISPLATE));
                this.AddRowVw_mjeseci_godine_isplate();
                num++;
                this.cmvw_mjeseci_godine_isplateSelect2.HasMoreRows = this.vw_mjeseci_godine_isplateSelect2.Read();
            }
            this.vw_mjeseci_godine_isplateSelect2.Close();
            this.Cleanup();
        }

        public virtual int Fill(vw_mjeseci_godine_isplateDataSet dataSet)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.vw_mjeseci_godine_isplateSet = dataSet;
            this.rowvw_mjeseci_godine_isplate = this.vw_mjeseci_godine_isplateSet.vw_mjeseci_godine_isplate.Newvw_mjeseci_godine_isplateRow();
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
            this.vw_mjeseci_godine_isplateSet = (vw_mjeseci_godine_isplateDataSet) dataSet;
            if (this.vw_mjeseci_godine_isplateSet != null)
            {
                return this.Fill(this.vw_mjeseci_godine_isplateSet);
            }
            this.vw_mjeseci_godine_isplateSet = new vw_mjeseci_godine_isplateDataSet();
            this.Fill(this.vw_mjeseci_godine_isplateSet);
            dataSet.Merge(this.vw_mjeseci_godine_isplateSet);
            return 0;
        }

        public virtual int FillPage(vw_mjeseci_godine_isplateDataSet dataSet, int startRow, int maxRows)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.vw_mjeseci_godine_isplateSet = dataSet;
            this.rowvw_mjeseci_godine_isplate = this.vw_mjeseci_godine_isplateSet.vw_mjeseci_godine_isplate.Newvw_mjeseci_godine_isplateRow();
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
            this.vw_mjeseci_godine_isplateSet = (vw_mjeseci_godine_isplateDataSet) dataSet;
            if (this.vw_mjeseci_godine_isplateSet != null)
            {
                return this.FillPage(this.vw_mjeseci_godine_isplateSet, startRow, maxRows);
            }
            this.vw_mjeseci_godine_isplateSet = new vw_mjeseci_godine_isplateDataSet();
            this.FillPage(this.vw_mjeseci_godine_isplateSet, startRow, maxRows);
            dataSet.Merge(this.vw_mjeseci_godine_isplateSet);
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
            this.scmdbuf = "SELECT COUNT(*) FROM [VW_PLACA_DD_MJESECI_GODINE_ISPLATE]" + str + "  ";
            this.cmvw_mjeseci_godine_isplateSelect1 = this.connDefault.GetCommand(this.scmdbuf, true);
            this.cmvw_mjeseci_godine_isplateSelect1.ErrorMask |= ErrorMask.Lock;
            this.vw_mjeseci_godine_isplateSelect1 = this.cmvw_mjeseci_godine_isplateSelect1.FetchData();
            if (this.vw_mjeseci_godine_isplateSelect1.IsDBNull(0))
            {
                this.m_RecordCount = 0;
            }
            else
            {
                this.m_RecordCount = this.vw_mjeseci_godine_isplateSelect1.GetInt32(0);
            }
            this.vw_mjeseci_godine_isplateSelect1.Close();
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

        private void Init_order_Vw_mjeseci_godine_isplate()
        {
            this.Order = new ArrayList();
            this.Order.Add(new OrderAttribute(Attribute.GODINAISPLATE, false));
            this.Order.Add(new OrderAttribute(Attribute.MJESECISPLATE, false));
        }

        private void Initialize()
        {
            this.resourceManager = Deklarit.Utils.ResourceManager.Instance;
            this.resourceManagerTables = new System.Resources.ResourceManager("Tables", Assembly.GetExecutingAssembly());
            this.scmdbuf = "";
            this.m_WhereString = "";
            this.m_RecordCount = 0;
            this.m__MJESECISPLATEIsNull = false;
            this.m_MJESECISPLATE = "";
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

        string Placa.Ivw_mjeseci_godine_isplateDataAdapter.Filter
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
            MJESECISPLATE,
            GODINAISPLATE
        }

        public class OrderAttribute
        {
            public bool OrderAttributeAscending;
            public vw_mjeseci_godine_isplateDataAdapter.Attribute OrderAttributeName;
            public string OrderAttributeString;

            public OrderAttribute(vw_mjeseci_godine_isplateDataAdapter.Attribute orderAttributeName)
            {
                this.OrderAttributeName = orderAttributeName;
                this.OrderAttributeAscending = true;
                this.OrderAttributeString = vw_mjeseci_godine_isplateDataAdapter.attributeNames[(int) this.OrderAttributeName];
            }

            public OrderAttribute(vw_mjeseci_godine_isplateDataAdapter.Attribute orderAttributeName, bool orderAttributeAscending)
            {
                this.OrderAttributeName = orderAttributeName;
                this.OrderAttributeAscending = orderAttributeAscending;
                this.OrderAttributeString = vw_mjeseci_godine_isplateDataAdapter.attributeNames[(int) this.OrderAttributeName];
            }
        }
    }
}


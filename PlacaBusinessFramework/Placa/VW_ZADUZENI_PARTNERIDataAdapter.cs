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

    public class VW_ZADUZENI_PARTNERIDataAdapter : IDataAdapter, IVW_ZADUZENI_PARTNERIDataAdapter
    {
        private static string[] attributeNames = new string[] { "[IDPARTNER]" };
        private ReadWriteCommand cmVW_ZADUZENI_PARTNERISelect1;
        private ReadWriteCommand cmVW_ZADUZENI_PARTNERISelect2;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        private DbParameter[] fillDataParameters;
        private string filterCondition;
        private string filterString;
        private string filterStringCond;
        private bool m__IDPARTNERIsNull;
        private int m_IDPARTNER;
        private int m_RecordCount;
        private string m_WhereString;
        private ArrayList orderArray;
        private string orderString;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private string reverseOrderString;
        private VW_ZADUZENI_PARTNERIDataSet.VW_ZADUZENI_PARTNERIRow rowVW_ZADUZENI_PARTNERI;
        private string scmdbuf;
        private IDataReader VW_ZADUZENI_PARTNERISelect1;
        private IDataReader VW_ZADUZENI_PARTNERISelect2;
        private VW_ZADUZENI_PARTNERIDataSet VW_ZADUZENI_PARTNERISet;

        public VW_ZADUZENI_PARTNERIDataAdapter()
        {
            this.Init_order_Vw_zaduzeni_partneri();
            this.orderString = GetOrderString(this.Order, true);
            this.reverseOrderString = GetOrderString(this.Order, false);
        }

        private void AddRowVw_zaduzeni_partneri()
        {
            this.VW_ZADUZENI_PARTNERISet.VW_ZADUZENI_PARTNERI.AddVW_ZADUZENI_PARTNERIRow(this.rowVW_ZADUZENI_PARTNERI);
            this.rowVW_ZADUZENI_PARTNERI.AcceptChanges();
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
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  [IDPARTNER] FROM [VW_ZADUZENI_PARTNERI]" + this.m_WhereString + "" + this.orderString + "";
                }
                else
                {
                    string[] strArray = new string[] { "SELECT TOP ", (startRow + maxRows).ToString(), "  [IDPARTNER] FROM [VW_ZADUZENI_PARTNERI]", this.m_WhereString, "", this.orderString, "" };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT [IDPARTNER] FROM [VW_ZADUZENI_PARTNERI]" + this.m_WhereString + "" + this.orderString + " ";
            }
            this.cmVW_ZADUZENI_PARTNERISelect2 = this.connDefault.GetCommand(this.scmdbuf, true);
            this.cmVW_ZADUZENI_PARTNERISelect2.ErrorMask |= ErrorMask.Lock;
            this.VW_ZADUZENI_PARTNERISelect2 = this.cmVW_ZADUZENI_PARTNERISelect2.FetchData();
            while (this.cmVW_ZADUZENI_PARTNERISelect2.HasMoreRows && (startRow > 0))
            {
                startRow--;
                this.cmVW_ZADUZENI_PARTNERISelect2.HasMoreRows = this.VW_ZADUZENI_PARTNERISelect2.Read();
            }
            int num = 0;
            while (this.cmVW_ZADUZENI_PARTNERISelect2.HasMoreRows && (num != maxRows))
            {
                this.m_IDPARTNER = this.dsDefault.Db.GetInt32(this.VW_ZADUZENI_PARTNERISelect2, 0, ref this.m__IDPARTNERIsNull);
                this.rowVW_ZADUZENI_PARTNERI = this.VW_ZADUZENI_PARTNERISet.VW_ZADUZENI_PARTNERI.NewVW_ZADUZENI_PARTNERIRow();
                this.rowVW_ZADUZENI_PARTNERI["IDPARTNER"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__IDPARTNERIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_IDPARTNER));
                this.AddRowVw_zaduzeni_partneri();
                num++;
                this.cmVW_ZADUZENI_PARTNERISelect2.HasMoreRows = this.VW_ZADUZENI_PARTNERISelect2.Read();
            }
            this.VW_ZADUZENI_PARTNERISelect2.Close();
            this.Cleanup();
        }

        public virtual int Fill(VW_ZADUZENI_PARTNERIDataSet dataSet)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.VW_ZADUZENI_PARTNERISet = dataSet;
            this.rowVW_ZADUZENI_PARTNERI = this.VW_ZADUZENI_PARTNERISet.VW_ZADUZENI_PARTNERI.NewVW_ZADUZENI_PARTNERIRow();
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
            this.VW_ZADUZENI_PARTNERISet = (VW_ZADUZENI_PARTNERIDataSet) dataSet;
            if (this.VW_ZADUZENI_PARTNERISet != null)
            {
                return this.Fill(this.VW_ZADUZENI_PARTNERISet);
            }
            this.VW_ZADUZENI_PARTNERISet = new VW_ZADUZENI_PARTNERIDataSet();
            this.Fill(this.VW_ZADUZENI_PARTNERISet);
            dataSet.Merge(this.VW_ZADUZENI_PARTNERISet);
            return 0;
        }

        public virtual int FillPage(VW_ZADUZENI_PARTNERIDataSet dataSet, int startRow, int maxRows)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.VW_ZADUZENI_PARTNERISet = dataSet;
            this.rowVW_ZADUZENI_PARTNERI = this.VW_ZADUZENI_PARTNERISet.VW_ZADUZENI_PARTNERI.NewVW_ZADUZENI_PARTNERIRow();
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
            this.VW_ZADUZENI_PARTNERISet = (VW_ZADUZENI_PARTNERIDataSet) dataSet;
            if (this.VW_ZADUZENI_PARTNERISet != null)
            {
                return this.FillPage(this.VW_ZADUZENI_PARTNERISet, startRow, maxRows);
            }
            this.VW_ZADUZENI_PARTNERISet = new VW_ZADUZENI_PARTNERIDataSet();
            this.FillPage(this.VW_ZADUZENI_PARTNERISet, startRow, maxRows);
            dataSet.Merge(this.VW_ZADUZENI_PARTNERISet);
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
            this.scmdbuf = "SELECT COUNT(*) FROM [VW_ZADUZENI_PARTNERI]" + str + "  ";
            this.cmVW_ZADUZENI_PARTNERISelect1 = this.connDefault.GetCommand(this.scmdbuf, true);
            this.cmVW_ZADUZENI_PARTNERISelect1.ErrorMask |= ErrorMask.Lock;
            this.VW_ZADUZENI_PARTNERISelect1 = this.cmVW_ZADUZENI_PARTNERISelect1.FetchData();
            if (this.VW_ZADUZENI_PARTNERISelect1.IsDBNull(0))
            {
                this.m_RecordCount = 0;
            }
            else
            {
                this.m_RecordCount = this.VW_ZADUZENI_PARTNERISelect1.GetInt32(0);
            }
            this.VW_ZADUZENI_PARTNERISelect1.Close();
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

        private void Init_order_Vw_zaduzeni_partneri()
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

        string Placa.IVW_ZADUZENI_PARTNERIDataAdapter.Filter
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
            IDPARTNER
        }

        public class OrderAttribute
        {
            public bool OrderAttributeAscending;
            public VW_ZADUZENI_PARTNERIDataAdapter.Attribute OrderAttributeName;
            public string OrderAttributeString;

            public OrderAttribute(VW_ZADUZENI_PARTNERIDataAdapter.Attribute orderAttributeName)
            {
                this.OrderAttributeName = orderAttributeName;
                this.OrderAttributeAscending = true;
                this.OrderAttributeString = VW_ZADUZENI_PARTNERIDataAdapter.attributeNames[(int) this.OrderAttributeName];
            }

            public OrderAttribute(VW_ZADUZENI_PARTNERIDataAdapter.Attribute orderAttributeName, bool orderAttributeAscending)
            {
                this.OrderAttributeName = orderAttributeName;
                this.OrderAttributeAscending = orderAttributeAscending;
                this.OrderAttributeString = VW_ZADUZENI_PARTNERIDataAdapter.attributeNames[(int) this.OrderAttributeName];
            }
        }
    }
}


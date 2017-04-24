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

    public class VW_MJESECI_GODINE_OBRACUNADataAdapter : IDataAdapter, IVW_MJESECI_GODINE_OBRACUNADataAdapter
    {
        private static string[] attributeNames = new string[] { "[MJESECOBRACUNA]", "[GODINAOBRACUNA]" };
        private ReadWriteCommand cmVW_MJESECI_GODINE_OBRACUNASelect1;
        private ReadWriteCommand cmVW_MJESECI_GODINE_OBRACUNASelect2;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        private DbParameter[] fillDataParameters;
        private string filterCondition;
        private string filterString;
        private string filterStringCond;
        private bool m__GODINAOBRACUNAIsNull;
        private bool m__MJESECOBRACUNAIsNull;
        private string m_GODINAOBRACUNA;
        private string m_MJESECOBRACUNA;
        private int m_RecordCount;
        private string m_WhereString;
        private ArrayList orderArray;
        private string orderString;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private string reverseOrderString;
        private VW_MJESECI_GODINE_OBRACUNADataSet.VW_MJESECI_GODINE_OBRACUNARow rowVW_MJESECI_GODINE_OBRACUNA;
        private string scmdbuf;
        private IDataReader VW_MJESECI_GODINE_OBRACUNASelect1;
        private IDataReader VW_MJESECI_GODINE_OBRACUNASelect2;
        private VW_MJESECI_GODINE_OBRACUNADataSet VW_MJESECI_GODINE_OBRACUNASet;

        public VW_MJESECI_GODINE_OBRACUNADataAdapter()
        {
            this.Init_order_Vw_mjeseci_godine_obracuna();
            this.orderString = GetOrderString(this.Order, true);
            this.reverseOrderString = GetOrderString(this.Order, false);
        }

        private void AddRowVw_mjeseci_godine_obracuna()
        {
            this.VW_MJESECI_GODINE_OBRACUNASet.VW_MJESECI_GODINE_OBRACUNA.AddVW_MJESECI_GODINE_OBRACUNARow(this.rowVW_MJESECI_GODINE_OBRACUNA);
            this.rowVW_MJESECI_GODINE_OBRACUNA.AcceptChanges();
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
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  [MJESECOBRACUNA], [GODINAOBRACUNA] FROM [VW_MJESECI_GODINE_OBRACUNA]" + this.m_WhereString + "" + this.orderString + "";
                }
                else
                {
                    string[] strArray = new string[] { "SELECT TOP ", (startRow + maxRows).ToString(), "  [MJESECOBRACUNA], [GODINAOBRACUNA] FROM [VW_MJESECI_GODINE_OBRACUNA]", this.m_WhereString, "", this.orderString, "" };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT [MJESECOBRACUNA], [GODINAOBRACUNA] FROM [VW_MJESECI_GODINE_OBRACUNA]" + this.m_WhereString + "" + this.orderString + " ";
            }
            this.cmVW_MJESECI_GODINE_OBRACUNASelect2 = this.connDefault.GetCommand(this.scmdbuf, true);
            this.cmVW_MJESECI_GODINE_OBRACUNASelect2.ErrorMask |= ErrorMask.Lock;
            this.VW_MJESECI_GODINE_OBRACUNASelect2 = this.cmVW_MJESECI_GODINE_OBRACUNASelect2.FetchData();
            while (this.cmVW_MJESECI_GODINE_OBRACUNASelect2.HasMoreRows && (startRow > 0))
            {
                startRow--;
                this.cmVW_MJESECI_GODINE_OBRACUNASelect2.HasMoreRows = this.VW_MJESECI_GODINE_OBRACUNASelect2.Read();
            }
            int num = 0;
            while (this.cmVW_MJESECI_GODINE_OBRACUNASelect2.HasMoreRows && (num != maxRows))
            {
                this.m_MJESECOBRACUNA = this.dsDefault.Db.GetString(this.VW_MJESECI_GODINE_OBRACUNASelect2, 0, ref this.m__MJESECOBRACUNAIsNull);
                this.m_GODINAOBRACUNA = this.dsDefault.Db.GetString(this.VW_MJESECI_GODINE_OBRACUNASelect2, 1, ref this.m__GODINAOBRACUNAIsNull);
                this.rowVW_MJESECI_GODINE_OBRACUNA = this.VW_MJESECI_GODINE_OBRACUNASet.VW_MJESECI_GODINE_OBRACUNA.NewVW_MJESECI_GODINE_OBRACUNARow();
                this.rowVW_MJESECI_GODINE_OBRACUNA["MJESECOBRACUNA"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__MJESECOBRACUNAIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_MJESECOBRACUNA));
                this.rowVW_MJESECI_GODINE_OBRACUNA["GODINAOBRACUNA"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__GODINAOBRACUNAIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_GODINAOBRACUNA));
                this.AddRowVw_mjeseci_godine_obracuna();
                num++;
                this.cmVW_MJESECI_GODINE_OBRACUNASelect2.HasMoreRows = this.VW_MJESECI_GODINE_OBRACUNASelect2.Read();
            }
            this.VW_MJESECI_GODINE_OBRACUNASelect2.Close();
            this.Cleanup();
        }

        public virtual int Fill(VW_MJESECI_GODINE_OBRACUNADataSet dataSet)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.VW_MJESECI_GODINE_OBRACUNASet = dataSet;
            this.rowVW_MJESECI_GODINE_OBRACUNA = this.VW_MJESECI_GODINE_OBRACUNASet.VW_MJESECI_GODINE_OBRACUNA.NewVW_MJESECI_GODINE_OBRACUNARow();
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
            this.VW_MJESECI_GODINE_OBRACUNASet = (VW_MJESECI_GODINE_OBRACUNADataSet) dataSet;
            if (this.VW_MJESECI_GODINE_OBRACUNASet != null)
            {
                return this.Fill(this.VW_MJESECI_GODINE_OBRACUNASet);
            }
            this.VW_MJESECI_GODINE_OBRACUNASet = new VW_MJESECI_GODINE_OBRACUNADataSet();
            this.Fill(this.VW_MJESECI_GODINE_OBRACUNASet);
            dataSet.Merge(this.VW_MJESECI_GODINE_OBRACUNASet);
            return 0;
        }

        public virtual int FillPage(VW_MJESECI_GODINE_OBRACUNADataSet dataSet, int startRow, int maxRows)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.VW_MJESECI_GODINE_OBRACUNASet = dataSet;
            this.rowVW_MJESECI_GODINE_OBRACUNA = this.VW_MJESECI_GODINE_OBRACUNASet.VW_MJESECI_GODINE_OBRACUNA.NewVW_MJESECI_GODINE_OBRACUNARow();
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
            this.VW_MJESECI_GODINE_OBRACUNASet = (VW_MJESECI_GODINE_OBRACUNADataSet) dataSet;
            if (this.VW_MJESECI_GODINE_OBRACUNASet != null)
            {
                return this.FillPage(this.VW_MJESECI_GODINE_OBRACUNASet, startRow, maxRows);
            }
            this.VW_MJESECI_GODINE_OBRACUNASet = new VW_MJESECI_GODINE_OBRACUNADataSet();
            this.FillPage(this.VW_MJESECI_GODINE_OBRACUNASet, startRow, maxRows);
            dataSet.Merge(this.VW_MJESECI_GODINE_OBRACUNASet);
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
            this.scmdbuf = "SELECT COUNT(*) FROM [VW_MJESECI_GODINE_OBRACUNA]" + str + "  ";
            this.cmVW_MJESECI_GODINE_OBRACUNASelect1 = this.connDefault.GetCommand(this.scmdbuf, true);
            this.cmVW_MJESECI_GODINE_OBRACUNASelect1.ErrorMask |= ErrorMask.Lock;
            this.VW_MJESECI_GODINE_OBRACUNASelect1 = this.cmVW_MJESECI_GODINE_OBRACUNASelect1.FetchData();
            if (this.VW_MJESECI_GODINE_OBRACUNASelect1.IsDBNull(0))
            {
                this.m_RecordCount = 0;
            }
            else
            {
                this.m_RecordCount = this.VW_MJESECI_GODINE_OBRACUNASelect1.GetInt32(0);
            }
            this.VW_MJESECI_GODINE_OBRACUNASelect1.Close();
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

        private void Init_order_Vw_mjeseci_godine_obracuna()
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
            this.m__MJESECOBRACUNAIsNull = false;
            this.m_MJESECOBRACUNA = "";
            this.m__GODINAOBRACUNAIsNull = false;
            this.m_GODINAOBRACUNA = "";
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

        string Placa.IVW_MJESECI_GODINE_OBRACUNADataAdapter.Filter
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
            MJESECOBRACUNA,
            GODINAOBRACUNA
        }

        public class OrderAttribute
        {
            public bool OrderAttributeAscending;
            public VW_MJESECI_GODINE_OBRACUNADataAdapter.Attribute OrderAttributeName;
            public string OrderAttributeString;

            public OrderAttribute(VW_MJESECI_GODINE_OBRACUNADataAdapter.Attribute orderAttributeName)
            {
                this.OrderAttributeName = orderAttributeName;
                this.OrderAttributeAscending = true;
                this.OrderAttributeString = VW_MJESECI_GODINE_OBRACUNADataAdapter.attributeNames[(int) this.OrderAttributeName];
            }

            public OrderAttribute(VW_MJESECI_GODINE_OBRACUNADataAdapter.Attribute orderAttributeName, bool orderAttributeAscending)
            {
                this.OrderAttributeName = orderAttributeName;
                this.OrderAttributeAscending = orderAttributeAscending;
                this.OrderAttributeString = VW_MJESECI_GODINE_OBRACUNADataAdapter.attributeNames[(int) this.OrderAttributeName];
            }
        }
    }
}


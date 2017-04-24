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

    public class PROVIDER_NETODataAdapter : IDataAdapter, IPROVIDER_NETODataAdapter
    {
        private static string[] attributeNames = new string[] { "TM1.[IDELEMENT]", "TM1.[NAZIVELEMENT]", "TM1.[IDVRSTAELEMENTA]" };
        private ReadWriteCommand cmELEMENTSelect1;
        private ReadWriteCommand cmELEMENTSelect2;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        private IDataReader ELEMENTSelect1;
        private IDataReader ELEMENTSelect2;
        private DbParameter[] fillDataParameters;
        private string filterCondition;
        private string filterString;
        private bool m__IDELEMENTIsNull;
        private bool m__IDVRSTAELEMENTAIsNull;
        private bool m__NAZIVELEMENTIsNull;
        private bool m__NAZIVVRSTAELEMENTIsNull;
        private string m_EL;
        private int m_IDELEMENT;
        private short m_IDVRSTAELEMENTA;
        private string m_NAZIVELEMENT;
        private string m_NAZIVVRSTAELEMENT;
        private int m_RecordCount;
        private string m_WhereString;
        private ArrayList orderArray;
        private string orderString;
        private PROVIDER_NETODataSet PROVIDER_NETOSet;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private string reverseOrderString;
        private PROVIDER_NETODataSet.ELEMENTRow rowELEMENT;
        private string scmdbuf;

        public PROVIDER_NETODataAdapter()
        {
            this.Init_order_Element();
            this.orderString = GetOrderString(this.Order, true);
            this.reverseOrderString = GetOrderString(this.Order, false);
        }

        private void AddRowElement()
        {
            this.PROVIDER_NETOSet.ELEMENT.AddELEMENTRow(this.rowELEMENT);
            this.rowELEMENT.AcceptChanges();
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        public void executePrivate(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE " + this.filterString + "  TM1.[IDVRSTAELEMENTA] = 1";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  TM1.[IDELEMENT], TM1.[NAZIVELEMENT], TM1.[IDVRSTAELEMENTA], T2.[NAZIVVRSTAELEMENT]  FROM ([ELEMENT] TM1 INNER JOIN [VRSTAELEMENT] T2 ON T2.[IDVRSTAELEMENTA] = TM1.[IDVRSTAELEMENTA])" + this.m_WhereString + "" + this.orderString + "";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  TM1.[IDELEMENT], TM1.[NAZIVELEMENT], TM1.[IDVRSTAELEMENTA], T2.[NAZIVVRSTAELEMENT], ROW_NUMBER() OVER  ( ", this.orderString, " ) AS DK_PAGENUM   FROM ([ELEMENT] TM1 INNER JOIN [VRSTAELEMENT] T2 ON T2.[IDVRSTAELEMENTA] = TM1.[IDVRSTAELEMENTA]) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT TM1.[IDELEMENT], TM1.[NAZIVELEMENT], TM1.[IDVRSTAELEMENTA], T2.[NAZIVVRSTAELEMENT] FROM ([ELEMENT] TM1 INNER JOIN [VRSTAELEMENT] T2 ON T2.[IDVRSTAELEMENTA] = TM1.[IDVRSTAELEMENTA])" + this.m_WhereString + "" + this.orderString + " ";
            }
            this.cmELEMENTSelect2 = this.connDefault.GetCommand(this.scmdbuf, false);
            this.cmELEMENTSelect2.ErrorMask |= ErrorMask.Lock;
            this.ELEMENTSelect2 = this.cmELEMENTSelect2.FetchData();
            int num = 0;
            while (this.cmELEMENTSelect2.HasMoreRows && (num != maxRows))
            {
                this.m_IDELEMENT = this.dsDefault.Db.GetInt32(this.ELEMENTSelect2, 0, ref this.m__IDELEMENTIsNull);
                this.m_NAZIVELEMENT = this.dsDefault.Db.GetString(this.ELEMENTSelect2, 1, ref this.m__NAZIVELEMENTIsNull);
                this.m_IDVRSTAELEMENTA = this.dsDefault.Db.GetInt16(this.ELEMENTSelect2, 2, ref this.m__IDVRSTAELEMENTAIsNull);
                this.m_NAZIVVRSTAELEMENT = this.dsDefault.Db.GetString(this.ELEMENTSelect2, 3, ref this.m__NAZIVVRSTAELEMENTIsNull);
                this.m_NAZIVVRSTAELEMENT = this.dsDefault.Db.GetString(this.ELEMENTSelect2, 3, ref this.m__NAZIVVRSTAELEMENTIsNull);
                if (!this.m__NAZIVVRSTAELEMENTIsNull)
                {
                    this.m_EL = this.m_NAZIVELEMENT.Trim() + " | " + this.m_NAZIVVRSTAELEMENT.Trim();
                }
                this.rowELEMENT = this.PROVIDER_NETOSet.ELEMENT.NewELEMENTRow();
                this.rowELEMENT["IDELEMENT"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__IDELEMENTIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_IDELEMENT));
                this.rowELEMENT["NAZIVELEMENT"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__NAZIVELEMENTIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_NAZIVELEMENT));
                this.rowELEMENT["IDVRSTAELEMENTA"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__IDVRSTAELEMENTAIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_IDVRSTAELEMENTA));
                this.rowELEMENT.EL = this.m_EL;
                this.AddRowElement();
                num++;
                this.cmELEMENTSelect2.HasMoreRows = this.ELEMENTSelect2.Read();
            }
            this.ELEMENTSelect2.Close();
            this.Cleanup();
        }

        public virtual int Fill(PROVIDER_NETODataSet dataSet)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.PROVIDER_NETOSet = dataSet;
            this.rowELEMENT = this.PROVIDER_NETOSet.ELEMENT.NewELEMENTRow();
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
            this.PROVIDER_NETOSet = (PROVIDER_NETODataSet) dataSet;
            if (this.PROVIDER_NETOSet != null)
            {
                return this.Fill(this.PROVIDER_NETOSet);
            }
            this.PROVIDER_NETOSet = new PROVIDER_NETODataSet();
            this.Fill(this.PROVIDER_NETOSet);
            dataSet.Merge(this.PROVIDER_NETOSet);
            return 0;
        }

        public virtual int FillPage(PROVIDER_NETODataSet dataSet, int startRow, int maxRows)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.PROVIDER_NETOSet = dataSet;
            this.rowELEMENT = this.PROVIDER_NETOSet.ELEMENT.NewELEMENTRow();
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
            this.PROVIDER_NETOSet = (PROVIDER_NETODataSet) dataSet;
            if (this.PROVIDER_NETOSet != null)
            {
                return this.FillPage(this.PROVIDER_NETOSet, startRow, maxRows);
            }
            this.PROVIDER_NETOSet = new PROVIDER_NETODataSet();
            this.FillPage(this.PROVIDER_NETOSet, startRow, maxRows);
            dataSet.Merge(this.PROVIDER_NETOSet);
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
            string str = " WHERE T1.[IDVRSTAELEMENTA] = 1";
            this.scmdbuf = "SELECT COUNT(*) FROM ([ELEMENT] T1 INNER JOIN [VRSTAELEMENT] T2 ON T2.[IDVRSTAELEMENTA] = T1.[IDVRSTAELEMENTA])" + str + "  ";
            this.cmELEMENTSelect1 = this.connDefault.GetCommand(this.scmdbuf, false);
            this.cmELEMENTSelect1.ErrorMask |= ErrorMask.Lock;
            this.ELEMENTSelect1 = this.cmELEMENTSelect1.FetchData();
            if (this.ELEMENTSelect1.IsDBNull(0))
            {
                this.m_RecordCount = 0;
            }
            else
            {
                this.m_RecordCount = this.ELEMENTSelect1.GetInt32(0);
            }
            this.ELEMENTSelect1.Close();
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

        private void Init_order_Element()
        {
            this.Order = new ArrayList();
            this.Order.Add(new OrderAttribute(Attribute.IDVRSTAELEMENTA, true));
        }

        private void Initialize()
        {
            this.resourceManager = Deklarit.Utils.ResourceManager.Instance;
            this.resourceManagerTables = new System.Resources.ResourceManager("Tables", Assembly.GetExecutingAssembly());
            this.scmdbuf = "";
            this.m_WhereString = "";
            this.m_RecordCount = 0;
            this.m__IDELEMENTIsNull = false;
            this.m_IDELEMENT = 0;
            this.m__NAZIVELEMENTIsNull = false;
            this.m_NAZIVELEMENT = "";
            this.m__IDVRSTAELEMENTAIsNull = false;
            this.m_IDVRSTAELEMENTA = 0;
            this.m__NAZIVVRSTAELEMENTIsNull = false;
            this.m_NAZIVVRSTAELEMENT = "";
            this.m_EL = "";
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

        string Placa.IPROVIDER_NETODataAdapter.Filter
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
            IDELEMENT,
            NAZIVELEMENT,
            IDVRSTAELEMENTA
        }

        public class OrderAttribute
        {
            public bool OrderAttributeAscending;
            public PROVIDER_NETODataAdapter.Attribute OrderAttributeName;
            public string OrderAttributeString;

            public OrderAttribute(PROVIDER_NETODataAdapter.Attribute orderAttributeName)
            {
                this.OrderAttributeName = orderAttributeName;
                this.OrderAttributeAscending = true;
                this.OrderAttributeString = PROVIDER_NETODataAdapter.attributeNames[(int) this.OrderAttributeName];
            }

            public OrderAttribute(PROVIDER_NETODataAdapter.Attribute orderAttributeName, bool orderAttributeAscending)
            {
                this.OrderAttributeName = orderAttributeName;
                this.OrderAttributeAscending = orderAttributeAscending;
                this.OrderAttributeString = PROVIDER_NETODataAdapter.attributeNames[(int) this.OrderAttributeName];
            }
        }
    }
}


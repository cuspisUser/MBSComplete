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

    public class uraDocsDataAdapter : IDataAdapter, IuraDocsDataAdapter
    {
        private static string[] attributeNames = new string[] { "TM1.[IDDOKUMENT]", "TM1.[NAZIVDOKUMENT]", "TM1.[IDTIPDOKUMENTA]", "T2.[NAZIVTIPDOKUMENTA]", "TM1.[PS]" };
        private ReadWriteCommand cmDOKUMENTSelect1;
        private ReadWriteCommand cmDOKUMENTSelect2;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private IDataReader DOKUMENTSelect1;
        private IDataReader DOKUMENTSelect2;
        private DataStore dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        private DbParameter[] fillDataParameters;
        private string filterCondition;
        private string filterString;
        private bool m__IDDOKUMENTIsNull;
        private bool m__IDTIPDOKUMENTAIsNull;
        private bool m__NAZIVDOKUMENTIsNull;
        private bool m__NAZIVTIPDOKUMENTAIsNull;
        private bool m__PSIsNull;
        private int m_IDDOKUMENT;
        private int m_IDTIPDOKUMENTA;
        private string m_NAZIVDOKUMENT;
        private string m_NAZIVTIPDOKUMENTA;
        private bool m_PS;
        private int m_RecordCount;
        private string m_WhereString;
        private ArrayList orderArray;
        private string orderString;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private string reverseOrderString;
        private DOKUMENTDataSet.DOKUMENTRow rowDOKUMENT;
        private string scmdbuf;
        private DOKUMENTDataSet uraDocsSet;

        public uraDocsDataAdapter()
        {
            this.Init_order_Dokument();
            this.orderString = GetOrderString(this.Order, true);
            this.reverseOrderString = GetOrderString(this.Order, false);
        }

        private void AddRowDokument()
        {
            this.uraDocsSet.DOKUMENT.AddDOKUMENTRow(this.rowDOKUMENT);
            this.rowDOKUMENT.AcceptChanges();
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        public void executePrivate(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE " + this.filterString + "  TM1.[IDTIPDOKUMENTA] = 2";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  TM1.[IDDOKUMENT], TM1.[NAZIVDOKUMENT], TM1.[IDTIPDOKUMENTA], T2.[NAZIVTIPDOKUMENTA], TM1.[PS]  FROM ([DOKUMENT] TM1 INNER JOIN [TIPDOKUMENTA] T2 ON T2.[IDTIPDOKUMENTA] = TM1.[IDTIPDOKUMENTA])" + this.m_WhereString + "" + this.orderString + "";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  TM1.[IDDOKUMENT], TM1.[NAZIVDOKUMENT], TM1.[IDTIPDOKUMENTA], T2.[NAZIVTIPDOKUMENTA], TM1.[PS], ROW_NUMBER() OVER  ( ", this.orderString, " ) AS DK_PAGENUM   FROM ([DOKUMENT] TM1 INNER JOIN [TIPDOKUMENTA] T2 ON T2.[IDTIPDOKUMENTA] = TM1.[IDTIPDOKUMENTA]) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT TM1.[IDDOKUMENT], TM1.[NAZIVDOKUMENT], TM1.[IDTIPDOKUMENTA], T2.[NAZIVTIPDOKUMENTA], TM1.[PS] FROM ([DOKUMENT] TM1 INNER JOIN [TIPDOKUMENTA] T2 ON T2.[IDTIPDOKUMENTA] = TM1.[IDTIPDOKUMENTA])" + this.m_WhereString + "" + this.orderString + " ";
            }
            this.cmDOKUMENTSelect2 = this.connDefault.GetCommand(this.scmdbuf, false);
            this.cmDOKUMENTSelect2.ErrorMask |= ErrorMask.Lock;
            this.DOKUMENTSelect2 = this.cmDOKUMENTSelect2.FetchData();
            int num = 0;
            while (this.cmDOKUMENTSelect2.HasMoreRows && (num != maxRows))
            {
                this.m_IDDOKUMENT = this.dsDefault.Db.GetInt32(this.DOKUMENTSelect2, 0, ref this.m__IDDOKUMENTIsNull);
                this.m_NAZIVDOKUMENT = this.dsDefault.Db.GetString(this.DOKUMENTSelect2, 1, ref this.m__NAZIVDOKUMENTIsNull).TrimEnd(new char[] { ' ' });
                this.m_IDTIPDOKUMENTA = this.dsDefault.Db.GetInt32(this.DOKUMENTSelect2, 2, ref this.m__IDTIPDOKUMENTAIsNull);
                this.m_NAZIVTIPDOKUMENTA = this.dsDefault.Db.GetString(this.DOKUMENTSelect2, 3, ref this.m__NAZIVTIPDOKUMENTAIsNull);
                this.m_PS = this.dsDefault.Db.GetBoolean(this.DOKUMENTSelect2, 4, ref this.m__PSIsNull);
                this.m_NAZIVTIPDOKUMENTA = this.dsDefault.Db.GetString(this.DOKUMENTSelect2, 3, ref this.m__NAZIVTIPDOKUMENTAIsNull);
                this.rowDOKUMENT = this.uraDocsSet.DOKUMENT.NewDOKUMENTRow();
                this.rowDOKUMENT["IDDOKUMENT"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__IDDOKUMENTIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_IDDOKUMENT));
                this.rowDOKUMENT["NAZIVDOKUMENT"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__NAZIVDOKUMENTIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_NAZIVDOKUMENT));
                this.rowDOKUMENT["IDTIPDOKUMENTA"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__IDTIPDOKUMENTAIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_IDTIPDOKUMENTA));
                this.rowDOKUMENT["NAZIVTIPDOKUMENTA"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__NAZIVTIPDOKUMENTAIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_NAZIVTIPDOKUMENTA));
                this.rowDOKUMENT["PS"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__PSIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_PS));
                this.AddRowDokument();
                num++;
                this.cmDOKUMENTSelect2.HasMoreRows = this.DOKUMENTSelect2.Read();
            }
            this.DOKUMENTSelect2.Close();
            this.Cleanup();
        }

        public virtual int Fill(DOKUMENTDataSet dataSet)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.uraDocsSet = dataSet;
            this.rowDOKUMENT = this.uraDocsSet.DOKUMENT.NewDOKUMENTRow();
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
            this.uraDocsSet = (DOKUMENTDataSet) dataSet;
            if (this.uraDocsSet != null)
            {
                return this.Fill(this.uraDocsSet);
            }
            this.uraDocsSet = new DOKUMENTDataSet();
            this.Fill(this.uraDocsSet);
            dataSet.Merge(this.uraDocsSet);
            return 0;
        }

        public virtual int FillPage(DOKUMENTDataSet dataSet, int startRow, int maxRows)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.uraDocsSet = dataSet;
            this.rowDOKUMENT = this.uraDocsSet.DOKUMENT.NewDOKUMENTRow();
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
            this.uraDocsSet = (DOKUMENTDataSet) dataSet;
            if (this.uraDocsSet != null)
            {
                return this.FillPage(this.uraDocsSet, startRow, maxRows);
            }
            this.uraDocsSet = new DOKUMENTDataSet();
            this.FillPage(this.uraDocsSet, startRow, maxRows);
            dataSet.Merge(this.uraDocsSet);
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
            string str = " WHERE T1.[IDTIPDOKUMENTA] = 2";
            this.scmdbuf = "SELECT COUNT(*) FROM ([DOKUMENT] T1 INNER JOIN [TIPDOKUMENTA] T2 ON T2.[IDTIPDOKUMENTA] = T1.[IDTIPDOKUMENTA])" + str + "  ";
            this.cmDOKUMENTSelect1 = this.connDefault.GetCommand(this.scmdbuf, false);
            this.cmDOKUMENTSelect1.ErrorMask |= ErrorMask.Lock;
            this.DOKUMENTSelect1 = this.cmDOKUMENTSelect1.FetchData();
            if (this.DOKUMENTSelect1.IsDBNull(0))
            {
                this.m_RecordCount = 0;
            }
            else
            {
                this.m_RecordCount = this.DOKUMENTSelect1.GetInt32(0);
            }
            this.DOKUMENTSelect1.Close();
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

        private void Init_order_Dokument()
        {
            this.Order = new ArrayList();
            this.Order.Add(new OrderAttribute(Attribute.IDTIPDOKUMENTA, true));
        }

        private void Initialize()
        {
            this.resourceManager = Deklarit.Utils.ResourceManager.Instance;
            this.resourceManagerTables = new System.Resources.ResourceManager("Tables", Assembly.GetExecutingAssembly());
            this.scmdbuf = "";
            this.m_WhereString = "";
            this.m_RecordCount = 0;
            this.m__IDDOKUMENTIsNull = false;
            this.m_IDDOKUMENT = 0;
            this.m__NAZIVDOKUMENTIsNull = false;
            this.m_NAZIVDOKUMENT = "";
            this.m__IDTIPDOKUMENTAIsNull = false;
            this.m_IDTIPDOKUMENTA = 0;
            this.m__NAZIVTIPDOKUMENTAIsNull = false;
            this.m_NAZIVTIPDOKUMENTA = "";
            this.m__PSIsNull = false;
            this.m_PS = false;
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

        string Placa.IuraDocsDataAdapter.Filter
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
            IDDOKUMENT,
            NAZIVDOKUMENT,
            IDTIPDOKUMENTA,
            NAZIVTIPDOKUMENTA,
            PS
        }

        public class OrderAttribute
        {
            public bool OrderAttributeAscending;
            public uraDocsDataAdapter.Attribute OrderAttributeName;
            public string OrderAttributeString;

            public OrderAttribute(uraDocsDataAdapter.Attribute orderAttributeName)
            {
                this.OrderAttributeName = orderAttributeName;
                this.OrderAttributeAscending = true;
                this.OrderAttributeString = uraDocsDataAdapter.attributeNames[(int) this.OrderAttributeName];
            }

            public OrderAttribute(uraDocsDataAdapter.Attribute orderAttributeName, bool orderAttributeAscending)
            {
                this.OrderAttributeName = orderAttributeName;
                this.OrderAttributeAscending = orderAttributeAscending;
                this.OrderAttributeString = uraDocsDataAdapter.attributeNames[(int) this.OrderAttributeName];
            }
        }
    }
}


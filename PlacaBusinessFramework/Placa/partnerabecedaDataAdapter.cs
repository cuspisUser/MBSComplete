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

    public class partnerabecedaDataAdapter : IDataAdapter, IpartnerabecedaDataAdapter
    {
        private static string[] attributeNames = new string[] { "TM1.[IDPARTNER]", "TM1.[NAZIVPARTNER]", "TM1.[MB]", "TM1.[PARTNERMJESTO]", "TM1.[PARTNERULICA]", "TM1.[PARTNEREMAIL]", "TM1.[PARTNEROIB]", "TM1.[PARTNERFAX]", "TM1.[PARTNERTELEFON]", "TM1.[PARTNERZIRO1]", "TM1.[PARTNERZIRO2]" };
        private ReadWriteCommand cmPARTNERSelect1;
        private ReadWriteCommand cmPARTNERSelect2;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        private DbParameter[] fillDataParameters;
        private string filterCondition;
        private string filterString;
        private string filterStringCond;
        private bool m__IDPARTNERIsNull;
        private bool m__MBIsNull;
        private bool m__NAZIVPARTNERIsNull;
        private bool m__PARTNEREMAILIsNull;
        private bool m__PARTNERFAXIsNull;
        private bool m__PARTNERMJESTOIsNull;
        private bool m__PARTNEROIBIsNull;
        private bool m__PARTNERTELEFONIsNull;
        private bool m__PARTNERULICAIsNull;
        private bool m__PARTNERZIRO1IsNull;
        private bool m__PARTNERZIRO2IsNull;
        private int m_IDPARTNER;
        private string m_MB;
        private string m_NAZIVPARTNER;
        private string m_PARTNEREMAIL;
        private string m_PARTNERFAX;
        private string m_PARTNERMJESTO;
        private string m_PARTNEROIB;
        private string m_PARTNERTELEFON;
        private string m_PARTNERULICA;
        private string m_PARTNERZIRO1;
        private string m_PARTNERZIRO2;
        private int m_RecordCount;
        private string m_WhereString;
        private ArrayList orderArray;
        private string orderString;
        private PARTNERDataSet partnerabecedaSet;
        private IDataReader PARTNERSelect1;
        private IDataReader PARTNERSelect2;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private string reverseOrderString;
        private PARTNERDataSet.PARTNERRow rowPARTNER;
        private string scmdbuf;

        public partnerabecedaDataAdapter()
        {
            this.Init_order_Partner();
            this.orderString = GetOrderString(this.Order, true);
            this.reverseOrderString = GetOrderString(this.Order, false);
        }

        private void AddRowPartner()
        {
            this.partnerabecedaSet.PARTNER.AddPARTNERRow(this.rowPARTNER);
            this.rowPARTNER.AcceptChanges();
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
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  TM1.[IDPARTNER], TM1.[NAZIVPARTNER], TM1.[MB], TM1.[PARTNERMJESTO], TM1.[PARTNERULICA], TM1.[PARTNEREMAIL], TM1.[PARTNEROIB], TM1.[PARTNERFAX], TM1.[PARTNERTELEFON], TM1.[PARTNERZIRO1], TM1.[PARTNERZIRO2]  FROM [PARTNER] TM1" + this.m_WhereString + "" + this.orderString + "";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  TM1.[IDPARTNER], TM1.[NAZIVPARTNER], TM1.[MB], TM1.[PARTNERMJESTO], TM1.[PARTNERULICA], TM1.[PARTNEREMAIL], TM1.[PARTNEROIB], TM1.[PARTNERFAX], TM1.[PARTNERTELEFON], TM1.[PARTNERZIRO1], TM1.[PARTNERZIRO2], ROW_NUMBER() OVER  ( ", this.orderString, " ) AS DK_PAGENUM   FROM [PARTNER] TM1 ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT TM1.[IDPARTNER], TM1.[NAZIVPARTNER], TM1.[MB], TM1.[PARTNERMJESTO], TM1.[PARTNERULICA], TM1.[PARTNEREMAIL], TM1.[PARTNEROIB], TM1.[PARTNERFAX], TM1.[PARTNERTELEFON], TM1.[PARTNERZIRO1], TM1.[PARTNERZIRO2] FROM [PARTNER] TM1" + this.m_WhereString + "" + this.orderString + " ";
            }
            this.cmPARTNERSelect2 = this.connDefault.GetCommand(this.scmdbuf, false);
            this.cmPARTNERSelect2.ErrorMask |= ErrorMask.Lock;
            this.PARTNERSelect2 = this.cmPARTNERSelect2.FetchData();
            int num = 0;
            while (this.cmPARTNERSelect2.HasMoreRows && (num != maxRows))
            {
                this.m_IDPARTNER = this.dsDefault.Db.GetInt32(this.PARTNERSelect2, 0, ref this.m__IDPARTNERIsNull);
                this.m_NAZIVPARTNER = this.dsDefault.Db.GetString(this.PARTNERSelect2, 1, ref this.m__NAZIVPARTNERIsNull).TrimEnd(new char[] { ' ' });
                this.m_MB = this.dsDefault.Db.GetString(this.PARTNERSelect2, 2, ref this.m__MBIsNull);
                this.m_PARTNERMJESTO = this.dsDefault.Db.GetString(this.PARTNERSelect2, 3, ref this.m__PARTNERMJESTOIsNull);
                this.m_PARTNERULICA = this.dsDefault.Db.GetString(this.PARTNERSelect2, 4, ref this.m__PARTNERULICAIsNull);
                this.m_PARTNEREMAIL = this.dsDefault.Db.GetString(this.PARTNERSelect2, 5, ref this.m__PARTNEREMAILIsNull);
                this.m_PARTNEROIB = this.dsDefault.Db.GetString(this.PARTNERSelect2, 6, ref this.m__PARTNEROIBIsNull);
                this.m_PARTNERFAX = this.dsDefault.Db.GetString(this.PARTNERSelect2, 7, ref this.m__PARTNERFAXIsNull);
                this.m_PARTNERTELEFON = this.dsDefault.Db.GetString(this.PARTNERSelect2, 8, ref this.m__PARTNERTELEFONIsNull);
                this.m_PARTNERZIRO1 = this.dsDefault.Db.GetString(this.PARTNERSelect2, 9, ref this.m__PARTNERZIRO1IsNull);
                this.m_PARTNERZIRO2 = this.dsDefault.Db.GetString(this.PARTNERSelect2, 10, ref this.m__PARTNERZIRO2IsNull);
                this.rowPARTNER = this.partnerabecedaSet.PARTNER.NewPARTNERRow();
                this.rowPARTNER["IDPARTNER"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__IDPARTNERIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_IDPARTNER));
                this.rowPARTNER["NAZIVPARTNER"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__NAZIVPARTNERIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_NAZIVPARTNER));
                this.rowPARTNER["MB"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__MBIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_MB));
                this.rowPARTNER["PARTNERMJESTO"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__PARTNERMJESTOIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_PARTNERMJESTO));
                this.rowPARTNER["PARTNERULICA"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__PARTNERULICAIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_PARTNERULICA));
                this.rowPARTNER["PARTNEREMAIL"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__PARTNEREMAILIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_PARTNEREMAIL));
                this.rowPARTNER["PARTNEROIB"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__PARTNEROIBIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_PARTNEROIB));
                this.rowPARTNER["PARTNERFAX"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__PARTNERFAXIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_PARTNERFAX));
                this.rowPARTNER["PARTNERTELEFON"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__PARTNERTELEFONIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_PARTNERTELEFON));
                this.rowPARTNER["PARTNERZIRO1"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__PARTNERZIRO1IsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_PARTNERZIRO1));
                this.rowPARTNER["PARTNERZIRO2"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__PARTNERZIRO2IsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_PARTNERZIRO2));
                this.AddRowPartner();
                num++;
                this.cmPARTNERSelect2.HasMoreRows = this.PARTNERSelect2.Read();
            }
            this.PARTNERSelect2.Close();
            this.Cleanup();
        }

        public virtual int Fill(PARTNERDataSet dataSet)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.partnerabecedaSet = dataSet;
            this.rowPARTNER = this.partnerabecedaSet.PARTNER.NewPARTNERRow();
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
            this.partnerabecedaSet = (PARTNERDataSet) dataSet;
            if (this.partnerabecedaSet != null)
            {
                return this.Fill(this.partnerabecedaSet);
            }
            this.partnerabecedaSet = new PARTNERDataSet();
            this.Fill(this.partnerabecedaSet);
            dataSet.Merge(this.partnerabecedaSet);
            return 0;
        }

        public virtual int FillPage(PARTNERDataSet dataSet, int startRow, int maxRows)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.partnerabecedaSet = dataSet;
            this.rowPARTNER = this.partnerabecedaSet.PARTNER.NewPARTNERRow();
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
            this.partnerabecedaSet = (PARTNERDataSet) dataSet;
            if (this.partnerabecedaSet != null)
            {
                return this.FillPage(this.partnerabecedaSet, startRow, maxRows);
            }
            this.partnerabecedaSet = new PARTNERDataSet();
            this.FillPage(this.partnerabecedaSet, startRow, maxRows);
            dataSet.Merge(this.partnerabecedaSet);
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
            this.scmdbuf = "SELECT COUNT(*) FROM [PARTNER]" + str + "  ";
            this.cmPARTNERSelect1 = this.connDefault.GetCommand(this.scmdbuf, false);
            this.cmPARTNERSelect1.ErrorMask |= ErrorMask.Lock;
            this.PARTNERSelect1 = this.cmPARTNERSelect1.FetchData();
            if (this.PARTNERSelect1.IsDBNull(0))
            {
                this.m_RecordCount = 0;
            }
            else
            {
                this.m_RecordCount = this.PARTNERSelect1.GetInt32(0);
            }
            this.PARTNERSelect1.Close();
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

        private void Init_order_Partner()
        {
            this.Order = new ArrayList();
            this.Order.Add(new OrderAttribute(Attribute.NAZIVPARTNER, true));
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
            this.m__MBIsNull = false;
            this.m_MB = "";
            this.m__PARTNERMJESTOIsNull = false;
            this.m_PARTNERMJESTO = "";
            this.m__PARTNERULICAIsNull = false;
            this.m_PARTNERULICA = "";
            this.m__PARTNEREMAILIsNull = false;
            this.m_PARTNEREMAIL = "";
            this.m__PARTNEROIBIsNull = false;
            this.m_PARTNEROIB = "";
            this.m__PARTNERFAXIsNull = false;
            this.m_PARTNERFAX = "";
            this.m__PARTNERTELEFONIsNull = false;
            this.m_PARTNERTELEFON = "";
            this.m__PARTNERZIRO1IsNull = false;
            this.m_PARTNERZIRO1 = "";
            this.m__PARTNERZIRO2IsNull = false;
            this.m_PARTNERZIRO2 = "";
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

        string Placa.IpartnerabecedaDataAdapter.Filter
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
            IDPARTNER,
            NAZIVPARTNER,
            MB,
            PARTNERMJESTO,
            PARTNERULICA,
            PARTNEREMAIL,
            PARTNEROIB,
            PARTNERFAX,
            PARTNERTELEFON,
            PARTNERZIRO1,
            PARTNERZIRO2
        }

        public class OrderAttribute
        {
            public bool OrderAttributeAscending;
            public partnerabecedaDataAdapter.Attribute OrderAttributeName;
            public string OrderAttributeString;

            public OrderAttribute(partnerabecedaDataAdapter.Attribute orderAttributeName)
            {
                this.OrderAttributeName = orderAttributeName;
                this.OrderAttributeAscending = true;
                this.OrderAttributeString = partnerabecedaDataAdapter.attributeNames[(int) this.OrderAttributeName];
            }

            public OrderAttribute(partnerabecedaDataAdapter.Attribute orderAttributeName, bool orderAttributeAscending)
            {
                this.OrderAttributeName = orderAttributeName;
                this.OrderAttributeAscending = orderAttributeAscending;
                this.OrderAttributeString = partnerabecedaDataAdapter.attributeNames[(int) this.OrderAttributeName];
            }
        }
    }
}


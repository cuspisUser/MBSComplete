namespace Placa
{
    using Deklarit.Data;
    using Deklarit.Utils;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Collections;
    using System.Data;
    using System.Data.Common;
    using System.Globalization;
    using System.Reflection;
    using System.Resources;
    using System.Runtime.CompilerServices;
    using System.Threading;

    public class trazi_partneraDataAdapter : IDataAdapter, Itrazi_partneraDataAdapter
    {
        private static string[] attributeNames = new string[] { "TM1.[IDPARTNER]", "TM1.[NAZIVPARTNER]", "TM1.[PARTNERMJESTO]", "TM1.[PARTNEREMAIL]", "TM1.[PARTNERULICA]", "TM1.[MB]", "TM1.[PARTNEROIB]" };
        private string AV8NAZIVPA;
        private ReadWriteCommand cmPARTNERSelect1;
        private ReadWriteCommand cmPARTNERSelect2;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        private DbParameter[] fillDataParameters;
        private string filterCondition;
        private string filterString;
        private string lV8NAZIVPA;
        private bool m__IDPARTNERIsNull;
        private bool m__MBIsNull;
        private bool m__NAZIVPARTNERIsNull;
        private bool m__PARTNEREMAILIsNull;
        private bool m__PARTNERMJESTOIsNull;
        private bool m__PARTNEROIBIsNull;
        private bool m__PARTNERULICAIsNull;
        private int m_IDPARTNER;
        private string m_MB;
        private string m_NAZIVPARTNER;
        private string m_PARTNEREMAIL;
        private string m_PARTNERMJESTO;
        private string m_PARTNEROIB;
        private string m_PARTNERULICA;
        private string m_PT;
        private int m_RecordCount;
        private int m_TopRowCount;
        private string m_WhereString;
        private ArrayList orderArray;
        private string orderString;
        private IDataReader PARTNERSelect1;
        private IDataReader PARTNERSelect2;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private string reverseOrderString;
        private trazi_partneraDataSet.PARTNERRow rowPARTNER;
        private string scmdbuf;
        private string sWhereSep;
        private trazi_partneraDataSet trazi_partneraSet;

        public trazi_partneraDataAdapter()
        {
            this.Init_order_Partner();
            this.orderString = GetOrderString(this.Order, true);
            this.reverseOrderString = GetOrderString(this.Order, false);
        }

        private void AddRowPartner()
        {
            this.trazi_partneraSet.PARTNER.AddPARTNERRow(this.rowPARTNER);
            this.rowPARTNER.AcceptChanges();
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        public void executePrivate(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE " + this.filterString + "  TM1.[NAZIVPARTNER] like '%' + @NAZIVPARTNER + '%'";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  TM1.[IDPARTNER], TM1.[NAZIVPARTNER], TM1.[PARTNERMJESTO], TM1.[PARTNEREMAIL], TM1.[PARTNERULICA], TM1.[MB], TM1.[PARTNEROIB] FROM [PARTNER] TM1" + this.m_WhereString + "" + this.orderString + "";
                }
                else
                {
                    if (string.Compare(this.m_WhereString.TrimEnd(new char[] { ' ' }), "".TrimEnd(new char[] { ' ' }), false, CultureInfo.CurrentCulture) == 0)
                    {
                        this.sWhereSep = " WHERE ";
                    }
                    else
                    {
                        this.sWhereSep = " AND ";
                    }
                    int internalRecordCount = this.GetInternalRecordCount(this.AV8NAZIVPA);
                    this.m_TopRowCount = Conversions.ToInteger(Interaction.IIf(internalRecordCount >= (startRow + maxRows), maxRows, RuntimeHelpers.GetObjectValue(Interaction.IIf(internalRecordCount >= startRow, internalRecordCount - startRow, 0))));
                    if (this.m_TopRowCount == 0)
                    {
                        return;
                    }
                    this.scmdbuf = "SELECT TM1.[IDPARTNER], TM1.[NAZIVPARTNER], TM1.[PARTNERMJESTO], TM1.[PARTNEREMAIL], TM1.[PARTNERULICA], TM1.[MB], TM1.[PARTNEROIB] FROM [PARTNER] TM1 WHERE TM1.[IDPARTNER] IN ( SELECT TOP " + maxRows.ToString() + " TM1.[IDPARTNER]  FROM [PARTNER] TM1" + this.m_WhereString + "" + this.sWhereSep + "TM1.[IDPARTNER] NOT IN ( SELECT TOP " + startRow.ToString() + " TM1.[IDPARTNER]  FROM [PARTNER] TM1" + this.m_WhereString + "" + this.orderString + ")" + this.orderString + ")" + this.orderString + "";
                }
            }
            else
            {
                this.scmdbuf = "SELECT TM1.[IDPARTNER], TM1.[NAZIVPARTNER], TM1.[PARTNERMJESTO], TM1.[PARTNEREMAIL], TM1.[PARTNERULICA], TM1.[MB], TM1.[PARTNEROIB] FROM [PARTNER] TM1" + this.m_WhereString + "" + this.orderString + " ";
            }
            this.cmPARTNERSelect2 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmPARTNERSelect2.IDbCommand.Parameters.Count == 0)
            {
                this.cmPARTNERSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVPARTNER", DbType.String, 100));
            }
            this.lV8NAZIVPA = StringUtil.PadRight(StringUtil.RTrim(this.AV8NAZIVPA), 100, "%");
            this.cmPARTNERSelect2.SetParameter(0, this.lV8NAZIVPA);
            this.cmPARTNERSelect2.ErrorMask |= ErrorMask.Lock;
            this.PARTNERSelect2 = this.cmPARTNERSelect2.FetchData();
            int num = 0;
            while (this.cmPARTNERSelect2.HasMoreRows && (num != maxRows))
            {
                this.m_IDPARTNER = this.dsDefault.Db.GetInt32(this.PARTNERSelect2, 0, ref this.m__IDPARTNERIsNull);
                this.m_NAZIVPARTNER = this.dsDefault.Db.GetString(this.PARTNERSelect2, 1, ref this.m__NAZIVPARTNERIsNull).TrimEnd(new char[] { ' ' });
                this.m_PARTNERMJESTO = this.dsDefault.Db.GetString(this.PARTNERSelect2, 2, ref this.m__PARTNERMJESTOIsNull);
                this.m_PARTNEREMAIL = this.dsDefault.Db.GetString(this.PARTNERSelect2, 3, ref this.m__PARTNEREMAILIsNull);
                this.m_PARTNERULICA = this.dsDefault.Db.GetString(this.PARTNERSelect2, 4, ref this.m__PARTNERULICAIsNull);
                this.m_MB = this.dsDefault.Db.GetString(this.PARTNERSelect2, 5, ref this.m__MBIsNull);
                this.m_PARTNEROIB = this.dsDefault.Db.GetString(this.PARTNERSelect2, 6, ref this.m__PARTNEROIBIsNull);
                this.m_PT = this.m_NAZIVPARTNER + " | " + NumberUtil.ToString((long) this.m_IDPARTNER, "");
                this.rowPARTNER = this.trazi_partneraSet.PARTNER.NewPARTNERRow();
                this.rowPARTNER["IDPARTNER"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__IDPARTNERIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_IDPARTNER));
                this.rowPARTNER["NAZIVPARTNER"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__NAZIVPARTNERIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_NAZIVPARTNER));
                this.rowPARTNER["PARTNERMJESTO"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__PARTNERMJESTOIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_PARTNERMJESTO));
                this.rowPARTNER["PARTNEREMAIL"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__PARTNEREMAILIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_PARTNEREMAIL));
                this.rowPARTNER["PARTNERULICA"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__PARTNERULICAIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_PARTNERULICA));
                this.rowPARTNER["MB"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__MBIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_MB));
                this.rowPARTNER["PARTNEROIB"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__PARTNEROIBIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_PARTNEROIB));
                this.rowPARTNER.PT = this.m_PT;
                this.AddRowPartner();
                num++;
                this.cmPARTNERSelect2.HasMoreRows = this.PARTNERSelect2.Read();
            }
            this.PARTNERSelect2.Close();
            this.Cleanup();
        }

        public virtual int Fill(trazi_partneraDataSet dataSet)
        {
            if (this.fillDataParameters == null)
            {
                throw new ArgumentException();
            }
            this.Fill(dataSet, this.fillDataParameters[0].Value.ToString());
            return 0;
        }

        public virtual int Fill(DataSet dataSet)
        {
            this.trazi_partneraSet = (trazi_partneraDataSet) dataSet;
            if (this.trazi_partneraSet != null)
            {
                return this.Fill(this.trazi_partneraSet);
            }
            this.trazi_partneraSet = new trazi_partneraDataSet();
            this.Fill(this.trazi_partneraSet);
            dataSet.Merge(this.trazi_partneraSet);
            return 0;
        }

        public virtual int Fill(trazi_partneraDataSet dataSet, string nAZIVPARTNER)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.trazi_partneraSet = dataSet;
            this.SetFillParameters(nAZIVPARTNER);
            this.AV8NAZIVPA = nAZIVPARTNER;
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

        public virtual int FillPage(trazi_partneraDataSet dataSet, int startRow, int maxRows)
        {
            if (this.fillDataParameters == null)
            {
                throw new ArgumentException();
            }
            this.FillPage(dataSet, this.fillDataParameters[0].Value.ToString(), startRow, maxRows);
            return 0;
        }

        public virtual int FillPage(DataSet dataSet, int startRow, int maxRows)
        {
            this.trazi_partneraSet = (trazi_partneraDataSet) dataSet;
            if (this.trazi_partneraSet != null)
            {
                return this.FillPage(this.trazi_partneraSet, startRow, maxRows);
            }
            this.trazi_partneraSet = new trazi_partneraDataSet();
            this.FillPage(this.trazi_partneraSet, startRow, maxRows);
            dataSet.Merge(this.trazi_partneraSet);
            return 0;
        }

        public virtual int FillPage(trazi_partneraDataSet dataSet, string nAZIVPARTNER, int startRow, int maxRows)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.trazi_partneraSet = dataSet;
            this.SetFillParameters(nAZIVPARTNER);
            this.AV8NAZIVPA = nAZIVPARTNER;
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
                DbParameter parameter = DbProviderFactories.GetFactory("System.Data.SqlClient").CreateParameter();
                parameter.ParameterName = "NAZIVPARTNER";
                parameter.DbType = DbType.String;
                this.fillDataParameters = new DbParameter[] { parameter };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount(string nAZIVPARTNER)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            string str = " WHERE [NAZIVPARTNER] like '%' + @NAZIVPARTNER + '%'";
            this.scmdbuf = "SELECT COUNT(*) FROM [PARTNER]" + str + "  ";
            this.cmPARTNERSelect1 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmPARTNERSelect1.IDbCommand.Parameters.Count == 0)
            {
                this.cmPARTNERSelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVPARTNER", DbType.String, 100));
            }
            this.lV8NAZIVPA = StringUtil.PadRight(StringUtil.RTrim(nAZIVPARTNER), 100, "%");
            this.cmPARTNERSelect1.SetParameter(0, this.lV8NAZIVPA);
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

        public virtual int GetRecordCount(string nAZIVPARTNER)
        {
            int internalRecordCount;
            try
            {
                this.SetFillParameters(nAZIVPARTNER);
                internalRecordCount = this.GetInternalRecordCount(nAZIVPARTNER);
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
        }

        private void Initialize()
        {
            this.resourceManager = Deklarit.Utils.ResourceManager.Instance;
            this.resourceManagerTables = new System.Resources.ResourceManager("Tables", Assembly.GetExecutingAssembly());
            this.AV8NAZIVPA = "";
            this.scmdbuf = "";
            this.m_WhereString = "";
            this.lV8NAZIVPA = "";
            this.m_RecordCount = 0;
            this.sWhereSep = "";
            this.m_TopRowCount = 0;
            this.m__IDPARTNERIsNull = false;
            this.m_IDPARTNER = 0;
            this.m__NAZIVPARTNERIsNull = false;
            this.m_NAZIVPARTNER = "";
            this.m__PARTNERMJESTOIsNull = false;
            this.m_PARTNERMJESTO = "";
            this.m__PARTNEREMAILIsNull = false;
            this.m_PARTNEREMAIL = "";
            this.m__PARTNERULICAIsNull = false;
            this.m_PARTNERULICA = "";
            this.m__MBIsNull = false;
            this.m_MB = "";
            this.m__PARTNEROIBIsNull = false;
            this.m_PARTNEROIB = "";
            this.m_PT = "";
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void SetFillParameters(string nAZIVPARTNER)
        {
            if (this.fillDataParameters == null)
            {
                this.GetFillParameters();
                this.fillDataParameters[0].Value = nAZIVPARTNER;
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

        string Placa.Itrazi_partneraDataAdapter.Filter
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
            IDPARTNER,
            NAZIVPARTNER,
            PARTNERMJESTO,
            PARTNEREMAIL,
            PARTNERULICA,
            MB,
            PARTNEROIB
        }

        public class OrderAttribute
        {
            public bool OrderAttributeAscending;
            public trazi_partneraDataAdapter.Attribute OrderAttributeName;
            public string OrderAttributeString;

            public OrderAttribute(trazi_partneraDataAdapter.Attribute orderAttributeName)
            {
                this.OrderAttributeName = orderAttributeName;
                this.OrderAttributeAscending = true;
                this.OrderAttributeString = trazi_partneraDataAdapter.attributeNames[(int) this.OrderAttributeName];
            }

            public OrderAttribute(trazi_partneraDataAdapter.Attribute orderAttributeName, bool orderAttributeAscending)
            {
                this.OrderAttributeName = orderAttributeName;
                this.OrderAttributeAscending = orderAttributeAscending;
                this.OrderAttributeString = trazi_partneraDataAdapter.attributeNames[(int) this.OrderAttributeName];
            }
        }
    }
}


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

    public class trazi_proizvodDataAdapter : IDataAdapter, Itrazi_proizvodDataAdapter
    {
        private static string[] attributeNames = new string[] { "TM1.[IDPROIZVOD]", "TM1.[NAZIVPROIZVOD]", "TM1.[CIJENA]", "TM1.[FINPOREZIDPOREZ]", "T3.[FINPOREZSTOPA]", "TM1.[IDJEDINICAMJERE]", "T2.[NAZIVJEDINICAMJERE]" };
        private string AV8nazivpr;
        private ReadWriteCommand cmPROIZVODSelect1;
        private ReadWriteCommand cmPROIZVODSelect2;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        private DbParameter[] fillDataParameters;
        private string filterCondition;
        private string filterString;
        private string lV8nazivpr;
        private bool m__CIJENAIsNull;
        private bool m__FINPOREZIDPOREZIsNull;
        private bool m__FINPOREZSTOPAIsNull;
        private bool m__IDJEDINICAMJEREIsNull;
        private bool m__IDPROIZVODIsNull;
        private bool m__NAZIVJEDINICAMJEREIsNull;
        private bool m__NAZIVPROIZVODIsNull;
        private decimal m_CIJENA;
        private int m_FINPOREZIDPOREZ;
        private decimal m_FINPOREZSTOPA;
        private int m_IDJEDINICAMJERE;
        private int m_IDPROIZVOD;
        private string m_NAZIVJEDINICAMJERE;
        private string m_NAZIVPROIZVOD;
        private int m_RecordCount;
        private int m_TopRowCount;
        private string m_WhereString;
        private ArrayList orderArray;
        private string orderString;
        private IDataReader PROIZVODSelect1;
        private IDataReader PROIZVODSelect2;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private string reverseOrderString;
        private trazi_proizvodDataSet.PROIZVODRow rowPROIZVOD;
        private string scmdbuf;
        private string sWhereSep;
        private trazi_proizvodDataSet trazi_proizvodSet;

        public trazi_proizvodDataAdapter()
        {
            this.Init_order_Proizvod();
            this.orderString = GetOrderString(this.Order, true);
            this.reverseOrderString = GetOrderString(this.Order, false);
        }

        private void AddRowProizvod()
        {
            this.trazi_proizvodSet.PROIZVOD.AddPROIZVODRow(this.rowPROIZVOD);
            this.rowPROIZVOD.AcceptChanges();
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        public void executePrivate(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE " + this.filterString + "  TM1.[NAZIVPROIZVOD] like '%' + @nazivproizvod + '%'";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  TM1.[IDPROIZVOD], TM1.[NAZIVPROIZVOD], TM1.[CIJENA], TM1.[FINPOREZIDPOREZ], T3.[FINPOREZSTOPA], TM1.[IDJEDINICAMJERE], T2.[NAZIVJEDINICAMJERE] FROM (([PROIZVOD] TM1 INNER JOIN [JEDINICAMJERE] T2 ON T2.[IDJEDINICAMJERE] = TM1.[IDJEDINICAMJERE]) INNER JOIN [FINPOREZ] T3 ON T3.[FINPOREZIDPOREZ] = TM1.[FINPOREZIDPOREZ])" + this.m_WhereString + "" + this.orderString + "";
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
                    int internalRecordCount = this.GetInternalRecordCount(this.AV8nazivpr);
                    this.m_TopRowCount = Conversions.ToInteger(Interaction.IIf(internalRecordCount >= (startRow + maxRows), maxRows, RuntimeHelpers.GetObjectValue(Interaction.IIf(internalRecordCount >= startRow, internalRecordCount - startRow, 0))));
                    if (this.m_TopRowCount == 0)
                    {
                        return;
                    }
                    this.scmdbuf = "SELECT TM1.[IDPROIZVOD], TM1.[NAZIVPROIZVOD], TM1.[CIJENA], TM1.[FINPOREZIDPOREZ], T3.[FINPOREZSTOPA], TM1.[IDJEDINICAMJERE], T2.[NAZIVJEDINICAMJERE] FROM (([PROIZVOD] TM1 INNER JOIN [JEDINICAMJERE] T2 ON T2.[IDJEDINICAMJERE] = TM1.[IDJEDINICAMJERE]) INNER JOIN [FINPOREZ] T3 ON T3.[FINPOREZIDPOREZ] = TM1.[FINPOREZIDPOREZ]) WHERE TM1.[IDPROIZVOD] IN ( SELECT TOP " + maxRows.ToString() + " TM1.[IDPROIZVOD]  FROM (([PROIZVOD] TM1 INNER JOIN [JEDINICAMJERE] T2 ON T2.[IDJEDINICAMJERE] = TM1.[IDJEDINICAMJERE]) INNER JOIN [FINPOREZ] T3 ON T3.[FINPOREZIDPOREZ] = TM1.[FINPOREZIDPOREZ])" + this.m_WhereString + "" + this.sWhereSep + "TM1.[IDPROIZVOD] NOT IN ( SELECT TOP " + startRow.ToString() + " TM1.[IDPROIZVOD]  FROM (([PROIZVOD] TM1 INNER JOIN [JEDINICAMJERE] T2 ON T2.[IDJEDINICAMJERE] = TM1.[IDJEDINICAMJERE]) INNER JOIN [FINPOREZ] T3 ON T3.[FINPOREZIDPOREZ] = TM1.[FINPOREZIDPOREZ])" + this.m_WhereString + "" + this.orderString + ")" + this.orderString + ")" + this.orderString + "";
                }
            }
            else
            {
                this.scmdbuf = "SELECT TM1.[IDPROIZVOD], TM1.[NAZIVPROIZVOD], TM1.[CIJENA], TM1.[FINPOREZIDPOREZ], T3.[FINPOREZSTOPA], TM1.[IDJEDINICAMJERE], T2.[NAZIVJEDINICAMJERE] FROM (([PROIZVOD] TM1 INNER JOIN [JEDINICAMJERE] T2 ON T2.[IDJEDINICAMJERE] = TM1.[IDJEDINICAMJERE]) INNER JOIN [FINPOREZ] T3 ON T3.[FINPOREZIDPOREZ] = TM1.[FINPOREZIDPOREZ])" + this.m_WhereString + "" + this.orderString + " ";
            }
            this.cmPROIZVODSelect2 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmPROIZVODSelect2.IDbCommand.Parameters.Count == 0)
            {
                this.cmPROIZVODSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@nazivproizvod", DbType.String, 500));
            }
            this.lV8nazivpr = StringUtil.PadRight(StringUtil.RTrim(this.AV8nazivpr), 500, "%");
            this.cmPROIZVODSelect2.SetParameter(0, this.lV8nazivpr);
            this.cmPROIZVODSelect2.ErrorMask |= ErrorMask.Lock;
            this.PROIZVODSelect2 = this.cmPROIZVODSelect2.FetchData();
            int num = 0;
            while (this.cmPROIZVODSelect2.HasMoreRows && (num != maxRows))
            {
                this.m_IDPROIZVOD = this.dsDefault.Db.GetInt32(this.PROIZVODSelect2, 0, ref this.m__IDPROIZVODIsNull);
                this.m_NAZIVPROIZVOD = this.dsDefault.Db.GetString(this.PROIZVODSelect2, 1, ref this.m__NAZIVPROIZVODIsNull);
                this.m_CIJENA = this.dsDefault.Db.GetDecimal(this.PROIZVODSelect2, 2, ref this.m__CIJENAIsNull);
                this.m_FINPOREZIDPOREZ = this.dsDefault.Db.GetInt32(this.PROIZVODSelect2, 3, ref this.m__FINPOREZIDPOREZIsNull);
                this.m_FINPOREZSTOPA = this.dsDefault.Db.GetDecimal(this.PROIZVODSelect2, 4, ref this.m__FINPOREZSTOPAIsNull);
                this.m_IDJEDINICAMJERE = this.dsDefault.Db.GetInt32(this.PROIZVODSelect2, 5, ref this.m__IDJEDINICAMJEREIsNull);
                this.m_NAZIVJEDINICAMJERE = this.dsDefault.Db.GetString(this.PROIZVODSelect2, 6, ref this.m__NAZIVJEDINICAMJEREIsNull);
                this.m_NAZIVJEDINICAMJERE = this.dsDefault.Db.GetString(this.PROIZVODSelect2, 6, ref this.m__NAZIVJEDINICAMJEREIsNull);
                this.m_FINPOREZSTOPA = this.dsDefault.Db.GetDecimal(this.PROIZVODSelect2, 4, ref this.m__FINPOREZSTOPAIsNull);
                this.rowPROIZVOD = this.trazi_proizvodSet.PROIZVOD.NewPROIZVODRow();
                this.rowPROIZVOD["IDPROIZVOD"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__IDPROIZVODIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_IDPROIZVOD));
                this.rowPROIZVOD["NAZIVPROIZVOD"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__NAZIVPROIZVODIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_NAZIVPROIZVOD));
                this.rowPROIZVOD["CIJENA"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__CIJENAIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_CIJENA));
                this.rowPROIZVOD["FINPOREZIDPOREZ"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__FINPOREZIDPOREZIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_FINPOREZIDPOREZ));
                this.rowPROIZVOD["FINPOREZSTOPA"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__FINPOREZSTOPAIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_FINPOREZSTOPA));
                this.rowPROIZVOD["IDJEDINICAMJERE"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__IDJEDINICAMJEREIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_IDJEDINICAMJERE));
                this.rowPROIZVOD["NAZIVJEDINICAMJERE"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__NAZIVJEDINICAMJEREIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_NAZIVJEDINICAMJERE));
                this.AddRowProizvod();
                num++;
                this.cmPROIZVODSelect2.HasMoreRows = this.PROIZVODSelect2.Read();
            }
            this.PROIZVODSelect2.Close();
            this.Cleanup();
        }

        public virtual int Fill(trazi_proizvodDataSet dataSet)
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
            this.trazi_proizvodSet = (trazi_proizvodDataSet) dataSet;
            if (this.trazi_proizvodSet != null)
            {
                return this.Fill(this.trazi_proizvodSet);
            }
            this.trazi_proizvodSet = new trazi_proizvodDataSet();
            this.Fill(this.trazi_proizvodSet);
            dataSet.Merge(this.trazi_proizvodSet);
            return 0;
        }

        public virtual int Fill(trazi_proizvodDataSet dataSet, string nazivproizvod)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.trazi_proizvodSet = dataSet;
            this.SetFillParameters(nazivproizvod);
            this.AV8nazivpr = nazivproizvod;
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

        public virtual int FillPage(trazi_proizvodDataSet dataSet, int startRow, int maxRows)
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
            this.trazi_proizvodSet = (trazi_proizvodDataSet) dataSet;
            if (this.trazi_proizvodSet != null)
            {
                return this.FillPage(this.trazi_proizvodSet, startRow, maxRows);
            }
            this.trazi_proizvodSet = new trazi_proizvodDataSet();
            this.FillPage(this.trazi_proizvodSet, startRow, maxRows);
            dataSet.Merge(this.trazi_proizvodSet);
            return 0;
        }

        public virtual int FillPage(trazi_proizvodDataSet dataSet, string nazivproizvod, int startRow, int maxRows)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.trazi_proizvodSet = dataSet;
            this.SetFillParameters(nazivproizvod);
            this.AV8nazivpr = nazivproizvod;
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
                parameter.ParameterName = "nazivproizvod";
                parameter.DbType = DbType.String;
                this.fillDataParameters = new DbParameter[] { parameter };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount(string nazivproizvod)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            string str = " WHERE T1.[NAZIVPROIZVOD] like '%' + @nazivproizvod + '%'";
            this.scmdbuf = "SELECT COUNT(*) FROM (([PROIZVOD] T1 INNER JOIN [JEDINICAMJERE] T2 ON T2.[IDJEDINICAMJERE] = T1.[IDJEDINICAMJERE]) INNER JOIN [FINPOREZ] T3 ON T3.[FINPOREZIDPOREZ] = T1.[FINPOREZIDPOREZ])" + str + "  ";
            this.cmPROIZVODSelect1 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmPROIZVODSelect1.IDbCommand.Parameters.Count == 0)
            {
                this.cmPROIZVODSelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@nazivproizvod", DbType.String, 500));
            }
            this.lV8nazivpr = StringUtil.PadRight(StringUtil.RTrim(nazivproizvod), 500, "%");
            this.cmPROIZVODSelect1.SetParameter(0, this.lV8nazivpr);
            this.cmPROIZVODSelect1.ErrorMask |= ErrorMask.Lock;
            this.PROIZVODSelect1 = this.cmPROIZVODSelect1.FetchData();
            if (this.PROIZVODSelect1.IsDBNull(0))
            {
                this.m_RecordCount = 0;
            }
            else
            {
                this.m_RecordCount = this.PROIZVODSelect1.GetInt32(0);
            }
            this.PROIZVODSelect1.Close();
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

        public virtual int GetRecordCount(string nazivproizvod)
        {
            int internalRecordCount;
            try
            {
                this.SetFillParameters(nazivproizvod);
                internalRecordCount = this.GetInternalRecordCount(nazivproizvod);
            }
            finally
            {
                this.Cleanup();
            }
            return internalRecordCount;
        }

        private void Init_order_Proizvod()
        {
            this.Order = new ArrayList();
        }

        private void Initialize()
        {
            this.resourceManager = Deklarit.Utils.ResourceManager.Instance;
            this.resourceManagerTables = new System.Resources.ResourceManager("Tables", Assembly.GetExecutingAssembly());
            this.AV8nazivpr = "";
            this.scmdbuf = "";
            this.m_WhereString = "";
            this.lV8nazivpr = "";
            this.m_RecordCount = 0;
            this.sWhereSep = "";
            this.m_TopRowCount = 0;
            this.m__IDPROIZVODIsNull = false;
            this.m_IDPROIZVOD = 0;
            this.m__NAZIVPROIZVODIsNull = false;
            this.m_NAZIVPROIZVOD = "";
            this.m__CIJENAIsNull = false;
            this.m_CIJENA = new decimal();
            this.m__FINPOREZIDPOREZIsNull = false;
            this.m_FINPOREZIDPOREZ = 0;
            this.m__FINPOREZSTOPAIsNull = false;
            this.m_FINPOREZSTOPA = new decimal();
            this.m__IDJEDINICAMJEREIsNull = false;
            this.m_IDJEDINICAMJERE = 0;
            this.m__NAZIVJEDINICAMJEREIsNull = false;
            this.m_NAZIVJEDINICAMJERE = "";
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void SetFillParameters(string nazivproizvod)
        {
            if (this.fillDataParameters == null)
            {
                this.GetFillParameters();
                this.fillDataParameters[0].Value = nazivproizvod;
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

        string Placa.Itrazi_proizvodDataAdapter.Filter
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
            IDPROIZVOD,
            NAZIVPROIZVOD,
            CIJENA,
            FINPOREZIDPOREZ,
            FINPOREZSTOPA,
            IDJEDINICAMJERE,
            NAZIVJEDINICAMJERE
        }

        public class OrderAttribute
        {
            public bool OrderAttributeAscending;
            public trazi_proizvodDataAdapter.Attribute OrderAttributeName;
            public string OrderAttributeString;

            public OrderAttribute(trazi_proizvodDataAdapter.Attribute orderAttributeName)
            {
                this.OrderAttributeName = orderAttributeName;
                this.OrderAttributeAscending = true;
                this.OrderAttributeString = trazi_proizvodDataAdapter.attributeNames[(int) this.OrderAttributeName];
            }

            public OrderAttribute(trazi_proizvodDataAdapter.Attribute orderAttributeName, bool orderAttributeAscending)
            {
                this.OrderAttributeName = orderAttributeName;
                this.OrderAttributeAscending = orderAttributeAscending;
                this.OrderAttributeString = trazi_proizvodDataAdapter.attributeNames[(int) this.OrderAttributeName];
            }
        }
    }
}


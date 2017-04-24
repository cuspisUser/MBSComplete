namespace Placa
{
    using Deklarit.Data;
    using Deklarit.Utils;
    using System;
    using System.Data;
    using System.Data.Common;
    using System.Reflection;
    using System.Resources;
    using System.Runtime.CompilerServices;
    using System.Threading;

    public class S_OD_REKAP_POREZDataAdapter : IDataAdapter, IS_OD_REKAP_POREZDataAdapter
    {
        private string AV8IDOBRAC;
        private ReadWriteCommand cmS_OD_REKAP_POREZSelect1;
        private ReadWriteCommand cmS_OD_REKAP_POREZSelect2;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        private DbParameter[] fillDataParameters;
        private int m_RecordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private S_OD_REKAP_POREZDataSet.S_OD_REKAP_POREZRow rowS_OD_REKAP_POREZ;
        private IDataReader S_OD_REKAP_POREZSelect1;
        private IDataReader S_OD_REKAP_POREZSelect2;
        private S_OD_REKAP_POREZDataSet S_OD_REKAP_POREZSet;

        private void AddRowS_od_rekap_porez()
        {
            this.S_OD_REKAP_POREZSet.S_OD_REKAP_POREZ.AddS_OD_REKAP_POREZRow(this.rowS_OD_REKAP_POREZ);
            this.rowS_OD_REKAP_POREZ.AcceptChanges();
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        public void executePrivate(int startRow, int maxRows)
        {
            this.cmS_OD_REKAP_POREZSelect2 = this.connDefault.GetCommand("S_PLACA_POREZ", true);
            this.cmS_OD_REKAP_POREZSelect2.IDbCommand.CommandType = CommandType.StoredProcedure;
            this.cmS_OD_REKAP_POREZSelect2.IDbCommand.Parameters.Clear();
            this.cmS_OD_REKAP_POREZSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOBRACUN", this.AV8IDOBRAC));
            this.cmS_OD_REKAP_POREZSelect2.ErrorMask |= ErrorMask.Lock;
            this.S_OD_REKAP_POREZSelect2 = this.cmS_OD_REKAP_POREZSelect2.FetchData();
            while (this.cmS_OD_REKAP_POREZSelect2.HasMoreRows && (startRow > 0))
            {
                startRow--;
                this.cmS_OD_REKAP_POREZSelect2.HasMoreRows = this.S_OD_REKAP_POREZSelect2.Read();
            }
            int num = 0;
            while (this.cmS_OD_REKAP_POREZSelect2.HasMoreRows && (num != maxRows))
            {
                this.rowS_OD_REKAP_POREZ["SIFRA"] = RuntimeHelpers.GetObjectValue(this.S_OD_REKAP_POREZSelect2["SIFRA"]);
                this.rowS_OD_REKAP_POREZ["SIFRAOPCINESTANOVANJA"] = RuntimeHelpers.GetObjectValue(this.S_OD_REKAP_POREZSelect2["SIFRAOPCINESTANOVANJA"]);
                this.rowS_OD_REKAP_POREZ["NAZIVOPCINE"] = RuntimeHelpers.GetObjectValue(this.S_OD_REKAP_POREZSelect2["NAZIVOPCINE"]);
                this.rowS_OD_REKAP_POREZ["OBRACUNATO"] = RuntimeHelpers.GetObjectValue(this.S_OD_REKAP_POREZSelect2["OBRACUNATO"]);
                this.rowS_OD_REKAP_POREZ["STOPA"] = RuntimeHelpers.GetObjectValue(this.S_OD_REKAP_POREZSelect2["STOPA"]);
                this.rowS_OD_REKAP_POREZ["OSNOVICa"] = RuntimeHelpers.GetObjectValue(this.S_OD_REKAP_POREZSelect2["OSNOVICA"]);
                this.rowS_OD_REKAP_POREZ["POREZOPIS"] = RuntimeHelpers.GetObjectValue(this.S_OD_REKAP_POREZSelect2["POREZOPIS"]);
                this.AddRowS_od_rekap_porez();
                num++;
                this.rowS_OD_REKAP_POREZ = this.S_OD_REKAP_POREZSet.S_OD_REKAP_POREZ.NewS_OD_REKAP_POREZRow();
                this.cmS_OD_REKAP_POREZSelect2.HasMoreRows = this.S_OD_REKAP_POREZSelect2.Read();
            }
            this.S_OD_REKAP_POREZSelect2.Close();
            this.Cleanup();
        }

        public virtual int Fill(S_OD_REKAP_POREZDataSet dataSet)
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
            this.S_OD_REKAP_POREZSet = (S_OD_REKAP_POREZDataSet) dataSet;
            if (this.S_OD_REKAP_POREZSet != null)
            {
                return this.Fill(this.S_OD_REKAP_POREZSet);
            }
            this.S_OD_REKAP_POREZSet = new S_OD_REKAP_POREZDataSet();
            this.Fill(this.S_OD_REKAP_POREZSet);
            dataSet.Merge(this.S_OD_REKAP_POREZSet);
            return 0;
        }

        public virtual int Fill(S_OD_REKAP_POREZDataSet dataSet, string iDOBRACUN)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.S_OD_REKAP_POREZSet = dataSet;
            this.rowS_OD_REKAP_POREZ = this.S_OD_REKAP_POREZSet.S_OD_REKAP_POREZ.NewS_OD_REKAP_POREZRow();
            this.SetFillParameters(iDOBRACUN);
            this.AV8IDOBRAC = iDOBRACUN;
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

        public virtual int FillPage(S_OD_REKAP_POREZDataSet dataSet, int startRow, int maxRows)
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
            this.S_OD_REKAP_POREZSet = (S_OD_REKAP_POREZDataSet) dataSet;
            if (this.S_OD_REKAP_POREZSet != null)
            {
                return this.FillPage(this.S_OD_REKAP_POREZSet, startRow, maxRows);
            }
            this.S_OD_REKAP_POREZSet = new S_OD_REKAP_POREZDataSet();
            this.FillPage(this.S_OD_REKAP_POREZSet, startRow, maxRows);
            dataSet.Merge(this.S_OD_REKAP_POREZSet);
            return 0;
        }

        public virtual int FillPage(S_OD_REKAP_POREZDataSet dataSet, string iDOBRACUN, int startRow, int maxRows)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.S_OD_REKAP_POREZSet = dataSet;
            this.rowS_OD_REKAP_POREZ = this.S_OD_REKAP_POREZSet.S_OD_REKAP_POREZ.NewS_OD_REKAP_POREZRow();
            this.SetFillParameters(iDOBRACUN);
            this.AV8IDOBRAC = iDOBRACUN;
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

        public virtual IDataParameter[] GetFillParameters()
        {
            if (this.fillDataParameters == null)
            {
                DbParameter parameter = DbProviderFactories.GetFactory("System.Data.SqlClient").CreateParameter();
                parameter.ParameterName = "IDOBRACUN";
                parameter.DbType = DbType.String;
                this.fillDataParameters = new DbParameter[] { parameter };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount(string iDOBRACUN)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmS_OD_REKAP_POREZSelect1 = this.connDefault.GetCommand("S_PLACA_POREZ", true);
            this.cmS_OD_REKAP_POREZSelect1.IDbCommand.CommandType = CommandType.StoredProcedure;
            this.cmS_OD_REKAP_POREZSelect1.IDbCommand.Parameters.Clear();
            this.cmS_OD_REKAP_POREZSelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOBRACUN", iDOBRACUN));
            this.cmS_OD_REKAP_POREZSelect1.ErrorMask |= ErrorMask.Lock;
            this.S_OD_REKAP_POREZSelect1 = this.cmS_OD_REKAP_POREZSelect1.FetchData();
            if (this.S_OD_REKAP_POREZSelect1.IsDBNull(0))
            {
                this.m_RecordCount = 0;
            }
            else
            {
                this.m_RecordCount = this.S_OD_REKAP_POREZSelect1.GetInt32(0);
            }
            this.S_OD_REKAP_POREZSelect1.Close();
            return this.m_RecordCount;
        }

        public virtual int GetRecordCount(string iDOBRACUN)
        {
            int internalRecordCount;
            try
            {
                this.SetFillParameters(iDOBRACUN);
                internalRecordCount = this.GetInternalRecordCount(iDOBRACUN);
            }
            finally
            {
                this.Cleanup();
            }
            return internalRecordCount;
        }

        private void Initialize()
        {
            this.resourceManager = Deklarit.Utils.ResourceManager.Instance;
            this.resourceManagerTables = new System.Resources.ResourceManager("Tables", Assembly.GetExecutingAssembly());
            this.AV8IDOBRAC = "";
            this.m_RecordCount = 0;
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void SetFillParameters(string iDOBRACUN)
        {
            if (this.fillDataParameters == null)
            {
                this.GetFillParameters();
                this.fillDataParameters[0].Value = iDOBRACUN;
            }
        }

        public virtual int Update(DataSet dataSet)
        {
            throw new InvalidOperationException();
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
    }
}


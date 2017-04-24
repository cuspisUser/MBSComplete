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

    public class S_OD_KREDIT_OBRACUNATDataAdapter : IDataAdapter, IS_OD_KREDIT_OBRACUNATDataAdapter
    {
        private string AV8IDOBRAC;
        private ReadWriteCommand cmS_OD_KREDIT_OBRACUNATSelect1;
        private ReadWriteCommand cmS_OD_KREDIT_OBRACUNATSelect2;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        private DbParameter[] fillDataParameters;
        private int m_RecordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private S_OD_KREDIT_OBRACUNATDataSet.S_OD_KREDIT_OBRACUNATRow rowS_OD_KREDIT_OBRACUNAT;
        private IDataReader S_OD_KREDIT_OBRACUNATSelect1;
        private IDataReader S_OD_KREDIT_OBRACUNATSelect2;
        private S_OD_KREDIT_OBRACUNATDataSet S_OD_KREDIT_OBRACUNATSet;

        private void AddRowS_od_kredit_obracunat()
        {
            this.S_OD_KREDIT_OBRACUNATSet.S_OD_KREDIT_OBRACUNAT.AddS_OD_KREDIT_OBRACUNATRow(this.rowS_OD_KREDIT_OBRACUNAT);
            this.rowS_OD_KREDIT_OBRACUNAT.AcceptChanges();
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        public void executePrivate(int startRow, int maxRows)
        {
            this.cmS_OD_KREDIT_OBRACUNATSelect2 = this.connDefault.GetCommand("S_PLACA_KREDIT_OBRACUNAT", true);
            this.cmS_OD_KREDIT_OBRACUNATSelect2.IDbCommand.CommandType = CommandType.StoredProcedure;
            this.cmS_OD_KREDIT_OBRACUNATSelect2.IDbCommand.Parameters.Clear();
            this.cmS_OD_KREDIT_OBRACUNATSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOBRACUN", this.AV8IDOBRAC));
            this.cmS_OD_KREDIT_OBRACUNATSelect2.ErrorMask |= ErrorMask.Lock;
            this.S_OD_KREDIT_OBRACUNATSelect2 = this.cmS_OD_KREDIT_OBRACUNATSelect2.FetchData();
            while (this.cmS_OD_KREDIT_OBRACUNATSelect2.HasMoreRows && (startRow > 0))
            {
                startRow--;
                this.cmS_OD_KREDIT_OBRACUNATSelect2.HasMoreRows = this.S_OD_KREDIT_OBRACUNATSelect2.Read();
            }
            int num = 0;
            while (this.cmS_OD_KREDIT_OBRACUNATSelect2.HasMoreRows && (num != maxRows))
            {
                this.rowS_OD_KREDIT_OBRACUNAT["OBRACUNATO"] = RuntimeHelpers.GetObjectValue(this.S_OD_KREDIT_OBRACUNATSelect2["OBRACUNATO"]);
                this.rowS_OD_KREDIT_OBRACUNAT["IDRADNIK"] = RuntimeHelpers.GetObjectValue(this.S_OD_KREDIT_OBRACUNATSelect2["IDRADNIK"]);
                this.rowS_OD_KREDIT_OBRACUNAT["IDKREDITOR"] = RuntimeHelpers.GetObjectValue(this.S_OD_KREDIT_OBRACUNATSelect2["IDKREDITOR"]);
                this.rowS_OD_KREDIT_OBRACUNAT["DATUMUGOVORA"] = RuntimeHelpers.GetObjectValue(this.S_OD_KREDIT_OBRACUNATSelect2["DATUMUGOVORA"]);
                this.AddRowS_od_kredit_obracunat();
                num++;
                this.rowS_OD_KREDIT_OBRACUNAT = this.S_OD_KREDIT_OBRACUNATSet.S_OD_KREDIT_OBRACUNAT.NewS_OD_KREDIT_OBRACUNATRow();
                this.cmS_OD_KREDIT_OBRACUNATSelect2.HasMoreRows = this.S_OD_KREDIT_OBRACUNATSelect2.Read();
            }
            this.S_OD_KREDIT_OBRACUNATSelect2.Close();
            this.Cleanup();
        }

        public virtual int Fill(S_OD_KREDIT_OBRACUNATDataSet dataSet)
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
            this.S_OD_KREDIT_OBRACUNATSet = (S_OD_KREDIT_OBRACUNATDataSet) dataSet;
            if (this.S_OD_KREDIT_OBRACUNATSet != null)
            {
                return this.Fill(this.S_OD_KREDIT_OBRACUNATSet);
            }
            this.S_OD_KREDIT_OBRACUNATSet = new S_OD_KREDIT_OBRACUNATDataSet();
            this.Fill(this.S_OD_KREDIT_OBRACUNATSet);
            dataSet.Merge(this.S_OD_KREDIT_OBRACUNATSet);
            return 0;
        }

        public virtual int Fill(S_OD_KREDIT_OBRACUNATDataSet dataSet, string iDOBRACUN)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.S_OD_KREDIT_OBRACUNATSet = dataSet;
            this.rowS_OD_KREDIT_OBRACUNAT = this.S_OD_KREDIT_OBRACUNATSet.S_OD_KREDIT_OBRACUNAT.NewS_OD_KREDIT_OBRACUNATRow();
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

        public virtual int FillPage(S_OD_KREDIT_OBRACUNATDataSet dataSet, int startRow, int maxRows)
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
            this.S_OD_KREDIT_OBRACUNATSet = (S_OD_KREDIT_OBRACUNATDataSet) dataSet;
            if (this.S_OD_KREDIT_OBRACUNATSet != null)
            {
                return this.FillPage(this.S_OD_KREDIT_OBRACUNATSet, startRow, maxRows);
            }
            this.S_OD_KREDIT_OBRACUNATSet = new S_OD_KREDIT_OBRACUNATDataSet();
            this.FillPage(this.S_OD_KREDIT_OBRACUNATSet, startRow, maxRows);
            dataSet.Merge(this.S_OD_KREDIT_OBRACUNATSet);
            return 0;
        }

        public virtual int FillPage(S_OD_KREDIT_OBRACUNATDataSet dataSet, string iDOBRACUN, int startRow, int maxRows)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.S_OD_KREDIT_OBRACUNATSet = dataSet;
            this.rowS_OD_KREDIT_OBRACUNAT = this.S_OD_KREDIT_OBRACUNATSet.S_OD_KREDIT_OBRACUNAT.NewS_OD_KREDIT_OBRACUNATRow();
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
            this.cmS_OD_KREDIT_OBRACUNATSelect1 = this.connDefault.GetCommand("S_PLACA_KREDIT_OBRACUNAT", true);
            this.cmS_OD_KREDIT_OBRACUNATSelect1.IDbCommand.CommandType = CommandType.StoredProcedure;
            this.cmS_OD_KREDIT_OBRACUNATSelect1.IDbCommand.Parameters.Clear();
            this.cmS_OD_KREDIT_OBRACUNATSelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOBRACUN", iDOBRACUN));
            this.cmS_OD_KREDIT_OBRACUNATSelect1.ErrorMask |= ErrorMask.Lock;
            this.S_OD_KREDIT_OBRACUNATSelect1 = this.cmS_OD_KREDIT_OBRACUNATSelect1.FetchData();
            if (this.S_OD_KREDIT_OBRACUNATSelect1.IsDBNull(0))
            {
                this.m_RecordCount = 0;
            }
            else
            {
                this.m_RecordCount = this.S_OD_KREDIT_OBRACUNATSelect1.GetInt32(0);
            }
            this.S_OD_KREDIT_OBRACUNATSelect1.Close();
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


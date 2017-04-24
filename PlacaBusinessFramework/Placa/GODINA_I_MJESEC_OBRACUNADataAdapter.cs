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

    public class GODINA_I_MJESEC_OBRACUNADataAdapter : IDataAdapter, IGODINA_I_MJESEC_OBRACUNADataAdapter
    {
        private ReadWriteCommand cmGODINA_I_MJESEC_OBRACUNASelect1;
        private ReadWriteCommand cmGODINA_I_MJESEC_OBRACUNASelect2;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        private DbParameter[] fillDataParameters;
        private IDataReader GODINA_I_MJESEC_OBRACUNASelect1;
        private IDataReader GODINA_I_MJESEC_OBRACUNASelect2;
        private GODINA_I_MJESEC_OBRACUNADataSet GODINA_I_MJESEC_OBRACUNASet;
        private int m_RecordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private GODINA_I_MJESEC_OBRACUNADataSet.GODINA_I_MJESEC_OBRACUNARow rowGODINA_I_MJESEC_OBRACUNA;

        private void AddRowGodina_i_mjesec_obracuna()
        {
            this.GODINA_I_MJESEC_OBRACUNASet.GODINA_I_MJESEC_OBRACUNA.AddGODINA_I_MJESEC_OBRACUNARow(this.rowGODINA_I_MJESEC_OBRACUNA);
            this.rowGODINA_I_MJESEC_OBRACUNA.AcceptChanges();
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        public void executePrivate(int startRow, int maxRows)
        {
            this.cmGODINA_I_MJESEC_OBRACUNASelect2 = this.connDefault.GetCommand("S_PLACA_GOD_MJE_OBR", true);
            this.cmGODINA_I_MJESEC_OBRACUNASelect2.IDbCommand.CommandType = CommandType.StoredProcedure;
            this.cmGODINA_I_MJESEC_OBRACUNASelect2.IDbCommand.Parameters.Clear();
            this.cmGODINA_I_MJESEC_OBRACUNASelect2.ErrorMask |= ErrorMask.Lock;
            this.GODINA_I_MJESEC_OBRACUNASelect2 = this.cmGODINA_I_MJESEC_OBRACUNASelect2.FetchData();
            while (this.cmGODINA_I_MJESEC_OBRACUNASelect2.HasMoreRows && (startRow > 0))
            {
                startRow--;
                this.cmGODINA_I_MJESEC_OBRACUNASelect2.HasMoreRows = this.GODINA_I_MJESEC_OBRACUNASelect2.Read();
            }
            int num = 0;
            while (this.cmGODINA_I_MJESEC_OBRACUNASelect2.HasMoreRows && (num != maxRows))
            {
                this.rowGODINA_I_MJESEC_OBRACUNA["GODINAIMJESECOBRACUNA"] = RuntimeHelpers.GetObjectValue(this.GODINA_I_MJESEC_OBRACUNASelect2["GODINAIMJESECOBRACUNA"]);
                this.AddRowGodina_i_mjesec_obracuna();
                num++;
                this.rowGODINA_I_MJESEC_OBRACUNA = this.GODINA_I_MJESEC_OBRACUNASet.GODINA_I_MJESEC_OBRACUNA.NewGODINA_I_MJESEC_OBRACUNARow();
                this.cmGODINA_I_MJESEC_OBRACUNASelect2.HasMoreRows = this.GODINA_I_MJESEC_OBRACUNASelect2.Read();
            }
            this.GODINA_I_MJESEC_OBRACUNASelect2.Close();
            this.Cleanup();
        }

        public virtual int Fill(GODINA_I_MJESEC_OBRACUNADataSet dataSet)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.GODINA_I_MJESEC_OBRACUNASet = dataSet;
            this.rowGODINA_I_MJESEC_OBRACUNA = this.GODINA_I_MJESEC_OBRACUNASet.GODINA_I_MJESEC_OBRACUNA.NewGODINA_I_MJESEC_OBRACUNARow();
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
            this.GODINA_I_MJESEC_OBRACUNASet = (GODINA_I_MJESEC_OBRACUNADataSet) dataSet;
            if (this.GODINA_I_MJESEC_OBRACUNASet != null)
            {
                return this.Fill(this.GODINA_I_MJESEC_OBRACUNASet);
            }
            this.GODINA_I_MJESEC_OBRACUNASet = new GODINA_I_MJESEC_OBRACUNADataSet();
            this.Fill(this.GODINA_I_MJESEC_OBRACUNASet);
            dataSet.Merge(this.GODINA_I_MJESEC_OBRACUNASet);
            return 0;
        }

        public virtual int FillPage(GODINA_I_MJESEC_OBRACUNADataSet dataSet, int startRow, int maxRows)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.GODINA_I_MJESEC_OBRACUNASet = dataSet;
            this.rowGODINA_I_MJESEC_OBRACUNA = this.GODINA_I_MJESEC_OBRACUNASet.GODINA_I_MJESEC_OBRACUNA.NewGODINA_I_MJESEC_OBRACUNARow();
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
            this.GODINA_I_MJESEC_OBRACUNASet = (GODINA_I_MJESEC_OBRACUNADataSet) dataSet;
            if (this.GODINA_I_MJESEC_OBRACUNASet != null)
            {
                return this.FillPage(this.GODINA_I_MJESEC_OBRACUNASet, startRow, maxRows);
            }
            this.GODINA_I_MJESEC_OBRACUNASet = new GODINA_I_MJESEC_OBRACUNADataSet();
            this.FillPage(this.GODINA_I_MJESEC_OBRACUNASet, startRow, maxRows);
            dataSet.Merge(this.GODINA_I_MJESEC_OBRACUNASet);
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
                DbProviderFactory factory = DbProviderFactories.GetFactory("System.Data.SqlClient");
                this.fillDataParameters = new DbParameter[0];
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount()
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmGODINA_I_MJESEC_OBRACUNASelect1 = this.connDefault.GetCommand("S_PLACA_GOD_MJE_OBR", true);
            this.cmGODINA_I_MJESEC_OBRACUNASelect1.IDbCommand.CommandType = CommandType.StoredProcedure;
            this.cmGODINA_I_MJESEC_OBRACUNASelect1.IDbCommand.Parameters.Clear();
            this.cmGODINA_I_MJESEC_OBRACUNASelect1.ErrorMask |= ErrorMask.Lock;
            this.GODINA_I_MJESEC_OBRACUNASelect1 = this.cmGODINA_I_MJESEC_OBRACUNASelect1.FetchData();
            if (this.GODINA_I_MJESEC_OBRACUNASelect1.IsDBNull(0))
            {
                this.m_RecordCount = 0;
            }
            else
            {
                this.m_RecordCount = this.GODINA_I_MJESEC_OBRACUNASelect1.GetInt32(0);
            }
            this.GODINA_I_MJESEC_OBRACUNASelect1.Close();
            return this.m_RecordCount;
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

        private void Initialize()
        {
            this.resourceManager = Deklarit.Utils.ResourceManager.Instance;
            this.resourceManagerTables = new System.Resources.ResourceManager("Tables", Assembly.GetExecutingAssembly());
            this.m_RecordCount = 0;
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
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


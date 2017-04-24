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

    public class S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMADataAdapter : IDataAdapter, IS_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMADataAdapter
    {
        private string AV8IDOBRAC;
        private ReadWriteCommand cmS_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMASelect1;
        private ReadWriteCommand cmS_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMASelect2;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        private DbParameter[] fillDataParameters;
        private int m_RecordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMADataSet.S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMARow rowS_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMA;
        private IDataReader S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMASelect1;
        private IDataReader S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMASelect2;
        private S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMADataSet S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMASet;

        private void AddRowS_placa_konacni_porez_rekapitulacija_po_radnicima()
        {
            this.S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMASet.S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMA.AddS_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMARow(this.rowS_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMA);
            this.rowS_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMA.AcceptChanges();
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        public void executePrivate(int startRow, int maxRows)
        {
            this.cmS_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMASelect2 = this.connDefault.GetCommand("S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMA", true);
            this.cmS_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMASelect2.IDbCommand.CommandType = CommandType.StoredProcedure;
            this.cmS_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMASelect2.IDbCommand.Parameters.Clear();
            this.cmS_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMASelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOBRACUN", this.AV8IDOBRAC));
            this.cmS_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMASelect2.ErrorMask |= ErrorMask.Lock;
            this.S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMASelect2 = this.cmS_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMASelect2.FetchData();
            while (this.cmS_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMASelect2.HasMoreRows && (startRow > 0))
            {
                startRow--;
                this.cmS_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMASelect2.HasMoreRows = this.S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMASelect2.Read();
            }
            int num = 0;
            while (this.cmS_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMASelect2.HasMoreRows && (num != maxRows))
            {
                this.rowS_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMA["PREZIME"] = RuntimeHelpers.GetObjectValue(this.S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMASelect2["PREZIME"]);
                this.rowS_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMA["IME"] = RuntimeHelpers.GetObjectValue(this.S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMASelect2["IME"]);
                this.rowS_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMA["SIFRAOPCINESTANOVANJA"] = RuntimeHelpers.GetObjectValue(this.S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMASelect2["SIFRAOPCINESTANOVANJA"]);
                this.rowS_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMA["NAZIVOPCINE"] = RuntimeHelpers.GetObjectValue(this.S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMASelect2["NAZIVOPCINE"]);
                this.rowS_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMA["KOREKCIJAPOREZA"] = RuntimeHelpers.GetObjectValue(this.S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMASelect2["KOREKCIJAPOREZA"]);
                this.rowS_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMA["KOREKCIJAPRIREZ"] = RuntimeHelpers.GetObjectValue(this.S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMASelect2["KOREKCIJAPRIREZ"]);
                this.rowS_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMA["ORIGINALPOREZ"] = RuntimeHelpers.GetObjectValue(this.S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMASelect2["ORIGINALPOREZ"]);
                this.rowS_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMA["ORIGINALPRIREZ"] = RuntimeHelpers.GetObjectValue(this.S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMASelect2["ORIGINALPRIREZ"]);
                this.rowS_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMA["IDRADNIK"] = RuntimeHelpers.GetObjectValue(this.S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMASelect2["IDRADNIK"]);
                this.AddRowS_placa_konacni_porez_rekapitulacija_po_radnicima();
                num++;
                this.rowS_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMA = this.S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMASet.S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMA.NewS_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMARow();
                this.cmS_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMASelect2.HasMoreRows = this.S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMASelect2.Read();
            }
            this.S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMASelect2.Close();
            this.Cleanup();
        }

        public virtual int Fill(S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMADataSet dataSet)
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
            this.S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMASet = (S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMADataSet) dataSet;
            if (this.S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMASet != null)
            {
                return this.Fill(this.S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMASet);
            }
            this.S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMASet = new S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMADataSet();
            this.Fill(this.S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMASet);
            dataSet.Merge(this.S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMASet);
            return 0;
        }

        public virtual int Fill(S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMADataSet dataSet, string iDOBRACUN)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMASet = dataSet;
            this.rowS_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMA = this.S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMASet.S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMA.NewS_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMARow();
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

        public virtual int FillPage(S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMADataSet dataSet, int startRow, int maxRows)
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
            this.S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMASet = (S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMADataSet) dataSet;
            if (this.S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMASet != null)
            {
                return this.FillPage(this.S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMASet, startRow, maxRows);
            }
            this.S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMASet = new S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMADataSet();
            this.FillPage(this.S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMASet, startRow, maxRows);
            dataSet.Merge(this.S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMASet);
            return 0;
        }

        public virtual int FillPage(S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMADataSet dataSet, string iDOBRACUN, int startRow, int maxRows)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMASet = dataSet;
            this.rowS_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMA = this.S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMASet.S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMA.NewS_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMARow();
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
            this.cmS_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMASelect1 = this.connDefault.GetCommand("S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMA", true);
            this.cmS_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMASelect1.IDbCommand.CommandType = CommandType.StoredProcedure;
            this.cmS_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMASelect1.IDbCommand.Parameters.Clear();
            this.cmS_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMASelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOBRACUN", iDOBRACUN));
            this.cmS_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMASelect1.ErrorMask |= ErrorMask.Lock;
            this.S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMASelect1 = this.cmS_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMASelect1.FetchData();
            if (this.S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMASelect1.IsDBNull(0))
            {
                this.m_RecordCount = 0;
            }
            else
            {
                this.m_RecordCount = this.S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMASelect1.GetInt32(0);
            }
            this.S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMASelect1.Close();
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


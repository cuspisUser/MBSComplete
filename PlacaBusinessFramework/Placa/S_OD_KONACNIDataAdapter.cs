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

    public class S_OD_KONACNIDataAdapter : IDataAdapter, IS_OD_KONACNIDataAdapter
    {
        private int AV8GODINA;
        private string AV9IDOBRAC;
        private ReadWriteCommand cmS_OD_KONACNISelect1;
        private ReadWriteCommand cmS_OD_KONACNISelect2;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        private DbParameter[] fillDataParameters;
        private int m_RecordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private S_OD_KONACNIDataSet.S_OD_KONACNIRow rowS_OD_KONACNI;
        private IDataReader S_OD_KONACNISelect1;
        private IDataReader S_OD_KONACNISelect2;
        private S_OD_KONACNIDataSet S_OD_KONACNISet;

        private void AddRowS_od_konacni()
        {
            this.S_OD_KONACNISet.S_OD_KONACNI.AddS_OD_KONACNIRow(this.rowS_OD_KONACNI);
            this.rowS_OD_KONACNI.AcceptChanges();
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        public void executePrivate(int startRow, int maxRows)
        {
            this.cmS_OD_KONACNISelect2 = this.connDefault.GetCommand("S_PLACA_KONACNI", true);
            this.cmS_OD_KONACNISelect2.IDbCommand.CommandType = CommandType.StoredProcedure;
            this.cmS_OD_KONACNISelect2.IDbCommand.Parameters.Clear();
            this.cmS_OD_KONACNISelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@GODINA", this.AV8GODINA));
            this.cmS_OD_KONACNISelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOBRACUN", this.AV9IDOBRAC));
            this.cmS_OD_KONACNISelect2.ErrorMask |= ErrorMask.Lock;
            this.S_OD_KONACNISelect2 = this.cmS_OD_KONACNISelect2.FetchData();
            while (this.cmS_OD_KONACNISelect2.HasMoreRows && (startRow > 0))
            {
                startRow--;
                this.cmS_OD_KONACNISelect2.HasMoreRows = this.S_OD_KONACNISelect2.Read();
            }
            int num = 0;
            while (this.cmS_OD_KONACNISelect2.HasMoreRows && (num != maxRows))
            {
                this.rowS_OD_KONACNI["poreznaosnovica"] = RuntimeHelpers.GetObjectValue(this.S_OD_KONACNISelect2["POREZNAOSNOVICA"]);
                this.rowS_OD_KONACNI["POREZIPRIREZ"] = RuntimeHelpers.GetObjectValue(this.S_OD_KONACNISelect2["POREZIPRIREZ"]);
                this.rowS_OD_KONACNI["OPCINA"] = RuntimeHelpers.GetObjectValue(this.S_OD_KONACNISelect2["OPCINA"]);
                this.rowS_OD_KONACNI["OIB"] = RuntimeHelpers.GetObjectValue(this.S_OD_KONACNISelect2["OIB"]);
                this.rowS_OD_KONACNI["IP"] = RuntimeHelpers.GetObjectValue(this.S_OD_KONACNISelect2["IP"]);
                this.rowS_OD_KONACNI["BROJMJESECISAISPLATAMA"] = RuntimeHelpers.GetObjectValue(this.S_OD_KONACNISelect2["BROJMJESECISAISPLATAMA"]);
                this.rowS_OD_KONACNI["STOPAPRIREZA"] = RuntimeHelpers.GetObjectValue(this.S_OD_KONACNISelect2["STOPAPRIREZA"]);
                this.rowS_OD_KONACNI["ODBITAK"] = RuntimeHelpers.GetObjectValue(this.S_OD_KONACNISelect2["ODBITAK"]);
                this.rowS_OD_KONACNI["dohodak"] = RuntimeHelpers.GetObjectValue(this.S_OD_KONACNISelect2["DOHODAK"]);
                this.rowS_OD_KONACNI["OLAKSICE"] = RuntimeHelpers.GetObjectValue(this.S_OD_KONACNISelect2["OLAKSICE"]);
                this.rowS_OD_KONACNI["BRUTO"] = RuntimeHelpers.GetObjectValue(this.S_OD_KONACNISelect2["BRUTO"]);
                this.rowS_OD_KONACNI["DOPRINOSI"] = RuntimeHelpers.GetObjectValue(this.S_OD_KONACNISelect2["DOPRINOSI"]);
                this.rowS_OD_KONACNI["FAKTOR"] = RuntimeHelpers.GetObjectValue(this.S_OD_KONACNISelect2["FAKTOR"]);
                this.rowS_OD_KONACNI["POREZ"] = RuntimeHelpers.GetObjectValue(this.S_OD_KONACNISelect2["POREZ"]);
                this.rowS_OD_KONACNI["PRIREZ"] = RuntimeHelpers.GetObjectValue(this.S_OD_KONACNISelect2["PRIREZ"]);
                this.rowS_OD_KONACNI["KRIZNIPOREZ"] = RuntimeHelpers.GetObjectValue(this.S_OD_KONACNISelect2["KRIZNIPOREZ"]);
                this.AddRowS_od_konacni();
                num++;
                this.rowS_OD_KONACNI = this.S_OD_KONACNISet.S_OD_KONACNI.NewS_OD_KONACNIRow();
                this.cmS_OD_KONACNISelect2.HasMoreRows = this.S_OD_KONACNISelect2.Read();
            }
            this.S_OD_KONACNISelect2.Close();
            this.Cleanup();
        }

        public virtual int Fill(S_OD_KONACNIDataSet dataSet)
        {
            if (this.fillDataParameters == null)
            {
                throw new ArgumentException();
            }
            this.Fill(dataSet, int.Parse(this.fillDataParameters[0].Value.ToString()), this.fillDataParameters[1].Value.ToString());
            return 0;
        }

        public virtual int Fill(DataSet dataSet)
        {
            this.S_OD_KONACNISet = (S_OD_KONACNIDataSet) dataSet;
            if (this.S_OD_KONACNISet != null)
            {
                return this.Fill(this.S_OD_KONACNISet);
            }
            this.S_OD_KONACNISet = new S_OD_KONACNIDataSet();
            this.Fill(this.S_OD_KONACNISet);
            dataSet.Merge(this.S_OD_KONACNISet);
            return 0;
        }

        public virtual int Fill(S_OD_KONACNIDataSet dataSet, int gODINA, string iDOBRACUN)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.S_OD_KONACNISet = dataSet;
            this.rowS_OD_KONACNI = this.S_OD_KONACNISet.S_OD_KONACNI.NewS_OD_KONACNIRow();
            this.SetFillParameters(gODINA, iDOBRACUN);
            this.AV8GODINA = gODINA;
            this.AV9IDOBRAC = iDOBRACUN;
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

        public virtual int FillPage(S_OD_KONACNIDataSet dataSet, int startRow, int maxRows)
        {
            if (this.fillDataParameters == null)
            {
                throw new ArgumentException();
            }
            this.FillPage(dataSet, int.Parse(this.fillDataParameters[0].Value.ToString()), this.fillDataParameters[1].Value.ToString(), startRow, maxRows);
            return 0;
        }

        public virtual int FillPage(DataSet dataSet, int startRow, int maxRows)
        {
            this.S_OD_KONACNISet = (S_OD_KONACNIDataSet) dataSet;
            if (this.S_OD_KONACNISet != null)
            {
                return this.FillPage(this.S_OD_KONACNISet, startRow, maxRows);
            }
            this.S_OD_KONACNISet = new S_OD_KONACNIDataSet();
            this.FillPage(this.S_OD_KONACNISet, startRow, maxRows);
            dataSet.Merge(this.S_OD_KONACNISet);
            return 0;
        }

        public virtual int FillPage(S_OD_KONACNIDataSet dataSet, int gODINA, string iDOBRACUN, int startRow, int maxRows)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.S_OD_KONACNISet = dataSet;
            this.rowS_OD_KONACNI = this.S_OD_KONACNISet.S_OD_KONACNI.NewS_OD_KONACNIRow();
            this.SetFillParameters(gODINA, iDOBRACUN);
            this.AV8GODINA = gODINA;
            this.AV9IDOBRAC = iDOBRACUN;
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
                DbProviderFactory factory = DbProviderFactories.GetFactory("System.Data.SqlClient");
                DbParameter parameter = factory.CreateParameter();
                parameter.ParameterName = "GODINA";
                parameter.DbType = DbType.Int32;
                DbParameter parameter2 = factory.CreateParameter();
                parameter2.ParameterName = "IDOBRACUN";
                parameter2.DbType = DbType.String;
                this.fillDataParameters = new DbParameter[] { parameter, parameter2 };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount(int gODINA, string iDOBRACUN)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmS_OD_KONACNISelect1 = this.connDefault.GetCommand("S_PLACA_KONACNI", true);
            this.cmS_OD_KONACNISelect1.IDbCommand.CommandType = CommandType.StoredProcedure;
            this.cmS_OD_KONACNISelect1.IDbCommand.Parameters.Clear();
            this.cmS_OD_KONACNISelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@GODINA", gODINA));
            this.cmS_OD_KONACNISelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOBRACUN", iDOBRACUN));
            this.cmS_OD_KONACNISelect1.ErrorMask |= ErrorMask.Lock;
            this.S_OD_KONACNISelect1 = this.cmS_OD_KONACNISelect1.FetchData();
            if (this.S_OD_KONACNISelect1.IsDBNull(0))
            {
                this.m_RecordCount = 0;
            }
            else
            {
                this.m_RecordCount = this.S_OD_KONACNISelect1.GetInt32(0);
            }
            this.S_OD_KONACNISelect1.Close();
            return this.m_RecordCount;
        }

        public virtual int GetRecordCount(int gODINA, string iDOBRACUN)
        {
            int internalRecordCount;
            try
            {
                this.SetFillParameters(gODINA, iDOBRACUN);
                internalRecordCount = this.GetInternalRecordCount(gODINA, iDOBRACUN);
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
            this.AV8GODINA = 0;
            this.AV9IDOBRAC = "";
            this.m_RecordCount = 0;
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void SetFillParameters(int gODINA, string iDOBRACUN)
        {
            if (this.fillDataParameters == null)
            {
                this.GetFillParameters();
                this.fillDataParameters[0].Value = gODINA;
                this.fillDataParameters[1].Value = iDOBRACUN;
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


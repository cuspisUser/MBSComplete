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

    public class sp_zap1DataAdapter : IDataAdapter, Isp_zap1DataAdapter
    {
        private string AV8IDOBRAC;
        private ReadWriteCommand cmsp_zap1Select1;
        private ReadWriteCommand cmsp_zap1Select2;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        private DbParameter[] fillDataParameters;
        private int m_RecordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private sp_zap1DataSet.sp_zap1Row rowsp_zap1;
        private IDataReader sp_zap1Select1;
        private IDataReader sp_zap1Select2;
        private sp_zap1DataSet sp_zap1Set;

        private void AddRowSp_zap1()
        {
            this.sp_zap1Set.sp_zap1.Addsp_zap1Row(this.rowsp_zap1);
            this.rowsp_zap1.AcceptChanges();
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        public void executePrivate(int startRow, int maxRows)
        {
            this.cmsp_zap1Select2 = this.connDefault.GetCommand("S_PLACA_ZAP1_OBRAZAC", true);
            this.cmsp_zap1Select2.IDbCommand.CommandType = CommandType.StoredProcedure;
            this.cmsp_zap1Select2.IDbCommand.Parameters.Clear();
            this.cmsp_zap1Select2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOBRACUN", this.AV8IDOBRAC));
            this.cmsp_zap1Select2.ErrorMask |= ErrorMask.Lock;
            this.sp_zap1Select2 = this.cmsp_zap1Select2.FetchData();
            while (this.cmsp_zap1Select2.HasMoreRows && (startRow > 0))
            {
                startRow--;
                this.cmsp_zap1Select2.HasMoreRows = this.sp_zap1Select2.Read();
            }
            int num = 0;
            while (this.cmsp_zap1Select2.HasMoreRows && (num != maxRows))
            {
                this.rowsp_zap1["ukupnobruto"] = RuntimeHelpers.GetObjectValue(this.sp_zap1Select2["UKUPNOBRUTO"]);
                this.rowsp_zap1["UKUPNODOPRINOSIIZ"] = RuntimeHelpers.GetObjectValue(this.sp_zap1Select2["UKUPNODOPRINOSIIZ"]);
                this.rowsp_zap1["STOPAMIOI"] = RuntimeHelpers.GetObjectValue(this.sp_zap1Select2["STOPAMIOI"]);
                this.rowsp_zap1["OSNOVICAMIOI"] = RuntimeHelpers.GetObjectValue(this.sp_zap1Select2["OSNOVICAMIOI"]);
                this.rowsp_zap1["UKUPNOMIOI"] = RuntimeHelpers.GetObjectValue(this.sp_zap1Select2["UKUPNOMIOI"]);
                this.rowsp_zap1["STOPAMIOII"] = RuntimeHelpers.GetObjectValue(this.sp_zap1Select2["STOPAMIOII"]);
                this.rowsp_zap1["OSNOVICAMIOII"] = RuntimeHelpers.GetObjectValue(this.sp_zap1Select2["OSNOVICAMIOII"]);
                this.rowsp_zap1["UKUPNOMIOII"] = RuntimeHelpers.GetObjectValue(this.sp_zap1Select2["UKUPNOMIOII"]);
                this.rowsp_zap1["UKUPNODOHODAK"] = RuntimeHelpers.GetObjectValue(this.sp_zap1Select2["UKUPNODOHODAK"]);
                this.rowsp_zap1["UKUPNOOO"] = RuntimeHelpers.GetObjectValue(this.sp_zap1Select2["UKUPNOOO"]);
                this.rowsp_zap1["ukupnoolaksice"] = RuntimeHelpers.GetObjectValue(this.sp_zap1Select2["UKUPNOOLAKSICE"]);
                this.rowsp_zap1["OSNOVICAPOREZ"] = RuntimeHelpers.GetObjectValue(this.sp_zap1Select2["OSNOVICAPOREZ"]);
                this.rowsp_zap1["UKUPNOPOREZDOFAKTOO2"] = RuntimeHelpers.GetObjectValue(this.sp_zap1Select2["UKUPNOPOREZDOFAKTOO2"]);
                this.rowsp_zap1["UKUPNOPOREZODFAKTOO2DO5"] = RuntimeHelpers.GetObjectValue(this.sp_zap1Select2["UKUPNOPOREZODFAKTOO2DO5"]);
                this.rowsp_zap1["UKUPNOPOREZODFAKTOO5"] = RuntimeHelpers.GetObjectValue(this.sp_zap1Select2["UKUPNOPOREZODFAKTOO5"]);
                this.rowsp_zap1["UKUPNOPOREZ"] = RuntimeHelpers.GetObjectValue(this.sp_zap1Select2["UKUPNOPOREZ"]);
                this.rowsp_zap1["UKUPNOPRIREZ"] = RuntimeHelpers.GetObjectValue(this.sp_zap1Select2["UKUPNOPRIREZ"]);
                this.rowsp_zap1["IZNOSPLACEIZNALOGAZAISPLATU"] = RuntimeHelpers.GetObjectValue(this.sp_zap1Select2["IZNOSPLACEIZNALOGAZAISPLATU"]);
                this.rowsp_zap1["UKUPNODOPRINOSINA"] = RuntimeHelpers.GetObjectValue(this.sp_zap1Select2["UKUPNODOPRINOSINA"]);
                this.rowsp_zap1["BROJRADNIKA"] = RuntimeHelpers.GetObjectValue(this.sp_zap1Select2["BROJRADNIKA"]);
                this.rowsp_zap1["STOPAZDRO"] = RuntimeHelpers.GetObjectValue(this.sp_zap1Select2["STOPAZDRO"]);
                this.rowsp_zap1["OSNOVICAZDRO"] = RuntimeHelpers.GetObjectValue(this.sp_zap1Select2["OSNOVICAZDRO"]);
                this.rowsp_zap1["UKUPNOZDRO"] = RuntimeHelpers.GetObjectValue(this.sp_zap1Select2["UKUPNOZDRO"]);
                this.rowsp_zap1["STOPAZDRP"] = RuntimeHelpers.GetObjectValue(this.sp_zap1Select2["STOPAZDRP"]);
                this.rowsp_zap1["OSNOVICAZDRP"] = RuntimeHelpers.GetObjectValue(this.sp_zap1Select2["OSNOVICAZDRP"]);
                this.rowsp_zap1["UKUPNOZDRP"] = RuntimeHelpers.GetObjectValue(this.sp_zap1Select2["UKUPNOZDRP"]);
                this.rowsp_zap1["STOPAZAP"] = RuntimeHelpers.GetObjectValue(this.sp_zap1Select2["STOPAZAP"]);
                this.rowsp_zap1["OSNOVICAZAP"] = RuntimeHelpers.GetObjectValue(this.sp_zap1Select2["OSNOVICAZAP"]);
                this.rowsp_zap1["UKUPNOZAP"] = RuntimeHelpers.GetObjectValue(this.sp_zap1Select2["UKUPNOZAP"]);
                this.rowsp_zap1["STOPAZAPI"] = RuntimeHelpers.GetObjectValue(this.sp_zap1Select2["STOPAZAPI"]);
                this.rowsp_zap1["OSNOVICAZAPI"] = RuntimeHelpers.GetObjectValue(this.sp_zap1Select2["OSNOVICAZAPI"]);
                this.rowsp_zap1["UKUPNOZAPI"] = RuntimeHelpers.GetObjectValue(this.sp_zap1Select2["UKUPNOZAPI"]);
                this.rowsp_zap1["BROJRACUNAZAP1"] = RuntimeHelpers.GetObjectValue(this.sp_zap1Select2["BROJRACUNAZAP1"]);
                this.AddRowSp_zap1();
                num++;
                this.rowsp_zap1 = this.sp_zap1Set.sp_zap1.Newsp_zap1Row();
                this.cmsp_zap1Select2.HasMoreRows = this.sp_zap1Select2.Read();
            }
            this.sp_zap1Select2.Close();
            this.Cleanup();
        }

        public virtual int Fill(sp_zap1DataSet dataSet)
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
            this.sp_zap1Set = (sp_zap1DataSet) dataSet;
            if (this.sp_zap1Set != null)
            {
                return this.Fill(this.sp_zap1Set);
            }
            this.sp_zap1Set = new sp_zap1DataSet();
            this.Fill(this.sp_zap1Set);
            dataSet.Merge(this.sp_zap1Set);
            return 0;
        }

        public virtual int Fill(sp_zap1DataSet dataSet, string iDOBRACUN)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.sp_zap1Set = dataSet;
            this.rowsp_zap1 = this.sp_zap1Set.sp_zap1.Newsp_zap1Row();
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

        public virtual int FillPage(sp_zap1DataSet dataSet, int startRow, int maxRows)
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
            this.sp_zap1Set = (sp_zap1DataSet) dataSet;
            if (this.sp_zap1Set != null)
            {
                return this.FillPage(this.sp_zap1Set, startRow, maxRows);
            }
            this.sp_zap1Set = new sp_zap1DataSet();
            this.FillPage(this.sp_zap1Set, startRow, maxRows);
            dataSet.Merge(this.sp_zap1Set);
            return 0;
        }

        public virtual int FillPage(sp_zap1DataSet dataSet, string iDOBRACUN, int startRow, int maxRows)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.sp_zap1Set = dataSet;
            this.rowsp_zap1 = this.sp_zap1Set.sp_zap1.Newsp_zap1Row();
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
            this.cmsp_zap1Select1 = this.connDefault.GetCommand("S_PLACA_ZAP1_OBRAZAC", true);
            this.cmsp_zap1Select1.IDbCommand.CommandType = CommandType.StoredProcedure;
            this.cmsp_zap1Select1.IDbCommand.Parameters.Clear();
            this.cmsp_zap1Select1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOBRACUN", iDOBRACUN));
            this.cmsp_zap1Select1.ErrorMask |= ErrorMask.Lock;
            this.sp_zap1Select1 = this.cmsp_zap1Select1.FetchData();
            if (this.sp_zap1Select1.IsDBNull(0))
            {
                this.m_RecordCount = 0;
            }
            else
            {
                this.m_RecordCount = this.sp_zap1Select1.GetInt32(0);
            }
            this.sp_zap1Select1.Close();
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


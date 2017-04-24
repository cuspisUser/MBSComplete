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

    public class S_FIN_DNEVNIKBLAGAJNEODDODataAdapter : IDataAdapter, IS_FIN_DNEVNIKBLAGAJNEODDODataAdapter
    {
        private int AV10VRSTA;
        private int AV11BLAG;
        private short AV12AKTIVN;
        private int AV8ODD;
        private int AV9DOO;
        private ReadWriteCommand cmS_FIN_DNEVNIKBLAGAJNEODDOSelect1;
        private ReadWriteCommand cmS_FIN_DNEVNIKBLAGAJNEODDOSelect2;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        private DbParameter[] fillDataParameters;
        private int m_RecordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private S_FIN_DNEVNIKBLAGAJNEODDODataSet.S_FIN_DNEVNIKBLAGAJNEODDORow rowS_FIN_DNEVNIKBLAGAJNEODDO;
        private IDataReader S_FIN_DNEVNIKBLAGAJNEODDOSelect1;
        private IDataReader S_FIN_DNEVNIKBLAGAJNEODDOSelect2;
        private S_FIN_DNEVNIKBLAGAJNEODDODataSet S_FIN_DNEVNIKBLAGAJNEODDOSet;

        private void AddRowS_fin_dnevnikblagajneoddo()
        {
            this.S_FIN_DNEVNIKBLAGAJNEODDOSet.S_FIN_DNEVNIKBLAGAJNEODDO.AddS_FIN_DNEVNIKBLAGAJNEODDORow(this.rowS_FIN_DNEVNIKBLAGAJNEODDO);
            this.rowS_FIN_DNEVNIKBLAGAJNEODDO.AcceptChanges();
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        public void executePrivate(int startRow, int maxRows)
        {
            this.cmS_FIN_DNEVNIKBLAGAJNEODDOSelect2 = this.connDefault.GetCommand("S_FIN_DNEVNIKBLAGAJNEOdDo", true);
            this.cmS_FIN_DNEVNIKBLAGAJNEODDOSelect2.IDbCommand.CommandType = CommandType.StoredProcedure;
            this.cmS_FIN_DNEVNIKBLAGAJNEODDOSelect2.IDbCommand.Parameters.Clear();
            this.cmS_FIN_DNEVNIKBLAGAJNEODDOSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ODD", this.AV8ODD));
            this.cmS_FIN_DNEVNIKBLAGAJNEODDOSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DOO", this.AV9DOO));
            this.cmS_FIN_DNEVNIKBLAGAJNEODDOSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@VRSTA", this.AV10VRSTA));
            this.cmS_FIN_DNEVNIKBLAGAJNEODDOSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BLAG", this.AV11BLAG));
            this.cmS_FIN_DNEVNIKBLAGAJNEODDOSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@AKTIVNAGODINA", this.AV12AKTIVN));
            this.cmS_FIN_DNEVNIKBLAGAJNEODDOSelect2.ErrorMask |= ErrorMask.Lock;
            this.S_FIN_DNEVNIKBLAGAJNEODDOSelect2 = this.cmS_FIN_DNEVNIKBLAGAJNEODDOSelect2.FetchData();
            while (this.cmS_FIN_DNEVNIKBLAGAJNEODDOSelect2.HasMoreRows && (startRow > 0))
            {
                startRow--;
                this.cmS_FIN_DNEVNIKBLAGAJNEODDOSelect2.HasMoreRows = this.S_FIN_DNEVNIKBLAGAJNEODDOSelect2.Read();
            }
            int num = 0;
            while (this.cmS_FIN_DNEVNIKBLAGAJNEODDOSelect2.HasMoreRows && (num != maxRows))
            {
                this.rowS_FIN_DNEVNIKBLAGAJNEODDO["NAZIVVRSTEDOK"] = RuntimeHelpers.GetObjectValue(this.S_FIN_DNEVNIKBLAGAJNEODDOSelect2["NAZIVVRSTEDOK"]);
                this.rowS_FIN_DNEVNIKBLAGAJNEODDO["BLGDATUMDOKUMENTA"] = RuntimeHelpers.GetObjectValue(this.S_FIN_DNEVNIKBLAGAJNEODDOSelect2["BLGDATUMDOKUMENTA"]);
                this.rowS_FIN_DNEVNIKBLAGAJNEODDO["BLGBROJDOKUMENTA"] = RuntimeHelpers.GetObjectValue(this.S_FIN_DNEVNIKBLAGAJNEODDOSelect2["BLGBROJDOKUMENTA"]);
                this.rowS_FIN_DNEVNIKBLAGAJNEODDO["IDBLGVRSTEDOK"] = RuntimeHelpers.GetObjectValue(this.S_FIN_DNEVNIKBLAGAJNEODDOSelect2["IDBLGVRSTEDOK"]);
                this.rowS_FIN_DNEVNIKBLAGAJNEODDO["BLGSVRHA"] = RuntimeHelpers.GetObjectValue(this.S_FIN_DNEVNIKBLAGAJNEODDOSelect2["BLGSVRHA"]);
                this.rowS_FIN_DNEVNIKBLAGAJNEODDO["PRIMITAK"] = RuntimeHelpers.GetObjectValue(this.S_FIN_DNEVNIKBLAGAJNEODDOSelect2["PRIMITAK"]);
                this.rowS_FIN_DNEVNIKBLAGAJNEODDO["IZDATAK"] = RuntimeHelpers.GetObjectValue(this.S_FIN_DNEVNIKBLAGAJNEODDOSelect2["IZDATAK"]);
                this.rowS_FIN_DNEVNIKBLAGAJNEODDO["BLGSLOVIMA"] = RuntimeHelpers.GetObjectValue(this.S_FIN_DNEVNIKBLAGAJNEODDOSelect2["BLGSLOVIMA"]);
                this.rowS_FIN_DNEVNIKBLAGAJNEODDO["KONTA"] = RuntimeHelpers.GetObjectValue(this.S_FIN_DNEVNIKBLAGAJNEODDOSelect2["KONTA"]);
                this.AddRowS_fin_dnevnikblagajneoddo();
                num++;
                this.rowS_FIN_DNEVNIKBLAGAJNEODDO = this.S_FIN_DNEVNIKBLAGAJNEODDOSet.S_FIN_DNEVNIKBLAGAJNEODDO.NewS_FIN_DNEVNIKBLAGAJNEODDORow();
                this.cmS_FIN_DNEVNIKBLAGAJNEODDOSelect2.HasMoreRows = this.S_FIN_DNEVNIKBLAGAJNEODDOSelect2.Read();
            }
            this.S_FIN_DNEVNIKBLAGAJNEODDOSelect2.Close();
            this.Cleanup();
        }

        public virtual int Fill(S_FIN_DNEVNIKBLAGAJNEODDODataSet dataSet)
        {
            if (this.fillDataParameters == null)
            {
                throw new ArgumentException();
            }
            this.Fill(dataSet, int.Parse(this.fillDataParameters[0].Value.ToString()), int.Parse(this.fillDataParameters[1].Value.ToString()), int.Parse(this.fillDataParameters[2].Value.ToString()), int.Parse(this.fillDataParameters[3].Value.ToString()), short.Parse(this.fillDataParameters[4].Value.ToString()));
            return 0;
        }

        public virtual int Fill(DataSet dataSet)
        {
            this.S_FIN_DNEVNIKBLAGAJNEODDOSet = (S_FIN_DNEVNIKBLAGAJNEODDODataSet) dataSet;
            if (this.S_FIN_DNEVNIKBLAGAJNEODDOSet != null)
            {
                return this.Fill(this.S_FIN_DNEVNIKBLAGAJNEODDOSet);
            }
            this.S_FIN_DNEVNIKBLAGAJNEODDOSet = new S_FIN_DNEVNIKBLAGAJNEODDODataSet();
            this.Fill(this.S_FIN_DNEVNIKBLAGAJNEODDOSet);
            dataSet.Merge(this.S_FIN_DNEVNIKBLAGAJNEODDOSet);
            return 0;
        }

        public virtual int Fill(S_FIN_DNEVNIKBLAGAJNEODDODataSet dataSet, int oDD, int dOO, int vRSTA, int bLAG, short aKTIVNAGODINA)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.S_FIN_DNEVNIKBLAGAJNEODDOSet = dataSet;
            this.rowS_FIN_DNEVNIKBLAGAJNEODDO = this.S_FIN_DNEVNIKBLAGAJNEODDOSet.S_FIN_DNEVNIKBLAGAJNEODDO.NewS_FIN_DNEVNIKBLAGAJNEODDORow();
            this.SetFillParameters(oDD, dOO, vRSTA, bLAG, aKTIVNAGODINA);
            this.AV8ODD = oDD;
            this.AV9DOO = dOO;
            this.AV10VRSTA = vRSTA;
            this.AV11BLAG = bLAG;
            this.AV12AKTIVN = aKTIVNAGODINA;
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

        public virtual int FillPage(S_FIN_DNEVNIKBLAGAJNEODDODataSet dataSet, int startRow, int maxRows)
        {
            if (this.fillDataParameters == null)
            {
                throw new ArgumentException();
            }
            this.FillPage(dataSet, int.Parse(this.fillDataParameters[0].Value.ToString()), int.Parse(this.fillDataParameters[1].Value.ToString()), int.Parse(this.fillDataParameters[2].Value.ToString()), int.Parse(this.fillDataParameters[3].Value.ToString()), short.Parse(this.fillDataParameters[4].Value.ToString()), startRow, maxRows);
            return 0;
        }

        public virtual int FillPage(DataSet dataSet, int startRow, int maxRows)
        {
            this.S_FIN_DNEVNIKBLAGAJNEODDOSet = (S_FIN_DNEVNIKBLAGAJNEODDODataSet) dataSet;
            if (this.S_FIN_DNEVNIKBLAGAJNEODDOSet != null)
            {
                return this.FillPage(this.S_FIN_DNEVNIKBLAGAJNEODDOSet, startRow, maxRows);
            }
            this.S_FIN_DNEVNIKBLAGAJNEODDOSet = new S_FIN_DNEVNIKBLAGAJNEODDODataSet();
            this.FillPage(this.S_FIN_DNEVNIKBLAGAJNEODDOSet, startRow, maxRows);
            dataSet.Merge(this.S_FIN_DNEVNIKBLAGAJNEODDOSet);
            return 0;
        }

        public virtual int FillPage(S_FIN_DNEVNIKBLAGAJNEODDODataSet dataSet, int oDD, int dOO, int vRSTA, int bLAG, short aKTIVNAGODINA, int startRow, int maxRows)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.S_FIN_DNEVNIKBLAGAJNEODDOSet = dataSet;
            this.rowS_FIN_DNEVNIKBLAGAJNEODDO = this.S_FIN_DNEVNIKBLAGAJNEODDOSet.S_FIN_DNEVNIKBLAGAJNEODDO.NewS_FIN_DNEVNIKBLAGAJNEODDORow();
            this.SetFillParameters(oDD, dOO, vRSTA, bLAG, aKTIVNAGODINA);
            this.AV8ODD = oDD;
            this.AV9DOO = dOO;
            this.AV10VRSTA = vRSTA;
            this.AV11BLAG = bLAG;
            this.AV12AKTIVN = aKTIVNAGODINA;
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
                parameter.ParameterName = "ODD";
                parameter.DbType = DbType.Int32;
                DbParameter parameter2 = factory.CreateParameter();
                parameter2.ParameterName = "DOO";
                parameter2.DbType = DbType.Int32;
                DbParameter parameter3 = factory.CreateParameter();
                parameter3.ParameterName = "VRSTA";
                parameter3.DbType = DbType.Int32;
                DbParameter parameter4 = factory.CreateParameter();
                parameter4.ParameterName = "BLAG";
                parameter4.DbType = DbType.Int32;
                DbParameter parameter5 = factory.CreateParameter();
                parameter5.ParameterName = "AKTIVNAGODINA";
                parameter5.DbType = DbType.Int16;
                this.fillDataParameters = new DbParameter[] { parameter, parameter2, parameter3, parameter4, parameter5 };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount(int oDD, int dOO, int vRSTA, int bLAG, short aKTIVNAGODINA)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmS_FIN_DNEVNIKBLAGAJNEODDOSelect1 = this.connDefault.GetCommand("S_FIN_DNEVNIKBLAGAJNEOdDo", true);
            this.cmS_FIN_DNEVNIKBLAGAJNEODDOSelect1.IDbCommand.CommandType = CommandType.StoredProcedure;
            this.cmS_FIN_DNEVNIKBLAGAJNEODDOSelect1.IDbCommand.Parameters.Clear();
            this.cmS_FIN_DNEVNIKBLAGAJNEODDOSelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ODD", oDD));
            this.cmS_FIN_DNEVNIKBLAGAJNEODDOSelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DOO", dOO));
            this.cmS_FIN_DNEVNIKBLAGAJNEODDOSelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@VRSTA", vRSTA));
            this.cmS_FIN_DNEVNIKBLAGAJNEODDOSelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BLAG", bLAG));
            this.cmS_FIN_DNEVNIKBLAGAJNEODDOSelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@AKTIVNAGODINA", aKTIVNAGODINA));
            this.cmS_FIN_DNEVNIKBLAGAJNEODDOSelect1.ErrorMask |= ErrorMask.Lock;
            this.S_FIN_DNEVNIKBLAGAJNEODDOSelect1 = this.cmS_FIN_DNEVNIKBLAGAJNEODDOSelect1.FetchData();
            if (this.S_FIN_DNEVNIKBLAGAJNEODDOSelect1.IsDBNull(0))
            {
                this.m_RecordCount = 0;
            }
            else
            {
                this.m_RecordCount = this.S_FIN_DNEVNIKBLAGAJNEODDOSelect1.GetInt32(0);
            }
            this.S_FIN_DNEVNIKBLAGAJNEODDOSelect1.Close();
            return this.m_RecordCount;
        }

        public virtual int GetRecordCount(int oDD, int dOO, int vRSTA, int bLAG, short aKTIVNAGODINA)
        {
            int num2 = 0;
            try
            {
                this.SetFillParameters(oDD, dOO, vRSTA, bLAG, aKTIVNAGODINA);
                num2 = this.GetInternalRecordCount(oDD, dOO, vRSTA, bLAG, aKTIVNAGODINA);
            }
            finally
            {
                this.Cleanup();
            }
            return num2;
        }

        private void Initialize()
        {
            this.resourceManager = Deklarit.Utils.ResourceManager.Instance;
            this.resourceManagerTables = new System.Resources.ResourceManager("Tables", Assembly.GetExecutingAssembly());
            this.AV8ODD = 0;
            this.AV9DOO = 0;
            this.AV10VRSTA = 0;
            this.AV11BLAG = 0;
            this.AV12AKTIVN = 0;
            this.m_RecordCount = 0;
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void SetFillParameters(int oDD, int dOO, int vRSTA, int bLAG, short aKTIVNAGODINA)
        {
            if (this.fillDataParameters == null)
            {
                this.GetFillParameters();
                this.fillDataParameters[0].Value = oDD;
                this.fillDataParameters[1].Value = dOO;
                this.fillDataParameters[2].Value = vRSTA;
                this.fillDataParameters[3].Value = bLAG;
                this.fillDataParameters[4].Value = aKTIVNAGODINA;
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


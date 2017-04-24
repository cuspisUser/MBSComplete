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

    public class S_OD_BOLOVANJE_FONDDataAdapter : IDataAdapter, IS_OD_BOLOVANJE_FONDDataAdapter
    {
        private int AV10idradn;
        private string AV8ODD;
        private string AV9DOOO;
        private ReadWriteCommand cmS_OD_BOLOVANJE_FONDSelect1;
        private ReadWriteCommand cmS_OD_BOLOVANJE_FONDSelect2;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        private DbParameter[] fillDataParameters;
        private int m_RecordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private S_OD_BOLOVANJE_FONDDataSet.S_OD_BOLOVANJE_FONDRow rowS_OD_BOLOVANJE_FOND;
        private IDataReader S_OD_BOLOVANJE_FONDSelect1;
        private IDataReader S_OD_BOLOVANJE_FONDSelect2;
        private S_OD_BOLOVANJE_FONDDataSet S_OD_BOLOVANJE_FONDSet;

        private void AddRowS_od_bolovanje_fond()
        {
            this.S_OD_BOLOVANJE_FONDSet.S_OD_BOLOVANJE_FOND.AddS_OD_BOLOVANJE_FONDRow(this.rowS_OD_BOLOVANJE_FOND);
            this.rowS_OD_BOLOVANJE_FOND.AcceptChanges();
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        public void executePrivate(int startRow, int maxRows)
        {
            this.cmS_OD_BOLOVANJE_FONDSelect2 = this.connDefault.GetCommand("S_PLACA_BOLOVANJE_FOND", true);
            this.cmS_OD_BOLOVANJE_FONDSelect2.IDbCommand.CommandType = CommandType.StoredProcedure;
            this.cmS_OD_BOLOVANJE_FONDSelect2.IDbCommand.Parameters.Clear();
            this.cmS_OD_BOLOVANJE_FONDSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ODD", this.AV8ODD));
            this.cmS_OD_BOLOVANJE_FONDSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DOOO", this.AV9DOOO));
            this.cmS_OD_BOLOVANJE_FONDSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@idradnik", this.AV10idradn));
            this.cmS_OD_BOLOVANJE_FONDSelect2.ErrorMask |= ErrorMask.Lock;
            this.S_OD_BOLOVANJE_FONDSelect2 = this.cmS_OD_BOLOVANJE_FONDSelect2.FetchData();
            while (this.cmS_OD_BOLOVANJE_FONDSelect2.HasMoreRows && (startRow > 0))
            {
                startRow--;
                this.cmS_OD_BOLOVANJE_FONDSelect2.HasMoreRows = this.S_OD_BOLOVANJE_FONDSelect2.Read();
            }
            int num = 0;
            while (this.cmS_OD_BOLOVANJE_FONDSelect2.HasMoreRows && (num != maxRows))
            {
                this.rowS_OD_BOLOVANJE_FOND["IDRADNIK"] = RuntimeHelpers.GetObjectValue(this.S_OD_BOLOVANJE_FONDSelect2["IDRADNIK"]);
                this.rowS_OD_BOLOVANJE_FOND["PREZIME"] = RuntimeHelpers.GetObjectValue(this.S_OD_BOLOVANJE_FONDSelect2["PREZIME"]);
                this.rowS_OD_BOLOVANJE_FOND["IME"] = RuntimeHelpers.GetObjectValue(this.S_OD_BOLOVANJE_FONDSelect2["IME"]);
                this.rowS_OD_BOLOVANJE_FOND["JMBG"] = RuntimeHelpers.GetObjectValue(this.S_OD_BOLOVANJE_FONDSelect2["JMBG"]);
                this.rowS_OD_BOLOVANJE_FOND["MJESECOBRACUNA"] = RuntimeHelpers.GetObjectValue(this.S_OD_BOLOVANJE_FONDSelect2["MJESECOBRACUNA"]);
                this.rowS_OD_BOLOVANJE_FOND["GODINAOBRACUNA"] = RuntimeHelpers.GetObjectValue(this.S_OD_BOLOVANJE_FONDSelect2["GODINAOBRACUNA"]);
                this.rowS_OD_BOLOVANJE_FOND["KOLONA4"] = RuntimeHelpers.GetObjectValue(this.S_OD_BOLOVANJE_FONDSelect2["KOLONA4"]);
                this.rowS_OD_BOLOVANJE_FOND["KOLONA5"] = RuntimeHelpers.GetObjectValue(this.S_OD_BOLOVANJE_FONDSelect2["KOLONA5"]);
                this.rowS_OD_BOLOVANJE_FOND["KOLONA6"] = RuntimeHelpers.GetObjectValue(this.S_OD_BOLOVANJE_FONDSelect2["KOLONA6"]);
                this.rowS_OD_BOLOVANJE_FOND["KOLONA8"] = RuntimeHelpers.GetObjectValue(this.S_OD_BOLOVANJE_FONDSelect2["KOLONA8"]);
                this.rowS_OD_BOLOVANJE_FOND["SATIUKUPNO"] = RuntimeHelpers.GetObjectValue(this.S_OD_BOLOVANJE_FONDSelect2["SATIUKUPNO"]);
                this.rowS_OD_BOLOVANJE_FOND["ukupnobruto"] = RuntimeHelpers.GetObjectValue(this.S_OD_BOLOVANJE_FONDSelect2["UKUPNOBRUTO"]);
                this.rowS_OD_BOLOVANJE_FOND["netoplaca"] = RuntimeHelpers.GetObjectValue(this.S_OD_BOLOVANJE_FONDSelect2["NETOPLACA"]);
                this.rowS_OD_BOLOVANJE_FOND["FONDMJESECA"] = RuntimeHelpers.GetObjectValue(this.S_OD_BOLOVANJE_FONDSelect2["FONDMJESECA"]);
                this.rowS_OD_BOLOVANJE_FOND["OIB"] = RuntimeHelpers.GetObjectValue(this.S_OD_BOLOVANJE_FONDSelect2["OIB"]);
                this.rowS_OD_BOLOVANJE_FOND["BROJZDRAVSTVENOG"] = RuntimeHelpers.GetObjectValue(this.S_OD_BOLOVANJE_FONDSelect2["BROJZDRAVSTVENOG"]);
                this.AddRowS_od_bolovanje_fond();
                num++;
                this.rowS_OD_BOLOVANJE_FOND = this.S_OD_BOLOVANJE_FONDSet.S_OD_BOLOVANJE_FOND.NewS_OD_BOLOVANJE_FONDRow();
                this.cmS_OD_BOLOVANJE_FONDSelect2.HasMoreRows = this.S_OD_BOLOVANJE_FONDSelect2.Read();
            }
            this.S_OD_BOLOVANJE_FONDSelect2.Close();
            this.Cleanup();
        }

        public virtual int Fill(S_OD_BOLOVANJE_FONDDataSet dataSet)
        {
            if (this.fillDataParameters == null)
            {
                throw new ArgumentException();
            }
            this.Fill(dataSet, this.fillDataParameters[0].Value.ToString(), this.fillDataParameters[1].Value.ToString(), int.Parse(this.fillDataParameters[2].Value.ToString()));
            return 0;
        }

        public virtual int Fill(DataSet dataSet)
        {
            this.S_OD_BOLOVANJE_FONDSet = (S_OD_BOLOVANJE_FONDDataSet) dataSet;
            if (this.S_OD_BOLOVANJE_FONDSet != null)
            {
                return this.Fill(this.S_OD_BOLOVANJE_FONDSet);
            }
            this.S_OD_BOLOVANJE_FONDSet = new S_OD_BOLOVANJE_FONDDataSet();
            this.Fill(this.S_OD_BOLOVANJE_FONDSet);
            dataSet.Merge(this.S_OD_BOLOVANJE_FONDSet);
            return 0;
        }

        public virtual int Fill(S_OD_BOLOVANJE_FONDDataSet dataSet, string oDD, string dOOO, int idradnik)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.S_OD_BOLOVANJE_FONDSet = dataSet;
            this.rowS_OD_BOLOVANJE_FOND = this.S_OD_BOLOVANJE_FONDSet.S_OD_BOLOVANJE_FOND.NewS_OD_BOLOVANJE_FONDRow();
            this.SetFillParameters(oDD, dOOO, idradnik);
            this.AV8ODD = oDD;
            this.AV9DOOO = dOOO;
            this.AV10idradn = idradnik;
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

        public virtual int FillPage(S_OD_BOLOVANJE_FONDDataSet dataSet, int startRow, int maxRows)
        {
            if (this.fillDataParameters == null)
            {
                throw new ArgumentException();
            }
            this.FillPage(dataSet, this.fillDataParameters[0].Value.ToString(), this.fillDataParameters[1].Value.ToString(), int.Parse(this.fillDataParameters[2].Value.ToString()), startRow, maxRows);
            return 0;
        }

        public virtual int FillPage(DataSet dataSet, int startRow, int maxRows)
        {
            this.S_OD_BOLOVANJE_FONDSet = (S_OD_BOLOVANJE_FONDDataSet) dataSet;
            if (this.S_OD_BOLOVANJE_FONDSet != null)
            {
                return this.FillPage(this.S_OD_BOLOVANJE_FONDSet, startRow, maxRows);
            }
            this.S_OD_BOLOVANJE_FONDSet = new S_OD_BOLOVANJE_FONDDataSet();
            this.FillPage(this.S_OD_BOLOVANJE_FONDSet, startRow, maxRows);
            dataSet.Merge(this.S_OD_BOLOVANJE_FONDSet);
            return 0;
        }

        public virtual int FillPage(S_OD_BOLOVANJE_FONDDataSet dataSet, string oDD, string dOOO, int idradnik, int startRow, int maxRows)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.S_OD_BOLOVANJE_FONDSet = dataSet;
            this.rowS_OD_BOLOVANJE_FOND = this.S_OD_BOLOVANJE_FONDSet.S_OD_BOLOVANJE_FOND.NewS_OD_BOLOVANJE_FONDRow();
            this.SetFillParameters(oDD, dOOO, idradnik);
            this.AV8ODD = oDD;
            this.AV9DOOO = dOOO;
            this.AV10idradn = idradnik;
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
                parameter.DbType = DbType.String;
                DbParameter parameter2 = factory.CreateParameter();
                parameter2.ParameterName = "DOOO";
                parameter2.DbType = DbType.String;
                DbParameter parameter3 = factory.CreateParameter();
                parameter3.ParameterName = "idradnik";
                parameter3.DbType = DbType.Int32;
                this.fillDataParameters = new DbParameter[] { parameter, parameter2, parameter3 };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount(string oDD, string dOOO, int idradnik)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmS_OD_BOLOVANJE_FONDSelect1 = this.connDefault.GetCommand("S_PLACA_BOLOVANJE_FOND", true);
            this.cmS_OD_BOLOVANJE_FONDSelect1.IDbCommand.CommandType = CommandType.StoredProcedure;
            this.cmS_OD_BOLOVANJE_FONDSelect1.IDbCommand.Parameters.Clear();
            this.cmS_OD_BOLOVANJE_FONDSelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ODD", oDD));
            this.cmS_OD_BOLOVANJE_FONDSelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DOOO", dOOO));
            this.cmS_OD_BOLOVANJE_FONDSelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@idradnik", idradnik));
            this.cmS_OD_BOLOVANJE_FONDSelect1.ErrorMask |= ErrorMask.Lock;
            this.S_OD_BOLOVANJE_FONDSelect1 = this.cmS_OD_BOLOVANJE_FONDSelect1.FetchData();
            if (this.S_OD_BOLOVANJE_FONDSelect1.IsDBNull(0))
            {
                this.m_RecordCount = 0;
            }
            else
            {
                this.m_RecordCount = this.S_OD_BOLOVANJE_FONDSelect1.GetInt32(0);
            }
            this.S_OD_BOLOVANJE_FONDSelect1.Close();
            return this.m_RecordCount;
        }

        public virtual int GetRecordCount(string oDD, string dOOO, int idradnik)
        {
            int num2 = 0;
            try
            {
                this.SetFillParameters(oDD, dOOO, idradnik);
                num2 = this.GetInternalRecordCount(oDD, dOOO, idradnik);
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
            this.AV8ODD = "";
            this.AV9DOOO = "";
            this.AV10idradn = 0;
            this.m_RecordCount = 0;
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void SetFillParameters(string oDD, string dOOO, int idradnik)
        {
            if (this.fillDataParameters == null)
            {
                this.GetFillParameters();
                this.fillDataParameters[0].Value = oDD;
                this.fillDataParameters[1].Value = dOOO;
                this.fillDataParameters[2].Value = idradnik;
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


namespace Placa
{
    using Deklarit;
    using Deklarit.Data;
    using Deklarit.Utils;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Collections;
    using System.Data;
    using System.Data.Common;
    using System.Globalization;
    using System.Reflection;
    using System.Resources;
    using System.Runtime.CompilerServices;
    using System.Runtime.Serialization;
    using System.Threading;

    public class OSNOVAOSIGURANJADataAdapter : IDataAdapter, IOSNOVAOSIGURANJADataAdapter
    {
        private bool _Gxremove;
        private ReadWriteCommand cmOSNOVAOSIGURANJASelect1;
        private ReadWriteCommand cmOSNOVAOSIGURANJASelect2;
        private ReadWriteCommand cmOSNOVAOSIGURANJASelect9;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private DbParameter[] fillDataParameters;
        private StatementType Gx_mode;
        private object m__NAZIVOSNOVAOSIGURANJAOriginal;
        private object m__RAZDOBLJESESMIJEPREKLAPATIOriginal;
        private object m__ZAMOOIDOSNOVAOSIGURANJAOriginal;
        private readonly string m_SelectString18 = "TM1.[IDOSNOVAOSIGURANJA], TM1.[RAZDOBLJESESMIJEPREKLAPATI], TM1.[NAZIVOSNOVAOSIGURANJA], T2.[NAZIVOSNOVAOSIGURANJA] AS ZAMOONAZIVOSNOVAOSIGURANJA, TM1.[ZAMOOIDOSNOVAOSIGURANJA] AS ZAMOOIDOSNOVAOSIGURANJA";
        private string m_WhereString;
        private IDataReader OSNOVAOSIGURANJASelect1;
        private IDataReader OSNOVAOSIGURANJASelect2;
        private IDataReader OSNOVAOSIGURANJASelect9;
        private OSNOVAOSIGURANJADataSet OSNOVAOSIGURANJASet;
        private short RcdFound18;
        private int recordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private OSNOVAOSIGURANJADataSet.OSNOVAOSIGURANJARow rowOSNOVAOSIGURANJA;
        private string scmdbuf;
        private StatementType sMode18;

        public event OSNOVAOSIGURANJAUpdateEventHandler OSNOVAOSIGURANJAUpdated;

        public event OSNOVAOSIGURANJAUpdateEventHandler OSNOVAOSIGURANJAUpdating;

        private void AddRowOsnovaosiguranja()
        {
            this.OSNOVAOSIGURANJASet.OSNOVAOSIGURANJA.AddOSNOVAOSIGURANJARow(this.rowOSNOVAOSIGURANJA);
        }

        private void AfterConfirmOsnovaosiguranja()
        {
            this.OnOSNOVAOSIGURANJAUpdating(new OSNOVAOSIGURANJAEventArgs(this.rowOSNOVAOSIGURANJA, this.Gx_mode));
        }

        private void CheckDeleteErrorsOsnovaosiguranja()
        {
            ReadWriteCommand command2 = this.connDefault.GetCommand("SELECT TOP 1 [IDOSNOVAOSIGURANJA] AS ZAMOOIDOSNOVAOSIGURANJA FROM [OSNOVAOSIGURANJA] WITH (NOLOCK) WHERE [ZAMOOIDOSNOVAOSIGURANJA] = @IDOSNOVAOSIGURANJA ", false);
            if (command2.IDbCommand.Parameters.Count == 0)
            {
                command2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOSNOVAOSIGURANJA", DbType.String, 2));
            }
            command2.SetParameterString(0, RuntimeHelpers.GetObjectValue(this.rowOSNOVAOSIGURANJA["IDOSNOVAOSIGURANJA"]));
            IDataReader reader2 = command2.FetchData();
            if (command2.HasMoreRows)
            {
                reader2.Close();
                throw new OSNOVAOSIGURANJAInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "OSNOVAOSIGURANJA" }));
            }
            reader2.Close();
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT TOP 1 [IDELEMENT] FROM [ELEMENT] WITH (NOLOCK) WHERE [IDOSNOVAOSIGURANJA] = @IDOSNOVAOSIGURANJA ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOSNOVAOSIGURANJA", DbType.String, 2));
            }
            command.SetParameterString(0, RuntimeHelpers.GetObjectValue(this.rowOSNOVAOSIGURANJA["IDOSNOVAOSIGURANJA"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                reader.Close();
                throw new ELEMENTInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "ELEMENT" }));
            }
            reader.Close();
        }

        private void CheckExtendedTableOsnovaosiguranja()
        {
            if (!this.rowOSNOVAOSIGURANJA.IsZAMOOIDOSNOVAOSIGURANJANull())
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [NAZIVOSNOVAOSIGURANJA] AS ZAMOONAZIVOSNOVAOSIGURANJA FROM [OSNOVAOSIGURANJA] WITH (NOLOCK) WHERE [IDOSNOVAOSIGURANJA] = @ZAMOOIDOSNOVAOSIGURANJA ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZAMOOIDOSNOVAOSIGURANJA", DbType.String, 2));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOSNOVAOSIGURANJA["ZAMOOIDOSNOVAOSIGURANJA"]));
                IDataReader reader = command.FetchData();
                if (!command.HasMoreRows && (string.Compare("".TrimEnd(new char[] { ' ' }), StringUtil.RTrim(this.rowOSNOVAOSIGURANJA.ZAMOOIDOSNOVAOSIGURANJA).TrimEnd(new char[] { ' ' }), false, CultureInfo.CurrentCulture) != 0))
                {
                    reader.Close();
                    throw new OSNOVAOSIGURANJAForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("OSNOVAOSIGURANJA") }));
                }
                this.rowOSNOVAOSIGURANJA["ZAMOONAZIVOSNOVAOSIGURANJA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0));
                reader.Close();
            }
            else
            {
                this.rowOSNOVAOSIGURANJA["ZAMOONAZIVOSNOVAOSIGURANJA"] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }
            if (this.rowOSNOVAOSIGURANJA.IDOSNOVAOSIGURANJA.Length == 0)
            {
                throw new EmptyNotAllowedException(string.Format(this.resourceManager.GetString("notnullempty"), new object[] { "Šifra osnove osiguranja" }));
            }
        }

        private void CheckOptimisticConcurrencyOsnovaosiguranja()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDOSNOVAOSIGURANJA], [RAZDOBLJESESMIJEPREKLAPATI], [NAZIVOSNOVAOSIGURANJA], [ZAMOOIDOSNOVAOSIGURANJA] AS ZAMOOIDOSNOVAOSIGURANJA FROM [OSNOVAOSIGURANJA] WITH (UPDLOCK) WHERE [IDOSNOVAOSIGURANJA] = @IDOSNOVAOSIGURANJA ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOSNOVAOSIGURANJA", DbType.String, 2));
                }
                command.SetParameterString(0, RuntimeHelpers.GetObjectValue(this.rowOSNOVAOSIGURANJA["IDOSNOVAOSIGURANJA"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new OSNOVAOSIGURANJADataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("OSNOVAOSIGURANJA") }));
                }
                if ((!command.HasMoreRows || !this.m__RAZDOBLJESESMIJEPREKLAPATIOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(reader, 1)))) || (!StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__NAZIVOSNOVAOSIGURANJAOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 2))) || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__ZAMOOIDOSNOVAOSIGURANJAOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 3)))))
                {
                    reader.Close();
                    throw new OSNOVAOSIGURANJADataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("OSNOVAOSIGURANJA") }));
                }
                reader.Close();
            }
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        private void CreateNewRowOsnovaosiguranja()
        {
            this.rowOSNOVAOSIGURANJA = this.OSNOVAOSIGURANJASet.OSNOVAOSIGURANJA.NewOSNOVAOSIGURANJARow();
        }

        private void Delete()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyOsnovaosiguranja();
            this.OnDeleteControlsOsnovaosiguranja();
            this.AfterConfirmOsnovaosiguranja();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [OSNOVAOSIGURANJA]  WHERE [IDOSNOVAOSIGURANJA] = @IDOSNOVAOSIGURANJA", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOSNOVAOSIGURANJA", DbType.String, 2));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameterString(0, RuntimeHelpers.GetObjectValue(this.rowOSNOVAOSIGURANJA["IDOSNOVAOSIGURANJA"]));
            command.ExecuteStmt();
            if (command.ForeignKeyError)
            {
                this.CheckDeleteErrorsOsnovaosiguranja();
            }
            this.OnOSNOVAOSIGURANJAUpdated(new OSNOVAOSIGURANJAEventArgs(this.rowOSNOVAOSIGURANJA, StatementType.Delete));
            this.rowOSNOVAOSIGURANJA.Delete();
            this.sMode18 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode18;
        }

        public virtual int Fill(OSNOVAOSIGURANJADataSet dataSet)
        {
            if (this.fillDataParameters != null)
            {
                this.Fill(dataSet, this.fillDataParameters[0].Value.ToString());
            }
            else
            {
                try
                {
                    this.InitializeMembers();
                    this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
                    this.OSNOVAOSIGURANJASet = dataSet;
                    this.LoadChildOsnovaosiguranja(0, -1);
                    dataSet.AcceptChanges();
                }
                finally
                {
                    this.Cleanup();
                }
            }
            return 0;
        }

        public virtual int Fill(DataSet dataSet)
        {
            this.OSNOVAOSIGURANJASet = (OSNOVAOSIGURANJADataSet) dataSet;
            if (this.OSNOVAOSIGURANJASet != null)
            {
                return this.Fill(this.OSNOVAOSIGURANJASet);
            }
            this.OSNOVAOSIGURANJASet = new OSNOVAOSIGURANJADataSet();
            this.Fill(this.OSNOVAOSIGURANJASet);
            dataSet.Merge(this.OSNOVAOSIGURANJASet);
            return 0;
        }

        public virtual int Fill(OSNOVAOSIGURANJADataSet dataSet, DataRow dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToString(dataRecord["IDOSNOVAOSIGURANJA"]));
        }

        public virtual int Fill(OSNOVAOSIGURANJADataSet dataSet, IDataRecord dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToString(dataRecord["IDOSNOVAOSIGURANJA"]));
        }

        public virtual int Fill(OSNOVAOSIGURANJADataSet dataSet, string iDOSNOVAOSIGURANJA)
        {
            if (!this.FillByIDOSNOVAOSIGURANJA(dataSet, iDOSNOVAOSIGURANJA))
            {
                throw new OSNOVAOSIGURANJANotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("OSNOVAOSIGURANJA") }));
            }
            return 0;
        }

        public virtual bool FillByIDOSNOVAOSIGURANJA(OSNOVAOSIGURANJADataSet dataSet, string iDOSNOVAOSIGURANJA)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.OSNOVAOSIGURANJASet = dataSet;
            this.rowOSNOVAOSIGURANJA = this.OSNOVAOSIGURANJASet.OSNOVAOSIGURANJA.NewOSNOVAOSIGURANJARow();
            this.rowOSNOVAOSIGURANJA.IDOSNOVAOSIGURANJA = iDOSNOVAOSIGURANJA;
            try
            {
                this.LoadByIDOSNOVAOSIGURANJA(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            if (this.RcdFound18 == 0)
            {
                return false;
            }
            return true;
        }

        public virtual int FillByZAMOOIDOSNOVAOSIGURANJA(OSNOVAOSIGURANJADataSet dataSet, string zAMOOIDOSNOVAOSIGURANJA)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.OSNOVAOSIGURANJASet = dataSet;
            this.rowOSNOVAOSIGURANJA = this.OSNOVAOSIGURANJASet.OSNOVAOSIGURANJA.NewOSNOVAOSIGURANJARow();
            this.rowOSNOVAOSIGURANJA.ZAMOOIDOSNOVAOSIGURANJA = zAMOOIDOSNOVAOSIGURANJA;
            try
            {
                this.LoadByZAMOOIDOSNOVAOSIGURANJA(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillPage(OSNOVAOSIGURANJADataSet dataSet, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.OSNOVAOSIGURANJASet = dataSet;
            try
            {
                this.LoadChildOsnovaosiguranja(startRow, maxRows);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillPageByZAMOOIDOSNOVAOSIGURANJA(OSNOVAOSIGURANJADataSet dataSet, string zAMOOIDOSNOVAOSIGURANJA, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.OSNOVAOSIGURANJASet = dataSet;
            this.rowOSNOVAOSIGURANJA = this.OSNOVAOSIGURANJASet.OSNOVAOSIGURANJA.NewOSNOVAOSIGURANJARow();
            this.rowOSNOVAOSIGURANJA.ZAMOOIDOSNOVAOSIGURANJA = zAMOOIDOSNOVAOSIGURANJA;
            try
            {
                this.LoadByZAMOOIDOSNOVAOSIGURANJA(startRow, maxRows);
                dataSet.AcceptChanges();
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

        private void GetByPrimaryKey()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDOSNOVAOSIGURANJA], [RAZDOBLJESESMIJEPREKLAPATI], [NAZIVOSNOVAOSIGURANJA], [ZAMOOIDOSNOVAOSIGURANJA] AS ZAMOOIDOSNOVAOSIGURANJA FROM [OSNOVAOSIGURANJA] WITH (NOLOCK) WHERE [IDOSNOVAOSIGURANJA] = @IDOSNOVAOSIGURANJA ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOSNOVAOSIGURANJA", DbType.String, 2));
            }
            command.SetParameterString(0, RuntimeHelpers.GetObjectValue(this.rowOSNOVAOSIGURANJA["IDOSNOVAOSIGURANJA"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.RcdFound18 = 1;
                this.rowOSNOVAOSIGURANJA["IDOSNOVAOSIGURANJA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetStringNE(reader, 0));
                this.rowOSNOVAOSIGURANJA["RAZDOBLJESESMIJEPREKLAPATI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(reader, 1));
                this.rowOSNOVAOSIGURANJA["NAZIVOSNOVAOSIGURANJA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 2));
                this.rowOSNOVAOSIGURANJA["ZAMOOIDOSNOVAOSIGURANJA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 3));
                this.sMode18 = this.Gx_mode;
                this.Gx_mode = StatementType.Select;
                this.LoadOsnovaosiguranja();
                this.Gx_mode = this.sMode18;
            }
            else
            {
                this.RcdFound18 = 0;
            }
            reader.Close();
        }

        public virtual IDataParameter[] GetFillParameters()
        {
            if (this.fillDataParameters == null)
            {
                DbParameter parameter = DbProviderFactories.GetFactory("System.Data.SqlClient").CreateParameter();
                parameter.ParameterName = "IDOSNOVAOSIGURANJA";
                parameter.DbType = DbType.String;
                this.fillDataParameters = new DbParameter[] { parameter };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount()
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmOSNOVAOSIGURANJASelect2 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [OSNOVAOSIGURANJA] WITH (NOLOCK) ", false);
            this.OSNOVAOSIGURANJASelect2 = this.cmOSNOVAOSIGURANJASelect2.FetchData();
            if (this.OSNOVAOSIGURANJASelect2.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.OSNOVAOSIGURANJASelect2.GetInt32(0);
            }
            this.OSNOVAOSIGURANJASelect2.Close();
            return this.recordCount;
        }

        private int GetInternalRecordCountByZAMOOIDOSNOVAOSIGURANJA(string zAMOOIDOSNOVAOSIGURANJA)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmOSNOVAOSIGURANJASelect1 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [OSNOVAOSIGURANJA] WITH (NOLOCK) WHERE [ZAMOOIDOSNOVAOSIGURANJA] = @ZAMOOIDOSNOVAOSIGURANJA ", false);
            if (this.cmOSNOVAOSIGURANJASelect1.IDbCommand.Parameters.Count == 0)
            {
                this.cmOSNOVAOSIGURANJASelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZAMOOIDOSNOVAOSIGURANJA", DbType.String, 2));
            }
            this.cmOSNOVAOSIGURANJASelect1.SetParameter(0, zAMOOIDOSNOVAOSIGURANJA);
            this.OSNOVAOSIGURANJASelect1 = this.cmOSNOVAOSIGURANJASelect1.FetchData();
            if (this.OSNOVAOSIGURANJASelect1.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.OSNOVAOSIGURANJASelect1.GetInt32(0);
            }
            this.OSNOVAOSIGURANJASelect1.Close();
            return this.recordCount;
        }

        public virtual int GetRecordCount()
        {
            int internalRecordCount;
            try
            {
                this.InitializeMembers();
                internalRecordCount = this.GetInternalRecordCount();
            }
            finally
            {
                this.Cleanup();
            }
            return internalRecordCount;
        }

        public virtual int GetRecordCountByZAMOOIDOSNOVAOSIGURANJA(string zAMOOIDOSNOVAOSIGURANJA)
        {
            int internalRecordCountByZAMOOIDOSNOVAOSIGURANJA;
            try
            {
                this.InitializeMembers();
                internalRecordCountByZAMOOIDOSNOVAOSIGURANJA = this.GetInternalRecordCountByZAMOOIDOSNOVAOSIGURANJA(zAMOOIDOSNOVAOSIGURANJA);
            }
            finally
            {
                this.Cleanup();
            }
            return internalRecordCountByZAMOOIDOSNOVAOSIGURANJA;
        }

        private void Initialize()
        {
            this.resourceManager = Deklarit.Utils.ResourceManager.Instance;
            this.resourceManagerTables = new System.Resources.ResourceManager("Tables", Assembly.GetExecutingAssembly());
            this.RcdFound18 = 0;
            this.scmdbuf = "";
            this.recordCount = 0;
            this._Gxremove = false;
            this.m__RAZDOBLJESESMIJEPREKLAPATIOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__NAZIVOSNOVAOSIGURANJAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__ZAMOOIDOSNOVAOSIGURANJAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m_WhereString = "";
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void InitializeMembers()
        {
            this.OSNOVAOSIGURANJASet = new OSNOVAOSIGURANJADataSet();
            this.Initialize();
            this.dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        }

        private void InsertOsnovaosiguranja()
        {
            this.CheckOptimisticConcurrencyOsnovaosiguranja();
            this.CheckExtendedTableOsnovaosiguranja();
            this.AfterConfirmOsnovaosiguranja();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [OSNOVAOSIGURANJA] ([IDOSNOVAOSIGURANJA], [RAZDOBLJESESMIJEPREKLAPATI], [NAZIVOSNOVAOSIGURANJA], [ZAMOOIDOSNOVAOSIGURANJA]) VALUES (@IDOSNOVAOSIGURANJA, @RAZDOBLJESESMIJEPREKLAPATI, @NAZIVOSNOVAOSIGURANJA, @ZAMOOIDOSNOVAOSIGURANJA)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOSNOVAOSIGURANJA", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RAZDOBLJESESMIJEPREKLAPATI", DbType.Boolean));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVOSNOVAOSIGURANJA", DbType.String, 100));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZAMOOIDOSNOVAOSIGURANJA", DbType.String, 2));
            }
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameterString(0, RuntimeHelpers.GetObjectValue(this.rowOSNOVAOSIGURANJA["IDOSNOVAOSIGURANJA"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowOSNOVAOSIGURANJA["RAZDOBLJESESMIJEPREKLAPATI"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowOSNOVAOSIGURANJA["NAZIVOSNOVAOSIGURANJA"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowOSNOVAOSIGURANJA["ZAMOOIDOSNOVAOSIGURANJA"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new OSNOVAOSIGURANJADuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            this.OnOSNOVAOSIGURANJAUpdated(new OSNOVAOSIGURANJAEventArgs(this.rowOSNOVAOSIGURANJA, StatementType.Insert));
        }

        private void LoadByIDOSNOVAOSIGURANJA(int startRow, int maxRows)
        {
            bool enforceConstraints = this.OSNOVAOSIGURANJASet.EnforceConstraints;
            this.OSNOVAOSIGURANJASet.OSNOVAOSIGURANJA.BeginLoadData();
            this.ScanByIDOSNOVAOSIGURANJA(startRow, maxRows);
            this.OSNOVAOSIGURANJASet.OSNOVAOSIGURANJA.EndLoadData();
            this.OSNOVAOSIGURANJASet.EnforceConstraints = enforceConstraints;
            if (this.OSNOVAOSIGURANJASet.OSNOVAOSIGURANJA.Count > 0)
            {
                this.rowOSNOVAOSIGURANJA = this.OSNOVAOSIGURANJASet.OSNOVAOSIGURANJA[this.OSNOVAOSIGURANJASet.OSNOVAOSIGURANJA.Count - 1];
            }
        }

        private void LoadByZAMOOIDOSNOVAOSIGURANJA(int startRow, int maxRows)
        {
            bool enforceConstraints = this.OSNOVAOSIGURANJASet.EnforceConstraints;
            this.OSNOVAOSIGURANJASet.OSNOVAOSIGURANJA.BeginLoadData();
            this.ScanByZAMOOIDOSNOVAOSIGURANJA(startRow, maxRows);
            this.OSNOVAOSIGURANJASet.OSNOVAOSIGURANJA.EndLoadData();
            this.OSNOVAOSIGURANJASet.EnforceConstraints = enforceConstraints;
            if (this.OSNOVAOSIGURANJASet.OSNOVAOSIGURANJA.Count > 0)
            {
                this.rowOSNOVAOSIGURANJA = this.OSNOVAOSIGURANJASet.OSNOVAOSIGURANJA[this.OSNOVAOSIGURANJASet.OSNOVAOSIGURANJA.Count - 1];
            }
        }

        private void LoadChildOsnovaosiguranja(int startRow, int maxRows)
        {
            this.CreateNewRowOsnovaosiguranja();
            bool enforceConstraints = this.OSNOVAOSIGURANJASet.EnforceConstraints;
            this.OSNOVAOSIGURANJASet.OSNOVAOSIGURANJA.BeginLoadData();
            this.ScanStartOsnovaosiguranja(startRow, maxRows);
            this.OSNOVAOSIGURANJASet.OSNOVAOSIGURANJA.EndLoadData();
            this.OSNOVAOSIGURANJASet.EnforceConstraints = enforceConstraints;
        }

        private void LoadDataOsnovaosiguranja(int maxRows)
        {
            int num = 0;
            if (this.RcdFound18 != 0)
            {
                this.ScanLoadOsnovaosiguranja();
                while ((this.RcdFound18 != 0) && (num != maxRows))
                {
                    num++;
                    this.LoadRowOsnovaosiguranja();
                    this.CreateNewRowOsnovaosiguranja();
                    this.ScanNextOsnovaosiguranja();
                }
            }
            if (num > 0)
            {
                this.RcdFound18 = 1;
            }
            this.ScanEndOsnovaosiguranja();
            if (this.OSNOVAOSIGURANJASet.OSNOVAOSIGURANJA.Count > 0)
            {
                this.rowOSNOVAOSIGURANJA = this.OSNOVAOSIGURANJASet.OSNOVAOSIGURANJA[this.OSNOVAOSIGURANJASet.OSNOVAOSIGURANJA.Count - 1];
            }
        }

        private void LoadOsnovaosiguranja()
        {
            if (!this.rowOSNOVAOSIGURANJA.IsZAMOOIDOSNOVAOSIGURANJANull())
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [NAZIVOSNOVAOSIGURANJA] AS ZAMOONAZIVOSNOVAOSIGURANJA FROM [OSNOVAOSIGURANJA] WITH (NOLOCK) WHERE [IDOSNOVAOSIGURANJA] = @ZAMOOIDOSNOVAOSIGURANJA ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZAMOOIDOSNOVAOSIGURANJA", DbType.String, 2));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOSNOVAOSIGURANJA["ZAMOOIDOSNOVAOSIGURANJA"]));
                IDataReader reader = command.FetchData();
                if (command.HasMoreRows)
                {
                    this.rowOSNOVAOSIGURANJA["ZAMOONAZIVOSNOVAOSIGURANJA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0));
                }
                reader.Close();
            }
            else
            {
                this.rowOSNOVAOSIGURANJA["ZAMOONAZIVOSNOVAOSIGURANJA"] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }
        }

        private void LoadRowOsnovaosiguranja()
        {
            this.AddRowOsnovaosiguranja();
        }

        private void OnDeleteControlsOsnovaosiguranja()
        {
            if (!this.rowOSNOVAOSIGURANJA.IsZAMOOIDOSNOVAOSIGURANJANull())
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [NAZIVOSNOVAOSIGURANJA] AS ZAMOONAZIVOSNOVAOSIGURANJA FROM [OSNOVAOSIGURANJA] WITH (NOLOCK) WHERE [IDOSNOVAOSIGURANJA] = @ZAMOOIDOSNOVAOSIGURANJA ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZAMOOIDOSNOVAOSIGURANJA", DbType.String, 2));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOSNOVAOSIGURANJA["ZAMOOIDOSNOVAOSIGURANJA"]));
                IDataReader reader = command.FetchData();
                if (command.HasMoreRows)
                {
                    this.rowOSNOVAOSIGURANJA["ZAMOONAZIVOSNOVAOSIGURANJA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0));
                }
                reader.Close();
            }
            else
            {
                this.rowOSNOVAOSIGURANJA["ZAMOONAZIVOSNOVAOSIGURANJA"] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }
        }

        private void OnOSNOVAOSIGURANJAUpdated(OSNOVAOSIGURANJAEventArgs e)
        {
            if (this.OSNOVAOSIGURANJAUpdated != null)
            {
                OSNOVAOSIGURANJAUpdateEventHandler oSNOVAOSIGURANJAUpdatedEvent = this.OSNOVAOSIGURANJAUpdated;
                if (oSNOVAOSIGURANJAUpdatedEvent != null)
                {
                    oSNOVAOSIGURANJAUpdatedEvent(this, e);
                }
            }
        }

        private void OnOSNOVAOSIGURANJAUpdating(OSNOVAOSIGURANJAEventArgs e)
        {
            if (this.OSNOVAOSIGURANJAUpdating != null)
            {
                OSNOVAOSIGURANJAUpdateEventHandler oSNOVAOSIGURANJAUpdatingEvent = this.OSNOVAOSIGURANJAUpdating;
                if (oSNOVAOSIGURANJAUpdatingEvent != null)
                {
                    oSNOVAOSIGURANJAUpdatingEvent(this, e);
                }
            }
        }

        private void ReadRowOsnovaosiguranja()
        {
            this.Gx_mode = Mode.FromRowState(this.rowOSNOVAOSIGURANJA.RowState);
            if (this.rowOSNOVAOSIGURANJA.RowState != DataRowState.Added)
            {
                this.m__RAZDOBLJESESMIJEPREKLAPATIOriginal = RuntimeHelpers.GetObjectValue(this.rowOSNOVAOSIGURANJA["RAZDOBLJESESMIJEPREKLAPATI", DataRowVersion.Original]);
                this.m__NAZIVOSNOVAOSIGURANJAOriginal = RuntimeHelpers.GetObjectValue(this.rowOSNOVAOSIGURANJA["NAZIVOSNOVAOSIGURANJA", DataRowVersion.Original]);
                this.m__ZAMOOIDOSNOVAOSIGURANJAOriginal = RuntimeHelpers.GetObjectValue(this.rowOSNOVAOSIGURANJA["ZAMOOIDOSNOVAOSIGURANJA", DataRowVersion.Original]);
            }
            else
            {
                this.m__RAZDOBLJESESMIJEPREKLAPATIOriginal = RuntimeHelpers.GetObjectValue(this.rowOSNOVAOSIGURANJA["RAZDOBLJESESMIJEPREKLAPATI"]);
                this.m__NAZIVOSNOVAOSIGURANJAOriginal = RuntimeHelpers.GetObjectValue(this.rowOSNOVAOSIGURANJA["NAZIVOSNOVAOSIGURANJA"]);
                this.m__ZAMOOIDOSNOVAOSIGURANJAOriginal = RuntimeHelpers.GetObjectValue(this.rowOSNOVAOSIGURANJA["ZAMOOIDOSNOVAOSIGURANJA"]);
            }
            this._Gxremove = this.rowOSNOVAOSIGURANJA.RowState == DataRowState.Deleted;
            if (this._Gxremove)
            {
                this.rowOSNOVAOSIGURANJA = (OSNOVAOSIGURANJADataSet.OSNOVAOSIGURANJARow) DataSetUtil.CloneOriginalDataRow(this.rowOSNOVAOSIGURANJA);
            }
        }

        private void ScanByIDOSNOVAOSIGURANJA(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[IDOSNOVAOSIGURANJA] = @IDOSNOVAOSIGURANJA";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString18 + "  FROM ([OSNOVAOSIGURANJA] TM1 WITH (NOLOCK) LEFT JOIN [OSNOVAOSIGURANJA] T2 WITH (NOLOCK) ON T2.[IDOSNOVAOSIGURANJA] = TM1.[ZAMOOIDOSNOVAOSIGURANJA])" + this.m_WhereString + " ORDER BY TM1.[IDOSNOVAOSIGURANJA]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString18, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDOSNOVAOSIGURANJA] ) AS DK_PAGENUM   FROM ([OSNOVAOSIGURANJA] TM1 WITH (NOLOCK) LEFT JOIN [OSNOVAOSIGURANJA] T2 WITH (NOLOCK) ON T2.[IDOSNOVAOSIGURANJA] = TM1.[ZAMOOIDOSNOVAOSIGURANJA]) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString18 + " FROM ([OSNOVAOSIGURANJA] TM1 WITH (NOLOCK) LEFT JOIN [OSNOVAOSIGURANJA] T2 WITH (NOLOCK) ON T2.[IDOSNOVAOSIGURANJA] = TM1.[ZAMOOIDOSNOVAOSIGURANJA])" + this.m_WhereString + " ORDER BY TM1.[IDOSNOVAOSIGURANJA] ";
            }
            this.cmOSNOVAOSIGURANJASelect9 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmOSNOVAOSIGURANJASelect9.IDbCommand.Parameters.Count == 0)
            {
                this.cmOSNOVAOSIGURANJASelect9.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOSNOVAOSIGURANJA", DbType.String, 2));
            }
            this.cmOSNOVAOSIGURANJASelect9.SetParameterString(0, RuntimeHelpers.GetObjectValue(this.rowOSNOVAOSIGURANJA["IDOSNOVAOSIGURANJA"]));
            this.OSNOVAOSIGURANJASelect9 = this.cmOSNOVAOSIGURANJASelect9.FetchData();
            this.RcdFound18 = 0;
            this.ScanLoadOsnovaosiguranja();
            this.LoadDataOsnovaosiguranja(maxRows);
        }

        private void ScanByZAMOOIDOSNOVAOSIGURANJA(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[ZAMOOIDOSNOVAOSIGURANJA] = @ZAMOOIDOSNOVAOSIGURANJA";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString18 + "  FROM ([OSNOVAOSIGURANJA] TM1 WITH (NOLOCK) LEFT JOIN [OSNOVAOSIGURANJA] T2 WITH (NOLOCK) ON T2.[IDOSNOVAOSIGURANJA] = TM1.[ZAMOOIDOSNOVAOSIGURANJA])" + this.m_WhereString + " ORDER BY TM1.[IDOSNOVAOSIGURANJA]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString18, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDOSNOVAOSIGURANJA] ) AS DK_PAGENUM   FROM ([OSNOVAOSIGURANJA] TM1 WITH (NOLOCK) LEFT JOIN [OSNOVAOSIGURANJA] T2 WITH (NOLOCK) ON T2.[IDOSNOVAOSIGURANJA] = TM1.[ZAMOOIDOSNOVAOSIGURANJA]) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString18 + " FROM ([OSNOVAOSIGURANJA] TM1 WITH (NOLOCK) LEFT JOIN [OSNOVAOSIGURANJA] T2 WITH (NOLOCK) ON T2.[IDOSNOVAOSIGURANJA] = TM1.[ZAMOOIDOSNOVAOSIGURANJA])" + this.m_WhereString + " ORDER BY TM1.[IDOSNOVAOSIGURANJA] ";
            }
            this.cmOSNOVAOSIGURANJASelect9 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmOSNOVAOSIGURANJASelect9.IDbCommand.Parameters.Count == 0)
            {
                this.cmOSNOVAOSIGURANJASelect9.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZAMOOIDOSNOVAOSIGURANJA", DbType.String, 2));
            }
            this.cmOSNOVAOSIGURANJASelect9.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOSNOVAOSIGURANJA["ZAMOOIDOSNOVAOSIGURANJA"]));
            this.OSNOVAOSIGURANJASelect9 = this.cmOSNOVAOSIGURANJASelect9.FetchData();
            this.RcdFound18 = 0;
            this.ScanLoadOsnovaosiguranja();
            this.LoadDataOsnovaosiguranja(maxRows);
        }

        private void ScanEndOsnovaosiguranja()
        {
            this.OSNOVAOSIGURANJASelect9.Close();
        }

        private void ScanLoadOsnovaosiguranja()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmOSNOVAOSIGURANJASelect9.HasMoreRows)
            {
                this.RcdFound18 = 1;
                this.rowOSNOVAOSIGURANJA["IDOSNOVAOSIGURANJA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetStringNE(this.OSNOVAOSIGURANJASelect9, 0));
                this.rowOSNOVAOSIGURANJA["RAZDOBLJESESMIJEPREKLAPATI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(this.OSNOVAOSIGURANJASelect9, 1));
                this.rowOSNOVAOSIGURANJA["NAZIVOSNOVAOSIGURANJA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.OSNOVAOSIGURANJASelect9, 2));
                this.rowOSNOVAOSIGURANJA["ZAMOONAZIVOSNOVAOSIGURANJA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.OSNOVAOSIGURANJASelect9, 3));
                this.rowOSNOVAOSIGURANJA["ZAMOOIDOSNOVAOSIGURANJA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.OSNOVAOSIGURANJASelect9, 4));
                this.rowOSNOVAOSIGURANJA["ZAMOONAZIVOSNOVAOSIGURANJA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.OSNOVAOSIGURANJASelect9, 3));
            }
        }

        private void ScanNextOsnovaosiguranja()
        {
            this.cmOSNOVAOSIGURANJASelect9.HasMoreRows = this.OSNOVAOSIGURANJASelect9.Read();
            this.RcdFound18 = 0;
            this.ScanLoadOsnovaosiguranja();
        }

        private void ScanStartOsnovaosiguranja(int startRow, int maxRows)
        {
            this.m_WhereString = "";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString18 + "  FROM ([OSNOVAOSIGURANJA] TM1 WITH (NOLOCK) LEFT JOIN [OSNOVAOSIGURANJA] T2 WITH (NOLOCK) ON T2.[IDOSNOVAOSIGURANJA] = TM1.[ZAMOOIDOSNOVAOSIGURANJA])" + this.m_WhereString + " ORDER BY TM1.[IDOSNOVAOSIGURANJA]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString18, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDOSNOVAOSIGURANJA] ) AS DK_PAGENUM   FROM ([OSNOVAOSIGURANJA] TM1 WITH (NOLOCK) LEFT JOIN [OSNOVAOSIGURANJA] T2 WITH (NOLOCK) ON T2.[IDOSNOVAOSIGURANJA] = TM1.[ZAMOOIDOSNOVAOSIGURANJA]) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString18 + " FROM ([OSNOVAOSIGURANJA] TM1 WITH (NOLOCK) LEFT JOIN [OSNOVAOSIGURANJA] T2 WITH (NOLOCK) ON T2.[IDOSNOVAOSIGURANJA] = TM1.[ZAMOOIDOSNOVAOSIGURANJA])" + this.m_WhereString + " ORDER BY TM1.[IDOSNOVAOSIGURANJA] ";
            }
            this.cmOSNOVAOSIGURANJASelect9 = this.connDefault.GetCommand(this.scmdbuf, false);
            this.OSNOVAOSIGURANJASelect9 = this.cmOSNOVAOSIGURANJASelect9.FetchData();
            this.RcdFound18 = 0;
            this.ScanLoadOsnovaosiguranja();
            this.LoadDataOsnovaosiguranja(maxRows);
        }

        public virtual int Update(DataSet dataSet)
        {
            this.InitializeMembers();
            this.OSNOVAOSIGURANJASet = (OSNOVAOSIGURANJADataSet) dataSet;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            if (this.OSNOVAOSIGURANJASet == null)
            {
                throw new ArgumentException(this.resourceManager.GetString("nulldset"));
            }
            try
            {
                IEnumerator enumerator = null;
                this.connDefault.BeginTransaction();
                try
                {
                    enumerator = this.OSNOVAOSIGURANJASet.OSNOVAOSIGURANJA.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        OSNOVAOSIGURANJADataSet.OSNOVAOSIGURANJARow current = (OSNOVAOSIGURANJADataSet.OSNOVAOSIGURANJARow) enumerator.Current;
                        this.rowOSNOVAOSIGURANJA = current;
                        if (Helpers.IsRowChanged(this.rowOSNOVAOSIGURANJA))
                        {
                            this.ReadRowOsnovaosiguranja();
                            if (this.rowOSNOVAOSIGURANJA.RowState == DataRowState.Added)
                            {
                                this.InsertOsnovaosiguranja();
                            }
                            else
                            {
                                if (this._Gxremove)
                                {
                                    this.Delete();
                                    continue;
                                }
                                this.UpdateOsnovaosiguranja();
                            }
                        }
                    }
                }
                finally
                {
                    if (enumerator is IDisposable)
                    {
                        (enumerator as IDisposable).Dispose();
                    }
                }
                dataSet.AcceptChanges();
                this.connDefault.Commit();
            }
            catch (System.Exception exception1)
            {
                throw exception1;
                
                //this.connDefault.Rollback();
                
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        private void UpdateOsnovaosiguranja()
        {
            this.CheckOptimisticConcurrencyOsnovaosiguranja();
            this.CheckExtendedTableOsnovaosiguranja();
            this.AfterConfirmOsnovaosiguranja();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [OSNOVAOSIGURANJA] SET [RAZDOBLJESESMIJEPREKLAPATI]=@RAZDOBLJESESMIJEPREKLAPATI, [NAZIVOSNOVAOSIGURANJA]=@NAZIVOSNOVAOSIGURANJA, [ZAMOOIDOSNOVAOSIGURANJA]=@ZAMOOIDOSNOVAOSIGURANJA  WHERE [IDOSNOVAOSIGURANJA] = @IDOSNOVAOSIGURANJA", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RAZDOBLJESESMIJEPREKLAPATI", DbType.Boolean));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVOSNOVAOSIGURANJA", DbType.String, 100));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZAMOOIDOSNOVAOSIGURANJA", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOSNOVAOSIGURANJA", DbType.String, 2));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOSNOVAOSIGURANJA["RAZDOBLJESESMIJEPREKLAPATI"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowOSNOVAOSIGURANJA["NAZIVOSNOVAOSIGURANJA"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowOSNOVAOSIGURANJA["ZAMOOIDOSNOVAOSIGURANJA"]));
            command.SetParameterString(3, RuntimeHelpers.GetObjectValue(this.rowOSNOVAOSIGURANJA["IDOSNOVAOSIGURANJA"]));
            command.ExecuteStmt();
            this.OnOSNOVAOSIGURANJAUpdated(new OSNOVAOSIGURANJAEventArgs(this.rowOSNOVAOSIGURANJA, StatementType.Update));
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

        [Serializable]
        public class ELEMENTInvalidDeleteException : InvalidDeleteException
        {
            public ELEMENTInvalidDeleteException()
            {
            }

            public ELEMENTInvalidDeleteException(string message) : base(message)
            {
            }

            protected ELEMENTInvalidDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public ELEMENTInvalidDeleteException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class OSNOVAOSIGURANJADataChangedException : DataChangedException
        {
            public OSNOVAOSIGURANJADataChangedException()
            {
            }

            public OSNOVAOSIGURANJADataChangedException(string message) : base(message)
            {
            }

            protected OSNOVAOSIGURANJADataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public OSNOVAOSIGURANJADataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class OSNOVAOSIGURANJADataLockedException : DataLockedException
        {
            public OSNOVAOSIGURANJADataLockedException()
            {
            }

            public OSNOVAOSIGURANJADataLockedException(string message) : base(message)
            {
            }

            protected OSNOVAOSIGURANJADataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public OSNOVAOSIGURANJADataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class OSNOVAOSIGURANJADuplicateKeyException : DuplicateKeyException
        {
            public OSNOVAOSIGURANJADuplicateKeyException()
            {
            }

            public OSNOVAOSIGURANJADuplicateKeyException(string message) : base(message)
            {
            }

            protected OSNOVAOSIGURANJADuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public OSNOVAOSIGURANJADuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class OSNOVAOSIGURANJAEventArgs : EventArgs
        {
            private OSNOVAOSIGURANJADataSet.OSNOVAOSIGURANJARow m_dataRow;
            private System.Data.StatementType m_statementType;

            public OSNOVAOSIGURANJAEventArgs(OSNOVAOSIGURANJADataSet.OSNOVAOSIGURANJARow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public OSNOVAOSIGURANJADataSet.OSNOVAOSIGURANJARow Row
            {
                get
                {
                    return this.m_dataRow;
                }
                set
                {
                    this.m_dataRow = value;
                }
            }

            public System.Data.StatementType StatementType
            {
                get
                {
                    return this.m_statementType;
                }
            }
        }

        [Serializable]
        public class OSNOVAOSIGURANJAForeignKeyNotFoundException : Deklarit.ForeignKeyNotFoundException
        {
            public OSNOVAOSIGURANJAForeignKeyNotFoundException()
            {
            }

            public OSNOVAOSIGURANJAForeignKeyNotFoundException(string message) : base(message)
            {
            }

            protected OSNOVAOSIGURANJAForeignKeyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public OSNOVAOSIGURANJAForeignKeyNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class OSNOVAOSIGURANJAInvalidDeleteException : InvalidDeleteException
        {
            public OSNOVAOSIGURANJAInvalidDeleteException()
            {
            }

            public OSNOVAOSIGURANJAInvalidDeleteException(string message) : base(message)
            {
            }

            protected OSNOVAOSIGURANJAInvalidDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public OSNOVAOSIGURANJAInvalidDeleteException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class OSNOVAOSIGURANJANotFoundException : DataNotFoundException
        {
            public OSNOVAOSIGURANJANotFoundException()
            {
            }

            public OSNOVAOSIGURANJANotFoundException(string message) : base(message)
            {
            }

            protected OSNOVAOSIGURANJANotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public OSNOVAOSIGURANJANotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public delegate void OSNOVAOSIGURANJAUpdateEventHandler(object sender, OSNOVAOSIGURANJADataAdapter.OSNOVAOSIGURANJAEventArgs e);
    }
}


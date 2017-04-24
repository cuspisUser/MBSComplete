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

    public class RAD1VEZASPOLDataAdapter : IDataAdapter, IRAD1VEZASPOLDataAdapter
    {
        private bool _Gxremove;
        private ReadWriteCommand cmRAD1VEZASPOLSelect1;
        private ReadWriteCommand cmRAD1VEZASPOLSelect2;
        private ReadWriteCommand cmRAD1VEZASPOLSelect3;
        private ReadWriteCommand cmRAD1VEZASPOLSelect6;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private DbParameter[] fillDataParameters;
        private StatementType Gx_mode;
        private readonly string m_SelectString285 = "TM1.[RAD1SPOLID], TM1.[IDSPOL]";
        private string m_WhereString;
        private IDataReader RAD1VEZASPOLSelect1;
        private IDataReader RAD1VEZASPOLSelect2;
        private IDataReader RAD1VEZASPOLSelect3;
        private IDataReader RAD1VEZASPOLSelect6;
        private RAD1VEZASPOLDataSet RAD1VEZASPOLSet;
        private short RcdFound285;
        private int recordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private RAD1VEZASPOLDataSet.RAD1VEZASPOLRow rowRAD1VEZASPOL;
        private string scmdbuf;
        private StatementType sMode285;

        public event RAD1VEZASPOLUpdateEventHandler RAD1VEZASPOLUpdated;

        public event RAD1VEZASPOLUpdateEventHandler RAD1VEZASPOLUpdating;

        private void AddRowRad1vezaspol()
        {
            this.RAD1VEZASPOLSet.RAD1VEZASPOL.AddRAD1VEZASPOLRow(this.rowRAD1VEZASPOL);
        }

        private void AfterConfirmRad1vezaspol()
        {
            this.OnRAD1VEZASPOLUpdating(new RAD1VEZASPOLEventArgs(this.rowRAD1VEZASPOL, this.Gx_mode));
        }

        private void CheckIntegrityErrorsRad1vezaspol()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [RAD1SPOLID] FROM [RAD1SPOL] WITH (NOLOCK) WHERE [RAD1SPOLID] = @RAD1SPOLID ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RAD1SPOLID", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRAD1VEZASPOL["RAD1SPOLID"]));
            IDataReader reader = command.FetchData();
            if (!command.HasMoreRows)
            {
                reader.Close();
                throw new RAD1SPOLForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("RAD1SPOL") }));
            }
            reader.Close();
            ReadWriteCommand command2 = this.connDefault.GetCommand("SELECT [IDSPOL] FROM [SPOL] WITH (NOLOCK) WHERE [IDSPOL] = @IDSPOL ", false);
            if (command2.IDbCommand.Parameters.Count == 0)
            {
                command2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSPOL", DbType.Int32));
            }
            command2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRAD1VEZASPOL["IDSPOL"]));
            IDataReader reader2 = command2.FetchData();
            if (!command2.HasMoreRows)
            {
                reader2.Close();
                throw new SPOLForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("SPOL") }));
            }
            reader2.Close();
            throw new ForeignKeyNotFoundException(this.resourceManager.GetString("refinterror"));
        }

        private void CheckOptimisticConcurrencyRad1vezaspol()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [RAD1SPOLID], [IDSPOL] FROM [RAD1VEZASPOL] WITH (UPDLOCK) WHERE [RAD1SPOLID] = @RAD1SPOLID AND [IDSPOL] = @IDSPOL ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RAD1SPOLID", DbType.Int32));
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSPOL", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRAD1VEZASPOL["RAD1SPOLID"]));
                command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowRAD1VEZASPOL["IDSPOL"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new RAD1VEZASPOLDataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("RAD1VEZASPOL") }));
                }
                if (!command.HasMoreRows)
                {
                    reader.Close();
                    throw new RAD1VEZASPOLDataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("RAD1VEZASPOL") }));
                }
                reader.Close();
            }
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        private void CreateNewRowRad1vezaspol()
        {
            this.rowRAD1VEZASPOL = this.RAD1VEZASPOLSet.RAD1VEZASPOL.NewRAD1VEZASPOLRow();
        }

        private void Delete()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyRad1vezaspol();
            this.AfterConfirmRad1vezaspol();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [RAD1VEZASPOL]  WHERE [RAD1SPOLID] = @RAD1SPOLID AND [IDSPOL] = @IDSPOL", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RAD1SPOLID", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSPOL", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRAD1VEZASPOL["RAD1SPOLID"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowRAD1VEZASPOL["IDSPOL"]));
            command.ExecuteStmt();
            this.OnRAD1VEZASPOLUpdated(new RAD1VEZASPOLEventArgs(this.rowRAD1VEZASPOL, StatementType.Delete));
            this.rowRAD1VEZASPOL.Delete();
            this.sMode285 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode285;
        }

        public virtual int Fill(RAD1VEZASPOLDataSet dataSet)
        {
            if (this.fillDataParameters != null)
            {
                this.Fill(dataSet, int.Parse(this.fillDataParameters[0].Value.ToString()), int.Parse(this.fillDataParameters[1].Value.ToString()));
            }
            else
            {
                try
                {
                    this.InitializeMembers();
                    this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
                    this.RAD1VEZASPOLSet = dataSet;
                    this.LoadChildRad1vezaspol(0, -1);
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
            this.RAD1VEZASPOLSet = (RAD1VEZASPOLDataSet) dataSet;
            if (this.RAD1VEZASPOLSet != null)
            {
                return this.Fill(this.RAD1VEZASPOLSet);
            }
            this.RAD1VEZASPOLSet = new RAD1VEZASPOLDataSet();
            this.Fill(this.RAD1VEZASPOLSet);
            dataSet.Merge(this.RAD1VEZASPOLSet);
            return 0;
        }

        public virtual int Fill(RAD1VEZASPOLDataSet dataSet, DataRow dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["RAD1SPOLID"]), Conversions.ToInteger(dataRecord["IDSPOL"]));
        }

        public virtual int Fill(RAD1VEZASPOLDataSet dataSet, IDataRecord dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["RAD1SPOLID"]), Conversions.ToInteger(dataRecord["IDSPOL"]));
        }

        public virtual int Fill(RAD1VEZASPOLDataSet dataSet, int rAD1SPOLID, int iDSPOL)
        {
            if (!this.FillByRAD1SPOLIDIDSPOL(dataSet, rAD1SPOLID, iDSPOL))
            {
                throw new RAD1VEZASPOLNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("RAD1VEZASPOL") }));
            }
            return 0;
        }

        public virtual int FillByIDSPOL(RAD1VEZASPOLDataSet dataSet, int iDSPOL)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.RAD1VEZASPOLSet = dataSet;
            this.rowRAD1VEZASPOL = this.RAD1VEZASPOLSet.RAD1VEZASPOL.NewRAD1VEZASPOLRow();
            this.rowRAD1VEZASPOL.IDSPOL = iDSPOL;
            try
            {
                this.LoadByIDSPOL(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillByRAD1SPOLID(RAD1VEZASPOLDataSet dataSet, int rAD1SPOLID)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.RAD1VEZASPOLSet = dataSet;
            this.rowRAD1VEZASPOL = this.RAD1VEZASPOLSet.RAD1VEZASPOL.NewRAD1VEZASPOLRow();
            this.rowRAD1VEZASPOL.RAD1SPOLID = rAD1SPOLID;
            try
            {
                this.LoadByRAD1SPOLID(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual bool FillByRAD1SPOLIDIDSPOL(RAD1VEZASPOLDataSet dataSet, int rAD1SPOLID, int iDSPOL)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.RAD1VEZASPOLSet = dataSet;
            this.rowRAD1VEZASPOL = this.RAD1VEZASPOLSet.RAD1VEZASPOL.NewRAD1VEZASPOLRow();
            this.rowRAD1VEZASPOL.RAD1SPOLID = rAD1SPOLID;
            this.rowRAD1VEZASPOL.IDSPOL = iDSPOL;
            try
            {
                this.LoadByRAD1SPOLIDIDSPOL(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            if (this.RcdFound285 == 0)
            {
                return false;
            }
            return true;
        }

        public virtual int FillPage(RAD1VEZASPOLDataSet dataSet, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.RAD1VEZASPOLSet = dataSet;
            try
            {
                this.LoadChildRad1vezaspol(startRow, maxRows);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillPageByIDSPOL(RAD1VEZASPOLDataSet dataSet, int iDSPOL, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.RAD1VEZASPOLSet = dataSet;
            this.rowRAD1VEZASPOL = this.RAD1VEZASPOLSet.RAD1VEZASPOL.NewRAD1VEZASPOLRow();
            this.rowRAD1VEZASPOL.IDSPOL = iDSPOL;
            try
            {
                this.LoadByIDSPOL(startRow, maxRows);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillPageByRAD1SPOLID(RAD1VEZASPOLDataSet dataSet, int rAD1SPOLID, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.RAD1VEZASPOLSet = dataSet;
            this.rowRAD1VEZASPOL = this.RAD1VEZASPOLSet.RAD1VEZASPOL.NewRAD1VEZASPOLRow();
            this.rowRAD1VEZASPOL.RAD1SPOLID = rAD1SPOLID;
            try
            {
                this.LoadByRAD1SPOLID(startRow, maxRows);
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
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [RAD1SPOLID], [IDSPOL] FROM [RAD1VEZASPOL] WITH (NOLOCK) WHERE [RAD1SPOLID] = @RAD1SPOLID AND [IDSPOL] = @IDSPOL ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RAD1SPOLID", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSPOL", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRAD1VEZASPOL["RAD1SPOLID"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowRAD1VEZASPOL["IDSPOL"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.RcdFound285 = 1;
                this.rowRAD1VEZASPOL["RAD1SPOLID"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 0));
                this.rowRAD1VEZASPOL["IDSPOL"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 1));
                this.sMode285 = this.Gx_mode;
                this.Gx_mode = StatementType.Select;
                this.Gx_mode = this.sMode285;
            }
            else
            {
                this.RcdFound285 = 0;
            }
            reader.Close();
        }

        public virtual IDataParameter[] GetFillParameters()
        {
            if (this.fillDataParameters == null)
            {
                DbProviderFactory factory = DbProviderFactories.GetFactory("System.Data.SqlClient");
                DbParameter parameter = factory.CreateParameter();
                parameter.ParameterName = "RAD1SPOLID";
                parameter.DbType = DbType.Int32;
                DbParameter parameter2 = factory.CreateParameter();
                parameter2.ParameterName = "IDSPOL";
                parameter2.DbType = DbType.Int32;
                this.fillDataParameters = new DbParameter[] { parameter, parameter2 };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount()
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmRAD1VEZASPOLSelect3 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [RAD1VEZASPOL] WITH (NOLOCK) ", false);
            this.RAD1VEZASPOLSelect3 = this.cmRAD1VEZASPOLSelect3.FetchData();
            if (this.RAD1VEZASPOLSelect3.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.RAD1VEZASPOLSelect3.GetInt32(0);
            }
            this.RAD1VEZASPOLSelect3.Close();
            return this.recordCount;
        }

        private int GetInternalRecordCountByIDSPOL(int iDSPOL)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmRAD1VEZASPOLSelect2 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [RAD1VEZASPOL] WITH (NOLOCK) WHERE [IDSPOL] = @IDSPOL ", false);
            if (this.cmRAD1VEZASPOLSelect2.IDbCommand.Parameters.Count == 0)
            {
                this.cmRAD1VEZASPOLSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSPOL", DbType.Int32));
            }
            this.cmRAD1VEZASPOLSelect2.SetParameter(0, iDSPOL);
            this.RAD1VEZASPOLSelect2 = this.cmRAD1VEZASPOLSelect2.FetchData();
            if (this.RAD1VEZASPOLSelect2.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.RAD1VEZASPOLSelect2.GetInt32(0);
            }
            this.RAD1VEZASPOLSelect2.Close();
            return this.recordCount;
        }

        private int GetInternalRecordCountByRAD1SPOLID(int rAD1SPOLID)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmRAD1VEZASPOLSelect1 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [RAD1VEZASPOL] WITH (NOLOCK) WHERE [RAD1SPOLID] = @RAD1SPOLID ", false);
            if (this.cmRAD1VEZASPOLSelect1.IDbCommand.Parameters.Count == 0)
            {
                this.cmRAD1VEZASPOLSelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RAD1SPOLID", DbType.Int32));
            }
            this.cmRAD1VEZASPOLSelect1.SetParameter(0, rAD1SPOLID);
            this.RAD1VEZASPOLSelect1 = this.cmRAD1VEZASPOLSelect1.FetchData();
            if (this.RAD1VEZASPOLSelect1.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.RAD1VEZASPOLSelect1.GetInt32(0);
            }
            this.RAD1VEZASPOLSelect1.Close();
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

        public virtual int GetRecordCountByIDSPOL(int iDSPOL)
        {
            int internalRecordCountByIDSPOL;
            try
            {
                this.InitializeMembers();
                internalRecordCountByIDSPOL = this.GetInternalRecordCountByIDSPOL(iDSPOL);
            }
            finally
            {
                this.Cleanup();
            }
            return internalRecordCountByIDSPOL;
        }

        public virtual int GetRecordCountByRAD1SPOLID(int rAD1SPOLID)
        {
            int num2 = 0;
            try
            {
                this.InitializeMembers();
                num2 = this.GetInternalRecordCountByRAD1SPOLID(rAD1SPOLID);
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
            this.RcdFound285 = 0;
            this.scmdbuf = "";
            this.recordCount = 0;
            this._Gxremove = false;
            this.m_WhereString = "";
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void InitializeMembers()
        {
            this.RAD1VEZASPOLSet = new RAD1VEZASPOLDataSet();
            this.Initialize();
            this.dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        }

        private void InsertRad1vezaspol()
        {
            this.CheckOptimisticConcurrencyRad1vezaspol();
            this.AfterConfirmRad1vezaspol();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [RAD1VEZASPOL] ([RAD1SPOLID], [IDSPOL]) VALUES (@RAD1SPOLID, @IDSPOL)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RAD1SPOLID", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSPOL", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRAD1VEZASPOL["RAD1SPOLID"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowRAD1VEZASPOL["IDSPOL"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new RAD1VEZASPOLDuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            if (command.ForeignKeyError)
            {
                this.CheckIntegrityErrorsRad1vezaspol();
            }
            this.OnRAD1VEZASPOLUpdated(new RAD1VEZASPOLEventArgs(this.rowRAD1VEZASPOL, StatementType.Insert));
        }

        private void LoadByIDSPOL(int startRow, int maxRows)
        {
            bool enforceConstraints = this.RAD1VEZASPOLSet.EnforceConstraints;
            this.RAD1VEZASPOLSet.RAD1VEZASPOL.BeginLoadData();
            this.ScanByIDSPOL(startRow, maxRows);
            this.RAD1VEZASPOLSet.RAD1VEZASPOL.EndLoadData();
            this.RAD1VEZASPOLSet.EnforceConstraints = enforceConstraints;
            if (this.RAD1VEZASPOLSet.RAD1VEZASPOL.Count > 0)
            {
                this.rowRAD1VEZASPOL = this.RAD1VEZASPOLSet.RAD1VEZASPOL[this.RAD1VEZASPOLSet.RAD1VEZASPOL.Count - 1];
            }
        }

        private void LoadByRAD1SPOLID(int startRow, int maxRows)
        {
            bool enforceConstraints = this.RAD1VEZASPOLSet.EnforceConstraints;
            this.RAD1VEZASPOLSet.RAD1VEZASPOL.BeginLoadData();
            this.ScanByRAD1SPOLID(startRow, maxRows);
            this.RAD1VEZASPOLSet.RAD1VEZASPOL.EndLoadData();
            this.RAD1VEZASPOLSet.EnforceConstraints = enforceConstraints;
            if (this.RAD1VEZASPOLSet.RAD1VEZASPOL.Count > 0)
            {
                this.rowRAD1VEZASPOL = this.RAD1VEZASPOLSet.RAD1VEZASPOL[this.RAD1VEZASPOLSet.RAD1VEZASPOL.Count - 1];
            }
        }

        private void LoadByRAD1SPOLIDIDSPOL(int startRow, int maxRows)
        {
            bool enforceConstraints = this.RAD1VEZASPOLSet.EnforceConstraints;
            this.RAD1VEZASPOLSet.RAD1VEZASPOL.BeginLoadData();
            this.ScanByRAD1SPOLIDIDSPOL(startRow, maxRows);
            this.RAD1VEZASPOLSet.RAD1VEZASPOL.EndLoadData();
            this.RAD1VEZASPOLSet.EnforceConstraints = enforceConstraints;
            if (this.RAD1VEZASPOLSet.RAD1VEZASPOL.Count > 0)
            {
                this.rowRAD1VEZASPOL = this.RAD1VEZASPOLSet.RAD1VEZASPOL[this.RAD1VEZASPOLSet.RAD1VEZASPOL.Count - 1];
            }
        }

        private void LoadChildRad1vezaspol(int startRow, int maxRows)
        {
            this.CreateNewRowRad1vezaspol();
            bool enforceConstraints = this.RAD1VEZASPOLSet.EnforceConstraints;
            this.RAD1VEZASPOLSet.RAD1VEZASPOL.BeginLoadData();
            this.ScanStartRad1vezaspol(startRow, maxRows);
            this.RAD1VEZASPOLSet.RAD1VEZASPOL.EndLoadData();
            this.RAD1VEZASPOLSet.EnforceConstraints = enforceConstraints;
        }

        private void LoadDataRad1vezaspol(int maxRows)
        {
            int num = 0;
            if (this.RcdFound285 != 0)
            {
                this.ScanLoadRad1vezaspol();
                while ((this.RcdFound285 != 0) && (num != maxRows))
                {
                    num++;
                    this.LoadRowRad1vezaspol();
                    this.CreateNewRowRad1vezaspol();
                    this.ScanNextRad1vezaspol();
                }
            }
            if (num > 0)
            {
                this.RcdFound285 = 1;
            }
            this.ScanEndRad1vezaspol();
            if (this.RAD1VEZASPOLSet.RAD1VEZASPOL.Count > 0)
            {
                this.rowRAD1VEZASPOL = this.RAD1VEZASPOLSet.RAD1VEZASPOL[this.RAD1VEZASPOLSet.RAD1VEZASPOL.Count - 1];
            }
        }

        private void LoadRowRad1vezaspol()
        {
            this.AddRowRad1vezaspol();
        }

        private void OnRAD1VEZASPOLUpdated(RAD1VEZASPOLEventArgs e)
        {
            if (this.RAD1VEZASPOLUpdated != null)
            {
                RAD1VEZASPOLUpdateEventHandler handler = this.RAD1VEZASPOLUpdated;
                if (handler != null)
                {
                    handler(this, e);
                }
            }
        }

        private void OnRAD1VEZASPOLUpdating(RAD1VEZASPOLEventArgs e)
        {
            if (this.RAD1VEZASPOLUpdating != null)
            {
                RAD1VEZASPOLUpdateEventHandler handler = this.RAD1VEZASPOLUpdating;
                if (handler != null)
                {
                    handler(this, e);
                }
            }
        }

        private void ReadRowRad1vezaspol()
        {
            this.Gx_mode = Mode.FromRowState(this.rowRAD1VEZASPOL.RowState);
            if (this.rowRAD1VEZASPOL.RowState == DataRowState.Added)
            {
            }
            this._Gxremove = this.rowRAD1VEZASPOL.RowState == DataRowState.Deleted;
            if (this._Gxremove)
            {
                this.rowRAD1VEZASPOL = (RAD1VEZASPOLDataSet.RAD1VEZASPOLRow) DataSetUtil.CloneOriginalDataRow(this.rowRAD1VEZASPOL);
            }
        }

        private void ScanByIDSPOL(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[IDSPOL] = @IDSPOL";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString285 + "  FROM [RAD1VEZASPOL] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[RAD1SPOLID], TM1.[IDSPOL]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString285, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[RAD1SPOLID], TM1.[IDSPOL] ) AS DK_PAGENUM   FROM [RAD1VEZASPOL] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString285 + " FROM [RAD1VEZASPOL] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[RAD1SPOLID], TM1.[IDSPOL] ";
            }
            this.cmRAD1VEZASPOLSelect6 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmRAD1VEZASPOLSelect6.IDbCommand.Parameters.Count == 0)
            {
                this.cmRAD1VEZASPOLSelect6.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSPOL", DbType.Int32));
            }
            this.cmRAD1VEZASPOLSelect6.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRAD1VEZASPOL["IDSPOL"]));
            this.RAD1VEZASPOLSelect6 = this.cmRAD1VEZASPOLSelect6.FetchData();
            this.RcdFound285 = 0;
            this.ScanLoadRad1vezaspol();
            this.LoadDataRad1vezaspol(maxRows);
        }

        private void ScanByRAD1SPOLID(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[RAD1SPOLID] = @RAD1SPOLID";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString285 + "  FROM [RAD1VEZASPOL] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[RAD1SPOLID], TM1.[IDSPOL]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString285, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[RAD1SPOLID], TM1.[IDSPOL] ) AS DK_PAGENUM   FROM [RAD1VEZASPOL] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString285 + " FROM [RAD1VEZASPOL] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[RAD1SPOLID], TM1.[IDSPOL] ";
            }
            this.cmRAD1VEZASPOLSelect6 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmRAD1VEZASPOLSelect6.IDbCommand.Parameters.Count == 0)
            {
                this.cmRAD1VEZASPOLSelect6.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RAD1SPOLID", DbType.Int32));
            }
            this.cmRAD1VEZASPOLSelect6.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRAD1VEZASPOL["RAD1SPOLID"]));
            this.RAD1VEZASPOLSelect6 = this.cmRAD1VEZASPOLSelect6.FetchData();
            this.RcdFound285 = 0;
            this.ScanLoadRad1vezaspol();
            this.LoadDataRad1vezaspol(maxRows);
        }

        private void ScanByRAD1SPOLIDIDSPOL(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[RAD1SPOLID] = @RAD1SPOLID and TM1.[IDSPOL] = @IDSPOL";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString285 + "  FROM [RAD1VEZASPOL] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[RAD1SPOLID], TM1.[IDSPOL]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString285, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[RAD1SPOLID], TM1.[IDSPOL] ) AS DK_PAGENUM   FROM [RAD1VEZASPOL] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString285 + " FROM [RAD1VEZASPOL] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[RAD1SPOLID], TM1.[IDSPOL] ";
            }
            this.cmRAD1VEZASPOLSelect6 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmRAD1VEZASPOLSelect6.IDbCommand.Parameters.Count == 0)
            {
                this.cmRAD1VEZASPOLSelect6.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RAD1SPOLID", DbType.Int32));
                this.cmRAD1VEZASPOLSelect6.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSPOL", DbType.Int32));
            }
            this.cmRAD1VEZASPOLSelect6.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRAD1VEZASPOL["RAD1SPOLID"]));
            this.cmRAD1VEZASPOLSelect6.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowRAD1VEZASPOL["IDSPOL"]));
            this.RAD1VEZASPOLSelect6 = this.cmRAD1VEZASPOLSelect6.FetchData();
            this.RcdFound285 = 0;
            this.ScanLoadRad1vezaspol();
            this.LoadDataRad1vezaspol(maxRows);
        }

        private void ScanEndRad1vezaspol()
        {
            this.RAD1VEZASPOLSelect6.Close();
        }

        private void ScanLoadRad1vezaspol()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmRAD1VEZASPOLSelect6.HasMoreRows)
            {
                this.RcdFound285 = 1;
                this.rowRAD1VEZASPOL["RAD1SPOLID"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.RAD1VEZASPOLSelect6, 0));
                this.rowRAD1VEZASPOL["IDSPOL"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.RAD1VEZASPOLSelect6, 1));
            }
        }

        private void ScanNextRad1vezaspol()
        {
            this.cmRAD1VEZASPOLSelect6.HasMoreRows = this.RAD1VEZASPOLSelect6.Read();
            this.RcdFound285 = 0;
            this.ScanLoadRad1vezaspol();
        }

        private void ScanStartRad1vezaspol(int startRow, int maxRows)
        {
            this.m_WhereString = "";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString285 + "  FROM [RAD1VEZASPOL] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[RAD1SPOLID], TM1.[IDSPOL]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString285, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[RAD1SPOLID], TM1.[IDSPOL] ) AS DK_PAGENUM   FROM [RAD1VEZASPOL] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString285 + " FROM [RAD1VEZASPOL] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[RAD1SPOLID], TM1.[IDSPOL] ";
            }
            this.cmRAD1VEZASPOLSelect6 = this.connDefault.GetCommand(this.scmdbuf, false);
            this.RAD1VEZASPOLSelect6 = this.cmRAD1VEZASPOLSelect6.FetchData();
            this.RcdFound285 = 0;
            this.ScanLoadRad1vezaspol();
            this.LoadDataRad1vezaspol(maxRows);
        }

        public virtual int Update(DataSet dataSet)
        {
            this.InitializeMembers();
            this.RAD1VEZASPOLSet = (RAD1VEZASPOLDataSet) dataSet;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            if (this.RAD1VEZASPOLSet == null)
            {
                throw new ArgumentException(this.resourceManager.GetString("nulldset"));
            }
            try
            {
                IEnumerator enumerator = null;
                this.connDefault.BeginTransaction();
                try
                {
                    enumerator = this.RAD1VEZASPOLSet.RAD1VEZASPOL.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        RAD1VEZASPOLDataSet.RAD1VEZASPOLRow current = (RAD1VEZASPOLDataSet.RAD1VEZASPOLRow) enumerator.Current;
                        this.rowRAD1VEZASPOL = current;
                        if (Helpers.IsRowChanged(this.rowRAD1VEZASPOL))
                        {
                            this.ReadRowRad1vezaspol();
                            if (this.rowRAD1VEZASPOL.RowState == DataRowState.Added)
                            {
                                this.InsertRad1vezaspol();
                            }
                            else
                            {
                                if (this._Gxremove)
                                {
                                    this.Delete();
                                    continue;
                                }
                                this.UpdateRad1vezaspol();
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

        private void UpdateRad1vezaspol()
        {
            this.CheckOptimisticConcurrencyRad1vezaspol();
            this.AfterConfirmRad1vezaspol();
            this.OnRAD1VEZASPOLUpdated(new RAD1VEZASPOLEventArgs(this.rowRAD1VEZASPOL, StatementType.Update));
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
        public class ForeignKeyNotFoundException : Deklarit.ForeignKeyNotFoundException
        {
            public ForeignKeyNotFoundException()
            {
            }

            public ForeignKeyNotFoundException(string message) : base(message)
            {
            }

            protected ForeignKeyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public ForeignKeyNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class RAD1SPOLForeignKeyNotFoundException : Deklarit.ForeignKeyNotFoundException
        {
            public RAD1SPOLForeignKeyNotFoundException()
            {
            }

            public RAD1SPOLForeignKeyNotFoundException(string message) : base(message)
            {
            }

            protected RAD1SPOLForeignKeyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public RAD1SPOLForeignKeyNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class RAD1VEZASPOLDataChangedException : DataChangedException
        {
            public RAD1VEZASPOLDataChangedException()
            {
            }

            public RAD1VEZASPOLDataChangedException(string message) : base(message)
            {
            }

            protected RAD1VEZASPOLDataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public RAD1VEZASPOLDataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class RAD1VEZASPOLDataLockedException : DataLockedException
        {
            public RAD1VEZASPOLDataLockedException()
            {
            }

            public RAD1VEZASPOLDataLockedException(string message) : base(message)
            {
            }

            protected RAD1VEZASPOLDataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public RAD1VEZASPOLDataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class RAD1VEZASPOLDuplicateKeyException : DuplicateKeyException
        {
            public RAD1VEZASPOLDuplicateKeyException()
            {
            }

            public RAD1VEZASPOLDuplicateKeyException(string message) : base(message)
            {
            }

            protected RAD1VEZASPOLDuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public RAD1VEZASPOLDuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class RAD1VEZASPOLEventArgs : EventArgs
        {
            private RAD1VEZASPOLDataSet.RAD1VEZASPOLRow m_dataRow;
            private System.Data.StatementType m_statementType;

            public RAD1VEZASPOLEventArgs(RAD1VEZASPOLDataSet.RAD1VEZASPOLRow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public RAD1VEZASPOLDataSet.RAD1VEZASPOLRow Row
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
        public class RAD1VEZASPOLNotFoundException : DataNotFoundException
        {
            public RAD1VEZASPOLNotFoundException()
            {
            }

            public RAD1VEZASPOLNotFoundException(string message) : base(message)
            {
            }

            protected RAD1VEZASPOLNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public RAD1VEZASPOLNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public delegate void RAD1VEZASPOLUpdateEventHandler(object sender, RAD1VEZASPOLDataAdapter.RAD1VEZASPOLEventArgs e);

        [Serializable]
        public class SPOLForeignKeyNotFoundException : Deklarit.ForeignKeyNotFoundException
        {
            public SPOLForeignKeyNotFoundException()
            {
            }

            public SPOLForeignKeyNotFoundException(string message) : base(message)
            {
            }

            protected SPOLForeignKeyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public SPOLForeignKeyNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }
    }
}


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

    public class RAD1MELEMENTIVEZADataAdapter : IDataAdapter, IRAD1MELEMENTIVEZADataAdapter
    {
        private bool _Gxremove;
        private ReadWriteCommand cmRAD1MELEMENTIVEZASelect1;
        private ReadWriteCommand cmRAD1MELEMENTIVEZASelect2;
        private ReadWriteCommand cmRAD1MELEMENTIVEZASelect3;
        private ReadWriteCommand cmRAD1MELEMENTIVEZASelect6;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private DbParameter[] fillDataParameters;
        private StatementType Gx_mode;
        private readonly string m_SelectString287 = "TM1.[RAD1ELEMENTIID], TM1.[IDELEMENT]";
        private string m_WhereString;
        private IDataReader RAD1MELEMENTIVEZASelect1;
        private IDataReader RAD1MELEMENTIVEZASelect2;
        private IDataReader RAD1MELEMENTIVEZASelect3;
        private IDataReader RAD1MELEMENTIVEZASelect6;
        private RAD1MELEMENTIVEZADataSet RAD1MELEMENTIVEZASet;
        private short RcdFound287;
        private int recordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private RAD1MELEMENTIVEZADataSet.RAD1MELEMENTIVEZARow rowRAD1MELEMENTIVEZA;
        private string scmdbuf;
        private StatementType sMode287;

        public event RAD1MELEMENTIVEZAUpdateEventHandler RAD1MELEMENTIVEZAUpdated;

        public event RAD1MELEMENTIVEZAUpdateEventHandler RAD1MELEMENTIVEZAUpdating;

        private void AddRowRad1melementiveza()
        {
            this.RAD1MELEMENTIVEZASet.RAD1MELEMENTIVEZA.AddRAD1MELEMENTIVEZARow(this.rowRAD1MELEMENTIVEZA);
        }

        private void AfterConfirmRad1melementiveza()
        {
            this.OnRAD1MELEMENTIVEZAUpdating(new RAD1MELEMENTIVEZAEventArgs(this.rowRAD1MELEMENTIVEZA, this.Gx_mode));
        }

        private void CheckIntegrityErrorsRad1melementiveza()
        {
            ReadWriteCommand command2 = this.connDefault.GetCommand("SELECT [RAD1ELEMENTIID] FROM [RAD1MELEMENTI] WITH (NOLOCK) WHERE [RAD1ELEMENTIID] = @RAD1ELEMENTIID ", false);
            if (command2.IDbCommand.Parameters.Count == 0)
            {
                command2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RAD1ELEMENTIID", DbType.Int32));
            }
            command2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRAD1MELEMENTIVEZA["RAD1ELEMENTIID"]));
            IDataReader reader2 = command2.FetchData();
            if (!command2.HasMoreRows)
            {
                reader2.Close();
                throw new RAD1MELEMENTIForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("RAD1MELEMENTI") }));
            }
            reader2.Close();
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDELEMENT] FROM [ELEMENT] WITH (NOLOCK) WHERE [IDELEMENT] = @IDELEMENT ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDELEMENT", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRAD1MELEMENTIVEZA["IDELEMENT"]));
            IDataReader reader = command.FetchData();
            if (!command.HasMoreRows)
            {
                reader.Close();
                throw new ELEMENTForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("ELEMENT") }));
            }
            reader.Close();
            throw new ForeignKeyNotFoundException(this.resourceManager.GetString("refinterror"));
        }

        private void CheckOptimisticConcurrencyRad1melementiveza()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [RAD1ELEMENTIID], [IDELEMENT] FROM [RAD1MELEMENTIVEZA] WITH (UPDLOCK) WHERE [RAD1ELEMENTIID] = @RAD1ELEMENTIID AND [IDELEMENT] = @IDELEMENT ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RAD1ELEMENTIID", DbType.Int32));
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDELEMENT", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRAD1MELEMENTIVEZA["RAD1ELEMENTIID"]));
                command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowRAD1MELEMENTIVEZA["IDELEMENT"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new RAD1MELEMENTIVEZADataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("RAD1MELEMENTIVEZA") }));
                }
                if (!command.HasMoreRows)
                {
                    reader.Close();
                    throw new RAD1MELEMENTIVEZADataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("RAD1MELEMENTIVEZA") }));
                }
                reader.Close();
            }
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        private void CreateNewRowRad1melementiveza()
        {
            this.rowRAD1MELEMENTIVEZA = this.RAD1MELEMENTIVEZASet.RAD1MELEMENTIVEZA.NewRAD1MELEMENTIVEZARow();
        }

        private void Delete()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyRad1melementiveza();
            this.AfterConfirmRad1melementiveza();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [RAD1MELEMENTIVEZA]  WHERE [RAD1ELEMENTIID] = @RAD1ELEMENTIID AND [IDELEMENT] = @IDELEMENT", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RAD1ELEMENTIID", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDELEMENT", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRAD1MELEMENTIVEZA["RAD1ELEMENTIID"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowRAD1MELEMENTIVEZA["IDELEMENT"]));
            command.ExecuteStmt();
            this.OnRAD1MELEMENTIVEZAUpdated(new RAD1MELEMENTIVEZAEventArgs(this.rowRAD1MELEMENTIVEZA, StatementType.Delete));
            this.rowRAD1MELEMENTIVEZA.Delete();
            this.sMode287 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode287;
        }

        public virtual int Fill(RAD1MELEMENTIVEZADataSet dataSet)
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
                    this.RAD1MELEMENTIVEZASet = dataSet;
                    this.LoadChildRad1melementiveza(0, -1);
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
            this.RAD1MELEMENTIVEZASet = (RAD1MELEMENTIVEZADataSet) dataSet;
            if (this.RAD1MELEMENTIVEZASet != null)
            {
                return this.Fill(this.RAD1MELEMENTIVEZASet);
            }
            this.RAD1MELEMENTIVEZASet = new RAD1MELEMENTIVEZADataSet();
            this.Fill(this.RAD1MELEMENTIVEZASet);
            dataSet.Merge(this.RAD1MELEMENTIVEZASet);
            return 0;
        }

        public virtual int Fill(RAD1MELEMENTIVEZADataSet dataSet, DataRow dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["RAD1ELEMENTIID"]), Conversions.ToInteger(dataRecord["IDELEMENT"]));
        }

        public virtual int Fill(RAD1MELEMENTIVEZADataSet dataSet, IDataRecord dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["RAD1ELEMENTIID"]), Conversions.ToInteger(dataRecord["IDELEMENT"]));
        }

        public virtual int Fill(RAD1MELEMENTIVEZADataSet dataSet, int rAD1ELEMENTIID, int iDELEMENT)
        {
            if (!this.FillByRAD1ELEMENTIIDIDELEMENT(dataSet, rAD1ELEMENTIID, iDELEMENT))
            {
                throw new RAD1MELEMENTIVEZANotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("RAD1MELEMENTIVEZA") }));
            }
            return 0;
        }

        public virtual int FillByIDELEMENT(RAD1MELEMENTIVEZADataSet dataSet, int iDELEMENT)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.RAD1MELEMENTIVEZASet = dataSet;
            this.rowRAD1MELEMENTIVEZA = this.RAD1MELEMENTIVEZASet.RAD1MELEMENTIVEZA.NewRAD1MELEMENTIVEZARow();
            this.rowRAD1MELEMENTIVEZA.IDELEMENT = iDELEMENT;
            try
            {
                this.LoadByIDELEMENT(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillByRAD1ELEMENTIID(RAD1MELEMENTIVEZADataSet dataSet, int rAD1ELEMENTIID)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.RAD1MELEMENTIVEZASet = dataSet;
            this.rowRAD1MELEMENTIVEZA = this.RAD1MELEMENTIVEZASet.RAD1MELEMENTIVEZA.NewRAD1MELEMENTIVEZARow();
            this.rowRAD1MELEMENTIVEZA.RAD1ELEMENTIID = rAD1ELEMENTIID;
            try
            {
                this.LoadByRAD1ELEMENTIID(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual bool FillByRAD1ELEMENTIIDIDELEMENT(RAD1MELEMENTIVEZADataSet dataSet, int rAD1ELEMENTIID, int iDELEMENT)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.RAD1MELEMENTIVEZASet = dataSet;
            this.rowRAD1MELEMENTIVEZA = this.RAD1MELEMENTIVEZASet.RAD1MELEMENTIVEZA.NewRAD1MELEMENTIVEZARow();
            this.rowRAD1MELEMENTIVEZA.RAD1ELEMENTIID = rAD1ELEMENTIID;
            this.rowRAD1MELEMENTIVEZA.IDELEMENT = iDELEMENT;
            try
            {
                this.LoadByRAD1ELEMENTIIDIDELEMENT(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            if (this.RcdFound287 == 0)
            {
                return false;
            }
            return true;
        }

        public virtual int FillPage(RAD1MELEMENTIVEZADataSet dataSet, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.RAD1MELEMENTIVEZASet = dataSet;
            try
            {
                this.LoadChildRad1melementiveza(startRow, maxRows);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillPageByIDELEMENT(RAD1MELEMENTIVEZADataSet dataSet, int iDELEMENT, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.RAD1MELEMENTIVEZASet = dataSet;
            this.rowRAD1MELEMENTIVEZA = this.RAD1MELEMENTIVEZASet.RAD1MELEMENTIVEZA.NewRAD1MELEMENTIVEZARow();
            this.rowRAD1MELEMENTIVEZA.IDELEMENT = iDELEMENT;
            try
            {
                this.LoadByIDELEMENT(startRow, maxRows);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillPageByRAD1ELEMENTIID(RAD1MELEMENTIVEZADataSet dataSet, int rAD1ELEMENTIID, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.RAD1MELEMENTIVEZASet = dataSet;
            this.rowRAD1MELEMENTIVEZA = this.RAD1MELEMENTIVEZASet.RAD1MELEMENTIVEZA.NewRAD1MELEMENTIVEZARow();
            this.rowRAD1MELEMENTIVEZA.RAD1ELEMENTIID = rAD1ELEMENTIID;
            try
            {
                this.LoadByRAD1ELEMENTIID(startRow, maxRows);
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
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [RAD1ELEMENTIID], [IDELEMENT] FROM [RAD1MELEMENTIVEZA] WITH (NOLOCK) WHERE [RAD1ELEMENTIID] = @RAD1ELEMENTIID AND [IDELEMENT] = @IDELEMENT ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RAD1ELEMENTIID", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDELEMENT", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRAD1MELEMENTIVEZA["RAD1ELEMENTIID"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowRAD1MELEMENTIVEZA["IDELEMENT"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.RcdFound287 = 1;
                this.rowRAD1MELEMENTIVEZA["RAD1ELEMENTIID"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 0));
                this.rowRAD1MELEMENTIVEZA["IDELEMENT"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 1));
                this.sMode287 = this.Gx_mode;
                this.Gx_mode = StatementType.Select;
                this.Gx_mode = this.sMode287;
            }
            else
            {
                this.RcdFound287 = 0;
            }
            reader.Close();
        }

        public virtual IDataParameter[] GetFillParameters()
        {
            if (this.fillDataParameters == null)
            {
                DbProviderFactory factory = DbProviderFactories.GetFactory("System.Data.SqlClient");
                DbParameter parameter = factory.CreateParameter();
                parameter.ParameterName = "RAD1ELEMENTIID";
                parameter.DbType = DbType.Int32;
                DbParameter parameter2 = factory.CreateParameter();
                parameter2.ParameterName = "IDELEMENT";
                parameter2.DbType = DbType.Int32;
                this.fillDataParameters = new DbParameter[] { parameter, parameter2 };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount()
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmRAD1MELEMENTIVEZASelect3 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [RAD1MELEMENTIVEZA] WITH (NOLOCK) ", false);
            this.RAD1MELEMENTIVEZASelect3 = this.cmRAD1MELEMENTIVEZASelect3.FetchData();
            if (this.RAD1MELEMENTIVEZASelect3.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.RAD1MELEMENTIVEZASelect3.GetInt32(0);
            }
            this.RAD1MELEMENTIVEZASelect3.Close();
            return this.recordCount;
        }

        private int GetInternalRecordCountByIDELEMENT(int iDELEMENT)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmRAD1MELEMENTIVEZASelect2 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [RAD1MELEMENTIVEZA] WITH (NOLOCK) WHERE [IDELEMENT] = @IDELEMENT ", false);
            if (this.cmRAD1MELEMENTIVEZASelect2.IDbCommand.Parameters.Count == 0)
            {
                this.cmRAD1MELEMENTIVEZASelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDELEMENT", DbType.Int32));
            }
            this.cmRAD1MELEMENTIVEZASelect2.SetParameter(0, iDELEMENT);
            this.RAD1MELEMENTIVEZASelect2 = this.cmRAD1MELEMENTIVEZASelect2.FetchData();
            if (this.RAD1MELEMENTIVEZASelect2.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.RAD1MELEMENTIVEZASelect2.GetInt32(0);
            }
            this.RAD1MELEMENTIVEZASelect2.Close();
            return this.recordCount;
        }

        private int GetInternalRecordCountByRAD1ELEMENTIID(int rAD1ELEMENTIID)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmRAD1MELEMENTIVEZASelect1 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [RAD1MELEMENTIVEZA] WITH (NOLOCK) WHERE [RAD1ELEMENTIID] = @RAD1ELEMENTIID ", false);
            if (this.cmRAD1MELEMENTIVEZASelect1.IDbCommand.Parameters.Count == 0)
            {
                this.cmRAD1MELEMENTIVEZASelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RAD1ELEMENTIID", DbType.Int32));
            }
            this.cmRAD1MELEMENTIVEZASelect1.SetParameter(0, rAD1ELEMENTIID);
            this.RAD1MELEMENTIVEZASelect1 = this.cmRAD1MELEMENTIVEZASelect1.FetchData();
            if (this.RAD1MELEMENTIVEZASelect1.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.RAD1MELEMENTIVEZASelect1.GetInt32(0);
            }
            this.RAD1MELEMENTIVEZASelect1.Close();
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

        public virtual int GetRecordCountByIDELEMENT(int iDELEMENT)
        {
            int internalRecordCountByIDELEMENT;
            try
            {
                this.InitializeMembers();
                internalRecordCountByIDELEMENT = this.GetInternalRecordCountByIDELEMENT(iDELEMENT);
            }
            finally
            {
                this.Cleanup();
            }
            return internalRecordCountByIDELEMENT;
        }

        public virtual int GetRecordCountByRAD1ELEMENTIID(int rAD1ELEMENTIID)
        {
            int num2 = 0;
            try
            {
                this.InitializeMembers();
                num2 = this.GetInternalRecordCountByRAD1ELEMENTIID(rAD1ELEMENTIID);
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
            this.RcdFound287 = 0;
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
            this.RAD1MELEMENTIVEZASet = new RAD1MELEMENTIVEZADataSet();
            this.Initialize();
            this.dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        }

        private void InsertRad1melementiveza()
        {
            this.CheckOptimisticConcurrencyRad1melementiveza();
            this.AfterConfirmRad1melementiveza();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [RAD1MELEMENTIVEZA] ([RAD1ELEMENTIID], [IDELEMENT]) VALUES (@RAD1ELEMENTIID, @IDELEMENT)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RAD1ELEMENTIID", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDELEMENT", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRAD1MELEMENTIVEZA["RAD1ELEMENTIID"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowRAD1MELEMENTIVEZA["IDELEMENT"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new RAD1MELEMENTIVEZADuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            if (command.ForeignKeyError)
            {
                this.CheckIntegrityErrorsRad1melementiveza();
            }
            this.OnRAD1MELEMENTIVEZAUpdated(new RAD1MELEMENTIVEZAEventArgs(this.rowRAD1MELEMENTIVEZA, StatementType.Insert));
        }

        private void LoadByIDELEMENT(int startRow, int maxRows)
        {
            bool enforceConstraints = this.RAD1MELEMENTIVEZASet.EnforceConstraints;
            this.RAD1MELEMENTIVEZASet.RAD1MELEMENTIVEZA.BeginLoadData();
            this.ScanByIDELEMENT(startRow, maxRows);
            this.RAD1MELEMENTIVEZASet.RAD1MELEMENTIVEZA.EndLoadData();
            this.RAD1MELEMENTIVEZASet.EnforceConstraints = enforceConstraints;
            if (this.RAD1MELEMENTIVEZASet.RAD1MELEMENTIVEZA.Count > 0)
            {
                this.rowRAD1MELEMENTIVEZA = this.RAD1MELEMENTIVEZASet.RAD1MELEMENTIVEZA[this.RAD1MELEMENTIVEZASet.RAD1MELEMENTIVEZA.Count - 1];
            }
        }

        private void LoadByRAD1ELEMENTIID(int startRow, int maxRows)
        {
            bool enforceConstraints = this.RAD1MELEMENTIVEZASet.EnforceConstraints;
            this.RAD1MELEMENTIVEZASet.RAD1MELEMENTIVEZA.BeginLoadData();
            this.ScanByRAD1ELEMENTIID(startRow, maxRows);
            this.RAD1MELEMENTIVEZASet.RAD1MELEMENTIVEZA.EndLoadData();
            this.RAD1MELEMENTIVEZASet.EnforceConstraints = enforceConstraints;
            if (this.RAD1MELEMENTIVEZASet.RAD1MELEMENTIVEZA.Count > 0)
            {
                this.rowRAD1MELEMENTIVEZA = this.RAD1MELEMENTIVEZASet.RAD1MELEMENTIVEZA[this.RAD1MELEMENTIVEZASet.RAD1MELEMENTIVEZA.Count - 1];
            }
        }

        private void LoadByRAD1ELEMENTIIDIDELEMENT(int startRow, int maxRows)
        {
            bool enforceConstraints = this.RAD1MELEMENTIVEZASet.EnforceConstraints;
            this.RAD1MELEMENTIVEZASet.RAD1MELEMENTIVEZA.BeginLoadData();
            this.ScanByRAD1ELEMENTIIDIDELEMENT(startRow, maxRows);
            this.RAD1MELEMENTIVEZASet.RAD1MELEMENTIVEZA.EndLoadData();
            this.RAD1MELEMENTIVEZASet.EnforceConstraints = enforceConstraints;
            if (this.RAD1MELEMENTIVEZASet.RAD1MELEMENTIVEZA.Count > 0)
            {
                this.rowRAD1MELEMENTIVEZA = this.RAD1MELEMENTIVEZASet.RAD1MELEMENTIVEZA[this.RAD1MELEMENTIVEZASet.RAD1MELEMENTIVEZA.Count - 1];
            }
        }

        private void LoadChildRad1melementiveza(int startRow, int maxRows)
        {
            this.CreateNewRowRad1melementiveza();
            bool enforceConstraints = this.RAD1MELEMENTIVEZASet.EnforceConstraints;
            this.RAD1MELEMENTIVEZASet.RAD1MELEMENTIVEZA.BeginLoadData();
            this.ScanStartRad1melementiveza(startRow, maxRows);
            this.RAD1MELEMENTIVEZASet.RAD1MELEMENTIVEZA.EndLoadData();
            this.RAD1MELEMENTIVEZASet.EnforceConstraints = enforceConstraints;
        }

        private void LoadDataRad1melementiveza(int maxRows)
        {
            int num = 0;
            if (this.RcdFound287 != 0)
            {
                this.ScanLoadRad1melementiveza();
                while ((this.RcdFound287 != 0) && (num != maxRows))
                {
                    num++;
                    this.LoadRowRad1melementiveza();
                    this.CreateNewRowRad1melementiveza();
                    this.ScanNextRad1melementiveza();
                }
            }
            if (num > 0)
            {
                this.RcdFound287 = 1;
            }
            this.ScanEndRad1melementiveza();
            if (this.RAD1MELEMENTIVEZASet.RAD1MELEMENTIVEZA.Count > 0)
            {
                this.rowRAD1MELEMENTIVEZA = this.RAD1MELEMENTIVEZASet.RAD1MELEMENTIVEZA[this.RAD1MELEMENTIVEZASet.RAD1MELEMENTIVEZA.Count - 1];
            }
        }

        private void LoadRowRad1melementiveza()
        {
            this.AddRowRad1melementiveza();
        }

        private void OnRAD1MELEMENTIVEZAUpdated(RAD1MELEMENTIVEZAEventArgs e)
        {
            if (this.RAD1MELEMENTIVEZAUpdated != null)
            {
                RAD1MELEMENTIVEZAUpdateEventHandler handler = this.RAD1MELEMENTIVEZAUpdated;
                if (handler != null)
                {
                    handler(this, e);
                }
            }
        }

        private void OnRAD1MELEMENTIVEZAUpdating(RAD1MELEMENTIVEZAEventArgs e)
        {
            if (this.RAD1MELEMENTIVEZAUpdating != null)
            {
                RAD1MELEMENTIVEZAUpdateEventHandler handler = this.RAD1MELEMENTIVEZAUpdating;
                if (handler != null)
                {
                    handler(this, e);
                }
            }
        }

        private void ReadRowRad1melementiveza()
        {
            this.Gx_mode = Mode.FromRowState(this.rowRAD1MELEMENTIVEZA.RowState);
            if (this.rowRAD1MELEMENTIVEZA.RowState == DataRowState.Added)
            {
            }
            this._Gxremove = this.rowRAD1MELEMENTIVEZA.RowState == DataRowState.Deleted;
            if (this._Gxremove)
            {
                this.rowRAD1MELEMENTIVEZA = (RAD1MELEMENTIVEZADataSet.RAD1MELEMENTIVEZARow) DataSetUtil.CloneOriginalDataRow(this.rowRAD1MELEMENTIVEZA);
            }
        }

        private void ScanByIDELEMENT(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[IDELEMENT] = @IDELEMENT";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString287 + "  FROM [RAD1MELEMENTIVEZA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[RAD1ELEMENTIID], TM1.[IDELEMENT]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString287, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[RAD1ELEMENTIID], TM1.[IDELEMENT] ) AS DK_PAGENUM   FROM [RAD1MELEMENTIVEZA] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString287 + " FROM [RAD1MELEMENTIVEZA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[RAD1ELEMENTIID], TM1.[IDELEMENT] ";
            }
            this.cmRAD1MELEMENTIVEZASelect6 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmRAD1MELEMENTIVEZASelect6.IDbCommand.Parameters.Count == 0)
            {
                this.cmRAD1MELEMENTIVEZASelect6.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDELEMENT", DbType.Int32));
            }
            this.cmRAD1MELEMENTIVEZASelect6.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRAD1MELEMENTIVEZA["IDELEMENT"]));
            this.RAD1MELEMENTIVEZASelect6 = this.cmRAD1MELEMENTIVEZASelect6.FetchData();
            this.RcdFound287 = 0;
            this.ScanLoadRad1melementiveza();
            this.LoadDataRad1melementiveza(maxRows);
        }

        private void ScanByRAD1ELEMENTIID(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[RAD1ELEMENTIID] = @RAD1ELEMENTIID";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString287 + "  FROM [RAD1MELEMENTIVEZA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[RAD1ELEMENTIID], TM1.[IDELEMENT]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString287, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[RAD1ELEMENTIID], TM1.[IDELEMENT] ) AS DK_PAGENUM   FROM [RAD1MELEMENTIVEZA] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString287 + " FROM [RAD1MELEMENTIVEZA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[RAD1ELEMENTIID], TM1.[IDELEMENT] ";
            }
            this.cmRAD1MELEMENTIVEZASelect6 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmRAD1MELEMENTIVEZASelect6.IDbCommand.Parameters.Count == 0)
            {
                this.cmRAD1MELEMENTIVEZASelect6.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RAD1ELEMENTIID", DbType.Int32));
            }
            this.cmRAD1MELEMENTIVEZASelect6.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRAD1MELEMENTIVEZA["RAD1ELEMENTIID"]));
            this.RAD1MELEMENTIVEZASelect6 = this.cmRAD1MELEMENTIVEZASelect6.FetchData();
            this.RcdFound287 = 0;
            this.ScanLoadRad1melementiveza();
            this.LoadDataRad1melementiveza(maxRows);
        }

        private void ScanByRAD1ELEMENTIIDIDELEMENT(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[RAD1ELEMENTIID] = @RAD1ELEMENTIID and TM1.[IDELEMENT] = @IDELEMENT";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString287 + "  FROM [RAD1MELEMENTIVEZA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[RAD1ELEMENTIID], TM1.[IDELEMENT]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString287, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[RAD1ELEMENTIID], TM1.[IDELEMENT] ) AS DK_PAGENUM   FROM [RAD1MELEMENTIVEZA] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString287 + " FROM [RAD1MELEMENTIVEZA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[RAD1ELEMENTIID], TM1.[IDELEMENT] ";
            }
            this.cmRAD1MELEMENTIVEZASelect6 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmRAD1MELEMENTIVEZASelect6.IDbCommand.Parameters.Count == 0)
            {
                this.cmRAD1MELEMENTIVEZASelect6.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RAD1ELEMENTIID", DbType.Int32));
                this.cmRAD1MELEMENTIVEZASelect6.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDELEMENT", DbType.Int32));
            }
            this.cmRAD1MELEMENTIVEZASelect6.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRAD1MELEMENTIVEZA["RAD1ELEMENTIID"]));
            this.cmRAD1MELEMENTIVEZASelect6.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowRAD1MELEMENTIVEZA["IDELEMENT"]));
            this.RAD1MELEMENTIVEZASelect6 = this.cmRAD1MELEMENTIVEZASelect6.FetchData();
            this.RcdFound287 = 0;
            this.ScanLoadRad1melementiveza();
            this.LoadDataRad1melementiveza(maxRows);
        }

        private void ScanEndRad1melementiveza()
        {
            this.RAD1MELEMENTIVEZASelect6.Close();
        }

        private void ScanLoadRad1melementiveza()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmRAD1MELEMENTIVEZASelect6.HasMoreRows)
            {
                this.RcdFound287 = 1;
                this.rowRAD1MELEMENTIVEZA["RAD1ELEMENTIID"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.RAD1MELEMENTIVEZASelect6, 0));
                this.rowRAD1MELEMENTIVEZA["IDELEMENT"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.RAD1MELEMENTIVEZASelect6, 1));
            }
        }

        private void ScanNextRad1melementiveza()
        {
            this.cmRAD1MELEMENTIVEZASelect6.HasMoreRows = this.RAD1MELEMENTIVEZASelect6.Read();
            this.RcdFound287 = 0;
            this.ScanLoadRad1melementiveza();
        }

        private void ScanStartRad1melementiveza(int startRow, int maxRows)
        {
            this.m_WhereString = "";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString287 + "  FROM [RAD1MELEMENTIVEZA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[RAD1ELEMENTIID], TM1.[IDELEMENT]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString287, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[RAD1ELEMENTIID], TM1.[IDELEMENT] ) AS DK_PAGENUM   FROM [RAD1MELEMENTIVEZA] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString287 + " FROM [RAD1MELEMENTIVEZA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[RAD1ELEMENTIID], TM1.[IDELEMENT] ";
            }
            this.cmRAD1MELEMENTIVEZASelect6 = this.connDefault.GetCommand(this.scmdbuf, false);
            this.RAD1MELEMENTIVEZASelect6 = this.cmRAD1MELEMENTIVEZASelect6.FetchData();
            this.RcdFound287 = 0;
            this.ScanLoadRad1melementiveza();
            this.LoadDataRad1melementiveza(maxRows);
        }

        public virtual int Update(DataSet dataSet)
        {
            this.InitializeMembers();
            this.RAD1MELEMENTIVEZASet = (RAD1MELEMENTIVEZADataSet) dataSet;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            if (this.RAD1MELEMENTIVEZASet == null)
            {
                throw new ArgumentException(this.resourceManager.GetString("nulldset"));
            }
            try
            {
                IEnumerator enumerator = null;
                this.connDefault.BeginTransaction();
                try
                {
                    enumerator = this.RAD1MELEMENTIVEZASet.RAD1MELEMENTIVEZA.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        RAD1MELEMENTIVEZADataSet.RAD1MELEMENTIVEZARow current = (RAD1MELEMENTIVEZADataSet.RAD1MELEMENTIVEZARow) enumerator.Current;
                        this.rowRAD1MELEMENTIVEZA = current;
                        if (Helpers.IsRowChanged(this.rowRAD1MELEMENTIVEZA))
                        {
                            this.ReadRowRad1melementiveza();
                            if (this.rowRAD1MELEMENTIVEZA.RowState == DataRowState.Added)
                            {
                                this.InsertRad1melementiveza();
                            }
                            else
                            {
                                if (this._Gxremove)
                                {
                                    this.Delete();
                                    continue;
                                }
                                this.UpdateRad1melementiveza();
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

        private void UpdateRad1melementiveza()
        {
            this.CheckOptimisticConcurrencyRad1melementiveza();
            this.AfterConfirmRad1melementiveza();
            this.OnRAD1MELEMENTIVEZAUpdated(new RAD1MELEMENTIVEZAEventArgs(this.rowRAD1MELEMENTIVEZA, StatementType.Update));
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
        public class ELEMENTForeignKeyNotFoundException : Deklarit.ForeignKeyNotFoundException
        {
            public ELEMENTForeignKeyNotFoundException()
            {
            }

            public ELEMENTForeignKeyNotFoundException(string message) : base(message)
            {
            }

            protected ELEMENTForeignKeyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public ELEMENTForeignKeyNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
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
        public class RAD1MELEMENTIForeignKeyNotFoundException : Deklarit.ForeignKeyNotFoundException
        {
            public RAD1MELEMENTIForeignKeyNotFoundException()
            {
            }

            public RAD1MELEMENTIForeignKeyNotFoundException(string message) : base(message)
            {
            }

            protected RAD1MELEMENTIForeignKeyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public RAD1MELEMENTIForeignKeyNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class RAD1MELEMENTIVEZADataChangedException : DataChangedException
        {
            public RAD1MELEMENTIVEZADataChangedException()
            {
            }

            public RAD1MELEMENTIVEZADataChangedException(string message) : base(message)
            {
            }

            protected RAD1MELEMENTIVEZADataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public RAD1MELEMENTIVEZADataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class RAD1MELEMENTIVEZADataLockedException : DataLockedException
        {
            public RAD1MELEMENTIVEZADataLockedException()
            {
            }

            public RAD1MELEMENTIVEZADataLockedException(string message) : base(message)
            {
            }

            protected RAD1MELEMENTIVEZADataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public RAD1MELEMENTIVEZADataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class RAD1MELEMENTIVEZADuplicateKeyException : DuplicateKeyException
        {
            public RAD1MELEMENTIVEZADuplicateKeyException()
            {
            }

            public RAD1MELEMENTIVEZADuplicateKeyException(string message) : base(message)
            {
            }

            protected RAD1MELEMENTIVEZADuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public RAD1MELEMENTIVEZADuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class RAD1MELEMENTIVEZAEventArgs : EventArgs
        {
            private RAD1MELEMENTIVEZADataSet.RAD1MELEMENTIVEZARow m_dataRow;
            private System.Data.StatementType m_statementType;

            public RAD1MELEMENTIVEZAEventArgs(RAD1MELEMENTIVEZADataSet.RAD1MELEMENTIVEZARow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public RAD1MELEMENTIVEZADataSet.RAD1MELEMENTIVEZARow Row
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
        public class RAD1MELEMENTIVEZANotFoundException : DataNotFoundException
        {
            public RAD1MELEMENTIVEZANotFoundException()
            {
            }

            public RAD1MELEMENTIVEZANotFoundException(string message) : base(message)
            {
            }

            protected RAD1MELEMENTIVEZANotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public RAD1MELEMENTIVEZANotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public delegate void RAD1MELEMENTIVEZAUpdateEventHandler(object sender, RAD1MELEMENTIVEZADataAdapter.RAD1MELEMENTIVEZAEventArgs e);
    }
}


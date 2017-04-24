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

    public class RAD1GELEMENTIVEZADataAdapter : IDataAdapter, IRAD1GELEMENTIVEZADataAdapter
    {
        private bool _Gxremove;
        private ReadWriteCommand cmRAD1GELEMENTIVEZASelect1;
        private ReadWriteCommand cmRAD1GELEMENTIVEZASelect2;
        private ReadWriteCommand cmRAD1GELEMENTIVEZASelect3;
        private ReadWriteCommand cmRAD1GELEMENTIVEZASelect6;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private DbParameter[] fillDataParameters;
        private StatementType Gx_mode;
        private readonly string m_SelectString286 = "TM1.[RAD1GELEMENTIID], TM1.[IDELEMENT]";
        private string m_WhereString;
        private IDataReader RAD1GELEMENTIVEZASelect1;
        private IDataReader RAD1GELEMENTIVEZASelect2;
        private IDataReader RAD1GELEMENTIVEZASelect3;
        private IDataReader RAD1GELEMENTIVEZASelect6;
        private RAD1GELEMENTIVEZADataSet RAD1GELEMENTIVEZASet;
        private short RcdFound286;
        private int recordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private RAD1GELEMENTIVEZADataSet.RAD1GELEMENTIVEZARow rowRAD1GELEMENTIVEZA;
        private string scmdbuf;
        private StatementType sMode286;

        public event RAD1GELEMENTIVEZAUpdateEventHandler RAD1GELEMENTIVEZAUpdated;

        public event RAD1GELEMENTIVEZAUpdateEventHandler RAD1GELEMENTIVEZAUpdating;

        private void AddRowRad1gelementiveza()
        {
            this.RAD1GELEMENTIVEZASet.RAD1GELEMENTIVEZA.AddRAD1GELEMENTIVEZARow(this.rowRAD1GELEMENTIVEZA);
        }

        private void AfterConfirmRad1gelementiveza()
        {
            this.OnRAD1GELEMENTIVEZAUpdating(new RAD1GELEMENTIVEZAEventArgs(this.rowRAD1GELEMENTIVEZA, this.Gx_mode));
        }

        private void CheckIntegrityErrorsRad1gelementiveza()
        {
            ReadWriteCommand command2 = this.connDefault.GetCommand("SELECT [RAD1GELEMENTIID] FROM [RAD1GELEMENTI] WITH (NOLOCK) WHERE [RAD1GELEMENTIID] = @RAD1GELEMENTIID ", false);
            if (command2.IDbCommand.Parameters.Count == 0)
            {
                command2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RAD1GELEMENTIID", DbType.Int32));
            }
            command2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRAD1GELEMENTIVEZA["RAD1GELEMENTIID"]));
            IDataReader reader2 = command2.FetchData();
            if (!command2.HasMoreRows)
            {
                reader2.Close();
                throw new RAD1GELEMENTIForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("RAD1GELEMENTI") }));
            }
            reader2.Close();
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDELEMENT] FROM [ELEMENT] WITH (NOLOCK) WHERE [IDELEMENT] = @IDELEMENT ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDELEMENT", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRAD1GELEMENTIVEZA["IDELEMENT"]));
            IDataReader reader = command.FetchData();
            if (!command.HasMoreRows)
            {
                reader.Close();
                throw new ELEMENTForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("ELEMENT") }));
            }
            reader.Close();
            throw new ForeignKeyNotFoundException(this.resourceManager.GetString("refinterror"));
        }

        private void CheckOptimisticConcurrencyRad1gelementiveza()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [RAD1GELEMENTIID], [IDELEMENT] FROM [RAD1GELEMENTIVEZA] WITH (UPDLOCK) WHERE [RAD1GELEMENTIID] = @RAD1GELEMENTIID AND [IDELEMENT] = @IDELEMENT ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RAD1GELEMENTIID", DbType.Int32));
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDELEMENT", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRAD1GELEMENTIVEZA["RAD1GELEMENTIID"]));
                command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowRAD1GELEMENTIVEZA["IDELEMENT"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new RAD1GELEMENTIVEZADataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("RAD1GELEMENTIVEZA") }));
                }
                if (!command.HasMoreRows)
                {
                    reader.Close();
                    throw new RAD1GELEMENTIVEZADataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("RAD1GELEMENTIVEZA") }));
                }
                reader.Close();
            }
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        private void CreateNewRowRad1gelementiveza()
        {
            this.rowRAD1GELEMENTIVEZA = this.RAD1GELEMENTIVEZASet.RAD1GELEMENTIVEZA.NewRAD1GELEMENTIVEZARow();
        }

        private void Delete()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyRad1gelementiveza();
            this.AfterConfirmRad1gelementiveza();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [RAD1GELEMENTIVEZA]  WHERE [RAD1GELEMENTIID] = @RAD1GELEMENTIID AND [IDELEMENT] = @IDELEMENT", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RAD1GELEMENTIID", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDELEMENT", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRAD1GELEMENTIVEZA["RAD1GELEMENTIID"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowRAD1GELEMENTIVEZA["IDELEMENT"]));
            command.ExecuteStmt();
            this.OnRAD1GELEMENTIVEZAUpdated(new RAD1GELEMENTIVEZAEventArgs(this.rowRAD1GELEMENTIVEZA, StatementType.Delete));
            this.rowRAD1GELEMENTIVEZA.Delete();
            this.sMode286 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode286;
        }

        public virtual int Fill(RAD1GELEMENTIVEZADataSet dataSet)
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
                    this.RAD1GELEMENTIVEZASet = dataSet;
                    this.LoadChildRad1gelementiveza(0, -1);
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
            this.RAD1GELEMENTIVEZASet = (RAD1GELEMENTIVEZADataSet) dataSet;
            if (this.RAD1GELEMENTIVEZASet != null)
            {
                return this.Fill(this.RAD1GELEMENTIVEZASet);
            }
            this.RAD1GELEMENTIVEZASet = new RAD1GELEMENTIVEZADataSet();
            this.Fill(this.RAD1GELEMENTIVEZASet);
            dataSet.Merge(this.RAD1GELEMENTIVEZASet);
            return 0;
        }

        public virtual int Fill(RAD1GELEMENTIVEZADataSet dataSet, DataRow dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["RAD1GELEMENTIID"]), Conversions.ToInteger(dataRecord["IDELEMENT"]));
        }

        public virtual int Fill(RAD1GELEMENTIVEZADataSet dataSet, IDataRecord dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["RAD1GELEMENTIID"]), Conversions.ToInteger(dataRecord["IDELEMENT"]));
        }

        public virtual int Fill(RAD1GELEMENTIVEZADataSet dataSet, int rAD1GELEMENTIID, int iDELEMENT)
        {
            if (!this.FillByRAD1GELEMENTIIDIDELEMENT(dataSet, rAD1GELEMENTIID, iDELEMENT))
            {
                throw new RAD1GELEMENTIVEZANotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("RAD1GELEMENTIVEZA") }));
            }
            return 0;
        }

        public virtual int FillByIDELEMENT(RAD1GELEMENTIVEZADataSet dataSet, int iDELEMENT)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.RAD1GELEMENTIVEZASet = dataSet;
            this.rowRAD1GELEMENTIVEZA = this.RAD1GELEMENTIVEZASet.RAD1GELEMENTIVEZA.NewRAD1GELEMENTIVEZARow();
            this.rowRAD1GELEMENTIVEZA.IDELEMENT = iDELEMENT;
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

        public virtual int FillByRAD1GELEMENTIID(RAD1GELEMENTIVEZADataSet dataSet, int rAD1GELEMENTIID)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.RAD1GELEMENTIVEZASet = dataSet;
            this.rowRAD1GELEMENTIVEZA = this.RAD1GELEMENTIVEZASet.RAD1GELEMENTIVEZA.NewRAD1GELEMENTIVEZARow();
            this.rowRAD1GELEMENTIVEZA.RAD1GELEMENTIID = rAD1GELEMENTIID;
            try
            {
                this.LoadByRAD1GELEMENTIID(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual bool FillByRAD1GELEMENTIIDIDELEMENT(RAD1GELEMENTIVEZADataSet dataSet, int rAD1GELEMENTIID, int iDELEMENT)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.RAD1GELEMENTIVEZASet = dataSet;
            this.rowRAD1GELEMENTIVEZA = this.RAD1GELEMENTIVEZASet.RAD1GELEMENTIVEZA.NewRAD1GELEMENTIVEZARow();
            this.rowRAD1GELEMENTIVEZA.RAD1GELEMENTIID = rAD1GELEMENTIID;
            this.rowRAD1GELEMENTIVEZA.IDELEMENT = iDELEMENT;
            try
            {
                this.LoadByRAD1GELEMENTIIDIDELEMENT(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            if (this.RcdFound286 == 0)
            {
                return false;
            }
            return true;
        }

        public virtual int FillPage(RAD1GELEMENTIVEZADataSet dataSet, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.RAD1GELEMENTIVEZASet = dataSet;
            try
            {
                this.LoadChildRad1gelementiveza(startRow, maxRows);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillPageByIDELEMENT(RAD1GELEMENTIVEZADataSet dataSet, int iDELEMENT, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.RAD1GELEMENTIVEZASet = dataSet;
            this.rowRAD1GELEMENTIVEZA = this.RAD1GELEMENTIVEZASet.RAD1GELEMENTIVEZA.NewRAD1GELEMENTIVEZARow();
            this.rowRAD1GELEMENTIVEZA.IDELEMENT = iDELEMENT;
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

        public virtual int FillPageByRAD1GELEMENTIID(RAD1GELEMENTIVEZADataSet dataSet, int rAD1GELEMENTIID, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.RAD1GELEMENTIVEZASet = dataSet;
            this.rowRAD1GELEMENTIVEZA = this.RAD1GELEMENTIVEZASet.RAD1GELEMENTIVEZA.NewRAD1GELEMENTIVEZARow();
            this.rowRAD1GELEMENTIVEZA.RAD1GELEMENTIID = rAD1GELEMENTIID;
            try
            {
                this.LoadByRAD1GELEMENTIID(startRow, maxRows);
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
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [RAD1GELEMENTIID], [IDELEMENT] FROM [RAD1GELEMENTIVEZA] WITH (NOLOCK) WHERE [RAD1GELEMENTIID] = @RAD1GELEMENTIID AND [IDELEMENT] = @IDELEMENT ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RAD1GELEMENTIID", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDELEMENT", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRAD1GELEMENTIVEZA["RAD1GELEMENTIID"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowRAD1GELEMENTIVEZA["IDELEMENT"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.RcdFound286 = 1;
                this.rowRAD1GELEMENTIVEZA["RAD1GELEMENTIID"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 0));
                this.rowRAD1GELEMENTIVEZA["IDELEMENT"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 1));
                this.sMode286 = this.Gx_mode;
                this.Gx_mode = StatementType.Select;
                this.Gx_mode = this.sMode286;
            }
            else
            {
                this.RcdFound286 = 0;
            }
            reader.Close();
        }

        public virtual IDataParameter[] GetFillParameters()
        {
            if (this.fillDataParameters == null)
            {
                DbProviderFactory factory = DbProviderFactories.GetFactory("System.Data.SqlClient");
                DbParameter parameter = factory.CreateParameter();
                parameter.ParameterName = "RAD1GELEMENTIID";
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
            this.cmRAD1GELEMENTIVEZASelect3 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [RAD1GELEMENTIVEZA] WITH (NOLOCK) ", false);
            this.RAD1GELEMENTIVEZASelect3 = this.cmRAD1GELEMENTIVEZASelect3.FetchData();
            if (this.RAD1GELEMENTIVEZASelect3.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.RAD1GELEMENTIVEZASelect3.GetInt32(0);
            }
            this.RAD1GELEMENTIVEZASelect3.Close();
            return this.recordCount;
        }

        private int GetInternalRecordCountByIDELEMENT(int iDELEMENT)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmRAD1GELEMENTIVEZASelect2 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [RAD1GELEMENTIVEZA] WITH (NOLOCK) WHERE [IDELEMENT] = @IDELEMENT ", false);
            if (this.cmRAD1GELEMENTIVEZASelect2.IDbCommand.Parameters.Count == 0)
            {
                this.cmRAD1GELEMENTIVEZASelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDELEMENT", DbType.Int32));
            }
            this.cmRAD1GELEMENTIVEZASelect2.SetParameter(0, iDELEMENT);
            this.RAD1GELEMENTIVEZASelect2 = this.cmRAD1GELEMENTIVEZASelect2.FetchData();
            if (this.RAD1GELEMENTIVEZASelect2.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.RAD1GELEMENTIVEZASelect2.GetInt32(0);
            }
            this.RAD1GELEMENTIVEZASelect2.Close();
            return this.recordCount;
        }

        private int GetInternalRecordCountByRAD1GELEMENTIID(int rAD1GELEMENTIID)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmRAD1GELEMENTIVEZASelect1 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [RAD1GELEMENTIVEZA] WITH (NOLOCK) WHERE [RAD1GELEMENTIID] = @RAD1GELEMENTIID ", false);
            if (this.cmRAD1GELEMENTIVEZASelect1.IDbCommand.Parameters.Count == 0)
            {
                this.cmRAD1GELEMENTIVEZASelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RAD1GELEMENTIID", DbType.Int32));
            }
            this.cmRAD1GELEMENTIVEZASelect1.SetParameter(0, rAD1GELEMENTIID);
            this.RAD1GELEMENTIVEZASelect1 = this.cmRAD1GELEMENTIVEZASelect1.FetchData();
            if (this.RAD1GELEMENTIVEZASelect1.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.RAD1GELEMENTIVEZASelect1.GetInt32(0);
            }
            this.RAD1GELEMENTIVEZASelect1.Close();
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

        public virtual int GetRecordCountByRAD1GELEMENTIID(int rAD1GELEMENTIID)
        {
            int num2 = 0;
            try
            {
                this.InitializeMembers();
                num2 = this.GetInternalRecordCountByRAD1GELEMENTIID(rAD1GELEMENTIID);
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
            this.RcdFound286 = 0;
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
            this.RAD1GELEMENTIVEZASet = new RAD1GELEMENTIVEZADataSet();
            this.Initialize();
            this.dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        }

        private void InsertRad1gelementiveza()
        {
            this.CheckOptimisticConcurrencyRad1gelementiveza();
            this.AfterConfirmRad1gelementiveza();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [RAD1GELEMENTIVEZA] ([RAD1GELEMENTIID], [IDELEMENT]) VALUES (@RAD1GELEMENTIID, @IDELEMENT)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RAD1GELEMENTIID", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDELEMENT", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRAD1GELEMENTIVEZA["RAD1GELEMENTIID"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowRAD1GELEMENTIVEZA["IDELEMENT"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new RAD1GELEMENTIVEZADuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            if (command.ForeignKeyError)
            {
                this.CheckIntegrityErrorsRad1gelementiveza();
            }
            this.OnRAD1GELEMENTIVEZAUpdated(new RAD1GELEMENTIVEZAEventArgs(this.rowRAD1GELEMENTIVEZA, StatementType.Insert));
        }

        private void LoadByIDELEMENT(int startRow, int maxRows)
        {
            bool enforceConstraints = this.RAD1GELEMENTIVEZASet.EnforceConstraints;
            this.RAD1GELEMENTIVEZASet.RAD1GELEMENTIVEZA.BeginLoadData();
            this.ScanByIDELEMENT(startRow, maxRows);
            this.RAD1GELEMENTIVEZASet.RAD1GELEMENTIVEZA.EndLoadData();
            this.RAD1GELEMENTIVEZASet.EnforceConstraints = enforceConstraints;
            if (this.RAD1GELEMENTIVEZASet.RAD1GELEMENTIVEZA.Count > 0)
            {
                this.rowRAD1GELEMENTIVEZA = this.RAD1GELEMENTIVEZASet.RAD1GELEMENTIVEZA[this.RAD1GELEMENTIVEZASet.RAD1GELEMENTIVEZA.Count - 1];
            }
        }

        private void LoadByRAD1GELEMENTIID(int startRow, int maxRows)
        {
            bool enforceConstraints = this.RAD1GELEMENTIVEZASet.EnforceConstraints;
            this.RAD1GELEMENTIVEZASet.RAD1GELEMENTIVEZA.BeginLoadData();
            this.ScanByRAD1GELEMENTIID(startRow, maxRows);
            this.RAD1GELEMENTIVEZASet.RAD1GELEMENTIVEZA.EndLoadData();
            this.RAD1GELEMENTIVEZASet.EnforceConstraints = enforceConstraints;
            if (this.RAD1GELEMENTIVEZASet.RAD1GELEMENTIVEZA.Count > 0)
            {
                this.rowRAD1GELEMENTIVEZA = this.RAD1GELEMENTIVEZASet.RAD1GELEMENTIVEZA[this.RAD1GELEMENTIVEZASet.RAD1GELEMENTIVEZA.Count - 1];
            }
        }

        private void LoadByRAD1GELEMENTIIDIDELEMENT(int startRow, int maxRows)
        {
            bool enforceConstraints = this.RAD1GELEMENTIVEZASet.EnforceConstraints;
            this.RAD1GELEMENTIVEZASet.RAD1GELEMENTIVEZA.BeginLoadData();
            this.ScanByRAD1GELEMENTIIDIDELEMENT(startRow, maxRows);
            this.RAD1GELEMENTIVEZASet.RAD1GELEMENTIVEZA.EndLoadData();
            this.RAD1GELEMENTIVEZASet.EnforceConstraints = enforceConstraints;
            if (this.RAD1GELEMENTIVEZASet.RAD1GELEMENTIVEZA.Count > 0)
            {
                this.rowRAD1GELEMENTIVEZA = this.RAD1GELEMENTIVEZASet.RAD1GELEMENTIVEZA[this.RAD1GELEMENTIVEZASet.RAD1GELEMENTIVEZA.Count - 1];
            }
        }

        private void LoadChildRad1gelementiveza(int startRow, int maxRows)
        {
            this.CreateNewRowRad1gelementiveza();
            bool enforceConstraints = this.RAD1GELEMENTIVEZASet.EnforceConstraints;
            this.RAD1GELEMENTIVEZASet.RAD1GELEMENTIVEZA.BeginLoadData();
            this.ScanStartRad1gelementiveza(startRow, maxRows);
            this.RAD1GELEMENTIVEZASet.RAD1GELEMENTIVEZA.EndLoadData();
            this.RAD1GELEMENTIVEZASet.EnforceConstraints = enforceConstraints;
        }

        private void LoadDataRad1gelementiveza(int maxRows)
        {
            int num = 0;
            if (this.RcdFound286 != 0)
            {
                this.ScanLoadRad1gelementiveza();
                while ((this.RcdFound286 != 0) && (num != maxRows))
                {
                    num++;
                    this.LoadRowRad1gelementiveza();
                    this.CreateNewRowRad1gelementiveza();
                    this.ScanNextRad1gelementiveza();
                }
            }
            if (num > 0)
            {
                this.RcdFound286 = 1;
            }
            this.ScanEndRad1gelementiveza();
            if (this.RAD1GELEMENTIVEZASet.RAD1GELEMENTIVEZA.Count > 0)
            {
                this.rowRAD1GELEMENTIVEZA = this.RAD1GELEMENTIVEZASet.RAD1GELEMENTIVEZA[this.RAD1GELEMENTIVEZASet.RAD1GELEMENTIVEZA.Count - 1];
            }
        }

        private void LoadRowRad1gelementiveza()
        {
            this.AddRowRad1gelementiveza();
        }

        private void OnRAD1GELEMENTIVEZAUpdated(RAD1GELEMENTIVEZAEventArgs e)
        {
            if (this.RAD1GELEMENTIVEZAUpdated != null)
            {
                RAD1GELEMENTIVEZAUpdateEventHandler handler = this.RAD1GELEMENTIVEZAUpdated;
                if (handler != null)
                {
                    handler(this, e);
                }
            }
        }

        private void OnRAD1GELEMENTIVEZAUpdating(RAD1GELEMENTIVEZAEventArgs e)
        {
            if (this.RAD1GELEMENTIVEZAUpdating != null)
            {
                RAD1GELEMENTIVEZAUpdateEventHandler handler = this.RAD1GELEMENTIVEZAUpdating;
                if (handler != null)
                {
                    handler(this, e);
                }
            }
        }

        private void ReadRowRad1gelementiveza()
        {
            this.Gx_mode = Mode.FromRowState(this.rowRAD1GELEMENTIVEZA.RowState);
            if (this.rowRAD1GELEMENTIVEZA.RowState == DataRowState.Added)
            {
            }
            this._Gxremove = this.rowRAD1GELEMENTIVEZA.RowState == DataRowState.Deleted;
            if (this._Gxremove)
            {
                this.rowRAD1GELEMENTIVEZA = (RAD1GELEMENTIVEZADataSet.RAD1GELEMENTIVEZARow) DataSetUtil.CloneOriginalDataRow(this.rowRAD1GELEMENTIVEZA);
            }
        }

        private void ScanByIDELEMENT(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[IDELEMENT] = @IDELEMENT";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString286 + "  FROM [RAD1GELEMENTIVEZA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[RAD1GELEMENTIID], TM1.[IDELEMENT]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString286, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[RAD1GELEMENTIID], TM1.[IDELEMENT] ) AS DK_PAGENUM   FROM [RAD1GELEMENTIVEZA] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString286 + " FROM [RAD1GELEMENTIVEZA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[RAD1GELEMENTIID], TM1.[IDELEMENT] ";
            }
            this.cmRAD1GELEMENTIVEZASelect6 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmRAD1GELEMENTIVEZASelect6.IDbCommand.Parameters.Count == 0)
            {
                this.cmRAD1GELEMENTIVEZASelect6.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDELEMENT", DbType.Int32));
            }
            this.cmRAD1GELEMENTIVEZASelect6.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRAD1GELEMENTIVEZA["IDELEMENT"]));
            this.RAD1GELEMENTIVEZASelect6 = this.cmRAD1GELEMENTIVEZASelect6.FetchData();
            this.RcdFound286 = 0;
            this.ScanLoadRad1gelementiveza();
            this.LoadDataRad1gelementiveza(maxRows);
        }

        private void ScanByRAD1GELEMENTIID(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[RAD1GELEMENTIID] = @RAD1GELEMENTIID";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString286 + "  FROM [RAD1GELEMENTIVEZA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[RAD1GELEMENTIID], TM1.[IDELEMENT]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString286, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[RAD1GELEMENTIID], TM1.[IDELEMENT] ) AS DK_PAGENUM   FROM [RAD1GELEMENTIVEZA] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString286 + " FROM [RAD1GELEMENTIVEZA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[RAD1GELEMENTIID], TM1.[IDELEMENT] ";
            }
            this.cmRAD1GELEMENTIVEZASelect6 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmRAD1GELEMENTIVEZASelect6.IDbCommand.Parameters.Count == 0)
            {
                this.cmRAD1GELEMENTIVEZASelect6.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RAD1GELEMENTIID", DbType.Int32));
            }
            this.cmRAD1GELEMENTIVEZASelect6.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRAD1GELEMENTIVEZA["RAD1GELEMENTIID"]));
            this.RAD1GELEMENTIVEZASelect6 = this.cmRAD1GELEMENTIVEZASelect6.FetchData();
            this.RcdFound286 = 0;
            this.ScanLoadRad1gelementiveza();
            this.LoadDataRad1gelementiveza(maxRows);
        }

        private void ScanByRAD1GELEMENTIIDIDELEMENT(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[RAD1GELEMENTIID] = @RAD1GELEMENTIID and TM1.[IDELEMENT] = @IDELEMENT";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString286 + "  FROM [RAD1GELEMENTIVEZA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[RAD1GELEMENTIID], TM1.[IDELEMENT]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString286, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[RAD1GELEMENTIID], TM1.[IDELEMENT] ) AS DK_PAGENUM   FROM [RAD1GELEMENTIVEZA] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString286 + " FROM [RAD1GELEMENTIVEZA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[RAD1GELEMENTIID], TM1.[IDELEMENT] ";
            }
            this.cmRAD1GELEMENTIVEZASelect6 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmRAD1GELEMENTIVEZASelect6.IDbCommand.Parameters.Count == 0)
            {
                this.cmRAD1GELEMENTIVEZASelect6.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RAD1GELEMENTIID", DbType.Int32));
                this.cmRAD1GELEMENTIVEZASelect6.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDELEMENT", DbType.Int32));
            }
            this.cmRAD1GELEMENTIVEZASelect6.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRAD1GELEMENTIVEZA["RAD1GELEMENTIID"]));
            this.cmRAD1GELEMENTIVEZASelect6.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowRAD1GELEMENTIVEZA["IDELEMENT"]));
            this.RAD1GELEMENTIVEZASelect6 = this.cmRAD1GELEMENTIVEZASelect6.FetchData();
            this.RcdFound286 = 0;
            this.ScanLoadRad1gelementiveza();
            this.LoadDataRad1gelementiveza(maxRows);
        }

        private void ScanEndRad1gelementiveza()
        {
            this.RAD1GELEMENTIVEZASelect6.Close();
        }

        private void ScanLoadRad1gelementiveza()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmRAD1GELEMENTIVEZASelect6.HasMoreRows)
            {
                this.RcdFound286 = 1;
                this.rowRAD1GELEMENTIVEZA["RAD1GELEMENTIID"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.RAD1GELEMENTIVEZASelect6, 0));
                this.rowRAD1GELEMENTIVEZA["IDELEMENT"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.RAD1GELEMENTIVEZASelect6, 1));
            }
        }

        private void ScanNextRad1gelementiveza()
        {
            this.cmRAD1GELEMENTIVEZASelect6.HasMoreRows = this.RAD1GELEMENTIVEZASelect6.Read();
            this.RcdFound286 = 0;
            this.ScanLoadRad1gelementiveza();
        }

        private void ScanStartRad1gelementiveza(int startRow, int maxRows)
        {
            this.m_WhereString = "";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString286 + "  FROM [RAD1GELEMENTIVEZA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[RAD1GELEMENTIID], TM1.[IDELEMENT]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString286, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[RAD1GELEMENTIID], TM1.[IDELEMENT] ) AS DK_PAGENUM   FROM [RAD1GELEMENTIVEZA] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString286 + " FROM [RAD1GELEMENTIVEZA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[RAD1GELEMENTIID], TM1.[IDELEMENT] ";
            }
            this.cmRAD1GELEMENTIVEZASelect6 = this.connDefault.GetCommand(this.scmdbuf, false);
            this.RAD1GELEMENTIVEZASelect6 = this.cmRAD1GELEMENTIVEZASelect6.FetchData();
            this.RcdFound286 = 0;
            this.ScanLoadRad1gelementiveza();
            this.LoadDataRad1gelementiveza(maxRows);
        }

        public virtual int Update(DataSet dataSet)
        {
            this.InitializeMembers();
            this.RAD1GELEMENTIVEZASet = (RAD1GELEMENTIVEZADataSet) dataSet;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            if (this.RAD1GELEMENTIVEZASet == null)
            {
                throw new ArgumentException(this.resourceManager.GetString("nulldset"));
            }
            try
            {
                IEnumerator enumerator = null;
                this.connDefault.BeginTransaction();
                try
                {
                    enumerator = this.RAD1GELEMENTIVEZASet.RAD1GELEMENTIVEZA.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        RAD1GELEMENTIVEZADataSet.RAD1GELEMENTIVEZARow current = (RAD1GELEMENTIVEZADataSet.RAD1GELEMENTIVEZARow) enumerator.Current;
                        this.rowRAD1GELEMENTIVEZA = current;
                        if (Helpers.IsRowChanged(this.rowRAD1GELEMENTIVEZA))
                        {
                            this.ReadRowRad1gelementiveza();
                            if (this.rowRAD1GELEMENTIVEZA.RowState == DataRowState.Added)
                            {
                                this.InsertRad1gelementiveza();
                            }
                            else
                            {
                                if (this._Gxremove)
                                {
                                    this.Delete();
                                    continue;
                                }
                                this.UpdateRad1gelementiveza();
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

        private void UpdateRad1gelementiveza()
        {
            this.CheckOptimisticConcurrencyRad1gelementiveza();
            this.AfterConfirmRad1gelementiveza();
            this.OnRAD1GELEMENTIVEZAUpdated(new RAD1GELEMENTIVEZAEventArgs(this.rowRAD1GELEMENTIVEZA, StatementType.Update));
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
        public class RAD1GELEMENTIForeignKeyNotFoundException : Deklarit.ForeignKeyNotFoundException
        {
            public RAD1GELEMENTIForeignKeyNotFoundException()
            {
            }

            public RAD1GELEMENTIForeignKeyNotFoundException(string message) : base(message)
            {
            }

            protected RAD1GELEMENTIForeignKeyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public RAD1GELEMENTIForeignKeyNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class RAD1GELEMENTIVEZADataChangedException : DataChangedException
        {
            public RAD1GELEMENTIVEZADataChangedException()
            {
            }

            public RAD1GELEMENTIVEZADataChangedException(string message) : base(message)
            {
            }

            protected RAD1GELEMENTIVEZADataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public RAD1GELEMENTIVEZADataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class RAD1GELEMENTIVEZADataLockedException : DataLockedException
        {
            public RAD1GELEMENTIVEZADataLockedException()
            {
            }

            public RAD1GELEMENTIVEZADataLockedException(string message) : base(message)
            {
            }

            protected RAD1GELEMENTIVEZADataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public RAD1GELEMENTIVEZADataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class RAD1GELEMENTIVEZADuplicateKeyException : DuplicateKeyException
        {
            public RAD1GELEMENTIVEZADuplicateKeyException()
            {
            }

            public RAD1GELEMENTIVEZADuplicateKeyException(string message) : base(message)
            {
            }

            protected RAD1GELEMENTIVEZADuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public RAD1GELEMENTIVEZADuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class RAD1GELEMENTIVEZAEventArgs : EventArgs
        {
            private RAD1GELEMENTIVEZADataSet.RAD1GELEMENTIVEZARow m_dataRow;
            private System.Data.StatementType m_statementType;

            public RAD1GELEMENTIVEZAEventArgs(RAD1GELEMENTIVEZADataSet.RAD1GELEMENTIVEZARow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public RAD1GELEMENTIVEZADataSet.RAD1GELEMENTIVEZARow Row
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
        public class RAD1GELEMENTIVEZANotFoundException : DataNotFoundException
        {
            public RAD1GELEMENTIVEZANotFoundException()
            {
            }

            public RAD1GELEMENTIVEZANotFoundException(string message) : base(message)
            {
            }

            protected RAD1GELEMENTIVEZANotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public RAD1GELEMENTIVEZANotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public delegate void RAD1GELEMENTIVEZAUpdateEventHandler(object sender, RAD1GELEMENTIVEZADataAdapter.RAD1GELEMENTIVEZAEventArgs e);
    }
}


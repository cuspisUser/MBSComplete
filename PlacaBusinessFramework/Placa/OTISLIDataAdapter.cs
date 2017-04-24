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

    public class OTISLIDataAdapter : IDataAdapter, IOTISLIDataAdapter
    {
        private bool _Gxremove;
        private ReadWriteCommand cmOTISLISelect1;
        private ReadWriteCommand cmOTISLISelect2;
        private ReadWriteCommand cmOTISLISelect5;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private DbParameter[] fillDataParameters;
        private StatementType Gx_mode;
        private readonly string m_SelectString294 = "TM1.[DATUMODLASKA], TM1.[IDRADNIK]";
        private string m_WhereString;
        private IDataReader OTISLISelect1;
        private IDataReader OTISLISelect2;
        private IDataReader OTISLISelect5;
        private OTISLIDataSet OTISLISet;
        private short RcdFound294;
        private int recordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private OTISLIDataSet.OTISLIRow rowOTISLI;
        private string scmdbuf;
        private StatementType sMode294;

        public event OTISLIUpdateEventHandler OTISLIUpdated;

        public event OTISLIUpdateEventHandler OTISLIUpdating;

        private void AddRowOtisli()
        {
            this.OTISLISet.OTISLI.AddOTISLIRow(this.rowOTISLI);
        }

        private void AfterConfirmOtisli()
        {
            this.OnOTISLIUpdating(new OTISLIEventArgs(this.rowOTISLI, this.Gx_mode));
        }

        private void CheckIntegrityErrorsOtisli()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDRADNIK] FROM [RADNIK] WITH (NOLOCK) WHERE [IDRADNIK] = @IDRADNIK ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOTISLI["IDRADNIK"]));
            IDataReader reader = command.FetchData();
            if (!command.HasMoreRows)
            {
                reader.Close();
                throw new RADNIKForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("RADNIK") }));
            }
            reader.Close();
            throw new ForeignKeyNotFoundException(this.resourceManager.GetString("refinterror"));
        }

        private void CheckOptimisticConcurrencyOtisli()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [DATUMODLASKA], [IDRADNIK] FROM [OTISLI] WITH (UPDLOCK) WHERE [IDRADNIK] = @IDRADNIK AND [DATUMODLASKA] = @DATUMODLASKA ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DATUMODLASKA", DbType.Date));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOTISLI["IDRADNIK"]));
                command.SetParameterDateObject(1, RuntimeHelpers.GetObjectValue(this.rowOTISLI["DATUMODLASKA"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new OTISLIDataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("OTISLI") }));
                }
                if (!command.HasMoreRows)
                {
                    reader.Close();
                    throw new OTISLIDataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("OTISLI") }));
                }
                reader.Close();
            }
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        private void CreateNewRowOtisli()
        {
            this.rowOTISLI = this.OTISLISet.OTISLI.NewOTISLIRow();
        }

        private void Delete()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyOtisli();
            this.AfterConfirmOtisli();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [OTISLI]  WHERE [IDRADNIK] = @IDRADNIK AND [DATUMODLASKA] = @DATUMODLASKA", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DATUMODLASKA", DbType.Date));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOTISLI["IDRADNIK"]));
            command.SetParameterDateObject(1, RuntimeHelpers.GetObjectValue(this.rowOTISLI["DATUMODLASKA"]));
            command.ExecuteStmt();
            this.OnOTISLIUpdated(new OTISLIEventArgs(this.rowOTISLI, StatementType.Delete));
            this.rowOTISLI.Delete();
            this.sMode294 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode294;
        }

        public virtual int Fill(OTISLIDataSet dataSet)
        {
            if (this.fillDataParameters != null)
            {
                this.Fill(dataSet, int.Parse(this.fillDataParameters[0].Value.ToString()), DateTime.Parse(this.fillDataParameters[1].Value.ToString()));
            }
            else
            {
                try
                {
                    this.InitializeMembers();
                    this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
                    this.OTISLISet = dataSet;
                    this.LoadChildOtisli(0, -1);
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
            this.OTISLISet = (OTISLIDataSet) dataSet;
            if (this.OTISLISet != null)
            {
                return this.Fill(this.OTISLISet);
            }
            this.OTISLISet = new OTISLIDataSet();
            this.Fill(this.OTISLISet);
            dataSet.Merge(this.OTISLISet);
            return 0;
        }

        public virtual int Fill(OTISLIDataSet dataSet, DataRow dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDRADNIK"]), Conversions.ToDate(dataRecord["DATUMODLASKA"]));
        }

        public virtual int Fill(OTISLIDataSet dataSet, IDataRecord dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDRADNIK"]), Conversions.ToDate(dataRecord["DATUMODLASKA"]));
        }

        public virtual int Fill(OTISLIDataSet dataSet, int iDRADNIK, DateTime dATUMODLASKA)
        {
            if (!this.FillByIDRADNIKDATUMODLASKA(dataSet, iDRADNIK, dATUMODLASKA))
            {
                throw new OTISLINotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("OTISLI") }));
            }
            return 0;
        }

        public virtual int FillByIDRADNIK(OTISLIDataSet dataSet, int iDRADNIK)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.OTISLISet = dataSet;
            this.rowOTISLI = this.OTISLISet.OTISLI.NewOTISLIRow();
            this.rowOTISLI.IDRADNIK = iDRADNIK;
            try
            {
                this.LoadByIDRADNIK(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual bool FillByIDRADNIKDATUMODLASKA(OTISLIDataSet dataSet, int iDRADNIK, DateTime dATUMODLASKA)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.OTISLISet = dataSet;
            this.rowOTISLI = this.OTISLISet.OTISLI.NewOTISLIRow();
            this.rowOTISLI.IDRADNIK = iDRADNIK;
            this.rowOTISLI.DATUMODLASKA = DateTimeUtil.ResetTime(dATUMODLASKA);
            try
            {
                this.LoadByIDRADNIKDATUMODLASKA(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            if (this.RcdFound294 == 0)
            {
                return false;
            }
            return true;
        }

        public virtual int FillPage(OTISLIDataSet dataSet, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.OTISLISet = dataSet;
            try
            {
                this.LoadChildOtisli(startRow, maxRows);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillPageByIDRADNIK(OTISLIDataSet dataSet, int iDRADNIK, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.OTISLISet = dataSet;
            this.rowOTISLI = this.OTISLISet.OTISLI.NewOTISLIRow();
            this.rowOTISLI.IDRADNIK = iDRADNIK;
            try
            {
                this.LoadByIDRADNIK(startRow, maxRows);
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
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [DATUMODLASKA], [IDRADNIK] FROM [OTISLI] WITH (NOLOCK) WHERE [IDRADNIK] = @IDRADNIK AND [DATUMODLASKA] = @DATUMODLASKA ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DATUMODLASKA", DbType.Date));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOTISLI["IDRADNIK"]));
            command.SetParameterDateObject(1, RuntimeHelpers.GetObjectValue(this.rowOTISLI["DATUMODLASKA"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.RcdFound294 = 1;
                this.rowOTISLI["DATUMODLASKA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDateTime(reader, 0));
                this.rowOTISLI["IDRADNIK"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 1));
                this.sMode294 = this.Gx_mode;
                this.Gx_mode = StatementType.Select;
                this.Gx_mode = this.sMode294;
            }
            else
            {
                this.RcdFound294 = 0;
            }
            reader.Close();
        }

        public virtual IDataParameter[] GetFillParameters()
        {
            if (this.fillDataParameters == null)
            {
                DbProviderFactory factory = DbProviderFactories.GetFactory("System.Data.SqlClient");
                DbParameter parameter = factory.CreateParameter();
                parameter.ParameterName = "IDRADNIK";
                parameter.DbType = DbType.Int32;
                DbParameter parameter2 = factory.CreateParameter();
                parameter2.ParameterName = "DATUMODLASKA";
                parameter2.DbType = DbType.Date;
                this.fillDataParameters = new DbParameter[] { parameter, parameter2 };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount()
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmOTISLISelect2 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [OTISLI] WITH (NOLOCK) ", false);
            this.OTISLISelect2 = this.cmOTISLISelect2.FetchData();
            if (this.OTISLISelect2.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.OTISLISelect2.GetInt32(0);
            }
            this.OTISLISelect2.Close();
            return this.recordCount;
        }

        private int GetInternalRecordCountByIDRADNIK(int iDRADNIK)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmOTISLISelect1 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [OTISLI] WITH (NOLOCK) WHERE [IDRADNIK] = @IDRADNIK ", false);
            if (this.cmOTISLISelect1.IDbCommand.Parameters.Count == 0)
            {
                this.cmOTISLISelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
            }
            this.cmOTISLISelect1.SetParameter(0, iDRADNIK);
            this.OTISLISelect1 = this.cmOTISLISelect1.FetchData();
            if (this.OTISLISelect1.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.OTISLISelect1.GetInt32(0);
            }
            this.OTISLISelect1.Close();
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

        public virtual int GetRecordCountByIDRADNIK(int iDRADNIK)
        {
            int internalRecordCountByIDRADNIK;
            try
            {
                this.InitializeMembers();
                internalRecordCountByIDRADNIK = this.GetInternalRecordCountByIDRADNIK(iDRADNIK);
            }
            finally
            {
                this.Cleanup();
            }
            return internalRecordCountByIDRADNIK;
        }

        private void Initialize()
        {
            this.resourceManager = Deklarit.Utils.ResourceManager.Instance;
            this.resourceManagerTables = new System.Resources.ResourceManager("Tables", Assembly.GetExecutingAssembly());
            this.RcdFound294 = 0;
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
            this.OTISLISet = new OTISLIDataSet();
            this.Initialize();
            this.dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        }

        private void InsertOtisli()
        {
            this.CheckOptimisticConcurrencyOtisli();
            this.AfterConfirmOtisli();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [OTISLI] ([DATUMODLASKA], [IDRADNIK]) VALUES (@DATUMODLASKA, @IDRADNIK)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DATUMODLASKA", DbType.Date));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameterDateObject(0, RuntimeHelpers.GetObjectValue(this.rowOTISLI["DATUMODLASKA"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowOTISLI["IDRADNIK"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new OTISLIDuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            if (command.ForeignKeyError)
            {
                this.CheckIntegrityErrorsOtisli();
            }
            this.OnOTISLIUpdated(new OTISLIEventArgs(this.rowOTISLI, StatementType.Insert));
        }

        private void LoadByIDRADNIK(int startRow, int maxRows)
        {
            bool enforceConstraints = this.OTISLISet.EnforceConstraints;
            this.OTISLISet.OTISLI.BeginLoadData();
            this.ScanByIDRADNIK(startRow, maxRows);
            this.OTISLISet.OTISLI.EndLoadData();
            this.OTISLISet.EnforceConstraints = enforceConstraints;
            if (this.OTISLISet.OTISLI.Count > 0)
            {
                this.rowOTISLI = this.OTISLISet.OTISLI[this.OTISLISet.OTISLI.Count - 1];
            }
        }

        private void LoadByIDRADNIKDATUMODLASKA(int startRow, int maxRows)
        {
            bool enforceConstraints = this.OTISLISet.EnforceConstraints;
            this.OTISLISet.OTISLI.BeginLoadData();
            this.ScanByIDRADNIKDATUMODLASKA(startRow, maxRows);
            this.OTISLISet.OTISLI.EndLoadData();
            this.OTISLISet.EnforceConstraints = enforceConstraints;
            if (this.OTISLISet.OTISLI.Count > 0)
            {
                this.rowOTISLI = this.OTISLISet.OTISLI[this.OTISLISet.OTISLI.Count - 1];
            }
        }

        private void LoadChildOtisli(int startRow, int maxRows)
        {
            this.CreateNewRowOtisli();
            bool enforceConstraints = this.OTISLISet.EnforceConstraints;
            this.OTISLISet.OTISLI.BeginLoadData();
            this.ScanStartOtisli(startRow, maxRows);
            this.OTISLISet.OTISLI.EndLoadData();
            this.OTISLISet.EnforceConstraints = enforceConstraints;
        }

        private void LoadDataOtisli(int maxRows)
        {
            int num = 0;
            if (this.RcdFound294 != 0)
            {
                this.ScanLoadOtisli();
                while ((this.RcdFound294 != 0) && (num != maxRows))
                {
                    num++;
                    this.LoadRowOtisli();
                    this.CreateNewRowOtisli();
                    this.ScanNextOtisli();
                }
            }
            if (num > 0)
            {
                this.RcdFound294 = 1;
            }
            this.ScanEndOtisli();
            if (this.OTISLISet.OTISLI.Count > 0)
            {
                this.rowOTISLI = this.OTISLISet.OTISLI[this.OTISLISet.OTISLI.Count - 1];
            }
        }

        private void LoadRowOtisli()
        {
            this.AddRowOtisli();
        }

        private void OnOTISLIUpdated(OTISLIEventArgs e)
        {
            if (this.OTISLIUpdated != null)
            {
                OTISLIUpdateEventHandler oTISLIUpdatedEvent = this.OTISLIUpdated;
                if (oTISLIUpdatedEvent != null)
                {
                    oTISLIUpdatedEvent(this, e);
                }
            }
        }

        private void OnOTISLIUpdating(OTISLIEventArgs e)
        {
            if (this.OTISLIUpdating != null)
            {
                OTISLIUpdateEventHandler oTISLIUpdatingEvent = this.OTISLIUpdating;
                if (oTISLIUpdatingEvent != null)
                {
                    oTISLIUpdatingEvent(this, e);
                }
            }
        }

        private void ReadRowOtisli()
        {
            this.Gx_mode = Mode.FromRowState(this.rowOTISLI.RowState);
            if (this.rowOTISLI.RowState != DataRowState.Deleted)
            {
                this.rowOTISLI["DATUMODLASKA"] = RuntimeHelpers.GetObjectValue(DateTimeUtil.ResetTimeObject(RuntimeHelpers.GetObjectValue(this.rowOTISLI["DATUMODLASKA"])));
            }
            if (this.rowOTISLI.RowState == DataRowState.Added)
            {
            }
            this._Gxremove = this.rowOTISLI.RowState == DataRowState.Deleted;
            if (this._Gxremove)
            {
                this.rowOTISLI = (OTISLIDataSet.OTISLIRow) DataSetUtil.CloneOriginalDataRow(this.rowOTISLI);
            }
        }

        private void ScanByIDRADNIK(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[IDRADNIK] = @IDRADNIK";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString294 + "  FROM [OTISLI] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDRADNIK], TM1.[DATUMODLASKA]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString294, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDRADNIK], TM1.[DATUMODLASKA] ) AS DK_PAGENUM   FROM [OTISLI] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString294 + " FROM [OTISLI] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDRADNIK], TM1.[DATUMODLASKA] ";
            }
            this.cmOTISLISelect5 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmOTISLISelect5.IDbCommand.Parameters.Count == 0)
            {
                this.cmOTISLISelect5.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
            }
            this.cmOTISLISelect5.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOTISLI["IDRADNIK"]));
            this.OTISLISelect5 = this.cmOTISLISelect5.FetchData();
            this.RcdFound294 = 0;
            this.ScanLoadOtisli();
            this.LoadDataOtisli(maxRows);
        }

        private void ScanByIDRADNIKDATUMODLASKA(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[IDRADNIK] = @IDRADNIK and TM1.[DATUMODLASKA] = @DATUMODLASKA";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString294 + "  FROM [OTISLI] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDRADNIK], TM1.[DATUMODLASKA]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString294, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDRADNIK], TM1.[DATUMODLASKA] ) AS DK_PAGENUM   FROM [OTISLI] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString294 + " FROM [OTISLI] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDRADNIK], TM1.[DATUMODLASKA] ";
            }
            this.cmOTISLISelect5 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmOTISLISelect5.IDbCommand.Parameters.Count == 0)
            {
                this.cmOTISLISelect5.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
                this.cmOTISLISelect5.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DATUMODLASKA", DbType.Date));
            }
            this.cmOTISLISelect5.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOTISLI["IDRADNIK"]));
            this.cmOTISLISelect5.SetParameterDateObject(1, RuntimeHelpers.GetObjectValue(this.rowOTISLI["DATUMODLASKA"]));
            this.OTISLISelect5 = this.cmOTISLISelect5.FetchData();
            this.RcdFound294 = 0;
            this.ScanLoadOtisli();
            this.LoadDataOtisli(maxRows);
        }

        private void ScanEndOtisli()
        {
            this.OTISLISelect5.Close();
        }

        private void ScanLoadOtisli()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmOTISLISelect5.HasMoreRows)
            {
                this.RcdFound294 = 1;
                this.rowOTISLI["DATUMODLASKA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDateTime(this.OTISLISelect5, 0));
                this.rowOTISLI["IDRADNIK"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.OTISLISelect5, 1));
            }
        }

        private void ScanNextOtisli()
        {
            this.cmOTISLISelect5.HasMoreRows = this.OTISLISelect5.Read();
            this.RcdFound294 = 0;
            this.ScanLoadOtisli();
        }

        private void ScanStartOtisli(int startRow, int maxRows)
        {
            this.m_WhereString = "";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString294 + "  FROM [OTISLI] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDRADNIK], TM1.[DATUMODLASKA]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString294, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDRADNIK], TM1.[DATUMODLASKA] ) AS DK_PAGENUM   FROM [OTISLI] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString294 + " FROM [OTISLI] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDRADNIK], TM1.[DATUMODLASKA] ";
            }
            this.cmOTISLISelect5 = this.connDefault.GetCommand(this.scmdbuf, false);
            this.OTISLISelect5 = this.cmOTISLISelect5.FetchData();
            this.RcdFound294 = 0;
            this.ScanLoadOtisli();
            this.LoadDataOtisli(maxRows);
        }

        public virtual int Update(DataSet dataSet)
        {
            this.InitializeMembers();
            this.OTISLISet = (OTISLIDataSet) dataSet;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            if (this.OTISLISet == null)
            {
                throw new ArgumentException(this.resourceManager.GetString("nulldset"));
            }
            try
            {
                IEnumerator enumerator = null;
                this.connDefault.BeginTransaction();
                try
                {
                    enumerator = this.OTISLISet.OTISLI.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        OTISLIDataSet.OTISLIRow current = (OTISLIDataSet.OTISLIRow) enumerator.Current;
                        this.rowOTISLI = current;
                        if (Helpers.IsRowChanged(this.rowOTISLI))
                        {
                            this.ReadRowOtisli();
                            if (this.rowOTISLI.RowState == DataRowState.Added)
                            {
                                this.InsertOtisli();
                            }
                            else
                            {
                                if (this._Gxremove)
                                {
                                    this.Delete();
                                    continue;
                                }
                                this.UpdateOtisli();
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

        private void UpdateOtisli()
        {
            this.CheckOptimisticConcurrencyOtisli();
            this.AfterConfirmOtisli();
            this.OnOTISLIUpdated(new OTISLIEventArgs(this.rowOTISLI, StatementType.Update));
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
        public class OTISLIDataChangedException : DataChangedException
        {
            public OTISLIDataChangedException()
            {
            }

            public OTISLIDataChangedException(string message) : base(message)
            {
            }

            protected OTISLIDataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public OTISLIDataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class OTISLIDataLockedException : DataLockedException
        {
            public OTISLIDataLockedException()
            {
            }

            public OTISLIDataLockedException(string message) : base(message)
            {
            }

            protected OTISLIDataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public OTISLIDataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class OTISLIDuplicateKeyException : DuplicateKeyException
        {
            public OTISLIDuplicateKeyException()
            {
            }

            public OTISLIDuplicateKeyException(string message) : base(message)
            {
            }

            protected OTISLIDuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public OTISLIDuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class OTISLIEventArgs : EventArgs
        {
            private OTISLIDataSet.OTISLIRow m_dataRow;
            private System.Data.StatementType m_statementType;

            public OTISLIEventArgs(OTISLIDataSet.OTISLIRow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public OTISLIDataSet.OTISLIRow Row
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
        public class OTISLINotFoundException : DataNotFoundException
        {
            public OTISLINotFoundException()
            {
            }

            public OTISLINotFoundException(string message) : base(message)
            {
            }

            protected OTISLINotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public OTISLINotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public delegate void OTISLIUpdateEventHandler(object sender, OTISLIDataAdapter.OTISLIEventArgs e);

        [Serializable]
        public class RADNIKForeignKeyNotFoundException : Deklarit.ForeignKeyNotFoundException
        {
            public RADNIKForeignKeyNotFoundException()
            {
            }

            public RADNIKForeignKeyNotFoundException(string message) : base(message)
            {
            }

            protected RADNIKForeignKeyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public RADNIKForeignKeyNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }
    }
}


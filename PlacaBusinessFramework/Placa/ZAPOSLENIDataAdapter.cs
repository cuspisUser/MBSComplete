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

    public class ZAPOSLENIDataAdapter : IDataAdapter, IZAPOSLENIDataAdapter
    {
        private bool _Gxremove;
        private ReadWriteCommand cmZAPOSLENISelect1;
        private ReadWriteCommand cmZAPOSLENISelect2;
        private ReadWriteCommand cmZAPOSLENISelect5;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private DbParameter[] fillDataParameters;
        private StatementType Gx_mode;
        private readonly string m_SelectString293 = "TM1.[DATUMZAPOSLENJA], TM1.[IDRADNIK]";
        private string m_WhereString;
        private short RcdFound293;
        private int recordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private ZAPOSLENIDataSet.ZAPOSLENIRow rowZAPOSLENI;
        private string scmdbuf;
        private StatementType sMode293;
        private IDataReader ZAPOSLENISelect1;
        private IDataReader ZAPOSLENISelect2;
        private IDataReader ZAPOSLENISelect5;
        private ZAPOSLENIDataSet ZAPOSLENISet;

        public event ZAPOSLENIUpdateEventHandler ZAPOSLENIUpdated;

        public event ZAPOSLENIUpdateEventHandler ZAPOSLENIUpdating;

        private void AddRowZaposleni()
        {
            this.ZAPOSLENISet.ZAPOSLENI.AddZAPOSLENIRow(this.rowZAPOSLENI);
        }

        private void AfterConfirmZaposleni()
        {
            this.OnZAPOSLENIUpdating(new ZAPOSLENIEventArgs(this.rowZAPOSLENI, this.Gx_mode));
        }

        private void CheckIntegrityErrorsZaposleni()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDRADNIK] FROM [RADNIK] WITH (NOLOCK) WHERE [IDRADNIK] = @IDRADNIK ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowZAPOSLENI["IDRADNIK"]));
            IDataReader reader = command.FetchData();
            if (!command.HasMoreRows)
            {
                reader.Close();
                throw new RADNIKForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("RADNIK") }));
            }
            reader.Close();
            throw new ForeignKeyNotFoundException(this.resourceManager.GetString("refinterror"));
        }

        private void CheckOptimisticConcurrencyZaposleni()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [DATUMZAPOSLENJA], [IDRADNIK] FROM [ZAPOSLENI] WITH (UPDLOCK) WHERE [IDRADNIK] = @IDRADNIK AND [DATUMZAPOSLENJA] = @DATUMZAPOSLENJA ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DATUMZAPOSLENJA", DbType.Date));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowZAPOSLENI["IDRADNIK"]));
                command.SetParameterDateObject(1, RuntimeHelpers.GetObjectValue(this.rowZAPOSLENI["DATUMZAPOSLENJA"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new ZAPOSLENIDataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("ZAPOSLENI") }));
                }
                if (!command.HasMoreRows)
                {
                    reader.Close();
                    throw new ZAPOSLENIDataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("ZAPOSLENI") }));
                }
                reader.Close();
            }
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        private void CreateNewRowZaposleni()
        {
            this.rowZAPOSLENI = this.ZAPOSLENISet.ZAPOSLENI.NewZAPOSLENIRow();
        }

        private void Delete()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyZaposleni();
            this.AfterConfirmZaposleni();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [ZAPOSLENI]  WHERE [IDRADNIK] = @IDRADNIK AND [DATUMZAPOSLENJA] = @DATUMZAPOSLENJA", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DATUMZAPOSLENJA", DbType.Date));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowZAPOSLENI["IDRADNIK"]));
            command.SetParameterDateObject(1, RuntimeHelpers.GetObjectValue(this.rowZAPOSLENI["DATUMZAPOSLENJA"]));
            command.ExecuteStmt();
            this.OnZAPOSLENIUpdated(new ZAPOSLENIEventArgs(this.rowZAPOSLENI, StatementType.Delete));
            this.rowZAPOSLENI.Delete();
            this.sMode293 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode293;
        }

        public virtual int Fill(ZAPOSLENIDataSet dataSet)
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
                    this.ZAPOSLENISet = dataSet;
                    this.LoadChildZaposleni(0, -1);
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
            this.ZAPOSLENISet = (ZAPOSLENIDataSet) dataSet;
            if (this.ZAPOSLENISet != null)
            {
                return this.Fill(this.ZAPOSLENISet);
            }
            this.ZAPOSLENISet = new ZAPOSLENIDataSet();
            this.Fill(this.ZAPOSLENISet);
            dataSet.Merge(this.ZAPOSLENISet);
            return 0;
        }

        public virtual int Fill(ZAPOSLENIDataSet dataSet, DataRow dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDRADNIK"]), Conversions.ToDate(dataRecord["DATUMZAPOSLENJA"]));
        }

        public virtual int Fill(ZAPOSLENIDataSet dataSet, IDataRecord dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDRADNIK"]), Conversions.ToDate(dataRecord["DATUMZAPOSLENJA"]));
        }

        public virtual int Fill(ZAPOSLENIDataSet dataSet, int iDRADNIK, DateTime dATUMZAPOSLENJA)
        {
            if (!this.FillByIDRADNIKDATUMZAPOSLENJA(dataSet, iDRADNIK, dATUMZAPOSLENJA))
            {
                throw new ZAPOSLENINotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("ZAPOSLENI") }));
            }
            return 0;
        }

        public virtual int FillByIDRADNIK(ZAPOSLENIDataSet dataSet, int iDRADNIK)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.ZAPOSLENISet = dataSet;
            this.rowZAPOSLENI = this.ZAPOSLENISet.ZAPOSLENI.NewZAPOSLENIRow();
            this.rowZAPOSLENI.IDRADNIK = iDRADNIK;
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

        public virtual bool FillByIDRADNIKDATUMZAPOSLENJA(ZAPOSLENIDataSet dataSet, int iDRADNIK, DateTime dATUMZAPOSLENJA)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.ZAPOSLENISet = dataSet;
            this.rowZAPOSLENI = this.ZAPOSLENISet.ZAPOSLENI.NewZAPOSLENIRow();
            this.rowZAPOSLENI.IDRADNIK = iDRADNIK;
            this.rowZAPOSLENI.DATUMZAPOSLENJA = DateTimeUtil.ResetTime(dATUMZAPOSLENJA);
            try
            {
                this.LoadByIDRADNIKDATUMZAPOSLENJA(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            if (this.RcdFound293 == 0)
            {
                return false;
            }
            return true;
        }

        public virtual int FillPage(ZAPOSLENIDataSet dataSet, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.ZAPOSLENISet = dataSet;
            try
            {
                this.LoadChildZaposleni(startRow, maxRows);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillPageByIDRADNIK(ZAPOSLENIDataSet dataSet, int iDRADNIK, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.ZAPOSLENISet = dataSet;
            this.rowZAPOSLENI = this.ZAPOSLENISet.ZAPOSLENI.NewZAPOSLENIRow();
            this.rowZAPOSLENI.IDRADNIK = iDRADNIK;
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
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [DATUMZAPOSLENJA], [IDRADNIK] FROM [ZAPOSLENI] WITH (NOLOCK) WHERE [IDRADNIK] = @IDRADNIK AND [DATUMZAPOSLENJA] = @DATUMZAPOSLENJA ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DATUMZAPOSLENJA", DbType.Date));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowZAPOSLENI["IDRADNIK"]));
            command.SetParameterDateObject(1, RuntimeHelpers.GetObjectValue(this.rowZAPOSLENI["DATUMZAPOSLENJA"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.RcdFound293 = 1;
                this.rowZAPOSLENI["DATUMZAPOSLENJA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDateTime(reader, 0));
                this.rowZAPOSLENI["IDRADNIK"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 1));
                this.sMode293 = this.Gx_mode;
                this.Gx_mode = StatementType.Select;
                this.Gx_mode = this.sMode293;
            }
            else
            {
                this.RcdFound293 = 0;
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
                parameter2.ParameterName = "DATUMZAPOSLENJA";
                parameter2.DbType = DbType.Date;
                this.fillDataParameters = new DbParameter[] { parameter, parameter2 };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount()
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmZAPOSLENISelect2 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [ZAPOSLENI] WITH (NOLOCK) ", false);
            this.ZAPOSLENISelect2 = this.cmZAPOSLENISelect2.FetchData();
            if (this.ZAPOSLENISelect2.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.ZAPOSLENISelect2.GetInt32(0);
            }
            this.ZAPOSLENISelect2.Close();
            return this.recordCount;
        }

        private int GetInternalRecordCountByIDRADNIK(int iDRADNIK)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmZAPOSLENISelect1 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [ZAPOSLENI] WITH (NOLOCK) WHERE [IDRADNIK] = @IDRADNIK ", false);
            if (this.cmZAPOSLENISelect1.IDbCommand.Parameters.Count == 0)
            {
                this.cmZAPOSLENISelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
            }
            this.cmZAPOSLENISelect1.SetParameter(0, iDRADNIK);
            this.ZAPOSLENISelect1 = this.cmZAPOSLENISelect1.FetchData();
            if (this.ZAPOSLENISelect1.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.ZAPOSLENISelect1.GetInt32(0);
            }
            this.ZAPOSLENISelect1.Close();
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
            this.RcdFound293 = 0;
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
            this.ZAPOSLENISet = new ZAPOSLENIDataSet();
            this.Initialize();
            this.dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        }

        private void InsertZaposleni()
        {
            this.CheckOptimisticConcurrencyZaposleni();
            this.AfterConfirmZaposleni();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [ZAPOSLENI] ([DATUMZAPOSLENJA], [IDRADNIK]) VALUES (@DATUMZAPOSLENJA, @IDRADNIK)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DATUMZAPOSLENJA", DbType.Date));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameterDateObject(0, RuntimeHelpers.GetObjectValue(this.rowZAPOSLENI["DATUMZAPOSLENJA"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowZAPOSLENI["IDRADNIK"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new ZAPOSLENIDuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            if (command.ForeignKeyError)
            {
                this.CheckIntegrityErrorsZaposleni();
            }
            this.OnZAPOSLENIUpdated(new ZAPOSLENIEventArgs(this.rowZAPOSLENI, StatementType.Insert));
        }

        private void LoadByIDRADNIK(int startRow, int maxRows)
        {
            bool enforceConstraints = this.ZAPOSLENISet.EnforceConstraints;
            this.ZAPOSLENISet.ZAPOSLENI.BeginLoadData();
            this.ScanByIDRADNIK(startRow, maxRows);
            this.ZAPOSLENISet.ZAPOSLENI.EndLoadData();
            this.ZAPOSLENISet.EnforceConstraints = enforceConstraints;
            if (this.ZAPOSLENISet.ZAPOSLENI.Count > 0)
            {
                this.rowZAPOSLENI = this.ZAPOSLENISet.ZAPOSLENI[this.ZAPOSLENISet.ZAPOSLENI.Count - 1];
            }
        }

        private void LoadByIDRADNIKDATUMZAPOSLENJA(int startRow, int maxRows)
        {
            bool enforceConstraints = this.ZAPOSLENISet.EnforceConstraints;
            this.ZAPOSLENISet.ZAPOSLENI.BeginLoadData();
            this.ScanByIDRADNIKDATUMZAPOSLENJA(startRow, maxRows);
            this.ZAPOSLENISet.ZAPOSLENI.EndLoadData();
            this.ZAPOSLENISet.EnforceConstraints = enforceConstraints;
            if (this.ZAPOSLENISet.ZAPOSLENI.Count > 0)
            {
                this.rowZAPOSLENI = this.ZAPOSLENISet.ZAPOSLENI[this.ZAPOSLENISet.ZAPOSLENI.Count - 1];
            }
        }

        private void LoadChildZaposleni(int startRow, int maxRows)
        {
            this.CreateNewRowZaposleni();
            bool enforceConstraints = this.ZAPOSLENISet.EnforceConstraints;
            this.ZAPOSLENISet.ZAPOSLENI.BeginLoadData();
            this.ScanStartZaposleni(startRow, maxRows);
            this.ZAPOSLENISet.ZAPOSLENI.EndLoadData();
            this.ZAPOSLENISet.EnforceConstraints = enforceConstraints;
        }

        private void LoadDataZaposleni(int maxRows)
        {
            int num = 0;
            if (this.RcdFound293 != 0)
            {
                this.ScanLoadZaposleni();
                while ((this.RcdFound293 != 0) && (num != maxRows))
                {
                    num++;
                    this.LoadRowZaposleni();
                    this.CreateNewRowZaposleni();
                    this.ScanNextZaposleni();
                }
            }
            if (num > 0)
            {
                this.RcdFound293 = 1;
            }
            this.ScanEndZaposleni();
            if (this.ZAPOSLENISet.ZAPOSLENI.Count > 0)
            {
                this.rowZAPOSLENI = this.ZAPOSLENISet.ZAPOSLENI[this.ZAPOSLENISet.ZAPOSLENI.Count - 1];
            }
        }

        private void LoadRowZaposleni()
        {
            this.AddRowZaposleni();
        }

        private void OnZAPOSLENIUpdated(ZAPOSLENIEventArgs e)
        {
            if (this.ZAPOSLENIUpdated != null)
            {
                ZAPOSLENIUpdateEventHandler zAPOSLENIUpdatedEvent = this.ZAPOSLENIUpdated;
                if (zAPOSLENIUpdatedEvent != null)
                {
                    zAPOSLENIUpdatedEvent(this, e);
                }
            }
        }

        private void OnZAPOSLENIUpdating(ZAPOSLENIEventArgs e)
        {
            if (this.ZAPOSLENIUpdating != null)
            {
                ZAPOSLENIUpdateEventHandler zAPOSLENIUpdatingEvent = this.ZAPOSLENIUpdating;
                if (zAPOSLENIUpdatingEvent != null)
                {
                    zAPOSLENIUpdatingEvent(this, e);
                }
            }
        }

        private void ReadRowZaposleni()
        {
            this.Gx_mode = Mode.FromRowState(this.rowZAPOSLENI.RowState);
            if (this.rowZAPOSLENI.RowState != DataRowState.Deleted)
            {
                this.rowZAPOSLENI["DATUMZAPOSLENJA"] = RuntimeHelpers.GetObjectValue(DateTimeUtil.ResetTimeObject(RuntimeHelpers.GetObjectValue(this.rowZAPOSLENI["DATUMZAPOSLENJA"])));
            }
            if (this.rowZAPOSLENI.RowState == DataRowState.Added)
            {
            }
            this._Gxremove = this.rowZAPOSLENI.RowState == DataRowState.Deleted;
            if (this._Gxremove)
            {
                this.rowZAPOSLENI = (ZAPOSLENIDataSet.ZAPOSLENIRow) DataSetUtil.CloneOriginalDataRow(this.rowZAPOSLENI);
            }
        }

        private void ScanByIDRADNIK(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[IDRADNIK] = @IDRADNIK";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString293 + "  FROM [ZAPOSLENI] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDRADNIK], TM1.[DATUMZAPOSLENJA]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString293, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDRADNIK], TM1.[DATUMZAPOSLENJA] ) AS DK_PAGENUM   FROM [ZAPOSLENI] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString293 + " FROM [ZAPOSLENI] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDRADNIK], TM1.[DATUMZAPOSLENJA] ";
            }
            this.cmZAPOSLENISelect5 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmZAPOSLENISelect5.IDbCommand.Parameters.Count == 0)
            {
                this.cmZAPOSLENISelect5.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
            }
            this.cmZAPOSLENISelect5.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowZAPOSLENI["IDRADNIK"]));
            this.ZAPOSLENISelect5 = this.cmZAPOSLENISelect5.FetchData();
            this.RcdFound293 = 0;
            this.ScanLoadZaposleni();
            this.LoadDataZaposleni(maxRows);
        }

        private void ScanByIDRADNIKDATUMZAPOSLENJA(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[IDRADNIK] = @IDRADNIK and TM1.[DATUMZAPOSLENJA] = @DATUMZAPOSLENJA";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString293 + "  FROM [ZAPOSLENI] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDRADNIK], TM1.[DATUMZAPOSLENJA]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString293, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDRADNIK], TM1.[DATUMZAPOSLENJA] ) AS DK_PAGENUM   FROM [ZAPOSLENI] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString293 + " FROM [ZAPOSLENI] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDRADNIK], TM1.[DATUMZAPOSLENJA] ";
            }
            this.cmZAPOSLENISelect5 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmZAPOSLENISelect5.IDbCommand.Parameters.Count == 0)
            {
                this.cmZAPOSLENISelect5.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
                this.cmZAPOSLENISelect5.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DATUMZAPOSLENJA", DbType.Date));
            }
            this.cmZAPOSLENISelect5.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowZAPOSLENI["IDRADNIK"]));
            this.cmZAPOSLENISelect5.SetParameterDateObject(1, RuntimeHelpers.GetObjectValue(this.rowZAPOSLENI["DATUMZAPOSLENJA"]));
            this.ZAPOSLENISelect5 = this.cmZAPOSLENISelect5.FetchData();
            this.RcdFound293 = 0;
            this.ScanLoadZaposleni();
            this.LoadDataZaposleni(maxRows);
        }

        private void ScanEndZaposleni()
        {
            this.ZAPOSLENISelect5.Close();
        }

        private void ScanLoadZaposleni()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmZAPOSLENISelect5.HasMoreRows)
            {
                this.RcdFound293 = 1;
                this.rowZAPOSLENI["DATUMZAPOSLENJA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDateTime(this.ZAPOSLENISelect5, 0));
                this.rowZAPOSLENI["IDRADNIK"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.ZAPOSLENISelect5, 1));
            }
        }

        private void ScanNextZaposleni()
        {
            this.cmZAPOSLENISelect5.HasMoreRows = this.ZAPOSLENISelect5.Read();
            this.RcdFound293 = 0;
            this.ScanLoadZaposleni();
        }

        private void ScanStartZaposleni(int startRow, int maxRows)
        {
            this.m_WhereString = "";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString293 + "  FROM [ZAPOSLENI] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDRADNIK], TM1.[DATUMZAPOSLENJA]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString293, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDRADNIK], TM1.[DATUMZAPOSLENJA] ) AS DK_PAGENUM   FROM [ZAPOSLENI] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString293 + " FROM [ZAPOSLENI] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDRADNIK], TM1.[DATUMZAPOSLENJA] ";
            }
            this.cmZAPOSLENISelect5 = this.connDefault.GetCommand(this.scmdbuf, false);
            this.ZAPOSLENISelect5 = this.cmZAPOSLENISelect5.FetchData();
            this.RcdFound293 = 0;
            this.ScanLoadZaposleni();
            this.LoadDataZaposleni(maxRows);
        }

        public virtual int Update(DataSet dataSet)
        {
            this.InitializeMembers();
            this.ZAPOSLENISet = (ZAPOSLENIDataSet) dataSet;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            if (this.ZAPOSLENISet == null)
            {
                throw new ArgumentException(this.resourceManager.GetString("nulldset"));
            }
            try
            {
                IEnumerator enumerator = null;
                this.connDefault.BeginTransaction();
                try
                {
                    enumerator = this.ZAPOSLENISet.ZAPOSLENI.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        ZAPOSLENIDataSet.ZAPOSLENIRow current = (ZAPOSLENIDataSet.ZAPOSLENIRow) enumerator.Current;
                        this.rowZAPOSLENI = current;
                        if (Helpers.IsRowChanged(this.rowZAPOSLENI))
                        {
                            this.ReadRowZaposleni();
                            if (this.rowZAPOSLENI.RowState == DataRowState.Added)
                            {
                                this.InsertZaposleni();
                            }
                            else
                            {
                                if (this._Gxremove)
                                {
                                    this.Delete();
                                    continue;
                                }
                                this.UpdateZaposleni();
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

        private void UpdateZaposleni()
        {
            this.CheckOptimisticConcurrencyZaposleni();
            this.AfterConfirmZaposleni();
            this.OnZAPOSLENIUpdated(new ZAPOSLENIEventArgs(this.rowZAPOSLENI, StatementType.Update));
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

        [Serializable]
        public class ZAPOSLENIDataChangedException : DataChangedException
        {
            public ZAPOSLENIDataChangedException()
            {
            }

            public ZAPOSLENIDataChangedException(string message) : base(message)
            {
            }

            protected ZAPOSLENIDataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public ZAPOSLENIDataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class ZAPOSLENIDataLockedException : DataLockedException
        {
            public ZAPOSLENIDataLockedException()
            {
            }

            public ZAPOSLENIDataLockedException(string message) : base(message)
            {
            }

            protected ZAPOSLENIDataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public ZAPOSLENIDataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class ZAPOSLENIDuplicateKeyException : DuplicateKeyException
        {
            public ZAPOSLENIDuplicateKeyException()
            {
            }

            public ZAPOSLENIDuplicateKeyException(string message) : base(message)
            {
            }

            protected ZAPOSLENIDuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public ZAPOSLENIDuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class ZAPOSLENIEventArgs : EventArgs
        {
            private ZAPOSLENIDataSet.ZAPOSLENIRow m_dataRow;
            private System.Data.StatementType m_statementType;

            public ZAPOSLENIEventArgs(ZAPOSLENIDataSet.ZAPOSLENIRow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public ZAPOSLENIDataSet.ZAPOSLENIRow Row
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
        public class ZAPOSLENINotFoundException : DataNotFoundException
        {
            public ZAPOSLENINotFoundException()
            {
            }

            public ZAPOSLENINotFoundException(string message) : base(message)
            {
            }

            protected ZAPOSLENINotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public ZAPOSLENINotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public delegate void ZAPOSLENIUpdateEventHandler(object sender, ZAPOSLENIDataAdapter.ZAPOSLENIEventArgs e);
    }
}


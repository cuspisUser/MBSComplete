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

    public class OSOBNIODBITAKDataAdapter : IDataAdapter, IOSOBNIODBITAKDataAdapter
    {
        private bool _Gxremove;
        private ReadWriteCommand cmOSOBNIODBITAKSelect1;
        private ReadWriteCommand cmOSOBNIODBITAKSelect4;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private DbParameter[] fillDataParameters;
        private StatementType Gx_mode;
        private object m__FAKTOROSOBNOGODBITKAOriginal;
        private object m__NAZIVOSOBNIODBITAKOriginal;
        private readonly string m_SelectString19 = "TM1.[IDOSOBNIODBITAK], TM1.[NAZIVOSOBNIODBITAK], TM1.[FAKTOROSOBNOGODBITKA]";
        private string m_WhereString;
        private IDataReader OSOBNIODBITAKSelect1;
        private IDataReader OSOBNIODBITAKSelect4;
        private OSOBNIODBITAKDataSet OSOBNIODBITAKSet;
        private short RcdFound19;
        private int recordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private OSOBNIODBITAKDataSet.OSOBNIODBITAKRow rowOSOBNIODBITAK;
        private string scmdbuf;
        private StatementType sMode19;

        public event OSOBNIODBITAKUpdateEventHandler OSOBNIODBITAKUpdated;

        public event OSOBNIODBITAKUpdateEventHandler OSOBNIODBITAKUpdating;

        private void AddRowOsobniodbitak()
        {
            this.OSOBNIODBITAKSet.OSOBNIODBITAK.AddOSOBNIODBITAKRow(this.rowOSOBNIODBITAK);
        }

        private void AfterConfirmOsobniodbitak()
        {
            this.OnOSOBNIODBITAKUpdating(new OSOBNIODBITAKEventArgs(this.rowOSOBNIODBITAK, this.Gx_mode));
        }

        private void CheckDeleteErrorsOsobniodbitak()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT TOP 1 [IDRADNIK], [OSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK] FROM [RADNIKOdbitak] WITH (NOLOCK) WHERE [OSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK] = @IDOSOBNIODBITAK ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOSOBNIODBITAK", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOSOBNIODBITAK["IDOSOBNIODBITAK"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                reader.Close();
                throw new RADNIKOdbitakInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "RADNIKOdbitak" }));
            }
            reader.Close();
        }

        private void CheckExtendedTableOsobniodbitak()
        {
            if (this.rowOSOBNIODBITAK.NAZIVOSOBNIODBITAK.Length == 0)
            {
                throw new EmptyNotAllowedException(string.Format(this.resourceManager.GetString("notnullempty"), new object[] { "Naziv osobnog odbitka" }));
            }
        }

        private void CheckOptimisticConcurrencyOsobniodbitak()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDOSOBNIODBITAK], [NAZIVOSOBNIODBITAK], [FAKTOROSOBNOGODBITKA] FROM [OSOBNIODBITAK] WITH (UPDLOCK) WHERE [IDOSOBNIODBITAK] = @IDOSOBNIODBITAK ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOSOBNIODBITAK", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOSOBNIODBITAK["IDOSOBNIODBITAK"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new OSOBNIODBITAKDataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("OSOBNIODBITAK") }));
                }
                if ((!command.HasMoreRows || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__NAZIVOSOBNIODBITAKOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetStringNE(reader, 1)))) || !this.m__FAKTOROSOBNOGODBITKAOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 2))))
                {
                    reader.Close();
                    throw new OSOBNIODBITAKDataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("OSOBNIODBITAK") }));
                }
                reader.Close();
            }
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        private void CreateNewRowOsobniodbitak()
        {
            this.rowOSOBNIODBITAK = this.OSOBNIODBITAKSet.OSOBNIODBITAK.NewOSOBNIODBITAKRow();
        }

        private void Delete()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyOsobniodbitak();
            this.AfterConfirmOsobniodbitak();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [OSOBNIODBITAK]  WHERE [IDOSOBNIODBITAK] = @IDOSOBNIODBITAK", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOSOBNIODBITAK", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOSOBNIODBITAK["IDOSOBNIODBITAK"]));
            command.ExecuteStmt();
            if (command.ForeignKeyError)
            {
                this.CheckDeleteErrorsOsobniodbitak();
            }
            this.OnOSOBNIODBITAKUpdated(new OSOBNIODBITAKEventArgs(this.rowOSOBNIODBITAK, StatementType.Delete));
            this.rowOSOBNIODBITAK.Delete();
            this.sMode19 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode19;
        }

        public virtual int Fill(OSOBNIODBITAKDataSet dataSet)
        {
            if (this.fillDataParameters != null)
            {
                this.Fill(dataSet, int.Parse(this.fillDataParameters[0].Value.ToString()));
            }
            else
            {
                try
                {
                    this.InitializeMembers();
                    this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
                    this.OSOBNIODBITAKSet = dataSet;
                    this.LoadChildOsobniodbitak(0, -1);
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
            this.OSOBNIODBITAKSet = (OSOBNIODBITAKDataSet) dataSet;
            if (this.OSOBNIODBITAKSet != null)
            {
                return this.Fill(this.OSOBNIODBITAKSet);
            }
            this.OSOBNIODBITAKSet = new OSOBNIODBITAKDataSet();
            this.Fill(this.OSOBNIODBITAKSet);
            dataSet.Merge(this.OSOBNIODBITAKSet);
            return 0;
        }

        public virtual int Fill(OSOBNIODBITAKDataSet dataSet, DataRow dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDOSOBNIODBITAK"]));
        }

        public virtual int Fill(OSOBNIODBITAKDataSet dataSet, IDataRecord dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDOSOBNIODBITAK"]));
        }

        public virtual int Fill(OSOBNIODBITAKDataSet dataSet, int iDOSOBNIODBITAK)
        {
            if (!this.FillByIDOSOBNIODBITAK(dataSet, iDOSOBNIODBITAK))
            {
                throw new OSOBNIODBITAKNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("OSOBNIODBITAK") }));
            }
            return 0;
        }

        public virtual bool FillByIDOSOBNIODBITAK(OSOBNIODBITAKDataSet dataSet, int iDOSOBNIODBITAK)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.OSOBNIODBITAKSet = dataSet;
            this.rowOSOBNIODBITAK = this.OSOBNIODBITAKSet.OSOBNIODBITAK.NewOSOBNIODBITAKRow();
            this.rowOSOBNIODBITAK.IDOSOBNIODBITAK = iDOSOBNIODBITAK;
            try
            {
                this.LoadByIDOSOBNIODBITAK(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            if (this.RcdFound19 == 0)
            {
                return false;
            }
            return true;
        }

        public virtual int FillPage(OSOBNIODBITAKDataSet dataSet, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.OSOBNIODBITAKSet = dataSet;
            try
            {
                this.LoadChildOsobniodbitak(startRow, maxRows);
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
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDOSOBNIODBITAK], [NAZIVOSOBNIODBITAK], [FAKTOROSOBNOGODBITKA] FROM [OSOBNIODBITAK] WITH (NOLOCK) WHERE [IDOSOBNIODBITAK] = @IDOSOBNIODBITAK ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOSOBNIODBITAK", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOSOBNIODBITAK["IDOSOBNIODBITAK"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.RcdFound19 = 1;
                this.rowOSOBNIODBITAK["IDOSOBNIODBITAK"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 0));
                this.rowOSOBNIODBITAK["NAZIVOSOBNIODBITAK"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetStringNE(reader, 1));
                this.rowOSOBNIODBITAK["FAKTOROSOBNOGODBITKA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 2));
                this.sMode19 = this.Gx_mode;
                this.Gx_mode = StatementType.Select;
                this.Gx_mode = this.sMode19;
            }
            else
            {
                this.RcdFound19 = 0;
            }
            reader.Close();
        }

        public virtual IDataParameter[] GetFillParameters()
        {
            if (this.fillDataParameters == null)
            {
                DbParameter parameter = DbProviderFactories.GetFactory("System.Data.SqlClient").CreateParameter();
                parameter.ParameterName = "IDOSOBNIODBITAK";
                parameter.DbType = DbType.Int32;
                this.fillDataParameters = new DbParameter[] { parameter };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount()
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmOSOBNIODBITAKSelect1 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [OSOBNIODBITAK] WITH (NOLOCK) ", false);
            this.OSOBNIODBITAKSelect1 = this.cmOSOBNIODBITAKSelect1.FetchData();
            if (this.OSOBNIODBITAKSelect1.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.OSOBNIODBITAKSelect1.GetInt32(0);
            }
            this.OSOBNIODBITAKSelect1.Close();
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

        private void Initialize()
        {
            this.resourceManager = Deklarit.Utils.ResourceManager.Instance;
            this.resourceManagerTables = new System.Resources.ResourceManager("Tables", Assembly.GetExecutingAssembly());
            this.RcdFound19 = 0;
            this.scmdbuf = "";
            this.recordCount = 0;
            this._Gxremove = false;
            this.m__NAZIVOSOBNIODBITAKOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__FAKTOROSOBNOGODBITKAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m_WhereString = "";
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void InitializeMembers()
        {
            this.OSOBNIODBITAKSet = new OSOBNIODBITAKDataSet();
            this.Initialize();
            this.dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        }

        private void InsertOsobniodbitak()
        {
            this.CheckOptimisticConcurrencyOsobniodbitak();
            this.CheckExtendedTableOsobniodbitak();
            this.AfterConfirmOsobniodbitak();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [OSOBNIODBITAK] ([IDOSOBNIODBITAK], [NAZIVOSOBNIODBITAK], [FAKTOROSOBNOGODBITKA]) VALUES (@IDOSOBNIODBITAK, @NAZIVOSOBNIODBITAK, @FAKTOROSOBNOGODBITKA)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOSOBNIODBITAK", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVOSOBNIODBITAK", DbType.String, 100));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@FAKTOROSOBNOGODBITKA", DbType.Currency));
            }
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOSOBNIODBITAK["IDOSOBNIODBITAK"]));
            command.SetParameterString(1, RuntimeHelpers.GetObjectValue(this.rowOSOBNIODBITAK["NAZIVOSOBNIODBITAK"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowOSOBNIODBITAK["FAKTOROSOBNOGODBITKA"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new OSOBNIODBITAKDuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            this.OnOSOBNIODBITAKUpdated(new OSOBNIODBITAKEventArgs(this.rowOSOBNIODBITAK, StatementType.Insert));
        }

        private void LoadByIDOSOBNIODBITAK(int startRow, int maxRows)
        {
            bool enforceConstraints = this.OSOBNIODBITAKSet.EnforceConstraints;
            this.OSOBNIODBITAKSet.OSOBNIODBITAK.BeginLoadData();
            this.ScanByIDOSOBNIODBITAK(startRow, maxRows);
            this.OSOBNIODBITAKSet.OSOBNIODBITAK.EndLoadData();
            this.OSOBNIODBITAKSet.EnforceConstraints = enforceConstraints;
            if (this.OSOBNIODBITAKSet.OSOBNIODBITAK.Count > 0)
            {
                this.rowOSOBNIODBITAK = this.OSOBNIODBITAKSet.OSOBNIODBITAK[this.OSOBNIODBITAKSet.OSOBNIODBITAK.Count - 1];
            }
        }

        private void LoadChildOsobniodbitak(int startRow, int maxRows)
        {
            this.CreateNewRowOsobniodbitak();
            bool enforceConstraints = this.OSOBNIODBITAKSet.EnforceConstraints;
            this.OSOBNIODBITAKSet.OSOBNIODBITAK.BeginLoadData();
            this.ScanStartOsobniodbitak(startRow, maxRows);
            this.OSOBNIODBITAKSet.OSOBNIODBITAK.EndLoadData();
            this.OSOBNIODBITAKSet.EnforceConstraints = enforceConstraints;
        }

        private void LoadDataOsobniodbitak(int maxRows)
        {
            int num = 0;
            if (this.RcdFound19 != 0)
            {
                this.ScanLoadOsobniodbitak();
                while ((this.RcdFound19 != 0) && (num != maxRows))
                {
                    num++;
                    this.LoadRowOsobniodbitak();
                    this.CreateNewRowOsobniodbitak();
                    this.ScanNextOsobniodbitak();
                }
            }
            if (num > 0)
            {
                this.RcdFound19 = 1;
            }
            this.ScanEndOsobniodbitak();
            if (this.OSOBNIODBITAKSet.OSOBNIODBITAK.Count > 0)
            {
                this.rowOSOBNIODBITAK = this.OSOBNIODBITAKSet.OSOBNIODBITAK[this.OSOBNIODBITAKSet.OSOBNIODBITAK.Count - 1];
            }
        }

        private void LoadRowOsobniodbitak()
        {
            this.AddRowOsobniodbitak();
        }

        private void OnOSOBNIODBITAKUpdated(OSOBNIODBITAKEventArgs e)
        {
            if (this.OSOBNIODBITAKUpdated != null)
            {
                OSOBNIODBITAKUpdateEventHandler oSOBNIODBITAKUpdatedEvent = this.OSOBNIODBITAKUpdated;
                if (oSOBNIODBITAKUpdatedEvent != null)
                {
                    oSOBNIODBITAKUpdatedEvent(this, e);
                }
            }
        }

        private void OnOSOBNIODBITAKUpdating(OSOBNIODBITAKEventArgs e)
        {
            if (this.OSOBNIODBITAKUpdating != null)
            {
                OSOBNIODBITAKUpdateEventHandler oSOBNIODBITAKUpdatingEvent = this.OSOBNIODBITAKUpdating;
                if (oSOBNIODBITAKUpdatingEvent != null)
                {
                    oSOBNIODBITAKUpdatingEvent(this, e);
                }
            }
        }

        private void ReadRowOsobniodbitak()
        {
            this.Gx_mode = Mode.FromRowState(this.rowOSOBNIODBITAK.RowState);
            if (this.rowOSOBNIODBITAK.RowState != DataRowState.Added)
            {
                this.m__NAZIVOSOBNIODBITAKOriginal = RuntimeHelpers.GetObjectValue(this.rowOSOBNIODBITAK["NAZIVOSOBNIODBITAK", DataRowVersion.Original]);
                this.m__FAKTOROSOBNOGODBITKAOriginal = RuntimeHelpers.GetObjectValue(this.rowOSOBNIODBITAK["FAKTOROSOBNOGODBITKA", DataRowVersion.Original]);
            }
            else
            {
                this.m__NAZIVOSOBNIODBITAKOriginal = RuntimeHelpers.GetObjectValue(this.rowOSOBNIODBITAK["NAZIVOSOBNIODBITAK"]);
                this.m__FAKTOROSOBNOGODBITKAOriginal = RuntimeHelpers.GetObjectValue(this.rowOSOBNIODBITAK["FAKTOROSOBNOGODBITKA"]);
            }
            this._Gxremove = this.rowOSOBNIODBITAK.RowState == DataRowState.Deleted;
            if (this._Gxremove)
            {
                this.rowOSOBNIODBITAK = (OSOBNIODBITAKDataSet.OSOBNIODBITAKRow) DataSetUtil.CloneOriginalDataRow(this.rowOSOBNIODBITAK);
            }
        }

        private void ScanByIDOSOBNIODBITAK(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[IDOSOBNIODBITAK] = @IDOSOBNIODBITAK";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString19 + "  FROM [OSOBNIODBITAK] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDOSOBNIODBITAK]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString19, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDOSOBNIODBITAK] ) AS DK_PAGENUM   FROM [OSOBNIODBITAK] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString19 + " FROM [OSOBNIODBITAK] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDOSOBNIODBITAK] ";
            }
            this.cmOSOBNIODBITAKSelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmOSOBNIODBITAKSelect4.IDbCommand.Parameters.Count == 0)
            {
                this.cmOSOBNIODBITAKSelect4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOSOBNIODBITAK", DbType.Int32));
            }
            this.cmOSOBNIODBITAKSelect4.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOSOBNIODBITAK["IDOSOBNIODBITAK"]));
            this.OSOBNIODBITAKSelect4 = this.cmOSOBNIODBITAKSelect4.FetchData();
            this.RcdFound19 = 0;
            this.ScanLoadOsobniodbitak();
            this.LoadDataOsobniodbitak(maxRows);
        }

        private void ScanEndOsobniodbitak()
        {
            this.OSOBNIODBITAKSelect4.Close();
        }

        private void ScanLoadOsobniodbitak()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmOSOBNIODBITAKSelect4.HasMoreRows)
            {
                this.RcdFound19 = 1;
                this.rowOSOBNIODBITAK["IDOSOBNIODBITAK"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.OSOBNIODBITAKSelect4, 0));
                this.rowOSOBNIODBITAK["NAZIVOSOBNIODBITAK"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetStringNE(this.OSOBNIODBITAKSelect4, 1));
                this.rowOSOBNIODBITAK["FAKTOROSOBNOGODBITKA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.OSOBNIODBITAKSelect4, 2));
            }
        }

        private void ScanNextOsobniodbitak()
        {
            this.cmOSOBNIODBITAKSelect4.HasMoreRows = this.OSOBNIODBITAKSelect4.Read();
            this.RcdFound19 = 0;
            this.ScanLoadOsobniodbitak();
        }

        private void ScanStartOsobniodbitak(int startRow, int maxRows)
        {
            this.m_WhereString = "";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString19 + "  FROM [OSOBNIODBITAK] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDOSOBNIODBITAK]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString19, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDOSOBNIODBITAK] ) AS DK_PAGENUM   FROM [OSOBNIODBITAK] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString19 + " FROM [OSOBNIODBITAK] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDOSOBNIODBITAK] ";
            }
            this.cmOSOBNIODBITAKSelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            this.OSOBNIODBITAKSelect4 = this.cmOSOBNIODBITAKSelect4.FetchData();
            this.RcdFound19 = 0;
            this.ScanLoadOsobniodbitak();
            this.LoadDataOsobniodbitak(maxRows);
        }

        public virtual int Update(DataSet dataSet)
        {
            this.InitializeMembers();
            this.OSOBNIODBITAKSet = (OSOBNIODBITAKDataSet) dataSet;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            if (this.OSOBNIODBITAKSet == null)
            {
                throw new ArgumentException(this.resourceManager.GetString("nulldset"));
            }
            try
            {
                IEnumerator enumerator = null;
                this.connDefault.BeginTransaction();
                try
                {
                    enumerator = this.OSOBNIODBITAKSet.OSOBNIODBITAK.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        OSOBNIODBITAKDataSet.OSOBNIODBITAKRow current = (OSOBNIODBITAKDataSet.OSOBNIODBITAKRow) enumerator.Current;
                        this.rowOSOBNIODBITAK = current;
                        if (Helpers.IsRowChanged(this.rowOSOBNIODBITAK))
                        {
                            this.ReadRowOsobniodbitak();
                            if (this.rowOSOBNIODBITAK.RowState == DataRowState.Added)
                            {
                                this.InsertOsobniodbitak();
                            }
                            else
                            {
                                if (this._Gxremove)
                                {
                                    this.Delete();
                                    continue;
                                }
                                this.UpdateOsobniodbitak();
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

        private void UpdateOsobniodbitak()
        {
            this.CheckOptimisticConcurrencyOsobniodbitak();
            this.CheckExtendedTableOsobniodbitak();
            this.AfterConfirmOsobniodbitak();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [OSOBNIODBITAK] SET [NAZIVOSOBNIODBITAK]=@NAZIVOSOBNIODBITAK, [FAKTOROSOBNOGODBITKA]=@FAKTOROSOBNOGODBITKA  WHERE [IDOSOBNIODBITAK] = @IDOSOBNIODBITAK", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVOSOBNIODBITAK", DbType.String, 100));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@FAKTOROSOBNOGODBITKA", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOSOBNIODBITAK", DbType.Int32));
            }
            command.SetParameterString(0, RuntimeHelpers.GetObjectValue(this.rowOSOBNIODBITAK["NAZIVOSOBNIODBITAK"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowOSOBNIODBITAK["FAKTOROSOBNOGODBITKA"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowOSOBNIODBITAK["IDOSOBNIODBITAK"]));
            command.ExecuteStmt();
            this.OnOSOBNIODBITAKUpdated(new OSOBNIODBITAKEventArgs(this.rowOSOBNIODBITAK, StatementType.Update));
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
        public class OSOBNIODBITAKDataChangedException : DataChangedException
        {
            public OSOBNIODBITAKDataChangedException()
            {
            }

            public OSOBNIODBITAKDataChangedException(string message) : base(message)
            {
            }

            protected OSOBNIODBITAKDataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public OSOBNIODBITAKDataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class OSOBNIODBITAKDataLockedException : DataLockedException
        {
            public OSOBNIODBITAKDataLockedException()
            {
            }

            public OSOBNIODBITAKDataLockedException(string message) : base(message)
            {
            }

            protected OSOBNIODBITAKDataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public OSOBNIODBITAKDataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class OSOBNIODBITAKDuplicateKeyException : DuplicateKeyException
        {
            public OSOBNIODBITAKDuplicateKeyException()
            {
            }

            public OSOBNIODBITAKDuplicateKeyException(string message) : base(message)
            {
            }

            protected OSOBNIODBITAKDuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public OSOBNIODBITAKDuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class OSOBNIODBITAKEventArgs : EventArgs
        {
            private OSOBNIODBITAKDataSet.OSOBNIODBITAKRow m_dataRow;
            private System.Data.StatementType m_statementType;

            public OSOBNIODBITAKEventArgs(OSOBNIODBITAKDataSet.OSOBNIODBITAKRow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public OSOBNIODBITAKDataSet.OSOBNIODBITAKRow Row
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
        public class OSOBNIODBITAKNotFoundException : DataNotFoundException
        {
            public OSOBNIODBITAKNotFoundException()
            {
            }

            public OSOBNIODBITAKNotFoundException(string message) : base(message)
            {
            }

            protected OSOBNIODBITAKNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public OSOBNIODBITAKNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public delegate void OSOBNIODBITAKUpdateEventHandler(object sender, OSOBNIODBITAKDataAdapter.OSOBNIODBITAKEventArgs e);

        [Serializable]
        public class RADNIKOdbitakInvalidDeleteException : InvalidDeleteException
        {
            public RADNIKOdbitakInvalidDeleteException()
            {
            }

            public RADNIKOdbitakInvalidDeleteException(string message) : base(message)
            {
            }

            protected RADNIKOdbitakInvalidDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public RADNIKOdbitakInvalidDeleteException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }
    }
}


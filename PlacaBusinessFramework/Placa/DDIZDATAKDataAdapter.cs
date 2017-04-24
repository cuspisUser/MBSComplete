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

    public class DDIZDATAKDataAdapter : IDataAdapter, IDDIZDATAKDataAdapter
    {
        private bool _Gxremove;
        private ReadWriteCommand cmDDIZDATAKSelect1;
        private ReadWriteCommand cmDDIZDATAKSelect4;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private IDataReader DDIZDATAKSelect1;
        private IDataReader DDIZDATAKSelect4;
        private DDIZDATAKDataSet DDIZDATAKSet;
        private DataStore dsDefault;
        private DbParameter[] fillDataParameters;
        private StatementType Gx_mode;
        private object m__DDNAZIVIZDATKAOriginal;
        private object m__DDPOSTOTAKIZDATKAOriginal;
        private readonly string m_SelectString163 = "TM1.[DDIDIZDATAK], TM1.[DDNAZIVIZDATKA], TM1.[DDPOSTOTAKIZDATKA]";
        private string m_WhereString;
        private short RcdFound163;
        private int recordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private DDIZDATAKDataSet.DDIZDATAKRow rowDDIZDATAK;
        private string scmdbuf;
        private StatementType sMode163;

        public event DDIZDATAKUpdateEventHandler DDIZDATAKUpdated;

        public event DDIZDATAKUpdateEventHandler DDIZDATAKUpdating;

        private void AddRowDdizdatak()
        {
            this.DDIZDATAKSet.DDIZDATAK.AddDDIZDATAKRow(this.rowDDIZDATAK);
        }

        private void AfterConfirmDdizdatak()
        {
            this.OnDDIZDATAKUpdating(new DDIZDATAKEventArgs(this.rowDDIZDATAK, this.Gx_mode));
        }

        private void CheckDeleteErrorsDdizdatak()
        {
            ReadWriteCommand command2 = this.connDefault.GetCommand("SELECT TOP 1 [DDOBRACUNIDOBRACUN], [DDIDRADNIK], [DDIDIZDATAK] FROM [DDOBRACUNRadniciIzdaci] WITH (NOLOCK) WHERE [DDIDIZDATAK] = @DDIDIZDATAK ", false);
            if (command2.IDbCommand.Parameters.Count == 0)
            {
                command2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDIDIZDATAK", DbType.Int32));
            }
            command2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDIZDATAK["DDIDIZDATAK"]));
            IDataReader reader2 = command2.FetchData();
            if (command2.HasMoreRows)
            {
                reader2.Close();
                throw new DDOBRACUNRadniciIzdaciInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "Izdaci" }));
            }
            reader2.Close();
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT TOP 1 [IDKATEGORIJA], [DDIDIZDATAK] FROM [DDKATEGORIJAIzdaci] WITH (NOLOCK) WHERE [DDIDIZDATAK] = @DDIDIZDATAK ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDIDIZDATAK", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDIZDATAK["DDIDIZDATAK"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                reader.Close();
                throw new DDKATEGORIJAIzdaciInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "Izdaci" }));
            }
            reader.Close();
        }

        private void CheckOptimisticConcurrencyDdizdatak()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [DDIDIZDATAK], [DDNAZIVIZDATKA], [DDPOSTOTAKIZDATKA] FROM [DDIZDATAK] WITH (UPDLOCK) WHERE [DDIDIZDATAK] = @DDIDIZDATAK ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDIDIZDATAK", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDIZDATAK["DDIDIZDATAK"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new DDIZDATAKDataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("DDIZDATAK") }));
                }
                if ((!command.HasMoreRows || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__DDNAZIVIZDATKAOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1)))) || !this.m__DDPOSTOTAKIZDATKAOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 2))))
                {
                    reader.Close();
                    throw new DDIZDATAKDataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("DDIZDATAK") }));
                }
                reader.Close();
            }
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        private void CreateNewRowDdizdatak()
        {
            this.rowDDIZDATAK = this.DDIZDATAKSet.DDIZDATAK.NewDDIZDATAKRow();
        }

        private void Delete()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyDdizdatak();
            this.AfterConfirmDdizdatak();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [DDIZDATAK]  WHERE [DDIDIZDATAK] = @DDIDIZDATAK", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDIDIZDATAK", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDIZDATAK["DDIDIZDATAK"]));
            command.ExecuteStmt();
            if (command.ForeignKeyError)
            {
                this.CheckDeleteErrorsDdizdatak();
            }
            this.OnDDIZDATAKUpdated(new DDIZDATAKEventArgs(this.rowDDIZDATAK, StatementType.Delete));
            this.rowDDIZDATAK.Delete();
            this.sMode163 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode163;
        }

        public virtual int Fill(DDIZDATAKDataSet dataSet)
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
                    this.DDIZDATAKSet = dataSet;
                    this.LoadChildDdizdatak(0, -1);
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
            this.DDIZDATAKSet = (DDIZDATAKDataSet) dataSet;
            if (this.DDIZDATAKSet != null)
            {
                return this.Fill(this.DDIZDATAKSet);
            }
            this.DDIZDATAKSet = new DDIZDATAKDataSet();
            this.Fill(this.DDIZDATAKSet);
            dataSet.Merge(this.DDIZDATAKSet);
            return 0;
        }

        public virtual int Fill(DDIZDATAKDataSet dataSet, DataRow dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["DDIDIZDATAK"]));
        }

        public virtual int Fill(DDIZDATAKDataSet dataSet, IDataRecord dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["DDIDIZDATAK"]));
        }

        public virtual int Fill(DDIZDATAKDataSet dataSet, int dDIDIZDATAK)
        {
            if (!this.FillByDDIDIZDATAK(dataSet, dDIDIZDATAK))
            {
                throw new DDIZDATAKNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("DDIZDATAK") }));
            }
            return 0;
        }

        public virtual bool FillByDDIDIZDATAK(DDIZDATAKDataSet dataSet, int dDIDIZDATAK)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.DDIZDATAKSet = dataSet;
            this.rowDDIZDATAK = this.DDIZDATAKSet.DDIZDATAK.NewDDIZDATAKRow();
            this.rowDDIZDATAK.DDIDIZDATAK = dDIDIZDATAK;
            try
            {
                this.LoadByDDIDIZDATAK(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            if (this.RcdFound163 == 0)
            {
                return false;
            }
            return true;
        }

        public virtual int FillPage(DDIZDATAKDataSet dataSet, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.DDIZDATAKSet = dataSet;
            try
            {
                this.LoadChildDdizdatak(startRow, maxRows);
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
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [DDIDIZDATAK], [DDNAZIVIZDATKA], [DDPOSTOTAKIZDATKA] FROM [DDIZDATAK] WITH (NOLOCK) WHERE [DDIDIZDATAK] = @DDIDIZDATAK ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDIDIZDATAK", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDIZDATAK["DDIDIZDATAK"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.RcdFound163 = 1;
                this.rowDDIZDATAK["DDIDIZDATAK"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 0));
                this.rowDDIZDATAK["DDNAZIVIZDATKA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1));
                this.rowDDIZDATAK["DDPOSTOTAKIZDATKA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 2));
                this.sMode163 = this.Gx_mode;
                this.Gx_mode = StatementType.Select;
                this.Gx_mode = this.sMode163;
            }
            else
            {
                this.RcdFound163 = 0;
            }
            reader.Close();
        }

        public virtual IDataParameter[] GetFillParameters()
        {
            if (this.fillDataParameters == null)
            {
                DbParameter parameter = DbProviderFactories.GetFactory("System.Data.SqlClient").CreateParameter();
                parameter.ParameterName = "DDIDIZDATAK";
                parameter.DbType = DbType.Int32;
                this.fillDataParameters = new DbParameter[] { parameter };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount()
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmDDIZDATAKSelect1 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [DDIZDATAK] WITH (NOLOCK) ", false);
            this.DDIZDATAKSelect1 = this.cmDDIZDATAKSelect1.FetchData();
            if (this.DDIZDATAKSelect1.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.DDIZDATAKSelect1.GetInt32(0);
            }
            this.DDIZDATAKSelect1.Close();
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
            this.RcdFound163 = 0;
            this.scmdbuf = "";
            this.recordCount = 0;
            this._Gxremove = false;
            this.m__DDNAZIVIZDATKAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__DDPOSTOTAKIZDATKAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m_WhereString = "";
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void InitializeMembers()
        {
            this.DDIZDATAKSet = new DDIZDATAKDataSet();
            this.Initialize();
            this.dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        }

        private void InsertDdizdatak()
        {
            this.CheckOptimisticConcurrencyDdizdatak();
            this.AfterConfirmDdizdatak();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [DDIZDATAK] ([DDIDIZDATAK], [DDNAZIVIZDATKA], [DDPOSTOTAKIZDATKA]) VALUES (@DDIDIZDATAK, @DDNAZIVIZDATKA, @DDPOSTOTAKIZDATKA)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDIDIZDATAK", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDNAZIVIZDATKA", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDPOSTOTAKIZDATKA", DbType.Currency));
            }
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDIZDATAK["DDIDIZDATAK"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowDDIZDATAK["DDNAZIVIZDATKA"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowDDIZDATAK["DDPOSTOTAKIZDATKA"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new DDIZDATAKDuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            this.OnDDIZDATAKUpdated(new DDIZDATAKEventArgs(this.rowDDIZDATAK, StatementType.Insert));
        }

        private void LoadByDDIDIZDATAK(int startRow, int maxRows)
        {
            bool enforceConstraints = this.DDIZDATAKSet.EnforceConstraints;
            this.DDIZDATAKSet.DDIZDATAK.BeginLoadData();
            this.ScanByDDIDIZDATAK(startRow, maxRows);
            this.DDIZDATAKSet.DDIZDATAK.EndLoadData();
            this.DDIZDATAKSet.EnforceConstraints = enforceConstraints;
            if (this.DDIZDATAKSet.DDIZDATAK.Count > 0)
            {
                this.rowDDIZDATAK = this.DDIZDATAKSet.DDIZDATAK[this.DDIZDATAKSet.DDIZDATAK.Count - 1];
            }
        }

        private void LoadChildDdizdatak(int startRow, int maxRows)
        {
            this.CreateNewRowDdizdatak();
            bool enforceConstraints = this.DDIZDATAKSet.EnforceConstraints;
            this.DDIZDATAKSet.DDIZDATAK.BeginLoadData();
            this.ScanStartDdizdatak(startRow, maxRows);
            this.DDIZDATAKSet.DDIZDATAK.EndLoadData();
            this.DDIZDATAKSet.EnforceConstraints = enforceConstraints;
        }

        private void LoadDataDdizdatak(int maxRows)
        {
            int num = 0;
            if (this.RcdFound163 != 0)
            {
                this.ScanLoadDdizdatak();
                while ((this.RcdFound163 != 0) && (num != maxRows))
                {
                    num++;
                    this.LoadRowDdizdatak();
                    this.CreateNewRowDdizdatak();
                    this.ScanNextDdizdatak();
                }
            }
            if (num > 0)
            {
                this.RcdFound163 = 1;
            }
            this.ScanEndDdizdatak();
            if (this.DDIZDATAKSet.DDIZDATAK.Count > 0)
            {
                this.rowDDIZDATAK = this.DDIZDATAKSet.DDIZDATAK[this.DDIZDATAKSet.DDIZDATAK.Count - 1];
            }
        }

        private void LoadRowDdizdatak()
        {
            this.AddRowDdizdatak();
        }

        private void OnDDIZDATAKUpdated(DDIZDATAKEventArgs e)
        {
            if (this.DDIZDATAKUpdated != null)
            {
                DDIZDATAKUpdateEventHandler dDIZDATAKUpdatedEvent = this.DDIZDATAKUpdated;
                if (dDIZDATAKUpdatedEvent != null)
                {
                    dDIZDATAKUpdatedEvent(this, e);
                }
            }
        }

        private void OnDDIZDATAKUpdating(DDIZDATAKEventArgs e)
        {
            if (this.DDIZDATAKUpdating != null)
            {
                DDIZDATAKUpdateEventHandler dDIZDATAKUpdatingEvent = this.DDIZDATAKUpdating;
                if (dDIZDATAKUpdatingEvent != null)
                {
                    dDIZDATAKUpdatingEvent(this, e);
                }
            }
        }

        private void ReadRowDdizdatak()
        {
            this.Gx_mode = Mode.FromRowState(this.rowDDIZDATAK.RowState);
            if (this.rowDDIZDATAK.RowState != DataRowState.Added)
            {
                this.m__DDNAZIVIZDATKAOriginal = RuntimeHelpers.GetObjectValue(this.rowDDIZDATAK["DDNAZIVIZDATKA", DataRowVersion.Original]);
                this.m__DDPOSTOTAKIZDATKAOriginal = RuntimeHelpers.GetObjectValue(this.rowDDIZDATAK["DDPOSTOTAKIZDATKA", DataRowVersion.Original]);
            }
            else
            {
                this.m__DDNAZIVIZDATKAOriginal = RuntimeHelpers.GetObjectValue(this.rowDDIZDATAK["DDNAZIVIZDATKA"]);
                this.m__DDPOSTOTAKIZDATKAOriginal = RuntimeHelpers.GetObjectValue(this.rowDDIZDATAK["DDPOSTOTAKIZDATKA"]);
            }
            this._Gxremove = this.rowDDIZDATAK.RowState == DataRowState.Deleted;
            if (this._Gxremove)
            {
                this.rowDDIZDATAK = (DDIZDATAKDataSet.DDIZDATAKRow) DataSetUtil.CloneOriginalDataRow(this.rowDDIZDATAK);
            }
        }

        private void ScanByDDIDIZDATAK(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[DDIDIZDATAK] = @DDIDIZDATAK";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString163 + "  FROM [DDIZDATAK] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[DDIDIZDATAK]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString163, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[DDIDIZDATAK] ) AS DK_PAGENUM   FROM [DDIZDATAK] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString163 + " FROM [DDIZDATAK] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[DDIDIZDATAK] ";
            }
            this.cmDDIZDATAKSelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmDDIZDATAKSelect4.IDbCommand.Parameters.Count == 0)
            {
                this.cmDDIZDATAKSelect4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDIDIZDATAK", DbType.Int32));
            }
            this.cmDDIZDATAKSelect4.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDIZDATAK["DDIDIZDATAK"]));
            this.DDIZDATAKSelect4 = this.cmDDIZDATAKSelect4.FetchData();
            this.RcdFound163 = 0;
            this.ScanLoadDdizdatak();
            this.LoadDataDdizdatak(maxRows);
        }

        private void ScanEndDdizdatak()
        {
            this.DDIZDATAKSelect4.Close();
        }

        private void ScanLoadDdizdatak()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmDDIZDATAKSelect4.HasMoreRows)
            {
                this.RcdFound163 = 1;
                this.rowDDIZDATAK["DDIDIZDATAK"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.DDIZDATAKSelect4, 0));
                this.rowDDIZDATAK["DDNAZIVIZDATKA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDIZDATAKSelect4, 1));
                this.rowDDIZDATAK["DDPOSTOTAKIZDATKA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.DDIZDATAKSelect4, 2));
            }
        }

        private void ScanNextDdizdatak()
        {
            this.cmDDIZDATAKSelect4.HasMoreRows = this.DDIZDATAKSelect4.Read();
            this.RcdFound163 = 0;
            this.ScanLoadDdizdatak();
        }

        private void ScanStartDdizdatak(int startRow, int maxRows)
        {
            this.m_WhereString = "";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString163 + "  FROM [DDIZDATAK] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[DDIDIZDATAK]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString163, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[DDIDIZDATAK] ) AS DK_PAGENUM   FROM [DDIZDATAK] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString163 + " FROM [DDIZDATAK] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[DDIDIZDATAK] ";
            }
            this.cmDDIZDATAKSelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            this.DDIZDATAKSelect4 = this.cmDDIZDATAKSelect4.FetchData();
            this.RcdFound163 = 0;
            this.ScanLoadDdizdatak();
            this.LoadDataDdizdatak(maxRows);
        }

        public virtual int Update(DataSet dataSet)
        {
            this.InitializeMembers();
            this.DDIZDATAKSet = (DDIZDATAKDataSet) dataSet;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            if (this.DDIZDATAKSet == null)
            {
                throw new ArgumentException(this.resourceManager.GetString("nulldset"));
            }
            try
            {
                IEnumerator enumerator = null;
                this.connDefault.BeginTransaction();
                try
                {
                    enumerator = this.DDIZDATAKSet.DDIZDATAK.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        DDIZDATAKDataSet.DDIZDATAKRow current = (DDIZDATAKDataSet.DDIZDATAKRow) enumerator.Current;
                        this.rowDDIZDATAK = current;
                        if (Helpers.IsRowChanged(this.rowDDIZDATAK))
                        {
                            this.ReadRowDdizdatak();
                            if (this.rowDDIZDATAK.RowState == DataRowState.Added)
                            {
                                this.InsertDdizdatak();
                            }
                            else
                            {
                                if (this._Gxremove)
                                {
                                    this.Delete();
                                    continue;
                                }
                                this.UpdateDdizdatak();
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

        private void UpdateDdizdatak()
        {
            this.CheckOptimisticConcurrencyDdizdatak();
            this.AfterConfirmDdizdatak();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [DDIZDATAK] SET [DDNAZIVIZDATKA]=@DDNAZIVIZDATKA, [DDPOSTOTAKIZDATKA]=@DDPOSTOTAKIZDATKA  WHERE [DDIDIZDATAK] = @DDIDIZDATAK", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDNAZIVIZDATKA", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDPOSTOTAKIZDATKA", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDIDIZDATAK", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDIZDATAK["DDNAZIVIZDATKA"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowDDIZDATAK["DDPOSTOTAKIZDATKA"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowDDIZDATAK["DDIDIZDATAK"]));
            command.ExecuteStmt();
            new ddizdatakupdateredundancy(ref this.dsDefault).execute(this.rowDDIZDATAK.DDIDIZDATAK);
            this.OnDDIZDATAKUpdated(new DDIZDATAKEventArgs(this.rowDDIZDATAK, StatementType.Update));
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
        public class DDIZDATAKDataChangedException : DataChangedException
        {
            public DDIZDATAKDataChangedException()
            {
            }

            public DDIZDATAKDataChangedException(string message) : base(message)
            {
            }

            protected DDIZDATAKDataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public DDIZDATAKDataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class DDIZDATAKDataLockedException : DataLockedException
        {
            public DDIZDATAKDataLockedException()
            {
            }

            public DDIZDATAKDataLockedException(string message) : base(message)
            {
            }

            protected DDIZDATAKDataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public DDIZDATAKDataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class DDIZDATAKDuplicateKeyException : DuplicateKeyException
        {
            public DDIZDATAKDuplicateKeyException()
            {
            }

            public DDIZDATAKDuplicateKeyException(string message) : base(message)
            {
            }

            protected DDIZDATAKDuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public DDIZDATAKDuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class DDIZDATAKEventArgs : EventArgs
        {
            private DDIZDATAKDataSet.DDIZDATAKRow m_dataRow;
            private System.Data.StatementType m_statementType;

            public DDIZDATAKEventArgs(DDIZDATAKDataSet.DDIZDATAKRow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public DDIZDATAKDataSet.DDIZDATAKRow Row
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
        public class DDIZDATAKNotFoundException : DataNotFoundException
        {
            public DDIZDATAKNotFoundException()
            {
            }

            public DDIZDATAKNotFoundException(string message) : base(message)
            {
            }

            protected DDIZDATAKNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public DDIZDATAKNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public delegate void DDIZDATAKUpdateEventHandler(object sender, DDIZDATAKDataAdapter.DDIZDATAKEventArgs e);

        [Serializable]
        public class DDKATEGORIJAIzdaciInvalidDeleteException : InvalidDeleteException
        {
            public DDKATEGORIJAIzdaciInvalidDeleteException()
            {
            }

            public DDKATEGORIJAIzdaciInvalidDeleteException(string message) : base(message)
            {
            }

            protected DDKATEGORIJAIzdaciInvalidDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public DDKATEGORIJAIzdaciInvalidDeleteException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class DDOBRACUNRadniciIzdaciInvalidDeleteException : InvalidDeleteException
        {
            public DDOBRACUNRadniciIzdaciInvalidDeleteException()
            {
            }

            public DDOBRACUNRadniciIzdaciInvalidDeleteException(string message) : base(message)
            {
            }

            protected DDOBRACUNRadniciIzdaciInvalidDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public DDOBRACUNRadniciIzdaciInvalidDeleteException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }
    }
}


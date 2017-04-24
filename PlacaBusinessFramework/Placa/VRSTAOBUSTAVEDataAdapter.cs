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

    public class VRSTAOBUSTAVEDataAdapter : IDataAdapter, IVRSTAOBUSTAVEDataAdapter
    {
        private bool _Gxremove;
        private ReadWriteCommand cmVRSTEOBUSTAVASelect1;
        private ReadWriteCommand cmVRSTEOBUSTAVASelect4;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private DbParameter[] fillDataParameters;
        private StatementType Gx_mode;
        private object m__NAZIVVRSTAOBUSTAVEOriginal;
        private readonly string m_SelectString42 = "TM1.[VRSTAOBUSTAVE], TM1.[NAZIVVRSTAOBUSTAVE]";
        private string m_WhereString;
        private short RcdFound42;
        private int recordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private VRSTAOBUSTAVEDataSet.VRSTEOBUSTAVARow rowVRSTEOBUSTAVA;
        private string scmdbuf;
        private StatementType sMode42;
        private VRSTAOBUSTAVEDataSet VRSTAOBUSTAVESet;
        private IDataReader VRSTEOBUSTAVASelect1;
        private IDataReader VRSTEOBUSTAVASelect4;

        public event VRSTEOBUSTAVAUpdateEventHandler VRSTEOBUSTAVAUpdated;

        public event VRSTEOBUSTAVAUpdateEventHandler VRSTEOBUSTAVAUpdating;

        private void AddRowVrsteobustava()
        {
            this.VRSTAOBUSTAVESet.VRSTEOBUSTAVA.AddVRSTEOBUSTAVARow(this.rowVRSTEOBUSTAVA);
        }

        private void AfterConfirmVrsteobustava()
        {
            this.OnVRSTEOBUSTAVAUpdating(new VRSTEOBUSTAVAEventArgs(this.rowVRSTEOBUSTAVA, this.Gx_mode));
        }

        private void CheckDeleteErrorsVrsteobustava()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT TOP 1 [IDOBUSTAVA] FROM [OBUSTAVA] WITH (NOLOCK) WHERE [VRSTAOBUSTAVE] = @VRSTAOBUSTAVE ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@VRSTAOBUSTAVE", DbType.Int16));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowVRSTEOBUSTAVA["VRSTAOBUSTAVE"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                reader.Close();
                throw new OBUSTAVAInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "OBUSTAVA" }));
            }
            reader.Close();
        }

        private void CheckExtendedTableVrsteobustava()
        {
            if (((this.rowVRSTEOBUSTAVA.VRSTAOBUSTAVE != 0) && (this.rowVRSTEOBUSTAVA.VRSTAOBUSTAVE != 1)) && (this.rowVRSTEOBUSTAVA.VRSTAOBUSTAVE != 2))
            {
                throw new VRSTAOBUSTAVEOutOfRangeException("Field Vrsta obustave is out of range");
            }
        }

        private void CheckOptimisticConcurrencyVrsteobustava()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [VRSTAOBUSTAVE], [NAZIVVRSTAOBUSTAVE] FROM [VRSTEOBUSTAVA] WITH (UPDLOCK) WHERE [VRSTAOBUSTAVE] = @VRSTAOBUSTAVE ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@VRSTAOBUSTAVE", DbType.Int16));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowVRSTEOBUSTAVA["VRSTAOBUSTAVE"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new VRSTEOBUSTAVADataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("VRSTEOBUSTAVA") }));
                }
                if (!command.HasMoreRows || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__NAZIVVRSTAOBUSTAVEOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1))))
                {
                    reader.Close();
                    throw new VRSTEOBUSTAVADataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("VRSTEOBUSTAVA") }));
                }
                reader.Close();
            }
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        private void CreateNewRowVrsteobustava()
        {
            this.rowVRSTEOBUSTAVA = this.VRSTAOBUSTAVESet.VRSTEOBUSTAVA.NewVRSTEOBUSTAVARow();
        }

        private void Delete()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyVrsteobustava();
            this.AfterConfirmVrsteobustava();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [VRSTEOBUSTAVA]  WHERE [VRSTAOBUSTAVE] = @VRSTAOBUSTAVE", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@VRSTAOBUSTAVE", DbType.Int16));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowVRSTEOBUSTAVA["VRSTAOBUSTAVE"]));
            command.ExecuteStmt();
            if (command.ForeignKeyError)
            {
                this.CheckDeleteErrorsVrsteobustava();
            }
            this.OnVRSTEOBUSTAVAUpdated(new VRSTEOBUSTAVAEventArgs(this.rowVRSTEOBUSTAVA, StatementType.Delete));
            this.rowVRSTEOBUSTAVA.Delete();
            this.sMode42 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode42;
        }

        public virtual int Fill(VRSTAOBUSTAVEDataSet dataSet)
        {
            if (this.fillDataParameters != null)
            {
                this.Fill(dataSet, short.Parse(this.fillDataParameters[0].Value.ToString()));
            }
            else
            {
                try
                {
                    this.InitializeMembers();
                    this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
                    this.VRSTAOBUSTAVESet = dataSet;
                    this.LoadChildVrsteobustava(0, -1);
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
            this.VRSTAOBUSTAVESet = (VRSTAOBUSTAVEDataSet) dataSet;
            if (this.VRSTAOBUSTAVESet != null)
            {
                return this.Fill(this.VRSTAOBUSTAVESet);
            }
            this.VRSTAOBUSTAVESet = new VRSTAOBUSTAVEDataSet();
            this.Fill(this.VRSTAOBUSTAVESet);
            dataSet.Merge(this.VRSTAOBUSTAVESet);
            return 0;
        }

        public virtual int Fill(VRSTAOBUSTAVEDataSet dataSet, DataRow dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToShort(dataRecord["VRSTAOBUSTAVE"]));
        }

        public virtual int Fill(VRSTAOBUSTAVEDataSet dataSet, IDataRecord dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToShort(dataRecord["VRSTAOBUSTAVE"]));
        }

        public virtual int Fill(VRSTAOBUSTAVEDataSet dataSet, short vRSTAOBUSTAVE)
        {
            if (!this.FillByVRSTAOBUSTAVE(dataSet, vRSTAOBUSTAVE))
            {
                throw new VRSTEOBUSTAVANotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("VRSTEOBUSTAVA") }));
            }
            return 0;
        }

        public virtual bool FillByVRSTAOBUSTAVE(VRSTAOBUSTAVEDataSet dataSet, short vRSTAOBUSTAVE)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.VRSTAOBUSTAVESet = dataSet;
            this.rowVRSTEOBUSTAVA = this.VRSTAOBUSTAVESet.VRSTEOBUSTAVA.NewVRSTEOBUSTAVARow();
            this.rowVRSTEOBUSTAVA.VRSTAOBUSTAVE = vRSTAOBUSTAVE;
            try
            {
                this.LoadByVRSTAOBUSTAVE(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            if (this.RcdFound42 == 0)
            {
                return false;
            }
            return true;
        }

        public virtual int FillPage(VRSTAOBUSTAVEDataSet dataSet, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.VRSTAOBUSTAVESet = dataSet;
            try
            {
                this.LoadChildVrsteobustava(startRow, maxRows);
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
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [VRSTAOBUSTAVE], [NAZIVVRSTAOBUSTAVE] FROM [VRSTEOBUSTAVA] WITH (NOLOCK) WHERE [VRSTAOBUSTAVE] = @VRSTAOBUSTAVE ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@VRSTAOBUSTAVE", DbType.Int16));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowVRSTEOBUSTAVA["VRSTAOBUSTAVE"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.RcdFound42 = 1;
                this.rowVRSTEOBUSTAVA["VRSTAOBUSTAVE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt16(reader, 0));
                this.rowVRSTEOBUSTAVA["NAZIVVRSTAOBUSTAVE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1));
                this.sMode42 = this.Gx_mode;
                this.Gx_mode = StatementType.Select;
                this.Gx_mode = this.sMode42;
            }
            else
            {
                this.RcdFound42 = 0;
            }
            reader.Close();
        }

        public virtual IDataParameter[] GetFillParameters()
        {
            if (this.fillDataParameters == null)
            {
                DbParameter parameter = DbProviderFactories.GetFactory("System.Data.SqlClient").CreateParameter();
                parameter.ParameterName = "VRSTAOBUSTAVE";
                parameter.DbType = DbType.Int16;
                this.fillDataParameters = new DbParameter[] { parameter };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount()
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmVRSTEOBUSTAVASelect1 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [VRSTEOBUSTAVA] WITH (NOLOCK) ", false);
            this.VRSTEOBUSTAVASelect1 = this.cmVRSTEOBUSTAVASelect1.FetchData();
            if (this.VRSTEOBUSTAVASelect1.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.VRSTEOBUSTAVASelect1.GetInt32(0);
            }
            this.VRSTEOBUSTAVASelect1.Close();
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
            this.RcdFound42 = 0;
            this.scmdbuf = "";
            this.recordCount = 0;
            this._Gxremove = false;
            this.m__NAZIVVRSTAOBUSTAVEOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m_WhereString = "";
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void InitializeMembers()
        {
            this.VRSTAOBUSTAVESet = new VRSTAOBUSTAVEDataSet();
            this.Initialize();
            this.dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        }

        private void InsertVrsteobustava()
        {
            this.CheckOptimisticConcurrencyVrsteobustava();
            this.CheckExtendedTableVrsteobustava();
            this.AfterConfirmVrsteobustava();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [VRSTEOBUSTAVA] ([VRSTAOBUSTAVE], [NAZIVVRSTAOBUSTAVE]) VALUES (@VRSTAOBUSTAVE, @NAZIVVRSTAOBUSTAVE)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@VRSTAOBUSTAVE", DbType.Int16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVVRSTAOBUSTAVE", DbType.String, 50));
            }
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowVRSTEOBUSTAVA["VRSTAOBUSTAVE"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowVRSTEOBUSTAVA["NAZIVVRSTAOBUSTAVE"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new VRSTEOBUSTAVADuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            this.OnVRSTEOBUSTAVAUpdated(new VRSTEOBUSTAVAEventArgs(this.rowVRSTEOBUSTAVA, StatementType.Insert));
        }

        private void LoadByVRSTAOBUSTAVE(int startRow, int maxRows)
        {
            bool enforceConstraints = this.VRSTAOBUSTAVESet.EnforceConstraints;
            this.VRSTAOBUSTAVESet.VRSTEOBUSTAVA.BeginLoadData();
            this.ScanByVRSTAOBUSTAVE(startRow, maxRows);
            this.VRSTAOBUSTAVESet.VRSTEOBUSTAVA.EndLoadData();
            this.VRSTAOBUSTAVESet.EnforceConstraints = enforceConstraints;
            if (this.VRSTAOBUSTAVESet.VRSTEOBUSTAVA.Count > 0)
            {
                this.rowVRSTEOBUSTAVA = this.VRSTAOBUSTAVESet.VRSTEOBUSTAVA[this.VRSTAOBUSTAVESet.VRSTEOBUSTAVA.Count - 1];
            }
        }

        private void LoadChildVrsteobustava(int startRow, int maxRows)
        {
            this.CreateNewRowVrsteobustava();
            bool enforceConstraints = this.VRSTAOBUSTAVESet.EnforceConstraints;
            this.VRSTAOBUSTAVESet.VRSTEOBUSTAVA.BeginLoadData();
            this.ScanStartVrsteobustava(startRow, maxRows);
            this.VRSTAOBUSTAVESet.VRSTEOBUSTAVA.EndLoadData();
            this.VRSTAOBUSTAVESet.EnforceConstraints = enforceConstraints;
        }

        private void LoadDataVrsteobustava(int maxRows)
        {
            int num = 0;
            if (this.RcdFound42 != 0)
            {
                this.ScanLoadVrsteobustava();
                while ((this.RcdFound42 != 0) && (num != maxRows))
                {
                    num++;
                    this.LoadRowVrsteobustava();
                    this.CreateNewRowVrsteobustava();
                    this.ScanNextVrsteobustava();
                }
            }
            if (num > 0)
            {
                this.RcdFound42 = 1;
            }
            this.ScanEndVrsteobustava();
            if (this.VRSTAOBUSTAVESet.VRSTEOBUSTAVA.Count > 0)
            {
                this.rowVRSTEOBUSTAVA = this.VRSTAOBUSTAVESet.VRSTEOBUSTAVA[this.VRSTAOBUSTAVESet.VRSTEOBUSTAVA.Count - 1];
            }
        }

        private void LoadRowVrsteobustava()
        {
            this.AddRowVrsteobustava();
        }

        private void OnVRSTEOBUSTAVAUpdated(VRSTEOBUSTAVAEventArgs e)
        {
            if (this.VRSTEOBUSTAVAUpdated != null)
            {
                VRSTEOBUSTAVAUpdateEventHandler vRSTEOBUSTAVAUpdatedEvent = this.VRSTEOBUSTAVAUpdated;
                if (vRSTEOBUSTAVAUpdatedEvent != null)
                {
                    vRSTEOBUSTAVAUpdatedEvent(this, e);
                }
            }
        }

        private void OnVRSTEOBUSTAVAUpdating(VRSTEOBUSTAVAEventArgs e)
        {
            if (this.VRSTEOBUSTAVAUpdating != null)
            {
                VRSTEOBUSTAVAUpdateEventHandler vRSTEOBUSTAVAUpdatingEvent = this.VRSTEOBUSTAVAUpdating;
                if (vRSTEOBUSTAVAUpdatingEvent != null)
                {
                    vRSTEOBUSTAVAUpdatingEvent(this, e);
                }
            }
        }

        private void ReadRowVrsteobustava()
        {
            this.Gx_mode = Mode.FromRowState(this.rowVRSTEOBUSTAVA.RowState);
            if (this.rowVRSTEOBUSTAVA.RowState != DataRowState.Added)
            {
                this.m__NAZIVVRSTAOBUSTAVEOriginal = RuntimeHelpers.GetObjectValue(this.rowVRSTEOBUSTAVA["NAZIVVRSTAOBUSTAVE", DataRowVersion.Original]);
            }
            else
            {
                this.m__NAZIVVRSTAOBUSTAVEOriginal = RuntimeHelpers.GetObjectValue(this.rowVRSTEOBUSTAVA["NAZIVVRSTAOBUSTAVE"]);
            }
            this._Gxremove = this.rowVRSTEOBUSTAVA.RowState == DataRowState.Deleted;
            if (this._Gxremove)
            {
                this.rowVRSTEOBUSTAVA = (VRSTAOBUSTAVEDataSet.VRSTEOBUSTAVARow) DataSetUtil.CloneOriginalDataRow(this.rowVRSTEOBUSTAVA);
            }
        }

        private void ScanByVRSTAOBUSTAVE(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[VRSTAOBUSTAVE] = @VRSTAOBUSTAVE";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString42 + "  FROM [VRSTEOBUSTAVA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[VRSTAOBUSTAVE]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString42, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[VRSTAOBUSTAVE] ) AS DK_PAGENUM   FROM [VRSTEOBUSTAVA] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString42 + " FROM [VRSTEOBUSTAVA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[VRSTAOBUSTAVE] ";
            }
            this.cmVRSTEOBUSTAVASelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmVRSTEOBUSTAVASelect4.IDbCommand.Parameters.Count == 0)
            {
                this.cmVRSTEOBUSTAVASelect4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@VRSTAOBUSTAVE", DbType.Int16));
            }
            this.cmVRSTEOBUSTAVASelect4.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowVRSTEOBUSTAVA["VRSTAOBUSTAVE"]));
            this.VRSTEOBUSTAVASelect4 = this.cmVRSTEOBUSTAVASelect4.FetchData();
            this.RcdFound42 = 0;
            this.ScanLoadVrsteobustava();
            this.LoadDataVrsteobustava(maxRows);
        }

        private void ScanEndVrsteobustava()
        {
            this.VRSTEOBUSTAVASelect4.Close();
        }

        private void ScanLoadVrsteobustava()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmVRSTEOBUSTAVASelect4.HasMoreRows)
            {
                this.RcdFound42 = 1;
                this.rowVRSTEOBUSTAVA["VRSTAOBUSTAVE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt16(this.VRSTEOBUSTAVASelect4, 0));
                this.rowVRSTEOBUSTAVA["NAZIVVRSTAOBUSTAVE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.VRSTEOBUSTAVASelect4, 1));
            }
        }

        private void ScanNextVrsteobustava()
        {
            this.cmVRSTEOBUSTAVASelect4.HasMoreRows = this.VRSTEOBUSTAVASelect4.Read();
            this.RcdFound42 = 0;
            this.ScanLoadVrsteobustava();
        }

        private void ScanStartVrsteobustava(int startRow, int maxRows)
        {
            this.m_WhereString = "";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString42 + "  FROM [VRSTEOBUSTAVA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[VRSTAOBUSTAVE]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString42, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[VRSTAOBUSTAVE] ) AS DK_PAGENUM   FROM [VRSTEOBUSTAVA] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString42 + " FROM [VRSTEOBUSTAVA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[VRSTAOBUSTAVE] ";
            }
            this.cmVRSTEOBUSTAVASelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            this.VRSTEOBUSTAVASelect4 = this.cmVRSTEOBUSTAVASelect4.FetchData();
            this.RcdFound42 = 0;
            this.ScanLoadVrsteobustava();
            this.LoadDataVrsteobustava(maxRows);
        }

        public virtual int Update(DataSet dataSet)
        {
            this.InitializeMembers();
            this.VRSTAOBUSTAVESet = (VRSTAOBUSTAVEDataSet) dataSet;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            if (this.VRSTAOBUSTAVESet == null)
            {
                throw new ArgumentException(this.resourceManager.GetString("nulldset"));
            }
            try
            {
                IEnumerator enumerator = null;
                this.connDefault.BeginTransaction();
                try
                {
                    enumerator = this.VRSTAOBUSTAVESet.VRSTEOBUSTAVA.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        VRSTAOBUSTAVEDataSet.VRSTEOBUSTAVARow current = (VRSTAOBUSTAVEDataSet.VRSTEOBUSTAVARow) enumerator.Current;
                        this.rowVRSTEOBUSTAVA = current;
                        if (Helpers.IsRowChanged(this.rowVRSTEOBUSTAVA))
                        {
                            this.ReadRowVrsteobustava();
                            if (this.rowVRSTEOBUSTAVA.RowState == DataRowState.Added)
                            {
                                this.InsertVrsteobustava();
                            }
                            else
                            {
                                if (this._Gxremove)
                                {
                                    this.Delete();
                                    continue;
                                }
                                this.UpdateVrsteobustava();
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

        private void UpdateVrsteobustava()
        {
            this.CheckOptimisticConcurrencyVrsteobustava();
            this.CheckExtendedTableVrsteobustava();
            this.AfterConfirmVrsteobustava();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [VRSTEOBUSTAVA] SET [NAZIVVRSTAOBUSTAVE]=@NAZIVVRSTAOBUSTAVE  WHERE [VRSTAOBUSTAVE] = @VRSTAOBUSTAVE", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVVRSTAOBUSTAVE", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@VRSTAOBUSTAVE", DbType.Int16));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowVRSTEOBUSTAVA["NAZIVVRSTAOBUSTAVE"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowVRSTEOBUSTAVA["VRSTAOBUSTAVE"]));
            command.ExecuteStmt();
            new vrsteobustavaupdateredundancy(ref this.dsDefault).execute(this.rowVRSTEOBUSTAVA.VRSTAOBUSTAVE);
            this.OnVRSTEOBUSTAVAUpdated(new VRSTEOBUSTAVAEventArgs(this.rowVRSTEOBUSTAVA, StatementType.Update));
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
        public class OBUSTAVAInvalidDeleteException : InvalidDeleteException
        {
            public OBUSTAVAInvalidDeleteException()
            {
            }

            public OBUSTAVAInvalidDeleteException(string message) : base(message)
            {
            }

            protected OBUSTAVAInvalidDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public OBUSTAVAInvalidDeleteException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class VRSTAOBUSTAVEOutOfRangeException : UserException
        {
            public VRSTAOBUSTAVEOutOfRangeException()
            {
            }

            public VRSTAOBUSTAVEOutOfRangeException(string message) : base(message)
            {
            }

            protected VRSTAOBUSTAVEOutOfRangeException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public VRSTAOBUSTAVEOutOfRangeException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class VRSTEOBUSTAVADataChangedException : DataChangedException
        {
            public VRSTEOBUSTAVADataChangedException()
            {
            }

            public VRSTEOBUSTAVADataChangedException(string message) : base(message)
            {
            }

            protected VRSTEOBUSTAVADataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public VRSTEOBUSTAVADataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class VRSTEOBUSTAVADataLockedException : DataLockedException
        {
            public VRSTEOBUSTAVADataLockedException()
            {
            }

            public VRSTEOBUSTAVADataLockedException(string message) : base(message)
            {
            }

            protected VRSTEOBUSTAVADataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public VRSTEOBUSTAVADataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class VRSTEOBUSTAVADuplicateKeyException : DuplicateKeyException
        {
            public VRSTEOBUSTAVADuplicateKeyException()
            {
            }

            public VRSTEOBUSTAVADuplicateKeyException(string message) : base(message)
            {
            }

            protected VRSTEOBUSTAVADuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public VRSTEOBUSTAVADuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class VRSTEOBUSTAVAEventArgs : EventArgs
        {
            private VRSTAOBUSTAVEDataSet.VRSTEOBUSTAVARow m_dataRow;
            private System.Data.StatementType m_statementType;

            public VRSTEOBUSTAVAEventArgs(VRSTAOBUSTAVEDataSet.VRSTEOBUSTAVARow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public VRSTAOBUSTAVEDataSet.VRSTEOBUSTAVARow Row
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
        public class VRSTEOBUSTAVANotFoundException : DataNotFoundException
        {
            public VRSTEOBUSTAVANotFoundException()
            {
            }

            public VRSTEOBUSTAVANotFoundException(string message) : base(message)
            {
            }

            protected VRSTEOBUSTAVANotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public VRSTEOBUSTAVANotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public delegate void VRSTEOBUSTAVAUpdateEventHandler(object sender, VRSTAOBUSTAVEDataAdapter.VRSTEOBUSTAVAEventArgs e);
    }
}


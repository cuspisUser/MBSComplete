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

    public class VRSTADOPRINOSDataAdapter : IDataAdapter, IVRSTADOPRINOSDataAdapter
    {
        private bool _Gxremove;
        private ReadWriteCommand cmVRSTADOPRINOSSelect1;
        private ReadWriteCommand cmVRSTADOPRINOSSelect4;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private DbParameter[] fillDataParameters;
        private StatementType Gx_mode;
        private object m__NAZIVVRSTADOPRINOSOriginal;
        private readonly string m_SelectString41 = "TM1.[IDVRSTADOPRINOS], TM1.[NAZIVVRSTADOPRINOS]";
        private string m_WhereString;
        private short RcdFound41;
        private int recordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private VRSTADOPRINOSDataSet.VRSTADOPRINOSRow rowVRSTADOPRINOS;
        private string scmdbuf;
        private StatementType sMode41;
        private IDataReader VRSTADOPRINOSSelect1;
        private IDataReader VRSTADOPRINOSSelect4;
        private VRSTADOPRINOSDataSet VRSTADOPRINOSSet;

        public event VRSTADOPRINOSUpdateEventHandler VRSTADOPRINOSUpdated;

        public event VRSTADOPRINOSUpdateEventHandler VRSTADOPRINOSUpdating;

        private void AddRowVrstadoprinos()
        {
            this.VRSTADOPRINOSSet.VRSTADOPRINOS.AddVRSTADOPRINOSRow(this.rowVRSTADOPRINOS);
        }

        private void AfterConfirmVrstadoprinos()
        {
            this.OnVRSTADOPRINOSUpdating(new VRSTADOPRINOSEventArgs(this.rowVRSTADOPRINOS, this.Gx_mode));
        }

        private void CheckDeleteErrorsVrstadoprinos()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT TOP 1 [IDDOPRINOS] FROM [DOPRINOS] WITH (NOLOCK) WHERE [IDVRSTADOPRINOS] = @IDVRSTADOPRINOS ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDVRSTADOPRINOS", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowVRSTADOPRINOS["IDVRSTADOPRINOS"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                reader.Close();
                throw new DOPRINOSInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "DOPRINOS" }));
            }
            reader.Close();
        }

        private void CheckOptimisticConcurrencyVrstadoprinos()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDVRSTADOPRINOS], [NAZIVVRSTADOPRINOS] FROM [VRSTADOPRINOS] WITH (UPDLOCK) WHERE [IDVRSTADOPRINOS] = @IDVRSTADOPRINOS ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDVRSTADOPRINOS", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowVRSTADOPRINOS["IDVRSTADOPRINOS"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new VRSTADOPRINOSDataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("VRSTADOPRINOS") }));
                }
                if (!command.HasMoreRows || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__NAZIVVRSTADOPRINOSOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1))))
                {
                    reader.Close();
                    throw new VRSTADOPRINOSDataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("VRSTADOPRINOS") }));
                }
                reader.Close();
            }
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        private void CreateNewRowVrstadoprinos()
        {
            this.rowVRSTADOPRINOS = this.VRSTADOPRINOSSet.VRSTADOPRINOS.NewVRSTADOPRINOSRow();
        }

        private void Delete()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyVrstadoprinos();
            this.AfterConfirmVrstadoprinos();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [VRSTADOPRINOS]  WHERE [IDVRSTADOPRINOS] = @IDVRSTADOPRINOS", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDVRSTADOPRINOS", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowVRSTADOPRINOS["IDVRSTADOPRINOS"]));
            command.ExecuteStmt();
            if (command.ForeignKeyError)
            {
                this.CheckDeleteErrorsVrstadoprinos();
            }
            this.OnVRSTADOPRINOSUpdated(new VRSTADOPRINOSEventArgs(this.rowVRSTADOPRINOS, StatementType.Delete));
            this.rowVRSTADOPRINOS.Delete();
            this.sMode41 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode41;
        }

        public virtual int Fill(VRSTADOPRINOSDataSet dataSet)
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
                    this.VRSTADOPRINOSSet = dataSet;
                    this.LoadChildVrstadoprinos(0, -1);
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
            this.VRSTADOPRINOSSet = (VRSTADOPRINOSDataSet) dataSet;
            if (this.VRSTADOPRINOSSet != null)
            {
                return this.Fill(this.VRSTADOPRINOSSet);
            }
            this.VRSTADOPRINOSSet = new VRSTADOPRINOSDataSet();
            this.Fill(this.VRSTADOPRINOSSet);
            dataSet.Merge(this.VRSTADOPRINOSSet);
            return 0;
        }

        public virtual int Fill(VRSTADOPRINOSDataSet dataSet, DataRow dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDVRSTADOPRINOS"]));
        }

        public virtual int Fill(VRSTADOPRINOSDataSet dataSet, IDataRecord dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDVRSTADOPRINOS"]));
        }

        public virtual int Fill(VRSTADOPRINOSDataSet dataSet, int iDVRSTADOPRINOS)
        {
            if (!this.FillByIDVRSTADOPRINOS(dataSet, iDVRSTADOPRINOS))
            {
                throw new VRSTADOPRINOSNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("VRSTADOPRINOS") }));
            }
            return 0;
        }

        public virtual bool FillByIDVRSTADOPRINOS(VRSTADOPRINOSDataSet dataSet, int iDVRSTADOPRINOS)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.VRSTADOPRINOSSet = dataSet;
            this.rowVRSTADOPRINOS = this.VRSTADOPRINOSSet.VRSTADOPRINOS.NewVRSTADOPRINOSRow();
            this.rowVRSTADOPRINOS.IDVRSTADOPRINOS = iDVRSTADOPRINOS;
            try
            {
                this.LoadByIDVRSTADOPRINOS(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            if (this.RcdFound41 == 0)
            {
                return false;
            }
            return true;
        }

        public virtual int FillPage(VRSTADOPRINOSDataSet dataSet, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.VRSTADOPRINOSSet = dataSet;
            try
            {
                this.LoadChildVrstadoprinos(startRow, maxRows);
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
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDVRSTADOPRINOS], [NAZIVVRSTADOPRINOS] FROM [VRSTADOPRINOS] WITH (NOLOCK) WHERE [IDVRSTADOPRINOS] = @IDVRSTADOPRINOS ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDVRSTADOPRINOS", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowVRSTADOPRINOS["IDVRSTADOPRINOS"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.RcdFound41 = 1;
                this.rowVRSTADOPRINOS["IDVRSTADOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 0));
                this.rowVRSTADOPRINOS["NAZIVVRSTADOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1));
                this.sMode41 = this.Gx_mode;
                this.Gx_mode = StatementType.Select;
                this.Gx_mode = this.sMode41;
            }
            else
            {
                this.RcdFound41 = 0;
            }
            reader.Close();
        }

        public virtual IDataParameter[] GetFillParameters()
        {
            if (this.fillDataParameters == null)
            {
                DbParameter parameter = DbProviderFactories.GetFactory("System.Data.SqlClient").CreateParameter();
                parameter.ParameterName = "IDVRSTADOPRINOS";
                parameter.DbType = DbType.Int32;
                this.fillDataParameters = new DbParameter[] { parameter };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount()
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmVRSTADOPRINOSSelect1 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [VRSTADOPRINOS] WITH (NOLOCK) ", false);
            this.VRSTADOPRINOSSelect1 = this.cmVRSTADOPRINOSSelect1.FetchData();
            if (this.VRSTADOPRINOSSelect1.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.VRSTADOPRINOSSelect1.GetInt32(0);
            }
            this.VRSTADOPRINOSSelect1.Close();
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
            this.RcdFound41 = 0;
            this.scmdbuf = "";
            this.recordCount = 0;
            this._Gxremove = false;
            this.m__NAZIVVRSTADOPRINOSOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m_WhereString = "";
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void InitializeMembers()
        {
            this.VRSTADOPRINOSSet = new VRSTADOPRINOSDataSet();
            this.Initialize();
            this.dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        }

        private void InsertVrstadoprinos()
        {
            this.CheckOptimisticConcurrencyVrstadoprinos();
            this.AfterConfirmVrstadoprinos();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [VRSTADOPRINOS] ([IDVRSTADOPRINOS], [NAZIVVRSTADOPRINOS]) VALUES (@IDVRSTADOPRINOS, @NAZIVVRSTADOPRINOS)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDVRSTADOPRINOS", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVVRSTADOPRINOS", DbType.String, 50));
            }
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowVRSTADOPRINOS["IDVRSTADOPRINOS"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowVRSTADOPRINOS["NAZIVVRSTADOPRINOS"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new VRSTADOPRINOSDuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            this.OnVRSTADOPRINOSUpdated(new VRSTADOPRINOSEventArgs(this.rowVRSTADOPRINOS, StatementType.Insert));
        }

        private void LoadByIDVRSTADOPRINOS(int startRow, int maxRows)
        {
            bool enforceConstraints = this.VRSTADOPRINOSSet.EnforceConstraints;
            this.VRSTADOPRINOSSet.VRSTADOPRINOS.BeginLoadData();
            this.ScanByIDVRSTADOPRINOS(startRow, maxRows);
            this.VRSTADOPRINOSSet.VRSTADOPRINOS.EndLoadData();
            this.VRSTADOPRINOSSet.EnforceConstraints = enforceConstraints;
            if (this.VRSTADOPRINOSSet.VRSTADOPRINOS.Count > 0)
            {
                this.rowVRSTADOPRINOS = this.VRSTADOPRINOSSet.VRSTADOPRINOS[this.VRSTADOPRINOSSet.VRSTADOPRINOS.Count - 1];
            }
        }

        private void LoadChildVrstadoprinos(int startRow, int maxRows)
        {
            this.CreateNewRowVrstadoprinos();
            bool enforceConstraints = this.VRSTADOPRINOSSet.EnforceConstraints;
            this.VRSTADOPRINOSSet.VRSTADOPRINOS.BeginLoadData();
            this.ScanStartVrstadoprinos(startRow, maxRows);
            this.VRSTADOPRINOSSet.VRSTADOPRINOS.EndLoadData();
            this.VRSTADOPRINOSSet.EnforceConstraints = enforceConstraints;
        }

        private void LoadDataVrstadoprinos(int maxRows)
        {
            int num = 0;
            if (this.RcdFound41 != 0)
            {
                this.ScanLoadVrstadoprinos();
                while ((this.RcdFound41 != 0) && (num != maxRows))
                {
                    num++;
                    this.LoadRowVrstadoprinos();
                    this.CreateNewRowVrstadoprinos();
                    this.ScanNextVrstadoprinos();
                }
            }
            if (num > 0)
            {
                this.RcdFound41 = 1;
            }
            this.ScanEndVrstadoprinos();
            if (this.VRSTADOPRINOSSet.VRSTADOPRINOS.Count > 0)
            {
                this.rowVRSTADOPRINOS = this.VRSTADOPRINOSSet.VRSTADOPRINOS[this.VRSTADOPRINOSSet.VRSTADOPRINOS.Count - 1];
            }
        }

        private void LoadRowVrstadoprinos()
        {
            this.AddRowVrstadoprinos();
        }

        private void OnVRSTADOPRINOSUpdated(VRSTADOPRINOSEventArgs e)
        {
            if (this.VRSTADOPRINOSUpdated != null)
            {
                VRSTADOPRINOSUpdateEventHandler vRSTADOPRINOSUpdatedEvent = this.VRSTADOPRINOSUpdated;
                if (vRSTADOPRINOSUpdatedEvent != null)
                {
                    vRSTADOPRINOSUpdatedEvent(this, e);
                }
            }
        }

        private void OnVRSTADOPRINOSUpdating(VRSTADOPRINOSEventArgs e)
        {
            if (this.VRSTADOPRINOSUpdating != null)
            {
                VRSTADOPRINOSUpdateEventHandler vRSTADOPRINOSUpdatingEvent = this.VRSTADOPRINOSUpdating;
                if (vRSTADOPRINOSUpdatingEvent != null)
                {
                    vRSTADOPRINOSUpdatingEvent(this, e);
                }
            }
        }

        private void ReadRowVrstadoprinos()
        {
            this.Gx_mode = Mode.FromRowState(this.rowVRSTADOPRINOS.RowState);
            if (this.rowVRSTADOPRINOS.RowState != DataRowState.Added)
            {
                this.m__NAZIVVRSTADOPRINOSOriginal = RuntimeHelpers.GetObjectValue(this.rowVRSTADOPRINOS["NAZIVVRSTADOPRINOS", DataRowVersion.Original]);
            }
            else
            {
                this.m__NAZIVVRSTADOPRINOSOriginal = RuntimeHelpers.GetObjectValue(this.rowVRSTADOPRINOS["NAZIVVRSTADOPRINOS"]);
            }
            this._Gxremove = this.rowVRSTADOPRINOS.RowState == DataRowState.Deleted;
            if (this._Gxremove)
            {
                this.rowVRSTADOPRINOS = (VRSTADOPRINOSDataSet.VRSTADOPRINOSRow) DataSetUtil.CloneOriginalDataRow(this.rowVRSTADOPRINOS);
            }
        }

        private void ScanByIDVRSTADOPRINOS(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[IDVRSTADOPRINOS] = @IDVRSTADOPRINOS";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString41 + "  FROM [VRSTADOPRINOS] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDVRSTADOPRINOS]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString41, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDVRSTADOPRINOS] ) AS DK_PAGENUM   FROM [VRSTADOPRINOS] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString41 + " FROM [VRSTADOPRINOS] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDVRSTADOPRINOS] ";
            }
            this.cmVRSTADOPRINOSSelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmVRSTADOPRINOSSelect4.IDbCommand.Parameters.Count == 0)
            {
                this.cmVRSTADOPRINOSSelect4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDVRSTADOPRINOS", DbType.Int32));
            }
            this.cmVRSTADOPRINOSSelect4.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowVRSTADOPRINOS["IDVRSTADOPRINOS"]));
            this.VRSTADOPRINOSSelect4 = this.cmVRSTADOPRINOSSelect4.FetchData();
            this.RcdFound41 = 0;
            this.ScanLoadVrstadoprinos();
            this.LoadDataVrstadoprinos(maxRows);
        }

        private void ScanEndVrstadoprinos()
        {
            this.VRSTADOPRINOSSelect4.Close();
        }

        private void ScanLoadVrstadoprinos()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmVRSTADOPRINOSSelect4.HasMoreRows)
            {
                this.RcdFound41 = 1;
                this.rowVRSTADOPRINOS["IDVRSTADOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.VRSTADOPRINOSSelect4, 0));
                this.rowVRSTADOPRINOS["NAZIVVRSTADOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.VRSTADOPRINOSSelect4, 1));
            }
        }

        private void ScanNextVrstadoprinos()
        {
            this.cmVRSTADOPRINOSSelect4.HasMoreRows = this.VRSTADOPRINOSSelect4.Read();
            this.RcdFound41 = 0;
            this.ScanLoadVrstadoprinos();
        }

        private void ScanStartVrstadoprinos(int startRow, int maxRows)
        {
            this.m_WhereString = "";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString41 + "  FROM [VRSTADOPRINOS] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDVRSTADOPRINOS]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString41, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDVRSTADOPRINOS] ) AS DK_PAGENUM   FROM [VRSTADOPRINOS] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString41 + " FROM [VRSTADOPRINOS] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDVRSTADOPRINOS] ";
            }
            this.cmVRSTADOPRINOSSelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            this.VRSTADOPRINOSSelect4 = this.cmVRSTADOPRINOSSelect4.FetchData();
            this.RcdFound41 = 0;
            this.ScanLoadVrstadoprinos();
            this.LoadDataVrstadoprinos(maxRows);
        }

        public virtual int Update(DataSet dataSet)
        {
            this.InitializeMembers();
            this.VRSTADOPRINOSSet = (VRSTADOPRINOSDataSet) dataSet;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            if (this.VRSTADOPRINOSSet == null)
            {
                throw new ArgumentException(this.resourceManager.GetString("nulldset"));
            }
            try
            {
                IEnumerator enumerator = null;
                this.connDefault.BeginTransaction();
                try
                {
                    enumerator = this.VRSTADOPRINOSSet.VRSTADOPRINOS.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        VRSTADOPRINOSDataSet.VRSTADOPRINOSRow current = (VRSTADOPRINOSDataSet.VRSTADOPRINOSRow) enumerator.Current;
                        this.rowVRSTADOPRINOS = current;
                        if (Helpers.IsRowChanged(this.rowVRSTADOPRINOS))
                        {
                            this.ReadRowVrstadoprinos();
                            if (this.rowVRSTADOPRINOS.RowState == DataRowState.Added)
                            {
                                this.InsertVrstadoprinos();
                            }
                            else
                            {
                                if (this._Gxremove)
                                {
                                    this.Delete();
                                    continue;
                                }
                                this.UpdateVrstadoprinos();
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

        private void UpdateVrstadoprinos()
        {
            this.CheckOptimisticConcurrencyVrstadoprinos();
            this.AfterConfirmVrstadoprinos();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [VRSTADOPRINOS] SET [NAZIVVRSTADOPRINOS]=@NAZIVVRSTADOPRINOS  WHERE [IDVRSTADOPRINOS] = @IDVRSTADOPRINOS", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVVRSTADOPRINOS", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDVRSTADOPRINOS", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowVRSTADOPRINOS["NAZIVVRSTADOPRINOS"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowVRSTADOPRINOS["IDVRSTADOPRINOS"]));
            command.ExecuteStmt();
            new vrstadoprinosupdateredundancy(ref this.dsDefault).execute(this.rowVRSTADOPRINOS.IDVRSTADOPRINOS);
            this.OnVRSTADOPRINOSUpdated(new VRSTADOPRINOSEventArgs(this.rowVRSTADOPRINOS, StatementType.Update));
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
        public class DOPRINOSInvalidDeleteException : InvalidDeleteException
        {
            public DOPRINOSInvalidDeleteException()
            {
            }

            public DOPRINOSInvalidDeleteException(string message) : base(message)
            {
            }

            protected DOPRINOSInvalidDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public DOPRINOSInvalidDeleteException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class VRSTADOPRINOSDataChangedException : DataChangedException
        {
            public VRSTADOPRINOSDataChangedException()
            {
            }

            public VRSTADOPRINOSDataChangedException(string message) : base(message)
            {
            }

            protected VRSTADOPRINOSDataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public VRSTADOPRINOSDataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class VRSTADOPRINOSDataLockedException : DataLockedException
        {
            public VRSTADOPRINOSDataLockedException()
            {
            }

            public VRSTADOPRINOSDataLockedException(string message) : base(message)
            {
            }

            protected VRSTADOPRINOSDataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public VRSTADOPRINOSDataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class VRSTADOPRINOSDuplicateKeyException : DuplicateKeyException
        {
            public VRSTADOPRINOSDuplicateKeyException()
            {
            }

            public VRSTADOPRINOSDuplicateKeyException(string message) : base(message)
            {
            }

            protected VRSTADOPRINOSDuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public VRSTADOPRINOSDuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class VRSTADOPRINOSEventArgs : EventArgs
        {
            private VRSTADOPRINOSDataSet.VRSTADOPRINOSRow m_dataRow;
            private System.Data.StatementType m_statementType;

            public VRSTADOPRINOSEventArgs(VRSTADOPRINOSDataSet.VRSTADOPRINOSRow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public VRSTADOPRINOSDataSet.VRSTADOPRINOSRow Row
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
        public class VRSTADOPRINOSNotFoundException : DataNotFoundException
        {
            public VRSTADOPRINOSNotFoundException()
            {
            }

            public VRSTADOPRINOSNotFoundException(string message) : base(message)
            {
            }

            protected VRSTADOPRINOSNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public VRSTADOPRINOSNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public delegate void VRSTADOPRINOSUpdateEventHandler(object sender, VRSTADOPRINOSDataAdapter.VRSTADOPRINOSEventArgs e);
    }
}


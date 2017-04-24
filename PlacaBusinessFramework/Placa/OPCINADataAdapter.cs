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

    public class OPCINADataAdapter : IDataAdapter, IOPCINADataAdapter
    {
        private bool _Gxremove;
        private ReadWriteCommand cmOPCINASelect1;
        private ReadWriteCommand cmOPCINASelect4;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private DbParameter[] fillDataParameters;
        private StatementType Gx_mode;
        private object m__NAZIVOPCINEOriginal;
        private object m__PRIREZOriginal;
        private object m__VBDIOPCINAOriginal;
        private object m__ZRNOPCINAOriginal;
        private readonly string m_SelectString16 = "TM1.[IDOPCINE], TM1.[NAZIVOPCINE], TM1.[PRIREZ], TM1.[VBDIOPCINA], TM1.[ZRNOPCINA]";
        private string m_WhereString;
        private IDataReader OPCINASelect1;
        private IDataReader OPCINASelect4;
        private OPCINADataSet OPCINASet;
        private short RcdFound16;
        private int recordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private OPCINADataSet.OPCINARow rowOPCINA;
        private string scmdbuf;
        private StatementType sMode16;

        public event OPCINAUpdateEventHandler OPCINAUpdated;

        public event OPCINAUpdateEventHandler OPCINAUpdating;

        private void AddRowOpcina()
        {
            this.OPCINASet.OPCINA.AddOPCINARow(this.rowOPCINA);
        }

        private void AfterConfirmOpcina()
        {
            this.OnOPCINAUpdating(new OPCINAEventArgs(this.rowOPCINA, this.Gx_mode));
        }

        private void CheckDeleteErrorsOpcina()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT TOP 1 [DDIDRADNIK] FROM [DDRADNIK] WITH (NOLOCK) WHERE [OPCINASTANOVANJAIDOPCINE] = @IDOPCINE ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOPCINE", DbType.String, 4));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOPCINA["IDOPCINE"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                reader.Close();
                throw new DDRADNIKInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "DDRADNIK" }));
            }
            reader.Close();
            ReadWriteCommand command2 = this.connDefault.GetCommand("SELECT TOP 1 [DDIDRADNIK] FROM [DDRADNIK] WITH (NOLOCK) WHERE [OPCINARADAIDOPCINE] = @IDOPCINE ", false);
            if (command2.IDbCommand.Parameters.Count == 0)
            {
                command2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOPCINE", DbType.String, 4));
            }
            command2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOPCINA["IDOPCINE"]));
            IDataReader reader2 = command2.FetchData();
            if (command2.HasMoreRows)
            {
                reader2.Close();
                throw new DDRADNIKInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "DDRADNIK" }));
            }
            reader2.Close();
            ReadWriteCommand command3 = this.connDefault.GetCommand("SELECT TOP 1 [IDRADNIK] FROM [RADNIK] WITH (NOLOCK) WHERE [OPCINASTANOVANJAIDOPCINE] = @IDOPCINE ", false);
            if (command3.IDbCommand.Parameters.Count == 0)
            {
                command3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOPCINE", DbType.String, 4));
            }
            command3.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOPCINA["IDOPCINE"]));
            IDataReader reader3 = command3.FetchData();
            if (command3.HasMoreRows)
            {
                reader3.Close();
                throw new RADNIKInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "RADNIK" }));
            }
            reader3.Close();
            ReadWriteCommand command4 = this.connDefault.GetCommand("SELECT TOP 1 [IDRADNIK] FROM [RADNIK] WITH (NOLOCK) WHERE [OPCINARADAIDOPCINE] = @IDOPCINE ", false);
            if (command4.IDbCommand.Parameters.Count == 0)
            {
                command4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOPCINE", DbType.String, 4));
            }
            command4.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOPCINA["IDOPCINE"]));
            IDataReader reader4 = command4.FetchData();
            if (command4.HasMoreRows)
            {
                reader4.Close();
                throw new RADNIKInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "RADNIK" }));
            }
            reader4.Close();
        }

        private void CheckOptimisticConcurrencyOpcina()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDOPCINE], [NAZIVOPCINE], [PRIREZ], [VBDIOPCINA], [ZRNOPCINA] FROM [OPCINA] WITH (UPDLOCK) WHERE [IDOPCINE] = @IDOPCINE ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOPCINE", DbType.String, 4));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOPCINA["IDOPCINE"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new OPCINADataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("OPCINA") }));
                }
                if ((!command.HasMoreRows || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__NAZIVOPCINEOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1)))) || ((!this.m__PRIREZOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 2))) || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__VBDIOPCINAOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 3)))) || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__ZRNOPCINAOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 4)))))
                {
                    reader.Close();
                    throw new OPCINADataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("OPCINA") }));
                }
                reader.Close();
            }
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        private void CreateNewRowOpcina()
        {
            this.rowOPCINA = this.OPCINASet.OPCINA.NewOPCINARow();
        }

        private void Delete()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyOpcina();
            this.AfterConfirmOpcina();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [OPCINA]  WHERE [IDOPCINE] = @IDOPCINE", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOPCINE", DbType.String, 4));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOPCINA["IDOPCINE"]));
            command.ExecuteStmt();
            if (command.ForeignKeyError)
            {
                this.CheckDeleteErrorsOpcina();
            }
            this.OnOPCINAUpdated(new OPCINAEventArgs(this.rowOPCINA, StatementType.Delete));
            this.rowOPCINA.Delete();
            this.sMode16 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode16;
        }

        public virtual int Fill(OPCINADataSet dataSet)
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
                    this.OPCINASet = dataSet;
                    this.LoadChildOpcina(0, -1);
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
            this.OPCINASet = (OPCINADataSet) dataSet;
            if (this.OPCINASet != null)
            {
                return this.Fill(this.OPCINASet);
            }
            this.OPCINASet = new OPCINADataSet();
            this.Fill(this.OPCINASet);
            dataSet.Merge(this.OPCINASet);
            return 0;
        }

        public virtual int Fill(OPCINADataSet dataSet, DataRow dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToString(dataRecord["IDOPCINE"]));
        }

        public virtual int Fill(OPCINADataSet dataSet, IDataRecord dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToString(dataRecord["IDOPCINE"]));
        }

        public virtual int Fill(OPCINADataSet dataSet, string iDOPCINE)
        {
            if (!this.FillByIDOPCINE(dataSet, iDOPCINE))
            {
                throw new OPCINANotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("OPCINA") }));
            }
            return 0;
        }

        public virtual bool FillByIDOPCINE(OPCINADataSet dataSet, string iDOPCINE)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.OPCINASet = dataSet;
            this.rowOPCINA = this.OPCINASet.OPCINA.NewOPCINARow();
            this.rowOPCINA.IDOPCINE = iDOPCINE;
            try
            {
                this.LoadByIDOPCINE(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            if (this.RcdFound16 == 0)
            {
                return false;
            }
            return true;
        }

        public virtual int FillPage(OPCINADataSet dataSet, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.OPCINASet = dataSet;
            try
            {
                this.LoadChildOpcina(startRow, maxRows);
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
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDOPCINE], [NAZIVOPCINE], [PRIREZ], [VBDIOPCINA], [ZRNOPCINA] FROM [OPCINA] WITH (NOLOCK) WHERE [IDOPCINE] = @IDOPCINE ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOPCINE", DbType.String, 4));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOPCINA["IDOPCINE"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.RcdFound16 = 1;
                this.rowOPCINA["IDOPCINE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0));
                this.rowOPCINA["NAZIVOPCINE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1));
                this.rowOPCINA["PRIREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 2));
                this.rowOPCINA["VBDIOPCINA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 3));
                this.rowOPCINA["ZRNOPCINA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 4));
                this.sMode16 = this.Gx_mode;
                this.Gx_mode = StatementType.Select;
                this.Gx_mode = this.sMode16;
            }
            else
            {
                this.RcdFound16 = 0;
            }
            reader.Close();
        }

        public virtual IDataParameter[] GetFillParameters()
        {
            if (this.fillDataParameters == null)
            {
                DbParameter parameter = DbProviderFactories.GetFactory("System.Data.SqlClient").CreateParameter();
                parameter.ParameterName = "IDOPCINE";
                parameter.DbType = DbType.String;
                this.fillDataParameters = new DbParameter[] { parameter };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount()
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmOPCINASelect1 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [OPCINA] WITH (NOLOCK) ", false);
            this.OPCINASelect1 = this.cmOPCINASelect1.FetchData();
            if (this.OPCINASelect1.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.OPCINASelect1.GetInt32(0);
            }
            this.OPCINASelect1.Close();
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
            this.RcdFound16 = 0;
            this.scmdbuf = "";
            this.recordCount = 0;
            this._Gxremove = false;
            this.m__NAZIVOPCINEOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__PRIREZOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__VBDIOPCINAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__ZRNOPCINAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m_WhereString = "";
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void InitializeMembers()
        {
            this.OPCINASet = new OPCINADataSet();
            this.Initialize();
            this.dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        }

        private void InsertOpcina()
        {
            this.CheckOptimisticConcurrencyOpcina();
            this.AfterConfirmOpcina();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [OPCINA] ([IDOPCINE], [NAZIVOPCINE], [PRIREZ], [VBDIOPCINA], [ZRNOPCINA]) VALUES (@IDOPCINE, @NAZIVOPCINE, @PRIREZ, @VBDIOPCINA, @ZRNOPCINA)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOPCINE", DbType.String, 4));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVOPCINE", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRIREZ", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@VBDIOPCINA", DbType.String, 7));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZRNOPCINA", DbType.String, 10));
            }
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOPCINA["IDOPCINE"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowOPCINA["NAZIVOPCINE"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowOPCINA["PRIREZ"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowOPCINA["VBDIOPCINA"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowOPCINA["ZRNOPCINA"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new OPCINADuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            this.OnOPCINAUpdated(new OPCINAEventArgs(this.rowOPCINA, StatementType.Insert));
        }

        private void LoadByIDOPCINE(int startRow, int maxRows)
        {
            bool enforceConstraints = this.OPCINASet.EnforceConstraints;
            this.OPCINASet.OPCINA.BeginLoadData();
            this.ScanByIDOPCINE(startRow, maxRows);
            this.OPCINASet.OPCINA.EndLoadData();
            this.OPCINASet.EnforceConstraints = enforceConstraints;
            if (this.OPCINASet.OPCINA.Count > 0)
            {
                this.rowOPCINA = this.OPCINASet.OPCINA[this.OPCINASet.OPCINA.Count - 1];
            }
        }

        private void LoadChildOpcina(int startRow, int maxRows)
        {
            this.CreateNewRowOpcina();
            bool enforceConstraints = this.OPCINASet.EnforceConstraints;
            this.OPCINASet.OPCINA.BeginLoadData();
            this.ScanStartOpcina(startRow, maxRows);
            this.OPCINASet.OPCINA.EndLoadData();
            this.OPCINASet.EnforceConstraints = enforceConstraints;
        }

        private void LoadDataOpcina(int maxRows)
        {
            int num = 0;
            if (this.RcdFound16 != 0)
            {
                this.ScanLoadOpcina();
                while ((this.RcdFound16 != 0) && (num != maxRows))
                {
                    num++;
                    this.LoadRowOpcina();
                    this.CreateNewRowOpcina();
                    this.ScanNextOpcina();
                }
            }
            if (num > 0)
            {
                this.RcdFound16 = 1;
            }
            this.ScanEndOpcina();
            if (this.OPCINASet.OPCINA.Count > 0)
            {
                this.rowOPCINA = this.OPCINASet.OPCINA[this.OPCINASet.OPCINA.Count - 1];
            }
        }

        private void LoadRowOpcina()
        {
            this.AddRowOpcina();
        }

        private void OnOPCINAUpdated(OPCINAEventArgs e)
        {
            if (this.OPCINAUpdated != null)
            {
                OPCINAUpdateEventHandler oPCINAUpdatedEvent = this.OPCINAUpdated;
                if (oPCINAUpdatedEvent != null)
                {
                    oPCINAUpdatedEvent(this, e);
                }
            }
        }

        private void OnOPCINAUpdating(OPCINAEventArgs e)
        {
            if (this.OPCINAUpdating != null)
            {
                OPCINAUpdateEventHandler oPCINAUpdatingEvent = this.OPCINAUpdating;
                if (oPCINAUpdatingEvent != null)
                {
                    oPCINAUpdatingEvent(this, e);
                }
            }
        }

        private void ReadRowOpcina()
        {
            this.Gx_mode = Mode.FromRowState(this.rowOPCINA.RowState);
            if (this.rowOPCINA.RowState != DataRowState.Added)
            {
                this.m__NAZIVOPCINEOriginal = RuntimeHelpers.GetObjectValue(this.rowOPCINA["NAZIVOPCINE", DataRowVersion.Original]);
                this.m__PRIREZOriginal = RuntimeHelpers.GetObjectValue(this.rowOPCINA["PRIREZ", DataRowVersion.Original]);
                this.m__VBDIOPCINAOriginal = RuntimeHelpers.GetObjectValue(this.rowOPCINA["VBDIOPCINA", DataRowVersion.Original]);
                this.m__ZRNOPCINAOriginal = RuntimeHelpers.GetObjectValue(this.rowOPCINA["ZRNOPCINA", DataRowVersion.Original]);
            }
            else
            {
                this.m__NAZIVOPCINEOriginal = RuntimeHelpers.GetObjectValue(this.rowOPCINA["NAZIVOPCINE"]);
                this.m__PRIREZOriginal = RuntimeHelpers.GetObjectValue(this.rowOPCINA["PRIREZ"]);
                this.m__VBDIOPCINAOriginal = RuntimeHelpers.GetObjectValue(this.rowOPCINA["VBDIOPCINA"]);
                this.m__ZRNOPCINAOriginal = RuntimeHelpers.GetObjectValue(this.rowOPCINA["ZRNOPCINA"]);
            }
            this._Gxremove = this.rowOPCINA.RowState == DataRowState.Deleted;
            if (this._Gxremove)
            {
                this.rowOPCINA = (OPCINADataSet.OPCINARow) DataSetUtil.CloneOriginalDataRow(this.rowOPCINA);
            }
        }

        private void ScanByIDOPCINE(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[IDOPCINE] = @IDOPCINE";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString16 + "  FROM [OPCINA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDOPCINE]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString16, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDOPCINE] ) AS DK_PAGENUM   FROM [OPCINA] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString16 + " FROM [OPCINA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDOPCINE] ";
            }
            this.cmOPCINASelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmOPCINASelect4.IDbCommand.Parameters.Count == 0)
            {
                this.cmOPCINASelect4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOPCINE", DbType.String, 4));
            }
            this.cmOPCINASelect4.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOPCINA["IDOPCINE"]));
            this.OPCINASelect4 = this.cmOPCINASelect4.FetchData();
            this.RcdFound16 = 0;
            this.ScanLoadOpcina();
            this.LoadDataOpcina(maxRows);
        }

        private void ScanEndOpcina()
        {
            this.OPCINASelect4.Close();
        }

        private void ScanLoadOpcina()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmOPCINASelect4.HasMoreRows)
            {
                this.RcdFound16 = 1;
                this.rowOPCINA["IDOPCINE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.OPCINASelect4, 0));
                this.rowOPCINA["NAZIVOPCINE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.OPCINASelect4, 1));
                this.rowOPCINA["PRIREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.OPCINASelect4, 2));
                this.rowOPCINA["VBDIOPCINA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.OPCINASelect4, 3));
                this.rowOPCINA["ZRNOPCINA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.OPCINASelect4, 4));
            }
        }

        private void ScanNextOpcina()
        {
            this.cmOPCINASelect4.HasMoreRows = this.OPCINASelect4.Read();
            this.RcdFound16 = 0;
            this.ScanLoadOpcina();
        }

        private void ScanStartOpcina(int startRow, int maxRows)
        {
            this.m_WhereString = "";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString16 + "  FROM [OPCINA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDOPCINE]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString16, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDOPCINE] ) AS DK_PAGENUM   FROM [OPCINA] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString16 + " FROM [OPCINA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDOPCINE] ";
            }
            this.cmOPCINASelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            this.OPCINASelect4 = this.cmOPCINASelect4.FetchData();
            this.RcdFound16 = 0;
            this.ScanLoadOpcina();
            this.LoadDataOpcina(maxRows);
        }

        public virtual int Update(DataSet dataSet)
        {
            this.InitializeMembers();
            this.OPCINASet = (OPCINADataSet) dataSet;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            if (this.OPCINASet == null)
            {
                throw new ArgumentException(this.resourceManager.GetString("nulldset"));
            }
            try
            {
                IEnumerator enumerator = null;
                this.connDefault.BeginTransaction();
                try
                {
                    enumerator = this.OPCINASet.OPCINA.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        OPCINADataSet.OPCINARow current = (OPCINADataSet.OPCINARow) enumerator.Current;
                        this.rowOPCINA = current;
                        if (Helpers.IsRowChanged(this.rowOPCINA))
                        {
                            this.ReadRowOpcina();
                            if (this.rowOPCINA.RowState == DataRowState.Added)
                            {
                                this.InsertOpcina();
                            }
                            else
                            {
                                if (this._Gxremove)
                                {
                                    this.Delete();
                                    continue;
                                }
                                this.UpdateOpcina();
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

        private void UpdateOpcina()
        {
            this.CheckOptimisticConcurrencyOpcina();
            this.AfterConfirmOpcina();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [OPCINA] SET [NAZIVOPCINE]=@NAZIVOPCINE, [PRIREZ]=@PRIREZ, [VBDIOPCINA]=@VBDIOPCINA, [ZRNOPCINA]=@ZRNOPCINA  WHERE [IDOPCINE] = @IDOPCINE", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVOPCINE", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRIREZ", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@VBDIOPCINA", DbType.String, 7));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZRNOPCINA", DbType.String, 10));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOPCINE", DbType.String, 4));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOPCINA["NAZIVOPCINE"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowOPCINA["PRIREZ"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowOPCINA["VBDIOPCINA"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowOPCINA["ZRNOPCINA"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowOPCINA["IDOPCINE"]));
            command.ExecuteStmt();
            this.OnOPCINAUpdated(new OPCINAEventArgs(this.rowOPCINA, StatementType.Update));
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
        public class DDRADNIKInvalidDeleteException : InvalidDeleteException
        {
            public DDRADNIKInvalidDeleteException()
            {
            }

            public DDRADNIKInvalidDeleteException(string message) : base(message)
            {
            }

            protected DDRADNIKInvalidDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public DDRADNIKInvalidDeleteException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class OPCINADataChangedException : DataChangedException
        {
            public OPCINADataChangedException()
            {
            }

            public OPCINADataChangedException(string message) : base(message)
            {
            }

            protected OPCINADataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public OPCINADataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class OPCINADataLockedException : DataLockedException
        {
            public OPCINADataLockedException()
            {
            }

            public OPCINADataLockedException(string message) : base(message)
            {
            }

            protected OPCINADataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public OPCINADataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class OPCINADuplicateKeyException : DuplicateKeyException
        {
            public OPCINADuplicateKeyException()
            {
            }

            public OPCINADuplicateKeyException(string message) : base(message)
            {
            }

            protected OPCINADuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public OPCINADuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class OPCINAEventArgs : EventArgs
        {
            private OPCINADataSet.OPCINARow m_dataRow;
            private System.Data.StatementType m_statementType;

            public OPCINAEventArgs(OPCINADataSet.OPCINARow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public OPCINADataSet.OPCINARow Row
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
        public class OPCINANotFoundException : DataNotFoundException
        {
            public OPCINANotFoundException()
            {
            }

            public OPCINANotFoundException(string message) : base(message)
            {
            }

            protected OPCINANotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public OPCINANotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public delegate void OPCINAUpdateEventHandler(object sender, OPCINADataAdapter.OPCINAEventArgs e);

        [Serializable]
        public class RADNIKInvalidDeleteException : InvalidDeleteException
        {
            public RADNIKInvalidDeleteException()
            {
            }

            public RADNIKInvalidDeleteException(string message) : base(message)
            {
            }

            protected RADNIKInvalidDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public RADNIKInvalidDeleteException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }
    }
}


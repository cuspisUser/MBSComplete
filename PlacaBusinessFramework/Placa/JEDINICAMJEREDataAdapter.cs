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

    public class JEDINICAMJEREDataAdapter : IDataAdapter, IJEDINICAMJEREDataAdapter
    {
        private bool _Gxremove;
        private ReadWriteCommand cmJEDINICAMJERESelect1;
        private ReadWriteCommand cmJEDINICAMJERESelect4;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private DbParameter[] fillDataParameters;
        private StatementType Gx_mode;
        private IDataReader JEDINICAMJERESelect1;
        private IDataReader JEDINICAMJERESelect4;
        private JEDINICAMJEREDataSet JEDINICAMJERESet;
        private object m__NAZIVJEDINICAMJEREOriginal;
        private readonly string m_SelectString210 = "TM1.[IDJEDINICAMJERE], TM1.[NAZIVJEDINICAMJERE]";
        private string m_WhereString;
        private short RcdFound210;
        private int recordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private JEDINICAMJEREDataSet.JEDINICAMJERERow rowJEDINICAMJERE;
        private string scmdbuf;
        private StatementType sMode210;

        public event JEDINICAMJEREUpdateEventHandler JEDINICAMJEREUpdated;

        public event JEDINICAMJEREUpdateEventHandler JEDINICAMJEREUpdating;

        private void AddRowJedinicamjere()
        {
            this.JEDINICAMJERESet.JEDINICAMJERE.AddJEDINICAMJERERow(this.rowJEDINICAMJERE);
        }

        private void AfterConfirmJedinicamjere()
        {
            this.OnJEDINICAMJEREUpdating(new JEDINICAMJEREEventArgs(this.rowJEDINICAMJERE, this.Gx_mode));
        }

        private void CheckDeleteErrorsJedinicamjere()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT TOP 1 [IDPROIZVOD] FROM [PROIZVOD] WITH (NOLOCK) WHERE [IDJEDINICAMJERE] = @IDJEDINICAMJERE ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDJEDINICAMJERE", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowJEDINICAMJERE["IDJEDINICAMJERE"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                reader.Close();
                throw new PROIZVODInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "PROIZVOD" }));
            }
            reader.Close();
        }

        private void CheckOptimisticConcurrencyJedinicamjere()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDJEDINICAMJERE], [NAZIVJEDINICAMJERE] FROM [JEDINICAMJERE] WITH (UPDLOCK) WHERE [IDJEDINICAMJERE] = @IDJEDINICAMJERE ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDJEDINICAMJERE", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowJEDINICAMJERE["IDJEDINICAMJERE"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new JEDINICAMJEREDataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("JEDINICAMJERE") }));
                }
                if (!command.HasMoreRows || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__NAZIVJEDINICAMJEREOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1))))
                {
                    reader.Close();
                    throw new JEDINICAMJEREDataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("JEDINICAMJERE") }));
                }
                reader.Close();
            }
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        private void CreateNewRowJedinicamjere()
        {
            this.rowJEDINICAMJERE = this.JEDINICAMJERESet.JEDINICAMJERE.NewJEDINICAMJERERow();
        }

        private void Delete()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyJedinicamjere();
            this.AfterConfirmJedinicamjere();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [JEDINICAMJERE]  WHERE [IDJEDINICAMJERE] = @IDJEDINICAMJERE", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDJEDINICAMJERE", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowJEDINICAMJERE["IDJEDINICAMJERE"]));
            command.ExecuteStmt();
            if (command.ForeignKeyError)
            {
                this.CheckDeleteErrorsJedinicamjere();
            }
            this.OnJEDINICAMJEREUpdated(new JEDINICAMJEREEventArgs(this.rowJEDINICAMJERE, StatementType.Delete));
            this.rowJEDINICAMJERE.Delete();
            this.sMode210 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode210;
        }

        public virtual int Fill(JEDINICAMJEREDataSet dataSet)
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
                    this.JEDINICAMJERESet = dataSet;
                    this.LoadChildJedinicamjere(0, -1);
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
            this.JEDINICAMJERESet = (JEDINICAMJEREDataSet) dataSet;
            if (this.JEDINICAMJERESet != null)
            {
                return this.Fill(this.JEDINICAMJERESet);
            }
            this.JEDINICAMJERESet = new JEDINICAMJEREDataSet();
            this.Fill(this.JEDINICAMJERESet);
            dataSet.Merge(this.JEDINICAMJERESet);
            return 0;
        }

        public virtual int Fill(JEDINICAMJEREDataSet dataSet, DataRow dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDJEDINICAMJERE"]));
        }

        public virtual int Fill(JEDINICAMJEREDataSet dataSet, IDataRecord dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDJEDINICAMJERE"]));
        }

        public virtual int Fill(JEDINICAMJEREDataSet dataSet, int iDJEDINICAMJERE)
        {
            if (!this.FillByIDJEDINICAMJERE(dataSet, iDJEDINICAMJERE))
            {
                throw new JEDINICAMJERENotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("JEDINICAMJERE") }));
            }
            return 0;
        }

        public virtual bool FillByIDJEDINICAMJERE(JEDINICAMJEREDataSet dataSet, int iDJEDINICAMJERE)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.JEDINICAMJERESet = dataSet;
            this.rowJEDINICAMJERE = this.JEDINICAMJERESet.JEDINICAMJERE.NewJEDINICAMJERERow();
            this.rowJEDINICAMJERE.IDJEDINICAMJERE = iDJEDINICAMJERE;
            try
            {
                this.LoadByIDJEDINICAMJERE(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            if (this.RcdFound210 == 0)
            {
                return false;
            }
            return true;
        }

        public virtual int FillPage(JEDINICAMJEREDataSet dataSet, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.JEDINICAMJERESet = dataSet;
            try
            {
                this.LoadChildJedinicamjere(startRow, maxRows);
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
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDJEDINICAMJERE], [NAZIVJEDINICAMJERE] FROM [JEDINICAMJERE] WITH (NOLOCK) WHERE [IDJEDINICAMJERE] = @IDJEDINICAMJERE ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDJEDINICAMJERE", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowJEDINICAMJERE["IDJEDINICAMJERE"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.RcdFound210 = 1;
                this.rowJEDINICAMJERE["IDJEDINICAMJERE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 0));
                this.rowJEDINICAMJERE["NAZIVJEDINICAMJERE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1));
                this.sMode210 = this.Gx_mode;
                this.Gx_mode = StatementType.Select;
                this.Gx_mode = this.sMode210;
            }
            else
            {
                this.RcdFound210 = 0;
            }
            reader.Close();
        }

        public virtual IDataParameter[] GetFillParameters()
        {
            if (this.fillDataParameters == null)
            {
                DbParameter parameter = DbProviderFactories.GetFactory("System.Data.SqlClient").CreateParameter();
                parameter.ParameterName = "IDJEDINICAMJERE";
                parameter.DbType = DbType.Int32;
                this.fillDataParameters = new DbParameter[] { parameter };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount()
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmJEDINICAMJERESelect1 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [JEDINICAMJERE] WITH (NOLOCK) ", false);
            this.JEDINICAMJERESelect1 = this.cmJEDINICAMJERESelect1.FetchData();
            if (this.JEDINICAMJERESelect1.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.JEDINICAMJERESelect1.GetInt32(0);
            }
            this.JEDINICAMJERESelect1.Close();
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
            this.RcdFound210 = 0;
            this.scmdbuf = "";
            this.recordCount = 0;
            this._Gxremove = false;
            this.m__NAZIVJEDINICAMJEREOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m_WhereString = "";
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void InitializeMembers()
        {
            this.JEDINICAMJERESet = new JEDINICAMJEREDataSet();
            this.Initialize();
            this.dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        }

        private void InsertJedinicamjere()
        {
            this.CheckOptimisticConcurrencyJedinicamjere();
            this.AfterConfirmJedinicamjere();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [JEDINICAMJERE] ([IDJEDINICAMJERE], [NAZIVJEDINICAMJERE]) VALUES (@IDJEDINICAMJERE, @NAZIVJEDINICAMJERE)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDJEDINICAMJERE", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVJEDINICAMJERE", DbType.String, 50));
            }
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowJEDINICAMJERE["IDJEDINICAMJERE"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowJEDINICAMJERE["NAZIVJEDINICAMJERE"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new JEDINICAMJEREDuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            this.OnJEDINICAMJEREUpdated(new JEDINICAMJEREEventArgs(this.rowJEDINICAMJERE, StatementType.Insert));
        }

        private void LoadByIDJEDINICAMJERE(int startRow, int maxRows)
        {
            bool enforceConstraints = this.JEDINICAMJERESet.EnforceConstraints;
            this.JEDINICAMJERESet.JEDINICAMJERE.BeginLoadData();
            this.ScanByIDJEDINICAMJERE(startRow, maxRows);
            this.JEDINICAMJERESet.JEDINICAMJERE.EndLoadData();
            this.JEDINICAMJERESet.EnforceConstraints = enforceConstraints;
            if (this.JEDINICAMJERESet.JEDINICAMJERE.Count > 0)
            {
                this.rowJEDINICAMJERE = this.JEDINICAMJERESet.JEDINICAMJERE[this.JEDINICAMJERESet.JEDINICAMJERE.Count - 1];
            }
        }

        private void LoadChildJedinicamjere(int startRow, int maxRows)
        {
            this.CreateNewRowJedinicamjere();
            bool enforceConstraints = this.JEDINICAMJERESet.EnforceConstraints;
            this.JEDINICAMJERESet.JEDINICAMJERE.BeginLoadData();
            this.ScanStartJedinicamjere(startRow, maxRows);
            this.JEDINICAMJERESet.JEDINICAMJERE.EndLoadData();
            this.JEDINICAMJERESet.EnforceConstraints = enforceConstraints;
        }

        private void LoadDataJedinicamjere(int maxRows)
        {
            int num = 0;
            if (this.RcdFound210 != 0)
            {
                this.ScanLoadJedinicamjere();
                while ((this.RcdFound210 != 0) && (num != maxRows))
                {
                    num++;
                    this.LoadRowJedinicamjere();
                    this.CreateNewRowJedinicamjere();
                    this.ScanNextJedinicamjere();
                }
            }
            if (num > 0)
            {
                this.RcdFound210 = 1;
            }
            this.ScanEndJedinicamjere();
            if (this.JEDINICAMJERESet.JEDINICAMJERE.Count > 0)
            {
                this.rowJEDINICAMJERE = this.JEDINICAMJERESet.JEDINICAMJERE[this.JEDINICAMJERESet.JEDINICAMJERE.Count - 1];
            }
        }

        private void LoadRowJedinicamjere()
        {
            this.AddRowJedinicamjere();
        }

        private void OnJEDINICAMJEREUpdated(JEDINICAMJEREEventArgs e)
        {
            if (this.JEDINICAMJEREUpdated != null)
            {
                JEDINICAMJEREUpdateEventHandler jEDINICAMJEREUpdatedEvent = this.JEDINICAMJEREUpdated;
                if (jEDINICAMJEREUpdatedEvent != null)
                {
                    jEDINICAMJEREUpdatedEvent(this, e);
                }
            }
        }

        private void OnJEDINICAMJEREUpdating(JEDINICAMJEREEventArgs e)
        {
            if (this.JEDINICAMJEREUpdating != null)
            {
                JEDINICAMJEREUpdateEventHandler jEDINICAMJEREUpdatingEvent = this.JEDINICAMJEREUpdating;
                if (jEDINICAMJEREUpdatingEvent != null)
                {
                    jEDINICAMJEREUpdatingEvent(this, e);
                }
            }
        }

        private void ReadRowJedinicamjere()
        {
            this.Gx_mode = Mode.FromRowState(this.rowJEDINICAMJERE.RowState);
            if (this.rowJEDINICAMJERE.RowState != DataRowState.Added)
            {
                this.m__NAZIVJEDINICAMJEREOriginal = RuntimeHelpers.GetObjectValue(this.rowJEDINICAMJERE["NAZIVJEDINICAMJERE", DataRowVersion.Original]);
            }
            else
            {
                this.m__NAZIVJEDINICAMJEREOriginal = RuntimeHelpers.GetObjectValue(this.rowJEDINICAMJERE["NAZIVJEDINICAMJERE"]);
            }
            this._Gxremove = this.rowJEDINICAMJERE.RowState == DataRowState.Deleted;
            if (this._Gxremove)
            {
                this.rowJEDINICAMJERE = (JEDINICAMJEREDataSet.JEDINICAMJERERow) DataSetUtil.CloneOriginalDataRow(this.rowJEDINICAMJERE);
            }
        }

        private void ScanByIDJEDINICAMJERE(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[IDJEDINICAMJERE] = @IDJEDINICAMJERE";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString210 + "  FROM [JEDINICAMJERE] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDJEDINICAMJERE]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString210, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDJEDINICAMJERE] ) AS DK_PAGENUM   FROM [JEDINICAMJERE] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString210 + " FROM [JEDINICAMJERE] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDJEDINICAMJERE] ";
            }
            this.cmJEDINICAMJERESelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmJEDINICAMJERESelect4.IDbCommand.Parameters.Count == 0)
            {
                this.cmJEDINICAMJERESelect4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDJEDINICAMJERE", DbType.Int32));
            }
            this.cmJEDINICAMJERESelect4.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowJEDINICAMJERE["IDJEDINICAMJERE"]));
            this.JEDINICAMJERESelect4 = this.cmJEDINICAMJERESelect4.FetchData();
            this.RcdFound210 = 0;
            this.ScanLoadJedinicamjere();
            this.LoadDataJedinicamjere(maxRows);
        }

        private void ScanEndJedinicamjere()
        {
            this.JEDINICAMJERESelect4.Close();
        }

        private void ScanLoadJedinicamjere()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmJEDINICAMJERESelect4.HasMoreRows)
            {
                this.RcdFound210 = 1;
                this.rowJEDINICAMJERE["IDJEDINICAMJERE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.JEDINICAMJERESelect4, 0));
                this.rowJEDINICAMJERE["NAZIVJEDINICAMJERE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.JEDINICAMJERESelect4, 1));
            }
        }

        private void ScanNextJedinicamjere()
        {
            this.cmJEDINICAMJERESelect4.HasMoreRows = this.JEDINICAMJERESelect4.Read();
            this.RcdFound210 = 0;
            this.ScanLoadJedinicamjere();
        }

        private void ScanStartJedinicamjere(int startRow, int maxRows)
        {
            this.m_WhereString = "";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString210 + "  FROM [JEDINICAMJERE] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDJEDINICAMJERE]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString210, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDJEDINICAMJERE] ) AS DK_PAGENUM   FROM [JEDINICAMJERE] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString210 + " FROM [JEDINICAMJERE] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDJEDINICAMJERE] ";
            }
            this.cmJEDINICAMJERESelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            this.JEDINICAMJERESelect4 = this.cmJEDINICAMJERESelect4.FetchData();
            this.RcdFound210 = 0;
            this.ScanLoadJedinicamjere();
            this.LoadDataJedinicamjere(maxRows);
        }

        public virtual int Update(DataSet dataSet)
        {
            this.InitializeMembers();
            this.JEDINICAMJERESet = (JEDINICAMJEREDataSet) dataSet;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            if (this.JEDINICAMJERESet == null)
            {
                throw new ArgumentException(this.resourceManager.GetString("nulldset"));
            }
            try
            {
                IEnumerator enumerator = null;
                this.connDefault.BeginTransaction();
                try
                {
                    enumerator = this.JEDINICAMJERESet.JEDINICAMJERE.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        JEDINICAMJEREDataSet.JEDINICAMJERERow current = (JEDINICAMJEREDataSet.JEDINICAMJERERow) enumerator.Current;
                        this.rowJEDINICAMJERE = current;
                        if (Helpers.IsRowChanged(this.rowJEDINICAMJERE))
                        {
                            this.ReadRowJedinicamjere();
                            if (this.rowJEDINICAMJERE.RowState == DataRowState.Added)
                            {
                                this.InsertJedinicamjere();
                            }
                            else
                            {
                                if (this._Gxremove)
                                {
                                    this.Delete();
                                    continue;
                                }
                                this.UpdateJedinicamjere();
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

        private void UpdateJedinicamjere()
        {
            this.CheckOptimisticConcurrencyJedinicamjere();
            this.AfterConfirmJedinicamjere();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [JEDINICAMJERE] SET [NAZIVJEDINICAMJERE]=@NAZIVJEDINICAMJERE  WHERE [IDJEDINICAMJERE] = @IDJEDINICAMJERE", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVJEDINICAMJERE", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDJEDINICAMJERE", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowJEDINICAMJERE["NAZIVJEDINICAMJERE"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowJEDINICAMJERE["IDJEDINICAMJERE"]));
            command.ExecuteStmt();
            this.OnJEDINICAMJEREUpdated(new JEDINICAMJEREEventArgs(this.rowJEDINICAMJERE, StatementType.Update));
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
        public class JEDINICAMJEREDataChangedException : DataChangedException
        {
            public JEDINICAMJEREDataChangedException()
            {
            }

            public JEDINICAMJEREDataChangedException(string message) : base(message)
            {
            }

            protected JEDINICAMJEREDataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public JEDINICAMJEREDataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class JEDINICAMJEREDataLockedException : DataLockedException
        {
            public JEDINICAMJEREDataLockedException()
            {
            }

            public JEDINICAMJEREDataLockedException(string message) : base(message)
            {
            }

            protected JEDINICAMJEREDataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public JEDINICAMJEREDataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class JEDINICAMJEREDuplicateKeyException : DuplicateKeyException
        {
            public JEDINICAMJEREDuplicateKeyException()
            {
            }

            public JEDINICAMJEREDuplicateKeyException(string message) : base(message)
            {
            }

            protected JEDINICAMJEREDuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public JEDINICAMJEREDuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class JEDINICAMJEREEventArgs : EventArgs
        {
            private JEDINICAMJEREDataSet.JEDINICAMJERERow m_dataRow;
            private System.Data.StatementType m_statementType;

            public JEDINICAMJEREEventArgs(JEDINICAMJEREDataSet.JEDINICAMJERERow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public JEDINICAMJEREDataSet.JEDINICAMJERERow Row
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
        public class JEDINICAMJERENotFoundException : DataNotFoundException
        {
            public JEDINICAMJERENotFoundException()
            {
            }

            public JEDINICAMJERENotFoundException(string message) : base(message)
            {
            }

            protected JEDINICAMJERENotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public JEDINICAMJERENotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public delegate void JEDINICAMJEREUpdateEventHandler(object sender, JEDINICAMJEREDataAdapter.JEDINICAMJEREEventArgs e);

        [Serializable]
        public class PROIZVODInvalidDeleteException : InvalidDeleteException
        {
            public PROIZVODInvalidDeleteException()
            {
            }

            public PROIZVODInvalidDeleteException(string message) : base(message)
            {
            }

            protected PROIZVODInvalidDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public PROIZVODInvalidDeleteException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }
    }
}


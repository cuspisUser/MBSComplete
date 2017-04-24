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

    public class LOKACIJEDataAdapter : IDataAdapter, ILOKACIJEDataAdapter
    {
        private bool _Gxremove;
        private ReadWriteCommand cmLOKACIJESelect1;
        private ReadWriteCommand cmLOKACIJESelect4;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private DbParameter[] fillDataParameters;
        private StatementType Gx_mode;
        private IDataReader LOKACIJESelect1;
        private IDataReader LOKACIJESelect4;
        private LOKACIJEDataSet LOKACIJESet;
        private object m__OPISLOKACIJEOriginal;
        private readonly string m_SelectString253 = "TM1.[IDLOKACIJE], TM1.[OPISLOKACIJE]";
        private string m_WhereString;
        private short RcdFound253;
        private int recordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private LOKACIJEDataSet.LOKACIJERow rowLOKACIJE;
        private string scmdbuf;
        private StatementType sMode253;

        public event LOKACIJEUpdateEventHandler LOKACIJEUpdated;

        public event LOKACIJEUpdateEventHandler LOKACIJEUpdating;

        private void AddRowLokacije()
        {
            this.LOKACIJESet.LOKACIJE.AddLOKACIJERow(this.rowLOKACIJE);
        }

        private void AfterConfirmLokacije()
        {
            this.OnLOKACIJEUpdating(new LOKACIJEEventArgs(this.rowLOKACIJE, this.Gx_mode));
        }

        private void CheckDeleteErrorsLokacije()
        {
            ReadWriteCommand command2 = this.connDefault.GetCommand("SELECT TOP 1 [INVBROJ], [IDOSDOKUMENT], [OSBROJDOKUMENTA] FROM [OSTEMELJNICA] WITH (NOLOCK) WHERE [RASHODLOKACIJEIDLOKACIJE] = @IDLOKACIJE ", false);
            if (command2.IDbCommand.Parameters.Count == 0)
            {
                command2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDLOKACIJE", DbType.Int32));
            }
            command2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowLOKACIJE["IDLOKACIJE"]));
            IDataReader reader2 = command2.FetchData();
            if (command2.HasMoreRows)
            {
                reader2.Close();
                throw new OSTEMELJNICAInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "TEMELJNICA" }));
            }
            reader2.Close();
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT TOP 1 [IDOSRAZMJESTAJ] FROM [OSRAZMJESTAJ] WITH (NOLOCK) WHERE [IDLOKACIJE] = @IDLOKACIJE ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDLOKACIJE", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowLOKACIJE["IDLOKACIJE"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                reader.Close();
                throw new OSRAZMJESTAJInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "OSRAZMJESTAJ" }));
            }
            reader.Close();
        }

        private void CheckExtendedTableLokacije()
        {
            this.rowLOKACIJE.LOK = NumberUtil.ToString((long) this.rowLOKACIJE.IDLOKACIJE, "") + " | " + this.rowLOKACIJE.OPISLOKACIJE;
        }

        private void CheckOptimisticConcurrencyLokacije()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDLOKACIJE], [OPISLOKACIJE] FROM [LOKACIJE] WITH (UPDLOCK) WHERE [IDLOKACIJE] = @IDLOKACIJE ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDLOKACIJE", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowLOKACIJE["IDLOKACIJE"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new LOKACIJEDataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("LOKACIJE") }));
                }
                if (!command.HasMoreRows || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__OPISLOKACIJEOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1))))
                {
                    reader.Close();
                    throw new LOKACIJEDataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("LOKACIJE") }));
                }
                reader.Close();
            }
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        private void CreateNewRowLokacije()
        {
            this.rowLOKACIJE = this.LOKACIJESet.LOKACIJE.NewLOKACIJERow();
        }

        private void Delete()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyLokacije();
            this.OnDeleteControlsLokacije();
            this.AfterConfirmLokacije();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [LOKACIJE]  WHERE [IDLOKACIJE] = @IDLOKACIJE", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDLOKACIJE", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowLOKACIJE["IDLOKACIJE"]));
            command.ExecuteStmt();
            if (command.ForeignKeyError)
            {
                this.CheckDeleteErrorsLokacije();
            }
            this.OnLOKACIJEUpdated(new LOKACIJEEventArgs(this.rowLOKACIJE, StatementType.Delete));
            this.rowLOKACIJE.Delete();
            this.sMode253 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode253;
        }

        public virtual int Fill(LOKACIJEDataSet dataSet)
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
                    this.LOKACIJESet = dataSet;
                    this.LoadChildLokacije(0, -1);
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
            this.LOKACIJESet = (LOKACIJEDataSet) dataSet;
            if (this.LOKACIJESet != null)
            {
                return this.Fill(this.LOKACIJESet);
            }
            this.LOKACIJESet = new LOKACIJEDataSet();
            this.Fill(this.LOKACIJESet);
            dataSet.Merge(this.LOKACIJESet);
            return 0;
        }

        public virtual int Fill(LOKACIJEDataSet dataSet, DataRow dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDLOKACIJE"]));
        }

        public virtual int Fill(LOKACIJEDataSet dataSet, IDataRecord dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDLOKACIJE"]));
        }

        public virtual int Fill(LOKACIJEDataSet dataSet, int iDLOKACIJE)
        {
            if (!this.FillByIDLOKACIJE(dataSet, iDLOKACIJE))
            {
                throw new LOKACIJENotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("LOKACIJE") }));
            }
            return 0;
        }

        public virtual bool FillByIDLOKACIJE(LOKACIJEDataSet dataSet, int iDLOKACIJE)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.LOKACIJESet = dataSet;
            this.rowLOKACIJE = this.LOKACIJESet.LOKACIJE.NewLOKACIJERow();
            this.rowLOKACIJE.IDLOKACIJE = iDLOKACIJE;
            try
            {
                this.LoadByIDLOKACIJE(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            if (this.RcdFound253 == 0)
            {
                return false;
            }
            return true;
        }

        public virtual int FillPage(LOKACIJEDataSet dataSet, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.LOKACIJESet = dataSet;
            try
            {
                this.LoadChildLokacije(startRow, maxRows);
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
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDLOKACIJE], [OPISLOKACIJE] FROM [LOKACIJE] WITH (NOLOCK) WHERE [IDLOKACIJE] = @IDLOKACIJE ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDLOKACIJE", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowLOKACIJE["IDLOKACIJE"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.RcdFound253 = 1;
                this.rowLOKACIJE["IDLOKACIJE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 0));
                this.rowLOKACIJE["OPISLOKACIJE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1));
                this.sMode253 = this.Gx_mode;
                this.Gx_mode = StatementType.Select;
                this.LoadLokacije();
                this.Gx_mode = this.sMode253;
            }
            else
            {
                this.RcdFound253 = 0;
            }
            reader.Close();
        }

        public virtual IDataParameter[] GetFillParameters()
        {
            if (this.fillDataParameters == null)
            {
                DbParameter parameter = DbProviderFactories.GetFactory("System.Data.SqlClient").CreateParameter();
                parameter.ParameterName = "IDLOKACIJE";
                parameter.DbType = DbType.Int32;
                this.fillDataParameters = new DbParameter[] { parameter };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount()
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmLOKACIJESelect1 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [LOKACIJE] WITH (NOLOCK) ", false);
            this.LOKACIJESelect1 = this.cmLOKACIJESelect1.FetchData();
            if (this.LOKACIJESelect1.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.LOKACIJESelect1.GetInt32(0);
            }
            this.LOKACIJESelect1.Close();
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
            this.RcdFound253 = 0;
            this.scmdbuf = "";
            this.recordCount = 0;
            this._Gxremove = false;
            this.m__OPISLOKACIJEOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m_WhereString = "";
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void InitializeMembers()
        {
            this.LOKACIJESet = new LOKACIJEDataSet();
            this.Initialize();
            this.dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        }

        private void InsertLokacije()
        {
            this.CheckOptimisticConcurrencyLokacije();
            this.CheckExtendedTableLokacije();
            this.AfterConfirmLokacije();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [LOKACIJE] ([IDLOKACIJE], [OPISLOKACIJE]) VALUES (@IDLOKACIJE, @OPISLOKACIJE)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDLOKACIJE", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OPISLOKACIJE", DbType.String, 50));
            }
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowLOKACIJE["IDLOKACIJE"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowLOKACIJE["OPISLOKACIJE"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new LOKACIJEDuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            this.OnLOKACIJEUpdated(new LOKACIJEEventArgs(this.rowLOKACIJE, StatementType.Insert));
        }

        private void LoadByIDLOKACIJE(int startRow, int maxRows)
        {
            bool enforceConstraints = this.LOKACIJESet.EnforceConstraints;
            this.LOKACIJESet.LOKACIJE.BeginLoadData();
            this.ScanByIDLOKACIJE(startRow, maxRows);
            this.LOKACIJESet.LOKACIJE.EndLoadData();
            this.LOKACIJESet.EnforceConstraints = enforceConstraints;
            if (this.LOKACIJESet.LOKACIJE.Count > 0)
            {
                this.rowLOKACIJE = this.LOKACIJESet.LOKACIJE[this.LOKACIJESet.LOKACIJE.Count - 1];
            }
        }

        private void LoadChildLokacije(int startRow, int maxRows)
        {
            this.CreateNewRowLokacije();
            bool enforceConstraints = this.LOKACIJESet.EnforceConstraints;
            this.LOKACIJESet.LOKACIJE.BeginLoadData();
            this.ScanStartLokacije(startRow, maxRows);
            this.LOKACIJESet.LOKACIJE.EndLoadData();
            this.LOKACIJESet.EnforceConstraints = enforceConstraints;
        }

        private void LoadDataLokacije(int maxRows)
        {
            int num = 0;
            if (this.RcdFound253 != 0)
            {
                this.ScanLoadLokacije();
                while ((this.RcdFound253 != 0) && (num != maxRows))
                {
                    num++;
                    this.LoadRowLokacije();
                    this.CreateNewRowLokacije();
                    this.ScanNextLokacije();
                }
            }
            if (num > 0)
            {
                this.RcdFound253 = 1;
            }
            this.ScanEndLokacije();
            if (this.LOKACIJESet.LOKACIJE.Count > 0)
            {
                this.rowLOKACIJE = this.LOKACIJESet.LOKACIJE[this.LOKACIJESet.LOKACIJE.Count - 1];
            }
        }

        private void LoadLokacije()
        {
            this.rowLOKACIJE.LOK = NumberUtil.ToString((long) this.rowLOKACIJE.IDLOKACIJE, "") + " | " + this.rowLOKACIJE.OPISLOKACIJE;
        }

        private void LoadRowLokacije()
        {
            this.OnLoadActionsLokacije();
            this.AddRowLokacije();
        }

        private void OnDeleteControlsLokacije()
        {
            this.rowLOKACIJE.LOK = NumberUtil.ToString((long) this.rowLOKACIJE.IDLOKACIJE, "") + " | " + this.rowLOKACIJE.OPISLOKACIJE;
        }

        private void OnLoadActionsLokacije()
        {
            this.rowLOKACIJE.LOK = NumberUtil.ToString((long) this.rowLOKACIJE.IDLOKACIJE, "") + " | " + this.rowLOKACIJE.OPISLOKACIJE;
        }

        private void OnLOKACIJEUpdated(LOKACIJEEventArgs e)
        {
            if (this.LOKACIJEUpdated != null)
            {
                LOKACIJEUpdateEventHandler lOKACIJEUpdatedEvent = this.LOKACIJEUpdated;
                if (lOKACIJEUpdatedEvent != null)
                {
                    lOKACIJEUpdatedEvent(this, e);
                }
            }
        }

        private void OnLOKACIJEUpdating(LOKACIJEEventArgs e)
        {
            if (this.LOKACIJEUpdating != null)
            {
                LOKACIJEUpdateEventHandler lOKACIJEUpdatingEvent = this.LOKACIJEUpdating;
                if (lOKACIJEUpdatingEvent != null)
                {
                    lOKACIJEUpdatingEvent(this, e);
                }
            }
        }

        private void ReadRowLokacije()
        {
            this.Gx_mode = Mode.FromRowState(this.rowLOKACIJE.RowState);
            if (this.rowLOKACIJE.RowState != DataRowState.Added)
            {
                this.m__OPISLOKACIJEOriginal = RuntimeHelpers.GetObjectValue(this.rowLOKACIJE["OPISLOKACIJE", DataRowVersion.Original]);
            }
            else
            {
                this.m__OPISLOKACIJEOriginal = RuntimeHelpers.GetObjectValue(this.rowLOKACIJE["OPISLOKACIJE"]);
            }
            this._Gxremove = this.rowLOKACIJE.RowState == DataRowState.Deleted;
            if (this._Gxremove)
            {
                this.rowLOKACIJE = (LOKACIJEDataSet.LOKACIJERow) DataSetUtil.CloneOriginalDataRow(this.rowLOKACIJE);
            }
        }

        private void ScanByIDLOKACIJE(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[IDLOKACIJE] = @IDLOKACIJE";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString253 + "  FROM [LOKACIJE] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDLOKACIJE]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString253, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDLOKACIJE] ) AS DK_PAGENUM   FROM [LOKACIJE] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString253 + " FROM [LOKACIJE] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDLOKACIJE] ";
            }
            this.cmLOKACIJESelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmLOKACIJESelect4.IDbCommand.Parameters.Count == 0)
            {
                this.cmLOKACIJESelect4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDLOKACIJE", DbType.Int32));
            }
            this.cmLOKACIJESelect4.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowLOKACIJE["IDLOKACIJE"]));
            this.LOKACIJESelect4 = this.cmLOKACIJESelect4.FetchData();
            this.RcdFound253 = 0;
            this.ScanLoadLokacije();
            this.LoadDataLokacije(maxRows);
        }

        private void ScanEndLokacije()
        {
            this.LOKACIJESelect4.Close();
        }

        private void ScanLoadLokacije()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmLOKACIJESelect4.HasMoreRows)
            {
                this.RcdFound253 = 1;
                this.rowLOKACIJE["IDLOKACIJE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.LOKACIJESelect4, 0));
                this.rowLOKACIJE["OPISLOKACIJE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.LOKACIJESelect4, 1));
            }
        }

        private void ScanNextLokacije()
        {
            this.cmLOKACIJESelect4.HasMoreRows = this.LOKACIJESelect4.Read();
            this.RcdFound253 = 0;
            this.ScanLoadLokacije();
        }

        private void ScanStartLokacije(int startRow, int maxRows)
        {
            this.m_WhereString = "";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString253 + "  FROM [LOKACIJE] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDLOKACIJE]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString253, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDLOKACIJE] ) AS DK_PAGENUM   FROM [LOKACIJE] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString253 + " FROM [LOKACIJE] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDLOKACIJE] ";
            }
            this.cmLOKACIJESelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            this.LOKACIJESelect4 = this.cmLOKACIJESelect4.FetchData();
            this.RcdFound253 = 0;
            this.ScanLoadLokacije();
            this.LoadDataLokacije(maxRows);
        }

        public virtual int Update(DataSet dataSet)
        {
            this.InitializeMembers();
            this.LOKACIJESet = (LOKACIJEDataSet) dataSet;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            if (this.LOKACIJESet == null)
            {
                throw new ArgumentException(this.resourceManager.GetString("nulldset"));
            }
            try
            {
                IEnumerator enumerator = null;
                this.connDefault.BeginTransaction();
                try
                {
                    enumerator = this.LOKACIJESet.LOKACIJE.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        LOKACIJEDataSet.LOKACIJERow current = (LOKACIJEDataSet.LOKACIJERow) enumerator.Current;
                        this.rowLOKACIJE = current;
                        if (Helpers.IsRowChanged(this.rowLOKACIJE))
                        {
                            this.ReadRowLokacije();
                            if (this.rowLOKACIJE.RowState == DataRowState.Added)
                            {
                                this.InsertLokacije();
                            }
                            else
                            {
                                if (this._Gxremove)
                                {
                                    this.Delete();
                                    continue;
                                }
                                this.UpdateLokacije();
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

        private void UpdateLokacije()
        {
            this.CheckOptimisticConcurrencyLokacije();
            this.CheckExtendedTableLokacije();
            this.AfterConfirmLokacije();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [LOKACIJE] SET [OPISLOKACIJE]=@OPISLOKACIJE  WHERE [IDLOKACIJE] = @IDLOKACIJE", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OPISLOKACIJE", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDLOKACIJE", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowLOKACIJE["OPISLOKACIJE"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowLOKACIJE["IDLOKACIJE"]));
            command.ExecuteStmt();
            this.OnLOKACIJEUpdated(new LOKACIJEEventArgs(this.rowLOKACIJE, StatementType.Update));
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
        public class LOKACIJEDataChangedException : DataChangedException
        {
            public LOKACIJEDataChangedException()
            {
            }

            public LOKACIJEDataChangedException(string message) : base(message)
            {
            }

            protected LOKACIJEDataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public LOKACIJEDataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class LOKACIJEDataLockedException : DataLockedException
        {
            public LOKACIJEDataLockedException()
            {
            }

            public LOKACIJEDataLockedException(string message) : base(message)
            {
            }

            protected LOKACIJEDataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public LOKACIJEDataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class LOKACIJEDuplicateKeyException : DuplicateKeyException
        {
            public LOKACIJEDuplicateKeyException()
            {
            }

            public LOKACIJEDuplicateKeyException(string message) : base(message)
            {
            }

            protected LOKACIJEDuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public LOKACIJEDuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class LOKACIJEEventArgs : EventArgs
        {
            private LOKACIJEDataSet.LOKACIJERow m_dataRow;
            private System.Data.StatementType m_statementType;

            public LOKACIJEEventArgs(LOKACIJEDataSet.LOKACIJERow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public LOKACIJEDataSet.LOKACIJERow Row
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
        public class LOKACIJENotFoundException : DataNotFoundException
        {
            public LOKACIJENotFoundException()
            {
            }

            public LOKACIJENotFoundException(string message) : base(message)
            {
            }

            protected LOKACIJENotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public LOKACIJENotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public delegate void LOKACIJEUpdateEventHandler(object sender, LOKACIJEDataAdapter.LOKACIJEEventArgs e);

        [Serializable]
        public class OSRAZMJESTAJInvalidDeleteException : InvalidDeleteException
        {
            public OSRAZMJESTAJInvalidDeleteException()
            {
            }

            public OSRAZMJESTAJInvalidDeleteException(string message) : base(message)
            {
            }

            protected OSRAZMJESTAJInvalidDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public OSRAZMJESTAJInvalidDeleteException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class OSTEMELJNICAInvalidDeleteException : InvalidDeleteException
        {
            public OSTEMELJNICAInvalidDeleteException()
            {
            }

            public OSTEMELJNICAInvalidDeleteException(string message) : base(message)
            {
            }

            protected OSTEMELJNICAInvalidDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public OSTEMELJNICAInvalidDeleteException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }
    }
}


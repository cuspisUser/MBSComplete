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

    public class SMJENEDataAdapter : IDataAdapter, ISMJENEDataAdapter
    {
        private bool _Gxremove;
        private ReadWriteCommand cmSMJENESelect1;
        private ReadWriteCommand cmSMJENESelect4;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private DbParameter[] fillDataParameters;
        private StatementType Gx_mode;
        private object m__OPISSMJENEOriginal;
        private object m__POCETAKOriginal;
        private object m__ZAVRSETAKOriginal;
        private readonly string m_SelectString248 = "TM1.[IDSMJENE], TM1.[OPISSMJENE], TM1.[POCETAK], TM1.[ZAVRSETAK]";
        private string m_WhereString;
        private short RcdFound248;
        private int recordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private SMJENEDataSet.SMJENERow rowSMJENE;
        private string scmdbuf;
        private IDataReader SMJENESelect1;
        private IDataReader SMJENESelect4;
        private SMJENEDataSet SMJENESet;
        private StatementType sMode248;

        public event SMJENEUpdateEventHandler SMJENEUpdated;

        public event SMJENEUpdateEventHandler SMJENEUpdating;

        private void AddRowSmjene()
        {
            this.SMJENESet.SMJENE.AddSMJENERow(this.rowSMJENE);
        }

        private void AfterConfirmSmjene()
        {
            this.OnSMJENEUpdating(new SMJENEEventArgs(this.rowSMJENE, this.Gx_mode));
        }

        private void CheckDeleteErrorsSmjene()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT TOP 1 [MJESEC], [IDGODINE], [BROJEVIDENCIJE], [IDRADNIK], [DAN] FROM [EVIDENCIJARADNICISATI] WITH (NOLOCK) WHERE [DRUGASMJENAIDSMJENE] = @IDSMJENE ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSMJENE", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSMJENE["IDSMJENE"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                reader.Close();
                throw new EVIDENCIJARADNICISATIInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "SATI" }));
            }
            reader.Close();
            ReadWriteCommand command2 = this.connDefault.GetCommand("SELECT TOP 1 [MJESEC], [IDGODINE], [BROJEVIDENCIJE], [IDRADNIK], [DAN] FROM [EVIDENCIJARADNICISATI] WITH (NOLOCK) WHERE [PRVASMJENAIDSMJENE] = @IDSMJENE ", false);
            if (command2.IDbCommand.Parameters.Count == 0)
            {
                command2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSMJENE", DbType.Int32));
            }
            command2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSMJENE["IDSMJENE"]));
            IDataReader reader2 = command2.FetchData();
            if (command2.HasMoreRows)
            {
                reader2.Close();
                throw new EVIDENCIJARADNICISATIInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "SATI" }));
            }
            reader2.Close();
        }

        private void CheckOptimisticConcurrencySmjene()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDSMJENE], [OPISSMJENE], [POCETAK], [ZAVRSETAK] FROM [SMJENE] WITH (UPDLOCK) WHERE [IDSMJENE] = @IDSMJENE ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSMJENE", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSMJENE["IDSMJENE"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new SMJENEDataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("SMJENE") }));
                }
                if ((!command.HasMoreRows || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__OPISSMJENEOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1)))) || (!StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__POCETAKOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 2))) || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__ZAVRSETAKOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 3)))))
                {
                    reader.Close();
                    throw new SMJENEDataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("SMJENE") }));
                }
                reader.Close();
            }
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        private void CreateNewRowSmjene()
        {
            this.rowSMJENE = this.SMJENESet.SMJENE.NewSMJENERow();
        }

        private void Delete()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencySmjene();
            this.AfterConfirmSmjene();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [SMJENE]  WHERE [IDSMJENE] = @IDSMJENE", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSMJENE", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSMJENE["IDSMJENE"]));
            command.ExecuteStmt();
            if (command.ForeignKeyError)
            {
                this.CheckDeleteErrorsSmjene();
            }
            this.OnSMJENEUpdated(new SMJENEEventArgs(this.rowSMJENE, StatementType.Delete));
            this.rowSMJENE.Delete();
            this.sMode248 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode248;
        }

        public virtual int Fill(SMJENEDataSet dataSet)
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
                    this.SMJENESet = dataSet;
                    this.LoadChildSmjene(0, -1);
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
            this.SMJENESet = (SMJENEDataSet) dataSet;
            if (this.SMJENESet != null)
            {
                return this.Fill(this.SMJENESet);
            }
            this.SMJENESet = new SMJENEDataSet();
            this.Fill(this.SMJENESet);
            dataSet.Merge(this.SMJENESet);
            return 0;
        }

        public virtual int Fill(SMJENEDataSet dataSet, DataRow dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDSMJENE"]));
        }

        public virtual int Fill(SMJENEDataSet dataSet, IDataRecord dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDSMJENE"]));
        }

        public virtual int Fill(SMJENEDataSet dataSet, int iDSMJENE)
        {
            if (!this.FillByIDSMJENE(dataSet, iDSMJENE))
            {
                throw new SMJENENotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("SMJENE") }));
            }
            return 0;
        }

        public virtual bool FillByIDSMJENE(SMJENEDataSet dataSet, int iDSMJENE)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.SMJENESet = dataSet;
            this.rowSMJENE = this.SMJENESet.SMJENE.NewSMJENERow();
            this.rowSMJENE.IDSMJENE = iDSMJENE;
            try
            {
                this.LoadByIDSMJENE(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            if (this.RcdFound248 == 0)
            {
                return false;
            }
            return true;
        }

        public virtual int FillPage(SMJENEDataSet dataSet, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.SMJENESet = dataSet;
            try
            {
                this.LoadChildSmjene(startRow, maxRows);
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
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDSMJENE], [OPISSMJENE], [POCETAK], [ZAVRSETAK] FROM [SMJENE] WITH (NOLOCK) WHERE [IDSMJENE] = @IDSMJENE ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSMJENE", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSMJENE["IDSMJENE"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.RcdFound248 = 1;
                this.rowSMJENE["IDSMJENE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 0));
                this.rowSMJENE["OPISSMJENE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1));
                this.rowSMJENE["POCETAK"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 2));
                this.rowSMJENE["ZAVRSETAK"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 3));
                this.sMode248 = this.Gx_mode;
                this.Gx_mode = StatementType.Select;
                this.Gx_mode = this.sMode248;
            }
            else
            {
                this.RcdFound248 = 0;
            }
            reader.Close();
        }

        public virtual IDataParameter[] GetFillParameters()
        {
            if (this.fillDataParameters == null)
            {
                DbParameter parameter = DbProviderFactories.GetFactory("System.Data.SqlClient").CreateParameter();
                parameter.ParameterName = "IDSMJENE";
                parameter.DbType = DbType.Int32;
                this.fillDataParameters = new DbParameter[] { parameter };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount()
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmSMJENESelect1 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [SMJENE] WITH (NOLOCK) ", false);
            this.SMJENESelect1 = this.cmSMJENESelect1.FetchData();
            if (this.SMJENESelect1.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.SMJENESelect1.GetInt32(0);
            }
            this.SMJENESelect1.Close();
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
            this.RcdFound248 = 0;
            this.scmdbuf = "";
            this.recordCount = 0;
            this._Gxremove = false;
            this.m__OPISSMJENEOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__POCETAKOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__ZAVRSETAKOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m_WhereString = "";
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void InitializeMembers()
        {
            this.SMJENESet = new SMJENEDataSet();
            this.Initialize();
            this.dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        }

        private void InsertSmjene()
        {
            this.CheckOptimisticConcurrencySmjene();
            this.AfterConfirmSmjene();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [SMJENE] ([IDSMJENE], [OPISSMJENE], [POCETAK], [ZAVRSETAK]) VALUES (@IDSMJENE, @OPISSMJENE, @POCETAK, @ZAVRSETAK)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSMJENE", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OPISSMJENE", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@POCETAK", DbType.String));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZAVRSETAK", DbType.String));
            }
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSMJENE["IDSMJENE"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowSMJENE["OPISSMJENE"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowSMJENE["POCETAK"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowSMJENE["ZAVRSETAK"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new SMJENEDuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            this.OnSMJENEUpdated(new SMJENEEventArgs(this.rowSMJENE, StatementType.Insert));
        }

        private void LoadByIDSMJENE(int startRow, int maxRows)
        {
            bool enforceConstraints = this.SMJENESet.EnforceConstraints;
            this.SMJENESet.SMJENE.BeginLoadData();
            this.ScanByIDSMJENE(startRow, maxRows);
            this.SMJENESet.SMJENE.EndLoadData();
            this.SMJENESet.EnforceConstraints = enforceConstraints;
            if (this.SMJENESet.SMJENE.Count > 0)
            {
                this.rowSMJENE = this.SMJENESet.SMJENE[this.SMJENESet.SMJENE.Count - 1];
            }
        }

        private void LoadChildSmjene(int startRow, int maxRows)
        {
            this.CreateNewRowSmjene();
            bool enforceConstraints = this.SMJENESet.EnforceConstraints;
            this.SMJENESet.SMJENE.BeginLoadData();
            this.ScanStartSmjene(startRow, maxRows);
            this.SMJENESet.SMJENE.EndLoadData();
            this.SMJENESet.EnforceConstraints = enforceConstraints;
        }

        private void LoadDataSmjene(int maxRows)
        {
            int num = 0;
            if (this.RcdFound248 != 0)
            {
                this.ScanLoadSmjene();
                while ((this.RcdFound248 != 0) && (num != maxRows))
                {
                    num++;
                    this.LoadRowSmjene();
                    this.CreateNewRowSmjene();
                    this.ScanNextSmjene();
                }
            }
            if (num > 0)
            {
                this.RcdFound248 = 1;
            }
            this.ScanEndSmjene();
            if (this.SMJENESet.SMJENE.Count > 0)
            {
                this.rowSMJENE = this.SMJENESet.SMJENE[this.SMJENESet.SMJENE.Count - 1];
            }
        }

        private void LoadRowSmjene()
        {
            this.AddRowSmjene();
        }

        private void OnSMJENEUpdated(SMJENEEventArgs e)
        {
            if (this.SMJENEUpdated != null)
            {
                SMJENEUpdateEventHandler sMJENEUpdatedEvent = this.SMJENEUpdated;
                if (sMJENEUpdatedEvent != null)
                {
                    sMJENEUpdatedEvent(this, e);
                }
            }
        }

        private void OnSMJENEUpdating(SMJENEEventArgs e)
        {
            if (this.SMJENEUpdating != null)
            {
                SMJENEUpdateEventHandler sMJENEUpdatingEvent = this.SMJENEUpdating;
                if (sMJENEUpdatingEvent != null)
                {
                    sMJENEUpdatingEvent(this, e);
                }
            }
        }

        private void ReadRowSmjene()
        {
            this.Gx_mode = Mode.FromRowState(this.rowSMJENE.RowState);
            if (this.rowSMJENE.RowState != DataRowState.Added)
            {
                this.m__OPISSMJENEOriginal = RuntimeHelpers.GetObjectValue(this.rowSMJENE["OPISSMJENE", DataRowVersion.Original]);
                this.m__POCETAKOriginal = RuntimeHelpers.GetObjectValue(this.rowSMJENE["POCETAK", DataRowVersion.Original]);
                this.m__ZAVRSETAKOriginal = RuntimeHelpers.GetObjectValue(this.rowSMJENE["ZAVRSETAK", DataRowVersion.Original]);
            }
            else
            {
                this.m__OPISSMJENEOriginal = RuntimeHelpers.GetObjectValue(this.rowSMJENE["OPISSMJENE"]);
                this.m__POCETAKOriginal = RuntimeHelpers.GetObjectValue(this.rowSMJENE["POCETAK"]);
                this.m__ZAVRSETAKOriginal = RuntimeHelpers.GetObjectValue(this.rowSMJENE["ZAVRSETAK"]);
            }
            this._Gxremove = this.rowSMJENE.RowState == DataRowState.Deleted;
            if (this._Gxremove)
            {
                this.rowSMJENE = (SMJENEDataSet.SMJENERow) DataSetUtil.CloneOriginalDataRow(this.rowSMJENE);
            }
        }

        private void ScanByIDSMJENE(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[IDSMJENE] = @IDSMJENE";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString248 + "  FROM [SMJENE] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDSMJENE]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString248, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDSMJENE] ) AS DK_PAGENUM   FROM [SMJENE] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString248 + " FROM [SMJENE] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDSMJENE] ";
            }
            this.cmSMJENESelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmSMJENESelect4.IDbCommand.Parameters.Count == 0)
            {
                this.cmSMJENESelect4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSMJENE", DbType.Int32));
            }
            this.cmSMJENESelect4.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSMJENE["IDSMJENE"]));
            this.SMJENESelect4 = this.cmSMJENESelect4.FetchData();
            this.RcdFound248 = 0;
            this.ScanLoadSmjene();
            this.LoadDataSmjene(maxRows);
        }

        private void ScanEndSmjene()
        {
            this.SMJENESelect4.Close();
        }

        private void ScanLoadSmjene()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmSMJENESelect4.HasMoreRows)
            {
                this.RcdFound248 = 1;
                this.rowSMJENE["IDSMJENE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.SMJENESelect4, 0));
                this.rowSMJENE["OPISSMJENE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.SMJENESelect4, 1));
                this.rowSMJENE["POCETAK"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.SMJENESelect4, 2));
                this.rowSMJENE["ZAVRSETAK"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.SMJENESelect4, 3));
            }
        }

        private void ScanNextSmjene()
        {
            this.cmSMJENESelect4.HasMoreRows = this.SMJENESelect4.Read();
            this.RcdFound248 = 0;
            this.ScanLoadSmjene();
        }

        private void ScanStartSmjene(int startRow, int maxRows)
        {
            this.m_WhereString = "";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString248 + "  FROM [SMJENE] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDSMJENE]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString248, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDSMJENE] ) AS DK_PAGENUM   FROM [SMJENE] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString248 + " FROM [SMJENE] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDSMJENE] ";
            }
            this.cmSMJENESelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            this.SMJENESelect4 = this.cmSMJENESelect4.FetchData();
            this.RcdFound248 = 0;
            this.ScanLoadSmjene();
            this.LoadDataSmjene(maxRows);
        }

        public virtual int Update(DataSet dataSet)
        {
            this.InitializeMembers();
            this.SMJENESet = (SMJENEDataSet) dataSet;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            if (this.SMJENESet == null)
            {
                throw new ArgumentException(this.resourceManager.GetString("nulldset"));
            }
            try
            {
                IEnumerator enumerator = null;
                this.connDefault.BeginTransaction();
                try
                {
                    enumerator = this.SMJENESet.SMJENE.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        SMJENEDataSet.SMJENERow current = (SMJENEDataSet.SMJENERow) enumerator.Current;
                        this.rowSMJENE = current;
                        if (Helpers.IsRowChanged(this.rowSMJENE))
                        {
                            this.ReadRowSmjene();
                            if (this.rowSMJENE.RowState == DataRowState.Added)
                            {
                                this.InsertSmjene();
                            }
                            else
                            {
                                if (this._Gxremove)
                                {
                                    this.Delete();
                                    continue;
                                }
                                this.UpdateSmjene();
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

        private void UpdateSmjene()
        {
            this.CheckOptimisticConcurrencySmjene();
            this.AfterConfirmSmjene();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [SMJENE] SET [OPISSMJENE]=@OPISSMJENE, [POCETAK]=@POCETAK, [ZAVRSETAK]=@ZAVRSETAK  WHERE [IDSMJENE] = @IDSMJENE", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OPISSMJENE", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@POCETAK", DbType.String));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZAVRSETAK", DbType.String));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSMJENE", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSMJENE["OPISSMJENE"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowSMJENE["POCETAK"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowSMJENE["ZAVRSETAK"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowSMJENE["IDSMJENE"]));
            command.ExecuteStmt();
            this.OnSMJENEUpdated(new SMJENEEventArgs(this.rowSMJENE, StatementType.Update));
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
        public class EVIDENCIJARADNICISATIInvalidDeleteException : InvalidDeleteException
        {
            public EVIDENCIJARADNICISATIInvalidDeleteException()
            {
            }

            public EVIDENCIJARADNICISATIInvalidDeleteException(string message) : base(message)
            {
            }

            protected EVIDENCIJARADNICISATIInvalidDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public EVIDENCIJARADNICISATIInvalidDeleteException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class SMJENEDataChangedException : DataChangedException
        {
            public SMJENEDataChangedException()
            {
            }

            public SMJENEDataChangedException(string message) : base(message)
            {
            }

            protected SMJENEDataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public SMJENEDataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class SMJENEDataLockedException : DataLockedException
        {
            public SMJENEDataLockedException()
            {
            }

            public SMJENEDataLockedException(string message) : base(message)
            {
            }

            protected SMJENEDataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public SMJENEDataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class SMJENEDuplicateKeyException : DuplicateKeyException
        {
            public SMJENEDuplicateKeyException()
            {
            }

            public SMJENEDuplicateKeyException(string message) : base(message)
            {
            }

            protected SMJENEDuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public SMJENEDuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class SMJENEEventArgs : EventArgs
        {
            private SMJENEDataSet.SMJENERow m_dataRow;
            private System.Data.StatementType m_statementType;

            public SMJENEEventArgs(SMJENEDataSet.SMJENERow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public SMJENEDataSet.SMJENERow Row
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
        public class SMJENENotFoundException : DataNotFoundException
        {
            public SMJENENotFoundException()
            {
            }

            public SMJENENotFoundException(string message) : base(message)
            {
            }

            protected SMJENENotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public SMJENENotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public delegate void SMJENEUpdateEventHandler(object sender, SMJENEDataAdapter.SMJENEEventArgs e);
    }
}


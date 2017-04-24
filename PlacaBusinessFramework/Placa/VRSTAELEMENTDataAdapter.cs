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

    public class VRSTAELEMENTDataAdapter : IDataAdapter, IVRSTAELEMENTDataAdapter
    {
        private bool _Gxremove;
        private ReadWriteCommand cmVRSTAELEMENTSelect1;
        private ReadWriteCommand cmVRSTAELEMENTSelect4;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private DbParameter[] fillDataParameters;
        private StatementType Gx_mode;
        private object m__NAZIVVRSTAELEMENTOriginal;
        private readonly string m_SelectString55 = "TM1.[IDVRSTAELEMENTA], TM1.[NAZIVVRSTAELEMENT]";
        private string m_WhereString;
        private short RcdFound55;
        private int recordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private VRSTAELEMENTDataSet.VRSTAELEMENTRow rowVRSTAELEMENT;
        private string scmdbuf;
        private StatementType sMode55;
        private IDataReader VRSTAELEMENTSelect1;
        private IDataReader VRSTAELEMENTSelect4;
        private VRSTAELEMENTDataSet VRSTAELEMENTSet;

        public event VRSTAELEMENTUpdateEventHandler VRSTAELEMENTUpdated;

        public event VRSTAELEMENTUpdateEventHandler VRSTAELEMENTUpdating;

        private void AddRowVrstaelement()
        {
            this.VRSTAELEMENTSet.VRSTAELEMENT.AddVRSTAELEMENTRow(this.rowVRSTAELEMENT);
        }

        private void AfterConfirmVrstaelement()
        {
            this.OnVRSTAELEMENTUpdating(new VRSTAELEMENTEventArgs(this.rowVRSTAELEMENT, this.Gx_mode));
        }

        private void CheckDeleteErrorsVrstaelement()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT TOP 1 [IDELEMENT] FROM [ELEMENT] WITH (NOLOCK) WHERE [IDVRSTAELEMENTA] = @IDVRSTAELEMENTA ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDVRSTAELEMENTA", DbType.Int16));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowVRSTAELEMENT["IDVRSTAELEMENTA"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                reader.Close();
                throw new ELEMENTInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "ELEMENT" }));
            }
            reader.Close();
        }

        private void CheckOptimisticConcurrencyVrstaelement()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDVRSTAELEMENTA], [NAZIVVRSTAELEMENT] FROM [VRSTAELEMENT] WITH (UPDLOCK) WHERE [IDVRSTAELEMENTA] = @IDVRSTAELEMENTA ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDVRSTAELEMENTA", DbType.Int16));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowVRSTAELEMENT["IDVRSTAELEMENTA"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new VRSTAELEMENTDataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("VRSTAELEMENT") }));
                }
                if (!command.HasMoreRows || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__NAZIVVRSTAELEMENTOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1))))
                {
                    reader.Close();
                    throw new VRSTAELEMENTDataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("VRSTAELEMENT") }));
                }
                reader.Close();
            }
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        private void CreateNewRowVrstaelement()
        {
            this.rowVRSTAELEMENT = this.VRSTAELEMENTSet.VRSTAELEMENT.NewVRSTAELEMENTRow();
        }

        private void Delete()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyVrstaelement();
            this.AfterConfirmVrstaelement();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [VRSTAELEMENT]  WHERE [IDVRSTAELEMENTA] = @IDVRSTAELEMENTA", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDVRSTAELEMENTA", DbType.Int16));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowVRSTAELEMENT["IDVRSTAELEMENTA"]));
            command.ExecuteStmt();
            if (command.ForeignKeyError)
            {
                this.CheckDeleteErrorsVrstaelement();
            }
            this.OnVRSTAELEMENTUpdated(new VRSTAELEMENTEventArgs(this.rowVRSTAELEMENT, StatementType.Delete));
            this.rowVRSTAELEMENT.Delete();
            this.sMode55 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode55;
        }

        public virtual int Fill(VRSTAELEMENTDataSet dataSet)
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
                    this.VRSTAELEMENTSet = dataSet;
                    this.LoadChildVrstaelement(0, -1);
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
            this.VRSTAELEMENTSet = (VRSTAELEMENTDataSet) dataSet;
            if (this.VRSTAELEMENTSet != null)
            {
                return this.Fill(this.VRSTAELEMENTSet);
            }
            this.VRSTAELEMENTSet = new VRSTAELEMENTDataSet();
            this.Fill(this.VRSTAELEMENTSet);
            dataSet.Merge(this.VRSTAELEMENTSet);
            return 0;
        }

        public virtual int Fill(VRSTAELEMENTDataSet dataSet, DataRow dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToShort(dataRecord["IDVRSTAELEMENTA"]));
        }

        public virtual int Fill(VRSTAELEMENTDataSet dataSet, IDataRecord dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToShort(dataRecord["IDVRSTAELEMENTA"]));
        }

        public virtual int Fill(VRSTAELEMENTDataSet dataSet, short iDVRSTAELEMENTA)
        {
            if (!this.FillByIDVRSTAELEMENTA(dataSet, iDVRSTAELEMENTA))
            {
                throw new VRSTAELEMENTNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("VRSTAELEMENT") }));
            }
            return 0;
        }

        public virtual bool FillByIDVRSTAELEMENTA(VRSTAELEMENTDataSet dataSet, short iDVRSTAELEMENTA)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.VRSTAELEMENTSet = dataSet;
            this.rowVRSTAELEMENT = this.VRSTAELEMENTSet.VRSTAELEMENT.NewVRSTAELEMENTRow();
            this.rowVRSTAELEMENT.IDVRSTAELEMENTA = iDVRSTAELEMENTA;
            try
            {
                this.LoadByIDVRSTAELEMENTA(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            if (this.RcdFound55 == 0)
            {
                return false;
            }
            return true;
        }

        public virtual int FillPage(VRSTAELEMENTDataSet dataSet, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.VRSTAELEMENTSet = dataSet;
            try
            {
                this.LoadChildVrstaelement(startRow, maxRows);
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
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDVRSTAELEMENTA], [NAZIVVRSTAELEMENT] FROM [VRSTAELEMENT] WITH (NOLOCK) WHERE [IDVRSTAELEMENTA] = @IDVRSTAELEMENTA ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDVRSTAELEMENTA", DbType.Int16));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowVRSTAELEMENT["IDVRSTAELEMENTA"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.RcdFound55 = 1;
                this.rowVRSTAELEMENT["IDVRSTAELEMENTA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt16(reader, 0));
                this.rowVRSTAELEMENT["NAZIVVRSTAELEMENT"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1));
                this.sMode55 = this.Gx_mode;
                this.Gx_mode = StatementType.Select;
                this.Gx_mode = this.sMode55;
            }
            else
            {
                this.RcdFound55 = 0;
            }
            reader.Close();
        }

        public virtual IDataParameter[] GetFillParameters()
        {
            if (this.fillDataParameters == null)
            {
                DbParameter parameter = DbProviderFactories.GetFactory("System.Data.SqlClient").CreateParameter();
                parameter.ParameterName = "IDVRSTAELEMENTA";
                parameter.DbType = DbType.Int16;
                this.fillDataParameters = new DbParameter[] { parameter };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount()
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmVRSTAELEMENTSelect1 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [VRSTAELEMENT] WITH (NOLOCK) ", false);
            this.VRSTAELEMENTSelect1 = this.cmVRSTAELEMENTSelect1.FetchData();
            if (this.VRSTAELEMENTSelect1.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.VRSTAELEMENTSelect1.GetInt32(0);
            }
            this.VRSTAELEMENTSelect1.Close();
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
            this.RcdFound55 = 0;
            this.scmdbuf = "";
            this.recordCount = 0;
            this._Gxremove = false;
            this.m__NAZIVVRSTAELEMENTOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m_WhereString = "";
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void InitializeMembers()
        {
            this.VRSTAELEMENTSet = new VRSTAELEMENTDataSet();
            this.Initialize();
            this.dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        }

        private void InsertVrstaelement()
        {
            this.CheckOptimisticConcurrencyVrstaelement();
            this.AfterConfirmVrstaelement();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [VRSTAELEMENT] ([IDVRSTAELEMENTA], [NAZIVVRSTAELEMENT]) VALUES (@IDVRSTAELEMENTA, @NAZIVVRSTAELEMENT)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDVRSTAELEMENTA", DbType.Int16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVVRSTAELEMENT", DbType.String, 0x19));
            }
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowVRSTAELEMENT["IDVRSTAELEMENTA"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowVRSTAELEMENT["NAZIVVRSTAELEMENT"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new VRSTAELEMENTDuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            this.OnVRSTAELEMENTUpdated(new VRSTAELEMENTEventArgs(this.rowVRSTAELEMENT, StatementType.Insert));
        }

        private void LoadByIDVRSTAELEMENTA(int startRow, int maxRows)
        {
            bool enforceConstraints = this.VRSTAELEMENTSet.EnforceConstraints;
            this.VRSTAELEMENTSet.VRSTAELEMENT.BeginLoadData();
            this.ScanByIDVRSTAELEMENTA(startRow, maxRows);
            this.VRSTAELEMENTSet.VRSTAELEMENT.EndLoadData();
            this.VRSTAELEMENTSet.EnforceConstraints = enforceConstraints;
            if (this.VRSTAELEMENTSet.VRSTAELEMENT.Count > 0)
            {
                this.rowVRSTAELEMENT = this.VRSTAELEMENTSet.VRSTAELEMENT[this.VRSTAELEMENTSet.VRSTAELEMENT.Count - 1];
            }
        }

        private void LoadChildVrstaelement(int startRow, int maxRows)
        {
            this.CreateNewRowVrstaelement();
            bool enforceConstraints = this.VRSTAELEMENTSet.EnforceConstraints;
            this.VRSTAELEMENTSet.VRSTAELEMENT.BeginLoadData();
            this.ScanStartVrstaelement(startRow, maxRows);
            this.VRSTAELEMENTSet.VRSTAELEMENT.EndLoadData();
            this.VRSTAELEMENTSet.EnforceConstraints = enforceConstraints;
        }

        private void LoadDataVrstaelement(int maxRows)
        {
            int num = 0;
            if (this.RcdFound55 != 0)
            {
                this.ScanLoadVrstaelement();
                while ((this.RcdFound55 != 0) && (num != maxRows))
                {
                    num++;
                    this.LoadRowVrstaelement();
                    this.CreateNewRowVrstaelement();
                    this.ScanNextVrstaelement();
                }
            }
            if (num > 0)
            {
                this.RcdFound55 = 1;
            }
            this.ScanEndVrstaelement();
            if (this.VRSTAELEMENTSet.VRSTAELEMENT.Count > 0)
            {
                this.rowVRSTAELEMENT = this.VRSTAELEMENTSet.VRSTAELEMENT[this.VRSTAELEMENTSet.VRSTAELEMENT.Count - 1];
            }
        }

        private void LoadRowVrstaelement()
        {
            this.AddRowVrstaelement();
        }

        private void OnVRSTAELEMENTUpdated(VRSTAELEMENTEventArgs e)
        {
            if (this.VRSTAELEMENTUpdated != null)
            {
                VRSTAELEMENTUpdateEventHandler vRSTAELEMENTUpdatedEvent = this.VRSTAELEMENTUpdated;
                if (vRSTAELEMENTUpdatedEvent != null)
                {
                    vRSTAELEMENTUpdatedEvent(this, e);
                }
            }
        }

        private void OnVRSTAELEMENTUpdating(VRSTAELEMENTEventArgs e)
        {
            if (this.VRSTAELEMENTUpdating != null)
            {
                VRSTAELEMENTUpdateEventHandler vRSTAELEMENTUpdatingEvent = this.VRSTAELEMENTUpdating;
                if (vRSTAELEMENTUpdatingEvent != null)
                {
                    vRSTAELEMENTUpdatingEvent(this, e);
                }
            }
        }

        private void ReadRowVrstaelement()
        {
            this.Gx_mode = Mode.FromRowState(this.rowVRSTAELEMENT.RowState);
            if (this.rowVRSTAELEMENT.RowState != DataRowState.Added)
            {
                this.m__NAZIVVRSTAELEMENTOriginal = RuntimeHelpers.GetObjectValue(this.rowVRSTAELEMENT["NAZIVVRSTAELEMENT", DataRowVersion.Original]);
            }
            else
            {
                this.m__NAZIVVRSTAELEMENTOriginal = RuntimeHelpers.GetObjectValue(this.rowVRSTAELEMENT["NAZIVVRSTAELEMENT"]);
            }
            this._Gxremove = this.rowVRSTAELEMENT.RowState == DataRowState.Deleted;
            if (this._Gxremove)
            {
                this.rowVRSTAELEMENT = (VRSTAELEMENTDataSet.VRSTAELEMENTRow) DataSetUtil.CloneOriginalDataRow(this.rowVRSTAELEMENT);
            }
        }

        private void ScanByIDVRSTAELEMENTA(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[IDVRSTAELEMENTA] = @IDVRSTAELEMENTA";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString55 + "  FROM [VRSTAELEMENT] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDVRSTAELEMENTA]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString55, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDVRSTAELEMENTA] ) AS DK_PAGENUM   FROM [VRSTAELEMENT] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString55 + " FROM [VRSTAELEMENT] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDVRSTAELEMENTA] ";
            }
            this.cmVRSTAELEMENTSelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmVRSTAELEMENTSelect4.IDbCommand.Parameters.Count == 0)
            {
                this.cmVRSTAELEMENTSelect4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDVRSTAELEMENTA", DbType.Int16));
            }
            this.cmVRSTAELEMENTSelect4.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowVRSTAELEMENT["IDVRSTAELEMENTA"]));
            this.VRSTAELEMENTSelect4 = this.cmVRSTAELEMENTSelect4.FetchData();
            this.RcdFound55 = 0;
            this.ScanLoadVrstaelement();
            this.LoadDataVrstaelement(maxRows);
        }

        private void ScanEndVrstaelement()
        {
            this.VRSTAELEMENTSelect4.Close();
        }

        private void ScanLoadVrstaelement()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmVRSTAELEMENTSelect4.HasMoreRows)
            {
                this.RcdFound55 = 1;
                this.rowVRSTAELEMENT["IDVRSTAELEMENTA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt16(this.VRSTAELEMENTSelect4, 0));
                this.rowVRSTAELEMENT["NAZIVVRSTAELEMENT"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.VRSTAELEMENTSelect4, 1));
            }
        }

        private void ScanNextVrstaelement()
        {
            this.cmVRSTAELEMENTSelect4.HasMoreRows = this.VRSTAELEMENTSelect4.Read();
            this.RcdFound55 = 0;
            this.ScanLoadVrstaelement();
        }

        private void ScanStartVrstaelement(int startRow, int maxRows)
        {
            this.m_WhereString = "";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString55 + "  FROM [VRSTAELEMENT] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDVRSTAELEMENTA]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString55, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDVRSTAELEMENTA] ) AS DK_PAGENUM   FROM [VRSTAELEMENT] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString55 + " FROM [VRSTAELEMENT] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDVRSTAELEMENTA] ";
            }
            this.cmVRSTAELEMENTSelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            this.VRSTAELEMENTSelect4 = this.cmVRSTAELEMENTSelect4.FetchData();
            this.RcdFound55 = 0;
            this.ScanLoadVrstaelement();
            this.LoadDataVrstaelement(maxRows);
        }

        public virtual int Update(DataSet dataSet)
        {
            this.InitializeMembers();
            this.VRSTAELEMENTSet = (VRSTAELEMENTDataSet) dataSet;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            if (this.VRSTAELEMENTSet == null)
            {
                throw new ArgumentException(this.resourceManager.GetString("nulldset"));
            }
            try
            {
                IEnumerator enumerator = null;
                this.connDefault.BeginTransaction();
                try
                {
                    enumerator = this.VRSTAELEMENTSet.VRSTAELEMENT.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        VRSTAELEMENTDataSet.VRSTAELEMENTRow current = (VRSTAELEMENTDataSet.VRSTAELEMENTRow) enumerator.Current;
                        this.rowVRSTAELEMENT = current;
                        if (Helpers.IsRowChanged(this.rowVRSTAELEMENT))
                        {
                            this.ReadRowVrstaelement();
                            if (this.rowVRSTAELEMENT.RowState == DataRowState.Added)
                            {
                                this.InsertVrstaelement();
                            }
                            else
                            {
                                if (this._Gxremove)
                                {
                                    this.Delete();
                                    continue;
                                }
                                this.UpdateVrstaelement();
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

        private void UpdateVrstaelement()
        {
            this.CheckOptimisticConcurrencyVrstaelement();
            this.AfterConfirmVrstaelement();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [VRSTAELEMENT] SET [NAZIVVRSTAELEMENT]=@NAZIVVRSTAELEMENT  WHERE [IDVRSTAELEMENTA] = @IDVRSTAELEMENTA", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVVRSTAELEMENT", DbType.String, 0x19));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDVRSTAELEMENTA", DbType.Int16));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowVRSTAELEMENT["NAZIVVRSTAELEMENT"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowVRSTAELEMENT["IDVRSTAELEMENTA"]));
            command.ExecuteStmt();
            new vrstaelementupdateredundancy(ref this.dsDefault).execute(this.rowVRSTAELEMENT.IDVRSTAELEMENTA);
            this.OnVRSTAELEMENTUpdated(new VRSTAELEMENTEventArgs(this.rowVRSTAELEMENT, StatementType.Update));

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
        public class ELEMENTInvalidDeleteException : InvalidDeleteException
        {
            public ELEMENTInvalidDeleteException()
            {
            }

            public ELEMENTInvalidDeleteException(string message) : base(message)
            {
            }

            protected ELEMENTInvalidDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public ELEMENTInvalidDeleteException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class VRSTAELEMENTDataChangedException : DataChangedException
        {
            public VRSTAELEMENTDataChangedException()
            {
            }

            public VRSTAELEMENTDataChangedException(string message) : base(message)
            {
            }

            protected VRSTAELEMENTDataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public VRSTAELEMENTDataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class VRSTAELEMENTDataLockedException : DataLockedException
        {
            public VRSTAELEMENTDataLockedException()
            {
            }

            public VRSTAELEMENTDataLockedException(string message) : base(message)
            {
            }

            protected VRSTAELEMENTDataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public VRSTAELEMENTDataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class VRSTAELEMENTDuplicateKeyException : DuplicateKeyException
        {
            public VRSTAELEMENTDuplicateKeyException()
            {
            }

            public VRSTAELEMENTDuplicateKeyException(string message) : base(message)
            {
            }

            protected VRSTAELEMENTDuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public VRSTAELEMENTDuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class VRSTAELEMENTEventArgs : EventArgs
        {
            private VRSTAELEMENTDataSet.VRSTAELEMENTRow m_dataRow;
            private System.Data.StatementType m_statementType;

            public VRSTAELEMENTEventArgs(VRSTAELEMENTDataSet.VRSTAELEMENTRow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public VRSTAELEMENTDataSet.VRSTAELEMENTRow Row
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
        public class VRSTAELEMENTNotFoundException : DataNotFoundException
        {
            public VRSTAELEMENTNotFoundException()
            {
            }

            public VRSTAELEMENTNotFoundException(string message) : base(message)
            {
            }

            protected VRSTAELEMENTNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public VRSTAELEMENTNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public delegate void VRSTAELEMENTUpdateEventHandler(object sender, VRSTAELEMENTDataAdapter.VRSTAELEMENTEventArgs e);
    }
}


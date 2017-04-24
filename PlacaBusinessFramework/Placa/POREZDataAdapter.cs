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

    public class POREZDataAdapter : IDataAdapter, IPOREZDataAdapter
    {
        private bool _Condition;
        private bool _Gxremove;
        private ReadWriteCommand cmPOREZSelect1;
        private ReadWriteCommand cmPOREZSelect4;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private DbParameter[] fillDataParameters;
        private StatementType Gx_mode;
        private object m__MOPOREZOriginal;
        private object m__MZPOREZOriginal;
        private object m__NAZIVPOREZOriginal;
        private object m__OPISPLACANJAPOREZOriginal;
        private object m__POPOREZOriginal;
        private object m__POREZMJESECNOOriginal;
        private object m__PRIMATELJPOREZ1Original;
        private object m__PRIMATELJPOREZ2Original;
        private object m__PZPOREZOriginal;
        private object m__SIFRAOPISAPLACANJAPOREZOriginal;
        private object m__STOPAPOREZAOriginal;
        private readonly string m_SelectString20 = "TM1.[IDPOREZ], TM1.[NAZIVPOREZ], TM1.[POREZMJESECNO], TM1.[STOPAPOREZA], TM1.[MOPOREZ], TM1.[POPOREZ], TM1.[MZPOREZ], TM1.[PZPOREZ], TM1.[PRIMATELJPOREZ1], TM1.[PRIMATELJPOREZ2], TM1.[SIFRAOPISAPLACANJAPOREZ], TM1.[OPISPLACANJAPOREZ]";
        private string m_WhereString;
        private IDataReader POREZSelect1;
        private IDataReader POREZSelect4;
        private POREZDataSet POREZSet;
        private short RcdFound20;
        private int recordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private POREZDataSet.POREZRow rowPOREZ;
        private string scmdbuf;
        private StatementType sMode20;

        public event POREZUpdateEventHandler POREZUpdated;

        public event POREZUpdateEventHandler POREZUpdating;

        private void AddRowPorez()
        {
            this.POREZSet.POREZ.AddPOREZRow(this.rowPOREZ);
        }

        private void AfterConfirmPorez()
        {
            this.OnPOREZUpdating(new POREZEventArgs(this.rowPOREZ, this.Gx_mode));
        }

        private void CheckDeleteErrorsPorez()
        {
            ReadWriteCommand command2 = this.connDefault.GetCommand("SELECT TOP 1 [DDOBRACUNIDOBRACUN], [DDIDRADNIK], [IDPOREZ] FROM [DDOBRACUNRadniciPorezi] WITH (NOLOCK) WHERE [IDPOREZ] = @IDPOREZ ", false);
            if (command2.IDbCommand.Parameters.Count == 0)
            {
                command2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDPOREZ", DbType.Int32));
            }
            command2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowPOREZ["IDPOREZ"]));
            IDataReader reader2 = command2.FetchData();
            if (command2.HasMoreRows)
            {
                reader2.Close();
                throw new DDOBRACUNRadniciPoreziInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "Porezi" }));
            }
            reader2.Close();
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT TOP 1 [IDKATEGORIJA], [IDPOREZ] FROM [DDKATEGORIJALevel1] WITH (NOLOCK) WHERE [IDPOREZ] = @IDPOREZ ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDPOREZ", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowPOREZ["IDPOREZ"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                reader.Close();
                throw new DDKATEGORIJALevel1InvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "Level1" }));
            }
            reader.Close();
            ReadWriteCommand command4 = this.connDefault.GetCommand("SELECT TOP 1 [IDSKUPPOREZAIDOPRINOSA], [IDPOREZ] FROM [SKUPPOREZAIDOPRINOSA1] WITH (NOLOCK) WHERE [IDPOREZ] = @IDPOREZ ", false);
            if (command4.IDbCommand.Parameters.Count == 0)
            {
                command4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDPOREZ", DbType.Int32));
            }
            command4.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowPOREZ["IDPOREZ"]));
            IDataReader reader4 = command4.FetchData();
            if (command4.HasMoreRows)
            {
                reader4.Close();
                throw new SKUPPOREZAIDOPRINOSA1InvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "SKUPPOREZAIDOPRINOSA1" }));
            }
            reader4.Close();
            ReadWriteCommand command3 = this.connDefault.GetCommand("SELECT TOP 1 [IDOBRACUN], [IDRADNIK], [IDPOREZ] FROM [ObracunPorezi] WITH (NOLOCK) WHERE [IDPOREZ] = @IDPOREZ ", false);
            if (command3.IDbCommand.Parameters.Count == 0)
            {
                command3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDPOREZ", DbType.Int32));
            }
            command3.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowPOREZ["IDPOREZ"]));
            IDataReader reader3 = command3.FetchData();
            if (command3.HasMoreRows)
            {
                reader3.Close();
                throw new ObracunPoreziInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "ObracunPorezi" }));
            }
            reader3.Close();
        }

        private void CheckOptimisticConcurrencyPorez()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDPOREZ], [NAZIVPOREZ], [POREZMJESECNO], [STOPAPOREZA], [MOPOREZ], [POPOREZ], [MZPOREZ], [PZPOREZ], [PRIMATELJPOREZ1], [PRIMATELJPOREZ2], [SIFRAOPISAPLACANJAPOREZ], [OPISPLACANJAPOREZ] FROM [POREZ] WITH (UPDLOCK) WHERE [IDPOREZ] = @IDPOREZ ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDPOREZ", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowPOREZ["IDPOREZ"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new POREZDataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("POREZ") }));
                }
                this._Condition = false;
                if ((!command.HasMoreRows || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__NAZIVPOREZOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1)))) || ((!this.m__POREZMJESECNOOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 2))) || !this.m__STOPAPOREZAOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 3)))) || (!StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__MOPOREZOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 4))) || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__POPOREZOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 5))))))
                {
                    this._Condition = true;
                }
                if ((this._Condition || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__MZPOREZOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 6)))) || (!StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__PZPOREZOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 7))) || ((!StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__PRIMATELJPOREZ1Original), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 8))) || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__PRIMATELJPOREZ2Original), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 9)))) || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__SIFRAOPISAPLACANJAPOREZOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 10))))))
                {
                    this._Condition = true;
                }
                if (this._Condition || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__OPISPLACANJAPOREZOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 11))))
                {
                    reader.Close();
                    throw new POREZDataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("POREZ") }));
                }
                reader.Close();
            }
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        private void CreateNewRowPorez()
        {
            this.rowPOREZ = this.POREZSet.POREZ.NewPOREZRow();
        }

        private void Delete()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyPorez();
            this.AfterConfirmPorez();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [POREZ]  WHERE [IDPOREZ] = @IDPOREZ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDPOREZ", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowPOREZ["IDPOREZ"]));
            command.ExecuteStmt();
            if (command.ForeignKeyError)
            {
                this.CheckDeleteErrorsPorez();
            }
            this.OnPOREZUpdated(new POREZEventArgs(this.rowPOREZ, StatementType.Delete));
            this.rowPOREZ.Delete();
            this.sMode20 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode20;
        }

        public virtual int Fill(POREZDataSet dataSet)
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
                    this.POREZSet = dataSet;
                    this.LoadChildPorez(0, -1);
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
            this.POREZSet = (POREZDataSet) dataSet;
            if (this.POREZSet != null)
            {
                return this.Fill(this.POREZSet);
            }
            this.POREZSet = new POREZDataSet();
            this.Fill(this.POREZSet);
            dataSet.Merge(this.POREZSet);
            return 0;
        }

        public virtual int Fill(POREZDataSet dataSet, DataRow dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDPOREZ"]));
        }

        public virtual int Fill(POREZDataSet dataSet, IDataRecord dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDPOREZ"]));
        }

        public virtual int Fill(POREZDataSet dataSet, int iDPOREZ)
        {
            if (!this.FillByIDPOREZ(dataSet, iDPOREZ))
            {
                throw new POREZNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("POREZ") }));
            }
            return 0;
        }

        public virtual bool FillByIDPOREZ(POREZDataSet dataSet, int iDPOREZ)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.POREZSet = dataSet;
            this.rowPOREZ = this.POREZSet.POREZ.NewPOREZRow();
            this.rowPOREZ.IDPOREZ = iDPOREZ;
            try
            {
                this.LoadByIDPOREZ(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            if (this.RcdFound20 == 0)
            {
                return false;
            }
            return true;
        }

        public virtual int FillPage(POREZDataSet dataSet, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.POREZSet = dataSet;
            try
            {
                this.LoadChildPorez(startRow, maxRows);
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
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDPOREZ], [NAZIVPOREZ], [POREZMJESECNO], [STOPAPOREZA], [MOPOREZ], [POPOREZ], [MZPOREZ], [PZPOREZ], [PRIMATELJPOREZ1], [PRIMATELJPOREZ2], [SIFRAOPISAPLACANJAPOREZ], [OPISPLACANJAPOREZ] FROM [POREZ] WITH (NOLOCK) WHERE [IDPOREZ] = @IDPOREZ ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDPOREZ", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowPOREZ["IDPOREZ"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.RcdFound20 = 1;
                this.rowPOREZ["IDPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 0));
                this.rowPOREZ["NAZIVPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1));
                this.rowPOREZ["POREZMJESECNO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 2));
                this.rowPOREZ["STOPAPOREZA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 3));
                this.rowPOREZ["MOPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 4));
                this.rowPOREZ["POPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 5));
                this.rowPOREZ["MZPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 6));
                this.rowPOREZ["PZPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 7));
                this.rowPOREZ["PRIMATELJPOREZ1"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 8));
                this.rowPOREZ["PRIMATELJPOREZ2"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 9));
                this.rowPOREZ["SIFRAOPISAPLACANJAPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 10));
                this.rowPOREZ["OPISPLACANJAPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 11));
                this.sMode20 = this.Gx_mode;
                this.Gx_mode = StatementType.Select;
                this.Gx_mode = this.sMode20;
            }
            else
            {
                this.RcdFound20 = 0;
            }
            reader.Close();
        }

        public virtual IDataParameter[] GetFillParameters()
        {
            if (this.fillDataParameters == null)
            {
                DbParameter parameter = DbProviderFactories.GetFactory("System.Data.SqlClient").CreateParameter();
                parameter.ParameterName = "IDPOREZ";
                parameter.DbType = DbType.Int32;
                this.fillDataParameters = new DbParameter[] { parameter };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount()
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmPOREZSelect1 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [POREZ] WITH (NOLOCK) ", false);
            this.POREZSelect1 = this.cmPOREZSelect1.FetchData();
            if (this.POREZSelect1.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.POREZSelect1.GetInt32(0);
            }
            this.POREZSelect1.Close();
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
            this.RcdFound20 = 0;
            this.scmdbuf = "";
            this.recordCount = 0;
            this._Gxremove = false;
            this.m__NAZIVPOREZOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__POREZMJESECNOOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__STOPAPOREZAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__MOPOREZOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__POPOREZOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__MZPOREZOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__PZPOREZOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__PRIMATELJPOREZ1Original = RuntimeHelpers.GetObjectValue(new object());
            this.m__PRIMATELJPOREZ2Original = RuntimeHelpers.GetObjectValue(new object());
            this.m__SIFRAOPISAPLACANJAPOREZOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__OPISPLACANJAPOREZOriginal = RuntimeHelpers.GetObjectValue(new object());
            this._Condition = false;
            this.m_WhereString = "";
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void InitializeMembers()
        {
            this.POREZSet = new POREZDataSet();
            this.Initialize();
            this.dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        }

        private void InsertPorez()
        {
            this.CheckOptimisticConcurrencyPorez();
            this.AfterConfirmPorez();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [POREZ] ([IDPOREZ], [NAZIVPOREZ], [POREZMJESECNO], [STOPAPOREZA], [MOPOREZ], [POPOREZ], [MZPOREZ], [PZPOREZ], [PRIMATELJPOREZ1], [PRIMATELJPOREZ2], [SIFRAOPISAPLACANJAPOREZ], [OPISPLACANJAPOREZ]) VALUES (@IDPOREZ, @NAZIVPOREZ, @POREZMJESECNO, @STOPAPOREZA, @MOPOREZ, @POPOREZ, @MZPOREZ, @PZPOREZ, @PRIMATELJPOREZ1, @PRIMATELJPOREZ2, @SIFRAOPISAPLACANJAPOREZ, @OPISPLACANJAPOREZ)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDPOREZ", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVPOREZ", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@POREZMJESECNO", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@STOPAPOREZA", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MOPOREZ", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@POPOREZ", DbType.String, 0x16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MZPOREZ", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PZPOREZ", DbType.String, 0x16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRIMATELJPOREZ1", DbType.String, 20));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRIMATELJPOREZ2", DbType.String, 20));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SIFRAOPISAPLACANJAPOREZ", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OPISPLACANJAPOREZ", DbType.String, 0x24));
            }
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowPOREZ["IDPOREZ"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowPOREZ["NAZIVPOREZ"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowPOREZ["POREZMJESECNO"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowPOREZ["STOPAPOREZA"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowPOREZ["MOPOREZ"]));
            command.SetParameter(5, RuntimeHelpers.GetObjectValue(this.rowPOREZ["POPOREZ"]));
            command.SetParameter(6, RuntimeHelpers.GetObjectValue(this.rowPOREZ["MZPOREZ"]));
            command.SetParameter(7, RuntimeHelpers.GetObjectValue(this.rowPOREZ["PZPOREZ"]));
            command.SetParameter(8, RuntimeHelpers.GetObjectValue(this.rowPOREZ["PRIMATELJPOREZ1"]));
            command.SetParameter(9, RuntimeHelpers.GetObjectValue(this.rowPOREZ["PRIMATELJPOREZ2"]));
            command.SetParameter(10, RuntimeHelpers.GetObjectValue(this.rowPOREZ["SIFRAOPISAPLACANJAPOREZ"]));
            command.SetParameter(11, RuntimeHelpers.GetObjectValue(this.rowPOREZ["OPISPLACANJAPOREZ"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new POREZDuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            this.OnPOREZUpdated(new POREZEventArgs(this.rowPOREZ, StatementType.Insert));
        }

        private void LoadByIDPOREZ(int startRow, int maxRows)
        {
            bool enforceConstraints = this.POREZSet.EnforceConstraints;
            this.POREZSet.POREZ.BeginLoadData();
            this.ScanByIDPOREZ(startRow, maxRows);
            this.POREZSet.POREZ.EndLoadData();
            this.POREZSet.EnforceConstraints = enforceConstraints;
            if (this.POREZSet.POREZ.Count > 0)
            {
                this.rowPOREZ = this.POREZSet.POREZ[this.POREZSet.POREZ.Count - 1];
            }
        }

        private void LoadChildPorez(int startRow, int maxRows)
        {
            this.CreateNewRowPorez();
            bool enforceConstraints = this.POREZSet.EnforceConstraints;
            this.POREZSet.POREZ.BeginLoadData();
            this.ScanStartPorez(startRow, maxRows);
            this.POREZSet.POREZ.EndLoadData();
            this.POREZSet.EnforceConstraints = enforceConstraints;
        }

        private void LoadDataPorez(int maxRows)
        {
            int num = 0;
            if (this.RcdFound20 != 0)
            {
                this.ScanLoadPorez();
                while ((this.RcdFound20 != 0) && (num != maxRows))
                {
                    num++;
                    this.LoadRowPorez();
                    this.CreateNewRowPorez();
                    this.ScanNextPorez();
                }
            }
            if (num > 0)
            {
                this.RcdFound20 = 1;
            }
            this.ScanEndPorez();
            if (this.POREZSet.POREZ.Count > 0)
            {
                this.rowPOREZ = this.POREZSet.POREZ[this.POREZSet.POREZ.Count - 1];
            }
        }

        private void LoadRowPorez()
        {
            this.AddRowPorez();
        }

        private void OnPOREZUpdated(POREZEventArgs e)
        {
            if (this.POREZUpdated != null)
            {
                POREZUpdateEventHandler pOREZUpdatedEvent = this.POREZUpdated;
                if (pOREZUpdatedEvent != null)
                {
                    pOREZUpdatedEvent(this, e);
                }
            }
        }

        private void OnPOREZUpdating(POREZEventArgs e)
        {
            if (this.POREZUpdating != null)
            {
                POREZUpdateEventHandler pOREZUpdatingEvent = this.POREZUpdating;
                if (pOREZUpdatingEvent != null)
                {
                    pOREZUpdatingEvent(this, e);
                }
            }
        }

        private void ReadRowPorez()
        {
            this.Gx_mode = Mode.FromRowState(this.rowPOREZ.RowState);
            if (this.rowPOREZ.RowState != DataRowState.Added)
            {
                this.m__NAZIVPOREZOriginal = RuntimeHelpers.GetObjectValue(this.rowPOREZ["NAZIVPOREZ", DataRowVersion.Original]);
                this.m__POREZMJESECNOOriginal = RuntimeHelpers.GetObjectValue(this.rowPOREZ["POREZMJESECNO", DataRowVersion.Original]);
                this.m__STOPAPOREZAOriginal = RuntimeHelpers.GetObjectValue(this.rowPOREZ["STOPAPOREZA", DataRowVersion.Original]);
                this.m__MOPOREZOriginal = RuntimeHelpers.GetObjectValue(this.rowPOREZ["MOPOREZ", DataRowVersion.Original]);
                this.m__POPOREZOriginal = RuntimeHelpers.GetObjectValue(this.rowPOREZ["POPOREZ", DataRowVersion.Original]);
                this.m__MZPOREZOriginal = RuntimeHelpers.GetObjectValue(this.rowPOREZ["MZPOREZ", DataRowVersion.Original]);
                this.m__PZPOREZOriginal = RuntimeHelpers.GetObjectValue(this.rowPOREZ["PZPOREZ", DataRowVersion.Original]);
                this.m__PRIMATELJPOREZ1Original = RuntimeHelpers.GetObjectValue(this.rowPOREZ["PRIMATELJPOREZ1", DataRowVersion.Original]);
                this.m__PRIMATELJPOREZ2Original = RuntimeHelpers.GetObjectValue(this.rowPOREZ["PRIMATELJPOREZ2", DataRowVersion.Original]);
                this.m__SIFRAOPISAPLACANJAPOREZOriginal = RuntimeHelpers.GetObjectValue(this.rowPOREZ["SIFRAOPISAPLACANJAPOREZ", DataRowVersion.Original]);
                this.m__OPISPLACANJAPOREZOriginal = RuntimeHelpers.GetObjectValue(this.rowPOREZ["OPISPLACANJAPOREZ", DataRowVersion.Original]);
            }
            else
            {
                this.m__NAZIVPOREZOriginal = RuntimeHelpers.GetObjectValue(this.rowPOREZ["NAZIVPOREZ"]);
                this.m__POREZMJESECNOOriginal = RuntimeHelpers.GetObjectValue(this.rowPOREZ["POREZMJESECNO"]);
                this.m__STOPAPOREZAOriginal = RuntimeHelpers.GetObjectValue(this.rowPOREZ["STOPAPOREZA"]);
                this.m__MOPOREZOriginal = RuntimeHelpers.GetObjectValue(this.rowPOREZ["MOPOREZ"]);
                this.m__POPOREZOriginal = RuntimeHelpers.GetObjectValue(this.rowPOREZ["POPOREZ"]);
                this.m__MZPOREZOriginal = RuntimeHelpers.GetObjectValue(this.rowPOREZ["MZPOREZ"]);
                this.m__PZPOREZOriginal = RuntimeHelpers.GetObjectValue(this.rowPOREZ["PZPOREZ"]);
                this.m__PRIMATELJPOREZ1Original = RuntimeHelpers.GetObjectValue(this.rowPOREZ["PRIMATELJPOREZ1"]);
                this.m__PRIMATELJPOREZ2Original = RuntimeHelpers.GetObjectValue(this.rowPOREZ["PRIMATELJPOREZ2"]);
                this.m__SIFRAOPISAPLACANJAPOREZOriginal = RuntimeHelpers.GetObjectValue(this.rowPOREZ["SIFRAOPISAPLACANJAPOREZ"]);
                this.m__OPISPLACANJAPOREZOriginal = RuntimeHelpers.GetObjectValue(this.rowPOREZ["OPISPLACANJAPOREZ"]);
            }
            this._Gxremove = this.rowPOREZ.RowState == DataRowState.Deleted;
            if (this._Gxremove)
            {
                this.rowPOREZ = (POREZDataSet.POREZRow) DataSetUtil.CloneOriginalDataRow(this.rowPOREZ);
            }
        }

        private void ScanByIDPOREZ(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[IDPOREZ] = @IDPOREZ";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString20 + "  FROM [POREZ] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDPOREZ]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString20, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDPOREZ] ) AS DK_PAGENUM   FROM [POREZ] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString20 + " FROM [POREZ] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDPOREZ] ";
            }
            this.cmPOREZSelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmPOREZSelect4.IDbCommand.Parameters.Count == 0)
            {
                this.cmPOREZSelect4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDPOREZ", DbType.Int32));
            }
            this.cmPOREZSelect4.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowPOREZ["IDPOREZ"]));
            this.POREZSelect4 = this.cmPOREZSelect4.FetchData();
            this.RcdFound20 = 0;
            this.ScanLoadPorez();
            this.LoadDataPorez(maxRows);
        }

        private void ScanEndPorez()
        {
            this.POREZSelect4.Close();
        }

        private void ScanLoadPorez()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmPOREZSelect4.HasMoreRows)
            {
                this.RcdFound20 = 1;
                this.rowPOREZ["IDPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.POREZSelect4, 0));
                this.rowPOREZ["NAZIVPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.POREZSelect4, 1));
                this.rowPOREZ["POREZMJESECNO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.POREZSelect4, 2));
                this.rowPOREZ["STOPAPOREZA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.POREZSelect4, 3));
                this.rowPOREZ["MOPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.POREZSelect4, 4));
                this.rowPOREZ["POPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.POREZSelect4, 5));
                this.rowPOREZ["MZPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.POREZSelect4, 6));
                this.rowPOREZ["PZPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.POREZSelect4, 7));
                this.rowPOREZ["PRIMATELJPOREZ1"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.POREZSelect4, 8));
                this.rowPOREZ["PRIMATELJPOREZ2"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.POREZSelect4, 9));
                this.rowPOREZ["SIFRAOPISAPLACANJAPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.POREZSelect4, 10));
                this.rowPOREZ["OPISPLACANJAPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.POREZSelect4, 11));
            }
        }

        private void ScanNextPorez()
        {
            this.cmPOREZSelect4.HasMoreRows = this.POREZSelect4.Read();
            this.RcdFound20 = 0;
            this.ScanLoadPorez();
        }

        private void ScanStartPorez(int startRow, int maxRows)
        {
            this.m_WhereString = "";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString20 + "  FROM [POREZ] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDPOREZ]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString20, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDPOREZ] ) AS DK_PAGENUM   FROM [POREZ] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString20 + " FROM [POREZ] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDPOREZ] ";
            }
            this.cmPOREZSelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            this.POREZSelect4 = this.cmPOREZSelect4.FetchData();
            this.RcdFound20 = 0;
            this.ScanLoadPorez();
            this.LoadDataPorez(maxRows);
        }

        public virtual int Update(DataSet dataSet)
        {
            this.InitializeMembers();
            this.POREZSet = (POREZDataSet) dataSet;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            if (this.POREZSet == null)
            {
                throw new ArgumentException(this.resourceManager.GetString("nulldset"));
            }
            try
            {
                IEnumerator enumerator = null;
                this.connDefault.BeginTransaction();
                try
                {
                    enumerator = this.POREZSet.POREZ.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        POREZDataSet.POREZRow current = (POREZDataSet.POREZRow) enumerator.Current;
                        this.rowPOREZ = current;
                        if (Helpers.IsRowChanged(this.rowPOREZ))
                        {
                            this.ReadRowPorez();
                            if (this.rowPOREZ.RowState == DataRowState.Added)
                            {
                                this.InsertPorez();
                            }
                            else
                            {
                                if (this._Gxremove)
                                {
                                    this.Delete();
                                    continue;
                                }
                                this.UpdatePorez();
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

        private void UpdatePorez()
        {
            this.CheckOptimisticConcurrencyPorez();
            this.AfterConfirmPorez();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [POREZ] SET [NAZIVPOREZ]=@NAZIVPOREZ, [POREZMJESECNO]=@POREZMJESECNO, [STOPAPOREZA]=@STOPAPOREZA, [MOPOREZ]=@MOPOREZ, [POPOREZ]=@POPOREZ, [MZPOREZ]=@MZPOREZ, [PZPOREZ]=@PZPOREZ, [PRIMATELJPOREZ1]=@PRIMATELJPOREZ1, [PRIMATELJPOREZ2]=@PRIMATELJPOREZ2, [SIFRAOPISAPLACANJAPOREZ]=@SIFRAOPISAPLACANJAPOREZ, [OPISPLACANJAPOREZ]=@OPISPLACANJAPOREZ  WHERE [IDPOREZ] = @IDPOREZ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVPOREZ", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@POREZMJESECNO", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@STOPAPOREZA", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MOPOREZ", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@POPOREZ", DbType.String, 0x16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MZPOREZ", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PZPOREZ", DbType.String, 0x16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRIMATELJPOREZ1", DbType.String, 20));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRIMATELJPOREZ2", DbType.String, 20));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SIFRAOPISAPLACANJAPOREZ", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OPISPLACANJAPOREZ", DbType.String, 0x24));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDPOREZ", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowPOREZ["NAZIVPOREZ"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowPOREZ["POREZMJESECNO"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowPOREZ["STOPAPOREZA"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowPOREZ["MOPOREZ"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowPOREZ["POPOREZ"]));
            command.SetParameter(5, RuntimeHelpers.GetObjectValue(this.rowPOREZ["MZPOREZ"]));
            command.SetParameter(6, RuntimeHelpers.GetObjectValue(this.rowPOREZ["PZPOREZ"]));
            command.SetParameter(7, RuntimeHelpers.GetObjectValue(this.rowPOREZ["PRIMATELJPOREZ1"]));
            command.SetParameter(8, RuntimeHelpers.GetObjectValue(this.rowPOREZ["PRIMATELJPOREZ2"]));
            command.SetParameter(9, RuntimeHelpers.GetObjectValue(this.rowPOREZ["SIFRAOPISAPLACANJAPOREZ"]));
            command.SetParameter(10, RuntimeHelpers.GetObjectValue(this.rowPOREZ["OPISPLACANJAPOREZ"]));
            command.SetParameter(11, RuntimeHelpers.GetObjectValue(this.rowPOREZ["IDPOREZ"]));
            command.ExecuteStmt();
            new porezupdateredundancy(ref this.dsDefault).execute(this.rowPOREZ.IDPOREZ);
            this.OnPOREZUpdated(new POREZEventArgs(this.rowPOREZ, StatementType.Update));
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
        public class DDKATEGORIJALevel1InvalidDeleteException : InvalidDeleteException
        {
            public DDKATEGORIJALevel1InvalidDeleteException()
            {
            }

            public DDKATEGORIJALevel1InvalidDeleteException(string message) : base(message)
            {
            }

            protected DDKATEGORIJALevel1InvalidDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public DDKATEGORIJALevel1InvalidDeleteException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class DDOBRACUNRadniciPoreziInvalidDeleteException : InvalidDeleteException
        {
            public DDOBRACUNRadniciPoreziInvalidDeleteException()
            {
            }

            public DDOBRACUNRadniciPoreziInvalidDeleteException(string message) : base(message)
            {
            }

            protected DDOBRACUNRadniciPoreziInvalidDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public DDOBRACUNRadniciPoreziInvalidDeleteException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class ObracunPoreziInvalidDeleteException : InvalidDeleteException
        {
            public ObracunPoreziInvalidDeleteException()
            {
            }

            public ObracunPoreziInvalidDeleteException(string message) : base(message)
            {
            }

            protected ObracunPoreziInvalidDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public ObracunPoreziInvalidDeleteException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class POREZDataChangedException : DataChangedException
        {
            public POREZDataChangedException()
            {
            }

            public POREZDataChangedException(string message) : base(message)
            {
            }

            protected POREZDataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public POREZDataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class POREZDataLockedException : DataLockedException
        {
            public POREZDataLockedException()
            {
            }

            public POREZDataLockedException(string message) : base(message)
            {
            }

            protected POREZDataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public POREZDataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class POREZDuplicateKeyException : DuplicateKeyException
        {
            public POREZDuplicateKeyException()
            {
            }

            public POREZDuplicateKeyException(string message) : base(message)
            {
            }

            protected POREZDuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public POREZDuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class POREZEventArgs : EventArgs
        {
            private POREZDataSet.POREZRow m_dataRow;
            private System.Data.StatementType m_statementType;

            public POREZEventArgs(POREZDataSet.POREZRow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public POREZDataSet.POREZRow Row
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
        public class POREZNotFoundException : DataNotFoundException
        {
            public POREZNotFoundException()
            {
            }

            public POREZNotFoundException(string message) : base(message)
            {
            }

            protected POREZNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public POREZNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public delegate void POREZUpdateEventHandler(object sender, POREZDataAdapter.POREZEventArgs e);

        [Serializable]
        public class SKUPPOREZAIDOPRINOSA1InvalidDeleteException : InvalidDeleteException
        {
            public SKUPPOREZAIDOPRINOSA1InvalidDeleteException()
            {
            }

            public SKUPPOREZAIDOPRINOSA1InvalidDeleteException(string message) : base(message)
            {
            }

            protected SKUPPOREZAIDOPRINOSA1InvalidDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public SKUPPOREZAIDOPRINOSA1InvalidDeleteException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }
    }
}

